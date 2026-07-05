using ProcessForge.RefreshLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProcessForge.ApplicationLogic
{
    public class AutoLoginLogic
    {
        //this is for fully automatic login for every NotLogin status in Account Data.
        public async static Task RunAutoLogin()
        {
            
        }
        public static void RefreshLogin(FlowLayoutPanel flowLayoutPanel, string processName, string accountDataFilePath)
        {
            //getting all data process with the same name and get their title and process id
            if (string.IsNullOrEmpty(processName) || string.IsNullOrEmpty(accountDataFilePath))
            {
                MessageBox.Show("please add process name and account data file path first at the main form", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Process[] AllProcess = Process.GetProcessesByName(processName);
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

            
            //extract file data from account data file path
            string[] FileExtract = File.ReadAllLines(accountDataFilePath);
            List<DataLoginFormat> DetectedData = new List<DataLoginFormat>();

            int counter = 0;
            foreach (string line in FileExtract)
            {
                if (string.IsNullOrEmpty(line))
                {
                    MessageBox.Show("Found empty line in account data file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string[] lineSplit = line.Split(new string[] { "," } , StringSplitOptions.None);
                if (lineSplit.Length != 5)
                {
                    MessageBox.Show("Invalid line format in account data file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;                
                }
                if (bool.TryParse(lineSplit[4], out bool valid))
                {
                    DetectedData.Add(new DataLoginFormat
                    {
                        nickname = lineSplit[0],
                        username = lineSplit[1],
                        password = lineSplit[2],
                        secondPassword = lineSplit[3],
                        isLogin = valid,
                        LineIndex = counter
                    });
                    counter++;
                }
                else
                {
                    MessageBox.Show("Invalid boolean value in account data file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                    
            }


            List<DataLoginFormat> DetectedProcess = new List<DataLoginFormat>();

            foreach (ProcessData item in ProcessTitle)
            {
                // Logic for detecting processes
                DataLoginFormat? matchedData = DetectedData.Find(data => data.nickname == item.TitleName);
                if (matchedData != null)
                {
                    matchedData.ProcessId = item.ProcessId; // Assign the ProcessId to the matched data
                    DetectedProcess.Add(matchedData);
                }
                else
                {
                    MessageBox.Show($"No matching account data found for process title: {item.TitleName}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //clear panel
            flowLayoutPanel.Controls.Clear();


            foreach (DataLoginFormat item in DetectedProcess)
            {
                int ProcessId = item.ProcessId;

                Button btn = new Button();

                btn.Text = item.nickname;
                btn.Tag = new ButtonData
                {
                    LineIndex = item.LineIndex,
                    Text = item.nickname
                };
                btn.Margin = new Padding(5, 5, 5, 5);
                btn.Size = new Size(135, 40);
                btn.Width = (int)(flowLayoutPanel.Width * 0.50);
                btn.Font = new Font("Segoe UI Symbol", 10F);
                btn.ForeColor = Color.White;
                btn.Click += (sender, e) => ButtonRestoreWindow_Click(sender, e, ProcessId);

                Button btn2 = new Button();
                btn2.Text = item.isLogin ? "Logined" : "Not Logined";
                btn2.Tag = item.LineIndex;
                btn2.Margin = new Padding(5, 5, 5, 5);
                btn2.Size = new Size(135, 40);
                btn2.Width = (int)(flowLayoutPanel.Width * 0.20);
                btn2.Font = new Font("Segoe UI Symbol", 10F);
                btn2.ForeColor = Color.White;
                btn2.BackColor = item.isLogin ? Color.Green : Color.Red;
                btn2.Click += (sender, e) => ButtonRestoreImport_Click(sender, e, accountDataFilePath);

                Button btn3 = new Button();

                btn3.Text = "Terminate";
                btn3.Tag = item.LineIndex;
                btn3.Margin = new Padding(5, 5, 5, 5);
                btn3.Size = new Size(135, 40);
                btn3.Width = (int)(flowLayoutPanel.Width * 0.20);
                btn3.Font = new Font("Segoe UI Symbol", 10F);
                btn3.ForeColor = Color.White;
                btn3.BackColor = Color.Maroon;
                btn3.Click += (sender, e) => ButtonTerminate_Click(sender, e, flowLayoutPanel, ProcessId);

                flowLayoutPanel.Controls.Add(btn);
                flowLayoutPanel.Controls.Add(btn2);
                flowLayoutPanel.Controls.Add(btn3);
            }
        }
        public static void ResetLogin(string accountDataFilePath)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset all login statuses to Not Logined?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            //extract file data from account data file path
            string[] FileExtract = File.ReadAllLines(accountDataFilePath);
            List<DataLoginFormat> DetectedData = new List<DataLoginFormat>();

            int counter = 0;
            foreach (string line in FileExtract)
            {
                if (string.IsNullOrEmpty(line))
                {
                    MessageBox.Show("Found empty line in account data file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string[] lineSplit = line.Split(new string[] { "," }, StringSplitOptions.None);
                if (lineSplit.Length != 5)
                {
                    MessageBox.Show("Invalid line format in account data file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (bool.TryParse(lineSplit[4], out bool valid))
                {
                    DetectedData.Add(new DataLoginFormat
                    {
                        nickname = lineSplit[0],
                        username = lineSplit[1],
                        password = lineSplit[2],
                        secondPassword = lineSplit[3],
                        isLogin = false,
                        LineIndex = counter
                    });
                    counter++;
                }
                else
                {
                    MessageBox.Show("Invalid boolean value in account data file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (DataLoginFormat item in DetectedData)
            {
                sb.AppendLine($"{item.nickname},{item.username},{item.password},{item.secondPassword},{item.isLogin}");
            }
            File.WriteAllText(accountDataFilePath, sb.ToString());
        }
        public static void TestLogin()
        {

        }


        private static void ButtonRestoreWindow_Click(object? sender, EventArgs e, int id)
        {
            if (sender is Button btn && !string.IsNullOrEmpty(btn.Text))
            {
                ProcessForge.FindWindowLogic.GetAndFindWindow.WindowRestore(id);
            }
            else
            {
                MessageBox.Show("Error, the windows form didn't have a title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private static void ButtonRestoreImport_Click(object? sender, EventArgs e, string path)
        {
            if (sender is Button btn && !string.IsNullOrEmpty(btn.Text) && !string.IsNullOrEmpty(btn.Tag?.ToString()))
            {
                string[] lines = File.ReadAllLines(path);
                if (btn.Text == "Not Logined")
                {
                    int StartsLine = (int)btn.Tag;
                    string[] DataSplit = lines[StartsLine].Split(new string[] { "," }, StringSplitOptions.None);
                    lines[StartsLine] = DataSplit[0] + "," + DataSplit[1] + "," + DataSplit[2] + "," + DataSplit[3] + "," + "true";
                    btn.Text = "Logined";
                    btn.BackColor = Color.Green;

                }
                else if (btn.Text == "Logined")
                {
                    int StartsLine = (int)btn.Tag;
                    string[] DataSplit = lines[StartsLine].Split(new string[] { "," }, StringSplitOptions.None);
                    lines[StartsLine] = DataSplit[0] + "," + DataSplit[1] + "," + DataSplit[2] + "," + DataSplit[3] + "," + "false";
                    btn.Text = "Not Logined";
                    btn.BackColor = Color.Red;
                }
                else
                {

                }

                File.WriteAllLines(path, lines);
            }
            else
            {
                MessageBox.Show("Error, the windows form didn't have a title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private static void ButtonTerminate_Click(object? sender, EventArgs e, FlowLayoutPanel flowLayoutPanel, int ProcessID)
        {
            bool terminateStatus = ProcessForge.ApplicationLogic.TerminateApplicationLogic.TerminateApplicationUsingId(ProcessID);
            if (terminateStatus)
            {
                if (sender is Button btn && !string.IsNullOrEmpty(btn.Tag?.ToString()))
                {
                    int StartsLine = (int)btn.Tag;
                    bool isFound = false;
                    foreach (Control control in flowLayoutPanel.Controls)
                    {

                        if (control is Button button)
                        {
                            if (button.Tag is ButtonData data && data.LineIndex == StartsLine)
                            {
                                button.Visible = false;
                                isFound = true;
                            }
                            else if (button.Tag is not ButtonData && button.Tag is not null && (int)button.Tag == StartsLine)
                            {
                                button.Visible = false;
                            }
                            else if (isFound && button.Tag is not null)
                            {
                                if (button.Tag is ButtonData currentData)
                                {
                                    button.Tag = new ButtonData
                                    {
                                        LineIndex = currentData.LineIndex - 1,
                                        Text = currentData.Text
                                    };
                                }
                                else
                                {
                                    int newTag = (int)button.Tag - 1;
                                    button.Tag = newTag;
                                }

                            }
                        }
                    }
                }

            }
        }
      

    }
    public class DataLoginFormat
    {
        public string nickname { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string secondPassword { get; set; } = string.Empty;
        public bool isLogin { get; set; } = false;
        public int ProcessId { get; set; } = 0;
        public int LineIndex { get; set; } = 0;
    }
}
