namespace ProcessForge
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            ClearRAM = new Button();
            ValidatingEvent = new Button();
            label2 = new Label();
            TimeForLooping = new TextBox();
            label3 = new Label();
            label4 = new Label();
            Run1 = new Button();
            label5 = new Label();
            label6 = new Label();
            FilePathName = new TextBox();
            BrowseFile = new Button();
            label7 = new Label();
            label8 = new Label();
            textBox3 = new TextBox();
            label9 = new Label();
            TestButton = new Button();
            label10 = new Label();
            Run2 = new Button();
            Terminate = new Button();
            ComboBox = new ComboBox();
            ProcessName = new TextBox();
            label11 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 73);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 0;
            label1.Text = "Clear Unused Memory";
            // 
            // ClearRAM
            // 
            ClearRAM.Location = new Point(12, 101);
            ClearRAM.Name = "ClearRAM";
            ClearRAM.Size = new Size(112, 34);
            ClearRAM.TabIndex = 1;
            ClearRAM.Text = "Clear RAM";
            ClearRAM.UseVisualStyleBackColor = true;
            ClearRAM.Click += ClearRAM_Click;
            // 
            // ValidatingEvent
            // 
            ValidatingEvent.Location = new Point(12, 228);
            ValidatingEvent.Name = "ValidatingEvent";
            ValidatingEvent.Size = new Size(112, 34);
            ValidatingEvent.TabIndex = 3;
            ValidatingEvent.Text = "Validating";
            ValidatingEvent.UseVisualStyleBackColor = true;
            ValidatingEvent.Click += ValidatingEvent_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 138);
            label2.Name = "label2";
            label2.Size = new Size(223, 50);
            label2.TabIndex = 2;
            label2.Text = "Clear Unused Memory\r\n(Looping every X Seconds)";
            // 
            // TimeForLooping
            // 
            TimeForLooping.Location = new Point(12, 191);
            TimeForLooping.Name = "TimeForLooping";
            TimeForLooping.Size = new Size(150, 31);
            TimeForLooping.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(179, 191);
            label3.Name = "label3";
            label3.Size = new Size(150, 25);
            label3.TabIndex = 5;
            label3.Text = "(MS) No Time Set";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 265);
            label4.Name = "label4";
            label4.Size = new Size(177, 25);
            label4.TabIndex = 6;
            label4.Text = "Count down event :  ";
            // 
            // Run1
            // 
            Run1.Location = new Point(12, 293);
            Run1.Name = "Run1";
            Run1.Size = new Size(112, 34);
            Run1.TabIndex = 7;
            Run1.Text = "Run";
            Run1.UseVisualStyleBackColor = true;
            Run1.Click += Run1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(455, 73);
            label5.Name = "label5";
            label5.Size = new Size(176, 25);
            label5.TabIndex = 8;
            label5.Text = "Run Bulk Application";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(455, 110);
            label6.Name = "label6";
            label6.Size = new Size(77, 25);
            label6.TabIndex = 9;
            label6.Text = "File Path";
            // 
            // FilePathName
            // 
            FilePathName.Location = new Point(455, 138);
            FilePathName.Name = "FilePathName";
            FilePathName.Size = new Size(273, 31);
            FilePathName.TabIndex = 10;
            // 
            // BrowseFile
            // 
            BrowseFile.Location = new Point(455, 175);
            BrowseFile.Name = "BrowseFile";
            BrowseFile.Size = new Size(273, 34);
            BrowseFile.TabIndex = 11;
            BrowseFile.Text = "Browse File Location...";
            BrowseFile.UseVisualStyleBackColor = true;
            BrowseFile.Click += BrowseFile_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(455, 228);
            label7.Name = "label7";
            label7.Size = new Size(85, 25);
            label7.TabIndex = 12;
            label7.Text = "Run Total";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(546, 228);
            label8.Name = "label8";
            label8.Size = new Size(322, 25);
            label8.TabIndex = 13;
            label8.Text = "Rename Every App (Optional - Choose)";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(455, 256);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(85, 31);
            textBox3.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(455, 290);
            label9.Name = "label9";
            label9.Size = new Size(98, 25);
            label9.TabIndex = 15;
            label9.Text = "Max (999x)";
            // 
            // TestButton
            // 
            TestButton.Location = new Point(455, 318);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(85, 34);
            TestButton.TabIndex = 16;
            TestButton.Text = "Test";
            TestButton.UseVisualStyleBackColor = true;
            TestButton.Click += TestButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(546, 323);
            label10.Name = "label10";
            label10.Size = new Size(185, 25);
            label10.TabIndex = 17;
            label10.Text = "Click \"Test\" to validate";
            // 
            // Run2
            // 
            Run2.Location = new Point(455, 358);
            Run2.Name = "Run2";
            Run2.Size = new Size(176, 34);
            Run2.TabIndex = 18;
            Run2.Text = "Run";
            Run2.UseVisualStyleBackColor = true;
            Run2.Click += Run2_Click;
            // 
            // Terminate
            // 
            Terminate.Location = new Point(637, 358);
            Terminate.Name = "Terminate";
            Terminate.Size = new Size(176, 34);
            Terminate.TabIndex = 19;
            Terminate.Text = "Terminate";
            Terminate.UseVisualStyleBackColor = true;
            Terminate.Click += Terminate_Click;
            // 
            // ComboBox
            // 
            ComboBox.FormattingEnabled = true;
            ComboBox.Location = new Point(549, 256);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(319, 33);
            ComboBox.TabIndex = 20;
            // 
            // ProcessName
            // 
            ProcessName.Location = new Point(12, 39);
            ProcessName.Name = "ProcessName";
            ProcessName.Size = new Size(856, 31);
            ProcessName.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(366, 11);
            label11.Name = "label11";
            label11.Size = new Size(124, 25);
            label11.TabIndex = 22;
            label11.Text = "Process Name";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(900, 450);
            Controls.Add(label11);
            Controls.Add(ProcessName);
            Controls.Add(ComboBox);
            Controls.Add(Terminate);
            Controls.Add(Run2);
            Controls.Add(label10);
            Controls.Add(TestButton);
            Controls.Add(label9);
            Controls.Add(textBox3);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(BrowseFile);
            Controls.Add(FilePathName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(Run1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(TimeForLooping);
            Controls.Add(ValidatingEvent);
            Controls.Add(label2);
            Controls.Add(ClearRAM);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Process Forge (0.0.0)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button ClearRAM;
        private Button ValidatingEvent;
        private Label label2;
        private TextBox TimeForLooping;
        private Label label3;
        private Label label4;
        private Button Run1;
        private Label label5;
        private Label label6;
        private TextBox FilePathName;
        private Button BrowseFile;
        private Label label7;
        private Label label8;
        private TextBox textBox3;
        private Label label9;
        private Button TestButton;
        private Label label10;
        private Button Run2;
        private Button Terminate;
        private ComboBox ComboBox;
        private TextBox ProcessName;
        private Label label11;
    }
}
