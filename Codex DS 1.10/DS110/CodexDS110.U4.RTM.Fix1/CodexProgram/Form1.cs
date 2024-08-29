using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using ILG.Codex2007.Favorites;
using ILG.Codex.CodexDSListBox;
using ILG.DS.Strings;
using ILG.Windows.Forms;
using System.IO;
using ILG.Codex.CodexR4.CodexSettings;
using System.Reflection;
using DS.Configurations;
using ILG.Codex.DS;
using ILG.DS.Zip;
using ILG.DS.AppStateManagement;
using System.Drawing;
using ILG.Codex.CodexR4.Notifications;
using System.Collections.Generic;
using ILG.DS.Notification.Visited;
using ILG.DS.Notification;

namespace ILG.Codex.CodexR4
{
    public partial class Form1 : Form
    {

        public int Codex_List_ZoomFactor;

        #region Common Values
        public DataSet LockupTables;
        
        public bool ForceExit = false;
        public static SplashScreen sp;
        public DataTable CodexVisited;
        public IDFinder ID_Finder;

        public List<int> _NewDocuments = new List<int>();

        #endregion Common Values

        private bool Policy_ShowHistory = true;
        private int CountForHistoryDocuments = 0;
        private int CountForMainDocuments = 0;

        Form_Codex_Document F_Codex_DOC;
        CodexDocumentList F_Codex_List;
        //private System.IO.MemoryStream codexmemoryStream = null;

        //Boolean IsFirstWindows = true;
        //String Form_Caption = "Codex 2007 DS Alpha 0.2";
        int ICG_NewsN = 2;
        int ICG_News_ComboV = 1;
        DateTime ICG_FromNewsDate = DateTime.Now;

        private String GetTSQLForIfHistoryExists()
        {
            String SQL = " IF OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL " + System.Environment.NewLine +
                         " SELECT 1 AS Result " + System.Environment.NewLine +
                         " ELSE SELECT 0 AS Result";
            
                return SQL;
        }

        private List<int> GetNewDocuments()
        {
            var result = new List<int>();
            using (SqlConnection cn = new SqlConnection(app.state.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = new SqlCommand(DS_GenerateNewDocumentsQuery(),cn))
                {
                    var reader = cm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetInt32(0));
                        }
                    }

                }
            }
            return result;
        }

        private String GetTSQLCountHistory()
        {
            String SQLNoAccess = " SELECT 0 ";
            String SQLFull = " SELECT COUNT(*) FROM CodexDS_DDOCS_History ";
            String SQLPublic = " SELECT COUNT(*) FROM CodexDS_DDOCS_History WHERE ( H_STATUS = 0)";
            String SQLExtended = " SELECT COUNT(*) FROM CodexDS_DDOCS_History WHERE ( H_STATUS = 0) OR ( H_STATUS = 1)";

            if (app.state.RunTimeLicense.IsRecoverDeletedDocumentsGranted() == true) return SQLFull;
            if (app.state.RunTimeLicense.IsHistoryExtendedAccessGranted() == true) return SQLExtended;
            if (app.state.RunTimeLicense.IsHistoryAccessGranted() == true) return SQLPublic;

            return SQLNoAccess;
        }
        private String GetTSQLCountMain()
        {
            String SQL = " SELECT COUNT(*) FROM CodexDS_DDOCS ";
            return SQL;
        }

        public void LoadTables()
        {
            try
            {
                string TableName = "CodexDS2007";
                SqlDataAdapter da = new SqlDataAdapter(
                                       "SELECT * FROM CodexDS_DAUTHOR ORDER By A_Order;" +
                                       "SELECT * FROM CodexDS_DTYPE ORDER By T_Order;" +
                                       "SELECT * FROM CodexDS_DSubject ORDER By S_Order;" +
                                       "SELECT * FROM CodexDS_DWords ORDER By W_Order;" +
                                       "SELECT * FROM CodexDS_DCategory ORDER By C_Order;" + //categ
                                       "SELECT * FROM CodexDS_DStatus ORDER By C_Order;"+    // sta
                                       "SELECT * FROM " + TableName + " ",	 // Need to Change in Codex 2007
                                       app.state.ConnectionString);
                LockupTables = new DataSet();
                DataTableMapping dtm3, dtm4, dtm5, dtm6, dtm9,dtm7,dtm8;
                dtm3 = da.TableMappings.Add("Table",  "CodexDS_DAUTHOR");
                dtm4 = da.TableMappings.Add("Table1", "CodexDS_DTYPE");
                dtm5 = da.TableMappings.Add("Table2", "CodexDS_DSubject");
                dtm6 = da.TableMappings.Add("Table3", "CodexDS_DWords");
                dtm7 = da.TableMappings.Add("Table4", "CodexDS_DCategory");
                dtm8 = da.TableMappings.Add("Table5", "CodexDS_DStatus");
                dtm9 = da.TableMappings.Add("Table6", "CodexDS2007");
                da.Fill(this.LockupTables);
                // Visited

                // Visited For Codex
                CodexVisited = new DataTable("VisitedTable");
                DataColumn dcdvs = new DataColumn("Visited");
                dcdvs.ReadOnly = false;
                dcdvs.DataType = System.Type.GetType("System.Int32");
                dcdvs.AutoIncrement = false;
                CodexVisited.Columns.Add(dcdvs);
                CodexVisited.PrimaryKey = new DataColumn[] { CodexVisited.Columns["Visited"] };

                try
                {
                    using (var cn = new SqlConnection(app.state.ConnectionString))
                    {
                        cn.Open();
                        SqlCommand cm = new SqlCommand(GetTSQLForIfHistoryExists(), cn);
                        int result = (int)cm.ExecuteScalar();
                        if (result == 1)
                        {
                            SqlCommand cm2 = new SqlCommand(GetTSQLCountHistory(), cn);
                            CountForHistoryDocuments = (int)cm2.ExecuteScalar();
                        }
                    }
                }
                catch
                {
                    CountForHistoryDocuments = 0;
                }

                using (var cn = new SqlConnection(app.state.ConnectionString))
                {
                    cn.Open();
                    SqlCommand cm2 = new SqlCommand(GetTSQLCountMain(), cn);
                    CountForMainDocuments = (int)cm2.ExecuteScalar();
                }
         
            }
            catch (Exception ex)
            {
                ILGMessageBox.ShowE("ბაზიდან ინფორმაციის წაკითხვა ვერ ხერხდება", ex.Message.ToString());
            }
        }

        #region Removed LoadDcoksSettings/SaveDcoksSettings
        //private void LoadDcoksSettings()
        //{
        //    #region Codex
        //        if (ILG.Codex.CodexR4.Properties.Settings.Default.DockDS == 1)
        //        {
        //            try
        //            {
        //                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        //                string fn = ILG.Codex.CodexR4.Properties.Settings.Default.DockSettingsPath + "\\Docks_CodexDS.bin";
        //                this.F_Codex_DOC.ultraDockManager1.LoadFromBinary(fn);
        //            }
        //            catch (Exception e)
        //            {
        //                this.Cursor = System.Windows.Forms.Cursors.Default;
        //                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება მიმდინარე პარამეტრების წაკითხვა", e.ToString());
        //            }
        //            finally
        //            {
        //                this.Cursor = System.Windows.Forms.Cursors.Default;
        //            }
        //        }
        //    #endregion Codex

        //}
        //private void SaveDcoksSettings()
        //{
        //    #region Codex
            
        //        if (ILG.Codex.CodexR4.Properties.Settings.Default.DockDS == 1)
        //        {
        //            try
        //            {
        //                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        //                string fn = ILG.Codex.CodexR4.Properties.Settings.Default.DockSettingsPath + "\\Docks_CodexDS.bin";
        //                if (System.IO.File.Exists(fn) == true) System.IO.File.Delete(fn);
        //                this.F_Codex_DOC.ultraDockManager1.SaveAsBinary(fn);
        //            }
        //            catch (Exception e)
        //            {
        //                this.Cursor = System.Windows.Forms.Cursors.Default;
        //                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება მიმდინარე პარამეტრების შენახვა", e.ToString());
        //            }
        //            finally
        //            {
        //                this.Cursor = System.Windows.Forms.Cursors.Default;
        //            }
        //        }
            
        //    #endregion Codex

            

            
        //}

        #endregion LoadDcoksSettings/SaveDcoksSettings
        public void SetLanguageLabel(int index)
        {
            switch (index)
            {

                case 1: CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "GEORGIAN(LAT)"; break;
                case 2: CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "GEORGIAN(RUS)"; break;
                case 3: CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "RUSSIAN(RUS)"; break;
                case 0: CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "ENGLISH"; break;

                default:
                    CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "Windows Keyboard";
                    break;
            }
        }

        public void SetLanguageLayout(int index)
        {
            switch (index)
            {

                case 1: KeyBoard.Layout.SetGeorgianLat(); break;
                case 2: KeyBoard.Layout.SetGeorgianRus();  break;
                case 3: KeyBoard.Layout.SetGeorgianRus(); break;
                case 0: KeyBoard.Layout.SetEnglish();break;

                default:
                    KeyBoard.Layout.SetOff(); break;
                    
            }
        }

        public Form1(bool FExit)
        {
            InitializeComponent();

            // Display Attribute Names

            //Codex_Autor_Label.Text = CodexDSOrganizationSettings.Instance.Settings.DisplayModel.authorAttributeSettings.DisplayName;


            app.state.Current_Keyboard_Layout = 0;

            SetLanguageLayout(app.state.Current_Keyboard_Layout);
            SetLanguageLabel(app.state.Current_Keyboard_Layout);

       
            DefaultSearchParameters();
            LoadTables();
            CheckIfNewDocuments();
            this.NotificationChecker.Start();

            UltraTree_DropHightLight_DrawFilter.Invalidate += new EventHandler(this.UltraTree_DropHightLight_DrawFilter_Invalidate);
            UltraTree_DropHightLight_DrawFilter.QueryStateAllowedForNode += new UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventHandler(this.UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode);
            LoadTree();
            NavigationInistialize();
            DisplayParameters();
            Profile_Label.Text = app.state.DS_Porfile_DisplayName;
            F_Codex_DOC = new Form_Codex_Document(this);
            //F_Codex_DOC.MainForm = this;

            F_Codex_List = new CodexDocumentList(this);
            
            this.formContainer3.ShowForm(F_Codex_DOC);
            this.formContainer_documentlist.ShowForm(F_Codex_List);
            ID_Finder = new IDFinder();
            ID_Finder.MainForm = this;
            ForceExit = FExit;
        }


     
        private void Form1_Load(object sender, EventArgs e)
        {
            SuspendLayout();

            if (app.state.Show_DS_Profile_Info == true)
                Profile_Label.Text = app.state.DS_Porfile_DisplayName;
            else
            { Profile_Label.Visible = false; }



            String s = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.ultraStatusBar1.Panels["BN"].Text = s;

            Infragistics.Win.AppStyling.StyleManager.Office2013ColorScheme = Infragistics.Win.Office2013ColorScheme.White;
            Infragistics.Win.AppStyling.StyleManager.Office2013Theme = Infragistics.Win.Office2013Theme.Excel;


            #region Codex Find Panel
            Codex_Search_Label.Left = 8;
            Codex_Search_Label.Top = 0;
            Codex_Search_Edit.Left = 0;
            Codex_Search_Edit.Top = Codex_Search_Label.Top + Codex_Search_Label.Height + 4;
            Codex_Search_Button.Top = Codex_Search_Edit.Top;
            Codex_Search_Button.Left = Codex_Search_Edit.Left + Codex_Search_Edit.Width + 8;
            Codex_Search_Button.Height = Codex_Search_Edit.Height;

            Codex_Fulltext_Label.Left = 0;
            Codex_Search_Combo.Top = Codex_Search_Edit.Top + Codex_Search_Edit.Height + 8;
            Codex_Search_Combo.Left = Codex_Fulltext_Label.Left + Codex_Fulltext_Label.Width + 8;
            Codex_Fulltext_Label.Top = Codex_Search_Combo.Top + ((Codex_Search_Combo.Height - Codex_Fulltext_Label.Height) / 2);

            int Codex_W = Codex_Search_Combo.Left + Codex_Search_Combo.Width;

            Codex_Number_Label.Left = 0;
            Codex_Number_Edit.Top = Codex_Search_Combo.Top + Codex_Search_Combo.Height + 8;
            //Codex_Number_Edit.Left = Codex_Number_Label.Left + Codex_Number_Label.Width + 12+8+4+  10;
            Codex_Number_Edit.Left = Codex_Comment_Label.Left + Codex_Comment_Label.Width + 8;
            Codex_Number_Label.Top = Codex_Number_Edit.Top + ((Codex_Number_Edit.Height - Codex_Number_Label.Height) / 2);
            Codex_Number_Edit.Width = Codex_W - Codex_Number_Edit.Left;

            Codex_Date_Label.Left = 0;
            Codex_Date_Edit1.Left = Codex_Number_Edit.Left;
            Codex_Date_Edit1.Top = Codex_Number_Edit.Top + Codex_Number_Edit.Height + 8;
            Codex_Date_Edit2.Top = Codex_Date_Edit1.Top;
            // Version 0.1
            //Codex_Date_Edit1.Width = (Codex_Number_Edit.Width - Codex_Date_Button1.Width * 2 - 6) / 2;
            //Codex_Date_Edit2.Width = Codex_Date_Edit1.Width;
            // Version 0.2
            ILG.Codex.CodexR4.PickDate d = new ILG.Codex.CodexR4.PickDate(DateTime.Now);
            Codex_Date_Edit1.Width = d.Width - Codex_Date_Button1.Width;
            Codex_Date_Edit2.Width = Codex_Date_Edit1.Width;
            Codex_Date_Button1.Top = Codex_Date_Edit1.Top;
            Codex_Date_Button2.Top = Codex_Date_Edit1.Top;
            Codex_Date_Button1.Left = Codex_Date_Edit1.Left + Codex_Date_Edit1.Width;
            int Codex_DataSeperator = Codex_Number_Edit.Width - (Codex_Date_Button1.Width * 2 + Codex_Date_Edit1.Width * 2);
            Codex_Date_Edit2.Left = Codex_Date_Button1.Left + Codex_Date_Button1.Width + Codex_DataSeperator;

            Codex_Date_Button2.Left = Codex_Date_Edit2.Left + Codex_Date_Edit2.Width;
            Codex_Date_Label.Top = Codex_Date_Edit1.Top + ((Codex_Date_Edit1.Height - Codex_Date_Label.Height) / 2);

            Codex_Autor_Label.Left = 0;
            Codex_Autor_Edit.Top = Codex_Date_Edit1.Top + Codex_Date_Edit1.Height + 8;
            Codex_Autor_Edit.Left = Codex_Number_Edit.Left;
            Codex_Autor_Label.Top = Codex_Autor_Edit.Top + ((Codex_Autor_Edit.Height - Codex_Autor_Label.Height) / 2);
            Codex_Autor_Button.Top = Codex_Autor_Edit.Top;
            Codex_Autor_Edit.Width = Codex_Number_Edit.Width - Codex_Autor_Button.Width;
            Codex_Autor_Button.Left = Codex_Autor_Edit.Left + Codex_Autor_Edit.Width;


            Codex_Type_Label.Left = 0;
            Codex_Type_Edit.Top = Codex_Autor_Edit.Top + Codex_Autor_Edit.Height + 8;
            Codex_Type_Edit.Left = Codex_Number_Edit.Left;
            Codex_Type_Label.Top = Codex_Type_Edit.Top + ((Codex_Type_Edit.Height - Codex_Type_Label.Height) / 2);
            Codex_Type_Button.Top = Codex_Type_Edit.Top;
            Codex_Type_Edit.Width = Codex_Number_Edit.Width - Codex_Type_Button.Width;
            Codex_Type_Button.Left = Codex_Type_Edit.Left + Codex_Type_Edit.Width;

            Codex_Subject_Label.Left = 0;
            Codex_Subject_Edit.Top = Codex_Type_Edit.Top + Codex_Type_Edit.Height + 8;
            Codex_Subject_Edit.Left = Codex_Number_Edit.Left;
            Codex_Subject_Label.Top = Codex_Subject_Edit.Top + ((Codex_Subject_Edit.Height - Codex_Subject_Label.Height) / 2);
            Codex_Subject_Button.Top = Codex_Subject_Edit.Top;
            Codex_Subject_Edit.Width = Codex_Number_Edit.Width - Codex_Subject_Button.Width;
            Codex_Subject_Button.Left = Codex_Subject_Edit.Left + Codex_Subject_Edit.Width;

            Codex_Word_Label.Left = 0;
            Codex_Word_Edit.Top = Codex_Subject_Edit.Top + Codex_Subject_Edit.Height + 8;
            Codex_Word_Edit.Left = Codex_Number_Edit.Left;
            Codex_Word_Label.Top = Codex_Word_Edit.Top + ((Codex_Word_Edit.Height - Codex_Word_Label.Height) / 2);
            Codex_Word_Button.Top = Codex_Word_Edit.Top;
            Codex_Word_Edit.Width = Codex_Number_Edit.Width - Codex_Word_Button.Width;
            Codex_Word_Button.Left = Codex_Word_Edit.Left + Codex_Word_Edit.Width;

            Codex_Category_L.Left = 0;
            Codex_Category_Edit.Top = Codex_Word_Edit.Top + Codex_Word_Edit.Height + 8;
            Codex_Category_Edit.Left = Codex_Number_Edit.Left;
            Codex_Category_L.Top = Codex_Category_Edit.Top + ((Codex_Category_Edit.Height - Codex_Category_L.Height) / 2);
            Codex_Category_Button.Top = Codex_Category_Edit.Top;
            Codex_Category_Edit.Width = Codex_Number_Edit.Width - Codex_Category_Button.Width;
            Codex_Category_Button.Left = Codex_Category_Edit.Left + Codex_Category_Edit.Width;


            Codex_Status_Label.Left = 0;
            Codex_Status_Edit.Top = Codex_Category_Edit.Top + Codex_Category_Edit.Height + 8;
            Codex_Status_Edit.Left = Codex_Number_Edit.Left;
            Codex_Status_Label.Top = Codex_Status_Edit.Top + ((Codex_Status_Edit.Height - Codex_Status_Label.Height) / 2);
            Codex_Status_Button.Top = Codex_Status_Edit.Top;
            Codex_Status_Edit.Width = Codex_Number_Edit.Width - Codex_Status_Button.Width;
            Codex_Status_Button.Left = Codex_Status_Edit.Left + Codex_Status_Edit.Width;

            Codex_Comment_Label.Left = 0;
            Codex_Comment_Edit.Top = Codex_Status_Edit.Top + Codex_Comment_Edit.Height + 8;
            Codex_Comment_Edit.Left = Codex_Number_Edit.Left;
            Codex_Comment_Label.Top = Codex_Comment_Edit.Top + ((Codex_Comment_Edit.Height - Codex_Comment_Label.Height) / 2);
            Codex_Comment_Edit.Width = Codex_Number_Edit.Width;

            Codex_Attrib_Label.Left = 0;
            Codex_Attrib_Edit.Top = Codex_Comment_Edit.Top + Codex_Attrib_Edit.Height + 8;
            Codex_Attrib_Edit.Left = Codex_Number_Edit.Left;
            Codex_Attrib_Label.Top = Codex_Attrib_Edit.Top + ((Codex_Attrib_Edit.Height - Codex_Comment_Label.Height) / 2);
            Codex_Attrib_Edit.Width = Codex_Number_Edit.Width;

            Codex_Access_Label.Left = 0;
            Codex_AccessCombo.Top = Codex_Attrib_Edit.Top + Codex_Attrib_Edit.Height + 8;
            Codex_AccessCombo.Left = Codex_Number_Edit.Left;
            Codex_Access_Label.Top = Codex_AccessCombo.Top + ((Codex_AccessCombo.Height - Codex_Access_Label.Height) / 2);
            Codex_AccessCombo.Width = Codex_Number_Edit.Width;
            Codex_AccessCombo.SelectedIndex = 0;

            if (app.state.RunTimeLicense.IsConfidentialDocumentShowInList() == false)
            {
                // Hide Access Attribute
                Codex_Access_Label.Enabled = false;
                Codex_Access_Label.Visible = false;
                Codex_AccessCombo.Enabled = false;
                Codex_AccessCombo.Visible = false;
            }


            ICG_Seperator.Top = Codex_AccessCombo.Top + Codex_AccessCombo.Height + 8;

            if (app.state.RunTimeLicense.IsConfidentialDocumentShowInList() == false)
            {
                // Hide Access Attribute
                ICG_Seperator.Top = Codex_Attrib_Edit.Top + Codex_Attrib_Edit.Height + 8;
            }

            //ICG_Seperator.Top = Codex_Attrib_Edit.Top + Codex_Attrib_Edit.Height + 8;
            ICG_Seperator.Left = 0;
            ICG_Seperator.Width = Codex_W;

            ICG_News_label.Left = 0;
            ICG_News_Edit.Top = ICG_Seperator.Top + ICG_Seperator.Height + 8;
            ICG_News_label.Top = ICG_News_Edit.Top + ((ICG_News_Edit.Height - ICG_News_label.Height) / 2);
            ICG_News_Combo.Top = ICG_News_Edit.Top;
            ICG_News_Edit.Left = ICG_News_label.Left + ICG_News_label.Width + 8;
            ICG_News_Combo.Left = ICG_News_Edit.Left + ICG_News_Edit.Width + 8;
            ICG_News_Button.Top = ICG_News_Combo.Top;
            ICG_News_DateCheck.Left = ICG_News_Combo.Left + ICG_News_Combo.Width + 8;
            ICG_News_DateCheck.Top = ICG_News_Edit.Top + ((ICG_News_Edit.Height - ICG_News_DateCheck.Height) / 2);
            News_Date_Edit.Left = ICG_News_DateCheck.Left + ICG_News_DateCheck.Width + 8;
            News_Date_Edit.Top = ICG_News_Edit.Top;
            News_Date_Button.Left = News_Date_Edit.Left + News_Date_Edit.Width;
            News_Date_Button.Top = News_Date_Edit.Top;
            ICG_News_Button.Width = Codex_Search_Button.Width;


            Codex_Search_Button.Width =
            Codex_Search_Combo.Left + Codex_Search_Combo.Width - Codex_Search_Button.Left;
            ICG_News_Button.Width = Codex_Search_Button.Width;


            //ICG_News_Combo.Width = Codex_W - ICG_News_Combo.Left - ICG_News_Button.Width - 8;
            ICG_News_Button.Left = News_Date_Button.Left + News_Date_Button.Width + 8;
            ICG_News_Check.Left = ICG_News_label.Left;
            ICG_News_Check.Top = ICG_News_Edit.Top + ICG_News_Edit.Height + 8;



            ICG_News_Button.Left = Codex_Search_Button.Left;
            ICG_News_Check.Left = ICG_News_Button.Left + ICG_News_Button.Width - ICG_News_Check.Width;
            News_Date_Edit.Enabled = false;
            News_Date_Button.Enabled = false;

            News_Date_Edit.Visible = false;
            News_Date_Button.Visible = false;

            

            #endregion  Codex Find Panel

            #region Firt Tab loading

            //if (def == 0) { MainTabs.SelectedTab = MainTabs.Tabs[1]; CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[0]; }
            // if (def == 1) { MainTabs.SelectedTab = MainTabs.Tabs[0]; CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[1]; }
            // if (def == 2) { MainTabs.SelectedTab = MainTabs.Tabs[0]; CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[0]; }
            LastRibbon = CodexToolBar.Ribbon.SelectedTab.Key;

            if (Form1.sp.Visible == true) Form1.sp.Hide();



            #endregion  Firt Tab loading




            #region Panels
            Codex_Search_Panel.Width = Codex_AccessCombo.Left + Codex_AccessCombo.Width + 24;
            Codex_Search_Panel.Left = (Codex_Search_Panel.Parent.ClientSize.Width - Codex_Search_Panel.Width) / 2;


            #endregion

            this.Left = 0;
            this.Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;


            // Codex Doced Document Part
            //this.codexmemoryStream = new System.IO.MemoryStream();
            //this.F_Codex_DOC.ultraDockManager1.SaveAsBinary(this.codexmemoryStream);

            // Load Docks

            // Set Default Views
            #region Views
            //if ((ILG.Codex.CodexR4.Properties.Settings.Default.ViewDS == 0) || (ILG.Codex.CodexR4.Properties.Settings.Default.ViewDS == 1))
            //{ CodexViewLayout = ILG.Codex.CodexR4.Properties.Settings.Default.ViewDS; }
            CodexViewLayout = 0;
            #endregion Views

            #region Zoom
            if (
                  ((app.state.UISettingsManager.content.ui_defaultzoom >= 10) && (app.state.UISettingsManager.content.ui_defaultzoom <= 400))
                  ||
                  ((app.state.UISettingsManager.content.ui_defaultzoom == -10) || (app.state.UISettingsManager.content.ui_defaultzoom == -20))
                )
            {
                CodexZoomFactor = app.state.UISettingsManager.content.ui_defaultzoom;
            }

            #endregion Zoom

            //LoadDcoksSettings();


            Codex_DefaultSearchParameters();

            CodexToolBar.Tools["DeletedDocuments"].SharedProps.Visible = false;
            CodexToolBar.Tools["DeletedDocuments"].SharedProps.Enabled = false;

            if (app.state.RunTimeLicense.IsSearchinDeletedDocumentsGranted() == true)
            {
                CodexToolBar.Tools["DeletedDocuments"].SharedProps.Visible = true;
                CodexToolBar.Tools["DeletedDocuments"].SharedProps.Enabled = true;
            }
            else
            {
                CodexToolBar.Tools["DeletedDocuments"].SharedProps.Visible = false;
                CodexToolBar.Tools["DeletedDocuments"].SharedProps.Enabled = false;
            }
            
            ResumeLayout();

            
        }

        private void Form1_Fill_Panel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CodexToolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            
            switch (e.Tool.Key)
            {
                case "Test":    // PopupMenuTool
            
                    break;

                case "GeoLat":    // ButtonTool
                    SetLanguageLayout(1);
                    SetLanguageLabel(1);
                    break;

                case "GeoRus":    // ButtonTool
                    SetLanguageLayout(2);//.KeyBoard.Layout.SetGeorgianRus();
                    SetLanguageLabel(2);
                    break;

                case "Rus":    // ButtonTool
                    SetLanguageLayout(3);//CodexR4.KeyBoard.Layout.SetRussian();
                    SetLanguageLabel(3);
                    break;

                case "English":    // ButtonTool
                    SetLanguageLayout(0);// CodexR4.KeyBoard.Layout.SetEnglish();
                    SetLanguageLabel(0);
                    break;

                case "Layout_Windows":    // ButtonTool
                    SetLanguageLayout(-1); // CodexR4.KeyBoard.Layout.SetOff();
                    SetLanguageLabel(-1);
                    break;

                case "Exit":    // ButtonTool
                    Close();
                           break;

                       case "BackButton": DoBack();
                           //if (ActiveProgram == 1) { DoBack(); return; }
                           //CallList(); 
                           break;
                       case "ForwardButton": DoForward(); break;

               case "OptionsSet":    // ButtonTool
                   if (DSBehaviorConfiguration.Instance.content.General.IsOptions == true)
                   {
                       CodexConfiguration f = new CodexConfiguration();
                       f.ShowDialog();
                   }
                   else
                   {
                      ILGMessageBox.Show("თქვენ არ გაქვთ კონფიგურაციასთან დაშვების შესაბამისი უფლება");
                   }
                   break;

               case "DOCAE":
                   {
                       DocumentAddEdit dd = new DocumentAddEdit();
                       dd.FormMain = this;
                       dd.Show();
                       dd.NewDocumentMode();
                       LoadTables();
                       DisplayParametersLimited();
                   }
                   break;

               case "ChangeDocument":
                   if (CodexDocumentID == -1) return;
                   if (app.state.RunTimeLicense.IsDocumentEditAllow() == false)
                   {
                       ILG.Windows.Forms.ILGMessageBox.Show("თქვენ არ გაქვთ დოკუმენტის ცვლილების უფლება");
                       return;
                   }
                   DocumentAddEdit dd2 = new DocumentAddEdit();
                   dd2.FormMain = this;
                   dd2.Show();
                   //dd2.NewDocumentMode();


                   if (dd2.EditDocumentMode(CodexDocumentID) != 0)
                       dd2.Close();
                   else
                   {
                       LoadTables();
                       DisplayParametersLimited();
                   }
                   
                   break;

               case "DeleteDocument": DODELDocument(); break;
                    

               case "ResetCommon":    // ButtonTool
                    Codex_DefaultSearchParameters();
                   break;

               case "TopNavigationLeft":    // ButtonTool
                        { MainTabs.SelectedTab = MainTabs.Tabs[0]; return; }
         
         

               case "TopNavigationRight":    // ButtonTool
                      { MainTabs.SelectedTab = MainTabs.Tabs[1]; return; }
         

               //TopNavigationLeft
                #region Codex
                
                #region Find
                case "Codex_Date_LastOneMonth":    // ButtonTool
                    Codex_Do_DataRanges(0);
                    break;

                case "Codex_Date_LastTwoMonth":    // ButtonTool
                    Codex_Do_DataRanges(1);
                    break;

                case "Codex_Date_LastYear":    // ButtonTool
                    Codex_Do_DataRanges(2);
                    break;

                case "Codex_Date_LastTwoYear":    // ButtonTool
                    Codex_Do_DataRanges(3);
                    break;

                case "Codex_Date_1995Today":    // ButtonTool
                    Codex_Do_DataRanges(4);
                    break;

                case "Codex_Date_Equal":    // ButtonTool
                    Codex_Do_DateEqual();
                    break;

                case "Codex_Date_Full":    // ButtonTool
                    Codex_Do_DataRanges(5);
                    break;

                case "Find_Codex_Reset":    // ButtonTool
                    Codex_DefaultSearchParameters();
                    break;

                #endregion Find


                #endregion Codex

                
                
                // Resorting
                #region Codex

                case "CodexSortMenu": ResortingCodexList(CodexSortBy, CodexFilterBy); break;
                
                        case "CodexSortDateDown":    // ButtonTool
                            CodexSorting(0);
                            break;

                        case "CodexSortDateUp":    // ButtonTool
                            CodexSorting(1);
                            break;

                        case "CodexSortAuthor":    // ButtonTool
                            CodexSorting(2);
                            break;

                        case "CodexSortType":    // ButtonTool
                            CodexSorting(3);
                            break;

                        case "CodexSortNumber":    // ButtonTool
                            CodexSorting(4);
                            break;

                        case "CodexSortStatus":    // ButtonTool
                            CodexSorting(5);
                            break;
                #endregion

                
               
                case "Save": SaveCommonButton(); break;

                #region Favorites
                        case "Favorites_Expand":    // ButtonTool
                            ExpandItem();
                            break;

                        case "Favorites_Colaspe":    // ButtonTool
                            ColapseItem();
                            break;

                        case "Favorites_NewFolder":    // ButtonTool
                            NewFolder();
                            break;

                        case "Favorites_Open":    // ButtonTool
                            // Place code here
                            break;

                        case "Favorites_OpenNew":    // ButtonTool
                            // Place code here
                            break;

                        case "Favorites_Remove":    // ButtonTool
                            DeleteItem();
                            break;

                        case "Favorites_Rename":    // ButtonTool
                            RenameItem();
                            break;
                    
                        case "AddToFavorites":
                                                            
                            if (ForceExit == true) { ILG.Windows.Forms.ILGMessageBox.Show("შვილობილ ფანჯარაში არ შეიძლება ფავორიტების გამოძახება/ცვლილება"); return; }
                
                            if (CodexTab.SelectedTab == CodexTab.Tabs[1])
                            {
                                ILGMessageBox.Show("ფავორიტებშის დასამატებლად საიჭიროა დოკუმენტის გახსნა"); return;
                            }
                
                            
                            { AddtoFavorites(CodexDocumentID,CodexDocumentCaption,Codex_DocumentTitle);  /* codexListBox1.Active_ID, codexListBox1.Active_TCaption,codexListBox1.Active_DCaption); */ return; }
                            
                        break;
                
                case "History_Clear" : ClearHistory(); break;
                case "Favorites_Clear": ClearFavorites(); break;

                #endregion Favorites


                case "FavoritesButton": 
                    { if (ForceExit == true) ILGMessageBox.Show("შვილობილ ფანჯარაში არ შეიძლება ფავორიტების გამოძახება/ცვლილება");
                      else 
                        CallFavoriteList(); 
                    }
                    break;
                case "HomeButton": HomeClick(); break;


               // Document View
                case "PageLayout" :
                     
                        CodexViewLayout = 0; 
                        ViewLayout();

                    
                    break;
                case "NormalLayout" :
                      CodexViewLayout = 1;
                        ViewLayout();
                 

                    break;
                case "Copy": CopyToClipboard(); break;
                case "SelectAll": SelectAll(); break;

                case "ExportPDF": SaveInPDF(); break;
                case "PrintDoc": printDoc(true); break;
                case "PrintSelection": printDoc(false); break;
                case "ExportToWord": ShowInWordPIA(); break;// showinword(); break;
                case "FindDocument": FindInDocument(); break;
                case "FeedBack": 
                    System.Diagnostics.Process.Start("mailto:support@codex.ge"); break;
                case "WebSite": 
                    System.Diagnostics.Process.Start("https://www.codex.ge"); break;

       
                case "About": AboutDS fabout = new AboutDS(); fabout.ShowDialog(); break;
                case "SaveList": SaveList(); break;
                case "ExportList": ExportList(); break;
                
                case "ExportToCodex":
                    {
                      ShowInNewWindows(2, CodexDocumentID, CodexDocumentCaption, "");
           
                    } break; 

                
                case "OpenHere" : OpenHere(); break;

                case "OpenNew":  OpenNew();  break;

                case "DatabaseRefresh":
                    LoadTables();
                    this.NotificationChecker.Stop();
                    CheckIfNewDocuments();
                    this.NotificationChecker.Start();
                    DisplayParametersLimited();
                    break;


                case "ListRefresh":
                    LoadTables();
                    DisplayParametersLimited();
                    RefreashList();
                    break;

                case "DocumentRefresh":
                    LoadTables();
                    DisplayParametersLimited();
                    RefreshDoc();
                    break;

                case "AttachmentProcess":    // ButtonTool
                    AttachProcess();
                    break;

                case "AttachmentSave":    // ButtonTool
                    AttachSave();
                    break;



                case "მიმღები ორგანო":    // ButtonTool
                    {
                        DocumentAddEdit a = new DocumentAddEdit();
                        a.CallTables(0);
                        a.LoadTables();
                        a.DisplayTables();
                    }

                    break;

                        case "დოკუმენტის სახე":    // ButtonTool
                    {
                        DocumentAddEdit a = new DocumentAddEdit();
                        a.CallTables(1);
                        a.LoadTables();
                        a.DisplayTables();
                    }
                    break;

                        case "დოკუმენტის თემატიკა":    // ButtonTool
                    {
                        DocumentAddEdit a = new DocumentAddEdit();
                        a.CallTables(2);
                        a.LoadTables();
                        a.DisplayTables();
                    }

                            break;

                        case "დოკუმენტის კატეგორია":    // ButtonTool
                            {
                                DocumentAddEdit a = new DocumentAddEdit();
                                a.CallTables(3);
                                a.LoadTables();
                                a.DisplayTables();
                            }

                            break;

                        case "დოკუმენტის სტატუსი":    // ButtonTool
                            {
                                DocumentAddEdit a = new DocumentAddEdit();
                                a.CallTables(4);
                                a.LoadTables();
                                a.DisplayTables();
                            }

                            break;

                        case "საკვანძო სიტყვები":    // ButtonTool
                            {
                                DocumentAddEdit a = new DocumentAddEdit();
                                a.CallTables(5);
                                a.LoadTables();
                                a.DisplayTables();
                            }

                            break;

      

                case "DeletedDocuments":
                    {
                        if (app.state.RunTimeLicense.IsSearchinDeletedDocumentsGranted() == false)
                        { 
                                ILGMessageBox.Show("თქვენ არ გაქვთ შესაბამისი დაშვების უფლება");
                                return;
                        }
                        if (app.state.RunTimeLicense.IsSearchinDeletedDocumentsGranted() == true)
                        {
                            HistoryForm1 fh1 = new HistoryForm1();
                            fh1.ShowDialog();
                        }


                    }
                    break;

                case "HistoryClick_Comparation":
                    {
                        if (history_data_model != null)
                        {
                            if (history_data_model.Items.Count > 0)
                            { 
                                CompareDocumentFormV2 f = new CompareDocumentFormV2();
                                f.InitialiseCombos(history_data_model, history_data_model.Items.Count, 0);
                                f.ShowDialog();
                                if (f.isCaneled == true) return;
                                else
                                {
                                    CallWordComparationProcess(f);
                                    return;
                                }


                            }
                        }
                        
                    }
                    break;

                case "ReminderManager":
                    Reminders reminders = new Reminders();
                    reminders.ShowDialog();
                    break;

                case "NewNotification":
                    SetReminder setReminder = new SetReminder(CodexDocumentID, CodexDocumentCaption, 0);
                    setReminder.ShowDialog();
                    break;

                case "HaveNotification":
                    Reminders dreminders = new Reminders(CodexDocumentID);
                    dreminders.ShowDialog();
                    break;

            }

            if (app.state.RunTimeLicense.IsHistoryAccessGranted() == true)
            {
                if (e.Tool.Key.ToUpper().StartsWith("HistoryClick_".ToUpper()) == true)
                {
                    int id = 0;
                    String s = e.Tool.Key.ToUpper().Replace("HistoryClick_".ToUpper(), String.Empty);
                    if (int.TryParse(s, out id) == true)
                    {
                        CallHistory(id);
                    }
                }
            }


        }





        private void AttachProcess()
        {
            if (F_Codex_DOC.listView1.SelectedItems.Count == 0)
            {
                ILGMessageBox.Show("აირჩიეთ ფაილი");
                return;
            }
             
            string str = F_Codex_DOC.listView1.SelectedItems[0].Text.ToString().Trim();

            string Suffix = "";
            string fn = DirectoryConfiguration.DSDocumentsDirectory + @"\"+Suffix +str;
            int i = 1;
            while (System.IO.File.Exists(fn) == true)
            {
                fn = DirectoryConfiguration.DSDocumentsDirectory + @"\" + i.ToString() + str;
                fn = fn.Replace("?", "_");
                i++;
            }

            fn = fn.Replace("?", "_");

            if (fn.Length >= MAX_PATH)
            {
                ILGMessageBox.Show("მიერთებული ფაილის დასახელება არის ოპერაციულ სისტეამში განსაზღვრულ სიგრძეზე დიდი" + System.Environment.NewLine +
                                    fn.ToString() + System.Environment.NewLine +
                                    "შეცვალეთ მიერთებული ფაილის სახელი", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                do
                {
                    string s = Guid.NewGuid().ToString() + "." + Path.GetExtension(str);
                    fn = Path.Combine(DirectoryConfiguration.DSDocumentsDirectory, s);
                }
                while (File.Exists(fn) == true);
            }
            
            DSZip.UnZip(ZipFileName, str, fn, OverWrite: true);
            
            //ZipArchive zipfile = new ZipArchive(new DiskFile(ZipFileName));
            //AbstractFile f = zipfile.GetFile(str);
            //DiskFile FF1 = new DiskFile(fn);
            //f.CopyTo(FF1, true);

            System.Diagnostics.Process.Start(fn);
             
        }

        private void AttachSave()
        {
            if (F_Codex_DOC.listView1.SelectedItems.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("აირჩიეთ ფაილი");
                return;
            }


            string str = F_Codex_DOC.listView1.SelectedItems[0].Text.ToString().Trim();

            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;
            string PathStr = "";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                PathStr = fd.SelectedPath;
            }
            else return;

            string fn = PathStr + @"\" + "" + str;
            fn = fn.Replace("?", "_");
            int i = 1;
            while (System.IO.File.Exists(fn) == true)
            //(File.Exists(fn + "_" + i.ToString() + ".Doc") == true) 
            {
                fn = PathStr + @"\" + i.ToString() + str;
                i++;

            }

            if (fn.Length >= MAX_PATH)
            {
                ILGMessageBox.Show("მიერთებული ფაილის დასახელება არის ოპერაციულ სისტეამში განსაზღვრულ სიგრძეზე დიდი" + System.Environment.NewLine +
                                    fn.ToString() + System.Environment.NewLine +
                                    "შეცვალეთ მიერთებული ფაილის სახელი", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                do
                {
                    string s = Guid.NewGuid().ToString() + "." + Path.GetExtension(str);
                    fn = Path.Combine(PathStr, s);
                }
                while (File.Exists(fn) == true);
            }

            DSZip.UnZip(ZipFileName, str, fn, OverWrite: true);
           
            // CodexZip.Zip_AddOrCreate(ZipFileName, str, fn);

            //ZipArchive zipfile = new ZipArchive(new DiskFile(ZipFileName));
            //AbstractFile f = zipfile.GetFile(str);
            //DiskFile FF1 = new DiskFile(fn);
            //f.CopyTo(FF1, true);

//            zf3.Entries.Extract(str, fn);
  //          zf3.Close();

            ILG.Windows.Forms.ILGMessageBox.Show("ფაილი ჩაწერილია");
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (F_Codex_DOC != null)
            {
                Panelss();
                ZoomingCodex();
            }
                
        }

        public void CaptionGeneration()
        {
            string Ind = "  ";
            if (ForceExit == true) Ind = ". ";
         
                    #region Codex
                    {
                        switch ( CodexTab.ActiveTab.Index) 
                        {
                            case 0: /* Find Form */ this.Text = Ind + "DS დოკუმენტების არქივი"; break;
                            case 1: /* List Form */ this.Text = Ind + "DS დოკუმენტების არქივი დოკუმენტების სია"; break;
                            case 2: /* Document Form */ this.Text = Ind + CodexDocumentCaption; break;
                        }
                    }

                
                    #endregion Codex
         
        }

        bool FavoritesLoaded = false;
        private void ultraTabControl2_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            
            Panelss();
            modify_zoomfactor();
            if (MainTabs.ActiveTab != null)
            {
                if (FavoritesLoaded == true)
                {
                    if (ForceExit == false) SaveTreeData();
                    if (ForceExit == false) SaveHistoryData();
                }
                

                if (ForceExit == false) { LoadTreeData(); FavoritesLoaded = true; }
                if (ForceExit == false) { LoadHistoryData(); FavoritesLoaded = true; }
                CaptionGeneration();
            }

                    #region Codex
                    {
                        switch ( CodexTab.ActiveTab.Index) 
                        {
                            case 0: /* Find Form */ 
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCODEX_DataBase"].Visible = true;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCODEX_List"].Visible = false;

                                //CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = false;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Cliboard"].Visible = false;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Export"].Visible = false;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Edit"].Visible = false;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = false;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_History"].Visible = false;

                                CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["Save"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = false;

                                if (app.state.RunTimeLicense.IsNewDocumentAllow() == true)
                                {
                                    CodexToolBar.Tools["DOCAE"].SharedProps.Enabled = true;
                                    CodexToolBar.Tools["DOCAE"].SharedProps.Visible = true;

                                    CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = true;
                                    CodexToolBar.Tools["DocAttributes"].SharedProps.Enabled = true;
                                    CodexToolBar.Tools["DocAttributes"].SharedProps.Visible = true;
                                  

                                }
                                else
                                {
                                    CodexToolBar.Tools["DOCAE"].SharedProps.Enabled = false;
                                    CodexToolBar.Tools["DOCAE"].SharedProps.Visible = false;
                                    CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = false;
                                    CodexToolBar.Tools["DocAttributes"].SharedProps.Enabled = false;
                                    CodexToolBar.Tools["DocAttributes"].SharedProps.Visible = false;
                                  
                                }

                                
                                CodexToolBar.Tools["DeleteDocument"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["ChangeDocument"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["DeleteDocument"].SharedProps.Visible = false;
                                CodexToolBar.Tools["ChangeDocument"].SharedProps.Visible = false;


                                break;
                            case 1: /* List Form */
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCODEX_DataBase"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCODEX_List"].Visible = true;

                              //CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Cliboard"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Export"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Edit"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_History"].Visible = false;


                              CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = false;
                              CodexToolBar.Tools["Save"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = false;
                              CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = false;
                              CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = false;

                              if (app.state.RunTimeLicense.IsNewDocumentAllow() == true)
                              {
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Enabled = true;
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Visible = true;
                                  CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = true;
                                  CodexToolBar.Tools["DocAttributes"].SharedProps.Enabled = true;
                                  CodexToolBar.Tools["DocAttributes"].SharedProps.Visible = true;


                                  CodexToolBar.Tools["DeleteDocument"].SharedProps.Enabled = true;
                                  CodexToolBar.Tools["DeleteDocument"].SharedProps.Visible = true;
                                
                                  
                              }
                              else
                              {
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Enabled = false;
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Visible = false;
                                  CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = false;
                                  CodexToolBar.Tools["DocAttributes"].SharedProps.Enabled = false;
                                  CodexToolBar.Tools["DocAttributes"].SharedProps.Visible = false;

                                  CodexToolBar.Tools["DeleteDocument"].SharedProps.Enabled = false;
                                  CodexToolBar.Tools["DeleteDocument"].SharedProps.Visible = false;
                                  
                              }

                              //CodexToolBar.Tools["DeleteDocument"].SharedProps.Enabled = false;
                              CodexToolBar.Tools["ChangeDocument"].SharedProps.Enabled = false;
                              //CodexToolBar.Tools["DeleteDocument"].SharedProps.Visible = false;
                              CodexToolBar.Tools["ChangeDocument"].SharedProps.Visible = false;

                              break; 
                          case 2:/* Document Form */
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCODEX_DataBase"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCODEX_List"].Visible = false;

                              //CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = true;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Cliboard"].Visible = true;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Export"].Visible = true;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Edit"].Visible = true;
                      //  CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_History"].Visible = false;


                        CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["Save"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = true;

                              if (app.state.RunTimeLicense.DocumentOperation() == true)
                              {
                                  CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = true;
                                  //CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RTools"].Visible = true;
                                  CodexToolBar.Tools["DocAttributes"].SharedProps.Enabled = true;
                                  CodexToolBar.Tools["DocAttributes"].SharedProps.Visible = true;
                                                      
                                  
                              }
                              else
                              {
                                  CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = false;
                                  //CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RTools"].Visible = false;
                                  CodexToolBar.Tools["DocAttributes"].SharedProps.Enabled = false;
                                  CodexToolBar.Tools["DocAttributes"].SharedProps.Visible = false;
                                  
                                  
                              }


                              if (app.state.RunTimeLicense.IsNewDocumentAllow() == true)
                              {
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Enabled = true;
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Visible = true;

                              }
                              else
                              {
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Enabled = false;
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Visible = false;
                              }


                              if (app.state.RunTimeLicense.IsDocumentEditAllow() == true)
                              {
                                  CodexToolBar.Tools["ChangeDocument"].SharedProps.Enabled = true;
                                  CodexToolBar.Tools["ChangeDocument"].SharedProps.Visible = true;
                              }
                              else
                              {
                                  CodexToolBar.Tools["ChangeDocument"].SharedProps.Enabled = false;
                                  CodexToolBar.Tools["ChangeDocument"].SharedProps.Visible = false;
                              }


                              if (app.state.RunTimeLicense.IsDocumentDeletetAllow() == true)
                              {
                                  CodexToolBar.Tools["DeleteDocument"].SharedProps.Enabled = true;
                                  CodexToolBar.Tools["DeleteDocument"].SharedProps.Visible = true;
                              }
                              else
                              {
                                  CodexToolBar.Tools["DeleteDocument"].SharedProps.Enabled = false;
                                  CodexToolBar.Tools["DeleteDocument"].SharedProps.Visible = false;
                              }

                              ViewLayout();
                              
                              ViewFindButtonStatus();
                              break;
                        }
                    }

                
                    #endregion Codex
                
        }

        private void Panelss()
        {
            Codex_Search_Panel.Left = (Codex_Search_Panel.Parent.ClientSize.Width - Codex_Search_Panel.Width) / 2;
        }

        
        #region Fill Results and Result DataSets
        
        #region Common
        static string FilterString(string str)
        {
            StringBuilder S = new StringBuilder("");
            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (str[i] >= ' ') S.Append(str[i]);
                if (str[i] == '\n') S.Append(' ');
            }

            return S.ToString();
        }

        #endregion Common

        #region Codex
        public DataSet Codex_Result;
        
        private void Codex_FillResult(String strcmd)
        {
            SqlDataAdapter daCodex = new SqlDataAdapter(strcmd, app.state.ConnectionString);
            daCodex.SelectCommand.CommandTimeout = 7200;
            Codex_Result = new DataSet();
            try
            {
                daCodex.Fill(Codex_Result);
            }
            catch (System.Exception ex)
            {
                bool UseFullText = app.state.UseFullTextSearch;
                if (UseFullText == true)
                    ILG.Windows.Forms.ILGMessageBox.ShowE("შეცდომა სერვერზე ! \n" +
                                                         "პროგრამის გაგრძელება შეუძლებელია, იგი დაიხურება ", 
                        "",ex.Message.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                else
                    ILG.Windows.Forms.ILGMessageBox.ShowE(
                        "სერვერთან კომუნიკაციის პრობლემა, დარწმუნდით, რომ SQL Service გაშვებულია \n" +
                        "ან შეცვალეთ კონფიგურაციის ფაილი.\n" +
                        "პროგრამის გაგრძელება შეუძლებელია, იგი დაიხურება ",
                        "", ex.Message.ToString(),
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                ForceExit = true;
                Close();
            }


            DataColumn dclm = new DataColumn("TopCaption");
            dclm.ReadOnly = false;
            dclm.DataType = System.Type.GetType("System.String");
            dclm.AutoIncrement = false;

            Codex_Result.Tables[0].Columns.Add(dclm); ;

            StringBuilder Strauthor = new StringBuilder("1");
            StringBuilder Strtype = new StringBuilder("1");
            StringBuilder Strstatus = new StringBuilder("0");
            StringBuilder StrCategory = new StringBuilder("0");

            LockupTables.Tables["CodexDS_DAuthor"].PrimaryKey = new DataColumn[] { LockupTables.Tables["CodexDS_DAuthor"].Columns["A_ID"] };
            LockupTables.Tables["CodexDS_DType"].PrimaryKey = new DataColumn[] { LockupTables.Tables["CodexDS_DType"].Columns["T_ID"] };
            LockupTables.Tables["CodexDS_DStatus"].PrimaryKey = new DataColumn[] { LockupTables.Tables["CodexDS_DStatus"].Columns["C_ID"] };
            LockupTables.Tables["CodexDS_DCategory"].PrimaryKey = new DataColumn[] { LockupTables.Tables["CodexDS_DCategory"].Columns["C_ID"] };

            DataRow dr;

            for (int i = 0; i <= Codex_Result.Tables[0].Rows.Count - 1; i++)
            {
                Strauthor.Remove(0, Strauthor.Length);
                Strtype.Remove(0, Strtype.Length);
                Strstatus.Remove(0, Strstatus.Length);
                StrCategory.Remove(0, StrCategory.Length);

                dr = LockupTables.Tables["CodexDS_DAuthor"].Rows.Find((int)Codex_Result.Tables[0].Rows[i]["C_Author"]);
             
                if (dr == null) Strauthor.Append(" ");
                else Strauthor.Append(@dr["A_Caption"].ToString().Trim());

                dr = LockupTables.Tables["CodexDs_DType"].Rows.Find((int)Codex_Result.Tables[0].Rows[i]["C_Type"]);

                if (dr == null) Strtype.Append(" ");
                else Strtype.Append(@dr["T_Caption"].ToString().Trim());


                // New ITEMS
                dr = LockupTables.Tables["CodexDs_DStatus"].Rows.Find((int)Codex_Result.Tables[0].Rows[i]["C_Status"]);

                if (dr == null) Strstatus.Append(" ");
                { if (dr["C_ID"].ToString().Trim() == "0") Strstatus.Append(" ");
                    else Strstatus.Append(@dr["C_Caption"].ToString().Trim());
                }


                dr = LockupTables.Tables["CodexDs_DCategory"].Rows.Find((int)Codex_Result.Tables[0].Rows[i]["C_Category"]);

                if (dr == null) StrCategory.Append(" ");
                {
                    if (dr["C_ID"].ToString().Trim() == "0") StrCategory.Append(" ");
                    else StrCategory.Append(@dr["C_Caption"].ToString().Trim());
                }

                String S =
                    PickDate.DateToString((DateTime)Codex_Result.Tables[0].Rows[i]["C_Date"]) + "  "
                    + Strauthor.ToString() + "  " + Strtype + " ";

                if (Codex_Result.Tables[0].Rows[i]["C_numberStr"] != null)
                {
                    if (Codex_Result.Tables[0].Rows[i]["C_numberStr"].ToString().Trim() != "") S = S + "N " + (Codex_Result.Tables[0].Rows[i]["C_numberStr"]).ToString().Trim();
                }
                
                
                if (Strstatus.ToString().Trim() != "") S = S + " : <" + Strstatus + "> ";
                if (StrCategory.ToString().Trim() != "") S = S + " : (" + StrCategory + ") ";




                String Saddt = "";
                if (DSBehaviorConfiguration.Instance.content.Attributes.ShowAdvancedAttributes == true)
                {
                    if (Codex_Result.Tables[0].Rows[i]["C_Addtional"] == null) Saddt = "";
                    else
                    {
                        if (Codex_Result.Tables[0].Rows[i]["C_Addtional"].ToString().Trim() != "")
                            Saddt = Codex_Result.Tables[0].Rows[i]["C_Addtional"].ToString().Trim();
                    }
                }

                if (Saddt.Trim() != "") S = S + "  " + Saddt;

                Int32 IDX = -1;
                String IDACCESS = "";
                if (Codex_Result.Tables[0].Rows[i]["C_Group"] == null) IDX = -1;
                else
                {
                    IDX = (int)Codex_Result.Tables[0].Rows[i]["C_ID"];
                    if ((int)Codex_Result.Tables[0].Rows[i]["C_Group"] == 0)
                    {
                        if (app.state.RunTimeLicense.IsDocumentIDShowInList() == true) IDACCESS = "[ID=" + IDX.ToString();
                    }
                    else
                    {
                        if (app.state.RunTimeLicense.IsConfidentialDocumentIDShowInList() == true) IDACCESS = " [ID=" + IDX.ToString();
                    }
                }

                if (IDACCESS.Trim() != "") S = IDACCESS +"] " + S;

                Codex_Result.Tables[0].Rows[i]["TopCaption"] = @S;
                Codex_Result.Tables[0].Rows[i]["C_Caption"] = @FilterString(Codex_Result.Tables[0].Rows[i]["C_Caption"].ToString());


            }

            ///CodexResultV = CodexResult.Select("", "C_Date DESC");

        }

        #endregion Codex

 
  
        
        

        #endregion Fill Results and Result DataSets




        private void HomeClick()
        {
            CodexTab.SelectedTab = this.CodexTab.Tabs[0]; CodexPos = 0;
        }

        

 
        private void CallList()
        {
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[1]; CodexPos = 1; 
        }


        public void DetermineSpecialView()
        {
            if (app.state.RunTimeLicense.IsDocumentViewRestrictedMode() == true)
            {
                F_Codex_DOC.textControl_Codex.EditMode = TXTextControl.EditMode.ReadOnly;
                CodexToolBar.Tools["Copy"].SharedProps.Enabled = false;
                CodexToolBar.Tools["SelectAll"].SharedProps.Enabled = false;
                CodexToolBar.Tools["Save"].SharedProps.Enabled = false;
                CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = false;
                CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = false;
                CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = false;
                CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = false;
                
            }
            else
            {
                F_Codex_DOC.textControl_Codex.EditMode = TXTextControl.EditMode.ReadAndSelect;
                CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = true;
                CodexToolBar.Tools["Save"].SharedProps.Enabled = true;
                CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = true;
                CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = true;
                CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = true;
                CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = true;
                CodexToolBar.Tools["SelectAll"].SharedProps.Enabled = true;
                CodexToolBar.Tools["FindDocument"].SharedProps.Enabled = true;
                CodexToolBar.Tools["Copy"].SharedProps.Enabled = true;
                
            }
        }
        public void DeterminePDFRTFMenu()
        {
            if (Codex_DocumentFormat == 0)
            {
                
                //CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = true;
                
                CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = true;
                CodexToolBar.Tools["PrintSelection"].SharedProps.Enabled = true;
                CodexToolBar.Tools["Save"].SharedProps.Enabled = true;
                CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = true;
                CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = true;
                CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = true;
                CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = true;
                CodexToolBar.Tools["SelectAll"].SharedProps.Enabled = true;
                CodexToolBar.Tools["FindDocument"].SharedProps.Enabled = true;
                CodexToolBar.Tools["Copy"].SharedProps.Enabled = true;
                DetermineSpecialView();
            }
            else
            {

                //CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = false;
                
                CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = true;
                CodexToolBar.Tools["PrintSelection"].SharedProps.Enabled = false;
                CodexToolBar.Tools["Save"].SharedProps.Enabled = false;
                CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = true;
                CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = false;
                CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = false;
                CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = true;
                CodexToolBar.Tools["SelectAll"].SharedProps.Enabled = false; // Until Implemeted Selections
                CodexToolBar.Tools["FindDocument"].SharedProps.Enabled = true;
                CodexToolBar.Tools["Copy"].SharedProps.Enabled = false; // Until Implemeted Selections


            }
        }


        public void DoesDocumentHaveNotificationToShow()
        {
            var res = DSLightNotificationManager.instance.IsNotificationsForDocuemtId(CodexDocumentID);
            CodexToolBar.Tools["HaveNotification"].SharedProps.Enabled = res;
            CodexToolBar.Tools["HaveNotification"].SharedProps.Visible = res;
        }

        // სიისდან გამოძახებული დოკუმენტების ნავიგაცია  ყოველთვის იყწება ახლიდან
        public void codexListBox1_DocumentClick(object sender, CodexDSListEventArgs e)
        {
            
            if (ISDocumentExsists(e._ID) == false)
            {
                ILGMessageBox.Show("დოკუმენტი ბაზაში არ მოიძებნა");
                RefreashList();
                return;
            }
            string doc = "";
            string link = "";
            string linkscema = "";
            int ZX = CodexOpenDocument(e._ID, ref doc, ref link, ref linkscema);
            if (ZX == -1000) return;
            if (ZX == -7701) return;
            AddtoHistory(e._ID, e._TCaption, e._DCaption);
            CodexLoadDoc(doc, link, linkscema, e._TCaption, e._DCaption);
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[2];
            CodexPos = 2;
            CodexDocsNav.newdoc(e._ID, e._TCaption, e._DCaption);
            DeterminePDFRTFMenu();
            DSVisitedNotificationManager.instance.AddVisitedDocument(e._ID);
            UpdateNewDocumetsListAfterVisit();
            DoesDocumentHaveNotificationToShow();
        }


        // გახსნა ახალ ფანჯარაში ისტორიაში არ ვარდება
        public void codexListBox1_DocumentClick3(object sender, CodexDSListEventArgs e)
        {

            if (ISDocumentExsists(e._ID) == false)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი ბაზაში არ მოიძებნა");
                RefreashList();
                return;
            }
            string doc = "";
            string link = "";
            string linkscema = "";
            int ZX = CodexOpenDocument(e._ID, ref doc, ref link, ref linkscema);
            if (ZX == -1000) { ForceExit = true; Close(); return; }
            if (ZX == -7701) return;
            CodexLoadDoc(doc, link, linkscema, e._TCaption, e._DCaption);
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[2];
            CodexPos = 2;
            CodexDocsNav.newdoc(e._ID, e._TCaption, e._DCaption);
            DeterminePDFRTFMenu();
            DSVisitedNotificationManager.instance.AddVisitedDocument(e._ID);
            UpdateNewDocumetsListAfterVisit();
            DoesDocumentHaveNotificationToShow();
        }

        public void codexListBox1_DocumentClick2(CodexDSListEventArgs e, bool append)
        {
            if (ISDocumentExsists(e._ID) == false)
            {
                ILGMessageBox.Show("დოკუმენტი ბაზაში არ მოიძებნა");
                RefreashList();
                return;
            }
            string doc = "";
            string link = "";
            string linkscema = "";
            int ZX = CodexOpenDocument(e._ID, ref doc, ref link, ref linkscema);
            if (ZX == -1000) return;
            if (ZX == -7701) return;
            CodexLoadDoc(doc, link, linkscema, e._TCaption, e._DCaption);
            AddtoHistory(CodexDocumentID, CodexDocumentCaption, Codex_DocumentTitle);
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[2];
            CodexPos = 2;
            if (append == true)
                CodexDocsNav.adddoc(e._ID, e._TCaption, e._DCaption);
            DeterminePDFRTFMenu();
            DSVisitedNotificationManager.instance.AddVisitedDocument(e._ID);
            UpdateNewDocumetsListAfterVisit();
            DoesDocumentHaveNotificationToShow();
        }



        public void RefreshDoc()
        {
            string doc = "";
            string link = "";
            string linkscema = "";
            int ZX = CodexOpenDocument(CodexDocumentID, ref doc, ref link, ref linkscema);
            if (ZX != 0) { HomeClick(); return; }
            if (ZX == -7701) return;
            CodexLoadDoc(doc, link, linkscema, CodexDocumentCaption,Codex_DocumentTitle);
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[2];
            CodexPos = 2;
            DeterminePDFRTFMenu();
        }

        private string LastRibbon = "";
        private void CodexToolBar_BeforeRibbonTabSelected(object sender, Infragistics.Win.UltraWinToolbars.BeforeRibbonTabSelectedEventArgs e)
        {
            bool f = false;
            switch (e.Tab.Key.ToString())
            {
                case "RCodex": this.MainTabs.SelectedTab = this.MainTabs.Tabs[0];  break;
               
            }
            if (f != true) LastRibbon = e.Tab.Key.ToString();
            
        }

        private void GoToLastRibbon()
        {
            if (LastRibbon != "")
                CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[LastRibbon];
        }


        private void CodexToolBar_ToolKeyPress(object sender, Infragistics.Win.UltraWinToolbars.ToolKeyPressEventArgs e)
        {

            
            if (e.Tool.Key == "Codex_List_Filter")
            {
                e.Handled = true;
                e.KeyChar = ILG.Codex.CodexR4.KeyBoard.Layout.U[e.KeyChar];
            }

        }

        private void ConfigurationCall()
        {
            if (DSBehaviorConfiguration.Instance.content.General.IsOptions == true)
            {
                CodexConfiguration f = new CodexConfiguration();
                //f.MainForm = this;
                f.ShowDialog();
            }
            else
            {
                ILG.Windows.Forms.ILGMessageBox.Show("თქვენ არ გაქვთ კონფიგურაციასთან დაშვების შესაბამისი უფლება");
            }
            //MessageBox.Show(LastRibbon);
            //GoToLastRibbon();

        }

        private void CodexToolBar_AfterRibbonTabSelected(object sender, Infragistics.Win.UltraWinToolbars.RibbonTabEventArgs e)
        {
            if (e.Tab.Key.ToString() == "RConfig")
            {
                GoToLastRibbon();
            }
        }

        private void CodexTab_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            
            if (e.Tab == CodexTab.Tabs[2])
            {
                
                F_Codex_DOC.textControl_Codex.Focus();
                modify_zoomfactor();
            }
            
        }

        
        
        public void textControl_Codex_InputPositionChanged(object sender, EventArgs e)
        {
            Codex_UpdateStatusBar();
        }

        
        

        public void OpenHere()
        {
               codexListBox1_DocumentClick2(new CodexDSListEventArgs(F_Codex_DOC.CodexLinkBox.Active_LinkTo, "", ""), true); 
        }


        public void OpenNew()
        {
            ShowInNewWindows(2, F_Codex_DOC.CodexLinkBox.Active_LinkTo, "", ""); 
        }

        
        public void CodexLinkBox_DocumentClick(object sender, ILG.Codex.CodexDSLinkListBox.CodexDSLinkListEventArgs e)
        {
            codexListBox1_DocumentClick2(new CodexDSListEventArgs(e._LinkTo, "<" + e._Caption + ">", ""), true);
        }

     
        private void ultraDockManager1_PropertyChanged(object sender, Infragistics.Win.PropertyChangedEventArgs e)
        {
            modify_zoomfactor();
        }

  

        private void ICG_News_Button_Click(object sender, EventArgs e)
        {
            if (ICG_News_Check.Checked == true)
            {
                if (Codex_Date1 > Codex_Date2) { ILGMessageBox.Show("თარიღის ინტერვალი არასოწრია !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }
                if ((Codex_Number_Edit.Text.Trim() != "") && (DSString.CheckNumStr(Codex_Number_Edit.Text) == false)) { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის შესაძლო ნომერი არასწორედაა მითითებული !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }

            }

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Codex_FillResult(Codex_GenerateNewsSQL());
            this.Cursor = System.Windows.Forms.Cursors.Default;

            int maxlist = app.state.UISettingsManager.content.ui_max_list;
            if (Codex_Result.Tables[0].Rows.Count == 0) { ILG.Windows.Forms.ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); return; }
            if (Codex_Result.Tables[0].Rows.Count >= maxlist)
            {
                //ILG.Windows.Forms.ILGMessageBox.Show("მოძებნილი დოკუმენტების რაოდენობა მეტია " + maxlist.ToString() + " - ზე  [" + Codex_Result.Tables[0].Rows.Count.ToString() + "] " +
                //                                              "  \n გთხოვთ დააკონკრეტოთ ძებნის პარამეტრები ");
                //return;
                if ((ILGMessageBox.Show("მოძებნილი დოკუმენტების რაოდენობა მეტია " + maxlist.ToString() + " - ზე  " + System.Environment.NewLine +
                  "გთხოვთ დააკონკრეტოთ ძებნის პარამეტრები ან დააჭირეთ ღილაკს <უარი> და ეკრანზე გამოვა მხოლოდ პირველი " + maxlist.ToString() + " დოკუმენტი", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK))
                {
                    return;
                }
            }

            CodexSorting(0);
            CodexList = true;
            CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიახლის სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            CodexToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "ახალი დოკუმენტები დალაგებულია";
            //Codex_List_SortLabel CodexListStatus.Text = "ახალი დოკუმენტები დალაგებულია";
            isnews = true;
            CodexPos = 1;
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[1];
            //this.F_Codex_List.DocumentListBox1.Visited = this.CodexVisited;
            //this.F_Codex_List.DocumentListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, app.state.RunTimeLicense.IsHistoryAccessGranted());////2);
            //this.F_Codex_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
            //this.F_Codex_List.DocumentListBox1.FillGrid();

            //F_Codex_List.DocumentListBox1.ShowIDMode = _InternalMode;
            F_Codex_List.DocumentListBox1.Visited = this.CodexVisited;
            F_Codex_List.DocumentListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, app.state.RunTimeLicense.IsHistoryAccessGranted());
            F_Codex_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
            F_Codex_List.SetZoomFactor(Codex_List_ZoomFactor);
            //F_Codex_List.DocumentListBox1.FillGrid();
            F_Codex_List.DocumentListBox1.FillGrid(_NewDocuments);


        }

        private void ultraLabel1_Click(object sender, EventArgs e)
        {

        }

        private void CodexToolBar_BeforeShortcutKeyProcessed(object sender, Infragistics.Win.UltraWinToolbars.BeforeShortcutKeyProcessedEventArgs e)
        {
            if (F_Codex_DOC.textControl_Codex.Focused == false) e.Cancel = true;

        }


        #region Word Comparation
        public String DSComparationTitle = "";
        
        
        public void CallWordComparationProcess(CompareDocumentFormV2 f)
        {
            // Perfom Commmand Line Activities
            int CurrentID = CodexDocumentID; 

            bool OriginalFrom_Main_Database = false;
            int OriginalDocumentID = f.OriginalDocID;
            if (OriginalDocumentID == -1) { OriginalDocumentID = CurrentID; OriginalFrom_Main_Database = true; }

            bool RevisedFrom_Main_Database = false;
            int RevisedDocumentID = f.RevisedDocID;
            if (RevisedDocumentID == -1) { RevisedDocumentID = CurrentID; RevisedFrom_Main_Database = true; }

            DocumentComparation b = new DocumentComparation();


            String OriginalFileName = "";
            String RevisedFileName = "";
            String CCFileName = b.ExtractDocumentsFromDatabaseForComparation(OriginalFrom_Main_Database, OriginalDocumentID, RevisedFrom_Main_Database, RevisedDocumentID, ref OriginalFileName, ref RevisedFileName);


            OriginalFileName = OriginalFileName.Replace(@"\", @"\\");
            RevisedFileName = RevisedFileName.Replace(@"\", @"\\");
            CCFileName = CCFileName.Replace(@"\", @"\\");

            String ComparationTitle = f.Tilte;



            int Result;
            //String Script = CodexWordJS.CompareTwoDocumentScript(OriginalFileName, RevisedFileName, /*CCFileName,*/ ComparationTitle, "222", "333");


            try
            {
                this.Cursor = Cursors.WaitCursor;

                Result = CodexWordPIA.CompareTwoDocumentScriptV2(OriginalFileName, RevisedFileName, CCFileName, ComparationTitle, " ", " ",
                  f.Granularity.SelectedIndex, f.ShowChangesIn.SelectedIndex, f.SourceDocuments.SelectedIndex, f.RevisionPanel.SelectedIndex, f.ChangeMode.SelectedIndex);
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }


            //System.Diagnostics.Process.Start(CCFileName);

        }

        #endregion Word Comparation

        private void ICG_News_DateCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool v = true;
            if (ICG_News_DateCheck.Checked == true)
            {
                News_Date_Edit.Text = PickDate.DateToString(ICG_FromNewsDate);
                v = true;
            }
            else
            {
                v = false;
            }
            News_Date_Edit.Enabled = v;
            News_Date_Edit.Visible = v;
            News_Date_Button.Enabled = v;
            News_Date_Button.Visible = v;

        }

        private void News_Date_Button_Click(object sender, EventArgs e)
        {
            var dlg2 = new PickDate(ICG_FromNewsDate);
            Point dc2 = new Point(News_Date_Edit.Location.X, News_Date_Edit.Location.Y);
            Point dc = Codex_Search_Panel.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            News_Date_Edit.Text = dlg2.ToString();
            ICG_FromNewsDate = dlg2.PickedDate;
        }

        private void MainTabs_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }


        private void CheckNotificationData()
        {
            int c = DSLightNotificationManager.instance.CountNotificationsForToday();
            if (c > 0) { 
                CodexToolBar.Tools["ReminderManager"].SharedProps.NotificationBadgeSettings.Appearance.FontData.SizeInPoints = 6;
                CodexToolBar.Tools["ReminderManager"].SharedProps.NotificationBadgeSettings.Appearance.FontData.Name = "Calibri";
                CodexToolBar.Tools["ReminderManager"].SharedProps.NotificationBadgeSettings.Visibility = Infragistics.Win.Notifications.NotificationBadgeVisibility.Always;
                CodexToolBar.Tools["ReminderManager"].SharedProps.NotificationBadgeText = c.ToString();
            }
            else
            {
                CodexToolBar.Tools["ReminderManager"].SharedProps.NotificationBadgeSettings.Appearance.FontData.SizeInPoints = 6;
                CodexToolBar.Tools["ReminderManager"].SharedProps.NotificationBadgeSettings.Appearance.FontData.Name = "Calibri";
                CodexToolBar.Tools["ReminderManager"].SharedProps.NotificationBadgeSettings.Visibility = Infragistics.Win.Notifications.NotificationBadgeVisibility.Never;
                CodexToolBar.Tools["ReminderManager"].SharedProps.NotificationBadgeText = "";
            }
        }

        private void CheckIfNewDocuments()
        {
            var data = GetNewDocuments();
            _NewDocuments = DSVisitedNotificationManager.instance.Check(data);
            UpdateNotificationButtonUI();
        }

        private void UpdateNewDocumetsListAfterVisit()
        {
            _NewDocuments = DSVisitedNotificationManager.instance.Check(_NewDocuments);
           UpdateNotificationButtonUI();
            
        }

        private void ShowDesktopAlert()
        {
            if (_NewDocuments.Count > 0)
            {
                ultraDesktopAlert1.Show($"ახალი დოკუმენტი", $" ბაზაში არის {_NewDocuments.Count} ახალი დოკუმენტი");
            }
        }

       
        private void UpdateNotificationButtonUI()
        {
            _NewDocuments = DSVisitedNotificationManager.instance.Check(_NewDocuments);
            if (_NewDocuments.Count > 0)
            {
                ICG_News_Button.Text = $"სიახლე ({_NewDocuments.Count})";
                ICG_News_Button.Appearance.ForeColor = Color.FromArgb(0xa4, 0x37, 0x3a);
                ICG_News_Button.Appearance.Image = Properties.Resources.place_red;
            }
            else
            {
                ICG_News_Button.Text = $"სიახლე ";
                ICG_News_Button.Appearance.ForeColor = Color.Black;
                ICG_News_Button.Appearance.Image = null;
            }
            CheckNotificationData();
        }


        private void NotificationChecker_Tick(object sender, EventArgs e)
        {
            CheckIfNewDocuments();
            ShowDesktopAlert();
        }
    }
}