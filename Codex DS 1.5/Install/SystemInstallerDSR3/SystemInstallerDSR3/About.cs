using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
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
            this.ProductList.Text = "Codex DS (Document Storage) v 1.5";

            TopImage.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(TopImage.Width, this.ClientSize.Height);
            
        }

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codex.ge"); 
        }

       
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}