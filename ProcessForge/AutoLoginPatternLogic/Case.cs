using OpenCvSharp;
using OpenCvSharp.Extensions;
using ProcessForge.ApplicationLogic;
using ProcessForge.FindWindowLogic;
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
        public void Case_1(Rectangle windowSize, TargetStepModel step)
        {
            string templatePath = step.ImagePath;
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
                        SendKeys.SendWait(accountData.username);
                        SendKeys.SendWait("{TAB}");
                        SendKeys.SendWait(accountData.password);
                        SendKeys.SendWait("{ENTER}");
                        // InputWindowLogic.InputWindow.ClickAt(maxLocation.X + template.Width / 2, maxLocation.Y + template.Height / 2);
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000); // Wait for 1 second before trying again
                    }
                }
            }
        }
        public void Case_2(Rectangle windowSize, TargetStepModel step)
        {
        }
        public void Case_3(Rectangle windowSize, TargetStepModel step)
        {
        }
        public void Case_4(Rectangle windowSize, TargetStepModel step)
        {
        }
        public void Case_5(Rectangle windowSize, TargetStepModel step)
        {
        }
        public void Case_6(Rectangle windowSize, TargetStepModel step)
        {
        }
        public void Case_7(Rectangle windowSize, TargetStepModel step)
        {
        }
        public void Case_8(Rectangle windowSize, TargetStepModel step)
        {
        }
        public void Case_9(Rectangle windowSize, TargetStepModel step)
        {
        }
    }
}
