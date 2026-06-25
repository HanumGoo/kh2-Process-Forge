using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessForge.RefreshLogic
{
    public class RefreshLogic
    {
        public static void Refresh(FlowLayoutPanel flowLayoutPanel, Label labelPage, int pageCount, List<string> AllProcessTitle)
        {
            //clear panel
            flowLayoutPanel.Controls.Clear();

            //generate button
            int PageStart = (pageCount - 1) * 100;
            int PageShow = 0;

            for (int i = PageStart; i < AllProcessTitle.Count; i++)
            {
                if (PageShow > 99)
                {
                    break;
                }

                Button btn = new Button();

                btn.Text = AllProcessTitle[i];
                btn.Margin = new Padding(5, 5, 5, 5);
                btn.Size = new Size(135, 40);
                btn.Width = flowLayoutPanel.Width - 300;
                btn.Font = new Font("Segoe UI Symbol", 9F);
                btn.ForeColor = Color.White;
                //btn.Click += Button_Click;

                flowLayoutPanel.Controls.Add(btn);
                PageShow++;
            }

            //rename label page
            labelPage.Text = AllProcessTitle.Count <= 100 ? $"{AllProcessTitle.Count}/{AllProcessTitle.Count}" : $"{PageStart} - {PageStart + PageShow}/{AllProcessTitle.Count}";
        
        }
        public static void RefreshWIthNotepadCheck(FlowLayoutPanel flowLayoutPanel, Label labelPage, int pageCount, List<string> AllProcessTitle, List<List<string>> AllDataImport)
        {
            flowLayoutPanel.Controls.Clear();

            

            List<List<string>> DetectedProcess = new List<List<string>>
            {
                new List<string>(),
                new List<string>()
            };

            foreach (var TitleName in AllProcessTitle)
            {
                for (int i = 0; i < AllDataImport[0].Count; i++)
                {
                    if (TitleName == AllDataImport[0][i])
                    {
                        DetectedProcess[0].Add(AllDataImport[0][i]);
                        DetectedProcess[1].Add(AllDataImport[1][i]);
                        break;
                    }
                    else
                    {

                    }
                }
            }

            //rename label page
            int PageStart = (pageCount - 1) * 100;
            int PageShow = 0;

            for (int i = PageStart; i < AllProcessTitle.Count; i++)
            {
                if (PageShow > 99)
                {
                    break;
                }

                Button btn = new Button();

                btn.Text = DetectedProcess[0][i];
                btn.Margin = new Padding(5, 5, 5, 5);
                btn.Size = new Size(135, 40);
                btn.Width = flowLayoutPanel.Width - 300;
                btn.Font = new Font("Segoe UI Symbol", 9F);
                btn.ForeColor = Color.White;
                //btn.Click += Button_Click;

                Button btn2 = new Button();

                btn2.Text = DetectedProcess[1][i];
                btn2.Margin = new Padding(5, 5, 5, 5);
                btn2.Size = new Size(135, 40);
                btn2.Width = flowLayoutPanel.Width - 550;
                btn2.Font = new Font("Segoe UI Symbol", 9F);
                btn2.ForeColor = Color.White;
                btn2.BackColor = Color.Green;
                //btn2.Click += Button_Click;

                flowLayoutPanel.Controls.Add(btn);
                flowLayoutPanel.Controls.Add(btn2);
                PageShow++;
            }

            //rename label page
            labelPage.Text = AllProcessTitle.Count <= 100 ? $"{AllProcessTitle.Count}/{AllProcessTitle.Count}" : $"{PageStart} - {PageStart + PageShow}/{AllProcessTitle.Count}";
        }
    }
}
