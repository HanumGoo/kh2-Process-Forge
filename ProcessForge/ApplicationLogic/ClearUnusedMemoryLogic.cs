using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ProcessForge.ApplicationLogic
{
    public static class ClearUnusedMemoryLogic
    {
        [DllImport("psapi.dll")]
        public static extern bool EmptyWorkingSet(IntPtr hProcess);
        private static void ClearUnusedMemory(string processName)
        {
            string processname = processName;

            Process[] AllProcess = Process.GetProcessesByName(processname);


            if (AllProcess.Length > 0)
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("Berhasil mengompres cina\n");
                foreach (Process process in AllProcess)
                {
                    bool result = EmptyWorkingSet(process.Handle);
                    if (result)
                    {
                        sb.Append("Process Name : " + process.ProcessName + " Process ID : " + process.Id + "\n");
                    }
                    else
                    {
                        MessageBox.Show("gagal, Seharusnya gk bisa gagal ya. tapi entah kenapa gagal", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                MessageBox.Show(sb.ToString(), "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("There's no Process name inc.exe. Are you really open it?");
            }
        }
        public static void ClearUnusedMemoryWithoutMessageBox(string processName)
        {
            string processname = processName;

            Process[] AllProcess = Process.GetProcessesByName(processname);


            if (AllProcess.Length > 0)
            {
                foreach (Process process in AllProcess)
                {
                    bool result = EmptyWorkingSet(process.Handle);
                    if (result)
                    {

                    }
                    else
                    {
                        return;
                    }
                }


            }
            else
            {

            }
        }
    }
}
