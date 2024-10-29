using ILG.DS.Controls;
using ILG.DS.Controls.WPF;
using ILG.DS.Strings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TXTextControl;

namespace ILG.Codex.CodexR4
{
    public partial class Form_Codex_Document : Form
    {
        private readonly Form1 _mainFormRef;
        public string LoadedPDFDoc = "";
        private bool ShowDocumentForm = false;
        public Form_Codex_Document(Form1 mainFormRef)
        {
            _mainFormRef = mainFormRef;
            InitializeComponent();
            SearchCloseButton.Text = '\u2715'.ToString();
            CodexTextInSearchButton.Text = '\ue11a'.ToString();
            CodexTextInClearButton.Text = '\ue10a'.ToString();

            SearchUp.Text = '\ue018'.ToString();
            SearchDown.Text = '\ue019'.ToString();

            DocumentWithSearchSplitContainer.Panel1Collapsed = true;
            EnableSearchControls(false);
            SearchResultLabel.Text = "";
            Previous_Index = -1;
            ilTextListControl1.ClearItems();
            FindinDocResult = null;
            

        }

        // Search In Document
        #region Search In Open Document

        public class TXSearchResults
        {
            public String Left_Text;
            public String Right_Text;
            public Int32 General_Position;
            public Int32 Length;
        }

        const int _TXSearchDisplayLimit = 100;
        const int _TXSearchLimit = 200;

        List<TXSearchResults> FindinDocResult;

        int Previous_Index = -1;
        int Current_Index = -1;

        bool SearchIsLimited = false;
        bool SelectionMode = false;


        int PerformSearch(String Str)
        {
            if (Str.Trim() == "") return 0;
            if ((Str.Length < 3) && (textControl_Codex.Pages > 50))
            {
                if (ILGMessageBox.Show(this, "მოსაძებნი სტრიქონი არის ძალიან მოკლე," + System.Environment.NewLine +
                                                              "ძებნის შედეგი შესაძლებელია იყოს საკმაოდ დიდი" + System.Environment.NewLine +
                                                              "ძებნამ შეიძლება დაიკავოს უფრო მეტი დრო", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return 0;
            }
            Regex reg = new Regex(Str, RegexOptions.IgnoreCase);
            int Findresult = reg.Matches(textControl_Codex.Text).Count;

            SearchIsLimited = false;
            if (Findresult > _TXSearchLimit)
            {
                if (ILGMessageBox.Show(this, $"მოძებნილი შედეგების რაოდენობაა {Findresult}" + Environment.NewLine +
                                             $"სისტემა ზღუდავს შედეგების ერთდროულ დამუშავებას {_TXSearchLimit} ელემენტით" + Environment.NewLine +
                                             $"ეკრანზე გამოვა მხოლოდ პირველი  {_TXSearchLimit} შედეგი" + Environment.NewLine +
                                             $"ალტერნატივისთვის გამოიყენეთ ტექსტში გაფართოებული ძებნა", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return 0;
                SearchIsLimited = true;
            }

            if (FindinDocResult != null) PerfomHideHighligth();
            int codexfindpostion = 0;
            FindinDocResult = new List<TXSearchResults>();
            textControl_Codex.HideSelection = true;
            int Counter = 0;
            while (codexfindpostion != -1)
            {

                codexfindpostion = textControl_Codex.Find(Str, codexfindpostion, TXTextControl.FindOptions.NoMessageBox | TXTextControl.FindOptions.MatchCase | TXTextControl.FindOptions.NoHighlight);
                if (codexfindpostion == -1) break;


                String ParagraphText = textControl_Codex.Paragraphs.GetItem(codexfindpostion).Text;
                int _PositionInParagraph = codexfindpostion - textControl_Codex.Paragraphs.GetItem(codexfindpostion).Start;
                if (_PositionInParagraph < 0) _PositionInParagraph = 0;


                int SelectedMargines = 42;
                int LeftMargine = SelectedMargines;
                int RightMargine = SelectedMargines;

                if (LeftMargine > _PositionInParagraph) LeftMargine = _PositionInParagraph;
                if (RightMargine > Math.Abs(ParagraphText.Length - Str.Length)) RightMargine = Math.Abs(ParagraphText.Length - Str.Length);

                String LeftText = "";
                if (LeftMargine != 0)
                {
                    textControl_Codex.Select(codexfindpostion - LeftMargine, LeftMargine);
                    LeftText = textControl_Codex.Selection.Text;

                    if (LeftText.Length > _TXSearchDisplayLimit) LeftText = "";
                    if (_mainFormRef.DS_DocEncoding.Trim().ToUpper() != "UNICODE") LeftText = DSString.converttoGuni(LeftText);
                }
                String RightText = "";

                if (RightMargine != 0)
                {
                    textControl_Codex.Select(codexfindpostion + Str.Length, RightMargine);
                    RightText = textControl_Codex.Selection.Text;
                    if (RightText.Length > _TXSearchDisplayLimit) RightText = "";
                    if (_mainFormRef.DS_DocEncoding.Trim().ToUpper() != "UNICODE") RightText = DSString.converttoGuni(RightText);

                }


                //  textControl_Codex.Select(dsfindpostion - LeftMargine, LeftMargine + Str.Length + RightMargine);// textControl_Codex.InputPosition txpart.StartPosition - 10
                //  String ItemText = textControl_Codex.Selection.Text;

                FindinDocResult.Add(new TXSearchResults { Left_Text = LeftText, Right_Text = RightText, General_Position = codexfindpostion, Length = Str.Length });
                codexfindpostion++;
                Counter++;
                if (Counter >= _TXSearchLimit) codexfindpostion = -1;
            }

            if (FindinDocResult.Count == 0)
            {
                FindinDocResult = null;
                ilTextListControl1.ClearItems();
                return 0;
            }



            if (FindinDocResult.Count > _TXSearchDisplayLimit)
            {
                SelectionMode = false;
                ilTextListControl1.IsEnabled = false; ilTextListControl1.Visibility = System.Windows.Visibility.Hidden; elementHost1.Visible = false;
                SearchInfoLabel.Visible = true;
                SearchInfoLabel.Text = $"ძებნის შედეგები ({Findresult}) ძალიან დიდია, გამოიყენეთ ნავიგაციის ღილაკები ამ შეტყობინების ზევით. ან გამოიყენეთ დოკუმენტის ტექსტში გაფართოებული ძებნა, მოსაძებნი სიტყვის ტექსტური ველის ბოლო ღილაკის დაჭერით.";
            }
            else
            {
                SelectionMode = true;
                ilTextListControl1.IsEnabled = true; ilTextListControl1.Visibility = System.Windows.Visibility.Visible; elementHost1.Visible = true;
                SearchInfoLabel.Visible = false;
            }
            //listBox1.Items.Clear();
            ilTextListControl1.ClearItems();


            foreach (TXSearchResults txpart in FindinDocResult)
            {
                textControl_Codex.Select(txpart.General_Position, txpart.Length);
                textControl_Codex.Selection.TextBackColor = System.Drawing.Color.FromArgb(255, 238, 128);// Color.Yellow;

                if (ilTextListControl1.IsEnabled == true)
                {
                    String FindStr = Str;
                    if (_mainFormRef.DS_DocEncoding.Trim().ToUpper() != "UNICODE") FindStr = DSString.converttoGuni(FindStr);
                    ilTextListControl1.addILItem(txpart.Left_Text, FindStr, txpart.Right_Text);
                }

            }
            textControl_Codex.HideSelection = false;
            Current_Index = 0;
            return FindinDocResult.Count;

        }
        void PerfomHideHighligth()
        {
            if (FindinDocResult == null) return;

            textControl_Codex.HideSelection = true;
            foreach (TXSearchResults txpart in FindinDocResult)
            {
                textControl_Codex.Select(txpart.General_Position, txpart.Length);
                textControl_Codex.Selection.TextBackColor = Color.White;
            }
            textControl_Codex.HideSelection = false;

            return;
        }

        public void EnableSearchControls(bool enableValue)
        {
            CodexTextIn.Enabled = enableValue;
            SearchUp.Enabled = enableValue;
            SearchDown.Enabled = enableValue;
            CodexTextInClearButton.Enabled = enableValue;
            CodexTextInSearchButton.Enabled = enableValue;
        }


        private void FindClick()
        {
            String PerfomString = CodexTextIn.Text.Trim();
            if (_mainFormRef.DS_DocEncoding.Trim().ToUpper() != "UNICODE") PerfomString = DSString.GeoUnitoGeo8(PerfomString);


            int x = PerformSearch(PerfomString);
            if (x == 0) { SearchResultLabel.Text = "არ მოიძებნა"; return; }
            else
            {
                String Sub = "";
                if (SearchIsLimited == true) Sub = " ზე მეტი";
                SearchResultLabel.Text = "მოიძებნა " + x.ToString() + Sub + " შედეგი";
            }
            Previous_Index = -1;
            (this.elementHost1.Child as ILTextListControl).OnTXListSelectedItemChanged += OnTXListSelectedItemChanged;
            CodexTextInSearchButton.Visible = false;
            CodexTextInSearchButton.Enabled = false;
            CodexTextInClearButton.Visible = true;
            CodexTextInClearButton.Enabled = true;
            SearchDown.Visible = true; SearchDown.Enabled = true;
            SearchUp.Visible = true; SearchUp.Enabled = true;
        }

        public void ClearClick()
        {
            CodexTextIn.Focus();
            (this.elementHost1.Child as ILTextListControl).OnTXListSelectedItemChanged -= OnTXListSelectedItemChanged;
            PerfomHideHighligth();
            SearchResultLabel.Text = "";
            Previous_Index = -1;
            ilTextListControl1.ClearItems();
            FindinDocResult = null;
            CodexTextInSearchButton.Visible = true;
            CodexTextInSearchButton.Enabled = true;
            CodexTextInClearButton.Visible = false;
            CodexTextInClearButton.Enabled = false;
            SearchDown.Visible = false; SearchDown.Enabled = false;
            SearchUp.Visible = false; SearchUp.Enabled = false;

        }

        void SelectItem()
        {
            if (FindinDocResult == null) return;
            if (FindinDocResult.Count == 0) return;

            int c = Current_Index;
            c++;
            String Sub = "";
            if (SearchIsLimited == true) Sub = " >";

            this.SearchResultLabel.Text = "შედეგი " + c.ToString() + " - " + FindinDocResult.Count.ToString() + Sub + " დან";

            if (Previous_Index != -1)
            {
                int oldpos = FindinDocResult[Previous_Index].General_Position;
                textControl_Codex.Select(oldpos, FindinDocResult[Previous_Index].Length);
                textControl_Codex.Selection.TextBackColor = System.Drawing.Color.FromArgb(255, 238, 128);// Color.Yellow;
            }

            int pos = FindinDocResult[Current_Index].General_Position;
            textControl_Codex.Select(pos, FindinDocResult[Current_Index].Length);
            textControl_Codex.Selection.TextBackColor = System.Drawing.Color.FromArgb(197, 184, 98);// Dark Color.Yellow;

            textControl_Codex.InputPosition = new TXTextControl.InputPosition(pos);
            if (textControl_Codex.Selection.Start == 0) textControl_Codex.ScrollLocation = new Point(textControl_Codex.ScrollLocation.X, textControl_Codex.TextChars[1].Bounds.Y);
            else textControl_Codex.ScrollLocation = new Point(textControl_Codex.ScrollLocation.X, textControl_Codex.TextChars[textControl_Codex.Selection.Start].Bounds.Y);
            Previous_Index = Current_Index;
        }
        void OnTXListSelectedItemChanged(object sender, ILTextListControl.MyControlEventArgs args)
        {
            if (FindinDocResult == null) return;
            if (ilTextListControl1.ItemCount() == 0) return;

            Current_Index = ilTextListControl1.CurrentIndex();
            SelectItem();
        }


        public void FindInDocumentLeftPanel()
        {
            //zzz if (Document_Form == null) return;

            ShowDocumentForm = !ShowDocumentForm;

            if (ShowDocumentForm == true)
            {

                CodexTextIn.Text = "";
                CodexTextInClearButton.Visible = false;
                SearchUp.Visible = false;
                SearchDown.Visible = false;
                SearchResultLabel.Text = "";
                SearchInfoLabel.Text = "";

                int h = CodexTextIn.Height;
                CodexTextInSearchButton.AutoSize = false;
                CodexTextInSearchButton.MinimumSize = new Size(h, h);
                CodexTextInSearchButton.Size = new Size(h, h);

                CodexTextInClearButton.AutoSize = false;
                CodexTextInClearButton.MinimumSize = new Size(h, h);
                CodexTextInClearButton.Size = new Size(h, h);
                

                DocumentWithSearchSplitContainer.Panel1Collapsed = false;
                EnableSearchControls(true);
                _mainFormRef.ZoomingCodex();
                CodexTextIn.Focus();
            }
            else
            {

                CodexTextInClearButton.Visible = false;

                DocumentWithSearchSplitContainer.Panel1Collapsed = true;
                EnableSearchControls(false);
                _mainFormRef.ZoomingCodex();

            }

        }

        private void SearchCloseButton_Click(object sender, EventArgs e)
        {
            FindInDocumentLeftPanel();
        }

        private void CodexTextInSearchButton_Click(object sender, EventArgs e)
        {
            FindClick();
        }

        private void CodexTextInClearButton_Click(object sender, EventArgs e)
        {
            ClearClick();
        }

        private void SearchUp_Click(object sender, EventArgs e)
        {
            if (SelectionMode == true) { ilTextListControl1.Up_Click(); }
            else { if (Current_Index > 0) { Current_Index--; SelectItem(); } }
        }

        private void SearchDown_Click(object sender, EventArgs e)
        {
            if (SelectionMode == true) { ilTextListControl1.Down_Click(); }
            else { if (Current_Index < (FindinDocResult.Count - 1)) { Current_Index++; SelectItem(); } }
        }

        private void CodexTextIn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) ClearClick();
            if (e.KeyCode == Keys.Enter) FindClick();
        }

        private void CodexTextIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];

        }


        #endregion Search In Open Document
      


        private void CodexInText_TextChanged(object sender, EventArgs e)
        {
            _mainFormRef.CodexInText_TextChanged(sender, e);
        }

        private void CodexInText_KeyUp(object sender, KeyEventArgs e)
        {
            _mainFormRef.CodexInText_KeyUp(sender, e);
        }

        private void CodexInText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
            {
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
            }
        }

        private void CodexSerachInCheck_CheckedChanged(object sender, EventArgs e)
        {
            _mainFormRef.CodexSerachInCheck_CheckedChanged(sender, e);
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            _mainFormRef.SearchingInTxText(sender, e);
        }

        private void textControl_Codex_InputPositionChanged(object sender, EventArgs e)
        {
            _mainFormRef.textControl_Codex_InputPositionChanged(sender, e);
        }

        private void CodexLinkBox_DocumentClick(object sender, DSLinkListBoxEventArgs e)
        {
            _mainFormRef.CodexLinkBox_DocumentClick(sender, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _mainFormRef.DSToolBar.ShowPopup("DocumenPopUp"); 
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            _mainFormRef.DSToolBar.ShowPopup("Keyboard3"); 
        }

        private void contextMenuStrip3_Opening(object sender, CancelEventArgs e)
        {
            _mainFormRef.DSToolBar.ShowPopup("LinkPopUp"); 
        }

        private void contextMenuStrip4_Opening(object sender, CancelEventArgs e)
        {
            // 

            _mainFormRef.DSToolBar.ShowPopup("Attachment"); 
        }

 

        public void ViewLayout(int CodexViewLayout)
        {

            if (CodexViewLayout == 0)
            {
                textControl_Codex.ViewMode = TXTextControl.ViewMode.PageView;
                _mainFormRef.CodexViewLayout = 0;
            }
            else
            {
                textControl_Codex.ViewMode = TXTextControl.ViewMode.Normal;
                _mainFormRef.CodexViewLayout = 1;
            }
        }

        private void CodexDocumentStatusBar_ButtonClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelEventArgs e)
        {
        }

        private void ultraDockManager1_AfterDockChange(object sender, Infragistics.Win.UltraWinDock.PaneEventArgs e)
        {
            _mainFormRef.ZoomingCodex();
        }

        private void Form_Codex_Document_FormClosed(object sender, FormClosedEventArgs e)
        {
            pdfViewer1.CloseDocument();
        }

        private void BacktoOriginalDocument_Click(object sender, EventArgs e)
        {
            _mainFormRef.BackToOriginalDocument();
        }

     


        private void SearchCloseButton_Click_1(object sender, EventArgs e)
        {
            FindInDocumentLeftPanel();
        }

        private void CodexTextInSearchButton_Click_1(object sender, EventArgs e)
        {
            FindClick();
        }

        private void CodexTextInClearButton_Click_1(object sender, EventArgs e)
        {
            ClearClick();
        }

        private void SearchUp_Click_1(object sender, EventArgs e)
        {
            if (SelectionMode == true) { ilTextListControl1.Up_Click(); }
            else { if (Current_Index > 0) { Current_Index--; SelectItem(); } }
        }

        private void SearchDown_Click_1(object sender, EventArgs e)
        {
            if (SelectionMode == true) { ilTextListControl1.Down_Click(); }
            else { if (Current_Index < (FindinDocResult.Count - 1)) { Current_Index++; SelectItem(); } }
        }

        private void CodexTextIn_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
        }

        private void CodexTextIn_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) ClearClick();
            if (e.KeyCode == Keys.Enter) FindClick();
        }
    }
}