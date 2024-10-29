using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace ILG.DS.Profile
{
    public partial class Wizard : Form
    {

        public Wizard()
        {
            InitializeComponent();
        }

        private void Wizard_Load(object sender, EventArgs e)
        {

            String s = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.labelID.Text = $"DS 1.11 Profile Manager Build {s}";
            this.labelID.AutoSize = true;
              //  this.labelID.Left = panel1.Width - this.labelID.Width - 8 ;
            ultraTabControl1.Height = this.ClientSize.Height - ultraTabControl1.Top;
            
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            Wizard_Form1 Form1 = new Wizard_Form1();
            Form1.ShowDialog();
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            Wizard_Form2 Form2 = new Wizard_Form2();
            Form2.ShowDialog();
        }
        
    }
}
