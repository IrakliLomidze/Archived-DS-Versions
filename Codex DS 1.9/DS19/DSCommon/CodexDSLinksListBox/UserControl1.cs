using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ILG.Codex.CodexDSLinkListBox
{

    public class CodexDSLinkListEventArgs : System.EventArgs
    {
        public int _LinkTo;
        public string _Caption;
        

        public CodexDSLinkListEventArgs(int LinkTo, string Caption)
        {
            this._LinkTo = LinkTo;
            this._Caption = Caption;
        }
    }

    public delegate void CallDocumentLinkEventHandler(object sender, CodexDSLinkListEventArgs e);
    
    public partial class CodexDSLinkListBox : UserControl
    {
        public string Active_Caption;
        public int Active_LinkTo;
        
        public DataRow[] DataSource;

        public string CaptionField;
        public string LinkTypeField;
        public string LinkToField;
        
        public DataTable Visited;

        Bitmap image_Sellector;
        //Bitmap image2;
        //Bitmap image5;
        //Bitmap image3;
        Bitmap image_Yellow;



        Bitmap image_Yello;
        Bitmap image_Blue;
        Bitmap image_Red;
        Bitmap image_Green;
        Bitmap image_Gray;

        
        // A delegate type for hooking up change notifications.

        
       
        public CodexDSLinkListBox()
        {
            InitializeComponent();
        }

        public event CallDocumentLinkEventHandler DocumentClick;

 
         protected virtual void OnDocumentClick(CodexDSLinkListEventArgs e)
         {
             DocumentClick(this, e);
         }


        public void InitializeVarialbles(int Varialbe)
        {

            
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint , true);
            this.SetStyle(ControlStyles.ResizeRedraw,false);
            this.UpdateStyles();

            

            nfont = new Font("Sylfaen", 9.25f , FontStyle.Regular);
            tfont = new Font("Sylfaen", 9.25f , FontStyle.Regular);
            colorn = Color.Black;
            leftMargines = 8;
            topMargines = 2;
            distance = 2;
            Form1 f = new Form1();
            image_Sellector = new Bitmap(f.pictureBox_Sellector.Image);//@"C:\1\1.bmp");
            //image2 = new Bitmap(f.pictureBox2.Image);
            //image5 = new Bitmap(f.pictureBox5.Image);
            //image3 = new Bitmap(f.pictureBox3.Image);
            image_Yellow = new Bitmap(f.pictureBox_Yellow.Image);

            image_Blue = new Bitmap(f.pictureBox_Blue.Image);
            image_Yello = new Bitmap(f.pictureBox_Yellow.Image);
            image_Red = new Bitmap(f.pictureBox_Red.Image);
            image_Green = new Bitmap(f.pictureBox_Green.Image);
            image_Gray = new Bitmap(f.pictureBox_Gray.Image);

            CaptionField = "Caption";
            LinkTypeField = "Type";
            LinkToField = "Link";

      
            LWithSize = listBox1.ClientSize.Width;

        }

        // ---------------------------------
        Font nfont;
        Color colorn;
        int leftMargines;
        int topMargines;


        int distance;
        Font tfont;

        int LWithSize;
        public void FillGrid()
        {
            this.SuspendLayout();
            this.listBox1.BeginUpdate();
            
            this.LWithSize = listBox1.ClientSize.Width;
            this.listBox1.HorizontalExtent = this.LWithSize;
            this.listBox1.Enabled = false;
            this.listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            this.listBox1.SelectionMode = SelectionMode.One;
            this.listBox1.BorderStyle = BorderStyle.None;
            this.listBox1.Items.Clear();

            
            // Calucalting NULL Fields
            int CCNUL = 0;
            for (int i = 0; i <= DataSource.Length - 1; i++)
                if (DataSource[i][LinkToField] == DBNull.Value) CCNUL++;

            DataRow[] ds2 = new DataRow[DataSource.Length-CCNUL];
            int ds2Index = 0;
            for (int i = 0; i <= DataSource.Length - 1; i++)
                if (DataSource[i][LinkToField] != DBNull.Value)
                {
                    ds2[ds2Index] = DataSource[i];
                    ds2Index++;
                }
                else continue;

            //MessageBox.Show("Original :"+ DataSource.Length.ToString() + "\n" + "New :" + ds2.Length.ToString());
            DataSource = ds2;
            

        
           
            for (int i = 0; i <= DataSource.Length - 1; i++)
               this.listBox1.Items.Add(i);
            this.listBox1.Enabled = true;

            if ( this.listBox1.Items.Count !=  0) this.listBox1.SelectedIndex = 0;
            this.listBox1.BorderStyle = BorderStyle.None;
         
            this.listBox1.EndUpdate();
            this.ResumeLayout();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            Graphics gfx = e.Graphics;
            int number = e.Index + 1;

                string xcaption = @DataSource[e.Index][CaptionField].ToString();
                Rectangle rect = new Rectangle(leftMargines + 16 + 2, topMargines + distance, this.LWithSize - leftMargines - 16 - 4, e.ItemHeight);

                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

                SizeF f1 = gfx.MeasureString(xcaption, nfont, rect.Width, stf);

                e.ItemHeight = topMargines + (int)f1.Height + distance * 3;
       }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

            int number = e.Index;
            if (e.Index < 0) return;

            string xcaption = @DataSource[e.Index][CaptionField].ToString();


            int status = (int)@DataSource[e.Index][LinkTypeField];
            int linkedto = (int)@DataSource[e.Index][LinkToField];

            xcaption = xcaption.Replace("ცვლილიბა", "ცვლილება");
            xcaption = xcaption.Replace("წელი", " წელი");
            xcaption = xcaption.Replace("წლის", " წელი");


            if ((@DataSource[e.Index][CaptionField].ToString().Trim() == ""))
            {
                status = 0;
                linkedto = 0;
            }

            int donotdraw = 0;

            if ((@DataSource[e.Index][CaptionField].ToString().Trim() == "")) donotdraw = 1;

            Brush b;
            Image Ball;

            #region Codex Brush
            if (Visited.Rows.Contains(new object[] { linkedto }) == false)
            {
                switch (status)
                {
                    case 0: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Blue; break; // Blue
                    case 1: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Gray; break; // Gary
                    case 2: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Blue; break; // Blue
                    case 3: b = new SolidBrush(Color.FromArgb(128, 13, 29)); Ball = this.image_Red; break; // Red
                    case 4: b = Brushes.Black; Ball = this.image_Yello; break;   // Yelow
                    case 5: b = Brushes.Black; Ball = this.image_Green; break;
                    default: b = Brushes.Black; Ball = this.image_Gray; break;
                }
            }
            else
            {
                switch (status)
                {
                    case 0: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Blue; break; // Blue
                    case 1: b = Brushes.Purple; Ball = this.image_Gray; break; // Gary
                    case 2: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Blue; break; // Blue
                    case 3: b = new SolidBrush(Color.FromArgb(128, 13, 29)); Ball = this.image_Red; break; // Red
                    case 4: b = Brushes.Purple; Ball = this.image_Yello; break;   // Yelow
                    case 5: b = Brushes.Purple; Ball = this.image_Green; break;
                    default: b = Brushes.Purple; Ball = this.image_Gray; break;
                }
            }
            #endregion Codex Brush





            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Graphics gfx = e.Graphics;


                Pen pen = new Pen(Color.FromArgb(214, 229, 245), 0.4f);
                pen = new Pen(Brushes.LightGray, 0.4f);

                gfx.DrawImage(Ball, e.Bounds.X + 4, e.Bounds.Y + 4);


                Pen PenX3 = new Pen(Color.FromArgb(0x7d, 0xa2, 0xce), 1);
                PenX3 = new Pen(Color.FromArgb(34, 115, 70), 0.4f); // Overide bulu to green

                gfx.DrawRectangle(PenX3, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2));
                gfx.DrawImage(image_Sellector, e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 2, e.Bounds.Height - 2);
                gfx.DrawRectangle(PenX3, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2));


                gfx.DrawImage(Ball, e.Bounds.X + 4, e.Bounds.Y + 4);

                //Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)Ball.Width + 2, e.Bounds.Y + topMargines  + distance, this.LWithSize - leftMargines - Ball.Width - 4, this.ClientSize.Height);
                Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + 16 + 2, e.Bounds.Y + topMargines + distance, this.LWithSize - leftMargines - 16 - 4, this.ClientSize.Height);

                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;


                //gfx.DrawString(xcaption, nfont, b, e.Bounds.X + leftMargines+Ball.Width+4, e.Bounds.Y + topMargines, rect, stf);

                gfx.DrawString(xcaption, nfont, b, rect, stf);

                SizeF f11 = gfx.MeasureString(xcaption, nfont);

            }
            else
            {
                Graphics gfx = e.Graphics;
                Pen pen = new Pen(Brushes.LightGray, 0.4f);

                gfx.FillRectangle(Brushes.White, e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 1, e.Bounds.Height - 1);
                gfx.DrawLine(pen, e.Bounds.X + 1, e.Bounds.Y + e.Bounds.Height - 1, e.Bounds.Width - 2, e.Bounds.Y + e.Bounds.Height - 3);


                gfx.DrawImage(Ball, e.Bounds.X + 4, e.Bounds.Y + 4);

                Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)16 + 2, e.Bounds.Y + topMargines + distance, this.LWithSize - leftMargines - 16 - 4, this.ClientSize.Height);
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

                gfx.DrawString(xcaption, nfont, b, rect, stf);

                //gfx.DrawString(xcaption, nfont, b, e.Bounds.X + leftMargines+16+2, e.Bounds.Y + topMargines);

            }



            // e.DrawFocusRectangle();


        }

        private void listBox1_DrawItem2(object sender, DrawItemEventArgs e)
        {
            
            int number = e.Index;
            if (e.Index < 0) return;
            //string xcaption = @DataSource[e.Index][CaptionField].ToString();

            string xcaption = @DataSource[e.Index][CaptionField].ToString();
            

            int status = (int)@DataSource[e.Index][LinkTypeField];
            int linkedto = (int)@DataSource[e.Index][LinkToField];


            if ((@DataSource[e.Index][CaptionField].ToString().Trim() == ""))
            {
                status = 0;
                linkedto = 0;
            }

            //int donotdraw = 0;

            //if ((ProgramName != "CODEX") && (@DataSource[e.Index][CaptionField].ToString().Trim() == "")) donotdraw = 1;

            Brush b;
            Image Ball;
            
           #region Codex Brush
                if (Visited.Rows.Contains(new object[] { linkedto }) == false)
                {
                    switch (status)
                    {
                        case 0: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Blue; break; // Blue
                        case 1: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Gray; break; // Gary
                        case 2: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Blue; break; // Blue
                        case 3: b = new SolidBrush(Color.FromArgb(128, 13, 29)); Ball = this.image_Red; break; // Red
                        case 4: b = Brushes.Black; Ball = this.image_Yello; break;   // Yelow
                        case 5: b = Brushes.Black; Ball = this.image_Green; break;
                        default: b = Brushes.Black; Ball = this.image_Gray;  break;
                    }
                }
                else
                {
                    switch (status)
                    {
                        case 0: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Blue; break; // Blue
                        case 1: b = Brushes.Purple; Ball = this.image_Gray; break; // Gary
                        case 2: b = new SolidBrush(Color.FromArgb(30, 57, 91)); Ball = this.image_Blue; break; // Blue
                        case 3: b = new SolidBrush(Color.FromArgb(128, 13, 29)); Ball = this.image_Red; break; // Red
                        case 4: b = Brushes.Purple; Ball = this.image_Yello; break;   // Yelow
                        case 5: b = Brushes.Purple; Ball = this.image_Green; break;
                        default: b = Brushes.Purple; Ball = this.image_Gray; break;
                    }
                }
                #endregion Codex Brush
                

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Graphics gfx = e.Graphics;

                Pen pen = new Pen(Brushes.LightGray, 0.4f);
                //Pen pen = new Pen(Color.FromArgb(214, 229, 245), 0.4f);

                gfx.DrawImage(Ball, e.Bounds.X + 1, e.Bounds.Y + 1);
         
                //gfx.DrawRectangle(pen, e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);
                gfx.DrawRectangle(pen, e.Bounds.X, e.Bounds.Y , e.Bounds.Width , e.Bounds.Height );


                Pen PenX3 = new Pen(Color.FromArgb(0x7d, 0xa2, 0xce), 1);
                PenX3 = new Pen(Color.FromArgb(34, 115, 70), 0.4f); // Overide bulu to green

                gfx.DrawRectangle(PenX3, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2));

                gfx.DrawImage(image_Sellector, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 1);

                gfx.DrawRectangle(PenX3, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2));

                gfx.DrawImage(Ball, e.Bounds.X + 1, e.Bounds.Y + 1);
                gfx.DrawString(xcaption, nfont, b, e.Bounds.X + leftMargines+16+2, e.Bounds.Y + topMargines);

                SizeF f11 = gfx.MeasureString(xcaption, nfont);

            }
            else
            {
                Graphics gfx = e.Graphics;
                Pen pen = new Pen(Brushes.LightGray, 0.4f);
                pen = new Pen(Brushes.LightGray, 0.4f);

                gfx.FillRectangle(Brushes.White, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height );

                gfx.FillRectangle(Brushes.White, e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 1, e.Bounds.Height - 1);
                gfx.DrawLine(pen, e.Bounds.X + 1, e.Bounds.Y + e.Bounds.Height - 3, e.Bounds.Width - 2, e.Bounds.Y + e.Bounds.Height - 3);

                
                gfx.DrawImage(Ball, e.Bounds.X + 1, e.Bounds.Y + 1);
                gfx.DrawString(xcaption, nfont, b, e.Bounds.X + leftMargines+16+2, e.Bounds.Y + topMargines);

            }



            e.DrawFocusRectangle();


        }


        private void DoVisited()
        {
            if (listBox1.Items.Count == 0) return;
            int id = (int)DataSource[this.listBox1.SelectedIndex][LinkToField]; ;
            if (Visited.Rows.Contains(new object[] { id }) == false)
                Visited.Rows.Add(new object[] { id });
            //MessageBox.Show(id.ToString());
            //MessageBox.Show(DataSource[this.listBox1.SelectedIndex][TCaptionField].ToString());
            
            OnDocumentClick(new CodexDSLinkListEventArgs((int)DataSource[this.listBox1.SelectedIndex][LinkToField],DataSource[this.listBox1.SelectedIndex][CaptionField].ToString()));
            
            
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
            
            Active_Caption = @DataSource[this.listBox1.SelectedIndex][CaptionField].ToString();
            Active_LinkTo = (int)@DataSource[this.listBox1.SelectedIndex][LinkToField];
        }

        private void listBox1_Click(object sender, EventArgs e)
        {

        }



    }
}