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
        private System.Windows.Forms.Label lblKeyboardWord;
        private System.Windows.Forms.TextBox txtKeyboardWord;
        private System.Windows.Forms.Button btnQuickTab;
        private System.Windows.Forms.Button btnQuickEnter;
        private System.Windows.Forms.Button btnAddKeyAction;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnPrevStep = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.lblStepIndicator = new System.Windows.Forms.Label();
            this.flpPageButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddSubStep = new System.Windows.Forms.Button();
            this.btnDeleteSubStep = new System.Windows.Forms.Button();
            this.tlpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gbImageConfig = new System.Windows.Forms.GroupBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnCaptureImage = new System.Windows.Forms.Button();
            this.lblCaptureTitle = new System.Windows.Forms.Label();
            this.txtCaptureTitle = new System.Windows.Forms.TextBox();
            this.lblTemplateName = new System.Windows.Forms.Label();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.lblImagePathTitle = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.gbActionConfig = new System.Windows.Forms.GroupBox();
            this.lblActionList = new System.Windows.Forms.Label();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnRemoveAction = new System.Windows.Forms.Button();
            this.btnClearActions = new System.Windows.Forms.Button();
            this.btnUpdateSelected = new System.Windows.Forms.Button();
            this.lblMouseHeader = new System.Windows.Forms.Label();
            this.btnCaptureCoords = new System.Windows.Forms.Button();
            this.chkUseRelativeOffset = new System.Windows.Forms.CheckBox();
            this.lblXCoord = new System.Windows.Forms.Label();
            this.numCoordX = new System.Windows.Forms.NumericUpDown();
            this.lblYCoord = new System.Windows.Forms.Label();
            this.numCoordY = new System.Windows.Forms.NumericUpDown();
            this.lblClickType = new System.Windows.Forms.Label();
            this.cmbClickType = new System.Windows.Forms.ComboBox();
            this.btnAddMouseAction = new System.Windows.Forms.Button();
            this.lblKeyboardHeader = new System.Windows.Forms.Label();
            this.lblKeyboardWord = new System.Windows.Forms.Label();
            this.txtKeyboardWord = new System.Windows.Forms.TextBox();
            this.btnQuickTab = new System.Windows.Forms.Button();
            this.btnQuickEnter = new System.Windows.Forms.Button();
            this.btnAddKeyAction = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnTestExecution = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlPagination.SuspendLayout();
            this.tlpMainLayout.SuspendLayout();
            this.gbImageConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.gbActionConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoordX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoordY)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // Header Panel
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Black;
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 55);
            this.pnlHeader.TabIndex = 0;

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(16, 8);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(262, 20);
            this.lblHeaderTitle.Text = "AUTO-LOGIN WORKFLOW BUILDER";

            // lblHeaderSubtitle
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(17, 30);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(550, 13);
            this.lblHeaderSubtitle.Text = "Capture image anchor and configure linear input macro sequence per step (Main Steps 1-5 & Custom Sub-Steps).";

            // 
            // Pagination Bar
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPagination.Controls.Add(this.btnNextStep);
            this.pnlPagination.Controls.Add(this.btnDeleteSubStep);
            this.pnlPagination.Controls.Add(this.btnAddSubStep);
            this.pnlPagination.Controls.Add(this.flpPageButtons);
            this.pnlPagination.Controls.Add(this.lblStepIndicator);
            this.pnlPagination.Controls.Add(this.btnPrevStep);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPagination.Location = new System.Drawing.Point(0, 55);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1000, 50);
            this.pnlPagination.TabIndex = 1;

            // btnPrevStep
            this.btnPrevStep.BackColor = System.Drawing.Color.White;
            this.btnPrevStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevStep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrevStep.ForeColor = System.Drawing.Color.Black;
            this.btnPrevStep.Location = new System.Drawing.Point(10, 10);
            this.btnPrevStep.Name = "btnPrevStep";
            this.btnPrevStep.Size = new System.Drawing.Size(65, 30);
            this.btnPrevStep.TabIndex = 0;
            this.btnPrevStep.Text = "< PREV";
            this.btnPrevStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrevStep.UseVisualStyleBackColor = false;

            // lblStepIndicator
            this.lblStepIndicator.AutoSize = true;
            this.lblStepIndicator.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStepIndicator.ForeColor = System.Drawing.Color.Black;
            this.lblStepIndicator.Location = new System.Drawing.Point(78, 17);
            this.lblStepIndicator.Name = "lblStepIndicator";
            this.lblStepIndicator.Size = new System.Drawing.Size(125, 15);
            this.lblStepIndicator.Text = "MAIN STEP 1 OF 5";

            // flpPageButtons
            this.flpPageButtons.AutoScroll = true;
            this.flpPageButtons.WrapContents = false;
            this.flpPageButtons.Location = new System.Drawing.Point(215, 6);
            this.flpPageButtons.Name = "flpPageButtons";
            this.flpPageButtons.Size = new System.Drawing.Size(530, 38);
            this.flpPageButtons.TabIndex = 1;

            // btnAddSubStep
            this.btnAddSubStep.BackColor = System.Drawing.Color.Black;
            this.btnAddSubStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSubStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubStep.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddSubStep.ForeColor = System.Drawing.Color.White;
            this.btnAddSubStep.Location = new System.Drawing.Point(755, 10);
            this.btnAddSubStep.Name = "btnAddSubStep";
            this.btnAddSubStep.Size = new System.Drawing.Size(85, 30);
            this.btnAddSubStep.TabIndex = 2;
            this.btnAddSubStep.Text = "+ ADD SUB";
            this.btnAddSubStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddSubStep.UseVisualStyleBackColor = false;

            // btnDeleteSubStep
            this.btnDeleteSubStep.BackColor = System.Drawing.Color.White;
            this.btnDeleteSubStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSubStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSubStep.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteSubStep.ForeColor = System.Drawing.Color.Crimson;
            this.btnDeleteSubStep.Location = new System.Drawing.Point(845, 10);
            this.btnDeleteSubStep.Name = "btnDeleteSubStep";
            this.btnDeleteSubStep.Size = new System.Drawing.Size(75, 30);
            this.btnDeleteSubStep.TabIndex = 3;
            this.btnDeleteSubStep.Text = "✕ DEL SUB";
            this.btnDeleteSubStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteSubStep.UseVisualStyleBackColor = false;

            // btnNextStep
            this.btnNextStep.BackColor = System.Drawing.Color.Black;
            this.btnNextStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNextStep.ForeColor = System.Drawing.Color.White;
            this.btnNextStep.Location = new System.Drawing.Point(925, 10);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(65, 30);
            this.btnNextStep.TabIndex = 4;
            this.btnNextStep.Text = "NEXT >";
            this.btnNextStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNextStep.UseVisualStyleBackColor = false;

            // 
            // Main Layout
            // 
            this.tlpMainLayout.ColumnCount = 2;
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpMainLayout.Controls.Add(this.gbImageConfig, 0, 0);
            this.tlpMainLayout.Controls.Add(this.gbActionConfig, 1, 0);
            this.tlpMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainLayout.Location = new System.Drawing.Point(0, 105);
            this.tlpMainLayout.Name = "tlpMainLayout";
            this.tlpMainLayout.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMainLayout.RowCount = 1;
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.Size = new System.Drawing.Size(1000, 425);
            this.tlpMainLayout.TabIndex = 2;

            // 
            // GroupBox: Image Anchor
            // 
            this.gbImageConfig.Controls.Add(this.txtImagePath);
            this.gbImageConfig.Controls.Add(this.lblImagePathTitle);
            this.gbImageConfig.Controls.Add(this.txtTemplateName);
            this.gbImageConfig.Controls.Add(this.lblTemplateName);
            this.gbImageConfig.Controls.Add(this.txtCaptureTitle);
            this.gbImageConfig.Controls.Add(this.lblCaptureTitle);
            this.gbImageConfig.Controls.Add(this.btnCaptureImage);
            this.gbImageConfig.Controls.Add(this.picPreview);
            this.gbImageConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImageConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbImageConfig.ForeColor = System.Drawing.Color.Black;
            this.gbImageConfig.Location = new System.Drawing.Point(13, 13);
            this.gbImageConfig.Name = "gbImageConfig";
            this.gbImageConfig.Size = new System.Drawing.Size(395, 401);
            this.gbImageConfig.TabIndex = 0;
            this.gbImageConfig.TabStop = false;
            this.gbImageConfig.Text = " CAPTURE - CHOOSE SERVER ";

            // picPreview
            this.picPreview.BackColor = System.Drawing.Color.White;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picPreview.Location = new System.Drawing.Point(15, 22);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(365, 155);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;

            // btnCaptureImage
            this.btnCaptureImage.BackColor = System.Drawing.Color.Black;
            this.btnCaptureImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaptureImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaptureImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCaptureImage.ForeColor = System.Drawing.Color.White;
            this.btnCaptureImage.Location = new System.Drawing.Point(15, 185);
            this.btnCaptureImage.Name = "btnCaptureImage";
            this.btnCaptureImage.Size = new System.Drawing.Size(365, 30);
            this.btnCaptureImage.TabIndex = 1;
            this.btnCaptureImage.Text = "CAPTURE IMAGE FOR THIS STEP";
            this.btnCaptureImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCaptureImage.UseVisualStyleBackColor = false;

            // lblCaptureTitle
            this.lblCaptureTitle.AutoSize = true;
            this.lblCaptureTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCaptureTitle.Location = new System.Drawing.Point(15, 222);
            this.lblCaptureTitle.Name = "lblCaptureTitle";
            this.lblCaptureTitle.Size = new System.Drawing.Size(160, 13);
            this.lblCaptureTitle.Text = "Capture Title (Dynamic Header):";

            // txtCaptureTitle
            this.txtCaptureTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaptureTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCaptureTitle.Location = new System.Drawing.Point(15, 239);
            this.txtCaptureTitle.Name = "txtCaptureTitle";
            this.txtCaptureTitle.Size = new System.Drawing.Size(365, 22);
            this.txtCaptureTitle.TabIndex = 2;

            // lblTemplateName
            this.lblTemplateName.AutoSize = true;
            this.lblTemplateName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTemplateName.Location = new System.Drawing.Point(15, 267);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(81, 13);
            this.lblTemplateName.Text = "Step Identifier:";

            // txtTemplateName
            this.txtTemplateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTemplateName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTemplateName.Location = new System.Drawing.Point(15, 284);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(365, 22);
            this.txtTemplateName.TabIndex = 3;

            // lblImagePathTitle
            this.lblImagePathTitle.AutoSize = true;
            this.lblImagePathTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImagePathTitle.Location = new System.Drawing.Point(15, 312);
            this.lblImagePathTitle.Name = "lblImagePathTitle";
            this.lblImagePathTitle.Size = new System.Drawing.Size(88, 13);
            this.lblImagePathTitle.Text = "Image File Path:";

            // txtImagePath
            this.txtImagePath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImagePath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtImagePath.Location = new System.Drawing.Point(15, 329);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(365, 22);
            this.txtImagePath.TabIndex = 4;

            // 
            // GroupBox: Linear Input Actions
            // 
            this.gbActionConfig.Controls.Add(this.btnAddKeyAction);
            this.gbActionConfig.Controls.Add(this.btnQuickEnter);
            this.gbActionConfig.Controls.Add(this.btnQuickTab);
            this.gbActionConfig.Controls.Add(this.txtKeyboardWord);
            this.gbActionConfig.Controls.Add(this.lblKeyboardWord);
            this.gbActionConfig.Controls.Add(this.lblKeyboardHeader);
            this.gbActionConfig.Controls.Add(this.btnAddMouseAction);
            this.gbActionConfig.Controls.Add(this.cmbClickType);
            this.gbActionConfig.Controls.Add(this.lblClickType);
            this.gbActionConfig.Controls.Add(this.numCoordY);
            this.gbActionConfig.Controls.Add(this.lblYCoord);
            this.gbActionConfig.Controls.Add(this.numCoordX);
            this.gbActionConfig.Controls.Add(this.lblXCoord);
            this.gbActionConfig.Controls.Add(this.chkUseRelativeOffset);
            this.gbActionConfig.Controls.Add(this.btnCaptureCoords);
            this.gbActionConfig.Controls.Add(this.lblMouseHeader);
            this.gbActionConfig.Controls.Add(this.btnUpdateSelected);
            this.gbActionConfig.Controls.Add(this.btnClearActions);
            this.gbActionConfig.Controls.Add(this.btnRemoveAction);
            this.gbActionConfig.Controls.Add(this.btnMoveDown);
            this.gbActionConfig.Controls.Add(this.btnMoveUp);
            this.gbActionConfig.Controls.Add(this.lstActions);
            this.gbActionConfig.Controls.Add(this.lblActionList);
            this.gbActionConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbActionConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbActionConfig.ForeColor = System.Drawing.Color.Black;
            this.gbActionConfig.Location = new System.Drawing.Point(414, 13);
            this.gbActionConfig.Name = "gbActionConfig";
            this.gbActionConfig.Size = new System.Drawing.Size(573, 401);
            this.gbActionConfig.TabIndex = 1;
            this.gbActionConfig.TabStop = false;
            this.gbActionConfig.Text = " LINEAR INPUT ACTIONS (MACRO SEQUENCE) ";

            // lblActionList
            this.lblActionList.AutoSize = true;
            this.lblActionList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblActionList.Location = new System.Drawing.Point(15, 20);
            this.lblActionList.Name = "lblActionList";
            this.lblActionList.Size = new System.Drawing.Size(232, 13);
            this.lblActionList.Text = "Linear Action Order (Executed in sequence):";

            // lstActions
            this.lstActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstActions.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstActions.FormattingEnabled = true;
            this.lstActions.IntegralHeight = false;
            this.lstActions.ItemHeight = 15;
            this.lstActions.Location = new System.Drawing.Point(15, 37);
            this.lstActions.Name = "lstActions";
            this.lstActions.Size = new System.Drawing.Size(540, 110);
            this.lstActions.TabIndex = 0;

            // btnMoveUp
            this.btnMoveUp.BackColor = System.Drawing.Color.White;
            this.btnMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMoveUp.Location = new System.Drawing.Point(15, 153);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 26);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.Text = "▲ Up";
            this.btnMoveUp.UseVisualStyleBackColor = false;

            // btnMoveDown
            this.btnMoveDown.BackColor = System.Drawing.Color.White;
            this.btnMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMoveDown.Location = new System.Drawing.Point(95, 153);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 26);
            this.btnMoveDown.TabIndex = 2;
            this.btnMoveDown.Text = "▼ Down";
            this.btnMoveDown.UseVisualStyleBackColor = false;

            // btnRemoveAction
            this.btnRemoveAction.BackColor = System.Drawing.Color.White;
            this.btnRemoveAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveAction.ForeColor = System.Drawing.Color.Crimson;
            this.btnRemoveAction.Location = new System.Drawing.Point(175, 153);
            this.btnRemoveAction.Name = "btnRemoveAction";
            this.btnRemoveAction.Size = new System.Drawing.Size(85, 26);
            this.btnRemoveAction.TabIndex = 3;
            this.btnRemoveAction.Text = "✕ Remove";
            this.btnRemoveAction.UseVisualStyleBackColor = false;

            // btnClearActions
            this.btnClearActions.BackColor = System.Drawing.Color.White;
            this.btnClearActions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearActions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearActions.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearActions.Location = new System.Drawing.Point(265, 153);
            this.btnClearActions.Name = "btnClearActions";
            this.btnClearActions.Size = new System.Drawing.Size(75, 26);
            this.btnClearActions.TabIndex = 4;
            this.btnClearActions.Text = "Clear All";
            this.btnClearActions.UseVisualStyleBackColor = false;

            // btnUpdateSelected
            this.btnUpdateSelected.BackColor = System.Drawing.Color.White;
            this.btnUpdateSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSelected.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateSelected.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpdateSelected.Location = new System.Drawing.Point(395, 153);
            this.btnUpdateSelected.Name = "btnUpdateSelected";
            this.btnUpdateSelected.Size = new System.Drawing.Size(160, 26);
            this.btnUpdateSelected.TabIndex = 5;
            this.btnUpdateSelected.Text = "✎ Update Selected";
            this.btnUpdateSelected.UseVisualStyleBackColor = false;

            // lblMouseHeader
            this.lblMouseHeader.AutoSize = true;
            this.lblMouseHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMouseHeader.ForeColor = System.Drawing.Color.Black;
            this.lblMouseHeader.Location = new System.Drawing.Point(15, 188);
            this.lblMouseHeader.Name = "lblMouseHeader";
            this.lblMouseHeader.Size = new System.Drawing.Size(130, 13);
            this.lblMouseHeader.Text = "Mouse Action Settings:";

            // btnCaptureCoords
            this.btnCaptureCoords.BackColor = System.Drawing.Color.Black;
            this.btnCaptureCoords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaptureCoords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaptureCoords.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCaptureCoords.ForeColor = System.Drawing.Color.White;
            this.btnCaptureCoords.Location = new System.Drawing.Point(15, 206);
            this.btnCaptureCoords.Name = "btnCaptureCoords";
            this.btnCaptureCoords.Size = new System.Drawing.Size(225, 26);
            this.btnCaptureCoords.TabIndex = 6;
            this.btnCaptureCoords.Text = "CAPTURE SCREEN COORD";
            this.btnCaptureCoords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCaptureCoords.UseVisualStyleBackColor = false;

            // chkUseRelativeOffset
            this.chkUseRelativeOffset.AutoSize = true;
            this.chkUseRelativeOffset.Checked = true;
            this.chkUseRelativeOffset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseRelativeOffset.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkUseRelativeOffset.Location = new System.Drawing.Point(250, 211);
            this.chkUseRelativeOffset.Name = "chkUseRelativeOffset";
            this.chkUseRelativeOffset.Size = new System.Drawing.Size(252, 17);
            this.chkUseRelativeOffset.TabIndex = 7;
            this.chkUseRelativeOffset.Text = "Use coordinates relative to matched image";
            this.chkUseRelativeOffset.UseVisualStyleBackColor = true;

            // lblXCoord
            this.lblXCoord.AutoSize = true;
            this.lblXCoord.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblXCoord.Location = new System.Drawing.Point(15, 241);
            this.lblXCoord.Name = "lblXCoord";
            this.lblXCoord.Size = new System.Drawing.Size(16, 13);
            this.lblXCoord.Text = "X:";

            // numCoordX
            this.numCoordX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCoordX.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numCoordX.Location = new System.Drawing.Point(34, 238);
            this.numCoordX.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numCoordX.Minimum = new decimal(new int[] { 9999, 0, 0, -2147483648 });
            this.numCoordX.Name = "numCoordX";
            this.numCoordX.Size = new System.Drawing.Size(65, 22);
            this.numCoordX.TabIndex = 8;

            // lblYCoord
            this.lblYCoord.AutoSize = true;
            this.lblYCoord.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblYCoord.Location = new System.Drawing.Point(105, 241);
            this.lblYCoord.Name = "lblYCoord";
            this.lblYCoord.Size = new System.Drawing.Size(15, 13);
            this.lblYCoord.Text = "Y:";

            // numCoordY
            this.numCoordY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCoordY.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numCoordY.Location = new System.Drawing.Point(123, 238);
            this.numCoordY.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numCoordY.Minimum = new decimal(new int[] { 9999, 0, 0, -2147483648 });
            this.numCoordY.Name = "numCoordY";
            this.numCoordY.Size = new System.Drawing.Size(65, 22);
            this.numCoordY.TabIndex = 9;

            // lblClickType
            this.lblClickType.AutoSize = true;
            this.lblClickType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClickType.Location = new System.Drawing.Point(195, 241);
            this.lblClickType.Name = "lblClickType";
            this.lblClickType.Size = new System.Drawing.Size(33, 13);
            this.lblClickType.Text = "Type:";

            // cmbClickType
            this.cmbClickType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClickType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClickType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbClickType.FormattingEnabled = true;
            this.cmbClickType.Items.AddRange(new object[] {
            "Single Left Click",
            "Double Left Click",
            "Single Right Click",
            "Hover Only"});
            this.cmbClickType.Location = new System.Drawing.Point(232, 238);
            this.cmbClickType.Name = "cmbClickType";
            this.cmbClickType.Size = new System.Drawing.Size(140, 21);
            this.cmbClickType.SelectedIndex = 0;
            this.cmbClickType.TabIndex = 10;

            // btnAddMouseAction
            this.btnAddMouseAction.BackColor = System.Drawing.Color.Black;
            this.btnAddMouseAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMouseAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMouseAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddMouseAction.ForeColor = System.Drawing.Color.White;
            this.btnAddMouseAction.Location = new System.Drawing.Point(380, 236);
            this.btnAddMouseAction.Name = "btnAddMouseAction";
            this.btnAddMouseAction.Size = new System.Drawing.Size(175, 26);
            this.btnAddMouseAction.TabIndex = 11;
            this.btnAddMouseAction.Text = "+ ADD MOUSE ACTION";
            this.btnAddMouseAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddMouseAction.UseVisualStyleBackColor = false;

            // lblKeyboardHeader
            this.lblKeyboardHeader.AutoSize = true;
            this.lblKeyboardHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKeyboardHeader.ForeColor = System.Drawing.Color.Black;
            this.lblKeyboardHeader.Location = new System.Drawing.Point(15, 275);
            this.lblKeyboardHeader.Name = "lblKeyboardHeader";
            this.lblKeyboardHeader.Size = new System.Drawing.Size(155, 13);
            this.lblKeyboardHeader.Text = "Keyboard Input (SendKeys):";

            // lblKeyboardWord
            this.lblKeyboardWord.AutoSize = true;
            this.lblKeyboardWord.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKeyboardWord.Location = new System.Drawing.Point(15, 298);
            this.lblKeyboardWord.Name = "lblKeyboardWord";
            this.lblKeyboardWord.Size = new System.Drawing.Size(33, 13);
            this.lblKeyboardWord.Text = "Keys:";

            // txtKeyboardWord
            this.txtKeyboardWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKeyboardWord.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtKeyboardWord.Location = new System.Drawing.Point(52, 295);
            this.txtKeyboardWord.Name = "txtKeyboardWord";
            this.txtKeyboardWord.Size = new System.Drawing.Size(205, 22);
            this.txtKeyboardWord.TabIndex = 12;

            // btnQuickTab
            this.btnQuickTab.BackColor = System.Drawing.Color.White;
            this.btnQuickTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickTab.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuickTab.Location = new System.Drawing.Point(264, 293);
            this.btnQuickTab.Name = "btnQuickTab";
            this.btnQuickTab.Size = new System.Drawing.Size(65, 26);
            this.btnQuickTab.TabIndex = 13;
            this.btnQuickTab.Text = "+ {TAB}";
            this.btnQuickTab.UseVisualStyleBackColor = false;

            // btnQuickEnter
            this.btnQuickEnter.BackColor = System.Drawing.Color.White;
            this.btnQuickEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickEnter.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuickEnter.Location = new System.Drawing.Point(335, 293);
            this.btnQuickEnter.Name = "btnQuickEnter";
            this.btnQuickEnter.Size = new System.Drawing.Size(75, 26);
            this.btnQuickEnter.TabIndex = 14;
            this.btnQuickEnter.Text = "+ {ENTER}";
            this.btnQuickEnter.UseVisualStyleBackColor = false;

            // btnAddKeyAction
            this.btnAddKeyAction.BackColor = System.Drawing.Color.Black;
            this.btnAddKeyAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddKeyAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddKeyAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddKeyAction.ForeColor = System.Drawing.Color.White;
            this.btnAddKeyAction.Location = new System.Drawing.Point(416, 293);
            this.btnAddKeyAction.Name = "btnAddKeyAction";
            this.btnAddKeyAction.Size = new System.Drawing.Size(139, 26);
            this.btnAddKeyAction.TabIndex = 15;
            this.btnAddKeyAction.Text = "+ ADD KEY ACTION";
            this.btnAddKeyAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddKeyAction.UseVisualStyleBackColor = false;

            // 
            // Footer Control Panel
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.Controls.Add(this.btnTestExecution);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 530);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1000, 50);
            this.pnlFooter.TabIndex = 3;

            // btnTestExecution
            this.btnTestExecution.BackColor = System.Drawing.Color.White;
            this.btnTestExecution.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestExecution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestExecution.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTestExecution.ForeColor = System.Drawing.Color.Black;
            this.btnTestExecution.Location = new System.Drawing.Point(12, 10);
            this.btnTestExecution.Name = "btnTestExecution";
            this.btnTestExecution.Size = new System.Drawing.Size(170, 30);
            this.btnTestExecution.TabIndex = 2;
            this.btnTestExecution.Text = "TEST CURRENT STEP";
            this.btnTestExecution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTestExecution.UseVisualStyleBackColor = false;

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(795, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.UseVisualStyleBackColor = false;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(890, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "SAVE ALL";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseVisualStyleBackColor = false;

            // 
            // AutoLoginSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 580);
            this.Controls.Add(this.tlpMainLayout);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlPagination);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoLoginSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProcessForge — Multi-Step Target Configuration";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.tlpMainLayout.ResumeLayout(false);
            this.gbImageConfig.ResumeLayout(false);
            this.gbImageConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.gbActionConfig.ResumeLayout(false);
            this.gbActionConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoordX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoordY)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}