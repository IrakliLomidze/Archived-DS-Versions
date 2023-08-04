using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;



namespace ILG.Codex.CodexR4
{
    public partial class Configuration : Form
    {
        bool _ShowInTaskBar = false;
        public Configuration(bool ShowInTaskBar =false)
        {
            InitializeComponent();
            _ShowInTaskBar = ShowInTaskBar;
        }

        public Form1 MainForm;

        private void FillForm()
        {
            this.SQLServerName.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer;

            #region Connection Strings
            ConnectionStringR4_R.Text = ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master;

         
            #endregion Connection Strings

            if (global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLPort == 0 ) this.SQLServerPort.Text = "";
                else this.SQLServerPort.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLPort.ToString();
            
            if (global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLAuthMethod == true) { this.SqlAutMethod_WindowsUser.Checked = false;  this.SqlAutMethod_BySQLUser.Checked = true; }
            else { this.SqlAutMethod_BySQLUser.Checked = false; this.SqlAutMethod_WindowsUser.Checked = true; }
            
           
        }

       
        

        private void Form2_Load(object sender, EventArgs e)
        {

            int formwidth = LeftPanel.Width + ConfiguraitonTop_ICON.Left + ConfiguraitonTop_ICON.Width * 3 + ConfiguraitonTop_ICON.Left + ConfiguraitonTop_Label.Width;
            this.ShowInTaskbar = false; //_ShowInTaskBar;
            FillForm();
   
        }

           
        // Generation Connections Strings
        private void ultraButton5_Click(object sender, EventArgs e)
        {

            string str_CodexR4_master = "";

            string servername = this.SQLServerName.Text.Trim();
            int i;
            
            
         

          #region SQL Server Type Express
                if (this.SQLServerPort.Text.Trim() != "")
                {
                    if (Int32.TryParse(this.SQLServerPort.Text, out i) == false)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("შეცდომაა პორტის ნომერში");
                        return;
                    }
                    servername = this.SQLServerName.Text.Trim() + "," + this.SQLServerPort.Text.Trim();
                }


                if (this.SqlAutMethod_WindowsUser.Checked == true)
                {
                    str_CodexR4_master = "workstation id=" + System.Environment.MachineName +
                                     ";packet size=4096;integrated security=SSPI;data source="
                                     + servername + ";persist security info=False;initial catalog=master;Connection Timeout=30";

      

                }
                else
                {
                    str_CodexR4_master = "workstation id=" + System.Environment.MachineName + ";packet size=4096;" +
                         "user id=sa;" + 
                         "password=" + ILG.Codex.CodexR4.Properties.Settings.Default.sa_passw.Trim() + "; data source=" +
                         servername + ";persist security info=False;initial catalog=master; Connection Timeout=30";

                }

                #endregion SQL Server Type Express
         
            this.ConnectionStringR4_R.Text = str_CodexR4_master;
  

        }

        private bool TestConnectionTo(String _ConnectionString, String Description )
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
                ILG.Windows.Forms.ILGMessageBox.ShowE("სერვერთან კავშირი არ მყარდება "+Description, ex.ToString());
                SQLConnected = false;
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

          //  bool SQLConnected = false;
            if (TestConnectionTo(this.ConnectionStringR4_R.Text, "ConnectionStringR4_R") == false) return;
            
      
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
            if (this.SqlAutMethod_BySQLUser.Checked == true) sqlauthmethod = true;

            try
            {
                ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer = this.SQLServerName.Text.Trim();
                
                ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master = ConnectionStringR4_R.Text.Trim();
                
                

                ILG.Codex.CodexR4.Properties.Settings.Default.SQLPort = (int)portnumber;
                ILG.Codex.CodexR4.Properties.Settings.Default.SQLAuthMethod = sqlauthmethod;
                    
                if (save == true) { global::ILG.Codex.CodexR4.Properties.Settings.Default.Save(); }
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

            Configuration.FirstConfiguration();
            FillForm();
            ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრები აღდგენილია");

        }
        // Configuration Workplace
        static public void FirstConfiguration()
        {
            if (ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer_Type == 0)
            {
                if (global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLAuthMethod == false)
                {
                    #region SQL Server Local Express
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer = ".\\CodexR4";

                    global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLPort = 0;
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLAuthMethod = false;
                    
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.KeyboardLayout = 1;

                
                    generateconnectionstring(0);

                    #endregion SQL Server Local Express

                }
                else
                {
                    #region SQL Server Server
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer = "Codex\\CodexR4";

                    global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLPort = 1433;
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLAuthMethod = true;
                    

                    generateconnectionstring(0);

                    #endregion SQL Server Server

                }
            }
            else
            {
                #region SQL Server Server
                global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer = @"(LocalDB)\MSSQLLocalDB";

                global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLPort = 0;
                //global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLAuthMethod = true;

                
                generateconnectionstring(1);

                #endregion SQL Server Server

            }
        }

        static public void generateconnectionstring(int pSQLServerType)
        {

            //string servername = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer;

            string servername = @".\CodexR4";

            string str_R4_master = "";
            
            if (pSQLServerType == 0)
            {
                #region SQL Server/Express
                if (global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLAuthMethod == false)
                {
                    #region SQL Server Express Local

                    str_R4_master = "workstation id=" + System.Environment.MachineName +
                     ";packet size=4096;integrated security=SSPI;data source="
                     + servername + ";persist security info=False;initial catalog=master;Connection Timeout=30";

                  
                    #endregion SQL Server Express Local
                }
                else
                {
                    #region SQL Server on Server 
                    str_R4_master = "workstation id=" + System.Environment.MachineName + ";packet size=4096;" +
                        "user id=sa;" +
                        "password=" + ILG.Codex.CodexR4.Properties.Settings.Default.sa_passw.Trim() + "; data source=" +
                        servername + ";persist security info=False;initial catalog=master;Connection Timeout=30";
                    
                    #endregion SQL Server on Server 
                }
                #endregion SQL Server/Express
            }
            else
            {
                #region SQL Server Express Local

                
               
                #endregion SQL Server Express Local
            }


            global::ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master = str_R4_master;
          

        }

        public bool isconnecting()
        {
            t:
            
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            SqlConnection test = new SqlConnection(global::ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);
            //MessageBox.Show(global::ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString);

            //bool SQLConnected = false;
            try
            {
                test.Open();
              //  SQLConnected = true;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                Form1.sp.ShowInTaskbar = true;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                if (ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ბაზასთან დაკავშირება \nგსურთ კოფიგურაციის ცვლილება", "Connection Error", ex.ToString(), System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }
                else
                {
                //    SQLConnected = false;
                    test.Close();
                    Configuration cf = new Configuration();
                    cf.ShowDialog();
                    goto t;
                }
            }
            finally
            {
                if (test.State == System.Data.ConnectionState.Open)
                {
                    test.Close();
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
            return true;
            
        }

        static public void load()
        {
            // Changed In R4 Update #1

            #region Declarce Directoryes R4 Update #1
            string CurrentDirCodex = System.Environment.CurrentDirectory;

            string CodexDocuments = @Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Codex R4 Documents";
            if (Directory.Exists(CodexDocuments) == false)
                Directory.CreateDirectory(CodexDocuments);
            
            string TempDirCodex = Environment.GetEnvironmentVariable("TEMP");
            if (Directory.Exists(TempDirCodex) == false)
            {
                TempDirCodex = CodexDocuments + @"\Temp";
                if (Directory.Exists(TempDirCodex) == false)
                    Directory.CreateDirectory(TempDirCodex);
            }

            // Creating Temp Direcotry
            TempDirCodex = TempDirCodex + @"\" + DateTime.Now.Ticks.ToString();
            if (Directory.Exists(TempDirCodex) == false)
                Directory.CreateDirectory(TempDirCodex);

            
            
            
            Directory.SetCurrentDirectory(CurrentDirCodex);

            global::ILG.Codex.CodexR4.Properties.Settings.Default.TemporaryDir = TempDirCodex;


            #endregion Declarce Directoryes R4 Update #1



            if (global::ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master == "") 
            {
                FirstConfiguration();
                global::ILG.Codex.CodexR4.Properties.Settings.Default.Save();
            }
            
         

        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Close();
        }





        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
        }

        

        private void Button_Install_Config_DataBaseInfo_Click(object sender, EventArgs e)
        {
            //xxxx
            String CodexLocalDBDataDirectories = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\Codex R4 Database";
            

            if (Directory.Exists(CodexLocalDBDataDirectories) == false)
                Directory.CreateDirectory(CodexLocalDBDataDirectories);

           }

        private void SQLServerType_ValueChanged(object sender, EventArgs e)
        {
            {
                // SQL Server / Express Mode
                SQLServerName.Enabled = true;
                SQLServerName.Text = @"";
                SQLServerPort.Enabled = true;
                SQLServerPort.Visible = true;
                SqlAutMethod_BySQLUser.Enabled = true;
                SqlAutMethod_BySQLUser.Visible = true;
                SqlAutMethod_WindowsUser.Enabled = true;
                SqlAutMethod_WindowsUser.Visible = true;
                //CodexAuthMetodGroup.Visible = true;
                SqlAutMethod_saPassword.Visible = true;
                SqlAutMethod_saPassword.Enabled = true;
                SQLTab.SelectedTab = SQLTab.Tabs[0];
                SQLTab.ActiveTab = SQLTab.Tabs[0];
            }

        }

        

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[1];
        }


        private void Link_Script_CodexUsersFull_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String Command = Properties.Resources.Script_Drop_DSCU + System.Environment.NewLine +
                             Properties.Resources.Script_Register_DSCU;
            ShowScriptInNotePad(Command, "Script_CU_DSUsers");
        }

        private void Link_Script_DropCodexUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String Command = Properties.Resources.Script_Drop_DSCU ;
            ShowScriptInNotePad(Command, "Script_Drop_DSUsers");
        }

        private void Link_Script_RegisterCodexUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String Command = ILG.Codex.CodexR4.Properties.Resources.Script_Register_DSCU;
            ShowScriptInNotePad(Command, "Script_Register_DSUsers");
        }



        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowScriptInNotePad(Properties.Resources.FullTextCreateAndPopulate_DS, 
                                "Script_FullText_CreateAndPopulate");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowScriptInNotePad(Properties.Resources.FullTextCreate,
                                 "Script_FullText_Create");
        }

        private void Link_Script_CodexXUsersFull_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String Command = Properties.Resources.Script_Drop_DSCXU + System.Environment.NewLine +
                             Properties.Resources.Script_Register_DSCXU;
            ShowScriptInNotePad(Command, "Script_CU_DSXUsers");
        }

        private void Link_Script_DropCodexXUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String Command = Properties.Resources.Script_Drop_DSCXU;
            ShowScriptInNotePad(Command, "Script_Drop_DSXUsers");
        }

        private void Link_Script_RegisterCodexXUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String Command = Properties.Resources.Script_Register_DSCXU;
            ShowScriptInNotePad(Command, "Script_Register_DSXUsers");
        }


        private void ShowScriptInNotePad(String script,String BaseFileName)
        {
            String Command = script;

            #region  Codex Script Temp Files
            int f_index = 0;
            string CodexScriptTempFilename = Properties.Settings.Default.TemporaryDir + "\\"+BaseFileName+"_" + f_index.ToString();

            while (System.IO.File.Exists(CodexScriptTempFilename) == true)
            {
                f_index++;
                CodexScriptTempFilename = Properties.Settings.Default.TemporaryDir + "\\" + BaseFileName + "_" + f_index.ToString();
            }

            #endregion Codex Script Temp Files

            File.WriteAllText(CodexScriptTempFilename, Command, Encoding.UTF8);
            System.Diagnostics.Process.Start("Notepad", CodexScriptTempFilename);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowScriptInNotePad(Properties.Resources.FullTextPopulate,
                                  "Script_FullText_Populate");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowScriptInNotePad(Properties.Resources.Legacy_BuiltinUsersDS,
                                          "Legacy_BuiltinUsersDS");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowScriptInNotePad(Properties.Resources.Legacy_BuiltinUsersDSR3,
                                    "Legacy_BuiltinUsersDSR3");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowScriptInNotePad(Properties.Resources.CreateHistoryTable,
                               "CreateHistoryTable");
        }
    }
}