using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProcessForge
{
    public class AutoSplitResult
    {
        public bool Success { get; set; }
        public int GroupCount { get; set; }
        public int ProcessesPerGroup { get; set; }
        public string GroupPrefix { get; set; } = "Group ";
        public bool ResetExisting { get; set; } = true;
    }

    public class AutoSplitDialog : Form
    {
        private readonly int _totalProcesses;
        private NumericUpDown numGroups = null!;
        private NumericUpDown numPerGroup = null!;
        private RadioButton rbByGroupCount = null!;
        private RadioButton rbByPerGroup = null!;
        private TextBox txtPrefix = null!;
        private CheckBox chkResetExisting = null!;
        private Label lblSummary = null!;
        private bool _isUpdating = false;

        public AutoSplitResult Result { get; private set; } = new AutoSplitResult();

        public AutoSplitDialog(int totalProcesses)
        {
            _totalProcesses = Math.Max(1, totalProcesses);
            InitializeComponents();
            UpdateCalculations();
        }

        private void InitializeComponents()
        {
            Text = "Auto-Split Processes Into Groups";
            Size = new Size(460, 360);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            // Header panel
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.Black
            };

            Label lblTitle = new Label
            {
                Text = "AUTO-SPLIT GROUPS",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.White,
                Location = new Point(16, 10),
                AutoSize = true
            };

            Label lblSubtitle = new Label
            {
                Text = $"Distribute {_totalProcesses} detected process(es) linearly into manageable groups.",
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.LightGray,
                Location = new Point(17, 34),
                AutoSize = true
            };

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            // GroupBox for split options
            GroupBox gbOptions = new GroupBox
            {
                Text = "Split Options",
                Location = new Point(16, 75),
                Size = new Size(412, 140),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
            };

            rbByGroupCount = new RadioButton
            {
                Text = "Split into number of groups:",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(16, 28),
                Size = new Size(200, 24),
                Checked = true
            };

            numGroups = new NumericUpDown
            {
                Minimum = 1,
                Maximum = Math.Max(1, _totalProcesses),
                Value = Math.Min(4, Math.Max(1, _totalProcesses)),
                Location = new Point(230, 28),
                Size = new Size(80, 24),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
            };

            rbByPerGroup = new RadioButton
            {
                Text = "Split by processes per group:",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(16, 62),
                Size = new Size(200, 24)
            };

            numPerGroup = new NumericUpDown
            {
                Minimum = 1,
                Maximum = Math.Max(1, _totalProcesses),
                Value = (decimal)Math.Max(1, Math.Ceiling((double)_totalProcesses / (double)numGroups.Value)),
                Location = new Point(230, 62),
                Size = new Size(80, 24),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
            };

            Label lblPrefix = new Label
            {
                Text = "Group Name Prefix:",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(16, 98),
                Size = new Size(130, 24)
            };

            txtPrefix = new TextBox
            {
                Text = "Group ",
                Location = new Point(150, 96),
                Size = new Size(160, 24),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
            };

            chkResetExisting = new CheckBox
            {
                Text = "Clear existing groups",
                Checked = true,
                Location = new Point(320, 98),
                Size = new Size(90, 24),
                Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point)
            };

            gbOptions.Controls.Add(rbByGroupCount);
            gbOptions.Controls.Add(numGroups);
            gbOptions.Controls.Add(rbByPerGroup);
            gbOptions.Controls.Add(numPerGroup);
            gbOptions.Controls.Add(lblPrefix);
            gbOptions.Controls.Add(txtPrefix);
            gbOptions.Controls.Add(chkResetExisting);

            // Summary label
            lblSummary = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic, GraphicsUnit.Point),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(16, 222),
                Size = new Size(412, 40)
            };

            // Buttons
            Button btnApply = new Button
            {
                Text = "Apply Split",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(220, 275),
                Size = new Size(110, 32),
                Cursor = Cursors.Hand
            };
            btnApply.Click += BtnApply_Click;

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(338, 275),
                Size = new Size(90, 32),
                Cursor = Cursors.Hand
            };
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            AcceptButton = btnApply;
            CancelButton = btnCancel;

            Controls.Add(pnlHeader);
            Controls.Add(gbOptions);
            Controls.Add(lblSummary);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);

            // Event handlers
            numGroups.ValueChanged += (s, e) =>
            {
                if (_isUpdating) return;
                _isUpdating = true;
                rbByGroupCount.Checked = true;
                int g = (int)numGroups.Value;
                int perG = (int)Math.Ceiling((double)_totalProcesses / g);
                numPerGroup.Value = Math.Max(1, Math.Min(_totalProcesses, perG));
                _isUpdating = false;
                UpdateCalculations();
            };

            numPerGroup.ValueChanged += (s, e) =>
            {
                if (_isUpdating) return;
                _isUpdating = true;
                rbByPerGroup.Checked = true;
                int perG = (int)numPerGroup.Value;
                int g = (int)Math.Ceiling((double)_totalProcesses / perG);
                numGroups.Value = Math.Max(1, Math.Min(_totalProcesses, g));
                _isUpdating = false;
                UpdateCalculations();
            };

            rbByGroupCount.CheckedChanged += (s, e) => UpdateCalculations();
            rbByPerGroup.CheckedChanged += (s, e) => UpdateCalculations();
            txtPrefix.TextChanged += (s, e) => UpdateCalculations();
        }

        private void UpdateCalculations()
        {
            int g = (int)numGroups.Value;
            int perG = (int)numPerGroup.Value;
            string prefix = string.IsNullOrWhiteSpace(txtPrefix.Text) ? "Group " : txtPrefix.Text.Trim() + " ";

            lblSummary.Text = $"Preview: {_totalProcesses} process(es) will be divided into {g} group(s)\n" +
                              $"naming: \"{prefix}1\" to \"{prefix}{g}\" (~{perG} per group).";
        }

        private void BtnApply_Click(object? sender, EventArgs e)
        {
            Result = new AutoSplitResult
            {
                Success = true,
                GroupCount = (int)numGroups.Value,
                ProcessesPerGroup = (int)numPerGroup.Value,
                GroupPrefix = string.IsNullOrWhiteSpace(txtPrefix.Text) ? "Group " : txtPrefix.Text,
                ResetExisting = chkResetExisting.Checked
            };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
