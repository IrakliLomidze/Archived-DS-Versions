using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ILG.Codex.SearchTxListBox
{

    public class SearchTxListBoxEventArgs : System.EventArgs
    {
        public int Position_In_Document;
        public int Position_In_Paragraph;
        public int Seleciton_Length;
        public String Text;
        public SearchTxListBoxEventArgs(int Position_In_Document,int Position_In_Paragraph,int Seleciton_Length,String Text)
        {
            this.Position_In_Document = Position_In_Document;
            this.Position_In_Paragraph = Position_In_Paragraph;
            this.Seleciton_Length = Seleciton_Length;
            this.Text = Text;
        }
    }

    public delegate void CallDocumentHistoryEventHandler(object sender, SearchTxListBoxEventArgs e);
    
    public partial class SearchTxListBox : UserControl
    {
        public List<SearchTxListBoxEventArgs> DataSource;

        public SearchTxListBox()
        {
            InitializeComponent();
        }

        public event CallDocumentHistoryEventHandler DocumentClick;


        protected virtual void OnDocumentClick(SearchTxListBoxEventArgs e)
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
        
            
            LWithSize =  listBox1.ClientSize.Width;

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
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.SuspendLayout();
            this.listBox1.BeginUpdate();
            this.LWithSize = listBox1.ClientSize.Width;
            this.listBox1.HorizontalExtent = this.LWithSize;
            this.listBox1.Enabled = false;
            //this.listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            this.listBox1.SelectionMode = SelectionMode.One;
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

            string xcaption = @DataSource[e.Index].Text.Trim();
            SizeF f1 = gfx.MeasureString(xcaption, nfont);
            e.ItemHeight = topMargines + (int)f1.Height + distance;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            

            int number = e.Index;
            if (e.Index < 0) return;

            string xcaption = @DataSource[e.Index].Text.Trim();
            
            Brush b = new SolidBrush(Color.FromArgb(30, 57, 91));
            
            
            b = new SolidBrush(Color.FromArgb(30, 57, 91));
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Graphics gfx = e.Graphics;

                Pen pen = new Pen(Color.FromArgb(224, 239, 255), 0.4f); //Brushes.LightGray, 0.4f);

               
                gfx.DrawRectangle(pen, e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);

                Pen PenX3 = new Pen(Color.FromArgb(0x7d, 0xa2, 0xce), 1);
                gfx.DrawRectangle(PenX3, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2));
            
                gfx.DrawString(xcaption, nfont, b, e.Bounds.X + leftMargines+16+2, e.Bounds.Y + topMargines);

                SizeF f11 = gfx.MeasureString(xcaption, nfont);

            }
            else
            {
                Graphics gfx = e.Graphics;
                Pen pen = new Pen(Color.FromArgb(224, 239, 255), 0.4f);  
            
                gfx.FillRectangle(Brushes.White, e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 1, e.Bounds.Height - 1);
                gfx.DrawLine(pen, e.Bounds.X + 1, e.Bounds.Y + e.Bounds.Height - 3, e.Bounds.Width - 2, e.Bounds.Y + e.Bounds.Height - 3);

                gfx.DrawString(xcaption, nfont, b, e.Bounds.X + leftMargines+16+2, e.Bounds.Y + topMargines);

                
                Rectangle Rect2 = new Rectangle(0, 0, 100, 100);
                TextFormatFlags flg = TextFormatFlags.WordBreak;
                TextBoxRenderer.DrawTextBox(gfx.e);
            }



            //e.DrawFocusRectangle();


        }


        private void DoVisited()
        {
            if (listBox1.Items.Count == 0) return;
            int id = (int)DataSource[this.listBox1.SelectedIndex][LinkToField]; ;
            
            OnDocumentClick(new HistoryListEventArgs((int)DataSource[this.listBox1.SelectedIndex][LinkToField]));
            
            
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

        


    }
}