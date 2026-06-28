using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessForge.RefreshLogic
{
    public class RefreshLogic
    {
        public static void Refresh(FlowLayoutPanel flowLayoutPanel, Label labelPage, int pageCount, List<ProcessData> AllProcessTitle)
        {
            //clear panel
            flowLayoutPanel.Controls.Clear();

            //generate button
            int PageStart = (pageCount - 1) * 100;
            int PageShow = 0;

            for (int i = PageStart; i < AllProcessTitle.Count; i++)
            {
                if (PageShow > 99)
                {
                    break;
                }

                int ProcessId = AllProcessTitle[i].ProcessId;

                Button btn = new Button();

                btn.Text = AllProcessTitle[i].TitleName;
                btn.Tag = new ButtonData
                {
                    LineIndex = i,
                    Text = AllProcessTitle[i].TitleName
                };
                btn.Margin = new Padding(5, 5, 5, 5);
                btn.Size = new Size(135, 40);
                btn.Width = flowLayoutPanel.Width - 300;
                btn.Font = new Font("Segoe UI Symbol", 9F);
                btn.ForeColor = Color.White;
                btn.Click += (sender, e) => ButtonRestoreWindow_Click(sender, e, ProcessId);

                Button btn3 = new Button();
                
                btn3.Text = "Terminate";
                btn3.Tag = i;
                btn3.Margin = new Padding(5, 5, 5, 5);
                btn3.Size = new Size(135, 40);
                btn3.Width = flowLayoutPanel.Width - 550;
                btn3.Font = new Font("Segoe UI Symbol", 9F);
                btn3.ForeColor = Color.White;
                btn3.BackColor = Color.Maroon;
                btn3.Click += (sender, e) => ButtonTerminate_Click(sender, e, flowLayoutPanel, ProcessId);

                flowLayoutPanel.Controls.Add(btn);
                flowLayoutPanel.Controls.Add(btn3);
                PageShow++;
            }

            //rename label page
            labelPage.Text = AllProcessTitle.Count <= 100 ? $"{AllProcessTitle.Count}/{AllProcessTitle.Count}" : $"{PageStart} - {PageStart + PageShow}/{AllProcessTitle.Count}";
        
        }
        public static void RefreshWIthNotepadCheck(FlowLayoutPanel flowLayoutPanel, Label labelPage, int pageCount, string path, List<ProcessData> AllProcessTitle, List<List<string>> AllDataImport)
        {
            flowLayoutPanel.Controls.Clear();

            

            List<List<string>> DetectedProcess = new List<List<string>>
            {
                new List<string>(),
                new List<string>(),
                new List<string>()
            };

            foreach (var processData in AllProcessTitle)
            {
                bool isFound = false;

                for (int i = 0; i < AllDataImport[0].Count; i++)
                {
                    if (processData.TitleName == AllDataImport[0][i])
                    {
                        DetectedProcess[0].Add(AllDataImport[0][i]);
                        DetectedProcess[1].Add(AllDataImport[1][i]);
                        DetectedProcess[2].Add(processData.ProcessId.ToString());
                        isFound = true;
                        break;
                    }
                    else
                    {

                    }
                }

                if (!isFound)
                {
                    DetectedProcess[0].Add(processData.TitleName);
                    DetectedProcess[1].Add("None");
                }

            }

            //rename label page
            int PageStart = (pageCount - 1) * 100;
            int PageShow = 0;

            for (int i = PageStart; i < DetectedProcess[0].Count; i++)
            {
                if (PageShow > 99)
                {
                    break;
                }

                int ProcessId = AllProcessTitle[i].ProcessId;

                Button btn = new Button();

                btn.Text = DetectedProcess[0][i];
                btn.Tag = new ButtonData
                {
                    LineIndex = i,
                    Text = DetectedProcess[0][i]
                };
                btn.Margin = new Padding(5, 5, 5, 5);
                btn.Size = new Size(135, 40);
                btn.Width = flowLayoutPanel.Width - 550;
                btn.Font = new Font("Segoe UI Symbol", 9F);
                btn.ForeColor = Color.White;
                btn.Click += (sender, e) => ButtonRestoreWindow_Click(sender, e, ProcessId);

                Button btn2 = new Button();

                btn2.Text = DetectedProcess[1][i];
                btn2.Tag = i;
                btn2.Margin = new Padding(5, 5, 5, 5);
                btn2.Size = new Size(135, 40);
                btn2.Width = flowLayoutPanel.Width - 550;
                btn2.Font = new Font("Segoe UI Symbol", 9F);
                btn2.ForeColor = Color.White;

                Button btn3 = new Button();
                
                btn3.Text = "Terminate";
                btn3.Tag = i;
                btn3.Margin = new Padding(5, 5, 5, 5);
                btn3.Size = new Size(135, 40);
                btn3.Width = flowLayoutPanel.Width - 550;
                btn3.Font = new Font("Segoe UI Symbol", 9F);
                btn3.ForeColor = Color.White;
                btn3.BackColor = Color.Maroon;
                btn3.Click += (sender, e) => ButtonTerminate_Click(sender, e, flowLayoutPanel, ProcessId);


                if (DetectedProcess[1][i] == "NotExist")
                {
                    btn2.BackColor = Color.Red;
                    btn2.Click += (sender, e) => ButtonRestoreImport_Click(sender, e, path);
                }
                else if (DetectedProcess[1][i] == "Exist")
                {
                    btn2.BackColor = Color.Green;
                    btn2.Click += (sender, e) => ButtonRestoreImport_Click(sender, e, path);
                }
                else
                {
                    btn2.BackColor = Color.Gray;
                }

                flowLayoutPanel.Controls.Add(btn);
                flowLayoutPanel.Controls.Add(btn2);
                flowLayoutPanel.Controls.Add(btn3);
                PageShow++;
            }

            //rename label page
            labelPage.Text = AllProcessTitle.Count <= 100 ? $"{AllProcessTitle.Count}/{AllProcessTitle.Count}" : $"{PageStart} - {PageStart + PageShow}/{AllProcessTitle.Count}";
        }

        public static void RefreshWIthNotepadImport(FlowLayoutPanel flowLayoutPanel, Label labelPage, int pageCount, string path, List<List<string>> AllDataImport)
        {
            flowLayoutPanel.Controls.Clear();

            List<List<string>> DetectedProcess = AllDataImport;

            //rename label page
            int PageStart = (pageCount - 1) * 100;
            int PageShow = 0;

            for (int i = PageStart; i < DetectedProcess[0].Count; i++)
            {
                if (PageShow > 99)
                {
                    break;
                }

                Button btn = new Button();

                btn.Text = DetectedProcess[0][i];
                btn.Tag = new ButtonData
                {
                    LineIndex = i,
                    Text = DetectedProcess[0][i]
                };
                btn.Margin = new Padding(5, 5, 5, 5);
                btn.Size = new Size(135, 40);
                btn.Width = flowLayoutPanel.Width - 550;
                btn.Font = new Font("Segoe UI Symbol", 9F);
                btn.ForeColor = Color.White;
                btn.Click += (sender, e) => Inputbox_Click(sender, e, path);

                Button btn2 = new Button();

                btn2.Text = DetectedProcess[1][i];
                btn2.Tag = i;
                btn2.Margin = new Padding(5, 5, 5, 5);
                btn2.Size = new Size(135, 40);
                btn2.Width = flowLayoutPanel.Width - 550;
                btn2.Font = new Font("Segoe UI Symbol", 9F);
                btn2.ForeColor = Color.White;

                Button btn3 = new Button();

                btn3.Text = "Delete";
                btn3.Tag = i;
                btn3.Margin = new Padding(5, 5, 5, 5);
                btn3.Size = new Size(135, 40);
                btn3.Width = flowLayoutPanel.Width - 550;
                btn3.Font = new Font("Segoe UI Symbol", 9F);
                btn3.ForeColor = Color.White;
                btn3.BackColor = Color.Maroon;
                btn3.Click += (sender, e) => ButtonDelete_Click(sender, e, path, flowLayoutPanel);

                if (DetectedProcess[1][i] == "NotExist")
                {
                    btn2.BackColor = Color.Red;
                    btn2.Click += (sender, e) => ButtonRestoreImport_Click(sender, e, path);
                }
                else if (DetectedProcess[1][i] == "Exist")
                {
                    btn2.BackColor = Color.Green;
                    btn2.Click += (sender, e) => ButtonRestoreImport_Click(sender, e, path);
                }
                else
                {
                    btn2.BackColor = Color.Gray;
                }

                flowLayoutPanel.Controls.Add(btn);
                flowLayoutPanel.Controls.Add(btn2);
                flowLayoutPanel.Controls.Add(btn3);
                PageShow++;
            }

            //rename label page
            labelPage.Text = AllDataImport[0].Count <= 100 ? $"{AllDataImport[0].Count}/{AllDataImport[0].Count}" : $"{PageStart} - {PageStart + PageShow}/{AllDataImport[0].Count}";
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
                if (btn.Text == "NotExist")
                {
                    int StartsLine = (int)btn.Tag;
                    string[] DataSplit = lines[StartsLine].Split(new string[] {","}, StringSplitOptions.None);
                    lines[StartsLine] = DataSplit[0] + "," + "Exist";
                    btn.Text = "Exist";
                    btn.BackColor = Color.Green;

                }
                else if (btn.Text == "Exist")
                {
                    int StartsLine = (int)btn.Tag;
                    string[] DataSplit = lines[StartsLine].Split(new string[] { "," }, StringSplitOptions.None);
                    lines[StartsLine] = DataSplit[0] + "," + "NotExist";
                    btn.Text = "NotExist";
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
        private static void ButtonDelete_Click(object? sender, EventArgs e, string path, FlowLayoutPanel flowLayoutPanel)
        {
            DialogResult messageBoxResult = MessageBox.Show("Are you sure want to delete this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (messageBoxResult != DialogResult.Yes)
            {
                return;
            }

            if (sender is Button btn && !string.IsNullOrEmpty(btn.Tag?.ToString()))
            {
                List<string> lines = File.ReadAllLines(path).ToList();

                int StartsLine = (int)btn.Tag;
                lines.RemoveAt(StartsLine);

                File.WriteAllLines(path, lines);

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
        private static void Inputbox_Click(object? sender, EventArgs e, string path)
        {
            string[]? text = ProcessForge.RefreshLogic.InputBox.Show("Please enter a new value:", "Input", false, "");
            if (text == null)
            {
                return;
            }
            if (sender is Button btn && btn.Tag is ButtonData data)
            {
                string[] lines = File.ReadAllLines(path);

                int StartsLine = data.LineIndex;
                string[] DataSplit = lines[StartsLine].Split(new string[] { "," }, StringSplitOptions.None);
                lines[StartsLine] = text[0] + "," + DataSplit[1];
                btn.Text = text[0];
                File.WriteAllLines(path, lines);
            }
            else
            {
                MessageBox.Show("Error, this one Import didn't provide any title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        
    }
    public class ButtonData
    {
        public int LineIndex { get; set; }
        public string Text { get; set; } = "";
    }
    public class ProcessData
    {
        public int ProcessId { get; set; }
        public string TitleName { get; set; } = "";
    }
}
