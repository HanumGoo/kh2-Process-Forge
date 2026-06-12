using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProcessForge.ApplicationLogic;


namespace ProcessForge.ComboBoxLogic
{
    public static class RenameUsingIncrementLogic
    {
        public static void RenameUsingIncrement(string appPath, int LowestIncrement, int HighestIncrement, string ProcessName)
        {
            string AppPath = appPath;
            int LowestResult = LowestIncrement;
            int HighestResult = HighestIncrement;

            if (LowestResult != 0 || HighestResult != 0)
            {

                List<string> IncrementAdd = new List<string>();
                for (int i = LowestResult; i < HighestResult + 1; i++)
                {
                    IncrementAdd.Add(i.ToString());
                }
                StartApplicationWithRenameLogic.StartApplicationWithRename(IncrementAdd, AppPath, ProcessName);
            }
            else
            {
                MessageBox.Show("Hey! Increment yang kamu berikan tidak boleh bernilai 0. mohon diperhatikan ya");
            }
        }
        
    }
}
