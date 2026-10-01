using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProcessForge
{
    public class AddImportDataForm : Form
    {
        private readonly string targetFilePath;
        private bool isBulkTabActive = false;

#pragma warning disable CS8618
        // Header Controls
        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Label lblFormatTag;

        // Navigation Bar Controls
        private Panel pnlNav;
        private Button btnTabSingle;
        private Button btnTabBulk;

        // Main Container Panels
        private Panel pnlSingleView;
        private Panel pnlBulkView;

        // Single View Controls (Left Column)
        private GroupBox gbInput;
        private Label lblTitlePrompt;
        private TextBox txtTitleName;
        private Label lblStatusField;
        private ComboBox cmbStatus;
        private Label lblHelper;
        private Button btnAddToQueue;

        // Single View Controls (Right Column)
        private GroupBox gbQueue;
        private ListBox lstQueuedTitles;
        private Button btnRemoveSelected;
        private Button btnClearQueue;

        // Bulk View Controls
        private GroupBox gbBulk;
        private Label lblBulkDesc;
        private TextBox txtBulkInput;

        // Footer Controls
        private Panel pnlFooter;
        private Label lblStatus;
        private Button btnCancel;
        private Button btnSave;

        public List<string> AddedLines { get; private set; } = new List<string>();

        public AddImportDataForm(string filePath)
        {
            this.targetFilePath = filePath;
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(820, 520);
            this.MinimumSize = new Size(820, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.Text = "ProcessForge — Add Import Process Titles";

            BuildHeader();
            BuildNavBar();
            BuildSingleView();
            BuildBulkView();
            BuildFooter();

            this.Controls.Add(pnlSingleView);
            this.Controls.Add(pnlBulkView);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlNav);
            this.Controls.Add(pnlHeader);

            SwitchTab(false);
            UpdateStatus();
        }

        private void BuildHeader()
        {
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 65,
                BackColor = Color.Black,
                Padding = new Padding(16, 8, 16, 8)
            };

            lblHeaderTitle = new Label
            {
                Text = "ADD IMPORT PROCESS TITLES",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(16, 7),
                AutoSize = true
            };

            lblHeaderSubtitle = new Label
            {
                Text = "Add window or process titles to your import list for tracking and automation.",
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.LightGray,
                Location = new Point(17, 27),
                AutoSize = true
            };

            lblFormatTag = new Label
            {
                Text = "Required Pattern:  TitleName,Status  (e.g. Process_01,NotExist — default status is NotExist)",
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                ForeColor = Color.LightSkyBlue,
                Location = new Point(17, 44),
                AutoSize = true
            };

            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblFormatTag);
        }

        private void BuildNavBar()
        {
            pnlNav = new Panel
            {
                Dock = DockStyle.Top,
                Height = 44,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(12, 6, 12, 6)
            };

            btnTabSingle = new Button
            {
                Text = "GUIDED FORM ENTRY",
                Size = new Size(180, 30),
                Location = new Point(12, 7),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnTabSingle.FlatAppearance.BorderSize = 1;
            btnTabSingle.FlatAppearance.BorderColor = Color.Black;
            btnTabSingle.Click += (s, e) => SwitchTab(false);

            btnTabBulk = new Button
            {
                Text = "BULK PASTE / MULTI-LINE",
                Size = new Size(190, 30),
                Location = new Point(198, 7),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnTabBulk.FlatAppearance.BorderSize = 1;
            btnTabBulk.FlatAppearance.BorderColor = Color.Silver;
            btnTabBulk.Click += (s, e) => SwitchTab(true);

            pnlNav.Controls.Add(btnTabSingle);
            pnlNav.Controls.Add(btnTabBulk);
        }

        private void SwitchTab(bool toBulk)
        {
            isBulkTabActive = toBulk;

            if (!toBulk)
            {
                btnTabSingle.BackColor = Color.Black;
                btnTabSingle.ForeColor = Color.White;
                btnTabSingle.FlatAppearance.BorderColor = Color.Black;

                btnTabBulk.BackColor = Color.White;
                btnTabBulk.ForeColor = Color.Black;
                btnTabBulk.FlatAppearance.BorderColor = Color.Silver;

                pnlSingleView.Visible = true;
                pnlBulkView.Visible = false;
                pnlSingleView.BringToFront();
            }
            else
            {
                btnTabSingle.BackColor = Color.White;
                btnTabSingle.ForeColor = Color.Black;
                btnTabSingle.FlatAppearance.BorderColor = Color.Silver;

                btnTabBulk.BackColor = Color.Black;
                btnTabBulk.ForeColor = Color.White;
                btnTabBulk.FlatAppearance.BorderColor = Color.Black;

                pnlSingleView.Visible = false;
                pnlBulkView.Visible = true;
                pnlBulkView.BringToFront();
            }

            UpdateStatus();
        }

        private void BuildSingleView()
        {
            pnlSingleView = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(12, 10, 12, 10),
                Visible = true
            };

            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.White
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // ── Left: Configuration GroupBox ───────────────────────────────────
            gbInput = new GroupBox
            {
                Text = " PROCESS TITLE CONFIGURATION ",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                Padding = new Padding(14, 14, 14, 14)
            };

            int curY = 26;

            // Title Name
            lblTitlePrompt = new Label
            {
                Text = "Window or Process Title Name:",
                Location = new Point(14, curY),
                AutoSize = true,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.Black
            };
            txtTitleName = new TextBox
            {
                Location = new Point(14, curY + 20),
                Height = 22,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                BackColor = Color.White,
                ForeColor = Color.Black
            };
            txtTitleName.Width = gbInput.Width - 28;

            // Status
            curY += 58;
            lblStatusField = new Label
            {
                Text = "Initial Status:",
                Location = new Point(14, curY),
                AutoSize = true,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.Black
            };
            cmbStatus = new ComboBox
            {
                Location = new Point(14, curY + 20),
                Height = 24,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                BackColor = Color.White,
                ForeColor = Color.Black
            };
            cmbStatus.Width = gbInput.Width - 28;
            cmbStatus.Items.Add("NotExist (Waiting / Target to launch)");
            cmbStatus.Items.Add("Exist (Already active / Running)");
            cmbStatus.SelectedIndex = 0;

            // Helper notice
            curY += 58;
            lblHelper = new Label
            {
                Text = "ℹ️ Titles are uniquely identified in the import list.\n   Selecting 'NotExist' tells the bot this process is not started yet.",
                Location = new Point(14, curY),
                Size = new Size(350, 36),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.DimGray
            };

            // Add to Queue button
            curY += 52;
            btnAddToQueue = new Button
            {
                Text = "+ ADD TO QUEUE",
                Location = new Point(14, curY),
                Height = 34,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnAddToQueue.Width = gbInput.Width - 28;
            btnAddToQueue.FlatAppearance.BorderSize = 0;
            btnAddToQueue.Click += BtnAddToQueue_Click;

            gbInput.Controls.Add(lblTitlePrompt);
            gbInput.Controls.Add(txtTitleName);
            gbInput.Controls.Add(lblStatusField);
            gbInput.Controls.Add(cmbStatus);
            gbInput.Controls.Add(lblHelper);
            gbInput.Controls.Add(btnAddToQueue);

            // ── Right: Queue GroupBox ─────────────────────────────────────────
            gbQueue = new GroupBox
            {
                Text = " QUEUED TITLES (0) ",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                Padding = new Padding(12, 12, 12, 12)
            };

            lstQueuedTitles = new ListBox
            {
                Location = new Point(12, 24),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Consolas", 8.5F, FontStyle.Regular),
                IntegralHeight = false
            };
            lstQueuedTitles.Size = new Size(gbQueue.Width - 24, gbQueue.Height - 74);

            btnRemoveSelected = new Button
            {
                Text = "REMOVE SELECTED",
                Height = 30,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Maroon,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnRemoveSelected.FlatAppearance.BorderSize = 1;
            btnRemoveSelected.FlatAppearance.BorderColor = Color.Silver;
            btnRemoveSelected.Click += (s, e) =>
            {
                if (lstQueuedTitles.SelectedIndex >= 0)
                {
                    lstQueuedTitles.Items.RemoveAt(lstQueuedTitles.SelectedIndex);
                    UpdateStatus();
                }
            };

            btnClearQueue = new Button
            {
                Text = "CLEAR ALL",
                Height = 30,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnClearQueue.FlatAppearance.BorderSize = 1;
            btnClearQueue.FlatAppearance.BorderColor = Color.Silver;
            btnClearQueue.Click += (s, e) =>
            {
                if (lstQueuedTitles.Items.Count > 0)
                {
                    lstQueuedTitles.Items.Clear();
                    UpdateStatus();
                }
            };

            gbQueue.Resize += (s, e) =>
            {
                int w = (gbQueue.ClientSize.Width - 30) / 2;
                btnRemoveSelected.Location = new Point(12, gbQueue.ClientSize.Height - 38);
                btnRemoveSelected.Width = w;

                btnClearQueue.Location = new Point(18 + w, gbQueue.ClientSize.Height - 38);
                btnClearQueue.Width = w;

                lstQueuedTitles.Size = new Size(gbQueue.ClientSize.Width - 24, gbQueue.ClientSize.Height - 70);
            };

            gbQueue.Controls.Add(lstQueuedTitles);
            gbQueue.Controls.Add(btnRemoveSelected);
            gbQueue.Controls.Add(btnClearQueue);

            tlp.Controls.Add(gbInput, 0, 0);
            tlp.Controls.Add(gbQueue, 1, 0);
            pnlSingleView.Controls.Add(tlp);
        }

        private void BuildBulkView()
        {
            pnlBulkView = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(12, 10, 12, 10),
                Visible = false
            };

            gbBulk = new GroupBox
            {
                Text = " BULK PROCESS TITLES PASTE / MULTI-LINE ",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                Padding = new Padding(14, 12, 14, 12)
            };

            lblBulkDesc = new Label
            {
                Text = "Enter or paste title names below (one per line).\nYou can enter raw titles (e.g. \"GameClient_01\") or explicit format (\"GameClient_01,NotExist\").",
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Location = new Point(14, 22),
                AutoSize = true
            };

            txtBulkInput = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                AcceptsReturn = true,
                AcceptsTab = true,
                Location = new Point(14, 60),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Consolas", 9.5F, FontStyle.Regular),
                Text = "Client_01" + Environment.NewLine +
                       "Client_02" + Environment.NewLine +
                       "Client_03"
            };
            txtBulkInput.Size = new Size(gbBulk.Width - 28, gbBulk.Height - 75);
            txtBulkInput.TextChanged += (s, e) => UpdateStatus();

            gbBulk.Resize += (s, e) =>
            {
                txtBulkInput.Size = new Size(gbBulk.ClientSize.Width - 28, gbBulk.ClientSize.Height - 75);
            };

            gbBulk.Controls.Add(lblBulkDesc);
            gbBulk.Controls.Add(txtBulkInput);
            pnlBulkView.Controls.Add(gbBulk);
        }

        private void BuildFooter()
        {
            pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 45,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(12, 7, 12, 7)
            };

            lblStatus = new Label
            {
                Text = "Ready to add titles.",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                Location = new Point(14, 14),
                AutoSize = true
            };

            Panel pnlActionBtns = new Panel
            {
                Dock = DockStyle.Right,
                Width = 230,
                BackColor = Color.Transparent
            };

            btnCancel = new Button
            {
                Text = "CANCEL",
                Size = new Size(85, 30),
                Location = new Point(15, 7),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = Color.Silver;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            btnSave = new Button
            {
                Text = "SAVE ALL",
                Size = new Size(115, 30),
                Location = new Point(106, 7),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            pnlActionBtns.Controls.Add(btnCancel);
            pnlActionBtns.Controls.Add(btnSave);

            pnlFooter.Controls.Add(lblStatus);
            pnlFooter.Controls.Add(pnlActionBtns);
        }

        private void UpdateStatus()
        {
            int queueCount = lstQueuedTitles.Items.Count;
            gbQueue.Text = $" QUEUED TITLES ({queueCount}) ";

            if (isBulkTabActive)
            {
                int bulkCount = txtBulkInput.Text
                    .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Count(l => !string.IsNullOrWhiteSpace(l));
                lblStatus.Text = $"Bulk mode: {bulkCount} title line(s) detected.";
            }
            else
            {
                lblStatus.Text = queueCount == 0
                    ? "Enter a title and click '+ ADD TO QUEUE' or enter directly."
                    : $"{queueCount} title(s) ready in queue.";
            }
        }

        private void BtnAddToQueue_Click(object? sender, EventArgs e)
        {
            string title = txtTitleName.Text.Trim();
            string status = cmbStatus.SelectedIndex == 1 ? "Exist" : "NotExist";

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a title name.", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitleName.Focus();
                return;
            }

            if (title.Contains(","))
            {
                MessageBox.Show("Title name cannot contain commas.", "Invalid Character", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formatted = $"{title},{status}";
            lstQueuedTitles.Items.Add(formatted);

            txtTitleName.Clear();
            cmbStatus.SelectedIndex = 0;
            txtTitleName.Focus();

            UpdateStatus();
        }

        private bool TryParseLine(string rawLine, int lineNumber, out string formattedLine, out string error)
        {
            formattedLine = string.Empty;
            error = string.Empty;

            string line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line)) return false;

            if (!line.Contains(","))
            {
                formattedLine = $"{line},NotExist";
                return true;
            }

            string[] parts = line.Split(',');
            if (parts.Length != 2)
            {
                error = $"Line {lineNumber}: Expected 'Title' or 'Title,Status', but found {parts.Length} parts.\nContent: \"{rawLine}\"";
                return false;
            }

            string title = parts[0].Trim();
            string status = parts[1].Trim();

            if (string.IsNullOrEmpty(title))
            {
                error = $"Line {lineNumber}: Title cannot be empty.";
                return false;
            }

            if (status != "NotExist" && status != "Exist")
            {
                error = $"Line {lineNumber}: Status must be 'NotExist' or 'Exist' (found '{status}').";
                return false;
            }

            formattedLine = $"{title},{status}";
            return true;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            List<string> linesToSave = new List<string>();

            // Auto-queue single entry if typed
            if (!string.IsNullOrWhiteSpace(txtTitleName.Text))
            {
                string status = cmbStatus.SelectedIndex == 1 ? "Exist" : "NotExist";
                string title = txtTitleName.Text.Trim();
                if (!title.Contains(","))
                {
                    linesToSave.Add($"{title},{status}");
                }
            }

            // 1. Collect from Queue
            foreach (var item in lstQueuedTitles.Items)
            {
                if (item != null)
                {
                    linesToSave.Add(item.ToString()!);
                }
            }

            // 2. If user is currently on Bulk Tab or queue is empty
            if (isBulkTabActive || linesToSave.Count == 0)
            {
                var bulkLines = txtBulkInput.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                int lineNum = 1;
                foreach (var rawLine in bulkLines)
                {
                    if (string.IsNullOrWhiteSpace(rawLine))
                    {
                        lineNum++;
                        continue;
                    }

                    if (!TryParseLine(rawLine, lineNum, out string formatted, out string error))
                    {
                        MessageBox.Show(error, "Invalid Line Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SwitchTab(true);
                        return;
                    }

                    if (!linesToSave.Contains(formatted))
                    {
                        linesToSave.Add(formatted);
                    }
                    lineNum++;
                }
            }

            if (linesToSave.Count == 0)
            {
                MessageBox.Show("Please enter or queue at least one title to add.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!string.IsNullOrEmpty(targetFilePath) && File.Exists(targetFilePath))
                {
                    List<string> existingLines = File.ReadAllLines(targetFilePath).ToList();
                    existingLines.AddRange(linesToSave);
                    File.WriteAllLines(targetFilePath, existingLines);
                }

                AddedLines = linesToSave;
                MessageBox.Show($"Successfully added {linesToSave.Count} title(s) to the import file!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to import file: {ex.Message}", "File Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
