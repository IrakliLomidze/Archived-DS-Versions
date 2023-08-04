using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TXTextControl;
using System.Runtime.InteropServices;
using ILG.Codex.CodexR4;
using System.Collections.Generic;
using ILG.Windows.Forms;
using ILG.Codex.CodexR4.CodexSettings;

namespace ILG.Codex.CodexR4
{
    public partial class Form_Test_Document : Form
    {
        public Form1 MainForm;
        
        public string ZipFileName;
        public bool HasAttachmen;
        
        string CodexDocumentCaption;
        DataSet CodexLink;

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

           // [DllImport("shell32.dll")]
           // public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
            [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SHGetFileInfo([MarshalAs(UnmanagedType.LPWStr)]string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        }

        #endregion ICON



        public Form_Test_Document()
        {
            InitializeComponent();
        }

    
        

        private void textControl_Codex_InputPositionChanged(object sender, EventArgs e)
        {
            //MainForm.textControl_Codex_InputPositionChanged(sender, e);
        }

        private void CodexLinkBox_DocumentClick(object sender, ILG.Codex.CodexDSLinkListBox.CodexDSLinkListEventArgs e)
        {
            //MainForm.CodexLinkBox_DocumentClick(sender, e);
        }




        #region X
        // ref string DocFileName, ref string LinkFileName, ref string LinkSchemaFileName
        const int MAX_PATH = 260;

        public int CodexOpenTestDocument(int ID )
        {
            string DocFileName;
            string LinkFileName;
            string LinkSchemaFileName;

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            // Define Document Call Statment
            String Fields = "C_ID,C_Caption,C_TEXT,C_Link, C_Author,C_Subject,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding,C_NumberStr,C_Status,C_Coments,C_Category,C_Addtional,C_Group,C_DocFormat,C_Attach";
            string strsql = "Select " + Fields + " FROM CODEXDS_DDOCS WHERE C_ID = " + ID.ToString() + " ";
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

            int Codex_DocumentFormat = (int)dst.Tables[0].Rows[0]["C_DocFormat"];

            byte[] doc = (byte[])dst.Tables[0].Rows[0]["C_Text"];

            #region  Codex Temp Files
            String U1 = DateTime.Now.Ticks.ToString();
            
            string CodexDocTempFilename = DirectoryConfiguration.CodexTemporaryDirectory + "\\Codex_" + ID.ToString() + U1;

            while (System.IO.File.Exists(CodexDocTempFilename) == true)
            {
                U1 = DateTime.Now.Ticks.ToString();
                CodexDocTempFilename = DirectoryConfiguration.CodexTemporaryDirectory + "\\Codex_" + ID.ToString() + U1;
            }

            U1 = DateTime.Now.Ticks.ToString();
            string CodexLinkTempFilename = DirectoryConfiguration.CodexTemporaryDirectory + "\\CodexLink_" + ID.ToString() + U1;

            while (System.IO.File.Exists(CodexLinkTempFilename) == true)
            {
                U1 = DateTime.Now.Ticks.ToString();
                CodexLinkTempFilename = DirectoryConfiguration.CodexTemporaryDirectory + "\\CodexLink_" + ID.ToString() + U1;
            }


            #endregion Codex Temp Files

            #region SaveBlobs
            FileStream fs = new FileStream(CodexDocTempFilename + ".tmpD", FileMode.Create, FileAccess.Write);
            fs.Write(doc, 0, doc.Length);
            fs.Close();


            doc = (byte[])dst.Tables[0].Rows[0]["C_LINK"];
            fs = new FileStream(CodexLinkTempFilename + ".tmpL", FileMode.Create, FileAccess.Write);
            fs.Write(doc, 0, doc.Length);
            fs.Close();


            if (dst.Tables[0].Rows[0]["C_Attach"] != DBNull.Value)
            {
                doc = (byte[])dst.Tables[0].Rows[0]["C_Attach"];
                fs = new FileStream(CodexLinkTempFilename + ".tmpA", FileMode.Create, FileAccess.Write);
                fs.Write(doc, 0, doc.Length);
                fs.Close();
                HasAttachmen = true;
                ZipFileName = CodexLinkTempFilename + ".tmpA";
            }
            else { HasAttachmen = false; }


            // UnZip Document there
            //C1.C1Zip.C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Open(CodexDocTempFilename + ".tmpD");
            String ZipFileName2 = CodexDocTempFilename + ".tmpD";

            if (Codex_DocumentFormat == 0)
            {
                CodexZip.UnZip(ZipFileName2, "D.RTF", CodexDocTempFilename + ".RTF");
                //zf.Entries.Extract("D.RTF", CodexDocTempFilename + ".RTF");
            }
            else
            {
                CodexZip.UnZip(ZipFileName2, "D.PDF", CodexDocTempFilename + ".PDF");
                //zf.Entries.Extract("D.PDF", CodexDocTempFilename + ".PDF");
            }
            //zf.Close();

            // UnZip Links there

            ZipFileName2 = CodexLinkTempFilename + ".tmpL";
            CodexZip.UnZip(ZipFileName2, "Links.XML", CodexDocTempFilename + "_L.XML");
            CodexZip.UnZip(ZipFileName2, "LinksSchema.XML", CodexDocTempFilename + "_LS.XML");

            //C1.C1Zip.C1ZipFile zf2 = new C1.C1Zip.C1ZipFile();
            //zf2.Open(CodexLinkTempFilename + ".tmpL");
            //zf2.Entries.Extract("Links.XML", CodexDocTempFilename + "_L.XML");
            //zf2.Entries.Extract("LinksSchema.XML", CodexDocTempFilename + "_LS.XML");
            //zf2.Close();



            File.Delete(CodexDocTempFilename + ".tmpD");
            File.Delete(CodexLinkTempFilename + ".tmpL");
            //File.Delete(CodexDocTempFilename + ".zip");


            // Document Caption
            if (Codex_DocumentFormat == 0)
                DocFileName = CodexDocTempFilename + ".rtf";
            else
                DocFileName = CodexDocTempFilename + ".pdf";

            LinkFileName = CodexDocTempFilename + "_L.XML";
            LinkSchemaFileName = CodexDocTempFilename + "_LS.XML";
            #endregion SaveBlobs

            //CodexDocumentID = ID; // Document ID
            //Codex_DocEncoding = "UNICODE"; //dst.Tables[0].Rows[0]["C_DocEncoding"].ToString();

            #region Document Caption Generation
            // Calcucate Document Caption 
            MainForm.LockupTables.Tables["CodexDS_DAuthor"].PrimaryKey = new DataColumn[] { MainForm.LockupTables.Tables["CodexDS_DAuthor"].Columns["A_ID"] };
            MainForm.LockupTables.Tables["CodexDS_DType"].PrimaryKey = new DataColumn[] { MainForm.LockupTables.Tables["CodexDS_DType"].Columns["T_ID"] };
            MainForm.LockupTables.Tables["CodexDS_DStatus"].PrimaryKey = new DataColumn[] { MainForm.LockupTables.Tables["CodexDS_DStatus"].Columns["C_ID"] };
            MainForm.LockupTables.Tables["CodexDS_DCategory"].PrimaryKey = new DataColumn[] { MainForm.LockupTables.Tables["CodexDS_DCategory"].Columns["C_ID"] };


            StringBuilder Strauthor = new StringBuilder("0");
            StringBuilder Strtype = new StringBuilder("0");
            StringBuilder Strstatus = new StringBuilder("0");
            StringBuilder StrCategory = new StringBuilder("0");
            DataRow dr;


            Strauthor.Remove(0, Strauthor.Length);
            Strtype.Remove(0, Strtype.Length);
            Strstatus.Remove(0, Strstatus.Length);
            StrCategory.Remove(0, StrCategory.Length);


            dr = MainForm.LockupTables.Tables["CodexDS_DAuthor"].Rows.Find((int)dst.Tables[0].Rows[0]["C_Author"]);
            if (dr == null) Strauthor.Append(" "); else Strauthor.Append(@dr["A_Caption"].ToString().Trim());

            dr = MainForm.LockupTables.Tables["CodexDS_DType"].Rows.Find((int)dst.Tables[0].Rows[0]["C_Type"]);
            if (dr == null) Strtype.Append(" "); else Strtype.Append(@dr["T_Caption"].ToString().Trim());

            // New ITEMS
            dr = MainForm.LockupTables.Tables["CodexDs_DStatus"].Rows.Find((int)dst.Tables[0].Rows[0]["C_Status"]);

            if (dr == null) Strstatus.Append(" ");
            {
                if (dr["C_ID"].ToString().Trim() == "0") Strstatus.Append(" ");
                else Strstatus.Append(@dr["C_Caption"].ToString().Trim());
            }

            dr = MainForm.LockupTables.Tables["CodexDs_DCategory"].Rows.Find((int)dst.Tables[0].Rows[0]["C_Category"]);

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

            CodexDocumentCaption = @S;
            //Codex_DocumentTitle = dst.Tables[0].Rows[0]["C_Caption"].ToString();

            #endregion Document Caption Generation
            this.Cursor = System.Windows.Forms.Cursors.Default;





            // Second Part

            IntPtr hImgSmall; //the handle to the system image list
            //IntPtr hImgLarge; //the handle to the system image list
            //string fName; //  'the file name to get icon from
            SHFILEINFO shinfo = new SHFILEINFO();


            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            #region Load Document
            if (Codex_DocumentFormat == 0)
            {
                TXTextControl.LoadSettings LoadSettings = new TXTextControl.LoadSettings();
                textControl_Codex.Load(DocFileName, TXTextControl.StreamType.RichTextFormat,LoadSettings);
                textControl_Codex.PageSize = LoadSettings.PageSize; textControl_Codex.PageMargins = LoadSettings.PageMargins; 
                File.Delete(DocFileName);
                DocumentTab.SelectedTab = DocumentTab.Tabs[0];
            }
            else
            {
                axAcroPDF1.LoadFile(DocFileName);
                File.Delete(DocFileName);
                DocumentTab.SelectedTab = DocumentTab.Tabs[1];
            }

            #endregion Load Document

            #region Load Links
            CodexLink = new DataSet();
            CodexLink.ReadXmlSchema(LinkSchemaFileName);
            CodexLink.ReadXml(LinkFileName, System.Data.XmlReadMode.InferSchema);
            File.Delete(LinkFileName);


            CodexLinkBox.DataSource = CodexLink.Tables[0].Select("", "ORDER ASC");
            CodexLinkBox.Visited = MainForm.CodexVisited;
            CodexLinkBox.InitializeVarialbles(2);
            CodexLinkBox.FillGrid();

            #endregion LoadLinks



            #region Load Attachment
            if ((HasAttachmen == true) && (License.IsAttachmentShow() == true))
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
                //zf3.Close();
                ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[0];
                ultraTabControl1.Tabs[1].Enabled = true;
                ultraTabControl1.Tabs[1].Visible = true;

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
                ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[0];
                ultraTabControl1.Tabs[1].Enabled = false;
                ultraTabControl1.Tabs[1].Visible = false;

            }

            #endregion Attachment


            ZoomingCodex();
            textControl_Codex.Focus();
            //Codex_UpdateStatusBar();
            // CodexDocumentCaptionLabel.Text = "   " + CodexDocumentCaption;
            this.Text = CodexDocumentCaption;
           // this.CodexDocumentStatusBar.Panels[0].Text = CodexDocumentCaption;
            this.Text = "Test: " + CodexDocumentCaption;

            //codexfindpostion = 0;
            this.Cursor = System.Windows.Forms.Cursors.Default;



            return 0;
        }


        // Document Operation

        
        #endregion X



        #region Zooming


        static public int PixelsPerInch = -1;


        private int detectzoom(int c)
        {

            if (PixelsPerInch == -1) PixelsPerInch = 96;
            System.Drawing.Graphics g = this.CreateGraphics();
            PixelsPerInch = (int)Math.Round(g.DpiX);

            int PageViewMargin = PixelsPerInch * 567 / 1440;                 /* 567 Twips PageLfet */

            //int W1 = F_CGL_DOC.textControl_CGL.Width - SystemInformation.HorizontalScrollBarThumbWidth - PageViewMargin*2;
            int W1 = this.textControl_Codex.Width - PageViewMargin * 2;
            int H1 = textControl_Codex.Height;
            //int bottomGap = 400;

            int nPageWidthInPixels = (int)(textControl_Codex.PageSize.Width
                // - F_CGL_DOC.textControl_CGL.PageSize.PageMargins.Left - F_CGL_DOC.textControl_CGL.PageMargins.Right
                                       );
            int nPageHeightInPixels = (int)(textControl_Codex.PageSize.Height
                // - F_CGL_DOC.textControl_CGL.PageMargins.Top - F_CGL_DOC.textControl_CGL.PageMargins.Bottom + bottomGap) 
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



        public void ZoomingCodex()
        {
            // Zooming 

            textControl_Codex.ZoomFactor = detectzoom(1); 
            
        }



        #endregion Zooming

        private void ultraButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        int _id = -1;
        public void ShowModal(int id)
        {
            lock(this)
            {
               Show(); 
            }
            int r = CodexOpenTestDocument(_id);
            if (r != 0) _id = -1;
            if (_id != -1) Close();
        }

        private void Form_Test_Document_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}