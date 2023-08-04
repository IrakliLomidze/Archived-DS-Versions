using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using ILG.Codex.CodexDSListBox;
using ILG.Codex.Strings;
using ILG.Windows.Forms;
using System.IO;
using ILG.Codex.CodexR4.CodexSettings;
using System.Drawing;
using System.ComponentModel;
using ILG.Codex.CodexR4.UI;

namespace ILG.Codex.CodexR4
{
    public partial class HistoryForm1 : Form
    {



        public int Codex_List_ZoomFactor;

        public DataSet LockupTables;
     

        private int CountForHistoryDocuments = 0;
        private int CodexDocumentID;
        private bool CodexList = false;


        DateTime Codex_Date1;
        DateTime Codex_Date2;
        DateTime CodexHistory_Date1;
        DateTime CodexHistory_Date2;
        string Codex_AutorSQL = "";
        string Codex_TypeSQL = "";
        string Codex_SubjectSQL = "";
        string Codex_WordSQL = "";
        string Codex_CategorySQL = "";
        string Codex_StatusSQL = "";

        private String GetTSQLForIfHistoryExists()
        {
            String SQL = " IF OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL " + System.Environment.NewLine +
                         " SELECT 1 AS Result " + System.Environment.NewLine +
                         " ELSE SELECT 0 AS Result";
            return SQL;
        }

        private String GetTSQLCountHistory()
        {
            String SQL = " SELECT COUNT(*) FROM CodexDS_DDOCS_History WHERE H_STATUS = -16";
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
                                       "SELECT * FROM CodexDS_DStatus ORDER By C_Order;" +    // sta
                                       "SELECT * FROM " + TableName + " ",	 // Need to Change in Codex 2007
                                       SQLConnectionStrings.Default.ConnectionString_CodexDS);
                LockupTables = new DataSet();
                DataTableMapping dtm3, dtm4, dtm5, dtm6, dtm9, dtm7, dtm8;
                dtm3 = da.TableMappings.Add("Table", "CodexDS_DAUTHOR");
                dtm4 = da.TableMappings.Add("Table1", "CodexDS_DTYPE");
                dtm5 = da.TableMappings.Add("Table2", "CodexDS_DSubject");
                dtm6 = da.TableMappings.Add("Table3", "CodexDS_DWords");
                dtm7 = da.TableMappings.Add("Table4", "CodexDS_DCategory");
                dtm8 = da.TableMappings.Add("Table5", "CodexDS_DStatus");
                dtm9 = da.TableMappings.Add("Table6", "CodexDS2007");
                da.Fill(this.LockupTables);
                // Visited

                
                try
                {
                    using (var cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
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
            }
            catch (Exception ex)
            {
                ILGMessageBox.ShowE("ბაზიდან ინფორმაციის წაკითხვა ვერ ხერხდება", ex.Message.ToString());
            }
        }


        public HistoryForm1()
        {
            InitializeComponent();

            // Display Attribute Names

            //Codex_Autor_Label.Text = CodexDSOrganizationSettings.Instance.Settings.DisplayModel.authorAttributeSettings.DisplayName;


            //Current_Language = (int)Properties.Settings.Default.KeyboardLayout;


            DefaultSearchParameters();
            LoadTables();
            DisplayParameters();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SuspendLayout();

            Infragistics.Win.AppStyling.StyleManager.Office2013ColorScheme = Infragistics.Win.Office2013ColorScheme.White;
            Infragistics.Win.AppStyling.StyleManager.Office2013Theme = Infragistics.Win.Office2013Theme.Excel;
            
 
            //this.Left = 0;
            //this.Top = 0;
            //this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            //this.Height = Screen.PrimaryScreen.WorkingArea.Height;


   

            Codex_DefaultSearchParameters();

            ResumeLayout();


        }



        private void CodexToolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

            switch (e.Tool.Key)
            {
   

                case "Exit":    // ButtonTool
                    Close();
                    break;

                case "DOCAE":
                    {
                        //HistoryDocumentAddEdit dd = new HistoryDocumentAddEdit();
                        //dd.FormMain = this;
                        //dd.Show();
                        //dd.NewDocumentMode();
                        //LoadTables();
                        //DisplayParametersLimited();
                    }
                    break;

                case "ChangeDocument":
                    if (CodexDocumentID == -1) return;
                    if (License.IsDocumentEditAllow() == false)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("თქვენ არ გაქვთ დოკუმენტის ცვლილების უფლება");
                        return;
                    }
                    //HistoryDocumentAddEdit dd2 = new HistoryDocumentAddEdit();
                    //dd2.FormMain = this;
                    //dd2.Show();
                    //dd2.NewDocumentMode();


                    //if (dd2.EditDocumentMode(CodexDocumentID) != 0)
                    //    dd2.Close();
                    //else
                    //{
                    //    LoadTables();
                    //    DisplayParametersLimited();
                    //}

                    break;

                case "DeleteDocument": DODELDocument(); break;


                case "ResetCommon":    // ButtonTool
                    Codex_DefaultSearchParameters();
                    break;

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


            }

        }

        private void DODELDocument()
        {
            throw new NotImplementedException();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Panelss();
        }

        public void CaptionGeneration()
        {
            string Ind = "  ";

            #region Codex
            {
                switch (CodexTab.ActiveTab.Index)
                {
                    case 0: /* Find Form */ this.Text = Ind + "წაშლილი დოკუმენტების ძებნა"; break;
                    case 1: /* List Form */ this.Text = Ind + "წაშლილი დოკუმენტების სია"; break;
                }
            }


            #endregion Codex

        }

        private void ultraTabControl2_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {

            Panelss();

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
        DataSet Codex_Result;

        private void Codex_FillResult(String strcmd)
        {
            SqlDataAdapter daCodex = new SqlDataAdapter(strcmd, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            daCodex.SelectCommand.CommandTimeout = 7200;
            Codex_Result = new DataSet();
            try
            {
                daCodex.Fill(Codex_Result);
            }
            catch (System.Exception ex)
            {
                    ILG.Windows.Forms.ILGMessageBox.ShowE("შეცდომა სერვერზე ! \n" +
                                                         "პროგრამის გაგრძელება შეუძლებელია, იგი დაიხურება ",
                        "", ex.Message.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                {
                    if (dr["C_ID"].ToString().Trim() == "0") Strstatus.Append(" ");
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
                if (ILG.Codex.CodexR4.Properties.Settings.Default.ShowAdvancedAttributes == true)
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

                if (IDACCESS.Trim() != "") S = IDACCESS + "] " + S;

                string ss1 = HistoryListDateTimetoGString((DateTime)Codex_Result.Tables[0].Rows[i]["H_Date"]);

                Codex_Result.Tables[0].Rows[i]["TopCaption"] = $"Archive : {ss1}, Title: {@S} ";
                Codex_Result.Tables[0].Rows[i]["C_Caption"] = @FilterString(Codex_Result.Tables[0].Rows[i]["C_Caption"].ToString());


            }

            ///CodexResultV = CodexResult.Select("", "C_Date DESC");

        }

        #endregion Codex






        #endregion Fill Results and Result DataSets




        private void HomeClick()
        {
            CodexTab.SelectedTab = this.CodexTab.Tabs[0]; CodexList = false;
        }




        private void CallList()
        {
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[1]; CodexList = true;
        }


   

        public void codexListBox1_DocumentClick(object sender, CodexDSListEventArgs e)
        {
            if (ISDocumentExsistsInHistory(e._ID) == false)
            {
                MessageBox.Show($"დოკუმენტი არ მოიძებნა არსებობს ბაზაში id:{e._ID}");
            }
            HistoryDocument d = new HistoryDocument();
       
            using (new WaitCursor())
            {
                d.Show();
                int i = 0;
                i = d.EditDocumentMode(e._ID, IsDeletedDocumentMode: true);
                if (i != 0) d.Close();
            }

         
        }

        private void CodexToolBar_ToolKeyPress(object sender, Infragistics.Win.UltraWinToolbars.ToolKeyPressEventArgs e)
        {
            if (e.Tool.Key == "Codex_List_Filter")
            {
                e.Handled = true;
                e.KeyChar = ILG.Codex.CodexR4.KeyBoard.Layout.U[e.KeyChar];
            }

        }

        public string HistoryListDateTimetoGString(DateTime dt)
        {
            String Str = "";
            switch (dt.Month)
            {
                case 1: Str = "იანვარი"; break;
                case 2: Str = "თებერვალი"; break;
                case 3: Str = "მარტი"; break;
                case 4: Str = "აპრილი"; break;
                case 5: Str = "მაისი"; break;
                case 6: Str = "ივნისი"; break;
                case 7: Str = "ივლისი"; break;
                case 8: Str = "აგვისტო"; break;
                case 9: Str = "სექტემბერი"; break;
                case 10: Str = "ოქტომბერი"; break;
                case 11: Str = "ნოემბერი"; break;
                case 12: Str = "დეკემბერი"; break;
            }

            Str = dt.Year.ToString() + " წ. " + dt.Day.ToString() + " " + Str;
            return Str;
        }
        // Load History Document

        public bool ISDocumentExsistsInHistory(int HID)
        {
            string strsql = "Select count(ID) FROM CodexDS_DDOCS_History WHERE ID = " + HID.ToString() + " ";
            bool result = false;
            using (var cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand(strsql, cn);
                result = ((int)cm.ExecuteScalar() > 0);
            }
            return result;
        }


        int CodexSortBy = 0;
        string CodexFilterBy = "";

        #region Sorting Button
        public void CodexSorting(int i)
        {
            switch (i)
            {
                case 0: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption = "დოკუმენტის თარიღის მიხედვით (კლებადობით)"; CodexSortBy = 0; break;
                case 1: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption = "დოკუმენტის თარიღის მიხედვით (ზრდადობით)"; CodexSortBy = 1; break;
                case 2: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption = "მიმღები ორგანოს მიხედვით"; CodexSortBy = 2; break;
                case 3: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption = "დოკუმენტის სახის მიხედვით"; CodexSortBy = 3; break;
                case 4: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption = "დოკუმენტის ნომრის მიხედვით"; CodexSortBy = 4; break;
                case 5: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption = "დოკუმენტის სტატუსის მიხედვით"; CodexSortBy = 5; break;
            }
        }


        #endregion Sorting Button

        #region Filter

        private void CGLListFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }


        private void CodexListFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }
        #endregion Filter

        void SaveList()
        {
            this.codexListBox1.SaveToRTF();

        }

        void ExportList()
        {
            String Suffix = "LL";
            String D = DateTime.Now.Ticks.ToString();
            string fn = DirectoryConfiguration.CurrentDirectory + @"\" + Suffix + D;//+".Doc";
            int i = 1;
            while (File.Exists(fn + "_" + i.ToString() + ".RTF") == true) { i++; }

            fn = fn + "_" + i.ToString() + ".RTF";

            try
            {
                this.codexListBox1.SaveToRTF(fn);
                System.Diagnostics.Process.Start(@"file" + @":\\" + fn);

            }
            catch (Exception ex)
            {
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება სიის ექსპორტი MS-Word ში", ex.ToString());
                return;
            }

        }

        #region Resorting Codex


        public void ResortingCodexList(int i, string Filter)
        {

            CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            //this.ultraGrid1.DataSource = Codex_Result.Tables[0];

            this.codexListBox1.FillGrid();


            switch (i)
            {
                case 0: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Date ASC"); break;
                case 1: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Date DESC"); break;
                case 2: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Author"); break;
                case 3: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Type"); break;
                case 4: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Number"); break;
                case 5: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Status"); break;
            }
            this.codexListBox1.FillGrid();

            CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + this.codexListBox1.DataSource.Length.ToString() + " დოკუმენტი";

            // CodexListAmoundLabel.Text = "სიაში არის " + this.codexListBox1.DataSource.Length.ToString() + " დოკუმენტი";


        }




        private void Codex_List_FilterGO_Click(object sender, EventArgs e)
        {
            string f = CodexFilterBy;
            CodexFilterBy = "C_Caption LIKE '%" + this.CodexListFilter.Text.Trim() + "%'";
            //ResortingCodexList(CodexSortBy, CodexFilterBy);

            if (Codex_Result.Tables[0].Select(CodexFilterBy).Length == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ფილტრაციის შედეგი ცარიელია");
                this.CodexFilterBy = f;
                Codex_List_FilterClear.Visible = false;
                CodexListFilter.Text = "";

            }
            else
            {
                Codex_List_FilterClear.Visible = true;
            }

            ResortingCodexList(CodexSortBy, CodexFilterBy);
            if (CodexListFilter.Text.Trim() == "") Codex_List_FilterClear.Visible = false;

        }

        private void Codex_List_FilterClear_Click(object sender, EventArgs e)
        {
            CodexListFilter.Text = "";
            Codex_List_FilterGO_Click(null, null);
        }
        #endregion Resorting Codex


        private void CodexListFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Codex_List_FilterGO_Click(null, null);
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
        
            var dlg2 = new PickDate(CodexHistory_Date1);
            Point dc2 = new Point(History_Date_Edit1.Location.X, History_Date_Edit1.Location.Y);
            //Point dc3 = History_Date_Edit1.FindForm().PointToClient(History_Date_Edit1.Parent.PointToScreen(History_Date_Edit1.Location));
            Point dc = tableLayoutPanel5.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            History_Date_Edit1.Text = dlg2.ToString();
            CodexHistory_Date1 = dlg2.PickedDate;
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            var dlg2 = new PickDate(CodexHistory_Date2);
            Point dc2 = new Point(History_Date_Edit2.Location.X, History_Date_Edit2.Location.Y);
            Point dc = tableLayoutPanel5.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            History_Date_Edit2.Text = dlg2.ToString();
            CodexHistory_Date2 = dlg2.PickedDate;
        }



        public void DefaultSearchParameters()
        {
            Codex_Date1 = new DateTime(1973, 1, 1);
            Codex_Date2 = DateTime.Now;

            CodexHistory_Date1 = new DateTime(1973, 1, 1);
            CodexHistory_Date2 = DateTime.Now;


        }


        public void DisplayParameters()
        {
            Codex_Date_Edit1.Text = PickDate.DateToString(Codex_Date1);
            Codex_Date_Edit2.Text = PickDate.DateToString(Codex_Date2);

            History_Date_Edit1.Text = PickDate.DateToString(CodexHistory_Date1);
            History_Date_Edit2.Text = PickDate.DateToString(CodexHistory_Date2);

            History_Search_Combo.SelectedIndex = 0;


            //// Codex Info
            //CodexToolBar.Tools["Codex_Info_Label1"].SharedProps.Caption = " ბაზაში არის " + LockupTables.Tables["CodexDS2007"].Rows[0]["C_CodexDSDocs"].ToString() + " დოკუმენტი";
            //CodexToolBar.Tools["Codex_Info_Date"].SharedProps.Caption = " ბოლო განახლება (" + PickDate.DateToString((DateTime)LockupTables.Tables["CodexDS2007"].Rows[0]["C_Date"]) + ")";

            //{
            //    CodexToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = " ისტორიაში არის " + CountForHistoryDocuments.ToString() + " დოკუმენტი";
            //}


        }


        public void DisplayParametersLimited()
        {
            CodexToolBar.Tools["Codex_Info_Label1"].SharedProps.Caption = " ბაზაში არის " + LockupTables.Tables["CodexDS2007"].Rows[0]["C_CodexDSDocs"].ToString() + " დოკუმენტი";
            CodexToolBar.Tools["Codex_Info_Date"].SharedProps.Caption = " ბოლო განახლება (" + PickDate.DateToString((DateTime)LockupTables.Tables["CodexDS2007"].Rows[0]["C_Date"]) + ")";

            {
                CodexToolBar.Tools["Codex_Info_History_Count"].SharedProps.Caption = " ისტორიაში არის " + CountForHistoryDocuments.ToString() + " დოკუმენტი";
            }
        }


        private void Codex_Search_Button_Click(object sender, EventArgs e)
        {
            if (Codex_Date1 > Codex_Date2) { ILGMessageBox.Show("თარიღის ინტერვალი არასწორია !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }

            if (CodexHistory_Date1 > CodexHistory_Date2) { ILGMessageBox.Show("თარიღის ინტერვალი არასწორია !", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); return; }



            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Codex_FillResult(Codex_GenerateFindSQLForDeleted());
            this.Cursor = System.Windows.Forms.Cursors.Default;

            int maxlist = (int)global::ILG.Codex.CodexR4.Properties.Settings.Default.MaximumDocListCodex;
            if (Codex_Result.Tables[0].Rows.Count == 0) { ILG.Windows.Forms.ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); return; }
            if (Codex_Result.Tables[0].Rows.Count >= maxlist)
            {
                ILGMessageBox.Show("მოძებნილი დოკუმენტების რაოდენობა მეტია " + maxlist.ToString() + " - ზე  [" + Codex_Result.Tables[0].Rows.Count.ToString() + "] " +
                            "  \n გთხოვთ დააკონკრეტოთ ძებნის პარამეტრები  ");
                return;
            }


            // Codex Navigation 1
            CodexSorting(0);
            FindResult.Text = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
        //    CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
         //   CodexToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "მოძებნილი დოკუმენტები დალაგებულია";
            //CodexListStatus.Text = "მოძებნილი დოკუმენტები დალაგებულია";

            this.CodexTab.SelectedTab = this.CodexTab.Tabs[1];
            CodexList = true;

            var CodexVisited = new DataTable("VisitedTable");
            DataColumn dcdvs = new DataColumn("Visited");
            dcdvs.ReadOnly = false;
            dcdvs.DataType = System.Type.GetType("System.Int32");
            dcdvs.AutoIncrement = false;
            CodexVisited.Columns.Add(dcdvs);
            CodexVisited.PrimaryKey = new DataColumn[] { CodexVisited.Columns["Visited"] };


            this.codexListBox1.Visited = CodexVisited;
            this.codexListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, License.IsHistoryAccessGranted(), IdFiledName: "id");
            this.codexListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
            this.codexListBox1.FillGrid();

        }

        void RefreashList()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Codex_FillResult(Codex_GenerateFindSQLForDeleted());
            this.Cursor = System.Windows.Forms.Cursors.Default;

            int maxlist = (int)global::ILG.Codex.CodexR4.Properties.Settings.Default.MaximumDocListCodex;
            if (Codex_Result.Tables[0].Rows.Count == 0) { ILG.Windows.Forms.ILGMessageBox.Show("მოცემული პარამეტრებით არცერთი დოკუმენტი არ მოიძებნა "); HomeClick(); return; }

            // Codex Navigation 1
            CodexSorting(0);
            CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            CodexToolBar.Tools["Codex_List_SortLabel"].SharedProps.Caption = "მოძებნილი დოკუმენტები დალაგებულია";
            //CodexListStatus.Text = "მოძებნილი დოკუმენტები დალაგებულია";
            //this.ultraGrid1.DataSource = Codex_Result.Tables[0];
            this.CodexTab.SelectedTab = this.CodexTab.Tabs[1];
            CodexList = true;

            var CodexVisited = new DataTable("VisitedTable");
            DataColumn dcdvs = new DataColumn("Visited");
            dcdvs.ReadOnly = false;
            dcdvs.DataType = System.Type.GetType("System.Int32");
            dcdvs.AutoIncrement = false;
            CodexVisited.Columns.Add(dcdvs);
            CodexVisited.PrimaryKey = new DataColumn[] { CodexVisited.Columns["Visited"] };

            this.codexListBox1.Visited = CodexVisited;
            this.codexListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, License.IsHistoryAccessGranted());//(2);
            this.codexListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
            this.codexListBox1.FillGrid();

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
            Point dc = tableLayoutPanel5.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            Codex_Date_Edit1.Text = dlg2.ToString();
            Codex_Date1 = dlg2.PickedDate;
        }


        private void Codex_Date_Button2_Click(object sender, EventArgs e)
        {
            var dlg2 = new PickDate(Codex_Date2);
            Point dc2 = new Point(Codex_Date_Edit2.Location.X, Codex_Date_Edit2.Location.Y);
            Point dc = tableLayoutPanel5.PointToScreen(dc2);
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
            Point dc = tableLayoutPanel4.PointToScreen(dc2);



            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DAuthor"], 0, "A_ID", "C_AUTHOR", "A_Caption", "მიმღები ორგანო", " ", dc.X, dc.Y, Codex_Autor_Edit.Width + Codex_Autor_Button.Width, "");

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
            Point dc = tableLayoutPanel4.PointToScreen(dc2);


            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DType"], 0, "T_ID", "C_Type", "T_Caption", "დოკუმენტის სახე", " ", dc.X, dc.Y, Codex_Type_Edit.Width + Codex_Type_Button.Width, "");

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
            Point dc = tableLayoutPanel4.PointToScreen(dc2);


            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DSubject"], 0, "S_ID", "C_Subject", "S_Caption", "თემატიკა", " ", dc.X, dc.Y, Codex_Subject_Edit.Width + Codex_Subject_Button.Width, "");


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
            Point dc = tableLayoutPanel4.PointToScreen(dc2);


            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DWords"], 1, "W_ID", "C_Words", "W_Caption", "საკვანძო სიტყვა/ები", " ", dc.X, dc.Y, Codex_Word_Edit.Width + Codex_Word_Button.Width, "");


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
            Point dc = tableLayoutPanel4.PointToScreen(dc2);


            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DCategory"], 0, "C_ID", "C_Category", "C_Caption", "დოკუმენტის კატეგორია", " ", dc.X, dc.Y, Codex_Category_Edit.Width + Codex_Category_Button.Width, "");

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
            Point dc = tableLayoutPanel4.PointToScreen(dc2);


            Sellpickerg f1 = new Sellpickerg(LockupTables.Tables["CodexDS_DStatus"], 0, "C_ID", "C_Status", "C_Caption", "დოკუმენტის სტატუსი", " ", dc.X, dc.Y, Codex_Status_Edit.Width + Codex_Status_Button.Width, "");

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

                case 0:
                    Codex_Date2 = DateTime.Now;
                    m = Codex_Date2.Month;
                    y = Codex_Date2.Year;
                    d = Codex_Date2.Day;
                    if (m == 1) { m = 12; y--; }
                    else m--;

                    if ((m == 2) && (m >= 29)) d = 28;
                    if (d == 31) d = 30;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // last month

                case 1:
                    Codex_Date2 = DateTime.Now;
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

                case 2:
                    Codex_Date2 = DateTime.Now;
                    m = Codex_Date2.Month;
                    y = Codex_Date2.Year - 1;
                    d = Codex_Date2.Day;

                    if ((m == 2) && (m == 29)) d = 28;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // last  year

                case 3:
                    Codex_Date2 = DateTime.Now;
                    m = Codex_Date2.Month;
                    y = Codex_Date2.Year - 2;
                    d = Codex_Date2.Day;

                    if ((m == 2) && (m == 29)) d = 28;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // last two year

                case 4:
                    Codex_Date2 = DateTime.Now;
                    m = 8;
                    y = 1995;
                    d = 24;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // last 1995-today

                case 5:
                    Codex_Date2 = DateTime.Now;
                    m = 1;
                    y = 1990;
                    d = 1;

                    Codex_Date1 = new DateTime(y, m, d);

                    break; // Full interval
                case 6:
                    Codex_Date2 = DateTime.Now;
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
            Codex_AutorSQL = "";
            Codex_TypeSQL = "";
            Codex_SubjectSQL = "";
            Codex_WordSQL = "";
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
            History_Search_Combo.SelectedIndex = 0; // Find in Caption
            Codex_AccessCombo.SelectedIndex = 0;
            //Codex_Filer.SelectedIndex = Codex_FilterV;

        }

        #endregion Codex




        #endregion Find Resetst

        #region Find SQL Srtipt Generation
        #region Codex


        private String Codex_GenerateFindSQLForDeleted()
        {



            String Fields = "id, H_Date, H_Status, C_ID,C_Caption,C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat,(CASE (ISNULL(DATALENGTH(C_Attach),0)) WHEN 0 THEN 0  ELSE 1 END) AS L_AttachmentSize, 0 as C_ShowHistory ";
            String StrHeader = "SELECT " + Fields + " FROM CODEXDS_DDOCS_History WHERE ";
            String Strd = "( ( C_Date >= " +
                  "CONVERT(DATETIME, '" + Codex_Date1.Year.ToString() + @"-" + Codex_Date1.Month.ToString("00") + @"-" + Codex_Date1.Day.ToString("00") + "T00:00:00.000' ,126) )" +
                " and " +
                "( C_Date <= " +
                  "CONVERT(DATETIME, '" + Codex_Date2.Year.ToString() + @"-" + Codex_Date2.Month.ToString("00") + @"-" + Codex_Date2.Day.ToString("00") + "T23:59:59.997' ,126) )" + " ) ";

            String Strd_H = " And ( ( H_Date >= " +
                  "CONVERT(DATETIME, '" + CodexHistory_Date1.Year.ToString() + @"-" + CodexHistory_Date1.Month.ToString("00") + @"-" + CodexHistory_Date1.Day.ToString("00") + "T00:00:00.000' ,126) )" +
                " and " +
                "( H_Date <= " +
                  "CONVERT(DATETIME, '" + CodexHistory_Date2.Year.ToString() + @"-" + CodexHistory_Date2.Month.ToString("00") + @"-" + CodexHistory_Date2.Day.ToString("00") + "T23:59:59.997' ,126) )" + " ) ";

            String Strc = "And " + CodexString.CaptionAnaliser(Codex_Search_Edit.Text, "C_Caption", "'") + " ";

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


            String SearchDeletedOnly = " And ( H_Status = -16 ) ";


            String Strf = "";

            if (Codex_AccessCombo.SelectedIndex == 0) Strf = "";
            if (Codex_AccessCombo.SelectedIndex == 1) Strf = " And (C_Group = 0)";
            if (Codex_AccessCombo.SelectedIndex == 2) Strf = " And (C_Group = 1)";


            string FullSQL = StrHeader + Strd + Strc + Strn + Stra + Strt + Strs + Strw + StrST + StrCT + StrComments + StrAdvancedAttribute + Strf + SearchDeletedOnly;

            return FullSQL;

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

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            HomeClick();
        }

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void codexListBox1_Load(object sender, EventArgs e)
        {

        }
    }
}