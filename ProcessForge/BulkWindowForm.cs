using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ProcessForge.RefreshLogic;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProcessForge
{
    public partial class BulkWindowForm : Form
    {
        //check import status
        bool isUsingImport = false;
        string ProcessName = string.Empty;

        //page
        int PageCount = 1;

        public BulkWindowForm(string processName)
        {
            InitializeComponent();
            ProcessName = processName;
            FormStartup();
            RefreshFunction();
        }
        public void FormStartup()
        {
            ProcessListLabel.Text = !string.IsNullOrEmpty(ProcessName) ? $"PROCESS LIST — {ProcessName.ToUpper()}" : "PROCESS LIST";

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

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (PageCount == 1)
            {
                return;
            }
            PageCount -= 1;
            RefreshFunction();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName(ProcessName).Length < PageCount * 100)
            {
                return;
            }
            PageCount += 1;
            RefreshFunction();
        }
        private void RefreshFunction()
        {
            if (string.IsNullOrEmpty(ProcessName))
            {
                MessageBox.Show("please add process name first at the main form", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Process[] AllProcess = Process.GetProcessesByName(ProcessName);
            List<ProcessData> ProcessTitle = new List<ProcessData>();

            foreach (Process item in AllProcess)
            {
                if (string.IsNullOrEmpty(item.MainWindowTitle))
                {

                }
                else
                {
                    ProcessTitle.Add(new ProcessData
                    {
                        TitleName = item.MainWindowTitle,
                        ProcessId = item.Id
                    });
                }
            }

            if (!isUsingImport)
            {
                RefreshLogic.RefreshLogic.Refresh(flowLayoutPanel, LabelPage, PageCount, ProcessTitle);
            }
            else
            {
                string path = ImportTextbox.Text;

                if (!File.Exists(path) || string.IsNullOrEmpty(path))
                {
                    MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string[] AllData = File.ReadAllText(path).Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
                List<List<string>> AllDataImport = new List<List<string>>
                    {
                        new List<string>(),
                        new List<string>()
                    };


                foreach (string item in AllData)
                {
                    string[] TitleAndStatus = item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    if (TitleAndStatus.Length != 2)
                    {
                        MessageBox.Show("Import Data error! please check this one: \n" + item, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    AllDataImport[0].Add(TitleAndStatus[0]);
                    AllDataImport[1].Add(TitleAndStatus[1]);
                }

                RefreshLogic.RefreshLogic.RefreshWIthNotepadCheck(flowLayoutPanel, LabelPage, PageCount, ImportTextbox.Text, ProcessTitle, AllDataImport);
            }
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

            flowLayoutPanel.SuspendLayout();
            try
            {
                bool isTrue = false;
                bool isTrueSecond = false;
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    if (control is Button button)
                    {
                        if (button.Tag is ButtonData data)
                        {
                            if (string.IsNullOrEmpty(search) || data.Text.ToLower().Contains(search))
                            {
                                button.Visible = true;
                                isTrue = true;
                            }
                            else
                            {
                                button.Visible = false;
                                isTrue = false;
                            }
                        }
                        else if (isTrue)
                        {
                            button.Visible = true;
                            isTrue = false;
                            isTrueSecond = true;
                        }
                        else
                        {
                            if (isTrueSecond)
                            {
                                button.Visible = true;
                                isTrueSecond = false;
                            }
                            else
                            {
                                button.Visible = false;
                            }
                        }
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
            isUsingImport = !isUsingImport;

            if (isUsingImport)
            {
                panel3.BackColor = Color.Green;
                OnOffImport.Text = "Off";
            }
            else
            {
                panel3.BackColor = Color.Red;
                OnOffImport.Text = "On";
            }
        }

        private void CheckImport_Click(object sender, EventArgs e)
        {
            string path = ImportTextbox.Text;

            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] AllData = File.ReadAllText(path).Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);


            foreach (string item in AllData)
            {
                string[] TitleAndStatus = item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                if (TitleAndStatus.Length != 2)
                {
                    MessageBox.Show("Import Data error! please check this one: \n" + $"\"{item}\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            MessageBox.Show("The import file was valid.\nReady to go!", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImportBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = ".txt file (*.txt)|*.txt";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                ImportTextbox.Text = OFD.FileName;
            }
        }
    }
}
