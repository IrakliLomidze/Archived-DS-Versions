using ILG.Codex.CodexR4;
using ILG.DS.Dialogs;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;


namespace ILG.DS.Configurations.Dialogs
{
    public partial class DSConfiguration: Form
    {
        bool _ShowInTaskBar = false;
        public DSConfiguration(bool ShowInTaskBar =false)
        {
            InitializeComponent();
            _ShowInTaskBar = ShowInTaskBar;
        }

  
   
        private void DetailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       
        }
    
    
        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DSProfileSQLServerConfiguration sf = new DSProfileSQLServerConfiguration();
            sf.ShowDialog();
        }

     
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "About":    // ButtonTool
                    AboutDS f = new AboutDS(); f.ShowDialog();
                    break;

         
                case "FeedBack":    // ButtonTool
                    
                    {
                        var processStartInfo = new ProcessStartInfo
                        {
                            FileName = "mailto:support@codex.ge",
                            UseShellExecute = true
                        };
                        Process.Start(processStartInfo);
                    }
                    break;

                case "Web":    // ButtonTool
                    
                    {
                        var processStartInfo = new ProcessStartInfo
                        {
                            FileName = "https://www.codex.ge",
                            UseShellExecute = true
                        };
                        Process.Start(processStartInfo);
                    }
                    break;

         
                case "დახურვა":    // ButtonTool
                    Close();
                    break;

         
            
            }

        }




        private void ultraTabPageControl5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ultraTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfigurationUI sf = new ConfigurationUI();
            sf.ShowDialog();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
     
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
 
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

       
        }
    }
}