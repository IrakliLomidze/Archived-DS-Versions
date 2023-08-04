using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ILG.Codex.CodexListBox
{

    public class CodexListEventArgs : System.EventArgs
    {
        public int _ID;
        public string _TCaption;
        public string _DCaption;

        public CodexListEventArgs(int ID, string TCaption, string DCaption)
        {
            this._ID = ID;
            this._TCaption = TCaption;
            this._DCaption = DCaption;
        }
    }

    public delegate void CallDocumentEventHandler(object sender, CodexListEventArgs e);
    
    public partial class CodexListBox : UserControl
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
        public bool usestatus;


        Bitmap image1;
        Bitmap image2;
        Bitmap image5;
        Bitmap image3;
        Bitmap image6;

        Bitmap image_Acro;
        Bitmap image_Word;
        Bitmap image_Icon;
        Bitmap image_Attach;
        Bitmap image_Unknown;
        // A delegate type for hooking up change notifications.

        
       
        public CodexListBox()
        {
            InitializeComponent();
        }

        public event CallDocumentEventHandler DocumentClick;

 
         protected virtual void OnDocumentClick(CodexListEventArgs e)
         {
             DocumentClick(this, e);
         }


        public void InitializeVarialbles(int Varialbe)
        {

            
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
            image1 = new Bitmap(f.pictureBox1.Image);//@"C:\1\1.bmp");
            image2 = new Bitmap(f.pictureBox2.Image);
            image5 = new Bitmap(f.pictureBox5.Image);
            image3 = new Bitmap(f.pictureBox3.Image);
            image6 = new Bitmap(f.pictureBox6.Image);

            image_Acro = new Bitmap(f.Acro_Pic.Image);
            image_Word = new Bitmap(f.Word_Pic.Image);
            image_Icon = new Bitmap(f.Word_Pic.Image);
            image_Unknown = new Bitmap(f.pictureBox9.Image);
            image_Attach = new Bitmap(f.pictureBox8.Image);

            switch (Varialbe)
            {
                case 2: // Codex
                    {
                        DCaptionField = "C_Caption";
                        TCaptionField = "TopCaption";
                        StatusField   = "C_Group";
                        IDField = "C_ID";
                        usestatus = true;
                    }
                    break;

                case 1: // CGL
                    {
                        DCaptionField = "C_Caption";
                        TCaptionField = "TopCaption";
                        StatusField = "C_Group";
                        IDField = "C_ID";
                        usestatus = true;
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


            Rectangle rect = new Rectangle(leftMargines + (int)f1.Width + 8 + image_Word.Width+4, topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8, e.ItemHeight);
            StringFormat stf = new StringFormat();
            stf.FormatFlags = StringFormatFlags.FitBlackBox;
            SizeF f2 = gfx.MeasureString(dtext, tfont, rect.Width, stf);
            int Temp = e.ItemWidth;
            if (f2.Width < (leftMargines + f1.Width + 8 + f11.Width)) Temp = leftMargines + (int)f1.Width + 8 + (int)f11.Width + 4;
            e.ItemHeight = topMargines + (int)f1.Height + distance + (int)f2.Height + 8 + 8;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            this.listBox1.SuspendLayout();
            int number = e.Index + 1;
            int statusLine = (int)DataSource[e.Index][StatusField];
            string statusString = "";
            
            if (usestatus == true)
            {
                switch (statusLine)
                {
                    case 0: statusString = ""; break;
                    case 1: statusString = " [კონფიდენციალური]"; break;
                    default: statusString = ""; break;
                }
            }


            
            string xcaption = DataSource[e.Index][TCaptionField].ToString() + statusString;//+ "  "+statusLine.ToString();
            string dtext = @DataSource[e.Index][DCaptionField].ToString();
            int ind = (int)DataSource[e.Index][IDField];
            if ((int)DataSource[e.Index]["C_DocFormat"] == 0)
            {
                image_Icon = image_Word;

            }
            //ISNULL(DATALENGTH(C_Attach),0) as L_AttachmentSize
            int hasattach = 0;
            
            //MessageBox.Show(DataSource[e.Index]["L_AttachmentSize"].ToString());
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

            if ((int)DataSource[e.Index]["C_DocFormat"] == 1)
            {
                image_Icon = image_Acro;

            }

            if ((int)DataSource[e.Index]["C_DocFormat"] > 1)
            {
                image_Icon = image_Unknown; 
            }



            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Graphics gfx = e.Graphics;

                Pen pen = new Pen(Brushes.SteelBlue, 0.4f);
                Pen pen2 = new Pen(Brushes.LightGray, 0.4f);
                Pen pen3 = new Pen(Brushes.LightGreen, 0.4f);


                gfx.DrawImage(image1, e.Bounds.X , e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - 1);

                


                //gfx.DrawString(number.ToString() + ".", nfont, Brushes.Black, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines);
                gfx.DrawString(number.ToString() + ".", nfont, Brushes.Black, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines-6);
                SizeF f1 = gfx.MeasureString(number.ToString() + ".", nfont);

                if ((usestatus == true))
                {
                    if (statusLine == 1)
                    {
                        // Codified
                        gfx.DrawImage(image2, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);

                        if (hasattach != 0)
                        gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines+2+image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);
                        //gfx.DrawString(xcaption, captionfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8 + image2.Width + 2, e.Bounds.Y + topMargines);
                        gfx.DrawString(xcaption, captionfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8 + image2.Width + 2, e.Bounds.Y + topMargines);
                    }
                    else
                    {
                        // Original
                        gfx.DrawImage(image5, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);
                        gfx.DrawString(xcaption, captionfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8 + image2.Width + 2, e.Bounds.Y + topMargines);

                        if (hasattach != 0)
                            gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);

                    }
                }
                else
                {
                    gfx.DrawImage(image3, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                    gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);
                    gfx.DrawString(xcaption, captionfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8 + image2.Width + 2, e.Bounds.Y + topMargines);

                    if (hasattach != 0)
                        gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);
                        
                }
                //gfx.DrawString(xcaption, nfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines);
                SizeF f11 = gfx.MeasureString(xcaption, captionfont);

                Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8   +image_Word.Width+4, e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8, this.ClientSize.Height);
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

                if (Visited.Rows.Contains(new object[] { ind }) == false)
                { gfx.DrawString(dtext, tfont, Brushes.Black, rect, stf);
                  
                }
                else
                { gfx.DrawString(dtext, tfont, Brushes.Purple, rect, stf);
                  //gfx.DrawImage(image6, e.Bounds.X +8, e.Bounds.Y + topMargines + f1.Height + 4);
                  gfx.DrawImage(image6, e.Bounds.X + 8, e.Bounds.Y + topMargines + f1.Height-6);
                }

            }
            else
            {
                Graphics gfx = e.Graphics;


                gfx.FillRectangle(Brushes.White, e.Bounds.X , e.Bounds.Y , e.Bounds.Width , e.Bounds.Height );
                
                gfx.FillRectangle(Brushes.LightGray, e.Bounds.X + 4, e.Bounds.Y + e.Bounds.Height -1, e.Bounds.Width - 8, 1);

                Pen pen = new Pen(Brushes.SteelBlue, 0.4f);

                //gfx.DrawString(number.ToString() + ".", nfont, Brushes.Black, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines);
                gfx.DrawString(number.ToString() + ".", nfont, Brushes.Black, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines-6);

                SizeF f1 = gfx.MeasureString(number.ToString() + ".", nfont);

                if ((usestatus == true))
                {
                    if (statusLine == 1)
                    {
                        // Codified
                           gfx.DrawImage(image2, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                           gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);
                           gfx.DrawString(xcaption, captionfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8 + image2.Width + 2, e.Bounds.Y + topMargines);
                        
                        if (hasattach != 0)
                               gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);
                        
                    }
                    else
                    {
                        // Original
                        SizeF f111 = gfx.MeasureString(xcaption, captionfont);

                        gfx.DrawImage(image5, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                        gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines,e.Bounds.Y + topMargines + f1.Height -6 + image6.Height+8);

                        if (hasattach != 0)
                        gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);



                        gfx.DrawString(xcaption, captionfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8 + image2.Width + 2, e.Bounds.Y + topMargines);
                    }
                }
                else
                {
                    gfx.DrawImage(image3, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines - 6);
                    gfx.DrawImage(image_Icon, e.Bounds.X + leftMargines, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);

                    if (hasattach != 0)
                    gfx.DrawImage(image_Attach, e.Bounds.X + leftMargines + 2 + image_Icon.Width, e.Bounds.Y + topMargines + f1.Height - 6 + image6.Height + 8);

                    
                    gfx.DrawString(xcaption, captionfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8 + image2.Width + 2, e.Bounds.Y + topMargines);
                }                //                gfx.DrawString(xcaption, nfont, Brushes.SteelBlue, e.Bounds.X + leftMargines + f1.Width + 8, e.Bounds.Y + topMargines);
                SizeF f11 = gfx.MeasureString(xcaption, captionfont);

                Rectangle rect = new Rectangle(e.Bounds.X + leftMargines + (int)f1.Width + 8 + image_Word.Width + 4, e.Bounds.Y + topMargines + (int)f1.Height + distance, this.LWithSize - leftMargines - (int)f1.Width - 8, this.ClientSize.Height);
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

                if (Visited.Rows.Contains(new object[] { ind }) == false)
                { gfx.DrawString(dtext, tfont, Brushes.Black, rect, stf); }
                else
                { gfx.DrawString(dtext, tfont, Brushes.Purple, rect, stf);
                  gfx.DrawImage(image6, e.Bounds.X + 8, e.Bounds.Y + topMargines + f1.Height - 6);
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
            //MessageBox.Show(id.ToString());
            //MessageBox.Show(DataSource[this.listBox1.SelectedIndex][TCaptionField].ToString());
            OnDocumentClick(new CodexListEventArgs(id,DataSource[this.listBox1.SelectedIndex][TCaptionField].ToString(),DataSource[this.listBox1.SelectedIndex][DCaptionField].ToString()));
            
            
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