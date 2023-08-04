using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ILG.Windows.Forms;
using System.IO;
using System.Threading;
using System.Security.Principal;

namespace ILG.Codex.CodexR4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static SplashScreen sp;

        int pagenumber_DatabaseInstaller;
        int pagenumber_DatabaseCreator;
        public static bool   Copying;
        CodexDSDataBaseInfo df = new CodexDSDataBaseInfo();
        

        private int showdetails()
        {
            CodexDSDataBaseInfo f = new CodexDSDataBaseInfo();
            int c = f.GetInfo(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer);
            if (c == 0)
            {
                try
                {
                    this.Install_Group_Step1.Text = f.DisplayString;
                }
                catch
                {
                    this.Install_Group_Step1.Text = "No Database Info";
                    return 1;
                }
            }
            else
            {
                this.Install_Group_Step1.Text = "Error in Reading Info File";
                return 2;
            }

            return c;

        }

        #region startinfo
     
        



        #endregion startinfo

        public delegate void ShowProgressDelegate(int progress, String Str, Color TextColor );


        public void ShowProgress_DatabaseInstaller(int progress, String Str, Color TextColor )
        {
            if (this.Install_listBox_Step1.InvokeRequired == false)
            {
                string[] StrItems = Str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String Str_Item in StrItems)
                {
                    if (Str_Item != "") this.Install_listBox_Step1.Items.Add(Str_Item);
                }
                this.Install_listBox_Step1.SelectedIndex = this.Install_listBox_Step1.Items.Count - 1;
                this.Install_listBox_Step1.ForeColor = TextColor;
                //this.progressBar2.Value = progress;
            }
            else
            {
                ShowProgressDelegate showProgress = new ShowProgressDelegate(ShowProgress_DatabaseInstaller);
                // Show progress synchronously 
                Invoke(showProgress, new object[] { progress, Str, TextColor });
            }


        }

        public void ShowProgress_MakeDatabase(int progress, string Str, Color TextColor)
        {
            if (this.TextEdit_Make_Step1.InvokeRequired == false)
            {
                if (Str != "")
                {
                    this.TextEdit_Make_Step1.SuspendLayout();
                    this.TextEdit_Make_Step1.Appearance.ForeColor = TextColor;
                    this.TextEdit_Make_Step1.Focus();
                    this.TextEdit_Make_Step1.Text = this.TextEdit_Make_Step1.Text + System.Environment.NewLine + Str;
                    if (TextEdit_Make_Step1.Text.Length > 0) this.TextEdit_Make_Step1.SelectionStart = this.TextEdit_Make_Step1.Text.Length - 1;
                    this.TextEdit_Make_Step1.ScrollToCaret();
                    this.TextEdit_Make_Step1.Focus();
                    this.TextEdit_Make_Step1.ResumeLayout();
                 
                //    if (Object.ReferenceEquals(null, TextColor) == true) this.TextEdit_Make_Step1.Appearance.ForeColor = Color.Black; 
                //                      else this.TextEdit_Make_Step1.Appearance.ForeColor = (Color)TextColor;
                //
                }

                //this.progressBar2.Value = progress;
            }
            else
            {
                ShowProgressDelegate showProgress = new ShowProgressDelegate(ShowProgress_MakeDatabase);
                // Show progress synchronously 
                Invoke(showProgress, new object[] { progress, Str, TextColor });
            }


        }


        public void _DropCodexUsers()
        {

            CodexDatabase s = new CodexDatabase(this);
            if (s.GetInfoFrom() != 0) return;

            this.Button_Close.Enabled = false;
            this.Button_Back.Enabled = false;
            this.Button_Next.Enabled = false;
            linkLabel1.Enabled = false;
            this.Install_StartButton_Step1.Enabled = false;


            if (s.DropCodexDSDatabaseUser() != 0) return;

            ShowProgress_DatabaseInstaller(0, "--------------------------------------------------------------", Color.Green);

            ShowProgress_DatabaseInstaller(0, "Done", Color.Green);

            this.Install_StartButton_Step1.Enabled = false;
            this.Button_Close.Enabled = true;
            linkLabel1.Enabled = true;
            for (int i = 0; i < this.ultraToolbarsManager1.Tools.Count; i++) { ultraToolbarsManager1.Tools[i].SharedProps.Enabled = true; }

            return;

        }
        public void _DropCodexXUsers()
        {

            CodexDatabase s = new CodexDatabase(this);
            if (s.GetInfoFrom() != 0) return;

            this.Button_Close.Enabled = false;
            this.Button_Back.Enabled = false;
            this.Button_Next.Enabled = false;
            linkLabel1.Enabled = false;
            this.Install_StartButton_Step1.Enabled = false;


            if (s.DropCodexDatabaseDSXUser() != 0) return;

            ShowProgress_DatabaseInstaller(0, "--------------------------------------------------------------", Color.Green);

            ShowProgress_DatabaseInstaller(0, "Done", Color.Green);

            this.Install_StartButton_Step1.Enabled = false;
            this.Button_Close.Enabled = true;
            linkLabel1.Enabled = true;
            for (int i = 0; i < this.ultraToolbarsManager1.Tools.Count; i++) { ultraToolbarsManager1.Tools[i].SharedProps.Enabled = true; }

            return;

        }


        public void DatabaseInstaller_Process_Workflow()
        {
            CodexDatabase s = new CodexDatabase(this);
            s.GetInfoFrom();
            //if (s.GetInfoFrom() != 0) return;

            //    MessageBox.Show(" 1: " +Properties.Settings.Default.CodexDatabaseTo_Installer.ToString());
            // Normal SQL Server
            InstallMode_CopyFiles = true;
            if (this.InstallMode_CopyFiles == true)
            {
                if (s.dropDatabase(true) != 0) return;     // Drop Existing Databases
                if (s.ProcessFiles_CopyToDatabase() != 0) return;  // CopyFiles
            }

            if (s.AttachDatabase() != 0) return;  // Atached Database

            //if (InstallMode_DatabaseBuiltinUsers == true) // Register Users if Nesessry
            //{
            //    if (s.RegisterDatabaseBuitinUser() != 0) return;  
            //}

            if (InstallMode_FullText == true)
            {
                if (s.CodexFullText() != 0) return;
            }

            if (InstallMode_DatabaseCodexXUsers == true) // Register Users if Nesessry
            {
                if (s.RegisterCodexDatabaseDSXUser() != 0) return;
            }


            if (InstallMode_DatabaseCodexUsers == true) // Register Users if Nesessry
            {
                if (s.RegisterCodexDSDatabaseUser() != 0) return;
            }

           
            CodexDatabase.UpdateToStructure16();

            ShowProgress_DatabaseInstaller(0, "--------------------------------------------------------------", Color.Green);

            ShowProgress_DatabaseInstaller(0, "მონაცემთა ბაზის კოპირება და რეგისტრაცა დასრულებულია", Color.Green);
            return;



        }


        

        public void DatabaseInstaller_Process()
        {
            this.Button_Close.Enabled = false;
            this.Button_Back.Enabled = false;
            this.Button_Next.Enabled = false;
            linkLabel1.Enabled = false;
            this.Install_StartButton_Step1.Enabled = false;

            Properties.Settings.Default.CodexDatabaseTo_Installer = this.Edit_Install_Config_WhereTo.Text;


            for (int i = 0; i < this.ultraToolbarsManager1.Tools.Count; i++) { ultraToolbarsManager1.Tools[i].SharedProps.Enabled = false; }

            // Defince Workflow

            ShowProgress_DatabaseInstaller(0, "მონაცემთა ბაზის კოპირების და რეგისტრაციის პროცესი", Color.Black);

            DatabaseInstaller_Process_Workflow();

            //this.Button_Next.Enabled = true;
            this.Install_StartButton_Step1.Enabled = false; 
            this.Button_Close.Enabled = true;
            linkLabel1.Enabled = true;
            for (int i = 0; i < this.ultraToolbarsManager1.Tools.Count; i++) { ultraToolbarsManager1.Tools[i].SharedProps.Enabled = true; }


        }

        delegate void ProcessDelegate();




        // Code is Same Copying From Next Button Click Removed Increments and Tab Next 
        // Remove All and Keep Only for Buttons
        private void UpdateCurrent_State_WhenGenral_TabChanged()
        {
            if (GeneralTab.ActiveTab.Index == 0)
            {
                #region Database Installer

                if (pagenumber_DatabaseInstaller == 1)
                {
                    Button_Back.Enabled = false;
                    Button_Close.Enabled = true;
                    Button_Next.Enabled = true;
                    return;

                }

                if (pagenumber_DatabaseInstaller == 2) 
                {
                    Button_Back.Enabled = true;
                    Button_Close.Enabled = true;
                    Button_Next.Enabled = true;
                    return;
                }
       
                if (pagenumber_DatabaseInstaller == 3)
                {
                    Button_Back.Enabled = true;
                    Button_Close.Enabled = true;
                    Button_Next.Enabled = false;
                    return;
                }


                if (pagenumber_DatabaseInstaller == 4)
                {
                    Button_Back.Enabled = true;
                    Button_Close.Enabled = true;
                    Button_Next.Enabled = true;
                    return;  
                }
         

                if (pagenumber_DatabaseInstaller == 5)
                {
                    Button_Back.Enabled = true;
                    Button_Close.Enabled = true;
                    Button_Next.Enabled = true;
                    return;
                }

                if (pagenumber_DatabaseInstaller == 6)
                {
                    Button_Back.Enabled = true;
                    Button_Close.Enabled = true;
                    Button_Next.Enabled = true;
                    return;               
                }


                if (pagenumber_DatabaseInstaller == 7)
                {
                    Button_Back.Enabled = true;
                    Button_Close.Enabled = true;
                    Button_Next.Enabled = false;
                    return;
                }


                if (pagenumber_DatabaseInstaller == 8)
                {
                    Button_Next.Enabled = false;
                }
         
                #endregion Database Installer

                return;
            }

            if (GeneralTab.ActiveTab.Index == 1)
            {
                #region Database Creator

                if (pagenumber_DatabaseCreator == 1)
                {
                    Button_Back.Enabled = false;
                    Button_Close.Enabled = true;
                    Button_Next.Enabled = true;
                    return;

                }

            
                if (pagenumber_DatabaseCreator == 2)
                {
                    Button_Back.Enabled = true;
                    Button_Close.Enabled = true;
                    Button_Next.Enabled = true;
                    return;
            
                }

                if (pagenumber_DatabaseCreator == 3)
                {
                    Button_Close.Enabled = true;
                    this.Button_Next.Enabled = false;
                    this.Button_Back.Enabled = true;
                }

                if (pagenumber_DatabaseCreator == 4)
                {
                    Button_Close.Enabled = true;
                    this.Button_Next.Enabled = false;
                    this.Button_Back.Enabled = true;
                }

            
                #endregion Database Creator

                return;
            }
       
        }


        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (GeneralTab.ActiveTab.Index == 0)
            {
                #region Database Installer

                #region Page2
                pagenumber_DatabaseInstaller++;
                if (pagenumber_DatabaseInstaller == 2)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    //ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer;
                    //ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer;
                    this.Edit_Install_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer;
                    this.Edit_Install_Config_WhereTo.Text = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer;  // textBox1.Text = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom;
                    this.Edit_Install_Config_DataBaseInfo.Text = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer;// this.textBox10.Text = Common.FromPath;





                    if (ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master.Trim() != "")
                    {
                        try
                        {
                            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                            var Info = CodexDatabase.GetSQLServerInfo(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);
                            string s = Info.Edition;
                            this.InfoLabel_SqlServer.Text = "SQL Server";
                            this.InfoValueLabel_InstanceName.Text = s;
                            this.InfoLabel_SqlVersion.Text = "Version";
                            this.InfoValueLabel_ProductVersion.Text = Info.ProductLevel;
                            this.InfoLabel_FullText.Text = "FullText";
                            if (Info.IsFullTextInstalled.Trim() == "1") this.InfoValueLabelFullText.Text = "Installed"; else this.InfoValueLabelFullText.Text = "Not Installed";
                            this.InfoLabel_Collation.Text = "Collcation";
                            this.InfoValueLabelCollation.Text = Info.Collation;

                    
                            Install_Config_Connect(false);
                        }
                        catch //(Exception x)
                        {
                            this.InfoLabel_SqlServer.Text = "";
                            this.InfoValueLabel_InstanceName.Text = "";
                            this.InfoLabel_SqlVersion.Text = "";
                            this.InfoValueLabel_ProductVersion.Text = "";
                            this.InfoLabel_FullText.Text = "";
                            this.InfoValueLabelFullText.Text = "";
                            this.InfoLabel_Collation.Text = "";
                            this.InfoValueLabelCollation.Text = "";
                            //this.SQLInfo.Text = "";
                            this.Cursor = System.Windows.Forms.Cursors.Default;
                            //ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დირექტორიის მოძებნა", x.Message.ToString());
                        }
                        finally
                        {
                            this.Cursor = System.Windows.Forms.Cursors.Default;
                        }
                    }


                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                #endregion Page2

                #region Page3

                if (pagenumber_DatabaseInstaller == 3)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer = this.Edit_Install_Config_WhereTo.Text;
                    ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer = this.Edit_Install_Config_DataBaseInfo.Text;
                    Form1.Copying = true; //!(DatabaseCopingBehaviourType.SelectedIndex == 3);// this.CheckBox_Install_Config_CopyOptions.Checked;
                    if (showdetails() == 0) this.Install_StartButton_Step1.Enabled = true; else this.Install_StartButton_Step1.Enabled = false;
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    this.Button_Next.Enabled = false;
                }

                #endregion Page3


                this.DataBaseInstaller.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);

                #endregion Database Installer
                return;
            }

            if (GeneralTab.ActiveTab.Index == 1)
            {
                #region Database Creator
                
                pagenumber_DatabaseCreator++;

                #region Page2
                if (pagenumber_DatabaseCreator == 2)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    this.Combo_Make_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer;
                    this.EditBox_Source_Make_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator;
                    this.EditBox_Destination_Make_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator;
                    this.Button_Back.Enabled = true;

                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                        var Info = CodexDatabase.GetSQLServerInfo(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);

                        string s = Info.Edition;
                        //this.SQLInfo.Text = s + " " + Info.ProductVersion;
                    }
                    catch
                    {
                        //this.SQLInfo.Text = "";
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }

                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }


                #endregion Page2

                #region Page3
                if (pagenumber_DatabaseCreator == 3)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator = this.EditBox_Destination_Make_Config_Servers.Text;
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator = this.EditBox_Source_Make_Config_Servers.Text;
                    if (showdetails() == 0) this.Install_StartButton_Step1.Enabled = true; else this.Install_StartButton_Step1.Enabled = false;
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    this.Button_Next.Enabled = false;
                    this.Button_Back.Enabled = true;
                }

                #endregion Page3

                this.DatabaseImageCreator.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);

                #endregion Database Creator
                return;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            pagenumber_DatabaseInstaller = 1;
            pagenumber_DatabaseCreator = 1;
            var _CodexDatabase  = new CodexDatabase(this);

            this.InfoLabel_SqlServer.Text = "";
            this.InfoValueLabel_InstanceName.Text = "";
            this.InfoLabel_SqlVersion.Text = "";
            this.InfoValueLabel_ProductVersion.Text = "";
            this.InfoLabel_FullText.Text = "";
            this.InfoValueLabelFullText.Text = "";
            this.InfoLabel_Collation.Text = "";
            this.InfoValueLabelCollation.Text = "";


            //Infragistics.Win.Office200 7ColorTable.ColorScheme = Infragistics.Win.Office200 7ColorScheme.Black;
            //Infragistics.Win.AppStyling.StyleManager.Load("c:\\1\\Office200 7Blue.isl");
            
            //if (global::ILG.Codex.CodexR4.Properties.Settings.Default.DefaTheme == 0)
            //    switch (Infragistics.Win.Office200 7ColorTable.ColorScheme)
            //    {
            //        case Infragistics.Win.Office200 7ColorScheme.Black: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.CodexR4.Properties.Settings.Default.CurrentDir + "\\Styles\\Office200 7Black.isl"); break;
            //        case Infragistics.Win.Office200 7ColorScheme.Blue: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.CodexR4.Properties.Settings.Default.CurrentDir + "\\Styles\\Office200 7Blue.isl"); break;
            //        case Infragistics.Win.Office200 7ColorScheme.Silver: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.CodexR4.Properties.Settings.Default.CurrentDir + "\\Styles\\Office200 7silver.isl"); break;
            //    }
            //else
           // {
            //    switch (global::ILG.Codex.CodexR4.Properties.Settings.Default.DefaTheme)
            //    {
            //        case 1: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.CodexR4.Properties.Settings.Default.CurrentDir + "\\Styles\\Office200 7Black.isl"); break;
            //        case 2: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.CodexR4.Properties.Settings.Default.CurrentDir + "\\Styles\\Office200 7Blue.isl"); break;
            //        case 3: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.CodexR4.Properties.Settings.Default.CurrentDir + "\\Styles\\Office200 7silver.isl"); break;
            //    }
           // }


   
            var vItem1 = new Infragistics.Win.ValueListItem();
            var vItem2 = new Infragistics.Win.ValueListItem();
            var vItem3 = new Infragistics.Win.ValueListItem();
            var vItem4 = new Infragistics.Win.ValueListItem();

            vItem1.DataValue = "0";
            vItem1.DisplayText = "Codex2007DS";

  


            GeneralTab.Tabs[1].Visible = true;
            GeneralTab.Tabs[1].Enabled = true;
             //GeneralTab.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
       
            CheckForIllegalCrossThreadCalls = false;
            ResumeLayout();

            if (Form1.sp.Visible == true) Form1.sp.Hide();
            //ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer;
            //ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer;



            this.Edit_Install_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer.Trim();
            this.EditBox_Source_Make_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator.Trim();
            this.EditBox_Destination_Make_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator.Trim();


            this.Edit_Install_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer.Trim();
            this.Edit_Install_Config_DataBaseInfo.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer.Trim();
            this.Edit_Install_Config_WhereTo.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer.Trim();
            //this.Edit_Install_Config_DataBaseInfo.Text = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer.Trim();



            SetInstallationMode(Database_Installation_Scenario.SelectedIndex);
            Database_Installation_Scenario.Enabled = false;
            Database_Installation_Scenario.Visible = false;

         

        }

     
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("პროგრამიდან გამოსვლა \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) Close();
        }


        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (GeneralTab.ActiveTab.Index == 0)
            {
                #region Database Installer
                if (DataBaseInstaller.SelectedTab.Index == 0) return;
                if (pagenumber_DatabaseInstaller == 0) return;
                pagenumber_DatabaseInstaller--;
                if (pagenumber_DatabaseInstaller == 3)
                {
                    this.Button_Next.Enabled = false;
                }
                else this.Button_Next.Enabled = true;


                this.DataBaseInstaller.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectPreviousTab);

                #endregion Database Installer
            }

            if (GeneralTab.ActiveTab.Index == 1)
            {
                #region Database Creator

                if (DatabaseImageCreator.SelectedTab.Index == 0) return;

                if (pagenumber_DatabaseCreator == 0) return;
                pagenumber_DatabaseCreator--;


                if (pagenumber_DatabaseCreator == 2)
                {

                    this.Button_Next.Enabled = true;
                    this.Button_Back.Enabled = true;
                }

                if (pagenumber_DatabaseCreator == 1)
                {
                    this.Button_Next.Enabled = true;
                    this.Button_Back.Enabled = false;
                }

                DatabaseImageCreator.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectPreviousTab);

                #endregion Database Creator
            }
        }



        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "About":    // ButtonTool
                    About f = new About(); f.ShowDialog();
                    break;

                case "Manual":    // ButtonTool
                    try { System.Diagnostics.Process.Start(@"file" + @":\\" + global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer + "\\Help\\CodexUpdate.XPS"); }
                    catch (Exception x) { ILG.Windows.Forms.ILGMessageBox.ShowE("დახმარების ფაილი არ მოიძებნა", x.Message.ToString()); }
                    break;

                case "FeedBack":    // ButtonTool
                    try { System.Diagnostics.Process.Start("mailto:support@codex.ge"); }
                    catch (Exception x)  { ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება წერილის გაგზავნა", x.Message.ToString()); }
                    break;

                case "Web":    // ButtonTool
                    try { System.Diagnostics.Process.Start("http://www.codex.ge"); }
                    catch (Exception x) { ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ვებ გვერდის გახსნა", x.Message.ToString()); }
                    break;

                case "Config":    // ButtonTool
                    //Configuration fc = new Configuration(); fc.ShowDialog(); 
                    break;

                case "TechManual":    // ButtonTool
                    try { System.Diagnostics.Process.Start(@"file" + @":\\" + global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer + "\\Help\\CodexTH.XPS"); }
                    catch (Exception x) { ILG.Windows.Forms.ILGMessageBox.ShowE("დახმარების ფაილი არ მოიძებნა", x.Message.ToString()); }
                    break;

                case "Exit":    // ButtonTool
                    if (ILG.Windows.Forms.ILGMessageBox.Show("პროგრამიდან გამოსვლა \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) Close();
                    break;

                case "InstallCopy":    // ButtonTool
                    CopyListBoxItemsToClipboard(Install_listBox_Step1);
                    break;

                case "Install_CopyAll":    // ButtonTool
                    CopyAllListBoxItemsToClipboard(Install_listBox_Step1);
                    break;

                case "Install_Clear":    // ButtonTool
                     ClearListBoxItems(Install_listBox_Step1);                    // Place code here
                    break;

      
                case "DropCodexUsers":
                    {
                        if (ILGMessageBox.Show(" Codex User (Old Users) წაშლა. დარწმუნებული ხართ ?", "",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            _DropCodexUsers();
                        }
                    }
          
                    break;

                case "DropCodexXUsers":
                    if (Windows.Forms.ILGMessageBox.Show("Codex X User (With Strong Password) წაშლა. დარწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        _DropCodexXUsers();
                    }
                    break;

                case "DropFullTextIndexes":    
                    // ButtonTool

                                               // Place code here

                    break;





            }

        }

  
        private void ultraButton7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
           // fd.RootFolder = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                String Result = fd.SelectedPath.ToString();
                if (Result.EndsWith("\\") == false) Result += "\\";
                this.Edit_Install_Config_WhereTo.Text = Result;// System.IO.Path.GetDirectoryName(Result); // ZXZ
                ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer = this.Edit_Install_Config_WhereTo.Text;
            }
        }

        private void ultraButton8_Click(object sender, EventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = "c:\\";
            fd.Filter = "Codex DS 1.6 Database Info File (*.CodexDatabaseInfo)|*.CodexDatabaseInfo";
            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            
            fd.Title = "Open Codex DS 1.6 Databse Info File";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.Edit_Install_Config_DataBaseInfo.Text = fd.FileName;
                ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer = this.Edit_Install_Config_DataBaseInfo.Text;
            }
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {

            ProcessDelegate proc = new ProcessDelegate(DatabaseInstaller_Process);
            proc.BeginInvoke(null, null);
            //this.Process();
            return;
        }
        
        

        private String FinalInfo(int InstallationType, ref String ErrorString)
        {
        

            String ResultReport = "Codex DS Database Installation Report " + System.Environment.NewLine;
          
            #region Info1
            var srv = new SqlConnection(Properties.Settings.Default.ConnectionString_master);
            try
            {
                srv.Open();// ConnectionContext.ConnectTimeout = 30;
            }
            catch (System.Exception ex)
            {
                ResultReport += "SERVER CONNECTION ERROR : SQL Server [" + global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer + "] EXECPTION >> " + ex.Message.ToString() + System.Environment.NewLine;
                ErrorString = ex.ToString();
             }
            finally
            {
                srv.Close();
            }

            if (ErrorString.ToString().Trim() != "") return "";


            ResultReport += "SQL SERVER : [" + global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer + "] " + System.Environment.NewLine;
            ResultReport += "Windows OS : [" + System.Environment.OSVersion.ToString() + "]" + System.Environment.NewLine;

            if (InstallationType != 0)
            {
                if (CodexDatabase.IsFullTextEnabled("CodexR4") == "1")
                {
                    ResultReport += "Full Text Serach Installed : TRUE" + System.Environment.NewLine;
                }
                else
                {
                    ResultReport += "Full Text Serach Installed : FALSE" + System.Environment.NewLine;
                }
            }
            #endregion Info1

            #region Info 1 (Check If Offline)
            var Databases1 = new List<string>() { "Codex2007DS".ToUpper() };

            foreach (var Catalog in Databases1)
            {
                if (CodexDatabase.IsOnline(Catalog.ToString().ToUpper(), ref ErrorString) == false)
                {
                    ResultReport += "DATABASE [:" + Catalog.ToString().ToUpper() + "] :  Is Offline " + System.Environment.NewLine;
                }
                else
                {
                    ResultReport += "DATABASE [" + Catalog.ToString().ToUpper() + "] : Is Online " + System.Environment.NewLine;
                }

                if (ErrorString.Trim() != "")
                {
                    ResultReport += "ErrorString : " + ErrorString + System.Environment.NewLine;
                    return ErrorString;
                }

            }

            #endregion Info 1 (Check If Offline)


            #region Info2


            var Databases = new List<string>() { "Codex2007DS".ToUpper() };

            foreach (var Catalog in Databases)
            {
                if (CodexDatabase.IsRegistred(Catalog.ToString().ToUpper(), ref ErrorString) == true)
                {
                    ResultReport += "DATABASE [:" + Catalog.ToString().ToUpper() + "] : Installed and registered " + System.Environment.NewLine;
                    if (CodexDatabase.IsOnline(Catalog.ToString().ToUpper(), ref ErrorString) == true)
                    {
                        ResultReport += "DATABASE [" + Catalog.ToString().ToUpper() + "] Path : " + CodexDatabase.GetDatabasePrimaryPath(Catalog.ToString().ToUpper()) + System.Environment.NewLine;
                    }
                }
                else
                {
                    ResultReport += "DATABASE [" + Catalog.ToString().ToUpper() + "] : NOT INSTALLED !!! " + System.Environment.NewLine;
                }

                if (ErrorString.Trim() != "")
                {
                    ResultReport += "ErrorString : " + ErrorString + System.Environment.NewLine;
                }

            }

            #endregion Info2

            #region Info3

            if (InstallationType != 0)
            {
                ResultReport += CodexDatabase.GetDatabaseUsersStatus(ref ErrorString, CheckBox_CodexDSUsers.Checked, CheckBox_CodexDSXUsers.Checked);
            }

            #endregion Info3

    
            return ResultReport;

        }

 


        private void Install_Config_Connect(bool WithMessages)
        {
            if (Edit_Install_Config_Servers.Text.Trim() == "") { ILG.Windows.Forms.ILGMessageBox.Show("მიუთითეთ SQL სერვერის სახელი"); return; }
            if ((Edit_Install_Config_Servers.Text.Trim().Contains(",") == true) || (Edit_Install_Config_Servers.Text.Trim().Contains(";") == true) ||
                (Edit_Install_Config_Servers.Text.Trim().Contains(":") == true) || (Edit_Install_Config_Servers.Text.Trim().Contains("'") == true) ||
                (Edit_Install_Config_Servers.Text.Trim().Contains("@") == true) || (Edit_Install_Config_Servers.Text.Trim().Contains("@") == true) ||
                (Edit_Install_Config_Servers.Text.Trim().Contains("&") == true)) { ILG.Windows.Forms.ILGMessageBox.Show("მიუთითეთ SQL სერვერის სახელი შეიცავს დაუშვებელ სიმბოლოებს"); return; }

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            #region generate new Connecgion String


            string servername = Edit_Install_Config_Servers.Text.Trim();

            string str_CodexR4_master = "workstation id=" + System.Environment.MachineName +
                 ";packet size=4096;integrated security=SSPI;data source="
                 + servername + ";persist security info=False;initial catalog=master;Connection Timeout=30";

            if (servername.ToUpper() == @"(LocalDB)\MSSQLLocalDB".ToUpper())
            {
                str_CodexR4_master = @"Data Source=(LocalDB)\MSSQLLocalDB; initial catalog=master;Integrated Security=True;Connection Timeout=30";
            }

            ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master = str_CodexR4_master;
            #endregion generate new Connecgion String
            SqlConnection test = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);// "Server=" + Combo_Install_Config_Servers.Text.Trim() + ";Integrated security=SSPI;database=master");

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
                ILG.Windows.Forms.ILGMessageBox.ShowE("კავშირი არ მყარდება: \n", ex.ToString());
                SQLConnected = false;
            }
            finally
            {
                if (test.State == ConnectionState.Open)
                {
                    test.Close();
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
            if (SQLConnected == true)
            {
                ReConfiguration2(Edit_Install_Config_Servers.Text, isCreatorMode: false);
                FillForm();
                if (WithMessages == true) ILG.Windows.Forms.ILGMessageBox.Show("კავშირი წარმატებულად დამყარდა");
                global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer = this.Edit_Install_Config_Servers.Text.Trim();
                this.Edit_Install_Config_WhereTo.Text = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer;  // textBox1.Text = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom;
            }

        }


        private void Create_Config_Connect(bool WithMessages)
        {
            if (Combo_Make_Config_Servers.Text.Trim() == "") { ILG.Windows.Forms.ILGMessageBox.Show("მიუთითეთ SQL სერვერის სახელი"); return; }
            if ((Combo_Make_Config_Servers.Text.Trim().Contains(",") == true) || (Combo_Make_Config_Servers.Text.Trim().Contains(";") == true) ||
                (Combo_Make_Config_Servers.Text.Trim().Contains(":") == true) || (Combo_Make_Config_Servers.Text.Trim().Contains("'") == true) ||
                (Combo_Make_Config_Servers.Text.Trim().Contains("@") == true) || (Combo_Make_Config_Servers.Text.Trim().Contains("@") == true) ||
                (Combo_Make_Config_Servers.Text.Trim().Contains("&") == true)) { ILG.Windows.Forms.ILGMessageBox.Show("მიუთითეთ SQL სერვერის სახელი შეიცავს დაუშვებელ სიმბოლოებს"); return; }

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            #region generate new Connecgion String


            string servername = Combo_Make_Config_Servers.Text.Trim();

            string str_CodexR4_master = "workstation id=" + System.Environment.MachineName +
                 ";packet size=4096;integrated security=SSPI;data source="
                 + servername + ";persist security info=False;initial catalog=master;Connection Timeout=30";

            if (servername.ToUpper() == @"(LocalDB)\MSSQLLocalDB".ToUpper())
            {
                str_CodexR4_master = @"Data Source=(LocalDB)\MSSQLLocalDB; initial catalog=master;Integrated Security=True;Connection Timeout=30";
            }

            ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master = str_CodexR4_master;
            #endregion generate new Connecgion String
            SqlConnection test = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);// "Server=" + Combo_Install_Config_Servers.Text.Trim() + ";Integrated security=SSPI;database=master");

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
                ILG.Windows.Forms.ILGMessageBox.ShowE("კავშირი არ მყარდება: \n", ex.ToString());
                SQLConnected = false;
            }
            finally
            {
                if (test.State == ConnectionState.Open)
                {
                    test.Close();
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
            if (SQLConnected == true)
            {
                ReConfiguration2(Combo_Make_Config_Servers.Text, isCreatorMode: true);
                FillForm();
                FillForm2();
                if (WithMessages == true) ILG.Windows.Forms.ILGMessageBox.Show("კავშირი წარმატებულად დამყარდა");
                global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer = this.Edit_Install_Config_Servers.Text.Trim();

            }

        }

        private void Button_Install_Config_Connect_Click(object sender, EventArgs e)
        {
            Install_Config_Connect(WithMessages : true);
        }

        private void FillForm()
        {
            this.Edit_Install_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer;
            this.Edit_Install_Config_DataBaseInfo.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer;
            this.Edit_Install_Config_WhereTo.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer;
        }

        private void FillForm2()
        {
            this.Combo_Make_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer;
            this.EditBox_Source_Make_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator;
            this.EditBox_Destination_Make_Config_Servers.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator;
        }

        public void ReConfiguration2(string SQLServerName, bool isCreatorMode )
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                // Readig Information About SQL Server 2005/2008/R2/2012/2012R2/2014 Inctances

                var srv = CodexDatabase.GetSQLServerInfo(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);
                string s = srv.Edition;
              
           
                if (isCreatorMode == true)
                {
                    String StringResult = System.IO.Path.GetDirectoryName(CodexDatabase.GetDatabasePrimaryPath("master"));
                    if (StringResult.EndsWith("\\") == false) StringResult += "\\";

                    global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator = "";
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator = StringResult;
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator = StringResult;

                }
                else
                {
                    String StringResult = System.IO.Path.GetDirectoryName(CodexDatabase.GetDatabasePrimaryPath("master"));
                    if (StringResult.EndsWith("\\") == false) StringResult += "\\";

                    
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer = StringResult;
             
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer = StringResult;

                    //ZXZ3 global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer = "";

                }

                global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer = SQLServerName;
                //this.SQLInfo.Text = s + " " + srv.ProductVersion + " Collcation " + srv.Collation;
                this.InfoLabel_SqlServer.Text = "SQL Server";
                this.InfoValueLabel_InstanceName.Text = s;
                this.InfoLabel_SqlVersion.Text = "Version";
                this.InfoValueLabel_ProductVersion.Text = srv.ProductVersion;
                this.InfoLabel_FullText.Text = "FullText";
                if (srv.IsFullTextInstalled.Trim() == "1") this.InfoValueLabelFullText.Text = "Installed"; else this.InfoValueLabelFullText.Text = "Not Installed";
                this.InfoLabel_Collation.Text = "Collcation";
                this.InfoValueLabelCollation.Text = srv.Collation;

                if (s.ToUpper() == @"(LocalDB)\MSSQLLocalDB".ToUpper())
                {
                    this.InfoLabel_SqlServer.Text = "SQL Server";
                    this.InfoValueLabel_InstanceName.Text = @"(LocalDB)\MSSQLLocalDB";
                    this.InfoLabel_SqlVersion.Text = "";
                    this.InfoValueLabel_ProductVersion.Text = "";
                    this.InfoLabel_FullText.Text = "";
                    InfoValueLabelFullText.Text = "";
                    this.InfoLabel_Collation.Text = "Collcation";
                    this.InfoValueLabelCollation.Text = srv.Collation;

                }




            }
            catch (Exception x)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.InfoLabel_SqlServer.Text = "";
                this.InfoValueLabel_InstanceName.Text = "";
                this.InfoLabel_SqlVersion.Text = "";
                this.InfoValueLabel_ProductVersion.Text = ""; 
                this.InfoLabel_FullText.Text = "";
                this.InfoValueLabelFullText.Text = "";
                this.InfoLabel_Collation.Text = "";
                this.InfoValueLabelCollation.Text = "";
                //this.SQLInfo.Text = "";
                
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დირექტორიის მოძებნა",x.Message.ToString());
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }


        }
        
        
        private void ultraButton20_Click(object sender, EventArgs e)
        {
            // Save Settings
            if (ILGMessageBox.Show("ინფორმაციის ჩაწერა კონფიგურაციის ფაილში ?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            try
            {
                Properties.Settings.Default.SQLServer = this.Edit_Install_Config_Servers.Text.Trim();
                Properties.Settings.Default.CodexDatabaseFrom_Installer = this.Edit_Install_Config_DataBaseInfo.Text.Trim();
                Properties.Settings.Default.CodexDatabaseTo_Installer = this.Edit_Install_Config_WhereTo.Text.Trim();
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის ჩაწერა კონფიგურაციის ფაილში", ex.Message.ToString());
                return;
            }

            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაციის ჩაწერილია");
        }

        private void ultraButton19_Click(object sender, EventArgs e)
        {
            About f = new About(); f.ShowDialog();
        }

        
        // =====================================================================================================
        // Database Creator
        // =====================================================================================================
        
 
        private void ultraButton11_Click(object sender, EventArgs e)
        {
            Create_Config_Connect(false);
        }

        private void ultraButton3_Click_1(object sender, EventArgs e)
        {
            // Save Settings
            if (ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაციის ჩაწერა კონფიგურაციის ფაილში ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            try
            {
                global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer = this.Edit_Install_Config_Servers.Text.Trim();
                global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator = this.EditBox_Source_Make_Config_Servers.Text.Trim();
                global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator = this.EditBox_Destination_Make_Config_Servers.Text.Trim();

                global::ILG.Codex.CodexR4.Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის ჩაწერა კონფიგურაციის ფაილში", ex.Message.ToString());
                return;
            }

            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაციის ჩაწერილია");
        }

        private void ultraButton9_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory =  "c:\\";
            fd.Filter = "Codex DS Database Info File (*.CodexDatabaseInfo)|*.CodexDatabaseInfo";
            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            fd.Title = "Open Codex DS Databse Info File";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.EditBox_Source_Make_Config_Servers.Text = System.IO.Path.GetDirectoryName(fd.FileName);
                ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator = EditBox_Source_Make_Config_Servers.Text;
            }
        }

        private void ultraButton2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            this.EditBox_Destination_Make_Config_Servers.Text = fd.SelectedPath.ToString();
            ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator = this.EditBox_Destination_Make_Config_Servers.Text;
        }

        private void ultraButton_Process_Click(object sender, EventArgs e)
        {
            
            ProcessDelegate proc = new ProcessDelegate( MakeProcess);
            proc.BeginInvoke(null, null);
            //this.Process();
            return;
        }

        private void ultraButton4_Click_1(object sender, EventArgs e)
        {
            GeneralTab.SelectedTab = GeneralTab.Tabs[1];
            GeneralTab.ActiveTab = GeneralTab.Tabs[1];

            DatabaseImageCreator.SelectedTab = DatabaseImageCreator.Tabs[2];
            DatabaseImageCreator.ActiveTab = DatabaseImageCreator.Tabs[2];
            return;
        }

        public void DatabaseCreation_Process_Workflow()
        {
            ShowProgress_MakeDatabase(0, "მონაცემთა ბაზის საინტალაციოს კოპირების პროცესი", Color.Black);
            ShowProgress_MakeDatabase(0, "-----------------------------------------------------", Color.Black);

            CodexDatabase s = new CodexDatabase(this);

            //////if (s.GetInfoFrom() != 0)
            //////{
            //////    ShowProgress_MakeDatabase(0, "Stoped With Error G1" , Color.Red);
            //////    return;
            //////}

            // LocalDB Scenraio
            //if (Combo_Make_Config_Servers.Text.ToUpper() == @"(LocalDB)\MSSQLLocalDB".ToUpper())
            //{
            //    if (s.ProcessFiles_FromDatabase() != 0)
            //    {
            //        ShowProgress_MakeDatabase(0, "Stoped With Error LD1", Color.Red);
            //        return;  // CopyFiles
            //    }
            //    ShowProgress_MakeDatabase(0, "--------------------------------------------------------------", Color.Green);
            //    ShowProgress_MakeDatabase(0, "მონაცემთა ბაზის კოპირება  დასრულებულია", Color.Green);

            //}
            //else
            {
                if (s.TakeOfflineDatabase(true, ShowProgress_MakeDatabase) != 0)
                {
                    ShowProgress_MakeDatabase(0, "Stoped With Error SM1", Color.Red);
                    return;
                }
                if (s.ProcessFiles_FromDatabase() != 0)
                {
                    ShowProgress_MakeDatabase(0, "Stoped With Error FM1", Color.Red);
                    return;
                }
                if (s.TakeOnlineDatabase(ShowProgress_MakeDatabase) != 0)
                {
                    ShowProgress_MakeDatabase(0, "Stoped With Error OM1", Color.Red);
                    return;
                };
                ShowProgress_MakeDatabase(0, "მონაცემთა ბაზის კოპირება  დასრულებულია", Color.Green);
            }




        }

        public void MakeProcess()
        {

            Button_Back.Enabled = false;
            Button_Next.Enabled = false;
            Button_Close.Enabled = false;
            Button_Make_Step1.Enabled = false;


            DatabaseCreation_Process_Workflow();

            Button_Back.Enabled = true;
            Button_Next.Enabled = false;
            Button_Close.Enabled = true;
            Button_Make_Step1.Enabled = true;
          

        }
        
        private void GeneralTab_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            UpdateCurrent_State_WhenGenral_TabChanged();
        }

    
          
        private void ultraPictureBox1_Click_1(object sender, EventArgs e)
        {
            String DBPath = Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer + "\\");

            String SQL =

                 "IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Codex2007DS') " + System.Environment.NewLine +
                 "BEGIN" + System.Environment.NewLine +
                 "EXEC sp_attach_db @dbname = N'Codex2007DS', " + System.Environment.NewLine +
                 "@filename1 = N'" + DBPath + "Codex2007DS_data.mdf'," + System.Environment.NewLine +
                 "@filename2 = N'" + DBPath + "Codex2007DS_blobs_data.ndf'," + System.Environment.NewLine +
                 "@filename3 = N'" + DBPath + "Codex2007DS_log.ldf' ;" + System.Environment.NewLine +
                 "END" + System.Environment.NewLine +

                 System.Environment.NewLine +

                 "GO" + System.Environment.NewLine;

            System.Windows.Forms.Clipboard.SetText(SQL);

        }
        
       

        private void linkLabel2_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Configuration f = new Configuration();
            f.ShowDialog();
        }


        //bool InstallMode_LocalDBMode = false;
 
        bool InstallMode_DatabaseCodexUsers = false;
        bool InstallMode_DatabaseCodexXUsers = false;
        bool InstallMode_FullText = false;
        bool InstallMode_CopyFiles = false;
        
       private void SetInstallationMode(int i)
        {
        
                //InstallMode_LocalDBMode = false;
                InstallMode_DatabaseCodexUsers = true;
                InstallMode_DatabaseCodexXUsers = true;
                InstallMode_FullText = true;

                // GUI
               
                CheckBox_CodexDSUsers.Checked = true;
                CheckBox_CodexDSUsers.Enabled = true;
                CheckBox_CodexDSXUsers.Checked = true;
                CheckBox_CodexDSXUsers.Enabled = true;


                Link_SpecificActions.Enabled = true;
                Link_SpecificActions.Visible = true;

                FullTextSearch.Checked = true;
                FullTextSearch.Enabled = true;

                Installlation_Scenarious_Label.Visible = false;

                Database_Installation_Scenario.Visible = false;
                Database_Installation_Scenario.Enabled = false;

                Button_Install_Config_Save.Visible = true;
                Button_Install_Config_Save.Enabled = true;

                linkLabel2.Visible = true;
                linkLabel2.Enabled = true;


        
        
            return;
        }

        private void Database_Installation_Scenario_SelectionChanged(object sender, EventArgs e)
        {
            SetInstallationMode(Database_Installation_Scenario.SelectedIndex);
        }

        private void FullTextSearch_CheckedChanged(object sender, EventArgs e)
        {
            InstallMode_FullText = FullTextSearch.Checked;
        }



        private void CodexUsers_CheckedChanged(object sender, EventArgs e)
        {
            InstallMode_DatabaseCodexUsers = (CheckBox_CodexDSUsers.Checked == true);
            InstallMode_DatabaseCodexXUsers = (CheckBox_CodexDSXUsers.Checked == true);
        }

        
        // Codex Database Result
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Generate Status of Database
            String Err = "";
        
            String Result = ""; 
            if (Err.Trim() == "")
            {
                ShowProgress_DatabaseInstaller(0, "კოდექსის მონაცემთა ბაზა", Color.Blue);
                ShowProgress_DatabaseInstaller(0, Result, Color.Blue);
            }
            else
            {
                ShowProgress_DatabaseInstaller(0, Result + System.Environment.NewLine + Err, Color.Red);

            }

        }
        


        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Generate Status of Database
            String Err = "";

            String Result = "";
          Result = FinalInfo(0, ref Err);

            ShowProgress_MakeDatabase(0, "კოდექსის მონაცემთა ბაზა", Color.Blue);
            ShowProgress_MakeDatabase(0, Result, Color.Blue);

        }
        

        private void CopyListBoxItemsToClipboard(ListBox Par)
        {
                int index = Par.SelectedIndex;
                String str = Par.Items[index].ToString();
                System.Windows.Forms.Clipboard.SetText(str);
        }

        private void CopyAllListBoxItemsToClipboard(ListBox Par)
        {
          
            String resultString = "";
            foreach (var a in Par.Items)
            {
                resultString += a.ToString() + System.Environment.NewLine;
            }
            System.Windows.Forms.Clipboard.SetText(resultString);
        }

        private void ClearListBoxItems(ListBox Par)
        {
            Par.Items.Clear();
        }

        private void tableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Configuration f = new Configuration();
            f.ShowDialog();
        }

        private void CheckBox_CodexXUsers_CheckedChanged(object sender, EventArgs e)
        {
            InstallMode_DatabaseCodexXUsers = CheckBox_CodexDSXUsers.Checked;
        }

        private void Link_SpecificActions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
