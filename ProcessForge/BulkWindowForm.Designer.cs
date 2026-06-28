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
            button1 = new Button();
            PreviousButton = new Button();
            NextButton = new Button();
            LabelPage = new Label();
            ImportTextbox = new TextBox();
            ImportBrowse = new Button();
            panel3 = new Panel();
            OnOffImport = new Button();
            panel4 = new Panel();
            CheckImport = new Button();
            SuspendLayout();
            // 
            // ProcessListLabel
            // 
            ProcessListLabel.Anchor = AnchorStyles.Top;
            ProcessListLabel.AutoSize = true;
            ProcessListLabel.Font = new Font("Segoe UI Symbol", 12F);
            ProcessListLabel.ForeColor = Color.White;
            ProcessListLabel.Location = new Point(12, 9);
            ProcessListLabel.Name = "ProcessListLabel";
            ProcessListLabel.Size = new Size(135, 32);
            ProcessListLabel.TabIndex = 1;
            ProcessListLabel.Text = "Process List";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 10F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(11, 68);
            label2.Name = "label2";
            label2.Size = new Size(210, 28);
            label2.TabIndex = 2;
            label2.Text = "Using Notepad Import";
            // 
            // RefreshButton
            // 
            RefreshButton.Anchor = AnchorStyles.Top;
            RefreshButton.BackColor = SystemColors.Desktop;
            RefreshButton.Font = new Font("Segoe UI Symbol", 9F);
            RefreshButton.ForeColor = Color.White;
            RefreshButton.Location = new Point(682, 11);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(105, 32);
            RefreshButton.TabIndex = 48;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(11, 118);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(776, 507);
            flowLayoutPanel.TabIndex = 49;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(11, 105);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 10);
            panel1.TabIndex = 50;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.ForeColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(11, 631);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 10);
            panel2.TabIndex = 51;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top;
            txtSearch.BackColor = SystemColors.Desktop;
            txtSearch.Font = new Font("Segoe UI Symbol", 9F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(443, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(233, 31);
            txtSearch.TabIndex = 52;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = SystemColors.Desktop;
            button1.Font = new Font("Segoe UI Symbol", 9F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(351, 11);
            button1.Name = "button1";
            button1.Size = new Size(86, 32);
            button1.TabIndex = 53;
            button1.Text = "Find";
            button1.UseVisualStyleBackColor = false;
            // 
            // PreviousButton
            // 
            PreviousButton.Anchor = AnchorStyles.Bottom;
            PreviousButton.BackColor = SystemColors.Desktop;
            PreviousButton.Font = new Font("Segoe UI Symbol", 9F);
            PreviousButton.ForeColor = Color.White;
            PreviousButton.Location = new Point(198, 650);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(103, 32);
            PreviousButton.TabIndex = 54;
            PreviousButton.Text = "Previous";
            PreviousButton.UseVisualStyleBackColor = false;
            PreviousButton.Click += PreviousButton_Click;
            // 
            // NextButton
            // 
            NextButton.Anchor = AnchorStyles.Bottom;
            NextButton.BackColor = SystemColors.Desktop;
            NextButton.Font = new Font("Segoe UI Symbol", 9F);
            NextButton.ForeColor = Color.White;
            NextButton.Location = new Point(307, 650);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(103, 32);
            NextButton.TabIndex = 55;
            NextButton.Text = "Next";
            NextButton.UseVisualStyleBackColor = false;
            NextButton.Click += NextButton_Click;
            // 
            // LabelPage
            // 
            LabelPage.Anchor = AnchorStyles.Bottom;
            LabelPage.AutoSize = true;
            LabelPage.Font = new Font("Segoe UI", 10F);
            LabelPage.ForeColor = Color.White;
            LabelPage.Location = new Point(12, 651);
            LabelPage.Name = "LabelPage";
            LabelPage.Size = new Size(56, 28);
            LabelPage.TabIndex = 56;
            LabelPage.Text = "??/??";
            // 
            // ImportTextbox
            // 
            ImportTextbox.Anchor = AnchorStyles.Top;
            ImportTextbox.BackColor = SystemColors.Desktop;
            ImportTextbox.Font = new Font("Segoe UI Symbol", 9F);
            ImportTextbox.ForeColor = Color.White;
            ImportTextbox.Location = new Point(443, 68);
            ImportTextbox.Name = "ImportTextbox";
            ImportTextbox.Size = new Size(233, 31);
            ImportTextbox.TabIndex = 57;
            // 
            // ImportBrowse
            // 
            ImportBrowse.Anchor = AnchorStyles.Top;
            ImportBrowse.BackColor = SystemColors.Desktop;
            ImportBrowse.Font = new Font("Segoe UI Symbol", 9F);
            ImportBrowse.ForeColor = Color.White;
            ImportBrowse.Location = new Point(682, 67);
            ImportBrowse.Name = "ImportBrowse";
            ImportBrowse.Size = new Size(105, 32);
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
            panel3.Location = new Point(224, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(29, 26);
            panel3.TabIndex = 42;
            // 
            // OnOffImport
            // 
            OnOffImport.Anchor = AnchorStyles.Top;
            OnOffImport.BackColor = SystemColors.Desktop;
            OnOffImport.Font = new Font("Segoe UI Symbol", 9F);
            OnOffImport.ForeColor = Color.White;
            OnOffImport.Location = new Point(259, 67);
            OnOffImport.Name = "OnOffImport";
            OnOffImport.Size = new Size(86, 32);
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
            panel4.Location = new Point(11, 51);
            panel4.Name = "panel4";
            panel4.Size = new Size(775, 10);
            panel4.TabIndex = 51;
            // 
            // CheckImport
            // 
            CheckImport.Anchor = AnchorStyles.Top;
            CheckImport.BackColor = SystemColors.Desktop;
            CheckImport.Font = new Font("Segoe UI Symbol", 9F);
            CheckImport.ForeColor = Color.White;
            CheckImport.Location = new Point(351, 67);
            CheckImport.Name = "CheckImport";
            CheckImport.Size = new Size(86, 32);
            CheckImport.TabIndex = 63;
            CheckImport.Text = "Check";
            CheckImport.UseVisualStyleBackColor = false;
            CheckImport.Click += CheckImport_Click;
            // 
            // BulkWindowForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 691);
            Controls.Add(CheckImport);
            Controls.Add(panel4);
            Controls.Add(OnOffImport);
            Controls.Add(panel3);
            Controls.Add(ImportBrowse);
            Controls.Add(ImportTextbox);
            Controls.Add(LabelPage);
            Controls.Add(PreviousButton);
            Controls.Add(NextButton);
            Controls.Add(button1);
            Controls.Add(txtSearch);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel);
            Controls.Add(RefreshButton);
            Controls.Add(label2);
            Controls.Add(ProcessListLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Button button1;
        private Button PreviousButton;
        private Button NextButton;
        private Label LabelPage;
        private TextBox ImportTextbox;
        private Button ImportBrowse;
        private Panel panel3;
        private Button OnOffImport;
        private Panel panel4;
        private Button CheckImport;
    }
}