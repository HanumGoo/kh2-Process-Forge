namespace ProcessForge
{
    partial class AutoLoginWindowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportWindowForm));
            CheckImport = new Button();
            panel4 = new Panel();
            OnOffImport = new Button();
            panel3 = new Panel();
            ImportBrowse = new Button();
            ImportTextbox = new TextBox();
            LabelPage = new Label();
            PreviousButton = new Button();
            NextButton = new Button();
            AddDatabutton = new Button();
            txtSearch = new TextBox();
            panel2 = new Panel();
            panel1 = new Panel();
            flowLayoutPanel = new FlowLayoutPanel();
            RefreshButton = new Button();
            label2 = new Label();
            ProcessListLabel = new Label();
            label1 = new Label();
            NewImportFile = new Button();
            SuspendLayout();
            // 
            // CheckImport
            // 
            CheckImport.Anchor = AnchorStyles.Top;
            CheckImport.BackColor = SystemColors.Desktop;
            CheckImport.Font = new Font("Segoe UI Symbol", 12F);
            CheckImport.ForeColor = Color.White;
            CheckImport.Location = new Point(407, 98);
            CheckImport.Name = "CheckImport";
            CheckImport.Size = new Size(160, 50);
            CheckImport.TabIndex = 80;
            CheckImport.Text = "Check";
            CheckImport.UseVisualStyleBackColor = false;
            CheckImport.Click += CheckImport_Click;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.Transparent;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.ForeColor = SystemColors.ActiveCaptionText;
            panel4.Location = new Point(9, 78);
            panel4.Name = "panel4";
            panel4.Size = new Size(1090, 14);
            panel4.TabIndex = 70;
            // 
            // OnOffImport
            // 
            OnOffImport.Anchor = AnchorStyles.Top;
            OnOffImport.BackColor = SystemColors.Desktop;
            OnOffImport.Font = new Font("Segoe UI Symbol", 12F);
            OnOffImport.ForeColor = Color.White;
            OnOffImport.Location = new Point(254, 98);
            OnOffImport.Name = "OnOffImport";
            OnOffImport.Size = new Size(147, 50);
            OnOffImport.TabIndex = 79;
            OnOffImport.Text = "Reset";
            OnOffImport.UseVisualStyleBackColor = false;
            OnOffImport.Click += OnOffImport_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.BackColor = Color.Green;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Font = new Font("Segoe UI Symbol", 12F);
            panel3.Location = new Point(193, 107);
            panel3.Name = "panel3";
            panel3.Size = new Size(30, 26);
            panel3.TabIndex = 66;
            // 
            // ImportBrowse
            // 
            ImportBrowse.Anchor = AnchorStyles.Top;
            ImportBrowse.BackColor = SystemColors.Desktop;
            ImportBrowse.Font = new Font("Segoe UI Symbol", 12F);
            ImportBrowse.ForeColor = Color.White;
            ImportBrowse.Location = new Point(911, 98);
            ImportBrowse.Name = "ImportBrowse";
            ImportBrowse.Size = new Size(189, 50);
            ImportBrowse.TabIndex = 78;
            ImportBrowse.Text = "Browse";
            ImportBrowse.UseVisualStyleBackColor = false;
            ImportBrowse.Click += ImportBrowse_Click;
            // 
            // ImportTextbox
            // 
            ImportTextbox.Anchor = AnchorStyles.Top;
            ImportTextbox.BackColor = SystemColors.Desktop;
            ImportTextbox.Font = new Font("Segoe UI Symbol", 12F);
            ImportTextbox.ForeColor = Color.White;
            ImportTextbox.Location = new Point(573, 100);
            ImportTextbox.Name = "ImportTextbox";
            ImportTextbox.Size = new Size(331, 39);
            ImportTextbox.TabIndex = 77;
            // 
            // LabelPage
            // 
            LabelPage.Anchor = AnchorStyles.Bottom;
            LabelPage.AutoSize = true;
            LabelPage.Font = new Font("Segoe UI", 12F);
            LabelPage.ForeColor = Color.White;
            LabelPage.Location = new Point(11, 1080);
            LabelPage.Name = "LabelPage";
            LabelPage.Size = new Size(67, 32);
            LabelPage.TabIndex = 76;
            LabelPage.Text = "??/??";
            LabelPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PreviousButton
            // 
            PreviousButton.Anchor = AnchorStyles.Bottom;
            PreviousButton.BackColor = SystemColors.Desktop;
            PreviousButton.Font = new Font("Segoe UI Symbol", 12F);
            PreviousButton.ForeColor = Color.White;
            PreviousButton.Location = new Point(214, 1080);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(187, 60);
            PreviousButton.TabIndex = 74;
            PreviousButton.Text = "Previous";
            PreviousButton.UseVisualStyleBackColor = false;
            PreviousButton.Click += PreviousButton_Click;
            // 
            // NextButton
            // 
            NextButton.Anchor = AnchorStyles.Bottom;
            NextButton.BackColor = SystemColors.Desktop;
            NextButton.Font = new Font("Segoe UI Symbol", 12F);
            NextButton.ForeColor = Color.White;
            NextButton.Location = new Point(407, 1080);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(183, 60);
            NextButton.TabIndex = 75;
            NextButton.Text = "Next";
            NextButton.UseVisualStyleBackColor = false;
            NextButton.Click += NextButton_Click;
            // 
            // AddDatabutton
            // 
            AddDatabutton.Anchor = AnchorStyles.Top;
            AddDatabutton.BackColor = SystemColors.Desktop;
            AddDatabutton.Font = new Font("Segoe UI Symbol", 12F);
            AddDatabutton.ForeColor = Color.White;
            AddDatabutton.Location = new Point(780, 12);
            AddDatabutton.Name = "AddDatabutton";
            AddDatabutton.Size = new Size(143, 57);
            AddDatabutton.TabIndex = 73;
            AddDatabutton.Text = "Add Data";
            AddDatabutton.UseVisualStyleBackColor = false;
            AddDatabutton.Click += AddDatabutton_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top;
            txtSearch.BackColor = SystemColors.Desktop;
            txtSearch.Font = new Font("Segoe UI Symbol", 12F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(463, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(310, 39);
            txtSearch.TabIndex = 72;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.ForeColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(11, 1060);
            panel2.Name = "panel2";
            panel2.Size = new Size(1087, 11);
            panel2.TabIndex = 71;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(11, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(1087, 11);
            panel1.TabIndex = 69;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(11, 175);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(1087, 878);
            flowLayoutPanel.TabIndex = 68;
            // 
            // RefreshButton
            // 
            RefreshButton.Anchor = AnchorStyles.Top;
            RefreshButton.BackColor = SystemColors.Desktop;
            RefreshButton.Font = new Font("Segoe UI Symbol", 12F);
            RefreshButton.ForeColor = Color.White;
            RefreshButton.Location = new Point(929, 12);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(171, 57);
            RefreshButton.TabIndex = 67;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(9, 100);
            label2.Name = "label2";
            label2.Size = new Size(191, 32);
            label2.TabIndex = 65;
            label2.Text = "Using .txt Import";
            // 
            // ProcessListLabel
            // 
            ProcessListLabel.Anchor = AnchorStyles.Top;
            ProcessListLabel.AutoSize = true;
            ProcessListLabel.Font = new Font("Segoe UI Symbol", 16F);
            ProcessListLabel.ForeColor = Color.White;
            ProcessListLabel.Location = new Point(9, 12);
            ProcessListLabel.Name = "ProcessListLabel";
            ProcessListLabel.Size = new Size(174, 45);
            ProcessListLabel.TabIndex = 64;
            ProcessListLabel.Text = "Import List";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(359, 18);
            label1.Name = "label1";
            label1.Size = new Size(104, 32);
            label1.TabIndex = 81;
            label1.Text = "Search : ";
            // 
            // NewImportFile
            // 
            NewImportFile.Anchor = AnchorStyles.Bottom;
            NewImportFile.BackColor = SystemColors.Desktop;
            NewImportFile.Font = new Font("Segoe UI Symbol", 12F);
            NewImportFile.ForeColor = Color.White;
            NewImportFile.Location = new Point(649, 1080);
            NewImportFile.Name = "NewImportFile";
            NewImportFile.Size = new Size(451, 60);
            NewImportFile.TabIndex = 82;
            NewImportFile.Text = "Create new import file";
            NewImportFile.UseVisualStyleBackColor = false;
            NewImportFile.Click += NewImportFile_Click;
            // 
            // ImportWindowForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1111, 1158);
            Controls.Add(NewImportFile);
            Controls.Add(label1);
            Controls.Add(CheckImport);
            Controls.Add(panel4);
            Controls.Add(OnOffImport);
            Controls.Add(panel3);
            Controls.Add(ImportBrowse);
            Controls.Add(ImportTextbox);
            Controls.Add(LabelPage);
            Controls.Add(PreviousButton);
            Controls.Add(NextButton);
            Controls.Add(AddDatabutton);
            Controls.Add(txtSearch);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel);
            Controls.Add(RefreshButton);
            Controls.Add(label2);
            Controls.Add(ProcessListLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ImportWindowForm";
            Text = "Import Handler";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CheckImport;
        private Panel panel4;
        private Button OnOffImport;
        private Panel panel3;
        private Button ImportBrowse;
        private TextBox ImportTextbox;
        private Label LabelPage;
        private Button PreviousButton;
        private Button NextButton;
        private Button AddDatabutton;
        private TextBox txtSearch;
        private Panel panel2;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel;
        private Button RefreshButton;
        private Label label2;
        private Label ProcessListLabel;
        private Label label1;
        private Button NewImportFile;
    }
}