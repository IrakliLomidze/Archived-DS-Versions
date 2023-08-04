using ILG.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TXTextControl;

namespace ILG.Codex.CodexR4.DocumentForm
{
    public partial class BaseTxDocument : Form
    {
        //public Form1 MainFormReference;

        private int ZoomFactor = -20;

        private int codexfindpostion = 0;
        private bool iscodexfff = false;

        private bool ShowCodexF = false;

        public String Codex_DocEncoding = "";



        public BaseTxDocument()
        {
            InitializeComponent();
            textControl.ButtonBar = this.buttonBar2;
            textControl.RulerBar = this.rulerBar1;
            textControl.VerticalRulerBar = this.rulerBar2;
            textControl.StatusBar = this.statusBar1;


            // Set shape menu item images and texts
            //SetShapeMenuItemResources();

            //textControl.ButtonBar = buttonBar1;
            //textControl.RulerBar = rulerBar1;
            //textControl.VerticalRulerBar = rulerBar2;
            //textControl.StatusBar = statusBar1;

            _fileHandler = new FileHandler(this, textControl);
            _fileDragDropHandler = new FileDragDropHandler();


            // Check system text direction
            //this.RightToLeft
            //    = CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft
            //    ? RightToLeft.Yes : RightToLeft.No;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                _fileHandler.DocumentFileName = args[1];
                _bLoadFileOnCreate = true;
            }
        }



        #region " Form Variables "

        private FileHandler _fileHandler;
        private FileDragDropHandler _fileDragDropHandler;
        private bool _bLoadFileOnCreate = false;
        private List<int> _customColors = new List<int>();
        private TXTextControl.FrameBase _objSel;        // Currently selected object

        private const string ExpressEditionInfoMessage = "Not available in Express Edition.";

        #endregion

        #region " Form Properties "



        public bool CanCopy
        {
            get { return textControl.CanCopy; }
        }

        public bool CanPaste
        {
            get { return textControl.CanPaste; }
        }

        public bool CanUndo
        {
            get { return textControl.CanUndo; }
        }

        public bool CanRedo
        {
            get { return textControl.CanRedo; }
        }

        #endregion

        #region " Form Events "

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadAppSettings();

            //_fileHandler.RecentFilesMenuItem = recentFilesToolStripMenuItem;

            if (_bLoadFileOnCreate)
            {
                if (!_fileHandler.FileOpen()) return;
                if (_fileHandler.DocumentFileName != "")
                {
                    this.Text = this.ProductName.ToString() + " - " + _fileHandler.DocumentTitle;
                }
            }

            _fileHandler.DocumentDirty = true;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_fileHandler.DocumentDirty)
            {
                DialogResult res
                    = MessageBox.Show("Save changes to " + _fileHandler.DocumentTitle + "?",
                        ProductName, MessageBoxButtons.YesNoCancel);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    _fileHandler.FileSave();
                    if (_fileHandler.DocumentFileName == "") e.Cancel = true;
                }
                else if (res == System.Windows.Forms.DialogResult.Cancel) e.Cancel = true;
            }
            SaveAppSettings();
        }

        #endregion

        #region " File menu event handlers "

        private void mnuFile_Open_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        private void mnuFile_DropDownOpening(object sender, EventArgs e)
        {
            _fileHandler.InitRecentFiles();
        }

        private void mnuFile_New_Click(object sender, EventArgs e)
        {
            FileNew();
        }

        private void mnuFile_Save_Click(object sender, System.EventArgs e)
        {
            FileSave();
        }

        private void mnuFile_SaveAs_Click(object sender, System.EventArgs e)
        {
            FileSaveAs();
        }

        private void mnuFile_PrintPreview_Click(object sender, System.EventArgs e)
        {
            PrintPreview();
        }

        private void mnuFile_Print_Click(object sender, System.EventArgs e)
        {
            Print();
        }

        private void mnuFile_Exit_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuFile_Export_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Force exception in standard version:
                textControl.Sections.GetItem();

                _fileHandler.FileSaveAs(TXTextControl.StreamType.AdobePDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when exporting document", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuFile_PageSetup_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (textControl.SectionFormatDialog(0) == System.Windows.Forms.DialogResult.OK) _fileHandler.DocumentDirty = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        #endregion

        #region " Edit menu event handlers "

        private void mnuEdit_Popup(object sender, System.EventArgs e)
        {
            mnuEdit_Undo.Enabled = textControl.CanUndo;
            mnuEdit_Redo.Enabled = textControl.CanRedo;
            mnuEdit_Cut.Enabled = textControl.CanCopy;
            mnuEdit_Copy.Enabled = textControl.CanCopy;
            mnuEdit_Paste.Enabled = textControl.CanPaste;

            mnuEdit_Undo.Text = "Undo " + textControl.UndoActionName;
            mnuEdit_Redo.Text = "Redo " + textControl.RedoActionName;

            // Hypertext links are not available in the Standard version. Accessing them  
            // would throw an exception if this sample program is used with a Standard version
            // of Text Control.
            try
            {
                mnuEdit_Hyperlink.Enabled = (textControl.HypertextLinks.GetItem() != null) || (textControl.DocumentLinks.GetItem() != null);
                mnuEdit_Target.Enabled = (textControl.DocumentTargets.GetItem() != null);
            }
            catch { }
        }

        private void mnuEdit_Undo_Click(object sender, System.EventArgs e)
        {
            textControl.Undo();
        }

        private void mnuEdit_Redo_Click(object sender, System.EventArgs e)
        {
            textControl.Redo();
        }

        private void mnuEdit_Cut_Click(object sender, System.EventArgs e)
        {
            textControl.Cut();
        }

        private void mnuEdit_Copy_Click(object sender, System.EventArgs e)
        {
            textControl.Copy();
        }

        private void mnuEdit_Paste_Click(object sender, System.EventArgs e)
        {
            textControl.Paste();
        }

        private void mnuEdit_Delete_Click(object sender, System.EventArgs e)
        {
            textControl.Clear();
        }

        private void mnuEdit_SelectAll_Click(object sender, System.EventArgs e)
        {
            textControl.SelectAll();
        }

        private void mnuEdit_Find_Click(object sender, System.EventArgs e)
        {
            textControl.Find();
        }

        private void mnuEdit_Replace_Click(object sender, System.EventArgs e)
        {
            textControl.Replace();
        }

        private void mnuEdit_Hyperlink_Click(object sender, System.EventArgs e)
        {
            var dlg = new TXTextControl.HyperlinkDialog(textControl);
            if (dlg.ShowDialog(this) == DialogResult.OK) _fileHandler.DocumentDirty = true;
        }

        private void mnuEdit_Target_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Force exception if standard version:
                TXTextControl.DocumentTarget target = textControl.DocumentTargets.GetItem();

                string targetName = "";

                if (target != null)
                {
                    targetName = target.Name;
                    if (InputBoxDialog.ShowInputBox("Enter a name for this bookmark:", ref targetName, this))
                    {
                        target.Name = targetName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        #endregion

        #region " View menu event handlers "

        private void mnuView_Popup(object sender, System.EventArgs e)
        {
            mnuView_Draft.Checked = (textControl.ViewMode == TXTextControl.ViewMode.Normal);
            mnuView_PageLayout.Checked = (textControl.ViewMode == TXTextControl.ViewMode.PageView);
            //mnuView_Toolbar.Checked = _toolStrip.Visible;
            //mnuView_ButtonBar.Checked = buttonBar1.Visible;
            //mnuView_StatusBar.Checked = statusBar1.Visible;
            //mnuView_HorizontalRuler.Checked = rulerBar1.Visible;
            //mnuView_VerticalRuler.Checked = rulerBar2.Visible;
            mnuView_HeadersAndFooters.Enabled = (textControl.ViewMode == TXTextControl.ViewMode.PageView);

            mnuView_TextFrameMarkerLines.Checked = textControl.TextFrameMarkerLines;
            mnuView_DocumentTargetMarkers.Checked = textControl.DocumentTargetMarkers;
            mnuView_DrawingMarkerLines.Checked = textControl.DrawingMarkerLines;

            _mnuView_FormLayout.Checked = (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes);
        }

        private void mnuView_Normal_Click(object sender, System.EventArgs e)
        {
            textControl.ViewMode = TXTextControl.ViewMode.Normal;
        }

        private void mnuView_PageLayout_Click(object sender, System.EventArgs e)
        {
            textControl.ViewMode = TXTextControl.ViewMode.PageView;
        }

        private void mnuView_Toolbar_Click(object sender, System.EventArgs e)
        {
            _toolStrip.Visible = !_toolStrip.Visible;
        }

        private void mnuView_ButtonBar_Click(object sender, System.EventArgs e)
        {
            buttonBar1.Visible = !buttonBar1.Visible;
        }

        private void mnuView_StatusBar_Click(object sender, System.EventArgs e)
        {
            statusBar1.Visible = !statusBar1.Visible;
        }

        private void mnuView_HorizontalRuler_Click(object sender, System.EventArgs e)
        {
            rulerBar1.Visible = !rulerBar1.Visible;
        }

        private void mnuView_VerticalRuler_Click(object sender, System.EventArgs e)
        {
            rulerBar2.Visible = !rulerBar2.Visible;
        }

        private void mnuView_Zoom_DropDownOpening(object sender, EventArgs e)
        {
            //mnuView_Zoom_25.Checked = (textControl.ZoomFactor == 25);
            //mnuView_Zoom_50.Checked = (textControl.ZoomFactor == 50);
            //mnuView_Zoom_75.Checked = (textControl.ZoomFactor == 75);
            //mnuView_Zoom_100.Checked = (textControl.ZoomFactor == 100);
            //mnuView_Zoom_150.Checked = (textControl.ZoomFactor == 150);
            //mnuView_Zoom_200.Checked = (textControl.ZoomFactor == 200);
            //mnuView_Zoom_300.Checked = (textControl.ZoomFactor == 300);

            // Modifed for Codex R4

            mnuView_Zoom_25.Checked = (ZoomFactor == 25);
            mnuView_Zoom_50.Checked = (ZoomFactor == 50);
            mnuView_Zoom_75.Checked = (ZoomFactor == 75);
            mnuView_Zoom_100.Checked = (ZoomFactor == 100);
            mnuView_Zoom_150.Checked = (ZoomFactor == 150);
            mnuView_Zoom_200.Checked = (ZoomFactor == 200);
            mnuView_Zoom_300.Checked = (ZoomFactor == 300);

            pageWithToolStripMenuItem.Checked = (ZoomFactor == -10);
            pageHeightToolStripMenuItem.Checked = (ZoomFactor == -20);

        }

        private void mnuView_Zoom_25_Click(object sender, System.EventArgs e)
        {
            // Modifed for Codex R4
            textControl.ZoomFactor = 25;
            ZoomFactor = 25;
        }

        private void mnuView_Zoom_50_Click(object sender, System.EventArgs e)
        {
            // Modifed for Codex R4
            textControl.ZoomFactor = 50;
            ZoomFactor = 50;
        }

        private void mnuView_Zoom_75_Click(object sender, System.EventArgs e)
        {
            // Modifed for Codex R4
            textControl.ZoomFactor = 75;
            ZoomFactor = 75;
        }

        private void mnuView_Zoom_100_Click(object sender, System.EventArgs e)
        {
            // Modifed for Codex R4
            textControl.ZoomFactor = 100;
            ZoomFactor = 100;
        }

        private void mnuView_Zoom_150_Click(object sender, System.EventArgs e)
        {
            // Modifed for Codex R4
            textControl.ZoomFactor = 150;
            ZoomFactor = 150;
        }

        private void mnuView_Zoom_200_Click(object sender, System.EventArgs e)
        {
            // Modifed for Codex R4
            textControl.ZoomFactor = 200;
            ZoomFactor = 200;
        }

        private void mnuView_Zoom_300_Click(object sender, System.EventArgs e)
        {
            // Modifed for Codex R4
            textControl.ZoomFactor = 300;
            ZoomFactor = 300;
        }

        private void pageWithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  for Codex R4
            ZoomFactor = -20;
            Zooming();
        }

        private void pageHeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  for Codex R4
            ZoomFactor = -10;
            Zooming();
        }


        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomingDialog zd1 = new ZoomingDialog();
            zd1.CurrentZoom = this.textControl.ZoomFactor;
            if (zd1.ShowDialog() == DialogResult.OK)
            {
                ZoomFactor = zd1.CurrentZoom;
                Zooming();
                return;
            }
        }


        private void mnuView_FormLayout_Click(object sender, EventArgs e)
        {
            DockStyle dockStyle;
            RightToLeft rtl;
            if (_mnuView_FormLayout.Checked)
            {
                dockStyle = DockStyle.Left;
                rtl = RightToLeft.No;
            }
            else
            {
                dockStyle = DockStyle.Right;
                rtl = RightToLeft.Yes;
            }
            rulerBar2.Dock = dockStyle;
            RightToLeft = rtl;
            Focus();
            textControl.Focus();
        }

        private void mnuView_HeadersAndFooters_Click(object sender, System.EventArgs e)
        {
            try
            {
                TXTextControl.Section currentSection = textControl.Sections.GetItem();
                TXTextControl.HeaderFooter headerFooter = null;
                if (currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) != null)
                {
                    headerFooter = currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader);
                }
                else if (currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) != null)
                {
                    headerFooter = currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header);
                }
                else
                {
                    currentSection.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.Header);
                    textControl.HeaderFooterActivationStyle = TXTextControl.HeaderFooterActivationStyle.ActivateClick;
                    headerFooter = currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header);
                }
                headerFooter.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void mnuView_TextFrameMarkerLines_Click(object sender, System.EventArgs e)
        {
            textControl.TextFrameMarkerLines = !textControl.TextFrameMarkerLines;
        }

        void MnuView_DrawingMarkerLines_Click(object sender, EventArgs e)
        {
            textControl.DrawingMarkerLines = !textControl.DrawingMarkerLines;
        }

        private void mnuView_DocumentTargetMarkers_Click(object sender, EventArgs e)
        {
            textControl.DocumentTargetMarkers = !textControl.DocumentTargetMarkers;
        }

        #endregion

        #region " Insert menu event handlers "

        private void mnuInsert_File_Click(object sender, System.EventArgs e)
        {
            try
            {
                _fileHandler.Insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void mnuInsert_Image_Click(object sender, System.EventArgs e)
        {
            TXTextControl.Image imageNew = new TXTextControl.Image();
            try
            {
                textControl.Images.Add(imageNew, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.ImageInsertionMode.DisplaceText);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void MnuPageNum_delete_Click(object sender, EventArgs e)
        {
            RemovePageNumbers();
        }

        void MnuField_delete_Click(object sender, EventArgs e)
        {
            DeleteField();
        }

        void MnuInsert_Shapes_DrawingCanvas_Click(object sender, EventArgs e)
        {
            InsertDrawingCanvas();
        }

        private void mnuInsert_Popup(object sender, System.EventArgs e)
        {
            _mnuItmInsert_pageNum.Enabled = _bHdrFtrActivated;

            // Try/Catch is required because hypertext links are not available in the Standard version. 
            // of Text Control. Accessing them would throw an exception if this sample program is used 
            // with a Standard Version.
            try
            {
                mnuInsert_Hyperlink.Enabled = textControl.HypertextLinks.CanAdd;
                mnuInsert_Target.Enabled = textControl.DocumentTargets.CanAdd;
            }
            catch { }
        }

        private void mnuInsert_TextFrame_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Force Exception if standard version:
                textControl.TextFrames.GetItem();
                Size sizeTextFrame = new Size(2268, 2268);   // Arbitrary size (Frame is inserted with the mouse anyway)

                TXTextControl.TextFrame textFrameNew = new TXTextControl.TextFrame(sizeTextFrame);
                textControl.TextFrames.Add(textFrameNew, TXTextControl.TextFrameInsertionMode.DisplaceText | TXTextControl.TextFrameInsertionMode.MoveWithText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        void MnuInsert_Symbol_Click(object sender, EventArgs e)
        {
            textControl.AddSymbolDialog();
        }

        private void mnuInsert_Hyperlink_Click(object sender, System.EventArgs e)
        {
            var dlg = new TXTextControl.HyperlinkDialog(textControl);
            if (dlg.ShowDialog(this) == DialogResult.OK) _fileHandler.DocumentDirty = true;
        }

        private void mnuInsert_Target_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Force Exception if standard version:
                textControl.DocumentTargets.GetItem();

                string targetName = "";

                if (InputBoxDialog.ShowInputBox("Bookmark name:", ref targetName, this))
                {
                    TXTextControl.DocumentTarget target = new TXTextControl.DocumentTarget(targetName) { Deleteable = false };
                    textControl.DocumentTargets.Add(target);
                    _fileHandler.DocumentDirty = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void MnuInsert_Fields_DropDownOpening(object sender, EventArgs e)
        {
            switch (_fldDispModeCur)
            {
                case FieldDisplayMode.ShowFieldText:
                    _mnuInsert_Fields_showFieldCodes.Checked = false;
                    _mnuInsert_Fields_showFieldText.Checked = true;
                    break;

                case FieldDisplayMode.ShowFieldCodes:
                    _mnuInsert_Fields_showFieldCodes.Checked = true;
                    _mnuInsert_Fields_showFieldText.Checked = false;
                    break;
            }

            _mnuInsert_Fields_highlightMergeFields.Checked = _bHighlightFields;
            _mnuInsert_Fields_deleteField.Enabled = FieldAtCurrentPos();
        }

        private void MnuInsert_Fields_insertMergeField_Click(object sender, EventArgs e)
        {
            InsertMergeField();
        }

        private void MnuInsert_Fields_insertSpecialField_IF_Click(object sender, EventArgs e)
        {
            InsertIfField();
        }

        private void MnuInsert_Fields_insertSpecialField_inclText_Click(object sender, EventArgs e)
        {
            InsertIncludeTextField();
        }

        private void MnuInsert_Fields_insertSpecialField_date_Click(object sender, EventArgs e)
        {
            InsertDateField();
        }

        private void mnuInsert_Fields_insertSpecialField_next_Click(object sender, EventArgs e)
        {
            InsertNextField();
        }

        private void mnuInsert_Fields_insertSpecialField_nextif_Click(object sender, EventArgs e)
        {
            InsertNextIfField();
        }

        private void MnuInsert_Fields_highlightMergeFields_Click(object sender, EventArgs e)
        {
            _bHighlightFields = !_bHighlightFields;
            _mnuInsert_Fields_highlightMergeFields.Checked = _bHighlightFields;
            SetDefaultFieldAndBlockProperties();
        }

        private void MnuInsert_Fields_showFieldCodes_Click(object sender, EventArgs e)
        {
            if (_mnuInsert_Fields_showFieldCodes.Checked) return;

            _fldDispModeCur = FieldDisplayMode.ShowFieldCodes;
            CheckFieldDisplayModeMenuItems();
            UpdateFieldValues();
        }

        private void MnuInsert_Fields_showFieldText_Click(object sender, EventArgs e)
        {
            if (_mnuInsert_Fields_showFieldText.Checked) return;

            _fldDispModeCur = FieldDisplayMode.ShowFieldText;
            CheckFieldDisplayModeMenuItems();
            UpdateFieldValues();
        }

        private void MnuItmPageNum_insert_Click(object sender, EventArgs e)
        {
            InsertPageNumber();
        }

        #endregion

        #region " Format menu event handlers "

        private void mnuFormat_Popup(object sender, System.EventArgs e)
        {
            _mnuFormat_Image.Enabled = (textControl.Images.GetItem() != null);

            try { _mnuFormat_TextFrame.Enabled = (textControl.TextFrames.GetItem() != null); }
            catch { _mnuFormat_TextFrame.Enabled = false; }

            try
            {
                bool bEnable = (textControl.Drawings.GetItem() != null);
                _mnuFormat_Shape.Enabled = bEnable;
            }
            catch { _mnuFormat_Shape.Enabled = false; }
        }

        private void mnuFormat_Character_Click(object sender, System.EventArgs e)
        {
            if (textControl.FontDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _fileHandler.DocumentDirty = true;
            }
        }

        private void mnuFormat_Paragraph_Click(object sender, System.EventArgs e)
        {
            if (textControl.ParagraphFormatDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _fileHandler.DocumentDirty = true;
            }
        }

        private void mnuFormat_Tabs_Click(object sender, System.EventArgs e)
        {
            if (textControl.TabDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _fileHandler.DocumentDirty = true;
            }
        }

        private void mnuFormat_Styles_Click(object sender, System.EventArgs e)
        {
            if (textControl.FormattingStylesDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _fileHandler.DocumentDirty = true;
            }
        }

        private void mnuFormat_HeadersFooters_Click(object sender, EventArgs e)
        {
            try
            {
                if (textControl.SectionFormatDialog(1) == System.Windows.Forms.DialogResult.OK)
                {
                    _fileHandler.DocumentDirty = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void mnuFormat_Image_Click(object sender, System.EventArgs e)
        {
            if (textControl.ImageAttributesDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _fileHandler.DocumentDirty = true;
            }
        }

        private void mnuFormat_List_DropDownOpening(object sender, EventArgs e)
        {
            mnuFormat_List_IncreaseLevel.Enabled
                = (textControl.Selection.ListFormat.Type != TXTextControl.ListType.None)
                && (textControl.Selection.ListFormat.Level < TXTextControl.ListFormat.MaxLevel);
            mnuFormat_List_DecreaseLevel.Enabled
                = (textControl.Selection.ListFormat.Type != TXTextControl.ListType.None)
                && (textControl.Selection.ListFormat.Level > 1);

            CheckListMenuItem();
        }

        private void mnuFormat_List_Attributes_Click(object sender, System.EventArgs e)
        {
            if (textControl.ListFormatDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _fileHandler.DocumentDirty = true;
            }
        }

        private void mnuFormat_List_IncreaseLevel_Click(object sender, System.EventArgs e)
        {
            textControl.Selection.ListFormat.Level += 1;
            textControl.Selection.IncreaseIndent();
        }

        private void mnuFormat_List_DecreaseLevel_Click(object sender, System.EventArgs e)
        {
            if (textControl.Selection.ListFormat.Level >= 2)
            {
                textControl.Selection.ListFormat.Level -= 1;
                textControl.Selection.DecreaseIndent();
            }
        }

        private void mnuFormat_List_ArabicNumbers_Click(object sender, System.EventArgs e)
        {
            if (mnuFormat_List_ArabicNumbers.Checked)
            {
                textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
                textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None;
                return;
            }

            textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
            textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.ArabicNumbers;
        }

        private void mnuFormat_List_CapitalLetters_Click(object sender, System.EventArgs e)
        {
            if (mnuFormat_List_CapitalLetters.Checked)
            {
                textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
                textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None;
                return;
            }

            textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
            textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.CapitalLetters;
        }

        private void mnuFormat_List_Letters_Click(object sender, System.EventArgs e)
        {
            if (mnuFormat_List_Letters.Checked)
            {
                textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
                textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None;
                return;
            }

            textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
            textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.Letters;
        }

        private void mnuFormat_List_RomanNumbers_Click(object sender, System.EventArgs e)
        {
            if (mnuFormat_List_RomanNumbers.Checked)
            {
                textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
                textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None;
                return;
            }

            textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
            textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.RomanNumbers;
        }

        private void mnuFormat_List_SmallRomanNumbers_Click(object sender, System.EventArgs e)
        {
            if (mnuFormat_List_SmallRomanNumbers.Checked)
            {
                textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
                textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None;
                return;
            }

            textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
            textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.SmallRomanNumbers;
        }

        private void mnuFormat_List_Bullets_Click(object sender, System.EventArgs e)
        {
            if (mnuFormat_List_Bullets.Checked)
            {
                textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
                textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None;
                return;
            }

            textControl.Selection.ListFormat.Type = TXTextControl.ListType.Bulleted;
        }

        private void mnuFormat_borders_Click(object sender, EventArgs e)
        {
            try
            {
                if (textControl.SectionFormatDialog(3) == System.Windows.Forms.DialogResult.OK)
                {
                    _fileHandler.DocumentDirty = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void mnuFormat_Columns_Click(object sender, EventArgs e)
        {
            try
            {
                if (textControl.SectionFormatDialog(2) == System.Windows.Forms.DialogResult.OK)
                {
                    _fileHandler.DocumentDirty = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void mnuFormat_TextFrame_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (textControl.TextFrameAttributesDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _fileHandler.DocumentDirty = true;
                }
            }
            catch { }
        }

        private void mnuFormat_SetLanguage_Click(object sender, EventArgs e)
        {
            textControl.LanguageDialog();
        }

        private void mnuFormat_Shape_Click(object sender, EventArgs e)
        {
            textControl.DrawingLayoutDialog();
        }

        #endregion

        #region " Table menu event handlers "

        private void mnuTable_Popup(object sender, System.EventArgs e)
        {
            TXTextControl.Table ThisTable = textControl.Tables.GetItem();

            mnuTable_Properties.Enabled = (ThisTable != null);
            mnuTable_GridLines.Checked = textControl.Tables.GridLines;

            if (ThisTable != null)
            {
                mnuTable_Delete.Enabled = true;
                mnuTable_Split.Enabled = ThisTable.CanSplit;
                mnuTable_Merge_Cells.Enabled = ThisTable.CanMergeCells;
                mnuTable_Split_Cells.Enabled = ThisTable.CanSplitCells;
                mnuTable_Select.Enabled = true;
            }
            else
            {
                mnuTable_Split.Enabled = false;
                mnuTable_Delete.Enabled = false;
                mnuTable_Merge_Cells.Enabled = false;
                mnuTable_Split_Cells.Enabled = false;
                mnuTable_Select.Enabled = false;
            }
        }

        private void mnuTable_Insert_Popup(object sender, System.EventArgs e)
        {
            mnuTable_Insert_Table.Enabled = textControl.Tables.CanAdd;

            TXTextControl.Table tableAtInputPosition = textControl.Tables.GetItem();
            if (tableAtInputPosition == null)
            {
                mnuTable_Insert_ColumnToTheLeft.Enabled = false;
                mnuTable_Insert_ColumnToTheRight.Enabled = false;
                mnuTable_Insert_RowAbove.Enabled = false;
                mnuTable_Insert_RowBelow.Enabled = false;
            }
            else
            {
                mnuTable_Insert_ColumnToTheLeft.Enabled = tableAtInputPosition.Columns.CanAdd;
                mnuTable_Insert_ColumnToTheRight.Enabled = tableAtInputPosition.Columns.CanAdd;
                mnuTable_Insert_RowAbove.Enabled = tableAtInputPosition.Rows.CanAdd;
                mnuTable_Insert_RowBelow.Enabled = tableAtInputPosition.Rows.CanAdd;
            }
        }

        private void mnuTable_Insert_Table_Click(object sender, System.EventArgs e)
        {
            InsertTable();
        }

        private void mnuTable_Insert_ColumnToTheLeft_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Columns.Add(TXTextControl.TableAddPosition.Before);
        }

        private void mnuTable_Insert_ColumnToTheRight_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Columns.Add(TXTextControl.TableAddPosition.After);
        }

        private void mnuTable_Insert_RowAbove_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Rows.Add(TXTextControl.TableAddPosition.Before, 1);
        }

        private void mnuTable_Insert_RowBelow_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Rows.Add(TXTextControl.TableAddPosition.After, 1);
        }

        private void mnuTable_Delete_Popup(object sender, System.EventArgs e)
        {
            TXTextControl.Table tableAtInputPosition = textControl.Tables.GetItem();

            if (tableAtInputPosition == null)
            {
                mnuTable_Delete_Table.Enabled = false;
                mnuTable_Delete_Column.Enabled = false;
                mnuTable_Delete_Rows.Enabled = false;
                mnuTable_Delete_Cells.Enabled = false;
            }
            else
            {
                mnuTable_Delete_Table.Enabled = tableAtInputPosition.Columns.CanRemove;
                mnuTable_Delete_Column.Enabled = tableAtInputPosition.Columns.CanRemove;
                mnuTable_Delete_Rows.Enabled = tableAtInputPosition.Rows.CanRemove;
                mnuTable_Delete_Cells.Enabled = tableAtInputPosition.Cells.CanRemove;
                mnuTable_Delete_Cells_entireColumn.Enabled = tableAtInputPosition.Columns.CanRemove;
                mnuTable_Delete_Cells_entireRow.Enabled = tableAtInputPosition.Rows.CanRemove;
            }
        }

        private void mnuTable_Delete_Table_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.Remove();
        }

        private void mnuTable_Delete_Column_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Columns.Remove();
        }

        private void mnuTable_Delete_Rows_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Rows.Remove();
        }

        private void mnuTable_Delete_Cells_shiftLeft_Click(object sender, EventArgs e)
        {
            textControl.Tables.GetItem().Cells.Remove();
        }

        private void mnuTable_Delete_Cells_entireRow_Click(object sender, EventArgs e)
        {
            textControl.Tables.GetItem().Rows.Remove();
        }

        private void mnuTable_Delete_Cells_entireColumn_Click(object sender, EventArgs e)
        {
            textControl.Tables.GetItem().Columns.Remove();
        }

        private void mnuTable_Merge_Cells_Click(object sender, EventArgs e)
        {
            textControl.Tables.GetItem().MergeCells();
        }

        private void mnuTable_Split_Cells_Click(object sender, EventArgs e)
        {
            textControl.Tables.GetItem().SplitCells();
        }

        private void mnuTable_Split_DropDownOpening(object sender, EventArgs e)
        {
            TXTextControl.Table tableAtInputPosition = textControl.Tables.GetItem();

            if (tableAtInputPosition == null)
            {
                mnuTable_Split_Above.Enabled = false;
                mnuTable_Split_Below.Enabled = false;
            }
            else
            {
                mnuTable_Split_Above.Enabled = true;
                mnuTable_Split_Below.Enabled = true;
            }

        }

        private void mnuTable_Split_Above_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Split(TXTextControl.TableAddPosition.Before);
        }

        private void mnuTable_Split_Below_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Split(TXTextControl.TableAddPosition.After);
        }

        private void mnuTable_Select_Popup(object sender, System.EventArgs e)
        {
            TXTextControl.Table tableAtInputPosition = null;
            TXTextControl.TableRow rowAtInputPosition = null;
            TXTextControl.TableCell cellAtInputPosition = null;
            TXTextControl.TableColumn columnAtInputPosition = null;

            tableAtInputPosition = textControl.Tables.GetItem();
            if (tableAtInputPosition != null)
            {
                rowAtInputPosition = tableAtInputPosition.Rows.GetItem();
                cellAtInputPosition = tableAtInputPosition.Cells.GetItem();
                columnAtInputPosition = tableAtInputPosition.Columns.GetItem();
            }

            mnuTable_Select_Table.Enabled = (tableAtInputPosition != null);
            mnuTable_Select_Row.Enabled = (rowAtInputPosition != null);
            mnuTable_Select_Cell.Enabled = (cellAtInputPosition != null);
            mnuTable_Select_Column.Enabled = (columnAtInputPosition != null);
        }

        private void mnuTable_Select_Table_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Select();
        }

        private void mnuTable_Select_Row_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Rows.GetItem().Select();
        }

        private void mnuTable_Select_Column_Click(object sender, EventArgs e)
        {
            textControl.Tables.GetItem().Columns.GetItem().Select();
        }

        private void mnuTable_Select_Cell_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GetItem().Cells.GetItem().Select();
        }

        private void mnuTable_GridLines_Click(object sender, System.EventArgs e)
        {
            textControl.Tables.GridLines = !textControl.Tables.GridLines;
        }

        private void mnuTable_Properties_Click(object sender, System.EventArgs e)
        {
            textControl.TableFormatDialog();
        }

        #endregion

        #region " Help menu event handlers "

        private void mnuHelp_AboutTXTextControlWords_Click(object sender, EventArgs e)
        {
            About();
        }
        #endregion

        #region " Menu item and toolbar button functions "

        public void FileNew()
        {
            if (_fileHandler.DocumentDirty)
            {
                DialogResult res
                    = MessageBox.Show("Save changes to " + _fileHandler.DocumentTitle + "?",
                        ProductName, MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                    case System.Windows.Forms.DialogResult.Yes:
                        _fileHandler.FileSave();
                        if (_fileHandler.DocumentFileName == "")
                            return;
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                }
            }
            _fileHandler.DocumentFileName = "";
            textControl.ResetContents();
            this.Text = this.ProductName.ToString() + " - " + _fileHandler.DocumentTitle;
            _fileHandler.DocumentDirty = false;
        }

        public void FileOpen()
        {
            if (_fileHandler.DocumentDirty)
            {
                DialogResult res
                    = MessageBox.Show("Save changes to " + _fileHandler.DocumentTitle + "?",
                        ProductName, MessageBoxButtons.YesNoCancel);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    _fileHandler.FileSave();
                    if (_fileHandler.DocumentFileName == "") return;
                }
                else if (res == System.Windows.Forms.DialogResult.Cancel) return;
            }

            _fileHandler.DocumentFileName = "";
            _fileHandler.FileOpen();
        }

        public void FileSave()
        {
            try
            {
                _fileHandler.FileSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when saving document", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FileSaveAs()
        {
            try
            {
                _fileHandler.FileSaveAs(TXTextControl.StreamType.RichTextFormat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when saving document", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Print()
        {
            textControl.Print(ProductName + " - " + _fileHandler.DocumentTitle);
        }

        public void PrintPreview()
        {
            textControl.PrintPreview(ProductName + " - " + _fileHandler.DocumentTitle);
        }

        public void About()
        {
            string copyright = "Copyright By GM";// ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(this.GetType().Assembly, typeof(AssemblyCopyrightAttribute))).Copyright;
            string asmTitle = "";// ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(this.GetType().Assembly, typeof(AssemblyTitleAttribute))).Title;

            MessageBox.Show(
                asmTitle
                 + "\r\n"
                 + copyright, "About " + ProductName,
                 MessageBoxButtons.OK, MessageBoxIcon.Information
            );
        }

        public int GetNumberOfPages()
        {
            int pages = 0;

            try
            {
                for (int i = 1; i <= textControl.Pages; i++)
                {
                    if (textControl.GetPages()[i].Section == textControl.Sections.GetItem().Number) ++pages;
                }
            }
            catch { }

            return pages;
        }


        #endregion

        #region " Form methods and functions "
        private void LoadAppSettings()
        {
            //// Take over initial resizing
            //this.StartPosition = FormStartPosition.Manual;

            //// Resize form
            //this.Size = Properties.Settings.Default.LastWindowSize;
            //this.Location = Properties.Settings.Default.LastWindowPos;
            //this.WindowState = Properties.Settings.Default.LastWindowState;

        }

        private void SaveAppSettings()
        {

        }

        #endregion

        #region " Toolbar event handlers "

        public void UpdateSaveStatus()
        {
            _toolStrip.Items["toolStripSave"].Enabled = _fileHandler.DocumentDirty;
            mnuFile.DropDownItems[4].Enabled = _fileHandler.DocumentDirty;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FileNew();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FileSave();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            PrintPreview();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            textControl.Cut();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            textControl.Copy();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            textControl.Paste();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            textControl.Clear();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            textControl.Undo();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            textControl.Redo();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            // Changed in R4
            DocumentSearchTab.Visible = true;
            DocumentSearchTab.Enabled = true;
            CodexInText.Focus();

            //textControl.Find();
        }

        private void toolStripMarginsAndPaper_Click(object sender, EventArgs e)
        {
            try
            {
                textControl.SectionFormatDialog(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void toolStripHeadersAndFooters_Click(object sender, EventArgs e)
        {
            try
            {
                textControl.SectionFormatDialog(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void toolStripColumns_Click(object sender, EventArgs e)
        {
            try
            {
                textControl.SectionFormatDialog(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void toolStripPageBorders_Click(object sender, EventArgs e)
        {
            try
            {
                textControl.SectionFormatDialog(3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName);
            }
        }

        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new InsertBreakDialog();
            dlg.tx = textControl;
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                _fileHandler.DocumentDirty = true;
            }
        }

        void rulerBar1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                textControl.TabDialog();
            }
        }

        #endregion

        #region "  Options menu event handlers  "

        private void mnuOptions_HTML_Click(object sender, System.EventArgs e)
        {
            var dlg = new HTMLOptionsDialog(_fileHandler);
            dlg.ShowDialog(this);
        }

        private void mnuOptions_PDF_Click(object sender, System.EventArgs e)
        {
            if (textControl.GetVersionInfo().Level > TXTextControl.VersionInfo.ProductLevel.Standard)
            {
                var dlg = new PDFOptionsDialog(textControl);
                dlg.FileHandler = _fileHandler;
                dlg.ShowDialog(this);
            }
            else
            {
                MessageBox.Show(ExpressEditionInfoMessage, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion // Options menu event handlers

        #region " Helpers "

        private int ColorToBGR(Color color) { return color.B << 16 | color.G << 8 | color.R; }

        private TXTextControl.FrameInsertionMode GetSelectedObjInsMode()
        {
            if (_objSel == null) return TXTextControl.FrameInsertionMode.AsCharacter;
            return _objSel.InsertionMode & ~(TXTextControl.FrameInsertionMode.MoveWithText | TXTextControl.FrameInsertionMode.FixedOnPage);
        }

        private void SetSelectedObjectInsertionMode(object mnuItem, TXTextControl.FrameInsertionMode insMode)
        {
            ToolStripMenuItem mi = mnuItem as ToolStripMenuItem;
            if ((mi == null) || mi.Checked) return;

            // Set new insertion mode
            SetObjectInsertionMode(_objSel, insMode);
            mi.Checked = true;
        }

        void SetObjectInsertionMode(TXTextControl.FrameBase obj, TXTextControl.FrameInsertionMode insMode)
        {
            if (obj == null) return;

            // If new insertion mode is "as character" discard previous insertion mode flags
            if (insMode == TXTextControl.FrameInsertionMode.AsCharacter)
            {
                obj.InsertionMode = insMode;
                return;
            }

            // Get current insertion mode flags
            TXTextControl.FrameInsertionMode insModeFlags
                = (obj.InsertionMode & (TXTextControl.FrameInsertionMode.FixedOnPage | TXTextControl.FrameInsertionMode.MoveWithText));

            // If currently no insertion mode flags are set, set to "move with text"
            if (insModeFlags == (TXTextControl.FrameInsertionMode)0)
            {
                insModeFlags = TXTextControl.FrameInsertionMode.MoveWithText;
            }

            // Combine new insertion mode with current insertion mode flags
            obj.InsertionMode = insModeFlags | insMode;
        }

        private void UpdateCurrentObject()
        {
            GetSelectedObject();
        }

        private void GetSelectedObject()
        {
            try
            {
                _objSel = textControl.Frames.GetItem();
            }
            catch { }
        }

        private void InsertTable()
        {
            if (textControl.Tables.Add())
            {
                _fileHandler.DocumentDirty = true;
            }
        }

        private void CheckFieldDisplayModeMenuItems()
        {
            switch (_fldDispModeCur)
            {
                case FieldDisplayMode.ShowFieldText:
                    _mnuInsert_Fields_showFieldCodes.Checked = false;
                    _mnuInsert_Fields_showFieldText.Checked = true;
                    break;

                case FieldDisplayMode.ShowFieldCodes:
                    _mnuInsert_Fields_showFieldCodes.Checked = true;
                    _mnuInsert_Fields_showFieldText.Checked = false;
                    break;
            }
        }

        public void UpdateGUIState()
        {
            _toolStrip.Items["toolStripCut"].Enabled = this.CanCopy;
            _toolStrip.Items["toolStripCopy"].Enabled = this.CanCopy;
            _toolStrip.Items["toolStripPaste"].Enabled = this.CanPaste;
            _toolStrip.Items["toolStripDelete"].Enabled = this.CanCopy;
            _toolStrip.Items["toolStripUndo"].Enabled = this.CanUndo;
            _toolStrip.Items["toolStripRedo"].Enabled = this.CanRedo;
            _toolStrip.Items["toolStripColumns"].Enabled = true;
        }

        private void CheckListMenuItem()
        {
            // Uncheck all list items
            foreach (var obj in mnuFormat_List.DropDownItems)
            {
                var item = obj as ToolStripMenuItem;
                if (item == null) continue;

                item.Checked = false;
            }

            switch (textControl.Selection.ListFormat.Type)
            {
                case TXTextControl.ListType.Bulleted:
                    mnuFormat_List_Bullets.Checked = true;
                    return;

                case TXTextControl.ListType.None: return;
            }

            switch (textControl.Selection.ListFormat.NumberFormat)
            {
                case TXTextControl.NumberFormat.ArabicNumbers:
                    mnuFormat_List_ArabicNumbers.Checked = true;
                    break;

                case TXTextControl.NumberFormat.CapitalLetters:
                    mnuFormat_List_CapitalLetters.Checked = true;
                    break;

                case TXTextControl.NumberFormat.Letters:
                    mnuFormat_List_Letters.Checked = true;
                    break;

                case TXTextControl.NumberFormat.RomanNumbers:
                    mnuFormat_List_RomanNumbers.Checked = true;
                    break;

                case TXTextControl.NumberFormat.SmallRomanNumbers:
                    mnuFormat_List_SmallRomanNumbers.Checked = true;
                    break;
            }
        }

        #endregion // Helpers



        public void SaveDocument()
        {
            TXTextControl.SaveSettings SaveSettings = new TXTextControl.SaveSettings();
            SaveSettings.PageMargins = textControl.PageMargins;
            SaveSettings.PageSize = textControl.PageSize;
            SaveSettings.ImageSaveMode = TXTextControl.ImageSaveMode.SaveAsData;
            SaveFileDialog sd = new SaveFileDialog();

            sd.Filter = "Rich Text Format (*.rtf)|*.rtf|Hiper Text Markaup Language (*.html)| *.html|Microsoft Word (*.doc)| *.doc|Microsoft Word 2007 (*.docx)| *.docx|Plain Text ANSI(*.txt)| *.txt";
            sd.FilterIndex = 0;
            sd.RestoreDirectory = true;
            sd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);// global::ILG.Codex.CodexR4.Properties.Settings.Default.CodexDocumentDir;
            sd.OverwritePrompt = false;

            TXTextControl.StreamType st = new TXTextControl.StreamType();
            st = TXTextControl.StreamType.RichTextFormat;

            if (sd.ShowDialog() == DialogResult.OK)
            {
                switch (sd.FilterIndex)
                {
                    case 1: st = TXTextControl.StreamType.RichTextFormat; break;
                    case 2: st = TXTextControl.StreamType.HTMLFormat; break;
                    case 3: st = TXTextControl.StreamType.MSWord; break;
                    case 4: st = TXTextControl.StreamType.WordprocessingML; break;
                    case 5: st = TXTextControl.StreamType.PlainText; break;
                }
                if (File.Exists(sd.FileName) == true)
                {
                    if (ILG.Windows.Forms.ILGMessageBox.Show("თქვენს მიერ მითითებული ფაილი " + Path.GetFileName(sd.FileName) + "\nუკვე არსებობს, გადავაწერო ?", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                        System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        textControl.Save(sd.FileName, st, SaveSettings);
                }
                else textControl.Save(sd.FileName, st, SaveSettings);

            }

        }

        public void SaveInPDF()
        {
            TXTextControl.SaveSettings SaveSettings = new TXTextControl.SaveSettings();
            SaveSettings.PageMargins = textControl.PageMargins;
            SaveSettings.PageSize = textControl.PageSize;
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Portable Document Format (*.pdf)|*.pdf";
            sd.FilterIndex = 2;
            sd.RestoreDirectory = true;
            sd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sd.OverwritePrompt = false;
            TXTextControl.StreamType st = new TXTextControl.StreamType();
            st = TXTextControl.StreamType.AdobePDF;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                switch (sd.FilterIndex)
                {
                    case 1: st = TXTextControl.StreamType.AdobePDFA; break;
                    case 2: st = TXTextControl.StreamType.AdobePDF; break;
                }

                if (File.Exists(sd.FileName) == true)
                {
                    if (ILG.Windows.Forms.ILGMessageBox.Show("თქვენს მიერ მითითებული ფაილი " + Path.GetFileName(sd.FileName) + "\nუკვე არსებობს, გადავაწერო ?", "", System.Windows.Forms.MessageBoxButtons.YesNo,
                        System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        textControl.Save(sd.FileName, st, SaveSettings);
                }
                else textControl.Save(sd.FileName, st, SaveSettings);
            }

        }


        // Codex Legacy Code
        // Zooming Factors


        private int Detect_Zoom_In_Document(int c)
        {
            var CurrentMesusringUnit = textControl.PageUnit;
            textControl.PageUnit = MeasuringUnit.Twips;
            int iVisibleGap = 65;

            // get resolution to calculate convert twips 1/100 inch
            Graphics g = textControl.CreateGraphics();
            int iTwipsPerPixel = (int)(1440 / g.DpiX);

            SectionFormat currentSection = textControl.Sections.GetItem().Format;

            double widthZoom = 100 * textControl.Width /
                ((currentSection.PageSize.Width / iTwipsPerPixel)
                + iVisibleGap);
            double heightZoom = 100 * textControl.Height /
                ((currentSection.PageSize.Height / iTwipsPerPixel)
                + iVisibleGap);


            if (widthZoom > 400) widthZoom = 400;
            if (widthZoom < 10) widthZoom = 10;
            if (heightZoom < 10) heightZoom = 10;
            if (heightZoom > 400) heightZoom = 400;

            if (widthZoom < heightZoom)
                textControl.ZoomFactor = (int)widthZoom;
            else
                textControl.ZoomFactor = (int)heightZoom;

            if (c == 1) return (int)widthZoom;
            return (int)heightZoom;

        }

        private void ZoomingDocument(ref int ZoomFactor)
        {
            // Zooming 
            if (ZoomFactor == -20) { textControl.ZoomFactor = Detect_Zoom_In_Document(1); }
            else
            {
                if (ZoomFactor == -10) { textControl.ZoomFactor = Detect_Zoom_In_Document(2); }
                else
                {
                    textControl.ZoomFactor = ZoomFactor;
                }
            }


            //Update Codex Status Bar
            //CodexStatusBar.Panels["Zoom"].Text = textControl.ZoomFactor + "%";
            //CodexZoomTrackBar.Value = textControl.ZoomFactor;
        }

        public void ClickZoom()
        {
            ZoomingDialog zd1 = new ZoomingDialog();
            zd1.CurrentZoom = this.textControl.ZoomFactor;
            if (zd1.ShowDialog() == DialogResult.OK)
            {
                ZoomFactor = zd1.CurrentZoom;
                //ZoomingDocument();
                return;
            }
        }

      



        #region Serach In TX

        public void FindInCodexDocument()
        {
            ShowCodexF = !ShowCodexF;
            DocumentSearchTab.Visible = ShowCodexF;
            DocumentSearchTab.Enabled = ShowCodexF;
            CodexInText.Focus();
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string str = GeoUnitoGeo8(CodexInText.Text.Trim());
            if ((Codex_DocEncoding.Trim().ToUpper() == "UNICODE") || (Codex_DocEncoding.Trim().ToUpper() == "")) str = CodexInText.Text.Trim();
            if (CodexSerachInCheck.Checked == false) codexfindpostion = textControl.Find(str, codexfindpostion + 1, TXTextControl.FindOptions.NoMessageBox | TXTextControl.FindOptions.MatchCase);
            else codexfindpostion = textControl.Find(str, codexfindpostion, TXTextControl.FindOptions.NoMessageBox | TXTextControl.FindOptions.MatchCase | TXTextControl.FindOptions.Reverse);
            if (codexfindpostion == -1)
            {
                if (iscodexfff == true) ILGMessageBox.Show("ტექსტში '" + CodexInText.Text.Trim() + "' მეტი არ მოიძებნა ");
                else ILGMessageBox.Show("ტექსტში '" + CodexInText.Text.Trim() + "' არ მოიძებნა ");
                iscodexfff = false;
            }
            else iscodexfff = true;
        }

        private void CodexInText_TextChanged(object sender, EventArgs e)
        {
            codexfindpostion = textControl.InputPosition.TextPosition;
            if (CodexInText.Text == "") codexfindpostion = 0;
            iscodexfff = false;
        }

        private void CodexInText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SearchButton_Click(null, null);
        }

        private void CodexSerachInCheck_CheckedChanged(object sender, EventArgs e)
        {
            //codexfindpostion = 0;
            iscodexfff = false;
        }

        #endregion Serach In TX

        private void textControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        #region Direct Tx Opeation

        public void TX_PSplitBelow()
        {
            textControl.Tables.GetItem().Split(TXTextControl.TableAddPosition.After);
        }
        public void TX_PSelectTable()
        {
            textControl.Tables.GetItem().Select();
        }
        public void TX_PSelectColumn()
        {
            textControl.Tables.GetItem().Cells.GetItem().Select();
        }
        public void TX_PSelectRow()
        {
            textControl.Tables.GetItem().Rows.GetItem().Select();
        }
        public void TX_InsertTable()
        {
            frmInsertTable InsertTableDialog2 = new frmInsertTable();
            InsertTableDialog2.tx = textControl;
            InsertTableDialog2.ShowDialog();

        }
        public void TX_HeaderFooter()
        {
            try
            {
                frmHeaderSettings HeaderSettingsDialog = new frmHeaderSettings();

                HeaderSettingsDialog.tx = textControl;
                HeaderSettingsDialog.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Codex TX ");
            }
        }
        public void TX_TextColor()
        {
            ColorDialog ColorDialog1 = new ColorDialog();
            ColorDialog1.ShowDialog();
            textControl.Selection.ForeColor = ColorDialog1.Color;
        }
        public void TX_DocumentBackgroundColor()
        {
            ColorDialog ColorDialog3 = new ColorDialog();
            ColorDialog3.ShowDialog();
            textControl.BackColor = ColorDialog3.Color;
        }
        public void TX_TextBackgroundColor()
        {
            ColorDialog ColorDialog2 = new ColorDialog();
            ColorDialog2.ShowDialog();
            textControl.Selection.TextBackColor = ColorDialog2.Color;
        }

        public void TX_InsertImage()
        {
            TXTextControl.Image NewImage = new TXTextControl.Image();
            textControl.Images.Add(NewImage, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.ImageInsertionMode.DisplaceText);
        }

        public void TX_DocumentFormat()
        {
            PageSetup ps = new PageSetup();
            ps.ShowDialog(this.textControl);

        }

        public void TX_Styles()
        {
            textControl.FormattingStylesDialog();
        }

        public void SwitchBetweenHeaderAndFooter()
        {
            //if (m_ActiveHeaderFooter != null)
            //{
            //    if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.Header)
            //        textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Activate();
            //    else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.Footer)
            //        textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Activate();
            //    else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.FirstPageHeader)
            //        textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).Activate();
            //    else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.FirstPageFooter)
            //        textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader).Activate();
            //}
        }

        public void GoToFirstPage()
        {
            //if (m_ActiveHeaderFooter != null)
            //{
            //    if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.Header)
            //        textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader).Activate();
            //    else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.Footer)
            //        textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter).Activate();
            //}
        }

        public void GoToDefault()
        {
            //if (m_ActiveHeaderFooter != null)
            //{
            //    if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.FirstPageHeader)
            //        textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Activate();
            //   else if (m_ActiveHeaderFooter.Type == TXTextControl.HeaderFooterType.FirstPageFooter)
            //        textControl1.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Activate();
            //}
        }



        public void RemoveAllSections()
        {
            TXTextControl.SectionCollection.SectionEnumerator sectionEnum = textControl.Sections.GetEnumerator();
            int sectionCounter = textControl.Sections.Count;



            sectionEnum.Reset();
            sectionEnum.MoveNext();
            for (int i = 0; i < sectionCounter; i++)
            {
                TXTextControl.Section curSection = (TXTextControl.Section)sectionEnum.Current;

                if (curSection.Number == 1)
                {
                    sectionEnum.MoveNext();
                    continue;
                }

                textControl.Selection.Start = curSection.Start - 2;
                textControl.Selection.Length = 1;
                textControl.Selection.Text = "";
            }


            textControl.PageSize = new TXTextControl.PageSize(827, 1169);
            textControl.PageMargins.Bottom = 79;
            textControl.PageMargins.Left = 79;
            textControl.PageMargins.Right = 79;
            textControl.PageMargins.Top = 79;

        }


        #endregion Direct Tx Opeation

    
        private int detectzoom(int c)
        {
            // Modifed for R4
            var baseunit = textControl.PageUnit;
            textControl.PageUnit = MeasuringUnit.Twips;
            int iVisibleGap = 65;
            //if (c == 1) iVisibleGap = 200;

            // get resolution to calculate convert twips 1/100 inch
            Graphics g = textControl.CreateGraphics();
            int iTwipsPerPixel = (int)(1440 / g.DpiX);

            SectionFormat currentSection = textControl.Sections.GetItem().Format;

            double widthZoom = 100 * textControl.Width /
                ((currentSection.PageSize.Width / iTwipsPerPixel)
                + iVisibleGap);
            double heightZoom = 100 * textControl.Height /
                ((currentSection.PageSize.Height / iTwipsPerPixel)
                + iVisibleGap);


            //int nPageWidthInPixels = (int)(textControl.PageSize.Width);
            //int nPageHeightInPixels = (int)(textControl.PageSize.Height);


            if (widthZoom > 400) widthZoom = 400;
            if (widthZoom < 10) widthZoom = 10;
            if (heightZoom < 10) heightZoom = 10;
            if (heightZoom > 400) heightZoom = 400;

            textControl.PageUnit = baseunit;

            if (c == 1) return (int)widthZoom;
            return (int)heightZoom;

        }


        public void Zooming()
        {
            // Zooming 

            if (this.ZoomFactor == -20) { textControl.ZoomFactor = detectzoom(1); }
            else
            {
                if (ZoomFactor == -10) { textControl.ZoomFactor = detectzoom(2); }
                else
                {
                    textControl.ZoomFactor = ZoomFactor;
                }
            }
        }




        public void Document_TXNew()
        {
            // Clear Text
            textControl.Load("", TXTextControl.StringStreamType.PlainText);


            try
            {
                while (this.textControl.Tables.Count != 0)
                {
                    this.textControl.Tables.Remove();
                }

                
                    this.textControl.Clear();
            }
            catch
            {
            }

            
            //textControl.PageSize = new TXTextControl.PageSize(850, 1100);

            //textControl.PageMargins.Bottom = 79;
            //textControl.PageMargins.Left = 79;
            //textControl.PageMargins.Right = 79;
            //textControl.PageMargins.Top = 79;

            TXTextControl.LoadSettings LoadSettings = new TXTextControl.LoadSettings();

            this.textControl.PageMargins.Top = Properties.Settings.Default.DocumentPageMarginTop;
            this.textControl.PageMargins.Bottom = Properties.Settings.Default.DocumentPageMarginBottom;
            this.textControl.PageMargins.Left = Properties.Settings.Default.DocumentPageMarginLeft;
            this.textControl.PageMargins.Right = Properties.Settings.Default.DocumentPageMarginRight;

            this.textControl.PageSize = new PageSize(Properties.Settings.Default.DocumentPageWidth,
                                                                    Properties.Settings.Default.DocumentPageHeight);

        }





        #region Paste as

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            textControl.Paste(TXTextControl.ClipboardFormat.RichTextFormat);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            textControl.Paste(TXTextControl.ClipboardFormat.PlainText);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            textControl.Paste(TXTextControl.ClipboardFormat.Image);
        }

        private void pasteAsHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textControl.Paste(TXTextControl.ClipboardFormat.HTMLFormat);
        }

        private void pasterAsTXIMAGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textControl.Paste(TXTextControl.ClipboardFormat.TXTextControlImage);
        }

        private void textControl_Click(object sender, EventArgs e)
        {

        }

        private void pasterAsTXFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
                textControl.Paste(TXTextControl.ClipboardFormat.TXTextControlFormat);
        }

        private void pasteAsTxFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textControl.Paste(TXTextControl.ClipboardFormat.TXTextControlTextframe);
        }

        #endregion Paste as


        #region Remove Section
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("ეს ოპერაცია დოკუმენტიდან ამოუღებს ყველა გასნხვავებულ სექციას \n\r ეს საშუალებას მოგცემთ დკუმენტი გაიხსნას უკეთესად წინა ვერსიაბში", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    RemoveAllSections();
                }
                catch
                {
                    ILGMessageBox.Show("არ ხერხდება სექციების წაშლა");
                }
            }

        }

        #endregion Remove Section

        public void SaveDocCodex()
        {
            FileSave();
        }

        public void SetPageViewLayout()
        {
            textControl.ViewMode = TXTextControl.ViewMode.PageView;

        }

        public void SerViewLayout(int ViewLayout)
        {
            if (ViewLayout == 0)
            {
                textControl.ViewMode = TXTextControl.ViewMode.PageView;
            }
            else
            {
                textControl.ViewMode = TXTextControl.ViewMode.Normal;
            }
       }



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

        private void BaseTxDocument_ResizeEnd(object sender, EventArgs e)
        {
            Zooming();
        }


        public bool isTextEmpty()
        {
            if (textControl.Text.ToString().Trim() == "") return true;
            else return false;
        }

        public bool MoreThanOneSection()
        {
            return (textControl.Sections.Count > 1);
        }
        public void OpenDocumentInTXEditor(bool WithCodexSettings)
        {
            OpenFileDialog fd = new OpenFileDialog();
            //fd.InitialDirectory = startdir;
            fd.Filter = "All files (*.*)|*.*";

            fd.Title = "Open Document";
            fd.Filter = "Microsoft Word (*.docx)|*.docx|Microsoft Word 2003(*.doc)|*.doc|Rich Text Format (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*";


            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            fd.Title = "Open File";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string str = System.IO.Path.GetExtension(fd.FileName).Trim().ToUpper();
                TXTextControl.LoadSettings LoadSettings = new TXTextControl.LoadSettings();
                
                switch (str)
                {
                    case ".RTF": textControl.Load(fd.FileName, TXTextControl.StreamType.RichTextFormat, LoadSettings); break;
                    case ".DOC": textControl.Load(fd.FileName, TXTextControl.StreamType.MSWord, LoadSettings); break;
                    case ".DOCX": textControl.Load(fd.FileName, TXTextControl.StreamType.WordprocessingML, LoadSettings); break;
                    case ".TXT": textControl.Load(fd.FileName, TXTextControl.StreamType.PlainText, LoadSettings); break;
                    default: ILG.Windows.Forms.ILGMessageBox.Show("ფაილი უცნობ ფორმატშია"); return; break;
                }

                // PAGE SIZE TO LETER
                if (WithCodexSettings == true)
                {
                    //textControl.PageSize = new TXTextControl.PageSize(850, 1100);

                    //textControl.PageMargins.Bottom = 79;
                    //textControl.PageMargins.Left = 79;
                    //textControl.PageMargins.Right = 79;
                    //textControl.PageMargins.Top = 79;
                    //TXTextControl.LoadSettings LoadSettings = new TXTextControl.LoadSettings();

                    this.textControl.PageMargins.Top = Properties.Settings.Default.DocumentPageMarginTop;
                    this.textControl.PageMargins.Bottom = Properties.Settings.Default.DocumentPageMarginBottom;
                    this.textControl.PageMargins.Left = Properties.Settings.Default.DocumentPageMarginLeft;
                    this.textControl.PageMargins.Right = Properties.Settings.Default.DocumentPageMarginRight;

                    this.textControl.PageSize = new PageSize(Properties.Settings.Default.DocumentPageWidth,
                                                                            Properties.Settings.Default.DocumentPageHeight);
                }


            }
        }




        private void ultraButton1_Click(object sender, EventArgs e)
        {
            DocumentSearchTab.Visible = false;
            DocumentSearchTab.Enabled = false;
            textControl.Selection.Length = 0;
        }

        public String GetSelectedTextFromTxTextEditor()
        {
            if (textControl.Selection.Length > 0) return textControl.Selection.Text;
            else return String.Empty;
        }


        public void SaveToRTF(String FullFileName)
        {
            TXTextControl.SaveSettings SaveSettings = new TXTextControl.SaveSettings();
            SaveSettings.PageMargins = textControl.PageMargins;
            SaveSettings.PageSize = textControl.PageSize;
            SaveSettings.ImageSaveMode = TXTextControl.ImageSaveMode.SaveAsData;

            textControl.Save(FullFileName, TXTextControl.StreamType.RichTextFormat, SaveSettings);
        }

        public void GetPlainText(out string Text)
        {
            textControl.Save(out Text, StringStreamType.PlainText);
        }

        public bool HaveMoreThanOneSection()
        {
            return (textControl.Sections.Count > 1);
        }

        public void RemoveAllHeaderAndFooters()
        {
            if (this.textControl.HeadersAndFooters.Count != 0)
                this.textControl.HeadersAndFooters.Remove(TXTextControl.HeaderFooterType.All);
        }

        public void SetFocusAndZooming()
        {
           textControl.Focus();
           Zooming();
        }


        public void ShowInMSWordViaTX(string Suffix)
        {

            string fn = DirectoryConfiguration.CodexTemporaryDirectory + @"\" + Suffix + DateTime.Now.Ticks.ToString();

            int i = 1;
            while (File.Exists(fn + "_" + i.ToString() + ".docx") == true) { i++; }

            fn = fn + "_" + i.ToString() + ".docx";

            try
            {
                textControl.Save(fn, TXTextControl.StreamType.WordprocessingML);
                System.Diagnostics.Process.Start(@"file" + @":\\" + fn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("არ ხერხდება დოკუმენტის ექსპორტი MS-Word ში" + System.Environment.NewLine+
                                ex.ToString()+
                                "ვცდით RTF ფორმატით");
                TXTextControl.SaveSettings SaveSettings = new TXTextControl.SaveSettings();
                SaveSettings.ImageSaveMode = TXTextControl.ImageSaveMode.SaveAsData;
                textControl.Save(fn, TXTextControl.StreamType.RichTextFormat, SaveSettings);
                i = 1;
                while (File.Exists(fn + "_" + i.ToString() + ".docx") == true) { i++; }
                fn = fn + "_" + i.ToString() + ".docx";
                System.Diagnostics.Process.Start(@"file" + @":\\" + fn);
                return;
            }
        }

        public void LoadRTFFileInTxTextEditor(String FullFileName)
        {
          textControl.Load(FullFileName, TXTextControl.StreamType.RichTextFormat);
        }
    
    }
}
