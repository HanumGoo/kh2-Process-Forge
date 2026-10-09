using OpenCvSharp;
using OpenCvSharp.Extensions;
using ProcessForge.AutoLoginPatternLogic;
using ProcessForge.FindWindowLogic;
using ProcessForge.RefreshLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessForge.ApplicationLogic
{
    public class AutoLoginLogic
    {
        //this is for fully automatic login for every NotLogin status in Account Data.

        private static CancellationTokenSource? _autoLoginCts;

        public static bool IsRunning => _autoLoginCts != null && !_autoLoginCts.IsCancellationRequested;

        public static void StopAutoLogin()
        {
            if (_autoLoginCts != null && !_autoLoginCts.IsCancellationRequested)
            {
                try
                {
                    _autoLoginCts.Cancel();
                }
                catch { }
            }
        }

        public async static Task RunAutoLogin(string processName, string accountDataFilePath, string autoLoginMode = "Standard Auto Login", Action? onProcessCompleted = null, CancellationToken externalToken = default)
        {
            if (IsRunning)
            {
                return;
            }

            using var linkedCts = externalToken != default
                ? CancellationTokenSource.CreateLinkedTokenSource(externalToken)
                : new CancellationTokenSource();

            _autoLoginCts = linkedCts;
            var token = linkedCts.Token;

            try
            {
                await Task.Run(() =>
                {
                    ExecuteAutoLogin(processName, accountDataFilePath, autoLoginMode, onProcessCompleted, token);
                }, token);
            }
            catch (OperationCanceledException)
            {
                // Operation cancelled cleanly
            }
            finally
            {
                _autoLoginCts = null;
            }
        }

        public async static Task RunAutoLogin(string processName, string accountDataFilePath, Action? onProcessCompleted, CancellationToken externalToken = default)
        {
            await RunAutoLogin(processName, accountDataFilePath, "Standard Auto Login", onProcessCompleted, externalToken);
        }

        private static void ExecuteAutoLogin(string processName, string accountDataFilePath, string autoLoginMode, Action? onProcessCompleted, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;

            // Detected Process
            #region Get All Process and Extract Account Data

            if (string.IsNullOrEmpty(processName) || string.IsNullOrEmpty(accountDataFilePath))
            {
                MessageBox.Show("please add process name and account data file path first at the main form", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Process[] AllProcess = Process.GetProcessesByName(processName);
            List<ProcessData> ProcessTitle = new List<ProcessData>();

            foreach (Process item in AllProcess)
            {
                if (cancellationToken.IsCancellationRequested) return;

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
                if (cancellationToken.IsCancellationRequested) return;

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
                if (cancellationToken.IsCancellationRequested) return;

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

            #endregion

            // Data from config
            #region Get Config Data
            string storageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");
            string configFilePath = Path.Combine(storageDirectory, "steps_config.json");

            List<TargetStepModel> loaded = AutoLoginSettingsForm.LoadSteps();
            bool isCreateCharacterMode = string.Equals(autoLoginMode, "Auto Login + Create Character", StringComparison.OrdinalIgnoreCase);

            #endregion

            foreach (DataLoginFormat item in DetectedProcess)
            {
                if (cancellationToken.IsCancellationRequested) break;

                if (item.isLogin)
                {
                    continue; // Skip if already logged in
                }

                // Restore the window and bring it to the foreground
                Process process = Process.GetProcessById(item.ProcessId);
                GetAndFindWindow.WindowRestore(item.ProcessId);
                process.WaitForInputIdle(); // Wait for the process to be ready for input

                if (cancellationToken.WaitHandle.WaitOne(1000)) break; // Optional: Add a small delay to ensure the window is fully restored

                // get the window size
                Rectangle windowSize = GetAndFindWindow.WindowSize(item.ProcessId);

                Case AllCase = new Case(storageDirectory, configFilePath, item, cancellationToken);

                // 1. Shared Main Steps: 1, 2, 3
                var mainSteps = loaded.Where(s => !s.IsSubStep && s.BranchType == "Main").ToList();
                if (mainSteps.Count == 0)
                {
                    mainSteps = loaded.Where(s => !s.IsSubStep && s.StepIndex < 3).ToList();
                }

                for (int i = 0; i < mainSteps.Count; i++)
                {
                    if (cancellationToken.IsCancellationRequested) break;
                    var step = mainSteps[i];
                    AllCase.ExecuteCase(windowSize, step, loaded);
                }

                if (cancellationToken.IsCancellationRequested) break;

                // 2. Branch Flow: Character Creation (CharSteps 4-9) vs Ordinary Auto Login (Steps 4-5)
                if (isCreateCharacterMode)
                {
                    var charSteps = loaded.Where(s => !s.IsSubStep && s.BranchType == "CreateCharacter").ToList();
                    if (charSteps.Count == 0)
                    {
                        charSteps = loaded.Where(s => s.StepTitle.StartsWith("CharStep")).ToList();
                    }

                    foreach (var charStep in charSteps)
                    {
                        if (cancellationToken.IsCancellationRequested) break;
                        AllCase.ExecuteCase(windowSize, charStep, loaded);
                    }
                }
                else
                {
                    var ordinarySteps = loaded.Where(s => !s.IsSubStep && s.BranchType == "Ordinary").ToList();
                    if (ordinarySteps.Count == 0)
                    {
                        ordinarySteps = loaded.Where(s => !s.IsSubStep && (s.StepIndex == 3 || s.StepIndex == 4)).ToList();
                    }

                    for (int i = 0; i < ordinarySteps.Count; i++)
                    {
                        if (cancellationToken.IsCancellationRequested) break;
                        var ordStep = ordinarySteps[i];
                        AllCase.ExecuteCase(windowSize, ordStep, loaded);
                    }
                }

                if (cancellationToken.IsCancellationRequested) break;
                GetAndFindWindow.WindowMinimize(item.ProcessId); // Minimize the window after processing

                // Mark item as logged in
                item.isLogin = true;

                // Update account data file: change false to True
                try
                {
                    if (File.Exists(accountDataFilePath))
                    {
                        string[] fileLines = File.ReadAllLines(accountDataFilePath);
                        bool updated = false;

                        if (item.LineIndex >= 0 && item.LineIndex < fileLines.Length)
                        {
                            string[] parts = fileLines[item.LineIndex].Split(',');
                            if (parts.Length == 5 && parts[0] == item.nickname)
                            {
                                fileLines[item.LineIndex] = $"{parts[0]},{parts[1]},{parts[2]},{parts[3]},True";
                                updated = true;
                            }
                        }

                        if (!updated)
                        {
                            for (int lineIdx = 0; lineIdx < fileLines.Length; lineIdx++)
                            {
                                string[] parts = fileLines[lineIdx].Split(',');
                                if (parts.Length == 5 && parts[0] == item.nickname)
                                {
                                    fileLines[lineIdx] = $"{parts[0]},{parts[1]},{parts[2]},{parts[3]},True";
                                    updated = true;
                                    break;
                                }
                            }
                        }

                        if (updated)
                        {
                            File.WriteAllLines(accountDataFilePath, fileLines);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to update account file for {item.nickname}: {ex.Message}");
                }

                // Trigger UI refresh callback
                onProcessCompleted?.Invoke();
            }
                // Logic for automatic login
                // You can implement the login logic here using the username, password, and secondPassword from the item object.
                // For example, you can use SendKeys or other methods to input the credentials into the application window.
                // Make sure to handle any exceptions or errors that may occur during the login process.

            // restore window and accepts 1 parameter that is the title process name
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
                btn.Size = new System.Drawing.Size(135, 40);
                btn.Width = (int)(flowLayoutPanel.Width * 0.50);
                btn.Font = new Font("Segoe UI Symbol", 10F);
                btn.ForeColor = Color.Black;
                btn.Click += (sender, e) => ButtonRestoreWindow_Click(sender, e, ProcessId);

                Button btn2 = new Button();
                btn2.Text = item.isLogin ? "Logined" : "Not Logined";
                btn2.Tag = item.LineIndex;
                btn2.Margin = new Padding(5, 5, 5, 5);
                btn2.Size = new System.Drawing.Size(135, 40);
                btn2.Width = (int)(flowLayoutPanel.Width * 0.20);
                btn2.Font = new Font("Segoe UI Symbol", 10F);
                btn2.ForeColor = Color.White;
                btn2.BackColor = item.isLogin ? Color.Green : Color.Red;
                btn2.Click += (sender, e) => ButtonRestoreImport_Click(sender, e, accountDataFilePath);

                Button btn3 = new Button();

                btn3.Text = "Terminate";
                btn3.Tag = item.LineIndex;
                btn3.Margin = new Padding(5, 5, 5, 5);
                btn3.Size = new System.Drawing.Size(135, 40);
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
        public static void RefreshLoginImport(FlowLayoutPanel flowLayoutPanel, string accountDataFilePath)
        {
            //getting all data process with the same name and get their title and process id
            if (string.IsNullOrEmpty(accountDataFilePath))
            {
                MessageBox.Show("please add account data file path first at the main form", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            //clear panel
            flowLayoutPanel.Controls.Clear();


            foreach (DataLoginFormat item in DetectedData)
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
                btn.Size = new System.Drawing.Size(135, 40);
                btn.Width = (int)(flowLayoutPanel.Width * 0.18);
                btn.Font = new Font("Segoe UI Symbol", 10F);
                btn.ForeColor = Color.Black;
                btn.Click += (sender, e) => ButtonRestoreImportNickname_Click(sender, e, accountDataFilePath);

                Button btn2 = new Button();
                btn2.Text = item.username;
                btn2.Tag = item.LineIndex;
                btn2.Margin = new Padding(5, 5, 5, 5);
                btn2.Size = new System.Drawing.Size(135, 40);
                btn2.Width = (int)(flowLayoutPanel.Width * 0.18);
                btn2.Font = new Font("Segoe UI Symbol", 10F);
                btn2.ForeColor = Color.Black;
                btn2.Click += (sender, e) => ButtonRestoreImportUsername_Click(sender, e, accountDataFilePath);

                Button btn3 = new Button();
                btn3.Text = item.password;
                btn3.Tag = item.LineIndex;
                btn3.Margin = new Padding(5, 5, 5, 5);
                btn3.Size = new System.Drawing.Size(135, 40);
                btn3.Width = (int)(flowLayoutPanel.Width * 0.18);
                btn3.Font = new Font("Segoe UI Symbol", 10F);
                btn3.ForeColor = Color.Black;
                btn3.Click += (sender, e) => ButtonRestoreImportPassword_Click(sender, e, accountDataFilePath);

                Button btn4 = new Button();
                btn4.Text = item.secondPassword;
                btn4.Tag = item.LineIndex;
                btn4.Margin = new Padding(5, 5, 5, 5);
                btn4.Size = new System.Drawing.Size(135, 40);
                btn4.Width = (int)(flowLayoutPanel.Width * 0.18);
                btn4.Font = new Font("Segoe UI Symbol", 10F);
                btn4.ForeColor = Color.Black;
                btn4.Click += (sender, e) => ButtonRestoreImportSecondPassword_Click(sender, e, accountDataFilePath);

                Button btn5 = new Button();
                btn5.Text = item.isLogin ? "Logined" : "Not Logined";
                btn5.Tag = item.LineIndex;
                btn5.Margin = new Padding(5, 5, 5, 5);
                btn5.Size = new System.Drawing.Size(135, 40);
                btn5.Width = (int)(flowLayoutPanel.Width * 0.10);
                btn5.Font = new Font("Segoe UI Symbol", 10F);
                btn5.ForeColor = Color.White;
                btn5.BackColor = item.isLogin ? Color.Green : Color.Red;
                btn5.Click += (sender, e) => ButtonRestoreImport_Click(sender, e, accountDataFilePath);

                Button btn6 = new Button();

                btn6.Text = "Delete";
                btn6.Tag = item.LineIndex;
                btn6.Margin = new Padding(5, 5, 5, 5);
                btn6.Size = new System.Drawing.Size(135, 40);
                btn6.Width = (int)(flowLayoutPanel.Width * 0.10);
                btn6.Font = new Font("Segoe UI Symbol", 10F);
                btn6.ForeColor = Color.White;
                btn6.BackColor = Color.Maroon;
                btn6.Click += (sender, e) => ButtonDelete_Click(sender, e, accountDataFilePath, flowLayoutPanel);

                flowLayoutPanel.Controls.Add(btn);
                flowLayoutPanel.Controls.Add(btn2);
                flowLayoutPanel.Controls.Add(btn3);
                flowLayoutPanel.Controls.Add(btn4);
                flowLayoutPanel.Controls.Add(btn5);
                flowLayoutPanel.Controls.Add(btn6);
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
            MessageBox.Show("Please use the Test button on MainForm with process name and account file path provided.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void TestLogin(string processName, string accountDataFilePath)
        {
            // 1. Validate Process Name
            if (string.IsNullOrWhiteSpace(processName))
            {
                MessageBox.Show("Please enter a Process Name in the 'Process Name' field.", "Test - Missing Process Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validate Account Data File Path
            if (string.IsNullOrWhiteSpace(accountDataFilePath))
            {
                MessageBox.Show("Please select or enter an Account Data file path first.", "Test - Missing File Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(accountDataFilePath))
            {
                MessageBox.Show($"The specified account data file does not exist:\n{accountDataFilePath}", "Test - File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Check Running Processes
            Process[] allProcesses = Process.GetProcessesByName(processName);
            if (allProcesses.Length == 0)
            {
                MessageBox.Show($"No running processes found matching: \"{processName}\".\nPlease ensure your application is running.", "Test - No Processes Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ProcessData> processTitles = new List<ProcessData>();
            int emptyTitleCount = 0;
            foreach (Process p in allProcesses)
            {
                if (string.IsNullOrEmpty(p.MainWindowTitle))
                {
                    emptyTitleCount++;
                }
                else
                {
                    processTitles.Add(new ProcessData
                    {
                        TitleName = p.MainWindowTitle,
                        ProcessId = p.Id
                    });
                }
            }

            // 4. Validate Account Data File Contents
            string[] fileExtract;
            try
            {
                fileExtract = File.ReadAllLines(accountDataFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to read account data file:\n{ex.Message}", "Test - Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fileExtract.Length == 0)
            {
                MessageBox.Show("The account data file is empty.", "Test - Empty File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DataLoginFormat> detectedAccounts = new List<DataLoginFormat>();
            List<string> formatErrors = new List<string>();

            for (int i = 0; i < fileExtract.Length; i++)
            {
                string line = fileExtract[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    formatErrors.Add($"Line {i + 1}: Empty line");
                    continue;
                }

                string[] parts = line.Split(',');
                if (parts.Length != 5)
                {
                    formatErrors.Add($"Line {i + 1}: Expected 5 comma-separated values, found {parts.Length}");
                    continue;
                }

                if (!bool.TryParse(parts[4], out bool isValidBool))
                {
                    formatErrors.Add($"Line {i + 1}: Invalid login status '{parts[4]}' (must be True or False)");
                    continue;
                }

                detectedAccounts.Add(new DataLoginFormat
                {
                    nickname = parts[0],
                    username = parts[1],
                    password = parts[2],
                    secondPassword = parts[3],
                    isLogin = isValidBool,
                    LineIndex = i
                });
            }

            if (formatErrors.Count > 0)
            {
                string errorSummary = string.Join("\n", formatErrors.Take(5));
                if (formatErrors.Count > 5) errorSummary += $"\n... and {formatErrors.Count - 5} more";
                MessageBox.Show($"Found {formatErrors.Count} formatting error(s) in account data file:\n\n{errorSummary}", "Test - Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Match Processes with Accounts
            int matchedCount = 0;
            int readyToLoginCount = 0;
            int alreadyLoggedInCount = 0;
            List<string> unmatchedProcessTitles = new List<string>();

            foreach (ProcessData pData in processTitles)
            {
                DataLoginFormat? match = detectedAccounts.Find(d => d.nickname == pData.TitleName);
                if (match != null)
                {
                    matchedCount++;
                    if (match.isLogin)
                    {
                        alreadyLoggedInCount++;
                    }
                    else
                    {
                        readyToLoginCount++;
                    }
                }
                else
                {
                    unmatchedProcessTitles.Add(pData.TitleName);
                }
            }

            // 6. Check Steps Config
            string storageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");
            string configFilePath = Path.Combine(storageDirectory, "steps_config.json");
            int mainStepsCount = 0;
            int subStepsCount = 0;
            bool configExists = File.Exists(configFilePath);

            if (configExists)
            {
                try
                {
                    string json = File.ReadAllText(configFilePath);
                    var steps = JsonSerializer.Deserialize<List<TargetStepModel>>(json);
                    if (steps != null)
                    {
                        foreach (var s in steps)
                        {
                            if (s.IsSubStep) subStepsCount++;
                            else mainStepsCount++;
                        }
                    }
                }
                catch { }
            }

            // 7. Compose and Display Report
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== AUTO LOGIN VALIDATION TEST ===");
            sb.AppendLine();
            sb.AppendLine($"• Target Process: {processName}");
            sb.AppendLine($"• Total Instances Running: {allProcesses.Length} ({processTitles.Count} with window title)");
            if (emptyTitleCount > 0)
            {
                sb.AppendLine($"  ({emptyTitleCount} process(es) have no main window title yet)");
            }
            sb.AppendLine();
            sb.AppendLine($"• Account Data File: {Path.GetFileName(accountDataFilePath)}");
            sb.AppendLine($"• Total Accounts in File: {detectedAccounts.Count}");
            sb.AppendLine();
            sb.AppendLine($"• Matched Processes: {matchedCount}");
            sb.AppendLine($"  - Ready for Auto Login: {readyToLoginCount} process(es)");
            sb.AppendLine($"  - Already Logged In: {alreadyLoggedInCount} process(es)");

            if (unmatchedProcessTitles.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine($"[Warning] {unmatchedProcessTitles.Count} running process(es) do not match any account nickname:");
                foreach (string title in unmatchedProcessTitles.Take(3))
                {
                    sb.AppendLine($"  • \"{title}\"");
                }
                if (unmatchedProcessTitles.Count > 3)
                {
                    sb.AppendLine($"  ... and {unmatchedProcessTitles.Count - 3} more");
                }
            }

            sb.AppendLine();
            if (!configExists)
            {
                sb.AppendLine("[Warning] 'steps_config.json' not found! Please configure steps first.");
            }
            else
            {
                sb.AppendLine($"• Steps Configured: {mainStepsCount} Main Step(s), {subStepsCount} Sub-Step(s)");
            }

            sb.AppendLine();
            if (readyToLoginCount > 0)
            {
                sb.AppendLine($"Status: OK! Ready to login {readyToLoginCount} application(s).");
            }
            else if (matchedCount > 0 && readyToLoginCount == 0)
            {
                sb.AppendLine("Status: All matched applications are already logged in (isLogin = True).");
            }
            else
            {
                sb.AppendLine("Status: No applications are ready to login.");
            }

            MessageBoxIcon icon = readyToLoginCount > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning;
            MessageBox.Show(sb.ToString(), "Auto Login Test", MessageBoxButtons.OK, icon);
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
        private static void ButtonRestoreImportUsername_Click(object? sender, EventArgs e, string path)
        {
            string[]? text = ProcessForge.RefreshLogic.InputBox.Show("Please enter a new value:", "Input", false, "");
            if (text == null)
            {
                return;
            }
            if (sender is Button btn && btn.Tag is int data)
            {
                string[] lines = File.ReadAllLines(path);

                int StartsLine = data;
                string[] DataSplit = lines[StartsLine].Split(new string[] { "," }, StringSplitOptions.None);
                lines[StartsLine] = DataSplit[0] + "," + text[0] + "," + DataSplit[2] + "," + DataSplit[3] + "," + DataSplit[4];
                btn.Text = text[0];
                File.WriteAllLines(path, lines);
            }
            else
            {
                MessageBox.Show("Error, this one Import didn't provide any title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private static void ButtonRestoreImportPassword_Click(object? sender, EventArgs e, string path)
        {
            string[]? text = ProcessForge.RefreshLogic.InputBox.Show("Please enter a new value:", "Input", false, "");
            if (text == null)
            {
                return;
            }
            if (sender is Button btn && btn.Tag is int data)
            {
                string[] lines = File.ReadAllLines(path);

                int StartsLine = data;
                string[] DataSplit = lines[StartsLine].Split(new string[] { "," }, StringSplitOptions.None);
                lines[StartsLine] = DataSplit[0] + "," + DataSplit[1] + "," + text[0] + "," + DataSplit[3] + "," + DataSplit[4];
                btn.Text = text[0];
                File.WriteAllLines(path, lines);
            }
            else
            {
                MessageBox.Show("Error, this one Import didn't provide any title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private static void ButtonRestoreImportSecondPassword_Click(object? sender, EventArgs e, string path)
        {
            string[]? text = ProcessForge.RefreshLogic.InputBox.Show("Please enter a new value:", "Input", false, "");
            if (text == null)
            {
                return;
            }
            if (sender is Button btn && btn.Tag is int data)
            {
                string[] lines = File.ReadAllLines(path);

                int StartsLine = data;
                string[] DataSplit = lines[StartsLine].Split(new string[] { "," }, StringSplitOptions.None);
                lines[StartsLine] = DataSplit[0] + "," + DataSplit[1] + "," + DataSplit[2] + "," + text[0] + "," + DataSplit[4];
                btn.Text = text[0];
                File.WriteAllLines(path, lines);
            }
            else
            {
                MessageBox.Show("Error, this one Import didn't provide any title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private static void ButtonRestoreImportNickname_Click(object? sender, EventArgs e, string path)
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
                lines[StartsLine] = text[0] + "," + DataSplit[1] + "," + DataSplit[2] + "," + DataSplit[3] + "," + DataSplit[4];
                btn.Text = text[0];
                File.WriteAllLines(path, lines);
            }
            else
            {
                MessageBox.Show("Error, this one Import didn't provide any title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
