namespace ProcessForge
{
    partial class ImportWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportWindowForm));
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
            lblColTitle = new Label();
            lblColStatus = new Label();
            lblColAction = new Label();
            pnlContent = new Panel();
            flowLayoutPanel = new FlowLayoutPanel();
            pnlFooter = new Panel();
            LabelPage = new Label();
            PreviousButton = new Button();
            NextButton = new Button();
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
            pnlHeader.Size = new Size(880, 65);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeaderSubtitle.ForeColor = Color.LightGray;
            lblHeaderSubtitle.Location = new Point(17, 34);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(445, 13);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Monitor process execution, inspect window states, and manage import target titles.";
            // 
            // ProcessListLabel
            // 
            ProcessListLabel.AutoSize = true;
            ProcessListLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ProcessListLabel.ForeColor = Color.White;
            ProcessListLabel.Location = new Point(16, 9);
            ProcessListLabel.Name = "ProcessListLabel";
            ProcessListLabel.Size = new Size(198, 20);
            ProcessListLabel.TabIndex = 0;
            ProcessListLabel.Text = "IMPORT TITLES MANAGER";
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
            pnlToolbar.Size = new Size(880, 85);
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
            RefreshButton.Location = new Point(770, 8);
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
            label2.Size = new Size(68, 13);
            label2.TabIndex = 7;
            label2.Text = "Import File:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Green;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(88, 50);
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
            OnOffImport.Location = new Point(108, 44);
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
            CheckImport.Location = new Point(204, 44);
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
            lblFilePath.Location = new Point(288, 50);
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
            ImportTextbox.Location = new Point(325, 46);
            ImportTextbox.Name = "ImportTextbox";
            ImportTextbox.Size = new Size(438, 22);
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
            ImportBrowse.Location = new Point(770, 44);
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
            pnlColumnHeaders.Controls.Add(lblColTitle);
            pnlColumnHeaders.Controls.Add(lblColStatus);
            pnlColumnHeaders.Controls.Add(lblColAction);
            pnlColumnHeaders.Dock = DockStyle.Top;
            pnlColumnHeaders.Location = new Point(0, 150);
            pnlColumnHeaders.Name = "pnlColumnHeaders";
            pnlColumnHeaders.Padding = new Padding(12, 0, 12, 0);
            pnlColumnHeaders.Size = new Size(880, 26);
            pnlColumnHeaders.TabIndex = 2;
            // 
            // lblColTitle
            // 
            lblColTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColTitle.ForeColor = Color.FromArgb(60, 60, 60);
            lblColTitle.Location = new Point(14, 5);
            lblColTitle.Name = "lblColTitle";
            lblColTitle.Size = new Size(380, 16);
            lblColTitle.Text = "WINDOW / PROCESS TITLE (CLICK TO EDIT)";
            // 
            // lblColStatus
            // 
            lblColStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColStatus.ForeColor = Color.FromArgb(60, 60, 60);
            lblColStatus.Location = new Point(445, 5);
            lblColStatus.Name = "lblColStatus";
            lblColStatus.Size = new Size(160, 16);
            lblColStatus.Text = "STATUS (EXIST / NOTEXIST)";
            // 
            // lblColAction
            // 
            lblColAction.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColAction.ForeColor = Color.FromArgb(60, 60, 60);
            lblColAction.Location = new Point(625, 5);
            lblColAction.Name = "lblColAction";
            lblColAction.Size = new Size(120, 16);
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
            pnlContent.Size = new Size(880, 464);
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
            flowLayoutPanel.Size = new Size(856, 440);
            flowLayoutPanel.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.WhiteSmoke;
            pnlFooter.Controls.Add(LabelPage);
            pnlFooter.Controls.Add(PreviousButton);
            pnlFooter.Controls.Add(NextButton);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 640);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(880, 45);
            pnlFooter.TabIndex = 4;
            // 
            // LabelPage
            // 
            LabelPage.AutoSize = true;
            LabelPage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LabelPage.ForeColor = Color.Black;
            LabelPage.Location = new Point(16, 14);
            LabelPage.Name = "LabelPage";
            LabelPage.Size = new Size(39, 15);
            LabelPage.TabIndex = 0;
            LabelPage.Text = "??/??";
            // 
            // PreviousButton
            // 
            PreviousButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PreviousButton.BackColor = Color.White;
            PreviousButton.Cursor = Cursors.Hand;
            PreviousButton.FlatStyle = FlatStyle.Flat;
            PreviousButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            PreviousButton.ForeColor = Color.Black;
            PreviousButton.Location = new Point(686, 7);
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
            NextButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            NextButton.ForeColor = Color.White;
            NextButton.Location = new Point(781, 7);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(85, 30);
            NextButton.TabIndex = 2;
            NextButton.Text = "NEXT >";
            NextButton.UseVisualStyleBackColor = false;
            NextButton.Click += NextButton_Click;
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
            // ImportWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(880, 685);
            Controls.Add(pnlContent);
            Controls.Add(pnlColumnHeaders);
            Controls.Add(pnlFooter);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(840, 500);
            Name = "ImportWindowForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProcessForge — Import Titles Manager";
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
        private Label lblColTitle;
        private Label lblColStatus;
        private Label lblColAction;
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