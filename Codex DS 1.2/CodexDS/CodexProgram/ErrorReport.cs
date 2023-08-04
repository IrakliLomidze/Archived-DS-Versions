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
            Report = "Codex 2007 DS [App:{" + Application.ProductName.ToString() + "} Version:{" + Application.ProductVersion.ToString() + "}  ]  \r\n" +
                           "Date  [" + DateTime.Now.ToShortDateString() + "]  \r\n" +
                           "OS Version [" + System.Environment.OSVersion.ToString() + "]  \r\n" +
                           "[Message] " + _Message + "\r\n" +
                           "[General] " + _String + "\r\n" +
                           "[StackTrace] \r\n" +
                           _StackTrace;


            _StackTrace = _StackTrace.Replace('\r', 'ქ').Replace('\n', 'ღ').Replace("ქ", "%0d").Replace("ღ", "%0a").Replace("&", "%26").Replace("?", "%3F");


            Report2 = "Codex 2007 DS [App:{" + Application.ProductName.ToString() + "} Version:{" + Application.ProductVersion.ToString() + "}  ]  %0d%0a" +
                          "Date  [" + DateTime.Now.ToShortDateString() + "]  %0d%0a" +
                          "OS Version [" + System.Environment.OSVersion.ToString() + "]  %0d%0a" +
                          "[Message] " + _Message + "%0d%0a" +
                          "[General] " + _String + "%0d%0a" +
                          "[StackTrace] %0d%0a" +
                          _StackTrace.ToString();

            
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            Close();   
        }

        string Report="";
        string Report2="";

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ILG.Windows.Forms.ILGMessageBox.ShowE("შეცდომა: "+_String, Report);
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            string BugTraqMail = global::ILG.Codex.Codex2007.Properties.Settings.Default.BugTraqMail;
            try
            {

                //String SMR = "mailto:""BugTraq@codexserver.com"&mailformat='html'&subject=Codex 2007 Bug Reporting&body=" + @Report2;
                String SMR = "mailto:"+BugTraqMail+"&mailformat='html'&subject=Codex 2007 DS Bug Reporting&body=" + @Report2;
                System.Diagnostics.Process.Start(SMR);
            }
            catch
            {
                try
                {
                    //String SMR = "mailto:BugTraq@codexserver.com&mailformat='html'&subject=Codex 2007 Bug Reporting&body=" + @Report;
                    String SMR = "mailto:"+BugTraqMail+"&mailformat='html'&subject=Codex 2007 DS Bug Reporting&body=" + @Report;
                    System.Diagnostics.Process.Start(SMR);
                }
                catch (Exception ex)
                {
                    ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება შეცდომის ანგარიშის (REPORT) ფორმირება", ex.Message.ToString());
                }
            }

            
        }
    }
}