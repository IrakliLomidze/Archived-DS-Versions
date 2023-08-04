using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net.Mail;
using System.IO;

namespace ILG.Codex.Codex2007
{
    public partial class ErrorReport : Form
    {
        
      public string _Data;
      public string _HelpLink;
      public string _InnerException;
      public string _Message;
      public string _Source;
      public string _StackTrace;
      public string _TargetSite;
      public string _String;
      

        public ErrorReport()
        {
            InitializeComponent();
        }

        private void ErrorReport_Load(object sender, EventArgs e)
        {
            ultraFormattedLinkLabel1.Value = global::ILG.Codex.Codex2007.Properties.Settings.Default.BugTraqMail.ToString().Trim();
            ultraFormattedLinkLabel1.BaseURL = "mailto:"+ global::ILG.Codex.Codex2007.Properties.Settings.Default.BugTraqMail.ToString().Trim();
            ILG.Codex.Codex2007.Properties.Settings.Default.WhenCrashNew = ILG.Codex.Codex2007.Properties.Settings.Default.WhenCrash;
            if (ILG.Codex.Codex2007.Properties.Settings.Default.WhenCrashNew == 0) ultraCheckEditor1.Checked = false;
            if (ILG.Codex.Codex2007.Properties.Settings.Default.WhenCrashNew == 1) ultraCheckEditor1.Checked = true;


            Report = "Codex DS R3.5 [App:{" + Application.ProductName.ToString() + "} Version:{" + Application.ProductVersion.ToString() + "}  ]  \r\n" +
                           "Date  [" + DateTime.Now.ToShortDateString() + "]  \r\n" +
                           "OS Version [" + System.Environment.OSVersion.ToString() + "]  \r\n" +
                           "[Message] " + _Message + "\r\n" +
                           "[General] " + _String + "\r\n" +
                           "[StackTrace] \r\n" +
                           _StackTrace;


            _StackTrace = _StackTrace.Replace('\r', 'ქ').Replace('\n', 'ღ').Replace("ქ", "%0d").Replace("ღ", "%0a").Replace("&", "%26").Replace("?", "%3F").Replace("=", "%3D");


            Report2 = "Codex DS R3.5 [App:{" + Application.ProductName.ToString() + "} Version:{" + Application.ProductVersion.ToString() + "}  ]  %0d%0a" +
                          "Date  [" + DateTime.Now.ToShortDateString() + "]  %0d%0a" +
                          "OS Version [" + System.Environment.OSVersion.ToString() + "]  %0d%0a" +
                          "[Message] " + _Message + "%0d%0a" +
                          "[General] " + _String + "%0d%0a" +
                          "[StackTrace] %0d%0a" +
                          _StackTrace.ToString();

            this.ultraTextEditor1.Text = Report;
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            Close();   
        }

        string Report="";
        string Report2="";

        

        private void SendMail_Click(object sender, EventArgs e)
        {
            string BugTraqMail = global::ILG.Codex.Codex2007.Properties.Settings.Default.BugTraqMail;
            try
            {

                String SMR = "mailto:" + BugTraqMail + "&mailformat='html'&subject=Codex DS R3.5 Reporting&body=" + @Report2;
                System.Diagnostics.Process.Start(SMR);
            }
            catch
            {
                try
                {
                    String SMR = "mailto:" + BugTraqMail + "&mailformat='html'&subject=Codex DS R3.5 Reporting&body=" + @Report;
                    System.Diagnostics.Process.Start(SMR);
                }
                catch (Exception ex)
                {
                    ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხება შეცდომის რეპორტის ფორმირება", ex.Message.ToString());
                }
            }

        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            About f = new About(); f.ShowDialog();
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Report);
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "პროგრამის შესახებ":    // ButtonTool
                      About f = new About(); f.ShowDialog();
                    break;

                case "პარამეტრები":    // ButtonTool
                    Configuration fc = new Configuration(); fc.ShowDialog(); 
                    break;

                case "ჩაწერა ფაილში":    // ButtonTool
                    Clipboard.SetText(Report);
                    break;

                case "ჩაწერა":    // ButtonTool
                    SavetoFile();
                    break;

                case "გაგზავნა":    // ButtonTool
                    SendMail_Click(null, null);
                    break;

                case "დახურვა":    // ButtonTool
                    Close();   
                    break;

            }

        }

        private void ultraFormattedLinkLabel2_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            Configuration fc = new Configuration(); fc.ShowDialog(); 
        }

        private void SavetoFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = @Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName.ToString(), FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                    sw.Write(Report);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                catch (Exception ce)
                {
                    ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ფაილში ჩაწერა", ce.Message.ToString());
                }
            }
        }

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            string BugTraqMail = global::ILG.Codex.Codex2007.Properties.Settings.Default.BugTraqMail;
            String SMR = "mailto:" + BugTraqMail;
            System.Diagnostics.Process.Start(SMR);
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            SavetoFile();
        }

        private void ultraLabel8_Click(object sender, EventArgs e)
        {

        }

        private void ultraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ultraCheckEditor1.Checked == true)  ILG.Codex.Codex2007.Properties.Settings.Default.WhenCrashNew = 1;
            if (this.ultraCheckEditor1.Checked == false) ILG.Codex.Codex2007.Properties.Settings.Default.WhenCrashNew = 0;
        }
    }
}