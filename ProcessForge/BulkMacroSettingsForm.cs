using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ProcessForge.BulkMacroLogic;
using ProcessForge.InputWindowLogic;
using Point = System.Drawing.Point;

namespace ProcessForge
{
    public partial class BulkMacroSettingsForm : Form
    {
        [DllImport("user32.dll")]
        private static extern void SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;

        private static readonly string storageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");

        private BulkWorkflowConfig _config;
        private BulkWorkflowModel? _currentWorkflow;
        private int _currentStepIndex = 0;
        private bool _isUpdatingUi = false;

        public BulkMacroSettingsForm(string? initialWorkflowId = null)
        {
            InitializeComponent();
            Directory.CreateDirectory(storageDirectory);

            _config = BulkWorkflowManager.LoadConfig();

            WireFormEvents();
            PopulateWorkflows(initialWorkflowId);
        }

        #region Initialization & Workflow Management

        private void WireFormEvents()
        {
            // Workflow management
            cmbWorkflows.SelectedIndexChanged += CmbWorkflows_SelectedIndexChanged;
            btnMoveWorkflowUp.Click += BtnMoveWorkflowUp_Click;
            btnMoveWorkflowDown.Click += BtnMoveWorkflowDown_Click;
            txtWorkflowSearch.TextChanged += TxtWorkflowSearch_TextChanged;
            btnNewWorkflow.Click += BtnNewWorkflow_Click;
            btnRenameWorkflow.Click += BtnRenameWorkflow_Click;
            btnDuplicateWorkflow.Click += BtnDuplicateWorkflow_Click;
            btnDeleteWorkflow.Click += BtnDeleteWorkflow_Click;

            // Step pagination buttons
            btnPrevStep.Click += (s, e) => { if (_currentStepIndex > 0) NavigateToStep(_currentStepIndex - 1); };
            btnNextStep.Click += (s, e) => { if (_currentWorkflow != null && _currentStepIndex < _currentWorkflow.Steps.Count - 1) NavigateToStep(_currentStepIndex + 1); };
            btnAddStep.Click += BtnAddStep_Click;
            btnAddSubStep.Click += BtnAddSubStep_Click;
            btnDeleteStep.Click += BtnDeleteStep_Click;

            // Image section
            btnCaptureImage.Click += BtnCaptureImage_Click;
            btnClearImage.Click += BtnClearImage_Click;
            picPreview.MouseClick += PicPreview_MouseClick;
            picPreview.Paint += PicPreview_Paint;

            // Action list buttons
            btnAddMouseAction.Click += BtnAddMouseAction_Click;
            btnAddKeyAction.Click += BtnAddKeyAction_Click;
            btnAddDelayAction.Click += BtnAddDelayAction_Click;
            btnAddInputBoxAction.Click += BtnAddInputBoxAction_Click;
            btnAddBreakAction.Click += BtnAddBreakAction_Click;
            btnAddGotoAction.Click += BtnAddGotoAction_Click;
            btnAddAutoLoginAction.Click += BtnAddAutoLoginAction_Click;
            btnAddClearMemoryAction.Click += BtnAddClearMemoryAction_Click;
            btnAddWorkflowAction.Click += BtnAddWorkflowAction_Click;
            btnMoveUp.Click += BtnMoveUp_Click;
            btnMoveDown.Click += BtnMoveDown_Click;
            btnRemoveAction.Click += BtnRemoveAction_Click;
            btnClearActions.Click += BtnClearActions_Click;
            btnUpdateSelected.Click += BtnUpdateSelected_Click;

            // Action list selection & interaction
            lstActions.SelectedIndexChanged += LstActions_SelectedIndexChanged;

            // Coordinate capture & preview updates
            btnCaptureCoords.Click += BtnCaptureCoords_Click;
            numCoordX.ValueChanged += (s, e) => picPreview.Invalidate();
            numCoordY.ValueChanged += (s, e) => picPreview.Invalidate();
            chkUseRelativeOffset.CheckedChanged += (s, e) => picPreview.Invalidate();

            // Dynamic Variable buttons
            btnVarUsername.Click += (s, e) => AppendKeyText("{USERNAME}");
            btnVarPassword.Click += (s, e) => AppendKeyText("{PASSWORD}");
            btnVarPin.Click += (s, e) => AppendKeyText("{SECONDPASSWORD}");
            btnVarNickname.Click += (s, e) => AppendKeyText("{NICKNAME}");
            btnQuickTab.Click += (s, e) => AppendKeyText("{TAB}");
            btnQuickEnter.Click += (s, e) => AppendKeyText("{ENTER}");

            // Footer
            btnTestExecution.Click += BtnTestExecution_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }

        private List<BulkWorkflowModel> GetFilteredWorkflows()
        {
            string query = txtWorkflowSearch?.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(query)) return _config.Workflows;
            return _config.Workflows.Where(w => w.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        private void PopulateWorkflows(string? selectedId = null)
        {
            _isUpdatingUi = true;
            cmbWorkflows.Items.Clear();

            if (_config.Workflows.Count == 0)
            {
                var def = BulkWorkflowManager.CreateDefaultWorkflow("Default Macro");
                _config.Workflows.Add(def);
                _config.SelectedWorkflowId = def.Id;
            }

            var visibleList = GetFilteredWorkflows();
            if (visibleList.Count == 0)
            {
                visibleList = _config.Workflows;
            }

            foreach (var wf in visibleList)
            {
                cmbWorkflows.Items.Add(wf.Name);
            }

            int selectIndex = 0;
            string targetId = !string.IsNullOrEmpty(selectedId) ? selectedId : _config.SelectedWorkflowId;
            if (!string.IsNullOrEmpty(targetId))
            {
                int found = visibleList.FindIndex(w => w.Id == targetId);
                if (found >= 0) selectIndex = found;
            }

            if (cmbWorkflows.Items.Count > 0)
            {
                cmbWorkflows.SelectedIndex = selectIndex;
                _currentWorkflow = visibleList[selectIndex];
                _config.SelectedWorkflowId = _currentWorkflow.Id;
            }

            UpdateWorkflowReorderButtonsState();
            _isUpdatingUi = false;

            _currentStepIndex = 0;
            BuildPaginationUI();
            LoadStepToForm(0);
        }

        private void UpdateWorkflowReorderButtonsState()
        {
            if (_currentWorkflow == null)
            {
                btnMoveWorkflowUp.Enabled = false;
                btnMoveWorkflowDown.Enabled = false;
                return;
            }

            int idx = _config.Workflows.FindIndex(w => w.Id == _currentWorkflow.Id);
            btnMoveWorkflowUp.Enabled = idx > 0;
            btnMoveWorkflowDown.Enabled = idx >= 0 && idx < _config.Workflows.Count - 1;
        }

        private void TxtWorkflowSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_isUpdatingUi) return;
            string? currentId = _currentWorkflow?.Id;
            PopulateWorkflows(currentId);
        }

        private void BtnMoveWorkflowUp_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            int idx = _config.Workflows.FindIndex(w => w.Id == _currentWorkflow.Id);
            if (idx > 0)
            {
                SaveCurrentFormToModel();
                var item = _config.Workflows[idx];
                _config.Workflows.RemoveAt(idx);
                _config.Workflows.Insert(idx - 1, item);
                BulkWorkflowManager.SaveConfig(_config);
                PopulateWorkflows(item.Id);
            }
        }

        private void BtnMoveWorkflowDown_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            int idx = _config.Workflows.FindIndex(w => w.Id == _currentWorkflow.Id);
            if (idx >= 0 && idx < _config.Workflows.Count - 1)
            {
                SaveCurrentFormToModel();
                var item = _config.Workflows[idx];
                _config.Workflows.RemoveAt(idx);
                _config.Workflows.Insert(idx + 1, item);
                BulkWorkflowManager.SaveConfig(_config);
                PopulateWorkflows(item.Id);
            }
        }

        private void CmbWorkflows_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isUpdatingUi) return;

            SaveCurrentFormToModel();

            var visibleList = GetFilteredWorkflows();
            int idx = cmbWorkflows.SelectedIndex;
            if (idx >= 0 && idx < visibleList.Count)
            {
                _currentWorkflow = visibleList[idx];
                _config.SelectedWorkflowId = _currentWorkflow.Id;
                UpdateWorkflowReorderButtonsState();
                _currentStepIndex = 0;
                BuildPaginationUI();
                LoadStepToForm(0);
            }
        }

        private void BtnNewWorkflow_Click(object? sender, EventArgs e)
        {
            string name = PromptDialog.Show("Enter a name for the new workflow:", "Create Workflow", "New Macro Workflow");
            if (string.IsNullOrWhiteSpace(name)) return;

            SaveCurrentFormToModel();

            var newWf = BulkWorkflowManager.CreateDefaultWorkflow(name.Trim());
            _config.Workflows.Add(newWf);
            _config.SelectedWorkflowId = newWf.Id;
            BulkWorkflowManager.SaveConfig(_config);

            PopulateWorkflows(newWf.Id);
        }

        private void BtnRenameWorkflow_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;

            string newName = PromptDialog.Show("Enter new name for workflow:", "Rename Workflow", _currentWorkflow.Name);
            if (string.IsNullOrWhiteSpace(newName) || newName.Trim() == _currentWorkflow.Name) return;

            string oldId = _currentWorkflow.Id;
            _currentWorkflow.Name = newName.Trim();

            // Update any workflow action referencing this workflow
            foreach (var wf in _config.Workflows)
            {
                if (wf.Steps == null) continue;
                foreach (var stp in wf.Steps)
                {
                    if (stp.Actions == null) continue;
                    foreach (var act in stp.Actions)
                    {
                        if ((act.ActionType == "Workflow" || act.ActionType == "RunWorkflow") && act.TargetWorkflowId == oldId)
                        {
                            act.TargetWorkflowName = newName.Trim();
                            act.Word = newName.Trim();
                        }
                    }
                }
            }

            BulkWorkflowManager.SaveConfig(_config);
            PopulateWorkflows(_currentWorkflow.Id);
        }

        private void BtnDuplicateWorkflow_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;

            SaveCurrentFormToModel();

            string cloneName = PromptDialog.Show("Enter name for duplicated workflow:", "Duplicate Workflow", $"{_currentWorkflow.Name} (Copy)");
            if (string.IsNullOrWhiteSpace(cloneName)) return;

            var cloned = _currentWorkflow.Clone(cloneName.Trim());
            _config.Workflows.Add(cloned);
            _config.SelectedWorkflowId = cloned.Id;
            BulkWorkflowManager.SaveConfig(_config);

            PopulateWorkflows(cloned.Id);
        }

        private void BtnDeleteWorkflow_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;

            if (_config.Workflows.Count <= 1)
            {
                MessageBox.Show("You must keep at least one workflow macro.", "Delete Workflow", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete workflow '{_currentWorkflow.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            _config.Workflows.Remove(_currentWorkflow);
            var nextWf = _config.Workflows[0];
            _config.SelectedWorkflowId = nextWf.Id;
            BulkWorkflowManager.SaveConfig(_config);

            PopulateWorkflows(nextWf.Id);
        }

        #endregion

        #region Step Navigation & Pagination

        private void BuildPaginationUI()
        {
            flpPageButtons.Controls.Clear();
            if (_currentWorkflow == null || _currentWorkflow.Steps.Count == 0) return;

            // Group into Main and Sub steps
            var mainSteps = _currentWorkflow.Steps.Where(s => !s.IsSubStep).ToList();
            var subSteps = _currentWorkflow.Steps.Where(s => s.IsSubStep).ToList();

            if (mainSteps.Count > 0)
            {
                Label lblMain = new Label
                {
                    Text = "MAIN:",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Margin = new Padding(2, 5, 2, 0)
                };
                flpPageButtons.Controls.Add(lblMain);

                int mainCounter = 1;
                foreach (var step in mainSteps)
                {
                    int stepIdx = _currentWorkflow.Steps.IndexOf(step);
                    flpPageButtons.Controls.Add(CreatePageButton(mainCounter.ToString(), stepIdx, false));
                    mainCounter++;
                }
            }

            if (subSteps.Count > 0)
            {
                Label lblSub = new Label
                {
                    Text = " | SUB:",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                    ForeColor = Color.DarkSlateBlue,
                    Margin = new Padding(3, 5, 2, 0)
                };
                flpPageButtons.Controls.Add(lblSub);

                int subCounter = 1;
                foreach (var step in subSteps)
                {
                    int stepIdx = _currentWorkflow.Steps.IndexOf(step);
                    flpPageButtons.Controls.Add(CreatePageButton($"S{subCounter}", stepIdx, true));
                    subCounter++;
                }
            }

            UpdatePaginationButtonsStyle();
            PopulateGotoStepsDropdown();
        }

        private Button CreatePageButton(string text, int targetIndex, bool isSub)
        {
            Button btn = new Button
            {
                Text = text,
                Width = 34,
                Height = 26,
                Margin = new Padding(2, 2, 2, 2),
                Tag = targetIndex,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 1;

            btn.Click += (s, e) =>
            {
                if (s is Button b && b.Tag is int idx)
                {
                    NavigateToStep(idx);
                }
            };

            return btn;
        }

        private void NavigateToStep(int targetIndex)
        {
            if (_currentWorkflow == null || targetIndex < 0 || targetIndex >= _currentWorkflow.Steps.Count) return;

            SaveCurrentFormToModel();
            _currentStepIndex = targetIndex;
            LoadStepToForm(_currentStepIndex);
            UpdatePaginationButtonsStyle();
            PopulateGotoStepsDropdown();
        }

        private void UpdatePaginationButtonsStyle()
        {
            if (_currentWorkflow == null || _currentStepIndex < 0 || _currentStepIndex >= _currentWorkflow.Steps.Count) return;

            var step = _currentWorkflow.Steps[_currentStepIndex];

            lblStepIndicator.Text = $"Step {_currentStepIndex + 1} of {_currentWorkflow.Steps.Count}: {step.CaptureTitle} ({(step.IsSubStep ? "SUB-STEP" : "MAIN STEP")})";
            lblStepIndicator.ForeColor = step.IsSubStep ? Color.DarkSlateBlue : Color.Black;

            btnPrevStep.Enabled = _currentStepIndex > 0;
            btnNextStep.Enabled = _currentStepIndex < _currentWorkflow.Steps.Count - 1;
            btnDeleteStep.Enabled = _currentWorkflow.Steps.Count > 1;

            foreach (Control c in flpPageButtons.Controls)
            {
                if (c is Button b && b.Tag is int idx)
                {
                    bool isCurrent = (idx == _currentStepIndex);
                    var bStep = _currentWorkflow.Steps[idx];

                    if (isCurrent)
                    {
                        b.BackColor = bStep.IsSubStep ? Color.DarkSlateBlue : Color.Black;
                        b.ForeColor = Color.White;
                        b.FlatAppearance.BorderColor = b.BackColor;
                    }
                    else
                    {
                        b.BackColor = Color.White;
                        b.ForeColor = bStep.IsSubStep ? Color.DarkSlateBlue : Color.Black;
                        b.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
                    }
                }
            }
        }

        private void BtnAddStep_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;

            SaveCurrentFormToModel();

            int mainCount = _currentWorkflow.Steps.Count(s => !s.IsSubStep);
            int newNum = mainCount + 1;
            var newStep = new TargetStepModel
            {
                StepIndex = _currentWorkflow.Steps.Count,
                StepTitle = $"Step_{newNum}",
                CaptureTitle = $"Main Step {newNum}",
                IsSubStep = false,
                BranchType = "Main",
                TemplateName = $"Macro_Step_{newNum}",
                ImagePath = string.Empty,
                Actions = new List<StepInputAction>()
            };

            _currentWorkflow.Steps.Add(newStep);
            BuildPaginationUI();
            NavigateToStep(_currentWorkflow.Steps.Count - 1);
        }

        private void BtnAddSubStep_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;

            SaveCurrentFormToModel();

            int subCount = _currentWorkflow.Steps.Count(s => s.IsSubStep);
            int newNum = subCount + 1;
            var newStep = new TargetStepModel
            {
                StepIndex = _currentWorkflow.Steps.Count,
                StepTitle = $"SubStep_{newNum}",
                CaptureTitle = $"Sub Step {newNum}",
                IsSubStep = true,
                BranchType = "SubStep",
                TemplateName = $"Macro_SubStep_{newNum}",
                ImagePath = string.Empty,
                Actions = new List<StepInputAction>()
            };

            _currentWorkflow.Steps.Add(newStep);
            BuildPaginationUI();
            NavigateToStep(_currentWorkflow.Steps.Count - 1);
        }

        private void BtnDeleteStep_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null || _currentWorkflow.Steps.Count <= 1)
            {
                MessageBox.Show("The workflow must have at least one step.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var stepToDelete = _currentWorkflow.Steps[_currentStepIndex];
            var confirm = MessageBox.Show($"Are you sure you want to delete '{stepToDelete.CaptureTitle}' ({stepToDelete.StepTitle})?", "Confirm Delete Step", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            _currentWorkflow.Steps.RemoveAt(_currentStepIndex);

            // Re-index steps
            for (int i = 0; i < _currentWorkflow.Steps.Count; i++)
            {
                _currentWorkflow.Steps[i].StepIndex = i;
            }

            _currentStepIndex = Math.Min(_currentStepIndex, _currentWorkflow.Steps.Count - 1);
            BuildPaginationUI();
            LoadStepToForm(_currentStepIndex);
        }

        #endregion

        #region Form <-> Model Binding

        private void SaveCurrentFormToModel()
        {
            if (_currentWorkflow == null || _currentStepIndex < 0 || _currentStepIndex >= _currentWorkflow.Steps.Count) return;

            var step = _currentWorkflow.Steps[_currentStepIndex];
            step.CaptureTitle = txtCaptureTitle.Text.Trim();
            step.TemplateName = txtTemplateName.Text.Trim();
            step.ImagePath = txtImagePath.Text.Trim();
        }

        private void LoadStepToForm(int index)
        {
            if (_currentWorkflow == null || index < 0 || index >= _currentWorkflow.Steps.Count) return;

            var step = _currentWorkflow.Steps[index];

            txtCaptureTitle.Text = step.CaptureTitle;
            txtTemplateName.Text = step.TemplateName;
            txtImagePath.Text = step.ImagePath;

            string titleDisplay = !string.IsNullOrWhiteSpace(step.CaptureTitle) ? step.CaptureTitle.ToUpper() : "STEP IMAGE";
            gbImageConfig.Text = $" {titleDisplay} (OPTIONAL ANCHOR) ";
            btnCaptureImage.Text = $"CAPTURE IMAGE — {titleDisplay}";

            lblActionList.Text = $"Action Sequence for {step.CaptureTitle} (Executed linearly):";

            LoadPreviewImage(step.ImagePath);
            RefreshActionsList();
            UpdateActionButtonsState();
            UpdatePaginationButtonsStyle();
            PopulateGotoStepsDropdown();
            PopulateTargetWorkflowsDropdown();
        }

        private void LoadPreviewImage(string path)
        {
            if (picPreview.Image != null)
            {
                var oldImg = picPreview.Image;
                picPreview.Image = null;
                oldImg.Dispose();
            }

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    picPreview.Image = Image.FromStream(stream);
                }
                catch
                {
                    picPreview.Image = null;
                }
            }
            picPreview.Invalidate();
        }

        #endregion

        #region Action List Management

        private void RefreshActionsList(int selectIndex = -1)
        {
            lstActions.Items.Clear();
            if (_currentWorkflow == null || _currentStepIndex < 0 || _currentStepIndex >= _currentWorkflow.Steps.Count) return;

            var step = _currentWorkflow.Steps[_currentStepIndex];
            step.Actions ??= new List<StepInputAction>();

            for (int i = 0; i < step.Actions.Count; i++)
            {
                lstActions.Items.Add($"{i + 1}. {step.Actions[i]}");
            }

            if (selectIndex >= 0 && selectIndex < lstActions.Items.Count)
            {
                lstActions.SelectedIndex = selectIndex;
            }
            else if (lstActions.Items.Count > 0)
            {
                lstActions.SelectedIndex = lstActions.Items.Count - 1;
            }

            UpdateActionButtonsState();
        }

        private void UpdateActionButtonsState()
        {
            int count = lstActions.Items.Count;
            int selIdx = lstActions.SelectedIndex;

            btnMoveUp.Enabled = selIdx > 0;
            btnMoveDown.Enabled = selIdx >= 0 && selIdx < count - 1;
            btnRemoveAction.Enabled = selIdx >= 0;
            btnClearActions.Enabled = count > 0;
            btnUpdateSelected.Enabled = selIdx >= 0;
        }

        private void LstActions_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateActionButtonsState();
            if (_currentWorkflow == null || _currentStepIndex < 0 || _currentStepIndex >= _currentWorkflow.Steps.Count) return;

            var step = _currentWorkflow.Steps[_currentStepIndex];
            int selIdx = lstActions.SelectedIndex;

            if (selIdx >= 0 && selIdx < step.Actions.Count)
            {
                var act = step.Actions[selIdx];
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
                    txtInputBoxPrompt.Text = act.PromptMessage ?? "Enter value:";
                }
                else if (act.ActionType == "AutoLogin")
                {
                    string mode = !string.IsNullOrWhiteSpace(act.AutoLoginMode) ? act.AutoLoginMode : (!string.IsNullOrWhiteSpace(act.Word) ? act.Word : "Standard Auto Login");
                    int modeIdx = cmbAutoLoginMode.FindStringExact(mode);
                    if (modeIdx >= 0) cmbAutoLoginMode.SelectedIndex = modeIdx;
                }
                else if (act.ActionType == "Goto")
                {
                    if (!string.IsNullOrEmpty(act.GotoStepTarget))
                    {
                        for (int i = 0; i < cmbGotoStep.Items.Count; i++)
                        {
                            string itemStr = cmbGotoStep.Items[i]?.ToString() ?? string.Empty;
                            if (itemStr.StartsWith(act.GotoStepTarget + ":", StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(itemStr, act.GotoStepTarget, StringComparison.OrdinalIgnoreCase))
                            {
                                cmbGotoStep.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else if (act.ActionType == "Workflow" || act.ActionType == "RunWorkflow")
                {
                    if (!string.IsNullOrEmpty(act.TargetWorkflowId))
                    {
                        for (int i = 0; i < cmbTargetWorkflow.Items.Count; i++)
                        {
                            if (cmbTargetWorkflow.Items[i] is WorkflowComboItem item && item.Workflow.Id == act.TargetWorkflowId)
                            {
                                cmbTargetWorkflow.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(act.TargetWorkflowName))
                    {
                        for (int i = 0; i < cmbTargetWorkflow.Items.Count; i++)
                        {
                            if (cmbTargetWorkflow.Items[i] is WorkflowComboItem item && string.Equals(item.Workflow.Name, act.TargetWorkflowName, StringComparison.OrdinalIgnoreCase))
                            {
                                cmbTargetWorkflow.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }

            picPreview.Invalidate();
        }

        private void BtnAddAutoLoginAction_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];

            string mode = cmbAutoLoginMode.SelectedItem?.ToString() ?? "Standard Auto Login";
            var action = new StepInputAction
            {
                ActionType = "AutoLogin",
                AutoLoginMode = mode,
                Word = mode
            };

            step.Actions.Add(action);
            RefreshActionsList(step.Actions.Count - 1);
        }

        private void BtnAddClearMemoryAction_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];

            var action = new StepInputAction
            {
                ActionType = "ClearMemory"
            };

            step.Actions.Add(action);
            RefreshActionsList(step.Actions.Count - 1);
        }

        private void BtnAddWorkflowAction_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];

            var selectedItem = cmbTargetWorkflow.SelectedItem as WorkflowComboItem;
            if (selectedItem == null || selectedItem.Workflow == null)
            {
                MessageBox.Show("Please select a valid macro workflow to run as a sub-workflow action.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var targetWf = selectedItem.Workflow;

            // Validate cycle & dependency inheritance exception
            if (!BulkWorkflowManager.CanWorkflowReference(_currentWorkflow, targetWf, _config.Workflows, out string reason))
            {
                MessageBox.Show(reason, "Invalid Workflow Reference", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var action = new StepInputAction
            {
                ActionType = "Workflow",
                TargetWorkflowId = targetWf.Id,
                TargetWorkflowName = targetWf.Name,
                Word = targetWf.Name
            };

            step.Actions.Add(action);
            RefreshActionsList(step.Actions.Count - 1);
        }

        private void BtnAddMouseAction_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];

            var action = new StepInputAction
            {
                ActionType = "Mouse",
                X = (int)numCoordX.Value,
                Y = (int)numCoordY.Value,
                ClickTypeIndex = cmbClickType.SelectedIndex,
                UseRelativeOffset = chkUseRelativeOffset.Checked
            };

            step.Actions.Add(action);
            RefreshActionsList(step.Actions.Count - 1);
        }

        private void BtnAddKeyAction_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyboardWord.Text))
            {
                MessageBox.Show("Please enter the keys or word to send.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKeyboardWord.Focus();
                return;
            }

            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];

            var action = new StepInputAction
            {
                ActionType = "Keyboard",
                Word = txtKeyboardWord.Text
            };

            step.Actions.Add(action);
            txtKeyboardWord.Clear();
            RefreshActionsList(step.Actions.Count - 1);
        }

        private void BtnAddDelayAction_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];

            var action = new StepInputAction
            {
                ActionType = "Delay",
                DelayMs = (int)numDelayMs.Value
            };

            step.Actions.Add(action);
            RefreshActionsList(step.Actions.Count - 1);
        }

        private void BtnAddInputBoxAction_Click(object? sender, EventArgs e)
        {
            string prompt = string.IsNullOrWhiteSpace(txtInputBoxPrompt.Text) ? "Enter required value:" : txtInputBoxPrompt.Text.Trim();
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];

            var action = new StepInputAction
            {
                ActionType = "InputBox",
                PromptMessage = prompt
            };

            step.Actions.Add(action);
            RefreshActionsList(step.Actions.Count - 1);
        }

        private void BtnUpdateSelected_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];
            int selIdx = lstActions.SelectedIndex;
            if (selIdx < 0 || selIdx >= step.Actions.Count) return;

            var existing = step.Actions[selIdx];
            if (existing.ActionType == "Mouse")
            {
                existing.X = (int)numCoordX.Value;
                existing.Y = (int)numCoordY.Value;
                existing.ClickTypeIndex = cmbClickType.SelectedIndex;
                existing.UseRelativeOffset = chkUseRelativeOffset.Checked;
            }
            else if (existing.ActionType == "Keyboard")
            {
                if (string.IsNullOrEmpty(txtKeyboardWord.Text))
                {
                    MessageBox.Show("Please enter the keyboard sequence.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                existing.Word = txtKeyboardWord.Text;
            }
            else if (existing.ActionType == "Delay")
            {
                existing.DelayMs = (int)numDelayMs.Value;
            }
            else if (existing.ActionType == "InputBox")
            {
                existing.PromptMessage = string.IsNullOrWhiteSpace(txtInputBoxPrompt.Text) ? "Enter required value:" : txtInputBoxPrompt.Text.Trim();
            }
            else if (existing.ActionType == "AutoLogin")
            {
                string mode = cmbAutoLoginMode.SelectedItem?.ToString() ?? "Standard Auto Login";
                existing.AutoLoginMode = mode;
                existing.Word = mode;
            }
            else if (existing.ActionType == "Goto")
            {
                if (cmbGotoStep.SelectedItem != null)
                {
                    string rawSelected = cmbGotoStep.SelectedItem.ToString() ?? string.Empty;
                    existing.GotoStepTarget = rawSelected.Contains(":") ? rawSelected.Split(':')[0].Trim() : rawSelected.Trim();
                }
            }
            else if (existing.ActionType == "Workflow" || existing.ActionType == "RunWorkflow")
            {
                var selectedItem = cmbTargetWorkflow.SelectedItem as WorkflowComboItem;
                if (selectedItem == null || selectedItem.Workflow == null)
                {
                    MessageBox.Show("Please select a valid macro workflow to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var targetWf = selectedItem.Workflow;
                if (!BulkWorkflowManager.CanWorkflowReference(_currentWorkflow, targetWf, _config.Workflows, out string reason))
                {
                    MessageBox.Show(reason, "Invalid Workflow Reference", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                existing.TargetWorkflowId = targetWf.Id;
                existing.TargetWorkflowName = targetWf.Name;
                existing.Word = targetWf.Name;
            }

            RefreshActionsList(selIdx);
            picPreview.Invalidate();
        }

        private void BtnMoveUp_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];
            int selIdx = lstActions.SelectedIndex;
            if (selIdx <= 0 || selIdx >= step.Actions.Count) return;

            var item = step.Actions[selIdx];
            step.Actions.RemoveAt(selIdx);
            step.Actions.Insert(selIdx - 1, item);

            RefreshActionsList(selIdx - 1);
            picPreview.Invalidate();
        }

        private void BtnMoveDown_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];
            int selIdx = lstActions.SelectedIndex;
            if (selIdx < 0 || selIdx >= step.Actions.Count - 1) return;

            var item = step.Actions[selIdx];
            step.Actions.RemoveAt(selIdx);
            step.Actions.Insert(selIdx + 1, item);

            RefreshActionsList(selIdx + 1);
            picPreview.Invalidate();
        }

        private void BtnRemoveAction_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];
            int selIdx = lstActions.SelectedIndex;
            if (selIdx < 0 || selIdx >= step.Actions.Count) return;

            step.Actions.RemoveAt(selIdx);
            int nextSel = Math.Min(selIdx, step.Actions.Count - 1);
            RefreshActionsList(nextSel);
            picPreview.Invalidate();
        }

        private void BtnClearActions_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];
            if (step.Actions.Count == 0) return;

            var confirm = MessageBox.Show("Clear all actions for this step?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                step.Actions.Clear();
                RefreshActionsList();
                picPreview.Invalidate();
            }
        }

        private void AppendKeyText(string key)
        {
            txtKeyboardWord.Text += key;
            txtKeyboardWord.Focus();
            txtKeyboardWord.SelectionStart = txtKeyboardWord.Text.Length;
        }

        #endregion

        #region Preview & Image Coordinate Translation

        private void BtnAddBreakAction_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            var step = _currentWorkflow.Steps[_currentStepIndex];

            var action = new StepInputAction
            {
                ActionType = "Break"
            };

            step.Actions.Add(action);
            RefreshActionsList(step.Actions.Count - 1);
        }

        private void BtnAddGotoAction_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null || cmbGotoStep.SelectedItem == null)
            {
                MessageBox.Show("Please select a target step to jump to.", "Target Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string rawSelected = cmbGotoStep.SelectedItem.ToString() ?? string.Empty;
            string targetTitle = rawSelected.Contains(":") ? rawSelected.Split(':')[0].Trim() : rawSelected.Trim();

            var step = _currentWorkflow.Steps[_currentStepIndex];
            var action = new StepInputAction
            {
                ActionType = "Goto",
                GotoStepTarget = targetTitle
            };

            step.Actions.Add(action);
            RefreshActionsList(step.Actions.Count - 1);
        }

        private void PopulateGotoStepsDropdown()
        {
            if (_currentWorkflow == null) return;
            string? currentSelection = cmbGotoStep.SelectedItem?.ToString();
            cmbGotoStep.BeginUpdate();
            cmbGotoStep.Items.Clear();

            for (int i = 0; i < _currentWorkflow.Steps.Count; i++)
            {
                var s = _currentWorkflow.Steps[i];
                string title = !string.IsNullOrEmpty(s.CaptureTitle) ? s.CaptureTitle : s.StepTitle;
                string typeDesc = s.IsSubStep ? "SUB" : "MAIN";
                cmbGotoStep.Items.Add($"{s.StepTitle}: {title} [{typeDesc}]");
            }

            if (!string.IsNullOrEmpty(currentSelection))
            {
                int found = -1;
                for (int i = 0; i < cmbGotoStep.Items.Count; i++)
                {
                    if (string.Equals(cmbGotoStep.Items[i]?.ToString(), currentSelection, StringComparison.OrdinalIgnoreCase))
                    {
                        found = i;
                        break;
                    }
                }
                if (found >= 0) cmbGotoStep.SelectedIndex = found;
                else if (cmbGotoStep.Items.Count > 0) cmbGotoStep.SelectedIndex = 0;
            }
            else if (cmbGotoStep.Items.Count > 0)
            {
                cmbGotoStep.SelectedIndex = 0;
            }

            cmbGotoStep.EndUpdate();
        }

        private void PopulateTargetWorkflowsDropdown(string? selectWorkflowId = null)
        {
            if (_currentWorkflow == null || _config.Workflows == null) return;
            string? currentSelectedId = (cmbTargetWorkflow.SelectedItem as WorkflowComboItem)?.Workflow?.Id ?? selectWorkflowId;

            cmbTargetWorkflow.BeginUpdate();
            cmbTargetWorkflow.Items.Clear();

            var validTargets = BulkWorkflowManager.GetValidTargetWorkflows(_currentWorkflow, _config.Workflows);
            int selectedIndex = -1;

            for (int i = 0; i < validTargets.Count; i++)
            {
                var wf = validTargets[i];
                cmbTargetWorkflow.Items.Add(new WorkflowComboItem(wf));
                if (!string.IsNullOrEmpty(currentSelectedId) && wf.Id == currentSelectedId)
                {
                    selectedIndex = i;
                }
            }

            if (selectedIndex >= 0)
            {
                cmbTargetWorkflow.SelectedIndex = selectedIndex;
            }
            else if (cmbTargetWorkflow.Items.Count > 0)
            {
                cmbTargetWorkflow.SelectedIndex = 0;
            }

            cmbTargetWorkflow.EndUpdate();
        }

        private class WorkflowComboItem
        {
            public BulkWorkflowModel Workflow { get; }
            public WorkflowComboItem(BulkWorkflowModel wf) => Workflow = wf;
            public override string ToString() => Workflow.Name;
        }

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

            Point? imgPt = TranslatePreviewToImage(e.Location);
            if (imgPt.HasValue)
            {
                chkUseRelativeOffset.Checked = true;
                numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, imgPt.Value.X));
                numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, imgPt.Value.Y));

                // If a mouse action is currently selected in the list, update it
                if (_currentWorkflow != null && _currentStepIndex >= 0 && _currentStepIndex < _currentWorkflow.Steps.Count)
                {
                    var step = _currentWorkflow.Steps[_currentStepIndex];
                    int selIdx = lstActions.SelectedIndex;
                    if (selIdx >= 0 && selIdx < step.Actions.Count)
                    {
                        var selAction = step.Actions[selIdx];
                        if (selAction.ActionType == "Mouse")
                        {
                            selAction.X = (int)numCoordX.Value;
                            selAction.Y = (int)numCoordY.Value;
                            selAction.UseRelativeOffset = true;
                            RefreshActionsList(selIdx);
                        }
                    }
                }

                picPreview.Invalidate();
            }
        }

        private void PicPreview_Paint(object? sender, PaintEventArgs e)
        {
            if (picPreview.Image == null || _currentWorkflow == null || _currentStepIndex < 0 || _currentStepIndex >= _currentWorkflow.Steps.Count) return;

            var step = _currentWorkflow.Steps[_currentStepIndex];
            int selectedIdx = lstActions.SelectedIndex;

            // Draw crosshairs for all relative mouse actions in this step
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
                        using Pen pen = new Pen(color, isSelected ? 2 : 1);
                        using Brush brush = new SolidBrush(color);
                        using Font font = new Font("Segoe UI", 8F, FontStyle.Bold);

                        e.Graphics.DrawEllipse(pen, x - 8, y - 8, 16, 16);
                        e.Graphics.DrawLine(pen, x - 12, y, x + 12, y);
                        e.Graphics.DrawLine(pen, x, y - 12, x, y + 12);
                        e.Graphics.FillEllipse(brush, x - 2, y - 2, 4, 4);

                        string badge = (i + 1).ToString();
                        e.Graphics.DrawString(badge, font, brush, x + 8, y - 12);
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
                    using Pen pen = new Pen(Color.LimeGreen, 2);
                    using Brush brush = new SolidBrush(Color.LimeGreen);

                    e.Graphics.DrawEllipse(pen, x - 8, y - 8, 16, 16);
                    e.Graphics.DrawLine(pen, x - 12, y, x + 12, y);
                    e.Graphics.DrawLine(pen, x, y - 12, x, y + 12);
                    e.Graphics.FillEllipse(brush, x - 2, y - 2, 4, 4);
                }
            }
        }

        #endregion

        #region Image Capture & Coordinate Picker

        private async Task HideForCaptureAsync()
        {
            this.Opacity = 0;
            this.WindowState = FormWindowState.Minimized;
            await Task.Delay(250);
        }

        private void RestoreAfterCapture()
        {
            if (!this.IsDisposed)
            {
                this.Opacity = 1.0;
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                this.Activate();
                picPreview?.Invalidate();
            }
        }

        private async void BtnCaptureImage_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;

            await HideForCaptureAsync();

            try
            {
                Rectangle selectedArea = SelectScreenArea();
                if (selectedArea.Width > 0 && selectedArea.Height > 0)
                {
                    using Bitmap screenshot = CaptureScreenRegion(selectedArea);
                    string wfIdSub = _currentWorkflow.Id.Length > 8 ? _currentWorkflow.Id.Substring(0, 8) : _currentWorkflow.Id;
                    string fileName = $"bulk_{wfIdSub}_step_{_currentStepIndex + 1}.png";
                    string savePath = Path.Combine(storageDirectory, fileName);

                    screenshot.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);

                    txtImagePath.Text = savePath;
                    _currentWorkflow.Steps[_currentStepIndex].ImagePath = savePath;
                    LoadPreviewImage(savePath);

                    // Center relative click default if coordinate is 0
                    if (numCoordX.Value == 0 && numCoordY.Value == 0)
                    {
                        numCoordX.Value = selectedArea.Width / 2;
                        numCoordY.Value = selectedArea.Height / 2;
                        chkUseRelativeOffset.Checked = true;
                    }

                    if (_currentWorkflow.Steps[_currentStepIndex].Actions.Count == 0)
                    {
                        _currentWorkflow.Steps[_currentStepIndex].Actions.Add(new StepInputAction
                        {
                            ActionType = "Mouse",
                            X = selectedArea.Width / 2,
                            Y = selectedArea.Height / 2,
                            ClickTypeIndex = 0,
                            UseRelativeOffset = true
                        });
                        RefreshActionsList(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error capturing image: {ex.Message}", "Capture Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RestoreAfterCapture();
            }
        }

        private void BtnClearImage_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;

            var step = _currentWorkflow.Steps[_currentStepIndex];
            step.ImagePath = string.Empty;
            txtImagePath.Text = string.Empty;
            LoadPreviewImage(string.Empty);
            picPreview.Invalidate();
        }

        private async void BtnCaptureCoords_Click(object? sender, EventArgs e)
        {
            await HideForCaptureAsync();

            try
            {
                Point clickedPoint = Point.Empty;
                Bitmap? screenBitmap = null;
                Rectangle fullScreenBounds = SystemInformation.VirtualScreen;

                try
                {
                    using (ScreenCaptureForm form = new ScreenCaptureForm(ScreenCaptureMode.Point))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            clickedPoint = form.SelectedPoint;
                            // Capture screen bitmap immediately while form is still hidden
                            if (chkUseRelativeOffset.Checked && !string.IsNullOrEmpty(txtImagePath.Text) && File.Exists(txtImagePath.Text))
                            {
                                screenBitmap = CaptureScreenRegion(fullScreenBounds);
                            }
                        }
                    }
                }
                finally
                {
                    RestoreAfterCapture();
                }

                if (!clickedPoint.IsEmpty)
                {
                    int finalX = clickedPoint.X;
                    int finalY = clickedPoint.Y;

                    // If relative offset is checked and template exists, calculate offset from template on screen
                    if (screenBitmap != null && !string.IsNullOrEmpty(txtImagePath.Text) && File.Exists(txtImagePath.Text))
                    {
                        using (screenBitmap)
                        using (Mat screenMat = BitmapConverter.ToMat(screenBitmap))
                        using (Mat templateMat = Cv2.ImRead(txtImagePath.Text, ImreadModes.Color))
                        using (Mat resultMat = new Mat())
                        using (Mat screenBGR = new Mat())
                        {
                            if (screenMat.Channels() == 4)
                                Cv2.CvtColor(screenMat, screenBGR, ColorConversionCodes.BGRA2BGR);
                            else
                                screenMat.CopyTo(screenBGR);

                            Cv2.MatchTemplate(screenBGR, templateMat, resultMat, TemplateMatchModes.CCoeffNormed);
                            Cv2.MinMaxLoc(resultMat, out _, out double maxVal, out _, out OpenCvSharp.Point maxLoc);

                            if (maxVal >= 0.70)
                            {
                                int templateScreenX = fullScreenBounds.X + maxLoc.X;
                                int templateScreenY = fullScreenBounds.Y + maxLoc.Y;

                                finalX = clickedPoint.X - templateScreenX;
                                finalY = clickedPoint.Y - templateScreenY;
                            }
                            else
                            {
                                MessageBox.Show(this, $"Template was not detected on screen (match: {maxVal:F2}). Coordinates recorded as absolute.", "Coordinate Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                chkUseRelativeOffset.Checked = false;
                            }
                        }
                    }

                    numCoordX.Value = Math.Max(numCoordX.Minimum, Math.Min(numCoordX.Maximum, finalX));
                    numCoordY.Value = Math.Max(numCoordY.Minimum, Math.Min(numCoordY.Maximum, finalY));

                    // Add mouse action to the workflow sequence (just like AutoLoginSettingsForm)
                    if (_currentWorkflow != null && _currentStepIndex >= 0 && _currentStepIndex < _currentWorkflow.Steps.Count)
                    {
                        var step = _currentWorkflow.Steps[_currentStepIndex];
                        int clickType = cmbClickType.SelectedIndex >= 0 ? cmbClickType.SelectedIndex : 0;

                        if (step.Actions.Count == 0)
                        {
                            step.Actions.Add(new StepInputAction
                            {
                                ActionType = "Mouse",
                                X = (int)numCoordX.Value,
                                Y = (int)numCoordY.Value,
                                ClickTypeIndex = clickType,
                                UseRelativeOffset = chkUseRelativeOffset.Checked
                            });
                            RefreshActionsList(0);
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show(this,
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
                                    ClickTypeIndex = clickType,
                                    UseRelativeOffset = chkUseRelativeOffset.Checked
                                });
                                RefreshActionsList(step.Actions.Count - 1);
                            }
                        }

                        picPreview.Invalidate();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error capturing coordinate: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RestoreAfterCapture();
            }
        }

        #endregion

        #region Test Execution

        private async void BtnTestExecution_Click(object? sender, EventArgs e)
        {
            if (_currentWorkflow == null) return;
            SaveCurrentFormToModel();

            var step = _currentWorkflow.Steps[_currentStepIndex];
            if (step.Actions.Count == 0)
            {
                MessageBox.Show("No actions configured for this step. Please add at least one mouse or keyboard action.", "No Actions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await HideForCaptureAsync();

            try
            {
                OpenCvSharp.Point matchLoc = new OpenCvSharp.Point(0, 0);
                Rectangle screenSize = SystemInformation.VirtualScreen;

                if (!string.IsNullOrEmpty(step.ImagePath) && File.Exists(step.ImagePath))
                {
                    using Bitmap fullScreenBitmap = CaptureScreenRegion(screenSize);
                    using Mat screenMat = BitmapConverter.ToMat(fullScreenBitmap);
                    using Mat templateMat = Cv2.ImRead(step.ImagePath, ImreadModes.Color);
                    using Mat resultMat = new Mat();
                    using Mat screenBGR = new Mat();

                    if (screenMat.Channels() == 4)
                        Cv2.CvtColor(screenMat, screenBGR, ColorConversionCodes.BGRA2BGR);
                    else
                        screenMat.CopyTo(screenBGR);

                    Cv2.MatchTemplate(screenBGR, templateMat, resultMat, TemplateMatchModes.CCoeffNormed);
                    Cv2.MinMaxLoc(resultMat, out _, out double maxVal, out _, out matchLoc);

                    if (maxVal < 0.80)
                    {
                        MessageBox.Show(this, $"Target image not found on screen.\nMatch Score: {maxVal:F2} (Threshold >= 0.80 required)", "Match Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                // Execute linear actions
                int executedCount = 0;
                var dummyAccount = new ApplicationLogic.DataLoginFormat
                {
                    username = "TestUser",
                    password = "TestPassword",
                    secondPassword = "TestSecondPassword",
                    nickname = "TestNick"
                };

                foreach (var action in step.Actions)
                {
                    if (action.ActionType == "Mouse")
                    {
                        int targetX, targetY;
                        if (action.UseRelativeOffset ?? true)
                        {
                            targetX = screenSize.X + matchLoc.X + (action.X ?? 0);
                            targetY = screenSize.Y + matchLoc.Y + (action.Y ?? 0);
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
                            string resolved = AutoLoginPatternLogic.Case.ResolveVariables(action.Word, dummyAccount);
                            SendKeys.SendWait(resolved);
                            executedCount++;
                            await Task.Delay(250);
                        }
                    }
                    else if (action.ActionType == "Delay")
                    {
                        await Task.Delay(action.DelayMs ?? 500);
                        executedCount++;
                    }
                    else if (action.ActionType == "InputBox")
                    {
                        string prompt = string.IsNullOrWhiteSpace(action.PromptMessage) ? "Enter value:" : action.PromptMessage;
                        string val = PromptDialog.Show(prompt);
                        if (!string.IsNullOrEmpty(val))
                        {
                            await Task.Delay(200);
                            SendKeys.SendWait(val);
                        }
                        executedCount++;
                        await Task.Delay(250);
                    }
                    else if (action.ActionType == "Break")
                    {
                        executedCount++;
                        MessageBox.Show(this, "🛑 [Break Action]\nWorkflow would stop for this window and advance to the next process.", "Break Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else if (action.ActionType == "Goto")
                    {
                        executedCount++;
                        MessageBox.Show(this, $"↪ [Goto Action]\nWorkflow would jump to target: \"{action.GotoStepTarget}\".", "Goto Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else if (action.ActionType == "AutoLogin")
                    {
                        executedCount++;
                        string mode = !string.IsNullOrWhiteSpace(action.AutoLoginMode) ? action.AutoLoginMode : (!string.IsNullOrWhiteSpace(action.Word) ? action.Word : "Standard Auto Login");
                        MessageBox.Show(this, $"🔐 [Auto-Login Action]\nWorkflow would trigger {mode} for the current window using its matched account credentials.", "Auto-Login Action Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (action.ActionType == "ClearMemory")
                    {
                        executedCount++;
                        MessageBox.Show(this, "🧹 [Clear Memory Action]\nWorkflow would silently clear working set memory for the current process.", "Clear Memory Action Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (action.ActionType == "Workflow" || action.ActionType == "RunWorkflow")
                    {
                        executedCount++;
                        string wfName = !string.IsNullOrWhiteSpace(action.TargetWorkflowName) ? action.TargetWorkflowName : (!string.IsNullOrWhiteSpace(action.Word) ? action.Word : "Sub-Workflow");
                        MessageBox.Show(this, $"📋 [Workflow Action]\nWorkflow would execute sub-workflow: \"{wfName}\" for the current window.", "Workflow Action Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                MessageBox.Show(this, $"Executed {executedCount} action(s) successfully.", "Test Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error running test execution: {ex.Message}", "Test Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RestoreAfterCapture();
            }
        }

        #endregion

        #region Save & Screen Capture Helpers

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            SaveCurrentFormToModel();

            if (_currentWorkflow != null)
            {
                _config.SelectedWorkflowId = _currentWorkflow.Id;
            }

            BulkWorkflowManager.SaveConfig(_config);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private Rectangle SelectScreenArea()
        {
            using ScreenCaptureForm form = new ScreenCaptureForm(ScreenCaptureMode.Area);
            if (form.ShowDialog() == DialogResult.OK)
            {
                return form.SelectedArea;
            }
            return Rectangle.Empty;
        }

        private Bitmap CaptureScreenRegion(Rectangle region)
        {
            Bitmap bitmap = new Bitmap(region.Width, region.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(region.Location, Point.Empty, region.Size);
            }
            return bitmap;
        }

        private void PerformClick(int x, int y, int clickType)
        {
            InputWindow.ClickAt(x, y, clickType);
        }

        #endregion
    }
}
