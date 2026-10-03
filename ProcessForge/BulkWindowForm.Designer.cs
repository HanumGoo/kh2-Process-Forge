namespace ProcessForge
{
    partial class BulkWindowForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkWindowForm));
            pnlHeader = new Panel();
            lblHeaderSubtitle = new Label();
            ProcessListLabel = new Label();
            btnHeaderAutoSplit = new Button();
            btnHeaderRefresh = new Button();
            btnHeaderSave = new Button();
            tabControlMain = new TabControl();
            tabGroupManager = new TabPage();
            pnlGroupRight = new Panel();
            flowGroupProcesses = new FlowLayoutPanel();
            pnlRightToolbar = new Panel();
            lblSelectedGroupTitle = new Label();
            txtGroupSearch = new TextBox();
            btnGroupClearSearch = new Button();
            btnAddByName = new Button();
            btnAddProcessToGroup = new Button();
            pnlGroupLeft = new Panel();
            lstGroups = new ListBox();
            pnlGroupActions = new Panel();
            lblGroupActionsTitle = new Label();
            btnGroupRestoreAll = new Button();
            btnGroupMinimizeAll = new Button();
            btnGroupTile = new Button();
            btnGroupRestoreBounds = new Button();
            btnGroupTerminateAll = new Button();
            btnRenameGroup = new Button();
            btnDeleteGroup = new Button();
            pnlLeftHeader = new Panel();
            lblGroupsHeader = new Label();
            btnAddGroup = new Button();
            tabLegacy = new TabPage();
            pnlContent = new Panel();
            flowLayoutPanel = new FlowLayoutPanel();
            pnlFooter = new Panel();
            LabelPage = new Label();
            PreviousButton = new Button();
            NextButton = new Button();
            pnlToolbar = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClearSearch = new Button();
            RefreshButton = new Button();
            label2 = new Label();
            panel3 = new Panel();
            OnOffImport = new Button();
            CheckImport = new Button();
            lblFilePath = new Label();
            ImportTextbox = new TextBox();
            ImportBrowse = new Button();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            pnlHeader.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabGroupManager.SuspendLayout();
            pnlGroupRight.SuspendLayout();
            pnlRightToolbar.SuspendLayout();
            pnlGroupLeft.SuspendLayout();
            pnlGroupActions.SuspendLayout();
            pnlLeftHeader.SuspendLayout();
            tabLegacy.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Black;
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(ProcessListLabel);
            pnlHeader.Controls.Add(btnHeaderAutoSplit);
            pnlHeader.Controls.Add(btnHeaderRefresh);
            pnlHeader.Controls.Add(btnHeaderSave);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 65);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 8.25F);
            lblHeaderSubtitle.ForeColor = Color.LightGray;
            lblHeaderSubtitle.Location = new Point(17, 34);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(272, 13);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Manage processes into groups with batch controls.";
            // 
            // ProcessListLabel
            // 
            ProcessListLabel.AutoSize = true;
            ProcessListLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ProcessListLabel.ForeColor = Color.White;
            ProcessListLabel.Location = new Point(16, 9);
            ProcessListLabel.Name = "ProcessListLabel";
            ProcessListLabel.Size = new Size(196, 20);
            ProcessListLabel.TabIndex = 0;
            ProcessListLabel.Text = "BULK PROCESS MANAGER";
            // 
            // btnHeaderAutoSplit
            // 
            btnHeaderAutoSplit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHeaderAutoSplit.BackColor = Color.FromArgb(0, 192, 192);
            btnHeaderAutoSplit.Cursor = Cursors.Hand;
            btnHeaderAutoSplit.FlatStyle = FlatStyle.Flat;
            btnHeaderAutoSplit.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnHeaderAutoSplit.ForeColor = Color.White;
            btnHeaderAutoSplit.Location = new Point(620, 16);
            btnHeaderAutoSplit.Name = "btnHeaderAutoSplit";
            btnHeaderAutoSplit.Size = new Size(150, 32);
            btnHeaderAutoSplit.TabIndex = 2;
            btnHeaderAutoSplit.Text = "⚡ Auto-Split Groups";
            btnHeaderAutoSplit.UseVisualStyleBackColor = false;
            // 
            // btnHeaderRefresh
            // 
            btnHeaderRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHeaderRefresh.BackColor = Color.FromArgb(50, 50, 50);
            btnHeaderRefresh.Cursor = Cursors.Hand;
            btnHeaderRefresh.FlatStyle = FlatStyle.Flat;
            btnHeaderRefresh.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnHeaderRefresh.ForeColor = Color.White;
            btnHeaderRefresh.Location = new Point(780, 16);
            btnHeaderRefresh.Name = "btnHeaderRefresh";
            btnHeaderRefresh.Size = new Size(95, 32);
            btnHeaderRefresh.TabIndex = 3;
            btnHeaderRefresh.Text = "🔄 Refresh";
            btnHeaderRefresh.UseVisualStyleBackColor = false;
            // 
            // btnHeaderSave
            // 
            btnHeaderSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHeaderSave.BackColor = Color.FromArgb(30, 70, 140);
            btnHeaderSave.Cursor = Cursors.Hand;
            btnHeaderSave.FlatStyle = FlatStyle.Flat;
            btnHeaderSave.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnHeaderSave.ForeColor = Color.White;
            btnHeaderSave.Location = new Point(885, 16);
            btnHeaderSave.Name = "btnHeaderSave";
            btnHeaderSave.Size = new Size(100, 32);
            btnHeaderSave.TabIndex = 4;
            btnHeaderSave.Text = "💾 Save";
            btnHeaderSave.UseVisualStyleBackColor = false;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabGroupManager);
            tabControlMain.Controls.Add(tabLegacy);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tabControlMain.Location = new Point(0, 65);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1000, 655);
            tabControlMain.TabIndex = 1;
            // 
            // tabGroupManager
            // 
            tabGroupManager.BackColor = Color.White;
            tabGroupManager.Controls.Add(pnlGroupRight);
            tabGroupManager.Controls.Add(pnlGroupLeft);
            tabGroupManager.Font = new Font("Segoe UI", 9F);
            tabGroupManager.Location = new Point(4, 24);
            tabGroupManager.Name = "tabGroupManager";
            tabGroupManager.Padding = new Padding(3);
            tabGroupManager.Size = new Size(992, 627);
            tabGroupManager.TabIndex = 0;
            tabGroupManager.Text = "Group Manager";
            // 
            // pnlGroupRight
            // 
            pnlGroupRight.Controls.Add(flowGroupProcesses);
            pnlGroupRight.Controls.Add(pnlRightToolbar);
            pnlGroupRight.Dock = DockStyle.Fill;
            pnlGroupRight.Location = new Point(283, 3);
            pnlGroupRight.Name = "pnlGroupRight";
            pnlGroupRight.Size = new Size(706, 621);
            pnlGroupRight.TabIndex = 1;
            // 
            // flowGroupProcesses
            // 
            flowGroupProcesses.AutoScroll = true;
            flowGroupProcesses.BackColor = Color.White;
            flowGroupProcesses.Dock = DockStyle.Fill;
            flowGroupProcesses.Location = new Point(0, 48);
            flowGroupProcesses.Name = "flowGroupProcesses";
            flowGroupProcesses.Padding = new Padding(8);
            flowGroupProcesses.Size = new Size(706, 573);
            flowGroupProcesses.TabIndex = 1;
            // 
            // pnlRightToolbar
            // 
            pnlRightToolbar.BackColor = Color.WhiteSmoke;
            pnlRightToolbar.BorderStyle = BorderStyle.FixedSingle;
            pnlRightToolbar.Controls.Add(lblSelectedGroupTitle);
            pnlRightToolbar.Controls.Add(txtGroupSearch);
            pnlRightToolbar.Controls.Add(btnGroupClearSearch);
            pnlRightToolbar.Controls.Add(btnAddByName);
            pnlRightToolbar.Controls.Add(btnAddProcessToGroup);
            pnlRightToolbar.Dock = DockStyle.Top;
            pnlRightToolbar.Location = new Point(0, 0);
            pnlRightToolbar.Name = "pnlRightToolbar";
            pnlRightToolbar.Size = new Size(706, 48);
            pnlRightToolbar.TabIndex = 0;
            // 
            // lblSelectedGroupTitle
            // 
            lblSelectedGroupTitle.AutoSize = true;
            lblSelectedGroupTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectedGroupTitle.Location = new Point(12, 13);
            lblSelectedGroupTitle.Name = "lblSelectedGroupTitle";
            lblSelectedGroupTitle.Size = new Size(134, 19);
            lblSelectedGroupTitle.TabIndex = 0;
            lblSelectedGroupTitle.Text = "Selected Group (0)";
            // 
            // txtGroupSearch
            // 
            txtGroupSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtGroupSearch.BorderStyle = BorderStyle.FixedSingle;
            txtGroupSearch.Font = new Font("Segoe UI", 9F);
            txtGroupSearch.Location = new Point(220, 12);
            txtGroupSearch.Name = "txtGroupSearch";
            txtGroupSearch.PlaceholderText = "Search...";
            txtGroupSearch.Size = new Size(135, 23);
            txtGroupSearch.TabIndex = 1;
            // 
            // btnGroupClearSearch
            // 
            btnGroupClearSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGroupClearSearch.BackColor = Color.White;
            btnGroupClearSearch.Cursor = Cursors.Hand;
            btnGroupClearSearch.FlatStyle = FlatStyle.Flat;
            btnGroupClearSearch.Font = new Font("Segoe UI", 8F);
            btnGroupClearSearch.Location = new Point(360, 11);
            btnGroupClearSearch.Name = "btnGroupClearSearch";
            btnGroupClearSearch.Size = new Size(48, 25);
            btnGroupClearSearch.TabIndex = 2;
            btnGroupClearSearch.Text = "Clear";
            btnGroupClearSearch.UseVisualStyleBackColor = false;
            // 
            // btnAddByName
            // 
            btnAddByName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddByName.BackColor = Color.FromArgb(40, 167, 69);
            btnAddByName.Cursor = Cursors.Hand;
            btnAddByName.FlatStyle = FlatStyle.Flat;
            btnAddByName.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnAddByName.ForeColor = Color.White;
            btnAddByName.Location = new Point(415, 10);
            btnAddByName.Name = "btnAddByName";
            btnAddByName.Size = new Size(130, 27);
            btnAddByName.TabIndex = 3;
            btnAddByName.Text = "+ Add by Name";
            btnAddByName.UseVisualStyleBackColor = false;
            // 
            // btnAddProcessToGroup
            // 
            btnAddProcessToGroup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProcessToGroup.BackColor = Color.Black;
            btnAddProcessToGroup.Cursor = Cursors.Hand;
            btnAddProcessToGroup.FlatStyle = FlatStyle.Flat;
            btnAddProcessToGroup.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnAddProcessToGroup.ForeColor = Color.White;
            btnAddProcessToGroup.Location = new Point(555, 10);
            btnAddProcessToGroup.Name = "btnAddProcessToGroup";
            btnAddProcessToGroup.Size = new Size(140, 27);
            btnAddProcessToGroup.TabIndex = 4;
            btnAddProcessToGroup.Text = "+ Add Running ▼";
            btnAddProcessToGroup.UseVisualStyleBackColor = false;
            // 
            // pnlGroupLeft
            // 
            pnlGroupLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlGroupLeft.Controls.Add(lstGroups);
            pnlGroupLeft.Controls.Add(pnlGroupActions);
            pnlGroupLeft.Controls.Add(pnlLeftHeader);
            pnlGroupLeft.Dock = DockStyle.Left;
            pnlGroupLeft.Location = new Point(3, 3);
            pnlGroupLeft.Name = "pnlGroupLeft";
            pnlGroupLeft.Size = new Size(280, 621);
            pnlGroupLeft.TabIndex = 0;
            // 
            // lstGroups
            // 
            lstGroups.BorderStyle = BorderStyle.None;
            lstGroups.Dock = DockStyle.Fill;
            lstGroups.Font = new Font("Segoe UI", 9.5F);
            lstGroups.Location = new Point(0, 42);
            lstGroups.Name = "lstGroups";
            lstGroups.Size = new Size(278, 353);
            lstGroups.TabIndex = 1;
            // 
            // pnlGroupActions
            // 
            pnlGroupActions.BackColor = Color.WhiteSmoke;
            pnlGroupActions.BorderStyle = BorderStyle.FixedSingle;
            pnlGroupActions.Controls.Add(lblGroupActionsTitle);
            pnlGroupActions.Controls.Add(btnGroupRestoreAll);
            pnlGroupActions.Controls.Add(btnGroupMinimizeAll);
            pnlGroupActions.Controls.Add(btnGroupTile);
            pnlGroupActions.Controls.Add(btnGroupRestoreBounds);
            pnlGroupActions.Controls.Add(btnGroupTerminateAll);
            pnlGroupActions.Controls.Add(btnRenameGroup);
            pnlGroupActions.Controls.Add(btnDeleteGroup);
            pnlGroupActions.Dock = DockStyle.Bottom;
            pnlGroupActions.Location = new Point(0, 395);
            pnlGroupActions.Name = "pnlGroupActions";
            pnlGroupActions.Size = new Size(278, 224);
            pnlGroupActions.TabIndex = 2;
            // 
            // lblGroupActionsTitle
            // 
            lblGroupActionsTitle.AutoSize = true;
            lblGroupActionsTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblGroupActionsTitle.Location = new Point(8, 6);
            lblGroupActionsTitle.Name = "lblGroupActionsTitle";
            lblGroupActionsTitle.Size = new Size(86, 15);
            lblGroupActionsTitle.TabIndex = 0;
            lblGroupActionsTitle.Text = "Group Actions";
            // 
            // btnGroupRestoreAll
            // 
            btnGroupRestoreAll.BackColor = Color.Black;
            btnGroupRestoreAll.Cursor = Cursors.Hand;
            btnGroupRestoreAll.FlatStyle = FlatStyle.Flat;
            btnGroupRestoreAll.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnGroupRestoreAll.ForeColor = Color.White;
            btnGroupRestoreAll.Location = new Point(8, 26);
            btnGroupRestoreAll.Name = "btnGroupRestoreAll";
            btnGroupRestoreAll.Size = new Size(125, 28);
            btnGroupRestoreAll.TabIndex = 1;
            btnGroupRestoreAll.Text = "▲ Restore All";
            btnGroupRestoreAll.UseVisualStyleBackColor = false;
            // 
            // btnGroupMinimizeAll
            // 
            btnGroupMinimizeAll.BackColor = Color.White;
            btnGroupMinimizeAll.Cursor = Cursors.Hand;
            btnGroupMinimizeAll.FlatStyle = FlatStyle.Flat;
            btnGroupMinimizeAll.Font = new Font("Segoe UI", 8.5F);
            btnGroupMinimizeAll.ForeColor = Color.Black;
            btnGroupMinimizeAll.Location = new Point(140, 26);
            btnGroupMinimizeAll.Name = "btnGroupMinimizeAll";
            btnGroupMinimizeAll.Size = new Size(128, 28);
            btnGroupMinimizeAll.TabIndex = 2;
            btnGroupMinimizeAll.Text = "▼ Minimize All";
            btnGroupMinimizeAll.UseVisualStyleBackColor = false;
            // 
            // btnGroupTile
            // 
            btnGroupTile.BackColor = Color.FromArgb(30, 70, 140);
            btnGroupTile.Cursor = Cursors.Hand;
            btnGroupTile.FlatStyle = FlatStyle.Flat;
            btnGroupTile.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnGroupTile.ForeColor = Color.White;
            btnGroupTile.Location = new Point(8, 60);
            btnGroupTile.Name = "btnGroupTile";
            btnGroupTile.Size = new Size(260, 28);
            btnGroupTile.TabIndex = 3;
            btnGroupTile.Text = "⊞ Tile Windows On Screen";
            btnGroupTile.UseVisualStyleBackColor = false;
            // 
            // btnGroupRestoreBounds
            // 
            btnGroupRestoreBounds.BackColor = Color.White;
            btnGroupRestoreBounds.Cursor = Cursors.Hand;
            btnGroupRestoreBounds.FlatStyle = FlatStyle.Flat;
            btnGroupRestoreBounds.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnGroupRestoreBounds.ForeColor = Color.FromArgb(30, 70, 140);
            btnGroupRestoreBounds.Location = new Point(8, 94);
            btnGroupRestoreBounds.Name = "btnGroupRestoreBounds";
            btnGroupRestoreBounds.Size = new Size(260, 28);
            btnGroupRestoreBounds.TabIndex = 4;
            btnGroupRestoreBounds.Text = "⟲ Restore Window Sizes";
            btnGroupRestoreBounds.UseVisualStyleBackColor = false;
            // 
            // btnGroupTerminateAll
            // 
            btnGroupTerminateAll.BackColor = Color.FromArgb(170, 30, 30);
            btnGroupTerminateAll.Cursor = Cursors.Hand;
            btnGroupTerminateAll.FlatStyle = FlatStyle.Flat;
            btnGroupTerminateAll.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnGroupTerminateAll.ForeColor = Color.White;
            btnGroupTerminateAll.Location = new Point(8, 128);
            btnGroupTerminateAll.Name = "btnGroupTerminateAll";
            btnGroupTerminateAll.Size = new Size(260, 28);
            btnGroupTerminateAll.TabIndex = 5;
            btnGroupTerminateAll.Text = "✕ Terminate Group";
            btnGroupTerminateAll.UseVisualStyleBackColor = false;
            // 
            // btnRenameGroup
            // 
            btnRenameGroup.BackColor = Color.White;
            btnRenameGroup.Cursor = Cursors.Hand;
            btnRenameGroup.FlatStyle = FlatStyle.Flat;
            btnRenameGroup.Font = new Font("Segoe UI", 8F);
            btnRenameGroup.ForeColor = Color.Black;
            btnRenameGroup.Location = new Point(8, 162);
            btnRenameGroup.Name = "btnRenameGroup";
            btnRenameGroup.Size = new Size(125, 26);
            btnRenameGroup.TabIndex = 6;
            btnRenameGroup.Text = "Rename";
            btnRenameGroup.UseVisualStyleBackColor = false;
            // 
            // btnDeleteGroup
            // 
            btnDeleteGroup.BackColor = Color.White;
            btnDeleteGroup.Cursor = Cursors.Hand;
            btnDeleteGroup.FlatStyle = FlatStyle.Flat;
            btnDeleteGroup.Font = new Font("Segoe UI", 8F);
            btnDeleteGroup.ForeColor = Color.FromArgb(170, 30, 30);
            btnDeleteGroup.Location = new Point(140, 162);
            btnDeleteGroup.Name = "btnDeleteGroup";
            btnDeleteGroup.Size = new Size(128, 26);
            btnDeleteGroup.TabIndex = 7;
            btnDeleteGroup.Text = "Delete Group";
            btnDeleteGroup.UseVisualStyleBackColor = false;
            // 
            // pnlLeftHeader
            // 
            pnlLeftHeader.BackColor = Color.WhiteSmoke;
            pnlLeftHeader.Controls.Add(lblGroupsHeader);
            pnlLeftHeader.Controls.Add(btnAddGroup);
            pnlLeftHeader.Dock = DockStyle.Top;
            pnlLeftHeader.Location = new Point(0, 0);
            pnlLeftHeader.Name = "pnlLeftHeader";
            pnlLeftHeader.Size = new Size(278, 42);
            pnlLeftHeader.TabIndex = 0;
            // 
            // lblGroupsHeader
            // 
            lblGroupsHeader.AutoSize = true;
            lblGroupsHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGroupsHeader.Location = new Point(8, 13);
            lblGroupsHeader.Name = "lblGroupsHeader";
            lblGroupsHeader.Size = new Size(110, 15);
            lblGroupsHeader.TabIndex = 0;
            lblGroupsHeader.Text = "PROCESS GROUPS";
            // 
            // btnAddGroup
            // 
            btnAddGroup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddGroup.BackColor = Color.Black;
            btnAddGroup.Cursor = Cursors.Hand;
            btnAddGroup.FlatStyle = FlatStyle.Flat;
            btnAddGroup.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAddGroup.ForeColor = Color.White;
            btnAddGroup.Location = new Point(175, 8);
            btnAddGroup.Name = "btnAddGroup";
            btnAddGroup.Size = new Size(95, 26);
            btnAddGroup.TabIndex = 1;
            btnAddGroup.Text = "+ Add Group";
            btnAddGroup.UseVisualStyleBackColor = false;
            // 
            // tabLegacy
            // 
            tabLegacy.BackColor = Color.White;
            tabLegacy.Controls.Add(pnlContent);
            tabLegacy.Controls.Add(pnlFooter);
            tabLegacy.Controls.Add(pnlToolbar);
            tabLegacy.Location = new Point(4, 24);
            tabLegacy.Name = "tabLegacy";
            tabLegacy.Padding = new Padding(3);
            tabLegacy.Size = new Size(992, 627);
            tabLegacy.TabIndex = 1;
            tabLegacy.Text = "Linear Process List (Legacy & Import)";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(flowLayoutPanel);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(3, 88);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(12);
            pnlContent.Size = new Size(986, 491);
            pnlContent.TabIndex = 2;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.White;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(12, 12);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(962, 467);
            flowLayoutPanel.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.WhiteSmoke;
            pnlFooter.Controls.Add(LabelPage);
            pnlFooter.Controls.Add(PreviousButton);
            pnlFooter.Controls.Add(NextButton);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(3, 579);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(986, 45);
            pnlFooter.TabIndex = 3;
            // 
            // LabelPage
            // 
            LabelPage.AutoSize = true;
            LabelPage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LabelPage.ForeColor = Color.Black;
            LabelPage.Location = new Point(16, 14);
            LabelPage.Name = "LabelPage";
            LabelPage.Size = new Size(32, 15);
            LabelPage.TabIndex = 0;
            LabelPage.Text = "??/??";
            // 
            // PreviousButton
            // 
            PreviousButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PreviousButton.BackColor = Color.White;
            PreviousButton.Cursor = Cursors.Hand;
            PreviousButton.FlatStyle = FlatStyle.Flat;
            PreviousButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            PreviousButton.ForeColor = Color.Black;
            PreviousButton.Location = new Point(792, 7);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(85, 30);
            PreviousButton.TabIndex = 1;
            PreviousButton.Text = "< PREV";
            PreviousButton.UseVisualStyleBackColor = false;
            PreviousButton.Click += PreviousButton_Click;
            // 
            // NextButton
            // 
            NextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            NextButton.BackColor = Color.Black;
            NextButton.Cursor = Cursors.Hand;
            NextButton.FlatStyle = FlatStyle.Flat;
            NextButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            NextButton.ForeColor = Color.White;
            NextButton.Location = new Point(887, 7);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(85, 30);
            NextButton.TabIndex = 2;
            NextButton.Text = "NEXT >";
            NextButton.UseVisualStyleBackColor = false;
            NextButton.Click += NextButton_Click;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.WhiteSmoke;
            pnlToolbar.Controls.Add(lblSearch);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(btnSearch);
            pnlToolbar.Controls.Add(btnClearSearch);
            pnlToolbar.Controls.Add(RefreshButton);
            pnlToolbar.Controls.Add(label2);
            pnlToolbar.Controls.Add(panel3);
            pnlToolbar.Controls.Add(OnOffImport);
            pnlToolbar.Controls.Add(CheckImport);
            pnlToolbar.Controls.Add(lblFilePath);
            pnlToolbar.Controls.Add(ImportTextbox);
            pnlToolbar.Controls.Add(ImportBrowse);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(3, 3);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(986, 85);
            pnlToolbar.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblSearch.ForeColor = Color.Black;
            lblSearch.Location = new Point(14, 14);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(44, 13);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.Location = new Point(65, 9);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(240, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(312, 8);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(72, 26);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnClearSearch
            // 
            btnClearSearch.BackColor = Color.White;
            btnClearSearch.Cursor = Cursors.Hand;
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Font = new Font("Segoe UI", 8.25F);
            btnClearSearch.ForeColor = Color.Black;
            btnClearSearch.Location = new Point(390, 8);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(62, 26);
            btnClearSearch.TabIndex = 3;
            btnClearSearch.Text = "CLEAR";
            btnClearSearch.UseVisualStyleBackColor = false;
            // 
            // RefreshButton
            // 
            RefreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RefreshButton.BackColor = Color.Black;
            RefreshButton.Cursor = Cursors.Hand;
            RefreshButton.FlatStyle = FlatStyle.Flat;
            RefreshButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            RefreshButton.ForeColor = Color.White;
            RefreshButton.Location = new Point(876, 8);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(96, 26);
            RefreshButton.TabIndex = 4;
            RefreshButton.Text = "REFRESH";
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(14, 49);
            label2.Name = "label2";
            label2.Size = new Size(94, 13);
            label2.TabIndex = 5;
            label2.Text = "Notepad Import:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(112, 50);
            panel3.Name = "panel3";
            panel3.Size = new Size(13, 13);
            panel3.TabIndex = 6;
            // 
            // OnOffImport
            // 
            OnOffImport.BackColor = Color.White;
            OnOffImport.Cursor = Cursors.Hand;
            OnOffImport.FlatStyle = FlatStyle.Flat;
            OnOffImport.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            OnOffImport.ForeColor = Color.Black;
            OnOffImport.Location = new Point(133, 44);
            OnOffImport.Name = "OnOffImport";
            OnOffImport.Size = new Size(58, 26);
            OnOffImport.TabIndex = 7;
            OnOffImport.Text = "On";
            OnOffImport.UseVisualStyleBackColor = false;
            OnOffImport.Click += OnOffImport_Click;
            // 
            // CheckImport
            // 
            CheckImport.BackColor = Color.White;
            CheckImport.Cursor = Cursors.Hand;
            CheckImport.FlatStyle = FlatStyle.Flat;
            CheckImport.Font = new Font("Segoe UI", 8.25F);
            CheckImport.ForeColor = Color.Black;
            CheckImport.Location = new Point(197, 44);
            CheckImport.Name = "CheckImport";
            CheckImport.Size = new Size(76, 26);
            CheckImport.TabIndex = 8;
            CheckImport.Text = "Check File";
            CheckImport.UseVisualStyleBackColor = false;
            CheckImport.Click += CheckImport_Click;
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Font = new Font("Segoe UI", 8.25F);
            lblFilePath.ForeColor = Color.DimGray;
            lblFilePath.Location = new Point(285, 50);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(33, 13);
            lblFilePath.TabIndex = 9;
            lblFilePath.Text = "Path:";
            // 
            // ImportTextbox
            // 
            ImportTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ImportTextbox.BorderStyle = BorderStyle.FixedSingle;
            ImportTextbox.Font = new Font("Segoe UI", 8.25F);
            ImportTextbox.Location = new Point(322, 46);
            ImportTextbox.Name = "ImportTextbox";
            ImportTextbox.Size = new Size(544, 22);
            ImportTextbox.TabIndex = 10;
            // 
            // ImportBrowse
            // 
            ImportBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ImportBrowse.BackColor = Color.White;
            ImportBrowse.Cursor = Cursors.Hand;
            ImportBrowse.FlatStyle = FlatStyle.Flat;
            ImportBrowse.Font = new Font("Segoe UI", 8.25F);
            ImportBrowse.ForeColor = Color.Black;
            ImportBrowse.Location = new Point(876, 44);
            ImportBrowse.Name = "ImportBrowse";
            ImportBrowse.Size = new Size(96, 26);
            ImportBrowse.TabIndex = 11;
            ImportBrowse.Text = "Browse...";
            ImportBrowse.UseVisualStyleBackColor = false;
            ImportBrowse.Click += ImportBrowse_Click;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 0);
            label1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 0);
            panel2.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(0, 0);
            panel4.TabIndex = 0;
            // 
            // BulkWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 720);
            Controls.Add(tabControlMain);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(880, 550);
            Name = "BulkWindowForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProcessForge — Bulk Process Manager";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tabControlMain.ResumeLayout(false);
            tabGroupManager.ResumeLayout(false);
            pnlGroupRight.ResumeLayout(false);
            pnlRightToolbar.ResumeLayout(false);
            pnlRightToolbar.PerformLayout();
            pnlGroupLeft.ResumeLayout(false);
            pnlGroupActions.ResumeLayout(false);
            pnlGroupActions.PerformLayout();
            pnlLeftHeader.ResumeLayout(false);
            pnlLeftHeader.PerformLayout();
            tabLegacy.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeaderSubtitle;
        private Label ProcessListLabel;
        private Button btnHeaderAutoSplit;
        private Button btnHeaderRefresh;
        private Button btnHeaderSave;
        private TabControl tabControlMain;
        private TabPage tabGroupManager;
        private Panel pnlGroupRight;
        private FlowLayoutPanel flowGroupProcesses;
        private Panel pnlRightToolbar;
        private Label lblSelectedGroupTitle;
        private TextBox txtGroupSearch;
        private Button btnGroupClearSearch;
        private Button btnAddByName;
        private Button btnAddProcessToGroup;
        private Panel pnlGroupLeft;
        private ListBox lstGroups;
        private Panel pnlGroupActions;
        private Label lblGroupActionsTitle;
        private Button btnGroupRestoreAll;
        private Button btnGroupMinimizeAll;
        private Button btnGroupTile;
        private Button btnGroupRestoreBounds;
        private Button btnGroupTerminateAll;
        private Button btnRenameGroup;
        private Button btnDeleteGroup;
        private Panel pnlLeftHeader;
        private Label lblGroupsHeader;
        private Button btnAddGroup;
        private TabPage tabLegacy;
        private Panel pnlToolbar;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClearSearch;
        private Button RefreshButton;
        private Label label2;
        private Panel panel3;
        private Button OnOffImport;
        private Button CheckImport;
        private Label lblFilePath;
        private TextBox ImportTextbox;
        private Button ImportBrowse;
        private Panel pnlContent;
        private FlowLayoutPanel flowLayoutPanel;
        private Panel pnlFooter;
        private Label LabelPage;
        private Button PreviousButton;
        private Button NextButton;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
    }
}