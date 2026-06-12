using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessForge.ApplicationLogic
{
    public static class DataProcessFromImport
    {
        public static List<List<string>> ProcessDataFromImport(string FilePath)
        {
            string notepadPath = FilePath;
            string NotepadImportData = string.Empty;

            List<List<string>> AllList = new List<List<string>>();
            List<string> Name = new List<string>();
            List<string> Status = new List<string>();

            if (File.Exists(notepadPath))
            {
                NotepadImportData = File.ReadAllText(notepadPath);
            }
            else
            {
                MessageBox.Show("File not found. Please check the file path and try again.");
                return AllList;
            }

            string[] NotepadExtract = NotepadImportData.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            

            for (int i = 0; i < NotepadExtract.Length; i++)
            {
                string[] NotepadExtractSpesific = NotepadExtract[i].Split(new string[] { "," }, StringSplitOptions.None);


                if (NotepadExtractSpesific.Length == 2)
                {
                    Name.Add(NotepadExtractSpesific[0]);
                    Status.Add(NotepadExtractSpesific[1]);
                }
                else
                {
                    MessageBox.Show("The notepad was not in the right format.\nThe wrong format: " + NotepadExtractSpesific[i] + "\n" + NotepadExtract[i].Length, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return AllList;
                }
            }
            AllList.Add(Name);
            AllList.Add(Status);
            return AllList;
        }
    }
}
