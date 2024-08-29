using System;
using System.Reflection;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{
    public partial class AboutDS : Form
    {
        public AboutDS()
        {
            InitializeComponent();
        }

        private void ultraTabPageControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            
            TopImage.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(TopImage.Width, this.ClientSize.Height);
            String s = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            Label_Version_And_Build.Text = "Build: "+s;
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