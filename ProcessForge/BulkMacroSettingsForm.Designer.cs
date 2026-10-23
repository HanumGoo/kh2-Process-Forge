namespace ProcessForge
{
    partial class BulkMacroSettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header Controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;

        // Workflow Profile Controls
        private System.Windows.Forms.Panel pnlWorkflowBar;
        private System.Windows.Forms.Label lblWorkflowLabel;
        private System.Windows.Forms.ComboBox cmbWorkflows;
        private System.Windows.Forms.Button btnMoveWorkflowUp;
        private System.Windows.Forms.Button btnMoveWorkflowDown;
        private System.Windows.Forms.Label lblWorkflowSearch;
        private System.Windows.Forms.TextBox txtWorkflowSearch;
        private System.Windows.Forms.Button btnNewWorkflow;
        private System.Windows.Forms.Button btnRenameWorkflow;
        private System.Windows.Forms.Button btnDuplicateWorkflow;
        private System.Windows.Forms.Button btnDeleteWorkflow;

        // Pagination Bar Controls
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Label lblStepIndicator;
        private System.Windows.Forms.Button btnPrevStep;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnAddStep;
        private System.Windows.Forms.Button btnAddSubStep;
        private System.Windows.Forms.Button btnDeleteStep;
        private System.Windows.Forms.FlowLayoutPanel flpPageButtons;

        private System.Windows.Forms.TableLayoutPanel tlpMainLayout;

        // Image Section Controls
        private System.Windows.Forms.GroupBox gbImageConfig;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnCaptureImage;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Label lblCaptureTitle;
        private System.Windows.Forms.TextBox txtCaptureTitle;
        private System.Windows.Forms.Label lblTemplateName;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.Label lblImagePathTitle;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Label lblImageNote;

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

        // Control Flow Action Section
        private System.Windows.Forms.Label lblControlFlowHeader;
        private System.Windows.Forms.Button btnAddBreakAction;
        private System.Windows.Forms.Label lblGotoTarget;
        private System.Windows.Forms.ComboBox cmbGotoStep;
        private System.Windows.Forms.Button btnAddGotoAction;

        // Special Actions Section (Auto-Login & Memory Management)
        private System.Windows.Forms.Label lblSpecialActionsHeader;
        private System.Windows.Forms.Label lblAutoLoginMode;
        private System.Windows.Forms.ComboBox cmbAutoLoginMode;
        private System.Windows.Forms.Button btnAddAutoLoginAction;
        private System.Windows.Forms.Button btnAddClearMemoryAction;

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
            pnlHeader = new System.Windows.Forms.Panel();
            lblHeaderSubtitle = new System.Windows.Forms.Label();
            lblHeaderTitle = new System.Windows.Forms.Label();
            pnlWorkflowBar = new System.Windows.Forms.Panel();
            btnDeleteWorkflow = new System.Windows.Forms.Button();
            btnDuplicateWorkflow = new System.Windows.Forms.Button();
            btnRenameWorkflow = new System.Windows.Forms.Button();
            btnNewWorkflow = new System.Windows.Forms.Button();
            btnMoveWorkflowUp = new System.Windows.Forms.Button();
            btnMoveWorkflowDown = new System.Windows.Forms.Button();
            lblWorkflowSearch = new System.Windows.Forms.Label();
            txtWorkflowSearch = new System.Windows.Forms.TextBox();
            cmbWorkflows = new System.Windows.Forms.ComboBox();
            lblWorkflowLabel = new System.Windows.Forms.Label();
            pnlPagination = new System.Windows.Forms.Panel();
            lblStepIndicator = new System.Windows.Forms.Label();
            btnPrevStep = new System.Windows.Forms.Button();
            btnNextStep = new System.Windows.Forms.Button();
            btnAddStep = new System.Windows.Forms.Button();
            btnAddSubStep = new System.Windows.Forms.Button();
            btnDeleteStep = new System.Windows.Forms.Button();
            flpPageButtons = new System.Windows.Forms.FlowLayoutPanel();
            tlpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            gbImageConfig = new System.Windows.Forms.GroupBox();
            lblImageNote = new System.Windows.Forms.Label();
            btnClearImage = new System.Windows.Forms.Button();
            txtImagePath = new System.Windows.Forms.TextBox();
            lblImagePathTitle = new System.Windows.Forms.Label();
            txtTemplateName = new System.Windows.Forms.TextBox();
            lblTemplateName = new System.Windows.Forms.Label();
            txtCaptureTitle = new System.Windows.Forms.TextBox();
            lblCaptureTitle = new System.Windows.Forms.Label();
            btnCaptureImage = new System.Windows.Forms.Button();
            picPreview = new System.Windows.Forms.PictureBox();
            gbActionConfig = new System.Windows.Forms.GroupBox();

            lblSpecialActionsHeader = new System.Windows.Forms.Label();
            lblAutoLoginMode = new System.Windows.Forms.Label();
            cmbAutoLoginMode = new System.Windows.Forms.ComboBox();
            btnAddAutoLoginAction = new System.Windows.Forms.Button();
            btnAddClearMemoryAction = new System.Windows.Forms.Button();

            lblControlFlowHeader = new System.Windows.Forms.Label();

            btnAddBreakAction = new System.Windows.Forms.Button();

            lblGotoTarget = new System.Windows.Forms.Label();

            cmbGotoStep = new System.Windows.Forms.ComboBox();

            btnAddGotoAction = new System.Windows.Forms.Button();
            btnAddInputBoxAction = new System.Windows.Forms.Button();
            txtInputBoxPrompt = new System.Windows.Forms.TextBox();
            lblInputBoxHeader = new System.Windows.Forms.Label();
            btnAddDelayAction = new System.Windows.Forms.Button();
            lblMsUnit = new System.Windows.Forms.Label();
            numDelayMs = new System.Windows.Forms.NumericUpDown();
            lblDelayHeader = new System.Windows.Forms.Label();
            btnAddKeyAction = new System.Windows.Forms.Button();
            btnQuickEnter = new System.Windows.Forms.Button();
            btnQuickTab = new System.Windows.Forms.Button();
            btnVarNickname = new System.Windows.Forms.Button();
            btnVarPin = new System.Windows.Forms.Button();
            btnVarPassword = new System.Windows.Forms.Button();
            btnVarUsername = new System.Windows.Forms.Button();
            txtKeyboardWord = new System.Windows.Forms.TextBox();
            lblKeyboardWord = new System.Windows.Forms.Label();
            lblKeyboardHeader = new System.Windows.Forms.Label();
            btnAddMouseAction = new System.Windows.Forms.Button();
            cmbClickType = new System.Windows.Forms.ComboBox();
            lblClickType = new System.Windows.Forms.Label();
            numCoordY = new System.Windows.Forms.NumericUpDown();
            lblYCoord = new System.Windows.Forms.Label();
            numCoordX = new System.Windows.Forms.NumericUpDown();
            lblXCoord = new System.Windows.Forms.Label();
            chkUseRelativeOffset = new System.Windows.Forms.CheckBox();
            btnCaptureCoords = new System.Windows.Forms.Button();
            lblMouseHeader = new System.Windows.Forms.Label();
            btnUpdateSelected = new System.Windows.Forms.Button();
            btnClearActions = new System.Windows.Forms.Button();
            btnRemoveAction = new System.Windows.Forms.Button();
            btnMoveDown = new System.Windows.Forms.Button();
            btnMoveUp = new System.Windows.Forms.Button();
            lstActions = new System.Windows.Forms.ListBox();
            lblActionList = new System.Windows.Forms.Label();
            pnlFooter = new System.Windows.Forms.Panel();
            btnTestExecution = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            pnlHeader.SuspendLayout();
            pnlWorkflowBar.SuspendLayout();
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
            pnlHeader.BackColor = System.Drawing.Color.Black;
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1020, 52);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblHeaderSubtitle.ForeColor = System.Drawing.Color.LightGray;
            lblHeaderSubtitle.Location = new System.Drawing.Point(17, 28);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new System.Drawing.Size(530, 13);
            lblHeaderSubtitle.TabIndex = 0;
            lblHeaderSubtitle.Text = "Configure customizable multi-step automation workflow macros for bulk process manager groups.";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            lblHeaderTitle.Location = new System.Drawing.Point(16, 7);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(306, 20);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "BULK WORKFLOW MACRO BUILDER";
            // 
            // pnlWorkflowBar
            // 
            pnlWorkflowBar.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            pnlWorkflowBar.Controls.Add(btnDeleteWorkflow);
            pnlWorkflowBar.Controls.Add(btnDuplicateWorkflow);
            pnlWorkflowBar.Controls.Add(btnRenameWorkflow);
            pnlWorkflowBar.Controls.Add(btnNewWorkflow);
            pnlWorkflowBar.Controls.Add(txtWorkflowSearch);
            pnlWorkflowBar.Controls.Add(lblWorkflowSearch);
            pnlWorkflowBar.Controls.Add(btnMoveWorkflowDown);
            pnlWorkflowBar.Controls.Add(btnMoveWorkflowUp);
            pnlWorkflowBar.Controls.Add(cmbWorkflows);
            pnlWorkflowBar.Controls.Add(lblWorkflowLabel);
            pnlWorkflowBar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlWorkflowBar.Location = new System.Drawing.Point(0, 52);
            pnlWorkflowBar.Name = "pnlWorkflowBar";
            pnlWorkflowBar.Size = new System.Drawing.Size(1240, 42);
            pnlWorkflowBar.TabIndex = 1;
            // 
            // btnDeleteWorkflow
            // 
            btnDeleteWorkflow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteWorkflow.BackColor = System.Drawing.Color.White;
            btnDeleteWorkflow.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDeleteWorkflow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeleteWorkflow.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnDeleteWorkflow.ForeColor = System.Drawing.Color.FromArgb(180, 40, 40);
            btnDeleteWorkflow.Location = new System.Drawing.Point(1135, 8);
            btnDeleteWorkflow.Name = "btnDeleteWorkflow";
            btnDeleteWorkflow.Size = new System.Drawing.Size(95, 26);
            btnDeleteWorkflow.TabIndex = 9;
            btnDeleteWorkflow.Text = "✕ Delete";
            btnDeleteWorkflow.UseVisualStyleBackColor = false;
            // 
            // btnDuplicateWorkflow
            // 
            btnDuplicateWorkflow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDuplicateWorkflow.BackColor = System.Drawing.Color.White;
            btnDuplicateWorkflow.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDuplicateWorkflow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDuplicateWorkflow.Font = new System.Drawing.Font("Segoe UI", 8F);
            btnDuplicateWorkflow.ForeColor = System.Drawing.Color.Black;
            btnDuplicateWorkflow.Location = new System.Drawing.Point(1035, 8);
            btnDuplicateWorkflow.Name = "btnDuplicateWorkflow";
            btnDuplicateWorkflow.Size = new System.Drawing.Size(95, 26);
            btnDuplicateWorkflow.TabIndex = 8;
            btnDuplicateWorkflow.Text = "Duplicate";
            btnDuplicateWorkflow.UseVisualStyleBackColor = false;
            // 
            // btnRenameWorkflow
            // 
            btnRenameWorkflow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRenameWorkflow.BackColor = System.Drawing.Color.White;
            btnRenameWorkflow.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRenameWorkflow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRenameWorkflow.Font = new System.Drawing.Font("Segoe UI", 8F);
            btnRenameWorkflow.ForeColor = System.Drawing.Color.Black;
            btnRenameWorkflow.Location = new System.Drawing.Point(945, 8);
            btnRenameWorkflow.Name = "btnRenameWorkflow";
            btnRenameWorkflow.Size = new System.Drawing.Size(85, 26);
            btnRenameWorkflow.TabIndex = 7;
            btnRenameWorkflow.Text = "Rename";
            btnRenameWorkflow.UseVisualStyleBackColor = false;
            // 
            // btnNewWorkflow
            // 
            btnNewWorkflow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewWorkflow.BackColor = System.Drawing.Color.Black;
            btnNewWorkflow.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNewWorkflow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNewWorkflow.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnNewWorkflow.ForeColor = System.Drawing.Color.White;
            btnNewWorkflow.Location = new System.Drawing.Point(810, 8);
            btnNewWorkflow.Name = "btnNewWorkflow";
            btnNewWorkflow.Size = new System.Drawing.Size(130, 26);
            btnNewWorkflow.TabIndex = 6;
            btnNewWorkflow.Text = "+ New Workflow";
            btnNewWorkflow.UseVisualStyleBackColor = false;
            // 
            // txtWorkflowSearch
            // 
            txtWorkflowSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtWorkflowSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            txtWorkflowSearch.Location = new System.Drawing.Point(475, 10);
            txtWorkflowSearch.Name = "txtWorkflowSearch";
            txtWorkflowSearch.PlaceholderText = "Search workflow...";
            txtWorkflowSearch.Size = new System.Drawing.Size(185, 23);
            txtWorkflowSearch.TabIndex = 5;
            // 
            // lblWorkflowSearch
            // 
            lblWorkflowSearch.AutoSize = true;
            lblWorkflowSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblWorkflowSearch.ForeColor = System.Drawing.Color.Black;
            lblWorkflowSearch.Location = new System.Drawing.Point(422, 14);
            lblWorkflowSearch.Name = "lblWorkflowSearch";
            lblWorkflowSearch.Size = new System.Drawing.Size(47, 13);
            lblWorkflowSearch.TabIndex = 4;
            lblWorkflowSearch.Text = "Search:";
            // 
            // btnMoveWorkflowDown
            // 
            btnMoveWorkflowDown.BackColor = System.Drawing.Color.White;
            btnMoveWorkflowDown.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMoveWorkflowDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMoveWorkflowDown.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnMoveWorkflowDown.ForeColor = System.Drawing.Color.Black;
            btnMoveWorkflowDown.Location = new System.Drawing.Point(375, 8);
            btnMoveWorkflowDown.Name = "btnMoveWorkflowDown";
            btnMoveWorkflowDown.Size = new System.Drawing.Size(32, 26);
            btnMoveWorkflowDown.TabIndex = 3;
            btnMoveWorkflowDown.Text = "▼";
            btnMoveWorkflowDown.UseVisualStyleBackColor = false;
            // 
            // btnMoveWorkflowUp
            // 
            btnMoveWorkflowUp.BackColor = System.Drawing.Color.White;
            btnMoveWorkflowUp.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMoveWorkflowUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMoveWorkflowUp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnMoveWorkflowUp.ForeColor = System.Drawing.Color.Black;
            btnMoveWorkflowUp.Location = new System.Drawing.Point(338, 8);
            btnMoveWorkflowUp.Name = "btnMoveWorkflowUp";
            btnMoveWorkflowUp.Size = new System.Drawing.Size(32, 26);
            btnMoveWorkflowUp.TabIndex = 2;
            btnMoveWorkflowUp.Text = "▲";
            btnMoveWorkflowUp.UseVisualStyleBackColor = false;
            // 
            // cmbWorkflows
            // 
            cmbWorkflows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbWorkflows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbWorkflows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            cmbWorkflows.FormattingEnabled = true;
            cmbWorkflows.Location = new System.Drawing.Point(105, 9);
            cmbWorkflows.Name = "cmbWorkflows";
            cmbWorkflows.Size = new System.Drawing.Size(225, 23);
            cmbWorkflows.TabIndex = 1;
            // 
            // lblWorkflowLabel
            // 
            lblWorkflowLabel.AutoSize = true;
            lblWorkflowLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblWorkflowLabel.ForeColor = System.Drawing.Color.Black;
            lblWorkflowLabel.Location = new System.Drawing.Point(15, 13);
            lblWorkflowLabel.Name = "lblWorkflowLabel";
            lblWorkflowLabel.Size = new System.Drawing.Size(81, 15);
            lblWorkflowLabel.TabIndex = 0;
            lblWorkflowLabel.Text = "WORKFLOW:";
            // 
            // pnlPagination
            // 
            pnlPagination.BackColor = System.Drawing.Color.WhiteSmoke;
            pnlPagination.Controls.Add(lblStepIndicator);
            pnlPagination.Controls.Add(btnPrevStep);
            pnlPagination.Controls.Add(btnNextStep);
            pnlPagination.Controls.Add(btnAddStep);
            pnlPagination.Controls.Add(btnAddSubStep);
            pnlPagination.Controls.Add(btnDeleteStep);
            pnlPagination.Controls.Add(flpPageButtons);
            pnlPagination.Dock = System.Windows.Forms.DockStyle.Top;
            pnlPagination.Location = new System.Drawing.Point(0, 94);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new System.Drawing.Size(1180, 75);
            pnlPagination.TabIndex = 2;
            // 
            // lblStepIndicator
            // 
            lblStepIndicator.AutoSize = true;
            lblStepIndicator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblStepIndicator.ForeColor = System.Drawing.Color.Black;
            lblStepIndicator.Location = new System.Drawing.Point(12, 10);
            lblStepIndicator.Name = "lblStepIndicator";
            lblStepIndicator.Size = new System.Drawing.Size(111, 15);
            lblStepIndicator.TabIndex = 0;
            lblStepIndicator.Text = "MAIN STEP 1 OF 1";
            // 
            // btnPrevStep
            // 
            btnPrevStep.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPrevStep.BackColor = System.Drawing.Color.White;
            btnPrevStep.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPrevStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrevStep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            btnPrevStep.ForeColor = System.Drawing.Color.Black;
            btnPrevStep.Location = new System.Drawing.Point(685, 5);
            btnPrevStep.Name = "btnPrevStep";
            btnPrevStep.Size = new System.Drawing.Size(75, 26);
            btnPrevStep.TabIndex = 1;
            btnPrevStep.Text = "< PREV";
            btnPrevStep.UseVisualStyleBackColor = false;
            // 
            // btnNextStep
            // 
            btnNextStep.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNextStep.BackColor = System.Drawing.Color.Black;
            btnNextStep.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNextStep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            btnNextStep.ForeColor = System.Drawing.Color.White;
            btnNextStep.Location = new System.Drawing.Point(765, 5);
            btnNextStep.Name = "btnNextStep";
            btnNextStep.Size = new System.Drawing.Size(75, 26);
            btnNextStep.TabIndex = 2;
            btnNextStep.Text = "NEXT >";
            btnNextStep.UseVisualStyleBackColor = false;
            // 
            // btnAddStep
            // 
            btnAddStep.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddStep.BackColor = System.Drawing.Color.Black;
            btnAddStep.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddStep.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddStep.ForeColor = System.Drawing.Color.White;
            btnAddStep.Location = new System.Drawing.Point(850, 5);
            btnAddStep.Name = "btnAddStep";
            btnAddStep.Size = new System.Drawing.Size(95, 26);
            btnAddStep.TabIndex = 3;
            btnAddStep.Text = "+ ADD STEP";
            btnAddStep.UseVisualStyleBackColor = false;
            // 
            // btnAddSubStep
            // 
            btnAddSubStep.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddSubStep.BackColor = System.Drawing.Color.White;
            btnAddSubStep.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddSubStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddSubStep.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddSubStep.ForeColor = System.Drawing.Color.DarkSlateBlue;
            btnAddSubStep.Location = new System.Drawing.Point(955, 5);
            btnAddSubStep.Name = "btnAddSubStep";
            btnAddSubStep.Size = new System.Drawing.Size(95, 26);
            btnAddSubStep.TabIndex = 4;
            btnAddSubStep.Text = "+ ADD SUB";
            btnAddSubStep.UseVisualStyleBackColor = false;
            // 
            // btnDeleteStep
            // 
            btnDeleteStep.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteStep.BackColor = System.Drawing.Color.White;
            btnDeleteStep.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDeleteStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeleteStep.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnDeleteStep.ForeColor = System.Drawing.Color.Crimson;
            btnDeleteStep.Location = new System.Drawing.Point(1060, 5);
            btnDeleteStep.Name = "btnDeleteStep";
            btnDeleteStep.Size = new System.Drawing.Size(105, 26);
            btnDeleteStep.TabIndex = 5;
            btnDeleteStep.Text = "✕ DEL STEP";
            btnDeleteStep.UseVisualStyleBackColor = false;
            // 
            // flpPageButtons
            // 
            flpPageButtons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flpPageButtons.AutoScroll = true;
            flpPageButtons.Location = new System.Drawing.Point(10, 36);
            flpPageButtons.Name = "flpPageButtons";
            flpPageButtons.Size = new System.Drawing.Size(1160, 34);
            flpPageButtons.TabIndex = 6;
            flpPageButtons.WrapContents = false;
            // 
            // tlpMainLayout
            // 
            tlpMainLayout.ColumnCount = 2;
            tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            tlpMainLayout.Controls.Add(gbImageConfig, 0, 0);
            tlpMainLayout.Controls.Add(gbActionConfig, 1, 0);
            tlpMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpMainLayout.Location = new System.Drawing.Point(0, 169);
            tlpMainLayout.Name = "tlpMainLayout";
            tlpMainLayout.Padding = new System.Windows.Forms.Padding(10);
            tlpMainLayout.RowCount = 1;
            tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpMainLayout.Size = new System.Drawing.Size(1180, 501);
            tlpMainLayout.TabIndex = 3;
            // 
            // gbImageConfig
            // 
            gbImageConfig.Controls.Add(lblImageNote);
            gbImageConfig.Controls.Add(btnClearImage);
            gbImageConfig.Controls.Add(txtImagePath);
            gbImageConfig.Controls.Add(lblImagePathTitle);
            gbImageConfig.Controls.Add(txtTemplateName);
            gbImageConfig.Controls.Add(lblTemplateName);
            gbImageConfig.Controls.Add(txtCaptureTitle);
            gbImageConfig.Controls.Add(lblCaptureTitle);
            gbImageConfig.Controls.Add(btnCaptureImage);
            gbImageConfig.Controls.Add(picPreview);
            gbImageConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            gbImageConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            gbImageConfig.ForeColor = System.Drawing.Color.Black;
            gbImageConfig.Location = new System.Drawing.Point(13, 13);
            gbImageConfig.Name = "gbImageConfig";
            gbImageConfig.Size = new System.Drawing.Size(414, 395);
            gbImageConfig.TabIndex = 0;
            gbImageConfig.TabStop = false;
            gbImageConfig.Text = " STEP 1 — IMAGE ANCHOR (OPTIONAL) ";
            // 
            // lblImageNote
            // 
            lblImageNote.AutoSize = true;
            lblImageNote.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            lblImageNote.ForeColor = System.Drawing.Color.DimGray;
            lblImageNote.Location = new System.Drawing.Point(15, 355);
            lblImageNote.Name = "lblImageNote";
            lblImageNote.Size = new System.Drawing.Size(400, 24);
            lblImageNote.TabIndex = 9;
            lblImageNote.Text = "* Note: Template image is optional. If blank, actions execute directly on the window.";
            // 
            // btnClearImage
            // 
            btnClearImage.BackColor = System.Drawing.Color.White;
            btnClearImage.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClearImage.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            btnClearImage.ForeColor = System.Drawing.Color.Crimson;
            btnClearImage.Location = new System.Drawing.Point(315, 178);
            btnClearImage.Name = "btnClearImage";
            btnClearImage.Size = new System.Drawing.Size(100, 28);
            btnClearImage.TabIndex = 8;
            btnClearImage.Text = "✕ Clear Image";
            btnClearImage.UseVisualStyleBackColor = false;
            // 
            // txtImagePath
            // 
            txtImagePath.BackColor = System.Drawing.Color.WhiteSmoke;
            txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtImagePath.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtImagePath.Location = new System.Drawing.Point(15, 322);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.ReadOnly = true;
            txtImagePath.Size = new System.Drawing.Size(400, 22);
            txtImagePath.TabIndex = 4;
            // 
            // lblImagePathTitle
            // 
            lblImagePathTitle.AutoSize = true;
            lblImagePathTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblImagePathTitle.Location = new System.Drawing.Point(15, 305);
            lblImagePathTitle.Name = "lblImagePathTitle";
            lblImagePathTitle.Size = new System.Drawing.Size(88, 13);
            lblImagePathTitle.TabIndex = 5;
            lblImagePathTitle.Text = "Image File Path:";
            // 
            // txtTemplateName
            // 
            txtTemplateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTemplateName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtTemplateName.Location = new System.Drawing.Point(15, 277);
            txtTemplateName.Name = "txtTemplateName";
            txtTemplateName.Size = new System.Drawing.Size(400, 22);
            txtTemplateName.TabIndex = 3;
            // 
            // lblTemplateName
            // 
            lblTemplateName.AutoSize = true;
            lblTemplateName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblTemplateName.Location = new System.Drawing.Point(15, 260);
            lblTemplateName.Name = "lblTemplateName";
            lblTemplateName.Size = new System.Drawing.Size(83, 13);
            lblTemplateName.TabIndex = 6;
            lblTemplateName.Text = "Step Identifier:";
            // 
            // txtCaptureTitle
            // 
            txtCaptureTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCaptureTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtCaptureTitle.Location = new System.Drawing.Point(15, 232);
            txtCaptureTitle.Name = "txtCaptureTitle";
            txtCaptureTitle.Size = new System.Drawing.Size(400, 22);
            txtCaptureTitle.TabIndex = 2;
            // 
            // lblCaptureTitle
            // 
            lblCaptureTitle.AutoSize = true;
            lblCaptureTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblCaptureTitle.Location = new System.Drawing.Point(15, 215);
            lblCaptureTitle.Name = "lblCaptureTitle";
            lblCaptureTitle.Size = new System.Drawing.Size(167, 13);
            lblCaptureTitle.TabIndex = 7;
            lblCaptureTitle.Text = "Capture Title (Dynamic Header):";
            // 
            // btnCaptureImage
            // 
            btnCaptureImage.BackColor = System.Drawing.Color.Black;
            btnCaptureImage.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCaptureImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCaptureImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            btnCaptureImage.ForeColor = System.Drawing.Color.White;
            btnCaptureImage.Location = new System.Drawing.Point(15, 178);
            btnCaptureImage.Name = "btnCaptureImage";
            btnCaptureImage.Size = new System.Drawing.Size(295, 28);
            btnCaptureImage.TabIndex = 1;
            btnCaptureImage.Text = "CAPTURE IMAGE ANCHOR";
            btnCaptureImage.UseVisualStyleBackColor = false;
            // 
            // picPreview
            // 
            picPreview.BackColor = System.Drawing.Color.White;
            picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            picPreview.Location = new System.Drawing.Point(15, 22);
            picPreview.Name = "picPreview";
            picPreview.Size = new System.Drawing.Size(400, 150);
            picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 0;
            picPreview.TabStop = false;
            // 
            // gbActionConfig
            // 
            gbActionConfig.Controls.Add(lblSpecialActionsHeader);
            gbActionConfig.Controls.Add(lblAutoLoginMode);
            gbActionConfig.Controls.Add(cmbAutoLoginMode);
            gbActionConfig.Controls.Add(btnAddAutoLoginAction);
            gbActionConfig.Controls.Add(btnAddClearMemoryAction);
            gbActionConfig.Controls.Add(lblControlFlowHeader);
            gbActionConfig.Controls.Add(btnAddBreakAction);
            gbActionConfig.Controls.Add(lblGotoTarget);
            gbActionConfig.Controls.Add(cmbGotoStep);
            gbActionConfig.Controls.Add(btnAddGotoAction);

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
            gbActionConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            gbActionConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            gbActionConfig.ForeColor = System.Drawing.Color.Black;
            gbActionConfig.Location = new System.Drawing.Point(433, 13);
            gbActionConfig.Name = "gbActionConfig";
            gbActionConfig.Size = new System.Drawing.Size(574, 395);
            gbActionConfig.TabIndex = 1;
            gbActionConfig.TabStop = false;
            gbActionConfig.Text = " LINEAR INPUT ACTIONS (MACRO SEQUENCE) ";
                        // 
            // lblControlFlowHeader
            // 
            lblControlFlowHeader.AutoSize = true;
            lblControlFlowHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblControlFlowHeader.ForeColor = System.Drawing.Color.Black;
            lblControlFlowHeader.Location = new System.Drawing.Point(15, 405);
            lblControlFlowHeader.Name = "lblControlFlowHeader";
            lblControlFlowHeader.Size = new System.Drawing.Size(198, 13);
            lblControlFlowHeader.TabIndex = 30;
            lblControlFlowHeader.Text = "Control Flow Actions (Break / Goto):";
            // 
            // btnAddBreakAction
            // 
            btnAddBreakAction.BackColor = System.Drawing.Color.Crimson;
            btnAddBreakAction.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddBreakAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddBreakAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddBreakAction.ForeColor = System.Drawing.Color.White;
            btnAddBreakAction.Location = new System.Drawing.Point(15, 425);
            btnAddBreakAction.Name = "btnAddBreakAction";
            btnAddBreakAction.Size = new System.Drawing.Size(160, 30);
            btnAddBreakAction.TabIndex = 31;
            btnAddBreakAction.Text = "🛑 + ADD BREAK";
            btnAddBreakAction.UseVisualStyleBackColor = false;
            // 
            // lblGotoTarget
            // 
            lblGotoTarget.AutoSize = true;
            lblGotoTarget.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblGotoTarget.Location = new System.Drawing.Point(190, 431);
            lblGotoTarget.Name = "lblGotoTarget";
            lblGotoTarget.Size = new System.Drawing.Size(68, 13);
            lblGotoTarget.TabIndex = 32;
            lblGotoTarget.Text = "Goto Target:";
            // 
            // cmbGotoStep
            // 
            cmbGotoStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbGotoStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbGotoStep.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            cmbGotoStep.FormattingEnabled = true;
            cmbGotoStep.Location = new System.Drawing.Point(265, 428);
            cmbGotoStep.Name = "cmbGotoStep";
            cmbGotoStep.Size = new System.Drawing.Size(235, 23);
            cmbGotoStep.TabIndex = 33;
            // 
            // btnAddGotoAction
            // 
            btnAddGotoAction.BackColor = System.Drawing.Color.Black;
            btnAddGotoAction.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddGotoAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddGotoAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddGotoAction.ForeColor = System.Drawing.Color.White;
            btnAddGotoAction.Location = new System.Drawing.Point(510, 425);
            btnAddGotoAction.Name = "btnAddGotoAction";
            btnAddGotoAction.Size = new System.Drawing.Size(165, 30);
            btnAddGotoAction.TabIndex = 34;
            btnAddGotoAction.Text = "↪ + ADD GOTO";
            btnAddGotoAction.UseVisualStyleBackColor = false;
            // 
            // lblSpecialActionsHeader
            // 
            lblSpecialActionsHeader.AutoSize = true;
            lblSpecialActionsHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblSpecialActionsHeader.ForeColor = System.Drawing.Color.Black;
            lblSpecialActionsHeader.Location = new System.Drawing.Point(15, 465);
            lblSpecialActionsHeader.Name = "lblSpecialActionsHeader";
            lblSpecialActionsHeader.Size = new System.Drawing.Size(265, 13);
            lblSpecialActionsHeader.TabIndex = 35;
            lblSpecialActionsHeader.Text = "Special Actions (Auto-Login / Memory Management):";
            // 
            // lblAutoLoginMode
            // 
            lblAutoLoginMode.AutoSize = true;
            lblAutoLoginMode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblAutoLoginMode.Location = new System.Drawing.Point(15, 492);
            lblAutoLoginMode.Name = "lblAutoLoginMode";
            lblAutoLoginMode.Size = new System.Drawing.Size(41, 13);
            lblAutoLoginMode.TabIndex = 36;
            lblAutoLoginMode.Text = "Mode:";
            // 
            // cmbAutoLoginMode
            // 
            cmbAutoLoginMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAutoLoginMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbAutoLoginMode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            cmbAutoLoginMode.FormattingEnabled = true;
            cmbAutoLoginMode.Items.AddRange(new object[] { "Standard Auto Login", "Auto Login + Create Character" });
            cmbAutoLoginMode.Location = new System.Drawing.Point(60, 488);
            cmbAutoLoginMode.Name = "cmbAutoLoginMode";
            cmbAutoLoginMode.Size = new System.Drawing.Size(200, 23);
            cmbAutoLoginMode.TabIndex = 37;
            // 
            // btnAddAutoLoginAction
            // 
            btnAddAutoLoginAction.BackColor = System.Drawing.Color.Black;
            btnAddAutoLoginAction.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddAutoLoginAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddAutoLoginAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddAutoLoginAction.ForeColor = System.Drawing.Color.White;
            btnAddAutoLoginAction.Location = new System.Drawing.Point(268, 485);
            btnAddAutoLoginAction.Name = "btnAddAutoLoginAction";
            btnAddAutoLoginAction.Size = new System.Drawing.Size(185, 30);
            btnAddAutoLoginAction.TabIndex = 38;
            btnAddAutoLoginAction.Text = "🔐 + ADD AUTO LOGIN";
            btnAddAutoLoginAction.UseVisualStyleBackColor = false;
            // 
            // btnAddClearMemoryAction
            // 
            btnAddClearMemoryAction.BackColor = System.Drawing.Color.FromArgb(40, 70, 110);
            btnAddClearMemoryAction.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddClearMemoryAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddClearMemoryAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddClearMemoryAction.ForeColor = System.Drawing.Color.White;
            btnAddClearMemoryAction.Location = new System.Drawing.Point(465, 485);
            btnAddClearMemoryAction.Name = "btnAddClearMemoryAction";
            btnAddClearMemoryAction.Size = new System.Drawing.Size(210, 30);
            btnAddClearMemoryAction.TabIndex = 39;
            btnAddClearMemoryAction.Text = "🧹 + CLEAR MEMORY (CURRENT)";
            btnAddClearMemoryAction.UseVisualStyleBackColor = false;
            // 
            // btnAddInputBoxAction
            //  
            btnAddInputBoxAction.BackColor = System.Drawing.Color.Black;
            btnAddInputBoxAction.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddInputBoxAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddInputBoxAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddInputBoxAction.ForeColor = System.Drawing.Color.White;
            btnAddInputBoxAction.Location = new System.Drawing.Point(510, 363);
            btnAddInputBoxAction.Name = "btnAddInputBoxAction";
            btnAddInputBoxAction.Size = new System.Drawing.Size(165, 28);
            btnAddInputBoxAction.TabIndex = 19;
            btnAddInputBoxAction.Text = "+ ADD PROMPT";
            btnAddInputBoxAction.UseVisualStyleBackColor = false;
            // 
            // txtInputBoxPrompt
            // 
            txtInputBoxPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtInputBoxPrompt.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtInputBoxPrompt.Location = new System.Drawing.Point(270, 365);
            txtInputBoxPrompt.Name = "txtInputBoxPrompt";
            txtInputBoxPrompt.Size = new System.Drawing.Size(230, 22);
            txtInputBoxPrompt.TabIndex = 18;
            txtInputBoxPrompt.Text = "Enter custom value:";
            // 
            // lblInputBoxHeader
            // 
            lblInputBoxHeader.AutoSize = true;
            lblInputBoxHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblInputBoxHeader.ForeColor = System.Drawing.Color.Black;
            lblInputBoxHeader.Location = new System.Drawing.Point(270, 345);
            lblInputBoxHeader.Name = "lblInputBoxHeader";
            lblInputBoxHeader.Size = new System.Drawing.Size(189, 13);
            lblInputBoxHeader.TabIndex = 20;
            lblInputBoxHeader.Text = "Message Input Box (Wait for User):";
            // 
            // btnAddDelayAction
            // 
            btnAddDelayAction.BackColor = System.Drawing.Color.Black;
            btnAddDelayAction.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddDelayAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddDelayAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddDelayAction.ForeColor = System.Drawing.Color.White;
            btnAddDelayAction.Location = new System.Drawing.Point(128, 363);
            btnAddDelayAction.Name = "btnAddDelayAction";
            btnAddDelayAction.Size = new System.Drawing.Size(130, 28);
            btnAddDelayAction.TabIndex = 17;
            btnAddDelayAction.Text = "+ ADD DELAY";
            btnAddDelayAction.UseVisualStyleBackColor = false;
            // 
            // lblMsUnit
            // 
            lblMsUnit.AutoSize = true;
            lblMsUnit.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblMsUnit.Location = new System.Drawing.Point(100, 369);
            lblMsUnit.Name = "lblMsUnit";
            lblMsUnit.Size = new System.Drawing.Size(21, 13);
            lblMsUnit.TabIndex = 21;
            lblMsUnit.Text = "ms";
            // 
            // numDelayMs
            // 
            numDelayMs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numDelayMs.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            numDelayMs.Increment = new decimal(new int[] { 250, 0, 0, 0 });
            numDelayMs.Location = new System.Drawing.Point(15, 365);
            numDelayMs.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numDelayMs.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            numDelayMs.Name = "numDelayMs";
            numDelayMs.Size = new System.Drawing.Size(80, 22);
            numDelayMs.TabIndex = 16;
            numDelayMs.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // lblDelayHeader
            // 
            lblDelayHeader.AutoSize = true;
            lblDelayHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblDelayHeader.ForeColor = System.Drawing.Color.Black;
            lblDelayHeader.Location = new System.Drawing.Point(15, 345);
            lblDelayHeader.Name = "lblDelayHeader";
            lblDelayHeader.Size = new System.Drawing.Size(81, 13);
            lblDelayHeader.TabIndex = 22;
            lblDelayHeader.Text = "Pause / Delay:";
            // 
            // btnAddKeyAction
            // 
            btnAddKeyAction.BackColor = System.Drawing.Color.Black;
            btnAddKeyAction.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddKeyAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddKeyAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddKeyAction.ForeColor = System.Drawing.Color.White;
            btnAddKeyAction.Location = new System.Drawing.Point(485, 307);
            btnAddKeyAction.Name = "btnAddKeyAction";
            btnAddKeyAction.Size = new System.Drawing.Size(190, 28);
            btnAddKeyAction.TabIndex = 15;
            btnAddKeyAction.Text = "+ ADD KEY ACTION";
            btnAddKeyAction.UseVisualStyleBackColor = false;
            // 
            // btnQuickEnter
            // 
            btnQuickEnter.BackColor = System.Drawing.Color.White;
            btnQuickEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            btnQuickEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQuickEnter.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnQuickEnter.Location = new System.Drawing.Point(390, 307);
            btnQuickEnter.Name = "btnQuickEnter";
            btnQuickEnter.Size = new System.Drawing.Size(85, 28);
            btnQuickEnter.TabIndex = 14;
            btnQuickEnter.Text = "+ {ENTER}";
            btnQuickEnter.UseVisualStyleBackColor = false;
            // 
            // btnQuickTab
            // 
            btnQuickTab.BackColor = System.Drawing.Color.White;
            btnQuickTab.Cursor = System.Windows.Forms.Cursors.Hand;
            btnQuickTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQuickTab.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnQuickTab.Location = new System.Drawing.Point(310, 307);
            btnQuickTab.Name = "btnQuickTab";
            btnQuickTab.Size = new System.Drawing.Size(75, 28);
            btnQuickTab.TabIndex = 13;
            btnQuickTab.Text = "+ {TAB}";
            btnQuickTab.UseVisualStyleBackColor = false;
            // 
            // btnVarNickname
            // 
            btnVarNickname.BackColor = System.Drawing.Color.White;
            btnVarNickname.Cursor = System.Windows.Forms.Cursors.Hand;
            btnVarNickname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVarNickname.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            btnVarNickname.ForeColor = System.Drawing.Color.Black;
            btnVarNickname.Location = new System.Drawing.Point(545, 279);
            btnVarNickname.Name = "btnVarNickname";
            btnVarNickname.Size = new System.Drawing.Size(130, 24);
            btnVarNickname.TabIndex = 28;
            btnVarNickname.Text = "+ {NICKNAME}";
            btnVarNickname.UseVisualStyleBackColor = false;
            // 
            // btnVarPin
            // 
            btnVarPin.BackColor = System.Drawing.Color.White;
            btnVarPin.Cursor = System.Windows.Forms.Cursors.Hand;
            btnVarPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVarPin.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            btnVarPin.ForeColor = System.Drawing.Color.Black;
            btnVarPin.Location = new System.Drawing.Point(420, 279);
            btnVarPin.Name = "btnVarPin";
            btnVarPin.Size = new System.Drawing.Size(120, 24);
            btnVarPin.TabIndex = 27;
            btnVarPin.Text = "+ {SECONDPASS}";
            btnVarPin.UseVisualStyleBackColor = false;
            // 
            // btnVarPassword
            // 
            btnVarPassword.BackColor = System.Drawing.Color.White;
            btnVarPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            btnVarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVarPassword.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            btnVarPassword.ForeColor = System.Drawing.Color.Black;
            btnVarPassword.Location = new System.Drawing.Point(305, 279);
            btnVarPassword.Name = "btnVarPassword";
            btnVarPassword.Size = new System.Drawing.Size(110, 24);
            btnVarPassword.TabIndex = 26;
            btnVarPassword.Text = "+ {PASSWORD}";
            btnVarPassword.UseVisualStyleBackColor = false;
            // 
            // btnVarUsername
            // 
            btnVarUsername.BackColor = System.Drawing.Color.White;
            btnVarUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            btnVarUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVarUsername.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            btnVarUsername.ForeColor = System.Drawing.Color.Black;
            btnVarUsername.Location = new System.Drawing.Point(190, 279);
            btnVarUsername.Name = "btnVarUsername";
            btnVarUsername.Size = new System.Drawing.Size(110, 24);
            btnVarUsername.TabIndex = 25;
            btnVarUsername.Text = "+ {USERNAME}";
            btnVarUsername.UseVisualStyleBackColor = false;
            // 
            // txtKeyboardWord
            // 
            txtKeyboardWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtKeyboardWord.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtKeyboardWord.Location = new System.Drawing.Point(55, 309);
            txtKeyboardWord.Name = "txtKeyboardWord";
            txtKeyboardWord.Size = new System.Drawing.Size(245, 22);
            txtKeyboardWord.TabIndex = 12;
            // 
            // lblKeyboardWord
            // 
            lblKeyboardWord.AutoSize = true;
            lblKeyboardWord.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblKeyboardWord.Location = new System.Drawing.Point(15, 312);
            lblKeyboardWord.Name = "lblKeyboardWord";
            lblKeyboardWord.Size = new System.Drawing.Size(32, 13);
            lblKeyboardWord.TabIndex = 23;
            lblKeyboardWord.Text = "Keys:";
            // 
            // lblKeyboardHeader
            // 
            lblKeyboardHeader.AutoSize = true;
            lblKeyboardHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblKeyboardHeader.ForeColor = System.Drawing.Color.Black;
            lblKeyboardHeader.Location = new System.Drawing.Point(15, 282);
            lblKeyboardHeader.Name = "lblKeyboardHeader";
            lblKeyboardHeader.Size = new System.Drawing.Size(152, 13);
            lblKeyboardHeader.TabIndex = 24;
            lblKeyboardHeader.Text = "Keyboard Input (SendKeys):";
            // 
            // btnAddMouseAction
            // 
            btnAddMouseAction.BackColor = System.Drawing.Color.Black;
            btnAddMouseAction.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddMouseAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddMouseAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnAddMouseAction.ForeColor = System.Drawing.Color.White;
            btnAddMouseAction.Location = new System.Drawing.Point(410, 245);
            btnAddMouseAction.Name = "btnAddMouseAction";
            btnAddMouseAction.Size = new System.Drawing.Size(265, 28);
            btnAddMouseAction.TabIndex = 11;
            btnAddMouseAction.Text = "+ ADD MOUSE ACTION";
            btnAddMouseAction.UseVisualStyleBackColor = false;
            // 
            // cmbClickType
            // 
            cmbClickType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbClickType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbClickType.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            cmbClickType.FormattingEnabled = true;
            cmbClickType.Items.AddRange(new object[] { "Single Left Click", "Double Left Click", "Single Right Click", "Hover Only" });
            cmbClickType.Location = new System.Drawing.Point(245, 247);
            cmbClickType.Name = "cmbClickType";
            cmbClickType.Size = new System.Drawing.Size(150, 22);
            cmbClickType.TabIndex = 10;
            // 
            // lblClickType
            // 
            lblClickType.AutoSize = true;
            lblClickType.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblClickType.Location = new System.Drawing.Point(205, 250);
            lblClickType.Name = "lblClickType";
            lblClickType.Size = new System.Drawing.Size(32, 13);
            lblClickType.TabIndex = 25;
            lblClickType.Text = "Type:";
            // 
            // numCoordY
            // 
            numCoordY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numCoordY.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            numCoordY.Location = new System.Drawing.Point(130, 247);
            numCoordY.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numCoordY.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            numCoordY.Name = "numCoordY";
            numCoordY.Size = new System.Drawing.Size(65, 22);
            numCoordY.TabIndex = 9;
            // 
            // lblYCoord
            // 
            lblYCoord.AutoSize = true;
            lblYCoord.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblYCoord.Location = new System.Drawing.Point(110, 250);
            lblYCoord.Name = "lblYCoord";
            lblYCoord.Size = new System.Drawing.Size(15, 13);
            lblYCoord.TabIndex = 26;
            lblYCoord.Text = "Y:";
            // 
            // numCoordX
            // 
            numCoordX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numCoordX.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            numCoordX.Location = new System.Drawing.Point(35, 247);
            numCoordX.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numCoordX.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            numCoordX.Name = "numCoordX";
            numCoordX.Size = new System.Drawing.Size(65, 22);
            numCoordX.TabIndex = 8;
            // 
            // lblXCoord
            // 
            lblXCoord.AutoSize = true;
            lblXCoord.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblXCoord.Location = new System.Drawing.Point(15, 250);
            lblXCoord.Name = "lblXCoord";
            lblXCoord.Size = new System.Drawing.Size(16, 13);
            lblXCoord.TabIndex = 27;
            lblXCoord.Text = "X:";
            // 
            // chkUseRelativeOffset
            // 
            chkUseRelativeOffset.AutoSize = true;
            chkUseRelativeOffset.Checked = true;
            chkUseRelativeOffset.CheckState = System.Windows.Forms.CheckState.Checked;
            chkUseRelativeOffset.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            chkUseRelativeOffset.Location = new System.Drawing.Point(255, 217);
            chkUseRelativeOffset.Name = "chkUseRelativeOffset";
            chkUseRelativeOffset.Size = new System.Drawing.Size(244, 17);
            chkUseRelativeOffset.TabIndex = 7;
            chkUseRelativeOffset.Text = "Use coordinates relative to matched image";
            chkUseRelativeOffset.UseVisualStyleBackColor = true;
            // 
            // btnCaptureCoords
            // 
            btnCaptureCoords.BackColor = System.Drawing.Color.Black;
            btnCaptureCoords.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCaptureCoords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCaptureCoords.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnCaptureCoords.ForeColor = System.Drawing.Color.White;
            btnCaptureCoords.Location = new System.Drawing.Point(15, 212);
            btnCaptureCoords.Name = "btnCaptureCoords";
            btnCaptureCoords.Size = new System.Drawing.Size(230, 28);
            btnCaptureCoords.TabIndex = 6;
            btnCaptureCoords.Text = "CAPTURE SCREEN COORD";
            btnCaptureCoords.UseVisualStyleBackColor = false;
            // 
            // lblMouseHeader
            // 
            lblMouseHeader.AutoSize = true;
            lblMouseHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblMouseHeader.ForeColor = System.Drawing.Color.Black;
            lblMouseHeader.Location = new System.Drawing.Point(15, 192);
            lblMouseHeader.Name = "lblMouseHeader";
            lblMouseHeader.Size = new System.Drawing.Size(128, 13);
            lblMouseHeader.TabIndex = 28;
            lblMouseHeader.Text = "Mouse Action Settings:";
            // 
            // btnUpdateSelected
            // 
            btnUpdateSelected.BackColor = System.Drawing.Color.White;
            btnUpdateSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            btnUpdateSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUpdateSelected.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnUpdateSelected.ForeColor = System.Drawing.Color.DarkSlateGray;
            btnUpdateSelected.Location = new System.Drawing.Point(485, 156);
            btnUpdateSelected.Name = "btnUpdateSelected";
            btnUpdateSelected.Size = new System.Drawing.Size(190, 28);
            btnUpdateSelected.TabIndex = 5;
            btnUpdateSelected.Text = "✎ Update Selected";
            btnUpdateSelected.UseVisualStyleBackColor = false;
            // 
            // btnClearActions
            // 
            btnClearActions.BackColor = System.Drawing.Color.White;
            btnClearActions.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClearActions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClearActions.Font = new System.Drawing.Font("Segoe UI", 8F);
            btnClearActions.Location = new System.Drawing.Point(290, 156);
            btnClearActions.Name = "btnClearActions";
            btnClearActions.Size = new System.Drawing.Size(85, 28);
            btnClearActions.TabIndex = 4;
            btnClearActions.Text = "Clear All";
            btnClearActions.UseVisualStyleBackColor = false;
            // 
            // btnRemoveAction
            // 
            btnRemoveAction.BackColor = System.Drawing.Color.White;
            btnRemoveAction.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRemoveAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRemoveAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnRemoveAction.ForeColor = System.Drawing.Color.Crimson;
            btnRemoveAction.Location = new System.Drawing.Point(190, 156);
            btnRemoveAction.Name = "btnRemoveAction";
            btnRemoveAction.Size = new System.Drawing.Size(95, 28);
            btnRemoveAction.TabIndex = 3;
            btnRemoveAction.Text = "✕ Remove";
            btnRemoveAction.UseVisualStyleBackColor = false;
            // 
            // btnMoveDown
            // 
            btnMoveDown.BackColor = System.Drawing.Color.White;
            btnMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMoveDown.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnMoveDown.Location = new System.Drawing.Point(100, 156);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new System.Drawing.Size(85, 28);
            btnMoveDown.TabIndex = 2;
            btnMoveDown.Text = "▼ Down";
            btnMoveDown.UseVisualStyleBackColor = false;
            // 
            // btnMoveUp
            // 
            btnMoveUp.BackColor = System.Drawing.Color.White;
            btnMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMoveUp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnMoveUp.Location = new System.Drawing.Point(15, 156);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new System.Drawing.Size(80, 28);
            btnMoveUp.TabIndex = 1;
            btnMoveUp.Text = "▲ Up";
            btnMoveUp.UseVisualStyleBackColor = false;
            // 
            // lstActions
            // 
            lstActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstActions.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lstActions.FormattingEnabled = true;
            lstActions.IntegralHeight = false;
            lstActions.Location = new System.Drawing.Point(15, 37);
            lstActions.Name = "lstActions";
            lstActions.Size = new System.Drawing.Size(660, 115);
            lstActions.TabIndex = 0;
            // 
            // lblActionList
            // 
            lblActionList.AutoSize = true;
            lblActionList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblActionList.Location = new System.Drawing.Point(15, 20);
            lblActionList.Name = "lblActionList";
            lblActionList.Size = new System.Drawing.Size(230, 13);
            lblActionList.TabIndex = 29;
            lblActionList.Text = "Linear Action Order (Executed in sequence):";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            pnlFooter.Controls.Add(btnTestExecution);
            pnlFooter.Controls.Add(btnCancel);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlFooter.Location = new System.Drawing.Point(0, 670);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new System.Drawing.Size(1180, 50);
            pnlFooter.TabIndex = 4;
            // 
            // btnTestExecution
            // 
            btnTestExecution.BackColor = System.Drawing.Color.White;
            btnTestExecution.Cursor = System.Windows.Forms.Cursors.Hand;
            btnTestExecution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTestExecution.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            btnTestExecution.ForeColor = System.Drawing.Color.Black;
            btnTestExecution.Location = new System.Drawing.Point(12, 10);
            btnTestExecution.Name = "btnTestExecution";
            btnTestExecution.Size = new System.Drawing.Size(180, 30);
            btnTestExecution.TabIndex = 2;
            btnTestExecution.Text = "TEST CURRENT STEP";
            btnTestExecution.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.BackColor = System.Drawing.Color.White;
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            btnCancel.ForeColor = System.Drawing.Color.Black;
            btnCancel.Location = new System.Drawing.Point(960, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(95, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.BackColor = System.Drawing.Color.Black;
            btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(1065, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(100, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "SAVE ALL";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // BulkMacroSettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1240, 780);
            Controls.Add(tlpMainLayout);
            Controls.Add(pnlFooter);
            Controls.Add(pnlPagination);
            Controls.Add(pnlWorkflowBar);
            Controls.Add(pnlHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BulkMacroSettingsForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ProcessForge — Bulk Workflow Macro Builder";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlWorkflowBar.ResumeLayout(false);
            pnlWorkflowBar.PerformLayout();
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
