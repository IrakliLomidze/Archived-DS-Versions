using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{
    public partial class ZoomingDialog : Form
    {
        public int CurrentZoom;

        public ZoomingDialog()
        {
            InitializeComponent();
        }

        private void ZoomingDialog_Load(object sender, EventArgs e)
        {
            ultraNumericEditor1.Value = CurrentZoom;
        }


        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (this.ultraOptionSet1.CheckedIndex == 6)
            {
                CurrentZoom = -20;
                return;
            }

            if (this.ultraOptionSet1.CheckedIndex == 7)
            {
                CurrentZoom = -10;
                return;
            }

            if ((this.ultraOptionSet1.CheckedIndex >= 0) && (this.ultraOptionSet1.CheckedIndex < 5))
            {
                int i = -20;
                try
                {
                    i = Int32.Parse(this.ultraOptionSet1.Value.ToString());
                }
                catch
                {
                    i = -20;
                }
                if (i >= 0) CurrentZoom = i;
                return;
            }

            if (this.ultraOptionSet1.CheckedIndex == 5)
            {
                int i = CurrentZoom;
                try
                {
                    i = Int32.Parse(this.ultraNumericEditor1.Value.ToString());
                }
                catch
                {
                    i = CurrentZoom;
                }
                if (i >= 0) CurrentZoom = i;
            
            }
        }


        
    }
}
