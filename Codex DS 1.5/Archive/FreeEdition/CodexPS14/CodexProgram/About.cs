using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ILG.Codex.Codex2007
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void ultraTabPageControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(ILG.Codex.Codex2007.Properties.Resources.bullet_triangle_glass_blue);
            this.imageList1.Images.Add(ILG.Codex.Codex2007.Properties.Resources.bullet_triangle_glass_green);
            this.imageList1.Images.Add(ILG.Codex.Codex2007.Properties.Resources.bullet_triangle_glass_red);
            this.imageList1.Images.Add(ILG.Codex.Codex2007.Properties.Resources.bullet_triangle_glass_grey);
            this.imageList1.Images.Add(ILG.Codex.Codex2007.Properties.Resources.bullet_triangle_glass_yellow);
            this.listView1.SmallImageList = imageList1;
            
                      
            listView1.Items.Clear();
            listView1.Items.Add("დოკუმენტების ძებნა", 0);
            listView1.Items.Add("დოკუმენტების დათვალიერება", 0);
            listView1.Items.Add("დოკუმენტების  კოპირება, ბეჭდვა", 4);
            listView1.Items.Add("დოკუმენტებზე ოპერირებაა", 3);
            listView1.Items.Add("სრული უფლებები სისტემაში", 3);
            

        }

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codexserver.com"); 
        }
    }
}