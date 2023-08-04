using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ILG.Codex.CodexR4.CodexSettings;


namespace ILG.Codex.CodexR4
{
    public partial class ConfigurationSQL : Form
    {
        bool _ShowInTaskBar = false;
        public ConfigurationSQL(bool ShowInTaskBar =false)
        {
            InitializeComponent();
            _ShowInTaskBar = ShowInTaskBar;
            
        }

        public Form1 MainForm;

        private void FillForm()
        {
            this.SQLServerNameEditBox.Text = SQLDatabaseConfiguration.Default.SQLServer;
            Combo_StrongPassword.SelectedIndex = 0;

            #region Connection Strings
            TextBox_ConnectionStringDS.Text = SQLConnectionStrings.Default.ConnectionString_CodexDS;

      
            #endregion Connection Strings

            if (SQLDatabaseConfiguration.Default.SQLPort == 0 ) this.SQLServerPort.Text = "";
                else this.SQLServerPort.Text = SQLDatabaseConfiguration.Default.SQLPort.ToString();
            
            if (SQLDatabaseConfiguration.Default.SQLAuthMethod == true) { this.radioButton_WinAuth.Checked = false;  this.radioButton_SQLAuth.Checked = true; }
            else { this.radioButton_SQLAuth.Checked = false; this.radioButton_WinAuth.Checked = true; }
            
            this.FullTextCheck.Checked = SQLDatabaseConfiguration.Default.UseFullTextSearch;
          
            this.SQLServerType.SelectedIndex = (int)SQLDatabaseConfiguration.Default.SQLServer_Type;
            this.SQLServerType_CurrentValue = (int)SQLDatabaseConfiguration.Default.SQLServer_Type;

            
        
                    SQLServerType.SelectedIndex = 0;
                    SQLServerType_ValueChanged(null, null);
                    SQLServerType.ReadOnly = true;
      
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            int formwidth = LeftPanel.Width + ConfiguraitonTop_ICON.Left + ConfiguraitonTop_ICON.Width * 3 + ConfiguraitonTop_ICON.Left + ConfiguraitonTop_Label.Width;
            this.ShowInTaskbar = _ShowInTaskBar;
            FillForm();
        }

        
        // Generation Connections Strings
        private void ultraButton5_Click(object sender, EventArgs e)
        {
            string str_CodexDS = "";
        

            string servername = this.SQLServerNameEditBox.Text.Trim();
            int i;
            
            string CatalogName_CodexR4 = "Codex2007DS";


            #region SQL Server Type Express
                if (this.SQLServerPort.Text.Trim() != "")
                {
                    if (Int32.TryParse(this.SQLServerPort.Text, out i) == false)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("შეცდომაა პორტის ნომერში");
                        return;
                    }
                    servername = this.SQLServerNameEditBox.Text.Trim() + "," + this.SQLServerPort.Text.Trim();
                }


                if (this.radioButton_WinAuth.Checked == true)
                {
                    str_CodexDS = "workstation id=" + System.Environment.MachineName +
                                     ";packet size=4096;integrated security=SSPI;data source="
                                     + servername + ";persist security info=False;initial catalog=" + CatalogName_CodexR4 + ";Connection Timeout=30";
                }
                else
                {

                    String CodexUserName = SQLServerConfigurationStatic.Default.CodexDS_XUser_Client_SQLUserName.Trim();
                    String CodexUserPassword = SQLServerConfigurationStatic.Default.CodexDS_XUser_Client_SQLPassword.Trim();


                    if (Combo_StrongPassword.SelectedIndex != 0)
                    {
                        CodexUserName = SQLServerConfigurationStatic.Default.CodexDS_User_Client_SQLUserName.Trim();
                        CodexUserPassword = SQLServerConfigurationStatic.Default.CodexDS_User_Client_SQLPassword.Trim();

                    }
                    
                    #region Read Write Connections
                    str_CodexDS = "workstation id=" + System.Environment.MachineName + ";packet size=4096;" +
                     "user id=" + CodexUserName + ";" +
                     "password=" + CodexUserPassword + "; data source=" +
                     servername + ";persist security info=False;initial catalog=" + CatalogName_CodexR4 + ";Connection Timeout=30";

                 
                    #endregion Read Write Connections
                }

                #endregion SQL Server Type Express
       

            this.TextBox_ConnectionStringDS.Text = str_CodexDS;


        }

        private bool TestConnectionTo(String _ConnectionString, String Description, ref String Err,  bool ShowWarning = true )
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            SqlConnection test = new SqlConnection(_ConnectionString);

            bool SQLConnected = false;
            try
            {
                test.Open();
                SQLConnected = true;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                if (ShowWarning == true) ILG.Windows.Forms.ILGMessageBox.ShowE("სერვერთან კავშირი არ მყარდება "+Description, ex.ToString());
                SQLConnected = false;
                Err = ex.Message.ToString();
            }
            finally
            {
                if (test.State == System.Data.ConnectionState.Open)
                {
                    test.Close();
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
            return SQLConnected;

        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            String ErrString = "";
          //  bool SQLConnected = false;
            if (TestConnectionTo(this.TextBox_ConnectionStringDS.Text, "ConnectionString", ref ErrString) == false) return;
          
            ILG.Windows.Forms.ILGMessageBox.Show("კავშირი წარმატებულად დამყარდა");
            
        }

        

        private int configurationApplySave(bool save)
        {
            int portnumber = 0;
            if (this.SQLServerPort.Text.Trim() != "")
            {
                if (Int32.TryParse(this.SQLServerPort.Text.Trim(), out portnumber) == false)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("შეცდომაა პორტის ნომერში");
                    return 1;
                }
            }

        
            
            bool sqlauthmethod = false;
            if (this.radioButton_SQLAuth.Checked == true) sqlauthmethod = true;

            try
            {
                SQLDatabaseConfiguration.Default.SQLServer = this.SQLServerNameEditBox.Text.Trim();

                SQLConnectionStrings.Default.ConnectionString_CodexDS = TextBox_ConnectionStringDS.Text.Trim();
    

                SQLDatabaseConfiguration.Default.SQLPort = (UInt32)portnumber;
                SQLDatabaseConfiguration.Default.SQLAuthMethod = sqlauthmethod;
                SQLDatabaseConfiguration.Default.UseFullTextSearch = this.FullTextCheck.Checked;
            
                if (save == true)
                {
                    SQLDatabaseConfiguration.Default.Save();
                    SQLConnectionStrings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                if (save == true) ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის ჩაწერა კონფიგურაციის ფაილში", ex.Message.ToString());
                else ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის მიღება კონფიგურაციის ფაილში", ex.Message.ToString());
                return 3;
            }
            //ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            return 0;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი კონფიგურაციის ჩაწერა ?", "", 
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

            if (configurationApplySave(true) == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            }

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი კონფიგურაციის მიღება ?", "",
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

            if (configurationApplySave(false) == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია მიღებულია");
            }
        }

        private void DetailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრების აღდგენა ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            if (ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრების აღდგენა ? \nდაადასტურეთ!", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            ConfigurationSQL.FirstConfiguration();
            FillForm();
            ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრები აღდგენილია");

        }
        // Configuration Workplace
        static public void FirstConfiguration()
        {
           
            
                #region SQL Server Server
                    SQLDatabaseConfiguration.Default.SQLServer = "Codex\\CodexR4";
                    SQLDatabaseConfiguration.Default.SQLPort = 1433;
                    SQLDatabaseConfiguration.Default.SQLAuthMethod = true;


                    Properties.Settings.Default.MaximumDocListCodex = 1200;
                    SQLDatabaseConfiguration.Default.UseFullTextSearch = true;


                    //Properties.Settings.Default.SaveDockPosition = 0;


                    Properties.Settings.Default.ZoomDS = -20;
                    
                    //Properties.Settings.Default.DocumentPreviewZoom = 2;

                    Properties.Settings.Default.KeyboardLayout = 1;

                    //Properties.Settings.Default.DocumentLinkPanelDockPosition = 0;
                    //Properties.Settings.Default.DocumentSearchPanelDockPosition = 0;
                    //Properties.Settings.Default.DocumentPreviewPanelDockPosition = 0;
                    generateconnectionstring(0);

                    #endregion SQL Server Server

        
        }

        static public void generateconnectionstring(int pSQLServerType)
        {

            //string servername = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer;

            string servername = @".\CodexR4";


            string str_CodexDS = "";

            //string servername = this.SQLServerName.Text.Trim();
            //int i;

            string CatalogName_CodexDS = "Codex2007DS";

            if (pSQLServerType == 0)
            {
                #region SQL Server/Express
     
                {
                    #region SQL Server on Server 
                    str_CodexDS = "workstation id=" + System.Environment.MachineName + ";packet size=4096;" +
                        "user id=" + SQLServerConfigurationStatic.Default.CodexDS_User_Client_SQLUserName.Trim() + ";" +
                        "password=" + SQLServerConfigurationStatic.Default.CodexDS_User_Client_SQLPassword.Trim() + "; data source=" +
                        servername + ";persist security info=False;initial catalog=" + CatalogName_CodexDS + ";Connection Timeout=30";

                  
                    #endregion SQL Server on Server 
                }
                #endregion SQL Server/Express
            }
   


            SQLConnectionStrings.Default.ConnectionString_CodexDS = str_CodexDS;

          

        }

       public bool isconnectionParticularDatabase(String ConnectionString, String ConnectionStringName, String DatabaseName,  ref bool isCanceled )
        {
            String ErrString = "";
            while ( TestConnectionTo(ConnectionString, ConnectionStringName, ref ErrString, ShowWarning : false ) == false) 
                
            {
                Form1.sp.ShowInTaskbar = true;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                if (ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება "+DatabaseName+" ბაზასთან დაკავშირება \nგსურთ კონფიგურაციის ცვლილება", "Connection Error", ErrString.ToString(), System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.No)
                {
                    isCanceled = true;
                }
                else
                {
                    isCanceled = false;
                }

                return false;


            }

            return true;
        }
        public bool isconnecting()
        {
            //this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            bool isCanceled = false;
           
            while (isconnectionParticularDatabase(SQLConnectionStrings.Default.ConnectionString_CodexDS, "ConnectionStringDS", "Codex2007DS", ref isCanceled) == false)
            {
                if (isCanceled == true) return false;
                ConfigurationSQL cf = new ConfigurationSQL();
                cf.ShowDialog();
                isCanceled = false;
            }
            

            
            this.Cursor = System.Windows.Forms.Cursors.Default;
            return true;
            
        }

        static public void load()
        {

            // Codex R4 License Informaiton And Behaviur
            #region Codex R4 License

            // Update License Information

            //global::ILG.Codex.CodexR4.Properties.Settings.Default.isisWorkstation = false;


            #endregion Codex R4 License



            if (SQLConnectionStrings.Default.ConnectionString_CodexDS == "") 
            {
                FirstConfiguration();
                SQLConnectionStrings.Default.Save();
                SQLDatabaseConfiguration.Default.Save();
            }
            
            #region Policy Settings
    
            #region ConnectionString
            if ((SQLConnectionStrings.Default.IsConnectionString == true) &&
                (SQLConnectionStrings.Default.App_CodexDS_ConnectionString.Trim() != "" )  
                )
            {
       
                SQLConnectionStrings.Default.ConnectionString_CodexDS = SQLConnectionStrings.Default.App_CodexDS_ConnectionString;
       
            }
            #endregion ConnectionString

            #region FullText
            if ((SQLDatabaseConfiguration.Default.IsFullText == true))
            {
                SQLDatabaseConfiguration.Default.UseFullTextSearch = SQLDatabaseConfiguration.Default.AppUseFullTextSearch;
            }

            #endregion FullText

            #endregion Policy Settings
            


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
                    AboutDS f = new AboutDS(); f.ShowDialog();
                    break;

    
                case "FeedBack":    // ButtonTool
                    System.Diagnostics.Process.Start("mailto:support@codex.ge");
                    break;

                case "Web":    // ButtonTool
                    System.Diagnostics.Process.Start("http://www.codex.ge");
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
        
        int SQLServerType_CurrentValue = 0;//(int)global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer_Type;

        private void SQLServerType_ValueChanged(object sender, EventArgs e)
        {
            {
                // SQL Server / Express Mode
                SQLServerNameEditBox.Enabled = true;
                SQLServerNameEditBox.Text = @"Codex\CodexR4";
                
                SQLServerPort.Enabled = true;
                SQLServerPort.Visible = true;
                radioButton_SQLAuth.Enabled = true;
                radioButton_SQLAuth.Visible = true;
                radioButton_WinAuth.Enabled = true;
                radioButton_WinAuth.Visible = true;
               // if (global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLAuthMethod == true)
                this.radioButton_WinAuth.Checked = false;
                this.radioButton_SQLAuth.Checked = true;
                

                CodexAuthMetodGroup.Visible = true;
                FullTextCheck.Enabled = true;
                FullTextCheck.Checked = true;
                Database_Post_Label.Visible = true;
                SQLTab.SelectedTab = SQLTab.Tabs[0];
                SQLTab.ActiveTab = SQLTab.Tabs[0];

                { SQLServerNameEditBox.Text = @".\CodexR4";
                  this.radioButton_SQLAuth.Checked = false;
                  this.radioButton_WinAuth.Checked = true; 
                }


            }

        }

        private void Button_Install_Config_DataBaseInfo_Click(object sender, EventArgs e)
        {
            
        }

        private void DropFromLocalDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void radioButton_SQLAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_SQLAuth.Checked)
            {
                radioButton_WinAuth.Checked = false;
            }
        }

        private void radioButton_WinAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_WinAuth.Checked)
            {
                radioButton_SQLAuth.Checked = false;
            }
        }
    }
}