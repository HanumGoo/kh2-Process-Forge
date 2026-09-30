namespace ProcessForge
{
    partial class AutoLoginSettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Visual Controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;

        // Pagination Bar Controls
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnPrevStep;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Label lblStepIndicator;
        private System.Windows.Forms.FlowLayoutPanel flpPageButtons;

        private System.Windows.Forms.TableLayoutPanel tlpMainLayout;

        // Image Section Controls
        private System.Windows.Forms.GroupBox gbImageConfig;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnCaptureImage;
        private System.Windows.Forms.Label lblImagePathTitle;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Label lblTemplateName;
        private System.Windows.Forms.TextBox txtTemplateName;

        // Coordinate Section Controls
        private System.Windows.Forms.GroupBox gbClickConfig;
        private System.Windows.Forms.Button btnCaptureCoords;
        private System.Windows.Forms.Label lblXCoord;
        private System.Windows.Forms.NumericUpDown numCoordX;
        private System.Windows.Forms.Label lblYCoord;
        private System.Windows.Forms.NumericUpDown numCoordY;
        private System.Windows.Forms.Label lblClickType;
        private System.Windows.Forms.ComboBox cmbClickType;
        private System.Windows.Forms.CheckBox chkUseRelativeOffset;

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
            this.tlpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gbImageConfig = new System.Windows.Forms.GroupBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnCaptureImage = new System.Windows.Forms.Button();
            this.lblImagePathTitle = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.lblTemplateName = new System.Windows.Forms.Label();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.gbClickConfig = new System.Windows.Forms.GroupBox();
            this.btnCaptureCoords = new System.Windows.Forms.Button();
            this.lblXCoord = new System.Windows.Forms.Label();
            this.numCoordX = new System.Windows.Forms.NumericUpDown();
            this.lblYCoord = new System.Windows.Forms.Label();
            this.numCoordY = new System.Windows.Forms.NumericUpDown();
            this.lblClickType = new System.Windows.Forms.Label();
            this.cmbClickType = new System.Windows.Forms.ComboBox();
            this.chkUseRelativeOffset = new System.Windows.Forms.CheckBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnTestExecution = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlPagination.SuspendLayout();
            this.tlpMainLayout.SuspendLayout();
            this.gbImageConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.gbClickConfig.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(800, 55);
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
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(325, 13);
            this.lblHeaderSubtitle.Text = "Capture image anchors and target mouse click locations per step.";

            // 
            // Pagination Bar
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPagination.Controls.Add(this.lblStepIndicator);
            this.pnlPagination.Controls.Add(this.flpPageButtons);
            this.pnlPagination.Controls.Add(this.btnPrevStep);
            this.pnlPagination.Controls.Add(this.btnNextStep);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPagination.Location = new System.Drawing.Point(0, 55);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(800, 45);
            this.pnlPagination.TabIndex = 1;

            // btnPrevStep
            this.btnPrevStep.BackColor = System.Drawing.Color.White;
            this.btnPrevStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevStep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrevStep.ForeColor = System.Drawing.Color.Black;
            this.btnPrevStep.Location = new System.Drawing.Point(12, 7);
            this.btnPrevStep.Name = "btnPrevStep";
            this.btnPrevStep.Size = new System.Drawing.Size(80, 30);
            this.btnPrevStep.TabIndex = 0;
            this.btnPrevStep.Text = "< PREV";
            this.btnPrevStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrevStep.UseVisualStyleBackColor = false;

            // lblStepIndicator
            this.lblStepIndicator.AutoSize = true;
            this.lblStepIndicator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStepIndicator.ForeColor = System.Drawing.Color.Black;
            this.lblStepIndicator.Location = new System.Drawing.Point(100, 15);
            this.lblStepIndicator.Name = "lblStepIndicator";
            this.lblStepIndicator.Size = new System.Drawing.Size(82, 15);
            this.lblStepIndicator.Text = "STEP 1 OF 9";

            // flpPageButtons (Contains 1..9 numeric pagination buttons)
            this.flpPageButtons.AutoScroll = false;
            this.flpPageButtons.Location = new System.Drawing.Point(205, 7);
            this.flpPageButtons.Name = "flpPageButtons";
            this.flpPageButtons.Size = new System.Drawing.Size(490, 32);
            this.flpPageButtons.TabIndex = 1;

            // btnNextStep
            this.btnNextStep.BackColor = System.Drawing.Color.Black;
            this.btnNextStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextStep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNextStep.ForeColor = System.Drawing.Color.White;
            this.btnNextStep.Location = new System.Drawing.Point(708, 7);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(80, 30);
            this.btnNextStep.TabIndex = 2;
            this.btnNextStep.Text = "NEXT >";
            this.btnNextStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNextStep.UseVisualStyleBackColor = false;

            // 
            // Main Layout
            // 
            this.tlpMainLayout.ColumnCount = 2;
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainLayout.Controls.Add(this.gbImageConfig, 0, 0);
            this.tlpMainLayout.Controls.Add(this.gbClickConfig, 1, 0);
            this.tlpMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainLayout.Location = new System.Drawing.Point(0, 100);
            this.tlpMainLayout.Name = "tlpMainLayout";
            this.tlpMainLayout.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMainLayout.RowCount = 1;
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.Size = new System.Drawing.Size(800, 305);
            this.tlpMainLayout.TabIndex = 2;

            // 
            // GroupBox: Image Anchor
            // 
            this.gbImageConfig.Controls.Add(this.txtTemplateName);
            this.gbImageConfig.Controls.Add(this.lblTemplateName);
            this.gbImageConfig.Controls.Add(this.txtImagePath);
            this.gbImageConfig.Controls.Add(this.lblImagePathTitle);
            this.gbImageConfig.Controls.Add(this.btnCaptureImage);
            this.gbImageConfig.Controls.Add(this.picPreview);
            this.gbImageConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImageConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbImageConfig.ForeColor = System.Drawing.Color.Black;
            this.gbImageConfig.Location = new System.Drawing.Point(13, 13);
            this.gbImageConfig.Name = "gbImageConfig";
            this.gbImageConfig.Size = new System.Drawing.Size(377, 280);
            this.gbImageConfig.TabIndex = 0;
            this.gbImageConfig.TabStop = false;
            this.gbImageConfig.Text = " IMAGE ANCHOR ";

            // picPreview
            this.picPreview.BackColor = System.Drawing.Color.White;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picPreview.Location = new System.Drawing.Point(15, 22);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(347, 115);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;

            // btnCaptureImage
            this.btnCaptureImage.BackColor = System.Drawing.Color.Black;
            this.btnCaptureImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaptureImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaptureImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCaptureImage.ForeColor = System.Drawing.Color.White;
            this.btnCaptureImage.Location = new System.Drawing.Point(15, 142);
            this.btnCaptureImage.Name = "btnCaptureImage";
            this.btnCaptureImage.Size = new System.Drawing.Size(347, 30);
            this.btnCaptureImage.TabIndex = 1;
            this.btnCaptureImage.Text = "CAPTURE IMAGE FOR THIS STEP";
            this.btnCaptureImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCaptureImage.UseVisualStyleBackColor = false;

            // lblTemplateName
            this.lblTemplateName.AutoSize = true;
            this.lblTemplateName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTemplateName.Location = new System.Drawing.Point(15, 177);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(81, 13);
            this.lblTemplateName.Text = "Step Identifier:";

            // txtTemplateName
            this.txtTemplateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTemplateName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTemplateName.Location = new System.Drawing.Point(15, 193);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(347, 22);
            this.txtTemplateName.TabIndex = 2;

            // lblImagePathTitle
            this.lblImagePathTitle.AutoSize = true;
            this.lblImagePathTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImagePathTitle.Location = new System.Drawing.Point(15, 221);
            this.lblImagePathTitle.Name = "lblImagePathTitle";
            this.lblImagePathTitle.Size = new System.Drawing.Size(81, 13);
            this.lblImagePathTitle.Text = "Image File Path:";

            // txtImagePath
            this.txtImagePath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImagePath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtImagePath.Location = new System.Drawing.Point(15, 237);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(347, 22);
            this.txtImagePath.TabIndex = 3;

            // 
            // GroupBox: Target Location
            // 
            this.gbClickConfig.Controls.Add(this.chkUseRelativeOffset);
            this.gbClickConfig.Controls.Add(this.cmbClickType);
            this.gbClickConfig.Controls.Add(this.lblClickType);
            this.gbClickConfig.Controls.Add(this.numCoordY);
            this.gbClickConfig.Controls.Add(this.lblYCoord);
            this.gbClickConfig.Controls.Add(this.numCoordX);
            this.gbClickConfig.Controls.Add(this.lblXCoord);
            this.gbClickConfig.Controls.Add(this.btnCaptureCoords);
            this.gbClickConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbClickConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbClickConfig.ForeColor = System.Drawing.Color.Black;
            this.gbClickConfig.Location = new System.Drawing.Point(396, 13);
            this.gbClickConfig.Name = "gbClickConfig";
            this.gbClickConfig.Size = new System.Drawing.Size(377, 280);
            this.gbClickConfig.TabIndex = 1;
            this.gbClickConfig.TabStop = false;
            this.gbClickConfig.Text = " TARGET CLICK LOCATION ";

            // btnCaptureCoords
            this.btnCaptureCoords.BackColor = System.Drawing.Color.Black;
            this.btnCaptureCoords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaptureCoords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaptureCoords.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCaptureCoords.ForeColor = System.Drawing.Color.White;
            this.btnCaptureCoords.Location = new System.Drawing.Point(15, 22);
            this.btnCaptureCoords.Name = "btnCaptureCoords";
            this.btnCaptureCoords.Size = new System.Drawing.Size(347, 30);
            this.btnCaptureCoords.TabIndex = 0;
            this.btnCaptureCoords.Text = "CAPTURE COORDINATE FOR THIS STEP";
            this.btnCaptureCoords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCaptureCoords.UseVisualStyleBackColor = false;

            // lblXCoord
            this.lblXCoord.AutoSize = true;
            this.lblXCoord.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblXCoord.Location = new System.Drawing.Point(15, 62);
            this.lblXCoord.Name = "lblXCoord";
            this.lblXCoord.Size = new System.Drawing.Size(77, 13);
            this.lblXCoord.Text = "X Coordinate:";

            // numCoordX
            this.numCoordX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCoordX.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numCoordX.Location = new System.Drawing.Point(15, 78);
            this.numCoordX.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numCoordX.Minimum = new decimal(new int[] { 9999, 0, 0, -2147483648 });
            this.numCoordX.Name = "numCoordX";
            this.numCoordX.Size = new System.Drawing.Size(347, 22);
            this.numCoordX.TabIndex = 1;

            // lblYCoord
            this.lblYCoord.AutoSize = true;
            this.lblYCoord.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblYCoord.Location = new System.Drawing.Point(15, 108);
            this.lblYCoord.Name = "lblYCoord";
            this.lblYCoord.Size = new System.Drawing.Size(75, 13);
            this.lblYCoord.Text = "Y Coordinate:";

            // numCoordY
            this.numCoordY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCoordY.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numCoordY.Location = new System.Drawing.Point(15, 124);
            this.numCoordY.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numCoordY.Minimum = new decimal(new int[] { 9999, 0, 0, -2147483648 });
            this.numCoordY.Name = "numCoordY";
            this.numCoordY.Size = new System.Drawing.Size(347, 22);
            this.numCoordY.TabIndex = 2;

            // lblClickType
            this.lblClickType.AutoSize = true;
            this.lblClickType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClickType.Location = new System.Drawing.Point(15, 154);
            this.lblClickType.Name = "lblClickType";
            this.lblClickType.Size = new System.Drawing.Size(73, 13);
            this.lblClickType.Text = "Mouse Action:";

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
            this.cmbClickType.Location = new System.Drawing.Point(15, 170);
            this.cmbClickType.Name = "cmbClickType";
            this.cmbClickType.Size = new System.Drawing.Size(347, 21);
            this.cmbClickType.SelectedIndex = 0;
            this.cmbClickType.TabIndex = 3;

            // chkUseRelativeOffset
            this.chkUseRelativeOffset.AutoSize = true;
            this.chkUseRelativeOffset.Checked = true;
            this.chkUseRelativeOffset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseRelativeOffset.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkUseRelativeOffset.Location = new System.Drawing.Point(15, 205);
            this.chkUseRelativeOffset.Name = "chkUseRelativeOffset";
            this.chkUseRelativeOffset.Size = new System.Drawing.Size(252, 17);
            this.chkUseRelativeOffset.TabIndex = 4;
            this.chkUseRelativeOffset.Text = "Use coordinates relative to matched image";
            this.chkUseRelativeOffset.UseVisualStyleBackColor = true;

            // 
            // Footer Control Panel
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.Controls.Add(this.btnTestExecution);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 405);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 45);
            this.pnlFooter.TabIndex = 3;

            // btnTestExecution
            this.btnTestExecution.BackColor = System.Drawing.Color.White;
            this.btnTestExecution.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestExecution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestExecution.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTestExecution.ForeColor = System.Drawing.Color.Black;
            this.btnTestExecution.Location = new System.Drawing.Point(12, 7);
            this.btnTestExecution.Name = "btnTestExecution";
            this.btnTestExecution.Size = new System.Drawing.Size(150, 30);
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
            this.btnCancel.Location = new System.Drawing.Point(598, 7);
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
            this.btnSave.Location = new System.Drawing.Point(693, 7);
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
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.gbClickConfig.ResumeLayout(false);
            this.gbClickConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoordX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoordY)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}