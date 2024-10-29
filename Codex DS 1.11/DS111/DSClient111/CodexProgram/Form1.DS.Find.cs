using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DS.Configurations;
using ILG.DS.Strings;
using ILG.DS.Favorites;
using ILG.DS.AppStateManagement;
using ILG.DS.Controls;
using ILG.DS.Configurations;

namespace ILG.Codex.CodexR4
{
    partial class Form1
    {
        #region Codex Values
        DateTime Codex_Date1;
        DateTime Codex_Date2;
        string Codex_AutorSQL = "";
        string Codex_TypeSQL = "";
        string Codex_SubjectSQL = "";
        string Codex_WordSQL = "";
        string Codex_CategorySQL = "";
        string Codex_StatusSQL = "";
        int Codex_FilterV = 0;
        bool Codex_FullTextV = false;
        //int Codex_NewsN = 2;
        //int Codex_News_ComboV = 0;

        #endregion Codex Values
        

        public void DefaultSearchParameters()
        {
            Codex_Date1 = new DateTime(1973, 1, 1);
            Codex_Date2 = DateTime.Now;
            Codex_FilterV = 0;
            Codex_FullTextV = false;

            DS_NewsN = 1;
            DS_News_ComboV = 1;
        }

   
        public void DisplayParameters()
        {
            DS_Date_Edit1.Text = PickDate.DateToString(Codex_Date1);
            DS_Date_Edit2.Text = PickDate.DateToString(Codex_Date2);


            
            
            //Codex_Filer.SelectedIndex = Codex_FilterV;
            
            if (Codex_FullTextV) DS_Search_Combo.SelectedIndex = 1; else DS_Search_Combo.SelectedIndex = 0;
            
            
            // Codex Info
            DSToolBar.Tools["Codex_Info_Label1"].SharedProps.Caption = " ბაზაში არის " + LockupTables.Tables["CodexDS2007"].Rows[0]["C_CodexDSDocs"].ToString() + " დოკუმენტი";
            DSToolBar.Tools["Codex_Info_Date"].SharedProps.Caption = " ბოლო განახლება (" + PickDate.DateToString((DateTime)LockupTables.Tables["CodexDS2007"].Rows[0]["C_Date"]) + ")";

            if (Policy_ShowHistory == true)
            {
                DSToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = " ისტორიაში არის " + CountForHistoryDocuments.ToString() + " დოკუმენტი";
            }

            if (app.state.RunTimeLicense.IsHistoryAccessGranted() == false)
            {
                DSToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = "ისტორიაზე არ გაქვთ დაშვება ";
            }

            DS_News_Combo.SelectedIndex = DS_News_ComboV;
            DS_News_Edit.Value = DS_NewsN;

 

        }


        public void DisplayParametersLimited()
        {
            DSToolBar.Tools["Codex_Info_Label1"].SharedProps.Caption = " ბაზაში არის " + LockupTables.Tables["CodexDS2007"].Rows[0]["C_CodexDSDocs"].ToString() + " დოკუმენტი";
            DSToolBar.Tools["Codex_Info_Date"].SharedProps.Caption = " ბოლო განახლება (" + PickDate.DateToString((DateTime)LockupTables.Tables["CodexDS2007"].Rows[0]["C_Date"]) + ")";

            if (Policy_ShowHistory == true)
            {
                DSToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = " ისტორიაში არის " + CountForHistoryDocuments.ToString() + " დოკუმენტი";
            }


            if (app.state.RunTimeLicense.IsHistoryAccessGranted() == false)
            {
                DSToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = "ისტორიაზე არ გაქვთ დაშვება ";
            }
        }


        private void Codex_Search_Button_Click(object sender, EventArgs e)
        {
            if (Codex_Date1 > Codex_Date2) { ILGMessageBox.Show("თარიღის ინტერვალი არასწორია !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }


            //if ((DS_Number_Edit.Text.Trim() != "") && (CodexString.CheckNumStr(DS_Number_Edit.Text) == false)) { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის შესაძლო ნომერი არასწორედაა მითითებული !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }

            bool UseFullText = app.state.UseFullTextSearch;
            if ((DS_Search_Combo.SelectedIndex == 1) && (UseFullText == false))
            {
                if (ILGMessageBox.Show("თქვენ მონიშნული გაქვთ დოკუმენტის ტექსტში ძებნა, \n" +
                    "რაც დაიკავებს უფრო მეტ დროს ვიდრე ჩვეულებრივი ძებნის რეჟიმი\n" +
                    "ამ სახით ძებნამ შეიძლება დაიკავოს რამოდენიმე წუთი\n" +
                    "გსურთ გაგრძელება ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;
            }

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Codex_FillResult(Codex_GenerateFindSQL());
            this.Cursor = System.Windows.Forms.Cursors.Default;

            int maxlist = app.state.UISettingsManager.content.ui_max_list;
            if (Codex_Result.Tables[0].Rows.Count == 0) { ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); return; }
            if (Codex_Result.Tables[0].Rows.Count >= maxlist)
            {
                //ILG.Windows.Forms.ILGMessageBox.Show("მოძებნილი დოკუმენტების რაოდენობა მეტია " + maxlist.ToString() + " - ზე  [" + Codex_Result.Tables[0].Rows.Count.ToString() + "] " +
                //                                              "  \n გთხოვთ დააკონკრეტოთ ძებნის პარამეტრები  ");
                //return;
                if ((ILGMessageBox.Show("მოძებნილი დოკუმენტების რაოდენობა მეტია " + maxlist.ToString() + " - ზე  " + System.Environment.NewLine +
                  "გთხოვთ დააკონკრეტოთ ძებნის პარამეტრები ან დააჭირეთ ღილაკს <უარი> და ეკრანზე გამოვა მხოლოდ პირველი " + maxlist.ToString() + " დოკუმენტი", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK))
                {
                    return;
                }

            }


            // Codex Navigation 1
            CodexSorting(0);
            DSToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            DSToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "მოძებნილი დოკუმენტები დალაგებულია";
                //CodexListStatus.Text = "მოძებნილი დოკუმენტები დალაგებულია";
            isnews = false;
            //this.ultraGrid1.DataSource = Codex_Result.Tables[0];
            this.DSTab.SelectedTab = this.DSTab.Tabs[1];
            CodexPos = 1;
            CodexList = true;



            //this.F_DS_List.DocumentListBox1.Visited = this.DSVisited;
            //this.F_DS_List.DocumentListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, app.state.RunTimeLicense.IsHistoryAccessGranted());
            //this.F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
            //this.F_DS_List.DocumentListBox1.FillGrid();


            //F_DS_List.DocumentListBox1.ShowIDMode = _InternalMode;
            F_DS_List.DocumentListBox1.Visited = this.DSVisited;
            F_DS_List.DocumentListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, app.state.RunTimeLicense.IsHistoryAccessGranted());
            F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
            F_DS_List.SetZoomFactor(DS_List_ZoomFactor);
            F_DS_List.DocumentListBox1.FillGrid(_NewDocuments);
            //F_DS_List.Panel_Preview_Dock();

        }

        void RefreashList()
        {
            if (isnews == false)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Codex_FillResult(Codex_GenerateFindSQL());
                this.Cursor = System.Windows.Forms.Cursors.Default;

                int maxlist = app.state.UISettingsManager.content.ui_max_list;
                if (Codex_Result.Tables[0].Rows.Count == 0) { ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); HomeClick(); return; }

                // Codex Navigation 1
                CodexSorting(0);
                DSToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
                DSToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "მოძებნილი დოკუმენტები დალაგებულია";
                //CodexListStatus.Text = "მოძებნილი დოკუმენტები დალაგებულია";
                isnews = false;
                //this.ultraGrid1.DataSource = Codex_Result.Tables[0];
                this.DSTab.SelectedTab = this.DSTab.Tabs[1];
                CodexPos = 1;
                CodexList = true;
                this.F_DS_List.DocumentListBox1.Visited = this.DSVisited;
                this.F_DS_List.DocumentListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, app.state.RunTimeLicense.IsHistoryAccessGranted());//(2);
                this.F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
                this.F_DS_List.DocumentListBox1.FillGrid();
            }
            else
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Codex_FillResult(Codex_GenerateNewsSQL());
                this.Cursor = System.Windows.Forms.Cursors.Default;

                int maxlist = app.state.UISettingsManager.content.ui_max_list;
                if (Codex_Result.Tables[0].Rows.Count == 0) { ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); HomeClick(); return; }
                
                CodexSorting(0);
                CodexList = true;
                DSToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიახლის სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
                DSToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "ახალი დოკუმენტები დალაგებულია";
                //Codex_List_SortLabel CodexListStatus.Text = "ახალი დოკუმენტები დალაგებულია";
                isnews = true;
                CodexPos = 1;
                this.DSTab.SelectedTab = this.DSTab.Tabs[1];
                this.F_DS_List.DocumentListBox1.Visited = this.DSVisited;
                this.F_DS_List.DocumentListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, app.state.RunTimeLicense.IsHistoryAccessGranted());// 2);
                this.F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
                this.F_DS_List.DocumentListBox1.FillGrid();
            }
        }

        #region PopUpMenus
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.DSToolBar.ShowPopup("Keyboard3", this);
        }

        private void Keboard4Popup_Opening(object sender, CancelEventArgs e)
        {
            this.DSToolBar.ShowPopup("Keyboard4", this);
        }

        private void CodexDateRange_Opening(object sender, CancelEventArgs e)
        {
            this.DSToolBar.ShowPopup("Codex_Date_Range", this);
        }

        private void CGLDateRange_Opening(object sender, CancelEventArgs e)
        {
            this.DSToolBar.ShowPopup("CGL_Date_Range", this);
        }

       
        private void CodexFind_Opening(object sender, CancelEventArgs e)
        {
            this.DSToolBar.ShowPopup("Codex_Find_PopUp", this);
        }

        private void CGLFind_Opening(object sender, CancelEventArgs e)
        {
            this.DSToolBar.ShowPopup("CGL_Find_PopUp", this);
        }

       



        #endregion PopUpMenus

        #region Data Pickers
        private void Codex_Date_Button1_Click(object sender, EventArgs e)
        {
            var dlg2 = new PickDate(Codex_Date1);
            Point dc2 = new Point(DS_Date_Edit1.Location.X, DS_Date_Edit1.Location.Y);
            Point dc = DS_Search_Panel.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            DS_Date_Edit1.Text = dlg2.ToString();
            Codex_Date1 = dlg2.PickedDate;
        }


        private void Codex_Date_Button2_Click(object sender, EventArgs e)
        {
            var dlg2 = new PickDate(Codex_Date2);
            Point dc2 = new Point(DS_Date_Edit2.Location.X, DS_Date_Edit2.Location.Y);
            Point dc = DS_Search_Panel.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            DS_Date_Edit2.Text = dlg2.ToString();
            Codex_Date2 = dlg2.PickedDate;


        }


       
        #endregion Data Pickers

        #region List Pickers
        private void Codex_Autor_Button_Click(object sender, EventArgs e)
        {

            Point dc2 = new Point(DS_Autor_Edit.Location.X, DS_Autor_Edit.Location.Y);
            Point dc = DS_Search_Panel.PointToScreen(dc2);

            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DAuthor"], 0, "A_ID", "C_AUTHOR", "A_Caption", "მიმღები ორგანო", " ", dc.X, dc.Y, DS_Autor_Edit.Width + DS_Autor_Button.Width,"");

            f1.ShowDialog();
            if (f1.canceled == false)
            {
                DS_Autor_Edit.Text = f1.ToString();
                Codex_AutorSQL = f1.ToSQLString();

                if (f1.ToWhat() == 0) DS_Autor_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) DS_Autor_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) DS_Autor_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        private void Codex_Type_Button_Click(object sender, EventArgs e)
        {
            Point dc2 = new Point(DS_Type_Edit.Location.X, DS_Type_Edit.Location.Y);
            Point dc = DS_Search_Panel.PointToScreen(dc2);


            //String FilterParameter = "";
            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DType"], 0, "T_ID", "C_Type", "T_Caption", "დოკუმენტის სახე", " ", dc.X, dc.Y, DS_Type_Edit.Width + DS_Type_Button.Width,"");

            f1.ShowDialog();
            if (f1.canceled == false)
            {
                DS_Type_Edit.Text = f1.ToString();
                Codex_TypeSQL = f1.ToSQLString();

                if (f1.ToWhat() == 0) DS_Type_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) DS_Type_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) DS_Type_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        private void Codex_Subject_Button_Click(object sender, EventArgs e)
        {
            Point dc2 = new Point(DS_Subject_Edit.Location.X, DS_Subject_Edit.Location.Y);
            Point dc = DS_Search_Panel.PointToScreen(dc2);


            //String FilterParameter = "";
            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DSubject"], 0, "S_ID", "C_Subject", "S_Caption", "თემატიკა", " ", dc.X, dc.Y, DS_Subject_Edit.Width + DS_Subject_Button.Width,"");


            f1.ShowDialog();
            if (f1.canceled == false)
            {
                DS_Subject_Edit.Text = f1.ToString();
                Codex_SubjectSQL = f1.ToSQLString();

                if (f1.ToWhat() == 0) DS_Subject_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) DS_Subject_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) DS_Subject_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        private void Codex_Word_Button_Click(object sender, EventArgs e)
        {

            Point dc2 = new Point(DS_Word_Edit.Location.X, DS_Word_Edit.Location.Y);
            Point dc = DS_Search_Panel.PointToScreen(dc2);


            //String FilterParameter = "";
            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DWords"], 1, "W_ID", "C_Words", "W_Caption", "საკვანძო სიტყვა/ები", " ", dc.X, dc.Y, DS_Word_Edit.Width + DS_Word_Button.Width,"");


            f1.ShowDialog();
            if (f1.canceled == false)
            {
                DS_Word_Edit.Text = f1.ToString();
                Codex_WordSQL = f1.ToSQLString();

                if (f1.ToWhat() == 0) DS_Word_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) DS_Word_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) DS_Word_Edit.Appearance.ForeColor = Color.Red;
            }
        }


        private void Codex_Category_Button_Click(object sender, EventArgs e)
        {
            Point dc2 = new Point(DS_Category_Edit.Location.X, DS_Category_Edit.Location.Y);
            Point dc = DS_Search_Panel.PointToScreen(dc2);

            //String FilterParameter = "";

            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DCategory"], 0, "C_ID", "C_Category", "C_Caption", "დოკუმენტის კატეგორია", " ", dc.X, dc.Y, DS_Category_Edit.Width + DS_Category_Button.Width,"");

            f1.ShowDialog();
            if (f1.canceled == false)
            {
                DS_Category_Edit.Text = f1.ToString();

                Codex_CategorySQL = f1.ToSQLString(); ;
                if (f1.ToWhat() == 0) DS_Category_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) DS_Category_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) DS_Category_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        private void Codex_Status_Button_Click(object sender, EventArgs e)
        {
            Point dc2 = new Point(DS_Status_Edit.Location.X, DS_Status_Edit.Location.Y);
            Point dc = DS_Search_Panel.PointToScreen(dc2);


            //String FilterParameter = "";
            //if (e != null) FilterParameter = e.KeyChar.ToString();


            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DStatus"], 0, "C_ID", "C_Status", "C_Caption", "დოკუმენტის სტატუსი", " ", dc.X, dc.Y, DS_Status_Edit.Width + DS_Status_Button.Width,"");

            f1.ShowDialog();
            if (f1.canceled == false)
            {
                DS_Status_Edit.Text = f1.ToString();

                Codex_StatusSQL = f1.ToSQLString(); ;
                if (f1.ToWhat() == 0) DS_Status_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) DS_Status_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) DS_Status_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        
        #endregion List Pickers

        private void Codex_Number_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
            //if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar <= ' ') || (e.KeyChar == '-') || (e.KeyChar == ',')) e.Handled = false;
            e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
        }

        #region  DateRanges
        #region Codex
        public void Codex_Do_DateEqual()
        {
            if ((this.DS_Date_Edit1.Focused == false) && (this.DS_Date_Edit2.Focused == false))
            {
                ILGMessageBox.Show("მიუთითეთ, რომელიმე თარიღი");
                return;
            }

            if (this.DS_Date_Edit2.Focused == true)
            {
                Codex_Date1 = new DateTime(Codex_Date2.Year, Codex_Date2.Month, Codex_Date2.Day);
            }

            if (this.DS_Date_Edit1.Focused == true)
            {
                Codex_Date2 = new DateTime(Codex_Date1.Year, Codex_Date1.Month, Codex_Date1.Day);
            }

            DS_Date_Edit1.Text = PickDate.DateToString(Codex_Date1);
            DS_Date_Edit2.Text = PickDate.DateToString(Codex_Date2);

        }


        public void Codex_Do_DataRanges(int i)
        {
            int m;
            int y;
            int d;
            switch (i)
            {

                case 0: Codex_Date2 = DateTime.Now;
                    m = Codex_Date2.Month;
                    y = Codex_Date2.Year;
                    d = Codex_Date2.Day;
                    if (m == 1) { m = 12; y--; }
                    else m--;

                    if ((m == 2) && (m >= 29)) d = 28;
                    if (d == 31) d = 30;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // last month

                case 1: Codex_Date2 = DateTime.Now;
                    m = Codex_Date2.Month;
                    y = Codex_Date2.Year;
                    d = Codex_Date2.Day;
                    if (m == 2) { m = 12; y--; }
                    else
                    {
                        if (m == 1) { m = 11; y--; }
                        else m--; m--;
                    }

                    if ((m == 2) && (m >= 29)) d = 28;
                    if (d == 31) d = 30;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // last two month

                case 2: Codex_Date2 = DateTime.Now;
                    m = Codex_Date2.Month;
                    y = Codex_Date2.Year - 1;
                    d = Codex_Date2.Day;

                    if ((m == 2) && (m == 29)) d = 28;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // last  year

                case 3: Codex_Date2 = DateTime.Now;
                    m = Codex_Date2.Month;
                    y = Codex_Date2.Year - 2;
                    d = Codex_Date2.Day;

                    if ((m == 2) && (m == 29)) d = 28;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // last two year

                case 4: Codex_Date2 = DateTime.Now;
                    m = 8;
                    y = 1995;
                    d = 24;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // last 1995-today

                case 5: Codex_Date2 = DateTime.Now;
                    m = 1;
                    y = 1990;
                    d = 1;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // Full interval
                case 6: Codex_Date2 = DateTime.Now;
                    m = 1;
                    y = 1973;
                    d = 1;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // Full interval 2
            }

            DS_Date_Edit1.Text = PickDate.DateToString(Codex_Date1);
            DS_Date_Edit2.Text = PickDate.DateToString(Codex_Date2);

        }


        #endregion Codex

  
        
        #endregion  DateRanges

        #region Find Resetst

        #region Codex

        public void Codex_DefaultSearchParameters()
        {

            // Logical
            Codex_FilterV = 0;
            Codex_FullTextV = false;
            Codex_AutorSQL = "";
            Codex_TypeSQL = "";
            Codex_SubjectSQL = "";
            Codex_WordSQL = "";
            Codex_FilterV = 0;
            Codex_FullTextV = false;
            Codex_CategorySQL = "";
            Codex_StatusSQL = "";

            
            // Visual
            DS_Search_Edit.Text = "";
            DS_Autor_Edit.Text = "";
            DS_Type_Edit.Text = "";
            DS_Subject_Edit.Text = "";
            DS_Word_Edit.Text = "";
            DS_Number_Edit.Text = "";
            DS_Status_Edit.Text = "";
            DS_Category_Edit.Text = "";
            DS_Comment_Edit.Text = "";
            DS_Attrib_Edit.Text = "";
            Codex_Do_DataRanges(6);
            DS_Search_Combo.SelectedIndex = 0; // Find in Caption
            DS_AccessCombo.SelectedIndex = 0;
            //Codex_Filer.SelectedIndex = Codex_FilterV;


            // New In 1.5.5
            if (DSBehaviorConfiguration.Instance.content.Attributes.IsDefaultParameterStatus == true)
            {
                SetStatusDefault(DSBehaviorConfiguration.Instance.content.Attributes.DefaultStatus);
            }

        }


        class AttributePair
        {
            public int Id { get; set; }
            public String Caption { get; set; }
        }
        private void SetStatusDefault(string ListofTheIds)
        {
            if (ListofTheIds.Trim() == "") return;

            List<AttributePair> items = new List<AttributePair>();
            using (SqlConnection cn = new SqlConnection(app.state.ConnectionString))
            {
                cn.Open();
                String SQL = $"SELECT C_ID, C_ORDER, C_CAPTION FROM [CodexDS_DStatus] WHERE C_ID IN ({ListofTheIds})";
                SqlCommand cm = new SqlCommand(SQL, cn);
                SqlDataReader reader = cm.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(new AttributePair { Id = (int)reader["C_ID"], Caption = (string)reader["C_CAPTION"] });
                }
            }


            string Codex_Status_Edit_Str = "";
            DictionaryToParameterStatus(items, out Codex_Status_Edit_Str, out Codex_StatusSQL);

            DS_Status_Edit.Text = Codex_Status_Edit_Str;


            return;
        }



        private void DictionaryToParameterStatus(List<AttributePair> PairList, out string DisplayString, out string SQLString)
        {
            DisplayString = "";
            SQLString = "";


            if (PairList.Count == 0)
            {
                return;
            }

            if (PairList.Count == 1)
            {
                if ((PairList[0].Id != 0) || (PairList[0].Caption.Trim() != ""))
                {
                    SQLString = " (  C_STATUS   = " + PairList[0].Id.ToString() + " )";
                    DisplayString = PairList[0].Caption.Trim();
                }
                return;
            }

            if (PairList.Count > 1)
            {
                for (int i = 0; i < PairList.Count; i++)
                {
                    if (PairList[i].Caption.ToString().Trim() == "") continue;
                    DisplayString += PairList[i].Caption.Trim();
                    if (i != PairList.Count - 1) DisplayString += ", ";
                    // SQL Generation
                    SQLString += " ( C_STATUS " + " = " + PairList[i].Id.ToString().Trim() + " ) ";
                    if (i != PairList.Count - 1) SQLString += " OR ";
                }
            }

            return;
        }

        #endregion Codex




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ForceExit == false) SaveTreeData();
            if (ForceExit == true) e.Cancel = false;
            else
            {
                if (ForceExit == false) SaveHistoryData(); // Save History
                if (ForceExit == false) SaveTreeData(); // Save Favorites
                //if (ForceExit == false) SaveDcoksSettings(); // Save Docks Settings
                if (ILGMessageBox.Show("პროგრამიდან გამოსვლა,\nდარწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HomeClick();
                    if (F_DS_DOC.LoadedPDFDoc != "") { try { File.Delete(F_DS_DOC.LoadedPDFDoc); } catch { }; }
                    e.Cancel = false;
                }
                else e.Cancel = true;
            }
        }

        #endregion Find Resetst

        #region Find SQL Srtipt Generation
        #region Codex

        private string Get_ShowHistoryFiled()
        {
            string ResultSQL = ", 0 AS C_ShowHistory ";
            if (app.state.RunTimeLicense.IsHistoryAccessGranted() == false) return ResultSQL;

            String HistoryPublicSQL = ", (CASE " +
                               "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NULL THEN 0 " +
                               "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL THEN  (Select Count (C_ID) From CodexDS_DDOCS_History Where (CodexDS_DDOCS_History.C_ID = CodexDS_DDOCS.C_ID AND CodexDS_DDOCS_History.H_Status = 0) )" +
                               "   ELSE 0 " +
                               "END) as  C_ShowHistory ";

            if (app.state.RunTimeLicense.IsHistoryExtendedAccessGranted() == false) return HistoryPublicSQL;

            String HistoryExtendedSQL = ", (CASE " +
                                        "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NULL THEN 0 " +
                                        "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL THEN  (Select Count (C_ID) From CodexDS_DDOCS_History Where ((CodexDS_DDOCS_History.C_ID = CodexDS_DDOCS.C_ID) AND ((CodexDS_DDOCS_History.H_Status = 0) OR (CodexDS_DDOCS_History.H_Status = 1) ) ))" +
                                        "   ELSE 0 " +
                                        "END) as  C_ShowHistory ";

            if (app.state.RunTimeLicense.IsRecoverDeletedDocumentsGranted() == false) return HistoryExtendedSQL;

            String HistoryFullSQL = ", (CASE " +
                                    "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NULL THEN 0 " +
                                    "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL THEN  (Select Count (C_ID) From CodexDS_DDOCS_History Where (CodexDS_DDOCS_History.C_ID = CodexDS_DDOCS.C_ID) )" +
                                    "   ELSE 0 " +
                                    "END) as  C_ShowHistory ";

            return HistoryFullSQL;
        }
        private String Codex_GenerateFindSQL()
        {



            String SpecialField = Get_ShowHistoryFiled();

            int Max_Document_in_Result_List = 1500;

            try
            {
                Max_Document_in_Result_List = app.state.UISettingsManager.content.ui_max_list;
                if (Max_Document_in_Result_List < 100) Max_Document_in_Result_List = 100;
                if (Max_Document_in_Result_List > 2500) Max_Document_in_Result_List = 2500;
            }
            catch
            {
                Max_Document_in_Result_List = 1500;
            }

            //String StrHeader = "SELECT TOP " + Max_Document_in_Result_List.ToString() + "   ";




            String Fields = "C_ID,C_Caption,C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat, C_DocText as DocText, (CASE (ISNULL(DATALENGTH(C_Attach),0)) WHEN 0 THEN 0  ELSE 1 END) AS L_AttachmentSize " + SpecialField;
            String StrHeader = $"SELECT TOP {Max_Document_in_Result_List} " + Fields + " FROM CODEXDS_DDOCS WHERE ";
            //StrHeader = StrHeader + Fields + " FROM CODEXDS_DDOCS WHERE ";
            String Strd = "( ( C_Date >= " +
                  "CONVERT(DATETIME, '" + Codex_Date1.Year.ToString() + @"-" + Codex_Date1.Month.ToString("00") + @"-" + Codex_Date1.Day.ToString("00") + "T00:00:00.000' ,126) )" +
                " and " +
                "( C_Date <= " +
                  "CONVERT(DATETIME, '" + Codex_Date2.Year.ToString() + @"-" + Codex_Date2.Month.ToString("00") + @"-" + Codex_Date2.Day.ToString("00") + "T23:59:59.997' ,126) )" + " ) ";

            String Strc = "And " + DSString.CaptionAnaliser(DS_Search_Edit.Text, "C_Caption", "'") + " ";

            if (this.DS_Search_Combo.SelectedIndex == 1) // if Full Text Sellected
            {
                bool UseFullTest = app.state.UseFullTextSearch;
                if (UseFullTest == false)
                {
                    Strc = "And (( C_DocText LIKE N'%" +
                    DSString.GeoUnitoGeo8(DS_Search_Edit.Text)
                    + "%') or   " +
                        " ( C_DocText LIKE N'%" +
                    DS_Search_Edit.Text
                    + "%'))";
                }
                else
                {
                    Strc = "And ( ( CONTAINS  (C_DocText , N'" + '"' +
                        DSString.GeoUnitoGeo8(DS_Search_Edit.Text)
                        + '*' + '"' + "  ')) or " +
                        "( CONTAINS  (C_DocText , N'" + '"' +
                        DS_Search_Edit.Text
                        + '*' + '"' + "  ')) )";

                }
            }

            if (DS_Search_Edit.Text.Trim() == "") Strc = "";

            String StrComment = "And " + DSString.CaptionAnaliser(DS_Comment_Edit.Text, "C_Coments", "'") + " ";
            if (DS_Comment_Edit.Text.Trim() == "") StrComment = "";

            String StrAdditional = "And " + DSString.CaptionAnaliser(DS_Attrib_Edit.Text, "C_Addtional", "'") + " ";
            if (DS_Attrib_Edit.Text.Trim() == "") StrAdditional = "";

             // PosPoned to next Version
            //String Strn = "And ( " + CodexString.NumAnaliser(DS_Number_Edit.Text, "C_Number", "'") + ") ";
            String Strn = "And ( C_NumberStr LIKE N'%" + DS_Number_Edit.Text.Trim() + "%') ";
            if (DS_Number_Edit.Text.Trim() == "") Strn = "";


            String Stra = " and ( " + Codex_AutorSQL + " ) ";
            if (Codex_AutorSQL.Trim() == "") Stra = "";

            String Strt = " and ( " + Codex_TypeSQL + " ) ";
            if (Codex_TypeSQL.Trim() == "") Strt = "";

            String Strs = " and ( " + Codex_SubjectSQL + " ) ";
            if (Codex_SubjectSQL.Trim() == "") Strs = "";

            String Strw = " and ( " + Codex_WordSQL + " ) ";
            if (Codex_WordSQL.Trim() == "") Strw = "";

            String StrST = " and ( " + Codex_StatusSQL + " ) ";
            if (Codex_StatusSQL.Trim() == "") StrST = "";

            String StrCT = " and ( " + Codex_CategorySQL + " ) ";
            if (Codex_CategorySQL.Trim() == "") StrCT = "";

            String StrComments = "And ( C_Coments LIKE N'%" + DS_Comment_Edit.Text.Trim() + "%') ";
            if (DS_Comment_Edit.Text.Trim() == "") StrComments = "";

            String StrAdvancedAttribute = "And ( C_Addtional LIKE N'%" + DS_Attrib_Edit.Text.Trim() + "%') ";
            if (DS_Attrib_Edit.Text.Trim() == "") StrAdvancedAttribute = "";


            bool RA = app.state.RunTimeLicense.IsConfidentialDocumentShowInList();

            
            String Strf = "";
            if (RA == false) Strf = " And (C_Group = 0)";
            if (RA == true)
            {
                if (DS_AccessCombo.SelectedIndex == 0) Strf = "";
                if (DS_AccessCombo.SelectedIndex == 1) Strf = " And (C_Group = 0)";
                if (DS_AccessCombo.SelectedIndex == 2) Strf = " And (C_Group = 1)";
            }


            string FullSQL = StrHeader + Strd + Strc + Strn + Stra + Strt + Strs + Strw + StrST + StrCT + StrComments+StrAdvancedAttribute + Strf;
       //     System.Windows.Forms.Clipboard.SetText(FullSQL);
         //   MessageBox.Show("N");
            return FullSQL;
            
        }

        private String Codex_GenerateNewsSQL()
        {
            //DateTime dd1 = DateTime.Now;
            DateTime dd1 = DS_FromNewsDate;
            if (DS_News_DateCheck.Checked == false) dd1 = DateTime.Now;

            TimeSpan ts = new TimeSpan(14, 0, 0);
            int factor = (Int32)this.DS_News_Edit.Value;

            switch (DS_News_Combo.SelectedIndex)
            {
                case 0: ts = new TimeSpan( factor, 0, 0, 0, 0); break;
                case 1: ts = new TimeSpan(7 * factor, 0, 0, 0, 0); break;
                case 2: ts = new TimeSpan(30 * factor, 0, 0, 0, 0); break;
                case 3: ts = new TimeSpan(92 * factor, 0, 0, 0, 0); break;
                case 4: ts = new TimeSpan(365 * factor, 0, 0, 0, 0); break;

            };

            DateTime dd3 = dd1 - ts;

            String SpecialField = Get_ShowHistoryFiled();


            int Max_Document_in_Result_List = 1500;

            try
            {
                Max_Document_in_Result_List = app.state.UISettingsManager.content.ui_max_list;
                if (Max_Document_in_Result_List < 100) Max_Document_in_Result_List = 100;
                if (Max_Document_in_Result_List > 2500) Max_Document_in_Result_List = 2500;
            }
            catch
            {
                Max_Document_in_Result_List = 1500;
            }


            String Fields = "C_ID,C_Caption,C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat,C_DocText as DocText, (CASE (ISNULL(DATALENGTH(C_Attach),0)) WHEN 0 THEN 0  ELSE 1 END) AS L_AttachmentSize " + SpecialField;
            //String StrHeader = "SELECT " + Fields + " FROM CODEXDS_DDOCS WHERE ";
            String StrHeader = $"SELECT TOP {Max_Document_in_Result_List} " + Fields + " FROM CODEXDS_DDOCS WHERE ";

            String Strd = "( ( C_EnterDate >= " +
                  "CONVERT(DATETIME, '" + dd3.Year.ToString() + @"-" + dd3.Month.ToString("00") + @"-" + dd3.Day.ToString("00") + "T00:00:00.000' ,126) )" +
                " and " +
                "( C_EnterDate <= " +
                  "CONVERT(DATETIME, '" + dd1.Year.ToString() + @"-" + dd1.Month.ToString("00") + @"-" + dd1.Day.ToString("00") + "T23:59:59.997' ,126) ) " + " ) ";

            String FullNewsSQL; 
            if (this.DS_News_Check.Checked == true)
                FullNewsSQL = Codex_GenerateFindSQL() + " and " + Strd;
            else
            {
                FullNewsSQL = StrHeader + Strd;
                bool RestrincAccess = app.state.RunTimeLicense.IsConfidentialDocumentShowInList();
                String Strf = "";
                if (RestrincAccess == false) Strf = " And (C_Group = 0)";
                FullNewsSQL = FullNewsSQL+ Strf;
                
            }

            return FullNewsSQL; 

        }

        private String DS_GenerateNewDocumentsQuery()
        {
            int offset = DSBehaviorConfiguration.Instance.content.NewDocumentNotification.new_document_notification; 
                

            DateTime from_date = DateTime.Now - TimeSpan.FromDays(offset);
            
            String StrHeader = $"SELECT C_ID FROM CODEXDS_DDOCS WHERE ";

            String Access = "";
            if (app.state.RunTimeLicense.IsEnterInConfidentialDocumentAlowed() == false)
            {
                Access = " (C_GROUP = 0) AND ";
            }

            String Strd = "(C_EnterDate >= " +
                  "CONVERT(DATETIME, '" + from_date.Year.ToString() + @"-" + from_date.Month.ToString("00") + @"-" + from_date.Day.ToString("00") + "T00:00:00.000' ,126)) ";
                  //"(C_LASTEDIT >= " +
                  //"CONVERT(DATETIME, '" + from_date.Year.ToString() + @"-" + from_date.Month.ToString("00") + @"-" + from_date.Day.ToString("00") + "T00:00:00.000' ,126)) "
                  //;

            return StrHeader + Access + Strd;
        }




        #endregion Codex



        #endregion Find SQL Srtipt Generation

        #region HotKeys Codex
        private void Codex_Date_Edit1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && ((e.Control == true) || (e.Alt == true)))
                Codex_Date_Button1_Click(null, null);

            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
                return;
            }


        }

        private void Codex_Date_Edit2_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && ((e.Control == true) || (e.Alt == true)))
                Codex_Date_Button2_Click(null, null);


            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }

        }

        private void Codex_Autor_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && ((e.Control == true) || (e.Alt == true)))
                Codex_Autor_Button_Click(null, null);
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Autor_Edit.Text = "";
                Codex_AutorSQL = "";
            }
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
        }

        private void Codex_Type_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && ((e.Control == true) || (e.Alt == true)))
                Codex_Type_Button_Click(null, null);
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Type_Edit.Text = "";
                Codex_TypeSQL = "";
            }
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
        }

        private void Codex_Subject_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && ((e.Control == true) || (e.Alt == true)))
                Codex_Subject_Button_Click(null, null);
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Subject_Edit.Text = "";
                Codex_SubjectSQL = "";
            }
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
        }

        private void Codex_Word_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && ((e.Control == true) || (e.Alt == true)))
                Codex_Word_Button_Click(null, null);
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Word_Edit.Text = "";
                Codex_WordSQL = "";
            }
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
        }

        private void Codex_Search_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Search_Edit.Text = "";
            }
        }

        private void Codex_Number_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Number_Edit.Text = "";
            }
        }

        private void Codex_Status_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && ((e.Control == true) || (e.Alt == true)))
                Codex_Status_Button_Click(null, null);
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Status_Edit.Text = "";
                Codex_StatusSQL = "";
            }
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }

        }

        private void Codex_Category_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && ((e.Control == true) || (e.Alt == true)))
                Codex_Category_Button_Click(null, null);
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Category_Edit.Text = "";
                Codex_CategorySQL = "";
            }
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
        }

        private void Codex_Search_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
            {
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
            }
        }

        private void Codex_Comment_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Comment_Edit.Text = "";
            }

        }
        
        private void Codex_Attrib_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
            if ((e.KeyCode == Keys.Escape))
            {
                DS_Attrib_Edit.Text = "";
            }

        }

        private void Codex_Attrib_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
            {
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
            }
        }

        private void Codex_Comment_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
            {
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
            }
        }

        #endregion HotKeys Codex

    }
}