﻿using System;
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
            this.ProductList.Text = "კოდექსი DS დოკუმენტების არქივი" ;

            Label_Version_And_Build.Text = "Version 7.0 Buuld Number 7.2017.2017.9731";

          
            
        }

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codex.ge"); 
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Label_Product_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}