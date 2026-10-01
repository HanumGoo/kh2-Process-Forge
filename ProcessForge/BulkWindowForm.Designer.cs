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
            pnlHeader.Size = new Size(820, 65);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeaderSubtitle.ForeColor = Color.LightGray;
            lblHeaderSubtitle.Location = new Point(17, 34);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(390, 13);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Bulk Process Manager — Monitor, restore, and terminate running processes.";
            // 
            // ProcessListLabel
            // 
            ProcessListLabel.AutoSize = true;
            ProcessListLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ProcessListLabel.ForeColor = Color.White;
            ProcessListLabel.Location = new Point(16, 9);
            ProcessListLabel.Name = "ProcessListLabel";
            ProcessListLabel.Size = new Size(185, 20);
            ProcessListLabel.TabIndex = 0;
            ProcessListLabel.Text = "BULK PROCESS MANAGER";
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
            pnlToolbar.Location = new Point(0, 65);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(820, 85);
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
            txtSearch.Size = new Size(240, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnClearSearch.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            RefreshButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            RefreshButton.ForeColor = Color.White;
            RefreshButton.Location = new Point(710, 8);
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
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(14, 49);
            label2.Name = "label2";
            label2.Size = new Size(93, 13);
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
            OnOffImport.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
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
            CheckImport.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            lblFilePath.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            ImportTextbox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            ImportTextbox.Location = new Point(322, 46);
            ImportTextbox.Name = "ImportTextbox";
            ImportTextbox.Size = new Size(378, 22);
            ImportTextbox.TabIndex = 10;
            // 
            // ImportBrowse
            // 
            ImportBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ImportBrowse.BackColor = Color.White;
            ImportBrowse.Cursor = Cursors.Hand;
            ImportBrowse.FlatStyle = FlatStyle.Flat;
            ImportBrowse.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            ImportBrowse.ForeColor = Color.Black;
            ImportBrowse.Location = new Point(710, 44);
            ImportBrowse.Name = "ImportBrowse";
            ImportBrowse.Size = new Size(96, 26);
            ImportBrowse.TabIndex = 11;
            ImportBrowse.Text = "Browse...";
            ImportBrowse.UseVisualStyleBackColor = false;
            ImportBrowse.Click += ImportBrowse_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(flowLayoutPanel);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 150);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(12);
            pnlContent.Size = new Size(820, 485);
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
            flowLayoutPanel.Size = new Size(796, 461);
            flowLayoutPanel.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.WhiteSmoke;
            pnlFooter.Controls.Add(LabelPage);
            pnlFooter.Controls.Add(PreviousButton);
            pnlFooter.Controls.Add(NextButton);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 635);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(820, 45);
            pnlFooter.TabIndex = 3;
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
            PreviousButton.Location = new Point(626, 7);
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
            NextButton.Location = new Point(721, 7);
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
            // BulkWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(820, 680);
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(820, 500);
            Name = "BulkWindowForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProcessForge — Bulk Process Manager";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
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