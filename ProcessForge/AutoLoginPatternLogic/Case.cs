using OpenCvSharp;
using OpenCvSharp.Extensions;
using ProcessForge.ApplicationLogic;
using ProcessForge.FindWindowLogic;
using ProcessForge.InputWindowLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ProcessForge.AutoLoginPatternLogic
{
    public class Case
    {
        string storageDirectory = string.Empty;
        string configFilePath = string.Empty;
        DataLoginFormat accountData;
        CancellationToken cancellationToken;

        public Case(string storageDirectory, string configFilePath, DataLoginFormat AccountData, CancellationToken cancellationToken = default)
        {
            this.storageDirectory = storageDirectory;
            this.configFilePath = configFilePath;
            this.accountData = AccountData;
            this.cancellationToken = cancellationToken;
        }

        public Case(string storageDirectory, string configFilePath, DataLoginFormat AccountData)
            : this(storageDirectory, configFilePath, AccountData, CancellationToken.None)
        {
        }

        private bool SleepOrCancel(int milliseconds)
        {
            if (cancellationToken.IsCancellationRequested) return true;
            return cancellationToken.WaitHandle.WaitOne(milliseconds);
        }

        public static string ResolveVariables(string input, DataLoginFormat? account)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (account == null) return input;

            string secPass = (account.secondPassword == "NotUsingSecondPassword" || account.secondPassword == null)
                ? string.Empty
                : account.secondPassword;

            return input
                .Replace("{USERNAME}", account.username ?? string.Empty, StringComparison.OrdinalIgnoreCase)
                .Replace("{PASSWORD}", account.password ?? string.Empty, StringComparison.OrdinalIgnoreCase)
                .Replace("{SECONDPASSWORD}", secPass, StringComparison.OrdinalIgnoreCase)
                .Replace("{SECONDPASS}", secPass, StringComparison.OrdinalIgnoreCase)
                .Replace("{PIN}", secPass, StringComparison.OrdinalIgnoreCase)
                .Replace("{NICKNAME}", account.nickname ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        public StepExecutionResult ExecuteStepActions(TargetStepModel step, OpenCvSharp.Point matchLocation, Rectangle windowSize = default)
        {
            if (step.Actions == null || step.Actions.Count == 0) return StepExecutionResult.Continue();

            int originX = windowSize.IsEmpty ? 0 : windowSize.X;
            int originY = windowSize.IsEmpty ? 0 : windowSize.Y;

            foreach (var action in step.Actions)
            {
                if (cancellationToken.IsCancellationRequested) return StepExecutionResult.Break();

                if (action.ActionType == "Break")
                {
                    return StepExecutionResult.Break();
                }
                else if (action.ActionType == "Goto")
                {
                    return StepExecutionResult.Goto(action.GotoStepTarget ?? string.Empty);
                }
                else if (action.ActionType == "Mouse")
                {
                    int clickType = action.ClickTypeIndex ?? 0;
                    if (action.UseRelativeOffset ?? true)
                    {
                        if (action.X.HasValue && action.Y.HasValue)
                        {
                            InputWindowLogic.InputWindow.ClickAt(originX + matchLocation.X + (action.X ?? 0), originY + matchLocation.Y + (action.Y ?? 0), clickType);
                        }
                    }
                    else
                    {
                        if (action.X.HasValue && action.Y.HasValue)
                        {
                            InputWindowLogic.InputWindow.ClickAt(action.X ?? 0, action.Y ?? 0, clickType);
                        }
                    }
                }
                else if (action.ActionType == "Keyboard")
                {
                    string resolvedWord = ResolveVariables(action.Word ?? string.Empty, accountData);
                    if (!string.IsNullOrEmpty(resolvedWord))
                    {
                        SendKeys.SendWait(resolvedWord);
                    }
                }
                else if (action.ActionType == "Delay")
                {
                    int delay = action.DelayMs ?? 500;
                    if (SleepOrCancel(delay)) return StepExecutionResult.Break();
                    continue;
                }
                else if (action.ActionType == "InputBox")
                {
                    string prompt = string.IsNullOrWhiteSpace(action.PromptMessage) ? "Enter custom input:" : action.PromptMessage;
                    string userInput = PromptDialog.Show(prompt);
                    if (cancellationToken.IsCancellationRequested) return StepExecutionResult.Break();

                    if (!string.IsNullOrEmpty(userInput))
                    {
                        if (SleepOrCancel(200)) return StepExecutionResult.Break();
                        SendKeys.SendWait(userInput);
                    }
                }

                if (SleepOrCancel(500)) return StepExecutionResult.Break();
            }

            return StepExecutionResult.Continue();
        }

        public StepExecutionResult ExecuteCase(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            if (cancellationToken.IsCancellationRequested) return StepExecutionResult.Break();
            var detectRes = DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            if (detectRes.Status != StepActionResult.Continue) return detectRes;
            if (cancellationToken.IsCancellationRequested) return StepExecutionResult.Break();

            if (matchScore >= 0.9)
            {
                // Fallback for Step 1 if actions list is empty: default to credentials input
                if (step.StepIndex == 0 && (step.Actions == null || step.Actions.Count == 0))
                {
                    SendKeys.SendWait(accountData.username ?? string.Empty);
                    if (cancellationToken.IsCancellationRequested) return StepExecutionResult.Break();
                    SendKeys.SendWait("{TAB}");
                    if (cancellationToken.IsCancellationRequested) return StepExecutionResult.Break();
                    SendKeys.SendWait(accountData.password ?? string.Empty);
                    if (cancellationToken.IsCancellationRequested) return StepExecutionResult.Break();
                    SendKeys.SendWait("{ENTER}");
                }
                // Fallback for Step 4 (Input Pin) if actions list is empty: input second password
                else if (step.StepIndex == 3 && (step.Actions == null || step.Actions.Count == 0))
                {
                    string pin = (accountData.secondPassword == "NotUsingSecondPassword" || accountData.secondPassword == null) ? string.Empty : accountData.secondPassword;
                    if (!string.IsNullOrEmpty(pin))
                    {
                        SendKeys.SendWait(pin);
                    }
                }

                var actionRes = ExecuteStepActions(step, matchLocation, windowSize);
                if (actionRes.Status != StepActionResult.Continue) return actionRes;
            }
            SleepOrCancel(500);
            return StepExecutionResult.Continue();
        }

        public StepExecutionResult Case_1(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps) => ExecuteCase(windowSize, step, allSteps);
        public StepExecutionResult Case_2(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps) => ExecuteCase(windowSize, step, allSteps);
        public StepExecutionResult Case_3(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps) => ExecuteCase(windowSize, step, allSteps);
        public StepExecutionResult Case_4(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps) => ExecuteCase(windowSize, step, allSteps);
        public StepExecutionResult Case_5(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps) => ExecuteCase(windowSize, step, allSteps);
        public StepExecutionResult Case_Generic(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps) => ExecuteCase(windowSize, step, allSteps);

        public StepExecutionResult SubCase(Rectangle windowSize, List<TargetStepModel> allSteps)
        {
            foreach (var step in allSteps)
            {
                if (cancellationToken.IsCancellationRequested) return StepExecutionResult.Break();
                if (step.IsSubStep)
                {
                    DetectImageSub(windowSize, step, out OpenCvSharp.Point matchLocation, out double matchScore);
                    if (matchScore >= 0.9)
                    {
                        var res = ExecuteStepActions(step, matchLocation, windowSize);
                        if (res.Status != StepActionResult.Continue)
                        {
                            return res;
                        }
                        break;
                    }
                }
            }
            return StepExecutionResult.Continue();
        }

        public StepExecutionResult DetectImageMain(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps, out OpenCvSharp.Point matchLocation, out double matchScore)
        {
            matchLocation = new OpenCvSharp.Point();
            matchScore = 0;

            string templatePath = step.ImagePath;

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Template image not found: " + templatePath);
                return StepExecutionResult.Break();
            }

            using Bitmap captureWindow = new Bitmap(windowSize.Width, windowSize.Height);
            using Mat template = Cv2.ImRead(templatePath, ImreadModes.Color);

            while (!cancellationToken.IsCancellationRequested)
            {
                using (Graphics g = Graphics.FromImage(captureWindow))
                {
                    g.CopyFromScreen(windowSize.Location, System.Drawing.Point.Empty, windowSize.Size);
                }

                using (Mat screen = BitmapConverter.ToMat(captureWindow))
                using (Mat result = new Mat())
                {
                    Cv2.CvtColor(
                            screen,
                            screen,
                            ColorConversionCodes.BGRA2BGR
                        );

                    Cv2.MatchTemplate(
                        screen,
                        template,
                        result,
                        TemplateMatchModes.CCoeffNormed
                    );

                    Cv2.MinMaxLoc(
                        result,
                        out double minValue,
                        out double maxValue,
                        out OpenCvSharp.Point minLocation,
                        out OpenCvSharp.Point maxLocation
                    );

                    if (maxValue >= 0.9)
                    {
                        matchLocation = maxLocation;
                        matchScore = maxValue;
                        return StepExecutionResult.Continue();
                    }
                    else
                    {
                        if (cancellationToken.IsCancellationRequested) return StepExecutionResult.Break();

                        if (step.StepIndex == 0)
                        {
                            // login scene - ensure window has focus
                            InputWindowLogic.InputWindow.ClickAt(windowSize.X + 50, windowSize.Y + 50);
                        }

                        var subResult = SubCase(windowSize, allSteps);
                        if (subResult.Status != StepActionResult.Continue)
                        {
                            return subResult;
                        }
                        if (SleepOrCancel(1000)) return StepExecutionResult.Break();
                    }
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                matchLocation = new OpenCvSharp.Point();
                matchScore = 0;
                return StepExecutionResult.Break();
            }

            return StepExecutionResult.Continue();
        }

        public void DetectImageSub(Rectangle windowSize, TargetStepModel step, out OpenCvSharp.Point matchLocation, out double matchScore)
        {
            matchLocation = new OpenCvSharp.Point();
            matchScore = 0;

            if (cancellationToken.IsCancellationRequested) return;

            string templatePath = step.ImagePath;

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Template image not found: " + templatePath);
                return;
            }

            using Bitmap captureWindow = new Bitmap(windowSize.Width, windowSize.Height);
            using Mat template = Cv2.ImRead(templatePath, ImreadModes.Color);

            using (Graphics g = Graphics.FromImage(captureWindow))
            {
                g.CopyFromScreen(windowSize.Location, System.Drawing.Point.Empty, windowSize.Size);
            }

            using (Mat screen = BitmapConverter.ToMat(captureWindow))
            using (Mat result = new Mat())
            {
                Cv2.CvtColor(
                        screen,
                        screen,
                        ColorConversionCodes.BGRA2BGR
                    );

                Cv2.MatchTemplate(
                    screen,
                    template,
                    result,
                    TemplateMatchModes.CCoeffNormed
                );

                Cv2.MinMaxLoc(
                    result,
                    out double minValue,
                    out double maxValue,
                    out OpenCvSharp.Point minLocation,
                    out OpenCvSharp.Point maxLocation
                );

                if (maxValue >= 0.9)
                {
                    matchLocation = maxLocation;
                    matchScore = maxValue;
                }
            }
        }
    }
}
