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
using ProcessForge.InputWindowLogic;
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

        public const int MainStepsCount = 3;
        public const int OrdinaryStepsCount = 2;
        public const int CharStepsCount = 6;
        public const int MinStandardSteps = 5; // 3 Main + 2 Ordinary
        public const int MaxTotalSteps = 25;

        public static readonly string[] DefaultMainTitles = new[]
        {
            "Capture - Choose Server",
            "Capture - Choose Channel",
            "Capture - Set Pin",
            "Capture - Input Pin",
            "Capture - Auction Icon"
        };

        public static readonly string[] DefaultCharBranchTitles = new[]
        {
            "Capture - Char Select",
            "Capture - Char Create",
            "Capture - Char Name",
            "Capture - Char Enter",
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

            // 1. Generate 3 Main Steps (0 to 2)
            for (int i = 0; i < MainStepsCount; i++)
            {
                steps.Add(new TargetStepModel
                {
                    StepIndex = i,
                    StepTitle = $"Step_{i + 1}",
                    CaptureTitle = DefaultMainTitles[i],
                    IsSubStep = false,
                    BranchType = "Main",
                    TemplateName = $"Target_Step_{i + 1}",
                    ImagePath = string.Empty,
                    Actions = new List<StepInputAction>()
                });
            }

            // 2. Generate 2 Ordinary Login Steps (3 to 4)
            for (int i = 0; i < OrdinaryStepsCount; i++)
            {
                int ordIdx = MainStepsCount + i;
                steps.Add(new TargetStepModel
                {
                    StepIndex = ordIdx,
                    StepTitle = $"Step_{ordIdx + 1}",
                    CaptureTitle = DefaultMainTitles[ordIdx],
                    IsSubStep = false,
                    BranchType = "Ordinary",
                    TemplateName = $"Target_Step_{ordIdx + 1}",
                    ImagePath = string.Empty,
                    Actions = new List<StepInputAction>()
                });
            }

            // 3. Generate 6 Create Character Branch Steps (5 to 10)
            for (int i = 0; i < CharStepsCount; i++)
            {
                int charStepNumber = i + 4; // CharStep 4, 5, 6, 7, 8, 9
                steps.Add(new TargetStepModel
                {
                    StepIndex = steps.Count,
                    StepTitle = $"CharStep_{charStepNumber}",
                    CaptureTitle = DefaultCharBranchTitles[i],
                    IsSubStep = false,
                    BranchType = "CreateCharacter",
                    TemplateName = $"Target_CharStep_{charStepNumber}",
                    ImagePath = string.Empty,
                    Actions = new List<StepInputAction>()
                });
            }

            // Seed default dynamic variable actions for Step 1 if actions list is empty
            if (steps[0].Actions.Count == 0)
            {
                steps[0].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{USERNAME}" });
                steps[0].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{TAB}" });
                steps[0].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{PASSWORD}" });
                steps[0].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{ENTER}" });
            }

            // Seed default dynamic variable action for Step 4 (Input Pin) if actions list is empty
            if (steps[3].Actions.Count == 0)
            {
                steps[3].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{SECONDPASSWORD}" });
            }

            // 4. Load and overlay from config file if exists
            if (File.Exists(configFilePath))
            {
                try
                {
                    string json = File.ReadAllText(configFilePath);
                    var loaded = JsonSerializer.Deserialize<List<TargetStepModel>>(json);
                    if (loaded != null && loaded.Count > 0)
                    {
                        var loadedCharSteps = new List<TargetStepModel>();
                        var loadedSubSteps = new List<TargetStepModel>();

                        for (int i = 0; i < loaded.Count; i++)
                        {
                            var item = loaded[i];

                            // Migrate legacy TargetX/TargetY if present
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
                            if (item.Actions == null) item.Actions = new List<StepInputAction>();

                            item.TargetX = null;
                            item.TargetY = null;
                            item.ClickTypeIndex = null;
                            item.UseRelativeOffset = null;

                            bool isSub = item.IsSubStep || item.BranchType == "SubStep" || (item.StepTitle?.StartsWith("SubStep") ?? false);
                            bool isChar = item.BranchType == "CreateCharacter" || (item.StepTitle?.StartsWith("CharStep") ?? false);

                            if (isChar)
                            {
                                item.BranchType = "CreateCharacter";
                                item.IsSubStep = false;
                                loadedCharSteps.Add(item);
                            }
                            else if (isSub)
                            {
                                item.BranchType = "SubStep";
                                item.IsSubStep = true;
                                loadedSubSteps.Add(item);
                            }
                            else if (item.StepIndex < 3 || item.BranchType == "Main" || item.StepTitle == "Step_1" || item.StepTitle == "Step_2" || item.StepTitle == "Step_3")
                            {
                                int mainIdx = item.StepIndex < 3 ? item.StepIndex : (item.StepTitle == "Step_2" ? 1 : (item.StepTitle == "Step_3" ? 2 : 0));
                                if (mainIdx >= 0 && mainIdx < 3)
                                {
                                    steps[mainIdx].CaptureTitle = !string.IsNullOrEmpty(item.CaptureTitle) ? item.CaptureTitle : DefaultMainTitles[mainIdx];
                                    steps[mainIdx].TemplateName = !string.IsNullOrEmpty(item.TemplateName) ? item.TemplateName : $"Target_Step_{mainIdx + 1}";
                                    steps[mainIdx].ImagePath = item.ImagePath ?? string.Empty;
                                    steps[mainIdx].Actions = item.Actions;
                                }
                            }
                            else if (item.StepIndex < 5 || item.BranchType == "Ordinary" || item.StepTitle == "Step_4" || item.StepTitle == "Step_5")
                            {
                                int ordIdx = (item.StepIndex == 3 || item.StepTitle == "Step_4") ? 3 : 4;
                                steps[ordIdx].CaptureTitle = !string.IsNullOrEmpty(item.CaptureTitle) ? item.CaptureTitle : DefaultMainTitles[ordIdx];
                                steps[ordIdx].TemplateName = !string.IsNullOrEmpty(item.TemplateName) ? item.TemplateName : $"Target_Step_{ordIdx + 1}";
                                steps[ordIdx].ImagePath = item.ImagePath ?? string.Empty;
                                steps[ordIdx].Actions = item.Actions;
                            }
                            else
                            {
                                item.BranchType = "SubStep";
                                item.IsSubStep = true;
                                loadedSubSteps.Add(item);
                            }
                        }

                        // Apply loaded Char steps
                        for (int i = 0; i < loadedCharSteps.Count && i < CharStepsCount; i++)
                        {
                            int targetSlot = 5 + i;
                            var charItem = loadedCharSteps[i];
                            steps[targetSlot].CaptureTitle = !string.IsNullOrEmpty(charItem.CaptureTitle) ? charItem.CaptureTitle : DefaultCharBranchTitles[i];
                            steps[targetSlot].TemplateName = !string.IsNullOrEmpty(charItem.TemplateName) ? charItem.TemplateName : $"Target_CharStep_{i + 4}";
                            steps[targetSlot].ImagePath = charItem.ImagePath ?? string.Empty;
                            steps[targetSlot].Actions = charItem.Actions;
                        }

                        // Append loaded Sub steps
                        for (int i = 0; i < loadedSubSteps.Count; i++)
                        {
                            if (steps.Count >= MaxTotalSteps) break;
                            var subItem = loadedSubSteps[i];
                            int subNum = steps.Count - 11 + 1;
                            subItem.StepIndex = steps.Count;
                            subItem.IsSubStep = true;
                            subItem.BranchType = "SubStep";
                            if (string.IsNullOrEmpty(subItem.CaptureTitle)) subItem.CaptureTitle = "Capture - Custom Handling";
                            if (string.IsNullOrEmpty(subItem.StepTitle)) subItem.StepTitle = $"SubStep_{subNum}";
                            if (string.IsNullOrEmpty(subItem.TemplateName)) subItem.TemplateName = $"Target_SubStep_{subNum}";
                            steps.Add(subItem);
                        }
                    }
                }
                catch
                {
                    // Fall back on parse error
                }
            }

            // Ensure Step 1 has actions even if loaded config had empty actions
            if (steps[0].Actions.Count == 0)
            {
                steps[0].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{USERNAME}" });
                steps[0].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{TAB}" });
                steps[0].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{PASSWORD}" });
                steps[0].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{ENTER}" });
            }

            // Ensure Step 4 has pin action even if loaded config had empty actions
            if (steps[3].Actions.Count == 0)
            {
                steps[3].Actions.Add(new StepInputAction { ActionType = "Keyboard", Word = "{SECONDPASSWORD}" });
            }

            // Check for existing screenshots in storageDirectory for any missing ImagePaths
            for (int i = 0; i < steps.Count; i++)
            {
                steps[i].StepIndex = i;

                if (string.IsNullOrEmpty(steps[i].ImagePath) || !File.Exists(steps[i].ImagePath))
                {
                    string candidateName;
                    if (steps[i].BranchType == "CreateCharacter")
                    {
                        candidateName = $"template_char_step_{i - 5 + 4}.png";
                    }
                    else if (steps[i].IsSubStep || steps[i].BranchType == "SubStep")
                    {
                        candidateName = $"template_substep_{i - 11 + 1}.png";
                        string candidatePath = Path.Combine(storageDirectory, candidateName);
                        if (!File.Exists(candidatePath))
                        {
                            string legacyName = $"template_step_{i + 1}.png";
                            string legacyPath = Path.Combine(storageDirectory, legacyName);
                            if (File.Exists(legacyPath))
                            {
                                candidateName = legacyName;
                            }
                        }
                    }
                    else
                    {
                        candidateName = $"template_step_{i + 1}.png";
                    }

                    string fullCandidatePath = Path.Combine(storageDirectory, candidateName);
                    if (File.Exists(fullCandidatePath))
                    {
                        steps[i].ImagePath = fullCandidatePath;
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

                for (int i = 0; i < Steps.Count; i++)
                {
                    Steps[i].StepIndex = i;
                    if (i < 3)
                    {
                        Steps[i].BranchType = "Main";
                        Steps[i].IsSubStep = false;
                    }
                    else if (i < 5)
                    {
                        Steps[i].BranchType = "Ordinary";
                        Steps[i].IsSubStep = false;
                    }
                    else if (i < 11)
                    {
                        Steps[i].BranchType = "CreateCharacter";
                        Steps[i].IsSubStep = false;
                    }
                    else
                    {
                        Steps[i].BranchType = "SubStep";
                        Steps[i].IsSubStep = true;
                    }

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

        private Button CreatePageButton(string text, int targetIndex)
        {
            Button btnPage = new Button
            {
                Text = text,
                Width = 32,
                Height = 26,
                Margin = new Padding(2, 2, 2, 2),
                Tag = targetIndex,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            btnPage.FlatAppearance.BorderSize = 1;

            btnPage.Click += (s, e) =>
            {
                if (s is Button b && b.Tag is int idx)
                {
                    NavigateToStep(idx);
                }
            };

            return btnPage;
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
                Margin = new Padding(2, 5, 2, 0)
            };
            flpPageButtons.Controls.Add(lblMain);

            // Main Steps (1 to 3)
            for (int i = 0; i < 3 && i < Steps.Count; i++)
            {
                flpPageButtons.Controls.Add(CreatePageButton((i + 1).ToString(), i));
            }

            // 2. " | LOGIN:" Section Label (Ordinary steps 4 to 5)
            Label lblLogin = new Label
            {
                Text = " |  LOGIN:",
                AutoSize = true,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                ForeColor = Color.SteelBlue,
                Margin = new Padding(3, 5, 2, 0)
            };
            flpPageButtons.Controls.Add(lblLogin);

            for (int i = 3; i < 5 && i < Steps.Count; i++)
            {
                flpPageButtons.Controls.Add(CreatePageButton((i + 1).ToString(), i));
            }

            // 3. " | CHAR:" Section Label (Create Character steps 4 to 9)
            Label lblChar = new Label
            {
                Text = " |  CHAR:",
                AutoSize = true,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                ForeColor = Color.ForestGreen,
                Margin = new Padding(3, 5, 2, 0)
            };
            flpPageButtons.Controls.Add(lblChar);

            for (int i = 5; i < 11 && i < Steps.Count; i++)
            {
                int charNum = i - 5 + 4;
                flpPageButtons.Controls.Add(CreatePageButton(charNum.ToString(), i));
            }

            // 4. " | SUB:" Section Label (Sub steps 1 to N)
            Label lblSub = new Label
            {
                Text = " |  SUB:",
                AutoSize = true,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Margin = new Padding(3, 5, 2, 0)
            };
            flpPageButtons.Controls.Add(lblSub);

            if (Steps.Count > 11)
            {
                for (int i = 11; i < Steps.Count; i++)
                {
                    int subNum = i - 11 + 1;
                    flpPageButtons.Controls.Add(CreatePageButton(subNum.ToString(), i));
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
                    Margin = new Padding(2, 5, 2, 0)
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
            btnVarUsername.Click += (s, e) => AppendKeyText("{USERNAME}");
            btnVarPassword.Click += (s, e) => AppendKeyText("{PASSWORD}");
            btnVarPin.Click += (s, e) => AppendKeyText("{SECONDPASSWORD}");
            btnVarNickname.Click += (s, e) => AppendKeyText("{NICKNAME}");

            // Delay & Input Box action events
            btnAddDelayAction.Click += BtnAddDelayAction_Click;
            btnAddInputBoxAction.Click += BtnAddInputBoxAction_Click;

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
            if (model.IsSubStep || model.BranchType == "SubStep")
            {
                lblActionList.Text = $"Sub-Step Actions Sequence ({model.CaptureTitle}):";
            }
            else if (model.BranchType == "Main" && index == 0)
            {
                lblActionList.Text = "Main Step 1 Actions (Hardcoded login; optional extra actions):";
            }
            else if (model.BranchType == "Main")
            {
                lblActionList.Text = $"Main Step {index + 1} Actions Sequence ({model.CaptureTitle}):";
            }
            else if (model.BranchType == "Ordinary")
            {
                lblActionList.Text = $"Ordinary Login Step {index + 1} Actions Sequence ({model.CaptureTitle}):";
            }
            else if (model.BranchType == "CreateCharacter")
            {
                int charNum = index - 5 + 4;
                lblActionList.Text = $"Create Character Step {charNum} Actions Sequence ({model.CaptureTitle}):";
            }
            else
            {
                lblActionList.Text = $"Step {index + 1} Actions Sequence ({model.CaptureTitle}):";
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
                else if (act.ActionType == "Delay")
                {
                    numDelayMs.Value = Math.Max(numDelayMs.Minimum, Math.Min(numDelayMs.Maximum, act.DelayMs ?? 500));
                }
                else if (act.ActionType == "InputBox")
                {
                    txtInputBoxPrompt.Text = act.PromptMessage ?? "Enter character name:";
                }
            }

            picPreview.Invalidate();
        }

        private void UpdatePaginationButtonsStyle()
        {
            if (currentStepIndex < 0 || currentStepIndex >= Steps.Count) return;

            var step = Steps[currentStepIndex];

            // Indicator text
            if (step.BranchType == "Main" || currentStepIndex < 3)
            {
                lblStepIndicator.Text = $"MAIN FLOW — STEP {currentStepIndex + 1} OF 3 ({step.CaptureTitle})";
                lblStepIndicator.ForeColor = Color.Black;
                btnDeleteSubStep.Enabled = false;
            }
            else if (step.BranchType == "Ordinary" || (currentStepIndex >= 3 && currentStepIndex < 5))
            {
                lblStepIndicator.Text = $"LOGIN FLOW — STEP {currentStepIndex + 1} OF 5 ({step.CaptureTitle})";
                lblStepIndicator.ForeColor = Color.SteelBlue;
                btnDeleteSubStep.Enabled = false;
            }
            else if (step.BranchType == "CreateCharacter" || (currentStepIndex >= 5 && currentStepIndex < 11))
            {
                int charNum = currentStepIndex - 5 + 4;
                lblStepIndicator.Text = $"CHAR CREATE BRANCH — STEP {charNum} OF 9 ({step.CaptureTitle})";
                lblStepIndicator.ForeColor = Color.ForestGreen;
                btnDeleteSubStep.Enabled = false;
            }
            else
            {
                int subNum = currentStepIndex - 11 + 1;
                int totalSub = Math.Max(0, Steps.Count - 11);
                lblStepIndicator.Text = $"SUB-STEP {subNum} OF {totalSub} ({step.CaptureTitle})";
                lblStepIndicator.ForeColor = Color.DarkSlateBlue;
                btnDeleteSubStep.Enabled = true;
            }

            btnPrevStep.Enabled = (currentStepIndex > 0);
            btnNextStep.Enabled = (currentStepIndex < Steps.Count - 1);
            btnAddSubStep.Enabled = (Steps.Count < MaxTotalSteps);

            // Styling for step buttons
            foreach (Control ctrl in flpPageButtons.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int pageIdx && pageIdx < Steps.Count)
                {
                    var btnStep = Steps[pageIdx];
                    Color themeColor;

                    if (btnStep.BranchType == "Main" || pageIdx < 3)
                        themeColor = Color.Black;
                    else if (btnStep.BranchType == "Ordinary" || (pageIdx >= 3 && pageIdx < 5))
                        themeColor = Color.SteelBlue;
                    else if (btnStep.BranchType == "CreateCharacter" || (pageIdx >= 5 && pageIdx < 11))
                        themeColor = Color.ForestGreen;
                    else
                        themeColor = Color.DarkSlateBlue;

                    if (pageIdx == currentStepIndex)
                    {
                        btn.BackColor = themeColor;
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = themeColor;
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = themeColor;
                        btn.FlatAppearance.BorderColor = themeColor;
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
                MessageBox.Show($"Maximum limit of {MaxTotalSteps} steps reached.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveCurrentFormToModel();

            int newIndex = Steps.Count;
            int subIndex = Math.Max(1, newIndex - 11 + 1);

            var newStep = new TargetStepModel
            {
                StepIndex = newIndex,
                StepTitle = $"SubStep_{subIndex}",
                CaptureTitle = "Capture - Custom Handling",
                IsSubStep = true,
                BranchType = "SubStep",
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
            if (!Steps[currentStepIndex].IsSubStep && Steps[currentStepIndex].BranchType != "SubStep")
            {
                MessageBox.Show("Fixed flow steps (Main, Ordinary Login, and Character Creation) cannot be deleted.\nOnly custom Sub-Steps can be deleted.", "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var stepToDelete = Steps[currentStepIndex];
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Sub-Step '{stepToDelete.CaptureTitle}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            Steps.RemoveAt(currentStepIndex);

            // Re-index remaining steps
            for (int i = 0; i < Steps.Count; i++)
            {
                Steps[i].StepIndex = i;
                if (Steps[i].IsSubStep || Steps[i].BranchType == "SubStep")
                {
                    int subNum = i - 11 + 1;
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

        private void BtnAddDelayAction_Click(object? sender, EventArgs e)
        {
            var currentStep = Steps[currentStepIndex];
            var action = new StepInputAction
            {
                ActionType = "Delay",
                DelayMs = (int)numDelayMs.Value
            };

            currentStep.Actions.Add(action);
            RefreshActionsList(currentStep.Actions.Count - 1);
            SaveStepsToConfig();
        }

        private void BtnAddInputBoxAction_Click(object? sender, EventArgs e)
        {
            string prompt = string.IsNullOrWhiteSpace(txtInputBoxPrompt.Text) ? "Enter required value:" : txtInputBoxPrompt.Text.Trim();
            var currentStep = Steps[currentStepIndex];
            var action = new StepInputAction
            {
                ActionType = "InputBox",
                PromptMessage = prompt
            };

            currentStep.Actions.Add(action);
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
                else if (act.ActionType == "Delay")
                {
                    act.DelayMs = (int)numDelayMs.Value;
                }
                else if (act.ActionType == "InputBox")
                {
                    act.PromptMessage = string.IsNullOrWhiteSpace(txtInputBoxPrompt.Text) ? "Enter required value:" : txtInputBoxPrompt.Text.Trim();
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
                        string fileName;
                        var step = Steps[currentStepIndex];
                        if (step.BranchType == "CreateCharacter")
                        {
                            int charNum = currentStepIndex - 5 + 4;
                            fileName = $"template_char_step_{charNum}.png";
                        }
                        else if (step.IsSubStep || step.BranchType == "SubStep")
                        {
                            int subNum = currentStepIndex - 11 + 1;
                            fileName = $"template_substep_{subNum}.png";
                        }
                        else
                        {
                            fileName = $"template_step_{currentStepIndex + 1}.png";
                        }

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
                                    var testAccount = new ApplicationLogic.DataLoginFormat
                                    {
                                        username = "TestUser",
                                        password = "TestPassword",
                                        secondPassword = "TestSecondPassword",
                                        nickname = "TestNickname"
                                    };
                                    string resolvedWord = AutoLoginPatternLogic.Case.ResolveVariables(action.Word, testAccount);
                                    SendKeys.SendWait(resolvedWord);
                                    executedCount++;
                                    await Task.Delay(250);
                                }
                            }
                            else if (action.ActionType == "Delay")
                            {
                                int delay = action.DelayMs ?? 500;
                                await Task.Delay(delay);
                                executedCount++;
                            }
                            else if (action.ActionType == "InputBox")
                            {
                                string prompt = string.IsNullOrWhiteSpace(action.PromptMessage) ? "Enter custom input:" : action.PromptMessage;
                                string inputVal = PromptDialog.Show(prompt);
                                if (!string.IsNullOrEmpty(inputVal))
                                {
                                    await Task.Delay(200);
                                    SendKeys.SendWait(inputVal);
                                }
                                executedCount++;
                                await Task.Delay(250);
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
        public string ActionType { get; set; } = "Mouse"; // "Mouse", "Keyboard", "Delay", "InputBox"

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

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DelayMs { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PromptMessage { get; set; }

        public override string ToString()
        {
            if (ActionType == "Keyboard")
            {
                return $"⌨ [Keyboard] SendKeys: \"{Word}\"";
            }
            else if (ActionType == "Delay")
            {
                return $"⏳ [Delay] Wait {DelayMs ?? 500} ms";
            }
            else if (ActionType == "InputBox")
            {
                string prompt = string.IsNullOrWhiteSpace(PromptMessage) ? "Prompt user for text" : PromptMessage;
                return $"💬 [Input Box] Prompt: \"{prompt}\" -> SendKeys";
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

        // Flow categorization: "Main" (1-3), "Ordinary" (4-5), "CreateCharacter" (4-7), "SubStep"
        public string BranchType { get; set; } = "Main";

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