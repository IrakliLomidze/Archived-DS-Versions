using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ILG.DS.Controls;
using ILG.DS.DSListBox.Properties;
using System.Runtime.Versioning;
using ILG.DS.Controls.DSList.Configuration;

namespace ILG.DS.Controls
{

    // Default ICON and Default Color is not implemented in this version

    [SupportedOSPlatform("windows")]
    public class DSListBoxEventArgs : System.EventArgs
    {
        public int _ID;
        public string _TCaption;
        public string _DCaption;

        public DSListBoxEventArgs(int ID, string TCaption, string DCaption)
        {
            this._ID = ID;
            this._TCaption = TCaption;
            this._DCaption = DCaption;
        }
    }

    public delegate void DSListBoxCallDocumentEventHandler(object sender, DSListBoxEventArgs e);
    public delegate void DSListBoxPreviewDocumentEventHandler(object sender);

    [SupportedOSPlatform("windows")]
    public partial class DSListBox : UserControl
    {


        public string Active_TCaption;
        public string Active_DCaption;
        public int Active_ID;

        public string Active_Preview;
        public int Active_DocStatus;
        public int Active_History;
        public int Active_DocType;



        public DataRow[] DataSource;
        public string IDField;
        public string DCaptionField;
        public string TCaptionField;
        public string StatusField;
        public string NField;
        public string PreviewField; 
        public DataTable Visited;
        public string ProgramName;
        public int callfrom;
        private bool UseConfidentialityStatus;


        //Bitmap image_Selection;
        Bitmap Image_DocumentWithLock;
        Bitmap Image_Lock;
        Bitmap Image_DocumentDefault;
        Bitmap Image_DocumentCodified;
        Bitmap image_Visited;

        //Bitmap image_AcroboatICONSmall;
        Bitmap image_WordIconSmall; // For Measurment

        Bitmap image_Icon;  // General Variable

        Bitmap image_Attach;

        Bitmap image_History;

        bool _ShowHistory = false;
        public bool Policy_VistiedLinksHiglitedInMagenta = false;

        //Bitmap image_Unknown;
        // A delegate type for hooking up change notifications.

        DSListConfiguration ListConfiguration;
        Form1 Instance;
        public String HighlightedText = "";


        private int m_DPI = 96; // Application's DPI (by default the VS Designer use 96 DPI)

        private Font Titlefont;
        private Font TitleNumberfont;
        private Font Captionfont;

        public bool IsPreviewFiled { set; get; } = true;

        public DSListBox()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, false);
            this.UpdateStyles();

            InitializeComponent();
            SetSegoeUI();

            m_DPI = DeviceDpi;

            Instance = new Form1();
        }

        
        public void SetSegoeUI()
        {
            Titlefont = new Font("Segoe UI", 10f, FontStyle.Regular);
            Captionfont = new Font("Segoe UI", 10F, FontStyle.Regular);
            TitleNumberfont = new Font("Segoe UI", 10F, FontStyle.Bold);
        }


        public event DSListBoxCallDocumentEventHandler DocumentClick;
        public event DSListBoxPreviewDocumentEventHandler PreviewDocument;

        protected virtual void OnDocumentClick(DSListBoxEventArgs e)
         {
             if (DocumentClick != null) DocumentClick(this, e);
         }

        protected virtual void OnDocumentPreview()
        {
            if (PreviewDocument != null) PreviewDocument(this);
        }


        private Image GetImageByIconIndex(int index)
        {
            Image result = Instance.IconIndex1.Image; // Default Image
                 
            switch (index)
            {
                case 1 : result = Instance.IconIndex1.Image; break;
                case 2 : result = Instance.IconIndex2.Image; break;
                case 3: result = Instance.IconIndex3.Image; break;
                case 4: result = Instance.IconIndex4.Image; break;
                case 5: result = Instance.IconIndex5.Image; break;
                case 6: result = Instance.IconIndex6.Image; break;
                case 7: result = Instance.IconIndex7.Image; break;
                case 8: result = Instance.IconIndex8.Image; break;
                case 9: result = Instance.IconIndex9.Image; break;
                case 10: result = Instance.IconIndex10.Image; break;

                case 11: result = Instance.IconIndex11.Image; break;
                case 12: result = Instance.IconIndex12.Image; break;
                case 13: result = Instance.IconIndex13.Image; break;
                case 14: result = Instance.IconIndex14.Image; break;
                case 15: result = Instance.IconIndex15.Image; break;
                case 16: result = Instance.IconIndex16.Image; break;
                case 17: result = Instance.IconIndex17.Image; break;
                case 18: result = Instance.IconIndex18.Image; break;
                case 19: result = Instance.IconIndex19.Image; break;
                case 20: result = Instance.IconIndex20.Image; break;

                case 21: result = Instance.IconIndex21.Image; break;
                case 22: result = Instance.IconIndex22.Image; break;
                case 23: result = Instance.IconIndex23.Image; break;
                case 24: result = Instance.IconIndex24.Image; break;
                case 25: result = Instance.IconIndex25.Image; break;
                case 26: result = Instance.IconIndex26.Image; break;
                case 27: result = Instance.IconIndex27.Image; break;
                case 28: result = Instance.IconIndex28.Image; break;
                case 29: result = Instance.IconIndex29.Image; break;
                case 30: result = Instance.IconIndex30.Image; break;

                case 31: result = Instance.IconIndex31.Image; break;
                case 32: result = Instance.IconIndex32.Image; break;
                case 33: result = Instance.IconIndex33.Image; break;
                case 34: result = Instance.IconIndex34.Image; break;
                case 35: result = Instance.IconIndex35.Image; break;
                case 36: result = Instance.IconIndex36.Image; break;
                case 37: result = Instance.IconIndex37.Image; break;
                case 38: result = Instance.IconIndex38.Image; break;
                case 39: result = Instance.IconIndex39.Image; break;
                case 40: result = Instance.IconIndex40.Image; break;

                case 41: result = Instance.IconIndex41.Image; break;
                case 42: result = Instance.IconIndex42.Image; break;
                case 43: result = Instance.IconIndex43.Image; break;
                case 44: result = Instance.IconIndex44.Image; break;
                case 45: result = Instance.IconIndex45.Image; break;
                case 46: result = Instance.IconIndex46.Image; break;
                case 47: result = Instance.IconIndex47.Image; break;
                case 48: result = Instance.IconIndex48.Image; break;
                case 49: result = Instance.IconIndex49.Image; break;
                case 50: result = Instance.IconIndex50.Image; break;

                case 51: result = Instance.IconIndex51.Image; break;
                case 52: result = Instance.IconIndex52.Image; break;
                case 53: result = Instance.IconIndex53.Image; break;
                case 54: result = Instance.IconIndex54.Image; break;
                case 55: result = Instance.IconIndex55.Image; break;
                case 56: result = Instance.IconIndex56.Image; break;
                case 57: result = Instance.IconIndex57.Image; break;
                case 58: result = Instance.IconIndex58.Image; break;
                case 59: result = Instance.IconIndex59.Image; break;
                case 60: result = Instance.IconIndex60.Image; break;
                case 61: result = Instance.IconIndex61.Image; break;

                default: result = Instance.IconIndex1.Image; break;
            }

            return result;
        }

        private Image GetByImageDocumentFormat(int index)
        {
            Image result = Instance.Word_Pic.Image; // Default Image
            switch(index)
            {
                case 0: result = Instance.Word_Pic.Image; break;
                case 1: result = Instance.Acro_Pic.Image; break;
                default: result = Instance.Picture_Unkown.Image; break;
            }
            return result;
        }

        private int GetIconIndexById(int id)
        {
            int result = 1; // default icon
            if (id == ListConfiguration.Id_config.ID_OriginalDocument ) result = ListConfiguration.IconIndex_config.IconIndexOfOriginalDocument;
            if (id == ListConfiguration.Id_config.ID_ArchivedDocument) result = ListConfiguration.IconIndex_config.IconIndexArchivedDocument;
            if (id == ListConfiguration.Id_config.ID_CodifiedDocument) result = ListConfiguration.IconIndex_config.IconIndexCodifiedDocument;
            if (id == ListConfiguration.Id_config.ID_Draft) result = ListConfiguration.IconIndex_config.IconIndexDraftDocument;
            if (id == ListConfiguration.Id_config.ID_ObsoleteDocument) result = ListConfiguration.IconIndex_config.IconIndexObsoleteDocument;
            if (id == ListConfiguration.Id_config.ID_Specified) result = ListConfiguration.IconIndex_config.IconIndexSpecifiedDocument;
            if (id == ListConfiguration.Id_config.ID_UnknowDocument) result = ListConfiguration.IconIndex_config.IconIndexUnknownDocument;
            
            return result;
        }


        private Color GetColorIndexById(int id)
        {
            Color result = Color.FromArgb(30, 57, 91); //0.4f; // default Color
            if (id == ListConfiguration.Id_config.ID_OriginalDocument) result = ListConfiguration.color_config.ColorOfOriginalDocument;
            if (id == ListConfiguration.Id_config.ID_ArchivedDocument) result = ListConfiguration.color_config.ColorOfArchivedDocument;
            if (id == ListConfiguration.Id_config.ID_CodifiedDocument) result = ListConfiguration.color_config.ColorOfCodifiedDocument;
            if (id == ListConfiguration.Id_config.ID_Draft) result = ListConfiguration.color_config.ColorOfDraftDocument;
            if (id == ListConfiguration.Id_config.ID_ObsoleteDocument) result = ListConfiguration.color_config.ColorOfObsoleteDocument;
            if (id == ListConfiguration.Id_config.ID_Specified) result = ListConfiguration.color_config.ColorOfSpecifiedDocument;
            if (id == ListConfiguration.Id_config.ID_UnknowDocument) result = ListConfiguration.color_config.ColorOfUnknownDocument;

            return result;
        }

        private Image GetImageForOrigianlDocument(int Status)
        {
            Image result = Instance.IconIndex1.Image; // Default Image
            if (ListConfiguration.NeedtoBeApplied == false)  return result;

            result = GetImageByIconIndex(GetIconIndexById(Status));
            return result;
        }

        private Color GetColorForTopTitle(int Status)
        {
            Color result = Color.FromArgb(30, 57, 91);  // Default Color
            if (ListConfiguration.NeedtoBeApplied == false) return result;

            result = GetColorIndexById(Status);
            return result;
        }


        public void Configure(DSListConfiguration configuration,bool ShowHistory, string IdFiledName = "C_ID")
        {
            ListConfiguration = configuration;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint , true);
            this.SetStyle(ControlStyles.ResizeRedraw,false);
            this.UpdateStyles();

            

            
            
            colorn = Color.Black;
            leftMargines = 8;
            topMargines = 10;
            distance = 12;
            Form1 f = new Form1();
            //image_Selection = new Bitmap(f.pictureBox_Selection.Image);//@"C:\1\1.bmp");
            Image_DocumentWithLock = new Bitmap(f.pictureBox_DocumentLock.Image);
            Image_DocumentDefault = new Bitmap(f.IconIndex1.Image);
            Image_DocumentCodified = new Bitmap(f.pictureBox_Document_Codified.Image);
            image_Visited = new Bitmap(f.Picture_Icon_Visited.Image);

            Image_Lock = new Bitmap(Instance.pictureBox_LockIcon.Image);
            image_WordIconSmall = new Bitmap(Instance.Word_Pic.Image);
            image_Attach = new Bitmap(Instance.Picture_Attachment_Icon.Image);

            image_History = new Bitmap(Instance.pictureBox_History.Image);

            DCaptionField = "C_Caption";
            TCaptionField = "TopCaption";
            StatusField   = "C_Group";
            PreviewField = "DocText";
            IDField = IdFiledName;
            UseConfidentialityStatus = true;
            
            LWithSize = listBox1.ClientSize.Width;

            _ShowHistory = ShowHistory;
        }

        // ---------------------------------
        Color colorn;
        int leftMargines;
        int topMargines;


        int distance;

        public List<int> _NewDocuments;

        int LWithSize;
        public void FillGrid(List<int> NewDocuments = null)
        {
            this.SuspendLayout();
            _NewDocuments = NewDocuments;   
            if (_NewDocuments == null) _NewDocuments = new List<int>();
            this.listBox1.BeginUpdate();
            this.LWithSize = listBox1.ClientSize.Width;
            this.listBox1.HorizontalExtent = this.LWithSize;
            this.listBox1.Enabled = false;
            this.listBox1.Items.Clear();

            for (int i = 0; i <= DataSource.Length - 1; i++)
               this.listBox1.Items.Add(i);
            this.listBox1.Enabled = true;

            this.listBox1.SelectedIndex = 0;
            this.listBox1.EndUpdate();
            this.ResumeLayout();
        }

        private bool IsNew(int i)
        {
            return _NewDocuments.Contains(i);  
        }


        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            Graphics gfx = e.Graphics;
            int number = e.Index + 1;
            
            string xcaption = @DataSource[e.Index][TCaptionField].ToString();
            string dtext = @DataSource[e.Index][DCaptionField].ToString();

            SizeF f1 = gfx.MeasureString(number.ToString() + ".", Titlefont);
            SizeF f11 = gfx.MeasureString(xcaption, Captionfont);

            Rectangle rect = new Rectangle(leftMargines + (int)f1.Width + 8 + image_WordIconSmall.Width + 4 + 2 + image_History.Width, topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8, e.ItemHeight);
            StringFormat stf = new StringFormat();
            stf.FormatFlags = StringFormatFlags.FitBlackBox;
            SizeF f2 = gfx.MeasureString(dtext, Titlefont, rect.Width, stf);
            int Temp = e.ItemWidth;
            if (f2.Width < (leftMargines + f1.Width + 8 + f11.Width)) Temp = leftMargines + (int)f1.Width + 8 + (int)f11.Width + 4;


            e.ItemHeight = topMargines + (int)f1.Height + distance + (int)f2.Height + 8 + 8+8;
        }





        private string GetConfidentialityStringByStatus(int Status)
        {
            string ConfidentialitystatusString = "";

            if (UseConfidentialityStatus == true)
            {
                switch (Status)
                {
                    case 0: ConfidentialitystatusString = ""; break;
                    case 1: ConfidentialitystatusString = " [კონფიდენციალური]"; break;
                    default: ConfidentialitystatusString = ""; break;
                }
            }
            return ConfidentialitystatusString;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            this.listBox1.SuspendLayout();
            int number = e.Index + 1;
            int confidentiality_status = (int)DataSource[e.Index][StatusField];
            string ConfidentialitystatusString = GetConfidentialityStringByStatus(confidentiality_status);

            string xcaption = DataSource[e.Index][TCaptionField].ToString() + ConfidentialitystatusString;//+ "  "+statusLine.ToString();
            string dtext = @DataSource[e.Index][DCaptionField].ToString();
            int ind = (int)DataSource[e.Index][IDField];
            bool DrawNewIcon = IsNew(ind);
            Bitmap new_Icon = Resources.place_red;
            image_Icon = new Bitmap(GetByImageDocumentFormat((int)DataSource[e.Index]["C_DocFormat"]));

            int hasattach = 0;

            if (DataSource[e.Index]["L_AttachmentSize"] == DBNull.Value) hasattach = 0;
            else
            {
                try
                {
                    hasattach = (int)DataSource[e.Index]["L_AttachmentSize"];
                }
                catch
                {
                    try
                    {
                        Int64 hasattach64 = 0;
                        hasattach64 = (Int64)DataSource[e.Index]["L_AttachmentSize"];
                        if (hasattach64 != 0) hasattach = 1;
                    }
                    catch
                    {
                        // Do not Detected
                        hasattach = 0;
                    }
                }

            }

            bool DrawHistoryIcon = false;
            if (_ShowHistory == true)
            {
                if (DataSource[e.Index]["C_ShowHistory"] != DBNull.Value)
                {
                    if ((int)DataSource[e.Index]["C_ShowHistory"] > 0)
                    {
                        DrawHistoryIcon = true;
                    }
                }
            }


            Brush TopColor = new SolidBrush(Color.FromArgb(30, 57, 91));


            int _DocumentStatus = (int)DataSource[e.Index]["C_Status"];
            Graphics gfx = e.Graphics;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                SolidBrush background = new SolidBrush(Color.FromArgb(234, 245, 239));
                Pen ItemBorder = new Pen(Color.FromArgb(34, 115, 70), 0.4f); // Overide bulu to green
                gfx.FillRectangle(background, e.Bounds.X + 3, e.Bounds.Y + 3, e.Bounds.Width - 5, e.Bounds.Height - 5);
                //gfx.DrawRectangle(ItemBorder, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 3, e.Bounds.Height - 3));
            }
            else
            {
                SolidBrush background = new SolidBrush(Color.White);
                gfx.FillRectangle(background, e.Bounds.X + 3, e.Bounds.Y + 3, e.Bounds.Width - 5, e.Bounds.Height - 5);
                gfx.FillRectangle(new SolidBrush(Color.FromArgb(214, 229, 245)), e.Bounds.X + 4, e.Bounds.Y + e.Bounds.Height - 1, e.Bounds.Width - 8, 1);
                gfx.FillRectangle(Brushes.LightGray, e.Bounds.X + 4, e.Bounds.Y + e.Bounds.Height - 1, e.Bounds.Width - 8, 1);

            }



            SizeF f1 = gfx.MeasureString(number.ToString() + ".", TitleNumberfont);
            if (DrawNewIcon == true)
            {
                gfx.DrawString(number.ToString() + ".", TitleNumberfont, Brushes.Black, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines - 6);
                SizeF p1 = gfx.MeasureString(number.ToString() + ".", TitleNumberfont);
                gfx.DrawString("*", TitleNumberfont, Brushes.Red, e.Bounds.X + leftMargines + p1.Width, e.Bounds.Y + topMargines - 6);
                f1 = gfx.MeasureString(number.ToString() + ".*", TitleNumberfont);
            }
            else
            {
                gfx.DrawString(number.ToString() + ".", TitleNumberfont, Brushes.Black, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines - 6);
            }


            Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_DocumentStatus));
            gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);

            int lockicon_width = 0;
            if (UseConfidentialityStatus == true)
            {
                if (confidentiality_status == 1)
                {
                    gfx.DrawImage(Image_Lock, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 8, e.Bounds.Y + topMargines - 6);
                    lockicon_width = Image_Lock.Width;
                }
            }

            Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_DocumentStatus));


            gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

            if (hasattach != 0)
                gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

            if (DrawHistoryIcon == true)
                gfx.DrawImage(image_History, e.Bounds.X + leftMargines + 2 + image_Icon.Width + 2 + image_Attach.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);


            gfx.DrawString(xcaption, Captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 2 + lockicon_width + 8, e.Bounds.Y + topMargines);


            SizeF f11 = gfx.MeasureString(xcaption, Captionfont);

            Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8 + image_WordIconSmall.Width + 4 + 2 + image_History.Width, e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8 - image_WordIconSmall.Width, this.ClientSize.Height - 4); //ZXZ2
            StringFormat stf = new StringFormat();
            stf.FormatFlags = StringFormatFlags.FitBlackBox;

            if (Visited.Rows.Contains(new object[] { ind }) == false)
            {
                gfx.DrawString(dtext, Titlefont, Brushes.Black, rect, stf);

            }
            else
            {
                gfx.DrawString(dtext, Titlefont, Brushes.Purple, rect, stf);
                gfx.DrawImage(image_Visited, e.Bounds.X + 8, e.Bounds.Y + topMargines + f1.Height - 6);
            }

            if (DrawNewIcon == true)
            {
                gfx.DrawImage(new_Icon, e.Bounds.X + 8, e.Bounds.Y + topMargines + f1.Height - 6);
            }

            //e.DrawFocusRectangle();
            this.listBox1.ResumeLayout();


        }


        private void DoVisited()
        {
            int id = (int)DataSource[this.listBox1.SelectedIndex][IDField]; ;
            if (Visited.Rows.Contains(new object[] { id }) == false)
                Visited.Rows.Add(new object[] { id });

            OnDocumentClick(new DSListBoxEventArgs(id,DataSource[this.listBox1.SelectedIndex][TCaptionField].ToString(),DataSource[this.listBox1.SelectedIndex][DCaptionField].ToString()));
            
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            DoVisited();
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) DoVisited();
        }



        #region Save List to File
        private string toRTFString(String Str)
        {
            StringBuilder st = new StringBuilder("");


            for (int i = 0; i <= Str.Length - 1; i++)
            {
                if (Convert.ToInt16(Str[i]) < 32) continue;

                if (Convert.ToInt16(Str[i]) > 255)
                {

                    st.Append(String.Format(@"\u{0}?", Convert.ToInt16(Str[i])));
                }
                else st.Append(String.Format(@"\'{0:x2}", Convert.ToInt16(Str[i])));
            }
            return st.ToString();

        }


        private String[] generetelistfile()
        {
            String[] str = new string[8 + DataSource.Length * 5 + 3];
            str[0] = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";
            str[1] = @"{\fonttbl";
            str[2] = @"{\f0\froman\fprq2\fcharset0 Sylfaen;}";
            str[3] = @"{\f1\fswiss\fcharset0 Arial;}}";
            str[4] = @"{\colortbl;\red0\green0\blue0;\red0\green64\blue128;\red0\green0\blue0;}";
            str[5] = @"{\*\generator Codex 2007 DS 2.0.0.0;}";
            str[6] = @"\deftab720\paperw11906\paperh16837\margl1440\margt1440\margr1440\margb1440\pard\cf1\f0\fs20\lang3079" + @toRTFString("მოძებნილი დოკუმენტების სია, რაოდენობა =  " + DataSource.Length) + @"\par";
            str[7] = @"\par";
            int j = 7 + 1;
            for (int i = 0; i < DataSource.Length; i++)
            {
                str[j] = @"\cf2\par";
                j++;
                str[j] = (i + 1).ToString() + ". " + @"\lang3079" + @toRTFString(DataSource[i][TCaptionField].ToString()) + @"\par";
                j++;
                str[j] = @"\par";
                j++;
                str[j] = @"\cf1" + @toRTFString(@DataSource[i][DCaptionField].ToString()) + @"\par";
                j++;
                str[j] = @"\par";
            }
            j++;
            str[j] = @"\tab\cf0\lang1033\f1\par";
            j++;
            str[j] = @"}";

            return str;


        }

        public void SaveToRTF()
        {

            Stream f;
            SaveFileDialog d = new SaveFileDialog();
            d.FileName = "DocumentsList";
            d.Filter = "Rich Text Format  (*.rtf)| *.rtf";
            d.Title = "Save Document List";
            string CodexDocuments = @Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            d.InitialDirectory = CodexDocuments;


            if (d.ShowDialog() == DialogResult.OK)
            {

                string s = System.IO.Path.GetExtension(d.FileName);

                string savepath = System.IO.Path.GetDirectoryName(d.FileName);
                if (savepath[savepath.Length - 1] != '\\') savepath = savepath + "\\";
                string savefilename = System.IO.Path.GetFileNameWithoutExtension(d.FileName);
                if (savefilename.ToLower() != "rtf") savefilename = savefilename + ".rtf";
                string savefullpath = savepath + savefilename;

                //if (File.Exists(savefullpath) == true)
                //{
                //    if (MessageBox.Show("ფაილი უკვე არსებობს გადავაწერო ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                //
                //}


                try
                {
                    f = new FileStream(savefullpath, FileMode.Create);
                    StreamWriter f1 = new StreamWriter(f);
                    string[] res = generetelistfile();
                    foreach (string r in res)
                    {
                        if (r != null) f1.WriteLine(r);
                    }
                    f1.Close();
                    f.Close();

                    ILGMessageBox.Show("სია ჩაწერილია");
                }
                catch
                {
                    ILGMessageBox.Show("არ ხერხდება სიის ჩაწერა");
                }




            }

        }

        public void SaveToRTF(string Filename)
        {
                    FileStream f = new FileStream(Filename, FileMode.Create);
                    StreamWriter f1 = new StreamWriter(f);
                    string[] res = generetelistfile();
                    foreach (string r in res)
                    {
                        if (r != null) f1.WriteLine(r);
                    }

                    f1.Close();
                    f.Close();
        }

        
    

        #endregion Save List to File

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Active_DCaption = @DataSource[this.listBox1.SelectedIndex][DCaptionField].ToString();
            Active_TCaption = @DataSource[this.listBox1.SelectedIndex][TCaptionField].ToString();
            Active_ID = (int)@DataSource[this.listBox1.SelectedIndex][IDField];

            if (this.IsPreviewFiled == true)
                Active_Preview = @DataSource[this.listBox1.SelectedIndex][PreviewField].ToString();
            else Active_Preview = "";
                Active_DocStatus = (int)@DataSource[this.listBox1.SelectedIndex][StatusField];
                Active_DocType = (int)@DataSource[this.listBox1.SelectedIndex]["C_DocFormat"];
            

            OnDocumentPreview();

        }

        private void listBox1_Click(object sender, EventArgs e)
        {

        }



    }
}