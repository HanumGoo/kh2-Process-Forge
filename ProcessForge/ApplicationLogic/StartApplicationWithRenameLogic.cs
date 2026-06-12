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



        public static void StartApplicationWithRename(List<string> DataID, string Path, string ProcessName)
        {
            try
            {
                List<Process> AllProcessRun = new List<Process>();

                for (int i = 0; i < DataID.Count; i++)
                {

                    if (i != 0 && i % 4 == 0)
                    {
                        //Thread.Sleep(30000);
                        ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName);
                        //CheckerUltimate(AllProcessRun);


                    }
                    if (i != 0 && i % 20 == 0)
                    {
                        //Thread.Sleep(150000);
                        ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName);
                        //CheckerUltimate(AllProcessRun);


                    }

                    Process Application = Process.Start(Path);

                    Application.WaitForInputIdle();

                    AllProcessRun.Add(Application);
                    IntPtr ApplicationHandle = Application.MainWindowHandle;


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
        public static void StartApplicationWithRenameWithImport(List<string> DataID, string Path, string notepadPath, string ProcessName)
        {
            try
            {
                string NotepadPath = notepadPath;

                string NotepadContent = File.ReadAllText(NotepadPath);

                string[] NotepadExtract = NotepadContent.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                List<string> IDData = new List<string>();
                List<string> StatusData = new List<string>();

                foreach (string IDPassword in NotepadExtract)
                {
                    string[] IDStatusData = IDPassword.Split(new string[] { "," }, StringSplitOptions.None);

                    if (IDStatusData.Length == 2)
                    {
                        IDData.Add(IDStatusData[0]);
                        StatusData.Add(IDStatusData[1]);
                    }
                    else
                    {
                        MessageBox.Show("Terjadi kesalahan data pada database notepad, mohon di cek kembali ya!\nData yang rusak : " + IDStatusData[0], "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }

                //List<Process> AllProcessRun = new List<Process>();
                StringBuilder MySB = new StringBuilder();

                for (int i = 0; i < NotepadExtract.Length; i++)
                {
                    if (StatusData[i] == "NotExist")
                    {
                        if (i != 0 && i % 4 == 0)
                        {
                            //Thread.Sleep(30000);
                            ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName);
                            //CheckerUltimate(AllProcessRun);


                        }
                        if (i != 0 && i % 20 == 0)
                        {
                            //Thread.Sleep(150000);
                            ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName);
                            //CheckerUltimate(AllProcessRun);


                        }

                        Process Application = Process.Start(Path);

                        Application.WaitForInputIdle();

                        //AllProcessRun.Add(Application);
                        IntPtr ApplicationHandle = Application.MainWindowHandle;


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
                                MySB.Append("\n");
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
                MessageBox.Show("error di StartApplicationWithRename : " + ex.Message);
            }
        }
        public static void StartApplicationWithoutRename(int TotalRunINT, string Path, string ProcessName)
        {
            try
            {
                //List<Process> AllProcessRun = new List<Process>();

                for (int i = 0; i < TotalRunINT; i++)
                {
                    if (i != 0 && i % 4 == 0)
                    {
                        //Thread.Sleep(30000);
                        ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName);
                        //CheckerUltimate(AllProcessRun);



                    }
                    if (i != 0 && i % 20 == 0)
                    {
                        //Thread.Sleep(150000);
                        ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName);
                        //CheckerUltimate(AllProcessRun);


                    }

                    Process Application = Process.Start(Path);

                    Application.WaitForInputIdle();
                    //AllProcessRun.Add(Application);
                    IntPtr ApplicationHandle = Application.MainWindowHandle;


                    if (ApplicationHandle == IntPtr.Zero)
                    {
                        MessageBox.Show("Error! process not found. call sheehan for help");
                        return;
                    }
                    else
                    {
                        ShowWindow(ApplicationHandle, SW_MINIMIZE);
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
                        MessageBox.Show("Tidak ketemu nama dengan ID yang sesuai");
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
