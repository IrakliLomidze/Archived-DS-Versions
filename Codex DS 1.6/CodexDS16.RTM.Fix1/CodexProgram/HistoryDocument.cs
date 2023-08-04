using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.IO;
using ILG.Windows.Forms;
using ILG.Codex.CodexR4;
using ILG.Codex.CodexR4.CodexSettings;
using ILG.Codex.CodexR4.DocumentForm;
using ILG.Codex.CodexR4.JsonConfigurations;
using ILG.Codex.CodexR4.UI;
using ILG.Codex.CodexR4.History;

namespace ILG.Codex.CodexR4
{
    public partial class HistoryDocument : Form
    {

        public BaseTxDocument TxDocument;

        public string DocumentCaption;
        public string DocumentTitle;


        int DefaultDocumentFormat = 0;
        string SellectedPDF = "";
        string Codex_DocEncoding = "";
        DataSet DS;
        DateTime Dt;
        DateTime Dt_H;
        int DocumentMode = -1;
        bool isDocAtrChanged = false;
        public Form1 FormMain;
        Form_Test_Document F_TEST_DOC;
        int History_IID = -1;
        int theDocumentID = -1;
        bool isDeletedDocument = false;
        int SSS; // Sectert Status

        private void NewDocumentMode()
        {
            TxDocument.Document_TXNew();

            DocumentMode = 1; // Add
            CLinkType.SelectedIndex = 1;
            CLinkAccess.SelectedIndex = 0;
            ElinkOrder.Text = "0";
            CSecStatus.SelectedIndex = 0;
            CDocFormat.SelectedIndex = 0;
            EDate1.Text = PickDate.DateToString(Dt);

            #region Create New Empty Zip File
            ZipFileName = DirectoryConfiguration.CodexTemporaryDirectory + "znew_" + DateTime.Now.Ticks.ToString() + ".zip";
            // Create Attach Zip File name


        
            #endregion Create New Empty Zip File

            #region Create new DLink
            DLinks = new DataSet("DataLink");
            // Empty Links
            DLinks.Tables.Add("Links");

            DataColumn col = new DataColumn("ID");
            col.DataType = System.Type.GetType("System.Int32");
            col.ReadOnly = false;
            col.AutoIncrement = false;
            DLinks.Tables["Links"].Columns.Add(col);

            DLinks.Tables["Links"].PrimaryKey = new DataColumn[] { DLinks.Tables["Links"].Columns["ID"] };


            col = new DataColumn("Order");
            col.DataType = System.Type.GetType("System.Double");
            col.ReadOnly = false;
            col.AutoIncrement = false;
            DLinks.Tables["Links"].Columns.Add(col);

            col = new DataColumn("Color");
            col.DataType = System.Type.GetType("System.Int32");
            col.ReadOnly = false;
            col.AutoIncrement = false;
            DLinks.Tables["Links"].Columns.Add(col);

            col = new DataColumn("Status");
            col.DataType = System.Type.GetType("System.Int32");
            col.ReadOnly = false;
            col.AutoIncrement = false;
            DLinks.Tables["Links"].Columns.Add(col);

            col = new DataColumn("Type");
            col.DataType = System.Type.GetType("System.Int32");
            col.ReadOnly = false;
            col.AutoIncrement = false;
            DLinks.Tables["Links"].Columns.Add(col);

            col = new DataColumn("Access");
            col.DataType = System.Type.GetType("System.Int32");
            col.ReadOnly = false;
            col.AutoIncrement = false;
            DLinks.Tables["Links"].Columns.Add(col);

            col = new DataColumn("Caption");
            col.DataType = System.Type.GetType("System.String");
            col.ReadOnly = false;
            col.MaxLength = 255;
            DLinks.Tables["Links"].Columns.Add(col);


            col = new DataColumn("Link");
            col.DataType = System.Type.GetType("System.Int32");
            col.ReadOnly = false;
            col.AutoIncrement = false;
            DLinks.Tables["Links"].Columns.Add(col);

            col = new DataColumn("Version");
            col.DataType = System.Type.GetType("System.Int32");
            col.ReadOnly = false;
            col.AutoIncrement = false;
            DLinks.Tables["Links"].Columns.Add(col);
            #endregion Create new DLink


            #region Grid
            CLinkGrid.DataSource = DLinks.Tables[0];
            CLinkGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            CLinkGrid.DisplayLayout.Key = "ID";

            for (int i = 0; i <= CLinkGrid.DisplayLayout.Bands[0].Columns.Count - 1; i++)
                CLinkGrid.DisplayLayout.Bands[0].Columns[i].Hidden = true;

            CLinkGrid.DisplayLayout.Bands[0].HeaderVisible = false;



            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].Header.Caption = "მიმდევრობა";
            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].Header.VisiblePosition = 1;
            //ultraGrid1.DisplayLayout.Bands[0].Columns["Order"].Width = 30;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


            CLinkGrid.DisplayLayout.Bands[0].Columns["Type"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Type"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Type"].Header.VisiblePosition = 2;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Type"].Header.Caption = "ტიპი";

            CLinkGrid.DisplayLayout.Bands[0].Columns["access"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["access"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["access"].Header.VisiblePosition = 3;
            CLinkGrid.DisplayLayout.Bands[0].Columns["access"].Header.Caption = "დაშვება";

            CLinkGrid.DisplayLayout.Bands[0].Columns["Link"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Link"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Link"].Header.VisiblePosition = 4;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Link"].Header.Caption = "კავშირი";

            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].Header.VisiblePosition = 5;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].Header.Caption = "კავშირის სახელი";
            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            //CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"]. .CellDisplayStyle= Infragistics.Win.UltraWinGrid.CellDisplayStyle. ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

            CLinkGrid.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            CLinkGrid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.WhiteSmoke;//AliceBlue;//.LightSteelBlue;// .Wheat;
            CLinkGrid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;


            CLinkGrid.DisplayLayout.MaxColScrollRegions = 1;
            CLinkGrid.DisplayLayout.MaxRowScrollRegions = 1;

            #endregion Grid



            //xxx
            //ultraToolbarsManager1.Tools["DDSaveNew"].SharedProps.Enabled = true;
            //ultraToolbarsManager1.Tools["DDNewDocument"].SharedProps.Enabled = true;
            ultraToolbarsManager1.Tools["DDSaveAsNew"].SharedProps.Enabled = false;
            ultraToolbarsManager1.Tools["DDDeleteDocument"].SharedProps.Enabled = false;
            ultraToolbarsManager1.Tools["DDSaveChanges"].SharedProps.Visible = false;

            this.Cursor = System.Windows.Forms.Cursors.Default;

            ultraTabControl13.Visible = false;
            ultraTabControl13.Enabled = false;
            this.Text = "ახალი დოკუმენტი";


            #region History Ribbon UI

            //if (License.IsHistoryAccessGranted() == true)
            //{
            //    ultraToolbarsManager1.Ribbon.Tabs["RHistory"].Visible = false;
            //    ultraToolbarsManager1.Ribbon.Tabs["RHistory"].Groups["History"].Visible = false;
            //    ultraToolbarsManager1.Tools["History_Refresh"].SharedProps.Enabled = false;
            //    ultraToolbarsManager1.Tools["History_Refresh"].SharedProps.Visible = false;

            //    ultraToolbarsManager1.Tools["History_Edit"].SharedProps.Enabled = false;
            //    ultraToolbarsManager1.Tools["History_Edit"].SharedProps.Visible = false;

            //    ultraToolbarsManager1.Tools["History_Delete"].SharedProps.Enabled = false;
            //    ultraToolbarsManager1.Tools["History_Delete"].SharedProps.Visible = false;

            //}

            #endregion History Ribbon UI



        }


        public HistoryDocument()
        {
            InitializeComponent();

            TxDocument = new BaseTxDocument();
            this.formContainer1.ShowForm(TxDocument);

            F_TEST_DOC = new Form_Test_Document();
            F_TEST_DOC.MainForm = (Form1)this.FormMain;

            if (Properties.Settings.Default.DocumentEncogingPolicy == true)
            {
                CEncoding.Enabled = true;
                CEncoding.Visible = true;
                LEncoding.Enabled = true;
                LEncoding.Visible = true;

                CEncoding.SelectedIndex = Properties.Settings.Default.DocumentDefaultEncoding;
            }
            else
            {
                CEncoding.Enabled = false;
                CEncoding.Visible = false;
                LEncoding.Enabled = false;
                LEncoding.Visible = false;

            }
            
       
        }

        const int MAX_PATH = 260;
        public int EditDocumentMode(int Id, bool IsDeletedDocumentMode )
        {

            #region Prepare Interface
            NewDocumentMode();
            
            DocumentMode = 0; // Change
            
            //xxx
            //ultraToolbarsManager1.Tools["DDSaveNew"].SharedProps.Enabled = false;
            //ultraToolbarsManager1.Tools["DDNewDocument"].SharedProps.Enabled = true;
            ultraToolbarsManager1.Tools["DDSaveAsNew"].SharedProps.Enabled = true;
            ultraToolbarsManager1.Tools["DDDeleteDocument"].SharedProps.Enabled = true;
            ultraToolbarsManager1.Tools["DDSaveChanges"].SharedProps.Visible = true;

            this.Cursor = System.Windows.Forms.Cursors.Default;

            ultraTabControl13.Visible = false;
            ultraTabControl13.Enabled = false;
            this.Text = "დოკუმენტი";
            #endregion Prepare Interface

            // Region Read Documetn IDEDIT

            string DocFileName;
            string LinkFileName;
            string LinkSchemaFileName;

            IntPtr hImgSmall; //the handle to the system image list

            SHFILEINFO shinfo = new SHFILEINFO();


            #region Read Information From Database
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            // Define Document Call Statment
            String Fields = "id, H_Date, H_Status, C_ID,C_Caption,C_TEXT,C_Link, C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat,C_Attach,C_DocText";
            string strsql = "Select " + Fields + " FROM CodexDS_DDOCS_History WHERE id = " + Id.ToString() + " ";
            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet dst = new DataSet();
            dacgl.Fill(dst);
            if (dst.Tables[0].Rows.Count != 1) return -1; // Document Not Found


            if ((int)dst.Tables[0].Rows[0]["C_Group"] != 0)
            {
                if (License.IsEnterInConfidentialDocumentAlowed() == false)
                {
                    ILGMessageBox.Show("თქვენ არ გაქვთ უფლება შეხვიდეთ ამ დოკუმენტში");
                    return -1000;
                }
            }

            #endregion Read Information From Database        
            
            #region  Codex Temp Files
            String U1 = DateTime.Now.Ticks.ToString();
            
            string CodexDocTempFilename = DirectoryConfiguration.CodexTemporaryDirectory + "\\Codex_" + Id.ToString() + U1;

            while (System.IO.File.Exists(CodexDocTempFilename) == true)
            {
                U1 = DateTime.Now.Ticks.ToString();
                CodexDocTempFilename = DirectoryConfiguration.CodexTemporaryDirectory + "\\Codex_" + Id.ToString() + U1;
            }

            U1 = DateTime.Now.Ticks.ToString();
            string CodexLinkTempFilename = DirectoryConfiguration.CodexTemporaryDirectory + "\\CodexLink_" + Id.ToString() + U1;

            while (System.IO.File.Exists(CodexLinkTempFilename) == true)
            {
                U1 = DateTime.Now.Ticks.ToString();
                CodexLinkTempFilename = DirectoryConfiguration.CodexTemporaryDirectory + "\\CodexLink_" + Id.ToString() + U1;
            }


            #endregion Codex Temp Files

            #region SaveBlobs

            byte[] doc = (byte[])dst.Tables[0].Rows[0]["C_Text"]; 
            FileStream fs = new FileStream(CodexDocTempFilename + ".tmpD", FileMode.Create, FileAccess.Write);
            fs.Write(doc, 0, doc.Length);
            fs.Close();


            doc = (byte[])dst.Tables[0].Rows[0]["C_LINK"];
            fs = new FileStream(CodexLinkTempFilename + ".tmpL", FileMode.Create, FileAccess.Write);
            fs.Write(doc, 0, doc.Length);
            fs.Close();

            
            DefaultDocumentFormat = (int)dst.Tables[0].Rows[0]["C_DocFormat"];

            

            
            if (dst.Tables[0].Rows[0]["C_Attach"] != DBNull.Value)
            {
                doc = (byte[])dst.Tables[0].Rows[0]["C_Attach"];
                fs = new FileStream(CodexLinkTempFilename + ".tmpA", FileMode.Create, FileAccess.Write);
                fs.Write(doc, 0, doc.Length);
                fs.Close();
                HasAttachments = true;
                ZipFileName = CodexLinkTempFilename + ".tmpA";
            }
            else { HasAttachments = false; }


            // UnZip Document there

            CodexZip.UnZip(CodexDocTempFilename + ".tmpD", "D.RTF", CodexDocTempFilename + ".RTF", OverWrite: true);
            //C1.C1Zip.C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Open(CodexDocTempFilename + ".tmpD");

            if (DefaultDocumentFormat == 0)
            {
                //zf.Entries.Extract("D.RTF", CodexDocTempFilename + ".RTF");
                CodexZip.UnZip(CodexDocTempFilename + ".tmpD", "D.RTF", CodexDocTempFilename + ".RTF", OverWrite: true);
            }
            else
            {
                //zf.Entries.Extract("D.PDF", CodexDocTempFilename + ".PDF");
                CodexZip.UnZip(CodexDocTempFilename + ".tmpD", "D.PDF", CodexDocTempFilename + ".PDF", OverWrite: true);
            }
            //zf.Close();



            CodexZip.UnZip(CodexLinkTempFilename + ".tmpL", "Links.XML", CodexDocTempFilename + "Links2.XML", OverWrite: true);
            CodexZip.UnZip(CodexLinkTempFilename + ".tmpL", "LinksSchema.XML", CodexDocTempFilename + "LinksSchema2.XML", OverWrite: true);

            // UnZip Links there
            //C1.C1Zip.C1ZipFile zf2 = new C1.C1Zip.C1ZipFile();
            
            //zf2.Open(CodexLinkTempFilename + ".tmpL");
            //zf2.Entries.Extract("Links.XML", CodexDocTempFilename + "Links2.XML");
            //zf2.Entries.Extract("LinksSchema.XML", CodexDocTempFilename + "LinksSchema2.XML");
            //zf2.Close();
            
            LinkFileName = CodexDocTempFilename + "Links2.XML";
            LinkSchemaFileName = CodexDocTempFilename + "LinksSchema2.XML";
            
            File.Delete(CodexDocTempFilename + ".tmpD");
            File.Delete(CodexLinkTempFilename + ".tmpL");
            //File.Delete(CodexDocTempFilename + ".zip");


            // Document Caption
            if (DefaultDocumentFormat == 0)
                DocFileName = CodexDocTempFilename + ".rtf";
            else
            {
                DocFileName = CodexDocTempFilename + ".pdf";
                this.SellectedPDF = DocFileName;
            }

            //LinkFileName = CodexDocTempFilename + "_L.XML";
            //LinkSchemaFileName = CodexDocTempFilename + "_LS.XML";
            this.Cursor = System.Windows.Forms.Cursors.Default;

            #endregion SaveBlobs

  
            
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            #region Load Document
            if (DefaultDocumentFormat == 0)
            {
                TXTextControl.LoadSettings LoadSettings = new TXTextControl.LoadSettings();
                TxDocument.LoadRTFFileInTxTextEditor(DocFileName);
                //textControl1.Load(DocFileName, TXTextControl.StreamType.RichTextFormat,LoadSettings);

                File.Delete(DocFileName);
                //DocumentTab.SelectedTab = DocumentTab.Tabs[0];
                this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
            }
            else
            {
                axAcroPDF1.LoadFile(DocFileName);
                //File.Delete(DocFileName);
                //DocumentTab.SelectedTab = DocumentTab.Tabs[1];
                this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[1];
            }

            #endregion Load Document

            #region Load Links
            DLinks.ReadXmlSchema(LinkSchemaFileName);
            DLinks.ReadXml(LinkFileName, System.Data.XmlReadMode.InferSchema);
            File.Delete(LinkFileName);

            CLinkGrid.DataSource = DLinks.Tables[0];//.Select("", "ORDER ASC");

            #region Grid
            CLinkGrid.DataSource = DLinks.Tables[0];
            CLinkGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            CLinkGrid.DisplayLayout.Key = "ID";

            for (int i = 0; i <= CLinkGrid.DisplayLayout.Bands[0].Columns.Count - 1; i++)
                CLinkGrid.DisplayLayout.Bands[0].Columns[i].Hidden = true;

            CLinkGrid.DisplayLayout.Bands[0].HeaderVisible = false;



            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].Header.Caption = "მიმდევრობა";
            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].Header.VisiblePosition = 1;
            //ultraGrid1.DisplayLayout.Bands[0].Columns["Order"].Width = 30;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Order"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


            CLinkGrid.DisplayLayout.Bands[0].Columns["Type"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Type"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Type"].Header.VisiblePosition = 2;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Type"].Header.Caption = "ტიპი";

            CLinkGrid.DisplayLayout.Bands[0].Columns["access"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["access"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["access"].Header.VisiblePosition = 3;
            CLinkGrid.DisplayLayout.Bands[0].Columns["access"].Header.Caption = "დაშვება";

            CLinkGrid.DisplayLayout.Bands[0].Columns["Link"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Link"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Link"].Header.VisiblePosition = 4;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Link"].Header.Caption = "კავშირი";

            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].Hidden = false;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].Header.VisiblePosition = 5;
            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].Header.Caption = "კავშირის სახელი";
            CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            //CLinkGrid.DisplayLayout.Bands[0].Columns["Caption"]. .CellDisplayStyle= Infragistics.Win.UltraWinGrid.CellDisplayStyle. ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

            CLinkGrid.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            CLinkGrid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.WhiteSmoke;//AliceBlue;//.LightSteelBlue;// .Wheat;
            CLinkGrid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;


            CLinkGrid.DisplayLayout.MaxColScrollRegions = 1;
            CLinkGrid.DisplayLayout.MaxRowScrollRegions = 1;

            #endregion Grid

            //CLinkGrid.Visited = (Form1)FormMain.CodexVisited;
           // CLinkGrid.InitializeVarialbles(2);
            //CLinkGrid.ProgramName = "CODEX";
            //CLinkGrid.FillGrid();

            #endregion LoadLinks

            #region Load Attachment
            if ((HasAttachments == true) && (License.IsAttachmentShow() == true))
            {
                //ZipArchive zipfile = new ZipArchive(new DiskFile(ZipFileName));

                List<string> filesinzip = CodexZip.GetEntitiesList(ZipFileName);

                if (filesinzip.Count != 0)
                {
                    foreach (var f in filesinzip)
                    {
                    
                        string st1 = DirectoryConfiguration.CodexTemporaryDirectory + "\\" + Path.GetFileName(f.ToString()).ToUpper().Trim();
                        st1 = st1.Replace("?", "_");

                        string str = Path.GetFileName(f.ToString()).Trim();

                        if (st1.Length >= MAX_PATH)
                        {
                            ILGMessageBox.Show("მიერთებული ფაილის დასახელება არის ოპერაციულ სისტეამში განსაზღვრულ სიგრძეზე დიდი" + System.Environment.NewLine +
                                                f.ToString() + System.Environment.NewLine +
                                                "შეცვალეთ მიერთებული ფაილის სახელი", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            CodexZip.UnZip(ZipFileName, f, st1);
                            File.SetAttributes(st1, FileAttributes.Normal);
                            hImgSmall = Win32.SHGetFileInfo(st1, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
                            File.Delete(st1);
                            //The icon is returned in the hIcon member of the shinfo struct
                            System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
                            imageList1.Images.Add(str, myIcon);
                        }

                        listView1.Items.Add(str, str);
       
                    }
                }
      
            }
            else
            {
                while (imageList1.Images.Count > 0)
                {
                    imageList1.Images.RemoveAt(0);
                }

                while (listView1.Items.Count > 0)
                {
                    listView1.Items.RemoveAt(0);
                }


            }

            #endregion Attachment

            this.Cursor = System.Windows.Forms.Cursors.Default;

            //CodexDocumentID = ID; // Document ID
            Codex_DocEncoding = dst.Tables[0].Rows[0]["C_DocEncoding"].ToString(); //"UNICODE"; //dst.Tables[0].Rows[0]["C_DocEncoding"].ToString();
            //            dst.Tables[0].Rows[0]["C_Addtional"]

            // Fileds
            ultraTextEditor1.Text = dst.Tables[0].Rows[0]["C_Caption"].ToString().Trim();
            // -----------------------------------------------------
            try 
            { CAuthor.Value = (int)dst.Tables[0].Rows[0]["C_Author"];}
            catch
            { CAuthor.Value = 0; }
            // -----------------------------------------------------
            try
            { CType.Value = (int)dst.Tables[0].Rows[0]["C_Type"];}
            catch
            { CType.Value = 0; }
            // -----------------------------------------------------
            try
            { CCategory.Value = (int)dst.Tables[0].Rows[0]["C_Category"];}
            catch
            { CCategory.Value = 0; }
            // -----------------------------------------------------
            try
            { CSbject.Value = (int)dst.Tables[0].Rows[0]["C_Subject"]; }
            catch
            { CSbject.Value = 0; }
            // -----------------------------------------------------
            try
            { CStatus.Value = (int)dst.Tables[0].Rows[0]["C_Status"]; }
            catch
            { CStatus.Value = 0; }
            // -----------------------------------------------------
            try
            { CSecStatus.SelectedIndex = (int)dst.Tables[0].Rows[0]["C_Group"]; }
            catch
            { CSecStatus.SelectedIndex = 0; }

            SSS = CSecStatus.SelectedIndex;


            CCategory.DisplayLayout.Bands[0].Columns[0].Width = CCategory.Width;

            ultraTextEditor2.Text = dst.Tables[0].Rows[0]["C_NumberStr"].ToString().Trim();
            EWord.Text = dst.Tables[0].Rows[0]["C_Words"].ToString().Trim();
            ultraTextEditor5.Text =  dst.Tables[0].Rows[0]["C_Coments"].ToString().Trim();
            ultraTextEditor6.Text = dst.Tables[0].Rows[0]["C_Addtional"].ToString().Trim();

            
            try
            { CDocFormat.SelectedIndex = (int)dst.Tables[0].Rows[0]["C_DocFormat"]; }
            catch
            { CDocFormat.SelectedIndex = 0; }

            if (CDocFormat.SelectedIndex == 1)
            {
                textBox1.Text = dst.Tables[0].Rows[0]["C_DocText"].ToString().Trim();
            }
            

            Dt = (DateTime)dst.Tables[0].Rows[0]["C_Date"];
            EDate1.Text = PickDate.DateToString(Dt);
            History_IID = Id;

            Dt_H = (DateTime)dst.Tables[0].Rows[0]["H_Date"];
            HistoryDate_Edit.Text = PickDate.DateToString(Dt_H);


            if (Properties.Settings.Default.DocumentEncogingPolicy == true)
            {
                if (dst.Tables[0].Rows[0]["C_DocEncoding"].ToString().Trim().ToUpper() == "UNICODE")
                {
                    CEncoding.SelectedIndex = 0;

                }
                else
                {
                    CEncoding.SelectedIndex = 1;
                }
            }

            theDocumentID = (int)dst.Tables[0].Rows[0]["C_ID"];

            if (License.IsModifiedHistoryGranted() == true)
            {
                HistoryStatus_Combo.Enabled = true;
                HistoryStatus_Combo.Visible = true;

                HistoryStatus_Label.Visible = true;

                HistoryStatus_Combo.Items.Clear();
                HistoryStatus_Combo.Items.Add(0, "ისტორიაში ჩანს");
                HistoryStatus_Combo.Items.Add(1, "ისტორიაში დამალულია");

                HistoryDate_Label.Visible = true;
                HistoryDate_Edit.Visible = true;
                HistoryDate_Edit.Enabled = true;
                HistoryDate_Button.Visible = true;
                HistoryDate_Button.Visible = true;
            }


            if (License.IsRecoverDeletedDocumentsGranted() == true)
            {
                HistoryStatus_Combo.Items.Clear();
                HistoryStatus_Combo.Items.Add(0, "ისტორიაში ჩანს");
                HistoryStatus_Combo.Items.Add(1, "ისტორიაში დამალულია");
                HistoryStatus_Combo.Items.Add(-1, "წაშლილია");
            }

            try
            { HistoryStatus_Combo.Value = (int)dst.Tables[0].Rows[0]["H_Status"]; }
            catch
            { HistoryStatus_Combo.Value = 0; }





      

            if (IsDeletedDocumentMode == true)
            {
                this.ultraToolbarsManager1.Tools["DDSaveChanges"].SharedProps.Enabled = false;
                this.ultraToolbarsManager1.Tools["DDSaveChanges"].SharedProps.Visible = false;

                this.ultraToolbarsManager1.Tools["DDSaveAsNew"].SharedProps.Enabled = false;
                this.ultraToolbarsManager1.Tools["DDSaveAsNew"].SharedProps.Visible = false;

                this.ultraToolbarsManager1.Tools["DDDeleteDocument"].SharedProps.Enabled = false;
                this.ultraToolbarsManager1.Tools["DDDeleteDocument"].SharedProps.Visible = false;

                Menu_IsRecoverDeletedDocumentsGranted(); // Grant Access if Allowed
            }
            else
            {
                Menu_IsDelleteInAdminMode();

                this.ultraToolbarsManager1.Tools["RecoverDocumentInTheDatabase"].SharedProps.Enabled = false;
                this.ultraToolbarsManager1.Tools["RecoverDocumentInTheDatabase"].SharedProps.Visible = false;
            }

        


            return 0;
        }

        private void Menu_IsRecoverDeletedDocumentsGranted()
        {
            if (License.IsRecoverDeletedDocumentsGranted() == true)
            {
                this.ultraToolbarsManager1.Tools["DeleteDocumentAdminMode"].SharedProps.Enabled = true;
                this.ultraToolbarsManager1.Tools["DeleteDocumentAdminMode"].SharedProps.Visible = true;

                this.ultraToolbarsManager1.Tools["RecoverDocumentInTheDatabase"].SharedProps.Enabled = true;
                this.ultraToolbarsManager1.Tools["RecoverDocumentInTheDatabase"].SharedProps.Visible = true;

            }
            else
            {
                this.ultraToolbarsManager1.Tools["DeleteDocumentAdminMode"].SharedProps.Enabled = false;
                this.ultraToolbarsManager1.Tools["DeleteDocumentAdminMode"].SharedProps.Visible = false;

                this.ultraToolbarsManager1.Tools["RecoverDocumentInTheDatabase"].SharedProps.Enabled = false;
                this.ultraToolbarsManager1.Tools["RecoverDocumentInTheDatabase"].SharedProps.Visible = false;
            }

        }

        private void Menu_IsDelleteInAdminMode()
        {
            if (License.IsRecoverDeletedDocumentsGranted() == true)
            {
                this.ultraToolbarsManager1.Tools["DeleteDocumentAdminMode"].SharedProps.Enabled = true;
                this.ultraToolbarsManager1.Tools["DeleteDocumentAdminMode"].SharedProps.Visible = true;
            }
            else
            {
                this.ultraToolbarsManager1.Tools["DeleteDocumentAdminMode"].SharedProps.Enabled = false;
                this.ultraToolbarsManager1.Tools["DeleteDocumentAdminMode"].SharedProps.Visible = false;
            }

        }


        #region Document Operation

        private void NewDocumentClick()
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ტექსტის და კავშირების გასუფთავება ? ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;
            NewDocumentMode();
        }


        private void OpenPDFDocument()
        {
            OpenFileDialog fd = new OpenFileDialog();
            //fd.InitialDirectory = startdir;
            fd.Filter = "All files (*.*)|*.*";

            fd.Title = "Open Document";
            fd.Filter = "Acrobat Document (*.pdf)|*.pdf|All files (*.*)|*.*";


            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            fd.Title = "Open File";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string str = System.IO.Path.GetExtension(fd.FileName).Trim().ToUpper();
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;


                string dstr = DirectoryConfiguration.CodexTemporaryDirectory.ToString() + "\\" + Path.GetFileName(fd.FileName);
                while (File.Exists(dstr) == true)
                {
                    dstr = DirectoryConfiguration.CodexTemporaryDirectory.ToString() + "\\" + DateTime.Now.Millisecond.ToString() + Path.GetFileName(fd.FileName);
                }
                File.Copy(fd.FileName, dstr);
                //this.axAcroPDF1.LoadFile(fd.FileName);
                this.axAcroPDF1.LoadFile(dstr);
                this.Cursor = System.Windows.Forms.Cursors.Default;
                SellectedPDF = fd.FileName;
            }

        }

   

   

        #region Find in Text

        #region ToolBars
 
       
        private void ultraTextEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }


        #endregion ToolBars

  
   
  
   
        #endregion Find in Text

     


        


        #endregion Document Operation

        private void button23_Click(object sender, EventArgs e)
        {
            LookUps f1 = new LookUps();
            f1.ultraButton6_Click(null, null);// T_Refresh.PerformClick();// Click(null, null);
            f1.ShowDialog();
        }

        private void DocumentAddEdit_Load(object sender, EventArgs e)
        {
            TxDocument.SetFocusAndZooming();
 

            LoadTables();
            DisplayTables();
            Dt = DateTime.Now;

            this.Left = 0;
            this.Top = 0;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

            
            this.Category_Mandatory_Label.Visible = CodexDSBehavioral.Default.UseCategoryAsMandatory;
            this.Status_Mandatory_Label.Visible = CodexDSBehavioral.Default.UseStatusAsMandatory;
            this.Number_Mandatory_Label.Visible = CodexDSBehavioral.Default.UseNumberAsManadatory;
            
            DoResize();

        }

        private void ultraToolbarsManager1_BeforeRibbonTabSelected(object sender, Infragistics.Win.UltraWinToolbars.BeforeRibbonTabSelectedEventArgs e)
        {
            //bool f = false;
            switch (e.Tab.Key.ToString())
            {
                case "RText": this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs[0]; DoResize(); TxDocument.SetFocusAndZooming(); break;
                case "RAttribute": this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs[1]; DoResize(); break;
                case "RLink": this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs[2]; break;
                case "RAttachment": this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs[3]; break;
            }
            //if (f != true) LastRibbon = e.Tab.Key.ToString();
        }


        int _CAuthor=-1; int _CType=-1; int _CCategory=-1;   int _CSbject=-1;    int _CStatus=-1;
        
        public void CallTableAfter()
        {
            if (_CAuthor   != -1) { try { CAuthor.Value    = _CAuthor; }   catch { CAuthor.Value   = 0; } }
            if (_CType     != -1) { try { CType.Value      = _CType; }     catch { CType.Value     = 0; } }
            if (_CCategory != -1) { try { CCategory.Value  = _CCategory; } catch { CCategory.Value = 0; } }
            if (_CSbject   != -1) { try { CSbject.Value    = _CSbject; }   catch { CSbject.Value   = 0; } }
            if (_CStatus   != -1) { try { CStatus.Value    = _CStatus; }   catch { CStatus.Value   = 0; } }
        }

        public void CallTableBefore()
        {
            _CAuthor = -1;  _CType = -1;  _CCategory = -1;  _CSbject = -1;  _CStatus = -1;
            if (CAuthor.Value   != null) _CAuthor   = (int)CAuthor.Value;
            if (CType.Value     != null) _CType     = (int)CType.Value;
            if (CCategory.Value != null) _CCategory = (int)CCategory.Value;
            if (CSbject.Value   != null) _CSbject   = (int)CSbject.Value;
            if (CStatus.Value   != null) _CStatus   = (int)CStatus.Value; 
        }
        
        
        public void CallTables(int i)
        {
            //LookUps tb = new LookUps();
            
            //tb.ultraButton1_Click(null, null); // Authors
            //tb.ultraButton6_Click(null, null); // Types
            //tb.S_Refresh_Click(null, null); // Subject
            //tb.ST_Refresh_Click(null, null); // Status
            //tb.C_Refresh_Click(null, null);// Category
            //tb.W_Refresh_Click(null, null);//Word
            //tb.SetTab(i);
            //tb.ShowDialog();
            
        }


        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {

                #region Documents
                case "NewDoc":    // ButtonTool
                    NewDocumentClick();
                    break;

                case "Open":    // ButtonTool
                    TxDocument.OpenDocumentInTXEditor(false); 
                    break;

                case "OpenR2":    // ButtonTool
                    TxDocument.OpenDocumentInTXEditor(true); 
                    break;

                case "Save":    // ButtonTool
                    TxDocument.SaveDocument();
                    break;

    

      

                case "FIND":    // ButtonTool
                    //bool gg =  CodexDocumentSearchTab.Visible;
                    //gg = !gg;
                    //CodexDocumentSearchTab.Visible = gg;
                    //CodexDocumentSearchTab.Enabled = gg;
                    break;



                case "PDF":    // PopupMenuTool
                    DefaultDocumentFormat = 1; ChangeViewF();
                    break;
                case "Word":    // PopupMenuTool
                    DefaultDocumentFormat = 0; ChangeViewF();
                    break;
                case "OpenPDF":
                    OpenPDFDocument();
                    break;
                case "ReduPDF":

                    break;


                #endregion Documents

                #region Attribute Tables
                //case "AuthorDialog":    // ButtonTool
                //      CallTableBefore();
                //      CallTables(0);
                //      LoadTables();
                //      DisplayTables();
                //      CallTableAfter();
                //    break;

                //case "TypeDialog":    // ButtonTool
                //    CallTableBefore();
                //    CallTables(1);
                //    LoadTables();
                //    DisplayTables();
                //    CallTableAfter();
                //    break;

                //case "SubjectDialog":    // ButtonTool
                //    CallTableBefore();
                //    CallTables(2);
                //    LoadTables();
                //    DisplayTables();
                //    CallTableAfter();
                //    break;

                //case "CategoryDialog":    // ButtonTool
                //    CallTableBefore();
                //    CallTables(3);
                //    LoadTables();
                //    DisplayTables();
                //    CallTableAfter();
                //    break;

                //case "StatusDialog":    // ButtonTool
                //    CallTableBefore();
                //    CallTables(4);
                //    LoadTables();
                //    DisplayTables();
                //    CallTableAfter();
                //    break;

                //case "KeyWordDialog":    // ButtonTool
                //    CallTableBefore();
                //    CallTables(5);
                //    LoadTables();
                //    DisplayTables();
                //    CallTableAfter();
                //    break;

                //case "DatabaseRefresh" :
                //     CallTableBefore();
                //     LoadTables();
                //     DisplayTables();
                //     CallTableAfter();

                //    break;

                #endregion Attribute Tables

                #region Links

                case "LinkNew":    // ButtonTool
                    LinkMode = 1;
                    ultraTabControl13.Visible = true;
                    ultraTabControl13.Enabled = true;
                    CLinkOperation.Text = "დამატება";
                    break;

                case "LinkChange":    // ButtonTool
                    LinkMode = 2;
                    ultraTabControl13.Visible = true;
                    ultraTabControl13.Enabled = true;
                    CLinkOperation.Text = "შეცვლა";
                    PerpareLinkEdit();
                    // View Grid Info
                    
                    break;

                        case "LinkDel":    // ButtonTool
                              DelLink();
                            break;

                        case "LinkClear":    // ButtonTool
                            CleanLink();
                            break;

                        case "LinkTest":    // ButtonTool
                            TestLink();
                            break;
                        #endregion Links

                #region Attachments
                        // Attahcments
                    
                        case "Attach":    // ButtonTool
                        AttachFile();
                        break;

                        case "Detech":    // ButtonTool
                        DettechFile();
                        break;

                        case "გაწმენდა":    // ButtonTool
                        ClearAttachs();
                        break;
                #endregion Attachments

                //case "DDNewDocument":    // ButtonTool
                //        HistoryDocument dd = new HistoryDocument();
                //        dd.FormMain = this.FormMain;
                //        dd.Show();
                //        dd.NewDocumentMode();
                //break;

                //case "DDSaveNew":    // ButtonTool
                //        DOSaveDocument();
                //    break;

                case "DDSaveAsNew":    // ButtonTool
                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ჩაწერა როგორც ახალის ?", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ჩაწერა როგორც ახალის ? დაადასტურეთ ", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                                        System.Windows.Forms.MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

                    DOSaveDocument();
                    break;

                case "DDSaveChanges":    // ButtonTool
                    DoEditDocumentInHistory();
                    break;

                
                case "DDDeleteDocument":    // ButtonTool
                     DoDeleteDocumentInHistory();
                    
                    break;

                case "DeleteDocumentAdminMode":    // ButtonTool
                    if (License.IsRecoverDeletedDocumentsGranted() == true)
                    {
                        DoAdminDeleteDocumentInHistory();
                    }

                    break;
                case "Close": Close(); break;

                case "RemoveSections" :
                    if (ILGMessageBox.Show("დოკუმენტიდან ყველა სექციის ამოღება \n" +
                                                             "სექციების ამოღებამ შეიძლება დააზიანოს დოკუმენტის ფორმატირება \n" +
                                                             "დაარწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                    if (ILGMessageBox.Show("დოკუმენტიდან ყველა სექციის ამოღება \n" +
                                                             "დაადასტურეთ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                    RemoveAllSections();
                    break;
   

                case "AttachmentSave":
                    SaveAttachment();
                    break;




                case "RecoverDocumentInTheDatabase":
                   DORecoveryoftheDocument();
                    break;

            }

        }

        #region PopUp
    
        #endregion PopUp

        private void RemoveAllSections()
        {
            TxDocument.RemoveAllSections();
            TxDocument.RemoveAllHeaderAndFooters();
            
        }


        private void DoResize()
        {
            TxDocument.SetFocusAndZooming();
            CCategory.DisplayLayout.Bands[0].Override.DefaultColWidth = CCategory.Width;
            CSbject.DisplayLayout.Bands[0].Override.DefaultColWidth = CSbject.Width;
            CWords.DisplayLayout.Bands[0].Override.DefaultColWidth = CWords.Width;
        }
  
        private void DocumentAddEdit_Resize(object sender, EventArgs e)
        {
            // Panelss();
            DoResize();

        }

        private void ChangeViewF()
        {
            switch (DefaultDocumentFormat)
            {
                case 0:
                    // Change to WORD
                    this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
                    // Disable Ribonns
                    this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup1"].Visible = true;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup2"].Visible = true;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup3"].Visible = true;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup4"].Visible = true;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup5"].Visible = true;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup6"].Visible = true;
                    this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup8"].Visible = false;

                    this.ultraToolbarsManager1.Tools["NewDoc"].SharedProps.Visible = true;
                    this.ultraToolbarsManager1.Tools["Open"].SharedProps.Visible = true;
                    this.ultraToolbarsManager1.Tools["Save"].SharedProps.Visible = true;
                    this.ultraToolbarsManager1.Tools["OpenPDF"].SharedProps.Visible = false;



                    this.ultraToolbarsManager1.ToolClick -= new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
                    try
                    {
                        (ultraToolbarsManager1.Tools["PDF"] as Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = false;
                        (ultraToolbarsManager1.Tools["Word"] as Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = true;
                    }
                    finally
                    {
                        this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
                    }


                    TxDocument.SetFocusAndZooming();
                    
                    break;
                case 1:

                    // Change to WORD
                    this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[1];
                    // Disable Ribonns
                    this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup1"].Visible = true;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup2"].Visible = false;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup3"].Visible = false;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup4"].Visible = false;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup5"].Visible = false;
                    //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup6"].Visible = false;
                    this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup8"].Visible = true;

                    this.ultraToolbarsManager1.Tools["NewDoc"].SharedProps.Visible = false;
                    this.ultraToolbarsManager1.Tools["Open"].SharedProps.Visible = false;
                    this.ultraToolbarsManager1.Tools["Save"].SharedProps.Visible = false;
                    this.ultraToolbarsManager1.Tools["OpenPDF"].SharedProps.Visible = true;

                    this.ultraToolbarsManager1.ToolClick -= new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
                    try
                    {

                        (ultraToolbarsManager1.Tools["Word"] as Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = false;
                        (ultraToolbarsManager1.Tools["PDF"] as Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = true; ;
                    }
                    finally
                    {
                        this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
                    }

         

                    break;

            }
        }


        private void DocumentAddEdit_Activated(object sender, EventArgs e)
        {
            if (this.ultraTabControl1.ActiveTab == this.ultraTabControl1.Tabs[0])
            {
                //MessageBox.Show("G");
                TxDocument.SetFocusAndZooming();
                ChangeViewF();
            }
        }

        #region KeyPress

        private void ultraTextEditor1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
            //X_UpdateStatusBar();
            //this.Text = ultraTextEditor1.Text;
        }

        private void ultraTextEditor1_KeyUp(object sender, KeyEventArgs e)
        {
            this.Text = ultraTextEditor1.Text;
        }

        private void ultraTextEditor5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void ultraTextEditor6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void ELinkCaption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void textControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        #endregion KeyPress


        private void ultraTabControl1_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            if (this.ultraTabControl1.ActiveTab == this.ultraTabControl1.Tabs[0])
            {
                // Show status Items

                TxDocument.SetFocusAndZooming();           
            }
            else
            {
                // Hide Status Items
                
            }
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ultraToolbarsManager1.ShowPopup("DocumentPopUp"); 
        }


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
                DataTableMapping dtm3, dtm4, dtm5, dtm6,dtm7, dtm8;
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

            //CWords
            CWords.DataSource = DS.Tables["CodexDS_DWords"];
            CWords.DisplayMember = "W_Caption";
            CWords.ValueMember = "W_ID";
            CWords.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;

            CWords.DisplayLayout.Bands[0].Columns["W_ID"].Hidden = true;
            CWords.DisplayLayout.Bands[0].Columns["W_Order"].Hidden = true;
            CWords.DisplayLayout.Bands[0].ColHeadersVisible = false;
            CWords.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //           CCategory.DisplayLayout.Grid.Width = CAuthor.Width;
            CWords.DisplayLayout.Bands[0].Override.DefaultColWidth = CWords.Width;

            CWords.MinDropDownItems = 5;
            CWords.MaxDropDownItems = 10;



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

        private void ultraButton7_Click(object sender, EventArgs e)
        {
            var dlg2 = new ILG.Codex.CodexR4.PickDate(Dt);
            Point dc2 = new Point(EDate1.Location.X, EDate1.Location.Y);
            Point dc = tableLayoutPanel3.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            EDate1.Text = dlg2.ToString();
            Dt = dlg2.PickedDate;
        }

        #region KeyWords
        private void button20_Click(object sender, EventArgs e)
        {

            this.EWord.Text = this.EWord.Text + this.CWords.Text.ToString().Trim() + " , ";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string s = this.EWord.Text;
            string s1 = this.CWords.Text.ToString().Trim() + " , ";
            s = s.Replace(s1, "");
            this.EWord.Text = s;
			
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.EWord.Text = "";
        }
        #endregion KeyWords


        #region Attach File

        #region ICON

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

            [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SHGetFileInfo([MarshalAs(UnmanagedType.LPWStr)]string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        }

        #endregion ICON

        //DiskFile zzipfile;
        //ZipArchive zipfile;
        string ZipFileName;
        bool HasAttachments = false;
     
        private void AttachFile()   
        {
            IntPtr hImgSmall; //the handle to the system image list
            //IntPtr hImgLarge; //the handle to the system image list
            //string fName; //  'the file name to get icon from
            SHFILEINFO shinfo = new SHFILEINFO();
            


            OpenFileDialog fdd = new OpenFileDialog();
            //fd.InitialDirectory = startdir;
            fdd.Filter = "All files (*.*)|*.*";

            fdd.Title = "Open File to Attach";
            //fd.Filter = "Microsoft Word (*.doc)|*.doc|Rich Text Format (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*";


            fdd.FilterIndex = 0;
            fdd.RestoreDirectory = true;
            fdd.Multiselect = false;
            //fd.Title = "Open File";

            if (fdd.ShowDialog() == DialogResult.OK)
            {
                // Check if this file already in Attachments
                #region Check if this file already in Attachments
                bool Isin = false;
                ///try
                ///{
                ///    zipfile.Open(ZipFileName);
                ///}
                ///catch (Exception x1)
                ///{
                ///    this.Cursor = System.Windows.Forms.Cursors.Default;

                ///   ILG.Windows.Forms.ILGMessageBox.ShowE("ვერ ხერხდება ფაილის მიბმა", "CE 420", x1.Message.ToString());
                ///    return;
                ///}

                //ZipArchive zipfile = new ZipArchive(new DiskFile(ZipFileName));
                List<string> filesinzip = CodexZip.GetEntitiesList(ZipFileName);

                if (filesinzip.Count != 0)
                {
                    foreach (var f in filesinzip)
                    {

                        if (Path.GetFileName(f.ToString()).ToUpper().Trim() == System.IO.Path.GetFileName(fdd.FileName).ToUpper().Trim()) Isin = true;
                    }
                    if (Isin == true)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("ფაილი " + System.IO.Path.GetFileName(fdd.FileName).Trim() + " უკვე არის სიაში");
                        return;
                    }
                }
                #endregion Check if this file already in Attachments

                // Try to Attach it in Zip
                #region // Try to Attach it in Zip
                bool Isadd = false;
                try
                {
                     this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                     //DiskFile File = new DiskFile(fdd.FileName);
                     //File.CopyTo(zipfile, true);

                    CodexZip.Zip_AddOrCreate(ZipFileName, Path.GetFileName(fdd.FileName), fdd.FileName);
                     
                     //zipfile.Open(ZipFileName);
                     //zipfile.Entries.Add(fdd.FileName);
                    Isadd = true;
                    HasAttachments = true;
                }
                catch (Exception x1)
                {
                    Isadd = false;
                    this.Cursor = System.Windows.Forms.Cursors.Default;

                    ILG.Windows.Forms.ILGMessageBox.ShowE("ვერ ხერხდება ფაილის მიბმა", "CE 419", x1.Message.ToString());
                    
                }
                finally
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    
                    //zipfile.Close();
                }

                if (Isadd == false) return;

                #endregion // Try to Attach it in Zip

                // Add ICON
                #region Add Icon
                string str = System.IO.Path.GetFileName(fdd.FileName).ToUpper().Trim();
                System.IO.File.SetAttributes(fdd.FileName, FileAttributes.Normal);
                hImgSmall = Win32.SHGetFileInfo(fdd.FileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);

                //Use this to get the large Icon
                //hImgLarge = SHGetFileInfo(fName, 0, 
                //	ref shinfo, (uint)Marshal.SizeOf(shinfo), 
                //	Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);

                //The icon is returned in the hIcon member of the shinfo struct
                System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);

                this.imageList1.Images.Add(str, myIcon);
                this.listView1.Items.Add(str, str);
                #endregion Add Icon
            }

        }

        private void DettechFile()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("აირჩიეთ თუ რომელი ფაილის წაშლა გსურთ");
                return;
            }
            // Find File in Zip 
            // Check if this file already in Attachments

            string dfilename = listView1.SelectedItems[0].Text;

            #region Check if this file exsitst in Attachments
            bool Isin = false;

            ///try
            ///{
            ///    zipfile.Open(ZipFileName);
            ///}
            ///catch (Exception x1)
            ///{
            ///    this.Cursor = System.Windows.Forms.Cursors.Default;

            ///                ILG.Windows.Forms.ILGMessageBox.ShowE("ვერ ხერხდება ფაილის წაშლა", "ZZ 420", x1.Message.ToString());
            ///    return;

            ///}
            ///
            List<string> filesinzip = CodexZip.GetEntitiesList(ZipFileName);
            //ZipArchive zipfile = new ZipArchive(new DiskFile(ZipFileName));

            if (filesinzip.Count != 0)
            {
                foreach (var f in filesinzip)
                {
                    if (Path.GetFileName(f.ToString()).ToUpper().Trim() == dfilename.ToUpper().Trim()) Isin = true;
                 
                }
                if (Isin == false)
                {
                    ILG.Windows.Forms.ILGMessageBox.ShowE("ვერ ხერხდება ფაილის წაშლა", "ZZ 427");
                    return;
                }
            }
            #endregion Check if this file is in Attachments
          

            
            #region // Try to remove it from Zip
            bool Isadd = false;
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                //                    this.Cursor = System.Windows.Forms.Cursors.Default;

                //ZippedFile f = new ZippedFile(zipfile, dfilename);
                
                // Removed in 1.5
                // ******
                //ZippedFile f = new ZippedFile(new DiskFile(ZipFileName), dfilename);
                //if (f.Exists) f.Delete();
                // ******
                
                ///zipfile.Open(ZipFileName);
                ///zipfile.Entries.Remove(dfilename);

                CodexZip.DeleteFromZip(ZipFileName, dfilename);
                
                Isadd = true;
            }
            catch (Exception x1)
            {
                Isadd = false;
                this.Cursor = System.Windows.Forms.Cursors.Default;

                ILG.Windows.Forms.ILGMessageBox.ShowE("ვერ ხერხდება ფაილის წაშლა", "CS 419", x1.Message.ToString());

            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;

                //zipfile.Close();
            }

            if (Isadd == false) return;


            
            #endregion

            // Remove ICON
            #region remove Icon

            this.imageList1.Images.RemoveByKey(dfilename);
            //this.listView1.Items.RemoveByKey(dfilename);
            this.listView1.Items.Remove(listView1.SelectedItems[0]);
            #endregion remove Icon


            #region Check if Zip Empty
            // Check if Zip Empty
            // ===========================================================
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                List<string> filesinzip2 = CodexZip.GetEntitiesList(ZipFileName);

                //ZipArchive zipfile2 = new ZipArchive(new DiskFile(ZipFileName));
                if (filesinzip2.Count == 0) HasAttachments = false;
            }
            catch (Exception x1)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("ვერ ხერხდება ფაილის წაშლა", "CZR 100", x1.Message.ToString());
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            #endregion
       }


        private void ClearAttachs()
        {

            if (ILG.Windows.Forms.ILGMessageBox.Show("მიბმული ფაილების გასუფთავება (ყველას წაშლა) დარწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            
            #region Try Read
            ///try
            ///{
            ///    zipfile.Open(ZipFileName);
            ///}
            ///catch (Exception x1)
            ///{
            ///    this.Cursor = System.Windows.Forms.Cursors.Default;
            ///
            ///    ILG.Windows.Forms.ILGMessageBox.ShowE("ვერ ხერხდება ფაილის წაშლა", "ZZ 720", x1.Message.ToString());
            ///    return;
            ///
            ///}
            #endregion 



            #region // Try to remove it from Zip
            bool Isadd = false;
            try
            {
                CodexZip.DelteAllFileInZip(ZipFileName);
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Isadd = true;
            }
            catch (Exception x1)
            {
                Isadd = false;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("ვერ ხერხდება ფაილის წაშლა", "CS 439", x1.Message.ToString());

            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
               // zipfile.Close();
            }

            if (Isadd == false) return;

            #endregion

            // Remove ICON
            #region remove Icon
            while (imageList1.Images.Count > 0)
            {
                imageList1.Images.RemoveAt(0);
            }

            while (listView1.Items.Count > 0)
            {
                listView1.Items.RemoveAt(0);
            }

            #endregion remove Icon


            #region Check if Zip Empty
            // Check if Zip Empty
            // ===========================================================
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                List<string> filesinzip = CodexZip.GetEntitiesList(ZipFileName);
                if (filesinzip.Count == 0) HasAttachments = false;
            }
            catch (Exception x1)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("ვერ ხერხდება ფაილის წაშლა", "CZR 100", x1.Message.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            #endregion
        }


        private void SaveAttachment()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("აირჩიეთ ფაილი");
                return;
            }


            string str = listView1.SelectedItems[0].Text.ToString().Trim();

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

            CodexZip.UnZip(ZipFileName, str, fn, OverWrite: true);

      
            ILG.Windows.Forms.ILGMessageBox.Show("ფაილი ჩაწერილია");

        }

        #endregion Attach File


        #region Links
        bool isLinkFound = false;
        int LinkMode;
        DataSet DLinks;


        private int CodexDocumentCaption(int ID, ref string DocCaption)
        {

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            // Define Document Call Statment
            String Fields = "id, H_Date, H_Status, C_ID,C_Caption, C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Category,C_Addtional,C_Group,C_DocFormat";
            string strsql = "Select " + Fields + " FROM CodexDS_DDOCS_History WHERE id = " + ID.ToString() + " ";
            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet dst = new DataSet();
            dacgl.Fill(dst);
            if (dst.Tables[0].Rows.Count != 1) return -1; // Document Not Found


            if ((int)dst.Tables[0].Rows[0]["C_Group"] != 0)
            {
                if (License.IsEnterInConfidentialDocumentAlowed() == false)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("თქვენ არ გაქვთ უფლება შეხვიდეთ ამ დოკუმენტში");
                    return -1000;
                }
            }

            
            // Document Caption
            
          
            // Calcucate Document Caption 
            (FormMain as Form1).LockupTables.Tables["CodexDS_DAuthor"].PrimaryKey = new DataColumn[] { (FormMain as Form1).LockupTables.Tables["CodexDS_DAuthor"].Columns["A_ID"] };
            (FormMain as Form1).LockupTables.Tables["CodexDS_DType"].PrimaryKey = new DataColumn[] { (FormMain as Form1).LockupTables.Tables["CodexDS_DType"].Columns["T_ID"] };
            (FormMain as Form1).LockupTables.Tables["CodexDS_DStatus"].PrimaryKey = new DataColumn[] { (FormMain as Form1).LockupTables.Tables["CodexDS_DStatus"].Columns["C_ID"] };
            (FormMain as Form1).LockupTables.Tables["CodexDS_DCategory"].PrimaryKey = new DataColumn[] { (FormMain as Form1).LockupTables.Tables["CodexDS_DCategory"].Columns["C_ID"] };


            StringBuilder Strauthor = new StringBuilder("0");
            StringBuilder Strtype = new StringBuilder("0");
            StringBuilder Strstatus = new StringBuilder("0");
            StringBuilder StrCategory = new StringBuilder("0");
            DataRow dr;


            Strauthor.Remove(0, Strauthor.Length);
            Strtype.Remove(0, Strtype.Length);
            Strstatus.Remove(0, Strstatus.Length);
            StrCategory.Remove(0, StrCategory.Length);


            dr = (FormMain as Form1).LockupTables.Tables["CodexDS_DAuthor"].Rows.Find((int)dst.Tables[0].Rows[0]["C_Author"]);
            if (dr == null) Strauthor.Append(" "); else Strauthor.Append(@dr["A_Caption"].ToString().Trim());

            dr = (FormMain as Form1).LockupTables.Tables["CodexDS_DType"].Rows.Find((int)dst.Tables[0].Rows[0]["C_Type"]);
            if (dr == null) Strtype.Append(" "); else Strtype.Append(@dr["T_Caption"].ToString().Trim());

            // New ITEMS
            dr = (FormMain as Form1).LockupTables.Tables["CodexDs_DStatus"].Rows.Find((int)dst.Tables[0].Rows[0]["C_Status"]);

            if (dr == null) Strstatus.Append(" ");
            {
                if (dr["C_ID"].ToString().Trim() == "0") Strstatus.Append(" ");
                else Strstatus.Append(@dr["C_Caption"].ToString().Trim());
            }

            dr = (FormMain as Form1).LockupTables.Tables["CodexDs_DCategory"].Rows.Find((int)dst.Tables[0].Rows[0]["C_Category"]);

            if (dr == null) StrCategory.Append(" ");
            {
                if (dr["C_ID"].ToString().Trim() == "0") StrCategory.Append(" ");
                else StrCategory.Append(@dr["C_Caption"].ToString().Trim());
            }

            // -----------------------------------------------------------


            String S =
                PickDate.DateToString((DateTime)dst.Tables[0].Rows[0]["C_Date"]) + "  "
                + Strauthor.ToString() + "  " + Strtype + " ";

            if (dst.Tables[0].Rows[0]["C_numberStr"] != null)
            {
                if (dst.Tables[0].Rows[0]["C_numberStr"].ToString().Trim() != "") S = S + "N " + (dst.Tables[0].Rows[0]["C_numberStr"]).ToString().Trim();
            }


            if (Strstatus.ToString().Trim() != "") S = S + " : <" + Strstatus + "> ";
            if (StrCategory.ToString().Trim() != "") S = S + " : (" + StrCategory + ") ";



            String Saddt = "";
            if (dst.Tables[0].Rows[0]["C_Addtional"] == null) Saddt = "";
            else
            {
                if (dst.Tables[0].Rows[0]["C_Addtional"].ToString().Trim() != "")
                    Saddt = dst.Tables[0].Rows[0]["C_Addtional"].ToString().Trim();
            }

            if (Saddt.Trim() != "") S = S + "  " + Saddt;

            Int32 IDX = -1;
            String IDACCESS = "";
            if (dst.Tables[0].Rows[0]["C_Group"] == null) IDX = -1;
            else
            {
                IDX = (int)dst.Tables[0].Rows[0]["C_ID"];
                if ((int)dst.Tables[0].Rows[0]["C_Group"] == 0)
                {
                    if (License.IsDocumentIDShowInList() == true) IDACCESS = " ID = #" + IDX.ToString();
                }
                else
                {
                    if (License.IsConfidentialDocumentIDShowInList() == true) IDACCESS = " ID = #" + IDX.ToString();
                }
            }

            if (IDACCESS.Trim() != "") S = S + IDACCESS;


            // -------------------------------

            DocCaption = @S;
            
            this.Cursor = System.Windows.Forms.Cursors.Default;


            return 0;
        }
  

         
        private void ultraButton1_Click_1(object sender, EventArgs e)
        {
            if (CLinkID.Text.Trim() == "")
            {ILG.Windows.Forms.ILGMessageBox.Show("მიუთითეთ დასაკავშირებელი დოკუმენტის ID"); return;}
            Int32 LinktoID = -1;
            bool R = Int32.TryParse(CLinkID.Text.Trim(),out LinktoID);
            // Try Search in Database
            if (R == false)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ID არაკორექტულია"); return; }


            string X = "";
            int r  = CodexDocumentCaption(LinktoID,ref X);
            if (r != 0) return;

            // Find Doc
            isLinkFound = true;

            //this.ELinkCaption.Text = CLinkType.Text + " დოკუმენტი [მიმღები ორგანო ] [დოკუმენტის სახე] [დოკუმენტის თარიღი] [ნომერი] ";
            this.ELinkCaption.Text = CLinkType.Text + " " +X ;;

        }

        private void CLinkID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar < ' ')  e.Handled = false;
        }

        private void AddLink()
        {
            if (LinkMode != 1) return;
            if (isLinkFound == false)
            { ILG.Windows.Forms.ILGMessageBox.Show("ჯერ მოძებნეთ დასაკავშირებელი დოკუმენტი"); return; }
            if (ELinkCaption.Text.Trim() == "")
            { ILG.Windows.Forms.ILGMessageBox.Show("კავშირის სახელი არ შეიძლება იყოს ცარიელი"); return; }
            
            Int32 XLinktoID = -1;
            bool R = Int32.TryParse(CLinkID.Text.Trim(),out XLinktoID);
            // Try Search in Database
            if (R == false)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ID არაკორექტულია"); return; }

            
            Int32 XOrder = -1;
            R = Int32.TryParse(ElinkOrder.Text.Trim(),out XOrder);
            // Try Search in Database
            if (R == false)
            { ILG.Windows.Forms.ILGMessageBox.Show("კავშირის მიმდევრობა არაკორექტულია"); return; }

            // Add Link
            if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი კავშირის დამატება ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            
            // Search is Link already in list 
            bool isinls = false;
            if (DLinks.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DLinks.Tables[0].Rows.Count; i++)
                {
                    if ((Int32)DLinks.Tables[0].Rows[i]["ID"] == XLinktoID) isinls = true;
                }
            }

            if (isinls == true)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი მითითებული ID–თ უკვე არის კავშირების სიაში"); return; }
            
            // Add Procedure
            int XColor = -1;
            switch (CLinkType.SelectedIndex)
            {
                case 0: XColor = 1; break; // Gray
                case 1: XColor = 2; break; // Blue
                case 2: XColor = 2; break; // Blue
                case 3: XColor = 3; break; // Red
                case 4: XColor = 4; break; // Yellow
                case 5: XColor = 5; break; // Green
                default: XColor = 1; break; // if other
            }

            int max = 0;
            foreach (DataRow dr in DLinks.Tables[0].Rows)
			 {
				if ((int)dr["ID"] > max ) max = (int)dr["ID"]; 
			 }

            DLinks.Tables[0].Rows.Add(new object[] {max+1, // ID
                                                XOrder, // Order
                                                XColor, // Color
                                                1,      // Status
                                                CLinkType.SelectedIndex, // Type
                                                CLinkAccess.SelectedIndex, // Access
                                                ELinkCaption.Text.Trim(), // Caption
                                                XLinktoID, // Link
                                                1           // Version
                                                }
                                  );


            ILG.Windows.Forms.ILGMessageBox.Show("კავშირი დამატებულია");
            CLinkID.Text = "";
            LinkMode = -1;
            ultraTabControl13.Visible = false;
            ultraTabControl13.Enabled = false;
            CLinkGrid.ActiveRow.Selected = false;
        }


        // LinkEdit Values
        Int32 L_ID = -1;
        Double L_Order;
        Int32 L_Color;
        Int32 L_LinkID;
        string L_Caption;
        Int32 L_Access;
        Int32 L_Type;
        Int32 L_Status;
        Int32 L_Version;
        int L_Index;
        private void PerpareLinkEdit()
        {
            if (CLinkGrid.Selected.Rows.Count == 0)
                { ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ კავშირი რედაქტირებისთვის"); return; }

            if (CLinkGrid.Selected.Rows.Count > 1)
            { ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ მხოლოდ ერთი კავშირი"); return; }
            


            int id = (int)this.CLinkGrid.Selected.Rows[0].Cells["ID"].Value;
            int ind = -1;
            for (int i = 0; i < DLinks.Tables[0].Rows.Count; i++)
            {
                if ((int)DLinks.Tables[0].Rows[i]["ID"] == id) {ind = i;break;}
            }

            L_Index = ind;
            L_ID = id;
        //    L_Order = (Int32)DLinks.Tables[0].Rows[ind]["Order"];
            L_Type = (Int32)DLinks.Tables[0].Rows[ind]["Type"];
            L_Order = (Double)DLinks.Tables[0].Rows[ind]["Order"];
            L_Status = (Int32)DLinks.Tables[0].Rows[ind]["Status"];
            L_Access = (Int32)DLinks.Tables[0].Rows[ind]["Access"];
            L_Version = (Int32)DLinks.Tables[0].Rows[ind]["Version"];
            L_Color = (Int32)DLinks.Tables[0].Rows[ind]["Color"];
            L_Caption = DLinks.Tables[0].Rows[ind]["Caption"].ToString();
            L_LinkID = (Int32)DLinks.Tables[0].Rows[ind]["Link"];

            CLinkType.SelectedIndex = L_Type;
            CLinkID.Text = L_LinkID.ToString();
            ElinkOrder.Text = L_Order.ToString();
            CLinkAccess.SelectedIndex = L_Access;
            ELinkCaption.Text = L_Caption;

            
        }



        private void EditLink()
        {
            if (LinkMode != 2) return;
            if (isLinkFound == false)
            { ILG.Windows.Forms.ILGMessageBox.Show("ჯერ მოძებნეთ დასაკავშირებელი დოკუმენტი"); return; }
            if (ELinkCaption.Text.Trim() == "")
            { ILG.Windows.Forms.ILGMessageBox.Show("კავშირის სახელი არ შეიძლება იყოს ცარიელი"); return; }

            Int32 XLinktoID = -1;
            bool R = Int32.TryParse(CLinkID.Text.Trim(), out XLinktoID);
            // Try Search in Database
            if (R == false)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ID არაკორექტულია"); return; }


            Int32 XOrder = -1;
            R = Int32.TryParse(ElinkOrder.Text.Trim(), out XOrder);
            // Try Search in Database
            if (R == false)
            { ILG.Windows.Forms.ILGMessageBox.Show("კავშირის მიმდევრობა არაკორექტულია"); return; }
            else
            { L_Order = XOrder; }

            // Add Link
            if (ILG.Windows.Forms.ILGMessageBox.Show("კავშირის შეცვლა  ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("კავშირის შეცვლა  ? დაადასტურეთ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;


            // Add Procedure
            int XColor = -1;
            switch (CLinkType.SelectedIndex)
            {
                case 0: XColor = 1; break; // Gray
                case 1: XColor = 2; break; // Blue
                case 2: XColor = 2; break; // Blue
                case 3: XColor = 3; break; // Red
                case 4: XColor = 4; break; // Yellow
                case 5: XColor = 5; break; // Green
                default: XColor = 1; break; // if other
            }

            
            DLinks.Tables[0].Rows[L_Index]["ID"] = L_ID;
            DLinks.Tables[0].Rows[L_Index]["Order"] = L_Order;
            DLinks.Tables[0].Rows[L_Index]["Color"] = XColor;
            DLinks.Tables[0].Rows[L_Index]["Status"] = 1;
            DLinks.Tables[0].Rows[L_Index]["Type"] = CLinkType.SelectedIndex;
            DLinks.Tables[0].Rows[L_Index]["Access"] = CLinkAccess.SelectedIndex;
            DLinks.Tables[0].Rows[L_Index]["Caption"] = ELinkCaption.Text.Trim();
            DLinks.Tables[0].Rows[L_Index]["Link"] = XLinktoID;
            DLinks.Tables[0].Rows[L_Index]["Version"] = 1;
            
            

            ILG.Windows.Forms.ILGMessageBox.Show("კავშირი შეცვლილია");
            CLinkID.Text = "";
            LinkMode = -1;
            ultraTabControl13.Visible = false;
            ultraTabControl13.Enabled = false;
            CLinkGrid.ActiveRow.Selected = false;
            
        }


        private void CLinkID_TextChanged(object sender, EventArgs e)
        {
            isLinkFound = false;
        }

        private void ElinkOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar < ' '))  e.Handled = false;
        }

        private void CLinkOperation_Click(object sender, EventArgs e)
        {
            if (LinkMode == 1) { AddLink(); return; }
            if (LinkMode == 2) { EditLink(); return; }
        }


        private void DelLink()
        {
            
            // Add Link
            if (ILG.Windows.Forms.ILGMessageBox.Show("კავშირის წაშლა  ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("კავშირის წაშლა  ? დაადასტურეთ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;


            if (CLinkGrid.Selected.Rows.Count == 0)
            { ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ კავშირი წასაშლელად"); return; }

            if (CLinkGrid.Selected.Rows.Count > 1)
            { ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ მხოლოდ ერთი კავშირი"); return; }
            

            int id = (int)this.CLinkGrid.Selected.Rows[0].Cells["ID"].Value;
            int ind = -1;
            for (int i = 0; i < DLinks.Tables[0].Rows.Count; i++)
            {
                if ((int)DLinks.Tables[0].Rows[i]["ID"] == id) { ind = i; break; }
            }

            
            DLinks.Tables[0].Rows[ind].Delete();

            ILG.Windows.Forms.ILGMessageBox.Show("კავშირი წაშლილია");
            CLinkID.Text = "";
            LinkMode = -1;
            ultraTabControl13.Visible = false;
            ultraTabControl13.Enabled = false;
            

        }

        public bool ISDocumentExsists(int ID)
        {
            string strsql = "Select C_ID FROM CodexDS_DDOCS_History WHERE ID = " + ID.ToString() + " ";
            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet dst = new DataSet();
            dacgl.Fill(dst);
            if (dst.Tables[0].Rows.Count == 1) return true; // Document Not Found
            return false;
        }

        private void TestLink()
        {
            if (CLinkGrid.Selected.Rows.Count == 0)
            { ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ კავშირი ტესტირებისთვის"); return; }

            if (CLinkGrid.Selected.Rows.Count > 1)
            { ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ მხოლოდ ერთი კავშირი"); return; }


            int id = (int)this.CLinkGrid.Selected.Rows[0].Cells["LINK"].Value;
           
            if (ISDocumentExsists(id) == false)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი ბაზაში არ მოიძებნა");
                return;
            }

            Form_Test_Document T = new Form_Test_Document();
            T.MainForm = (Form1)this.FormMain;
            T.ShowInTaskbar = false;
            T.Show();
            int r = T.CodexOpenTestDocument(id);
            if (r != 0) T.Close();
            //else {MessageBox.Show(r.ToString());}
        }
        private void CleanLink()
        {

            // Add Link
            if (ILG.Windows.Forms.ILGMessageBox.Show("კავშირიების გაწმენდა  ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("კავშირიების გაწმენდა  ? დაადასტურეთ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("კავშირიების გაწმენდა  ? დაადასტურეთ ხელმეორედ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;


            DLinks.Tables[0].Clear();

            ILG.Windows.Forms.ILGMessageBox.Show("კავშირები წაშლილია");
            CLinkID.Text = "";
            LinkMode = -1;
            ultraTabControl13.Visible = false;
            ultraTabControl13.Enabled = false;


        }
        #endregion Links

        private void textControl1_TextChanged(object sender, EventArgs e)
        {
            isDocAtrChanged = true;
        }

        private void DocumentAddEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDocAtrChanged == false) e.Cancel = false;
            else
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის დახურვა ჩაწერის გარეშე ,\nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                    
                }
                else
                {
                    e.Cancel = true;
                    //DOSaveDocument();
                }
            }
            
        }



        #region SaveEditDelDoc
        
        #region Preparation
      //  private C1.C1Zip.C1ZipFile zfD;
        private string @resultText;
        private byte[] resultdoc;
        private byte[] linkresult;
        private byte[] attachments;

        private void CreareAttachment()
        {
            if (HasAttachments == false) return;

            if (File.Exists(ZipFileName) == false)
            {
                HasAttachments = false; return;
            }
            

            FileStream fs = new FileStream(ZipFileName, FileMode.Open, FileAccess.Read);
            attachments = new byte[(int)fs.Length];
            fs.Read(attachments, 0, (int)fs.Length);
            fs.Close();
           
        }


        private void CreareRTFDocument()
        {
            //TXTextControl.SaveSettings s = new TXTextControl.SaveSettings();
            //s.PageMargins = textControl1.PageMargins;
            //s.PageSize = textControl1.PageSize;

            TxDocument.SaveToRTF(DirectoryConfiguration.CodexTemporaryDirectory + @"\D.RTF");
            //textControl1.Save(Properties.Settings.Default.TemporaryDir + @"\D.RTF", TXTextControl.StreamType.RichTextFormat,s);

            TxDocument.GetPlainText(out @resultText);
            //textControl1.Save(out @resultText, TXTextControl.StringStreamType.PlainText);//.PlainText,s);

            String ZipFileName = DirectoryConfiguration.CodexTemporaryDirectory + @"\Doc2.Zip";
            String RTFFileName = DirectoryConfiguration.CodexTemporaryDirectory + @"\D.RTF";
            CodexZip.Zip(ZipFileName, "D.RTF", RTFFileName);

            //C1.C1Zip.C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Create(ILG.Codex.CodexR4.Properties.Settings.Default.TemporaryDir + @"\Doc2.Zip");
            //zf.Entries.Add(ILG.Codex.CodexR4.Properties.Settings.Default.TemporaryDir + @"\D.RTF", "D.RTF");
            //zf.Close();

            FileStream fs = new FileStream(DirectoryConfiguration.CodexTemporaryDirectory + @"\Doc2.Zip", FileMode.Open, FileAccess.Read);
            resultdoc = new byte[(int)fs.Length];
            fs.Read(resultdoc, 0, (int)fs.Length);
            fs.Close();
            File.Delete(DirectoryConfiguration.CodexTemporaryDirectory + @"\Doc2.Zip");
            if (File.Exists(DirectoryConfiguration.CodexTemporaryDirectory + @"\D.RTF") == true) File.Delete(DirectoryConfiguration.CodexTemporaryDirectory + @"\D.RTF");

        }


        private void CrearePDFDocument()
        {
            // Version 1.0 When PDF File Save Full Text Search Not Worked


            String ZipFileName = DirectoryConfiguration.CodexTemporaryDirectory + @"\Doc3.Zip";
            CodexZip.Zip(ZipFileName, "D.PDF", SellectedPDF);

            //C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Create(ILG.Codex.CodexR4.Properties.Settings.Default.TemporaryDir + @"\Doc3.Zip");

            //zf.Entries.Add(SellectedPDF, "D.PDF");
            //zf.Close();

            FileStream fs = new FileStream(DirectoryConfiguration.CodexTemporaryDirectory + @"\Doc3.Zip", FileMode.Open, FileAccess.Read);
            resultdoc = new byte[(int)fs.Length];
            fs.Read(resultdoc, 0, (int)fs.Length);
            fs.Close();
            File.Delete(DirectoryConfiguration.CodexTemporaryDirectory + @"\Doc3.Zip");
            if (File.Exists(DirectoryConfiguration.CodexTemporaryDirectory + @"\D.PDF") == true) File.Delete(DirectoryConfiguration.CodexTemporaryDirectory + @"\D.RTF");

        }


        private void CreareLinks()
        {

            String ZipFileName = DirectoryConfiguration.CodexTemporaryDirectory + @"\LINKS.ZIP";
            String FileName_Links = DirectoryConfiguration.CodexTemporaryDirectory + @"\Links.XML";
            String FileName_LinksSchema = DirectoryConfiguration.CodexTemporaryDirectory + @"\LinksSchema.XML";

            DLinks.WriteXml(FileName_Links);
            DLinks.WriteXmlSchema(FileName_LinksSchema);

            CodexZip.Zip(ZipFileName, "Links.XML", FileName_Links);
            CodexZip.Zip_Add(ZipFileName, "LinksSchema.XML", FileName_LinksSchema);

            //C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Create(ILG.Codex.CodexR4.Properties.Settings.Default.TemporaryDir + @"\LINKS.ZIP");

            //zf.Entries.Add(ILG.Codex.CodexR4.Properties.Settings.Default.TemporaryDir + @"\Links.XML", "Links.XML");
            //zf.Entries.Add(ILG.Codex.CodexR4.Properties.Settings.Default.TemporaryDir + @"\LinksSchema.XML", "LinksSchema.XML");

            //zf.Close();


            File.Delete(DirectoryConfiguration.CodexTemporaryDirectory + @"\Links.XML");
            File.Delete(DirectoryConfiguration.CodexTemporaryDirectory + @"\LinksSchema.XML");

            FileStream fs = new FileStream(DirectoryConfiguration.CodexTemporaryDirectory + @"\LINKS.ZIP", FileMode.Open, FileAccess.Read);
            linkresult = new byte[fs.Length];
            fs.Read(linkresult, 0, (int)fs.Length);
            fs.Close();
            File.Delete(DirectoryConfiguration.CodexTemporaryDirectory + @"\LINKS.ZIP");
        }
        #endregion Preparation

        
        private void DOSaveDocument()
        {
            #region Checks
            if (ultraTextEditor1.Text.Trim() == "")
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სათაური არ შეიძლება იყოს ცარიელი"); return; }
            
            if (CAuthor.SelectedRow == null)
            //{ ILGMessageBox.Show($" {CodexDSOrganizationSettings.Instance.Settings.DisplayModel.authorAttributeSettings.DisplayName} არის აუცილებელი ველი"); return; }
              { ILGMessageBox.Show("მიმღები ორგანო არის აუცილებელი ველი"); return; }

            if ((int)CAuthor.SelectedRow.Cells["A_ID"].Value == 0)
             { ILG.Windows.Forms.ILGMessageBox.Show("მიმღები ორგანო არის აუცილებელი ველი"); return; }
            //{ ILGMessageBox.Show($" {CodexDSOrganizationSettings.Instance.Settings.DisplayModel.authorAttributeSettings.DisplayName} არის აუცილებელი ველი"); return; }
 

            if (CType.SelectedRow == null)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სახე არის აუცილებელი ველი"); return; }

            if ((int)CType.SelectedRow.Cells["T_ID"].Value == 0)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სახე არის აუცილებელი ველი"); return; }

            if (CSbject.SelectedRow == null)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თემატიკა არის აუცილებელი ველი"); return; }

            if ((int)CSbject.SelectedRow.Cells["S_ID"].Value == 0)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თემატიკა არის აუცილებელი ველი"); return; }

            if (Dt == null)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თარიღი არის აუცილებელი ველი"); return; }

            // Check if Document Empty
            if (( DefaultDocumentFormat == 0) &&  ( TxDocument.isTextEmpty()))
            { ILG.Windows.Forms.ILGMessageBox.Show("RTF დოკუმენტის ტექსტი ცარილელია"); return; }

           
            if (( DefaultDocumentFormat == 1) && (this.SellectedPDF.Trim() == "") )
                { ILG.Windows.Forms.ILGMessageBox.Show("PDF დოკუმენტის ტექსტი ცარილელია"); return; }
            #endregion Checks

            #region Additinal Checks
            if (CodexDSBehavioral.Default.UseCategoryAsMandatory == true)
            {
                if (CCategory.SelectedRow == null)
                { ILGMessageBox.Show("დოკუმენტის კატეგორია არის აუცილებელი ველი"); return; }

                if ((int)CCategory.SelectedRow.Cells["C_ID"].Value == 0)
                { ILGMessageBox.Show("დოკუმენტის კატეგორია არის აუცილებელი ველი"); return; }
            }

            if (CodexDSBehavioral.Default.UseStatusAsMandatory == true)
            {
                if (CStatus.SelectedRow == null)
                { ILGMessageBox.Show("დოკუმენტის სტატუსი არის აუცილებელი ველი"); return; }

                if ((int)CStatus.SelectedRow.Cells["C_ID"].Value == 0)
                { ILGMessageBox.Show("დოკუმენტის სტატუსი არის აუცილებელი ველი"); return; }
            }

            if (CodexDSBehavioral.Default.UseNumberAsManadatory == true)
            {
                if ((ultraTextEditor2.Text.Trim() == ""))
                { ILGMessageBox.Show("დოკუმენტის ნომერი არის აუცილებელი ველი"); return; }
            }

            #endregion Additinal Checks


            if (License.IsConfidentialSaveAllow() == false)
            {
                if (CSecStatus.SelectedIndex != 0)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("თქვენ არ გაქვთ უფლება ჩაწეროთ კონფიდენციალური დოკუმენტი");
                    return;
                }
            }

            if (Properties.Settings.Default.AskToRemoveSections == true)
            {
                if (TxDocument.MoreThanOneSection() == true)
                {
                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი შეიცავს სექციებს, ის არ გამოჩნდება კარგად კოდექს დოკუმენტების არქივის ადრეულ ვერსიებში \nგავაგრძელო ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }
            }


            if (CodexDSBehavioral.Default.CheckSaveNewConditionOnDublicate == true)
            {
                //if (CheckTheDocumentExistance() == true)
                //{
                //    if (CodexDSBehavioral.Default.CheckSaveWarnOnly == true)
                //    {
                //        if (ILGMessageBox.Show("დოკუმენტი ესეთი პარამეტრებით უკვე არსებობს ბაზაში გავაგრძელო ?", "", MessageBoxButtons.YesNo,
                //           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                //    }
                //    else
                //    {
                //        ILGMessageBox.Show("დოკუმენტი ესეთი პარამეტრებით უკვე არსებობს ბაზაში" + System.Environment.NewLine + "მისი ჩაწერა არ მოხდება", "", MessageBoxButtons.OK,
                //               MessageBoxIcon.Error);
                //        return;
                //    }
                //}

            }


            // Confirm to Save Document
            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ჩაწერა", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

            #region Prepare Parameters
            int EEDocNumber = 0;
            if (Int32.TryParse(ultraTextEditor2.Text,out EEDocNumber) == false) EEDocNumber = -1;

            int DocumentStatus = -1;
            if (CStatus.SelectedRow == null)  DocumentStatus = 0;
            else DocumentStatus = (int)CStatus.SelectedRow.Cells["C_ID"].Value;
            
            int DocumentCategory = -1;
            if (CCategory.SelectedRow == null)  DocumentCategory = 0;
            else DocumentCategory = (int)CCategory.SelectedRow.Cells["C_ID"].Value;

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (DefaultDocumentFormat == 0) CreareRTFDocument();
                if (DefaultDocumentFormat == 1) CrearePDFDocument();
                CreareLinks();
                CreareAttachment();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის ჩაწერა Error #A10001", ex.Message.ToString());
                return;
            }



            int HistoryStatus = 0;

            try
            {
                var i = HistoryStatus_Combo.SelectedIndex;
                if (i == 2) HistoryStatus = -1;
            }
            catch
            {
                HistoryStatus = 0;
            }

            #endregion Prepare Parameters
            // Save Procedure
            #region Create Command "InsertDoc"
            String InsertCommand = "INSERT INTO [dbo].[CodexDS_DDOCS_History] ([H_Date], [H_Caption] ,[H_Title] ,[H_Status],[H_OperationStatus], [H_ByUser], [C_ID], [C_CAPTION], [C_AUTHOR], [C_Subject], [C_TYPE], [C_WORDS], [C_NUMBER], [C_NumberStr], [C_DATE], [C_LASTEDIT], [C_ENTERDATE], [C_TEXT], [C_LINK], [C_STATUS], [C_DocFormat], [C_DocEncoding], [C_DocText], [C_Coments], [C_Version], [C_Presentation], [C_Original], [C_Attach], [C_Group], [C_Category], [C_Addtional], [C_Picture]) "
                                 + " VALUES (@H_Date, @H_Caption ,@H_Title ,@H_Status,@H_OperationStatus, @H_ByUser, @C_ID, @C_CAPTION, @C_AUTHOR, @C_Subject, @C_TYPE, @C_WORDS, @C_NUMBER, @C_NumberStr, @C_DATE, @C_LASTEDIT, @C_ENTERDATE, @C_TEXT, @C_LINK, @C_STATUS, @C_DocFormat, @C_DocEncoding, @C_DocText, @C_Coments, @C_Version, @C_Presentation, @C_Original, @C_Attach, @C_Group, @C_Category, @C_Addtional, @C_Picture) ";

     

            SqlCommand InsertDoc = new SqlCommand(InsertCommand);
            InsertDoc.CommandText = InsertCommand;
            InsertDoc.CommandType = CommandType.Text;
            InsertDoc.Parameters.Add(new SqlParameter("@H_DATE", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "H_DATE", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@H_CAPTION", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "H_CAPTION", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@H_Title", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "H_Title", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@H_ByUser", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "H_ByUser", DataRowVersion.Current, false, null, "", "", ""));

            InsertDoc.Parameters.Add(new SqlParameter("@H_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "H_Status", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@H_OperationStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "H_OperationStatus", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_ID", DataRowVersion.Current, false, null, "", "", ""));


            InsertDoc.Parameters.Add(new SqlParameter("@C_CAPTION", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "C_CAPTION", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_AUTHOR", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_AUTHOR", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Subject", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_Subject", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_TYPE", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_TYPE", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_WORDS", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "C_WORDS", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_NUMBER", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_NUMBER", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_NumberStr", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "C_NumberStr", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_DATE", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "C_DATE", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_LASTEDIT", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "C_LASTEDIT", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_ENTERDATE", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "C_ENTERDATE", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_TEXT", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_TEXT", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_LINK", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_LINK", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_STATUS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_STATUS", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_DocFormat", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_DocFormat", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_DocEncoding", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "C_DocEncoding", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_DocText", SqlDbType.NText, 0, ParameterDirection.Input, 0, 0, "C_DocText", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Coments", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "C_Coments", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Version", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_Version", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Presentation", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_Presentation", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Original", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_Original", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Attach", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_Attach", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Group", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_Group", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Category", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_Category", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Addtional", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "C_Addtional", DataRowVersion.Current, false, null, "", "", ""));
            InsertDoc.Parameters.Add(new SqlParameter("@C_Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_Picture", DataRowVersion.Current, false, null, "", "", ""));
            #endregion Create Command "InsertDoc"

            #region Fill Rarameters
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                #region FillParameters

                InsertDoc.Parameters["@H_DATE"].Value = Dt_H;

                InsertDoc.Parameters["@H_CAPTION"].Value = "";

                InsertDoc.Parameters["@H_Title"].Value = "";

                InsertDoc.Parameters["@H_ByUser"].Value = "";

                InsertDoc.Parameters["@H_Status"].Value = HistoryStatus;

                InsertDoc.Parameters["@H_OperationStatus"].Value = 0;
                
                InsertDoc.Parameters["@C_ID"].Value = theDocumentID;
                    

                InsertDoc.Parameters["@C_CAPTION"].Value = ultraTextEditor1.Text.Trim();
                InsertDoc.Parameters["@C_AUTHOR"].Value = (int)CAuthor.SelectedRow.Cells["A_ID"].Value;
                InsertDoc.Parameters["@C_Subject"].Value = (int)CSbject.SelectedRow.Cells["S_ID"].Value;
                InsertDoc.Parameters["@C_TYPE"].Value = (int)CType.SelectedRow.Cells["T_ID"].Value;
                InsertDoc.Parameters["@C_WORDS"].Value = EWord.Text;
                InsertDoc.Parameters["@C_NUMBER"].Value = EEDocNumber;
                InsertDoc.Parameters["@C_NumberStr"].Value = ultraTextEditor2.Text.Trim();
                InsertDoc.Parameters["@C_DATE"].Value = Dt;
                InsertDoc.Parameters["@C_LASTEDIT"].Value = DateTime.Now;
                InsertDoc.Parameters["@C_ENTERDATE"].Value = DateTime.Now;
                InsertDoc.Parameters["@C_TEXT"].Value = resultdoc;
                InsertDoc.Parameters["@C_LINK"].Value = linkresult;
                InsertDoc.Parameters["@C_STATUS"].Value = DocumentStatus;
                InsertDoc.Parameters["@C_DocFormat"].Value = DefaultDocumentFormat;
                InsertDoc.Parameters["@C_DocEncoding"].Value = "UNICODE";

                if (ILG.Codex.CodexR4.Properties.Settings.Default.DocumentEncogingPolicy == true)
                {
                    InsertDoc.Parameters["@C_DocEncoding"].Value = CEncoding.Value.ToString().Trim();
                }


                if (DefaultDocumentFormat == 0)
                    InsertDoc.Parameters["@C_DocText"].Value = resultText;
                else
                    InsertDoc.Parameters["@C_DocText"].Value = textBox1.Text.ToString();

                InsertDoc.Parameters["@C_Coments"].Value = ultraTextEditor5.Text.Trim();
                InsertDoc.Parameters["@C_Version"].Value = 1;
                InsertDoc.Parameters["@C_Presentation"].Value = DBNull.Value;
                InsertDoc.Parameters["@C_Original"].Value = DBNull.Value;


                if (HasAttachments == true)
                    InsertDoc.Parameters["@C_Attach"].Value = attachments;
                else
                    InsertDoc.Parameters["@C_Attach"].Value = DBNull.Value;

                InsertDoc.Parameters["@C_Group"].Value = CSecStatus.SelectedIndex;
                InsertDoc.Parameters["@C_Category"].Value = DocumentCategory;
                InsertDoc.Parameters["@C_Addtional"].Value = ultraTextEditor6.Text.Trim();
                InsertDoc.Parameters["@C_Picture"].Value = DBNull.Value;
                #endregion FillParameters
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის ჩაწერა Error #A10002", ex.Message.ToString());
                return;
            }
            #endregion Fill Rarameters

            #region SaveDoc
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                
                InsertDoc.Connection = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS);
                InsertDoc.Connection.Open();
                InsertDoc.ExecuteNonQuery();
                InsertDoc.Connection.Close();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის ჩაწერა Error #A10003", ex.Message.ToString());
                return;
            }
            #endregion SaveDoc

            #region UpdateInformation
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                int Quantity = 0;
                // Update information Tables
                SqlCommand scoount = new SqlCommand("SELECT COUNT(C_ID) FROM CodexDS_DDocs");
                scoount.Connection = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS);
                scoount.Connection.Open();
                Quantity = (int)scoount.ExecuteScalar();
                scoount.Connection.Close();



                string dtstr1 = "CONVERT(DATETIME, '" + DateTime.Now.Year.ToString() + @"-" + DateTime.Now.Month.ToString("00") + @"-" + DateTime.Now.Day.ToString("00") + "T00:00:00.000' ,126) ";
                string StrInfo = "UPDATE CodexDS2007 SET [C_Version] = 50,  [C_Date] = " + dtstr1 + ", [C_CodexDSDocs] = "+Quantity.ToString() +", " +
                             "[C_CodexDate] = " + dtstr1 + ",  [C_CodexDSVersion] = 65 WHERE [C_Version] = 50 ";
                SqlCommand sinfo = new SqlCommand(StrInfo);
                 
                sinfo.Connection = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS);
                sinfo.Connection.Open();
                sinfo.ExecuteNonQuery();
                sinfo.Clone();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის ჩაწერა Error #A10004", ex.Message.ToString());
                return;
            }


            #endregion UpdateInformation
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი ჩაწერილია");
            // Detemine Close or not after Saving
            //(this.FormMain as Form1).LoadTables();
            //(this.FormMain as Form1).DisplayParametersLimited();

            if (ILG.Codex.CodexR4.Properties.Settings.Default.DSAfterSaveNewDoc == false)
            {
                isDocAtrChanged = false; 
                this.ultraTextEditor1.Text = "";
                isDocAtrChanged = false; 
            }
            else
            {
                isDocAtrChanged = false; 
                Close();
            }

        }

        
        private void DoEditDocumentInHistory()
        {
            #region Checks
            
            if (ultraTextEditor1.Text.Trim() == "")
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სათაური არ შეიძლება იყოს ცარიელი"); return; }

            if (CAuthor.SelectedRow == null)
            { ILG.Windows.Forms.ILGMessageBox.Show("მიმღები ორგანო არის აუცილებელი ველი"); return; }
            //{ ILGMessageBox.Show($" {CodexDSOrganizationSettings.Instance.Settings.DisplayModel.authorAttributeSettings.DisplayName} არის აუცილებელი ველი"); return; }
 

            if ((int)CAuthor.SelectedRow.Cells["A_ID"].Value == 0)
            { ILG.Windows.Forms.ILGMessageBox.Show("მიმღები ორგანო არის აუცილებელი ველი"); return; }
            //{ ILGMessageBox.Show($" {CodexDSOrganizationSettings.Instance.Settings.DisplayModel.authorAttributeSettings.DisplayName} არის აუცილებელი ველი"); return; }
 

            if (CType.SelectedRow == null)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სახე არის აუცილებელი ველი"); return; }

            if ((int)CType.SelectedRow.Cells["T_ID"].Value == 0)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სახე არის აუცილებელი ველი"); return; }

            if (CSbject.SelectedRow == null)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თემატიკა არის აუცილებელი ველი"); return; }

            if ((int)CSbject.SelectedRow.Cells["S_ID"].Value == 0)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თემატიკა არის აუცილებელი ველი"); return; }

            if (Dt == null)
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თარიღი არის აუცილებელი ველი"); return; }

            // Check if Document Empty
            if ((DefaultDocumentFormat == 0) && (TxDocument.isTextEmpty()))
            { ILG.Windows.Forms.ILGMessageBox.Show("RTF დოკუმენტის ტექსტი ცარილელია"); return; }


            if ((DefaultDocumentFormat == 1) && (this.SellectedPDF.Trim() == ""))
            { ILG.Windows.Forms.ILGMessageBox.Show("PDF დოკუმენტის ტექსტი ცარილელია"); return; }
            #endregion Checks

            #region Additinal Checks
            if (CodexDSBehavioral.Default.UseCategoryAsMandatory == true)
            {
                if (CCategory.SelectedRow == null)
                { ILGMessageBox.Show("დოკუმენტის კატეგორია არის აუცილებელი ველი"); return; }

                if ((int)CCategory.SelectedRow.Cells["C_ID"].Value == 0)
                { ILGMessageBox.Show("დოკუმენტის კატეგორია არის აუცილებელი ველი"); return; }
            }

            if (CodexDSBehavioral.Default.UseStatusAsMandatory == true)
            {
                if (CStatus.SelectedRow == null)
                { ILGMessageBox.Show("დოკუმენტის სტატუსი არის აუცილებელი ველი"); return; }

                if ((int)CStatus.SelectedRow.Cells["C_ID"].Value == 0)
                { ILGMessageBox.Show("დოკუმენტის სტატუსი არის აუცილებელი ველი"); return; }
            }

            if (CodexDSBehavioral.Default.UseNumberAsManadatory == true)
            {
                if ((ultraTextEditor2.Text.Trim() == ""))
                { ILGMessageBox.Show("დოკუმენტის ნომერი არის აუცილებელი ველი"); return; }
            }

            #endregion Additinal Checks


            if (License.IsConfidentialSaveAllow() == false)
            {
                if (CSecStatus.SelectedIndex != 0)
                {
                    ILGMessageBox.Show("თქვენ არ გაქვთ უფლება ჩაწეროთ კონფიდენციალური დოკუმენტი");
                    return;
                }
            }

            if (Properties.Settings.Default.AskToRemoveSections == true)
            {
                if (TxDocument.MoreThanOneSection() == true)
                {
                    if (ILGMessageBox.Show("დოკუმენტი შეიცავს სექციებს, ის არ გამოჩნდება კარგად კოდექს დოკუმენტების არქივის ადრეულ ვერსიებში \nგავაგრძელო ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }
            }



            // Confirm to Save Document
            if (ILGMessageBox.Show("დოკუმენტის შეცვლა", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის შეცვლა დაადასტურეთ", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (CodexDSBehavioral.Default.CheckSaveChangeConditionOnDublicate == true)
            {
                //if (CheckTheDocumentExistance() == true)
                //{
                //    if (CodexDSBehavioral.Default.CheckSaveWarnOnly == true)
                //    {
                //        if (ILGMessageBox.Show("დოკუმენტი ესეთი პარამეტრებით უკვე არსებობს ბაზაში გავაგრძელო ?", "", MessageBoxButtons.YesNo,
                //           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                //    }
                //    else
                //    {
                //        ILGMessageBox.Show("დოკუმენტი ესეთი პარამეტრებით უკვე არსებობს ბაზაში" + System.Environment.NewLine + "მისი ჩაწერა არ მოხდება", "", MessageBoxButtons.OK,
                //               MessageBoxIcon.Error);
                //        return;
                //    }
                //}

            }


            #region Prepare Parameters
            int EEDocNumber = 0;
            if (Int32.TryParse(ultraTextEditor2.Text, out EEDocNumber) == false) EEDocNumber = -1;

            int DocumentStatus = -1;
            if (CStatus.SelectedRow == null) DocumentStatus = 0;
            else DocumentStatus = (int)CStatus.SelectedRow.Cells["C_ID"].Value;

            int DocumentCategory = -1;
            if (CCategory.SelectedRow == null) DocumentCategory = 0;
            else DocumentCategory = (int)CCategory.SelectedRow.Cells["C_ID"].Value;

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (DefaultDocumentFormat == 0) CreareRTFDocument();
                if (DefaultDocumentFormat == 1) CrearePDFDocument();
                CreareLinks();
                CreareAttachment();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის ჩაწერა Error #A10001", ex.Message.ToString());
                return;
            }



            int HistoryStatus = 0;

            try
            {
                var i = HistoryStatus_Combo.SelectedIndex;
                if (i == 2) HistoryStatus = -1; else HistoryStatus = i;
            }
            catch
            {
                HistoryStatus = 0;
            }

            #endregion Prepare Parameters


            // Save Procedure


            // Changed in DS 1.6

            #region SaveDoc
            try
            {
                using (new WaitCursor())
                {
                    using (SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
                    {
                        cn.Open();
                        using (SqlTransaction tr = cn.BeginTransaction())
                        {
                            #region Create Command "UpdateDoc" in History

                            String UpdateCommand = "UPDATE [dbo].[CodexDS_DDOCS_History] SET [H_Date] = @H_Date, [H_Status] = @H_Status,  [C_CAPTION] = @C_CAPTION, [C_AUTHOR] = @C_AUTHOR" +
                                ", [C_Subject] = @C_Subject, [C_TYPE] = @C_TYPE, [C_WORDS] = @C_WORDS, [C_NUMBER]" +
                                " = @C_NUMBER, [C_NumberStr] = @C_NumberStr, [C_DATE] = @C_DATE, [C_LASTEDIT] = @" +
                                "C_LASTEDIT, [C_TEXT] = @C_TEXT, [C_LINK] = @C_LINK" +
                                ", [C_STATUS] = @C_STATUS, [C_DocFormat] = @C_DocFormat, [C_DocEncoding] = @C_Doc" +
                                "Encoding, [C_DocText] = @C_DocText, [C_Coments] = @C_Coments, [C_Version] = @C_V" +
                                "ersion, [C_Presentation] = @C_Presentation, [C_Original] = @C_Original, [C_Attac" +
                                "h] = @C_Attach, [C_Group] = @C_Group, [C_Category] = @C_Category, [C_Addtional] " +
                                "= @C_Addtional, [C_Picture] = @C_Picture WHERE ([id] = @Original_id)        ";

                            SqlCommand UpdateDoc = new SqlCommand(UpdateCommand, cn, tr);
                            UpdateDoc.CommandText = UpdateCommand;
                            UpdateDoc.CommandType = CommandType.Text;

                            UpdateDoc.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@H_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "H_Status", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@H_DATE", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "H_DATE", DataRowVersion.Current, false, null, "", "", ""));


                            UpdateDoc.Parameters.Add(new SqlParameter("@C_CAPTION", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "C_CAPTION", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_AUTHOR", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_AUTHOR", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Subject", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_Subject", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_TYPE", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_TYPE", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_WORDS", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "C_WORDS", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_NUMBER", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_NUMBER", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_NumberStr", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "C_NumberStr", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_DATE", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "C_DATE", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_LASTEDIT", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "C_LASTEDIT", DataRowVersion.Current, false, null, "", "", ""));

                            UpdateDoc.Parameters.Add(new SqlParameter("@C_TEXT", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_TEXT", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_LINK", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_LINK", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_STATUS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_STATUS", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_DocFormat", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_DocFormat", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_DocEncoding", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "C_DocEncoding", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_DocText", SqlDbType.NText, 0, ParameterDirection.Input, 0, 0, "C_DocText", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Coments", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "C_Coments", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Version", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_Version", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Presentation", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_Presentation", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Original", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_Original", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Attach", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_Attach", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Group", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_Group", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Category", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "C_Category", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Addtional", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "C_Addtional", DataRowVersion.Current, false, null, "", "", ""));
                            UpdateDoc.Parameters.Add(new SqlParameter("@C_Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "C_Picture", DataRowVersion.Current, false, null, "", "", ""));
                            #endregion Create Command "UpdateDoc"

                            
                            #region Fill Rarameters
                            try
                            {
                                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                                #region FillParameters
                                UpdateDoc.Parameters["@Original_id"].Value = History_IID;
                                UpdateDoc.Parameters["@H_Date"].Value = Dt_H;
                                UpdateDoc.Parameters["@H_STATUS"].Value = HistoryStatus;

                                UpdateDoc.Parameters["@C_CAPTION"].Value = ultraTextEditor1.Text.Trim();
                                UpdateDoc.Parameters["@C_AUTHOR"].Value = (int)CAuthor.SelectedRow.Cells["A_ID"].Value;
                                UpdateDoc.Parameters["@C_Subject"].Value = (int)CSbject.SelectedRow.Cells["S_ID"].Value;
                                UpdateDoc.Parameters["@C_TYPE"].Value = (int)CType.SelectedRow.Cells["T_ID"].Value;
                                UpdateDoc.Parameters["@C_WORDS"].Value = EWord.Text;
                                UpdateDoc.Parameters["@C_NUMBER"].Value = EEDocNumber;
                                UpdateDoc.Parameters["@C_NumberStr"].Value = ultraTextEditor2.Text.Trim();
                                UpdateDoc.Parameters["@C_DATE"].Value = Dt;
                                UpdateDoc.Parameters["@C_LASTEDIT"].Value = DateTime.Now;

                                UpdateDoc.Parameters["@C_TEXT"].Value = resultdoc;
                                UpdateDoc.Parameters["@C_LINK"].Value = linkresult;
                                UpdateDoc.Parameters["@C_STATUS"].Value = DocumentStatus;
                                UpdateDoc.Parameters["@C_DocFormat"].Value = DefaultDocumentFormat;
                                UpdateDoc.Parameters["@C_DocEncoding"].Value = "UNICODE";

                                if (ILG.Codex.CodexR4.Properties.Settings.Default.DocumentEncogingPolicy == true)
                                {
                                    UpdateDoc.Parameters["@C_DocEncoding"].Value = CEncoding.Value.ToString().Trim();
                                }


                                if (DefaultDocumentFormat == 0)
                                    UpdateDoc.Parameters["@C_DocText"].Value = resultText;
                                else
                                    UpdateDoc.Parameters["@C_DocText"].Value = textBox1.Text;

                                UpdateDoc.Parameters["@C_Coments"].Value = ultraTextEditor5.Text.Trim();
                                UpdateDoc.Parameters["@C_Version"].Value = 1;
                                UpdateDoc.Parameters["@C_Presentation"].Value = DBNull.Value;
                                UpdateDoc.Parameters["@C_Original"].Value = DBNull.Value;


                                if (HasAttachments == true)
                                    UpdateDoc.Parameters["@C_Attach"].Value = attachments;
                                else
                                    UpdateDoc.Parameters["@C_Attach"].Value = DBNull.Value;

                                UpdateDoc.Parameters["@C_Group"].Value = CSecStatus.SelectedIndex;
                                UpdateDoc.Parameters["@C_Category"].Value = DocumentCategory;
                                UpdateDoc.Parameters["@C_Addtional"].Value = ultraTextEditor6.Text.Trim();
                                UpdateDoc.Parameters["@C_Picture"].Value = DBNull.Value;
                                #endregion FillParameters
                                this.Cursor = System.Windows.Forms.Cursors.Default;
                            }
                            catch (Exception ex)
                            {
                                this.Cursor = System.Windows.Forms.Cursors.Default;
                                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის ჩაწერა Error #H10002", ex.Message.ToString());
                                return;
                            }
                            #endregion Fill Rarameters

                      
                            //some code
                            UpdateDoc.ExecuteNonQuery();
              
                            tr.Commit();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის ჩაწერა Error #H10001", ex.Message.ToString());
                return;
            }
            #endregion SaveDoc

            
            this.Cursor = Cursors.Default;
            ILGMessageBox.Show("დოკუმენტი ჩაწერილია");
            // Detemine Close or not after Saving
         
            if (Properties.Settings.Default.DSAfterSaveNewDoc == false)
            {
                isDocAtrChanged = false;
                this.ultraTextEditor1.Text = "";
                isDocAtrChanged = false;
            }
            else
            {
                isDocAtrChanged = false;
                Close();
            }

        }

        public void DoAdminDeleteDocumentInHistory()
        {
            if (License.IsRecoverDeletedDocumentsGranted() == false)
            {
                ILGMessageBox.Show("თქვენ არ გაქვთ უფლება წაშალოთ დოკუმენტი");
                return;
            }
            // Confirm to Save Document
            if (ILGMessageBox.Show("დოკუმენტის წაშლა (admin რეჟიმში) \nწაშლილი დოკუმენტი აღარ აღდგება !", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის წაშლა (admin რეჟიმში) დაადასტურეთ  \nწაშლილი დოკუმენტი აღარ აღდგება !!", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის წაშლა (admin რეჟიმში) დაადასტურეთ ხელმეორედ \nწაშლილი დოკუმენტი აღარ აღდგება !!!", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის წაშლა (admin რეჟიმში) დაადასტურეთ კიდევ ერთხელ \nწაშლილი დოკუმენტი აღარ აღდგება !!!!", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            // DELETE Procedure

            try
            {
                using (new WaitCursor())
                {
                    using (SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
                    {
                        cn.Open();
                        using (SqlTransaction tr = cn.BeginTransaction())
                        {


                            #region Create Command "DeleteDoc"
                            String DeleteCommandSQL = "DELETE [dbo].[CodexDS_DDOCS_History] WHERE ([id] = @Original_id) ";

                            SqlCommand DeleteDoc = new SqlCommand(DeleteCommandSQL, cn, tr);
                            DeleteDoc.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Current, false, null, "", "", ""));

                            #endregion Create Command "DeleteDoc"

          
                            DeleteDoc.Parameters["@Original_id"].Value = History_IID;

                            DeleteDoc.ExecuteNonQuery();
                            
                            tr.Commit();


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის წაშლა Error #A10001", ex.Message.ToString());
                return;

            }

            this.Cursor = System.Windows.Forms.Cursors.Default;
            ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი წაშლილია");
            // Detemine Close or not after Saving
            //(this.FormMain as Form1).LoadTables();
            //(this.FormMain as Form1).DisplayParametersLimited();

            //if (ILG.Codex.CodexR4.Properties.Settings.Default.DSAfterSaveNewDoc == false)
            //{
            //    isDocAtrChanged = false;
            //    this.ultraTextEditor1.Text = "";
            //    isDocAtrChanged = false;
            //}
            //else
            {
                isDocAtrChanged = false;
                Close();
            }

        }

        public void DoDeleteDocumentInHistory()
        {

            if (License.IsDeleteAlowed() == false)
            {
                ILGMessageBox.Show("თქვენ არ გაქვთ უფლება წაშალოთ დოკუმენტი");
                return;
            }
            // Confirm to Save Document
            if (ILGMessageBox.Show("დოკუმენტის წაშლა \nწაშლილი დოკუმენტი აღარ აღდგება", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის წაშლა დაადასტურეთ \nწაშლილი დოკუმენტი აღარ აღდგება", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის წაშლა დაადასტურეთ ხელმეორედ \nწაშლილი დოკუმენტი აღარ აღდგება", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის წაშლა დაადასტურეთ კიდევ ერთხელ \nწაშლილი დოკუმენტი აღარ აღდგება", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            // DELETE Procedure
            int HistoryStatus = 0;

            try
            {
                var i = HistoryStatus_Combo.SelectedIndex;
                if (i == 2) HistoryStatus = -1;
            }
            catch
            {
                HistoryStatus = 0;
            }

            try
            {
                using (new WaitCursor())
                {
                    using (SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
                    {
                        cn.Open();
                        using (SqlTransaction tr = cn.BeginTransaction())
                        {
                  
                            #region Create Command DeleteDoc  User  mode "UpdateDoc" in History

                            String DeleteCommandSQL = "UPDATE [dbo].[CodexDS_DDOCS_History] SET[H_Status] = @H_Status "+
                                "WHERE ([id] = @Original_id)   ";

                            SqlCommand DeleteDoc = new SqlCommand(DeleteCommandSQL, cn, tr);

                            DeleteDoc.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Current, false, null, "", "", ""));
                            DeleteDoc.Parameters.Add(new SqlParameter("@H_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "H_Status", DataRowVersion.Current, false, null, "", "", ""));

                            #endregion Create Command DeleteDoc  User  mode "UpdateDoc" in History


                            #region Fill Rarameters
                            try
                            {
                                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                                DeleteDoc.Parameters["@Original_id"].Value = History_IID;
                                DeleteDoc.Parameters["@H_STATUS"].Value = HistoryStatus;
                                
                                this.Cursor = System.Windows.Forms.Cursors.Default;
                            }
                            catch (Exception ex)
                            {
                                this.Cursor = Cursors.Default;
                                ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის ჩაწერა Error #H10002", ex.Message.ToString());
                                return;
                            }
                            #endregion Fill Rarameters



                            DeleteDoc.Parameters["@Original_id"].Value = History_IID;
                            DeleteDoc.Parameters["@H_STATUS"].Value = -1;

                            DeleteDoc.ExecuteNonQuery();

                            tr.Commit();


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის წაშლა Error #H10001", ex.Message.ToString());
                return;

            }

            this.Cursor = Cursors.Default;
            ILGMessageBox.Show("დოკუმენტი წაშლილია");
            // Detemine Close or not after Saving
            //(this.FormMain as Form1).LoadTables();
            //(this.FormMain as Form1).DisplayParametersLimited();

            //if (ILG.Codex.CodexR4.Properties.Settings.Default.DSAfterSaveNewDoc == false)
            //{
            //    isDocAtrChanged = false;
            //    this.ultraTextEditor1.Text = "";
            //    isDocAtrChanged = false;
            //}
            //else
            {
                isDocAtrChanged = false;
                Close();
            }

        }

        public void DoDeleteDocumentInHistory_ExternalCall(int pid)
        {

            if (License.IsDeleteAlowed() == false)
            {
                ILGMessageBox.Show("თქვენ არ გაქვთ უფლება წაშალოთ დოკუმენტი");
                return;
            }
            // Confirm to Save Document
            if (ILGMessageBox.Show("დოკუმენტის წაშლა \nწაშლილი დოკუმენტი აღარ აღდგება", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის წაშლა დაადასტურეთ \nწაშლილი დოკუმენტი აღარ აღდგება", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის წაშლა დაადასტურეთ ხელმეორედ \nწაშლილი დოკუმენტი აღარ აღდგება", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის წაშლა დაადასტურეთ კიდევ ერთხელ \nწაშლილი დოკუმენტი აღარ აღდგება", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            // DELETE Procedure
            int HistoryStatus = -1;

      

            try
            {
                using (new WaitCursor())
                {
                    using (SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
                    {
                        cn.Open();
                        using (SqlTransaction tr = cn.BeginTransaction())
                        {

                            #region Create Command DeleteDoc  User  mode "UpdateDoc" in History

                            String DeleteCommandSQL = "UPDATE [dbo].[CodexDS_DDOCS_History] SET[H_Status] = @H_Status " +
                                "WHERE ([id] = @Original_id)   ";

                            SqlCommand DeleteDoc = new SqlCommand(DeleteCommandSQL, cn, tr);

                            DeleteDoc.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Current, false, null, "", "", ""));
                            DeleteDoc.Parameters.Add(new SqlParameter("@H_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "H_Status", DataRowVersion.Current, false, null, "", "", ""));

                            #endregion Create Command DeleteDoc  User  mode "UpdateDoc" in History


                            #region Fill Rarameters
                            try
                            {
                                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                                DeleteDoc.Parameters["@Original_id"].Value = pid;
                                DeleteDoc.Parameters["@H_STATUS"].Value = HistoryStatus;

                                this.Cursor = System.Windows.Forms.Cursors.Default;
                            }
                            catch (Exception ex)
                            {
                                this.Cursor = Cursors.Default;
                                ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის წაშლა Error #H10002", ex.Message.ToString());
                                return;
                            }
                            #endregion Fill Rarameters



                            DeleteDoc.Parameters["@Original_id"].Value = pid;
                            DeleteDoc.Parameters["@H_STATUS"].Value = -1;

                            DeleteDoc.ExecuteNonQuery();

                            tr.Commit();


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის წაშლა Error #H10001", ex.Message.ToString());
                return;

            }

            this.Cursor = Cursors.Default;
            ILGMessageBox.Show("დოკუმენტი წაშლილია");
            // Detemine Close or not after Saving
            //(this.FormMain as Form1).LoadTables();
            //(this.FormMain as Form1).DisplayParametersLimited();

            //if (ILG.Codex.CodexR4.Properties.Settings.Default.DSAfterSaveNewDoc == false)
            //{
            //    isDocAtrChanged = false;
            //    this.ultraTextEditor1.Text = "";
            //    isDocAtrChanged = false;
            //}
            //else
        }

        #endregion SaveEditDelDoc

        private void CDocFormat_ValueChanged(object sender, EventArgs e)
        {
            if (CDocFormat.SelectedIndex == 0) // RTF
            {
                DefaultDocumentFormat = 0; return;
            }
            if (CDocFormat.SelectedIndex == 1) // PDF
            {
                DefaultDocumentFormat = 1; return;
            }
        }


        private void CSecStatus_ValueChanged(object sender, EventArgs e)
        {
            if (DocumentMode == 0)
            {
                if ((SSS == 1) && (CSecStatus.SelectedIndex == 0))
                {
                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი იყო კონფიდენციალური თქვენ მას ეს შეზღუდვა მოუხსენით \nამ დოკუმნეტზე წვდომას შესძლებს ყველა \n დარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Error,MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) { CSecStatus.SelectedIndex = 1; return; }

                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი იყო კონფიდენციალური თქვენ მას ეს შეზღუდვა მოუხსენით \nამ დოკუმნეტზე წვდომას შესძლებს ყველა \n დარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) { CSecStatus.SelectedIndex = 1; return; }

                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი იყო კონფიდენციალური თქვენ მას ეს შეზღუდვა მოუხსენით \nამ დოკუმნეტზე წვდომას შესძლებს ყველა \n დარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) { CSecStatus.SelectedIndex = 1; return; }
                }
            }
        }

        private void ultraTabControl3_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("არსებული ტექსტის შეცვლა ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            }
                textBox1.Paste();
           
        }

        





        private void ultraButton3_Click(object sender, EventArgs e)
        {

            FormMain.ID_Finder.ShowDialog();
            if (FormMain.ID_Finder.Return_ID != -1)
            {
                CLinkID.Text = FormMain.ID_Finder.Return_ID.ToString();
            }
        }





        private void DocumentAddEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            axAcroPDF1.Dispose();
            axAcroPDF1 = null;

        }

     


        public bool HasDocumentHistory(int ID)
        {
            string strsql = $"Select Count(C_ID) from CodexDS_DDOCS_History WHERE (C_ID = {ID.ToString()})  AND (H_Status = 0)  ";
            if (License.IsHistoryExtendedAccessGranted() == true) strsql = $"Select Count(C_ID) from CodexDS_DDOCS_History WHERE C_ID = {ID.ToString()} ";
            bool result = false;
            using (var cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand(strsql, cn);
                result = ((int)cm.ExecuteScalar() > 0);
            }
            return result;
        }


        //HistoryListModel model = new HistoryListModel();
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


        HistoryListModel historymodel = new HistoryListModel();

        // History H_Status 0 is Default
        // H_Status 1 is Hidden
        // H_Status -1 is Deleted History Link
        // H_Status -16 Deleted Base Document

        private void CodexLoadHistoryItems(int ID)
        {
           
            historymodel.Items.Clear();

            String Fields = " [id] ,[H_Date], [H_Status] ,[C_ID] ,[C_CAPTION] ,[C_AUTHOR] ,[C_TYPE],[C_NUMBER]  ,[C_NumberStr]    ,[C_DATE], [C_DocFormat], ISNULL(DATALENGTH(C_Attach),0) AS AttachmentSize ";

            string strsql = $"Select {Fields} from CodexDS_DDOCS_History " +
                            $" WHERE ((C_ID = { ID.ToString() } ) AND ( H_STATUS = 0)) Order By H_Date desc";

            if (License.IsHistoryExtendedAccessGranted() == true)
                strsql = $"Select {Fields} from CodexDS_DDOCS_History " +
                            $" WHERE (C_ID = { ID.ToString() } ) AND (( H_STATUS = 0) OR (H_STATUS = 1)) Order By H_Date desc";

            if (License.IsRecoverDeletedDocumentsGranted() == true) // Only in Admin mode IsDeletedInHistoryGranted() == true)
                strsql = $"Select {Fields} from CodexDS_DDOCS_History " +
                            $" WHERE (C_ID = { ID.ToString() } ) AND (( H_STATUS = 0) OR (H_STATUS = 1) OR (H_STATUS = -1)) Order By H_Date desc";


            using (var cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
            {
                cn.Open();

                using (var command = new SqlCommand(strsql, cn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            historymodel.Items.Add(new HistoryListModelEntry()
                            {
                                ID = (int)reader["ID"],
                                HistoryTitle = HistoryListDateTimetoGString((DateTime)reader["H_Date"]) + " " + ((DateTime)reader["H_Date"]).ToShortTimeString(),
                                DocumentFormat = (int)reader["C_DocFormat"],
                                HistoryStatusField = (int)reader["H_Status"],
                                HasAttachment = ((int)reader["AttachmentSize"] > 0),
                                Caption = (string)reader["C_Caption"]
                            }

                            );
                        }
                    }
                }
            }

        }


     



        private void HistoryDate_Button_Click(object sender, EventArgs e)
        {
            var dlg2 = new ILG.Codex.CodexR4.PickDate(Dt);
            Point dc2 = new Point(HistoryDate_Edit.Location.X, EDate1.Location.Y);
            Point dc = tableLayoutPanel9.PointToScreen(dc2);
            dlg2.Location = dc;
            dlg2.ShowDialog();
            HistoryDate_Edit.Text = dlg2.ToString();
            Dt_H = dlg2.PickedDate;
        }

        private string GetSQLforRecovery(int idInHistoryTable)
        {
            String SQL =
                " IF OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL " + System.Environment.NewLine +
                "  BEGIN " + System.Environment.NewLine +
                "    SET IDENTITY_INSERT CodexDS_DDOCS ON " + System.Environment.NewLine +

                "    INSERT INTO CodexDS_DDOCS([C_ID], [C_CAPTION], [C_AUTHOR], [C_Subject], [C_TYPE], [C_WORDS], [C_NUMBER], [C_NumberStr], [C_DATE], [C_LASTEDIT], [C_ENTERDATE], [C_TEXT], [C_LINK], [C_STATUS], [C_DocFormat], [C_DocEncoding], [C_DocText], [C_Coments], [C_Version], [C_Presentation], [C_Original], [C_Attach], [C_Group], [C_Category], [C_Addtional], [C_Picture]) " + System.Environment.NewLine +
                "    SELECT [C_ID], [C_CAPTION], [C_AUTHOR], [C_Subject], [C_TYPE], [C_WORDS], [C_NUMBER], [C_NumberStr], [C_DATE], [C_LASTEDIT], [C_ENTERDATE], [C_TEXT], [C_LINK], [C_STATUS], [C_DocFormat], [C_DocEncoding], [C_DocText], [C_Coments], [C_Version], [C_Presentation], [C_Original], [C_Attach], [C_Group], [C_Category], [C_Addtional], [C_Picture] " + System.Environment.NewLine +
                "    FROM CodexDS_DDOCS_History " + System.Environment.NewLine +
               $"    WHERE id = {idInHistoryTable}; " + System.Environment.NewLine +

                "    SET IDENTITY_INSERT CodexDS_DDOCS OFF " + System.Environment.NewLine +
               $"    DELETE FROM CodexDS_DDOCS_History WHERE id = {idInHistoryTable}; " + System.Environment.NewLine +

                "    UPDATE CodexDS2007 SET[C_CodexDSDocs] = (SELECT COUNT(C_ID) FROM CodexDS_DDocs), [C_CodexDate] = GETDATE(), [C_Date] = GETDATE() " + System.Environment.NewLine +
                "    WHERE[C_Version] = 50 " + System.Environment.NewLine +
                "  END";

            return SQL;
        }

        private string GetSQLforRecoveryASNew(int idInHistoryTable)
        {
            String SQL =
                " IF OBJECT_ID(N'CodexDS_DDOCS_History', N'U') IS NOT NULL " + System.Environment.NewLine +
                "  BEGIN " + System.Environment.NewLine +
                "    SET IDENTITY_INSERT CodexDS_DDOCS ON " + System.Environment.NewLine +

                "    INSERT INTO CodexDS_DDOCS([C_CAPTION], [C_AUTHOR], [C_Subject], [C_TYPE], [C_WORDS], [C_NUMBER], [C_NumberStr], [C_DATE], [C_LASTEDIT], [C_ENTERDATE], [C_TEXT], [C_LINK], [C_STATUS], [C_DocFormat], [C_DocEncoding], [C_DocText], [C_Coments], [C_Version], [C_Presentation], [C_Original], [C_Attach], [C_Group], [C_Category], [C_Addtional], [C_Picture]) " + System.Environment.NewLine +
                "    SELECT [C_CAPTION], [C_AUTHOR], [C_Subject], [C_TYPE], [C_WORDS], [C_NUMBER], [C_NumberStr], [C_DATE], [C_LASTEDIT], [C_ENTERDATE], [C_TEXT], [C_LINK], [C_STATUS], [C_DocFormat], [C_DocEncoding], [C_DocText], [C_Coments], [C_Version], [C_Presentation], [C_Original], [C_Attach], [C_Group], [C_Category], [C_Addtional], [C_Picture] " + System.Environment.NewLine +
                "    FROM CodexDS_DDOCS_History " + System.Environment.NewLine +
               $"    WHERE id = {idInHistoryTable}; " + System.Environment.NewLine +

                "    SET IDENTITY_INSERT CodexDS_DDOCS OFF " + System.Environment.NewLine +
               $"    DELETE FROM CodexDS_DDOCS_History WHERE id = {idInHistoryTable}; " + System.Environment.NewLine +

                "    UPDATE CodexDS2007 SET[C_CodexDSDocs] = (SELECT COUNT(C_ID) FROM CodexDS_DDocs), [C_CodexDate] = GETDATE(), [C_Date] = GETDATE() " + System.Environment.NewLine +
                "    WHERE[C_Version] = 50 " + System.Environment.NewLine +
                "  END";

            return SQL;
        }

        private string GetSQLforCheck(int idInMainTable)
        {
            String SQL =
                $" SELECT COUNT(*) FROM CodexDS_DDOCS WHERE C_ID = {idInMainTable}  ";
            return SQL;
        }

        public bool ISDocumentRecovable(int idHistory)
        {
            string FullSQLStatment =  $"SELECT COUNT(*) FROM CodexDS_DDOCS WHERE C_ID = (Select C_ID FROM CodexDS_DDOCS_History WHERE ID = {idHistory})";
         
            using (SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand(FullSQLStatment, cn);
                int Qunatity = (int)cm.ExecuteScalar();
                if (Qunatity == 0) return true;
            }
            return false;
        }


        private void DORecoveryoftheDocument()
        {
            if (License.IsRecoverDeletedDocumentsGranted() == false)
            {
                ILGMessageBox.Show("თქვენ არ გაქვთ აამ ოპერაციის უფლება");

            }

            if (ILGMessageBox.Show("დოკუმენტის აღდგენა", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (ILGMessageBox.Show("დოკუმენტის აღდგენა დაადასტურეთ", "", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            int _id = History_IID;
            bool RecoveryMode = true;
            if (ISDocumentRecovable(_id) == false)
            {
                if (ILGMessageBox.Show("ეს დოკუემნტი უკვე არსებობს ბაზაში, მისი აღდგენა შესაძლებელია როგორც ახლის" + System.Environment.NewLine +"ამ შემთხვევაში დაირღვევა კავშირები", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

                if (ILGMessageBox.Show("მისი აღდგენა შესაძლებელია როგორც ახლის" + System.Environment.NewLine + "ამ შემთხვევაში დაირღვევა კავშირები დაადასტურეთ", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
                RecoveryMode = false;
            }

            #region Recovery
            try
            {
                using (new WaitCursor())
                {
                    using (SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS))
                    {
                        cn.Open();
                        using (SqlTransaction tr = cn.BeginTransaction())
                        {
                            String RecoveryCommandSQL = GetSQLforRecovery(_id);
                            if (RecoveryMode == false) RecoveryCommandSQL = GetSQLforRecoveryASNew(_id);
                         
                            SqlCommand RecoveryCommand = new SqlCommand(RecoveryCommandSQL, cn, tr);
                            RecoveryCommand.ExecuteNonQuery();
                            tr.Commit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის აღდგენა Error #R10001", ex.Message.ToString());
                return;
            }
            #endregion Recovery


            this.Cursor = Cursors.Default;
            ILGMessageBox.Show("დოკუმენტი აღდგენელია");
            this.isDocAtrChanged = false;
            Close();
        }

    }
}