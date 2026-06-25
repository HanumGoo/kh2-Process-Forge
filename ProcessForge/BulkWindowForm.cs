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
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            
            Process[] AllProcess = Process.GetProcessesByName(ProcessName);
            List<string> ProcessTitle = new List<string>();

            foreach (Process item in AllProcess)
            {
                ProcessTitle.Add(item.MainWindowTitle);
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

                RefreshLogic.RefreshLogic.RefreshWIthNotepadCheck(flowLayoutPanel, LabelPage, PageCount, ProcessTitle, AllDataImport);
            }
        }

        private void TestGenerate_Click(object sender, EventArgs e)
        {
            //FlowLayoutPanel.Controls.Clear();
            List<string> _savedApps = new List<string>
            {
                "app1",
                "app2",
                "app3"
            };

            foreach (var item in _savedApps)
            {
                Button btn = new Button();

                btn.Text = item;
                //btn.Tag = item;

                //btn.Click += Button_Click;

                flowLayoutPanel.Controls.Add(btn);
            }
        }

        private void TestGenerate2_Click(object sender, EventArgs e)
        {
            //FlowLayoutPanel.Controls.Clear();
            List<string> _savedApps = new List<string>
            {
                "app1",
                "app2",
                "app3"
            };

            foreach (var item in _savedApps)
            {
                Button btn = new Button();

                btn.Text = item;
                btn.Margin = new Padding(5, 5, 5, 5);
                btn.Size = new Size(135, 40);
                btn.Width = flowLayoutPanel.Width - 300;
                btn.Font = new Font("Segoe UI Symbol", 9F);
                btn.ForeColor = Color.White;

                Button btn2 = new Button(); 
                btn2.Text = item;
                btn2.Margin = new Padding(5, 5, 5, 5);
                btn2.Size = new Size(135, 40);
                btn2.Width = flowLayoutPanel.Width - 550;
                btn2.Font = new Font("Segoe UI Symbol", 9F);
                btn2.ForeColor = Color.White;
                btn2.BackColor = Color.Green;
                //btn.Tag = item;

                //btn.Click += Button_Click;

                flowLayoutPanel.Controls.Add(btn);
                flowLayoutPanel.Controls.Add(btn2);
            }
        }
    }
}
