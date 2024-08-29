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
                if (Str != "")
                {
                    this.listBox1.SuspendLayout();
                    this.listBox1.Focus();
                    this.listBox1.Text = this.listBox1.Text + System.Environment.NewLine + Str;
                    if (listBox1.Text.Length > 0) this.listBox1.SelectionStart = this.listBox1.Text.Length - 1;
                    this.listBox1.ScrollToCaret();
                    this.listBox1.Focus();
                    this.listBox1.ResumeLayout();
                }

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
            ultraButton_Close.Enabled = false;
            ultraButton_Back.Enabled = false;
            ultraButton_Next.Enabled = false;
            ultraButton_Process.Enabled = false;
            

            ShowProgress(0, "მონაცემთა ბაზის კოპირების და რეგისტრაციის პროცესი");
            ShowProgress(0, "-----------------------------------------------------");
            Database s = new Database();
            s.Owner = this;

            if (s.GetInfoFrom() == 0)
            {
                if (s.TakeOfflineDatabase() == 0)
                {
                    s.ProcessFiles();
                    s.TakeOnlineDatabase();
                }
            }


            ultraButton_Close.Enabled = true;
            ultraButton_Back.Enabled = true;
            //ultraButton_Next.Enabled = true;
            ultraButton_Process.Enabled = true;


        }


        delegate void ProcessDelegate();
    }
}
