namespace ProcessForge
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            ClearRAM = new Button();
            ValidatingEvent = new Button();
            label2 = new Label();
            MSTimeSetLabel = new Label();
            CountDownSeconds = new Label();
            Run1 = new Button();
            label5 = new Label();
            label6 = new Label();
            FilePathName = new TextBox();
            BrowseFile = new Button();
            label8 = new Label();
            MaxLabel = new Label();
            TestButton = new Button();
            label10 = new Label();
            Run2 = new Button();
            Terminate = new Button();
            ComboBox = new ComboBox();
            ProcessName = new TextBox();
            label11 = new Label();
            TimeSetForClearRAM = new NumericUpDown();
            CountDownTimer = new System.Windows.Forms.Timer(components);
            TimerForSeconds = new System.Windows.Forms.Timer(components);
            RenameTextbox = new TextBox();
            RenameLabel = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            RunTotalLabel = new Label();
            DelimiterToLabel = new Label();
            BrowseFileNotepad = new Button();
            NotepadPathTextbox = new TextBox();
            DelayLabel = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            DelayInformation = new Label();
            DelayInformation1 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            numericUpDown5 = new NumericUpDown();
            label4 = new Label();
            CPUChecker = new Button();
            panel4 = new Panel();
            label7 = new Label();
            OpenBulkWindow = new Button();
            TextWinHandler = new Label();
            OpenWindowImportThing = new Button();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)TimeSetForClearRAM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 14F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(8, 77);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(200, 25);
            label1.TabIndex = 0;
            label1.Text = "Clear Unused Memory";
            // 
            // ClearRAM
            // 
            ClearRAM.BackColor = SystemColors.Desktop;
            ClearRAM.Font = new Font("Segoe UI Symbol", 12F);
            ClearRAM.ForeColor = Color.White;
            ClearRAM.Location = new Point(8, 107);
            ClearRAM.Margin = new Padding(2);
            ClearRAM.Name = "ClearRAM";
            ClearRAM.Size = new Size(320, 42);
            ClearRAM.TabIndex = 1;
            ClearRAM.Text = "Clear RAM";
            ClearRAM.UseVisualStyleBackColor = false;
            ClearRAM.Click += ClearRAM_Click;
            // 
            // ValidatingEvent
            // 
            ValidatingEvent.BackColor = SystemColors.Desktop;
            ValidatingEvent.Font = new Font("Segoe UI Symbol", 12F);
            ValidatingEvent.ForeColor = Color.White;
            ValidatingEvent.Location = new Point(165, 338);
            ValidatingEvent.Margin = new Padding(2);
            ValidatingEvent.Name = "ValidatingEvent";
            ValidatingEvent.Size = new Size(162, 44);
            ValidatingEvent.TabIndex = 3;
            ValidatingEvent.Text = "Validate";
            ValidatingEvent.UseVisualStyleBackColor = false;
            ValidatingEvent.Click += ValidatingEvent_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 14F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(8, 177);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(234, 50);
            label2.TabIndex = 2;
            label2.Text = "Clear Unused Memory\r\n(Looping every X Seconds)";
            // 
            // MSTimeSetLabel
            // 
            MSTimeSetLabel.AutoSize = true;
            MSTimeSetLabel.Font = new Font("Segoe UI Symbol", 12F);
            MSTimeSetLabel.ForeColor = Color.White;
            MSTimeSetLabel.Location = new Point(7, 278);
            MSTimeSetLabel.Margin = new Padding(2, 0, 2, 0);
            MSTimeSetLabel.Name = "MSTimeSetLabel";
            MSTimeSetLabel.Size = new Size(132, 21);
            MSTimeSetLabel.TabIndex = 5;
            MSTimeSetLabel.Text = "(MS) No Time Set";
            // 
            // CountDownSeconds
            // 
            CountDownSeconds.AutoSize = true;
            CountDownSeconds.Font = new Font("Segoe UI Symbol", 12F);
            CountDownSeconds.ForeColor = Color.White;
            CountDownSeconds.Location = new Point(7, 309);
            CountDownSeconds.Margin = new Padding(2, 0, 2, 0);
            CountDownSeconds.Name = "CountDownSeconds";
            CountDownSeconds.Size = new Size(152, 21);
            CountDownSeconds.TabIndex = 6;
            CountDownSeconds.Text = "Count down event :  ";
            // 
            // Run1
            // 
            Run1.BackColor = SystemColors.Desktop;
            Run1.Font = new Font("Segoe UI Symbol", 12F);
            Run1.ForeColor = Color.White;
            Run1.Location = new Point(7, 338);
            Run1.Margin = new Padding(2);
            Run1.Name = "Run1";
            Run1.Size = new Size(154, 44);
            Run1.TabIndex = 7;
            Run1.Text = "Run";
            Run1.UseVisualStyleBackColor = false;
            Run1.Click += Run1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Desktop;
            label5.Font = new Font("Segoe UI Symbol", 14F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(470, 77);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(187, 25);
            label5.TabIndex = 8;
            label5.Text = "Run Bulk Application";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Symbol", 12F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(470, 102);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(69, 21);
            label6.TabIndex = 9;
            label6.Text = "File Path";
            // 
            // FilePathName
            // 
            FilePathName.BackColor = SystemColors.Desktop;
            FilePathName.Font = new Font("Segoe UI Symbol", 12F);
            FilePathName.ForeColor = Color.White;
            FilePathName.Location = new Point(470, 125);
            FilePathName.Margin = new Padding(2);
            FilePathName.Name = "FilePathName";
            FilePathName.Size = new Size(370, 29);
            FilePathName.TabIndex = 10;
            // 
            // BrowseFile
            // 
            BrowseFile.BackColor = SystemColors.Desktop;
            BrowseFile.Font = new Font("Segoe UI Symbol", 12F);
            BrowseFile.ForeColor = Color.White;
            BrowseFile.Location = new Point(470, 161);
            BrowseFile.Margin = new Padding(2);
            BrowseFile.Name = "BrowseFile";
            BrowseFile.Size = new Size(370, 40);
            BrowseFile.TabIndex = 11;
            BrowseFile.Text = "Browse File Location...";
            BrowseFile.UseVisualStyleBackColor = false;
            BrowseFile.Click += BrowseFile_Click_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Symbol", 12F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(470, 207);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(281, 21);
            label8.TabIndex = 13;
            label8.Text = "Rename Every App (Optional - Choose)";
            // 
            // MaxLabel
            // 
            MaxLabel.AutoSize = true;
            MaxLabel.Font = new Font("Segoe UI Symbol", 12F);
            MaxLabel.ForeColor = Color.White;
            MaxLabel.Location = new Point(760, 326);
            MaxLabel.Margin = new Padding(2, 0, 2, 0);
            MaxLabel.Name = "MaxLabel";
            MaxLabel.Size = new Size(87, 21);
            MaxLabel.TabIndex = 15;
            MaxLabel.Text = "Max (999x)";
            // 
            // TestButton
            // 
            TestButton.BackColor = SystemColors.Desktop;
            TestButton.Font = new Font("Segoe UI Symbol", 12F);
            TestButton.ForeColor = Color.White;
            TestButton.Location = new Point(473, 499);
            TestButton.Margin = new Padding(2);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(85, 32);
            TestButton.TabIndex = 16;
            TestButton.Text = "Test";
            TestButton.UseVisualStyleBackColor = false;
            TestButton.Click += TestButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Symbol", 12F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(562, 505);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(163, 21);
            label10.TabIndex = 17;
            label10.Text = "Click \"Test\" to validate";
            // 
            // Run2
            // 
            Run2.BackColor = SystemColors.Desktop;
            Run2.Font = new Font("Segoe UI Symbol", 12F);
            Run2.ForeColor = Color.White;
            Run2.Location = new Point(473, 535);
            Run2.Margin = new Padding(2);
            Run2.Name = "Run2";
            Run2.Size = new Size(181, 39);
            Run2.TabIndex = 18;
            Run2.Text = "Run";
            Run2.UseVisualStyleBackColor = false;
            Run2.Click += Run2_Click;
            // 
            // Terminate
            // 
            Terminate.BackColor = SystemColors.Desktop;
            Terminate.Font = new Font("Segoe UI Symbol", 12F);
            Terminate.ForeColor = Color.White;
            Terminate.Location = new Point(658, 535);
            Terminate.Margin = new Padding(2);
            Terminate.Name = "Terminate";
            Terminate.Size = new Size(179, 39);
            Terminate.TabIndex = 19;
            Terminate.Text = "Terminate";
            Terminate.UseVisualStyleBackColor = false;
            Terminate.Click += Terminate_Click;
            // 
            // ComboBox
            // 
            ComboBox.BackColor = SystemColors.Desktop;
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.Font = new Font("Segoe UI Symbol", 9F);
            ComboBox.ForeColor = Color.White;
            ComboBox.FormattingEnabled = true;
            ComboBox.Items.AddRange(new object[] { "None...", "Rename Title Manually (Advanced)", "Rename Title To Integer Increment (Advanced)", "Rename Title Using Notepad Import (Advanced)" });
            ComboBox.Location = new Point(470, 238);
            ComboBox.Margin = new Padding(2);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(370, 23);
            ComboBox.TabIndex = 20;
            ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // ProcessName
            // 
            ProcessName.BackColor = SystemColors.Desktop;
            ProcessName.Font = new Font("Segoe UI Symbol", 12F);
            ProcessName.ForeColor = Color.White;
            ProcessName.Location = new Point(8, 38);
            ProcessName.Margin = new Padding(2);
            ProcessName.MaxLength = 100;
            ProcessName.Name = "ProcessName";
            ProcessName.PlaceholderText = "(chrome, notepad, etc)";
            ProcessName.Size = new Size(834, 29);
            ProcessName.TabIndex = 21;
            ProcessName.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Symbol", 14F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(359, 9);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(131, 25);
            label11.TabIndex = 22;
            label11.Text = "Process Name";
            // 
            // TimeSetForClearRAM
            // 
            TimeSetForClearRAM.BackColor = SystemColors.Desktop;
            TimeSetForClearRAM.Font = new Font("Segoe UI Symbol", 12F);
            TimeSetForClearRAM.ForeColor = Color.White;
            TimeSetForClearRAM.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            TimeSetForClearRAM.Location = new Point(9, 238);
            TimeSetForClearRAM.Margin = new Padding(2);
            TimeSetForClearRAM.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            TimeSetForClearRAM.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            TimeSetForClearRAM.Name = "TimeSetForClearRAM";
            TimeSetForClearRAM.Size = new Size(113, 29);
            TimeSetForClearRAM.TabIndex = 23;
            TimeSetForClearRAM.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // CountDownTimer
            // 
            CountDownTimer.Interval = 10000;
            CountDownTimer.Tick += CountDownTimer_Tick;
            // 
            // TimerForSeconds
            // 
            TimerForSeconds.Interval = 1000;
            TimerForSeconds.Tick += TimerForSeconds_Tick;
            // 
            // RenameTextbox
            // 
            RenameTextbox.BackColor = SystemColors.Desktop;
            RenameTextbox.Font = new Font("Segoe UI Symbol", 12F);
            RenameTextbox.ForeColor = Color.White;
            RenameTextbox.Location = new Point(470, 295);
            RenameTextbox.Margin = new Padding(2);
            RenameTextbox.Name = "RenameTextbox";
            RenameTextbox.Size = new Size(305, 29);
            RenameTextbox.TabIndex = 25;
            // 
            // RenameLabel
            // 
            RenameLabel.AutoSize = true;
            RenameLabel.Font = new Font("Segoe UI Symbol", 12F);
            RenameLabel.ForeColor = Color.White;
            RenameLabel.Location = new Point(470, 266);
            RenameLabel.Margin = new Padding(2, 0, 2, 0);
            RenameLabel.Name = "RenameLabel";
            RenameLabel.Size = new Size(195, 21);
            RenameLabel.TabIndex = 24;
            RenameLabel.Text = "Rename Application Name";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = SystemColors.Desktop;
            numericUpDown1.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown1.ForeColor = Color.White;
            numericUpDown1.Location = new Point(473, 296);
            numericUpDown1.Margin = new Padding(2);
            numericUpDown1.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(40, 29);
            numericUpDown1.TabIndex = 26;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = SystemColors.Desktop;
            numericUpDown2.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown2.ForeColor = Color.White;
            numericUpDown2.Location = new Point(548, 296);
            numericUpDown2.Margin = new Padding(2);
            numericUpDown2.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(46, 29);
            numericUpDown2.TabIndex = 27;
            numericUpDown2.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // RunTotalLabel
            // 
            RunTotalLabel.AutoSize = true;
            RunTotalLabel.Font = new Font("Segoe UI Symbol", 12F);
            RunTotalLabel.ForeColor = Color.White;
            RunTotalLabel.Location = new Point(771, 266);
            RunTotalLabel.Margin = new Padding(2, 0, 2, 0);
            RunTotalLabel.Name = "RunTotalLabel";
            RunTotalLabel.Size = new Size(76, 21);
            RunTotalLabel.TabIndex = 28;
            RunTotalLabel.Text = "Run Total";
            // 
            // DelimiterToLabel
            // 
            DelimiterToLabel.AutoSize = true;
            DelimiterToLabel.Font = new Font("Segoe UI Symbol", 12F);
            DelimiterToLabel.ForeColor = Color.White;
            DelimiterToLabel.Location = new Point(517, 297);
            DelimiterToLabel.Margin = new Padding(2, 0, 2, 0);
            DelimiterToLabel.Name = "DelimiterToLabel";
            DelimiterToLabel.Size = new Size(27, 21);
            DelimiterToLabel.TabIndex = 30;
            DelimiterToLabel.Text = "To";
            // 
            // BrowseFileNotepad
            // 
            BrowseFileNotepad.BackColor = SystemColors.Desktop;
            BrowseFileNotepad.Font = new Font("Segoe UI Symbol", 12F);
            BrowseFileNotepad.ForeColor = Color.White;
            BrowseFileNotepad.Location = new Point(470, 339);
            BrowseFileNotepad.Margin = new Padding(2);
            BrowseFileNotepad.Name = "BrowseFileNotepad";
            BrowseFileNotepad.Size = new Size(370, 43);
            BrowseFileNotepad.TabIndex = 32;
            BrowseFileNotepad.Text = "Browse File Location...";
            BrowseFileNotepad.UseVisualStyleBackColor = false;
            BrowseFileNotepad.Click += BrowseFileNotepad_Click;
            // 
            // NotepadPathTextbox
            // 
            NotepadPathTextbox.BackColor = SystemColors.Desktop;
            NotepadPathTextbox.Font = new Font("Segoe UI Symbol", 12F);
            NotepadPathTextbox.ForeColor = Color.White;
            NotepadPathTextbox.Location = new Point(470, 295);
            NotepadPathTextbox.Margin = new Padding(2);
            NotepadPathTextbox.Name = "NotepadPathTextbox";
            NotepadPathTextbox.Size = new Size(370, 29);
            NotepadPathTextbox.TabIndex = 31;
            // 
            // DelayLabel
            // 
            DelayLabel.AutoSize = true;
            DelayLabel.Font = new Font("Segoe UI Symbol", 14F);
            DelayLabel.ForeColor = Color.White;
            DelayLabel.Location = new Point(470, 412);
            DelayLabel.Margin = new Padding(2, 0, 2, 0);
            DelayLabel.Name = "DelayLabel";
            DelayLabel.Size = new Size(59, 25);
            DelayLabel.TabIndex = 33;
            DelayLabel.Text = "Delay";
            // 
            // numericUpDown3
            // 
            numericUpDown3.BackColor = SystemColors.Desktop;
            numericUpDown3.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown3.ForeColor = Color.White;
            numericUpDown3.Location = new Point(473, 466);
            numericUpDown3.Margin = new Padding(2);
            numericUpDown3.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(85, 29);
            numericUpDown3.TabIndex = 34;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.BackColor = SystemColors.Desktop;
            numericUpDown4.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown4.ForeColor = Color.White;
            numericUpDown4.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown4.Location = new Point(586, 466);
            numericUpDown4.Margin = new Padding(2);
            numericUpDown4.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(251, 29);
            numericUpDown4.TabIndex = 35;
            // 
            // DelayInformation
            // 
            DelayInformation.AutoSize = true;
            DelayInformation.Font = new Font("Segoe UI Symbol", 12F);
            DelayInformation.ForeColor = Color.White;
            DelayInformation.Location = new Point(470, 442);
            DelayInformation.Margin = new Padding(2, 0, 2, 0);
            DelayInformation.Name = "DelayInformation";
            DelayInformation.Size = new Size(88, 21);
            DelayInformation.TabIndex = 36;
            DelayInformation.Text = "Application";
            // 
            // DelayInformation1
            // 
            DelayInformation1.AutoSize = true;
            DelayInformation1.Font = new Font("Segoe UI Symbol", 12F);
            DelayInformation1.ForeColor = Color.White;
            DelayInformation1.Location = new Point(586, 442);
            DelayInformation1.Margin = new Padding(2, 0, 2, 0);
            DelayInformation1.Name = "DelayInformation1";
            DelayInformation1.Size = new Size(96, 21);
            DelayInformation1.TabIndex = 37;
            DelayInformation1.Text = "Milliseconds";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(566, 468);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(16, 21);
            label3.TabIndex = 38;
            label3.Text = "/";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(8, 161);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(319, 10);
            panel1.TabIndex = 39;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Location = new Point(296, 303);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(30, 27);
            panel2.TabIndex = 40;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Location = new Point(809, 507);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(28, 24);
            panel3.TabIndex = 41;
            // 
            // numericUpDown5
            // 
            numericUpDown5.BackColor = SystemColors.Desktop;
            numericUpDown5.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown5.ForeColor = Color.White;
            numericUpDown5.Location = new Point(779, 295);
            numericUpDown5.Margin = new Padding(2);
            numericUpDown5.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown5.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(61, 29);
            numericUpDown5.TabIndex = 42;
            numericUpDown5.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(618, 416);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(148, 21);
            label4.TabIndex = 44;
            label4.Text = "Pause if CPU% > 80";
            // 
            // CPUChecker
            // 
            CPUChecker.BackColor = Color.Red;
            CPUChecker.Font = new Font("Segoe UI Symbol", 9F);
            CPUChecker.ForeColor = Color.Black;
            CPUChecker.Location = new Point(771, 416);
            CPUChecker.Margin = new Padding(2);
            CPUChecker.Name = "CPUChecker";
            CPUChecker.Size = new Size(66, 21);
            CPUChecker.TabIndex = 45;
            CPUChecker.Text = "Off";
            CPUChecker.UseVisualStyleBackColor = false;
            CPUChecker.Click += CPUChecker_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.ForeColor = SystemColors.ActiveCaptionText;
            panel4.Location = new Point(9, 393);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(319, 10);
            panel4.TabIndex = 40;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Symbol", 14F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(8, 408);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(159, 25);
            label7.TabIndex = 46;
            label7.Text = "Bulk App Handler";
            // 
            // OpenBulkWindow
            // 
            OpenBulkWindow.BackColor = SystemColors.Desktop;
            OpenBulkWindow.Font = new Font("Segoe UI Symbol", 12F);
            OpenBulkWindow.ForeColor = Color.White;
            OpenBulkWindow.Location = new Point(8, 441);
            OpenBulkWindow.Margin = new Padding(2);
            OpenBulkWindow.Name = "OpenBulkWindow";
            OpenBulkWindow.Size = new Size(320, 44);
            OpenBulkWindow.TabIndex = 47;
            OpenBulkWindow.Text = "Open";
            OpenBulkWindow.UseVisualStyleBackColor = false;
            OpenBulkWindow.Click += OpenBulkWindow_Click;
            // 
            // TextWinHandler
            // 
            TextWinHandler.AutoSize = true;
            TextWinHandler.Font = new Font("Segoe UI Symbol", 14F);
            TextWinHandler.ForeColor = Color.White;
            TextWinHandler.Location = new Point(8, 492);
            TextWinHandler.Margin = new Padding(2, 0, 2, 0);
            TextWinHandler.Name = "TextWinHandler";
            TextWinHandler.Size = new Size(180, 25);
            TextWinHandler.TabIndex = 48;
            TextWinHandler.Text = "Text Import Handler";
            // 
            // OpenWindowImportThing
            // 
            OpenWindowImportThing.BackColor = SystemColors.Desktop;
            OpenWindowImportThing.Font = new Font("Segoe UI Symbol", 12F);
            OpenWindowImportThing.ForeColor = Color.White;
            OpenWindowImportThing.Location = new Point(8, 525);
            OpenWindowImportThing.Margin = new Padding(2);
            OpenWindowImportThing.Name = "OpenWindowImportThing";
            OpenWindowImportThing.Size = new Size(320, 49);
            OpenWindowImportThing.TabIndex = 49;
            OpenWindowImportThing.Text = "Open";
            OpenWindowImportThing.UseVisualStyleBackColor = false;
            OpenWindowImportThing.Click += OpenWindowImportThing_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.ForeColor = SystemColors.ActiveCaptionText;
            panel5.Location = new Point(470, 395);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(367, 10);
            panel5.TabIndex = 41;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(857, 599);
            Controls.Add(panel5);
            Controls.Add(OpenWindowImportThing);
            Controls.Add(TextWinHandler);
            Controls.Add(OpenBulkWindow);
            Controls.Add(label7);
            Controls.Add(panel4);
            Controls.Add(CPUChecker);
            Controls.Add(label4);
            Controls.Add(numericUpDown5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(DelayInformation1);
            Controls.Add(DelayInformation);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown3);
            Controls.Add(DelayLabel);
            Controls.Add(BrowseFileNotepad);
            Controls.Add(NotepadPathTextbox);
            Controls.Add(DelimiterToLabel);
            Controls.Add(RunTotalLabel);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(RenameTextbox);
            Controls.Add(RenameLabel);
            Controls.Add(TimeSetForClearRAM);
            Controls.Add(label11);
            Controls.Add(ProcessName);
            Controls.Add(ComboBox);
            Controls.Add(Terminate);
            Controls.Add(Run2);
            Controls.Add(label10);
            Controls.Add(TestButton);
            Controls.Add(MaxLabel);
            Controls.Add(label8);
            Controls.Add(BrowseFile);
            Controls.Add(FilePathName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(Run1);
            Controls.Add(CountDownSeconds);
            Controls.Add(MSTimeSetLabel);
            Controls.Add(ValidatingEvent);
            Controls.Add(label2);
            Controls.Add(ClearRAM);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Process Forge (0.0.0)";
            ((System.ComponentModel.ISupportInitialize)TimeSetForClearRAM).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Button ClearRAM;
        private Button ValidatingEvent;
        private Label label2;
        private Label MSTimeSetLabel;
        private Label CountDownSeconds;
        private Button Run1;
        private Label label5;
        private Label label6;
        private TextBox FilePathName;
        private Button BrowseFile;
        private Label label8;
        private Label MaxLabel;
        private Button TestButton;
        private Label label10;
        private Button Run2;
        private Button Terminate;
        private ComboBox ComboBox;
        private TextBox ProcessName;
        private Label label11;
        private NumericUpDown TimeSetForClearRAM;
        private System.Windows.Forms.Timer CountDownTimer;
        private System.Windows.Forms.Timer TimerForSeconds;
        private TextBox RenameTextbox;
        private Label RenameLabel;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label RunTotalLabel;
        private Label DelimiterToLabel;
        private Button BrowseFileNotepad;
        private TextBox NotepadPathTextbox;
        private Label DelayLabel;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private Label DelayInformation;
        private Label DelayInformation1;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private NumericUpDown numericUpDown5;
        private Label label4;
        private Button CPUChecker;
        private Panel panel4;
        private Label label7;
        private Button OpenBulkWindow;
        private Label TextWinHandler;
        private Button OpenWindowImportThing;
        private Panel panel5;
    }
}
