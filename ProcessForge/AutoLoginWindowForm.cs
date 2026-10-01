using ProcessForge.ApplicationLogic;
using ProcessForge.RefreshLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProcessForge
{
    public partial class AutoLoginWindowForm : Form
    {
        //process name
        string processName;

        public AutoLoginWindowForm(string ProcessName)
        {

            InitializeComponent();
            FormStartup();
            processName = ProcessName;
        }
        public void FormStartup()
        {
            ProcessListLabel.Text = "AUTO LOGIN ACCOUNTS MANAGER";

            // Enable double buffering on flowLayoutPanel to eliminate flicker
            typeof(FlowLayoutPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(flowLayoutPanel, true, null);

            btnSearch.Click += (s, e) => ExecuteSearch();
            btnClearSearch.Click += (s, e) => { txtSearch.Clear(); ExecuteSearch(); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ExecuteSearch();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshFunction();
        }
        private void RefreshFunction()
        {
            string path = ImportTextbox.Text;
            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] AllLines = File.ReadAllLines(path);
            LabelPage.Text = $"Total Accounts: {AllLines.Length}";
            AutoLoginLogic.RefreshLoginImport(flowLayoutPanel, ImportTextbox.Text);
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                ExecuteSearch();
            }
        }

        private void ExecuteSearch()
        {
            string search = txtSearch.Text.Trim().ToLower();

            // In AutoLoginLogic.RefreshLoginImport, each account row adds exactly 6 buttons to flowLayoutPanel:
            // 0: Nickname (ButtonData), 1: Username, 2: Password, 3: SecondPassword, 4: IsLogin status, 5: Delete button
            flowLayoutPanel.SuspendLayout();
            try
            {
                var controls = flowLayoutPanel.Controls.Cast<Control>().ToList();
                int totalRows = controls.Count / 6;

                for (int r = 0; r < totalRows; r++)
                {
                    int startIndex = r * 6;
                    var rowControls = controls.Skip(startIndex).Take(6).ToList();

                    bool matches = string.IsNullOrEmpty(search);
                    if (!matches && rowControls.Count >= 6)
                    {
                        string nickname = rowControls[0].Text.ToLower();
                        string username = rowControls[1].Text.ToLower();
                        string password = rowControls[2].Text.ToLower();
                        string secondPassword = rowControls[3].Text.ToLower();
                        string status = rowControls[4].Text.ToLower();

                        matches = nickname.Contains(search) ||
                                  username.Contains(search) ||
                                  password.Contains(search) ||
                                  secondPassword.Contains(search) ||
                                  status.Contains(search);
                    }

                    foreach (var ctrl in rowControls)
                    {
                        ctrl.Visible = matches;
                    }
                }
            }
            finally
            {
                flowLayoutPanel.ResumeLayout(true);
            }
        }

        private void OnOffImport_Click(object sender, EventArgs e)
        {
            string path = ImportTextbox.Text;
            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("do you want to reset all the status?.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            string[] AllLines = File.ReadAllLines(path);
            StringBuilder sb = new StringBuilder();
            foreach (string line in AllLines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    MessageBox.Show("Error! : the file contain empty line(s).", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<string> lineSplit = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (lineSplit.Count != 5)
                {
                    MessageBox.Show("Error! : the file contain wrong format line(s).\n" + lineSplit, "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (lineSplit[4].ToLower() != "true" && lineSplit[4].ToLower() != "false")
                {
                    MessageBox.Show("Error! : the file contain wrong format line(s).\n" + lineSplit, "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lineSplit[4] = "false";
                sb.AppendLine(string.Join(",", lineSplit));
            }
            File.WriteAllText(path, sb.ToString());
            RefreshFunction();
        }

        private void CheckImport_Click(object sender, EventArgs e)
        {
            string path = ImportTextbox.Text;
            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] AllLines = File.ReadAllLines(path);
            foreach (string line in AllLines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    MessageBox.Show("Error! : the file contain empty line(s).", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string[] lineSplit = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (lineSplit.Length != 5)
                {
                    MessageBox.Show("Error! : the file contain wrong format line(s).\n" + lineSplit, "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (lineSplit[4].ToLower() != "true" && lineSplit[4].ToLower() != "false")
                {
                    MessageBox.Show("Error! : the file contain wrong format line(s).\n" + lineSplit, "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }
            MessageBox.Show("Import file is valid!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImportBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = ".txt file (*.txt)|*.txt";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                ImportTextbox.Text = OFD.FileName;
                RefreshFunction();
            }

        }

        private void AddDatabutton_Click(object sender, EventArgs e)
        {
            string path = ImportTextbox.Text;

            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new AddAccountDataForm(path))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshFunction();
                }
            }
        }

        private void NewImportFile_Click(object sender, EventArgs e)
        {
            using (var form = new AddAccountFileForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(form.CreatedFilePath))
                {
                    ImportTextbox.Text = form.CreatedFilePath;
                    RefreshFunction();
                }
            }
        }

       
    }
}
