﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ILG.Codex2007;
using ILG.Windows.Forms;
using ILG.Codex.WindowsForms;
using ILG.Codex2007.Strings;
using ILG.Codex2007.Favorites;
using ILG.Codex.CodexListBox;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolTip;
using Xceed.Zip;
using Xceed.FileSystem;


namespace ILG.Codex.Codex2007
{
    public partial class Form1 : Form
    {
        
   
        
        #region Common Values
        public DataSet LockupTables;
        int Current_Language;
        public bool ForceExit = false;
        public static SplashScreen sp;
        int ActiveProgram = -1;
        public DataTable CodexVisited;
        
        
       #endregion Common Values

        
        Form_Codex_Document F_Codex_DOC;
        //Boolean IsFirstWindows = true;
        //String Form_Caption = "Codex 2007 DS Alpha 0.2";
        int ICG_NewsN = 2;
        int ICG_News_ComboV = 1;


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
                                       global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
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

            }
            catch (Exception ex)
            {
                ILG.Windows.Forms.ILGMessageBox.ShowE("ბაზიდან ინფორმაციის წაკითხვა ვერ ხერხდება", ex.Message.ToString());
                // Force to Exit
            }
        }


        public Form1(bool FExit)
        {
            InitializeComponent();
            Current_Language = (int)global::ILG.Codex.Codex2007.Properties.Settings.Default.KeyboardLayout;
            this.LanguageSwitcher.SelectedIndex = Current_Language;
            DefaultSearchParameters();
            LoadTables();
            UltraTree_DropHightLight_DrawFilter.Invalidate += new EventHandler(this.UltraTree_DropHightLight_DrawFilter_Invalidate);
            UltraTree_DropHightLight_DrawFilter.QueryStateAllowedForNode += new UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventHandler(this.UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode);
            LoadTree();
            NavigationInistialize();
            DisplayParameters();

            F_Codex_DOC = new Form_Codex_Document();
            F_Codex_DOC.MainForm = this;
            this.formContainer3.ShowForm(F_Codex_DOC);

            ForceExit = FExit;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory
             + "\\Styles\\Office2007Blue.isl"
            );
            //Infragistics.Win.Office2007ColorTable.ColorScheme = Infragistics.Win.Office2007ColorScheme.Black;
            //Infragistics.Win.AppStyling.StyleManager.Load("c:\\1\\Office2007Blue.isl");
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.DefaTheme == 0)
                switch (Infragistics.Win.Office2007ColorTable.ColorScheme)
                {
                    case Infragistics.Win.Office2007ColorScheme.Black: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007Black.isl"); break;
                    case Infragistics.Win.Office2007ColorScheme.Blue: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007Blue.isl"); break;
                    case Infragistics.Win.Office2007ColorScheme.Silver: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007silver.isl"); break;
                }
            else
            {
                switch (global::ILG.Codex.Codex2007.Properties.Settings.Default.DefaTheme)
                {
                    case 1: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007Black.isl"); break;
                    case 2: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007Blue.isl"); break;
                    case 3: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007silver.isl"); break;
                }
            }


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
            Codex_Number_Edit.Left = Codex_Number_Label.Left + Codex_Number_Label.Width + 12+8+4;
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
            ILG.Codex.WindowsForms.PickDate d = new ILG.Codex.WindowsForms.PickDate(DateTime.Now);
            Codex_Date_Edit1.Width = d.Width-Codex_Date_Button1.Width;
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

            ICG_Seperator.Top = Codex_Attrib_Edit.Top + Codex_Attrib_Edit.Height + 8;
            ICG_Seperator.Left = 0;
            ICG_Seperator.Width = Codex_W;

            ICG_News_label.Left = 0;
            ICG_News_Edit.Top = ICG_Seperator.Top + ICG_Seperator.Height + 8;
            ICG_News_label2.Top = ICG_News_Edit.Top + ((ICG_News_Edit.Height - ICG_News_label2.Height) / 2);
            ICG_News_label.Top = ICG_News_label2.Top;
            ICG_News_Combo.Top = ICG_News_Edit.Top;
            ICG_News_Edit.Left = ICG_News_label2.Left + ICG_News_label2.Width + 8;
            ICG_News_Combo.Left = ICG_News_Edit.Left + ICG_News_Edit.Width + 8;
            ICG_News_Button.Top = ICG_News_Combo.Top;
            ICG_News_Button.Width = Codex_Search_Button.Width;
            ICG_News_Combo.Width = Codex_W - ICG_News_Combo.Left - ICG_News_Button.Width - 8;
            ICG_News_Button.Left = ICG_News_Combo.Left + ICG_News_Combo.Width + 8;
            ICG_News_Check.Left = ICG_News_label2.Left;
            ICG_News_Check.Top = ICG_News_Edit.Top + ICG_News_Edit.Height + 8;
           


       #endregion  Codex Find Panel
    
            #region Firt Tab loading
            
                //if (def == 0) { MainTabs.SelectedTab = MainTabs.Tabs[1]; CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[0]; }
               // if (def == 1) { MainTabs.SelectedTab = MainTabs.Tabs[0]; CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[1]; }
               // if (def == 2) { MainTabs.SelectedTab = MainTabs.Tabs[0]; CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[0]; }
                LastRibbon = CodexToolBar.Ribbon.SelectedTab.Key;
                
                if (Form1.sp.Visible == true) Form1.sp.Hide();

            

            #endregion  Firt Tab loading

   


            #region Panels
            Codex_Search_Panel.Left = (Codex_Search_Panel.Parent.ClientSize.Width - Codex_Search_Panel.Width) / 2;
            
            
#endregion

            this.Left = 0;
            this.Top = 0;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

            



            
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
                    ILG.Codex.KeyBoard.Layout.SetGeorgianLat();
                    LanguageSwitcher.SelectedIndex = 1;
                    break;

                case "GeoRus":    // ButtonTool
                    ILG.Codex.KeyBoard.Layout.SetGeorgianRus();
                    LanguageSwitcher.SelectedIndex = 2;
                    break;

                case "Rus":    // ButtonTool
                    ILG.Codex.KeyBoard.Layout.SetRussian();
                    LanguageSwitcher.SelectedIndex = 3;
                    break;

                case "English":    // ButtonTool
                    ILG.Codex.KeyBoard.Layout.SetEnglish();
                    LanguageSwitcher.SelectedIndex = 0;
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
                   if (global::ILG.Codex.Codex2007.Properties.Settings.Default.IsOptions == true)
                   {
                       Configuration f = new Configuration();
                       f.ShowDialog();
                   }
                   else
                   {
                       ILG.Windows.Forms.ILGMessageBox.Show("თქვენ არ გაქვთ კონფიგურაციასთან დაშვების შესაბამისი უფლება");
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
                   if (License.IsDocumentEditAllow() == false)
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
                   if (ActiveProgram == -1) return;
                   else
                   {
                       if (ActiveProgram == 2) Codex_DefaultSearchParameters();
                       
                       
                   }
                   
                   break;

               case "TopNavigationLeft":    // ButtonTool
                   if (ActiveProgram == -1) return;
                   else
                   {
                       ActiveProgram++;
                       if (ActiveProgram > 2) ActiveProgram = 0;

                       if (ActiveProgram == 2) { MainTabs.SelectedTab = MainTabs.Tabs[0]; return; }
                     
                       

                   }
                   break;

               case "TopNavigationRight":    // ButtonTool
                   if (ActiveProgram == -1) return;
                   else
                   {
                       ActiveProgram--;
                       if (ActiveProgram < 0) ActiveProgram = 2;

                       if (ActiveProgram == 2) { MainTabs.SelectedTab = MainTabs.Tabs[1]; return; }
                       if (ActiveProgram == 1) { MainTabs.SelectedTab = MainTabs.Tabs[0]; ; return; }
                       
                   }
                   break;

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
                                ILG.Windows.Forms.ILGMessageBox.Show("ფავორიტებშის დასამატებლად საიჭიროა დოკუმენტის გახსნა"); return;
                            }
                
                            
                            { AddtoFavorites(CodexDocumentID,CodexDocumentCaption,Codex_DocumentTitle);  /* codexListBox1.Active_ID, codexListBox1.Active_TCaption,codexListBox1.Active_DCaption); */ return; }
                            
                        break;
                
                case "History_Clear" : ClearHistory(); break;
                case "Favorites_Clear": ClearFavorites(); break;

                #endregion Favorites


                case "FavoritesButton": 
                    { if (ForceExit == true) ILG.Windows.Forms.ILGMessageBox.Show("შვილობილ ფანჯარაში არ შეიძლება ფავორიტების გამოძახება/ცვლილება");
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
                case "ExportToWord": showinword(); break;
                case "FindDocument": FindInDocument(); break;
                case "FeedBack": 
                    System.Diagnostics.Process.Start("mailto:support@codexserver.com"); break;
                case "WebSite": 
                    System.Diagnostics.Process.Start("http://www.codexserver.com"); break;

                case "Manual": 
                    //System.Diagnostics.Process.Start("http://www.codexserver.com/help/index.html");
                    //System.Diagnostics.Process.Start("http://www.codexserver.com/help/index.html");
                    System.Diagnostics.Process.Start(@"file" + @":\\" + global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory+"\\Help\\Codex.XPS");
                    break;

                case "About": About fabout = new About(); fabout.ShowDialog(); break;
                case "SaveList": SaveList(); break;
                case "ExportList": ExportList(); break;
                
                case "ExportToCodex":
                    {
                        //MessageBox.Show(ActiveProgram.ToString() );
                        switch (ActiveProgram)
                        {
                            case 2: ShowInNewWindows(2, CodexDocumentID, CodexDocumentCaption, ""); break;
                            
                            
                        }
                    } break; // xxx

                
                case "OpenHere" : OpenHere(); break;

                case "OpenNew":  OpenNew();  break;

                case "DatabaseRefresh":
                    LoadTables();
                    
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


            }

        }

        private void AttachProcess()
        {
            if (F_Codex_DOC.listView1.SelectedItems.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("აირჩიეთ ფაილი");
                return;
            }
             
            //C1.C1Zip.C1ZipFile zf3 = new C1.C1Zip.C1ZipFile();
            //zf3.Open(ZipFileName);
            string str = F_Codex_DOC.listView1.SelectedItems[0].Text.ToString().Trim();

            string Suffix = "";
            string fn = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDocumentDir + @"\"+Suffix +str;
            int i = 1;
            while (System.IO.File.Exists(fn) == true)
                //(File.Exists(fn + "_" + i.ToString() + ".Doc") == true) 
            {
                fn = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDocumentDir + @"\" + i.ToString() + str;
                fn = fn.Replace("?", "_");
                i++;
            }

            fn = fn.Replace("?", "_");
            ZipArchive zipfile = new ZipArchive(new DiskFile(ZipFileName));
            AbstractFile f = zipfile.GetFile(str);
            DiskFile FF1 = new DiskFile(fn);
            f.CopyTo(FF1, true);

            //zf3.Entries.Extract(str,fn);
            //zf3.Close();
            System.Diagnostics.Process.Start(fn);
             
        }

        private void AttachSave()
        {
            if (F_Codex_DOC.listView1.SelectedItems.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("აირჩიეთ ფაილი");
                return;
            }


    //        C1.C1Zip.C1ZipFile zf3 = new C1.C1Zip.C1ZipFile();
      //      zf3.Open(ZipFileName);
            string str = F_Codex_DOC.listView1.SelectedItems[0].Text.ToString().Trim();

            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;
            string Path = "";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                Path = fd.SelectedPath;// zf3.Entries.Extract(str, fd.FileName);
            }
            else return;

            string fn = Path + @"\" + "" + str;
            fn = fn.Replace("?", "_");
            int i = 1;
            while (System.IO.File.Exists(fn) == true)
            //(File.Exists(fn + "_" + i.ToString() + ".Doc") == true) 
            {
                fn = Path + @"\" + i.ToString() + str;
                i++;

            }

            ZipArchive zipfile = new ZipArchive(new DiskFile(ZipFileName));
            AbstractFile f = zipfile.GetFile(str);
            DiskFile FF1 = new DiskFile(fn);
            f.CopyTo(FF1, true);

//            zf3.Entries.Extract(str, fn);
  //          zf3.Close();

            ILG.Windows.Forms.ILGMessageBox.Show("ფაილი ჩაწერილია");
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Panelss();
            switch (ActiveProgram)
            {   
                case 2: ZoomingCodex(); break;
            }
                
        }

        public void CaptionGeneration()
        {
            string Ind = "  ";
            if (ForceExit == true) Ind = ". ";
            switch (ActiveProgram)
            {
                // Codex 2007
                case 2:
                    #region Codex
                    {
                        switch ( CodexTab.ActiveTab.Index) 
                        {
                            case 0: /* Find Form */ this.Text = Ind + "კოდექსი 2007"; break;
                            case 1: /* List Form */ this.Text = Ind + "კოდექსი 2007 დოკუმენტების სია"; break;
                            case 2: /* Document Form */ this.Text = Ind + CodexDocumentCaption; break;
                        }
                    }

                
                    #endregion Codex
                    break; // Codex 2007
                
            }
                
        

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
                ActiveProgram = 2;// MainTabs.ActiveTab.Index;


                if (ForceExit == false) { LoadTreeData(); FavoritesLoaded = true; }
                if (ForceExit == false) { LoadHistoryData(); FavoritesLoaded = true; }
                CaptionGeneration();
            }

            ActiveProgram = 2;

            switch (ActiveProgram)
            {

                
                // Codex 2007
                case 2:
                    #region Codex
                    {
                        switch ( CodexTab.ActiveTab.Index) 
                        {
                            case 0: /* Find Form */ 
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCODEX_DataBase"].Visible = true;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCODEX_List"].Visible = false;

                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = false;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Cliboard"].Visible = false;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Export"].Visible = false;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Edit"].Visible = false;
                                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = false;

                                CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["Save"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = false;
                                CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = false;

                                if (License.IsNewDocumentAllow() == true)
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

                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Cliboard"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Export"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Edit"].Visible = false;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["XDOC"].Visible = false;

                              CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = false;
                              CodexToolBar.Tools["Save"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = false;
                              CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = false;
                              CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = false;

                              if (License.IsNewDocumentAllow() == true)
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

                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = true;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Cliboard"].Visible = true;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Export"].Visible = true;
                              CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_Edit"].Visible = true;

                              CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["Save"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = true;
                              CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = true;

                              if (License.DocumentOperation() == true)
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


                              if (License.IsNewDocumentAllow() == true)
                              {
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Enabled = true;
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Visible = true;

                              }
                              else
                              {
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Enabled = false;
                                  CodexToolBar.Tools["DOCAE"].SharedProps.Visible = false;
                              }


                              if (License.IsDocumentEditAllow() == true)
                              {
                                  CodexToolBar.Tools["ChangeDocument"].SharedProps.Enabled = true;
                                  CodexToolBar.Tools["ChangeDocument"].SharedProps.Visible = true;
                              }
                              else
                              {
                                  CodexToolBar.Tools["ChangeDocument"].SharedProps.Enabled = false;
                                  CodexToolBar.Tools["ChangeDocument"].SharedProps.Visible = false;
                              }


                              if (License.IsDocumentDeletetAllow() == true)
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
                
                    break; // Codex 2007

            }
                
        }

        private void Panelss()
        {
            Codex_Search_Panel.Left = (Codex_Search_Panel.Parent.ClientSize.Width - Codex_Search_Panel.Width) / 2;
        }


        
        private void LanguageSwitcher_SelectionChanged(object sender, EventArgs e)
        {
            switch (LanguageSwitcher.SelectedIndex)
            {
                case 0:
                    ILG.Codex.KeyBoard.Layout.SetEnglish();
                    break;

                case 1:
                    ILG.Codex.KeyBoard.Layout.SetGeorgianLat();
                    break;

                case 2:
                    ILG.Codex.KeyBoard.Layout.SetGeorgianRus();
                    break;

                case 3:
                    ILG.Codex.KeyBoard.Layout.SetRussian();
                    break;
            }
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
        DataSet Codex_Result;
        
        private void Codex_FillResult(String strcmd)
        {
            SqlDataAdapter daCodex = new SqlDataAdapter(strcmd, global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
            daCodex.SelectCommand.CommandTimeout = 7200;
            Codex_Result = new DataSet();
            try
            {
                daCodex.Fill(Codex_Result);
            }
            catch (System.Exception ex)
            {
                bool UseFullText = global::ILG.Codex.Codex2007.Properties.Settings.Default.UseFullTextSearch;
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
                if (ILG.Codex.Codex2007.Properties.Settings.Default.ShowAdvancedAttributes == true)
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
                        if (License.IsDocumentIDShowInList() == true) IDACCESS = "[ID=" + IDX.ToString();
                    }
                    else
                    {
                        if (License.IsConfidentialDocumentIDShowInList() == true) IDACCESS = " [ID=" + IDX.ToString();
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
            switch (ActiveProgram)
            {
                case 2: this.CodexTab.SelectedTab = this.CodexTab.Tabs[0]; CodexPos = 0; break;
            }
        }

        

 
        private void CallList()
        {
            switch (ActiveProgram)
            {
                case 2: this.CodexTab.SelectedTab = this.CodexTab.Tabs[1]; CodexPos = 1; break;
            }
        }


        public void DetermineSpecialView()
        {
            if (License.IsDocumentViewRestrictedMode() == true)
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
                
                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = true;
                
                CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = true;
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

                CodexToolBar.Ribbon.Tabs["RCODEX"].Groups["RCodex_View"].Visible = false;
                
                CodexToolBar.Tools["PrintMenu"].SharedProps.Enabled = false;
                CodexToolBar.Tools["Save"].SharedProps.Enabled = false;
                CodexToolBar.Tools["AddtoFavorites"].SharedProps.Enabled = true;
                CodexToolBar.Tools["ExportToCodex"].SharedProps.Enabled = false;
                CodexToolBar.Tools["ExportToWord"].SharedProps.Enabled = false;
                CodexToolBar.Tools["ExportPDF"].SharedProps.Enabled = false;
                CodexToolBar.Tools["SelectAll"].SharedProps.Enabled = false;
                CodexToolBar.Tools["FindDocument"].SharedProps.Enabled = false;
                CodexToolBar.Tools["Copy"].SharedProps.Enabled = false;
                  
                
            }
        }



        // სიისდან გამოძახებული დოკუმენტების ნავიგაცია  ყოველთვის იყწება ახლიდან
        public void codexListBox1_DocumentClick(object sender, CodexListEventArgs e)
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
            if (ZX == -1000) return;
            AddtoHistory(e._ID, e._TCaption, e._DCaption);
            CodexLoadDoc(doc, link, linkscema, e._TCaption, e._DCaption);
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[2];
            CodexPos = 2;
            CodexDocsNav.newdoc(e._ID, e._TCaption, e._DCaption);
            DeterminePDFRTFMenu();
        }
        // გახსნა ახალ ფანჯარაში ისტორიაში არ ვარდება
        public void codexListBox1_DocumentClick3(object sender, CodexListEventArgs e)
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
            CodexLoadDoc(doc, link, linkscema, e._TCaption, e._DCaption);
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[2];
            CodexPos = 2;
            CodexDocsNav.newdoc(e._ID, e._TCaption, e._DCaption);
            DeterminePDFRTFMenu();
        }

        public void codexListBox1_DocumentClick2(CodexListEventArgs e, bool append)
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
            if (ZX == -1000) return;
            CodexLoadDoc(doc, link, linkscema, e._TCaption, e._DCaption);
            AddtoHistory(CodexDocumentID, CodexDocumentCaption, Codex_DocumentTitle);
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[2];
            CodexPos = 2;
            if (append == true)
                CodexDocsNav.adddoc(e._ID, e._TCaption, e._DCaption);
            DeterminePDFRTFMenu();
        }



        public void RefreshDoc()
        {
            string doc = "";
            string link = "";
            string linkscema = "";
            int ZX = CodexOpenDocument(CodexDocumentID, ref doc, ref link, ref linkscema);
            if (ZX != 0) { HomeClick(); return; }
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
                case "RCodex": this.MainTabs.SelectedTab = this.MainTabs.Tabs[0]; ActiveProgram = 2; break;
               
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
                e.KeyChar = ILG.Codex.KeyBoard.Layout.U[e.KeyChar];
            }

        }

        private void ConfigurationCall()
        {
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.IsOptions == true)
            {
                Configuration f = new Configuration();
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
            switch (ActiveProgram)
            {
                case 2: codexListBox1_DocumentClick2(new CodexListEventArgs(F_Codex_DOC.CodexLinkBox.Active_LinkTo, "", ""), true); break;
                case 0: break;
            }
        }


        public void OpenNew()
        {
            switch (ActiveProgram)
            {
                case 2: ShowInNewWindows(2, F_Codex_DOC.CodexLinkBox.Active_LinkTo, "", ""); break;
                case 0:  break;
            }
        }

        
        public void CodexLinkBox_DocumentClick(object sender, ILG.Codex.LinkListBox.LinkListEventArgs e)
        {
            codexListBox1_DocumentClick2(new CodexListEventArgs(e._LinkTo, "<" + e._Caption + ">", ""), true);
        }

     
        private void ultraDockManager1_PropertyChanged(object sender, Infragistics.Win.PropertyChangedEventArgs e)
        {
            modify_zoomfactor();
        }

        private void CodexFindTab_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ICG_News_Button_Click(object sender, EventArgs e)
        {
            if (ICG_News_Check.Checked == true)
            {
                if (Codex_Date1 > Codex_Date2) { ILG.Windows.Forms.ILGMessageBox.Show("თარიღის ინტერვალი არასოწრია !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }
                if ((Codex_Number_Edit.Text.Trim() != "") && (CodexString.CheckNumStr(Codex_Number_Edit.Text) == false)) { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის შესაძლო ნომერი არასწორედაა მითითებული !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }

            }

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Codex_FillResult(Codex_GenerateNewsSQL());
            this.Cursor = System.Windows.Forms.Cursors.Default;

            int maxlist = (int)global::ILG.Codex.Codex2007.Properties.Settings.Default.MaximumDocListCodex;
            if (Codex_Result.Tables[0].Rows.Count == 0) { ILG.Windows.Forms.ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); return; }
            if (Codex_Result.Tables[0].Rows.Count >= maxlist)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მოძებნილი დოკუმენტების რაოდენობა მეტია " + maxlist.ToString() + " - ზე  [" + Codex_Result.Tables[0].Rows.Count.ToString() + "] " +
                                                              "  \n გთხოვთ დააკონკრეტოთ ძებნის პარამეტრები ");
                return;
            }

            CodexSorting(0);
            CodexList = true;
            CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიახლის სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            CodexToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "ახალი დოკუმენტები დალაგებულია";
            //Codex_List_SortLabel CodexListStatus.Text = "ახალი დოკუმენტები დალაგებულია";
            isnews = true;
            CodexPos = 1;
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[1];
            this.codexListBox1.Visited = this.CodexVisited;
            this.codexListBox1.InitializeVarialbles(2);
            this.codexListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
            this.codexListBox1.FillGrid();


        }

      


    }
}