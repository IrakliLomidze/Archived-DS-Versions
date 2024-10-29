using ILG.Codex.CodexR4;
using ILG.DS.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILG.DS.Dialogs
{
    public partial class SearchInText : Form
    {

        // private fields
        private TXTextControl.TextControl tx;
        private int selStart = 0;
        private int selLength = 0;
        private TXTextControl.FindOptions findOptions;
        private CodexFondGoDialogMode CurrentMode;

        public enum CodexFondGoDialogMode
        {
            FindInText,
            GoInText
        }
    
    
    
        private void setOptions()
        {
            // fill the FindReplaceOptions object to store the settings
            lblOptions.Text = "   ";
            
            //cmbDirection.
            if (cmbDirection.SelectedIndex == 0) lblOptions.Text += "ძებნა ქვევით, ";
            if (cmbDirection.SelectedIndex == 1) lblOptions.Text += "ძებნა ზევით, ";

            if (cbMatchCase.Checked == true) lblOptions.Text += "განასხვავე რეგისტრი, ";

            lblOptions.Text = lblOptions.Text.Remove(lblOptions.Text.Length - 2, 2).Trim();

        }

        public SearchInText(TXTextControl.TextControl TextControl,String CodexEncoding,CodexFondGoDialogMode Mode)
        {
            tx = TextControl;
            tx.HideSelection = false;

            selStart = tx.Selection.Start;

            if (tx.Selection.Length > 0)
                selLength = tx.Selection.Length;

            InitializeComponent();
            DocumentEncoding = CodexEncoding;
            CurrentMode = Mode; 
            setOptions();
        }

        
        private void cbMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            // adjust the search settings for match case
            if (cbMatchCase.Checked == true)
                findOptions |= TXTextControl.FindOptions.MatchCase;
            else
                findOptions -= TXTextControl.FindOptions.MatchCase;

            setOptions();

        }

        

   

   
        private void cmbDirection_ValueChanged(object sender, EventArgs e)
        {
            
            switch (cmbDirection.SelectedIndex)
            {
                case 0:
                    findOptions -= TXTextControl.FindOptions.Reverse;
                    break;
                case 1:
                    findOptions |= TXTextControl.FindOptions.Reverse;
                    break;
            }

            setOptions();
        }



        int _forHeight;
        int _formWidth;
        private void SearchInText_Load(object sender, EventArgs e)
        {
            // Control Arragment
            FindLabel.Left = 8;
            FindLabel.Top = 8;

            cbSearchString.Left = FindLabel.Left + FindLabel.Width + 8;
            cbSearchString.Top = FindLabel.Top - (cbSearchString.Height - FindLabel.Height) / 2;
            _formWidth = cbSearchString.Left + cbSearchString.Width + 12;

            OptionLabel.Left = 8;
            OptionLabel.Top = cbSearchString.Top + cbSearchString.Height + 12;


            lblOptions.Left = OptionLabel.Left + OptionLabel.Width + 12;
            lblOptions.Top = OptionLabel.Top;
            lblOptions.Text = "";

            
            ultraButton3.Top = lblOptions.Top;
            ultraButton3.Left = cbSearchString.Left + cbSearchString.Width - ultraButton3.Width;

            ultraButton2.Top = lblOptions.Top;
            ultraButton2.Left = ultraButton3.Left - 8 - ultraButton2.Width;

           
            lblGroupSeachOptions.Left = 8;
            lblGroupSeachOptions.Top = ultraButton2.Top + ultraButton2.Height + 8;
            Line1.Top = lblGroupSeachOptions.Top + lblGroupSeachOptions.Height / 2;
            Line1.Width = cbSearchString.Left + cbSearchString.Width - lblGroupSeachOptions.Width - 8;

            ultraLabel1.Top = lblGroupSeachOptions.Top + lblGroupSeachOptions.Height + 12;
            ultraLabel1.Left = 8;

            cmbDirection.Left = ultraLabel1.Left + ultraLabel1.Width + 8;
            cmbDirection.Top = ultraLabel1.Top - (cmbDirection.Height - ultraLabel1.Height) / 2;
            cmbDirection.SelectedIndex = 0;

            TextFindCombo.Left = cmbDirection.Left + cmbDirection.Width + 8;
            TextFindCombo.Top = cmbDirection.Top;
            TextFindCombo.SelectedIndex = 0;

            //cbMatchCase.Top = cmbDirection.Top + cmbDirection.Height + 8;
            //cbMatchCase.Left = 8;





            cbMatchCase.Top = ultraLabel1.Top;// ultraCheckEditor1.Top;
            cbMatchCase.Left = cbSearchString.Left + cbSearchString.Width - cbMatchCase.Width;

            _forHeight = cbMatchCase.Top + cbMatchCase.Height + 12 + 24;




            ClientSize = new Size(_formWidth, _forHeight);


            GOLabel.Left = 8;
            GOLabel.Top = 8;
            GoListBox.Left = 8;
            GoListBox.Top = GOLabel.Top + GOLabel.Height + 8;
            GoListBox.Height = cmbDirection.Top + cmbDirection.Height - GoListBox.Top; 
            GoEdit.Top = GoListBox.Top;
            GoEdit.Left = GoListBox.Left + GoListBox.Width + 8;

            GoEdit.Width = cbSearchString.Left + cbSearchString.Width - GoEdit.Left;

            GoCloseButton.Left = GoEdit.Left + GoEdit.Width - GoCloseButton.Width;
            GoCloseButton.Top = GoListBox.Top + GoListBox.Height - GoCloseButton.Height;

            GoButton.Top = GoCloseButton.Top;
            GoButton.Left = GoCloseButton.Left - 8 - GoCloseButton.Width;

            
            GoListBox.SelectedIndex = 0;


            if (CurrentMode == CodexFondGoDialogMode.GoInText) MainTabs.SelectedTab = MainTabs.Tabs[1];
            else MainTabs.SelectedTab = MainTabs.Tabs[0];
            //updateStrings();
            
            // SetForm to Long
            
        }

        string searchString;
        string searchText;

        int findpostion = 0;
        bool isfff = false;
        string DocumentEncoding;
        public char ConvertGeoUnitoGeo8(char c)
        {

            int code = Convert.ToInt16(c);

            if ((code >= 0x10d0) && (code <= 0x10d6)) return Convert.ToChar((code - 0x10d0) + 0xc0);
            if (code == 0x10f1) return Convert.ToChar(0xc7);
            if ((code >= 0x10d7) && (code <= 0x10dc)) return Convert.ToChar((code - 0x10d7) + 0xc8);
            if (code == 0x10f2) return Convert.ToChar(0xce);
            if ((code >= 0x10dd) && (code <= 0x10e2)) return Convert.ToChar((code - 0x10dd) + 0xcf);
            if (code == 0x10f3) return Convert.ToChar(0xd5);
            if ((code >= 0x10e3) && (code <= 0x10ee)) return Convert.ToChar((code - 0x10e3) + 0xd6);
            if (code == 0x10f4) return Convert.ToChar(0xe2);
            if ((code >= 0x10ef) && (code <= 0x10f0)) return Convert.ToChar((code - 0x10ef) + 0xe3);
            if (code == 0x10f5) return Convert.ToChar(0xe5);
            if (code == 0x10f6) return Convert.ToChar(0xe6);
            else return '÷';

        }
        public string GeoUnitoGeo8(string str)
        {
            StringBuilder st = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if ((Convert.ToInt16(str[i]) >= 0x10D0) && (Convert.ToInt16(str[i]) <= 0x10FB))
                    st.Append(Convert.ToChar(this.ConvertGeoUnitoGeo8(str[i])));
                else st.Append(str[i]);

            }
            return st.ToString();

        }
        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (TextFindCombo.SelectedIndex == 1) findpostion = 0;
            string str = GeoUnitoGeo8(cbSearchString.Text.Trim());
            if (DocumentEncoding.Trim().ToUpper() == "UNICODE") str = cbSearchString.Text.Trim();
            findOptions |= TXTextControl.FindOptions.NoHighlight;
            findOptions |= TXTextControl.FindOptions.NoMessageBox;

            if (cmbDirection.SelectedIndex == 0) findpostion = tx.Find(str, findpostion + 1, TXTextControl.FindOptions.NoMessageBox | TXTextControl.FindOptions.MatchCase);
            else findpostion = tx.Find(str, findpostion, TXTextControl.FindOptions.NoMessageBox | TXTextControl.FindOptions.MatchCase | TXTextControl.FindOptions.Reverse);
            if (findpostion == -1)
            {
                if (isfff == true) ILGMessageBox.Show("ტექსტში '" + cbSearchString.Text.Trim() + "' მეტი არ მოიძებნა ");
                else ILGMessageBox.Show("ტექსტში '" + cbSearchString.Text.Trim() + "' არ მოიძებნა ");
                isfff = false;
            }
            else
            {
                isfff = true;
                TextFindCombo.SelectedIndex = 0;
            }


            saveString(searchString);
        }


        StringCollection SearchStrings = new StringCollection();
        private void saveString(string SearchString)
        {
            // save 10 entries in the application settings
            //ILG.Codex.CodexR4.Properties.Settings.Default.SearchStrings

            // Update #1
            //ILG.Codex.CodexR4.Properties.Settings s = new ILG.Codex.CodexR4.Properties.Settings();
            // Changed in Update 2

            

            StringCollection newCol;

            
            if (SearchStrings == null)
                newCol = new System.Collections.Specialized.StringCollection();
            else
                newCol = SearchStrings;

            if (newCol.Contains(SearchString))
                return;

            newCol.Insert(0, SearchString);

            // remove when more than 10
            if (newCol.Count > 10)
                newCol.RemoveAt(10);

           SearchStrings = newCol;
            
        }


        private void ultraButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSearchString_TextChanged(object sender, EventArgs e)
        {
            findpostion = tx.InputPosition.TextPosition;
            if (cbSearchString.Text == "") findpostion = 0;
            TextFindCombo.SelectedIndex = 1;
            isfff = false;
        }

        private void cbSearchString_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ultraButton2_Click(null, null);
        }

        private void cbSearchString_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = DSKeyboardLayout.U[e.KeyChar];

        }

        private void GoCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            int GoItem = -1;
            if (Int32.TryParse(GoEdit.Text, out GoItem) == false) return;
            if (GoItem < 0) return;
            #region Pages
            if (GoListBox.SelectedIndex == 0)  // Pages
            {
                if ((GoItem > 0)  && ( GoItem < tx.Pages ))
                {
                    TXTextControl.PageCollection pages = null;

                    try
                    {
                        pages = tx.GetPages();
                    }
                    catch //(Exception ex)
                    {
                        return;
                    }

                    tx.Selection.Start = pages[GoItem].Start - 1;
                    tx.ScrollLocation = new Point(tx.ScrollLocation.X, pages.GetItem().Bounds.Top);

                }

            }

            #endregion Pages

            #region Section
            if (GoListBox.SelectedIndex == 1)  // Pages
            {
                if ((GoItem > 0) && (GoItem < tx.Sections.Count))
                {
                    tx.Selection.Start = tx.Sections[GoItem].Start - 1;
                    tx.ScrollLocation = (tx.Sections.GetItem().Start <= tx.TextChars.Count) ?
                        new Point(tx.ScrollLocation.X, tx.TextChars[tx.Sections.GetItem().Start].Bounds.Top) :
                        new Point(tx.ScrollLocation.X, tx.Lines[tx.Lines.Count].TextBounds.Top);
                }

            }

            #endregion Seciotn

            #region Lines
            if (GoListBox.SelectedIndex == 2)  // Pages
            {
                if ((GoItem > 0) && (GoItem < tx.Lines.Count))
                {
                    tx.Selection.Start = tx.Lines[GoItem].Start - 1;
                    tx.ScrollLocation =   new Point(tx.ScrollLocation.X, tx.Lines[tx.Lines.Count].TextBounds.Top);
                }

            }

            #endregion Lines

            //#region Tables
            //if (GoListBox.SelectedIndex == 2)  // Pages
            //{
            //    if ((GoItem > 0) && (GoItem < tx.Tables.Count))
            //    {
            //        TXTextControl.TableCollection tables = null;

            //        tx.Selection.Start = tx.Tables.GetItem(GoItem).Cells.Columns[0]Start - 1;
            //        tx.ScrollLocation = new Point(tx.ScrollLocation.X, tx.Tables[tx.Tables.Count].TextBounds.Top);
            //    }

            //}

            //#endregion Tables
        }


        // Update 1

        public Form1 mainform;
        
        private void SearchInText_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                    #region Codex
                    {
                            //mainform.F_Codex_isFindWindows = false;
                    }
                    #endregion Codex

        }
    }
}
