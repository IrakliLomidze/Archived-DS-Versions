using System;
using System.Collections.Generic;
using System.Text;

namespace ILG.Codex.Codex2007
{
    partial class Form1
    {
        public delegate void ShowProgressDelegate(int progress, string Str);

        public void ShowProgress(int progress, string Str)
        {
            if (this.listBox1.InvokeRequired == false)
            {
                if (Str != "") this.listBox1.Items.Add(Str);
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                //this.progressBar2.Value = progress;
            }
            else
            {
                ShowProgressDelegate showProgress = new ShowProgressDelegate(ShowProgress);
                // Show progress synchronously 
                Invoke(showProgress, new object[] { progress, Str });
            }


        }

        public void Process()
        {
            this.ultraButton1.Enabled = false;
            this.ultraButton2.Enabled = false;
            this.ultraButton3.Enabled = false;
            this.ultraButton4.Enabled = false;
            
            for (int i = 0; i < this.ultraToolbarsManager1.Tools.Count; i++)  { ultraToolbarsManager1.Tools[i].SharedProps.Enabled = false; }

            ShowProgress(0, "მონაცემთა ბაზის კოპირების და რეგისტრაციის პროცესი");
            int cc = 0;
            Database s = new Database(this);
            if (s.GetInfoFrom() == 0)
            {
                if (s.dropDatabase() == 0)
                {

                    if (Form1.Copying == true)
                    {
                        if (s.ProcessFiles() == 0)
                        {
                            cc = s.AttachDatabase();

                        }
                    }
                    else
                    {
                        cc = s.AttachDatabase();
                    }


                }

            }


            //this.button7.Enabled = true;
            //this.button17.Enabled  = true;
            if (cc == 0) { this.ultraButton3.Enabled = true; this.ultraButton4.Enabled = false; }
            this.ultraButton1.Enabled = true;
            for (int i = 0; i < this.ultraToolbarsManager1.Tools.Count; i++) { ultraToolbarsManager1.Tools[i].SharedProps.Enabled = true; }
            //this.button19.Enabled = true;


        }

        delegate void ProcessDelegate();
    }
}
