using ProcessForge.RefreshLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProcessForge
{
    public partial class ImportWindowForm : Form
    {
        //check import status
        bool isUsingImport = true;

        //page
        int PageCount = 1;

        public ImportWindowForm()
        {
            InitializeComponent();
            FormStartup();
        }
        public void FormStartup()
        {
            ProcessListLabel.Text = $"Import List";
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshFunction();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (PageCount == 1)
            {
                return;
            }
            PageCount -= 1;
            RefreshFunction();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            string path = ImportTextbox.Text;

            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] AllData = File.ReadAllText(path).Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (AllData.Length < PageCount * 100)
            {
                return;
            }
            PageCount += 1;
            RefreshFunction();
        }
        private void RefreshFunction()
        {
            if (!isUsingImport)
            {
                //RefreshLogic.RefreshLogic.Refresh(flowLayoutPanel, LabelPage, PageCount, ProcessTitle);
            }
            else
            {
                string path = ImportTextbox.Text;

                if (!File.Exists(path) || string.IsNullOrEmpty(path))
                {
                    MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string[] AllData = File.ReadAllText(path).Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
                List<List<string>> AllDataImport = new List<List<string>>
                    {
                        new List<string>(),
                        new List<string>()
                    };


                foreach (string item in AllData)
                {
                    string[] TitleAndStatus = item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    if (TitleAndStatus.Length != 2)
                    {
                        MessageBox.Show("Import Data error! please check this one: \n" + item, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    AllDataImport[0].Add(TitleAndStatus[0]);
                    AllDataImport[1].Add(TitleAndStatus[1]);
                }

                RefreshLogic.RefreshLogic.RefreshWIthNotepadImport(flowLayoutPanel, LabelPage, PageCount, ImportTextbox.Text, AllDataImport);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            bool isTrue = false;
            bool isTrueSecond = false;
            foreach (Control control in flowLayoutPanel.Controls)
            {

                if (control is Button button)
                {
                    if (button.Tag is ButtonData data)
                    {
                        if (data.Text.ToLower().Contains(search))
                        {
                            button.Visible = true;
                            isTrue = true;
                        }
                        else
                        {
                            button.Visible = false;
                            isTrue = false;
                        }
                    }
                    else if (isTrue)
                    {
                        button.Visible = true;
                        isTrue = false;
                        isTrueSecond = true;
                    }
                    else
                    {
                        if (isTrueSecond)
                        {
                            button.Visible = true;
                            isTrueSecond = false;
                        }
                        else
                        {
                            button.Visible = false;
                        }
                    }
                }
            }
        }

        private void OnOffImport_Click(object sender, EventArgs e)
        {
            DialogResult messageBoxResult = MessageBox.Show("Are you sure want to reset all status\nto \"NotExist\"?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (messageBoxResult != DialogResult.Yes)
            {
                return;
            }

            string path = ImportTextbox.Text;

            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] AllData = File.ReadAllLines(path);
            List<string> AllDataImport = new List<string>();



            foreach (string item in AllData)
            {
                string[] TitleAndStatus = item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                if (TitleAndStatus.Length != 2)
                {
                    MessageBox.Show("Import Data error! please check this one: \n" + item, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AllDataImport.Add(TitleAndStatus[0] + ",NotExist");
            }

            File.WriteAllLines(path, AllDataImport);
            RefreshFunction();
        }

        private void CheckImport_Click(object sender, EventArgs e)
        {
            string path = ImportTextbox.Text;

            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] AllData = File.ReadAllText(path).Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);


            foreach (string item in AllData)
            {
                string[] TitleAndStatus = item.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                if (TitleAndStatus.Length != 2)
                {
                    MessageBox.Show("Import Data error! please check this one: \n" + $"\"{item}\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (TitleAndStatus[1] == "NotExist" || TitleAndStatus[1] == "Exist")
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("Import Data error! please check this one(status error): \n" + $"\"{item}\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            MessageBox.Show("The import file was valid.\nReady to go!", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImportBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = ".txt file (*.txt)|*.txt";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                ImportTextbox.Text = OFD.FileName;
                RefreshFunction();
            }

        }

        private void AddDatabutton_Click(object sender, EventArgs e)
        {
            string path = ImportTextbox.Text;

            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[]? text = ProcessForge.RefreshLogic.InputBox.Show("new data (can be bulk using new line) : ", "Input", true, "");
            if (text == null || text[0] == "")
            {
                return;
            }

            string[] lines = File.ReadAllLines(path);

            List<string> linesList = lines.ToList();

            foreach (string item in text)
            {
                linesList.Add(item + ",NotExist");
            }


            File.WriteAllLines(path, linesList);
            RefreshFunction();
        }

        private void NewImportFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            FBD.Description = "Choose folder";
            FBD.UseDescriptionForTitle = true; // Menampilkan deskripsi sebagai judul
            FBD.ShowNewFolderButton = true;   // Mengizinkan buat folder baru

            string selectedPath;


            if (FBD.ShowDialog() == DialogResult.OK)
            {
                // Ambil path folder yang dipilih
                selectedPath = FBD.SelectedPath;
                //MessageBox.Show("Folder yang dipilih: " + selectedPath, "Informasi");
            }
            else
            {
                return;
            }

            string[]? fileName = ProcessForge.RefreshLogic.InputBox.Show("File Name : ", "Input", false, "");

            if (fileName == null)
            {
                //MessageBox.Show("No title no create then", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (fileName[0] == "")
            {
                MessageBox.Show("No title no create then", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            string[]? bulkData = ProcessForge.RefreshLogic.InputBox.Show("new/first data (optional) : ", "Input", true, "");

            if (bulkData == null)
            {
                return;
            }

            List<string> bulkImportData = new List<string>();

            foreach (string item in bulkData)
            {
                bulkImportData.Add(item + ",NotExist");
            }

            string pathFileCombine = Path.Combine(selectedPath, fileName[0] + ".txt");
            if (File.Exists(pathFileCombine))
            {
                DialogResult fileExist = MessageBox.Show("file already exist with that file name. replace it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.None);

                if (fileExist == DialogResult.Yes)
                {
                    File.WriteAllLines(pathFileCombine, bulkImportData);
                    MessageBox.Show("Create import file success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            else
            {
                File.WriteAllLines(pathFileCombine, bulkImportData);
                MessageBox.Show("Create import file success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

       
    }
}
