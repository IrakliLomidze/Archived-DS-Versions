using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4.Configurations
{
    public partial class DSProfileSelector : Form
    {
        public DSProfileSelector()
        {
            InitializeComponent();
            SuspendLayout();
            int h = TopPanel.Height + dataGridView1.Height + CloseButton.Height + (CloseButton.Height / 2) + (CloseButton.Height / 2);
            int w = ConfiguraitonTop_ICON.Margin.Left + ConfiguraitonTop_ICON.Size.Width + ConfiguraitonTop_ICON.Margin.Right +
                    ConfiguraitonTop_Label.Width + ConfiguraitonTop_ICON.Size.Width;
            this.ClientSize = new System.Drawing.Size(w, h);
            Select_Button.Left = w - Select_Button.Width - 16;
            Select_Button.Top = w - CloseButton.Height - CloseButton.Height / 2;
            CloseButton.Left = Select_Button.Left - Select_Button.Width - 8;
            Select_Button.Top = CloseButton.Top;
            ResumeLayout();

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Codex_Search_Button_Click(object sender, EventArgs e)
        {

        }

        private void DSProfileSelector_Load(object sender, EventArgs e)
        {
        }
    }
}
