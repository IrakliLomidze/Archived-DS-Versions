using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILG.Codex.CodexR4;
using ILG.Codex.Strings;
using ILG.Codex.CodexR4.CodexSettings;

namespace ILG.Codex.CodexR4
{
    public partial class IDFinder : Form
    {
        public Form1 MainForm;
        public IDFinder()
        {
            InitializeComponent();
        }

        private void IDFinder_Load(object sender, EventArgs e)
        {
            this.Width = this.Codex_Attrib_Edit.Left + this.Codex_Attrib_Edit.Width + ultraLabel9.Left * 2;// label14.Left * 2;
            EDate1.Text = PickDate.DateToString(Dt);
            LoadTables();
            LoadListTables();
            DisplayTables();
            Return_ID = -1;
        }

        private void ultraTextEditor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        DateTime Dt = DateTime.Now;
        private void ultraButton7_Click(object sender, EventArgs e)
        {
            var dlg2 = new PickDate(Dt);
            Point dc2 = new Point(EDate1.Location.X, EDate1.Location.Y);
            Point dc =  this.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            EDate1.Text = dlg2.ToString();
            Dt = dlg2.PickedDate;
        }



        DataSet DS;
        
        
        public void LoadTables()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                                       "SELECT * FROM CodexDS_DAUTHOR ORDER By A_Order;" +
                                       "SELECT * FROM CodexDS_DTYPE ORDER By T_Order;" +
                                       "SELECT * FROM CodexDS_DSubject ORDER By S_Order;" +
                                       "SELECT * FROM CodexDS_DWords ORDER By W_Order;" +
                                       "SELECT * FROM CodexDS_DCategory ORDER By C_Order;" +
                                       "SELECT * FROM CodexDS_DStatus ORDER By C_Order;",
                                       SQLConnectionStrings.Default.ConnectionString_CodexDS);
                DS = new DataSet();
                
                DataTableMapping dtm3, dtm4, dtm5, dtm6, dtm7, dtm8;
                dtm3 = da.TableMappings.Add("Table", "CodexDS_DAUTHOR");
                dtm4 = da.TableMappings.Add("Table1", "CodexDS_DTYPE");
                dtm5 = da.TableMappings.Add("Table2", "CodexDS_DSubject");
                dtm6 = da.TableMappings.Add("Table3", "CodexDS_DWords");
                dtm7 = da.TableMappings.Add("Table4", "CodexDS_DCategory");
                dtm8 = da.TableMappings.Add("Table5", "CodexDS_DStatus");
                da.Fill(DS);
                // Visited


            }
            catch (Exception ex)
            {
                ILG.Windows.Forms.ILGMessageBox.ShowE("ბაზიდან ინფორმაციის წაკითხვა ვერ ხერხდება", ex.Message.ToString());
                // Force to Exit
            }

        }

        public void DisplayTables()
        {
            CAuthor.DataSource = DS.Tables["CodexDS_DAUTHOR"];
            CAuthor.DisplayMember = "A_Caption";
            CAuthor.ValueMember = "A_ID";
            CAuthor.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;

            CAuthor.DisplayLayout.Bands[0].Columns["A_ID"].Hidden = true;
            CAuthor.DisplayLayout.Bands[0].Columns["A_Order"].Hidden = true;
            CAuthor.DisplayLayout.Bands[0].ColHeadersVisible = false;
            CAuthor.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            CAuthor.DisplayLayout.Grid.Width = CAuthor.Width;
            CAuthor.DisplayLayout.Bands[0].Override.DefaultColWidth = CAuthor.Width;

            CAuthor.MinDropDownItems = 5;
            CAuthor.MaxDropDownItems = 10;


            CType.DataSource = DS.Tables["CodexDS_DTYPE"];
            CType.DisplayMember = "T_Caption";
            CType.ValueMember = "T_ID";
            CType.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;

            CType.DisplayLayout.Bands[0].Columns["T_ID"].Hidden = true;
            CType.DisplayLayout.Bands[0].Columns["T_Order"].Hidden = true;
            CType.DisplayLayout.Bands[0].ColHeadersVisible = false;
            CType.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //CType.DisplayLayout.Grid.Width = CType.Width;
            CType.DisplayLayout.Bands[0].Override.DefaultColWidth = CAuthor.Width;

            CType.MinDropDownItems = 5;
            CType.MaxDropDownItems = 10;


            //CCategory

            CCategory.DataSource = DS.Tables["CodexDS_DCategory"];
            CCategory.DisplayMember = "C_Caption";
            CCategory.ValueMember = "C_ID";
            CCategory.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;

            CCategory.DisplayLayout.Bands[0].Columns["C_ID"].Hidden = true;
            CCategory.DisplayLayout.Bands[0].Columns["C_Order"].Hidden = true;
            CCategory.DisplayLayout.Bands[0].ColHeadersVisible = false;
            CCategory.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //           CCategory.DisplayLayout.Grid.Width = CAuthor.Width;
            CCategory.DisplayLayout.Bands[0].Override.DefaultColWidth = CCategory.Width;

            CCategory.MinDropDownItems = 5;
            CCategory.MaxDropDownItems = 10;


            //CSbject
            CSbject.DataSource = DS.Tables["CodexDS_DSubject"];
            CSbject.DisplayMember = "S_Caption";
            CSbject.ValueMember = "S_ID";
            CSbject.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;

            CSbject.DisplayLayout.Bands[0].Columns["S_ID"].Hidden = true;
            CSbject.DisplayLayout.Bands[0].Columns["S_Order"].Hidden = true;
            CSbject.DisplayLayout.Bands[0].ColHeadersVisible = false;
            CSbject.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //           CCategory.DisplayLayout.Grid.Width = CAuthor.Width;
            CSbject.DisplayLayout.Bands[0].Override.DefaultColWidth = CSbject.Width;

            CSbject.MinDropDownItems = 5;
            CSbject.MaxDropDownItems = 10;

            
            //CStatus
            CStatus.DataSource = DS.Tables["CodexDS_DStatus"];
            CStatus.DisplayMember = "C_Caption";
            CStatus.ValueMember = "C_ID";
            CStatus.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;

            CStatus.DisplayLayout.Bands[0].Columns["C_ID"].Hidden = true;
            CStatus.DisplayLayout.Bands[0].Columns["C_Order"].Hidden = true;
            CStatus.DisplayLayout.Bands[0].ColHeadersVisible = false;
            CStatus.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //           CCategory.DisplayLayout.Grid.Width = CAuthor.Width;
            CStatus.DisplayLayout.Bands[0].Override.DefaultColWidth = CStatus.Width;

            CStatus.MinDropDownItems = 5;
            CStatus.MaxDropDownItems = 10;

        }

        private void ultraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
            EDate1.Enabled = ultraCheckEditor1.Checked;
            ultraButton7.Enabled = ultraCheckEditor1.Checked;
        }


        private string Get_ShowHistoryFiled()
        {
            string ResultSQL = ", 0 AS C_ShowHistory ";
            if (License.IsHistoryAccessGranted() == false) return ResultSQL;

            String HisotryPublicSQL = ", (CASE " +
                               "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NULL THEN 0 " +
                               "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL THEN  (Select Count (C_ID) From CodexDS_DDOCS_History Where (CodexDS_DDOCS_History.C_ID = CodexDS_DDOCS.C_ID AND CodexDS_DDOCS_History.H_Status = 0) )" +
                               "   ELSE 0 " +
                               "END) as  C_ShowHistory ";

            if (License.IsHistoryExtendedAccessGranted() == false) return HisotryPublicSQL;

            String HisotryFullSQL = ", (CASE " +
                               "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NULL THEN 0 " +
                               "    WHEN OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL THEN  (Select Count (C_ID) From CodexDS_DDOCS_History Where (CodexDS_DDOCS_History.C_ID = CodexDS_DDOCS.C_ID) )" +
                               "   ELSE 0 " +
                               "END) as  C_ShowHistory ";

            return HisotryFullSQL;
        }


        private String Codex_GenerateFindSQL()
        {
            String SpecialField = Get_ShowHistoryFiled();



            String Fields = "C_ID,C_Caption,C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_Status,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat,(CASE (ISNULL(DATALENGTH(C_Attach),0)) WHEN 0 THEN 0  ELSE 1 END) AS L_AttachmentSize " + SpecialField;
            String StrHeader = "SELECT " + Fields + " FROM CODEXDS_DDOCS WHERE (1=1) ";
            String Strd = "";
            if (ultraCheckEditor1.Checked == true)
            {

                 Strd = " And ( ( C_Date >= " +
                      "CONVERT(DATETIME, '" + Dt.Year.ToString() + @"-" + Dt.Month.ToString("00") + @"-" + Dt.Day.ToString("00") + "T00:00:00.000' ,126) )" +
                    " and " +
                    "( C_Date <= " +
                      "CONVERT(DATETIME, '" + Dt.Year.ToString() + @"-" + Dt.Month.ToString("00") + @"-" + Dt.Day.ToString("00") + "T23:59:59.997' ,126) )" + " ) ";
            }

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


            String Stra = "";
            if (CAuthor.Value != null) Stra = " and ( C_Author = " + CAuthor.Value.ToString() + " ) ";
            if (CAuthor.Text.Trim() == "") Stra = "";

            String Strt = "";
            if (CType.Value != null) Strt = " and ( C_Type = " + CType.Value.ToString() + " ) ";
            if (CType.Text.Trim() == "") Strt = "";


            String Strs = "";
            if (CSbject.Value != null) Strs = " and ( C_Subject = " + CSbject.Value.ToString() + " ) ";
            if (CSbject.Text.Trim() == "") Strs = "";

            String StrST = "";
            if (CStatus.Value != null) StrST = " and ( C_Status = " + CStatus.Value.ToString() + " ) ";
            if (CStatus.Text.Trim() == "") StrST = "";

            String StrCT = "";
            if (CCategory.Value != null) StrCT = " and ( C_Category = " + CCategory.Value.ToString() + " ) ";
            if (CCategory.Text.Trim() == "") StrCT = "";


            string FullSQL = StrHeader + Strd + Strc + Strn + Stra + Strt + Strs + StrST + StrCT + StrComment + StrAdditional;
            
            return FullSQL;

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
        public DataSet LockupTables;
        public DataTable CodexVisited;
      

        public void LoadListTables()
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
                    ILG.Windows.Forms.ILGMessageBox.ShowE(
                        "სერვერთან კომუნიკაციის პრობლემა, დარწმუნდით, რომ SQL Service გაშვებულია \n" +
                        "ან შეცვალეთ კონფიგურაციის ფაილი.\n", //+
                        //"პროგრამის გაგრძელება შეუძლებელია, იგი დაიხურება ",
                        "", ex.Message.ToString(),
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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

                Codex_Result.Tables[0].Rows[i]["TopCaption"] = @S;
                Codex_Result.Tables[0].Rows[i]["C_Caption"] = @FilterString(Codex_Result.Tables[0].Rows[i]["C_Caption"].ToString());


            }

            ///CodexResultV = CodexResult.Select("", "C_Date DESC");

        }

        #endregion Codex






        #endregion Fill Results and Result DataSets


       
        private void Codex_Search_Button_Click(object sender, EventArgs e)
        {
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

            //CodexPos = 1;
            //CodexList = true;
            this.codexListBox1.Visited = this.CodexVisited;
            this.codexListBox1.Configure(StatusAttributeConfiguration.ListConfiguration, License.IsHistoryAccessGranted());
            this.codexListBox1.DataSource = Codex_Result.Tables[0].Select("", "C_Date DESC");
            this.codexListBox1.FillGrid();
            codexListBox1.Enabled = true;
            //this.ultraStatusBar1.Text = "მოძებნილი დოკუმენტეის რაოდება = " + Codex_Result.Tables[0].Rows.Count.ToString();
        }

        public int Return_ID =-1;
        private void codexListBox1_DocumentClick(object sender, CodexDSListBox.CodexDSListEventArgs e)
        {
            //if (Codex_Result == null) return;
           // if (Codex_Result.Tables.Count == 0) return;
           // if (Codex_Result.Tables[0].Rows.Count == 0) return;
            Return_ID = e._ID;
            Close();
        }

        public bool ISDocumentExsists(int ID)
        {
            string strsql = "Select C_ID FROM CODEXDS_DDOCS WHERE C_ID = " + ID.ToString() + " ";
            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet dst = new DataSet();
            dacgl.Fill(dst);
            if (dst.Tables[0].Rows.Count == 1) return true; // Document Not Found
            return false;
        }


        private void TestLink()
        {
            if (codexListBox1.Enabled == false) return;

            int id = codexListBox1.Active_ID;

            if (ISDocumentExsists(id) == false)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი ბაზაში არ მოიძებნა");
                return;
            }

            Form_Test_Document T = new Form_Test_Document();
            T.MainForm = this.MainForm;
            T.ShowInTaskbar = false;
            //T.ShowModal(id);
            T.Show();
            T.Hide();
            int r = T.CodexOpenTestDocument(id);
            if (r != 0) T.Close();
            else T.ShowDialog();
        }

  
        private void ultraButton1_Click_1(object sender, EventArgs e)
        {
            TestLink();
        }

    }
}
