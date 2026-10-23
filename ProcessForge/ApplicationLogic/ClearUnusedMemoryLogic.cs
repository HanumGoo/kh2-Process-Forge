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
        public static void ClearUnusedMemory(string processName)
        {
            string processname = processName;

            Process[] AllProcess = Process.GetProcessesByName(processname);

            if (AllProcess.Length > 0)
            {

                StringBuilder sb = new StringBuilder();
                sb.Append($"Success Clearing {processName}!\n");
                foreach (Process process in AllProcess)
                {
                    bool result = EmptyWorkingSet(process.Handle);
                    if (result)
                    {
                        sb.Append("Name: " + process.ProcessName + ", ID: " + process.Id + "\n");
                    }
                    else
                    {
                        MessageBox.Show("gagal, Seharusnya gk bisa gagal ya. tapi entah kenapa gagal", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                MessageBox.Show(sb.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show($"There's no Process name {processName}. Are you really open it?");
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

        public static bool ClearMemoryForProcess(int processId)
        {
            if (processId <= 0) return false;
            try
            {
                using Process process = Process.GetProcessById(processId);
                return EmptyWorkingSet(process.Handle);
            }
            catch
            {
                return false;
            }
        }
    }
}
