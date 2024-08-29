using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ILG.Codex.CodexR4;
using ILG.DS.Strings;


namespace ILG.Codex.CodexR4
{
    partial class Form1
    {

        #region PopUpMenus
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("Keyboard3", this);
        }

        private void Keboard4Popup_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("Keyboard4", this);
        }

        private void CodexDateRange_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("Codex_Date_Range", this);
        }

        private void CGLDateRange_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("CGL_Date_Range", this);
        }

       
        private void CodexFind_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("Codex_Find_PopUp", this);
        }

        private void CGLFind_Opening(object sender, CancelEventArgs e)
        {
            this.CodexToolBar.ShowPopup("CGL_Find_PopUp", this);
        }

       



        #endregion PopUpMenus

       

        #region List Pickers
        private void Codex_Autor_Button_Click(object sender, EventArgs e)
        {

            
        }

        private void Codex_Type_Button_Click(object sender, EventArgs e)
        {
           
        }

        private void Codex_Subject_Button_Click(object sender, EventArgs e)
        {
            
        }

        private void Codex_Word_Button_Click(object sender, EventArgs e)
        {

            
        }


        private void Codex_Category_Button_Click(object sender, EventArgs e)
        {
            
        }

        private void Codex_Status_Button_Click(object sender, EventArgs e)
        {
            
        }

        
        #endregion List Pickers

        private void Codex_Number_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
            //if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar <= ' ') || (e.KeyChar == '-') || (e.KeyChar == ',')) e.Handled = false;
            e.KeyChar = ILG.Codex.CodexR4.KeyBoard.Layout.U[e.KeyChar];
        }

    




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (ForceExit == true) e.Cancel = false;
            else
            {
                if (Windows.Forms.ILGMessageBox.Show("პროგრამიდან გამოსვლა,\nდარწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HomeClick();
                    e.Cancel = false;
                }
                else e.Cancel = true;
            }
        }

        

    
        
        #region HotKeys Codex
        private void Codex_Date_Edit1_KeyUp(object sender, KeyEventArgs e)
        {
           

        }

    


        private void Codex_Search_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        

        private void Codex_Attrib_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void Codex_Comment_Edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        #endregion HotKeys Codex

    }
}