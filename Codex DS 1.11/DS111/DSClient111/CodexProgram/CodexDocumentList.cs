using ILG.DS.AppStateManagement;
using ILG.DS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{
    public partial class CodexDocumentList : Form
    {
        private readonly Form1 MainFormRef;
        public CodexDocumentList(Form1 mainFormRef)
        {
            MainFormRef = mainFormRef;
            InitializeComponent();
            Document_Preview.ShortcutsEnabled = false;
            // TODO ContextMenu is no longer supported. Use ContextMenuStrip instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/winforms#removed-controls
            //Document_Preview.Context = new ContextMenu();
            Document_Preview.LinkClicked += Document_Preview_LinkClicked;
        }

        private void Document_Preview_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            
        }

        private void ListFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.ListFilter.Text.Trim() != "")
            {
                TopBar.Appearance.BackColor = Color.FromArgb(205, 230, 247);
                TopBar.Appearance.BackColor2 = Color.FromArgb(205, 230, 247);

                TopBar.Appearance.BorderColor = Color.FromArgb(42,141,212);
                TopBar.Appearance.BorderColor2 = Color.FromArgb(42, 141, 212);
            }
            else
            {
                TopBar.Appearance.BackColor = Color.FromArgb(255, 255, 255);
                TopBar.Appearance.BackColor2 = Color.FromArgb(255, 255, 255);

                TopBar.Appearance.BorderColor = Color.FromArgb(255, 255, 255);
                TopBar.Appearance.BorderColor2 = Color.FromArgb(255, 255, 255);
            }


        }

        private void DocumentListBox1_DocumentClick(object sender, DSListBoxEventArgs e)
        {
            MainFormRef.codexListBox1_DocumentClick(sender, e); 
        }
        private void List_FilterGO()
        {

            string f = MainFormRef.CodexFilterBy;

            
            #region Codex
                        MainFormRef.CodexFilterBy = "C_Caption LIKE '%" + ListFilter.Text.Trim() + "%'";

                        if (MainFormRef.Codex_Result.Tables[0].Select(MainFormRef.CodexFilterBy).Length == 0)
                        {
                            ILGMessageBox.Show("ფილტრაციის შედეგი ცარიელია");
                            MainFormRef.CodexFilterBy = f;
                            ListFilter.ButtonsRight["Reset"].Visible = false;
                            ListFilter.Text = "";
                            this.DocumentListBox1.HighlightedText = "";
                        }
                        else
                        {
                            ListFilter.ButtonsRight["Reset"].Visible = true;
                            this.DocumentListBox1.HighlightedText = ListFilter.Text.Trim();
                        }

                        MainFormRef.ResortingCodexList(MainFormRef.CodexSortBy, MainFormRef.CodexFilterBy);

                        if (ListFilter.Text.Trim() == "") ListFilter.ButtonsRight["Reset"].Visible = false;
                   #endregion Codex
           

        }
       
        private void ListFilter_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (e.Button.Key == "Search")
            {
                List_FilterGO();
            }

            if (e.Button.Key == "Reset")
            {
                ListFilter.Text = ""; 
                List_FilterGO();
            }
        }

        private void ListFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) List_FilterGO();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            MainFormRef.DSToolBar.ShowPopup("ListMenu"); 
        }

        private void DocumentListBox1_PreviewDocument(object sender)
        {
            Cursor = Cursors.WaitCursor;

            if (DocumentListBox1.Active_DocType == 1)
            {
                this.Document_Preview.Text = "!!! ეს არის PDF დოკუმენტი, მისი სრული ტექსტის ნახვა შეუძლებელია დოკუმენტში გახმსნის გარეშე " + Environment.NewLine +
                                             "ჩანს მხოლოდ საკვანძო სიტყვები სტრულტექსტოვანი ძებნისთვის" + Environment.NewLine +
                                              "---------------------------------------------------------------------------------------------------" + Environment.NewLine +
                    DocumentListBox1.Active_Preview;
            }
            else
            {
                this.Document_Preview.Text = DocumentListBox1.Active_Preview;
            }

            this.Document_Preview_Label.Text = DocumentListBox1.Active_TCaption;

            //if (DocumentListBox1.Active_DocStatus == 0) DocumentPictureBox.Image = DocumentListBox1.Image_Doc;
            //else DocumentPictureBox.Image = DocumentListBox1.Image_Doc_Cod;

            Cursor = Cursors.Default;

        }


        private void Document_Preview_Label_Click(object sender, EventArgs e)
        {
        }




        private void ListSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ILResize();
        }

        void ILResize()
        {
            ListFilter.Width = TopBar.Width - ListFilter.Left * 2;
            Document_Preview_Label.Width = PreviewBar.Width - Document_Preview_Label.Left - 8;

            

        }

        private void CodexDocumentList_Load(object sender, EventArgs e)
        {

            //ListSplitContainer.SplitterDistance = this.ClientSize.Width / 2;
            float ratio = 0.5f;
            //if (ListSplitContainer.Orientation == Orientation.Horizontal) ratio = ILG.Codex.CodexR4.Properties.Settings.Default.Spliter_List_Horizontal;

            if ((ratio <= 0.0f) || (ratio >= 1.0f)) ratio = 0.5f;
            ListSplitContainer.SplitterDistance = (int)(ListSplitContainer.Width * ratio);

         
            ListFilter.Left = 8;
            ListFilter.Top = 4;
            ListFilter.Width = TopBar.Width - ListFilter.Left * 2;
            TopBar.Height = ListFilter.Top + ListFilter.Height + ListFilter.Top;
            
         
            
            this.DocumentPictureBox.Left = 8;
            this.DocumentPictureBox.Top = 8;
            
            //PreviewBar.Height = 2 * this.DocumentPictureBox.Top + this.DocumentPictureBox.Height;

            TopBar.Appearance.BackColor = Color.FromArgb(255, 255, 255);
            TopBar.Appearance.BackColor2 = Color.FromArgb(255, 255, 255);

            TopBar.Appearance.BorderColor = Color.FromArgb(255, 255, 255);
            TopBar.Appearance.BorderColor2 = Color.FromArgb(255, 255, 255);

            Document_Preview_Label.Left = DocumentPictureBox.Left + DocumentPictureBox.Width + 8;
            Document_Preview_Label.Top = DocumentPictureBox.Top;

            Button_Copy.Left = DocumentPictureBox.Left + DocumentPictureBox.Width+ 8;
            Button_Copy.Top = Document_Preview_Label.Top + Document_Preview_Label.Height + 8;

            Button_Save.Top = Button_Copy.Top;
            Button_Word.Top = Button_Copy.Top;

            Button_Save.Left = Button_Copy.Left + Button_Copy.Width + 8;
            Button_Word.Left = Button_Save.Left + Button_Save.Width + 8;

            PreviewBar.Height = Button_Save.Top + Button_Save.Height + 4;


            ultraLabel1.Left = 8;
            ultraLabel1.Top = 2;
            panel1.Height = ultraLabel1.Top * 2 + ultraLabel1.Height;

            this.Document_Preview.SelectionColor = Color.LightGray;



            ILResize();
            if (app.state.UISettingsManager.content.ui_showlistpreview == false)
            {
                ListSplitContainer.Panel2Collapsed = true;
            }

        }

        private void ListSplitContainer_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            ILResize();
        }

        private void CodexDocumentList_Resize_1(object sender, EventArgs e)
        {
            ILResize();
        }


        #region Zoom
        // Zooming Factor
        float PreviewZoomingFactor = 10.5f;

        public int GetZoomFactor()
        {
            return FontSizetoTracValue(PreviewZoomingFactor);
        }

        public void SetZoomFactor(float newZoom)
        {
            PreviewZoomingFactor = newZoom;
            //this.Document_Preview.Font = new System.Drawing.Font(Document_Preview.Font.Name.ToString(), PreviewZoomingFactor );
        }



        private float TrackToFontSize(int Progress)
        {
            float MinSize = 8.0f;
            return MinSize + (float)Progress / 2;
        }
        private int FontSizetoTracValue(float FontSize)
        {
            float Delta = FontSize - 8.0f;
            float D = Delta * 2;
            return  (int)Math.Round(D);
        }


        public void ZoomingList(int zoomfactor)
        {
            SetZoomFactor(TrackToFontSize(zoomfactor));
        }

        #endregion Zoom

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            //Preview_Copy
            MainFormRef.DSToolBar.ShowPopup("Preview");
        }

        public void Perofm_Copy()
        {
            Document_Preview.Copy();
        }

        public void Perfom_SelectAll()
        {
            Document_Preview.SelectAll();

        }

        //public enum Panel_Preview_Dock_Position { Right = 0, Left = 1, Bottom = 2, Close = -1 };

        //public void Panel_Preview_Dock()
        //{
        //    if (ILG.Codex.CodexR4.Properties.Settings.Default.DocumentPreviewPanelDockPosition == 0) { Panel_Preview_Dock(Panel_Preview_Dock_Position.Right); return; }
        //    if (ILG.Codex.CodexR4.Properties.Settings.Default.DocumentPreviewPanelDockPosition == 1) { Panel_Preview_Dock(Panel_Preview_Dock_Position.Bottom); return; }

        //    if (ILG.Codex.CodexR4.Properties.Settings.Default.DocumentPreviewPanelDockPosition == 2) { Panel_Preview_Dock(Panel_Preview_Dock_Position.Close); return; }

        //    Panel_Preview_Dock(Panel_Preview_Dock_Position.Right); return; 

        //}

        //public void Panel_Preview_Dock(Panel_Preview_Dock_Position Position)
        //{
        //    switch (Position)
        //    {
        //        case Panel_Preview_Dock_Position.Right:
        //            {

        //                ListSplitContainer.Orientation = Orientation.Vertical;
        //                if (ListSplitContainer.Panel2Collapsed == true) { ListSplitContainer.Panel2Collapsed = false; }
        //                if ((ListSplitContainer.Panel1Collapsed == false) && (ListSplitContainer.Panel2Collapsed == false))
        //                {
        //                    float ratio = ILG.Codex.CodexR4.Properties.Settings.Default.Spliter_List_Vertical;
        //                    if ((ratio <= 0.0f) || (ratio >= 1.0f)) ratio = 0.5f;
        //                    ListSplitContainer.SplitterDistance = (int)(ListSplitContainer.Width * ratio);
        //                }
        //                ILG.Codex.CodexR4.Properties.Settings.Default.DocumentPreviewPanelDockPosition = (int)Panel_Preview_Dock_Position.Right;

        //                this.MainFormRef.Document_Preview_Panel_Dock_Closed = false;
        //                //this.MainFormRef.CodexStatusBar.Panels["ListZoom"].Visible = true;
        //            } break;

        //        case Panel_Preview_Dock_Position.Bottom:
        //            {
        //                ListSplitContainer.Orientation = Orientation.Horizontal;

        //                if (ListSplitContainer.Panel2Collapsed == true) { ListSplitContainer.Panel2Collapsed = false; }

        //                if ((ListSplitContainer.Panel1Collapsed == false) && (ListSplitContainer.Panel2Collapsed == false))
        //                {
        //                    float ratio = ILG.Codex.CodexR4.Properties.Settings.Default.Spliter_List_Horizontal;
        //                    if ((ratio <= 0.0f) || (ratio >= 1.0f)) ratio = 0.5f;
        //                    ListSplitContainer.SplitterDistance = (int)(ListSplitContainer.Height * 0.5);
        //                }

        //                ILG.Codex.CodexR4.Properties.Settings.Default.DocumentLinkPanelDockPosition = (int)Panel_Preview_Dock_Position.Bottom;

        //                this.MainFormRef.Document_Link_Panel_Dock_Closed = false;
                        
        //            } break;


        //        case Panel_Preview_Dock_Position.Close:
        //            {

        //                ListSplitContainer.Panel2Collapsed = true;
        //                ILG.Codex.CodexR4.Properties.Settings.Default.DocumentLinkPanelDockPosition = (int)Panel_Preview_Dock_Position.Close;
        //                this.MainFormRef.Document_Link_Panel_Dock_Closed = true;
                        

        //            } break;

        //    }
        //}

        private void Button_Copy_Click(object sender, EventArgs e)
        {
            if (app.state.RunTimeLicense.IsDocumentViewRestrictedMode() == true) { ILGMessageBox.Show("მოქმედების ჩატარებისთვის თქვენ არ გაქვთ შესაბამისი უფლება"); return; }
            Clipboard.SetText(Document_Preview.Text);
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            // ZXZ ZXZ
            //MainFormRef.SaveFromDatabase();
        }

        private void ListFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
        }
    }
}
