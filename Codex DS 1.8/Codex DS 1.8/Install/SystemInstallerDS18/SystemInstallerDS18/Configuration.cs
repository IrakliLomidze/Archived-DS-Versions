using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace ILG.Codex.CodexR4
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {

            LeftPanel_Label1.Left = 8;
            LeftPanel_Label1.Top = 12;

            LeftPanel_Label2.Left = 8;
            LeftPanel_Label2.Top = LeftPanel_Label1.Top + LeftPanel_Label1.Height+8;

     
            LeftPanel.Width = Math.Max(LeftPanel_Label2.Width, LeftPanel_Label1.Width)+LeftPanel_Label1.Left*2;

            ConfiguraitonTop_ICON.Left = 8;
            ConfiguraitonTop_ICON.Top = 2;
            ConfiguraitonTop_Label.Left = ConfiguraitonTop_ICON.Left * 2 + ConfiguraitonTop_ICON.Width;
            ConfiguraitonTop_Label.Top = ConfiguraitonTop_ICON.Top;
            ConfiguraitonTop_Panel.Height = Math.Max(ConfiguraitonTop_ICON.Top + ConfiguraitonTop_ICON.Top + ConfiguraitonTop_ICON.Height, ConfiguraitonTop_Label.Height);


            DataBase_Icon.Left = 8;
            DataBase_Icon.Top = 12;

            DatabaseServer.Left = DataBase_Icon.Left + DataBase_Icon.Width + DataBase_Icon.Left;
            DatabaseServer.Top = DataBase_Icon.Top;


            Database_Name_Label.Left = DataBase_Icon.Left + DataBase_Icon.Width + DataBase_Icon.Left;
            Database_Name_Label.Top = DatabaseServer.Top + DatabaseServer.Height + 8;

            Edit_CMD_Database_Install.Left = Database_Name_Label.Left + Database_Name_Label.Width + 8; 

            Edit_CMD_Database_Install.Top = Database_Name_Label.Top - (Database_Name_Label.Height - Database_Name_Label.Height)/2;

            Edit_CMD_Database_Install.Width = DatabaseServer.Left + DatabaseServer.Width - Edit_CMD_Database_Install.Left;


            

            Silent_ICON.Left = DataBase_Icon.Left;

         
            Check_WindowsComponents.Top = Silent_ICON.Top;

            Check_CodexInstall.Top = Check_WindowsComponents.Top + Check_WindowsComponents.Height + 8;

            
            
            //SQLServerPort.Left = Edit_CMD_Database_Install.Left + Edit_CMD_Database_Install.Width + 8;
            
            //SQLServerPort.Top = Edit_CMD_Database_Install.Top;


            int formwidth = LeftPanel.Width + DatabaseServer.Left + DatabaseServer.Width + 16; // ConfiguraitonTop_ICON.Left + ConfiguraitonTop_ICON.Width * 3 + ConfiguraitonTop_ICON.Left + ConfiguraitonTop_Label.Width;
            //this.Width = formwidth;

            this.Width = formwidth;


            
        }

           

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            string str_CodexR4_RO = "";
            string str_CodexR4History_RO = "";
            string str_CodexR4Update_RO = "";

            string str_CodexR4_RW = "";
            string str_CodexR4History_RW = "";
            string str_CodexR4Update_RW = "";
            

            string servername = this.Edit_CMD_Database_Install.Text.Trim();
            int i;
            
            string CatalogName_CodexR4 = "CodexR4";
            string CatalogName_CodexR4History = "CodexR4History";
            string CatalogName_CodexR4Update = "CodexR4Update";

            
            {
                str_CodexR4_RO = "workstation id=" + System.Environment.MachineName +
                                 ";packet size=4096;integrated security=SSPI;data source="
                                 + servername + ";persist security info=False;initial catalog=" + CatalogName_CodexR4 + ";Connection Timeout=30";

                str_CodexR4History_RO = "workstation id=" + System.Environment.MachineName +
                                        ";packet size=4096;integrated security=SSPI;data source="
                                         + servername + ";persist security info=False;initial catalog=" + CatalogName_CodexR4History + ";Connection Timeout=30";

                str_CodexR4Update_RO = "workstation id=" + System.Environment.MachineName +
                                       " ;packet size=4096;integrated security=SSPI;data source="
                                        + servername + ";persist security info=False;initial catalog=" + CatalogName_CodexR4Update + ";Connection Timeout=30";


                str_CodexR4_RW = str_CodexR4_RO;
                str_CodexR4History_RW = str_CodexR4History_RO;
                str_CodexR4Update_RW = str_CodexR4Update_RO;
                
            }
      
       

        }

     

        private int configurationApplySave(bool save)
        {
        
     

            return 0;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            //if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი კონფიგურაციის ჩაწერა ?", "", 
            //    System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

            //if (configurationApplySave(true) == 0)
            //{
            //    ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            //}

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apply new Configuration ?", "",
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

            if (configurationApplySave(false) == 0)
            {
                MessageBox.Show("New Configuraiton has been applied");
            }
        }

        private void DetailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Do you want to reset by default paraments ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            if (MessageBox.Show("Do you want to reset by default paraments ? \nPlease confirm again!", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

//            ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრები აღდგენილია");

        }
        // Configuration Workplace
      
  
    
        static public void load()
        {
            
     
      
            #region FullText
            //if ((global::ILG.Codex.CodexR4.Properties.Settings.Default.IsFullText == true))
            //{
            //    global::ILG.Codex.CodexR4.Properties.Settings.Default.UseFullTextSearch = global::ILG.Codex.CodexR4.Properties.Settings.Default.AppUseFullTextSearch;
            //}

            #endregion FullText

            #region Default Program
            //if ((global::ILG.Codex.CodexR4.Properties.Settings.Default.isDefault == true) &&
            //   (global::ILG.Codex.CodexR4.Properties.Settings.Default.AppDefault >= 0) && (global::ILG.Codex.CodexR4.Properties.Settings.Default.AppDefault < 5))
            //{
            //    global::ILG.Codex.CodexR4.Properties.Settings.Default.DefaultProgram = (uint)global::ILG.Codex.CodexR4.Properties.Settings.Default.AppDefault;
            //}
            //#endregion Default Program

            


            #endregion Policy Settings
            
            #region declarce directoryes
            string CurrentDirCodex = System.Environment.CurrentDirectory;
		
            //string CodexDocuments = @Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Codex R4 Documents";
            //if (Directory.Exists(CodexDocuments) == false)
            //    Directory.CreateDirectory(CodexDocuments);

            //string FavoriteDocuments = CodexDocuments + @"\Favorites";
            //if (Directory.Exists(FavoriteDocuments) == false)
            //    Directory.CreateDirectory(FavoriteDocuments);

            //string ComparedDocuments = CodexDocuments + @"\WorkDocuments";
            //if (Directory.Exists(ComparedDocuments) == false)
            //    Directory.CreateDirectory(ComparedDocuments);

            //string CodexUpdateDirectory = CodexDocuments + @"\Codex R4 Update";
            //if (Directory.Exists(CodexUpdateDirectory) == false)
            //    Directory.CreateDirectory(CodexUpdateDirectory);




            //string DockSettings = CodexDocuments + @"\Settings";
            //if (Directory.Exists(DockSettings) == false)
            //    Directory.CreateDirectory(DockSettings);


            string TempDirCodex = Environment.GetEnvironmentVariable("TEMP");
            //if (Directory.Exists(TempDirCodex) == false)
            //{
            //    TempDirCodex = CodexDocuments + @"\Temp";
            //    if (Directory.Exists(TempDirCodex) == false)
            //        Directory.CreateDirectory(TempDirCodex);
            //}

            // Creating Temp Direcotry
            TempDirCodex = TempDirCodex + @"\" + DateTime.Now.Ticks.ToString();
            if (Directory.Exists(TempDirCodex) == false)
                Directory.CreateDirectory(TempDirCodex);

            //string HelpDir = CurrentDirCodex + @"\Help";
            //if (Directory.Exists(HelpDir) == false)
            //    Directory.CreateDirectory(HelpDir);

            Directory.SetCurrentDirectory(CurrentDirCodex);



            // Creating Temp Direcotry
            
            #endregion declarce directoryes


            //global::ILG.Codex.CodexR4.Properties.Settings.Default.TemporaryDir = TempDirCodex;
            //global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexCurrentDirectory = Environment.CurrentDirectory;
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

    

        

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "About":    // ButtonTool
                    About f = new About(); f.ShowDialog();
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

                case "ჩაწერა":    // ButtonTool
                    ultraButton1_Click(null, null);
                    break;

                case "მიღება":    // ButtonTool
                    ultraButton2_Click(null, null);
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

        private void ultraTabPageControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Database_Name_Label_Click(object sender, EventArgs e)
        {

        }
    }
}