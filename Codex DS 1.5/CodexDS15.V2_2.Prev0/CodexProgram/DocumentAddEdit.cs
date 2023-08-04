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

namespace ILG.Codex.Codex2007
{
    public partial class DocumentAddEdit : Form
    {
        int DefaultDocumentFormat = 0;
        string SellectedPDF = "";
        string Codex_DocEncoding = "";
        private TXTextControl.HeaderFooter m_ActiveHeaderFooter = null;
        DataSet DS;
        DateTime Dt;
        int DocumentMode = -1;
        bool isDocAtrChanged = false;
        public Form1 FormMain;
        Form_Test_Document F_TEST_DOC;
        int IID = -1;
        int SSS; // Sectert Status


        public DocumentAddEdit()
        {
            InitializeComponent();

            //this.axAcroPDF1.CreateControl();

            F_TEST_DOC = new Form_Test_Document();
            F_TEST_DOC.MainForm = (Form1)this.FormMain;

            if (ILG.Codex.Codex2007.Properties.Settings.Default.DocumentEncogingPolicy == true)
            {
                CEncoding.Enabled = true;
                CEncoding.Visible = true;
                LEncoding.Enabled = true;
                LEncoding.Visible = true;

                CEncoding.SelectedIndex = ILG.Codex.Codex2007.Properties.Settings.Default.DocumentDefaultEncoding;
            }
            else
            {
                CEncoding.Enabled = false;
                CEncoding.Visible = false;
                LEncoding.Enabled = false;
                LEncoding.Visible = false;

            }
            
       
        }

        public void NewDocumentMode()
        {
            #region TextControl
//            this.textControl1.SelectAll();
  //          this.textControl1.Selection.Text = "";

            this.textControl1.Load("", TXTextControl.StringStreamType.PlainText);
            try
            {
                while (this.textControl1.Tables.Count != 0)
                {
                    this.textControl1.Tables.Remove();
                }
            }
            catch
            {
            }

            // Set Margines
            TXTextControl.LoadSettings LoadSettings = new TXTextControl.LoadSettings();
            
            this.textControl1.PageMargins.Top     = ILG.Codex.Codex2007.Properties.Settings.Default.DocumentPageMarginTop;
            this.textControl1.PageMargins.Bottom  = ILG.Codex.Codex2007.Properties.Settings.Default.DocumentPageMarginBottom;
            this.textControl1.PageMargins.Left    = ILG.Codex.Codex2007.Properties.Settings.Default.DocumentPageMarginLeft ;
            this.textControl1.PageMargins.Right   = ILG.Codex.Codex2007.Properties.Settings.Default.DocumentPageMarginRight;

            this.textControl1.PageSize = new TXTextControl.PageSize(Properties.Settings.Default.DocumentPageWidth,
                                                                    Properties.Settings.Default.DocumentPageHeight);
           
            #endregion TextControl
            
            DocumentMode = 1; // Add
            CLinkType.SelectedIndex = 1;
            CLinkAccess.SelectedIndex = 0;
            ElinkOrder.Text = "0";
            CSecStatus.SelectedIndex = 0;
            CDocFormat.SelectedIndex = 0;
            EDate1.Text = PickDate.DateToString(Dt);

            #region Create New Empty Zip File
            ZipFileName = ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + "znew_" + DateTime.Now.Ticks.ToString() + ".zip";
            // Create Attach Zip File name

            
                try
                {
                    //DiskFile f11 = new DiskFile(ZipFileName);
                    //f11.Create();
                    //zipfile = new ZipArchive(f11);
                    //zipfile.Create();
                }
                catch (Exception x1)
                {
                    ILG.Windows.Forms.ILGMessageBox.ShowE("ახალი დოკუმენტის პარამეტრების შექმნა ვერ ხერხდება", "CE 418", x1.Message.ToString());
                    ///zipfile.Close();
                    
                    return;
                }
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
            ultraToolbarsManager1.Tools["DDSaveNew"].SharedProps.Enabled = true;
            ultraToolbarsManager1.Tools["DDNewDocument"].SharedProps.Enabled = true;
            ultraToolbarsManager1.Tools["DDSaveAsNew"].SharedProps.Enabled = false;
            ultraToolbarsManager1.Tools["DDDeleteDocument"].SharedProps.Enabled = false;
            ultraToolbarsManager1.Tools["DDSaveChanges"].SharedProps.Visible = false;

            this.Cursor = System.Windows.Forms.Cursors.Default;

            ultraTabControl13.Visible = false;
            ultraTabControl13.Enabled = false;
            this.Text = "ახალი დოკუმენტი";
           

        }

        const int MAX_PATH = 260;
        public int EditDocumentMode(int ID)
        {

            #region Prepare Interface
            NewDocumentMode();
            
            DocumentMode = 0; // Change
            
            //xxx
            ultraToolbarsManager1.Tools["DDSaveNew"].SharedProps.Enabled = false;
            ultraToolbarsManager1.Tools["DDNewDocument"].SharedProps.Enabled = true;
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
            //IntPtr hImgLarge; //the handle to the system image list
            //string fName; //  'the file name to get icon from
            SHFILEINFO shinfo = new SHFILEINFO();


            #region Read Information From Database
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            // Define Document Call Statment
            String Fields = "C_ID,C_Caption,C_TEXT,C_Link, C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat,C_Attach,C_DocText";
            string strsql = "Select " + Fields + " FROM CODEXDS_DDOCS WHERE C_ID = " + ID.ToString() + " ";
            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
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

            #endregion Read Information From Database        
            
            #region  Codex Temp Files
            String U1 = DateTime.Now.Ticks.ToString();
            string CodexDocTempFilename = global::ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + "\\Codex_" + ID.ToString() + U1;

            while (System.IO.File.Exists(CodexDocTempFilename) == true)
            {
                U1 = DateTime.Now.Ticks.ToString();
                CodexDocTempFilename = global::ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + "\\Codex_" + ID.ToString() + U1;
            }

            U1 = DateTime.Now.Ticks.ToString();
            string CodexLinkTempFilename = global::ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + "\\CodexLink_" + ID.ToString() + U1;

            while (System.IO.File.Exists(CodexLinkTempFilename) == true)
            {
                U1 = DateTime.Now.Ticks.ToString();
                CodexLinkTempFilename = global::ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + "\\CodexLink_" + ID.ToString() + U1;
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
                textControl1.Load(DocFileName, TXTextControl.StreamType.RichTextFormat,LoadSettings);
                // Removed for Tx 15 //textControl1.PageSize = LoadSettings.PageSize; textControl1.PageMargins = LoadSettings.PageMargins; 
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
                    
                        string st1 = Properties.Settings.Default.TemporaryDir + "\\" + Path.GetFileName(f.ToString()).ToUpper().Trim();
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
            IID = ID;


            if (ILG.Codex.Codex2007.Properties.Settings.Default.DocumentEncogingPolicy == true)
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



         
            return 0;

  
  

        }

   
        #region Document Operation

        private void NewDocumentClick()
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ტექსტის და კავშირების გასუფთავება ? ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;
            NewDocumentMode();
        }

   
        private void OpenDocument()
        {
            OpenFileDialog fd = new OpenFileDialog();
            //fd.InitialDirectory = startdir;
            fd.Filter = "All files (*.*)|*.*";
            
            fd.Title = "Open Document";
            fd.Filter = "Microsoft Word 2007 (*.docx)|*.docx|Microsoft Word (*.doc)|*.doc|Rich Text Format (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*";


            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            fd.Title = "Open File";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string str = System.IO.Path.GetExtension(fd.FileName).Trim().ToUpper();
                TXTextControl.LoadSettings LoadSettings = new TXTextControl.LoadSettings();

                if (str == ".RTF")  { this.textControl1.Load(fd.FileName, TXTextControl.StreamType.RichTextFormat, LoadSettings); textControl1.PageSize = LoadSettings.PageSize; textControl1.PageMargins = LoadSettings.PageMargins; return; }
                if (str == ".DOC")  { this.textControl1.Load(fd.FileName, TXTextControl.StreamType.MSWord, LoadSettings); textControl1.PageSize = LoadSettings.PageSize; textControl1.PageMargins = LoadSettings.PageMargins;  return; }
                if (str == ".DOCX") { this.textControl1.Load(fd.FileName, TXTextControl.StreamType.WordprocessingML, LoadSettings); textControl1.PageSize = LoadSettings.PageSize; textControl1.PageMargins = LoadSettings.PageMargins; return; }

                if (str == ".TXT")  { this.textControl1.Load(fd.FileName, TXTextControl.StreamType.PlainText, LoadSettings); textControl1.PageSize = LoadSettings.PageSize; textControl1.PageMargins = LoadSettings.PageMargins; return; }
                ILG.Windows.Forms.ILGMessageBox.Show("ფაილი უცნობ ფორმატშია");
            }

        }


        private void OpenDocumentR2()
        {
            OpenFileDialog fd = new OpenFileDialog();
            //fd.InitialDirectory = startdir;
            fd.Filter = "All files (*.*)|*.*";

            fd.Title = "Open Document";
            fd.Filter = "Microsoft Word 2007 (*.docx)|*.docx|Microsoft Word (*.doc)|*.doc|Rich Text Format (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*";


            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            fd.Title = "Open File With Original Setting";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string str = System.IO.Path.GetExtension(fd.FileName).Trim().ToUpper();
                TXTextControl.LoadSettings LoadSettings = new TXTextControl.LoadSettings();

                if (str == ".RTF") { this.textControl1.Load(fd.FileName, TXTextControl.StreamType.RichTextFormat, LoadSettings);  return; }
                if (str == ".DOC") { this.textControl1.Load(fd.FileName, TXTextControl.StreamType.MSWord, LoadSettings);  return; }
                if (str == ".DOCX") { this.textControl1.Load(fd.FileName, TXTextControl.StreamType.WordprocessingML, LoadSettings);  return; }

                if (str == ".TXT") { this.textControl1.Load(fd.FileName, TXTextControl.StreamType.PlainText, LoadSettings);  }
                ILG.Windows.Forms.ILGMessageBox.Show("ფაილი უცნობ ფორმატშია");
            }

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


                string dstr = ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir.ToString() + "\\" + Path.GetFileName(fd.FileName);
                while (File.Exists(dstr) == true)
                {
                    dstr = ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir.ToString() + "\\" + DateTime.Now.Millisecond.ToString() + Path.GetFileName(fd.FileName);
                }
                File.Copy(fd.FileName, dstr);
                //this.axAcroPDF1.LoadFile(fd.FileName);
                this.axAcroPDF1.LoadFile(dstr);
                this.Cursor = System.Windows.Forms.Cursors.Default;
                SellectedPDF = fd.FileName;
            }

        }

        private void SaveDocument()
        {
            TXTextControl.SaveSettings SaveSettings = new TXTextControl.SaveSettings();
            SaveSettings.ImageSaveMode = TXTextControl.ImageSaveMode.SaveAsData;


            SaveFileDialog fd = new SaveFileDialog();
			//fd.InitialDirectory = startdir;
            fd.Filter = fd.Filter = "Microsoft Word (*.docx)|*.docx|Microsoft Word (*.doc)|*.doc|Rich Text Format (*.rtf)|*.rtf|txt files (*.txt)|*.txt";
			if (fd.ShowDialog() == DialogResult.OK)

			{
                string str = System.IO.Path.GetExtension(fd.FileName).Trim().ToUpper();

                //if (str == ".RTF")  { this.textControl1.Save(fd.FileName, TXTextControl.StreamType.RichTextFormat,SaveSettings); return; }
                //if (str == ".DOC")  { this.textControl1.Save(fd.FileName, TXTextControl.StreamType.MSWord,SaveSettings); return; }
                //if (str == ".DOCX") { this.textControl1.Save(fd.FileName, TXTextControl.StreamType.WordprocessingML, SaveSettings); return; }
                //if (str == ".TXT")  { this.textControl1.Save(fd.FileName, TXTextControl.StreamType.PlainText, SaveSettings); return; }

                if (str == ".RTF") { this.textControl1.Save(fd.FileName, TXTextControl.StreamType.RichTextFormat, SaveSettings); return; }
                if (str == ".DOC") { this.textControl1.Save(fd.FileName, TXTextControl.StreamType.MSWord, SaveSettings); return; }
                if (str == ".DOCX") { this.textControl1.Save(fd.FileName, TXTextControl.StreamType.WordprocessingML, SaveSettings); return; }
                if (str == ".TXT") { this.textControl1.Save(fd.FileName, TXTextControl.StreamType.PlainText); return; }

			}

        }

        #region View Layout
        int XViewLayout = 0;
       
        

        #endregion View Layout

        #region Zooming

        public int ZoomFactor = -20;

        private void ultraTrackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            ZoomFactor = textControl1.ZoomFactor;
        }

        private void ultraTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (ZoomFactor < 0) return;
            modify_zoomfactor(this.ultraTrackBar1.Value);
        }


        static public int PixelsPerInch = -1;


        private int detectzoom(int c)
        {

            if (PixelsPerInch == -1) PixelsPerInch = 96;
            System.Drawing.Graphics g = this.CreateGraphics();
            PixelsPerInch = (int)Math.Round(g.DpiX);

            int PageViewMargin = PixelsPerInch * 567 / 1440;                 /* 567 Twips PageLfet */

            //int W1 = F_CGL_DOC.textControl_CGL.Width - SystemInformation.HorizontalScrollBarThumbWidth - PageViewMargin*2;
            int W1 = textControl1.Width - PageViewMargin * 2;
            int H1 = textControl1.Height;
            //int bottomGap = 400;

            int nPageWidthInPixels = (int)(textControl1.PageSize.Width
                                       );
            int nPageHeightInPixels = (int)(textControl1.PageSize.Height
                                        );


            int nZoomW = (100 * W1) / nPageWidthInPixels;
            int nZoomH = (100 * H1) / nPageHeightInPixels;


            if (nZoomW > 400) nZoomW = 400;
            if (nZoomW < 10) nZoomW = 10;
            if (nZoomH < 10) nZoomH = 10;
            if (nZoomH > 400) nZoomH = 400;

            if (c == 1) return nZoomW;
            return nZoomH;

        }


        public void Zooming()
        {
            // Zooming 

            if (ZoomFactor == -20) { textControl1.ZoomFactor = detectzoom(1); }
            else
            {
                if (ZoomFactor == -10) { textControl1.ZoomFactor = detectzoom(2); }
                else
                {
                    textControl1.ZoomFactor = ZoomFactor;
                }
            }

            CodexDocumentStatusBar.Panels["Zoom"].Text = textControl1.ZoomFactor + "%";
            ultraTrackBar1.Value = textControl1.ZoomFactor;
        }


        // Main Zooming
        public void modify_zoomfactor(int zoom)
        {
            ZoomFactor = zoom; Zooming();
        }

        private void modify_zoomfactor()
        {
            Zooming();
        }


        private void View_zoomfactor()
        {
            CodexDocumentStatusBar.Panels["Zoom"].Text = textControl1.ZoomFactor + "%";
            ultraTrackBar1.Value = textControl1.ZoomFactor;

        }


        #endregion Zooming

        #region Change Position

        private void X_UpdateStatusBar()
        {
            int allpages = textControl1.Pages;
            int currentpage = textControl1.InputPosition.Page;

            string ss = "სექცია " + textControl1.InputPosition.Section.ToString() + "/" + textControl1.Sections.Count.ToString();

            string s1 = "გვერდი  " + currentpage.ToString() + ":  " + currentpage.ToString() + "/" + allpages.ToString();
            CodexDocumentStatusBar.Panels["Pages"].Text = s1;
            int dline = textControl1.InputPosition.Line;
            int dpos = textControl1.InputPosition.Column;
            s1 = "სტრ. " + dline.ToString() + " პოზ. " + dpos.ToString();
            CodexDocumentStatusBar.Panels["Section"].Text = ss;            
            CodexDocumentStatusBar.Panels["Currsor"].Text = s1;
            CodexDocumentStatusBar.Panels["Caption"].Text = ultraTextEditor1.Text;
        }


        private void textControl1_InputPositionChanged(object sender, EventArgs e)
        {
            X_UpdateStatusBar();
            isDocAtrChanged = true;
        }

        #endregion Change Position

        #region Find in Text

        #region ToolBars
 
       
        private void ultraTextEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CodexR4.KeyBoard.Layout.U[e.KeyChar];
        }


        #endregion ToolBars

        #region Codex
        // Codex Searching
        int codexfindpostion = 0;
        bool iscodexfff = false;
   
        public void ultraButton1_Click(object sender, EventArgs e)
        {
            string str = CodexInText.Text.Trim();
            if (Codex_DocEncoding.Trim().ToUpper() == "UNICODE") str = CodexInText.Text.Trim();
            if (CodexSerachInCheck.Checked == false) codexfindpostion = textControl1.Find(str, codexfindpostion + 1, TXTextControl.FindOptions.NoMessageBox | TXTextControl.FindOptions.MatchCase);
            else codexfindpostion = textControl1.Find(str, codexfindpostion, TXTextControl.FindOptions.NoMessageBox | TXTextControl.FindOptions.MatchCase | TXTextControl.FindOptions.Reverse);
            if (codexfindpostion == -1)
            {
                if (iscodexfff == true) ILG.Windows.Forms.ILGMessageBox.Show("ტექსტში '" + CodexInText.Text.Trim() + "' მეტი არ მოიძებნა ");
                else ILG.Windows.Forms.ILGMessageBox.Show("ტექსტში '" + CodexInText.Text.Trim() + "' არ მოიძებნა ");
                iscodexfff = false;
            }
            else iscodexfff = true;


        }
        public void CodexInText_TextChanged(object sender, EventArgs e)
        {
            codexfindpostion = textControl1.InputPosition.TextPosition;
            if (CodexInText.Text == "") codexfindpostion = 0;
            iscodexfff = false;

        }

        public void CodexInText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ultraButton1_Click(null, null);
        }


        public void CodexSerachInCheck_CheckedChanged(object sender, EventArgs e)
        {
            //codexfindpostion = 0;
            iscodexfff = false;
        }


        #endregion Codex


   
  
   
        #endregion Find in Text

        #region Headers

        public void HeaderAttributes()
        {
            textControl1.SectionFormatDialog(1);
        }

        public void SwitchBetweenHeaderAndFooter()
        {
            if (m_ActiveHeaderFooter != null)
            {
                if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.Header)
                    textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Activate();
                else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.Footer)
                    textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Activate();
                else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.FirstPageHeader)
                    textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).Activate();
                else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.FirstPageFooter)
                    textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader).Activate();
            }
        }

        public void GoToFirstPage()
        {
            if (m_ActiveHeaderFooter != null)
            {
                if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.Header)
                    textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader).Activate();
                else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.Footer)
                    textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).Activate();
            }
        }

        public void GoToDefault()
        {
            if (m_ActiveHeaderFooter != null)
            {
                if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.FirstPageHeader)
                    textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Activate();
                else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.FirstPageFooter)
                    textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Activate();
            }
        }

        #endregion Headers


        
        private void ChangeViewF()
        {
            switch (DefaultDocumentFormat)
            {
                case 0 :
                        // Change to WORD
                        this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
                        // Disable Ribonns
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup1"].Visible = true;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup2"].Visible = true;
                        //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup3"].Visible = true;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup4"].Visible = true;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup5"].Visible = true;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup6"].Visible = true;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup8"].Visible = false;

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

                    
                        CodexDocumentStatusBar.Panels["Section"].Visible = true;
                        CodexDocumentStatusBar.Panels["Pages"].Visible = true;
                        CodexDocumentStatusBar.Panels["Currsor"].Visible = true;
                        CodexDocumentStatusBar.Panels["Caption"].Visible = true;
                        CodexDocumentStatusBar.Panels["HeaderFooter"].Visible = true;
                        CodexDocumentStatusBar.Panels["WebLayout"].Visible = true;
                        CodexDocumentStatusBar.Panels["PageLayout"].Visible = true;
                        CodexDocumentStatusBar.Panels["Zoom"].Visible = true;
                        CodexDocumentStatusBar.Panels["ZoomProg"].Visible = true;
        
                        textControl1.Focus();
                        break;
                case 1 :

                        // Change to WORD
                        this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[1];
                        // Disable Ribonns
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup1"].Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup2"].Visible = false;
                        //this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup3"].Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup4"].Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup5"].Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup6"].Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["RText"].Groups["ribbonGroup8"].Visible = true;

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

                        CodexDocumentStatusBar.Panels["Section"].Visible = false;
                        CodexDocumentStatusBar.Panels["Pages"].Visible = false;
                        CodexDocumentStatusBar.Panels["Currsor"].Visible = false;
                        CodexDocumentStatusBar.Panels["Caption"].Visible = true;
                        CodexDocumentStatusBar.Panels["HeaderFooter"].Visible = false;
                        CodexDocumentStatusBar.Panels["WebLayout"].Visible = false;
                        CodexDocumentStatusBar.Panels["PageLayout"].Visible = false;
                        CodexDocumentStatusBar.Panels["Zoom"].Visible = false;
                        CodexDocumentStatusBar.Panels["ZoomProg"].Visible = false;
        


                    
                    break;
                           
            }
        }

        #endregion Document Operation

        private void button23_Click(object sender, EventArgs e)
        {
            LookUps f1 = new LookUps();
            f1.ultraButton6_Click(null, null);// T_Refresh.PerformClick();// Click(null, null);
            f1.ShowDialog();
        }

        private void DocumentAddEdit_Load(object sender, EventArgs e)
        {
            this.textControl1.ButtonBar = this.buttonBar1;
            textControl1.RulerBar = rulerBar1;
            textControl1.VerticalRulerBar = rulerBar2;
            textControl1.Focus();
            Zooming();
            textControl1.Focus();
            X_UpdateStatusBar();
            textControl1.Focus();

            LoadTables();
            DisplayTables();
            Dt = DateTime.Now;

            this.Left = 0;
            this.Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - this.CodexDocumentStatusBar.Height;

            this.Category_Mandatory_Label.Visible = Properties.Settings.Default.UseCategoryAsMandatory;
            this.Status_Mandatory_Label.Visible = Properties.Settings.Default.UseStatusAsMandatory;
            this.Number_Mandatory_Label.Visible = Properties.Settings.Default.UseNumberAsManadatory;

            DoResize();

        }

        private void ultraToolbarsManager1_BeforeRibbonTabSelected(object sender, Infragistics.Win.UltraWinToolbars.BeforeRibbonTabSelectedEventArgs e)
        {
                //bool f = false;
                switch (e.Tab.Key.ToString())
                {
                    case "RText": this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs[0]; DoResize(); textControl1.Focus();  break;
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
            LookUps tb = new LookUps();
            
            tb.ultraButton1_Click(null, null); // Authors
            tb.ultraButton6_Click(null, null); // Types
            tb.S_Refresh_Click(null, null); // Subject
            tb.ST_Refresh_Click(null, null); // Status
            tb.C_Refresh_Click(null, null);// Category
            tb.W_Refresh_Click(null, null);//Word
            tb.SetTab(i);
            tb.ShowDialog();
            
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
                    OpenDocument();
                    break;

                case "OpenR2":    // ButtonTool
                    OpenDocumentR2();
                    break;

                case "Save":    // ButtonTool
                    SaveDocument();
                    break;

                case "Copy":    // ButtonTool
                    if (textControl1.CanCopy == true) textControl1.Copy();
                    break;

                case "Paste":    // ButtonTool
                    if (textControl1.CanPaste == true) textControl1.Paste();
                    break;

                case "Cut":    // ButtonTool
                    if (textControl1.CanCopy == true)   textControl1.Cut();
                    break;

                case "PCopy":    // ButtonTool
                    if (textControl1.CanCopy == true) textControl1.Copy();
                    break;

                case "PCut":    // ButtonTool
                    if (textControl1.CanCopy == true) textControl1.Cut();
                    break;

                case "PPaste":    // ButtonTool
                    if (textControl1.CanPaste == true) textControl1.Paste();
                    break;

                case "PasteImage" :
                    if (textControl1.CanPaste == true) textControl1.Paste(TXTextControl.ClipboardFormat.Image);
                    break;

                case "PasteHTML":
                    if (textControl1.CanPaste == true) textControl1.Paste(TXTextControl.ClipboardFormat.HTMLFormat);
                    break;

                case "PasteText":
                    if (textControl1.CanPaste == true) textControl1.Paste(TXTextControl.ClipboardFormat.PlainText);
                    break;

                case "PasteRTF":
                    if (textControl1.CanPaste == true) textControl1.Paste(TXTextControl.ClipboardFormat.RichTextFormat);
                    break;

                case "PasteTX":
                    if (textControl1.CanPaste == true) textControl1.Paste(TXTextControl.ClipboardFormat.TXTextControlFormat);
                    break;

                case "PasteTXImage":
                    if (textControl1.CanPaste == true) textControl1.Paste(TXTextControl.ClipboardFormat.TXTextControlImage);
                    break;

                case "PasteTextBox":
                    if (textControl1.CanPaste == true) textControl1.Paste(TXTextControl.ClipboardFormat.TXTextControlTextframe);
                    break;


                case "PInsertTable":    // ButtonTool
                    frmInsertTable InsertTableDialog = new frmInsertTable();
                    InsertTableDialog.tx = textControl1;
                    InsertTableDialog.ShowDialog();

                    break;

                case "InsertTable":    // ButtonTool
                    frmInsertTable InsertTableDialog2 = new frmInsertTable();
                    InsertTableDialog2.tx = textControl1;
                    InsertTableDialog2.ShowDialog();

                    break;


                case "PColumnLeft":    // ButtonTool
                    textControl1.Tables.GetItem().Columns.Add(TXTextControl.TableAddPosition.Before); 
                    break;
                
                case "PInsertColumntRight":    // ButtonTool
                    textControl1.Tables.GetItem().Columns.Add(TXTextControl.TableAddPosition.After);
                    break;

                case "PRowAbove":    // ButtonTool
                    textControl1.Tables.GetItem().Rows.Add(TXTextControl.TableAddPosition.Before, 1);
                    break;

                case "PRowBelow":    // ButtonTool
                    textControl1.Tables.GetItem().Rows.Add(TXTextControl.TableAddPosition.After, 1);
                    break;


                case "PGridLines":    // ButtonTool
                    textControl1.Tables.GridLines = !textControl1.Tables.GridLines;
                    break;



                case "PDelTable":    // ButtonTool
                    textControl1.Tables.Remove();
                    break;

                case "PDelColumn":    // ButtonTool
                    textControl1.Tables.GetItem().Columns.Remove();
                    break;

                case "PDelRow":    // ButtonTool
                    textControl1.Tables.GetItem().Rows.Remove();
                    break;

                case "InsertPicute":    // ButtonTool
                    TXTextControl.Image NewImage = new TXTextControl.Image();
                    textControl1.Images.Add(NewImage, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.ImageInsertionMode.DisplaceText);
                    break;


                case "PSplitAbove":    // ButtonTool
                    textControl1.Tables.GetItem().Split(TXTextControl.TableAddPosition.Before);
                    break;

                case "PSplitBelow":    // ButtonTool
                    textControl1.Tables.GetItem().Split(TXTextControl.TableAddPosition.After);
                    break;



                case "PSelectTable":    // ButtonTool
                    textControl1.Tables.GetItem().Select();
                    break;

                case "PSelectColumn":    // ButtonTool
                    textControl1.Tables.GetItem().Cells.GetItem().Select();
                    break;

                case "PSelectRow":    // ButtonTool
                    textControl1.Tables.GetItem().Rows.GetItem().Select();
                    break;



                case "SellectAll":    // ButtonTool
                    textControl1.SelectAll();

                    break;


                case "InsertTextBox" :
                    if (ILG.Windows.Forms.ILGMessageBox.Show("ტექსტ ბლოკის ჩასმა ? ","",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)       
                    {
                       Size TextFrameSize = new Size(2000, 1000);
                       TXTextControl.TextFrame NewTextFrame = new TXTextControl.TextFrame(TextFrameSize);
                       textControl1.TextFrames.Add(NewTextFrame, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.TextFrameInsertionMode.DisplaceCompleteLines);
                    }
                    break;

                case "TextBoxFormating":
                    try
                    {
                        textControl1.TextFrameAttributesDialog();
                    }
                    catch
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ ტექსტ ბლოკი (TextBox)");
                    }
                    break;
            
                case "TabFormating" :
                    textControl1.TabDialog();
                    break;

                case "ImageFormating" :
                    try
                    {
                        textControl1.ImageAttributesDialog();
                    }
                    catch
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ სურათი");
                    }
                    break;

                case "CollumnFormat":    // ButtonTool
                    try
                    {
                        textControl1.SectionFormatDialog(2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Codex 2007 DS");
                    }
                    break;

                case "DocumentFormatMenu":
                    try
                    {
                        textControl1.SectionFormatDialog(0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Codex 2007 DS");
                    }
                    break;

                case "FormatHeaderFooter" :
                    try
                    {
                        textControl1.SectionFormatDialog(1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Codex 2007 DS");
                    }
                    break;

                case "PHeaderFooterFormat":    // ButtonTool
                    try
                    {
                        textControl1.SectionFormatDialog(1);
                    }
                    catch (Exception ex)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show(ex.Message, "Codex 2007 DS");
                    } 
                    break;

                case "PPickFormat":    // ButtonTool
                    try
                    {
                        textControl1.ImageAttributesDialog();
                    }
                    catch
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ სურათი");
                    }
                    break;

                case "TextColor":    // ButtonTool
                    ColorDialog ColorDialog1 = new ColorDialog();
                    ColorDialog1.ShowDialog();
                    textControl1.Selection.ForeColor = ColorDialog1.Color;
                    break;

                case "TextBackGroundColor":    // ButtonTool
                    ColorDialog ColorDialog2 = new ColorDialog();
                    ColorDialog2.ShowDialog();
                    textControl1.Selection.TextBackColor = ColorDialog2.Color;
                    break;

                case "DocumentBackground":    // ButtonTool
                    ColorDialog ColorDialog3 = new ColorDialog();
                    ColorDialog3.ShowDialog();
                    textControl1.BackColor = ColorDialog3.Color;
                    break;


                case "DocFormat":    // ButtonTool
                        textControl1.SectionFormatDialog(0);
                       //PageSetup ps = new PageSetup();
                       //ps.ShowDialog(this.textControl1);
                    break;

                case "DocParagraph":    // ButtonTool
                    textControl1.ParagraphFormatDialog();
                    break;

                case "FontFormating":    // ButtonTool
                    textControl1.FontDialog();
                    break;

                case "FormatStyles":    // ButtonTool
                    textControl1.FormattingStylesDialog();
                    break;

                case "FormatList":    // ButtonTool
                    textControl1.ListFormatDialog();
                    break;

                case "FormatTable":    // ButtonTool
                    try
                    {
                        this.textControl1.TableFormatDialog();
                    }
                    catch
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ ცხრილი");
                    }
                    break;

                case "HeaderFooter":    // ButtonTool
                    try
                    {
                        TXTextControl.HeaderFooter Header;

                        // Insert headers and footers if the document does not yet contain them
                        if (textControl1.HeadersAndFooters.Count == 0)
                            textControl1.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.All);
                        textControl1.HeaderFooterActivationStyle = TXTextControl.HeaderFooterActivationStyle.ActivateClick;
                        //textControl1.HeadersAndFooters.Styles = TXTextControl.HeaderFooterStyles.ActivateClick;

                        // Activate first page header. If there is no first page header, try normal header
                        Header = textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader);
                        if (Header == null)
                            Header = textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header);

                        if (Header != null)
                            Header.Activate();
                    }
                    catch (Exception ex)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show(ex.Message, "არ ხერხდება კოლონტიტულის ფორმირება");
                    }

                    break;

                case "Undo":    // ButtonTool
                    if (textControl1.CanUndo == true) textControl1.Undo();
                    break;

                case "Redo":    // ButtonTool
                    if (textControl1.CanRedo == true) textControl1.Redo();
                    break;

                case "FIND":    // ButtonTool
                    bool gg = CodexDocumentSearchTab.Visible;
                    gg = !gg;
                    CodexDocumentSearchTab.Visible = gg;
                    CodexDocumentSearchTab.Enabled = gg;
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

                case "InsertBreak" :
                    
                    
                    frmInsertBreak frmInsertBreak = new frmInsertBreak();

                    frmInsertBreak.tx = textControl1;
                    frmInsertBreak.ShowDialog();
            
                    break;

                #endregion Documents

                #region Attribute Tables
                case "AuthorDialog":    // ButtonTool
                      CallTableBefore();
                      CallTables(0);
                      LoadTables();
                      DisplayTables();
                      CallTableAfter();
                    break;

                case "TypeDialog":    // ButtonTool
                    CallTableBefore();
                    CallTables(1);
                    LoadTables();
                    DisplayTables();
                    CallTableAfter();
                    break;

                case "SubjectDialog":    // ButtonTool
                    CallTableBefore();
                    CallTables(2);
                    LoadTables();
                    DisplayTables();
                    CallTableAfter();
                    break;

                case "CategoryDialog":    // ButtonTool
                    CallTableBefore();
                    CallTables(3);
                    LoadTables();
                    DisplayTables();
                    CallTableAfter();
                    break;

                case "StatusDialog":    // ButtonTool
                    CallTableBefore();
                    CallTables(4);
                    LoadTables();
                    DisplayTables();
                    CallTableAfter();
                    break;

                case "KeyWordDialog":    // ButtonTool
                    CallTableBefore();
                    CallTables(5);
                    LoadTables();
                    DisplayTables();
                    CallTableAfter();
                    break;

                case "DatabaseRefresh" :
                     CallTableBefore();
                     LoadTables();
                     DisplayTables();
                     CallTableAfter();

                    break;

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

                case "DDNewDocument":    // ButtonTool
                        DocumentAddEdit dd = new DocumentAddEdit();
                        dd.FormMain = this.FormMain;
                        dd.Show();
                        dd.NewDocumentMode();
                break;

                case "DDSaveNew":    // ButtonTool
                        DOSaveDocument();
                    break;

                case "DDSaveAsNew":    // ButtonTool
                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ჩაწერა როგორც ახალის ?", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ჩაწერა როგორც ახალის ? დაადასტურეთ ", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                                        System.Windows.Forms.MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

                    DOSaveDocument();
                    break;

                case "DDSaveChanges":    // ButtonTool
                    DOEditDocument();
                    break;

                
                case "DDDeleteDocument":    // ButtonTool
                    if (License.IsDeleteAlowed() == true) DODELDocument();
                    break;
                case "Close": Close(); break;

                case "RemoveSections" :
                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტიდან ყველა სექციის ამოღება \n" +
                                                             "სექციების ამოღებამ შეიძლება დააზიანოს დოკუმენტის ფორმატირება \n" +
                                                             "დაარწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტიდან ყველა სექციის ამოღება \n" +
                                                             "დაადასტურეთ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                    RemoveAllSections();
                    break;
                case "FormatSections":
                    textControl1.SectionFormatDialog(0);
                    break;


                case "AttachmentSave":
                    SaveAttachment();
                    break;

                
            }

        }

        #region PopUp
        private void BeforePopUp()
        {

            
            ultraToolbarsManager1.Tools["PPickFormat"].SharedProps.Enabled = (textControl1.Images.GetItem() != null);
            
            // Headers and footers are not available in the Standard version. Accessing them  
            // would throw an exception if this sample program is used with a Standard version
            // of Text Control.
            try
            {
                //(ultraToolbarsManager1.Tools["HeaderFooter"] as Infragistics.Win.UltraWinToolbars.ButtonTool).Enabled = !(textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) == null) || !(textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) == null);
                ultraToolbarsManager1.Tools["PHeaderFooterFormat"].SharedProps.Enabled = !(textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) == null) || !(textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) == null);
            }
            catch { }

            // Tables

            TXTextControl.Table ThisTable = textControl1.Tables.GetItem();

            ultraToolbarsManager1.Tools["FormatTable"].SharedProps.Enabled = (ThisTable != null);

            //ხცრილი გაყოფა
            if (ThisTable != null)
                ultraToolbarsManager1.Tools["ხცრილი გაყოფა"].SharedProps.Enabled = ThisTable.CanSplit;
            else
                ultraToolbarsManager1.Tools["ხცრილი გაყოფა"].SharedProps.Enabled = false;



            // ჩასმები

            ultraToolbarsManager1.Tools["PInsertTable"].SharedProps.Enabled = textControl1.Tables.CanAdd;

            
            TXTextControl.Table TableAtInputPosition = textControl1.Tables.GetItem();
            if (TableAtInputPosition == null)
            {
                ultraToolbarsManager1.Tools["PColumnLeft"].SharedProps.Enabled = false;
                ultraToolbarsManager1.Tools["PInsertColumntRight"].SharedProps.Enabled = false;
                ultraToolbarsManager1.Tools["PRowAbove"].SharedProps.Enabled = false;
                ultraToolbarsManager1.Tools["PRowBelow"].SharedProps.Enabled = false;
            }
            else
            {
                ultraToolbarsManager1.Tools["PColumnLeft"].SharedProps.Enabled  = TableAtInputPosition.Columns.CanAdd;
                ultraToolbarsManager1.Tools["PInsertColumntRight"].SharedProps.Enabled  = TableAtInputPosition.Columns.CanAdd;
                ultraToolbarsManager1.Tools["PRowAbove"].SharedProps.Enabled = TableAtInputPosition.Rows.CanAdd;
                ultraToolbarsManager1.Tools["PRowBelow"].SharedProps.Enabled = TableAtInputPosition.Rows.CanAdd;
            }


             //TXTextControl.Table 
                TableAtInputPosition = textControl1.Tables.GetItem();

            if (TableAtInputPosition == null)
            {
                ultraToolbarsManager1.Tools["PDelTable"].SharedProps.Enabled = false;
                ultraToolbarsManager1.Tools["PDelColumn"].SharedProps.Enabled = false;
                ultraToolbarsManager1.Tools["PDelRow"].SharedProps.Enabled = false;
            }
            else
            {
                ultraToolbarsManager1.Tools["PDelTable"].SharedProps.Enabled = TableAtInputPosition.Columns.CanRemove;
                ultraToolbarsManager1.Tools["PDelColumn"].SharedProps.Enabled = TableAtInputPosition.Columns.CanRemove;
                ultraToolbarsManager1.Tools["PDelRow"].SharedProps.Enabled = TableAtInputPosition.Rows.CanRemove;
            }



            //TXTextControl.Table 
                TableAtInputPosition = null;
            TXTextControl.TableRow RowAtInputPosition = null;
            TXTextControl.TableCell CellAtInputPosition = null;

            TableAtInputPosition = textControl1.Tables.GetItem();
            if (TableAtInputPosition != null)
            {
                RowAtInputPosition = TableAtInputPosition.Rows.GetItem();
                CellAtInputPosition = TableAtInputPosition.Cells.GetItem();
            }

            ultraToolbarsManager1.Tools["PSelectTable"].SharedProps.Enabled = (TableAtInputPosition != null);
            ultraToolbarsManager1.Tools["PSelectRow"].SharedProps.Enabled = (RowAtInputPosition != null);
            ultraToolbarsManager1.Tools["PSelectColumn"].SharedProps.Enabled = (CellAtInputPosition != null);

        }
        #endregion PopUp

        private void RemoveAllSections()
        {
            TXTextControl.SectionCollection.SectionEnumerator sectionEnum = textControl1.Sections.GetEnumerator();
            int sectionCounter = textControl1.Sections.Count;

            sectionEnum.Reset();
            sectionEnum.MoveNext();
            for (int i = 0; i < sectionCounter; i++)
            {
                TXTextControl.Section curSection = (TXTextControl.Section)sectionEnum.Current;

                if (curSection.Number == 1)
                {
                    sectionEnum.MoveNext();
                    continue;
                }

                textControl1.Selection.Start = curSection.Start - 2;
                textControl1.Selection.Length = 1;
                textControl1.Selection.Text = "";
            }

            this.textControl1.PageMargins.Top = ILG.Codex.Codex2007.Properties.Settings.Default.DocumentPageMarginTop;
            this.textControl1.PageMargins.Bottom = ILG.Codex.Codex2007.Properties.Settings.Default.DocumentPageMarginBottom;
            this.textControl1.PageMargins.Left = ILG.Codex.Codex2007.Properties.Settings.Default.DocumentPageMarginLeft;
            this.textControl1.PageMargins.Right = ILG.Codex.Codex2007.Properties.Settings.Default.DocumentPageMarginRight;

            this.textControl1.PageSize = new TXTextControl.PageSize(Properties.Settings.Default.DocumentPageWidth,
                                                                    Properties.Settings.Default.DocumentPageHeight);
            
        }


        private void DoResize()
        {
            Zooming();
            CCategory.DisplayLayout.Bands[0].Override.DefaultColWidth = CCategory.Width;
            CSbject.DisplayLayout.Bands[0].Override.DefaultColWidth = CSbject.Width;
            CWords.DisplayLayout.Bands[0].Override.DefaultColWidth = CWords.Width;
        }
  
        private void DocumentAddEdit_Resize(object sender, EventArgs e)
        {
            // Panelss();
            DoResize();

        }

        private void DocumentAddEdit_Activated(object sender, EventArgs e)
        {
            if (this.ultraTabControl1.ActiveTab == this.ultraTabControl1.Tabs[0])
            {
                //MessageBox.Show("G");

                Zooming();
                textControl1.Focus();
                X_UpdateStatusBar();
                ViewLayout(XViewLayout);
                ChangeViewF();
            }
        }

        #region KeyPress

        private void ultraTextEditor1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
            e.KeyChar = CodexR4.KeyBoard.Layout.U[e.KeyChar];
            //X_UpdateStatusBar();
            //this.Text = ultraTextEditor1.Text;
        }

        private void ultraTextEditor1_KeyUp(object sender, KeyEventArgs e)
        {
            X_UpdateStatusBar();
            this.Text = ultraTextEditor1.Text;
        }

        private void ultraTextEditor5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = CodexR4.KeyBoard.Layout.U[e.KeyChar];
        }

        private void ultraTextEditor6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = ILG.Codex.CodexR4.KeyBoard.Layout.U[e.KeyChar];
        }

        private void ELinkCaption_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = ILG.Codex.CodexR4.KeyBoard.Layout.U[e.KeyChar];
        }

        private void textControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = ILG.Codex.CodexR4.KeyBoard.Layout.U[e.KeyChar];
        }

        #endregion KeyPress


        private void ultraTabControl1_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            if (this.ultraTabControl1.ActiveTab == this.ultraTabControl1.Tabs[0])
            {
                // Show status Items
                CodexDocumentStatusBar.Panels[0].Visible = true;
                CodexDocumentStatusBar.Panels[1].Visible = true;
                CodexDocumentStatusBar.Panels[2].Visible = true;
                CodexDocumentStatusBar.Panels[3].Visible = true;
                CodexDocumentStatusBar.Panels[4].Visible = true;
                CodexDocumentStatusBar.Panels[5].Visible = true;
                CodexDocumentStatusBar.Panels[6].Visible = true;
                CodexDocumentStatusBar.Panels[7].Visible = true;
                CodexDocumentStatusBar.Panels[8].Visible = true;
                
                textControl1.Focus();
      
            }
            else
            {
                // Hide Status Items
                
                CodexDocumentStatusBar.Panels[0].Visible = false;
                CodexDocumentStatusBar.Panels[1].Visible = false;
                CodexDocumentStatusBar.Panels[2].Visible = false;
                //CodexDocumentStatusBar.Panels[3].Visible = false;
                CodexDocumentStatusBar.Panels[4].Visible = false;
                CodexDocumentStatusBar.Panels[5].Visible = false;
                CodexDocumentStatusBar.Panels[6].Visible = false;
                CodexDocumentStatusBar.Panels[7].Visible = false;
                CodexDocumentStatusBar.Panels[8].Visible = false;
                
            }
        }

        private void ultraToolbarsManager1_BeforeApplicationMenuDropDown(object sender, CancelEventArgs e)
        {
            BeforePopUp();
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            BeforePopUp();
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
                                       global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
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
            String Fields = "C_ID,C_Caption, C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Category,C_Addtional,C_Group,C_DocFormat";
            string strsql = "Select " + Fields + " FROM CODEXDS_DDOCS WHERE C_ID = " + ID.ToString() + " ";
            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
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

        private void CLinkID_ValueChanged(object sender, EventArgs e)
        {

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
            string strsql = "Select C_ID FROM CODEXDS_DDOCS WHERE C_ID = " + ID.ToString() + " ";
            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
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
                    System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = false;
                    
                }
                else
                {
                    e.Cancel = true;
                    DOSaveDocument();

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
            TXTextControl.SaveSettings s = new TXTextControl.SaveSettings();
            s.PageMargins = textControl1.PageMargins;
            s.PageSize = textControl1.PageSize;
            s.ImageSaveMode = TXTextControl.ImageSaveMode.SaveAsData;

            textControl1.Save(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\D.RTF", TXTextControl.StreamType.RichTextFormat,s);
            
            textControl1.Save(out @resultText, TXTextControl.StringStreamType.PlainText);//.PlainText,s);

            String ZipFileName = Properties.Settings.Default.TemporaryDir + @"\Doc2.Zip";
            String RTFFileName = Properties.Settings.Default.TemporaryDir + @"\D.RTF";
            CodexZip.Zip(ZipFileName, "D.RTF", RTFFileName);

            //C1.C1Zip.C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Create(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\Doc2.Zip");
            //zf.Entries.Add(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\D.RTF", "D.RTF");
            //zf.Close();

            FileStream fs = new FileStream(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\Doc2.Zip", FileMode.Open, FileAccess.Read);
            resultdoc = new byte[(int)fs.Length];
            fs.Read(resultdoc, 0, (int)fs.Length);
            fs.Close();
            File.Delete(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\Doc2.Zip");
            if (File.Exists(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\D.RTF") == true) File.Delete(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\D.RTF");

        }


        private void CrearePDFDocument()
        {
            // Version 1.0 When PDF File Save Full Text Search Not Worked


            String ZipFileName = Properties.Settings.Default.TemporaryDir + @"\Doc3.Zip";
            CodexZip.Zip(ZipFileName, "D.PDF", SellectedPDF);

            //C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Create(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\Doc3.Zip");

            //zf.Entries.Add(SellectedPDF, "D.PDF");
            //zf.Close();

            FileStream fs = new FileStream(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\Doc3.Zip", FileMode.Open, FileAccess.Read);
            resultdoc = new byte[(int)fs.Length];
            fs.Read(resultdoc, 0, (int)fs.Length);
            fs.Close();
            File.Delete(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\Doc3.Zip");
            if (File.Exists(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\D.PDF") == true) File.Delete(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\D.RTF");

        }


        private void CreareLinks()
        {

            String ZipFileName = Properties.Settings.Default.TemporaryDir + @"\LINKS.ZIP";
            String FileName_Links = Properties.Settings.Default.TemporaryDir + @"\Links.XML";
            String FileName_LinksSchema = Properties.Settings.Default.TemporaryDir + @"\LinksSchema.XML";

            DLinks.WriteXml(FileName_Links);
            DLinks.WriteXmlSchema(FileName_LinksSchema);

            CodexZip.Zip(ZipFileName, "Links.XML", FileName_Links);
            CodexZip.Zip_Add(ZipFileName, "LinksSchema.XML", FileName_LinksSchema);

            //C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Create(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\LINKS.ZIP");

            //zf.Entries.Add(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\Links.XML", "Links.XML");
            //zf.Entries.Add(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\LinksSchema.XML", "LinksSchema.XML");

            //zf.Close();


            File.Delete(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\Links.XML");
            File.Delete(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\LinksSchema.XML");

            FileStream fs = new FileStream(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\LINKS.ZIP", FileMode.Open, FileAccess.Read);
            linkresult = new byte[fs.Length];
            fs.Read(linkresult, 0, (int)fs.Length);
            fs.Close();
            File.Delete(ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir + @"\LINKS.ZIP");
        }
        #endregion Preparation


        private bool CheckTheDocumentExistance()
        {
            String DocumentCaption = ultraTextEditor1.Text.Trim();

            int DocumentAuthor = (int)CAuthor.SelectedRow.Cells["A_ID"].Value;

            int DocumentType = (int)CType.SelectedRow.Cells["T_ID"].Value;

            int DocumentNumber = 0;
            if (Int32.TryParse(ultraTextEditor2.Text, out DocumentNumber) == false) DocumentNumber = -1;

            DateTime DocumentDate = Dt;
            // = Dt;
            int DocumentStatus = -1;
            if (CStatus.SelectedRow == null) DocumentStatus = 0;
            else DocumentStatus = (int)CStatus.SelectedRow.Cells["C_ID"].Value;

            #region Build SQL

            String SQL = $"Select COUNT(C_ID) FROM [CodexDS_DDOCS] ";
            String Condition = $"WHERE C_AUTHOR = {DocumentAuthor}  AND C_TYPE = {DocumentType} AND C_Number = {DocumentNumber}";

            String Condition_Date = " AND ( ( C_Date >= " +
            "CONVERT(DATETIME, '" + Dt.Year.ToString() + @"-" + Dt.Month.ToString("00") + @"-" + Dt.Day.ToString("00") + "T00:00:00.000' ,126) )" +
            " and " +
            "( C_Date <= " +
            "CONVERT(DATETIME, '" + Dt.Year.ToString() + @"-" + Dt.Month.ToString("00") + @"-" + Dt.Day.ToString("00") + "T23:59:59.997' ,126) )" + " ) ";

            String ConditionStatus = $" AND C_STATUS = {DocumentStatus}  ";
            String ConditionCaption = $" AND LTRIM(RTRIM(C_CAPTION)) LIKE N'%{DocumentCaption}%'";

            if (Properties.Settings.Default.CheckSaveConditionWithDocumentStatus == false) ConditionStatus = "";
            if (Properties.Settings.Default.CheckSaveConditionWithDocumentCaption == false) ConditionCaption = "";

            String FullSQLStatment = SQL + Condition + Condition_Date + ConditionStatus + ConditionCaption;
            #endregion 

            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand(FullSQLStatment, cn);
                int Qunatity = (int)cm.ExecuteScalar();
                if (Qunatity != 0) return true;
            }

                return false;
        }


        private void DOSaveDocument()
        {
            #region Checks
            if (ultraTextEditor1.Text.Trim() == "")
            { ILGMessageBox.Show("დოკუმენტის სათაური არ შეიძლება იყოს ცარიელი"); return; }
            
            if (CAuthor.SelectedRow == null)
            { ILGMessageBox.Show("მიმღები ორგანო არის აუცილებელი ველი"); return; }

            if ((int)CAuthor.SelectedRow.Cells["A_ID"].Value == 0)
            { ILGMessageBox.Show("მიმღები ორგანო არის აუცილებელი ველი"); return; }

            
            if (CType.SelectedRow == null)
            { ILGMessageBox.Show("დოკუმენტის სახე არის აუცილებელი ველი"); return; }

            if ((int)CType.SelectedRow.Cells["T_ID"].Value == 0)
            { ILGMessageBox.Show("დოკუმენტის სახე არის აუცილებელი ველი"); return; }

            if (CSbject.SelectedRow == null)
            { ILGMessageBox.Show("დოკუმენტის თემატიკა არის აუცილებელი ველი"); return; }

            if ((int)CSbject.SelectedRow.Cells["S_ID"].Value == 0)
            { ILGMessageBox.Show("დოკუმენტის თემატიკა არის აუცილებელი ველი"); return; }

            if (Dt == null)
            { ILGMessageBox.Show("დოკუმენტის თარიღი არის აუცილებელი ველი"); return; }

            // Check if Document Empty
            if (( DefaultDocumentFormat == 0) &&  (this.textControl1.Text.ToString().Trim() == ""))
            { ILG.Windows.Forms.ILGMessageBox.Show("RTF დოკუმენტის ტექსტი ცარილელია"); return; }

           
            if (( DefaultDocumentFormat == 1) && (this.SellectedPDF.Trim() == "") )
                { ILG.Windows.Forms.ILGMessageBox.Show("PDF დოკუმენტის ტექსტი ცარილელია"); return; }
            #endregion Checks

            #region Additinal Checks
            if (Properties.Settings.Default.UseCategoryAsMandatory == true)
            {
                if (CCategory.SelectedRow == null)
                { ILGMessageBox.Show("დოკუმენტის კატეგორია არის აუცილებელი ველი"); return; }

                if ((int)CCategory.SelectedRow.Cells["C_ID"].Value == 0)
                { ILGMessageBox.Show("დოკუმენტის კატეგორია არის აუცილებელი ველი"); return; }
            }

            if (Properties.Settings.Default.UseStatusAsMandatory == true)
            {
                if (CStatus.SelectedRow == null)
                { ILGMessageBox.Show("დოკუმენტის სტატუსი არის აუცილებელი ველი"); return; }

                if ((int)CStatus.SelectedRow.Cells["C_ID"].Value == 0)
                { ILGMessageBox.Show("დოკუმენტის სტატუსი არის აუცილებელი ველი"); return; }
            }

            if (Properties.Settings.Default.UseNumberAsManadatory == true)
            {
                if ((ultraTextEditor2.Text.Trim() == "") )
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
                if (textControl1.Sections.Count > 1)
                {
                    if (ILGMessageBox.Show("დოკუმენტი შეიცავს სექციებს, ის არ გამოჩნდება კარგად კოდექს დოკუმენტების არქივის ადრეულ ვერსიებში \nგავაგრძელო ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }
            }



            // Confirm to Save Document
            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის ჩაწერა", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;


            if (Properties.Settings.Default.CheckSaveNewConditionOnDublicate == true)
            {
                if (CheckTheDocumentExistance() == true)
                {
                    if (Properties.Settings.Default.CheckSaveWarnOnly == true)
                    {
                        if (ILGMessageBox.Show("დოკუმენტი ესეთი პარამეტრებით უკვე არსებობს ბაზაში გავაგრძელო ?", "", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }
                    else
                    {
                        ILGMessageBox.Show("დოკუმენტი ესეთი პარამეტრებით უკვე არსებობს ბაზაში" + System.Environment.NewLine + "მისი ჩაწერა არ მოხდება", "", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                        return;
                    }
                }

            }




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
            #endregion Prepare Parameters
            // Save Procedure
            #region Create Command "InsertDoc"
            String InsertCommand = "INSERT INTO [dbo].[CodexDS_DDOCS] ([C_CAPTION], [C_AUTHOR], [C_Subject], [C_TYPE], [C_WORDS], [C_NUMBER], [C_NumberStr], [C_DATE], [C_LASTEDIT], [C_ENTERDATE], [C_TEXT], [C_LINK], [C_STATUS], [C_DocFormat], [C_DocEncoding], [C_DocText], [C_Coments], [C_Version], [C_Presentation], [C_Original], [C_Attach], [C_Group], [C_Category], [C_Addtional], [C_Picture]) VALUES (@C_CAPTION, @C_AUTHOR, @C_Subject, @C_TYPE, @C_WORDS, @C_NUMBER, @C_NumberStr, @C_DATE, @C_LASTEDIT, @C_ENTERDATE, @C_TEXT, @C_LINK, @C_STATUS, @C_DocFormat, @C_DocEncoding, @C_DocText, @C_Coments, @C_Version, @C_Presentation, @C_Original, @C_Attach, @C_Group, @C_Category, @C_Addtional, @C_Picture) " +
                                   "SELECT C_ID, C_CAPTION, C_AUTHOR, C_Subject, C_TYPE, C_WORDS, C_NUMBER, C_NumberStr, C_DATE, C_LASTEDIT, C_ENTERDATE, C_TEXT, C_LINK, C_STATUS, C_DocFormat, C_DocEncoding, C_DocText, C_Coments, C_Version, C_Presentation, C_Original, C_Attach, C_Group, C_Category, C_Addtional, C_Picture FROM CodexDS_DDOCS WHERE (C_ID = SCOPE_IDENTITY())";
            SqlCommand InsertDoc = new SqlCommand(InsertCommand);
            InsertDoc.CommandText = InsertCommand;
            InsertDoc.CommandType = CommandType.Text;

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

                if (ILG.Codex.Codex2007.Properties.Settings.Default.DocumentEncogingPolicy == true)
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
                
                InsertDoc.Connection = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
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
                scoount.Connection = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
                scoount.Connection.Open();
                Quantity = (int)scoount.ExecuteScalar();
                scoount.Connection.Close();



                string dtstr1 = "CONVERT(DATETIME, '" + DateTime.Now.Year.ToString() + @"-" + DateTime.Now.Month.ToString("00") + @"-" + DateTime.Now.Day.ToString("00") + "T00:00:00.000' ,126) ";
                string StrInfo = "UPDATE CodexDS2007 SET [C_Version] = 50,  [C_Date] = " + dtstr1 + ", [C_CodexDSDocs] = "+Quantity.ToString() +", " +
                             "[C_CodexDate] = " + dtstr1 + ",  [C_CodexDSVersion] = 65 WHERE [C_Version] = 50 ";
                SqlCommand sinfo = new SqlCommand(StrInfo);
                 
                sinfo.Connection = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
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
            (this.FormMain as Form1).LoadTables();
            (this.FormMain as Form1).DisplayParametersLimited();

            if (ILG.Codex.Codex2007.Properties.Settings.Default.DSAfterSaveNewDoc == false)
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

        private void DOEditDocument()
        {
            #region Checks
            
            if (ultraTextEditor1.Text.Trim() == "")
            { ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სათაური არ შეიძლება იყოს ცარიელი"); return; }

            if (CAuthor.SelectedRow == null)
            { ILG.Windows.Forms.ILGMessageBox.Show("მიმღები ორგანო არის აუცილებელი ველი"); return; }

            if ((int)CAuthor.SelectedRow.Cells["A_ID"].Value == 0)
            { ILG.Windows.Forms.ILGMessageBox.Show("მიმღები ორგანო არის აუცილებელი ველი"); return; }


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
            if ((DefaultDocumentFormat == 0) && (this.textControl1.Text.ToString().Trim() == ""))
            { ILG.Windows.Forms.ILGMessageBox.Show("RTF დოკუმენტის ტექსტი ცარილელია"); return; }


            if ((DefaultDocumentFormat == 1) && (this.SellectedPDF.Trim() == ""))
            { ILG.Windows.Forms.ILGMessageBox.Show("PDF დოკუმენტის ტექსტი ცარილელია"); return; }
            #endregion Checks

            #region Additinal Checks
            if (Properties.Settings.Default.UseCategoryAsMandatory == true)
            {
                if (CCategory.SelectedRow == null)
                { ILGMessageBox.Show("დოკუმენტის კატეგორია არის აუცილებელი ველი"); return; }

                if ((int)CCategory.SelectedRow.Cells["C_ID"].Value == 0)
                { ILGMessageBox.Show("დოკუმენტის კატეგორია არის აუცილებელი ველი"); return; }
            }

            if (Properties.Settings.Default.UseStatusAsMandatory == true)
            {
                if (CStatus.SelectedRow == null)
                { ILGMessageBox.Show("დოკუმენტის სტატუსი არის აუცილებელი ველი"); return; }

                if ((int)CStatus.SelectedRow.Cells["C_ID"].Value == 0)
                { ILGMessageBox.Show("დოკუმენტის სტატუსი არის აუცილებელი ველი"); return; }
            }

            if (Properties.Settings.Default.UseNumberAsManadatory == true)
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

            if (ILG.Codex.Codex2007.Properties.Settings.Default.AskToRemoveSections == true)
            {
                if (textControl1.Sections.Count > 1)
                {
                    if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი შეიცავს სექციებს, ის არ გამოჩნდება კარგად კოდექს დოკუმენტების არქივის ადრეულ ვერსიებში \nგავაგრძელო ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }
            }

            // Confirm to Save Document
            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის შეცვლა", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;

            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის შეცვლა დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;



            if (Properties.Settings.Default.CheckSaveChangeConditionOnDublicate == true)
            {
                if (CheckTheDocumentExistance() == true)
                {
                    if (Properties.Settings.Default.CheckSaveWarnOnly == true)
                    {
                        if (ILGMessageBox.Show("დოკუმენტი ესეთი პარამეტრებით უკვე არსებობს ბაზაში გავაგრძელო ?", "", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }
                    else
                    {
                        ILGMessageBox.Show("დოკუმენტი ესეთი პარამეტრებით უკვე არსებობს ბაზაში" + System.Environment.NewLine + "მისი ჩაწერა არ მოხდება", "", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                        return;
                    }
                }
                
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
            #endregion Prepare Parameters
            // Save Procedure
            #region Create Command "UpdateDoc"
            String UpdateCommand = "UPDATE [dbo].[CodexDS_DDOCS] SET [C_CAPTION] = @C_CAPTION, [C_AUTHOR] = @C_AUTHOR" +
                ", [C_Subject] = @C_Subject, [C_TYPE] = @C_TYPE, [C_WORDS] = @C_WORDS, [C_NUMBER]" +
                " = @C_NUMBER, [C_NumberStr] = @C_NumberStr, [C_DATE] = @C_DATE, [C_LASTEDIT] = @" +
                "C_LASTEDIT, [C_TEXT] = @C_TEXT, [C_LINK] = @C_LINK" +
                ", [C_STATUS] = @C_STATUS, [C_DocFormat] = @C_DocFormat, [C_DocEncoding] = @C_Doc" +
                "Encoding, [C_DocText] = @C_DocText, [C_Coments] = @C_Coments, [C_Version] = @C_V" +
                "ersion, [C_Presentation] = @C_Presentation, [C_Original] = @C_Original, [C_Attac" +
                "h] = @C_Attach, [C_Group] = @C_Group, [C_Category] = @C_Category, [C_Addtional] " +
                "= @C_Addtional, [C_Picture] = @C_Picture WHERE ([C_ID] = @Original_C_ID)        " ;

            SqlCommand UpdateDoc = new SqlCommand(UpdateCommand);
            UpdateDoc.CommandText = UpdateCommand;
            UpdateDoc.CommandType = CommandType.Text;

            UpdateDoc.Parameters.Add(new SqlParameter("@Original_C_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "C_ID", DataRowVersion.Current, false, null, "", "", ""));
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
                UpdateDoc.Parameters["@Original_C_ID"].Value = IID;
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

                if (ILG.Codex.Codex2007.Properties.Settings.Default.DocumentEncogingPolicy == true)
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
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის ჩაწერა Error #A10002", ex.Message.ToString());
                return;
            }
            #endregion Fill Rarameters

            #region SaveDoc
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                UpdateDoc.Connection = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
                UpdateDoc.Connection.Open();
                UpdateDoc.ExecuteNonQuery();
                UpdateDoc.Connection.Close();
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
                scoount.Connection = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
                scoount.Connection.Open();
                Quantity = (int)scoount.ExecuteScalar();
                scoount.Connection.Close();



                string dtstr1 = "CONVERT(DATETIME, '" + DateTime.Now.Year.ToString() + @"-" + DateTime.Now.Month.ToString("00") + @"-" + DateTime.Now.Day.ToString("00") + "T00:00:00.000' ,126) ";
                string StrInfo = "UPDATE CodexDS2007 SET [C_Version] = 50,  [C_Date] = " + dtstr1 + ", [C_CodexDSDocs] = " + Quantity.ToString() + ", " +
                             "[C_CodexDate] = " + dtstr1 + ",  [C_CodexDSVersion] = 65 WHERE [C_Version] = 50 ";
                SqlCommand sinfo = new SqlCommand(StrInfo);

                sinfo.Connection = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
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
            (this.FormMain as Form1).LoadTables();
            (this.FormMain as Form1).DisplayParametersLimited();

            if (ILG.Codex.Codex2007.Properties.Settings.Default.DSAfterSaveNewDoc == false)
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

        public void DODELDocument()
        {
          

           
            if (License.IsDeleteAlowed() == false)
            {
                    ILG.Windows.Forms.ILGMessageBox.Show("თქვენ არ გაქვთ უფლება წაშალოთ დოკუმენტი");
                    return;
            }
            // Confirm to Save Document
            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის წაშლა \nწაშლილი დოკუმენტი აღარ აღდგება", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Error,MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის წაშლა დაადასტურეთ \nწაშლილი დოკუმენტი აღარ აღდგება", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის წაშლა დაადასტურეთ ხელმეორედ \nწაშლილი დოკუმენტი აღარ აღდგება", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

            if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის წაშლა დაადასტურეთ კიდევ ერთხელ \nწაშლილი დოკუმენტი აღარ აღდგება", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

            // DELETE Procedure
            #region Create Command "DeleteDoc"
            String DeleteCommand = "DELETE [dbo].[CodexDS_DDOCS] WHERE ([C_ID] = @Original_C_ID) ";

            SqlCommand DeleteDoc = new SqlCommand(DeleteCommand);
            DeleteDoc.CommandText = DeleteCommand;
            DeleteDoc.CommandType = CommandType.Text;

            DeleteDoc.Parameters.Add(new SqlParameter("@Original_C_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "C_ID", DataRowVersion.Current, false, null, "", "", ""));

            #endregion Create Command "DeleteDoc"

            #region Fill Rarameters
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                #region FillParameters
                DeleteDoc.Parameters["@Original_C_ID"].Value = IID;
                #endregion FillParameters
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის წაშლა Error #A10002", ex.Message.ToString());
                return;
            }
            #endregion Fill Rarameters

            #region DeleteDoc
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                DeleteDoc.Connection = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
                DeleteDoc.Connection.Open();
                DeleteDoc.ExecuteNonQuery();
                DeleteDoc.Connection.Close();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის წაშლა Error #A10003", ex.Message.ToString());
                return;
            }
            #endregion DELDoc

            #region UpdateInformation
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                int Quantity = 0;
                // Update information Tables
                SqlCommand scoount = new SqlCommand("SELECT COUNT(C_ID) FROM CodexDS_DDocs");
                scoount.Connection = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
                scoount.Connection.Open();
                Quantity = (int)scoount.ExecuteScalar();
                scoount.Connection.Close();



                string dtstr1 = "CONVERT(DATETIME, '" + DateTime.Now.Year.ToString() + @"-" + DateTime.Now.Month.ToString("00") + @"-" + DateTime.Now.Day.ToString("00") + "T00:00:00.000' ,126) ";
                string StrInfo = "UPDATE CodexDS2007 SET [C_Version] = 50,  [C_Date] = " + dtstr1 + ", [C_CodexDSDocs] = " + Quantity.ToString() + ", " +
                             "[C_CodexDate] = " + dtstr1 + ",  [C_CodexDSVersion] = 65 WHERE [C_Version] = 50 ";
                SqlCommand sinfo = new SqlCommand(StrInfo);

                sinfo.Connection = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
                sinfo.Connection.Open();
                sinfo.ExecuteNonQuery();
                sinfo.Clone();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დოკუმენტის წაშლა Error #A10004", ex.Message.ToString());
                return;
            }


            #endregion UpdateInformation
  
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტი წაშლილია");
            // Detemine Close or not after Saving
            (this.FormMain as Form1).LoadTables();
            (this.FormMain as Form1).DisplayParametersLimited();

            //if (ILG.Codex.Codex2007.Properties.Settings.Default.DSAfterSaveNewDoc == false)
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

        private void EWord_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        

        public void ViewLayout(int ViewLayout)
        {

            if (ViewLayout == 0)
            {
                textControl1.ViewMode = TXTextControl.ViewMode.PageView;
                XViewLayout = 0;
                this.CodexDocumentStatusBar.ButtonClick -= new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.CodexDocumentStatusBar_ButtonClick);
                try
                {
                    CodexDocumentStatusBar.Panels["PageLayout"].Checked = true;
                    CodexDocumentStatusBar.Panels["WebLayout"].Checked = false;
                }
                finally
                {
                    this.CodexDocumentStatusBar.ButtonClick += new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.CodexDocumentStatusBar_ButtonClick);
                }

            }
            else
            {
                textControl1.ViewMode = TXTextControl.ViewMode.Normal;
                XViewLayout = 1;
                this.CodexDocumentStatusBar.ButtonClick -= new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.CodexDocumentStatusBar_ButtonClick);
                try
                {
                    CodexDocumentStatusBar.Panels["PageLayout"].Checked = false;
                    CodexDocumentStatusBar.Panels["WebLayout"].Checked = true;
                }
                finally
                {
                    this.CodexDocumentStatusBar.ButtonClick += new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.CodexDocumentStatusBar_ButtonClick);
                }
            }
        }


        private void CodexDocumentStatusBar_ButtonClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelEventArgs e)
        {
            if (e.Panel.Key.ToUpper() == "Zoom".ToUpper())
            {
                ZoomingDialog zd1 = new ZoomingDialog();
                zd1.CurrentZoom = this.textControl1.ZoomFactor;
                if (zd1.ShowDialog() == DialogResult.OK)
                {

                    ZoomFactor = zd1.CurrentZoom;
                    Zooming();
                    return;
                }
            }


            if (e.Panel.Key.ToUpper() == "Section".ToUpper())
            {
                ultraToolbarsManager1.ShowPopup("SectionManager"); 
                return;
            }


            if (e.Panel.Key.ToUpper() == "WebLayout".ToUpper())
            {
                ViewLayout(1);
                return;
            }

            

            if (e.Panel.Key.ToUpper() == "PageLayout".ToUpper())
            {
                ViewLayout(0);
                return;
                
            }

            if (e.Panel.Key.ToUpper() == "HeaderFooter".ToUpper())
            {
                try
                {
                    TXTextControl.HeaderFooter Header;

                    // Insert headers and footers if the document does not yet contain them
                    if (textControl1.HeadersAndFooters.Count == 0)
                        textControl1.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.All);
                    //textControl1.HeadersAndFooters.Styles = TXTextControl.HeaderFooterStyles.ActivateClick;
                    textControl1.HeaderFooterActivationStyle = TXTextControl.HeaderFooterActivationStyle.ActivateClick;

                    // Activate first page header. If there is no first page header, try normal header
                    Header = textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader);
                    if (Header == null)
                        Header = textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header);

                    if (Header != null)
                        Header.Activate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "არ ხერხდება კოლონტიტულის ფორმირება");
                }

            }
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {

            FormMain.ID_Finder.ShowDialog();
            if (FormMain.ID_Finder.Return_ID != -1)
            {
                CLinkID.Text = FormMain.ID_Finder.Return_ID.ToString();
            }
        }

        private void EDate1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DocumentAddEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            axAcroPDF1.Dispose();
            axAcroPDF1 = null;

        }

        private void ultraLabel13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}