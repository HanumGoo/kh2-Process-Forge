using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProcessForge.Config;
using ProcessForge.FindWindowLogic;
using ProcessForge.RefreshLogic;

namespace ProcessForge
{
    public partial class BulkWindowForm : Form
    {
        // Core state
        private string ProcessName = string.Empty;
        private List<ProcessData> DetectedProcesses = new List<ProcessData>();
        private BulkWindowConfig BulkConfig = new BulkWindowConfig();
        private int SelectedGroupIndex = 0; // 0 = All Detected, 1 = Ungrouped, 2+ = Custom Groups

        // Legacy / Import state
        private bool isUsingImport = false;
        private int PageCount = 1;

        public BulkWindowForm(string processName)
        {
            InitializeComponent();
            ProcessName = processName;
            FormStartup();
            RefreshAll();
        }

        public void FormStartup()
        {
            ProcessListLabel.Text = !string.IsNullOrEmpty(ProcessName)
                ? $"BULK PROCESS MANAGER — {ProcessName.ToUpper()}"
                : "BULK PROCESS MANAGER";

            // Double buffering on flow panels to avoid flicker
            typeof(FlowLayoutPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(flowGroupProcesses, true, null);
            typeof(FlowLayoutPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(flowLayoutPanel, true, null);

            // Load saved config
            try
            {
                var fullConfig = AppConfigManager.LoadConfig();
                if (fullConfig.BulkWindow != null)
                {
                    BulkConfig = fullConfig.BulkWindow;
                    BulkConfig.Groups ??= new List<ProcessGroupModel>();
                    BulkConfig.OriginalWindowBounds ??= new Dictionary<string, WindowBoundsModel>(StringComparer.OrdinalIgnoreCase);
                }
            }
            catch { }

            // Wire Header Events
            btnHeaderAutoSplit.Click += BtnHeaderAutoSplit_Click;
            btnHeaderRefresh.Click += (s, e) => RefreshAll();
            btnHeaderSave.Click += (s, e) => SaveGroupsConfig(true);

            // Wire Group Manager Events
            btnAddGroup.Click += BtnAddGroup_Click;
            btnAddByName.Click += BtnAddByName_Click;
            lstGroups.SelectedIndexChanged += LstGroups_SelectedIndexChanged;
            txtGroupSearch.TextChanged += (s, e) => RenderGroupProcesses();
            btnGroupClearSearch.Click += (s, e) => { txtGroupSearch.Clear(); };
            btnAddProcessToGroup.Click += BtnAddProcessToGroup_Click;

            btnGroupRestoreAll.Click += BtnGroupRestoreAll_Click;
            btnGroupMinimizeAll.Click += BtnGroupMinimizeAll_Click;
            btnGroupTile.Click += BtnGroupTile_Click;
            btnGroupRestoreBounds.Click += BtnGroupRestoreBounds_Click;
            btnGroupTerminateAll.Click += BtnGroupTerminateAll_Click;
            btnRenameGroup.Click += BtnRenameGroup_Click;
            btnDeleteGroup.Click += BtnDeleteGroup_Click;

            flowGroupProcesses.Resize += (s, e) => ResizeProcessCards();

            // Wire Legacy Events
            btnSearch.Click += (s, e) => ExecuteSearch();
            btnClearSearch.Click += (s, e) => { txtSearch.Clear(); ExecuteSearch(); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ExecuteSearch();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        #region Refresh & Scanning

        public void RefreshAll()
        {
            if (string.IsNullOrEmpty(ProcessName))
            {
                MessageBox.Show("Please specify a Process Name on the main form first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Scan running processes
            Process[] allProcesses = Process.GetProcessesByName(ProcessName);
            DetectedProcesses.Clear();
            bool boundsRecorded = false;

            // Load latest config to ensure any background bounds recorded by StartApplication are present
            var currentConfig = AppConfigManager.LoadConfig();
            BulkConfig.OriginalWindowBounds = currentConfig.BulkWindow.OriginalWindowBounds ?? new Dictionary<string, WindowBoundsModel>(StringComparer.OrdinalIgnoreCase);

            foreach (Process p in allProcesses)
            {
                if (!string.IsNullOrEmpty(p.MainWindowTitle))
                {
                    DetectedProcesses.Add(new ProcessData
                    {
                        TitleName = p.MainWindowTitle,
                        ProcessId = p.Id
                    });

                    // Capture initial window bounds if not already recorded
                    if (!BulkConfig.OriginalWindowBounds.ContainsKey(p.MainWindowTitle))
                    {
                        var bounds = GetAndFindWindow.GetWindowBounds(p.Id);
                        if (bounds.HasValue && bounds.Value.Width > 50 && bounds.Value.Height > 50)
                        {
                            BulkConfig.OriginalWindowBounds[p.MainWindowTitle] = new WindowBoundsModel(
                                bounds.Value.X, bounds.Value.Y, bounds.Value.Width, bounds.Value.Height);
                            boundsRecorded = true;
                        }
                    }
                }
            }

            if (boundsRecorded)
            {
                SaveGroupsConfig(false);
            }

            // 2. Update Header
            ProcessListLabel.Text = $"BULK PROCESS MANAGER — {ProcessName.ToUpper()} ({DetectedProcesses.Count} RUNNING)";

            // 3. Update Group Manager View
            UpdateGroupListView();

            // 4. Update Legacy View
            RefreshFunction();
        }

        private void UpdateGroupListView()
        {
            lstGroups.BeginUpdate();
            try
            {
                int prevSelected = lstGroups.SelectedIndex >= 0 ? lstGroups.SelectedIndex : SelectedGroupIndex;
                lstGroups.Items.Clear();

                // Compute counts
                var assignedTitles = new HashSet<string>(BulkConfig.Groups.SelectMany(g => g.ProcessTitles));
                int ungroupedCount = DetectedProcesses.Count(p => !assignedTitles.Contains(p.TitleName));

                lstGroups.Items.Add($"★ All Detected ({DetectedProcesses.Count})");
                lstGroups.Items.Add($"● Ungrouped ({ungroupedCount})");

                for (int i = 0; i < BulkConfig.Groups.Count; i++)
                {
                    var grp = BulkConfig.Groups[i];
                    int runningInGrp = grp.ProcessTitles.Count(t => DetectedProcesses.Any(p => p.TitleName == t));
                    lstGroups.Items.Add($"📁 {grp.GroupName} ({runningInGrp})");
                }

                if (prevSelected >= 0 && prevSelected < lstGroups.Items.Count)
                {
                    lstGroups.SelectedIndex = prevSelected;
                }
                else if (lstGroups.Items.Count > 0)
                {
                    lstGroups.SelectedIndex = 0;
                }
            }
            finally
            {
                lstGroups.EndUpdate();
            }

            RenderGroupProcesses();
        }

        #endregion

        #region Group Management & Selection

        private void LstGroups_SelectedIndexChanged(object? sender, EventArgs e)
        {
            SelectedGroupIndex = lstGroups.SelectedIndex;
            UpdateGroupActionsState();
            RenderGroupProcesses();
        }

        private void UpdateGroupActionsState()
        {
            bool isCustomGroup = SelectedGroupIndex >= 2 && (SelectedGroupIndex - 2) < BulkConfig.Groups.Count;

            if (isCustomGroup)
            {
                var grp = BulkConfig.Groups[SelectedGroupIndex - 2];
                lblGroupActionsTitle.Text = $"Actions for: {grp.GroupName}";
                btnRenameGroup.Enabled = true;
                btnDeleteGroup.Enabled = true;
                btnAddProcessToGroup.Visible = true;
            }
            else if (SelectedGroupIndex == 1)
            {
                lblGroupActionsTitle.Text = "Actions: Ungrouped Processes";
                btnRenameGroup.Enabled = false;
                btnDeleteGroup.Enabled = false;
                btnAddProcessToGroup.Visible = false;
            }
            else
            {
                lblGroupActionsTitle.Text = "Actions: All Detected Processes";
                btnRenameGroup.Enabled = false;
                btnDeleteGroup.Enabled = false;
                btnAddProcessToGroup.Visible = false;
            }
        }

        private List<ProcessData> GetCurrentViewProcesses()
        {
            var search = txtGroupSearch.Text.Trim().ToLowerInvariant();

            List<ProcessData> result;

            if (SelectedGroupIndex == 0)
            {
                // All Detected
                result = new List<ProcessData>(DetectedProcesses);
            }
            else if (SelectedGroupIndex == 1)
            {
                // Ungrouped
                var assigned = new HashSet<string>(BulkConfig.Groups.SelectMany(g => g.ProcessTitles));
                result = DetectedProcesses.Where(p => !assigned.Contains(p.TitleName)).ToList();
            }
            else if (SelectedGroupIndex >= 2 && (SelectedGroupIndex - 2) < BulkConfig.Groups.Count)
            {
                // Specific custom group
                var grp = BulkConfig.Groups[SelectedGroupIndex - 2];
                result = new List<ProcessData>();

                // Preserve the linear order of titles in the group
                foreach (string title in grp.ProcessTitles)
                {
                    var match = DetectedProcesses.FirstOrDefault(p => p.TitleName == title);
                    if (match != null)
                    {
                        result.Add(match);
                    }
                    else
                    {
                        // Window offline but in group
                        result.Add(new ProcessData
                        {
                            TitleName = title,
                            ProcessId = 0
                        });
                    }
                }
            }
            else
            {
                result = new List<ProcessData>();
            }

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.TitleName.ToLowerInvariant().Contains(search) ||
                                           (p.ProcessId > 0 && p.ProcessId.ToString().Contains(search))).ToList();
            }

            return result;
        }

        private void RenderGroupProcesses()
        {
            flowGroupProcesses.SuspendLayout();
            try
            {
                flowGroupProcesses.Controls.Clear();
                var items = GetCurrentViewProcesses();

                // Update right toolbar title
                if (SelectedGroupIndex == 0)
                {
                    lblSelectedGroupTitle.Text = $"★ All Detected Processes ({items.Count})";
                }
                else if (SelectedGroupIndex == 1)
                {
                    lblSelectedGroupTitle.Text = $"● Ungrouped Processes ({items.Count})";
                }
                else if (SelectedGroupIndex >= 2 && (SelectedGroupIndex - 2) < BulkConfig.Groups.Count)
                {
                    var grp = BulkConfig.Groups[SelectedGroupIndex - 2];
                    lblSelectedGroupTitle.Text = $"📁 {grp.GroupName} ({items.Count} items)";
                }

                bool isCustomGroup = SelectedGroupIndex >= 2 && (SelectedGroupIndex - 2) < BulkConfig.Groups.Count;
                int cardWidth = Math.Max(480, flowGroupProcesses.ClientSize.Width - 25);

                for (int i = 0; i < items.Count; i++)
                {
                    var pData = items[i];
                    Panel card = CreateProcessCard(pData, i, items.Count, isCustomGroup, cardWidth);
                    flowGroupProcesses.Controls.Add(card);
                }

                if (items.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No processes to display in this view.",
                        ForeColor = Color.DimGray,
                        Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point),
                        AutoSize = true,
                        Padding = new Padding(20)
                    };
                    flowGroupProcesses.Controls.Add(lblEmpty);
                }
            }
            finally
            {
                flowGroupProcesses.ResumeLayout(true);
            }
        }

        private Panel CreateProcessCard(ProcessData pData, int index, int totalCount, bool isCustomGroup, int cardWidth)
        {
            Panel card = new Panel
            {
                Width = cardWidth,
                Height = 44,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3, 3, 3, 3)
            };

            // Index
            Label lblIndex = new Label
            {
                Text = $"#{index + 1}",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.DimGray,
                Location = new Point(8, 13),
                Size = new Size(35, 20)
            };

            // Title
            Label lblTitle = new Label
            {
                Text = pData.TitleName,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.Black,
                Location = new Point(45, 11),
                Size = new Size(Math.Max(150, cardWidth - 430), 22),
                AutoEllipsis = true
            };

            // PID / Status
            Label lblPid = new Label
            {
                Text = pData.ProcessId > 0 ? $"PID: {pData.ProcessId}" : "(Offline)",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = pData.ProcessId > 0 ? Color.FromArgb(40, 120, 40) : Color.DarkRed,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(cardWidth - 380, 13),
                Size = new Size(75, 20)
            };

            // Buttons: Restore, Minimize, Move To, [Up, Down, Remove / Terminate]
            Button btnRestore = new Button
            {
                Text = "Restore",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point),
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(cardWidth - 295, 8),
                Size = new Size(62, 26),
                Cursor = Cursors.Hand,
                Enabled = pData.ProcessId > 0
            };
            btnRestore.Click += (s, e) =>
            {
                if (pData.ProcessId > 0)
                {
                    if (BulkConfig.OriginalWindowBounds.TryGetValue(pData.TitleName, out var b))
                    {
                        GetAndFindWindow.SetWindowBounds(pData.ProcessId, b.X, b.Y, b.Width, b.Height);
                    }
                    else
                    {
                        GetAndFindWindow.WindowRestore(pData.ProcessId);
                    }
                }
            };

            Button btnMinimize = new Button
            {
                Text = "Minimize",
                Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(cardWidth - 230, 8),
                Size = new Size(64, 26),
                Cursor = Cursors.Hand,
                Enabled = pData.ProcessId > 0
            };
            btnMinimize.Click += (s, e) =>
            {
                if (pData.ProcessId > 0)
                {
                    GetAndFindWindow.WindowMinimize(pData.ProcessId);
                }
            };

            Button btnMoveTo = new Button
            {
                Text = "Group ▼",
                Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point),
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(cardWidth - 162, 8),
                Size = new Size(65, 26),
                Cursor = Cursors.Hand
            };
            btnMoveTo.Click += (s, e) => ShowMoveToContextMenu(btnMoveTo, pData.TitleName);

            card.Controls.Add(lblIndex);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblPid);
            card.Controls.Add(btnRestore);
            card.Controls.Add(btnMinimize);
            card.Controls.Add(btnMoveTo);

            if (isCustomGroup)
            {
                // Order buttons
                Button btnUp = new Button
                {
                    Text = "▲",
                    Font = new Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Location = new Point(cardWidth - 92, 8),
                    Size = new Size(26, 26),
                    Cursor = Cursors.Hand,
                    Enabled = index > 0
                };
                btnUp.Click += (s, e) => MoveProcess(pData.TitleName, -1);

                Button btnDown = new Button
                {
                    Text = "▼",
                    Font = new Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Location = new Point(cardWidth - 63, 8),
                    Size = new Size(26, 26),
                    Cursor = Cursors.Hand,
                    Enabled = index < totalCount - 1
                };
                btnDown.Click += (s, e) => MoveProcess(pData.TitleName, 1);

                Button btnRemove = new Button
                {
                    Text = "✕",
                    Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point),
                    BackColor = Color.FromArgb(170, 30, 30),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Location = new Point(cardWidth - 34, 8),
                    Size = new Size(26, 26),
                    Cursor = Cursors.Hand
                };
                btnRemove.Click += (s, e) => RemoveFromCurrentGroup(pData.TitleName);

                card.Controls.Add(btnUp);
                card.Controls.Add(btnDown);
                card.Controls.Add(btnRemove);
            }
            else
            {
                // Terminate button
                Button btnTerm = new Button
                {
                    Text = "Terminate",
                    Font = new Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point),
                    BackColor = Color.FromArgb(170, 30, 30),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Location = new Point(cardWidth - 92, 8),
                    Size = new Size(84, 26),
                    Cursor = Cursors.Hand,
                    Enabled = pData.ProcessId > 0
                };
                btnTerm.Click += (s, e) =>
                {
                    if (pData.ProcessId <= 0) return;
                    var res = MessageBox.Show($"Terminate process \"{pData.TitleName}\" (PID: {pData.ProcessId})?", "Confirm Terminate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            Process.GetProcessById(pData.ProcessId).Kill();
                            RefreshAll();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to terminate process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };

                card.Controls.Add(btnTerm);
            }

            return card;
        }

        private void ResizeProcessCards()
        {
            int cardWidth = Math.Max(480, flowGroupProcesses.ClientSize.Width - 25);
            foreach (Control c in flowGroupProcesses.Controls)
            {
                if (c is Panel card)
                {
                    card.Width = cardWidth;
                }
            }
        }

        #endregion

        #region Auto-Split & Linear Grouping

        private void BtnHeaderAutoSplit_Click(object? sender, EventArgs e)
        {
            if (DetectedProcesses.Count == 0)
            {
                MessageBox.Show("No running processes detected to split.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new AutoSplitDialog(DetectedProcesses.Count);
            if (dlg.ShowDialog(this) == DialogResult.OK && dlg.Result.Success)
            {
                var res = dlg.Result;

                if (res.ResetExisting)
                {
                    BulkConfig.Groups.Clear();
                }

                int total = DetectedProcesses.Count;
                int gCount = Math.Max(1, res.GroupCount);
                int perGroup = res.ProcessesPerGroup;

                for (int i = 0; i < gCount; i++)
                {
                    int startIdx = i * perGroup;
                    if (startIdx >= total && i > 0) break;

                    int endIdx = (i == gCount - 1) ? total : Math.Min(total, (i + 1) * perGroup);
                    int count = Math.Max(0, endIdx - startIdx);

                    var slice = DetectedProcesses.Skip(startIdx).Take(count).Select(p => p.TitleName).ToList();

                    string groupName = $"{res.GroupPrefix.Trim()} {i + 1}";

                    // If group name already exists, make unique
                    int renameCounter = 2;
                    string finalName = groupName;
                    while (BulkConfig.Groups.Any(g => g.GroupName.Equals(finalName, StringComparison.OrdinalIgnoreCase)))
                    {
                        finalName = $"{groupName} ({renameCounter++})";
                    }

                    BulkConfig.Groups.Add(new ProcessGroupModel(finalName, slice));
                }

                SaveGroupsConfig(false);
                SelectedGroupIndex = 2; // Select Group 1
                UpdateGroupListView();
                MessageBox.Show($"Successfully split {total} processes into {BulkConfig.Groups.Count} groups!", "Auto-Split Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Move, Reorder & Group Membership

        private void ShowMoveToContextMenu(Button anchor, string processTitle)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            // Find which group currently contains this title
            var currentGroup = BulkConfig.Groups.FirstOrDefault(g => g.ProcessTitles.Contains(processTitle));

            // Option: Ungroup
            var miUngroup = new ToolStripMenuItem("● Ungrouped (Remove from group)");
            miUngroup.Enabled = currentGroup != null;
            miUngroup.Click += (s, e) =>
            {
                if (currentGroup != null)
                {
                    currentGroup.ProcessTitles.Remove(processTitle);
                    SaveGroupsConfig(false);
                    UpdateGroupListView();
                }
            };
            menu.Items.Add(miUngroup);
            menu.Items.Add(new ToolStripSeparator());

            // List custom groups
            for (int i = 0; i < BulkConfig.Groups.Count; i++)
            {
                var targetGroup = BulkConfig.Groups[i];
                var miGroup = new ToolStripMenuItem($"📁 {targetGroup.GroupName}");
                if (targetGroup == currentGroup)
                {
                    miGroup.Checked = true;
                    miGroup.Enabled = false;
                }
                miGroup.Click += (s, e) =>
                {
                    // Remove from old group
                    if (currentGroup != null)
                    {
                        currentGroup.ProcessTitles.Remove(processTitle);
                    }
                    // Add to new group
                    if (!targetGroup.ProcessTitles.Contains(processTitle))
                    {
                        targetGroup.ProcessTitles.Add(processTitle);
                    }
                    SaveGroupsConfig(false);
                    UpdateGroupListView();
                };
                menu.Items.Add(miGroup);
            }

            menu.Items.Add(new ToolStripSeparator());
            var miNewGroup = new ToolStripMenuItem("+ Create New Group for this process...");
            miNewGroup.Click += (s, e) =>
            {
                string[]? res = InputBox.Show("Enter name for new group:", "New Group", false, $"Group {BulkConfig.Groups.Count + 1}");
                if (res != null && !string.IsNullOrWhiteSpace(res[0]))
                {
                    string newName = res[0].Trim();
                    if (currentGroup != null)
                    {
                        currentGroup.ProcessTitles.Remove(processTitle);
                    }
                    var newGroup = new ProcessGroupModel(newName, new[] { processTitle });
                    BulkConfig.Groups.Add(newGroup);
                    SaveGroupsConfig(false);
                    SelectedGroupIndex = BulkConfig.Groups.Count + 1;
                    UpdateGroupListView();
                }
            };
            menu.Items.Add(miNewGroup);

            menu.Show(anchor, new Point(0, anchor.Height));
        }

        private void MoveProcess(string processTitle, int direction)
        {
            if (SelectedGroupIndex < 2) return;
            int gIndex = SelectedGroupIndex - 2;
            if (gIndex >= BulkConfig.Groups.Count) return;

            var grp = BulkConfig.Groups[gIndex];
            int idx = grp.ProcessTitles.IndexOf(processTitle);
            if (idx < 0) return;

            int targetIdx = idx + direction;
            if (targetIdx >= 0 && targetIdx < grp.ProcessTitles.Count)
            {
                grp.ProcessTitles.RemoveAt(idx);
                grp.ProcessTitles.Insert(targetIdx, processTitle);
                SaveGroupsConfig(false);
                RenderGroupProcesses();
            }
        }

        private void RemoveFromCurrentGroup(string processTitle)
        {
            if (SelectedGroupIndex < 2) return;
            int gIndex = SelectedGroupIndex - 2;
            if (gIndex >= BulkConfig.Groups.Count) return;

            var grp = BulkConfig.Groups[gIndex];
            grp.ProcessTitles.Remove(processTitle);
            SaveGroupsConfig(false);
            UpdateGroupListView();
        }

        private void BtnAddByName_Click(object? sender, EventArgs e)
        {
            ProcessGroupModel targetGroup;

            if (SelectedGroupIndex >= 2 && (SelectedGroupIndex - 2) < BulkConfig.Groups.Count)
            {
                targetGroup = BulkConfig.Groups[SelectedGroupIndex - 2];
            }
            else
            {
                if (BulkConfig.Groups.Count == 0)
                {
                    string[]? newGrpRes = InputBox.Show("No groups exist yet. Enter a name for the first group:", "Create Group", false, "Group 1");
                    if (newGrpRes == null || string.IsNullOrWhiteSpace(newGrpRes[0])) return;
                    targetGroup = new ProcessGroupModel(newGrpRes[0].Trim());
                    BulkConfig.Groups.Add(targetGroup);
                }
                else
                {
                    targetGroup = BulkConfig.Groups[0];
                }
            }

            string[]? res = InputBox.Show(
                $"Enter window title / process name to add to \"{targetGroup.GroupName}\":\n(The window does not need to be open right now; it will link automatically once online)",
                "Add Window by Name",
                false,
                "");

            if (res != null && !string.IsNullOrWhiteSpace(res[0]))
            {
                string name = res[0].Trim();

                if (targetGroup.ProcessTitles.Contains(name))
                {
                    MessageBox.Show($"\"{name}\" is already in {targetGroup.GroupName}.", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if it's already in another group
                var otherGrp = BulkConfig.Groups.FirstOrDefault(g => g != targetGroup && g.ProcessTitles.Contains(name));
                if (otherGrp != null)
                {
                    var moveConfirm = MessageBox.Show($"\"{name}\" is currently in \"{otherGrp.GroupName}\". Move it to \"{targetGroup.GroupName}\"?", "Move Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (moveConfirm == DialogResult.Yes)
                    {
                        otherGrp.ProcessTitles.Remove(name);
                    }
                    else
                    {
                        return;
                    }
                }

                targetGroup.ProcessTitles.Add(name);
                SaveGroupsConfig(false);
                UpdateGroupListView();

                bool isOnline = DetectedProcesses.Any(p => p.TitleName.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (isOnline)
                {
                    MessageBox.Show($"Added \"{name}\" to {targetGroup.GroupName}.\nStatus: Online (Active PID detected)!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Added \"{name}\" to {targetGroup.GroupName}.\nStatus: Offline. When this window/process launches, it will automatically appear active here.", "Added to Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnAddProcessToGroup_Click(object? sender, EventArgs e)
        {
            if (SelectedGroupIndex < 2) return;
            int gIndex = SelectedGroupIndex - 2;
            if (gIndex >= BulkConfig.Groups.Count) return;

            var grp = BulkConfig.Groups[gIndex];
            var assigned = new HashSet<string>(BulkConfig.Groups.SelectMany(g => g.ProcessTitles));
            var available = DetectedProcesses.Where(p => !assigned.Contains(p.TitleName)).ToList();

            ContextMenuStrip menu = new ContextMenuStrip();

            var miTypeManual = new ToolStripMenuItem("✏ Type Window Name Manually...");
            miTypeManual.Font = new Font(miTypeManual.Font, FontStyle.Bold);
            miTypeManual.Click += (s, ev) => BtnAddByName_Click(sender, e);
            menu.Items.Add(miTypeManual);
            menu.Items.Add(new ToolStripSeparator());

            if (available.Count == 0)
            {
                var miNone = new ToolStripMenuItem("(No unassigned running processes)");
                miNone.Enabled = false;
                menu.Items.Add(miNone);
            }
            else
            {
                foreach (var p in available)
                {
                    var mi = new ToolStripMenuItem($"Add \"{p.TitleName}\" (PID: {p.ProcessId})");
                    mi.Click += (s, ev) =>
                    {
                        if (!grp.ProcessTitles.Contains(p.TitleName))
                        {
                            grp.ProcessTitles.Add(p.TitleName);
                            SaveGroupsConfig(false);
                            UpdateGroupListView();
                        }
                    };
                    menu.Items.Add(mi);
                }

                menu.Items.Add(new ToolStripSeparator());
                var miAddAll = new ToolStripMenuItem($"Add All {available.Count} Ungrouped Running Processes");
                miAddAll.Click += (s, ev) =>
                {
                    foreach (var p in available)
                    {
                        if (!grp.ProcessTitles.Contains(p.TitleName))
                        {
                            grp.ProcessTitles.Add(p.TitleName);
                        }
                    }
                    SaveGroupsConfig(false);
                    UpdateGroupListView();
                };
                menu.Items.Add(miAddAll);
            }

            menu.Show(btnAddProcessToGroup, new Point(0, btnAddProcessToGroup.Height));
        }

        #endregion

        #region Group Batch Actions (Restore All, Minimize All, Tile, Terminate)

        private List<int> GetCurrentGroupProcessIds()
        {
            var pDataList = GetCurrentViewProcesses();
            return pDataList.Where(p => p.ProcessId > 0).Select(p => p.ProcessId).ToList();
        }

        private void BtnGroupRestoreAll_Click(object? sender, EventArgs e)
        {
            var pids = GetCurrentGroupProcessIds();
            if (pids.Count == 0)
            {
                MessageBox.Show("No active processes to restore in this view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GetAndFindWindow.RestoreWindows(pids);
        }

        private void BtnGroupMinimizeAll_Click(object? sender, EventArgs e)
        {
            var pids = GetCurrentGroupProcessIds();
            if (pids.Count == 0)
            {
                MessageBox.Show("No active processes to minimize in this view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GetAndFindWindow.MinimizeWindows(pids);
        }

        private void BtnGroupTile_Click(object? sender, EventArgs e)
        {
            var pDataList = GetCurrentViewProcesses().Where(p => p.ProcessId > 0).ToList();
            if (pDataList.Count == 0)
            {
                MessageBox.Show("No active processes to tile in this view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Capture and save original window locations and sizes before tiling if not already saved
            bool capturedAny = false;
            foreach (var p in pDataList)
            {
                if (!BulkConfig.OriginalWindowBounds.ContainsKey(p.TitleName))
                {
                    var bounds = GetAndFindWindow.GetWindowBounds(p.ProcessId);
                    if (bounds.HasValue && bounds.Value.Width > 50 && bounds.Value.Height > 50)
                    {
                        BulkConfig.OriginalWindowBounds[p.TitleName] = new WindowBoundsModel(
                            bounds.Value.X, bounds.Value.Y, bounds.Value.Width, bounds.Value.Height);
                        capturedAny = true;
                    }
                }
            }

            if (capturedAny)
            {
                SaveGroupsConfig(false);
            }

            var pids = pDataList.Select(p => p.ProcessId).ToList();
            GetAndFindWindow.TileWindows(pids);
        }

        private void BtnGroupRestoreBounds_Click(object? sender, EventArgs e)
        {
            // Reload latest config to get all saved bounds from application starts
            var latestConfig = AppConfigManager.LoadConfig();
            BulkConfig.OriginalWindowBounds = latestConfig.BulkWindow.OriginalWindowBounds ?? new Dictionary<string, WindowBoundsModel>(StringComparer.OrdinalIgnoreCase);

            var pDataList = GetCurrentViewProcesses().Where(p => p.ProcessId > 0).ToList();
            if (pDataList.Count == 0)
            {
                MessageBox.Show("No active processes in this view to restore.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Find a common fallback window size from existing recorded bounds if available
            WindowBoundsModel? defaultFallback = BulkConfig.OriginalWindowBounds.Values.FirstOrDefault(b => b.Width > 100 && b.Height > 100);

            int restoredCount = 0;
            foreach (var p in pDataList)
            {
                WindowBoundsModel? targetBounds = null;
                if (BulkConfig.OriginalWindowBounds.TryGetValue(p.TitleName, out var b))
                {
                    targetBounds = b;
                }
                else if (defaultFallback != null)
                {
                    targetBounds = defaultFallback;
                }

                if (targetBounds != null)
                {
                    GetAndFindWindow.SetWindowBounds(p.ProcessId, targetBounds.X, targetBounds.Y, targetBounds.Width, targetBounds.Height);
                    restoredCount++;
                }
                else
                {
                    // Fallback to basic restore and foreground
                    GetAndFindWindow.WindowRestore(p.ProcessId);
                }
            }

            if (restoredCount > 0)
            {
                //MessageBox.Show($"Restored original location and size for {restoredCount} window(s)!", "Layout Recovered", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No saved original window locations found for these processes.\nWindows have been brought to the foreground.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGroupTerminateAll_Click(object? sender, EventArgs e)
        {
            var pids = GetCurrentGroupProcessIds();
            if (pids.Count == 0)
            {
                MessageBox.Show("No active processes to terminate in this view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string groupName = SelectedGroupIndex >= 2 && (SelectedGroupIndex - 2) < BulkConfig.Groups.Count
                ? BulkConfig.Groups[SelectedGroupIndex - 2].GroupName
                : (SelectedGroupIndex == 1 ? "Ungrouped" : "All Detected");

            var confirm = MessageBox.Show($"Are you sure you want to terminate ALL {pids.Count} process(es) in '{groupName}'?", "Confirm Bulk Terminate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                foreach (int pid in pids)
                {
                    try
                    {
                        Process.GetProcessById(pid).Kill();
                    }
                    catch { }
                }
                RefreshAll();
            }
        }

        private void BtnRenameGroup_Click(object? sender, EventArgs e)
        {
            if (SelectedGroupIndex < 2) return;
            int gIndex = SelectedGroupIndex - 2;
            if (gIndex >= BulkConfig.Groups.Count) return;

            var grp = BulkConfig.Groups[gIndex];
            string[]? res = InputBox.Show("Enter new name for this group:", "Rename Group", false, grp.GroupName);
            if (res != null && !string.IsNullOrWhiteSpace(res[0]))
            {
                grp.GroupName = res[0].Trim();
                SaveGroupsConfig(false);
                UpdateGroupListView();
            }
        }

        private void BtnDeleteGroup_Click(object? sender, EventArgs e)
        {
            if (SelectedGroupIndex < 2) return;
            int gIndex = SelectedGroupIndex - 2;
            if (gIndex >= BulkConfig.Groups.Count) return;

            var grp = BulkConfig.Groups[gIndex];
            var confirm = MessageBox.Show($"Delete group '{grp.GroupName}'?\n(Processes in this group will become ungrouped)", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                BulkConfig.Groups.RemoveAt(gIndex);
                SaveGroupsConfig(false);
                SelectedGroupIndex = Math.Min(SelectedGroupIndex, BulkConfig.Groups.Count + 1);
                UpdateGroupListView();
            }
        }

        private void BtnAddGroup_Click(object? sender, EventArgs e)
        {
            string[]? res = InputBox.Show("Enter new group name:", "Add Group", false, $"Group {BulkConfig.Groups.Count + 1}");
            if (res != null && !string.IsNullOrWhiteSpace(res[0]))
            {
                string name = res[0].Trim();
                BulkConfig.Groups.Add(new ProcessGroupModel(name));
                SaveGroupsConfig(false);
                SelectedGroupIndex = BulkConfig.Groups.Count + 1;
                UpdateGroupListView();
            }
        }

        private void SaveGroupsConfig(bool showMessage)
        {
            try
            {
                AppConfigManager.SaveBulkWindowConfig(BulkConfig);
                if (showMessage)
                {
                    MessageBox.Show("Group configuration saved successfully to main_config.json.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (showMessage)
                {
                    MessageBox.Show($"Failed to save group configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveGroupsConfig(false);
            base.OnFormClosing(e);
        }

        #endregion

        #region Legacy / Flat List & Import Features

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (PageCount == 1) return;
            PageCount -= 1;
            RefreshFunction();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName(ProcessName).Length < PageCount * 100) return;
            PageCount += 1;
            RefreshFunction();
        }

        private void RefreshFunction()
        {
            if (string.IsNullOrEmpty(ProcessName)) return;

            if (!isUsingImport)
            {
                RefreshLogic.RefreshLogic.Refresh(flowLayoutPanel, LabelPage, PageCount, DetectedProcesses);
            }
            else
            {
                string path = ImportTextbox.Text;
                if (!File.Exists(path) || string.IsNullOrEmpty(path))
                {
                    return;
                }

                string[] allData = File.ReadAllText(path).Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
                List<List<string>> allDataImport = new List<List<string>>
                {
                    new List<string>(),
                    new List<string>()
                };

                foreach (string item in allData)
                {
                    string[] titleAndStatus = item.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (titleAndStatus.Length == 2)
                    {
                        allDataImport[0].Add(titleAndStatus[0]);
                        allDataImport[1].Add(titleAndStatus[1]);
                    }
                }

                RefreshLogic.RefreshLogic.RefreshWIthNotepadCheck(flowLayoutPanel, LabelPage, PageCount, ImportTextbox.Text, DetectedProcesses, allDataImport);
            }
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                ExecuteSearch();
            }
        }

        private void ExecuteSearch()
        {
            string search = txtSearch.Text.Trim().ToLower();

            flowLayoutPanel.SuspendLayout();
            try
            {
                bool isTrue = false;
                bool isTrueSecond = false;
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    if (control is Button button)
                    {
                        if (button.Tag is ButtonData data)
                        {
                            if (string.IsNullOrEmpty(search) || data.Text.ToLower().Contains(search))
                            {
                                button.Visible = true;
                                isTrue = true;
                            }
                            else
                            {
                                button.Visible = false;
                                isTrue = false;
                            }
                        }
                        else if (isTrue)
                        {
                            button.Visible = true;
                            isTrue = false;
                            isTrueSecond = true;
                        }
                        else
                        {
                            if (isTrueSecond)
                            {
                                button.Visible = true;
                                isTrueSecond = false;
                            }
                            else
                            {
                                button.Visible = false;
                            }
                        }
                    }
                }
            }
            finally
            {
                flowLayoutPanel.ResumeLayout(true);
            }
        }

        private void OnOffImport_Click(object sender, EventArgs e)
        {
            isUsingImport = !isUsingImport;

            if (isUsingImport)
            {
                panel3.BackColor = Color.Green;
                OnOffImport.Text = "Off";
            }
            else
            {
                panel3.BackColor = Color.Red;
                OnOffImport.Text = "On";
            }
        }

        private void CheckImport_Click(object sender, EventArgs e)
        {
            string path = ImportTextbox.Text;

            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isn't right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] allData = File.ReadAllText(path).Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in allData)
            {
                string[] titleAndStatus = item.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                if (titleAndStatus.Length != 2)
                {
                    MessageBox.Show("Import Data error! please check this one: \n" + $"\"{item}\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            MessageBox.Show("The import file was valid.\nReady to go!", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImportBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".txt file (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImportTextbox.Text = ofd.FileName;
            }
        }

        #endregion
    }
}
