using OpenCvSharp;
using OpenCvSharp.Extensions;
using ProcessForge.ApplicationLogic;
using ProcessForge.FindWindowLogic;
using ProcessForge.InputWindowLogic;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace ProcessForge.AutoLoginPatternLogic
{
    public class Case
    {
        string storageDirectory = string.Empty;
        string configFilePath = string.Empty;
        DataLoginFormat accountData;
        public Case(string storageDirectory, string configFilePath, DataLoginFormat AccountData)
        {
            this.storageDirectory = storageDirectory;
            this.configFilePath = configFilePath;
            this.accountData = AccountData;
        }
        //public int StepIndex { get; set; }
        //public string StepTitle { get; set; } = string.Empty;
        //public string TemplateName { get; set; } = string.Empty;
        //public string ImagePath { get; set; } = string.Empty;
        //public int TargetX { get; set; }
        //public int TargetY { get; set; }
        //public int ClickTypeIndex { get; set; } = 0;
        //public bool UseRelativeOffset { get; set; } = true;

        public void Case_1(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            // InputWindowLogic.InputWindow.ClickAt(maxLocation.X + template.Width / 2, maxLocation.Y + template.Height / 2);
            if (matchScore >= 0.9)
            {
            SendKeys.SendWait(accountData.username);
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait(accountData.password);
            SendKeys.SendWait("{ENTER}");
            }
        }
        public void Case_2(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            if (matchScore >= 0.9)
            {
            foreach (var action in step.Actions)
            {
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
                Thread.Sleep(500); // Wait for 0.5 seconds before performing the next action
            }
            }
            Thread.Sleep(500);
        }
        public void Case_3(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            Thread.Sleep(2000); // Wait for 2 seconds before performing the next action
            if (matchScore >= 0.9)
            {
            foreach (var action in step.Actions)
            {
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
                Thread.Sleep(500); // Wait for 0.5 seconds before performing the next action
            }
            }
            Thread.Sleep(500);
        }
        public void Case_4(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            Thread.Sleep(500);
            if (matchScore >= 0.9)
            {
            SendKeys.SendWait(accountData.secondPassword == "NotUsingSecondPassword" ? string.Empty : accountData.secondPassword);
            foreach (var action in step.Actions)
            {
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
                Thread.Sleep(500); // Wait for 0.5 seconds before performing the next action
            }
            }
            Thread.Sleep(500);
        }
        public void Case_5(Rectangle windowSize, TargetStepModel step, List<TargetStepModel> allSteps)
        {
            DetectImageMain(windowSize, step, allSteps, out OpenCvSharp.Point matchLocation, out double matchScore);
            Thread.Sleep(1500); // Wait for 3 seconds before performing the next action
            if (matchScore >= 0.9)
            {
                foreach (var action in step.Actions)
                {
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
                    Thread.Sleep(500); // Wait for 0.5 seconds before performing the next action
                }
            }
        }

        public void SubCase(Rectangle windowSize, List<TargetStepModel> allSteps)
        {
            foreach (var step in allSteps)
            {
                if (step.IsSubStep)
                {
                    DetectImageSub(windowSize, step, out OpenCvSharp.Point matchLocation, out double matchScore);
                    if (matchScore >= 0.9)
                    {
                        foreach (var action in step.Actions)
                        {
                            if (action.ActionType == "Mouse")
                            {
                                if (action.UseRelativeOffset == true)
                                {
                                    if (action.X.HasValue && action.Y.HasValue)
                                    {
                                        InputWindowLogic.InputWindow.ClickAt(matchLocation.X + (action.X ?? 0), matchLocation.Y + (action.Y ?? 0));
                                            MessageBox.Show("match location + action x : " + (matchLocation.X + action.X ?? 0).ToString() + "\n" +  "match location + action y : " + (matchLocation.Y + action.Y ?? 0).ToString() + "\n" + "match score : " + matchScore.ToString() + "\n" + "match location: " + matchLocation.ToString() + "\n" + "action location: " + action.X.ToString() + ", " + action.Y.ToString());
                                        }
                                }
                                else
                                {
                                    if (action.X.HasValue && action.Y.HasValue)
                                    {
                                        InputWindowLogic.InputWindow.ClickAt(action.X ?? 0, action.Y ?? 0);
                                            //MessageBox.Show((action.X ?? 0).ToString(), (action.Y ?? 0).ToString());
                                    }
                                }
                            }
                            else if (action.ActionType == "Keyboard")
                            {
                                SendKeys.SendWait(action.Word ?? string.Empty);
                            }
                            Thread.Sleep(1000); // Wait for 2 seconds before performing the next action
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
            string templatePath = step.ImagePath;

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Template image not found: " + templatePath);
                matchLocation = new OpenCvSharp.Point();
                matchScore = 0;
                return;
            }

            using Bitmap captureWindow = new Bitmap(windowSize.Width, windowSize.Height);
            using Mat template = Cv2.ImRead(templatePath, ImreadModes.Color);

            while (true)
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

                    //MessageBox.Show(
                    //    $"Best Match:\n" +
                    //    $"X: {maxLocation.X}\n" +
                    //    $"Y: {maxLocation.Y}\n" +
                    //    $"Score: {maxValue}" +
                    //    $"Score: {minValue}"
                    //);

                    // for center
                    if (maxValue >= 0.9)
                    {
                        matchLocation = maxLocation;
                        matchScore = maxValue;
                        break;
                    }
                    else
                    {
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
                        Thread.Sleep(1000); // Wait for 1 second before trying again
                    }
                }
            }
        }
        public void DetectImageSub(Rectangle windowSize, TargetStepModel step, out OpenCvSharp.Point matchLocation, out double matchScore)
        {
            string templatePath = step.ImagePath;

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Template image not found: " + templatePath);
                matchLocation = new OpenCvSharp.Point();
                matchScore = 0;
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

                    //MessageBox.Show(
                    //    $"Best Match:\n" +
                    //    $"X: {maxLocation.X}\n" +
                    //    $"Y: {maxLocation.Y}\n" +
                    //    $"Score: {maxValue}" +
                    //    $"Score: {minValue}"
                    //);

                    // for center
                    if (maxValue >= 0.9)
                    {
                        matchLocation = maxLocation;
                        matchScore = maxValue;
                    }
                    else
                    {
                        matchLocation = new OpenCvSharp.Point();
                        matchScore = 0;
                    }
                }
        }
    }
}
