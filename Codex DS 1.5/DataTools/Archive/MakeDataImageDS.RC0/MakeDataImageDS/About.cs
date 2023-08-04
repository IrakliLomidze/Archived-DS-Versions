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
        }

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codex.ge"); 
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {

        }
    }
}