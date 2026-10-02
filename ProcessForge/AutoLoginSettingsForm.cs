using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace ProcessForge
{
    

    public partial class AutoLoginSettingsForm : Form
    {
        [DllImport("user32.dll")]
        private static extern void SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        private const int TotalSteps = 9;
        private int currentStepIndex = 0;
        private static readonly string storageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");
        private static readonly string configFilePath = Path.Combine(storageDirectory, "steps_config.json");
        
        private Rectangle lastCapturedArea = Rectangle.Empty;
        private int lastCapturedStepIndex = -1;

        public List<TargetStepModel> Steps { get; private set; } = new List<TargetStepModel>();

        public AutoLoginSettingsForm()
        {
            InitializeComponent();

            Directory.CreateDirectory(storageDirectory);

            InitializeStepsData();
            BuildPaginationUI();
            WireFormEvents();

            LoadStepToForm(0);
        }

        private void InitializeStepsData()
        {
            Steps = LoadSteps();
        }

        public static List<TargetStepModel> LoadSteps()
        {
            Directory.CreateDirectory(storageDirectory);
            List<TargetStepModel> steps = new List<TargetStepModel>();

            for (int i = 0; i < TotalSteps; i++)
            {
                steps.Add(new TargetStepModel
                {
                    StepIndex = i,
                    StepTitle = $"Step_{i + 1}",
                    TemplateName = $"Target_Step_{i + 1}"
                });
            }

            if (File.Exists(configFilePath))
            {
                try
                {
                    string json = File.ReadAllText(configFilePath);
                    var loaded = JsonSerializer.Deserialize<List<TargetStepModel>>(json);
                    if (loaded != null)
                    {
                        foreach (var item in loaded)
                        {
                            if (item.StepIndex >= 0 && item.StepIndex < TotalSteps)
                            {
                                steps[item.StepIndex] = item;
                            }
                        }
                    }
                }
                catch
                {
                    // Fall back to default on parse error
                }
            }

            // Also check for existing screenshots in storageDirectory
            for (int i = 0; i < TotalSteps; i++)
            {
                string expectedFileName = $"template_step_{i + 1}.png";
                string expectedPath = Path.Combine(storageDirectory, expectedFileName);

                if (File.Exists(expectedPath))
                {
                    if (string.IsNullOrEmpty(steps[i].ImagePath) || !File.Exists(steps[i].ImagePath))
                    {
                        steps[i].ImagePath = expectedPath;
                    }

                    // Default X/Y to image center if uninitialized
                    if (steps[i].TargetX == 0 && steps[i].TargetY == 0)
                    {
                        try
                        {
                            using (var stream = new FileStream(expectedPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            using (var bmp = new Bitmap(stream))
                            {
                                steps[i].TargetX = bmp.Width / 2;
                                steps[i].TargetY = bmp.Height / 2;
                                steps[i].UseRelativeOffset = true;
                            }
                        }
                        catch { }
                    }
                }
            }

            return steps;
        }

        private void SaveStepsToConfig()
        {
            try
            {
                Directory.CreateDirectory(storageDirectory);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(Steps, options);
                File.WriteAllText(configFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving steps configuration: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BuildPaginationUI()
        {
            flpPageButtons.Controls.Clear();

            for (int i = 0; i < TotalSteps; i++)
            {
                int stepNum = i + 1;
                Button btnPage = new Button
                {
                    Text = stepNum.ToString(),
                    Width = 42,
                    Height = 30,
                    Margin = new Padding(3, 0, 3, 0),
                    Tag = i,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand
                };
                btnPage.FlatAppearance.BorderSize = 1;

                btnPage.Click += (s, e) =>
                {
                    if (s is Button b && b.Tag is int targetIndex)
                    {
                        NavigateToStep(targetIndex);
                    }
                };

                flpPageButtons.Controls.Add(btnPage);
            }
        }

        private void WireFormEvents()
        {
            btnPrevStep.Click += (s, e) => NavigateToStep(currentStepIndex - 1);
            btnNextStep.Click += (s, e) => NavigateToStep(currentStepIndex + 1);

            // Action triggers
            btnCaptureImage.Click += BtnCaptureImage_Click;
            btnCaptureCoords.Click += BtnCaptureCoords_Click;
            btnTestExecution.Click += BtnTestExecution_Click;

            // Preview click to set coordinate directly on the template
            picPreview.MouseClick += PicPreview_MouseClick;
            picPreview.Paint += PicPreview_Paint;

            numCoordX.ValueChanged += (s, e) => picPreview.Invalidate();
            numCoordY.ValueChanged += (s, e) => picPreview.Invalidate();
            chkUseRelativeOffset.CheckedChanged += (s, e) => picPreview.Invalidate();

            btnSave.Click += (s, e) =>
            {
                SaveCurrentFormToModel();
                SaveStepsToConfig();
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }

        #region Navigation & Data Binding

        private void NavigateToStep(int targetStepIndex)
        {
            if (targetStepIndex < 0 || targetStepIndex >= TotalSteps) return;

            SaveCurrentFormToModel();
            currentStepIndex = targetStepIndex;
            LoadStepToForm(currentStepIndex);
        }

        private void SaveCurrentFormToModel()
        {
            var model = Steps[currentStepIndex];
            model.TemplateName = txtTemplateName.Text;
            model.ImagePath = txtImagePath.Text;
            model.TargetX = (int)numCoordX.Value;
            model.TargetY = (int)numCoordY.Value;
            model.ClickTypeIndex = cmbClickType.SelectedIndex;
            model.UseRelativeOffset = chkUseRelativeOffset.Checked;
        }

        private void LoadStepToForm(int index)
        {
            var model = Steps[index];

            txtTemplateName.Text = model.TemplateName;
            txtImagePath.Text = model.ImagePath;
            numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, model.TargetX));
            numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, model.TargetY));

            if (model.ClickTypeIndex >= 0 && model.ClickTypeIndex < cmbClickType.Items.Count)
            {
                cmbClickType.SelectedIndex = model.ClickTypeIndex;
            }
            chkUseRelativeOffset.Checked = model.UseRelativeOffset;

            // Load Preview Safely (without locking image file or stream disposal bug)
            if (picPreview.Image != null)
            {
                var oldImg = picPreview.Image;
                picPreview.Image = null;
                oldImg.Dispose();
            }

            if (!string.IsNullOrEmpty(model.ImagePath) && File.Exists(model.ImagePath))
            {
                try
                {
                    using (var stream = new FileStream(model.ImagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var temp = Image.FromStream(stream))
                    {
                        picPreview.Image = new Bitmap(temp);
                    }
                }
                catch
                {
                    picPreview.Image = null;
                }
            }

            lblStepIndicator.Text = $"STEP {index + 1} OF {TotalSteps}";
            btnPrevStep.Enabled = index > 0;
            btnNextStep.Enabled = index < TotalSteps - 1;

            UpdatePaginationButtonsStyle();
            picPreview.Invalidate();
        }

        private void UpdatePaginationButtonsStyle()
        {
            foreach (Control ctrl in flpPageButtons.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int pageIdx)
                {
                    if (pageIdx == currentStepIndex)
                    {
                        btn.BackColor = Color.Black;
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = Color.Black;
                    }
                }
            }
        }

        #endregion

        #region Preview Coordinate Translation & Crosshair

        private Point? TranslatePreviewToImage(Point clickPos)
        {
            if (picPreview.Image == null) return null;

            int imgW = picPreview.Image.Width;
            int imgH = picPreview.Image.Height;
            int boxW = picPreview.ClientSize.Width;
            int boxH = picPreview.ClientSize.Height;

            if (imgW == 0 || imgH == 0 || boxW == 0 || boxH == 0) return null;

            float ratioW = (float)boxW / imgW;
            float ratioH = (float)boxH / imgH;
            float scale = Math.Min(ratioW, ratioH);

            float displayedW = imgW * scale;
            float displayedH = imgH * scale;

            float offsetX = (boxW - displayedW) / 2f;
            float offsetY = (boxH - displayedH) / 2f;

            if (clickPos.X < offsetX || clickPos.X > offsetX + displayedW ||
                clickPos.Y < offsetY || clickPos.Y > offsetY + displayedH)
            {
                return null;
            }

            int imgX = (int)((clickPos.X - offsetX) / scale);
            int imgY = (int)((clickPos.Y - offsetY) / scale);

            return new Point(imgX, imgY);
        }

        private Point? TranslateImageToPreview(int imgX, int imgY)
        {
            if (picPreview.Image == null) return null;

            int imgW = picPreview.Image.Width;
            int imgH = picPreview.Image.Height;
            int boxW = picPreview.ClientSize.Width;
            int boxH = picPreview.ClientSize.Height;

            if (imgW == 0 || imgH == 0 || boxW == 0 || boxH == 0) return null;

            float ratioW = (float)boxW / imgW;
            float ratioH = (float)boxH / imgH;
            float scale = Math.Min(ratioW, ratioH);

            float displayedW = imgW * scale;
            float displayedH = imgH * scale;

            float offsetX = (boxW - displayedW) / 2f;
            float offsetY = (boxH - displayedH) / 2f;

            int prevX = (int)(offsetX + imgX * scale);
            int prevY = (int)(offsetY + imgY * scale);

            return new Point(prevX, prevY);
        }

        private void PicPreview_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || picPreview.Image == null) return;
            if (!chkUseRelativeOffset.Checked) return;

            Point? imgPt = TranslatePreviewToImage(e.Location);
            if (imgPt.HasValue)
            {
                numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, imgPt.Value.X));
                numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, imgPt.Value.Y));
                chkUseRelativeOffset.Checked = true;

                SaveCurrentFormToModel();
                SaveStepsToConfig();
                picPreview.Invalidate();
            }
        }

        private void PicPreview_Paint(object? sender, PaintEventArgs e)
        {
            if (picPreview.Image != null && chkUseRelativeOffset.Checked)
            {
                Point? prevPt = TranslateImageToPreview((int)numCoordX.Value, (int)numCoordY.Value);
                if (prevPt.HasValue)
                {
                    int x = prevPt.Value.X;
                    int y = prevPt.Value.Y;

                    using (Pen pen = new Pen(Color.Red, 2))
                    using (Brush brush = new SolidBrush(Color.Red))
                    {
                        e.Graphics.DrawEllipse(pen, x - 8, y - 8, 16, 16);
                        e.Graphics.DrawLine(pen, x - 12, y, x + 12, y);
                        e.Graphics.DrawLine(pen, x, y - 12, x, y + 12);
                        e.Graphics.FillEllipse(brush, x - 2, y - 2, 4, 4);
                    }
                }
            }
        }

        #endregion

        #region Image Capture & OpenCV Functionality

        private async void BtnCaptureImage_Click(object? sender, EventArgs e)
        {
            this.Hide();
            await Task.Delay(200); // Allow window to hide completely

            try
            {
                Rectangle selectedArea = SelectScreenArea();

                if (selectedArea.Width > 0 && selectedArea.Height > 0)
                {
                    lastCapturedArea = selectedArea;
                    lastCapturedStepIndex = currentStepIndex;

                    using (Bitmap screenshot = CaptureScreenRegion(selectedArea))
                    {
                        string fileName = $"template_step_{currentStepIndex + 1}.png";
                        string savePath = Path.Combine(storageDirectory, fileName);

                        screenshot.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);

                        txtImagePath.Text = savePath;
                        Steps[currentStepIndex].ImagePath = savePath;

                        // Default X/Y to center relative offset if empty
                        if (numCoordX.Value == 0 && numCoordY.Value == 0)
                        {
                            numCoordX.Value = selectedArea.Width / 2;
                            numCoordY.Value = selectedArea.Height / 2;
                            chkUseRelativeOffset.Checked = true;
                        }
                    }

                    SaveCurrentFormToModel();
                    SaveStepsToConfig();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error capturing template: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Show();
                LoadStepToForm(currentStepIndex);
            }
        }

        private async void BtnCaptureCoords_Click(object? sender, EventArgs e)
        {
            var step = Steps[currentStepIndex];
            bool isRelative = chkUseRelativeOffset.Checked;

            this.Hide();
            await Task.Delay(200);

            try
            {
                using (ScreenCaptureForm form = new ScreenCaptureForm(ScreenCaptureMode.Point))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Point clickedPoint = form.SelectedPoint;

                        if (!isRelative)
                        {
                            // Relative coordinate is disabled: capture absolute screen coordinates starting from screen 0, 0
                            numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, clickedPoint.X));
                            numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, clickedPoint.Y));
                            chkUseRelativeOffset.Checked = false;
                        }
                        else
                        {
                            // Relative coordinate is enabled: calculate offset relative to matched template
                            bool matched = false;
                            if (!string.IsNullOrEmpty(step.ImagePath) && File.Exists(step.ImagePath))
                            {
                                try
                                {
                                    Rectangle screenSize = Screen.PrimaryScreen?.Bounds ?? Screen.GetBounds(clickedPoint);
                                    using (Bitmap fullScreenBitmap = CaptureScreenRegion(screenSize))
                                    using (Mat screenMat = BitmapConverter.ToMat(fullScreenBitmap))
                                    using (Mat templateMat = Cv2.ImRead(step.ImagePath, ImreadModes.Color))
                                    using (Mat resultMat = new Mat())
                                    {
                                        Cv2.CvtColor(screenMat, screenMat, ColorConversionCodes.BGRA2BGR);
                                        Cv2.MatchTemplate(screenMat, templateMat, resultMat, TemplateMatchModes.CCoeffNormed);
                                        Cv2.MinMaxLoc(resultMat, out double minVal, out double maxVal, out OpenCvSharp.Point minLoc, out OpenCvSharp.Point maxLoc);

                                        if (maxVal >= 0.70)
                                        {
                                            int relX = clickedPoint.X - maxLoc.X;
                                            int relY = clickedPoint.Y - maxLoc.Y;

                                            numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, relX));
                                            numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, relY));
                                            chkUseRelativeOffset.Checked = true;
                                            matched = true;
                                        }
                                    }
                                }
                                catch
                                {
                                    // In case OpenCV matching fails, fallback
                                }
                            }

                            if (!matched)
                            {
                                // If user captured region in this session on the same step
                                if (lastCapturedArea.Width > 0 && lastCapturedArea.Height > 0 &&
                                    lastCapturedStepIndex == currentStepIndex)
                                {
                                    int relX = clickedPoint.X - lastCapturedArea.X;
                                    int relY = clickedPoint.Y - lastCapturedArea.Y;

                                    numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, relX));
                                    numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, relY));
                                    chkUseRelativeOffset.Checked = true;
                                }
                                else
                                {
                                    // Direct screen coordinate fallback
                                    numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, clickedPoint.X));
                                    numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, clickedPoint.Y));
                                    chkUseRelativeOffset.Checked = false;
                                }
                            }
                        }

                        SaveCurrentFormToModel();
                        SaveStepsToConfig();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error capturing coordinate: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Show();
                picPreview.Invalidate();
            }
        }

        private async void BtnTestExecution_Click(object? sender, EventArgs e)
        {
            SaveCurrentFormToModel();
            var step = Steps[currentStepIndex];

            if (string.IsNullOrEmpty(step.ImagePath) || !File.Exists(step.ImagePath))
            {
                MessageBox.Show("Please capture an image template for this step first.", "Missing Template", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            await Task.Delay(300);

            try
            {
                // 1. Capture full active screen
                Rectangle screenSize = Screen.PrimaryScreen?.Bounds ?? Screen.GetBounds(Point.Empty);
                using (Bitmap fullScreenBitmap = CaptureScreenRegion(screenSize))
                using (Mat screenMat = BitmapConverter.ToMat(fullScreenBitmap))
                using (Mat templateMat = Cv2.ImRead(step.ImagePath, ImreadModes.Color))
                using (Mat resultMat = new Mat())
                {
                    // Convert screen color format
                    Cv2.CvtColor(screenMat, screenMat, ColorConversionCodes.BGRA2BGR);

                    // 2. Perform Template Matching via OpenCV
                    Cv2.MatchTemplate(screenMat, templateMat, resultMat, TemplateMatchModes.CCoeffNormed);
                    Cv2.MinMaxLoc(resultMat, out double minVal, out double maxVal, out OpenCvSharp.Point minLoc, out OpenCvSharp.Point maxLoc);

                    if (maxVal >= 0.85) // Confidence threshold
                    {
                        int targetX, targetY;

                        if (step.UseRelativeOffset)
                        {
                            targetX = maxLoc.X + step.TargetX;
                            targetY = maxLoc.Y + step.TargetY;
                        }
                        else
                        {
                            targetX = step.TargetX;
                            targetY = step.TargetY;
                        }

                        // Execute Click Simulation
                        PerformClick(targetX, targetY, step.ClickTypeIndex);

                        MessageBox.Show($"Match Found! (Score: {maxVal:F2})\nClicked At X: {targetX}, Y: {targetY}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Target image not found on screen.\nBest Match Score: {maxVal:F2} (Threshold required: >= 0.85)", "Match Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running execution test: {ex.Message}", "Test Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Show();
            }
        }

        #endregion

        #region Helpers & P/Invoke Wrappers

        private Rectangle SelectScreenArea()
        {
            using (ScreenCaptureForm form = new ScreenCaptureForm(ScreenCaptureMode.Area))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.SelectedArea;
                }
            }
            return Rectangle.Empty;
        }

        private Bitmap CaptureScreenRegion(Rectangle region)
        {
            Bitmap bitmap = new Bitmap(region.Width, region.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(region.Location, System.Drawing.Point.Empty, region.Size);
            }
            return bitmap;
        }

        private void PerformClick(int x, int y, int clickType)
        {
            SetCursorPos(x, y);

            switch (clickType)
            {
                case 0: // Single Left Click
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                    break;
                case 1: // Double Left Click
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                    break;
                case 2: // Single Right Click
                    const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
                    const uint MOUSEEVENTF_RIGHTUP = 0x0010;
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, UIntPtr.Zero);
                    break;
                case 3: // Hover Only
                    break;
            }
        }

        #endregion
    }

    public class TargetStepModel
    {
        public int StepIndex { get; set; }
        public string StepTitle { get; set; } = string.Empty;
        public string TemplateName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public int TargetX { get; set; }
        public int TargetY { get; set; }
        public int ClickTypeIndex { get; set; } = 0;
        public bool UseRelativeOffset { get; set; } = true;
    }
}