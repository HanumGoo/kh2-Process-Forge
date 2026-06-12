using System.Runtime.InteropServices;

namespace ProcessForge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        //clear the RAM by emptying the working set of the current process
        private void ClearRAM_Click(object sender, EventArgs e)
        {
             
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

        //test button for validating the click event
        private void ValidatingEvent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Validating");
        }

        //run the process with the given path and time for looping
        private void Run1_Click(object sender, EventArgs e)
        {

        }
        //test button for validating the click event
        private void TestButton_Click(object sender, EventArgs e)
        {

        }

        //run the process with the given path and time for looping

        private void Run2_Click(object sender, EventArgs e)
        {

        }

        //terminate the process with the given path
        private void Terminate_Click(object sender, EventArgs e)
        {

        }
    }
}
