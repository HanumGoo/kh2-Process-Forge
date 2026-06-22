using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProcessForge.ApplicationLogic
{
    public class StartApplicationWithRenameLogic
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_MINIMIZE = 6;
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);



        public async static Task StartApplicationWithRename(List<string> DataID, string Path, int ApplicationCount, int Delay, string ProcessName, CancellationToken Token, bool isUsingCPUCheck)
        {
            try
            {
                //List<Process> AllProcessRun = new List<Process>();
                Token.ThrowIfCancellationRequested();
                for (int i = 0; i < DataID.Count; i++)
                {
                    Token.ThrowIfCancellationRequested();
                    if (i % ApplicationCount == 0)
                    {
                        await Task.Delay(Delay, Token);
                        ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName);
                        //CheckerUltimate(AllProcessRun);
                    }

                    if (isUsingCPUCheck)
                    {
                        Token.ThrowIfCancellationRequested();

                        CpuMonitor cpu = new CpuMonitor();
                        await Task.Delay(1000, Token);
                        float cpuUsage = await cpu.GetCpuUsage();
                        //MessageBox.Show($"Current CPU Usage: {cpuUsage:F2}%");

                        while (cpuUsage > 80)
                        {
                            Token.ThrowIfCancellationRequested();

                            await Task.Delay(2000, Token);// Wait for 1 second before checking again
                            cpuUsage = await cpu.GetCpuUsage();
                        }
                    }

                    Process Application = Process.Start(Path);
                    await Task.Delay(500, Token);
                    Application.WaitForInputIdle();
                    Application.Refresh();
                    IntPtr ApplicationHandle = GetMainWindowHandleByPid(Application.Id);

                    if (ApplicationHandle == IntPtr.Zero)
                    {
                        MessageBox.Show("Error! process not found. call sheehan for help");
                        return;
                    }
                    else
                    {
                        ShowWindow(ApplicationHandle, SW_MINIMIZE);
                        SetWindowText(ApplicationHandle, DataID[i]);
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error di StartApplicationWithRename : " + ex.Message);
            }
        }
        public async static Task StartApplicationWithRenameWithImport(string Path, string notepadPath, int ApplicationCount, int Delay, string ProcessName, CancellationToken Token, bool isUsingCPUCheck)
        {
            try
            {
                Token.ThrowIfCancellationRequested();
                string NotepadPath = notepadPath;

                string NotepadContent = File.ReadAllText(NotepadPath);

                string[] NotepadExtract = NotepadContent.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> IDData = new List<string>();
                List<string> StatusData = new List<string>();

                foreach (string IDPassword in NotepadExtract)
                {
                    Token.ThrowIfCancellationRequested();
                    string[] IDStatusData = IDPassword.Split(new string[] { "," }, StringSplitOptions.None);

                    if (IDStatusData.Length == 2)
                    {
                        IDData.Add(IDStatusData[0]);
                        StatusData.Add(IDStatusData[1]);
                    }
                    else
                    {
                        MessageBox.Show("There is an error from your notepad data!\nBroke Data : " + IDStatusData[0], "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }

                //for (int i = 0; i < IDData.Count; i++)
                //{
                //    MessageBox.Show("ID : " + IDData[i] + "notepad: " + NotepadExtract[i] + "Hello");
                //}

                //List<Process> AllProcessRun = new List<Process>();
                StringBuilder MySB = new StringBuilder();

                for (int i = 0; i < NotepadExtract.Length; i++)
                {
                    

                    Token.ThrowIfCancellationRequested();
                    if (StatusData[i] == "NotExist")
                    {
                        if (i % ApplicationCount == 0)
                        {
                            Token.ThrowIfCancellationRequested();
                            await Task.Delay(Delay, Token);
                            ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName);
                            //CheckerUltimate(AllProcessRun);


                        }

                        if (isUsingCPUCheck)
                        {
                            Token.ThrowIfCancellationRequested();

                            CpuMonitor cpu = new CpuMonitor();
                            await Task.Delay(1000, Token);
                            float cpuUsage = await cpu.GetCpuUsage();
                            //MessageBox.Show($"Current CPU Usage: {cpuUsage:F2}%");

                            while (cpuUsage > 80)
                            {
                                Token.ThrowIfCancellationRequested();

                                await Task.Delay(2000, Token);// Wait for 1 second before checking again
                                cpuUsage = await cpu.GetCpuUsage();
                            }
                        }

                        Process Application = Process.Start(Path);
                        await Task.Delay(500, Token);
                        Application.WaitForInputIdle();
                        Application.Refresh();
                        IntPtr ApplicationHandle = GetMainWindowHandleByPid(Application.Id);


                        if (ApplicationHandle == IntPtr.Zero)
                        {
                            MessageBox.Show("Error! process not found. call sheehan for help");
                            return;
                        }
                        else
                        {
                            ShowWindow(ApplicationHandle, SW_MINIMIZE);
                            SetWindowText(ApplicationHandle, IDData[i]);
                            StatusData[i] = "Exist";
                            MySB.Append(IDData[i] + "," + StatusData[i]);

                            if (i < NotepadExtract.Length - 1)
                            {
                                MySB.Append(Environment.NewLine);
                            }
                            








                        }
                    }
                    else
                    {

                    }


                }

                File.WriteAllText(notepadPath, MySB.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("error from StartApplicationWithRename : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async static Task StartApplicationWithoutRename(int TotalRunINT, string Path, int ApplicationCount, int Delay, string ProcessName, CancellationToken Token, bool isUsingCPUCheck)
        {
            try
            {
                //List<Process> AllProcessRun = new List<Process>();
                Token.ThrowIfCancellationRequested();
                for (int i = 0; i < TotalRunINT; i++)
                {
                    Token.ThrowIfCancellationRequested();
                    if (i % ApplicationCount == 0)
                    {
                        Token.ThrowIfCancellationRequested();
                        await Task.Delay(Delay, Token);
                        ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName);
                        //CheckerUltimate(AllProcessRun);
                    }

                    if (isUsingCPUCheck)
                    {
                        Token.ThrowIfCancellationRequested();

                        CpuMonitor cpu = new CpuMonitor();
                        await Task.Delay(1000, Token);
                        float cpuUsage = await cpu.GetCpuUsage();
                        //MessageBox.Show($"Current CPU Usage: {cpuUsage:F2}%");

                        while (cpuUsage > 80)
                        {
                            Token.ThrowIfCancellationRequested();

                            await Task.Delay(2000, Token);// Wait for 1 second before checking again
                            cpuUsage = await cpu.GetCpuUsage();
                        }
                    }

                    Process Application = Process.Start(Path);
                    await Task.Delay(500, Token);
                    Application.WaitForInputIdle();
                    Application.Refresh();
                    IntPtr ApplicationHandle = GetMainWindowHandleByPid(Application.Id);

                    if (ApplicationHandle == IntPtr.Zero)
                    {
                        MessageBox.Show("Error! process not found. call sheehan for help");
                        return;
                    }
                    else
                    {
                        ShowWindow(ApplicationHandle, SW_MINIMIZE);
                        //MessageBox.Show("Handle Found! : " + ApplicationHandle.ToString());
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void CheckerUltimate(List<Process> AllProcessRun)
        {
            bool Checker = false;
            while (Checker == false)
            {

                List<float> cpuUsageAll = new List<float>();
                foreach (Process p in AllProcessRun)
                {
                    Thread.Sleep(2000);
                    string InstanceName = GetProcessInstanceName(p.Id);

                    if (InstanceName == "Not Found")
                    {
                        MessageBox.Show("Name not found with the corresponding ID");
                        return;
                    }
                    PerformanceCounter counter = new PerformanceCounter("Process", "% Processor Time", InstanceName);

                    cpuUsageAll.Add(counter.NextValue());



                }
                int counterforfloat = 0;
                foreach (float thefloat in cpuUsageAll)
                {
                    if (thefloat > 6)
                    {
                        counterforfloat++;
                    }
                    else
                    {

                    }
                }

                if (counterforfloat == 0)
                {
                    Checker = true;
                }
                else
                {

                }

            }
        }
        private static IntPtr GetMainWindowHandleByPid(int pid)
        {
            IntPtr foundHandle = IntPtr.Zero;

            EnumWindows((hWnd, lParam) =>
            {
                GetWindowThreadProcessId(hWnd, out uint windowPid);
                if (windowPid == pid)
                {
                    foundHandle = hWnd;
                    return false; // Stop enumeration
                }
                return true; // Continue
            }, IntPtr.Zero);

            return foundHandle;
        }

        private static string GetProcessInstanceName(int ProcessID)
        {
            PerformanceCounterCategory category = new PerformanceCounterCategory("Process");
            string[] instances = category.GetInstanceNames();

            foreach (string instance in instances)
            {
                // Match the instance to the PID
                using (PerformanceCounter counter = new PerformanceCounter("Process", "ID Process", instance, true))
                {
                    if ((int)counter.RawValue == ProcessID)
                    {
                        return instance; // Return the matching instance name
                    }
                }
            }
            return "Not Found";
        }
    }
}
