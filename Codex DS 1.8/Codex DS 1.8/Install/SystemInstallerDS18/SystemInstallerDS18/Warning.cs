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
    public partial class WarningMessageDialog : Form
    {
        
      public String _Data;
      public String _HelpLink;
      public String _InnerException;
      public String _Message;
      public String _Source;
      public String _StackTrace;
      public String _TargetSite;
      public String _String;
      

        public WarningMessageDialog()
        {
            InitializeComponent();
        }

        private void Warning_Load(object sender, EventArgs e)
        {

  //          Codex_Left_Label1.Left = 8;
  //          Codex_Left_Label2.Left = 8;
  //          Codex_Left_Label2.Left = 8;
  //          Codex_Left_Label1.Top = 12;
  //          Codex_Left_Label2.Top = Codex_Left_Label1.Top + Codex_Left_Label1.Height + 6;
  ////          Codex_Left_Label3.Top = Codex_Left_Label2.Top + Codex_Left_Label2.Height + 6;
  //          int C_MaxWidth = Math.Max(Codex_Left_Label1.Width, Codex_Left_Label2.Width);//, Codex_Left_Label3.Width);
  //          LeftPanel.Width = Codex_Left_Label1.Left * 2 + C_MaxWidth;

  //          Error_ArrowIcon.Left = 8;
  //          Error_ArrowIcon.Top = 4;
  //          Big_Caption.Left = Error_ArrowIcon.Left*2 + Error_ArrowIcon.Width;
  //          Big_Caption.Top = Error_ArrowIcon.Top;
            


  //          Panel_Top.Left = 8;
  //          Panel_Top.Top = Math.Max((Big_Caption.Top+Big_Caption.Height),(Error_ArrowIcon.Top+Error_ArrowIcon.Height))+12;

  //          int formwidth = LeftPanel.Width + Error_ArrowIcon.Left + Error_ArrowIcon.Width*2 + Big_Caption.Left + Big_Caption.Width;
  //          //this.Width = formwidth;

  //          Panel_Top_Label_top.Left = 8;
  //          Panel_Top_Label_top.Top = 4;

  //          Panel_Top_Label_Caption_Version.Left = 8;
  //          Panel_Top_Label_Caption_Version.Top = Panel_Top_Label_top.Top + Panel_Top_Label_top.Height + 8;
  //          Panel_Top.Height = Panel_Top_Label_top.Top + Panel_Top_Label_top.Height  + 8 + Panel_Top_Label_Caption_Version.Height + 8;
  //          Panel_Top.Width = formwidth - Panel_Top.Left - Panel_Top.Left - LeftPanel.Width;// -2;

            

  //          Panel_Frame.Left = 8;
  //          Panel_Frame.Top = Panel_Top.Top + Panel_Top.Height + 12;
  //          Panel_Frame.Width = Panel_Top.Width;
  //          Panel_Error_ICON.Left = 8;
  //          Panel_Error_ICON.Top = 8;

  //          Panel_Frame.Width = Panel_Top.Width;

  //          Error_Detail.Left = Panel_Error_Label.Left;
  //          Error_Detail.Top = Panel_Error_Label.Top + Panel_Error_Label.Height + 8;
  //          Error_Detail.Width = Panel_Frame.Width - Error_Detail.Left - 8;

  //          Error_Detail.Height = Panel_Error_ICON.Height * 4;

  //          Panel_Frame.Height = Error_Detail.Top + Error_Detail.Height + 8;

            
  //          CloseButton.Top = Panel_Frame.Top + Panel_Frame.Height + 8;
  //          CloseButton.Left = Panel_Frame.Left + Panel_Frame.Width - CloseButton.Width;


  //          ClientSize = new Size( LeftPanel.Width + CloseButton.Left + CloseButton.Width + 8 , CloseButton.Height + CloseButton.Top + 8);


            this.Panel_Top_Label_Caption_Version.Text = System.Environment.OSVersion.VersionString;


            String Supprted_Opetation_System =
                "Windows 10" + System.Environment.NewLine +
                "Windows 8.1" + System.Environment.NewLine +
                "Windows 7 With Service Pack 1" + System.Environment.NewLine +
                "Windows 2012 R2" + System.Environment.NewLine +
                "Windows 2012 " + System.Environment.NewLine +
                "Windows 2008 R2 With Service Pack 1" + System.Environment.NewLine +
                "";

         //   MessageBox.Show("VVVV Major = " + System.Environment.OSVersion.Version.Major.ToString() + "  Minor =" + System.Environment.OSVersion.Version.Minor.ToString());
            this.Error_Detail.Text = Supprted_Opetation_System;
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            Close();   
        }

       
        

    }
}