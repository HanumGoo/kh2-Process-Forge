using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ProcessForge.ApplicationLogic;

namespace ProcessForge.FindWindowLogic
{
    public static class GetAndFindWindow
    {
        private const int SW_RESTORE = 9;
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void UpdateListbox(ListBox listBox, string NotepadFilePath, string ProcessName)
        {
            listBox.Items.Clear();
            Process[] AllApplicationProcess = Process.GetProcessesByName(ProcessName);
            List<string> ProcessNameList = new List<string>();


            foreach (Process p in AllApplicationProcess)
            {
                IntPtr hWnd = p.MainWindowHandle;

                if (hWnd != IntPtr.Zero)
                {
                    StringBuilder MySB = new StringBuilder(256);
                    int Title = GetWindowText(hWnd, MySB, MySB.Capacity);

                    if (Title != 0)
                    {
                        ProcessNameList.Add(MySB.ToString());
                    }

                }
                else
                {
                    MessageBox.Show($"there is no {ProcessName} opened. check again please?");
                    return;
                }
            }

            List<List<string>> AllDataFromNotepad = DataProcessFromImport.ProcessDataFromImport(NotepadFilePath);
            List<string> NewDataStructure = new List<string>();

            for (int o = 0; o < ProcessNameList.Count; o++)
            {
                bool CheckingTheStatus = false;



                for (int i = 0; i < AllDataFromNotepad[0].Count; i++)
                {

                    if (ProcessNameList[o] == AllDataFromNotepad[0][i])
                    {
                        ProcessNameList[o] = ProcessNameList[o] + " | Status: " + AllDataFromNotepad[1][i];
                        CheckingTheStatus = true;
                        break;
                    }
                    else
                    {

                    }
                }

                if (CheckingTheStatus)
                {
                    //listBox1.Items.Add(ProcessName[o]);
                    NewDataStructure.Add(ProcessNameList[o]);
                }
                else
                {
                    //listBox1.Items.Add(ProcessName[o] + "     | Status : No Account in notepad Import");
                    NewDataStructure.Add(ProcessName[o] + " | Status: No Item in notepad Import");
                }
            }
            //NewDataStructure.Sort();
            foreach (string s in NewDataStructure)
            {
                listBox.Items.Add(s);
            }
        }
        public static void WindowRestore(string TitleName)
        {

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                IntPtr hWnd = FindWindow(null, TitleName);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, SW_RESTORE);

                }
                else
                {
                    MessageBox.Show("fail2");
                }


            
        }
    }
}
