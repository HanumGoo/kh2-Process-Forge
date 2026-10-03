using OpenCvSharp;
using OpenCvSharp.Extensions;
using ProcessForge.ApplicationLogic;
using ProcessForge.FindWindowLogic;
using ProcessForge.InputWindowLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Text;
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

        public void Case_1(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            if (cancellationToken.IsCancellationRequested) return;
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            if (cancellationToken.IsCancellationRequested) return;
            if (matchScore >= 0.9)
            {
                SendKeys.SendWait(accountData.username);
                if (cancellationToken.IsCancellationRequested) return;
                SendKeys.SendWait("{TAB}");
                if (cancellationToken.IsCancellationRequested) return;
                SendKeys.SendWait(accountData.password);
                if (cancellationToken.IsCancellationRequested) return;
                SendKeys.SendWait("{ENTER}");
            }
        }

        public void Case_2(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            if (cancellationToken.IsCancellationRequested) return;
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            if (cancellationToken.IsCancellationRequested) return;
            if (matchScore >= 0.9)
            {
                foreach (var action in step.Actions)
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    if (action.ActionType == "Mouse")
                    {
                        if (action.UseRelativeOffset == true)
                        {
                            if (action.X.HasValue && action.Y.HasValue)
                            {
                                InputWindowLogic.InputWindow.ClickAt(matchLocation.X + (action.X ?? 0), matchLocation.Y + (action.Y ?? 0));
                            }
                        }
                        else
                        {
                            if (action.X.HasValue && action.Y.HasValue)
                            {
                                InputWindowLogic.InputWindow.ClickAt(action.X ?? 0, action.Y ?? 0);
                            }
                        }
                    }
                    else if (action.ActionType == "Keyboard")
                    {
                        SendKeys.SendWait(action.Word ?? string.Empty);
                    }
                    if (SleepOrCancel(500)) return;
                }
            }
            SleepOrCancel(500);
        }

        public void Case_3(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            if (cancellationToken.IsCancellationRequested) return;
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            if (SleepOrCancel(2000)) return;
            if (matchScore >= 0.9)
            {
                foreach (var action in step.Actions)
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    if (action.ActionType == "Mouse")
                    {
                        if (action.UseRelativeOffset == true)
                        {
                            if (action.X.HasValue && action.Y.HasValue)
                            {
                                InputWindowLogic.InputWindow.ClickAt(matchLocation.X + (action.X ?? 0), matchLocation.Y + (action.Y ?? 0));
                            }
                        }
                        else
                        {
                            if (action.X.HasValue && action.Y.HasValue)
                            {
                                InputWindowLogic.InputWindow.ClickAt(action.X ?? 0, action.Y ?? 0);
                            }
                        }
                    }
                    else if (action.ActionType == "Keyboard")
                    {
                        SendKeys.SendWait(action.Word ?? string.Empty);
                    }
                    if (SleepOrCancel(500)) return;
                }
            }
            SleepOrCancel(500);
        }

        public void Case_4(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            if (cancellationToken.IsCancellationRequested) return;
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            if (SleepOrCancel(500)) return;
            if (matchScore >= 0.9)
            {
                SendKeys.SendWait(accountData.secondPassword == "NotUsingSecondPassword" ? string.Empty : accountData.secondPassword);
                foreach (var action in step.Actions)
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    if (action.ActionType == "Mouse")
                    {
                        if (action.UseRelativeOffset == true)
                        {
                            if (action.X.HasValue && action.Y.HasValue)
                            {
                                InputWindowLogic.InputWindow.ClickAt(matchLocation.X + (action.X ?? 0), matchLocation.Y + (action.Y ?? 0));
                            }
                        }
                        else
                        {
                            if (action.X.HasValue && action.Y.HasValue)
                            {
                                InputWindowLogic.InputWindow.ClickAt(action.X ?? 0, action.Y ?? 0);
                            }
                        }
                    }
                    else if (action.ActionType == "Keyboard")
                    {
                        SendKeys.SendWait(action.Word ?? string.Empty);
                    }
                    if (SleepOrCancel(500)) return;
                }
            }
            SleepOrCancel(500);
        }

        public void Case_5(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            if (cancellationToken.IsCancellationRequested) return;
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            if (SleepOrCancel(1500)) return;
            if (matchScore >= 0.9)
            {
                foreach (var action in step.Actions)
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    if (action.ActionType == "Mouse")
                    {
                        if (action.UseRelativeOffset == true)
                        {
                            if (action.X.HasValue && action.Y.HasValue)
                            {
                                InputWindowLogic.InputWindow.ClickAt(matchLocation.X + (action.X ?? 0), matchLocation.Y + (action.Y ?? 0));
                            }
                        }
                        else
                        {
                            if (action.X.HasValue && action.Y.HasValue)
                            {
                                InputWindowLogic.InputWindow.ClickAt(action.X ?? 0, action.Y ?? 0);
                            }
                        }
                    }
                    else if (action.ActionType == "Keyboard")
                    {
                        SendKeys.SendWait(action.Word ?? string.Empty);
                    }
                    if (SleepOrCancel(500)) return;
                }
            }
        }

        public void SubCase(Rectangle windowSize, List<TargetStepModel> allSteps)
        {
            foreach (var step in allSteps)
            {
                if (cancellationToken.IsCancellationRequested) return;
                if (step.IsSubStep)
                {
                    DetectImageSub(windowSize, step, out OpenCvSharp.Point matchLocation, out double matchScore);
                    if (matchScore >= 0.9)
                    {
                        foreach (var action in step.Actions)
                        {
                            if (cancellationToken.IsCancellationRequested) return;
                            if (action.ActionType == "Mouse")
                            {
                                if (action.UseRelativeOffset == true)
                                {
                                    if (action.X.HasValue && action.Y.HasValue)
                                    {
                                        InputWindowLogic.InputWindow.ClickAt(matchLocation.X + (action.X ?? 0), matchLocation.Y + (action.Y ?? 0));
                                    }
                                }
                                else
                                {
                                    if (action.X.HasValue && action.Y.HasValue)
                                    {
                                        InputWindowLogic.InputWindow.ClickAt(action.X ?? 0, action.Y ?? 0);
                                    }
                                }
                            }
                            else if (action.ActionType == "Keyboard")
                            {
                                SendKeys.SendWait(action.Word ?? string.Empty);
                            }
                            if (SleepOrCancel(1000)) return;
                        }
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public void DetectImageMain(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps, out OpenCvSharp.Point matchLocation, out double matchScore)
        {
            matchLocation = new OpenCvSharp.Point();
            matchScore = 0;

            string templatePath = step.ImagePath;

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Template image not found: " + templatePath);
                return;
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
                        break;
                    }
                    else
                    {
                        if (cancellationToken.IsCancellationRequested) return;

                        switch (step.StepIndex)
                        {
                            case 0:
                                // login scene
                                InputWindowLogic.InputWindow.ClickAt(windowSize.X + 50, windowSize.Y + 50);
                                break;
                            case 1:
                                // choose channel scene
                                break;
                            case 2:
                                // choose character scene
                                break;
                            case 3:
                                // input second password scene
                                break;
                            case 4:
                                // after login scene
                                break;
                            default:
                                MessageBox.Show("Target image not found. Please check the template image.");
                                break;
                        }

                        SubCase(windowSize, allSteps);
                        if (SleepOrCancel(1000)) return;
                    }
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                matchLocation = new OpenCvSharp.Point();
                matchScore = 0;
            }
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
