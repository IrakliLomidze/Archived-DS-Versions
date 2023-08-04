// History H_Status 0 is Default
// H_Status 1 is Hidden
// H_Status -1 is Deleted History Link
// H_Status -16 Deleted Base Document


using System;
using System.Drawing;
using System.Windows.Forms;
using ILG.Codex.CodexR4.History;

namespace ILG.Codex.CodexDSHistoryListBox
{

    // Default ICON and Default Color is not impemented in this verson


    public class CodexDSHistoryListEventArgs : System.EventArgs
    {
        public int _ID;

        public CodexDSHistoryListEventArgs(int ID)
        {
            this._ID = ID;
        }
    }

    public delegate void CallHistoryDocumentEventHandler(object sender, CodexDSHistoryListEventArgs e);
    
    public partial class CodexDSHistoryListBox : UserControl
    {
        public string Active_TCaption;
        public string Active_DCaption;
        public int Active_ID;
        
        public HistoryListModel DataSource;
        public string IDField;
        public string DCaptionField;
        public string TCaptionField;
        public string StatusField;
        public string NField;

        public int callfrom;

        Bitmap image_Selection;
        Bitmap Image_DocumentDefault;
        Bitmap Image_DocumentHidden;
       
        //Bitmap image_AcroboatICONSmall;
        Bitmap image_WordIconSmall; // For Measurment

        Bitmap image_Icon;  // General Variable

        Bitmap image_Attach;

        Form1 Instance;

        public CodexDSHistoryListBox()
        {
            InitializeComponent();
            Instance = new Form1();
            DataSource = new HistoryListModel();
        }

        public event CallHistoryDocumentEventHandler DocumentClick;

 
         protected virtual void OnDocumentClick(CodexDSHistoryListEventArgs e)
         {
             DocumentClick(this, e);
         }


        private Image GetImageByIconIndex(int index)
        {
            Image result = Instance.IconIndex_Default.Image; // Default Image
                 
            switch (index)
            {
                case 0 : result = Instance.IconIndex_Default.Image; break;
                case 1 : result = Instance.IconIndex_Hide.Image; break;
                case -1: result = Instance.IconIndex_Deleted.Image; break;
                default: result = Instance.IconIndex_Hide.Image; break;
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


        private Color GetColorIndexById(int id)
        {
            Color result = Color.FromArgb(30, 57, 91); //0.4f; // default Color

            return result;
        }

        private Image GetImageForOrigianlDocument(int Status)
        {
            Image result = Instance.IconIndex_Default.Image; // Default Image
          
            result = GetImageByIconIndex(Status);
            return result;
        }

        private Color GetColorForTopTitle(int Status)
        {
            Color result = Color.FromArgb(30, 57, 91);  // Default Color

            return result;
        }


        public void Configure()
        {
         
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint , true);
            this.SetStyle(ControlStyles.ResizeRedraw,false);
            this.UpdateStyles();

            

            nfont = new Font("Sylfaen", 10, FontStyle.Bold);
            tfont = new Font("Sylfaen", 10, FontStyle.Regular);
            nfont = new Font("Sylfaen", 10, FontStyle.Regular);
            captionfont = new Font("Sylfaen", 10, FontStyle.Bold);
            colorn = Color.Black;
            leftMargines = 8;
            topMargines = 10;
            distance = 12;
            Form1 f = new Form1();
            image_Selection = new Bitmap(f.pictureBox_Selection.Image);//@"C:\1\1.bmp");
            Image_DocumentDefault = new Bitmap(f.IconIndex_Default.Image);
            Image_DocumentHidden = new Bitmap(f.IconIndex_Hide.Image);
       
            image_WordIconSmall = new Bitmap(Instance.Word_Pic.Image);
            image_Attach = new Bitmap(Instance.Picture_Attachment_Icon.Image);

       
            DCaptionField = "C_Caption";
            TCaptionField = "TopCaption";
            StatusField   = "H_Status";
            IDField = "H_ID";

            
            LWithSize = listBox1.ClientSize.Width;

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

            for (int i = 0; i <= DataSource.Items.Count - 1; i++)
               this.listBox1.Items.Add(i);
            this.listBox1.Enabled = true;

            if (listBox1.Items.Count > 0) listBox1.SelectedIndex = 0;
            this.listBox1.EndUpdate();
            this.ResumeLayout();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (listBox1.Items.Count == 0) return;

            Graphics gfx = e.Graphics;
            int number = e.Index + 1;

            string xcaption = @DataSource.Items[e.Index].HistoryTitle.ToString().Trim();//[TCaptionField].ToString();
            string dtext = @DataSource.Items[e.Index].Caption.ToString();//[DCaptionField].ToString();

            SizeF f1 = gfx.MeasureString(number.ToString() + ".", nfont);
            //SizeF f11 = gfx.MeasureString(xcaption, nfont);
            SizeF f11 = gfx.MeasureString(xcaption, captionfont);

            Rectangle rect = new Rectangle(leftMargines + (int)f1.Width + 8 + image_WordIconSmall.Width+4 , topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8, e.ItemHeight);
            StringFormat stf = new StringFormat();
            stf.FormatFlags = StringFormatFlags.FitBlackBox;
            SizeF f2 = gfx.MeasureString(dtext, tfont, rect.Width, stf);
            int Temp = e.ItemWidth;
            if (f2.Width < (leftMargines + f1.Width + 8 + f11.Width)) Temp = leftMargines + (int)f1.Width + 8 + (int)f11.Width + 4;
            e.ItemHeight = topMargines + (int)f1.Height + distance + (int)f2.Height + 8 + 8;
        }

  

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (listBox1.Items.Count == 0) return;


            this.listBox1.SuspendLayout();
            int number = e.Index + 1;
            int statusLine = DataSource.Items[e.Index].HistoryStatusField;

            string documentTopTitle = DataSource.Items[e.Index].HistoryTitle.ToString(); //+ "  "+statusLine.ToString();
            string documentCaption = @DataSource.Items[e.Index].Caption.ToString();
            int Id = (int)DataSource.Items[e.Index].ID;

            image_Icon = new Bitmap(GetByImageDocumentFormat((int)DataSource.Items[e.Index].DocumentFormat));

            bool hasattach = DataSource.Items[e.Index].HasAttachment;
                
            Brush TopColor = new SolidBrush(Color.FromArgb(30, 57, 91));


            int _HistoryItemStatus = (int)DataSource.Items[e.Index].HistoryStatusField;

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

                //if ((UseConfidentialityStatus == true))
                {
                    if (statusLine == 1)
                    {

                        Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_HistoryItemStatus));
                        gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                   
                        Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_HistoryItemStatus));


                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 );

                        if (hasattach == true)
                        gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines+2+image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 );

                 
                        gfx.DrawString(documentTopTitle, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentHidden.Width + 8, e.Bounds.Y + topMargines);

                        //gfx.DrawString(xcaption, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentWithLock.Width + 2 + Image_Lock.Width+8, e.Bounds.Y + topMargines);
                    }
                    else
                    {
                        // Original
                        Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_HistoryItemStatus));

                        gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height  + 8);

                        Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_HistoryItemStatus));

                        gfx.DrawString(documentTopTitle, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentHidden.Width + 2, e.Bounds.Y + topMargines);

                        if (hasattach == true)
                            gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height + 2);

                    }
                }
                //else
                //{
                //    Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_HistoryItemStatus));
                //    gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);

                //    gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6  + 8);
                //    Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_HistoryItemStatus));

                //    gfx.DrawString(documentCaption, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentHidden.Width + 2, e.Bounds.Y + topMargines);

                //    if (hasattach == true)
                //        gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height + 2 );

         
                //}
                //gfx.DrawString(xcaption, nfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines);

                SizeF f11 = gfx.MeasureString(documentTopTitle, captionfont);

                Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8 + image_WordIconSmall.Width + 4 , e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8 - image_WordIconSmall.Width , this.ClientSize.Height - 4); //ZXZ2
                //Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8                       , e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8     , this.ClientSize.Height);
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

                gfx.DrawString(documentCaption, tfont, Brushes.Black, rect, stf);
               
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

                //if ((UseConfidentialityStatus == true))
                {
                    if (statusLine == 1)
                    {
                        // Confidetial
                        Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_HistoryItemStatus));

                        gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
              
                        Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_HistoryItemStatus));

                        //                        gfx.DrawImage(Image_DocumentWithLock, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6  + 8);
                           gfx.DrawString(documentTopTitle, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentHidden.Width + 2 +8, e.Bounds.Y + topMargines);

                        if (hasattach == true)
                            gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + 8);

           
                    }
                    else
                    {
                        // Original
                        SizeF f111 = gfx.MeasureString(documentTopTitle, captionfont);

                        Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_HistoryItemStatus));

                        gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines,e.Bounds.Y + topMargines + f1.Height -6 +8);

                        if (hasattach == true)
                            gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + 8);

          
                        Brush NewTopColor = new SolidBrush(GetColorForTopTitle(_HistoryItemStatus));


                        gfx.DrawString(documentTopTitle, captionfont, NewTopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentHidden.Width + 2, e.Bounds.Y + topMargines);
                    }
                }
                //else
                //{
                //    Bitmap Document_icon = new Bitmap(GetImageForOrigianlDocument(_HistoryItemStatus));

                //    gfx.DrawImage(Document_icon, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                //    gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6  + 8);

                //    if (hasattach == true)
                //    gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + 8);



                //    gfx.DrawString(documentCaption, captionfont, TopColor, e.Bounds.X + leftMargines + f1.Width + 8 + Image_DocumentHidden.Width + 2, e.Bounds.Y + topMargines);
                //}                

                SizeF f11 = gfx.MeasureString(documentTopTitle, captionfont);

                Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8 + image_WordIconSmall.Width + 4, e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8, this.ClientSize.Height);
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

         
                gfx.DrawString(documentCaption, tfont, Brushes.Black, rect, stf); 
            }

            e.DrawFocusRectangle();
            this.listBox1.ResumeLayout();
				

        }


        private void DoVisited()
        {
            if (listBox1.Items == null) return;

            if (listBox1.Items.Count == 0) return;
            int id = (int)DataSource.Items[this.listBox1.SelectedIndex].ID ;
            OnDocumentClick(new CodexDSHistoryListEventArgs(id));
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



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Active_ID = (int)@DataSource.Items[this.listBox1.SelectedIndex].ID;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {

        }



    }
}