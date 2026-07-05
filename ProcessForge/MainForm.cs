using ProcessForge.ApplicationLogic;
using ProcessForge.FindWindowLogic;
using ProcessForge.RefreshLogic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProcessForge
{
    public partial class MainForm : Form
    {
        //for timer
        int secondsRemaining;

        //for Run 1
        bool isRun1Running = false;

        //for Run 2
        bool isRun2Running = false;
        bool isUsingCPUCheck = false;
        private CancellationTokenSource? _cts;

        //for BulkWindowForm
        BulkWindowForm? bulkWindowForm;
        //for ImportWindowForm
        ImportWindowForm? importWindowForm;
        //for AutoLoginWindowForm
        AutoLoginWindowForm? autoLoginWindowForm;

        string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public MainForm()
        {
            InitializeComponent();
            FormStartup();
        }
        private void FormStartup()
        {
            ComboBox.SelectedIndex = 0;
        }

        //clear the RAM by emptying the working set of the current process
        private void ClearRAM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProcessName.Text))
            {
                MessageBox.Show("Please enter a process name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClearUnusedMemoryLogic.ClearUnusedMemory(ProcessName.Text);
        }

        //browse for the executable file to run
        private void BrowseFile_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Executable Files (*.exe)|*.exe";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                FilePathName.Text = OFD.FileName;
            }
        }
        private void BrowseFileNotepad_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Text Files (*.txt)|*.txt";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                NotepadPathTextbox.Text = OFD.FileName;
            }
        }

        //test button for validating the click event
        private void ValidatingEvent_Click(object sender, EventArgs e)
        {
            decimal testmyint = TimeSetForClearRAM.Value;
            MSTimeSetLabel.Text = $"Validating - Time Set: {testmyint} ms";
        }

        //run the process with the given path and time for looping
        private void Run1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProcessName.Text))
            {
                MessageBox.Show("Please enter a process name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isRun1Running)
            {
                CountDownTimer.Stop();
                TimerForSeconds.Stop();
                Run1.Text = "Run";
                isRun1Running = false;
                CountDownSeconds.Text = "Count down event : Stopped";
                panel2.BackColor = Color.Red;

            }
            else
            {
                secondsRemaining = (int)TimeSetForClearRAM.Value / 1000;
                CountDownTimer.Interval = (int)TimeSetForClearRAM.Value;
                CountDownTimer.Start();
                TimerForSeconds.Start();

                Run1.Text = "Stop";
                isRun1Running = true;
                panel2.BackColor = Color.Green;
            }

        }
        private void TimerForSeconds_Tick(object sender, EventArgs e)
        {
            if (secondsRemaining > 0)
            {
                secondsRemaining--;
                CountDownSeconds.Text = $"Count down event : {secondsRemaining} seconds";
            }
        }
        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            secondsRemaining = (int)(TimeSetForClearRAM.Value / 1000);
            ApplicationLogic.ClearUnusedMemoryLogic.ClearUnusedMemoryWithoutMessageBox(ProcessName.Text);
        }
        //test button for validating the click event
        private void TestButton_Click(object sender, EventArgs e)
        {
            int RunTotal = (int)numericUpDown5.Value;
            string FilePath = FilePathName.Text;
            int MinRun = (int)numericUpDown1.Value;
            int MaxRun = (int)numericUpDown2.Value;
            int Application = (int)numericUpDown3.Value;
            int Delay = (int)numericUpDown4.Value;
            string ProcessNameString = ProcessName.Text;
            string renameText = RenameTextbox.Text;

            if (ComboBox.SelectedIndex == 0)
            {
                if (RunTotal <= 0)
                {
                    MessageBox.Show("Please enter a valid number of times to run the application.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show($"Running an Application for {RunTotal} times", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ComboBox.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(renameText))
                {
                    MessageBox.Show("Please enter a rename text.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (RunTotal <= 0)
                {
                    MessageBox.Show("Please enter a valid number of times to run the application.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show($"Running an Application for {RunTotal} times\nRenaming all Applications to {renameText}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ComboBox.SelectedIndex == 2)
            {
                if (MinRun > MaxRun || MinRun <= 0 || MaxRun <= 0)
                {
                    MessageBox.Show("Please ensure that the minimum and maximum run values are valid and the minimum is less than or equal to the maximum.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show($"Running an Application for {MaxRun - MinRun + 1} times\nRenaming all Applications from {MinRun} to {MaxRun}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ComboBox.SelectedIndex == 3)
            {
                try
                {
                    string NotepadPath = NotepadPathTextbox.Text;
                    string[] NotepadContent = File.ReadAllLines(NotepadPath);

                    int runCounter = 0;
                    foreach (string line in NotepadContent)
                    {
                        string[] NotepadExtract = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                        if (NotepadExtract.Length != 2)
                        {
                            MessageBox.Show($"valid data! : {line}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (NotepadExtract[1] == "NotExist")
                        {
                            runCounter++;
                        }
                    }

                    MessageBox.Show($"Running an Application for {runCounter} times\nRenaming all Applications based on the content of the txt file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error! : {ex.Message}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        //run the process with the given path and time for looping

        private async void Run2_Click(object sender, EventArgs e)
        {
            if (isRun2Running)
            {
                _cts?.Cancel();
                return;
            }

            int RunTotal = (int)numericUpDown5.Value;
            string FilePath = FilePathName.Text;
            int Application = (int)numericUpDown3.Value;
            int Delay = (int)numericUpDown4.Value;
            string ProcessNameString = ProcessName.Text;

            isRun2Running = true;
            panel3.BackColor = Color.Green;
            Run2.Text = "Stop";
            _cts = new CancellationTokenSource();

            try
            {
                if (ComboBox.SelectedIndex == 0)
                {
                    //none selection
                    if (RunTotal <= 0)
                    {
                        MessageBox.Show("Please enter a valid number of times to run the application.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    await StartApplicationWithRenameLogic.StartApplicationWithoutRename(RunTotal, FilePath, Application, Delay, ProcessNameString, _cts.Token, isUsingCPUCheck);
                    return;
                }
                if (ComboBox.SelectedIndex == 1)
                {
                    //manually rename selection
                    if (string.IsNullOrEmpty(RenameTextbox.Text))
                    {
                        MessageBox.Show("Please enter a rename text.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (RunTotal <= 0)
                    {
                        MessageBox.Show("Please enter a valid number of times to run the application.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    List<string> DataID = new List<string>();

                    for (int i = 0; i < RunTotal; i++)
                    {
                        DataID.Add($"{RenameTextbox.Text}");
                    }

                    await StartApplicationWithRenameLogic.StartApplicationWithRename(DataID, FilePath, Application, Delay, ProcessNameString, _cts.Token, isUsingCPUCheck);
                    return;
                }
                if (ComboBox.SelectedIndex == 2)
                {
                    //rename using increment selection
                    int FirstRange = (int)numericUpDown1.Value;
                    int SecondRange = (int)numericUpDown2.Value;

                    if (FirstRange > SecondRange || FirstRange <= 0 || SecondRange <= 0)
                    {
                        MessageBox.Show("Please ensure that the minimum and maximum run values are valid and the minimum is less than or equal to the maximum.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    List<string> DataID = new List<string>();

                    for (int i = FirstRange; i <= SecondRange; i++)
                    {
                        DataID.Add($"{i}");
                    }

                    await StartApplicationWithRenameLogic.StartApplicationWithRename(DataID, FilePath, Application, Delay, ProcessNameString, _cts.Token, isUsingCPUCheck);
                    return;
                }
                if (ComboBox.SelectedIndex == 3)
                {
                    //rename using import selection
                    try
                    {
                        await StartApplicationWithRenameLogic.StartApplicationWithRenameWithImport(FilePath, NotepadPathTextbox.Text, Application, Delay, ProcessNameString, _cts.Token, isUsingCPUCheck);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("The operation was successfully canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                panel3.BackColor = Color.Red;
                isRun2Running = false;
                Run2.Text = "Run";
                _cts.Dispose();
                _cts = null;
            }

        }

        //terminate the process with the given path
        private void Terminate_Click(object sender, EventArgs e)
        {
            string ProcessNameString = ProcessName.Text;
            if (string.IsNullOrEmpty(ProcessNameString))
            {
                MessageBox.Show("Please enter a valid process name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TerminateApplicationLogic.TerminateApplication(ProcessNameString);
            return;
        }

        private void OpenBulkWindow_Click(object sender, EventArgs e)
        {
            if (bulkWindowForm == null || bulkWindowForm.IsDisposed)
            {
                if (string.IsNullOrEmpty(ProcessName.Text))
                {
                    MessageBox.Show("please add process name first at the main form", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bulkWindowForm = new BulkWindowForm(ProcessName.Text);
                bulkWindowForm.Show();
            }
        }
        private void OpenWindowImportThing_Click(object sender, EventArgs e)
        {
            if (importWindowForm == null || importWindowForm.IsDisposed)
            {
                importWindowForm = new ImportWindowForm();
                importWindowForm.Show();
            }
        }


        //event handler for the combo box selection change, currently empty
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox.SelectedIndex == 0)
            {
                ComboBoxSelectedIndex0();
            }
            if (ComboBox.SelectedIndex == 1)
            {
                ComboBoxSelectedIndex1();
            }
            if (ComboBox.SelectedIndex == 2)
            {
                ComboBoxSelectedIndex2();
            }
            if (ComboBox.SelectedIndex == 3)
            {
                ComboBoxSelectedIndex3();
            }
        }
        private void ComboBoxSelectedIndex0()
        {
            //none selection
            //RunTotalLabel.Location = new Point(515, RunTotalLabel.Location.Y);
            //numericUpDown5.Location = new Point(515, numericUpDown5.Location.Y);
            //MaxLabel.Location = new Point(515, MaxLabel.Location.Y);
            RunTotalLabel.Visible = true;
            numericUpDown5.Visible = true;
            MaxLabel.Visible = true;


            RenameLabel.Visible = false;
            RenameTextbox.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            DelimiterToLabel.Visible = false;
            NotepadPathTextbox.Visible = false;
            BrowseFileNotepad.Visible = false;
        }
        private void ComboBoxSelectedIndex1()
        {
            //Manually rename selection
            //RunTotalLabel.Location = new Point(860, RunTotalLabel.Location.Y);
            //numericUpDown5.Location = new Point(860, numericUpDown5.Location.Y);
            //MaxLabel.Location = new Point(860, MaxLabel.Location.Y);
            RenameLabel.Text = "Rename Application Name";
            RenameLabel.Visible = true;
            RenameTextbox.Visible = true;
            RunTotalLabel.Visible = true;
            numericUpDown5.Visible = true;
            MaxLabel.Visible = true;


            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            DelimiterToLabel.Visible = false;
            NotepadPathTextbox.Visible = false;
            BrowseFileNotepad.Visible = false;
        }
        private void ComboBoxSelectedIndex2()
        {
            //Rename using increment selection
            RenameLabel.Text = "Rename Application by Increment";
            RenameLabel.Visible = true;
            numericUpDown1.Visible = true;
            numericUpDown2.Visible = true;
            DelimiterToLabel.Visible = true;


            RenameTextbox.Visible = false;
            RunTotalLabel.Visible = false;
            numericUpDown5.Visible = false;
            MaxLabel.Visible = false;
            NotepadPathTextbox.Visible = false;
            BrowseFileNotepad.Visible = false;
        }
        private void ComboBoxSelectedIndex3()
        {
            //Rename using import selection
            RenameLabel.Text = "Rename Application by Import";
            RenameLabel.Visible = true;
            NotepadPathTextbox.Visible = true;
            BrowseFileNotepad.Visible = true;

            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            RenameTextbox.Visible = false;
            RunTotalLabel.Visible = false;
            numericUpDown5.Visible = false;
            MaxLabel.Visible = false;
            DelimiterToLabel.Visible = false;

        }

        private void CPUChecker_Click(object sender, EventArgs e)
        {
            if (isUsingCPUCheck)
            {
                isUsingCPUCheck = false;
                CPUChecker.BackColor = Color.Red;
                CPUChecker.Text = "Off";
            }
            else
            {
                isUsingCPUCheck = true;
                CPUChecker.BackColor = Color.Green;
                CPUChecker.Text = "On";
            }
        }

        private void browseAccount_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Text Files (*.txt)|*.txt";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                FilePathNameLogin.Text = OFD.FileName;
            }
        }

        private void accountFileHandler_Click(object sender, EventArgs e)
        {
            if (autoLoginWindowForm == null || autoLoginWindowForm.IsDisposed)
            {
                if (string.IsNullOrEmpty(ProcessName.Text))
                {
                    MessageBox.Show("please add process name first at the main form", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                autoLoginWindowForm = new AutoLoginWindowForm();
                autoLoginWindowForm.Show();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(FilePathNameLogin.Text) || string.IsNullOrEmpty(FilePathNameLogin.Text))
            {
                MessageBox.Show("Error! : the account data file path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AutoLoginLogic.RefreshLogin(flowLayoutPanel, ProcessName.Text, FilePathNameLogin.Text);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(FilePathNameLogin.Text) || string.IsNullOrEmpty(FilePathNameLogin.Text))
            {
                MessageBox.Show("Error! : the account data file path isnt right or you didn't add one.", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AutoLoginLogic.ResetLogin(FilePathNameLogin.Text);
        }

        private void testLogin_Click(object sender, EventArgs e)
        {
            AutoLoginLogic.TestLogin();
        }

        private async void runLogin_Click(object sender, EventArgs e)
        {
            await AutoLoginLogic.RunAutoLogin();
        }

        private void txtSearchLogin_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchLogin.Text.ToLower();

            bool isTrue = false;
            bool isTrueSecond = false;
            foreach (Control control in flowLayoutPanel.Controls)
            {

                if (control is System.Windows.Forms.Button button)
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
    }
}
