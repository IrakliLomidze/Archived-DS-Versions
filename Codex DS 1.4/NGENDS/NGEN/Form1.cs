using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NGEN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ultraPictureBox3_Click(object sender, EventArgs e)
        {

        }
        public static string DotNetFrameworkDir;
        public static string CurrentDir;
        public static string TempDir;
        public static int Build;



        private static void InstallProcess(String fn)
        {
            string Filename;
            Filename = CurrentDir + "\\"+fn;
            if (File.Exists(Filename) == true)
            {
                string ss = DotNetFrameworkDir + "\\ngen.exe";
                string sa = "install " + "\"" + Filename + "\"";
                //string ss = DotNetFrameworkDir + @"\ngen.exe" +  " /? ";
              //NETFrameworkDir+@"\ngen.exe "+"\""+LocalVars.CurrentDirCodex+@"\"+Path.GetFileName(a[i].ToString())+"\"");
                //MessageBox.Show(ss.ToString());   
                //System.Diagnostics.Process proc = new System.Diagnostics.Process.s.Process();
               // System.Diagnostics.ProcessStartInfo myProcessStartInfo = new System.Diagnostics.ProcessStartInfo(ss);
              
               // myProcessStartInfo.UseShellExecute = false;
                //myProcessStartInfo.RedirectStandardOutput = true;
               // proc.StartInfo = myProcessStartInfo;
               // proc.Start();
               // proc.WaitForExit();
       //         System.Diagnostics.Process.Start(ss,sa);
                //proc.WaitForExit();
               // Clipboard.SetText(ss);
               // MessageBox.Show(ss);
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(ss,sa);
                proc.WaitForExit();
            }
            return;
        }

        private static void UnInstallProcess(String fn)
        {
            string Filename;
            Filename = CurrentDir + "\\" + fn;
            if (File.Exists(Filename) == true)
            {
               // string ss = DotNetFrameworkDir + "\\ngen.exe uninstall " + "\"" + Filename + "\"";
                string ss = DotNetFrameworkDir + "\\ngen.exe";
                string sa = "uninstall " + "\"" + Filename + "\"";
         
                //System.Diagnostics.Process proc = new System.Diagnostics.Process();
                //System.Diagnostics.ProcessStartInfo myProcessStartInfo = new System.Diagnostics.ProcessStartInfo(ss);
             //   myProcessStartInfo.UseShellExecute = false;
              //  myProcessStartInfo.RedirectStandardOutput = true;
               // proc.StartInfo = myProcessStartInfo;
               // proc.Start();
               // proc.WaitForExit();
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(ss,sa);
                proc.WaitForExit();
            }
            return;
        }

        public static void DoInstall()
        {
            Form1.InstallProcess("Codex2007DS.exe");
            Form1.InstallProcess("DataBaseInstallerDS.exe");
            Form1.InstallProcess("MakeDataImageDS.exe");
        }
        public static void DoUpdate()
        {
            //string ss = DotNetFrameworkDir + "\\ngen.exe Update";
            string ss = DotNetFrameworkDir + "\\ngen.exe";
            string sa = "Update";
         
           // System.Diagnostics.Process proc = new System.Diagnostics.Process();
          //  System.Diagnostics.ProcessStartInfo myProcessStartInfo = new System.Diagnostics.ProcessStartInfo(ss);
           // myProcessStartInfo.UseShellExecute = false;
            //myProcessStartInfo.RedirectStandardOutput = true;
           // proc.StartInfo = myProcessStartInfo;   
           // proc.Start();
           // proc.WaitForExit();
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(ss,sa);
            proc.WaitForExit();
        }
        public static void DoUninstall()
        {
            Form1.UnInstallProcess("Codex2007DS.exe");
            Form1.UnInstallProcess("DataBaseInstallerDS.exe");
            Form1.UnInstallProcess("MakeDataImageDS.exe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ultraTextEditor1.Text = DotNetFrameworkDir;
            Infragistics.Win.AppStyling.StyleManager.Load(Form1.CurrentDir + "\\Styles\\Windows7.isl");

            
        }

        private void ultraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
            this.ultraButton2.Enabled = this.ultraCheckEditor1.Checked;
            this.ultraButton3.Enabled = this.ultraCheckEditor1.Checked;
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string st = fd.SelectedPath;
                if (System.IO.File.Exists(st + "\\ngen.exe") != true)
                {
                    MessageBox.Show("მითითებულ დირექტორიაში არ არის ngen.exe");
                    return;
                }

                this.ultraTextEditor1.Text = fd.SelectedPath;
                Form1.DotNetFrameworkDir = this.ultraTextEditor1.Text;

            }

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("კომპილაცია დარწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Form1.DoInstall();
            }
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("განახლება კომპილაცია დარწმუნებული ხართ ?\n ეს პროცედურა დაიკავებს დიდ დროს", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Form1.DoUpdate();
            }
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ბუფერის გაწმენდა დარწმუნებული ხართ ?\n ეს პროცედურა დაიკავებს დიდ დროს", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Form1.DoUninstall();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ultraTabControl_Main.SelectedTab = this.ultraTabControl_Main.Tabs[0];
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ultraTabControl_Main.SelectedTab = this.ultraTabControl_Main.Tabs[1];
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ultraTabControl_Main.SelectedTab = this.ultraTabControl_Main.Tabs[2];
        }

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {

        }

        private void ultraTabPageControl5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}