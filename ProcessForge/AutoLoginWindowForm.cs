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
    public partial class AutoLoginWindowForm : Form
    {
        //check import status
        bool isUsingImport = true;

        //page
        int PageCount = 1;

        public AutoLoginWindowForm()
        {
            InitializeComponent();
            FormStartup();
        }
        public void FormStartup()
        {
            ProcessListLabel.Text = $"Account File Handler";
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {

        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {

        }

        private void NextButton_Click(object sender, EventArgs e)
        {

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
            
        }

        private void CheckImport_Click(object sender, EventArgs e)
        {
            string path = ImportTextbox.Text;
            if (!File.Exists(path) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Error! : the path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void ImportBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = ".txt file (*.txt)|*.txt";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                ImportTextbox.Text = OFD.FileName;
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
