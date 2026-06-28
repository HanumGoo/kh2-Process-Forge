namespace ProcessForge
{
    partial class BulkWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkWindowForm));
            ProcessListLabel = new Label();
            label2 = new Label();
            RefreshButton = new Button();
            flowLayoutPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            txtSearch = new TextBox();
            PreviousButton = new Button();
            NextButton = new Button();
            LabelPage = new Label();
            ImportTextbox = new TextBox();
            ImportBrowse = new Button();
            panel3 = new Panel();
            OnOffImport = new Button();
            panel4 = new Panel();
            CheckImport = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // ProcessListLabel
            // 
            ProcessListLabel.Anchor = AnchorStyles.Top;
            ProcessListLabel.AutoSize = true;
            ProcessListLabel.Font = new Font("Segoe UI Symbol", 16F);
            ProcessListLabel.ForeColor = Color.White;
            ProcessListLabel.Location = new Point(7, 8);
            ProcessListLabel.Margin = new Padding(2, 0, 2, 0);
            ProcessListLabel.Name = "ProcessListLabel";
            ProcessListLabel.Size = new Size(123, 30);
            ProcessListLabel.TabIndex = 1;
            ProcessListLabel.Text = "Process List";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 73);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(165, 21);
            label2.TabIndex = 2;
            label2.Text = "Using Notepad Import";
            // 
            // RefreshButton
            // 
            RefreshButton.Anchor = AnchorStyles.Top;
            RefreshButton.BackColor = SystemColors.Desktop;
            RefreshButton.Font = new Font("Segoe UI Symbol", 12F);
            RefreshButton.ForeColor = Color.White;
            RefreshButton.Location = new Point(669, 8);
            RefreshButton.Margin = new Padding(2, 2, 2, 2);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(110, 39);
            RefreshButton.TabIndex = 48;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(7, 114);
            flowLayoutPanel.Margin = new Padding(2, 2, 2, 2);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(770, 526);
            flowLayoutPanel.TabIndex = 49;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(7, 102);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(772, 8);
            panel1.TabIndex = 50;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.ForeColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(7, 644);
            panel2.Margin = new Padding(2, 2, 2, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(772, 8);
            panel2.TabIndex = 51;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top;
            txtSearch.BackColor = SystemColors.Desktop;
            txtSearch.Font = new Font("Segoe UI Symbol", 12F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(399, 8);
            txtSearch.Margin = new Padding(2, 2, 2, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(266, 29);
            txtSearch.TabIndex = 52;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // PreviousButton
            // 
            PreviousButton.Anchor = AnchorStyles.Bottom;
            PreviousButton.BackColor = SystemColors.Desktop;
            PreviousButton.Font = new Font("Segoe UI Symbol", 12F);
            PreviousButton.ForeColor = Color.White;
            PreviousButton.Location = new Point(151, 662);
            PreviousButton.Margin = new Padding(2, 2, 2, 2);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(144, 30);
            PreviousButton.TabIndex = 54;
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
            NextButton.Location = new Point(299, 662);
            NextButton.Margin = new Padding(2, 2, 2, 2);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(150, 30);
            NextButton.TabIndex = 55;
            NextButton.Text = "Next";
            NextButton.UseVisualStyleBackColor = false;
            NextButton.Click += NextButton_Click;
            // 
            // LabelPage
            // 
            LabelPage.Anchor = AnchorStyles.Bottom;
            LabelPage.AutoSize = true;
            LabelPage.Font = new Font("Segoe UI Symbol", 12F);
            LabelPage.ForeColor = Color.White;
            LabelPage.Location = new Point(6, 662);
            LabelPage.Margin = new Padding(2, 0, 2, 0);
            LabelPage.Name = "LabelPage";
            LabelPage.Size = new Size(44, 21);
            LabelPage.TabIndex = 56;
            LabelPage.Text = "??/??";
            // 
            // ImportTextbox
            // 
            ImportTextbox.Anchor = AnchorStyles.Top;
            ImportTextbox.BackColor = SystemColors.Desktop;
            ImportTextbox.Font = new Font("Segoe UI Symbol", 12F);
            ImportTextbox.ForeColor = Color.White;
            ImportTextbox.Location = new Point(398, 65);
            ImportTextbox.Margin = new Padding(2, 2, 2, 2);
            ImportTextbox.Name = "ImportTextbox";
            ImportTextbox.Size = new Size(266, 29);
            ImportTextbox.TabIndex = 57;
            // 
            // ImportBrowse
            // 
            ImportBrowse.Anchor = AnchorStyles.Top;
            ImportBrowse.BackColor = SystemColors.Desktop;
            ImportBrowse.Font = new Font("Segoe UI Symbol", 12F);
            ImportBrowse.ForeColor = Color.White;
            ImportBrowse.Location = new Point(668, 63);
            ImportBrowse.Margin = new Padding(2, 2, 2, 2);
            ImportBrowse.Name = "ImportBrowse";
            ImportBrowse.Size = new Size(111, 35);
            ImportBrowse.TabIndex = 58;
            ImportBrowse.Text = "Browse";
            ImportBrowse.UseVisualStyleBackColor = false;
            ImportBrowse.Click += ImportBrowse_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.BackColor = Color.Red;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Font = new Font("Segoe UI Symbol", 12F);
            panel3.Location = new Point(175, 77);
            panel3.Margin = new Padding(2, 2, 2, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(22, 17);
            panel3.TabIndex = 42;
            // 
            // OnOffImport
            // 
            OnOffImport.Anchor = AnchorStyles.Top;
            OnOffImport.BackColor = SystemColors.Desktop;
            OnOffImport.Font = new Font("Segoe UI Symbol", 12F);
            OnOffImport.ForeColor = Color.White;
            OnOffImport.Location = new Point(201, 63);
            OnOffImport.Margin = new Padding(2, 2, 2, 2);
            OnOffImport.Name = "OnOffImport";
            OnOffImport.Size = new Size(94, 35);
            OnOffImport.TabIndex = 62;
            OnOffImport.Text = "On";
            OnOffImport.UseVisualStyleBackColor = false;
            OnOffImport.Click += OnOffImport_Click;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.Transparent;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.ForeColor = SystemColors.ActiveCaptionText;
            panel4.Location = new Point(7, 51);
            panel4.Margin = new Padding(2, 2, 2, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(771, 10);
            panel4.TabIndex = 51;
            // 
            // CheckImport
            // 
            CheckImport.Anchor = AnchorStyles.Top;
            CheckImport.BackColor = SystemColors.Desktop;
            CheckImport.Font = new Font("Segoe UI Symbol", 12F);
            CheckImport.ForeColor = Color.White;
            CheckImport.Location = new Point(299, 63);
            CheckImport.Margin = new Padding(2, 2, 2, 2);
            CheckImport.Name = "CheckImport";
            CheckImport.Size = new Size(95, 35);
            CheckImport.TabIndex = 63;
            CheckImport.Text = "Check";
            CheckImport.UseVisualStyleBackColor = false;
            CheckImport.Click += CheckImport_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(327, 11);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 64;
            label1.Text = "Search : ";
            // 
            // BulkWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(788, 703);
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
            Controls.Add(txtSearch);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel);
            Controls.Add(RefreshButton);
            Controls.Add(label2);
            Controls.Add(ProcessListLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "BulkWindowForm";
            Text = "App Handler";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProcessListLabel;
        private Label label2;
        private Button RefreshButton;
        private FlowLayoutPanel flowLayoutPanel;
        private Panel panel1;
        private Panel panel2;
        private TextBox txtSearch;
        private Button PreviousButton;
        private Button NextButton;
        private Label LabelPage;
        private TextBox ImportTextbox;
        private Button ImportBrowse;
        private Panel panel3;
        private Button OnOffImport;
        private Panel panel4;
        private Button CheckImport;
        private Label label1;
    }
}