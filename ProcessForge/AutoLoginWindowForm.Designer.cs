namespace ProcessForge
{
    partial class AutoLoginWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoLoginWindowForm));
            pnlHeader = new Panel();
            lblHeaderSubtitle = new Label();
            ProcessListLabel = new Label();
            pnlToolbar = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClearSearch = new Button();
            AddDatabutton = new Button();
            NewImportFile = new Button();
            RefreshButton = new Button();
            label2 = new Label();
            panel3 = new Panel();
            OnOffImport = new Button();
            CheckImport = new Button();
            lblFilePath = new Label();
            ImportTextbox = new TextBox();
            ImportBrowse = new Button();
            pnlColumnHeaders = new Panel();
            lblColNickname = new Label();
            lblColUsername = new Label();
            lblColPassword = new Label();
            lblColSecPass = new Label();
            lblColStatus = new Label();
            lblColAction = new Label();
            pnlContent = new Panel();
            flowLayoutPanel = new FlowLayoutPanel();
            pnlFooter = new Panel();
            LabelPage = new Label();
            lblFooterTip = new Label();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlColumnHeaders.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Black;
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(ProcessListLabel);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(920, 65);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeaderSubtitle.ForeColor = Color.LightGray;
            lblHeaderSubtitle.Location = new Point(17, 34);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(465, 13);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Manage account credentials, passwords, and login statuses for automated process login.";
            // 
            // ProcessListLabel
            // 
            ProcessListLabel.AutoSize = true;
            ProcessListLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ProcessListLabel.ForeColor = Color.White;
            ProcessListLabel.Location = new Point(16, 9);
            ProcessListLabel.Name = "ProcessListLabel";
            ProcessListLabel.Size = new Size(272, 20);
            ProcessListLabel.TabIndex = 0;
            ProcessListLabel.Text = "AUTO LOGIN ACCOUNTS MANAGER";
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.WhiteSmoke;
            pnlToolbar.Controls.Add(lblSearch);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(btnSearch);
            pnlToolbar.Controls.Add(btnClearSearch);
            pnlToolbar.Controls.Add(AddDatabutton);
            pnlToolbar.Controls.Add(NewImportFile);
            pnlToolbar.Controls.Add(RefreshButton);
            pnlToolbar.Controls.Add(label2);
            pnlToolbar.Controls.Add(panel3);
            pnlToolbar.Controls.Add(OnOffImport);
            pnlToolbar.Controls.Add(CheckImport);
            pnlToolbar.Controls.Add(lblFilePath);
            pnlToolbar.Controls.Add(ImportTextbox);
            pnlToolbar.Controls.Add(ImportBrowse);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 65);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(920, 85);
            pnlToolbar.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSearch.ForeColor = Color.Black;
            lblSearch.Location = new Point(14, 14);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 13);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(65, 9);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(220, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(292, 8);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(70, 26);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnClearSearch
            // 
            btnClearSearch.BackColor = Color.White;
            btnClearSearch.Cursor = Cursors.Hand;
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClearSearch.ForeColor = Color.Black;
            btnClearSearch.Location = new Point(366, 8);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(58, 26);
            btnClearSearch.TabIndex = 3;
            btnClearSearch.Text = "CLEAR";
            btnClearSearch.UseVisualStyleBackColor = false;
            // 
            // AddDatabutton
            // 
            AddDatabutton.BackColor = Color.Black;
            AddDatabutton.Cursor = Cursors.Hand;
            AddDatabutton.FlatStyle = FlatStyle.Flat;
            AddDatabutton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            AddDatabutton.ForeColor = Color.White;
            AddDatabutton.Location = new Point(434, 8);
            AddDatabutton.Name = "AddDatabutton";
            AddDatabutton.Size = new Size(100, 26);
            AddDatabutton.TabIndex = 4;
            AddDatabutton.Text = "+ ADD DATA";
            AddDatabutton.UseVisualStyleBackColor = false;
            AddDatabutton.Click += AddDatabutton_Click;
            // 
            // NewImportFile
            // 
            NewImportFile.BackColor = Color.White;
            NewImportFile.Cursor = Cursors.Hand;
            NewImportFile.FlatStyle = FlatStyle.Flat;
            NewImportFile.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            NewImportFile.ForeColor = Color.Black;
            NewImportFile.Location = new Point(538, 8);
            NewImportFile.Name = "NewImportFile";
            NewImportFile.Size = new Size(95, 26);
            NewImportFile.TabIndex = 5;
            NewImportFile.Text = "+ NEW FILE";
            NewImportFile.UseVisualStyleBackColor = false;
            NewImportFile.Click += NewImportFile_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RefreshButton.BackColor = Color.Black;
            RefreshButton.Cursor = Cursors.Hand;
            RefreshButton.FlatStyle = FlatStyle.Flat;
            RefreshButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            RefreshButton.ForeColor = Color.White;
            RefreshButton.Location = new Point(810, 8);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(96, 26);
            RefreshButton.TabIndex = 6;
            RefreshButton.Text = "REFRESH";
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(14, 49);
            label2.Name = "label2";
            label2.Size = new Size(76, 13);
            label2.TabIndex = 7;
            label2.Text = "Account File:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Green;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(95, 50);
            panel3.Name = "panel3";
            panel3.Size = new Size(13, 13);
            panel3.TabIndex = 8;
            // 
            // OnOffImport
            // 
            OnOffImport.BackColor = Color.White;
            OnOffImport.Cursor = Cursors.Hand;
            OnOffImport.FlatStyle = FlatStyle.Flat;
            OnOffImport.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            OnOffImport.ForeColor = Color.Maroon;
            OnOffImport.Location = new Point(116, 44);
            OnOffImport.Name = "OnOffImport";
            OnOffImport.Size = new Size(92, 26);
            OnOffImport.TabIndex = 9;
            OnOffImport.Text = "Reset Status";
            OnOffImport.UseVisualStyleBackColor = false;
            OnOffImport.Click += OnOffImport_Click;
            // 
            // CheckImport
            // 
            CheckImport.BackColor = Color.White;
            CheckImport.Cursor = Cursors.Hand;
            CheckImport.FlatStyle = FlatStyle.Flat;
            CheckImport.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            CheckImport.ForeColor = Color.Black;
            CheckImport.Location = new Point(212, 44);
            CheckImport.Name = "CheckImport";
            CheckImport.Size = new Size(76, 26);
            CheckImport.TabIndex = 10;
            CheckImport.Text = "Check File";
            CheckImport.UseVisualStyleBackColor = false;
            CheckImport.Click += CheckImport_Click;
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilePath.ForeColor = Color.DimGray;
            lblFilePath.Location = new Point(296, 50);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(33, 13);
            lblFilePath.TabIndex = 11;
            lblFilePath.Text = "Path:";
            // 
            // ImportTextbox
            // 
            ImportTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ImportTextbox.BorderStyle = BorderStyle.FixedSingle;
            ImportTextbox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            ImportTextbox.Location = new Point(334, 46);
            ImportTextbox.Name = "ImportTextbox";
            ImportTextbox.Size = new Size(468, 22);
            ImportTextbox.TabIndex = 12;
            // 
            // ImportBrowse
            // 
            ImportBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ImportBrowse.BackColor = Color.White;
            ImportBrowse.Cursor = Cursors.Hand;
            ImportBrowse.FlatStyle = FlatStyle.Flat;
            ImportBrowse.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            ImportBrowse.ForeColor = Color.Black;
            ImportBrowse.Location = new Point(810, 44);
            ImportBrowse.Name = "ImportBrowse";
            ImportBrowse.Size = new Size(96, 26);
            ImportBrowse.TabIndex = 13;
            ImportBrowse.Text = "Browse...";
            ImportBrowse.UseVisualStyleBackColor = false;
            ImportBrowse.Click += ImportBrowse_Click;
            // 
            // pnlColumnHeaders
            // 
            pnlColumnHeaders.BackColor = Color.FromArgb(235, 238, 242);
            pnlColumnHeaders.Controls.Add(lblColNickname);
            pnlColumnHeaders.Controls.Add(lblColUsername);
            pnlColumnHeaders.Controls.Add(lblColPassword);
            pnlColumnHeaders.Controls.Add(lblColSecPass);
            pnlColumnHeaders.Controls.Add(lblColStatus);
            pnlColumnHeaders.Controls.Add(lblColAction);
            pnlColumnHeaders.Dock = DockStyle.Top;
            pnlColumnHeaders.Location = new Point(0, 150);
            pnlColumnHeaders.Name = "pnlColumnHeaders";
            pnlColumnHeaders.Padding = new Padding(12, 0, 12, 0);
            pnlColumnHeaders.Size = new Size(920, 26);
            pnlColumnHeaders.TabIndex = 2;
            // 
            // lblColNickname
            // 
            lblColNickname.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColNickname.ForeColor = Color.FromArgb(60, 60, 60);
            lblColNickname.Location = new Point(14, 5);
            lblColNickname.Name = "lblColNickname";
            lblColNickname.Size = new Size(150, 16);
            lblColNickname.Text = "NICKNAME / TITLE";
            // 
            // lblColUsername
            // 
            lblColUsername.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColUsername.ForeColor = Color.FromArgb(60, 60, 60);
            lblColUsername.Location = new Point(175, 5);
            lblColUsername.Name = "lblColUsername";
            lblColUsername.Size = new Size(150, 16);
            lblColUsername.Text = "USERNAME";
            // 
            // lblColPassword
            // 
            lblColPassword.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColPassword.ForeColor = Color.FromArgb(60, 60, 60);
            lblColPassword.Location = new Point(335, 5);
            lblColPassword.Name = "lblColPassword";
            lblColPassword.Size = new Size(150, 16);
            lblColPassword.Text = "PASSWORD";
            // 
            // lblColSecPass
            // 
            lblColSecPass.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColSecPass.ForeColor = Color.FromArgb(60, 60, 60);
            lblColSecPass.Location = new Point(495, 5);
            lblColSecPass.Name = "lblColSecPass";
            lblColSecPass.Size = new Size(150, 16);
            lblColSecPass.Text = "SECOND PASSWORD";
            // 
            // lblColStatus
            // 
            lblColStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColStatus.ForeColor = Color.FromArgb(60, 60, 60);
            lblColStatus.Location = new Point(655, 5);
            lblColStatus.Name = "lblColStatus";
            lblColStatus.Size = new Size(95, 16);
            lblColStatus.Text = "LOGIN STATUS";
            // 
            // lblColAction
            // 
            lblColAction.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColAction.ForeColor = Color.FromArgb(60, 60, 60);
            lblColAction.Location = new Point(760, 5);
            lblColAction.Name = "lblColAction";
            lblColAction.Size = new Size(90, 16);
            lblColAction.Text = "ACTION";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(flowLayoutPanel);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 176);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(12);
            pnlContent.Size = new Size(920, 464);
            pnlContent.TabIndex = 3;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.White;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(12, 12);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(896, 440);
            flowLayoutPanel.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.WhiteSmoke;
            pnlFooter.Controls.Add(LabelPage);
            pnlFooter.Controls.Add(lblFooterTip);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 640);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(920, 42);
            pnlFooter.TabIndex = 4;
            // 
            // LabelPage
            // 
            LabelPage.AutoSize = true;
            LabelPage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelPage.ForeColor = Color.Black;
            LabelPage.Location = new Point(16, 13);
            LabelPage.Name = "LabelPage";
            LabelPage.Size = new Size(39, 15);
            LabelPage.TabIndex = 0;
            LabelPage.Text = "??/??";
            // 
            // lblFooterTip
            // 
            lblFooterTip.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFooterTip.AutoSize = true;
            lblFooterTip.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFooterTip.ForeColor = Color.DimGray;
            lblFooterTip.Location = new Point(480, 14);
            lblFooterTip.Name = "lblFooterTip";
            lblFooterTip.Size = new Size(424, 13);
            lblFooterTip.TabIndex = 1;
            lblFooterTip.Text = "ℹ️ Click any text field to edit it directly. Click Login status to toggle state.";
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
            // AutoLoginWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(920, 682);
            Controls.Add(pnlContent);
            Controls.Add(pnlColumnHeaders);
            Controls.Add(pnlFooter);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(880, 500);
            Name = "AutoLoginWindowForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProcessForge — Auto Login Accounts Manager";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlColumnHeaders.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeaderSubtitle;
        private Label ProcessListLabel;
        private Panel pnlToolbar;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClearSearch;
        private Button AddDatabutton;
        private Button NewImportFile;
        private Button RefreshButton;
        private Label label2;
        private Panel panel3;
        private Button OnOffImport;
        private Button CheckImport;
        private Label lblFilePath;
        private TextBox ImportTextbox;
        private Button ImportBrowse;
        private Panel pnlColumnHeaders;
        private Label lblColNickname;
        private Label lblColUsername;
        private Label lblColPassword;
        private Label lblColSecPass;
        private Label lblColStatus;
        private Label lblColAction;
        private Panel pnlContent;
        private FlowLayoutPanel flowLayoutPanel;
        private Panel pnlFooter;
        private Label LabelPage;
        private Label lblFooterTip;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
    }
}