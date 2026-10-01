using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProcessForge
{
    public class AddAccountDataForm : Form
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
        private Label lblNick;
        private TextBox txtNickname;
        private Label lblUser;
        private TextBox txtUsername;
        private Label lblPass;
        private TextBox txtPassword;
        private Label lblSecPass;
        private TextBox txtSecondPassword;
        private Label lblLoginStatus;
        private ComboBox cmbIsLogin;
        private Button btnAddToQueue;

        // Single View Controls (Right Column)
        private GroupBox gbQueue;
        private ListBox lstQueuedAccounts;
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

        public AddAccountDataForm(string filePath)
        {
            this.targetFilePath = filePath;
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(820, 540);
            this.MinimumSize = new Size(820, 540);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.Text = "ProcessForge — Add Account Data";

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
                Text = "ADD ACCOUNT CREDENTIALS",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(16, 7),
                AutoSize = true
            };

            lblHeaderSubtitle = new Label
            {
                Text = "Add new account login credentials to your account import file.",
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.LightGray,
                Location = new Point(17, 27),
                AutoSize = true
            };

            lblFormatTag = new Label
            {
                Text = "Required Pattern:  Nickname, Username, Password, SecondPassword, IsLogin",
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

            // ── Left: Input Credentials GroupBox ──────────────────────────────
            gbInput = new GroupBox
            {
                Text = " ACCOUNT CREDENTIALS ",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                Padding = new Padding(14, 12, 14, 12)
            };

            int curY = 22;
            int stepY = 50;

            // Nickname
            lblNick = MakeFieldLabel("Nickname (Window Title):", curY);
            txtNickname = MakeTextBox(curY + 18);
            gbInput.Controls.Add(lblNick);
            gbInput.Controls.Add(txtNickname);

            // Username
            curY += stepY;
            lblUser = MakeFieldLabel("Username:", curY);
            txtUsername = MakeTextBox(curY + 18);
            gbInput.Controls.Add(lblUser);
            gbInput.Controls.Add(txtUsername);

            // Password
            curY += stepY;
            lblPass = MakeFieldLabel("Password:", curY);
            txtPassword = MakeTextBox(curY + 18);
            gbInput.Controls.Add(lblPass);
            gbInput.Controls.Add(txtPassword);

            // Second Password
            curY += stepY;
            lblSecPass = MakeFieldLabel("Second Password:", curY);
            txtSecondPassword = MakeTextBox(curY + 18);
            gbInput.Controls.Add(lblSecPass);
            gbInput.Controls.Add(txtSecondPassword);

            // Login Status
            curY += stepY;
            lblLoginStatus = MakeFieldLabel("Initial Login Status:", curY);
            cmbIsLogin = new ComboBox
            {
                Location = new Point(14, curY + 18),
                Height = 24,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                BackColor = Color.White,
                ForeColor = Color.Black
            };
            cmbIsLogin.Width = gbInput.Width - 28;
            cmbIsLogin.Items.Add("False (Not Logged In)");
            cmbIsLogin.Items.Add("True (Already Logged In)");
            cmbIsLogin.SelectedIndex = 0;
            gbInput.Controls.Add(lblLoginStatus);
            gbInput.Controls.Add(cmbIsLogin);

            // Add to Queue button
            curY += stepY + 6;
            btnAddToQueue = new Button
            {
                Text = "+ ADD TO QUEUE",
                Location = new Point(14, curY),
                Height = 32,
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
            gbInput.Controls.Add(btnAddToQueue);

            // ── Right: Queue GroupBox ─────────────────────────────────────────
            gbQueue = new GroupBox
            {
                Text = " QUEUED ACCOUNTS (0) ",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                Padding = new Padding(12, 12, 12, 12)
            };

            lstQueuedAccounts = new ListBox
            {
                Location = new Point(12, 24),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Consolas", 8.5F, FontStyle.Regular),
                IntegralHeight = false
            };
            lstQueuedAccounts.Size = new Size(gbQueue.Width - 24, gbQueue.Height - 74);

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
                if (lstQueuedAccounts.SelectedIndex >= 0)
                {
                    lstQueuedAccounts.Items.RemoveAt(lstQueuedAccounts.SelectedIndex);
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
                if (lstQueuedAccounts.Items.Count > 0)
                {
                    lstQueuedAccounts.Items.Clear();
                    UpdateStatus();
                }
            };

            // Size buttons evenly when gbQueue resizes
            gbQueue.Resize += (s, e) =>
            {
                int w = (gbQueue.ClientSize.Width - 30) / 2;
                btnRemoveSelected.Location = new Point(12, gbQueue.ClientSize.Height - 38);
                btnRemoveSelected.Width = w;

                btnClearQueue.Location = new Point(18 + w, gbQueue.ClientSize.Height - 38);
                btnClearQueue.Width = w;

                lstQueuedAccounts.Size = new Size(gbQueue.ClientSize.Width - 24, gbQueue.ClientSize.Height - 70);
            };

            gbQueue.Controls.Add(lstQueuedAccounts);
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
                Text = " BULK ACCOUNT PASTE / MULTI-LINE ",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                Padding = new Padding(14, 12, 14, 12)
            };

            lblBulkDesc = new Label
            {
                Text = "Enter or paste accounts below (one account per line).\nRequired pattern: Nickname,Username,Password,SecondPassword,IsLogin",
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
                Text = "noles1,naga,passwordtest123,passwordtest123,False" + Environment.NewLine +
                       "noles2,naga,passwordtest123,passwordtest123,False"
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
                Text = "Ready to add accounts.",
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

        private Label MakeFieldLabel(string text, int top)
        {
            return new Label
            {
                Text = text,
                Location = new Point(14, top),
                AutoSize = true,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.Black
            };
        }

        private TextBox MakeTextBox(int top)
        {
            return new TextBox
            {
                Location = new Point(14, top),
                Height = 22,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                BackColor = Color.White,
                ForeColor = Color.Black
            };
        }

        private void UpdateStatus()
        {
            int queueCount = lstQueuedAccounts.Items.Count;
            gbQueue.Text = $" QUEUED ACCOUNTS ({queueCount}) ";

            if (isBulkTabActive)
            {
                int bulkCount = txtBulkInput.Text
                    .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Count(l => !string.IsNullOrWhiteSpace(l));
                lblStatus.Text = $"Bulk mode: {bulkCount} account line(s) detected.";
            }
            else
            {
                lblStatus.Text = queueCount == 0
                    ? "Enter fields and click '+ ADD TO QUEUE' or enter directly."
                    : $"{queueCount} account(s) ready in queue.";
            }
        }

        private void BtnAddToQueue_Click(object? sender, EventArgs e)
        {
            string nick = txtNickname.Text.Trim();
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string secPass = txtSecondPassword.Text.Trim();
            string isLog = cmbIsLogin.SelectedIndex == 1 ? "True" : "False";

            if (string.IsNullOrEmpty(nick))
            {
                MessageBox.Show("Please enter a Nickname (Window Title).", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNickname.Focus();
                return;
            }

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Please enter a Username.", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (nick.Contains(",") || user.Contains(",") || pass.Contains(",") || secPass.Contains(","))
            {
                MessageBox.Show("Values cannot contain commas, as comma is used as delimiter.", "Invalid Character", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string line = $"{nick},{user},{pass},{secPass},{isLog}";
            lstQueuedAccounts.Items.Add(line);

            txtNickname.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtSecondPassword.Clear();
            cmbIsLogin.SelectedIndex = 0;
            txtNickname.Focus();

            UpdateStatus();
        }

        private bool TryParseLine(string rawLine, int lineNumber, out string formattedLine, out string error)
        {
            formattedLine = string.Empty;
            error = string.Empty;

            string line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line)) return false;

            string[] parts = line.Split(',');

            if (parts.Length == 4)
            {
                parts = new string[] { parts[0], parts[1], parts[2], parts[3], "False" };
            }

            if (parts.Length != 5)
            {
                error = $"Line {lineNumber}: Expected 5 comma-delimited values (Nickname,Username,Password,SecondPassword,IsLogin), but found {parts.Length}.\nContent: \"{rawLine}\"";
                return false;
            }

            string nick = parts[0].Trim();
            string user = parts[1].Trim();
            string pass = parts[2].Trim();
            string secPass = parts[3].Trim();
            string statusStr = parts[4].Trim();

            if (string.IsNullOrEmpty(nick))
            {
                error = $"Line {lineNumber}: Nickname cannot be empty.";
                return false;
            }

            if (string.IsNullOrEmpty(user))
            {
                error = $"Line {lineNumber}: Username cannot be empty.";
                return false;
            }

            if (!bool.TryParse(statusStr, out bool isValidBool))
            {
                error = $"Line {lineNumber}: IsLogin status must be 'True' or 'False' (found '{statusStr}').";
                return false;
            }

            formattedLine = $"{nick},{user},{pass},{secPass},{isValidBool}";
            return true;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            List<string> linesToSave = new List<string>();

            // Auto-queue single entry if typed
            if (!string.IsNullOrWhiteSpace(txtNickname.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                string isLog = cmbIsLogin.SelectedIndex == 1 ? "True" : "False";
                string pending = $"{txtNickname.Text.Trim()},{txtUsername.Text.Trim()},{txtPassword.Text.Trim()},{txtSecondPassword.Text.Trim()},{isLog}";
                linesToSave.Add(pending);
            }

            // 1. Collect from Form Queue
            foreach (var item in lstQueuedAccounts.Items)
            {
                if (item != null)
                {
                    linesToSave.Add(item.ToString()!);
                }
            }

            // 2. If user is currently on Bulk Tab or nothing in single queue
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
                MessageBox.Show("Please enter or queue at least one account to add.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Successfully added {linesToSave.Count} account(s) to the import file!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to account file: {ex.Message}", "File Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
