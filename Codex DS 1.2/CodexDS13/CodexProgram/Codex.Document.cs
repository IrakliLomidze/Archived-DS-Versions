using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ILG.Codex.Codex2007
{
    public partial class Form_Codex_Document : Form
    {
        public Form1 MainForm;

        public Form_Codex_Document()
        {
            InitializeComponent();
        }

        private void CodexInText_TextChanged(object sender, EventArgs e)
        {
            MainForm.CodexInText_TextChanged(sender, e);
        }

        private void CodexInText_KeyUp(object sender, KeyEventArgs e)
        {
            MainForm.CodexInText_KeyUp(sender, e);
        }

        private void CodexInText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = ILG.Codex.KeyBoard.Layout.U[e.KeyChar];
        }

        private void CodexSerachInCheck_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.CodexSerachInCheck_CheckedChanged(sender, e);
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            MainForm.ultraButton1_Click(sender, e);
        }

        private void textControl_Codex_InputPositionChanged(object sender, EventArgs e)
        {
            MainForm.textControl_Codex_InputPositionChanged(sender, e);
        }

        private void CodexLinkBox_DocumentClick(object sender, ILG.Codex.LinkListBox.LinkListEventArgs e)
        {
            MainForm.CodexLinkBox_DocumentClick(sender, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            MainForm.CodexToolBar.ShowPopup("DocumenPopUp"); 
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            MainForm.CodexToolBar.ShowPopup("Keyboard3"); 
        }

        private void contextMenuStrip3_Opening(object sender, CancelEventArgs e)
        {
            MainForm.CodexToolBar.ShowPopup("LinkPopUp"); 
        }

        private void contextMenuStrip4_Opening(object sender, CancelEventArgs e)
        {
            // 

            MainForm.CodexToolBar.ShowPopup("Attachment"); 
        }

        private void ultraTrackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.CodexZoomFactor = textControl_Codex.ZoomFactor;
        }

        private void ultraTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (MainForm.CodexZoomFactor < 0) return;
            MainForm.modify_zoomfactor(this.ultraTrackBar1.Value);
        }

        public void ViewLayout(int CodexViewLayout)
        {

            if (CodexViewLayout == 0)
            {
                textControl_Codex.ViewMode = TXTextControl.ViewMode.PageView;
                MainForm.CodexViewLayout = 0;
                this.CodexDocumentStatusBar.ButtonClick -= new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.CodexDocumentStatusBar_ButtonClick);
                try
                {
                    CodexDocumentStatusBar.Panels["PageLayout"].Checked = true;
                    CodexDocumentStatusBar.Panels["WebLayout"].Checked = false;
                }
                finally
                {
                    this.CodexDocumentStatusBar.ButtonClick += new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.CodexDocumentStatusBar_ButtonClick);
                }

            }
            else
            {
                textControl_Codex.ViewMode = TXTextControl.ViewMode.Normal;
                MainForm.CodexViewLayout = 1;
                this.CodexDocumentStatusBar.ButtonClick -= new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.CodexDocumentStatusBar_ButtonClick);
                try
                {
                    CodexDocumentStatusBar.Panels["PageLayout"].Checked = false;
                    CodexDocumentStatusBar.Panels["WebLayout"].Checked = true;
                }
                finally
                {
                    this.CodexDocumentStatusBar.ButtonClick += new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.CodexDocumentStatusBar_ButtonClick);
                }
            }
        }

        private void CodexDocumentStatusBar_ButtonClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelEventArgs e)
        {
            if (e.Panel.Key.ToUpper() == "Zoom".ToUpper())
            {
                ZoomingDialog zd1 = new ZoomingDialog();
                zd1.CurrentZoom = this.textControl_Codex.ZoomFactor;
                if (zd1.ShowDialog() == DialogResult.OK)
                {

                    MainForm.CodexZoomFactor = zd1.CurrentZoom;
                    MainForm.ZoomingCodex();
                    return;
                }
            }

            if (e.Panel.Key.ToUpper() == "WebLayout".ToUpper())
            {
                ViewLayout(1);
                return;
            }


            if (e.Panel.Key.ToUpper() == "PageLayout".ToUpper())
            {
                ViewLayout(0);
                return;
            }
        }

        private void ultraDockManager1_AfterDockChange(object sender, Infragistics.Win.UltraWinDock.PaneEventArgs e)
        {
            MainForm.ZoomingCodex();
        }
    }
}