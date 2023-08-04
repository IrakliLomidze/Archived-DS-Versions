using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ILG.Codex.CodexR4;
using ILG.Codex.CodexR4.CodexSettings;
using ILG.Codex.Strings;
using ILG.Codex2007;

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

            ICG_NewsN = 1;
            ICG_News_ComboV = 1;
        }

   
        public void DisplayParameters()
        {
            Codex_Date_Edit1.Text = PickDate.DateToString(Codex_Date1);
            Codex_Date_Edit2.Text = PickDate.DateToString(Codex_Date2);


            
            
            //Codex_Filer.SelectedIndex = Codex_FilterV;
            
            if (Codex_FullTextV) Codex_Search_Combo.SelectedIndex = 1; else Codex_Search_Combo.SelectedIndex = 0;
            
            
            // Codex Info
            CodexToolBar.Tools["Codex_Info_Label1"].SharedProps.Caption = " ბაზაში არის " + LockupTables.Tables["CodexDS2007"].Rows[0]["C_CodexDSDocs"].ToString() + " დოკუმენტი";
            CodexToolBar.Tools["Codex_Info_Date"].SharedProps.Caption = " ბოლო განახლება (" + PickDate.DateToString((DateTime)LockupTables.Tables["CodexDS2007"].Rows[0]["C_Date"]) + ")";

            if (Policy_ShowHistory == true)
            {
                CodexToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = " ისტორიაში არის " + CountForHistoryDocuments.ToString() + " დოკუმენტი";
            }

            if (License.IsHistoryAccessGranted() == false)
            {
                CodexToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = "ისტორიაზე არ გაქვთ დაშვება ";
            }

            ICG_News_Combo.SelectedIndex = ICG_News_ComboV;
            ICG_News_Edit.Value = ICG_NewsN;

 

        }


        public void DisplayParametersLimited()
        {
            CodexToolBar.Tools["Codex_Info_Label1"].SharedProps.Caption = " ბაზაში არის " + LockupTables.Tables["CodexDS2007"].Rows[0]["C_CodexDSDocs"].ToString() + " დოკუმენტი";
            CodexToolBar.Tools["Codex_Info_Date"].SharedProps.Caption = " ბოლო განახლება (" + PickDate.DateToString((DateTime)LockupTables.Tables["CodexDS2007"].Rows[0]["C_Date"]) + ")";

            if (Policy_ShowHistory == true)
            {
                CodexToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = " ისტორიაში არის " + CountForHistoryDocuments.ToString() + " დოკუმენტი";
            }


            if (License.IsHistoryAccessGranted() == false)
            {
                CodexToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = "ისტორიაზე არ გაქვთ დაშვება ";
            }
        }


        private void Codex_Search_Button_Click(object sender, EventArgs e)
        {
            if (Codex_Date1 > Codex_Date2) { ILG.Windows.Forms.ILGMessageBox.Show("თარიღის ინტერვალი არასწორია !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }


            //if ((Codex_Number_Edit.Text.Trim() != "") && (CodexString.CheckNumStr(Codex_Number_Edit.Text) == false)) { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის შესაძლო ნომერი არასწორედაა მითითებული !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }

            bool UseFullText = SQLDatabaseConfiguration.Default.UseFullTextSearch;
            if ((Codex_Search_Combo.SelectedIndex == 1) && (UseFullText == false))
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("თქვენ მონიშნული გაქვთ დოკუმენტის ტექსტში ძებნა, \n" +
                    "რაც დაიკავებს უფრო მეტ დროს ვიდრე ჩვეულებრივი ძებნის რეჟიმი\n" +
                    "ამ სახით ძებნამ შეიძლება დაიკავოს რამოდენიმე წუთი\n" +
                    "გსურთ გაგრძელება ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;
            }

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Codex_FillResult(Codex_GenerateFindSQL());
            this.Cursor = System.Windows.Forms.Cursors.Default;

            int maxlist = (int)global::ILG.Codex.CodexR4.Properties.Settings.Default.MaximumDocListCodex;
            if (Codex_Result.Tables[0].Rows.Count == 0) { ILG.Windows.Forms.ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); return; }
            if (Codex_Result.Tables[0].Rows.Count >= maxlist)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მოძებნილი დოკუმენტების რაოდენობა მეტია " + maxlist.ToString() + " - ზე  [" + Codex_Result.Tables[0].Rows.Count.ToString() + "] " +
                                                              "  \n გთხოვთ დააკონკრეტოთ ძებნის პარამეტრები  ");
                return;
            }
            // Codex Navigation 1
            CodexSorting(0);
            CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            CodexToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "მოძებნილი დოკუმენტები დალაგებულია";
                //CodexListStatus.Text = "მოძებნილი დოკუმენტები დალაგებულია";
            isnews = false;
            //this.ultraGrid1.DataSource = Codex_Result.Tables[0];
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[1];
            CodexPos = 1;
            CodexList = true;

            
            
            this.codexListBox1.Visited = this.CodexVisited;
            this.codexListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, License.IsHistoryAccessGranted());
            this.codexListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
            this.codexListBox1.FillGrid();

        }

        void RefreashList()
        {
            if (isnews == false)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Codex_FillResult(Codex_GenerateFindSQL());
                this.Cursor = System.Windows.Forms.Cursors.Default;

                int maxlist = (int)global::ILG.Codex.CodexR4.Properties.Settings.Default.MaximumDocListCodex;
                if (Codex_Result.Tables[0].Rows.Count == 0) { ILG.Windows.Forms.ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); HomeClick(); return; }

                // Codex Navigation 1
                CodexSorting(0);
                CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
                CodexToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "მოძებნილი დოკუმენტები დალაგებულია";
                //CodexListStatus.Text = "მოძებნილი დოკუმენტები დალაგებულია";
                isnews = false;
                //this.ultraGrid1.DataSource = Codex_Result.Tables[0];
                this.CodexTab.SelectedTab = this.CodexTab.Tabs[1];
                CodexPos = 1;
                CodexList = true;
                this.codexListBox1.Visited = this.CodexVisited;
                this.codexListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, License.IsHistoryAccessGranted());//(2);
                this.codexListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
                this.codexListBox1.FillGrid();
            }
            else
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Codex_FillResult(Codex_GenerateNewsSQL());
                this.Cursor = System.Windows.Forms.Cursors.Default;

                int maxlist = (int)global::ILG.Codex.CodexR4.Properties.Settings.Default.MaximumDocListCodex;
                if (Codex_Result.Tables[0].Rows.Count == 0) { ILG.Windows.Forms.ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); HomeClick(); return; }
                
                CodexSorting(0);
                CodexList = true;
                CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიახლის სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
                CodexToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "ახალი დოკუმენტები დალაგებულია";
                //Codex_List_SortLabel CodexListStatus.Text = "ახალი დოკუმენტები დალაგებულია";
                isnews = true;
                CodexPos = 1;
                this.CodexTab.SelectedTab = this.CodexTab.Tabs[1];
                this.codexListBox1.Visited = this.CodexVisited;
                this.codexListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, License.IsHistoryAccessGranted());// 2);
                this.codexListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
                this.codexListBox1.FillGrid();
            }
        }

        #region PopUpMenus
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("Keyboard3", this);
        }

        private void Keboard4Popup_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("Keyboard4", this);
        }

        private void CodexDateRange_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("Codex_Date_Range", this);
        }

        private void CGLDateRange_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("CGL_Date_Range", this);
        }

       
        private void CodexFind_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("Codex_Find_PopUp", this);
        }

        private void CGLFind_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("CGL_Find_PopUp", this);
        }

       



        #endregion PopUpMenus

        #region Data Pickers
        private void Codex_Date_Button1_Click(object sender, EventArgs e)
        {
            var dlg2 = new PickDate(Codex_Date1);
            Point dc2 = new Point(Codex_Date_Edit1.Location.X, Codex_Date_Edit1.Location.Y);
            Point dc = Codex_Search_Panel.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            Codex_Date_Edit1.Text = dlg2.ToString();
            Codex_Date1 = dlg2.PickedDate;
        }


        private void Codex_Date_Button2_Click(object sender, EventArgs e)
        {
            var dlg2 = new PickDate(Codex_Date2);
            Point dc2 = new Point(Codex_Date_Edit2.Location.X, Codex_Date_Edit2.Location.Y);
            Point dc = Codex_Search_Panel.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            Codex_Date_Edit2.Text = dlg2.ToString();
            Codex_Date2 = dlg2.PickedDate;


        }


       
        #endregion Data Pickers

        #region List Pickers
        private void Codex_Autor_Button_Click(object sender, EventArgs e)
        {

            Point dc2 = new Point(Codex_Autor_Edit.Location.X, Codex_Autor_Edit.Location.Y);
            Point dc = Codex_Search_Panel.PointToScreen(dc2);


            String FilterParameter = "";

            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DAuthor"], 0, "A_ID", "C_AUTHOR", "A_Caption", "მიმღები ორგანო", " ", dc.X, dc.Y, Codex_Autor_Edit.Width + Codex_Autor_Button.Width,"");

            f1.ShowDialog();
            if (f1.canceled == false)
            {
                Codex_Autor_Edit.Text = f1.ToString();
                Codex_AutorSQL = f1.ToSQLString();

                if (f1.ToWhat() == 0) Codex_Autor_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) Codex_Autor_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) Codex_Autor_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        private void Codex_Type_Button_Click(object sender, EventArgs e)
        {
            Point dc2 = new Point(Codex_Type_Edit.Location.X, Codex_Type_Edit.Location.Y);
            Point dc = Codex_Search_Panel.PointToScreen(dc2);


            String FilterParameter = "";
            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DType"], 0, "T_ID", "C_Type", "T_Caption", "დოკუმენტის სახე", " ", dc.X, dc.Y, Codex_Type_Edit.Width + Codex_Type_Button.Width,"");

            f1.ShowDialog();
            if (f1.canceled == false)
            {
                Codex_Type_Edit.Text = f1.ToString();
                Codex_TypeSQL = f1.ToSQLString();

                if (f1.ToWhat() == 0) Codex_Type_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) Codex_Type_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) Codex_Type_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        private void Codex_Subject_Button_Click(object sender, EventArgs e)
        {
            Point dc2 = new Point(Codex_Subject_Edit.Location.X, Codex_Subject_Edit.Location.Y);
            Point dc = Codex_Search_Panel.PointToScreen(dc2);


            String FilterParameter = "";
            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DSubject"], 0, "S_ID", "C_Subject", "S_Caption", "თემატიკა", " ", dc.X, dc.Y, Codex_Subject_Edit.Width + Codex_Subject_Button.Width,"");


            f1.ShowDialog();
            if (f1.canceled == false)
            {
                Codex_Subject_Edit.Text = f1.ToString();
                Codex_SubjectSQL = f1.ToSQLString();

                if (f1.ToWhat() == 0) Codex_Subject_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) Codex_Subject_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) Codex_Subject_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        private void Codex_Word_Button_Click(object sender, EventArgs e)
        {

            Point dc2 = new Point(Codex_Word_Edit.Location.X, Codex_Word_Edit.Location.Y);
            Point dc = Codex_Search_Panel.PointToScreen(dc2);


            String FilterParameter = "";
            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DWords"], 1, "W_ID", "C_Words", "W_Caption", "საკვანძო სიტყვა/ები", " ", dc.X, dc.Y, Codex_Word_Edit.Width + Codex_Word_Button.Width,"");


            f1.ShowDialog();
            if (f1.canceled == false)
            {
                Codex_Word_Edit.Text = f1.ToString();
                Codex_WordSQL = f1.ToSQLString();

                if (f1.ToWhat() == 0) Codex_Word_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) Codex_Word_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) Codex_Word_Edit.Appearance.ForeColor = Color.Red;
            }
        }


        private void Codex_Category_Button_Click(object sender, EventArgs e)
        {
            Point dc2 = new Point(Codex_Category_Edit.Location.X, Codex_Category_Edit.Location.Y);
            Point dc = Codex_Search_Panel.PointToScreen(dc2);

            String FilterParameter = "";

            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DCategory"], 0, "C_ID", "C_Category", "C_Caption", "დოკუმენტის კატეგორია", " ", dc.X, dc.Y, Codex_Category_Edit.Width + Codex_Category_Button.Width,"");

            f1.ShowDialog();
            if (f1.canceled == false)
            {
                Codex_Category_Edit.Text = f1.ToString();

                Codex_CategorySQL = f1.ToSQLString(); ;
                if (f1.ToWhat() == 0) Codex_Category_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) Codex_Category_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) Codex_Category_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        private void Codex_Status_Button_Click(object sender, EventArgs e)
        {
            Point dc2 = new Point(Codex_Status_Edit.Location.X, Codex_Status_Edit.Location.Y);
            Point dc = Codex_Search_Panel.PointToScreen(dc2);


            String FilterParameter = "";
            //if (e != null) FilterParameter = e.KeyChar.ToString();


            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DStatus"], 0, "C_ID", "C_Status", "C_Caption", "დოკუმენტის სტატუსი", " ", dc.X, dc.Y, Codex_Status_Edit.Width + Codex_Status_Button.Width,"");

            f1.ShowDialog();
            if (f1.canceled == false)
            {
                Codex_Status_Edit.Text = f1.ToString();

                Codex_StatusSQL = f1.ToSQLString(); ;
                if (f1.ToWhat() == 0) Codex_Status_Edit.Appearance.ForeColor = Color.Gray;
                if (f1.ToWhat() == 1) Codex_Status_Edit.Appearance.ForeColor = Color.Black;
                if (f1.ToWhat() == 2) Codex_Status_Edit.Appearance.ForeColor = Color.Red;
            }
        }

        
        #endregion List Pickers

        private void Codex_Number_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
            //if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar <= ' ') || (e.KeyChar == '-') || (e.KeyChar == ',')) e.Handled = false;
            e.KeyChar = ILG.Codex.CodexR4.KeyBoard.Layout.U[e.KeyChar];
        }

        #region  DateRanges
        #region Codex
        public void Codex_Do_DateEqual()
        {
            if ((this.Codex_Date_Edit1.Focused == false) && (this.Codex_Date_Edit2.Focused == false))
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მიუთითეთ, რომელიმე თარიღი");
                return;
            }

            if (this.Codex_Date_Edit2.Focused == true)
            {
                Codex_Date1 = new DateTime(Codex_Date2.Year, Codex_Date2.Month, Codex_Date2.Day);
            }

            if (this.Codex_Date_Edit1.Focused == true)
            {
                Codex_Date2 = new DateTime(Codex_Date1.Year, Codex_Date1.Month, Codex_Date1.Day);
            }

            Codex_Date_Edit1.Text = PickDate.DateToString(Codex_Date1);
            Codex_Date_Edit2.Text = PickDate.DateToString(Codex_Date2);

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

            Codex_Date_Edit1.Text = ILG.Codex.CodexR4.PickDate.DateToString(Codex_Date1);
            Codex_Date_Edit2.Text = ILG.Codex.CodexR4.PickDate.DateToString(Codex_Date2);

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
            Codex_Search_Edit.Text = "";
            Codex_Autor_Edit.Text = "";
            Codex_Type_Edit.Text = "";
            Codex_Subject_Edit.Text = "";
            Codex_Word_Edit.Text = "";
            Codex_Number_Edit.Text = "";
            Codex_Status_Edit.Text = "";
            Codex_Category_Edit.Text = "";
            Codex_Comment_Edit.Text = "";
            Codex_Attrib_Edit.Text = "";
            Codex_Do_DataRanges(6);
            Codex_Search_Combo.SelectedIndex = 0; // Find in Caption
            Codex_AccessCombo.SelectedIndex = 0;
            //Codex_Filer.SelectedIndex = Codex_FilterV;


            // New In 1.5.5
            if (CodexDSBehavioral.Default.IsDefaultParameterStatus == true)
            {
                SetStatusDefault(CodexDSBehavioral.Default.DefaultStatus);
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
            using (SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
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

            Codex_Status_Edit.Text = Codex_Status_Edit_Str;


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
                if (ForceExit == false) SaveDcoksSettings(); // Save Docks Settings
                if (ILG.Windows.Forms.ILGMessageBox.Show("პროგრამიდან გამოსვლა,\nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = false;
                else e.Cancel = true;
            }
        }

        #endregion Find Resetst

        #region Find SQL Srtipt Generation
        #region Codex

        private string Get_ShowHistoryFiled()
        {
            string ResultSQL = ", 0 AS C_ShowHistory ";
            if (License.IsHistoryAccessGranted() == false) return ResultSQL;

            String HistoryPublicSQL = ", (CASE " +
                               "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NULL THEN 0 " +
                               "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL THEN  (Select Count (C_ID) From CodexDS_DDOCS_History Where (CodexDS_DDOCS_History.C_ID = CodexDS_DDOCS.C_ID AND CodexDS_DDOCS_History.H_Status = 0) )" +
                               "   ELSE 0 " +
                               "END) as  C_ShowHistory ";

            if (License.IsHistoryExtendedAccessGranted() == false) return HistoryPublicSQL;

            String HistoryExtendedSQL = ", (CASE " +
                                        "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NULL THEN 0 " +
                                        "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL THEN  (Select Count (C_ID) From CodexDS_DDOCS_History Where ((CodexDS_DDOCS_History.C_ID = CodexDS_DDOCS.C_ID) AND ((CodexDS_DDOCS_History.H_Status = 0) OR (CodexDS_DDOCS_History.H_Status = 1) ) ))" +
                                        "   ELSE 0 " +
                                        "END) as  C_ShowHistory ";

            if (License.IsRecoverDeletedDocumentsGranted() == false) return HistoryExtendedSQL;

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




            String Fields = "C_ID,C_Caption,C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat,(CASE (ISNULL(DATALENGTH(C_Attach),0)) WHEN 0 THEN 0  ELSE 1 END) AS L_AttachmentSize "+ SpecialField;
            String StrHeader = "SELECT " + Fields + " FROM CODEXDS_DDOCS WHERE ";
            String Strd = "( ( C_Date >= " +
                  "CONVERT(DATETIME, '" + Codex_Date1.Year.ToString() + @"-" + Codex_Date1.Month.ToString("00") + @"-" + Codex_Date1.Day.ToString("00") + "T00:00:00.000' ,126) )" +
                " and " +
                "( C_Date <= " +
                  "CONVERT(DATETIME, '" + Codex_Date2.Year.ToString() + @"-" + Codex_Date2.Month.ToString("00") + @"-" + Codex_Date2.Day.ToString("00") + "T23:59:59.997' ,126) )" + " ) ";

            String Strc = "And " + CodexString.CaptionAnaliser(Codex_Search_Edit.Text, "C_Caption", "'") + " ";

            if (this.Codex_Search_Combo.SelectedIndex == 1) // if Full Text Sellected
            {
                bool UseFullTest = SQLDatabaseConfiguration.Default.UseFullTextSearch;
                if (UseFullTest == false)
                {
                    Strc = "And (( C_DocText LIKE N'%" +
                    CodexString.GeoUnitoGeo8(Codex_Search_Edit.Text)
                    + "%') or   " +
                        " ( C_DocText LIKE N'%" +
                    Codex_Search_Edit.Text
                    + "%'))";
                }
                else
                {
                    Strc = "And ( ( CONTAINS  (C_DocText , N'" + '"' +
                        CodexString.GeoUnitoGeo8(Codex_Search_Edit.Text)
                        + '*' + '"' + "  ')) or " +
                        "( CONTAINS  (C_DocText , N'" + '"' +
                        Codex_Search_Edit.Text
                        + '*' + '"' + "  ')) )";

                }
            }

            if (Codex_Search_Edit.Text.Trim() == "") Strc = "";

            String StrComment = "And " + CodexString.CaptionAnaliser(Codex_Comment_Edit.Text, "C_Coments", "'") + " ";
            if (Codex_Comment_Edit.Text.Trim() == "") StrComment = "";

            String StrAdditional = "And " + CodexString.CaptionAnaliser(Codex_Attrib_Edit.Text, "C_Addtional", "'") + " ";
            if (Codex_Attrib_Edit.Text.Trim() == "") StrAdditional = "";

             // PosPoned to next Version
            //String Strn = "And ( " + CodexString.NumAnaliser(Codex_Number_Edit.Text, "C_Number", "'") + ") ";
            String Strn = "And ( C_NumberStr LIKE N'%" + Codex_Number_Edit.Text.Trim() + "%') ";
            if (Codex_Number_Edit.Text.Trim() == "") Strn = "";


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

            String StrComments = "And ( C_Coments LIKE N'%" + Codex_Comment_Edit.Text.Trim() + "%') ";
            if (Codex_Comment_Edit.Text.Trim() == "") StrComments = "";

            String StrAdvancedAttribute = "And ( C_Addtional LIKE N'%" + Codex_Attrib_Edit.Text.Trim() + "%') ";
            if (Codex_Attrib_Edit.Text.Trim() == "") StrAdvancedAttribute = "";


            bool RA = License.IsConfidentialDocumentShowInList();

            
            String Strf = "";
            if (RA == false) Strf = " And (C_Group = 0)";
            if (RA == true)
            {
                if (Codex_AccessCombo.SelectedIndex == 0) Strf = "";
                if (Codex_AccessCombo.SelectedIndex == 1) Strf = " And (C_Group = 0)";
                if (Codex_AccessCombo.SelectedIndex == 2) Strf = " And (C_Group = 1)";
            }


            string FullSQL = StrHeader + Strd + Strc + Strn + Stra + Strt + Strs + Strw + StrST + StrCT + StrComments+StrAdvancedAttribute + Strf;
       //     System.Windows.Forms.Clipboard.SetText(FullSQL);
         //   MessageBox.Show("N");
            return FullSQL;
            
        }

        private String Codex_GenerateNewsSQL()
        {
            DateTime dd1 = DateTime.Now;
            TimeSpan ts = new TimeSpan(14, 0, 0);
            int factor = (Int32)this.ICG_News_Edit.Value;

            switch (ICG_News_Combo.SelectedIndex)
            {
                case 0: ts = new TimeSpan( factor, 0, 0, 0, 0); break;
                case 1: ts = new TimeSpan(7 * factor, 0, 0, 0, 0); break;
                case 2: ts = new TimeSpan(30 * factor, 0, 0, 0, 0); break;
                case 3: ts = new TimeSpan(92 * factor, 0, 0, 0, 0); break;
                case 4: ts = new TimeSpan(365 * factor, 0, 0, 0, 0); break;

            };

            DateTime dd3 = dd1 - ts;

            String SpecialField = Get_ShowHistoryFiled();

            //String Fields = "C_ID,C_Caption,C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat,ISNULL(DATALENGTH(C_Attach),0) as L_AttachmentSize";
            //(CASE (ISNULL(DATALENGTH(C_Attach),0)) WHEN 0 THEN 0  ELSE 1 END) AS L_AttachmentSize,
            String Fields = "C_ID,C_Caption,C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat,(CASE (ISNULL(DATALENGTH(C_Attach),0)) WHEN 0 THEN 0  ELSE 1 END) AS L_AttachmentSize " + SpecialField;
            String StrHeader = "SELECT " + Fields + " FROM CODEXDS_DDOCS WHERE ";
            String Strd = "( ( C_EnterDate >= " +
                  "CONVERT(DATETIME, '" + dd3.Year.ToString() + @"-" + dd3.Month.ToString("00") + @"-" + dd3.Day.ToString("00") + "T00:00:00.000' ,126) )" +
                " and " +
                "( C_EnterDate <= " +
                  "CONVERT(DATETIME, '" + dd1.Year.ToString() + @"-" + dd1.Month.ToString("00") + @"-" + dd1.Day.ToString("00") + "T23:59:59.997' ,126) ) " + " ) ";

            String FullNewsSQL; 
            if (this.ICG_News_Check.Checked == true)
                FullNewsSQL = Codex_GenerateFindSQL() + " and " + Strd;
            else
            {
                FullNewsSQL = StrHeader + Strd;
                bool RestrincAccess = License.IsConfidentialDocumentShowInList();
                String Strf = "";
                if (RestrincAccess == false) Strf = " And (C_Group = 0)";
                FullNewsSQL = FullNewsSQL+ Strf;
                
            }

            return FullNewsSQL; 

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
                Codex_Autor_Edit.Text = "";
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
                Codex_Type_Edit.Text = "";
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
                Codex_Subject_Edit.Text = "";
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
                Codex_Word_Edit.Text = "";
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
                Codex_Search_Edit.Text = "";
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
                Codex_Number_Edit.Text = "";
            }
        }

        private void Codex_Status_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && ((e.Control == true) || (e.Alt == true)))
                Codex_Status_Button_Click(null, null);
            if ((e.KeyCode == Keys.Escape))
            {
                Codex_Status_Edit.Text = "";
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
                Codex_Category_Edit.Text = "";
                Codex_CategorySQL = "";
            }
            if ((e.KeyCode == Keys.Enter))
            {
                Codex_Search_Button_Click(null, null);
            }
        }

        private void Codex_Search_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
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
                Codex_Comment_Edit.Text = "";
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
                Codex_Attrib_Edit.Text = "";
            }

        }

        private void Codex_Attrib_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void Codex_Comment_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        #endregion HotKeys Codex

    }
}