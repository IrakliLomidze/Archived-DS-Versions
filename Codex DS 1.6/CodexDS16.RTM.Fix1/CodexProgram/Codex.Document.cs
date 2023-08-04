using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
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
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
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

        private void CodexLinkBox_DocumentClick(object sender, ILG.Codex.CodexDSLinkListBox.CodexDSLinkListEventArgs e)
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

 

        public void ViewLayout(int CodexViewLayout)
        {

            if (CodexViewLayout == 0)
            {
                textControl_Codex.ViewMode = TXTextControl.ViewMode.PageView;
                MainForm.CodexViewLayout = 0;
            }
            else
            {
                textControl_Codex.ViewMode = TXTextControl.ViewMode.Normal;
                MainForm.CodexViewLayout = 1;
            }
        }

        private void CodexDocumentStatusBar_ButtonClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelEventArgs e)
        {
        }

        private void ultraDockManager1_AfterDockChange(object sender, Infragistics.Win.UltraWinDock.PaneEventArgs e)
        {
            MainForm.ZoomingCodex();
        }

        private void Form_Codex_Document_FormClosed(object sender, FormClosedEventArgs e)
        {
            axAcroPDF1.Dispose();
            axAcroPDF1 = null;

        }

        private void BacktoOriginalDocument_Click(object sender, EventArgs e)
        {
            MainForm.BackToOriginalDocument();
        }
    }
}