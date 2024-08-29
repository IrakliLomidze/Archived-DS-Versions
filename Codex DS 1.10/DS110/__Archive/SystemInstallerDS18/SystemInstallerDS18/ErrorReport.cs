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

namespace ILG.Codex.CodexR4
{
    public partial class ErrorReport : Form
    {
        
      public String _Data;
      public String _HelpLink;
      public String _InnerException;
      public String _Message;
      public String _Source;
      public String _StackTrace;
      public String _TargetSite;
      public String _String;
      

        public ErrorReport()
        {
            InitializeComponent();
        }

        private void ErrorReport_Load(object sender, EventArgs e)
        {

            //Codex_Left_Label1.Left = 8;
            //Codex_Left_Label2.Left = 8;
            //Codex_Left_Label2.Left = 8;
            //Codex_Left_Label1.Top = 12;
            //Codex_Left_Label2.Top = Codex_Left_Label1.Top + Codex_Left_Label1.Height + 6;
            //int C_MaxWidth = Math.Max(Math.Max(Codex_Left_Label1.Width, Codex_Left_Label2.Width), 0);
            //LeftPanel.Width = Codex_Left_Label1.Left * 2 + C_MaxWidth;

            //Error_ArrowIcon.Left = 8;
            //Error_ArrowIcon.Top = 4;
            //Big_Caption.Left = Error_ArrowIcon.Left*2 + Error_ArrowIcon.Width;
            //Big_Caption.Top = Error_ArrowIcon.Top;
            


            //Panel_Top.Left = 8;
            //Panel_Top.Top = Math.Max((Big_Caption.Top+Big_Caption.Height),(Error_ArrowIcon.Top+Error_ArrowIcon.Height))+12;

            //int formwidth = LeftPanel.Width + Error_ArrowIcon.Left + Error_ArrowIcon.Width*2 + Big_Caption.Left + Big_Caption.Width;
            ////this.Width = formwidth;

            //Panel_Top_Label_top.Left = 8;
            //Panel_Top_Label_top.Top = 4;

            //Panel_Top_Label_Caption.Left = 8;
            //Panel_Top_Label_Caption.Top = Panel_Top_Label_top.Top + Panel_Top_Label_top.Height + 8;
            //Panel_Top.Height = Panel_Top_Label_top.Top + Panel_Top_Label_top.Height  + 8 + Panel_Top_Label_Caption.Height + 8;
            //Panel_Top.Width = formwidth - Panel_Top.Left - Panel_Top.Left - LeftPanel.Width;// -2;

            //Panel_Top_Options_Link.Top = Panel_Top_Label_top.Top;
            //Panel_Top_Options_Link.Left = Panel_Top.Width - Panel_Top_Options_Link.Width - 8;

            //Save_Button.Left = Panel_Top.Left + (Panel_Top.Width - Save_Button.Width);


            //Panel_Frame.Left = 8;
            //Panel_Frame.Top = Panel_Top.Top + Panel_Top.Height + 12;
            //Panel_Frame.Width = Panel_Top.Width;
            //Panel_Error_ICON.Left = 8;
            //Panel_Error_ICON.Top = 8;

            //Panel_Error_Label.Top = 8;
            //Panel_Error_Label.Left = Panel_Error_ICON.Left * 2 + Panel_Error_ICON.Width;
            //Panel_Error_Link.Left = Panel_Frame.Width - Panel_Error_Link.Width - 8;
            //Panel_Frame.Width = Panel_Top.Width;

            //Error_Detail.Left = Panel_Error_Label.Left;
            //Error_Detail.Top = Panel_Error_Label.Top + Panel_Error_Label.Height + 8;
            //Error_Detail.Width = Panel_Frame.Width - Error_Detail.Left - 8;

            //Error_Detail.Height = Panel_Error_ICON.Height * 4;

            //Panel_Frame.Height = Error_Detail.Top + Error_Detail.Height + 8;

            //Reboot_Check.Left = Panel_Frame.Left;
            //Reboot_Check.Top = Panel_Frame.Top + Panel_Frame.Height + 8;

            //CloseButton.Top = Reboot_Check.Top;
            //CloseButton.Left = Panel_Frame.Left + Panel_Frame.Width - CloseButton.Width;


            //ClientSize = new Size( LeftPanel.Width + CloseButton.Left + CloseButton.Width + 8 , CloseButton.Height + CloseButton.Top + 8);
            

            //Panel_Error_Link.Value = global::ILG.Codex.CodexR4.Properties.Settings.Default.BugTraqMail.ToString().Trim();
            //Panel_Error_Link.BaseURL = "mailto:"+ global::ILG.Codex.CodexR4.Properties.Settings.Default.BugTraqMail.ToString().Trim();
            //ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrashNew = ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrash;
            //if (ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrashNew == 0) Reboot_Check.Checked = false;
            //if (ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrashNew == 1) Reboot_Check.Checked = true;

           

            Report = "Codex R4 Platform Installer [App:{" + Application.ProductName.ToString() + "} Version:{" + Application.ProductVersion.ToString() + "}  ]  \r\n" +
                           "Date  [" + DateTime.Now.ToShortDateString() + "]  \r\n" +
                           "OS Version [" + System.Environment.OSVersion.ToString() + "]  \r\n" +
                           "[Message] " + _Message + "\r\n" +
                           "[General] " + _String + "\r\n" +
                           "[StackTrace] \r\n" +
                           _StackTrace;


            _StackTrace = _StackTrace.Replace('\r', 'ქ').Replace('\n', 'ღ').Replace("ქ", "%0d").Replace("ღ", "%0a").Replace("&", "%26").Replace("?", "%3F").Replace("=", "%3D");


            Report2 = "Codex R4 Platform Installer [App:{" + Application.ProductName.ToString() + "} Version:{" + Application.ProductVersion.ToString() + "}  ]  %0d%0a" +
                          "Date  [" + DateTime.Now.ToShortDateString() + "]  %0d%0a" +
                          "OS Version [" + System.Environment.OSVersion.ToString() + "]  %0d%0a" +
                          "[Message] " + _Message + "%0d%0a" +
                          "[General] " + _String + "%0d%0a" +
                          "[StackTrace] %0d%0a" +
                          _StackTrace.ToString();

            this.Error_Detail.Text = Report;
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            Close();   
        }

        string Report="";
        string Report2="";

        


        private void ultraButton4_Click(object sender, EventArgs e)
        {
            About f = new About(); f.ShowDialog();
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Report);
        }

        
        private void ultraFormattedLinkLabel2_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            //Configuration fc = new Configuration(); fc.ShowDialog(); 
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
                    //ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ფაილში ჩაწერა", ce.Message.ToString());
                }
            }
        }

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            //string BugTraqMail = global::ILG.Codex.CodexR4.Properties.Settings.Default.BugTraqMail;
            //String SMR = "mailto:" + BugTraqMail;
            //System.Diagnostics.Process.Start(SMR);
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            SavetoFile();
        }


        private void ultraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.Reboot_Check.Checked == true)  ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrashNew = 1;
            //if (this.Reboot_Check.Checked == false) ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrashNew = 0;
        }

        private void ultraPictureBox2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Report);
            
        }


    }
}