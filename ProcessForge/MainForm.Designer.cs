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
            pnlHeader = new Panel();
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            settingForm = new Button();
            pnlProcessToolbar = new Panel();
            label11 = new Label();
            ProcessName = new TextBox();
            gbMemoryManagement = new GroupBox();
            label1 = new Label();
            ClearRAM = new Button();
            gbTimedMemory = new GroupBox();
            label2 = new Label();
            TimeSetForClearRAM = new NumericUpDown();
            ValidatingEvent = new Button();
            pnlTimedStatus = new Panel();
            MSTimeSetLabel = new Label();
            CountDownSeconds = new Label();
            lblStatusText = new Label();
            panel2 = new Panel();
            Run1 = new Button();
            gbHandlers = new GroupBox();
            label7 = new Label();
            lblBulkSub = new Label();
            OpenBulkWindow = new Button();
            TextWinHandler = new Label();
            lblImportSub = new Label();
            OpenWindowImportThing = new Button();
            gbBulkApp = new GroupBox();
            label5 = new Label();
            label6 = new Label();
            FilePathName = new TextBox();
            BrowseFile = new Button();
            label8 = new Label();
            ComboBox = new ComboBox();
            pnlRenameOptions = new Panel();
            RenameLabel = new Label();
            RunTotalLabel = new Label();
            RenameTextbox = new TextBox();
            numericUpDown1 = new NumericUpDown();
            DelimiterToLabel = new Label();
            numericUpDown2 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            MaxLabel = new Label();
            NotepadPathTextbox = new TextBox();
            BrowseFileNotepad = new Button();
            DelayLabel = new Label();
            pnlDelaySettings = new Panel();
            DelayInformation = new Label();
            numericUpDown3 = new NumericUpDown();
            label3 = new Label();
            DelayInformation1 = new Label();
            numericUpDown4 = new NumericUpDown();
            label4 = new Label();
            CPUChecker = new Button();
            pnlValidationRow = new Panel();
            TestButton = new Button();
            label10 = new Label();
            panel3 = new Panel();
            Run2 = new Button();
            Terminate = new Button();
            gbAutoLogin = new GroupBox();
            label9 = new Label();
            label13 = new Label();
            label12 = new Label();
            FilePathNameLogin = new TextBox();
            browseAccount = new Button();
            accountFileHandler = new Button();
            pnlLoginListToolbar = new Panel();
            label15 = new Label();
            refreshButton = new Button();
            resetButton = new Button();
            lblSearchPrompt = new Label();
            txtSearchLogin = new TextBox();
            btnSearchLogin = new Button();
            btnClearSearchLogin = new Button();
            pnlLoginColumnHeaders = new Panel();
            lblColTitle = new Label();
            lblColStatus = new Label();
            lblColAction = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            pnlLoginBottom = new Panel();
            testLogin = new Button();
            lblAutoLoginMode = new Label();
            cmbAutoLoginMode = new ComboBox();
            label14 = new Label();
            panel8 = new Panel();
            runLogin = new Button();
            panel1 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel9 = new Panel();
            CountDownTimer = new System.Windows.Forms.Timer(components);
            TimerForSeconds = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            pnlProcessToolbar.SuspendLayout();
            gbMemoryManagement.SuspendLayout();
            gbTimedMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TimeSetForClearRAM).BeginInit();
            pnlTimedStatus.SuspendLayout();
            gbHandlers.SuspendLayout();
            gbBulkApp.SuspendLayout();
            pnlRenameOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            pnlDelaySettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            pnlValidationRow.SuspendLayout();
            gbAutoLogin.SuspendLayout();
            pnlLoginListToolbar.SuspendLayout();
            pnlLoginColumnHeaders.SuspendLayout();
            pnlLoginBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Black;
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(settingForm);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1900, 65);
            pnlHeader.TabIndex = 100;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 10);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(247, 21);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "PROCESS FORGE - KH2 EDITION";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 8.25F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(200, 200, 200);
            lblHeaderSubtitle.Location = new Point(21, 38);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(370, 13);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Multi-Instance Automation, Memory Optimzer,, and Auto-Login System";
            // 
            // settingForm
            // 
            settingForm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            settingForm.BackColor = Color.White;
            settingForm.Cursor = Cursors.Hand;
            settingForm.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            settingForm.FlatStyle = FlatStyle.Flat;
            settingForm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            settingForm.ForeColor = Color.Black;
            settingForm.Location = new Point(1746, 14);
            settingForm.Name = "settingForm";
            settingForm.Size = new Size(130, 36);
            settingForm.TabIndex = 1;
            settingForm.Text = "⚙ Settings";
            settingForm.UseVisualStyleBackColor = false;
            settingForm.Click += settingForm_Click;
            // 
            // pnlProcessToolbar
            // 
            pnlProcessToolbar.BackColor = Color.WhiteSmoke;
            pnlProcessToolbar.Controls.Add(label11);
            pnlProcessToolbar.Controls.Add(ProcessName);
            pnlProcessToolbar.Dock = DockStyle.Top;
            pnlProcessToolbar.Location = new Point(0, 65);
            pnlProcessToolbar.Name = "pnlProcessToolbar";
            pnlProcessToolbar.Size = new Size(1900, 55);
            pnlProcessToolbar.TabIndex = 101;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(20, 16);
            label11.Name = "label11";
            label11.Size = new Size(141, 17);
            label11.TabIndex = 0;
            label11.Text = "Target Process Name:";
            // 
            // ProcessName
            // 
            ProcessName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ProcessName.BackColor = Color.White;
            ProcessName.BorderStyle = BorderStyle.FixedSingle;
            ProcessName.Font = new Font("Segoe UI", 10.5F);
            ProcessName.ForeColor = Color.Black;
            ProcessName.Location = new Point(200, 12);
            ProcessName.MaxLength = 100;
            ProcessName.Name = "ProcessName";
            ProcessName.PlaceholderText = "(e.g., kh2, chrome, notepad)";
            ProcessName.Size = new Size(1676, 26);
            ProcessName.TabIndex = 0;
            ProcessName.Text = "kh2";
            // 
            // gbMemoryManagement
            // 
            gbMemoryManagement.BackColor = Color.White;
            gbMemoryManagement.Controls.Add(label1);
            gbMemoryManagement.Controls.Add(ClearRAM);
            gbMemoryManagement.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            gbMemoryManagement.ForeColor = Color.Black;
            gbMemoryManagement.Location = new Point(20, 130);
            gbMemoryManagement.Name = "gbMemoryManagement";
            gbMemoryManagement.Size = new Size(430, 150);
            gbMemoryManagement.TabIndex = 2;
            gbMemoryManagement.TabStop = false;
            gbMemoryManagement.Text = "CLEAR UNUSED MEMORY";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 8.5F);
            label1.ForeColor = Color.FromArgb(90, 90, 90);
            label1.Location = new Point(18, 30);
            label1.Name = "label1";
            label1.Size = new Size(394, 38);
            label1.TabIndex = 0;
            label1.Text = "Empty the working set of the target process to free unused system RAM immediately.";
            // 
            // ClearRAM
            // 
            ClearRAM.BackColor = Color.Black;
            ClearRAM.Cursor = Cursors.Hand;
            ClearRAM.FlatAppearance.BorderColor = Color.Black;
            ClearRAM.FlatStyle = FlatStyle.Flat;
            ClearRAM.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ClearRAM.ForeColor = Color.White;
            ClearRAM.Location = new Point(18, 75);
            ClearRAM.Name = "ClearRAM";
            ClearRAM.Size = new Size(394, 55);
            ClearRAM.TabIndex = 2;
            ClearRAM.Text = "CLEAR RAM NOW";
            ClearRAM.UseVisualStyleBackColor = false;
            ClearRAM.Click += ClearRAM_Click;
            // 
            // gbTimedMemory
            // 
            gbTimedMemory.BackColor = Color.White;
            gbTimedMemory.Controls.Add(label2);
            gbTimedMemory.Controls.Add(TimeSetForClearRAM);
            gbTimedMemory.Controls.Add(ValidatingEvent);
            gbTimedMemory.Controls.Add(pnlTimedStatus);
            gbTimedMemory.Controls.Add(Run1);
            gbTimedMemory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            gbTimedMemory.ForeColor = Color.Black;
            gbTimedMemory.Location = new Point(20, 292);
            gbTimedMemory.Name = "gbTimedMemory";
            gbTimedMemory.Size = new Size(430, 345);
            gbTimedMemory.TabIndex = 3;
            gbTimedMemory.TabStop = false;
            gbTimedMemory.Text = "TIMED MEMORY CLEANER (LOOP)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.5F);
            label2.ForeColor = Color.FromArgb(70, 70, 70);
            label2.Location = new Point(18, 28);
            label2.Name = "label2";
            label2.Size = new Size(169, 15);
            label2.TabIndex = 0;
            label2.Text = "Loop Interval (in milliseconds):";
            // 
            // TimeSetForClearRAM
            // 
            TimeSetForClearRAM.BackColor = Color.White;
            TimeSetForClearRAM.BorderStyle = BorderStyle.FixedSingle;
            TimeSetForClearRAM.Font = new Font("Segoe UI", 10F);
            TimeSetForClearRAM.ForeColor = Color.Black;
            TimeSetForClearRAM.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            TimeSetForClearRAM.Location = new Point(18, 52);
            TimeSetForClearRAM.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            TimeSetForClearRAM.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            TimeSetForClearRAM.Name = "TimeSetForClearRAM";
            TimeSetForClearRAM.Size = new Size(225, 25);
            TimeSetForClearRAM.TabIndex = 3;
            TimeSetForClearRAM.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // ValidatingEvent
            // 
            ValidatingEvent.BackColor = Color.White;
            ValidatingEvent.Cursor = Cursors.Hand;
            ValidatingEvent.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            ValidatingEvent.FlatStyle = FlatStyle.Flat;
            ValidatingEvent.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            ValidatingEvent.ForeColor = Color.Black;
            ValidatingEvent.Location = new Point(255, 51);
            ValidatingEvent.Name = "ValidatingEvent";
            ValidatingEvent.Size = new Size(157, 32);
            ValidatingEvent.TabIndex = 4;
            ValidatingEvent.Text = "Validate";
            ValidatingEvent.UseVisualStyleBackColor = false;
            ValidatingEvent.Click += ValidatingEvent_Click;
            // 
            // pnlTimedStatus
            // 
            pnlTimedStatus.BackColor = Color.WhiteSmoke;
            pnlTimedStatus.BorderStyle = BorderStyle.FixedSingle;
            pnlTimedStatus.Controls.Add(MSTimeSetLabel);
            pnlTimedStatus.Controls.Add(CountDownSeconds);
            pnlTimedStatus.Controls.Add(lblStatusText);
            pnlTimedStatus.Controls.Add(panel2);
            pnlTimedStatus.Location = new Point(18, 95);
            pnlTimedStatus.Name = "pnlTimedStatus";
            pnlTimedStatus.Size = new Size(394, 150);
            pnlTimedStatus.TabIndex = 10;
            // 
            // MSTimeSetLabel
            // 
            MSTimeSetLabel.AutoSize = true;
            MSTimeSetLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            MSTimeSetLabel.ForeColor = Color.Black;
            MSTimeSetLabel.Location = new Point(16, 16);
            MSTimeSetLabel.Name = "MSTimeSetLabel";
            MSTimeSetLabel.Size = new Size(105, 15);
            MSTimeSetLabel.TabIndex = 0;
            MSTimeSetLabel.Text = "(MS) No Time Set";
            // 
            // CountDownSeconds
            // 
            CountDownSeconds.AutoSize = true;
            CountDownSeconds.Font = new Font("Segoe UI", 8.5F);
            CountDownSeconds.ForeColor = Color.FromArgb(50, 50, 50);
            CountDownSeconds.Location = new Point(16, 50);
            CountDownSeconds.Name = "CountDownSeconds";
            CountDownSeconds.Size = new Size(158, 15);
            CountDownSeconds.TabIndex = 1;
            CountDownSeconds.Text = "Count down event : Stopped";
            // 
            // lblStatusText
            // 
            lblStatusText.AutoSize = true;
            lblStatusText.Font = new Font("Segoe UI", 8.5F);
            lblStatusText.ForeColor = Color.FromArgb(70, 70, 70);
            lblStatusText.Location = new Point(16, 105);
            lblStatusText.Name = "lblStatusText";
            lblStatusText.Size = new Size(85, 15);
            lblStatusText.TabIndex = 2;
            lblStatusText.Text = "Cleaner Status:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(130, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(22, 22);
            panel2.TabIndex = 3;
            // 
            // Run1
            // 
            Run1.BackColor = Color.Black;
            Run1.Cursor = Cursors.Hand;
            Run1.FlatAppearance.BorderColor = Color.Black;
            Run1.FlatStyle = FlatStyle.Flat;
            Run1.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            Run1.ForeColor = Color.White;
            Run1.Location = new Point(18, 260);
            Run1.Name = "Run1";
            Run1.Size = new Size(394, 65);
            Run1.TabIndex = 5;
            Run1.Text = "Run";
            Run1.UseVisualStyleBackColor = false;
            Run1.Click += Run1_Click;
            // 
            // gbHandlers
            // 
            gbHandlers.BackColor = Color.White;
            gbHandlers.Controls.Add(label7);
            gbHandlers.Controls.Add(lblBulkSub);
            gbHandlers.Controls.Add(OpenBulkWindow);
            gbHandlers.Controls.Add(TextWinHandler);
            gbHandlers.Controls.Add(lblImportSub);
            gbHandlers.Controls.Add(OpenWindowImportThing);
            gbHandlers.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            gbHandlers.ForeColor = Color.Black;
            gbHandlers.Location = new Point(20, 648);
            gbHandlers.Name = "gbHandlers";
            gbHandlers.Size = new Size(430, 240);
            gbHandlers.TabIndex = 6;
            gbHandlers.TabStop = false;
            gbHandlers.Text = "EXTERNAL TOOLS && HANDLERS";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(18, 28);
            label7.Name = "label7";
            label7.Size = new Size(104, 15);
            label7.TabIndex = 0;
            label7.Text = "Bulk App Handler";
            // 
            // lblBulkSub
            // 
            lblBulkSub.AutoSize = true;
            lblBulkSub.Font = new Font("Segoe UI", 8F);
            lblBulkSub.ForeColor = Color.FromArgb(100, 100, 100);
            lblBulkSub.Location = new Point(18, 50);
            lblBulkSub.Name = "lblBulkSub";
            lblBulkSub.Size = new Size(257, 13);
            lblBulkSub.TabIndex = 1;
            lblBulkSub.Text = "Manage multi-client instances and window titles";
            // 
            // OpenBulkWindow
            // 
            OpenBulkWindow.BackColor = Color.White;
            OpenBulkWindow.Cursor = Cursors.Hand;
            OpenBulkWindow.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            OpenBulkWindow.FlatStyle = FlatStyle.Flat;
            OpenBulkWindow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            OpenBulkWindow.ForeColor = Color.Black;
            OpenBulkWindow.Location = new Point(18, 73);
            OpenBulkWindow.Name = "OpenBulkWindow";
            OpenBulkWindow.Size = new Size(394, 40);
            OpenBulkWindow.TabIndex = 6;
            OpenBulkWindow.Text = "Open Bulk App Handler";
            OpenBulkWindow.UseVisualStyleBackColor = false;
            OpenBulkWindow.Click += OpenBulkWindow_Click;
            // 
            // TextWinHandler
            // 
            TextWinHandler.AutoSize = true;
            TextWinHandler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            TextWinHandler.ForeColor = Color.Black;
            TextWinHandler.Location = new Point(18, 128);
            TextWinHandler.Name = "TextWinHandler";
            TextWinHandler.Size = new Size(121, 15);
            TextWinHandler.TabIndex = 3;
            TextWinHandler.Text = "Text Import Handler";
            // 
            // lblImportSub
            // 
            lblImportSub.AutoSize = true;
            lblImportSub.Font = new Font("Segoe UI", 8F);
            lblImportSub.ForeColor = Color.FromArgb(100, 100, 100);
            lblImportSub.Location = new Point(18, 150);
            lblImportSub.Name = "lblImportSub";
            lblImportSub.Size = new Size(255, 13);
            lblImportSub.TabIndex = 4;
            lblImportSub.Text = "Configure imported application titles and status";
            // 
            // OpenWindowImportThing
            // 
            OpenWindowImportThing.BackColor = Color.White;
            OpenWindowImportThing.Cursor = Cursors.Hand;
            OpenWindowImportThing.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            OpenWindowImportThing.FlatStyle = FlatStyle.Flat;
            OpenWindowImportThing.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            OpenWindowImportThing.ForeColor = Color.Black;
            OpenWindowImportThing.Location = new Point(18, 173);
            OpenWindowImportThing.Name = "OpenWindowImportThing";
            OpenWindowImportThing.Size = new Size(394, 40);
            OpenWindowImportThing.TabIndex = 7;
            OpenWindowImportThing.Text = "Open Text Import Handler";
            OpenWindowImportThing.UseVisualStyleBackColor = false;
            OpenWindowImportThing.Click += OpenWindowImportThing_Click;
            // 
            // gbBulkApp
            // 
            gbBulkApp.BackColor = Color.White;
            gbBulkApp.Controls.Add(label5);
            gbBulkApp.Controls.Add(label6);
            gbBulkApp.Controls.Add(FilePathName);
            gbBulkApp.Controls.Add(BrowseFile);
            gbBulkApp.Controls.Add(label8);
            gbBulkApp.Controls.Add(ComboBox);
            gbBulkApp.Controls.Add(pnlRenameOptions);
            gbBulkApp.Controls.Add(DelayLabel);
            gbBulkApp.Controls.Add(pnlDelaySettings);
            gbBulkApp.Controls.Add(pnlValidationRow);
            gbBulkApp.Controls.Add(Run2);
            gbBulkApp.Controls.Add(Terminate);
            gbBulkApp.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            gbBulkApp.ForeColor = Color.Black;
            gbBulkApp.Location = new Point(475, 130);
            gbBulkApp.Name = "gbBulkApp";
            gbBulkApp.Size = new Size(665, 758);
            gbBulkApp.TabIndex = 8;
            gbBulkApp.TabStop = false;
            gbBulkApp.Text = "RUN BULK APPLICATION";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.25F);
            label5.ForeColor = Color.FromArgb(90, 90, 90);
            label5.Location = new Point(20, 28);
            label5.Name = "label5";
            label5.Size = new Size(367, 13);
            label5.TabIndex = 0;
            label5.Text = "Configure multi-instance launch settings, renaming rules, and pacing.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(20, 56);
            label6.Name = "label6";
            label6.Size = new Size(156, 15);
            label6.TabIndex = 1;
            label6.Text = "Executable File Path (.exe):";
            // 
            // FilePathName
            // 
            FilePathName.BackColor = Color.White;
            FilePathName.BorderStyle = BorderStyle.FixedSingle;
            FilePathName.Font = new Font("Segoe UI", 9.5F);
            FilePathName.ForeColor = Color.Black;
            FilePathName.Location = new Point(20, 80);
            FilePathName.Name = "FilePathName";
            FilePathName.PlaceholderText = "(Path to game or application executable...)";
            FilePathName.Size = new Size(485, 24);
            FilePathName.TabIndex = 8;
            // 
            // BrowseFile
            // 
            BrowseFile.BackColor = Color.White;
            BrowseFile.Cursor = Cursors.Hand;
            BrowseFile.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            BrowseFile.FlatStyle = FlatStyle.Flat;
            BrowseFile.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            BrowseFile.ForeColor = Color.Black;
            BrowseFile.Location = new Point(515, 78);
            BrowseFile.Name = "BrowseFile";
            BrowseFile.Size = new Size(130, 33);
            BrowseFile.TabIndex = 9;
            BrowseFile.Text = "Browse...";
            BrowseFile.UseVisualStyleBackColor = false;
            BrowseFile.Click += BrowseFile_Click_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(20, 125);
            label8.Name = "label8";
            label8.Size = new Size(194, 15);
            label8.TabIndex = 4;
            label8.Text = "Application Title Renaming Mode:";
            // 
            // ComboBox
            // 
            ComboBox.BackColor = Color.White;
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.Font = new Font("Segoe UI", 9.5F);
            ComboBox.ForeColor = Color.Black;
            ComboBox.FormattingEnabled = true;
            ComboBox.Items.AddRange(new object[] { "None...", "Rename Title Manually (Advanced)", "Rename Title To Integer Increment (Advanced)", "Rename Title Using Notepad Import (Advanced)" });
            ComboBox.Location = new Point(20, 150);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(625, 25);
            ComboBox.TabIndex = 10;
            ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // pnlRenameOptions
            // 
            pnlRenameOptions.BackColor = Color.WhiteSmoke;
            pnlRenameOptions.BorderStyle = BorderStyle.FixedSingle;
            pnlRenameOptions.Controls.Add(RenameLabel);
            pnlRenameOptions.Controls.Add(RunTotalLabel);
            pnlRenameOptions.Controls.Add(RenameTextbox);
            pnlRenameOptions.Controls.Add(numericUpDown1);
            pnlRenameOptions.Controls.Add(DelimiterToLabel);
            pnlRenameOptions.Controls.Add(numericUpDown2);
            pnlRenameOptions.Controls.Add(numericUpDown5);
            pnlRenameOptions.Controls.Add(MaxLabel);
            pnlRenameOptions.Controls.Add(NotepadPathTextbox);
            pnlRenameOptions.Controls.Add(BrowseFileNotepad);
            pnlRenameOptions.Location = new Point(20, 192);
            pnlRenameOptions.Name = "pnlRenameOptions";
            pnlRenameOptions.Size = new Size(625, 130);
            pnlRenameOptions.TabIndex = 11;
            // 
            // RenameLabel
            // 
            RenameLabel.AutoSize = true;
            RenameLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            RenameLabel.ForeColor = Color.Black;
            RenameLabel.Location = new Point(16, 12);
            RenameLabel.Name = "RenameLabel";
            RenameLabel.Size = new Size(154, 15);
            RenameLabel.TabIndex = 0;
            RenameLabel.Text = "Rename Application Name";
            // 
            // RunTotalLabel
            // 
            RunTotalLabel.AutoSize = true;
            RunTotalLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            RunTotalLabel.ForeColor = Color.Black;
            RunTotalLabel.Location = new Point(440, 12);
            RunTotalLabel.Name = "RunTotalLabel";
            RunTotalLabel.Size = new Size(59, 15);
            RunTotalLabel.TabIndex = 1;
            RunTotalLabel.Text = "Run Total";
            // 
            // RenameTextbox
            // 
            RenameTextbox.BackColor = Color.White;
            RenameTextbox.BorderStyle = BorderStyle.FixedSingle;
            RenameTextbox.Font = new Font("Segoe UI", 9.5F);
            RenameTextbox.ForeColor = Color.Black;
            RenameTextbox.Location = new Point(16, 36);
            RenameTextbox.Name = "RenameTextbox";
            RenameTextbox.Size = new Size(405, 24);
            RenameTextbox.TabIndex = 11;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.White;
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown1.Font = new Font("Segoe UI", 9.5F);
            numericUpDown1.ForeColor = Color.Black;
            numericUpDown1.Location = new Point(16, 36);
            numericUpDown1.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(85, 24);
            numericUpDown1.TabIndex = 12;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DelimiterToLabel
            // 
            DelimiterToLabel.AutoSize = true;
            DelimiterToLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DelimiterToLabel.ForeColor = Color.Black;
            DelimiterToLabel.Location = new Point(108, 40);
            DelimiterToLabel.Name = "DelimiterToLabel";
            DelimiterToLabel.Size = new Size(20, 15);
            DelimiterToLabel.TabIndex = 4;
            DelimiterToLabel.Text = "To";
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.White;
            numericUpDown2.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown2.Font = new Font("Segoe UI", 9.5F);
            numericUpDown2.ForeColor = Color.Black;
            numericUpDown2.Location = new Point(138, 36);
            numericUpDown2.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(85, 24);
            numericUpDown2.TabIndex = 13;
            numericUpDown2.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // numericUpDown5
            // 
            numericUpDown5.BackColor = Color.White;
            numericUpDown5.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown5.Font = new Font("Segoe UI", 9.5F);
            numericUpDown5.ForeColor = Color.Black;
            numericUpDown5.Location = new Point(440, 36);
            numericUpDown5.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown5.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(90, 24);
            numericUpDown5.TabIndex = 14;
            numericUpDown5.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MaxLabel
            // 
            MaxLabel.AutoSize = true;
            MaxLabel.Font = new Font("Segoe UI", 8F);
            MaxLabel.ForeColor = Color.FromArgb(100, 100, 100);
            MaxLabel.Location = new Point(538, 40);
            MaxLabel.Name = "MaxLabel";
            MaxLabel.Size = new Size(60, 13);
            MaxLabel.TabIndex = 7;
            MaxLabel.Text = "Max (999x)";
            // 
            // NotepadPathTextbox
            // 
            NotepadPathTextbox.BackColor = Color.White;
            NotepadPathTextbox.BorderStyle = BorderStyle.FixedSingle;
            NotepadPathTextbox.Font = new Font("Segoe UI", 9.5F);
            NotepadPathTextbox.ForeColor = Color.Black;
            NotepadPathTextbox.Location = new Point(16, 36);
            NotepadPathTextbox.Name = "NotepadPathTextbox";
            NotepadPathTextbox.PlaceholderText = "(Path to titles text file...)";
            NotepadPathTextbox.Size = new Size(590, 24);
            NotepadPathTextbox.TabIndex = 15;
            // 
            // BrowseFileNotepad
            // 
            BrowseFileNotepad.BackColor = Color.White;
            BrowseFileNotepad.Cursor = Cursors.Hand;
            BrowseFileNotepad.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            BrowseFileNotepad.FlatStyle = FlatStyle.Flat;
            BrowseFileNotepad.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            BrowseFileNotepad.ForeColor = Color.Black;
            BrowseFileNotepad.Location = new Point(16, 75);
            BrowseFileNotepad.Name = "BrowseFileNotepad";
            BrowseFileNotepad.Size = new Size(590, 38);
            BrowseFileNotepad.TabIndex = 16;
            BrowseFileNotepad.Text = "Browse Text File Location...";
            BrowseFileNotepad.UseVisualStyleBackColor = false;
            BrowseFileNotepad.Click += BrowseFileNotepad_Click;
            // 
            // DelayLabel
            // 
            DelayLabel.AutoSize = true;
            DelayLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            DelayLabel.ForeColor = Color.Black;
            DelayLabel.Location = new Point(20, 338);
            DelayLabel.Name = "DelayLabel";
            DelayLabel.Size = new Size(174, 15);
            DelayLabel.TabIndex = 8;
            DelayLabel.Text = "Batch Delay && CPU Throttling:";
            // 
            // pnlDelaySettings
            // 
            pnlDelaySettings.BackColor = Color.WhiteSmoke;
            pnlDelaySettings.BorderStyle = BorderStyle.FixedSingle;
            pnlDelaySettings.Controls.Add(DelayInformation);
            pnlDelaySettings.Controls.Add(numericUpDown3);
            pnlDelaySettings.Controls.Add(label3);
            pnlDelaySettings.Controls.Add(DelayInformation1);
            pnlDelaySettings.Controls.Add(numericUpDown4);
            pnlDelaySettings.Controls.Add(label4);
            pnlDelaySettings.Controls.Add(CPUChecker);
            pnlDelaySettings.Location = new Point(20, 362);
            pnlDelaySettings.Name = "pnlDelaySettings";
            pnlDelaySettings.Size = new Size(625, 140);
            pnlDelaySettings.TabIndex = 17;
            // 
            // DelayInformation
            // 
            DelayInformation.AutoSize = true;
            DelayInformation.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            DelayInformation.ForeColor = Color.Black;
            DelayInformation.Location = new Point(16, 14);
            DelayInformation.Name = "DelayInformation";
            DelayInformation.Size = new Size(119, 15);
            DelayInformation.TabIndex = 0;
            DelayInformation.Text = "Instances Per Batch:";
            // 
            // numericUpDown3
            // 
            numericUpDown3.BackColor = Color.White;
            numericUpDown3.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown3.Font = new Font("Segoe UI", 9.5F);
            numericUpDown3.ForeColor = Color.Black;
            numericUpDown3.Location = new Point(16, 38);
            numericUpDown3.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 24);
            numericUpDown3.TabIndex = 17;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(145, 36);
            label3.Name = "label3";
            label3.Size = new Size(17, 21);
            label3.TabIndex = 2;
            label3.Text = "/";
            // 
            // DelayInformation1
            // 
            DelayInformation1.AutoSize = true;
            DelayInformation1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            DelayInformation1.ForeColor = Color.Black;
            DelayInformation1.Location = new Point(175, 14);
            DelayInformation1.Name = "DelayInformation1";
            DelayInformation1.Size = new Size(220, 15);
            DelayInformation1.TabIndex = 3;
            DelayInformation1.Text = "Delay Between Batches (Milliseconds):";
            // 
            // numericUpDown4
            // 
            numericUpDown4.BackColor = Color.White;
            numericUpDown4.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown4.Font = new Font("Segoe UI", 9.5F);
            numericUpDown4.ForeColor = Color.Black;
            numericUpDown4.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown4.Location = new Point(175, 38);
            numericUpDown4.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(430, 24);
            numericUpDown4.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(16, 92);
            label4.Name = "label4";
            label4.Size = new Size(212, 15);
            label4.TabIndex = 5;
            label4.Text = "Pause Execution if CPU Usage > 80%:";
            // 
            // CPUChecker
            // 
            CPUChecker.BackColor = Color.Red;
            CPUChecker.Cursor = Cursors.Hand;
            CPUChecker.FlatAppearance.BorderSize = 0;
            CPUChecker.FlatStyle = FlatStyle.Flat;
            CPUChecker.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CPUChecker.ForeColor = Color.White;
            CPUChecker.Location = new Point(320, 86);
            CPUChecker.Name = "CPUChecker";
            CPUChecker.Size = new Size(95, 34);
            CPUChecker.TabIndex = 19;
            CPUChecker.Text = "Off";
            CPUChecker.UseVisualStyleBackColor = false;
            CPUChecker.Click += CPUChecker_Click;
            // 
            // pnlValidationRow
            // 
            pnlValidationRow.BackColor = Color.WhiteSmoke;
            pnlValidationRow.BorderStyle = BorderStyle.FixedSingle;
            pnlValidationRow.Controls.Add(TestButton);
            pnlValidationRow.Controls.Add(label10);
            pnlValidationRow.Controls.Add(panel3);
            pnlValidationRow.Location = new Point(20, 520);
            pnlValidationRow.Name = "pnlValidationRow";
            pnlValidationRow.Size = new Size(625, 58);
            pnlValidationRow.TabIndex = 20;
            // 
            // TestButton
            // 
            TestButton.BackColor = Color.White;
            TestButton.Cursor = Cursors.Hand;
            TestButton.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            TestButton.FlatStyle = FlatStyle.Flat;
            TestButton.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            TestButton.ForeColor = Color.Black;
            TestButton.Location = new Point(16, 11);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(115, 34);
            TestButton.TabIndex = 20;
            TestButton.Text = "Test Setup";
            TestButton.UseVisualStyleBackColor = false;
            TestButton.Click += TestButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8.5F);
            label10.ForeColor = Color.FromArgb(70, 70, 70);
            label10.Location = new Point(142, 18);
            label10.Name = "label10";
            label10.Size = new Size(125, 15);
            label10.TabIndex = 1;
            label10.Text = "Click \"Test\" to validate";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(580, 16);
            panel3.Name = "panel3";
            panel3.Size = new Size(24, 24);
            panel3.TabIndex = 2;
            // 
            // Run2
            // 
            Run2.BackColor = Color.Black;
            Run2.Cursor = Cursors.Hand;
            Run2.FlatAppearance.BorderColor = Color.Black;
            Run2.FlatStyle = FlatStyle.Flat;
            Run2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            Run2.ForeColor = Color.White;
            Run2.Location = new Point(20, 600);
            Run2.Name = "Run2";
            Run2.Size = new Size(300, 65);
            Run2.TabIndex = 21;
            Run2.Text = "Run";
            Run2.UseVisualStyleBackColor = false;
            Run2.Click += Run2_Click;
            // 
            // Terminate
            // 
            Terminate.BackColor = Color.FromArgb(170, 30, 30);
            Terminate.Cursor = Cursors.Hand;
            Terminate.FlatAppearance.BorderColor = Color.FromArgb(170, 30, 30);
            Terminate.FlatStyle = FlatStyle.Flat;
            Terminate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            Terminate.ForeColor = Color.White;
            Terminate.Location = new Point(345, 600);
            Terminate.Name = "Terminate";
            Terminate.Size = new Size(300, 65);
            Terminate.TabIndex = 22;
            Terminate.Text = "Terminate";
            Terminate.UseVisualStyleBackColor = false;
            Terminate.Click += Terminate_Click;
            // 
            // gbAutoLogin
            // 
            gbAutoLogin.BackColor = Color.White;
            gbAutoLogin.Controls.Add(label9);
            gbAutoLogin.Controls.Add(label13);
            gbAutoLogin.Controls.Add(label12);
            gbAutoLogin.Controls.Add(FilePathNameLogin);
            gbAutoLogin.Controls.Add(browseAccount);
            gbAutoLogin.Controls.Add(accountFileHandler);
            gbAutoLogin.Controls.Add(pnlLoginListToolbar);
            gbAutoLogin.Controls.Add(pnlLoginColumnHeaders);
            gbAutoLogin.Controls.Add(flowLayoutPanel);
            gbAutoLogin.Controls.Add(pnlLoginBottom);
            gbAutoLogin.Controls.Add(runLogin);
            gbAutoLogin.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            gbAutoLogin.ForeColor = Color.Black;
            gbAutoLogin.Location = new Point(1165, 130);
            gbAutoLogin.Name = "gbAutoLogin";
            gbAutoLogin.Size = new Size(695, 758);
            gbAutoLogin.TabIndex = 23;
            gbAutoLogin.TabStop = false;
            gbAutoLogin.Text = "AUTO LOGIN AUTOMATION";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(20, 26);
            label9.Name = "label9";
            label9.Size = new Size(67, 15);
            label9.TabIndex = 0;
            label9.Text = "Auto Login";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 8.25F);
            label13.ForeColor = Color.FromArgb(90, 90, 90);
            label13.Location = new Point(20, 48);
            label13.Name = "label13";
            label13.Size = new Size(156, 13);
            label13.TabIndex = 1;
            label13.Text = "Auto-Login For All Exist Apps";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(20, 75);
            label12.Name = "label12";
            label12.Size = new Size(135, 15);
            label12.TabIndex = 2;
            label12.Text = "Account Data File Path:";
            // 
            // FilePathNameLogin
            // 
            FilePathNameLogin.BackColor = Color.White;
            FilePathNameLogin.BorderStyle = BorderStyle.FixedSingle;
            FilePathNameLogin.Font = new Font("Segoe UI", 9.5F);
            FilePathNameLogin.ForeColor = Color.Black;
            FilePathNameLogin.Location = new Point(20, 98);
            FilePathNameLogin.Name = "FilePathNameLogin";
            FilePathNameLogin.PlaceholderText = "(Your Account Data File...)";
            FilePathNameLogin.Size = new Size(385, 24);
            FilePathNameLogin.TabIndex = 23;
            // 
            // browseAccount
            // 
            browseAccount.BackColor = Color.White;
            browseAccount.Cursor = Cursors.Hand;
            browseAccount.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            browseAccount.FlatStyle = FlatStyle.Flat;
            browseAccount.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            browseAccount.ForeColor = Color.Black;
            browseAccount.Location = new Point(415, 96);
            browseAccount.Name = "browseAccount";
            browseAccount.Size = new Size(120, 33);
            browseAccount.TabIndex = 24;
            browseAccount.Text = "Browse...";
            browseAccount.UseVisualStyleBackColor = false;
            browseAccount.Click += browseAccount_Click;
            // 
            // accountFileHandler
            // 
            accountFileHandler.BackColor = Color.White;
            accountFileHandler.Cursor = Cursors.Hand;
            accountFileHandler.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            accountFileHandler.FlatStyle = FlatStyle.Flat;
            accountFileHandler.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            accountFileHandler.ForeColor = Color.Black;
            accountFileHandler.Location = new Point(545, 96);
            accountFileHandler.Name = "accountFileHandler";
            accountFileHandler.Size = new Size(130, 33);
            accountFileHandler.TabIndex = 25;
            accountFileHandler.Text = "Accounts Window";
            accountFileHandler.UseVisualStyleBackColor = false;
            accountFileHandler.Click += accountFileHandler_Click;
            // 
            // pnlLoginListToolbar
            // 
            pnlLoginListToolbar.BackColor = Color.WhiteSmoke;
            pnlLoginListToolbar.BorderStyle = BorderStyle.FixedSingle;
            pnlLoginListToolbar.Controls.Add(label15);
            pnlLoginListToolbar.Controls.Add(refreshButton);
            pnlLoginListToolbar.Controls.Add(resetButton);
            pnlLoginListToolbar.Controls.Add(lblSearchPrompt);
            pnlLoginListToolbar.Controls.Add(txtSearchLogin);
            pnlLoginListToolbar.Controls.Add(btnSearchLogin);
            pnlLoginListToolbar.Controls.Add(btnClearSearchLogin);
            pnlLoginListToolbar.Location = new Point(20, 142);
            pnlLoginListToolbar.Name = "pnlLoginListToolbar";
            pnlLoginListToolbar.Size = new Size(655, 82);
            pnlLoginListToolbar.TabIndex = 26;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(12, 10);
            label15.Name = "label15";
            label15.Size = new Size(156, 15);
            label15.TabIndex = 0;
            label15.Text = "Exist Apps List - Auto Login";
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.White;
            refreshButton.Cursor = Cursors.Hand;
            refreshButton.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            refreshButton.FlatStyle = FlatStyle.Flat;
            refreshButton.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            refreshButton.ForeColor = Color.Black;
            refreshButton.Location = new Point(410, 6);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(110, 30);
            refreshButton.TabIndex = 26;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += refreshButton_Click;
            // 
            // resetButton
            // 
            resetButton.BackColor = Color.White;
            resetButton.Cursor = Cursors.Hand;
            resetButton.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            resetButton.FlatStyle = FlatStyle.Flat;
            resetButton.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            resetButton.ForeColor = Color.Black;
            resetButton.Location = new Point(530, 6);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(110, 30);
            resetButton.TabIndex = 27;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += resetButton_Click;
            // 
            // lblSearchPrompt
            // 
            lblSearchPrompt.AutoSize = true;
            lblSearchPrompt.Font = new Font("Segoe UI", 8.5F);
            lblSearchPrompt.ForeColor = Color.FromArgb(70, 70, 70);
            lblSearchPrompt.Location = new Point(12, 47);
            lblSearchPrompt.Name = "lblSearchPrompt";
            lblSearchPrompt.Size = new Size(45, 15);
            lblSearchPrompt.TabIndex = 3;
            lblSearchPrompt.Text = "Search:";
            // 
            // txtSearchLogin
            // 
            txtSearchLogin.BackColor = Color.White;
            txtSearchLogin.BorderStyle = BorderStyle.FixedSingle;
            txtSearchLogin.Font = new Font("Segoe UI", 9F);
            txtSearchLogin.ForeColor = Color.Black;
            txtSearchLogin.Location = new Point(70, 44);
            txtSearchLogin.MaxLength = 100;
            txtSearchLogin.Name = "txtSearchLogin";
            txtSearchLogin.PlaceholderText = "(Search apps...)";
            txtSearchLogin.Size = new Size(380, 23);
            txtSearchLogin.TabIndex = 28;
            txtSearchLogin.TextChanged += txtSearchLogin_TextChanged;
            // 
            // btnSearchLogin
            // 
            btnSearchLogin.BackColor = Color.Black;
            btnSearchLogin.Cursor = Cursors.Hand;
            btnSearchLogin.FlatAppearance.BorderColor = Color.Black;
            btnSearchLogin.FlatStyle = FlatStyle.Flat;
            btnSearchLogin.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnSearchLogin.ForeColor = Color.White;
            btnSearchLogin.Location = new Point(460, 42);
            btnSearchLogin.Name = "btnSearchLogin";
            btnSearchLogin.Size = new Size(85, 30);
            btnSearchLogin.TabIndex = 29;
            btnSearchLogin.Text = "Search";
            btnSearchLogin.UseVisualStyleBackColor = false;
            // 
            // btnClearSearchLogin
            // 
            btnClearSearchLogin.BackColor = Color.White;
            btnClearSearchLogin.Cursor = Cursors.Hand;
            btnClearSearchLogin.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnClearSearchLogin.FlatStyle = FlatStyle.Flat;
            btnClearSearchLogin.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnClearSearchLogin.ForeColor = Color.Black;
            btnClearSearchLogin.Location = new Point(555, 42);
            btnClearSearchLogin.Name = "btnClearSearchLogin";
            btnClearSearchLogin.Size = new Size(85, 30);
            btnClearSearchLogin.TabIndex = 30;
            btnClearSearchLogin.Text = "Clear";
            btnClearSearchLogin.UseVisualStyleBackColor = false;
            // 
            // pnlLoginColumnHeaders
            // 
            pnlLoginColumnHeaders.BackColor = Color.Black;
            pnlLoginColumnHeaders.Controls.Add(lblColTitle);
            pnlLoginColumnHeaders.Controls.Add(lblColStatus);
            pnlLoginColumnHeaders.Controls.Add(lblColAction);
            pnlLoginColumnHeaders.Location = new Point(20, 230);
            pnlLoginColumnHeaders.Name = "pnlLoginColumnHeaders";
            pnlLoginColumnHeaders.Size = new Size(655, 28);
            pnlLoginColumnHeaders.TabIndex = 105;
            // 
            // lblColTitle
            // 
            lblColTitle.AutoSize = true;
            lblColTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColTitle.ForeColor = Color.White;
            lblColTitle.Location = new Point(14, 5);
            lblColTitle.Name = "lblColTitle";
            lblColTitle.Size = new Size(155, 13);
            lblColTitle.TabIndex = 0;
            lblColTitle.Text = "PROCESS TITLE / NICKNAME";
            // 
            // lblColStatus
            // 
            lblColStatus.AutoSize = true;
            lblColStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColStatus.ForeColor = Color.White;
            lblColStatus.Location = new Point(350, 5);
            lblColStatus.Name = "lblColStatus";
            lblColStatus.Size = new Size(82, 13);
            lblColStatus.TabIndex = 1;
            lblColStatus.Text = "LOGIN STATUS";
            // 
            // lblColAction
            // 
            lblColAction.AutoSize = true;
            lblColAction.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblColAction.ForeColor = Color.White;
            lblColAction.Location = new Point(500, 5);
            lblColAction.Name = "lblColAction";
            lblColAction.Size = new Size(48, 13);
            lblColAction.TabIndex = 2;
            lblColAction.Text = "ACTION";
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.White;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel.Location = new Point(20, 258);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(655, 360);
            flowLayoutPanel.TabIndex = 31;
            // 
            // pnlLoginBottom
            // 
            pnlLoginBottom.BackColor = Color.WhiteSmoke;
            pnlLoginBottom.BorderStyle = BorderStyle.FixedSingle;
            pnlLoginBottom.Controls.Add(testLogin);
            pnlLoginBottom.Controls.Add(lblAutoLoginMode);
            pnlLoginBottom.Controls.Add(cmbAutoLoginMode);
            pnlLoginBottom.Controls.Add(label14);
            pnlLoginBottom.Controls.Add(panel8);
            pnlLoginBottom.Location = new Point(20, 628);
            pnlLoginBottom.Name = "pnlLoginBottom";
            pnlLoginBottom.Size = new Size(655, 46);
            pnlLoginBottom.TabIndex = 32;
            // 
            // testLogin
            // 
            testLogin.BackColor = Color.White;
            testLogin.Cursor = Cursors.Hand;
            testLogin.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            testLogin.FlatStyle = FlatStyle.Flat;
            testLogin.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            testLogin.ForeColor = Color.Black;
            testLogin.Location = new Point(12, 8);
            testLogin.Name = "testLogin";
            testLogin.Size = new Size(80, 30);
            testLogin.TabIndex = 32;
            testLogin.Text = "Test";
            testLogin.UseVisualStyleBackColor = false;
            testLogin.Click += testLogin_Click;
            // 
            // lblAutoLoginMode
            // 
            lblAutoLoginMode.AutoSize = true;
            lblAutoLoginMode.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAutoLoginMode.ForeColor = Color.Black;
            lblAutoLoginMode.Location = new Point(102, 14);
            lblAutoLoginMode.Name = "lblAutoLoginMode";
            lblAutoLoginMode.Size = new Size(71, 15);
            lblAutoLoginMode.TabIndex = 33;
            lblAutoLoginMode.Text = "Flow Mode:";
            // 
            // cmbAutoLoginMode
            // 
            cmbAutoLoginMode.BackColor = Color.White;
            cmbAutoLoginMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAutoLoginMode.Font = new Font("Segoe UI", 9F);
            cmbAutoLoginMode.ForeColor = Color.Black;
            cmbAutoLoginMode.FormattingEnabled = true;
            cmbAutoLoginMode.Items.AddRange(new object[] {
            "Standard Auto Login (Login Only)",
            "Auto Login + Create Character"});
            cmbAutoLoginMode.Location = new Point(178, 10);
            cmbAutoLoginMode.Name = "cmbAutoLoginMode";
            cmbAutoLoginMode.Size = new Size(425, 23);
            cmbAutoLoginMode.TabIndex = 34;
            // 
            // label14
            // 
            label14.Visible = false;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Red;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Location = new Point(618, 12);
            panel8.Name = "panel8";
            panel8.Size = new Size(22, 22);
            panel8.TabIndex = 2;
            // 
            // runLogin
            // 
            runLogin.BackColor = Color.Black;
            runLogin.Cursor = Cursors.Hand;
            runLogin.FlatAppearance.BorderColor = Color.Black;
            runLogin.FlatStyle = FlatStyle.Flat;
            runLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            runLogin.ForeColor = Color.White;
            runLogin.Location = new Point(20, 684);
            runLogin.Name = "runLogin";
            runLogin.Size = new Size(655, 52);
            runLogin.TabIndex = 33;
            runLogin.Text = "RUN AUTO LOGIN";
            runLogin.UseVisualStyleBackColor = false;
            runLogin.Click += runLogin_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 102;
            panel1.Visible = false;
            // 
            // panel4
            // 
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(0, 0);
            panel4.TabIndex = 103;
            panel4.Visible = false;
            // 
            // panel5
            // 
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(0, 0);
            panel5.TabIndex = 104;
            panel5.Visible = false;
            // 
            // panel6
            // 
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(0, 0);
            panel6.TabIndex = 105;
            panel6.Visible = false;
            // 
            // panel7
            // 
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(0, 0);
            panel7.TabIndex = 106;
            panel7.Visible = false;
            // 
            // panel9
            // 
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(0, 0);
            panel9.TabIndex = 107;
            panel9.Visible = false;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1900, 919);
            Controls.Add(gbAutoLogin);
            Controls.Add(gbBulkApp);
            Controls.Add(gbHandlers);
            Controls.Add(gbTimedMemory);
            Controls.Add(gbMemoryManagement);
            Controls.Add(pnlProcessToolbar);
            Controls.Add(pnlHeader);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel6);
            Controls.Add(panel7);
            Controls.Add(panel9);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Process Forge - KH2 Edition (by HanumGoo)";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlProcessToolbar.ResumeLayout(false);
            pnlProcessToolbar.PerformLayout();
            gbMemoryManagement.ResumeLayout(false);
            gbTimedMemory.ResumeLayout(false);
            gbTimedMemory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TimeSetForClearRAM).EndInit();
            pnlTimedStatus.ResumeLayout(false);
            pnlTimedStatus.PerformLayout();
            gbHandlers.ResumeLayout(false);
            gbHandlers.PerformLayout();
            gbBulkApp.ResumeLayout(false);
            gbBulkApp.PerformLayout();
            pnlRenameOptions.ResumeLayout(false);
            pnlRenameOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            pnlDelaySettings.ResumeLayout(false);
            pnlDelaySettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            pnlValidationRow.ResumeLayout(false);
            pnlValidationRow.PerformLayout();
            gbAutoLogin.ResumeLayout(false);
            gbAutoLogin.PerformLayout();
            pnlLoginListToolbar.ResumeLayout(false);
            pnlLoginListToolbar.PerformLayout();
            pnlLoginColumnHeaders.ResumeLayout(false);
            pnlLoginColumnHeaders.PerformLayout();
            pnlLoginBottom.ResumeLayout(false);
            pnlLoginBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Controls used by business logic
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
        private Button settingForm;

        // Modern UI layout containers and labels
        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlProcessToolbar;
        private GroupBox gbMemoryManagement;
        private GroupBox gbTimedMemory;
        private Panel pnlTimedStatus;
        private Label lblStatusText;
        private GroupBox gbHandlers;
        private Label lblBulkSub;
        private Label lblImportSub;
        private GroupBox gbBulkApp;
        private Panel pnlRenameOptions;
        private Panel pnlDelaySettings;
        private Panel pnlValidationRow;
        private GroupBox gbAutoLogin;
        private Panel pnlLoginListToolbar;
        private Label lblSearchPrompt;
        internal Button btnSearchLogin;
        internal Button btnClearSearchLogin;
        private Panel pnlLoginColumnHeaders;
        private Label lblColTitle;
        private Label lblColStatus;
        private Label lblColAction;
        private Panel pnlLoginBottom;
        private Label lblAutoLoginMode;
        private ComboBox cmbAutoLoginMode;
    }
}
