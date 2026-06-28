using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProcessForge.ApplicationLogic
{
    public class TerminateApplicationLogic
    {
        public static void TerminateApplication(string ProcessName)
        {
            DialogResult MB = MessageBox.Show("Are you sure terminate all " + ProcessName + " process?", "You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (MB == DialogResult.Yes)
            {
                Process[] AllINCProcess = Process.GetProcessesByName(ProcessName);

                if (AllINCProcess.Length == 0)
                {
                    MessageBox.Show("there is no " + ProcessName + " process running, are you sure you have it open?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (Process p in AllINCProcess)
                {
                    p.Kill();
                }
            }
            else
            {

            }
        }
        public static bool TerminateApplicationUsingId(int id)
        {
            DialogResult MB = MessageBox.Show("Are you sure terminate this app id : " + id + " process?", "You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (MB == DialogResult.Yes)
            {
                Process AllINCProcess = Process.GetProcessById(id);

                if (AllINCProcess == null)
                {
                    MessageBox.Show("there is no " + id + " ID process running, are you sure you have it open?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                
                    AllINCProcess.Kill();
                    return true;

            }
            else
            {
                return false;
            }
        }
    }
}
