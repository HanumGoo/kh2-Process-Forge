using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProcessForge
{
    public class AddImportFileForm : Form
    {
        private bool isBulkTabActive = false;

#pragma warning disable CS8618
        // Header Controls
        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Label lblFormatTag;

        // File Location Section
        private GroupBox gbFileConfig;
        private Label lblFolderPrompt;
        private TextBox txtFolderPath;
        private Button btnBrowseFolder;
        private Label lblFileNamePrompt;
        private TextBox txtFileName;
        private Label lblExtension;
        private Label lblFullPathPreview;

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
        private Button btnCreate;

        public string CreatedFilePath { get; private set; } = string.Empty;
        public List<string> AddedLines { get; private set; } = new List<string>();

        public AddImportFileForm()
        {
            InitializeUI();
        }
#pragma warning restore CS8618

        private void InitializeUI()
        {
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(840, 580);
            this.MinimumSize = new Size(840, 580);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.Text = "ProcessForge — Create New Import Titles File";

            BuildHeader();
            BuildFileConfig();
            BuildNavBar();
            BuildSingleView();
            BuildBulkView();
            BuildFooter();

            this.Controls.Add(pnlSingleView);
            this.Controls.Add(pnlBulkView);
            this.Controls.Add(pnlNav);
            this.Controls.Add(gbFileConfig);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlHeader);

            SwitchTab(false);
            UpdateFullPathPreview();
        }

        private void BuildHeader()
        {
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 65,
                BackColor = Color.Black
            };

            lblHeaderTitle = new Label
            {
                Text = "CREATE NEW IMPORT TITLES FILE",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(18, 12),
                AutoSize = true
            };

            lblHeaderSubtitle = new Label
            {
                Text = "Specify directory, file name, and optionally add initial process titles.",
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.LightGray,
                Location = new Point(19, 36),
                AutoSize = true
            };

            lblFormatTag = new Label
            {
                Text = "FORMAT: Title,Status (e.g. GameClient_01,NotExist)",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(200, 200, 200),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(410, 24),
                Size = new Size(410, 20)
            };

            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblFormatTag);
        }

        private void BuildFileConfig()
        {
            gbFileConfig = new GroupBox
            {
                Text = "FILE DESTINATION && NAME",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(14, 72),
                Size = new Size(812, 105),
                BackColor = Color.White
            };

            lblFolderPrompt = new Label
            {
                Text = "Folder Location:",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(14, 22),
                AutoSize = true
            };

            txtFolderPath = new TextBox
            {
                Location = new Point(14, 42),
                Size = new Size(410, 25),
                Font = new Font("Segoe UI", 9F),
                BorderStyle = BorderStyle.FixedSingle,
                Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            txtFolderPath.TextChanged += (s, e) => UpdateFullPathPreview();

            btnBrowseFolder = new Button
            {
                Text = "Browse...",
                Location = new Point(432, 41),
                Size = new Size(85, 27),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBrowseFolder.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnBrowseFolder.Click += BtnBrowseFolder_Click;

            lblFileNamePrompt = new Label
            {
                Text = "File Name:",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(530, 22),
                AutoSize = true
            };

            txtFileName = new TextBox
            {
                Location = new Point(530, 42),
                Size = new Size(220, 25),
                Font = new Font("Segoe UI", 9F),
                BorderStyle = BorderStyle.FixedSingle,
                Text = "ImportTitles"
            };
            txtFileName.TextChanged += (s, e) => UpdateFullPathPreview();

            lblExtension = new Label
            {
                Text = ".txt",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 80),
                Location = new Point(755, 44),
                AutoSize = true
            };

            lblFullPathPreview = new Label
            {
                Text = "Full Path: ",
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(14, 76),
                Size = new Size(780, 20)
            };

            gbFileConfig.Controls.Add(lblFolderPrompt);
            gbFileConfig.Controls.Add(txtFolderPath);
            gbFileConfig.Controls.Add(btnBrowseFolder);
            gbFileConfig.Controls.Add(lblFileNamePrompt);
            gbFileConfig.Controls.Add(txtFileName);
            gbFileConfig.Controls.Add(lblExtension);
            gbFileConfig.Controls.Add(lblFullPathPreview);
        }

        private void BuildNavBar()
        {
            pnlNav = new Panel
            {
                Location = new Point(14, 184),
                Size = new Size(812, 38),
                BackColor = Color.WhiteSmoke
            };

            btnTabSingle = new Button
            {
                Text = "Single Entry Form",
                Location = new Point(4, 4),
                Size = new Size(160, 30),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnTabSingle.Click += (s, e) => SwitchTab(false);

            btnTabBulk = new Button
            {
                Text = "Bulk Multi-Line Input",
                Location = new Point(170, 4),
                Size = new Size(160, 30),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnTabBulk.Click += (s, e) => SwitchTab(true);

            pnlNav.Controls.Add(btnTabSingle);
            pnlNav.Controls.Add(btnTabBulk);
        }

        private void BuildSingleView()
        {
            pnlSingleView = new Panel
            {
                Location = new Point(14, 226),
                Size = new Size(812, 295),
                BackColor = Color.White
            };

            // Left side: Input Card
            gbInput = new GroupBox
            {
                Text = "INITIAL TITLE DETAILS (OPTIONAL)",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(0, 0),
                Size = new Size(420, 290),
                BackColor = Color.White
            };

            lblTitlePrompt = new Label { Text = "Window Title / Client Name:", Location = new Point(14, 30), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            txtTitleName = new TextBox { Location = new Point(14, 52), Size = new Size(390, 24), Font = new Font("Segoe UI", 9.5F), BorderStyle = BorderStyle.FixedSingle, PlaceholderText = "(e.g. GameClient_01)" };

            lblStatusField = new Label { Text = "Initial State:", Location = new Point(14, 95), AutoSize = true, Font = new Font("Segoe UI", 8.5F) };
            cmbStatus = new ComboBox
            {
                Location = new Point(14, 117),
                Size = new Size(390, 24),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5F)
            };
            cmbStatus.Items.AddRange(new object[] { "NotExist (Default - not yet running)", "Exist (Already running)" });
            cmbStatus.SelectedIndex = 0;

            lblHelper = new Label
            {
                Text = "Tip: Most new import lists start with 'NotExist' so the app can launch them.",
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(14, 155),
                Size = new Size(390, 36)
            };

            btnAddToQueue = new Button
            {
                Text = "+ ADD TO FILE QUEUE",
                Location = new Point(14, 215),
                Size = new Size(390, 48),
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnAddToQueue.FlatAppearance.BorderColor = Color.Black;
            btnAddToQueue.Click += BtnAddToQueue_Click;

            gbInput.Controls.Add(lblTitlePrompt);
            gbInput.Controls.Add(txtTitleName);
            gbInput.Controls.Add(lblStatusField);
            gbInput.Controls.Add(cmbStatus);
            gbInput.Controls.Add(lblHelper);
            gbInput.Controls.Add(btnAddToQueue);

            // Right side: Queue Card
            gbQueue = new GroupBox
            {
                Text = "QUEUED TITLES (READY TO WRITE)",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(430, 0),
                Size = new Size(382, 290),
                BackColor = Color.White
            };

            lstQueuedTitles = new ListBox
            {
                Location = new Point(12, 24),
                Size = new Size(358, 205),
                Font = new Font("Consolas", 8.5F),
                BorderStyle = BorderStyle.FixedSingle
            };

            btnRemoveSelected = new Button
            {
                Text = "Remove Selected",
                Location = new Point(12, 240),
                Size = new Size(170, 34),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRemoveSelected.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnRemoveSelected.Click += (s, e) =>
            {
                if (lstQueuedTitles.SelectedIndex >= 0)
                {
                    AddedLines.RemoveAt(lstQueuedTitles.SelectedIndex);
                    lstQueuedTitles.Items.RemoveAt(lstQueuedTitles.SelectedIndex);
                    UpdateStatus();
                }
            };

            btnClearQueue = new Button
            {
                Text = "Clear All",
                Location = new Point(190, 240),
                Size = new Size(180, 34),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClearQueue.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnClearQueue.Click += (s, e) =>
            {
                AddedLines.Clear();
                lstQueuedTitles.Items.Clear();
                UpdateStatus();
            };

            gbQueue.Controls.Add(lstQueuedTitles);
            gbQueue.Controls.Add(btnRemoveSelected);
            gbQueue.Controls.Add(btnClearQueue);

            pnlSingleView.Controls.Add(gbInput);
            pnlSingleView.Controls.Add(gbQueue);
        }

        private void BuildBulkView()
        {
            pnlBulkView = new Panel
            {
                Location = new Point(14, 226),
                Size = new Size(812, 295),
                BackColor = Color.White,
                Visible = false
            };

            gbBulk = new GroupBox
            {
                Text = "PASTE MULTI-LINE RAW TITLES (OPTIONAL)",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            lblBulkDesc = new Label
            {
                Text = "Enter titles one per line. If status is omitted, ',NotExist' will be appended automatically.",
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(12, 22),
                Size = new Size(780, 20)
            };

            txtBulkInput = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Font = new Font("Consolas", 9F),
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(12, 45),
                Size = new Size(788, 235),
                PlaceholderText = "GameClient_01\r\nGameClient_02\r\nGameClient_03,NotExist"
            };
            txtBulkInput.TextChanged += (s, e) => UpdateStatus();

            gbBulk.Controls.Add(lblBulkDesc);
            gbBulk.Controls.Add(txtBulkInput);
            pnlBulkView.Controls.Add(gbBulk);
        }

        private void BuildFooter()
        {
            pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.WhiteSmoke
            };

            lblStatus = new Label
            {
                Text = "Ready to create file.",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(18, 16),
                AutoSize = true
            };

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(600, 10),
                Size = new Size(95, 30),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            btnCreate = new Button
            {
                Text = "CREATE FILE",
                Location = new Point(705, 10),
                Size = new Size(120, 30),
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCreate.FlatAppearance.BorderColor = Color.Black;
            btnCreate.Click += BtnCreate_Click;

            pnlFooter.Controls.Add(lblStatus);
            pnlFooter.Controls.Add(btnCancel);
            pnlFooter.Controls.Add(btnCreate);
        }

        private void BtnBrowseFolder_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select Destination Folder for New Import Titles File";
                fbd.UseDescriptionForTitle = true;
                fbd.ShowNewFolderButton = true;
                if (Directory.Exists(txtFolderPath.Text))
                {
                    fbd.SelectedPath = txtFolderPath.Text;
                }

                if (fbd.ShowDialog(this) == DialogResult.OK)
                {
                    txtFolderPath.Text = fbd.SelectedPath;
                    UpdateFullPathPreview();
                }
            }
        }

        private void UpdateFullPathPreview()
        {
            string folder = txtFolderPath.Text.Trim();
            string fileName = txtFileName.Text.Trim();
            if (string.IsNullOrEmpty(fileName)) fileName = "NewFile";
            if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".txt";
            }

            string combined = Path.Combine(folder, fileName);
            lblFullPathPreview.Text = $"Full Target Path: {combined}";
            UpdateStatus();
        }

        private void SwitchTab(bool toBulk)
        {
            isBulkTabActive = toBulk;

            pnlSingleView.Visible = !toBulk;
            pnlBulkView.Visible = toBulk;

            if (toBulk)
            {
                btnTabBulk.BackColor = Color.Black;
                btnTabBulk.ForeColor = Color.White;
                btnTabBulk.FlatAppearance.BorderColor = Color.Black;

                btnTabSingle.BackColor = Color.White;
                btnTabSingle.ForeColor = Color.Black;
                btnTabSingle.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            }
            else
            {
                btnTabSingle.BackColor = Color.Black;
                btnTabSingle.ForeColor = Color.White;
                btnTabSingle.FlatAppearance.BorderColor = Color.Black;

                btnTabBulk.BackColor = Color.White;
                btnTabBulk.ForeColor = Color.Black;
                btnTabBulk.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            }

            UpdateStatus();
        }

        private void BtnAddToQueue_Click(object? sender, EventArgs e)
        {
            string title = txtTitleName.Text.Trim();
            string status = cmbStatus.SelectedIndex == 1 ? "Exist" : "NotExist";

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a title name.", "Empty Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string line = $"{title},{status}";
            AddedLines.Add(line);
            lstQueuedTitles.Items.Add($"{title} -> {status}");

            txtTitleName.Clear();
            cmbStatus.SelectedIndex = 0;
            txtTitleName.Focus();

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            int count = isBulkTabActive
                ? txtBulkInput.Lines.Count(l => !string.IsNullOrWhiteSpace(l))
                : AddedLines.Count;

            lblStatus.Text = $"Initial Titles to write: {count}";
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            string folder = txtFolderPath.Text.Trim();
            string name = txtFileName.Text.Trim();

            if (string.IsNullOrEmpty(folder))
            {
                MessageBox.Show("Please specify a folder path.", "Missing Folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please specify a file name.", "Missing File Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                name += ".txt";
            }

            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not access or create folder:\n{ex.Message}", "Folder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fullPath = Path.Combine(folder, name);

            List<string> linesToWrite = new List<string>();

            if (isBulkTabActive)
            {
                foreach (string rawLine in txtBulkInput.Lines)
                {
                    string trimmed = rawLine.Trim();
                    if (!string.IsNullOrEmpty(trimmed))
                    {
                        if (trimmed.Contains(','))
                        {
                            linesToWrite.Add(trimmed);
                        }
                        else
                        {
                            linesToWrite.Add(trimmed + ",NotExist");
                        }
                    }
                }
            }
            else
            {
                linesToWrite.AddRange(AddedLines);
            }

            if (File.Exists(fullPath))
            {
                DialogResult confirm = MessageBox.Show($"File already exists:\n{fullPath}\n\nDo you want to overwrite it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    return;
                }
            }

            try
            {
                File.WriteAllLines(fullPath, linesToWrite);
                CreatedFilePath = fullPath;
                MessageBox.Show($"Import titles file created successfully!\n\nPath: {fullPath}\nTitles: {linesToWrite.Count}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to write file:\n{ex.Message}", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
