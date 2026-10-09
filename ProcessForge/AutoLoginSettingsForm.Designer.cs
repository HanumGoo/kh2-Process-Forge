namespace ProcessForge
{
    partial class AutoLoginSettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header Controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;

        // Pagination Bar Controls
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnPrevStep;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Label lblStepIndicator;
        private System.Windows.Forms.FlowLayoutPanel flpPageButtons;
        private System.Windows.Forms.Button btnAddSubStep;
        private System.Windows.Forms.Button btnDeleteSubStep;

        private System.Windows.Forms.TableLayoutPanel tlpMainLayout;

        // Image Section Controls
        private System.Windows.Forms.GroupBox gbImageConfig;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnCaptureImage;
        private System.Windows.Forms.Label lblCaptureTitle;
        private System.Windows.Forms.TextBox txtCaptureTitle;
        private System.Windows.Forms.Label lblTemplateName;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.Label lblImagePathTitle;
        private System.Windows.Forms.TextBox txtImagePath;

        // Linear Action Sequence Controls
        private System.Windows.Forms.GroupBox gbActionConfig;
        private System.Windows.Forms.Label lblActionList;
        private System.Windows.Forms.ListBox lstActions;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnRemoveAction;
        private System.Windows.Forms.Button btnClearActions;
        private System.Windows.Forms.Button btnUpdateSelected;

        // Mouse Action Section
        private System.Windows.Forms.Label lblMouseHeader;
        private System.Windows.Forms.Button btnCaptureCoords;
        private System.Windows.Forms.CheckBox chkUseRelativeOffset;
        private System.Windows.Forms.Label lblXCoord;
        private System.Windows.Forms.NumericUpDown numCoordX;
        private System.Windows.Forms.Label lblYCoord;
        private System.Windows.Forms.NumericUpDown numCoordY;
        private System.Windows.Forms.Label lblClickType;
        private System.Windows.Forms.ComboBox cmbClickType;
        private System.Windows.Forms.Button btnAddMouseAction;

        // Keyboard Action Section
        private System.Windows.Forms.Label lblKeyboardHeader;
        private System.Windows.Forms.Button btnVarUsername;
        private System.Windows.Forms.Button btnVarPassword;
        private System.Windows.Forms.Button btnVarPin;
        private System.Windows.Forms.Button btnVarNickname;
        private System.Windows.Forms.Label lblKeyboardWord;
        private System.Windows.Forms.TextBox txtKeyboardWord;
        private System.Windows.Forms.Button btnQuickTab;
        private System.Windows.Forms.Button btnQuickEnter;
        private System.Windows.Forms.Button btnAddKeyAction;

        // Delay Action Section
        private System.Windows.Forms.Label lblDelayHeader;
        private System.Windows.Forms.NumericUpDown numDelayMs;
        private System.Windows.Forms.Label lblMsUnit;
        private System.Windows.Forms.Button btnAddDelayAction;

        // Message Input Box Section
        private System.Windows.Forms.Label lblInputBoxHeader;
        private System.Windows.Forms.TextBox txtInputBoxPrompt;
        private System.Windows.Forms.Button btnAddInputBoxAction;

        // Footer Controls
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTestExecution;

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
            pnlHeader = new Panel();
            lblHeaderSubtitle = new Label();
            lblHeaderTitle = new Label();
            pnlPagination = new Panel();
            btnNextStep = new Button();
            btnDeleteSubStep = new Button();
            btnAddSubStep = new Button();
            flpPageButtons = new FlowLayoutPanel();
            lblStepIndicator = new Label();
            btnPrevStep = new Button();
            tlpMainLayout = new TableLayoutPanel();
            gbImageConfig = new GroupBox();
            txtImagePath = new TextBox();
            lblImagePathTitle = new Label();
            txtTemplateName = new TextBox();
            lblTemplateName = new Label();
            txtCaptureTitle = new TextBox();
            lblCaptureTitle = new Label();
            btnCaptureImage = new Button();
            picPreview = new PictureBox();
            gbActionConfig = new GroupBox();
            btnAddInputBoxAction = new Button();
            txtInputBoxPrompt = new TextBox();
            lblInputBoxHeader = new Label();
            btnAddDelayAction = new Button();
            lblMsUnit = new Label();
            numDelayMs = new NumericUpDown();
            lblDelayHeader = new Label();
            btnAddKeyAction = new Button();
            btnQuickEnter = new Button();
            btnQuickTab = new Button();
            btnVarNickname = new Button();
            btnVarPin = new Button();
            btnVarPassword = new Button();
            btnVarUsername = new Button();
            txtKeyboardWord = new TextBox();
            lblKeyboardWord = new Label();
            lblKeyboardHeader = new Label();
            btnAddMouseAction = new Button();
            cmbClickType = new ComboBox();
            lblClickType = new Label();
            numCoordY = new NumericUpDown();
            lblYCoord = new Label();
            numCoordX = new NumericUpDown();
            lblXCoord = new Label();
            chkUseRelativeOffset = new CheckBox();
            btnCaptureCoords = new Button();
            lblMouseHeader = new Label();
            btnUpdateSelected = new Button();
            btnClearActions = new Button();
            btnRemoveAction = new Button();
            btnMoveDown = new Button();
            btnMoveUp = new Button();
            lstActions = new ListBox();
            lblActionList = new Label();
            pnlFooter = new Panel();
            btnTestExecution = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            pnlHeader.SuspendLayout();
            pnlPagination.SuspendLayout();
            tlpMainLayout.SuspendLayout();
            gbImageConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            gbActionConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDelayMs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCoordY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCoordX).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Black;
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 55);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 8F);
            lblHeaderSubtitle.ForeColor = Color.LightGray;
            lblHeaderSubtitle.Location = new Point(17, 30);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(579, 13);
            lblHeaderSubtitle.TabIndex = 0;
            lblHeaderSubtitle.Text = "Capture image anchor and configure linear input macro sequence per step (Main Steps 1-5 & Custom Sub-Steps).";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(16, 8);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(262, 20);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "AUTO-LOGIN WORKFLOW BUILDER";
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = Color.WhiteSmoke;
            pnlPagination.Controls.Add(lblStepIndicator);
            pnlPagination.Controls.Add(btnPrevStep);
            pnlPagination.Controls.Add(btnNextStep);
            pnlPagination.Controls.Add(btnAddSubStep);
            pnlPagination.Controls.Add(btnDeleteSubStep);
            pnlPagination.Controls.Add(flpPageButtons);
            pnlPagination.Dock = DockStyle.Top;
            pnlPagination.Location = new Point(0, 55);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1000, 75);
            pnlPagination.TabIndex = 1;
            // 
            // lblStepIndicator
            // 
            lblStepIndicator.AutoSize = true;
            lblStepIndicator.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStepIndicator.ForeColor = Color.Black;
            lblStepIndicator.Location = new Point(12, 10);
            lblStepIndicator.Name = "lblStepIndicator";
            lblStepIndicator.Size = new Size(118, 15);
            lblStepIndicator.TabIndex = 0;
            lblStepIndicator.Text = "MAIN STEP 1 OF 3";
            // 
            // btnPrevStep
            // 
            btnPrevStep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevStep.BackColor = Color.White;
            btnPrevStep.Cursor = Cursors.Hand;
            btnPrevStep.FlatStyle = FlatStyle.Flat;
            btnPrevStep.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnPrevStep.ForeColor = Color.Black;
            btnPrevStep.Location = new Point(660, 5);
            btnPrevStep.Name = "btnPrevStep";
            btnPrevStep.Size = new Size(65, 26);
            btnPrevStep.TabIndex = 1;
            btnPrevStep.Text = "< PREV";
            btnPrevStep.UseVisualStyleBackColor = false;
            // 
            // btnNextStep
            // 
            btnNextStep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNextStep.BackColor = Color.Black;
            btnNextStep.Cursor = Cursors.Hand;
            btnNextStep.FlatStyle = FlatStyle.Flat;
            btnNextStep.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnNextStep.ForeColor = Color.White;
            btnNextStep.Location = new Point(730, 5);
            btnNextStep.Name = "btnNextStep";
            btnNextStep.Size = new Size(65, 26);
            btnNextStep.TabIndex = 2;
            btnNextStep.Text = "NEXT >";
            btnNextStep.UseVisualStyleBackColor = false;
            // 
            // btnAddSubStep
            // 
            btnAddSubStep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddSubStep.BackColor = Color.Black;
            btnAddSubStep.Cursor = Cursors.Hand;
            btnAddSubStep.FlatStyle = FlatStyle.Flat;
            btnAddSubStep.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAddSubStep.ForeColor = Color.White;
            btnAddSubStep.Location = new Point(805, 5);
            btnAddSubStep.Name = "btnAddSubStep";
            btnAddSubStep.Size = new Size(92, 26);
            btnAddSubStep.TabIndex = 3;
            btnAddSubStep.Text = "+ ADD SUB";
            btnAddSubStep.UseVisualStyleBackColor = false;
            // 
            // btnDeleteSubStep
            // 
            btnDeleteSubStep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteSubStep.BackColor = Color.White;
            btnDeleteSubStep.Cursor = Cursors.Hand;
            btnDeleteSubStep.FlatStyle = FlatStyle.Flat;
            btnDeleteSubStep.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnDeleteSubStep.ForeColor = Color.Crimson;
            btnDeleteSubStep.Location = new Point(903, 5);
            btnDeleteSubStep.Name = "btnDeleteSubStep";
            btnDeleteSubStep.Size = new Size(87, 26);
            btnDeleteSubStep.TabIndex = 4;
            btnDeleteSubStep.Text = "✕ DEL SUB";
            btnDeleteSubStep.UseVisualStyleBackColor = false;
            // 
            // flpPageButtons
            // 
            flpPageButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpPageButtons.AutoScroll = true;
            flpPageButtons.Location = new Point(10, 36);
            flpPageButtons.Name = "flpPageButtons";
            flpPageButtons.Size = new Size(980, 34);
            flpPageButtons.TabIndex = 5;
            flpPageButtons.WrapContents = false;
            // 
            // tlpMainLayout
            // 
            tlpMainLayout.ColumnCount = 2;
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            tlpMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            tlpMainLayout.Controls.Add(gbImageConfig, 0, 0);
            tlpMainLayout.Controls.Add(gbActionConfig, 1, 0);
            tlpMainLayout.Dock = DockStyle.Fill;
            tlpMainLayout.Location = new Point(0, 112);
            tlpMainLayout.Name = "tlpMainLayout";
            tlpMainLayout.Padding = new Padding(10);
            tlpMainLayout.RowCount = 1;
            tlpMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMainLayout.Size = new Size(1000, 438);
            tlpMainLayout.TabIndex = 2;
            // 
            // gbImageConfig
            // 
            gbImageConfig.Controls.Add(txtImagePath);
            gbImageConfig.Controls.Add(lblImagePathTitle);
            gbImageConfig.Controls.Add(txtTemplateName);
            gbImageConfig.Controls.Add(lblTemplateName);
            gbImageConfig.Controls.Add(txtCaptureTitle);
            gbImageConfig.Controls.Add(lblCaptureTitle);
            gbImageConfig.Controls.Add(btnCaptureImage);
            gbImageConfig.Controls.Add(picPreview);
            gbImageConfig.Dock = DockStyle.Fill;
            gbImageConfig.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbImageConfig.ForeColor = Color.Black;
            gbImageConfig.Location = new Point(13, 13);
            gbImageConfig.Name = "gbImageConfig";
            gbImageConfig.Size = new Size(405, 412);
            gbImageConfig.TabIndex = 0;
            gbImageConfig.TabStop = false;
            gbImageConfig.Text = " CAPTURE - CHOOSE SERVER ";
            // 
            // txtImagePath
            // 
            txtImagePath.BackColor = Color.WhiteSmoke;
            txtImagePath.BorderStyle = BorderStyle.FixedSingle;
            txtImagePath.Font = new Font("Segoe UI", 8.25F);
            txtImagePath.Location = new Point(15, 329);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.ReadOnly = true;
            txtImagePath.Size = new Size(365, 22);
            txtImagePath.TabIndex = 4;
            // 
            // lblImagePathTitle
            // 
            lblImagePathTitle.AutoSize = true;
            lblImagePathTitle.Font = new Font("Segoe UI", 8.25F);
            lblImagePathTitle.Location = new Point(15, 312);
            lblImagePathTitle.Name = "lblImagePathTitle";
            lblImagePathTitle.Size = new Size(88, 13);
            lblImagePathTitle.TabIndex = 5;
            lblImagePathTitle.Text = "Image File Path:";
            // 
            // txtTemplateName
            // 
            txtTemplateName.BorderStyle = BorderStyle.FixedSingle;
            txtTemplateName.Font = new Font("Segoe UI", 8.25F);
            txtTemplateName.Location = new Point(15, 284);
            txtTemplateName.Name = "txtTemplateName";
            txtTemplateName.Size = new Size(365, 22);
            txtTemplateName.TabIndex = 3;
            // 
            // lblTemplateName
            // 
            lblTemplateName.AutoSize = true;
            lblTemplateName.Font = new Font("Segoe UI", 8.25F);
            lblTemplateName.Location = new Point(15, 267);
            lblTemplateName.Name = "lblTemplateName";
            lblTemplateName.Size = new Size(83, 13);
            lblTemplateName.TabIndex = 6;
            lblTemplateName.Text = "Step Identifier:";
            // 
            // txtCaptureTitle
            // 
            txtCaptureTitle.BorderStyle = BorderStyle.FixedSingle;
            txtCaptureTitle.Font = new Font("Segoe UI", 8.25F);
            txtCaptureTitle.Location = new Point(15, 239);
            txtCaptureTitle.Name = "txtCaptureTitle";
            txtCaptureTitle.Size = new Size(365, 22);
            txtCaptureTitle.TabIndex = 2;
            // 
            // lblCaptureTitle
            // 
            lblCaptureTitle.AutoSize = true;
            lblCaptureTitle.Font = new Font("Segoe UI", 8.25F);
            lblCaptureTitle.Location = new Point(15, 222);
            lblCaptureTitle.Name = "lblCaptureTitle";
            lblCaptureTitle.Size = new Size(167, 13);
            lblCaptureTitle.TabIndex = 7;
            lblCaptureTitle.Text = "Capture Title (Dynamic Header):";
            // 
            // btnCaptureImage
            // 
            btnCaptureImage.BackColor = Color.Black;
            btnCaptureImage.Cursor = Cursors.Hand;
            btnCaptureImage.FlatStyle = FlatStyle.Flat;
            btnCaptureImage.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnCaptureImage.ForeColor = Color.White;
            btnCaptureImage.Location = new Point(15, 185);
            btnCaptureImage.Name = "btnCaptureImage";
            btnCaptureImage.Size = new Size(365, 30);
            btnCaptureImage.TabIndex = 1;
            btnCaptureImage.Text = "CAPTURE IMAGE FOR THIS STEP";
            btnCaptureImage.UseVisualStyleBackColor = false;
            // 
            // picPreview
            // 
            picPreview.BackColor = Color.White;
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Cursor = Cursors.Cross;
            picPreview.Location = new Point(15, 22);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(365, 155);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 0;
            picPreview.TabStop = false;
            // 
            // gbActionConfig
            // 
            gbActionConfig.Controls.Add(btnAddInputBoxAction);
            gbActionConfig.Controls.Add(txtInputBoxPrompt);
            gbActionConfig.Controls.Add(lblInputBoxHeader);
            gbActionConfig.Controls.Add(btnAddDelayAction);
            gbActionConfig.Controls.Add(lblMsUnit);
            gbActionConfig.Controls.Add(numDelayMs);
            gbActionConfig.Controls.Add(lblDelayHeader);
            gbActionConfig.Controls.Add(btnAddKeyAction);
            gbActionConfig.Controls.Add(btnQuickEnter);
            gbActionConfig.Controls.Add(btnQuickTab);
            gbActionConfig.Controls.Add(btnVarNickname);
            gbActionConfig.Controls.Add(btnVarPin);
            gbActionConfig.Controls.Add(btnVarPassword);
            gbActionConfig.Controls.Add(btnVarUsername);
            gbActionConfig.Controls.Add(txtKeyboardWord);
            gbActionConfig.Controls.Add(lblKeyboardWord);
            gbActionConfig.Controls.Add(lblKeyboardHeader);
            gbActionConfig.Controls.Add(btnAddMouseAction);
            gbActionConfig.Controls.Add(cmbClickType);
            gbActionConfig.Controls.Add(lblClickType);
            gbActionConfig.Controls.Add(numCoordY);
            gbActionConfig.Controls.Add(lblYCoord);
            gbActionConfig.Controls.Add(numCoordX);
            gbActionConfig.Controls.Add(lblXCoord);
            gbActionConfig.Controls.Add(chkUseRelativeOffset);
            gbActionConfig.Controls.Add(btnCaptureCoords);
            gbActionConfig.Controls.Add(lblMouseHeader);
            gbActionConfig.Controls.Add(btnUpdateSelected);
            gbActionConfig.Controls.Add(btnClearActions);
            gbActionConfig.Controls.Add(btnRemoveAction);
            gbActionConfig.Controls.Add(btnMoveDown);
            gbActionConfig.Controls.Add(btnMoveUp);
            gbActionConfig.Controls.Add(lstActions);
            gbActionConfig.Controls.Add(lblActionList);
            gbActionConfig.Dock = DockStyle.Fill;
            gbActionConfig.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gbActionConfig.ForeColor = Color.Black;
            gbActionConfig.Location = new Point(424, 13);
            gbActionConfig.Name = "gbActionConfig";
            gbActionConfig.Size = new Size(563, 412);
            gbActionConfig.TabIndex = 1;
            gbActionConfig.TabStop = false;
            gbActionConfig.Text = " LINEAR INPUT ACTIONS (MACRO SEQUENCE) ";
            // 
            // btnAddInputBoxAction
            // 
            btnAddInputBoxAction.BackColor = Color.Black;
            btnAddInputBoxAction.Cursor = Cursors.Hand;
            btnAddInputBoxAction.FlatStyle = FlatStyle.Flat;
            btnAddInputBoxAction.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAddInputBoxAction.ForeColor = Color.White;
            btnAddInputBoxAction.Location = new Point(445, 346);
            btnAddInputBoxAction.Name = "btnAddInputBoxAction";
            btnAddInputBoxAction.Size = new Size(110, 26);
            btnAddInputBoxAction.TabIndex = 19;
            btnAddInputBoxAction.Text = "+ ADD PROMPT";
            btnAddInputBoxAction.UseVisualStyleBackColor = false;
            // 
            // txtInputBoxPrompt
            // 
            txtInputBoxPrompt.BorderStyle = BorderStyle.FixedSingle;
            txtInputBoxPrompt.Font = new Font("Segoe UI", 8.25F);
            txtInputBoxPrompt.Location = new Point(245, 348);
            txtInputBoxPrompt.Name = "txtInputBoxPrompt";
            txtInputBoxPrompt.Size = new Size(195, 22);
            txtInputBoxPrompt.TabIndex = 18;
            txtInputBoxPrompt.Text = "Enter character name:";
            // 
            // lblInputBoxHeader
            // 
            lblInputBoxHeader.AutoSize = true;
            lblInputBoxHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblInputBoxHeader.ForeColor = Color.Black;
            lblInputBoxHeader.Location = new Point(245, 328);
            lblInputBoxHeader.Name = "lblInputBoxHeader";
            lblInputBoxHeader.Size = new Size(189, 13);
            lblInputBoxHeader.TabIndex = 20;
            lblInputBoxHeader.Text = "Message Input Box (Wait for User):";
            // 
            // btnAddDelayAction
            // 
            btnAddDelayAction.BackColor = Color.Black;
            btnAddDelayAction.Cursor = Cursors.Hand;
            btnAddDelayAction.FlatStyle = FlatStyle.Flat;
            btnAddDelayAction.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAddDelayAction.ForeColor = Color.White;
            btnAddDelayAction.Location = new Point(118, 346);
            btnAddDelayAction.Name = "btnAddDelayAction";
            btnAddDelayAction.Size = new Size(118, 26);
            btnAddDelayAction.TabIndex = 17;
            btnAddDelayAction.Text = "+ ADD DELAY";
            btnAddDelayAction.UseVisualStyleBackColor = false;
            // 
            // lblMsUnit
            // 
            lblMsUnit.AutoSize = true;
            lblMsUnit.Font = new Font("Segoe UI", 8.25F);
            lblMsUnit.Location = new Point(93, 351);
            lblMsUnit.Name = "lblMsUnit";
            lblMsUnit.Size = new Size(21, 13);
            lblMsUnit.TabIndex = 21;
            lblMsUnit.Text = "ms";
            // 
            // numDelayMs
            // 
            numDelayMs.BorderStyle = BorderStyle.FixedSingle;
            numDelayMs.Font = new Font("Segoe UI", 8.25F);
            numDelayMs.Increment = new decimal(new int[] { 250, 0, 0, 0 });
            numDelayMs.Location = new Point(15, 348);
            numDelayMs.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numDelayMs.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            numDelayMs.Name = "numDelayMs";
            numDelayMs.Size = new Size(75, 22);
            numDelayMs.TabIndex = 16;
            numDelayMs.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // lblDelayHeader
            // 
            lblDelayHeader.AutoSize = true;
            lblDelayHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblDelayHeader.ForeColor = Color.Black;
            lblDelayHeader.Location = new Point(15, 328);
            lblDelayHeader.Name = "lblDelayHeader";
            lblDelayHeader.Size = new Size(81, 13);
            lblDelayHeader.TabIndex = 22;
            lblDelayHeader.Text = "Pause / Delay:";
            // 
            // btnAddKeyAction
            // 
            btnAddKeyAction.BackColor = Color.Black;
            btnAddKeyAction.Cursor = Cursors.Hand;
            btnAddKeyAction.FlatStyle = FlatStyle.Flat;
            btnAddKeyAction.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAddKeyAction.ForeColor = Color.White;
            btnAddKeyAction.Location = new Point(416, 293);
            btnAddKeyAction.Name = "btnAddKeyAction";
            btnAddKeyAction.Size = new Size(139, 26);
            btnAddKeyAction.TabIndex = 15;
            btnAddKeyAction.Text = "+ ADD KEY ACTION";
            btnAddKeyAction.UseVisualStyleBackColor = false;
            // 
            // btnQuickEnter
            // 
            btnQuickEnter.BackColor = Color.White;
            btnQuickEnter.Cursor = Cursors.Hand;
            btnQuickEnter.FlatStyle = FlatStyle.Flat;
            btnQuickEnter.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnQuickEnter.Location = new Point(335, 293);
            btnQuickEnter.Name = "btnQuickEnter";
            btnQuickEnter.Size = new Size(75, 26);
            btnQuickEnter.TabIndex = 14;
            btnQuickEnter.Text = "+ {ENTER}";
            btnQuickEnter.UseVisualStyleBackColor = false;
            // 
            // btnQuickTab
            // 
            btnQuickTab.BackColor = Color.White;
            btnQuickTab.Cursor = Cursors.Hand;
            btnQuickTab.FlatStyle = FlatStyle.Flat;
            btnQuickTab.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnQuickTab.Location = new Point(264, 293);
            btnQuickTab.Name = "btnQuickTab";
            btnQuickTab.Size = new Size(65, 26);
            btnQuickTab.TabIndex = 13;
            btnQuickTab.Text = "+ {TAB}";
            btnQuickTab.UseVisualStyleBackColor = false;
            // 
            // txtKeyboardWord
            // 
            txtKeyboardWord.BorderStyle = BorderStyle.FixedSingle;
            txtKeyboardWord.Font = new Font("Segoe UI", 8.25F);
            txtKeyboardWord.Location = new Point(52, 295);
            txtKeyboardWord.Name = "txtKeyboardWord";
            txtKeyboardWord.Size = new Size(205, 22);
            txtKeyboardWord.TabIndex = 12;
            // 
            // lblKeyboardWord
            // 
            lblKeyboardWord.AutoSize = true;
            lblKeyboardWord.Font = new Font("Segoe UI", 8.25F);
            lblKeyboardWord.Location = new Point(15, 298);
            lblKeyboardWord.Name = "lblKeyboardWord";
            lblKeyboardWord.Size = new Size(32, 13);
            lblKeyboardWord.TabIndex = 23;
            lblKeyboardWord.Text = "Keys:";
            // 
            // lblKeyboardHeader
            // 
            lblKeyboardHeader.AutoSize = true;
            lblKeyboardHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblKeyboardHeader.ForeColor = Color.Black;
            lblKeyboardHeader.Location = new Point(15, 275);
            lblKeyboardHeader.Name = "lblKeyboardHeader";
            lblKeyboardHeader.Size = new Size(152, 13);
            lblKeyboardHeader.TabIndex = 24;
            lblKeyboardHeader.Text = "Keyboard Input (SendKeys):";
            // 
            // btnVarUsername
            // 
            btnVarUsername.BackColor = Color.White;
            btnVarUsername.Cursor = Cursors.Hand;
            btnVarUsername.FlatStyle = FlatStyle.Flat;
            btnVarUsername.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            btnVarUsername.ForeColor = Color.Black;
            btnVarUsername.Location = new Point(175, 270);
            btnVarUsername.Name = "btnVarUsername";
            btnVarUsername.Size = new Size(88, 22);
            btnVarUsername.TabIndex = 25;
            btnVarUsername.Text = "+ {USERNAME}";
            btnVarUsername.UseVisualStyleBackColor = false;
            // 
            // btnVarPassword
            // 
            btnVarPassword.BackColor = Color.White;
            btnVarPassword.Cursor = Cursors.Hand;
            btnVarPassword.FlatStyle = FlatStyle.Flat;
            btnVarPassword.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            btnVarPassword.ForeColor = Color.Black;
            btnVarPassword.Location = new Point(267, 270);
            btnVarPassword.Name = "btnVarPassword";
            btnVarPassword.Size = new Size(90, 22);
            btnVarPassword.TabIndex = 26;
            btnVarPassword.Text = "+ {PASSWORD}";
            btnVarPassword.UseVisualStyleBackColor = false;
            // 
            // btnVarPin
            // 
            btnVarPin.BackColor = Color.White;
            btnVarPin.Cursor = Cursors.Hand;
            btnVarPin.FlatStyle = FlatStyle.Flat;
            btnVarPin.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            btnVarPin.ForeColor = Color.Black;
            btnVarPin.Location = new Point(361, 270);
            btnVarPin.Name = "btnVarPin";
            btnVarPin.Size = new Size(92, 22);
            btnVarPin.TabIndex = 27;
            btnVarPin.Text = "+ {SECONDPASS}";
            btnVarPin.UseVisualStyleBackColor = false;
            // 
            // btnVarNickname
            // 
            btnVarNickname.BackColor = Color.White;
            btnVarNickname.Cursor = Cursors.Hand;
            btnVarNickname.FlatStyle = FlatStyle.Flat;
            btnVarNickname.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            btnVarNickname.ForeColor = Color.Black;
            btnVarNickname.Location = new Point(457, 270);
            btnVarNickname.Name = "btnVarNickname";
            btnVarNickname.Size = new Size(98, 22);
            btnVarNickname.TabIndex = 28;
            btnVarNickname.Text = "+ {NICKNAME}";
            btnVarNickname.UseVisualStyleBackColor = false;
            // 
            // btnAddMouseAction
            // 
            btnAddMouseAction.BackColor = Color.Black;
            btnAddMouseAction.Cursor = Cursors.Hand;
            btnAddMouseAction.FlatStyle = FlatStyle.Flat;
            btnAddMouseAction.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAddMouseAction.ForeColor = Color.White;
            btnAddMouseAction.Location = new Point(380, 236);
            btnAddMouseAction.Name = "btnAddMouseAction";
            btnAddMouseAction.Size = new Size(175, 26);
            btnAddMouseAction.TabIndex = 11;
            btnAddMouseAction.Text = "+ ADD MOUSE ACTION";
            btnAddMouseAction.UseVisualStyleBackColor = false;
            // 
            // cmbClickType
            // 
            cmbClickType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClickType.FlatStyle = FlatStyle.Flat;
            cmbClickType.Font = new Font("Segoe UI", 8.25F);
            cmbClickType.FormattingEnabled = true;
            cmbClickType.Items.AddRange(new object[] { "Single Left Click", "Double Left Click", "Single Right Click", "Hover Only" });
            cmbClickType.Location = new Point(232, 238);
            cmbClickType.Name = "cmbClickType";
            cmbClickType.Size = new Size(140, 21);
            cmbClickType.TabIndex = 10;
            // 
            // lblClickType
            // 
            lblClickType.AutoSize = true;
            lblClickType.Font = new Font("Segoe UI", 8.25F);
            lblClickType.Location = new Point(195, 241);
            lblClickType.Name = "lblClickType";
            lblClickType.Size = new Size(32, 13);
            lblClickType.TabIndex = 25;
            lblClickType.Text = "Type:";
            // 
            // numCoordY
            // 
            numCoordY.BorderStyle = BorderStyle.FixedSingle;
            numCoordY.Font = new Font("Segoe UI", 8.25F);
            numCoordY.Location = new Point(123, 238);
            numCoordY.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numCoordY.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            numCoordY.Name = "numCoordY";
            numCoordY.Size = new Size(65, 22);
            numCoordY.TabIndex = 9;
            // 
            // lblYCoord
            // 
            lblYCoord.AutoSize = true;
            lblYCoord.Font = new Font("Segoe UI", 8.25F);
            lblYCoord.Location = new Point(105, 241);
            lblYCoord.Name = "lblYCoord";
            lblYCoord.Size = new Size(15, 13);
            lblYCoord.TabIndex = 26;
            lblYCoord.Text = "Y:";
            // 
            // numCoordX
            // 
            numCoordX.BorderStyle = BorderStyle.FixedSingle;
            numCoordX.Font = new Font("Segoe UI", 8.25F);
            numCoordX.Location = new Point(34, 238);
            numCoordX.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numCoordX.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            numCoordX.Name = "numCoordX";
            numCoordX.Size = new Size(65, 22);
            numCoordX.TabIndex = 8;
            // 
            // lblXCoord
            // 
            lblXCoord.AutoSize = true;
            lblXCoord.Font = new Font("Segoe UI", 8.25F);
            lblXCoord.Location = new Point(15, 241);
            lblXCoord.Name = "lblXCoord";
            lblXCoord.Size = new Size(16, 13);
            lblXCoord.TabIndex = 27;
            lblXCoord.Text = "X:";
            // 
            // chkUseRelativeOffset
            // 
            chkUseRelativeOffset.AutoSize = true;
            chkUseRelativeOffset.Checked = true;
            chkUseRelativeOffset.CheckState = CheckState.Checked;
            chkUseRelativeOffset.Font = new Font("Segoe UI", 8.25F);
            chkUseRelativeOffset.Location = new Point(250, 211);
            chkUseRelativeOffset.Name = "chkUseRelativeOffset";
            chkUseRelativeOffset.Size = new Size(244, 17);
            chkUseRelativeOffset.TabIndex = 7;
            chkUseRelativeOffset.Text = "Use coordinates relative to matched image";
            chkUseRelativeOffset.UseVisualStyleBackColor = true;
            // 
            // btnCaptureCoords
            // 
            btnCaptureCoords.BackColor = Color.Black;
            btnCaptureCoords.Cursor = Cursors.Hand;
            btnCaptureCoords.FlatStyle = FlatStyle.Flat;
            btnCaptureCoords.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnCaptureCoords.ForeColor = Color.White;
            btnCaptureCoords.Location = new Point(15, 206);
            btnCaptureCoords.Name = "btnCaptureCoords";
            btnCaptureCoords.Size = new Size(225, 26);
            btnCaptureCoords.TabIndex = 6;
            btnCaptureCoords.Text = "CAPTURE SCREEN COORD";
            btnCaptureCoords.UseVisualStyleBackColor = false;
            // 
            // lblMouseHeader
            // 
            lblMouseHeader.AutoSize = true;
            lblMouseHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblMouseHeader.ForeColor = Color.Black;
            lblMouseHeader.Location = new Point(15, 188);
            lblMouseHeader.Name = "lblMouseHeader";
            lblMouseHeader.Size = new Size(128, 13);
            lblMouseHeader.TabIndex = 28;
            lblMouseHeader.Text = "Mouse Action Settings:";
            // 
            // btnUpdateSelected
            // 
            btnUpdateSelected.BackColor = Color.White;
            btnUpdateSelected.Cursor = Cursors.Hand;
            btnUpdateSelected.FlatStyle = FlatStyle.Flat;
            btnUpdateSelected.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnUpdateSelected.ForeColor = Color.DarkSlateGray;
            btnUpdateSelected.Location = new Point(395, 153);
            btnUpdateSelected.Name = "btnUpdateSelected";
            btnUpdateSelected.Size = new Size(160, 26);
            btnUpdateSelected.TabIndex = 5;
            btnUpdateSelected.Text = "✎ Update Selected";
            btnUpdateSelected.UseVisualStyleBackColor = false;
            // 
            // btnClearActions
            // 
            btnClearActions.BackColor = Color.White;
            btnClearActions.Cursor = Cursors.Hand;
            btnClearActions.FlatStyle = FlatStyle.Flat;
            btnClearActions.Font = new Font("Segoe UI", 8F);
            btnClearActions.Location = new Point(265, 153);
            btnClearActions.Name = "btnClearActions";
            btnClearActions.Size = new Size(75, 26);
            btnClearActions.TabIndex = 4;
            btnClearActions.Text = "Clear All";
            btnClearActions.UseVisualStyleBackColor = false;
            // 
            // btnRemoveAction
            // 
            btnRemoveAction.BackColor = Color.White;
            btnRemoveAction.Cursor = Cursors.Hand;
            btnRemoveAction.FlatStyle = FlatStyle.Flat;
            btnRemoveAction.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnRemoveAction.ForeColor = Color.Crimson;
            btnRemoveAction.Location = new Point(175, 153);
            btnRemoveAction.Name = "btnRemoveAction";
            btnRemoveAction.Size = new Size(85, 26);
            btnRemoveAction.TabIndex = 3;
            btnRemoveAction.Text = "✕ Remove";
            btnRemoveAction.UseVisualStyleBackColor = false;
            // 
            // btnMoveDown
            // 
            btnMoveDown.BackColor = Color.White;
            btnMoveDown.Cursor = Cursors.Hand;
            btnMoveDown.FlatStyle = FlatStyle.Flat;
            btnMoveDown.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnMoveDown.Location = new Point(95, 153);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(75, 26);
            btnMoveDown.TabIndex = 2;
            btnMoveDown.Text = "▼ Down";
            btnMoveDown.UseVisualStyleBackColor = false;
            // 
            // btnMoveUp
            // 
            btnMoveUp.BackColor = Color.White;
            btnMoveUp.Cursor = Cursors.Hand;
            btnMoveUp.FlatStyle = FlatStyle.Flat;
            btnMoveUp.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnMoveUp.Location = new Point(15, 153);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(75, 26);
            btnMoveUp.TabIndex = 1;
            btnMoveUp.Text = "▲ Up";
            btnMoveUp.UseVisualStyleBackColor = false;
            // 
            // lstActions
            // 
            lstActions.BorderStyle = BorderStyle.FixedSingle;
            lstActions.Font = new Font("Segoe UI", 8.5F);
            lstActions.FormattingEnabled = true;
            lstActions.IntegralHeight = false;
            lstActions.Location = new Point(15, 37);
            lstActions.Name = "lstActions";
            lstActions.Size = new Size(540, 110);
            lstActions.TabIndex = 0;
            // 
            // lblActionList
            // 
            lblActionList.AutoSize = true;
            lblActionList.Font = new Font("Segoe UI", 8.25F);
            lblActionList.Location = new Point(15, 20);
            lblActionList.Name = "lblActionList";
            lblActionList.Size = new Size(230, 13);
            lblActionList.TabIndex = 29;
            lblActionList.Text = "Linear Action Order (Executed in sequence):";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.WhiteSmoke;
            pnlFooter.Controls.Add(btnTestExecution);
            pnlFooter.Controls.Add(btnCancel);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 550);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1000, 50);
            pnlFooter.TabIndex = 3;
            // 
            // btnTestExecution
            // 
            btnTestExecution.BackColor = Color.White;
            btnTestExecution.Cursor = Cursors.Hand;
            btnTestExecution.FlatStyle = FlatStyle.Flat;
            btnTestExecution.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnTestExecution.ForeColor = Color.Black;
            btnTestExecution.Location = new Point(12, 10);
            btnTestExecution.Name = "btnTestExecution";
            btnTestExecution.Size = new Size(170, 30);
            btnTestExecution.TabIndex = 2;
            btnTestExecution.Text = "TEST CURRENT STEP";
            btnTestExecution.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 8.25F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(795, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Black;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(890, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "SAVE ALL";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // AutoLoginSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 620);
            Controls.Add(tlpMainLayout);
            Controls.Add(pnlFooter);
            Controls.Add(pnlPagination);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AutoLoginSettingsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProcessForge — Multi-Step Target Configuration";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlPagination.ResumeLayout(false);
            pnlPagination.PerformLayout();
            tlpMainLayout.ResumeLayout(false);
            gbImageConfig.ResumeLayout(false);
            gbImageConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            gbActionConfig.ResumeLayout(false);
            gbActionConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDelayMs).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCoordY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCoordX).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}