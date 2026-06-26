namespace ProcessForge
{
    partial class ImportWindowForm
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
            button1 = new Button();
            txtSearch = new TextBox();
            panel2 = new Panel();
            panel1 = new Panel();
            flowLayoutPanel = new FlowLayoutPanel();
            RefreshButton = new Button();
            label2 = new Label();
            ProcessListLabel = new Label();
            SuspendLayout();
            // 
            // CheckImport
            // 
            CheckImport.BackColor = SystemColors.Desktop;
            CheckImport.Font = new Font("Segoe UI Symbol", 9F);
            CheckImport.ForeColor = Color.White;
            CheckImport.Location = new Point(350, 72);
            CheckImport.Name = "CheckImport";
            CheckImport.Size = new Size(86, 32);
            CheckImport.TabIndex = 80;
            CheckImport.Text = "Check";
            CheckImport.UseVisualStyleBackColor = false;
            CheckImport.Click += CheckImport_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.ForeColor = SystemColors.ActiveCaptionText;
            panel4.Location = new Point(10, 56);
            panel4.Name = "panel4";
            panel4.Size = new Size(775, 10);
            panel4.TabIndex = 70;
            // 
            // OnOffImport
            // 
            OnOffImport.BackColor = SystemColors.Desktop;
            OnOffImport.Font = new Font("Segoe UI Symbol", 9F);
            OnOffImport.ForeColor = Color.White;
            OnOffImport.Location = new Point(258, 72);
            OnOffImport.Name = "OnOffImport";
            OnOffImport.Size = new Size(86, 32);
            OnOffImport.TabIndex = 79;
            OnOffImport.Text = "On";
            OnOffImport.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Green;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Location = new Point(223, 75);
            panel3.Name = "panel3";
            panel3.Size = new Size(29, 26);
            panel3.TabIndex = 66;
            // 
            // ImportBrowse
            // 
            ImportBrowse.BackColor = SystemColors.Desktop;
            ImportBrowse.Font = new Font("Segoe UI Symbol", 9F);
            ImportBrowse.ForeColor = Color.White;
            ImportBrowse.Location = new Point(681, 72);
            ImportBrowse.Name = "ImportBrowse";
            ImportBrowse.Size = new Size(105, 32);
            ImportBrowse.TabIndex = 78;
            ImportBrowse.Text = "Browse";
            ImportBrowse.UseVisualStyleBackColor = false;
            ImportBrowse.Click += ImportBrowse_Click;
            // 
            // ImportTextbox
            // 
            ImportTextbox.BackColor = SystemColors.Desktop;
            ImportTextbox.Font = new Font("Segoe UI Symbol", 9F);
            ImportTextbox.ForeColor = Color.White;
            ImportTextbox.Location = new Point(442, 73);
            ImportTextbox.Name = "ImportTextbox";
            ImportTextbox.Size = new Size(233, 31);
            ImportTextbox.TabIndex = 77;
            // 
            // LabelPage
            // 
            LabelPage.AutoSize = true;
            LabelPage.Font = new Font("Segoe UI", 10F);
            LabelPage.ForeColor = Color.White;
            LabelPage.Location = new Point(370, 653);
            LabelPage.Name = "LabelPage";
            LabelPage.Size = new Size(56, 28);
            LabelPage.TabIndex = 76;
            LabelPage.Text = "??/??";
            // 
            // PreviousButton
            // 
            PreviousButton.BackColor = SystemColors.Desktop;
            PreviousButton.Font = new Font("Segoe UI Symbol", 9F);
            PreviousButton.ForeColor = Color.White;
            PreviousButton.Location = new Point(243, 652);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(103, 32);
            PreviousButton.TabIndex = 74;
            PreviousButton.Text = "Previous";
            PreviousButton.UseVisualStyleBackColor = false;
            PreviousButton.Click += PreviousButton_Click;
            // 
            // NextButton
            // 
            NextButton.BackColor = SystemColors.Desktop;
            NextButton.Font = new Font("Segoe UI Symbol", 9F);
            NextButton.ForeColor = Color.White;
            NextButton.Location = new Point(454, 652);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(103, 32);
            NextButton.TabIndex = 75;
            NextButton.Text = "Next";
            NextButton.UseVisualStyleBackColor = false;
            NextButton.Click += NextButton_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Desktop;
            button1.Font = new Font("Segoe UI Symbol", 9F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(350, 16);
            button1.Name = "button1";
            button1.Size = new Size(86, 32);
            button1.TabIndex = 73;
            button1.Text = "Find";
            button1.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.Desktop;
            txtSearch.Font = new Font("Segoe UI Symbol", 9F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(442, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(233, 31);
            txtSearch.TabIndex = 72;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.ForeColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(10, 636);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 10);
            panel2.TabIndex = 71;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(10, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 10);
            panel1.TabIndex = 69;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(10, 123);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(776, 507);
            flowLayoutPanel.TabIndex = 68;
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = SystemColors.Desktop;
            RefreshButton.Font = new Font("Segoe UI Symbol", 9F);
            RefreshButton.ForeColor = Color.White;
            RefreshButton.Location = new Point(681, 16);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(105, 32);
            RefreshButton.TabIndex = 67;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 10F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 73);
            label2.Name = "label2";
            label2.Size = new Size(159, 28);
            label2.TabIndex = 65;
            label2.Text = "Using .txt Import";
            // 
            // ProcessListLabel
            // 
            ProcessListLabel.AutoSize = true;
            ProcessListLabel.Font = new Font("Segoe UI Symbol", 12F);
            ProcessListLabel.ForeColor = Color.White;
            ProcessListLabel.Location = new Point(11, 14);
            ProcessListLabel.Name = "ProcessListLabel";
            ProcessListLabel.Size = new Size(127, 32);
            ProcessListLabel.TabIndex = 64;
            ProcessListLabel.Text = "Import List";
            // 
            // ImportWindowForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 702);
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
        private Button button1;
        private TextBox txtSearch;
        private Panel panel2;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel;
        private Button RefreshButton;
        private Label label2;
        private Label ProcessListLabel;
    }
}