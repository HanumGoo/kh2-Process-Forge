using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public const int MinMainSteps = 5;
        public const int MaxTotalSteps = 20;

        public static readonly string[] DefaultMainTitles = new[]
        {
            "Capture - Choose Server",
            "Capture - Choose Channel",
            "Capture - Set Pin",
            "Capture - Input Pin",
            "Capture - Auction Icon"
        };

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

            // Generate default 5 Main Steps
            for (int i = 0; i < MinMainSteps; i++)
            {
                steps.Add(new TargetStepModel
                {
                    StepIndex = i,
                    StepTitle = $"Step_{i + 1}",
                    CaptureTitle = DefaultMainTitles[i],
                    IsSubStep = false,
                    TemplateName = $"Target_Step_{i + 1}",
                    ImagePath = string.Empty,
                    Actions = new List<StepInputAction>()
                });
            }

            if (File.Exists(configFilePath))
            {
                try
                {
                    string json = File.ReadAllText(configFilePath);
                    var loaded = JsonSerializer.Deserialize<List<TargetStepModel>>(json);
                    if (loaded != null && loaded.Count > 0)
                    {
                        int totalToLoad = Math.Min(MaxTotalSteps, Math.Max(MinMainSteps, loaded.Count));

                        // Pre-populate slots for loaded sub-steps
                        while (steps.Count < totalToLoad)
                        {
                            int nextIdx = steps.Count;
                            steps.Add(new TargetStepModel
                            {
                                StepIndex = nextIdx,
                                StepTitle = $"SubStep_{nextIdx - 4}",
                                CaptureTitle = "Capture - Custom Handling",
                                IsSubStep = true,
                                TemplateName = $"Target_SubStep_{nextIdx - 4}",
                                ImagePath = string.Empty,
                                Actions = new List<StepInputAction>()
                            });
                        }

                        for (int i = 0; i < Math.Min(MaxTotalSteps, loaded.Count); i++)
                        {
                            var item = loaded[i];
                            item.StepIndex = i;
                            item.IsSubStep = (i >= MinMainSteps);

                            // Apply default capture title if missing
                            if (string.IsNullOrEmpty(item.CaptureTitle))
                            {
                                item.CaptureTitle = (i < MinMainSteps) ? DefaultMainTitles[i] : "Capture - Custom Handling";
                            }

                            if (string.IsNullOrEmpty(item.StepTitle))
                            {
                                item.StepTitle = item.IsSubStep ? $"SubStep_{i - 4}" : $"Step_{i + 1}";
                            }

                            if (string.IsNullOrEmpty(item.TemplateName))
                            {
                                item.TemplateName = item.IsSubStep ? $"Target_SubStep_{i - 4}" : $"Target_Step_{i + 1}";
                            }

                            // Migrate legacy TargetX/TargetY to Actions if needed
                            if ((item.Actions == null || item.Actions.Count == 0) && item.TargetX.HasValue && item.TargetY.HasValue)
                            {
                                item.Actions = new List<StepInputAction>();
                                if (item.TargetX.Value != 0 || item.TargetY.Value != 0)
                                {
                                    item.Actions.Add(new StepInputAction
                                    {
                                        ActionType = "Mouse",
                                        X = item.TargetX.Value,
                                        Y = item.TargetY.Value,
                                        ClickTypeIndex = item.ClickTypeIndex ?? 0,
                                        UseRelativeOffset = item.UseRelativeOffset ?? false
                                    });
                                }
                            }

                            if (item.Actions == null)
                            {
                                item.Actions = new List<StepInputAction>();
                            }

                            // Clear legacy properties so they are omitted in serialization
                            item.TargetX = null;
                            item.TargetY = null;
                            item.ClickTypeIndex = null;
                            item.UseRelativeOffset = null;

                            steps[i] = item;
                        }
                    }
                }
                catch
                {
                    // Fall back to default on parse error
                }
            }

            // Check for existing screenshots in storageDirectory
            for (int i = 0; i < steps.Count; i++)
            {
                string expectedFileName = $"template_step_{i + 1}.png";
                string expectedPath = Path.Combine(storageDirectory, expectedFileName);

                if (File.Exists(expectedPath))
                {
                    if (string.IsNullOrEmpty(steps[i].ImagePath) || !File.Exists(steps[i].ImagePath))
                    {
                        steps[i].ImagePath = expectedPath;
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

                // Ensure legacy fields are null and indexes are clean
                for (int i = 0; i < Steps.Count; i++)
                {
                    Steps[i].StepIndex = i;
                    Steps[i].IsSubStep = (i >= MinMainSteps);
                    Steps[i].TargetX = null;
                    Steps[i].TargetY = null;
                    Steps[i].ClickTypeIndex = null;
                    Steps[i].UseRelativeOffset = null;
                }

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

            // 1. "MAIN:" Section Label
            Label lblMain = new Label
            {
                Text = "MAIN:",
                AutoSize = true,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                ForeColor = Color.Black,
                Margin = new Padding(2, 8, 3, 0)
            };
            flpPageButtons.Controls.Add(lblMain);

            // 2. Main Step Buttons (1 to 5)
            int mainCount = Math.Min(MinMainSteps, Steps.Count);
            for (int i = 0; i < mainCount; i++)
            {
                int stepNum = i + 1;
                Button btnPage = new Button
                {
                    Text = stepNum.ToString(),
                    Width = 34,
                    Height = 28,
                    Margin = new Padding(2, 1, 2, 1),
                    Tag = i,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
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

            // 3. " |  SUB:" Section Label
            Label lblSub = new Label
            {
                Text = " |  SUB:",
                AutoSize = true,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Margin = new Padding(5, 8, 3, 0)
            };
            flpPageButtons.Controls.Add(lblSub);

            // 4. Sub Step Buttons (6 to Steps.Count)
            if (Steps.Count > MinMainSteps)
            {
                for (int i = MinMainSteps; i < Steps.Count; i++)
                {
                    int stepNum = i + 1;
                    Button btnPage = new Button
                    {
                        Text = stepNum.ToString(),
                        Width = 34,
                        Height = 28,
                        Margin = new Padding(2, 1, 2, 1),
                        Tag = i,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
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
            else
            {
                Label lblNone = new Label
                {
                    Text = "(none)",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Margin = new Padding(2, 8, 2, 0)
                };
                flpPageButtons.Controls.Add(lblNone);
            }

            UpdatePaginationButtonsStyle();
        }

        private void WireFormEvents()
        {
            btnPrevStep.Click += (s, e) => NavigateToStep(currentStepIndex - 1);
            btnNextStep.Click += (s, e) => NavigateToStep(currentStepIndex + 1);

            // Sub-step management events
            btnAddSubStep.Click += BtnAddSubStep_Click;
            btnDeleteSubStep.Click += BtnDeleteSubStep_Click;

            // Image anchor events
            btnCaptureImage.Click += BtnCaptureImage_Click;

            // Synchronize GroupBox header in real time when user edits Capture Title
            txtCaptureTitle.TextChanged += (s, e) =>
            {
                string title = !string.IsNullOrEmpty(txtCaptureTitle.Text) ? txtCaptureTitle.Text.Trim().ToUpper() : "IMAGE ANCHOR";
                gbImageConfig.Text = $" {title} ";
                btnCaptureImage.Text = $"CAPTURE IMAGE — {title}";
            };

            // Action sequence list events
            lstActions.SelectedIndexChanged += LstActions_SelectedIndexChanged;
            btnMoveUp.Click += BtnMoveUp_Click;
            btnMoveDown.Click += BtnMoveDown_Click;
            btnRemoveAction.Click += BtnRemoveAction_Click;
            btnClearActions.Click += BtnClearActions_Click;
            btnUpdateSelected.Click += BtnUpdateSelected_Click;

            // Mouse action events
            btnCaptureCoords.Click += BtnCaptureCoords_Click;
            btnAddMouseAction.Click += BtnAddMouseAction_Click;

            // Keyboard action events
            btnAddKeyAction.Click += BtnAddKeyAction_Click;
            btnQuickTab.Click += (s, e) => AppendKeyText("{TAB}");
            btnQuickEnter.Click += (s, e) => AppendKeyText("{ENTER}");

            // Test execution
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
            if (targetStepIndex < 0 || targetStepIndex >= Steps.Count) return;

            SaveCurrentFormToModel();
            currentStepIndex = targetStepIndex;
            LoadStepToForm(currentStepIndex);
        }

        private void SaveCurrentFormToModel()
        {
            if (currentStepIndex >= 0 && currentStepIndex < Steps.Count)
            {
                var model = Steps[currentStepIndex];
                model.CaptureTitle = txtCaptureTitle.Text.Trim();
                model.TemplateName = txtTemplateName.Text.Trim();
                model.ImagePath = txtImagePath.Text.Trim();
            }
        }

        private void LoadStepToForm(int index)
        {
            var model = Steps[index];

            txtCaptureTitle.Text = model.CaptureTitle;
            txtTemplateName.Text = model.TemplateName;
            txtImagePath.Text = model.ImagePath;

            string displayTitle = !string.IsNullOrEmpty(model.CaptureTitle) ? model.CaptureTitle.ToUpper() : "IMAGE ANCHOR";
            gbImageConfig.Text = $" {displayTitle} ";
            btnCaptureImage.Text = $"CAPTURE IMAGE — {displayTitle}";

            // Context-sensitive action list header
            if (model.IsSubStep)
            {
                lblActionList.Text = $"Sub-Step Actions Sequence ({model.CaptureTitle}):";
            }
            else if (index == 0)
            {
                lblActionList.Text = "Main Step 1 Actions (Hardcoded login; optional extra actions):";
            }
            else
            {
                lblActionList.Text = $"Main Step {index + 1} Actions Sequence ({model.CaptureTitle}):";
            }

            // Load Preview Safely
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

            UpdatePaginationButtonsStyle();
            RefreshActionsList(model.Actions.Count > 0 ? 0 : -1);
        }

        private void RefreshActionsList(int selectIndex = -1)
        {
            lstActions.BeginUpdate();
            lstActions.Items.Clear();

            var currentStep = Steps[currentStepIndex];
            for (int i = 0; i < currentStep.Actions.Count; i++)
            {
                var act = currentStep.Actions[i];
                lstActions.Items.Add($"{i + 1}. {act}");
            }

            if (selectIndex >= 0 && selectIndex < lstActions.Items.Count)
            {
                lstActions.SelectedIndex = selectIndex;
            }
            else if (lstActions.Items.Count > 0)
            {
                lstActions.SelectedIndex = 0;
            }
            else
            {
                lstActions.SelectedIndex = -1;
            }

            lstActions.EndUpdate();
            UpdateActionButtonsState();
            picPreview.Invalidate();
        }

        private void UpdateActionButtonsState()
        {
            int selIdx = lstActions.SelectedIndex;
            int count = lstActions.Items.Count;

            btnMoveUp.Enabled = selIdx > 0;
            btnMoveDown.Enabled = selIdx >= 0 && selIdx < count - 1;
            btnRemoveAction.Enabled = selIdx >= 0;
            btnClearActions.Enabled = count > 0;
            btnUpdateSelected.Enabled = selIdx >= 0;
        }

        private void LstActions_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateActionButtonsState();
            var currentStep = Steps[currentStepIndex];
            int selIdx = lstActions.SelectedIndex;

            if (selIdx >= 0 && selIdx < currentStep.Actions.Count)
            {
                var act = currentStep.Actions[selIdx];
                if (act.ActionType == "Mouse")
                {
                    numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, act.X ?? 0));
                    numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, act.Y ?? 0));
                    if (act.ClickTypeIndex.HasValue && act.ClickTypeIndex.Value >= 0 && act.ClickTypeIndex.Value < cmbClickType.Items.Count)
                    {
                        cmbClickType.SelectedIndex = act.ClickTypeIndex.Value;
                    }
                    chkUseRelativeOffset.Checked = act.UseRelativeOffset ?? true;
                }
                else if (act.ActionType == "Keyboard")
                {
                    txtKeyboardWord.Text = act.Word ?? string.Empty;
                }
            }

            picPreview.Invalidate();
        }

        private void UpdatePaginationButtonsStyle()
        {
            // Indicator text
            if (currentStepIndex < MinMainSteps)
            {
                lblStepIndicator.Text = $"MAIN STEP {currentStepIndex + 1} OF {MinMainSteps}";
                lblStepIndicator.ForeColor = Color.Black;
                btnDeleteSubStep.Enabled = false;
            }
            else
            {
                int subNum = currentStepIndex - MinMainSteps + 1;
                int totalSub = Steps.Count - MinMainSteps;
                lblStepIndicator.Text = $"SUB-STEP {subNum} OF {totalSub} (TOTAL: {currentStepIndex + 1}/{Steps.Count})";
                lblStepIndicator.ForeColor = Color.DarkSlateBlue;
                btnDeleteSubStep.Enabled = true;
            }

            btnPrevStep.Enabled = (currentStepIndex > 0);
            btnNextStep.Enabled = (currentStepIndex < Steps.Count - 1);
            btnAddSubStep.Enabled = (Steps.Count < MaxTotalSteps);

            // Styling for step buttons
            foreach (Control ctrl in flpPageButtons.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int pageIdx)
                {
                    bool isSub = (pageIdx >= MinMainSteps);
                    if (pageIdx == currentStepIndex)
                    {
                        btn.BackColor = isSub ? Color.DarkSlateBlue : Color.Black;
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = isSub ? Color.DarkSlateBlue : Color.Black;
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = isSub ? Color.DarkSlateBlue : Color.Black;
                        btn.FlatAppearance.BorderColor = isSub ? Color.MediumPurple : Color.Black;
                    }
                }
            }
        }

        #endregion

        #region Sub-Step Add & Delete

        private void BtnAddSubStep_Click(object? sender, EventArgs e)
        {
            if (Steps.Count >= MaxTotalSteps)
            {
                MessageBox.Show($"Maximum limit of {MaxTotalSteps} steps (5 Main Steps + 15 Sub-Steps) reached.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveCurrentFormToModel();

            int newIndex = Steps.Count;
            int subIndex = newIndex - MinMainSteps + 1;

            var newStep = new TargetStepModel
            {
                StepIndex = newIndex,
                StepTitle = $"SubStep_{subIndex}",
                CaptureTitle = "Capture - Custom Handling",
                IsSubStep = true,
                TemplateName = $"Target_SubStep_{subIndex}",
                ImagePath = string.Empty,
                Actions = new List<StepInputAction>()
            };

            Steps.Add(newStep);
            BuildPaginationUI();
            NavigateToStep(newIndex);
            SaveStepsToConfig();
        }

        private void BtnDeleteSubStep_Click(object? sender, EventArgs e)
        {
            if (currentStepIndex < MinMainSteps)
            {
                MessageBox.Show("Main Steps (Steps 1 to 5) are fixed and cannot be deleted.", "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var stepToDelete = Steps[currentStepIndex];
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Sub-Step '{stepToDelete.CaptureTitle}' (Step {currentStepIndex + 1})?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            Steps.RemoveAt(currentStepIndex);

            // Re-index remaining steps
            for (int i = 0; i < Steps.Count; i++)
            {
                Steps[i].StepIndex = i;
                Steps[i].IsSubStep = (i >= MinMainSteps);
                if (i >= MinMainSteps)
                {
                    int subNum = i - MinMainSteps + 1;
                    if (Steps[i].StepTitle.StartsWith("SubStep_"))
                    {
                        Steps[i].StepTitle = $"SubStep_{subNum}";
                    }
                    if (Steps[i].TemplateName.StartsWith("Target_SubStep_"))
                    {
                        Steps[i].TemplateName = $"Target_SubStep_{subNum}";
                    }
                }
            }

            int targetIdx = Math.Min(currentStepIndex, Steps.Count - 1);
            currentStepIndex = targetIdx;
            BuildPaginationUI();
            LoadStepToForm(currentStepIndex);
            SaveStepsToConfig();
        }

        #endregion

        #region Action List Management

        private void BtnAddMouseAction_Click(object? sender, EventArgs e)
        {
            var currentStep = Steps[currentStepIndex];
            var action = new StepInputAction
            {
                ActionType = "Mouse",
                X = (int)numCoordX.Value,
                Y = (int)numCoordY.Value,
                ClickTypeIndex = cmbClickType.SelectedIndex,
                UseRelativeOffset = chkUseRelativeOffset.Checked
            };

            currentStep.Actions.Add(action);
            RefreshActionsList(currentStep.Actions.Count - 1);
            SaveStepsToConfig();
        }

        private void BtnAddKeyAction_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyboardWord.Text))
            {
                MessageBox.Show("Please enter the keys or word to send.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKeyboardWord.Focus();
                return;
            }

            var currentStep = Steps[currentStepIndex];
            var action = new StepInputAction
            {
                ActionType = "Keyboard",
                Word = txtKeyboardWord.Text
            };

            currentStep.Actions.Add(action);
            txtKeyboardWord.Clear();
            RefreshActionsList(currentStep.Actions.Count - 1);
            SaveStepsToConfig();
        }

        private void AppendKeyText(string key)
        {
            txtKeyboardWord.Text += key;
            txtKeyboardWord.Focus();
            txtKeyboardWord.SelectionStart = txtKeyboardWord.Text.Length;
        }

        private void BtnUpdateSelected_Click(object? sender, EventArgs e)
        {
            var currentStep = Steps[currentStepIndex];
            int selIdx = lstActions.SelectedIndex;

            if (selIdx >= 0 && selIdx < currentStep.Actions.Count)
            {
                var act = currentStep.Actions[selIdx];
                if (act.ActionType == "Mouse")
                {
                    act.X = (int)numCoordX.Value;
                    act.Y = (int)numCoordY.Value;
                    act.ClickTypeIndex = cmbClickType.SelectedIndex;
                    act.UseRelativeOffset = chkUseRelativeOffset.Checked;
                }
                else if (act.ActionType == "Keyboard")
                {
                    if (string.IsNullOrEmpty(txtKeyboardWord.Text))
                    {
                        MessageBox.Show("Please enter keys or text to update the selected keyboard action.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtKeyboardWord.Focus();
                        return;
                    }
                    act.Word = txtKeyboardWord.Text;
                }

                RefreshActionsList(selIdx);
                SaveStepsToConfig();
            }
        }

        private void BtnMoveUp_Click(object? sender, EventArgs e)
        {
            var currentStep = Steps[currentStepIndex];
            int selIdx = lstActions.SelectedIndex;
            if (selIdx > 0)
            {
                var item = currentStep.Actions[selIdx];
                currentStep.Actions.RemoveAt(selIdx);
                currentStep.Actions.Insert(selIdx - 1, item);
                RefreshActionsList(selIdx - 1);
                SaveStepsToConfig();
            }
        }

        private void BtnMoveDown_Click(object? sender, EventArgs e)
        {
            var currentStep = Steps[currentStepIndex];
            int selIdx = lstActions.SelectedIndex;
            if (selIdx >= 0 && selIdx < currentStep.Actions.Count - 1)
            {
                var item = currentStep.Actions[selIdx];
                currentStep.Actions.RemoveAt(selIdx);
                currentStep.Actions.Insert(selIdx + 1, item);
                RefreshActionsList(selIdx + 1);
                SaveStepsToConfig();
            }
        }

        private void BtnRemoveAction_Click(object? sender, EventArgs e)
        {
            var currentStep = Steps[currentStepIndex];
            int selIdx = lstActions.SelectedIndex;
            if (selIdx >= 0 && selIdx < currentStep.Actions.Count)
            {
                currentStep.Actions.RemoveAt(selIdx);
                int newIdx = Math.Min(selIdx, currentStep.Actions.Count - 1);
                RefreshActionsList(newIdx);
                SaveStepsToConfig();
            }
        }

        private void BtnClearActions_Click(object? sender, EventArgs e)
        {
            var currentStep = Steps[currentStepIndex];
            if (currentStep.Actions.Count == 0) return;

            if (MessageBox.Show("Clear all actions for this step?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                currentStep.Actions.Clear();
                RefreshActionsList(-1);
                SaveStepsToConfig();
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

                // If a mouse action is selected in the list, update it directly
                var currentStep = Steps[currentStepIndex];
                int selIdx = lstActions.SelectedIndex;
                if (selIdx >= 0 && selIdx < currentStep.Actions.Count)
                {
                    var selectedAction = currentStep.Actions[selIdx];
                    if (selectedAction.ActionType == "Mouse")
                    {
                        selectedAction.X = (int)numCoordX.Value;
                        selectedAction.Y = (int)numCoordY.Value;
                        selectedAction.UseRelativeOffset = true;
                        RefreshActionsList(selIdx);
                        SaveStepsToConfig();
                    }
                }

                picPreview.Invalidate();
            }
        }

        private void PicPreview_Paint(object? sender, PaintEventArgs e)
        {
            if (picPreview.Image == null) return;

            var step = Steps[currentStepIndex];
            int selectedIdx = lstActions.SelectedIndex;

            // Draw crosshairs for all relative mouse actions in the sequence
            for (int i = 0; i < step.Actions.Count; i++)
            {
                var action = step.Actions[i];
                if (action.ActionType == "Mouse" && (action.UseRelativeOffset ?? false))
                {
                    Point? prevPt = TranslateImageToPreview(action.X ?? 0, action.Y ?? 0);
                    if (prevPt.HasValue)
                    {
                        int x = prevPt.Value.X;
                        int y = prevPt.Value.Y;
                        bool isSelected = (i == selectedIdx);

                        Color color = isSelected ? Color.Red : Color.DodgerBlue;
                        using (Pen pen = new Pen(color, isSelected ? 2 : 1))
                        using (Brush brush = new SolidBrush(color))
                        using (Font font = new Font("Segoe UI", 8F, FontStyle.Bold))
                        {
                            e.Graphics.DrawEllipse(pen, x - 8, y - 8, 16, 16);
                            e.Graphics.DrawLine(pen, x - 12, y, x + 12, y);
                            e.Graphics.DrawLine(pen, x, y - 12, x, y + 12);
                            e.Graphics.FillEllipse(brush, x - 2, y - 2, 4, 4);

                            // Draw sequence badge
                            string badge = (i + 1).ToString();
                            e.Graphics.DrawString(badge, font, brush, x + 8, y - 12);
                        }
                    }
                }
            }

            // If no actions exist or none selected, draw current inputs indicator in LimeGreen
            if (chkUseRelativeOffset.Checked && (step.Actions.Count == 0 || selectedIdx < 0))
            {
                Point? inputPt = TranslateImageToPreview((int)numCoordX.Value, (int)numCoordY.Value);
                if (inputPt.HasValue)
                {
                    int x = inputPt.Value.X;
                    int y = inputPt.Value.Y;
                    using (Pen pen = new Pen(Color.LimeGreen, 2))
                    using (Brush brush = new SolidBrush(Color.LimeGreen))
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

                        // If no actions exist (and not step 1 hardcoded login), add default center mouse click action
                        if (Steps[currentStepIndex].Actions.Count == 0 && currentStepIndex != 0)
                        {
                            Steps[currentStepIndex].Actions.Add(new StepInputAction
                            {
                                ActionType = "Mouse",
                                X = selectedArea.Width / 2,
                                Y = selectedArea.Height / 2,
                                ClickTypeIndex = 0,
                                UseRelativeOffset = true
                            });
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
                        int finalX = clickedPoint.X;
                        int finalY = clickedPoint.Y;
                        bool finalRelative = isRelative;

                        if (!isRelative)
                        {
                            finalX = clickedPoint.X;
                            finalY = clickedPoint.Y;
                            finalRelative = false;
                        }
                        else
                        {
                            // Relative coordinate: calculate offset relative to matched template
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
                                            finalX = clickedPoint.X - maxLoc.X;
                                            finalY = clickedPoint.Y - maxLoc.Y;
                                            finalRelative = true;
                                            matched = true;
                                        }
                                    }
                                }
                                catch { }
                            }

                            if (!matched)
                            {
                                if (lastCapturedArea.Width > 0 && lastCapturedArea.Height > 0 &&
                                    lastCapturedStepIndex == currentStepIndex)
                                {
                                    finalX = clickedPoint.X - lastCapturedArea.X;
                                    finalY = clickedPoint.Y - lastCapturedArea.Y;
                                    finalRelative = true;
                                }
                                else
                                {
                                    finalX = clickedPoint.X;
                                    finalY = clickedPoint.Y;
                                    finalRelative = false;
                                }
                            }
                        }

                        numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, finalX));
                        numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, finalY));
                        chkUseRelativeOffset.Checked = finalRelative;

                        // Add directly if first action, or ask user
                        if (step.Actions.Count == 0 && currentStepIndex != 0)
                        {
                            step.Actions.Add(new StepInputAction
                            {
                                ActionType = "Mouse",
                                X = (int)numCoordX.Value,
                                Y = (int)numCoordY.Value,
                                ClickTypeIndex = cmbClickType.SelectedIndex,
                                UseRelativeOffset = chkUseRelativeOffset.Checked
                            });
                            RefreshActionsList(0);
                            SaveStepsToConfig();
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show(
                                $"Captured coordinate: X = {numCoordX.Value}, Y = {numCoordY.Value} ({(chkUseRelativeOffset.Checked ? "Relative" : "Absolute")}).\n\nAdd this as a new mouse action to the sequence?",
                                "Coordinate Captured",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                step.Actions.Add(new StepInputAction
                                {
                                    ActionType = "Mouse",
                                    X = (int)numCoordX.Value,
                                    Y = (int)numCoordY.Value,
                                    ClickTypeIndex = cmbClickType.SelectedIndex,
                                    UseRelativeOffset = chkUseRelativeOffset.Checked
                                });
                                RefreshActionsList(step.Actions.Count - 1);
                                SaveStepsToConfig();
                            }
                        }
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

            if (step.Actions.Count == 0 && currentStepIndex != 0)
            {
                MessageBox.Show("No actions configured for this step. Please add at least one mouse or keyboard action.", "No Actions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        int executedCount = 0;

                        // Execute linear action sequence in order
                        foreach (var action in step.Actions)
                        {
                            if (action.ActionType == "Mouse")
                            {
                                int targetX, targetY;
                                if (action.UseRelativeOffset ?? false)
                                {
                                    targetX = maxLoc.X + (action.X ?? 0);
                                    targetY = maxLoc.Y + (action.Y ?? 0);
                                }
                                else
                                {
                                    targetX = action.X ?? 0;
                                    targetY = action.Y ?? 0;
                                }

                                PerformClick(targetX, targetY, action.ClickTypeIndex ?? 0);
                                executedCount++;
                                await Task.Delay(250);
                            }
                            else if (action.ActionType == "Keyboard")
                            {
                                if (!string.IsNullOrEmpty(action.Word))
                                {
                                    SendKeys.SendWait(action.Word);
                                    executedCount++;
                                    await Task.Delay(250);
                                }
                            }
                        }

                        if (executedCount > 0)
                        {
                            MessageBox.Show($"Match Found! (Score: {maxVal:F2})\nExecuted {executedCount} action(s) in sequence successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Match Found! (Score: {maxVal:F2})\nTemplate detected successfully on screen.\n(0 macro actions configured; Step 1 input is handled by custom code in Case 1).", "Template Match Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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

    public class StepInputAction
    {
        public string ActionType { get; set; } = "Mouse"; // "Mouse" or "Keyboard"

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? X { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Y { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ClickTypeIndex { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UseRelativeOffset { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Word { get; set; }

        public override string ToString()
        {
            if (ActionType == "Keyboard")
            {
                return $"⌨ [Keyboard] SendKeys: \"{Word}\"";
            }
            else
            {
                string clickDesc = (ClickTypeIndex ?? 0) switch
                {
                    0 => "Single Left Click",
                    1 => "Double Left Click",
                    2 => "Single Right Click",
                    3 => "Hover Only",
                    _ => "Click"
                };
                string mode = (UseRelativeOffset ?? true) ? "Relative" : "Absolute";
                return $"🖱 [Mouse] {clickDesc} at ({X ?? 0}, {Y ?? 0}) [{mode}]";
            }
        }
    }

    public class TargetStepModel
    {
        public int StepIndex { get; set; }
        public string StepTitle { get; set; } = string.Empty;
        public string CaptureTitle { get; set; } = string.Empty;
        public bool IsSubStep { get; set; } = false;
        public string TemplateName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        // Linear input action macro sequence
        public List<StepInputAction> Actions { get; set; } = new List<StepInputAction>();

        // Legacy properties for backward compatibility
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TargetX { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TargetY { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ClickTypeIndex { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UseRelativeOffset { get; set; }
    }
}