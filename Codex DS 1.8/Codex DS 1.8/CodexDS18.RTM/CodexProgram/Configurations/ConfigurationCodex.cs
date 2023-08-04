using System;
using System.Windows.Forms;


namespace ILG.Codex.CodexR4
{
    public partial class CodexConfiguration: Form
    {
        bool _ShowInTaskBar = false;
        public CodexConfiguration(bool ShowInTaskBar =false)
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
            ConfigurationSQL sf = new ConfigurationSQL();
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
                    System.Diagnostics.Process.Start("mailto:support@codexserver.com");
                    break;

                case "Web":    // ButtonTool
                    System.Diagnostics.Process.Start("http://www.codexserver.com");
                    break;

         
                case "დახურვა":    // ButtonTool
                    Close();
                    break;

         
            
            }

        }




        private void ultraTabPageControl5_Paint(object sender, PaintEventArgs e)
        {
            //ToolTipText: კოდექს R4 –ში რეალიზებულია სრულტექსტოვანი ძებნა, რომელიც საშუალებას იძლევა მოძებნოს დოკუმენტი ტექსტში არსებული სიტყვით ან ფრაზით. ფუნქციის გამოყენებისთვის არსებობს ორი გზა:  მოძებნოს ტექსტი ბაზაში ან გამოიყენოს SQL Server ის Full Text Search სერვისი. თუ თქვენ მუშაობთ პერსონალურ ვერისასთან მაშინ გათიშეთ ეს ოფცია. თუ მუშაობთ ქსელური ვერსიით რეკომენდირებულია ზემოთ მოყვანილი ოფცია იყოს ჩართული (მონიშნული)

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