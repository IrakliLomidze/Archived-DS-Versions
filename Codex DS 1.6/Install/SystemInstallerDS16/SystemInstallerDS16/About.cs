﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
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

            Label_Version_And_Build.Text = "Version 7.0 Buuld Number 7.2017.2017.9731";
            String s = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            Label_Version_And_Build.Text = "Build: " + s;

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