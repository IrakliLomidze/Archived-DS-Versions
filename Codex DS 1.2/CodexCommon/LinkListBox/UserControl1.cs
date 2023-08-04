using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ILG.Codex.LinkListBox
{

    public class LinkListEventArgs : System.EventArgs
    {
        public int _LinkTo;
        public string _Caption;
        

        public LinkListEventArgs(int LinkTo, string Caption)
        {
            this._LinkTo = LinkTo;
            this._Caption = Caption;
        }
    }

    public delegate void CallDocumentLinkEventHandler(object sender, LinkListEventArgs e);
    
    public partial class LinkListBox : UserControl
    {
        public string Active_Caption;
        public int Active_LinkTo;
        
        public DataRow[] DataSource;

        public string CaptionField;
        public string LinkTypeField;
        public string LinkToField;
        
        public DataTable Visited;
        public string ProgramName;

        Bitmap image1;
        Bitmap image2;
        Bitmap image5;
        Bitmap image3;
        Bitmap image6;


        Bitmap image8;

        Bitmap image_6;
        Bitmap image_8;
        Bitmap image_9;
        Bitmap image_10;
        Bitmap image_11;

        
        // A delegate type for hooking up change notifications.

        
       
        public LinkListBox()
        {
            InitializeComponent();
        }

        public event CallDocumentLinkEventHandler DocumentClick;

 
         protected virtual void OnDocumentClick(LinkListEventArgs e)
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
            image1 = new Bitmap(f.pictureBox1.Image);//@"C:\1\1.bmp");
            image2 = new Bitmap(f.pictureBox2.Image);
            image5 = new Bitmap(f.pictureBox5.Image);
            image3 = new Bitmap(f.pictureBox3.Image);
            image6 = new Bitmap(f.pictureBox6.Image);

            image_8 = new Bitmap(f.pictureBox8.Image);
            image_6 = new Bitmap(f.pictureBox6.Image);
            image_9 = new Bitmap(f.pictureBox9.Image);
            image_10 = new Bitmap(f.pictureBox10.Image);
            image_11 = new Bitmap(f.pictureBox11.Image);
            
            
            switch (Varialbe)
            {
                case 2: // Codex
                    {

                        CaptionField = "Caption";
                        LinkTypeField = "Type";
                        LinkToField = "Link";
                    }
                    break;

                case 1: // CGL
                    {
                        CaptionField = "Caption";
                        LinkTypeField = "Type";
                        LinkToField = "Link";
                    }
                    break;

            }
            
            

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
            this.listBox1.EndUpdate();
            this.ResumeLayout();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            Graphics gfx = e.Graphics;
            int number = e.Index + 1;
            
            if (this.ProgramName == "CODEX")
            {
                string xcaption = @DataSource[e.Index][CaptionField].ToString();
                SizeF f1 = gfx.MeasureString(xcaption, nfont);
                e.ItemHeight = topMargines + (int)f1.Height + distance;
            }
            else // CGL
            {
                string xcaption = @DataSource[e.Index][CaptionField].ToString();
                if (@DataSource[e.Index][CaptionField].ToString().Trim() == "")
                    e.ItemHeight = 0;
                else
                {
                    SizeF f1 = gfx.MeasureString(xcaption, nfont);
                    e.ItemHeight = topMargines + (int)f1.Height + distance;
                }
			
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            int number = e.Index;
            if (e.Index < 0) return;
            //string xcaption = @DataSource[e.Index][CaptionField].ToString();

            string xcaption = @DataSource[e.Index][CaptionField].ToString();
            

            int status = (int)@DataSource[e.Index][LinkTypeField];
            int linkedto = (int)@DataSource[e.Index][LinkToField];


            if ((ProgramName != "CODEX") && (@DataSource[e.Index][CaptionField].ToString().Trim() == ""))
            {
                status = 0;
                linkedto = 0;
            }

            int donotdraw = 0;

            if ((ProgramName != "CODEX") && (@DataSource[e.Index][CaptionField].ToString().Trim() == "")) donotdraw = 1;

            Brush b;
            Image Ball;
            
            if (ProgramName == "CODEX")
            {
                #region Codex Brush
                if (Visited.Rows.Contains(new object[] { linkedto }) == false)
                {
                    switch (status)
                    {
                        case 0: b = Brushes.Black; Ball = this.image_8; break;  // Blue
                        case 1: b = Brushes.Blue; Ball = this.image_11;  break; // Gary
                        case 2: b = Brushes.Blue; Ball = this.image_8; break;  // Blue
                        case 3: b = Brushes.Red; Ball = this.image_9;  break;  // Red
                        case 4: b = Brushes.Black; Ball = this.image_6; break;   // Yelow
                        case 5: b = Brushes.Black; Ball = this.image_10; break;
                        default: b = Brushes.Black; Ball = this.image_11;  break;
                    }
                }
                else
                {
                    switch (status)
                    {
                        case 0: b = Brushes.Purple; Ball = this.image_8; break;  // Blue
                        case 1: b = Brushes.Purple; Ball = this.image_11; break; // Gary
                        case 2: b = Brushes.Purple; Ball = this.image_8; break;  // Blue
                        case 3: b = Brushes.DarkRed; Ball = this.image_9; break;  // Red
                        case 4: b = Brushes.Purple; Ball = this.image_6; break;   // Yelow
                        case 5: b = Brushes.Purple; Ball = this.image_10; break;
                        default: b = Brushes.Purple; Ball = this.image_11; break;
                    }
                }
                #endregion Codex Brush
            }
            else
            {
                #region CGL Brush
                if (Visited.Rows.Contains(new object[] { linkedto }) == false)
                {
                    switch (status)
                    {
                        case 0: b = Brushes.Black; Ball = this.image_8;  break;
                        case 1: b = Brushes.Red; Ball = this.image_9;  break;
                        case 3: b = Brushes.SteelBlue; Ball = this.image_6;  break;
                        default: b = Brushes.Black; Ball = this.image_6;  break;
                    }
                }
                else
                {
                    switch (status)
                    {
                        case 0: b = Brushes.Purple; Ball = this.image_8; break;
                        case 1: b = Brushes.Brown; Ball = this.image_9; break;
                        case 3: b = Brushes.Purple; Ball = this.image_6;  break;
                        default: b = Brushes.Purple; Ball = this.image_6;  break;
                    }
                }
                #endregion Codex Brush
            }
                

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Graphics gfx = e.Graphics;

                //Pen pen = new Pen(Brushes.SteelBlue, 0.4f);
                Pen pen = new Pen(Brushes.LightGray, 0.4f);

                //gfx.DrawImage();
                gfx.DrawImage(Ball, e.Bounds.X + 1, e.Bounds.Y + 1);
         
                gfx.DrawRectangle(pen, e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);
                
                //gfx.DrawImage(image1, e.Bounds.X+2, e.Bounds.Y+2, e.Bounds.Width-2, e.Bounds.Height - 2);
                gfx.DrawImage(image1, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 1);
                //gfx.FillRectangle(Brushes.LightSteelBlue, e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 3, e.Bounds.Height - 3);

                gfx.DrawImage(Ball, e.Bounds.X + 1, e.Bounds.Y + 1);
                gfx.DrawString(xcaption, nfont, b, e.Bounds.X + leftMargines+16+2, e.Bounds.Y + topMargines);

                SizeF f11 = gfx.MeasureString(xcaption, nfont);

            }
            else
            {
                Graphics gfx = e.Graphics;
                Pen pen = new Pen(Brushes.LightGray, 0.4f);

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
            
            OnDocumentClick(new LinkListEventArgs((int)DataSource[this.listBox1.SelectedIndex][LinkToField],DataSource[this.listBox1.SelectedIndex][CaptionField].ToString()));
            
            
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