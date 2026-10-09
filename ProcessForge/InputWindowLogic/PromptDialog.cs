using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProcessForge.InputWindowLogic
{
    public static class PromptDialog
    {
        public static string Show(string prompt, string title = "Custom Input Required", string defaultValue = "")
        {
            if (Application.OpenForms.Count > 0 && Application.OpenForms[0] != null)
            {
                Form? mainForm = Application.OpenForms[0];
                if (mainForm != null && mainForm.InvokeRequired)
                {
                    string result = string.Empty;
                    mainForm.Invoke(new Action(() =>
                    {
                        result = ShowInternal(prompt, title, defaultValue);
                    }));
                    return result;
                }
            }

            return ShowInternal(prompt, title, defaultValue);
        }

        private static string ShowInternal(string prompt, string title, string defaultValue)
        {
            using Form promptForm = new Form
            {
                Width = 440,
                Height = 185,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = string.IsNullOrWhiteSpace(title) ? "Custom Input Required" : title,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = true,
                BackColor = Color.White
            };

            Label lblPrompt = new Label
            {
                Left = 20,
                Top = 15,
                Width = 385,
                Height = 35,
                Text = string.IsNullOrWhiteSpace(prompt) ? "Enter required value for macro sequence:" : prompt,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.Black
            };

            TextBox txtInput = new TextBox
            {
                Left = 20,
                Top = 55,
                Width = 385,
                Text = defaultValue,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                BorderStyle = BorderStyle.FixedSingle
            };

            Button btnOk = new Button
            {
                Text = "OK",
                Left = 225,
                Top = 95,
                Width = 85,
                Height = 30,
                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Left = 320,
                Top = 95,
                Width = 85,
                Height = 30,
                DialogResult = DialogResult.Cancel,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Cursor = Cursors.Hand
            };

            promptForm.Controls.Add(lblPrompt);
            promptForm.Controls.Add(txtInput);
            promptForm.Controls.Add(btnOk);
            promptForm.Controls.Add(btnCancel);
            promptForm.AcceptButton = btnOk;
            promptForm.CancelButton = btnCancel;

            promptForm.Shown += (s, e) =>
            {
                txtInput.Focus();
                txtInput.SelectAll();
            };

            DialogResult dialogResult = promptForm.ShowDialog();
            return dialogResult == DialogResult.OK ? txtInput.Text : string.Empty;
        }
    }
}
