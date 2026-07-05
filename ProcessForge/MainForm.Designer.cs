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
            panel6 = new Panel();
            label9 = new Label();
            browseAccount = new Button();
            FilePathNameLogin = new TextBox();
            label12 = new Label();
            label13 = new Label();
            panel7 = new Panel();
            runLogin = new Button();
            panel8 = new Panel();
            label14 = new Label();
            testLogin = new Button();
            flowLayoutPanel = new FlowLayoutPanel();
            refreshButton = new Button();
            resetButton = new Button();
            txtSearchLogin = new TextBox();
            accountFileHandler = new Button();
            panel9 = new Panel();
            label15 = new Label();
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
            label1.Location = new Point(11, 128);
            label1.Name = "label1";
            label1.Size = new Size(294, 38);
            label1.TabIndex = 0;
            label1.Text = "Clear Unused Memory";
            // 
            // ClearRAM
            // 
            ClearRAM.BackColor = SystemColors.Desktop;
            ClearRAM.Font = new Font("Segoe UI Symbol", 12F);
            ClearRAM.ForeColor = Color.White;
            ClearRAM.Location = new Point(11, 178);
            ClearRAM.Name = "ClearRAM";
            ClearRAM.Size = new Size(457, 70);
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
            ValidatingEvent.Location = new Point(236, 563);
            ValidatingEvent.Name = "ValidatingEvent";
            ValidatingEvent.Size = new Size(231, 73);
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
            label2.Location = new Point(11, 295);
            label2.Name = "label2";
            label2.Size = new Size(344, 76);
            label2.TabIndex = 2;
            label2.Text = "Clear Unused Memory\r\n(Looping every X Seconds)";
            // 
            // MSTimeSetLabel
            // 
            MSTimeSetLabel.AutoSize = true;
            MSTimeSetLabel.Font = new Font("Segoe UI Symbol", 12F);
            MSTimeSetLabel.ForeColor = Color.White;
            MSTimeSetLabel.Location = new Point(10, 463);
            MSTimeSetLabel.Name = "MSTimeSetLabel";
            MSTimeSetLabel.Size = new Size(203, 32);
            MSTimeSetLabel.TabIndex = 5;
            MSTimeSetLabel.Text = "(MS) No Time Set";
            // 
            // CountDownSeconds
            // 
            CountDownSeconds.AutoSize = true;
            CountDownSeconds.Font = new Font("Segoe UI Symbol", 12F);
            CountDownSeconds.ForeColor = Color.White;
            CountDownSeconds.Location = new Point(10, 515);
            CountDownSeconds.Name = "CountDownSeconds";
            CountDownSeconds.Size = new Size(238, 32);
            CountDownSeconds.TabIndex = 6;
            CountDownSeconds.Text = "Count down event :  ";
            // 
            // Run1
            // 
            Run1.BackColor = SystemColors.Desktop;
            Run1.Font = new Font("Segoe UI Symbol", 12F);
            Run1.ForeColor = Color.White;
            Run1.Location = new Point(10, 563);
            Run1.Name = "Run1";
            Run1.Size = new Size(220, 73);
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
            label5.Location = new Point(671, 128);
            label5.Name = "label5";
            label5.Size = new Size(274, 38);
            label5.TabIndex = 8;
            label5.Text = "Run Bulk Application";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Symbol", 12F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(671, 170);
            label6.Name = "label6";
            label6.Size = new Size(105, 32);
            label6.TabIndex = 9;
            label6.Text = "File Path";
            // 
            // FilePathName
            // 
            FilePathName.BackColor = SystemColors.Desktop;
            FilePathName.Font = new Font("Segoe UI Symbol", 12F);
            FilePathName.ForeColor = Color.White;
            FilePathName.Location = new Point(671, 208);
            FilePathName.Name = "FilePathName";
            FilePathName.Size = new Size(527, 39);
            FilePathName.TabIndex = 10;
            // 
            // BrowseFile
            // 
            BrowseFile.BackColor = SystemColors.Desktop;
            BrowseFile.Font = new Font("Segoe UI Symbol", 12F);
            BrowseFile.ForeColor = Color.White;
            BrowseFile.Location = new Point(671, 268);
            BrowseFile.Name = "BrowseFile";
            BrowseFile.Size = new Size(529, 67);
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
            label8.Location = new Point(671, 345);
            label8.Name = "label8";
            label8.Size = new Size(432, 32);
            label8.TabIndex = 13;
            label8.Text = "Rename Every App (Optional - Choose)";
            // 
            // MaxLabel
            // 
            MaxLabel.AutoSize = true;
            MaxLabel.Font = new Font("Segoe UI Symbol", 12F);
            MaxLabel.ForeColor = Color.White;
            MaxLabel.Location = new Point(1086, 543);
            MaxLabel.Name = "MaxLabel";
            MaxLabel.Size = new Size(130, 32);
            MaxLabel.TabIndex = 15;
            MaxLabel.Text = "Max (999x)";
            // 
            // TestButton
            // 
            TestButton.BackColor = SystemColors.Desktop;
            TestButton.Font = new Font("Segoe UI Symbol", 12F);
            TestButton.ForeColor = Color.White;
            TestButton.Location = new Point(676, 832);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(121, 53);
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
            label10.Location = new Point(803, 842);
            label10.Name = "label10";
            label10.Size = new Size(252, 32);
            label10.TabIndex = 17;
            label10.Text = "Click \"Test\" to validate";
            // 
            // Run2
            // 
            Run2.BackColor = SystemColors.Desktop;
            Run2.Font = new Font("Segoe UI Symbol", 12F);
            Run2.ForeColor = Color.White;
            Run2.Location = new Point(676, 892);
            Run2.Name = "Run2";
            Run2.Size = new Size(259, 65);
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
            Terminate.Location = new Point(940, 892);
            Terminate.Name = "Terminate";
            Terminate.Size = new Size(256, 65);
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
            ComboBox.Location = new Point(671, 397);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(527, 33);
            ComboBox.TabIndex = 20;
            ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // ProcessName
            // 
            ProcessName.BackColor = SystemColors.Desktop;
            ProcessName.Font = new Font("Segoe UI Symbol", 12F);
            ProcessName.ForeColor = Color.White;
            ProcessName.Location = new Point(11, 63);
            ProcessName.MaxLength = 100;
            ProcessName.Name = "ProcessName";
            ProcessName.PlaceholderText = "(chrome, notepad, etc)";
            ProcessName.Size = new Size(1190, 39);
            ProcessName.TabIndex = 21;
            ProcessName.Text = "kh2";
            ProcessName.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Symbol", 14F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(513, 15);
            label11.Name = "label11";
            label11.Size = new Size(193, 38);
            label11.TabIndex = 22;
            label11.Text = "Process Name";
            // 
            // TimeSetForClearRAM
            // 
            TimeSetForClearRAM.BackColor = SystemColors.Desktop;
            TimeSetForClearRAM.Font = new Font("Segoe UI Symbol", 12F);
            TimeSetForClearRAM.ForeColor = Color.White;
            TimeSetForClearRAM.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            TimeSetForClearRAM.Location = new Point(13, 397);
            TimeSetForClearRAM.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            TimeSetForClearRAM.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            TimeSetForClearRAM.Name = "TimeSetForClearRAM";
            TimeSetForClearRAM.Size = new Size(161, 39);
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
            RenameTextbox.Location = new Point(671, 492);
            RenameTextbox.Name = "RenameTextbox";
            RenameTextbox.Size = new Size(434, 39);
            RenameTextbox.TabIndex = 25;
            // 
            // RenameLabel
            // 
            RenameLabel.AutoSize = true;
            RenameLabel.Font = new Font("Segoe UI Symbol", 12F);
            RenameLabel.ForeColor = Color.White;
            RenameLabel.Location = new Point(671, 443);
            RenameLabel.Name = "RenameLabel";
            RenameLabel.Size = new Size(299, 32);
            RenameLabel.TabIndex = 24;
            RenameLabel.Text = "Rename Application Name";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = SystemColors.Desktop;
            numericUpDown1.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown1.ForeColor = Color.White;
            numericUpDown1.Location = new Point(676, 493);
            numericUpDown1.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(57, 39);
            numericUpDown1.TabIndex = 26;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = SystemColors.Desktop;
            numericUpDown2.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown2.ForeColor = Color.White;
            numericUpDown2.Location = new Point(783, 493);
            numericUpDown2.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(66, 39);
            numericUpDown2.TabIndex = 27;
            numericUpDown2.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // RunTotalLabel
            // 
            RunTotalLabel.AutoSize = true;
            RunTotalLabel.Font = new Font("Segoe UI Symbol", 12F);
            RunTotalLabel.ForeColor = Color.White;
            RunTotalLabel.Location = new Point(1101, 443);
            RunTotalLabel.Name = "RunTotalLabel";
            RunTotalLabel.Size = new Size(116, 32);
            RunTotalLabel.TabIndex = 28;
            RunTotalLabel.Text = "Run Total";
            // 
            // DelimiterToLabel
            // 
            DelimiterToLabel.AutoSize = true;
            DelimiterToLabel.Font = new Font("Segoe UI Symbol", 12F);
            DelimiterToLabel.ForeColor = Color.White;
            DelimiterToLabel.Location = new Point(739, 495);
            DelimiterToLabel.Name = "DelimiterToLabel";
            DelimiterToLabel.Size = new Size(41, 32);
            DelimiterToLabel.TabIndex = 30;
            DelimiterToLabel.Text = "To";
            // 
            // BrowseFileNotepad
            // 
            BrowseFileNotepad.BackColor = SystemColors.Desktop;
            BrowseFileNotepad.Font = new Font("Segoe UI Symbol", 12F);
            BrowseFileNotepad.ForeColor = Color.White;
            BrowseFileNotepad.Location = new Point(671, 565);
            BrowseFileNotepad.Name = "BrowseFileNotepad";
            BrowseFileNotepad.Size = new Size(529, 72);
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
            NotepadPathTextbox.Location = new Point(671, 492);
            NotepadPathTextbox.Name = "NotepadPathTextbox";
            NotepadPathTextbox.Size = new Size(527, 39);
            NotepadPathTextbox.TabIndex = 31;
            // 
            // DelayLabel
            // 
            DelayLabel.AutoSize = true;
            DelayLabel.Font = new Font("Segoe UI Symbol", 14F);
            DelayLabel.ForeColor = Color.White;
            DelayLabel.Location = new Point(671, 687);
            DelayLabel.Name = "DelayLabel";
            DelayLabel.Size = new Size(87, 38);
            DelayLabel.TabIndex = 33;
            DelayLabel.Text = "Delay";
            // 
            // numericUpDown3
            // 
            numericUpDown3.BackColor = SystemColors.Desktop;
            numericUpDown3.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown3.ForeColor = Color.White;
            numericUpDown3.Location = new Point(676, 777);
            numericUpDown3.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(121, 39);
            numericUpDown3.TabIndex = 34;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.BackColor = SystemColors.Desktop;
            numericUpDown4.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown4.ForeColor = Color.White;
            numericUpDown4.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown4.Location = new Point(837, 777);
            numericUpDown4.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(359, 39);
            numericUpDown4.TabIndex = 35;
            // 
            // DelayInformation
            // 
            DelayInformation.AutoSize = true;
            DelayInformation.Font = new Font("Segoe UI Symbol", 12F);
            DelayInformation.ForeColor = Color.White;
            DelayInformation.Location = new Point(671, 737);
            DelayInformation.Name = "DelayInformation";
            DelayInformation.Size = new Size(134, 32);
            DelayInformation.TabIndex = 36;
            DelayInformation.Text = "Application";
            // 
            // DelayInformation1
            // 
            DelayInformation1.AutoSize = true;
            DelayInformation1.Font = new Font("Segoe UI Symbol", 12F);
            DelayInformation1.ForeColor = Color.White;
            DelayInformation1.Location = new Point(837, 737);
            DelayInformation1.Name = "DelayInformation1";
            DelayInformation1.Size = new Size(146, 32);
            DelayInformation1.TabIndex = 37;
            DelayInformation1.Text = "Milliseconds";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Symbol", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(809, 780);
            label3.Name = "label3";
            label3.Size = new Size(23, 32);
            label3.TabIndex = 38;
            label3.Text = "/";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(11, 268);
            panel1.Name = "panel1";
            panel1.Size = new Size(454, 14);
            panel1.TabIndex = 39;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Location = new Point(423, 505);
            panel2.Name = "panel2";
            panel2.Size = new Size(41, 42);
            panel2.TabIndex = 40;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Location = new Point(1156, 845);
            panel3.Name = "panel3";
            panel3.Size = new Size(38, 37);
            panel3.TabIndex = 41;
            // 
            // numericUpDown5
            // 
            numericUpDown5.BackColor = SystemColors.Desktop;
            numericUpDown5.Font = new Font("Segoe UI Symbol", 12F);
            numericUpDown5.ForeColor = Color.White;
            numericUpDown5.Location = new Point(1113, 492);
            numericUpDown5.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown5.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(87, 39);
            numericUpDown5.TabIndex = 42;
            numericUpDown5.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Symbol", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(883, 693);
            label4.Name = "label4";
            label4.Size = new Size(224, 32);
            label4.TabIndex = 44;
            label4.Text = "Pause if CPU% > 80";
            // 
            // CPUChecker
            // 
            CPUChecker.BackColor = Color.Red;
            CPUChecker.Font = new Font("Segoe UI Symbol", 9F);
            CPUChecker.ForeColor = Color.Black;
            CPUChecker.Location = new Point(1101, 693);
            CPUChecker.Name = "CPUChecker";
            CPUChecker.Size = new Size(94, 35);
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
            panel4.Location = new Point(13, 655);
            panel4.Name = "panel4";
            panel4.Size = new Size(454, 14);
            panel4.TabIndex = 40;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Symbol", 14F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(11, 680);
            label7.Name = "label7";
            label7.Size = new Size(234, 38);
            label7.TabIndex = 46;
            label7.Text = "Bulk App Handler";
            // 
            // OpenBulkWindow
            // 
            OpenBulkWindow.BackColor = SystemColors.Desktop;
            OpenBulkWindow.Font = new Font("Segoe UI Symbol", 12F);
            OpenBulkWindow.ForeColor = Color.White;
            OpenBulkWindow.Location = new Point(11, 735);
            OpenBulkWindow.Name = "OpenBulkWindow";
            OpenBulkWindow.Size = new Size(457, 73);
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
            TextWinHandler.Location = new Point(11, 820);
            TextWinHandler.Name = "TextWinHandler";
            TextWinHandler.Size = new Size(265, 38);
            TextWinHandler.TabIndex = 48;
            TextWinHandler.Text = "Text Import Handler";
            // 
            // OpenWindowImportThing
            // 
            OpenWindowImportThing.BackColor = SystemColors.Desktop;
            OpenWindowImportThing.Font = new Font("Segoe UI Symbol", 12F);
            OpenWindowImportThing.ForeColor = Color.White;
            OpenWindowImportThing.Location = new Point(11, 875);
            OpenWindowImportThing.Name = "OpenWindowImportThing";
            OpenWindowImportThing.Size = new Size(457, 82);
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
            panel5.Location = new Point(671, 658);
            panel5.Name = "panel5";
            panel5.Size = new Size(523, 14);
            panel5.TabIndex = 41;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Transparent;
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.ForeColor = SystemColors.ActiveCaptionText;
            panel6.Location = new Point(1222, 26);
            panel6.Name = "panel6";
            panel6.Size = new Size(10, 934);
            panel6.TabIndex = 40;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Symbol", 14F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(1248, 15);
            label9.Name = "label9";
            label9.Size = new Size(152, 38);
            label9.TabIndex = 50;
            label9.Text = "Auto Login";
            // 
            // browseAccount
            // 
            browseAccount.BackColor = SystemColors.Desktop;
            browseAccount.Font = new Font("Segoe UI Symbol", 12F);
            browseAccount.ForeColor = Color.White;
            browseAccount.Location = new Point(1248, 199);
            browseAccount.Name = "browseAccount";
            browseAccount.Size = new Size(288, 67);
            browseAccount.TabIndex = 54;
            browseAccount.Text = "Browse File Location...";
            browseAccount.UseVisualStyleBackColor = false;
            browseAccount.Click += browseAccount_Click;
            // 
            // FilePathNameLogin
            // 
            FilePathNameLogin.BackColor = SystemColors.Desktop;
            FilePathNameLogin.Font = new Font("Segoe UI Symbol", 12F);
            FilePathNameLogin.ForeColor = Color.White;
            FilePathNameLogin.Location = new Point(1248, 148);
            FilePathNameLogin.Name = "FilePathNameLogin";
            FilePathNameLogin.PlaceholderText = "(Your Account Data File...)";
            FilePathNameLogin.Size = new Size(602, 39);
            FilePathNameLogin.TabIndex = 53;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Symbol", 12F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(1248, 110);
            label12.Name = "label12";
            label12.Size = new Size(255, 32);
            label12.TabIndex = 52;
            label12.Text = "Account Data File Path";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.Desktop;
            label13.Font = new Font("Segoe UI Symbol", 14F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(1248, 68);
            label13.Name = "label13";
            label13.Size = new Size(376, 38);
            label13.TabIndex = 51;
            label13.Text = "Auto-Login For All Exist Apps";
            // 
            // panel7
            // 
            panel7.BackColor = Color.Transparent;
            panel7.BorderStyle = BorderStyle.Fixed3D;
            panel7.ForeColor = SystemColors.ActiveCaptionText;
            panel7.Location = new Point(1248, 813);
            panel7.Name = "panel7";
            panel7.Size = new Size(602, 14);
            panel7.TabIndex = 42;
            // 
            // runLogin
            // 
            runLogin.BackColor = SystemColors.Desktop;
            runLogin.Font = new Font("Segoe UI Symbol", 12F);
            runLogin.ForeColor = Color.White;
            runLogin.Location = new Point(1248, 892);
            runLogin.Name = "runLogin";
            runLogin.Size = new Size(602, 65);
            runLogin.TabIndex = 55;
            runLogin.Text = "Run";
            runLogin.UseVisualStyleBackColor = false;
            runLogin.Click += runLogin_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Red;
            panel8.BorderStyle = BorderStyle.Fixed3D;
            panel8.Location = new Point(1812, 845);
            panel8.Name = "panel8";
            panel8.Size = new Size(38, 37);
            panel8.TabIndex = 42;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Symbol", 12F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(1375, 843);
            label14.Name = "label14";
            label14.Size = new Size(252, 32);
            label14.TabIndex = 58;
            label14.Text = "Click \"Test\" to validate";
            // 
            // testLogin
            // 
            testLogin.BackColor = SystemColors.Desktop;
            testLogin.Font = new Font("Segoe UI Symbol", 12F);
            testLogin.ForeColor = Color.White;
            testLogin.Location = new Point(1248, 833);
            testLogin.Name = "testLogin";
            testLogin.Size = new Size(121, 53);
            testLogin.TabIndex = 57;
            testLogin.Text = "Test";
            testLogin.UseVisualStyleBackColor = false;
            testLogin.Click += testLogin_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(1248, 473);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(602, 334);
            flowLayoutPanel.TabIndex = 69;
            // 
            // refreshButton
            // 
            refreshButton.BackColor = SystemColors.Desktop;
            refreshButton.Font = new Font("Segoe UI Symbol", 12F);
            refreshButton.ForeColor = Color.White;
            refreshButton.Location = new Point(1248, 355);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(288, 65);
            refreshButton.TabIndex = 70;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += refreshButton_Click;
            // 
            // resetButton
            // 
            resetButton.BackColor = SystemColors.Desktop;
            resetButton.Font = new Font("Segoe UI Symbol", 12F);
            resetButton.ForeColor = Color.White;
            resetButton.Location = new Point(1542, 355);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(308, 65);
            resetButton.TabIndex = 71;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += resetButton_Click;
            // 
            // txtSearchLogin
            // 
            txtSearchLogin.BackColor = SystemColors.Desktop;
            txtSearchLogin.Font = new Font("Segoe UI Symbol", 12F);
            txtSearchLogin.ForeColor = Color.White;
            txtSearchLogin.Location = new Point(1248, 428);
            txtSearchLogin.MaxLength = 100;
            txtSearchLogin.Name = "txtSearchLogin";
            txtSearchLogin.PlaceholderText = "(Searching...)";
            txtSearchLogin.Size = new Size(602, 39);
            txtSearchLogin.TabIndex = 72;
            txtSearchLogin.TextAlign = HorizontalAlignment.Center;
            txtSearchLogin.TextChanged += txtSearchLogin_TextChanged;
            // 
            // accountFileHandler
            // 
            accountFileHandler.BackColor = SystemColors.Desktop;
            accountFileHandler.Font = new Font("Segoe UI Symbol", 12F);
            accountFileHandler.ForeColor = Color.White;
            accountFileHandler.Location = new Point(1542, 199);
            accountFileHandler.Name = "accountFileHandler";
            accountFileHandler.Size = new Size(308, 67);
            accountFileHandler.TabIndex = 73;
            accountFileHandler.Text = "Account File Handler";
            accountFileHandler.UseVisualStyleBackColor = false;
            accountFileHandler.Click += accountFileHandler_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Transparent;
            panel9.BorderStyle = BorderStyle.Fixed3D;
            panel9.ForeColor = SystemColors.ActiveCaptionText;
            panel9.Location = new Point(1248, 279);
            panel9.Name = "panel9";
            panel9.Size = new Size(602, 14);
            panel9.TabIndex = 43;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Symbol", 12F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(1248, 308);
            label15.Name = "label15";
            label15.Size = new Size(304, 32);
            label15.TabIndex = 74;
            label15.Text = "Exist Apps List - Auto Login";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1884, 998);
            Controls.Add(label15);
            Controls.Add(panel9);
            Controls.Add(accountFileHandler);
            Controls.Add(txtSearchLogin);
            Controls.Add(resetButton);
            Controls.Add(refreshButton);
            Controls.Add(flowLayoutPanel);
            Controls.Add(label14);
            Controls.Add(testLogin);
            Controls.Add(panel8);
            Controls.Add(runLogin);
            Controls.Add(panel7);
            Controls.Add(browseAccount);
            Controls.Add(FilePathNameLogin);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label9);
            Controls.Add(panel6);
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
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Process Forge - Kingdom Heroes 2 Edition";
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
        private Panel panel6;
        private Label label9;
        private Button browseAccount;
        private TextBox FilePathNameLogin;
        private Label label12;
        private Label label13;
        private Panel panel7;
        private Button runLogin;
        private Panel panel8;
        private Label label14;
        private Button testLogin;
        private FlowLayoutPanel flowLayoutPanel;
        private TextBox txtSearchLogin;
        private Button accountFileHandler;
        private Panel panel9;
        private Label label15;
        private Button refreshButton;
        private Button resetButton;
    }
}
