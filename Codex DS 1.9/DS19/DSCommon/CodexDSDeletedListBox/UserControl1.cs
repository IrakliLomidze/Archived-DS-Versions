using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CodexDSListBox;

namespace ILG.Codex.CodexDSListBox
{

    // Default ICON and Default Color is not impemented in this verson


    public class CodexDSListEventArgs : System.EventArgs
    {
        public int _ID;
        public string _TCaption;
        public string _DCaption;

        public CodexDSListEventArgs(int ID, string TCaption, string DCaption)
        {
            this._ID = ID;
            this._TCaption = TCaption;
            this._DCaption = DCaption;
        }
    }

    public delegate void CallDocumentEventHandler(object sender, CodexDSListEventArgs e);
    
    public partial class CodexDSListBox : UserControl
    {
        public string Active_TCaption;
        public string Active_DCaption;
        public int Active_ID;
        
        public DataRow[] DataSource;
        public string IDField;
        public string DCaptionField;
        public string TCaptionField;
        public string StatusField;
        public string NField;
        public DataTable Visited;
        public string ProgramName;
        public int callfrom;
        private bool UseConfidentialityStatus;


        Bitmap image_Selection;
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

        bool _ShowHisotry = false;

        //Bitmap image_Unknown;
        // A delegate type for hooking up change notifications.

        DSListConfiguration ListConfiguration;
        Form1 Instance;

        public CodexDSListBox()
        {
            InitializeComponent();
            Instance = new Form1();
        }

        public event CallDocumentEventHandler DocumentClick;

 
         protected virtual void OnDocumentClick(CodexDSListEventArgs e)
         {
             DocumentClick(this, e);
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
            if (id == ListConfiguration.IdConfiguration.IdOfOriginalDocument ) result = ListConfiguration.IconIndexConfiguration.IconIndexOfOriginalDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfArchivedDocument) result = ListConfiguration.IconIndexConfiguration.IconIndexArchivedDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfCodifiedDocument) result = ListConfiguration.IconIndexConfiguration.IconIndexCodifiedDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfDraftDocument) result = ListConfiguration.IconIndexConfiguration.IconIndexDraftDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfObsoleteDocument) result = ListConfiguration.IconIndexConfiguration.IconIndexObsoleteDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfSpecifiedDocument) result = ListConfiguration.IconIndexConfiguration.IconIndexSpecifiedDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfUnknownDocument) result = ListConfiguration.IconIndexConfiguration.IconIndexUnknownDocument;
            
            return result;
        }


        private Color GetColorIndexById(int id)
        {
            Color result = Color.FromArgb(30, 57, 91); //0.4f; // default Color
            if (id == ListConfiguration.IdConfiguration.IdOfOriginalDocument) result = ListConfiguration.ColorConfiguration.ColorOfOriginalDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfArchivedDocument) result = ListConfiguration.ColorConfiguration.ColorOfArchivedDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfCodifiedDocument) result = ListConfiguration.ColorConfiguration.ColorOfCodifiedDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfDraftDocument) result = ListConfiguration.ColorConfiguration.ColorOfDraftDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfObsoleteDocument) result = ListConfiguration.ColorConfiguration.ColorOfObsoleteDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfSpecifiedDocument) result = ListConfiguration.ColorConfiguration.ColorOfSpecifiedDocument;
            if (id == ListConfiguration.IdConfiguration.IdOfUnknownDocument) result = ListConfiguration.ColorConfiguration.ColorOfUnknownDocument;

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


        public void Configure(DSListConfiguration configuration,bool ShowHistory)
        {
            ListConfiguration = configuration;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint , true);
            this.SetStyle(ControlStyles.ResizeRedraw,false);
            this.UpdateStyles();

            

            nfont = new Font("Sylfaen", 10, FontStyle.Bold);
            tfont = new Font("Sylfaen", 10, FontStyle.Regular);
            captionfont = new Font("Sylfaen", 10, FontStyle.Bold);
            colorn = Color.Black;
            leftMargines = 8;
            topMargines = 10;
            distance = 12;
            Form1 f = new Form1();
            image_Selection = new Bitmap(f.pictureBox_Selection.Image);//@"C:\1\1.bmp");
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
            IDField = "C_ID";
            UseConfidentialityStatus = true;
            
            LWithSize = listBox1.ClientSize.Width;

            _ShowHisotry = ShowHistory;
        }

        // ---------------------------------
        Font nfont;
        Color colorn;
        int leftMargines;
        int topMargines;


        int distance;
        Font tfont;
        Font captionfont;

        int LWithSize;
        public void FillGrid()
        {
            this.SuspendLayout();
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

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            Graphics gfx = e.Graphics;
            int number = e.Index + 1;

            string xcaption = @DataSource[e.Index][TCaptionField].ToString();
            string dtext = @DataSource[e.Index][DCaptionField].ToString();

            SizeF f1 = gfx.MeasureString(number.ToString() + ".", nfont);
            //SizeF f11 = gfx.MeasureString(xcaption, nfont);
            SizeF f11 = gfx.MeasureString(xcaption, captionfont);

            Rectangle rect = new Rectangle(leftMargines + (int)f1.Width + 8 + image_WordIconSmall.Width+4 + 2 + image_History.Width, topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8, e.ItemHeight);
            StringFormat stf = new StringFormat();
            stf.FormatFlags = StringFormatFlags.FitBlackBox;
            SizeF f2 = gfx.MeasureString(dtext, tfont, rect.Width, stf);
            int Temp = e.ItemWidth;
            if (f2.Width < (leftMargines + f1.Width + 8 + f11.Width)) Temp = leftMargines + (int)f1.Width + 8 + (int)f11.Width + 4;
            e.ItemHeight = topMargines + (int)f1.Height + distance + (int)f2.Height + 8 + 8;
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
            int statusLine = (int)DataSource[e.Index][StatusField];
            string ConfidentialitystatusString = GetConfidentialityStringByStatus(statusLine);
 
            string xcaption = DataSource[e.Index][TCaptionField].ToString() + ConfidentialitystatusString;//+ "  "+statusLine.ToString();
            string dtext = @DataSource[e.Index][DCaptionField].ToString();
            int ind = (int)DataSource[e.Index][IDField];

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
            if (_ShowHisotry == true)
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

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Graphics gfx = e.Graphics;

                Pen pen = new Pen(Brushes.SteelBlue, 0.4f);
                pen = new Pen(Color.FromArgb(34, 115, 70), 0.4f); // Overide bulu to green

                Pen pen2 = new Pen(Color.FromArgb(30, 57, 91), 0.4f);
                Pen pen3 = new Pen(Color.FromArgb(214, 229, 245), 0.4f);

                Pen PenX3 = new Pen(Color.FromArgb(0x7d, 0xa2, 0xce), 1);
                PenX3 = new Pen(Color.FromArgb(34, 115, 70), 0.4f); // Overide bulu to green

                Pen PenX2 = new Pen(Color.FromArgb(0xeb, 0xf4, 0xfd), 1);
                Pen PenX1 = new Pen(Color.FromArgb(0xd0, 0xe4, 0xf4), 1);
                Brush B1 = new SolidBrush(Color.FromArgb(0xd0, 0xe4, 0xf4));

                gfx.DrawRectangle(PenX3, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 3, e.Bounds.Height - 3));
                gfx.DrawImage(image_Selection, e.Bounds.X +3, e.Bounds.Y+3, e.Bounds.Width-5, e.Bounds.Height - 5);

                gfx.DrawString(number.ToString() + ".", nfont, Brushes.Black, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines-6);
                SizeF f1 = gfx.MeasureString(number.ToString() + ".", nfont);

                if ((UseConfidentialityStatus == true))
                {
                    if (statusLine == 1)
                    {

                        // Confidential
                        Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_DocumentStatus));
                        gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(Image_Lock, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 8 , e.Bounds.Y + topMargines - 6);

                        Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_DocumentStatus));


                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                        if (hasattach != 0)
                        gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines+2+image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                        if (DrawHistoryIcon == true)
                        gfx.DrawImage(image_History, e.Bounds.X + leftMargines + 2 + image_Icon.Width + 2 + image_Attach.Width  , e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                        gfx.DrawString(xcaption, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 2 + Image_Lock.Width + 8, e.Bounds.Y + topMargines);

                        //gfx.DrawString(xcaption, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 2 + Image_Lock.Width+8, e.Bounds.Y + topMargines);
                    }
                    else
                    {
                        // Original
                        Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_DocumentStatus));

                        gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                        Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_DocumentStatus));

                        gfx.DrawString(xcaption, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 2, e.Bounds.Y + topMargines);

                        if (hasattach != 0)
                            gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                        if (DrawHistoryIcon == true)
                            gfx.DrawImage(image_History, e.Bounds.X + leftMargines + 2 + image_Icon.Width + 2 + image_Attach.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                    }
                }
                else
                {
                    Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_DocumentStatus));
                    gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);

                    gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);
                    Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_DocumentStatus));

                    gfx.DrawString(xcaption, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 2, e.Bounds.Y + topMargines);

                    if (hasattach != 0)
                        gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                    if (DrawHistoryIcon == true)
                        gfx.DrawImage(image_History, e.Bounds.X + leftMargines + 2 + image_Icon.Width + 2 + image_Attach.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                }
                //gfx.DrawString(xcaption, nfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines);

                SizeF f11 = gfx.MeasureString(xcaption, captionfont);

                Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8 + image_WordIconSmall.Width + 4 + 2 + image_History.Width, e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8 - image_WordIconSmall.Width , this.ClientSize.Height - 4); //ZXZ2
                //Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8                       , e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8     , this.ClientSize.Height);
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

                if (Visited.Rows.Contains(new object[] { ind }) == false)
                { gfx.DrawString(dtext, tfont, Brushes.Black, rect, stf);
                  
                }
                else
                { gfx.DrawString(dtext, tfont, Brushes.Purple, rect, stf);
                  //gfx.DrawImage(image6, e.Bounds.X +8, e.Bounds.Y + topMargines + f1.Height + 4);
                  gfx.DrawImage(image_Visited, e.Bounds.X + 8, e.Bounds.Y + topMargines + f1.Height-6);
                }

            }
            else
            {
                Graphics gfx = e.Graphics;


                gfx.FillRectangle(Brushes.White, e.Bounds.X , e.Bounds.Y , e.Bounds.Width , e.Bounds.Height );

                //gfx.FillRectangle(Brushes.LightGray, e.Bounds.X + 4, e.Bounds.Y + e.Bounds.Height -1, e.Bounds.Width - 8, 1);

                gfx.FillRectangle(new SolidBrush(Color.FromArgb(214, 229, 245)), e.Bounds.X + 4, e.Bounds.Y + e.Bounds.Height - 1, e.Bounds.Width - 8, 1);
                gfx.FillRectangle(Brushes.LightGray, e.Bounds.X + 4, e.Bounds.Y + e.Bounds.Height - 1, e.Bounds.Width - 8, 1);

                Pen pen = new Pen(Brushes.SteelBlue, 0.4f);
                //pen = new Pen(TopColor, 0.4f);
                

                
                gfx.DrawString(number.ToString() + ".", nfont, Brushes.Black, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines-6); 
                

                SizeF f1 = gfx.MeasureString(number.ToString() + ".", nfont);

                if ((UseConfidentialityStatus == true))
                {
                    if (statusLine == 1)
                    {
                        // Confidetial
                        Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_DocumentStatus));

                        gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(Image_Lock, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 8, e.Bounds.Y + topMargines - 6);

                        Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_DocumentStatus));

                        //                        gfx.DrawImage(Image_DocumentWithLock, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);
                           gfx.DrawString(xcaption, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 2 + Image_Lock.Width+8, e.Bounds.Y + topMargines);
                        
                        if (hasattach != 0)
                               gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                        if (DrawHistoryIcon == true)
                            gfx.DrawImage(image_History, e.Bounds.X + leftMargines + 2 + image_Icon.Width + 2 + image_Attach.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                    }
                    else
                    {
                        // Original
                        SizeF f111 = gfx.MeasureString(xcaption, captionfont);

                        Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_DocumentStatus));

                        gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines,e.Bounds.Y + topMargines + f1.Height -6 + image_Visited.Height+8);

                        if (hasattach != 0)
                        gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                        if (DrawHistoryIcon == true)
                            gfx.DrawImage(image_History, e.Bounds.X + leftMargines + 2 + image_Icon.Width + 2 + image_Attach.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                        Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_DocumentStatus));


                        gfx.DrawString(xcaption, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 2, e.Bounds.Y + topMargines);
                    }
                }
                else
                {
                    Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_DocumentStatus));

                    gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                    gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                    if (hasattach != 0)
                    gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);

                    if (DrawHistoryIcon == true)
                        gfx.DrawImage(image_History, e.Bounds.X + leftMargines + 2 + image_Icon.Width + 2 + image_Attach.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image_Visited.Height + 8);


                    gfx.DrawString(xcaption, captionfont, TopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 2, e.Bounds.Y + topMargines);
                }                
                SizeF f11 = gfx.MeasureString(xcaption, captionfont);

                //Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8 + image_Word.Width + 4, e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8, this.ClientSize.Height);
                Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8 + image_WordIconSmall.Width + 4 + 2 + image_History.Width, e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8 - image_WordIconSmall.Width, this.ClientSize.Height - 4); //ZXZ2
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

                if (Visited.Rows.Contains(new object[] { ind }) == false)
                { gfx.DrawString(dtext, tfont, Brushes.Black, rect, stf); }
                else
                { gfx.DrawString(dtext, tfont, Brushes.Purple, rect, stf);
                  gfx.DrawImage(image_Visited, e.Bounds.X + 8, e.Bounds.Y + topMargines + f1.Height - 6);
                }
            }

            e.DrawFocusRectangle();
            this.listBox1.ResumeLayout();
				

        }


        private void DoVisited()
        {
            int id = (int)DataSource[this.listBox1.SelectedIndex][IDField]; ;
            if (Visited.Rows.Contains(new object[] { id }) == false)
                Visited.Rows.Add(new object[] { id });

            OnDocumentClick(new CodexDSListEventArgs(id,DataSource[this.listBox1.SelectedIndex][TCaptionField].ToString(),DataSource[this.listBox1.SelectedIndex][DCaptionField].ToString()));
            
            
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
            d.FileName = "rtf";
            d.Filter = "Rich Text Format  (*.rtf)| *.rtf";
            d.Title = "Save List";
			

            if (d.ShowDialog() == DialogResult.OK)
            {
                string s = System.IO.Path.GetExtension(d.FileName);
                if (s.ToLower() != "rtf") d.FileName = System.IO.Path.GetFileNameWithoutExtension(d.FileName) + ".rtf";
                
                if ((f = d.OpenFile()) != null)
                {  // create stream
                    StreamWriter f1 = new StreamWriter(f);
                    string[] res = generetelistfile();
                    foreach (string r in res)
                    {
                        if (r != null) f1.WriteLine(r);
                    }

                    f1.Close();
                    f.Close();
                    ILG.Windows.Forms.ILGMessageBox.Show("სია ჩაწერილია");

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
        }

        private void listBox1_Click(object sender, EventArgs e)
        {

        }



    }
}