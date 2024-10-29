using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ILG.DS.AppStateManagement;
using DS.Configurations;
using ILG.DS.Profile;
using ILG.DS.Controls;
using ILG.DS.Dialogs;
using ILG.Codex.CodexR4;

namespace ILG.DS.Configurations.Dialogs
{
    public partial class DSProfileSQLServerConfiguration : Form
    {
        bool _ShowInTaskBar = false;
        private DSProfileManager _dsProfileManager;
        private UserSQLConfigurationManager _userSQLConfiguration;
        public DSProfileSQLServerConfiguration(bool ShowInTaskBar =false)
        {
            InitializeComponent();
            _ShowInTaskBar = ShowInTaskBar;
            ProfileNameLabel.Text = app.state.DS_Porfile_DisplayName;
        }

        public Form1 MainForm;

        private void Form2_Load(object sender, EventArgs e)
        {
            int formwidth = LeftPanel.Width + ConfiguraitonTop_ICON.Left + ConfiguraitonTop_ICON.Width * 3 + ConfiguraitonTop_ICON.Left + ConfiguraitonTop_Label.Width;
            this.ShowInTaskbar = _ShowInTaskBar;

            _dsProfileManager = new DSProfileManager(app.state.DS_Profile_Id + ".dsprofile",
                                                     Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory + @"\PROFILES"));
            _dsProfileManager.ReadConfiguraiton();
            _userSQLConfiguration = new UserSQLConfigurationManager(app.state.DS_Profile_Id);
            _userSQLConfiguration.ReadConfiguraiton();


            SQLServerNameEditBox.Text = _userSQLConfiguration.content.db_host ?? "";
            SQLServerPort.Text = _userSQLConfiguration.content.db_port ?? "" ;
            FullTextCheck.Checked = ((_userSQLConfiguration.content.db_usefulltext ?? "").ToUpper().Trim() == "TRUE");
        }


      

        private bool TestConnection(String _ConnectionString, ref String Err,  bool ShowWarning = true )
        {
            this.Cursor = Cursors.WaitCursor;
            SqlConnection test = new SqlConnection(_ConnectionString);

            bool SQLConnected = false;
            try
            {
                test.Open();
                SQLConnected = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                string ErrorDetail = ex.Message + Environment.NewLine + ex.ToString() 
                    + Environment.NewLine +  "DS Client On Connection string : " 
                    + Environment.NewLine + _ConnectionString ;
                if (ShowWarning == true) ILGMessageBox.ShowE("სერვერთან კავშირი არ მყარდება ", ErrorDetail);
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
            this.Cursor = Cursors.Default;
            return SQLConnected;

        }

        private void TestConnection_Click(object sender, EventArgs e)
        {
            string st = generateconnectionString();
            if (st != "")
            {
                string err = "";
                if (TestConnection(st,ref err, true) == true) ILGMessageBox.Show("კავშირი წარმატებულად დამყარდა");
            }
        }

        

        private int configurationApplySave()
        {
            int portnumber = 0;
            if (this.SQLServerPort.Text.Trim() != "")
            {
                if (Int32.TryParse(this.SQLServerPort.Text.Trim(), out portnumber) == false)
                {
                    ILGMessageBox.Show("შეცდომაა პორტის ნომერში");
                    return 1;
                }
            }


            try
            {
                _userSQLConfiguration.content.db_host = SQLServerNameEditBox.Text.Trim();
                _userSQLConfiguration.content.db_port = ((UInt32)portnumber).ToString();
                _userSQLConfiguration.content.db_usefulltext = FullTextCheck.Checked.ToString().ToUpper();
                _userSQLConfiguration.content.db_connectionstring = generateconnectionString();
                _userSQLConfiguration.WriteConfiguration();

            }
            catch (Exception ex)
            {
                ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის ჩაწერა კონფიგურაციის ფაილში", ex.Message.ToString());
                return 3;
            }
            //ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            return 0;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (ILGMessageBox.Show("ახალი კონფიგურაციის ჩაწერა ?", "", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (configurationApplySave() == 0)
            {
                ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            }

        }


        public string generateconnectionString(int timeout = 45)
        {
            string servername = this.SQLServerNameEditBox.Text.Trim();

            int i;
         
            if ((SQLServerPort.Text.Trim() != "") && (SQLServerPort.Text.Trim() != "1433") && (SQLServerPort.Text.Trim() != "0"))
            {
                if (Int32.TryParse(this.SQLServerPort.Text, out i) == false)
                {
                    ILGMessageBox.Show("შეცდომაა პორტის ნომერში"); return "";
                }
                servername = this.SQLServerNameEditBox.Text.Trim() + "," + this.SQLServerPort.Text.Trim();
            }

            servername = servername.Replace(@"/",@"\");
            string _db_name = _dsProfileManager._content.ds_db_name.Trim();
            string CodexUserName = _dsProfileManager._content.ds_sql_sqluser_username.Trim();
            string CodexUserPassword = _dsProfileManager._content.ds_sql_sqluser_password.Trim();


            string cn = "workstation id=" + Environment.MachineName + ";packet size=4096;" +
                 "user id=" + CodexUserName + ";" +
                 //"password=" + CodexUserPassword + "; data source=" +
                 "password=" + CodexUserPassword + "; server=" +
                 servername + ";persist security info=False;initial catalog=" + _db_name + $";Connection Timeout = {timeout}";
            return cn;
        }

      
        private void CloseButton_Click(object sender, EventArgs e)
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
                    
                    break;

                case "Web":    // ButtonTool
                    
                    break;

    
                case "დახურვა":    // ButtonTool
                    Close();
                    break;

                case "ჩაწერა":    // ButtonTool
                    Save_Click(null, null);
                    break;


            }

        }
        
    }
}