using System.Drawing;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4.DocumentForm
{
    partial class BaseTxDocument
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab10 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl13 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.CodexInText = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.CodexSerachInCheck = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.SearchButton = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.ultraTabSharedControlsPage5 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.DocumentSearchTab = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.buttonBar2 = new TXTextControl.ButtonBar();
            this.buttonBar1 = new TXTextControl.ButtonBar();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.textControl = new TXTextControl.TextControl();
            this._contextMenuApplicationFields = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._fieldPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deleteFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_New = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFile_PageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_PrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_Find = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Replace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem16 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_Hyperlink = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Target = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_PageLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Draft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView_HeadersAndFooters = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView_TextFrameMarkerLines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_DrawingMarkerLines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_DocumentTargetMarkers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem19 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView_Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_25 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_50 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_75 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_150 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_200 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_300 = new System.Windows.Forms.ToolStripMenuItem();
            this.pageWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageHeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this._mnuView_FormLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_File = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_Image = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_TextFrame = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_pageNum = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuItmInsert_pageNum = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuPageNum_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep_mnuInsert1 = new System.Windows.Forms.ToolStripSeparator();
            this._mnuInsert_Fields = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Fields_insertMergeField = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Fields_insertSpecialField = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Fields_insertSpecialField_IF = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Fields_insertSpecialField_inclText = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Fields_insertSpecialField_date = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Fields_insertSpecialField_Next = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Fields_insertSpecialField_NextIf = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Fields_highlightMergeFields = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this._mnuInsert_Fields_showFieldCodes = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Fields_showFieldText = new System.Windows.Forms.ToolStripMenuItem();
            this._sep_field01 = new System.Windows.Forms.ToolStripSeparator();
            this._mnuInsert_Fields_deleteField = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuInsert_Symbol = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep_mnuInsert2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_Hyperlink = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Target = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep_mnuInsert3 = new System.Windows.Forms.ToolStripSeparator();
            this.sectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Character = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Paragraph = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_Attributes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_IncreaseLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_DecreaseLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem28 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_List_ArabicNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_CapitalLetters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_Letters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_RomanNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_SmallRomanNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_Bullets = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Styles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_HeadersAndFooters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Columns = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_pageframe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Tabs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem20 = new System.Windows.Forms.ToolStripSeparator();
            this._mnuFormat_Image = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuFormat_TextFrame = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuFormat_Shape = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_SetLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Insert_Table = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem21 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Insert_ColumnToTheLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Insert_ColumnToTheRight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem24 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Insert_RowAbove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Insert_RowBelow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Table = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Column = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Rows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Cells = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Cells_shiftLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Cells_entireRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Cells_entireColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select_Table = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select_Row = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select_Column = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select_Cell = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Merge_Cells = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Split_Cells = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Split = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Split_Above = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Split_Below = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_GridLines = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep_mnuTable1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripNewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCut = new System.Windows.Forms.ToolStripButton();
            this.toolStripCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripPaste = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAsHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasterAsTXIMAGEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasterAsTXFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAsTxFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator444 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMarginsAndPaper = new System.Windows.Forms.ToolStripButton();
            this.toolStripHeadersAndFooters = new System.Windows.Forms.ToolStripButton();
            this.toolStripColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripPageBorders = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this._sep_pageNum01 = new System.Windows.Forms.ToolStripSeparator();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.ultraTabPageControl13.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodexInText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodexSerachInCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentSearchTab)).BeginInit();
            this.DocumentSearchTab.SuspendLayout();
            this._contextMenuApplicationFields.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl13
            // 
            this.ultraTabPageControl13.Controls.Add(this.tableLayoutPanel1);
            this.ultraTabPageControl13.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraTabPageControl13.Name = "ultraTabPageControl13";
            this.ultraTabPageControl13.Size = new System.Drawing.Size(814, 40);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 328F));
            this.tableLayoutPanel1.Controls.Add(this.ultraButton1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CodexInText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CodexSerachInCheck, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.SearchButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 40);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ultraButton1
            // 
            this.ultraButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ultraButton1.AutoSize = true;
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013ScrollbarButton;
            this.ultraButton1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraButton1.Location = new System.Drawing.Point(789, 8);
            this.ultraButton1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(19, 24);
            this.ultraButton1.TabIndex = 3;
            this.ultraButton1.Text = "X";
            this.ultraButton1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // CodexInText
            // 
            this.CodexInText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CodexInText.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodexInText.Location = new System.Drawing.Point(12, 7);
            this.CodexInText.Margin = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.CodexInText.Name = "CodexInText";
            this.CodexInText.Size = new System.Drawing.Size(247, 25);
            this.CodexInText.TabIndex = 1;
            this.CodexInText.TextChanged += new System.EventHandler(this.CodexInText_TextChanged);
            this.CodexInText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CodexInText_KeyUp);
            // 
            // CodexSerachInCheck
            // 
            this.CodexSerachInCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CodexSerachInCheck.BackColor = System.Drawing.Color.Transparent;
            this.CodexSerachInCheck.BackColorInternal = System.Drawing.Color.Transparent;
            this.CodexSerachInCheck.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button;
            this.CodexSerachInCheck.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2007CheckBoxGlyphInfo;
            this.CodexSerachInCheck.Location = new System.Drawing.Point(389, 8);
            this.CodexSerachInCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CodexSerachInCheck.Name = "CodexSerachInCheck";
            this.CodexSerachInCheck.Size = new System.Drawing.Size(94, 23);
            this.CodexSerachInCheck.TabIndex = 2;
            this.CodexSerachInCheck.Text = "ძებნა ზევით";
            this.CodexSerachInCheck.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.CodexSerachInCheck.CheckedChanged += new System.EventHandler(this.CodexSerachInCheck_CheckedChanged);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton;
            this.SearchButton.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(277, 7);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(103, 26);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "ძებნა";
            this.SearchButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SearchButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ultraStatusBar1
            // 
            appearance1.FontData.Name = "Sylfaen";
            appearance1.FontData.SizeInPoints = 9F;
            this.ultraStatusBar1.Appearance = appearance1;
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 0);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(0, 0);
            this.ultraStatusBar1.TabIndex = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.statusBar1.ColumnText = "სვეტი  ";
            this.statusBar1.DisplayColors.BackColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.statusBar1.DisplayColors.BackColorMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.statusBar1.DisplayColors.BackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.statusBar1.DisplayColors.ForeColor = System.Drawing.Color.White;
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.LineText = "სტიქონი ";
            this.statusBar1.Location = new System.Drawing.Point(0, 374);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.PageText = "გვერდი ";
            this.statusBar1.SectionText = "სექცია  ";
            this.statusBar1.Size = new System.Drawing.Size(814, 22);
            this.statusBar1.TabIndex = 70;
            // 
            // ultraTabSharedControlsPage5
            // 
            this.ultraTabSharedControlsPage5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraTabSharedControlsPage5.Name = "ultraTabSharedControlsPage5";
            this.ultraTabSharedControlsPage5.Size = new System.Drawing.Size(814, 40);
            // 
            // DocumentSearchTab
            // 
            this.DocumentSearchTab.Controls.Add(this.ultraTabSharedControlsPage5);
            this.DocumentSearchTab.Controls.Add(this.ultraTabPageControl13);
            this.DocumentSearchTab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DocumentSearchTab.Enabled = false;
            this.DocumentSearchTab.Location = new System.Drawing.Point(0, 334);
            this.DocumentSearchTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DocumentSearchTab.Name = "DocumentSearchTab";
            this.DocumentSearchTab.SharedControlsPage = this.ultraTabSharedControlsPage5;
            this.DocumentSearchTab.Size = new System.Drawing.Size(814, 40);
            this.DocumentSearchTab.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.DocumentSearchTab.TabIndex = 13;
            ultraTab10.TabPage = this.ultraTabPageControl13;
            ultraTab10.Text = "tab1";
            this.DocumentSearchTab.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab10});
            this.DocumentSearchTab.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DocumentSearchTab.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.DocumentSearchTab.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            this.DocumentSearchTab.Visible = false;
            // 
            // buttonBar2
            // 
            this.buttonBar2.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBar2.Location = new System.Drawing.Point(0, 49);
            this.buttonBar2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBar2.Name = "buttonBar2";
            this.buttonBar2.Size = new System.Drawing.Size(814, 28);
            this.buttonBar2.TabIndex = 15;
            this.buttonBar2.Text = "TXButtonBar";
            // 
            // buttonBar1
            // 
            this.buttonBar1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBar1.Location = new System.Drawing.Point(0, 0);
            this.buttonBar1.Name = "buttonBar1";
            this.buttonBar1.Size = new System.Drawing.Size(200, 28);
            this.buttonBar1.TabIndex = 0;
            // 
            // rulerBar1
            // 
            this.rulerBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rulerBar1.Location = new System.Drawing.Point(0, 77);
            this.rulerBar1.Name = "rulerBar1";
            this.rulerBar1.Size = new System.Drawing.Size(814, 25);
            this.rulerBar1.TabIndex = 68;
            this.rulerBar1.Text = "rulerBar1";
            // 
            // rulerBar2
            // 
            this.rulerBar2.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.rulerBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.rulerBar2.Location = new System.Drawing.Point(0, 102);
            this.rulerBar2.Name = "rulerBar2";
            this.rulerBar2.Size = new System.Drawing.Size(25, 232);
            this.rulerBar2.TabIndex = 69;
            this.rulerBar2.Text = "rulerBar2";
            // 
            // textControl
            // 
            this.textControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textControl.HideSelection = false;
            this.textControl.Location = new System.Drawing.Point(25, 102);
            this.textControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textControl.Name = "textControl";
            this.textControl.PageMargins.Bottom = 79.03D;
            this.textControl.PageMargins.Left = 79.03D;
            this.textControl.PageMargins.Right = 79.03D;
            this.textControl.PageMargins.Top = 79.03D;
            this.textControl.RulerBar = this.rulerBar1;
            this.textControl.Size = new System.Drawing.Size(789, 232);
            this.textControl.TabIndex = 12;
            this.textControl.VerticalRulerBar = this.rulerBar2;
            this.textControl.Click += new System.EventHandler(this.textControl_Click);
            this.textControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textControl_KeyPress);
            // 
            // _contextMenuApplicationFields
            // 
            this._contextMenuApplicationFields.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fieldPropertiesToolStripMenuItem,
            this._deleteFieldToolStripMenuItem});
            this._contextMenuApplicationFields.Name = "_contextMenuApplicationFields";
            this._contextMenuApplicationFields.Size = new System.Drawing.Size(165, 48);
            // 
            // _fieldPropertiesToolStripMenuItem
            // 
            this._fieldPropertiesToolStripMenuItem.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergefieldproperties;
            this._fieldPropertiesToolStripMenuItem.Name = "_fieldPropertiesToolStripMenuItem";
            this._fieldPropertiesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this._fieldPropertiesToolStripMenuItem.Text = "Field &Properties…";
            this._fieldPropertiesToolStripMenuItem.Click += new System.EventHandler(this.FieldPropertiesToolStripMenuItem_Click);
            // 
            // _deleteFieldToolStripMenuItem
            // 
            this._deleteFieldToolStripMenuItem.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergedeletefield;
            this._deleteFieldToolStripMenuItem.Name = "_deleteFieldToolStripMenuItem";
            this._deleteFieldToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this._deleteFieldToolStripMenuItem.Text = "&Delete Field";
            this._deleteFieldToolStripMenuItem.Click += new System.EventHandler(this.DeleteFieldToolStripMenuItem_Click);
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuInsert,
            this.mnuFormat,
            this.mnuTable});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(814, 24);
            this._menuStrip.TabIndex = 1;
            this._menuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile_New,
            this.mnuFile_Open,
            this.toolStripMenuItem1,
            this.mnuFile_Save,
            this.mnuFile_SaveAs,
            this.mnuFile_Export,
            this.menuItem6,
            this.mnuFile_PageSetup,
            this.mnuFile_PrintPreview,
            this.mnuFile_Print});
            this.mnuFile.MergeIndex = 0;
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(63, 20);
            this.mnuFile.Text = "&ფაილი";
            this.mnuFile.DropDownOpening += new System.EventHandler(this.mnuFile_DropDownOpening);
            // 
            // mnuFile_New
            // 
            this.mnuFile_New.Image = global::ILG.Codex.CodexR4.Properties.Resources.newpage;
            this.mnuFile_New.Name = "mnuFile_New";
            this.mnuFile_New.Size = new System.Drawing.Size(152, 22);
            this.mnuFile_New.Text = "&ახალი";
            this.mnuFile_New.Click += new System.EventHandler(this.mnuFile_New_Click);
            // 
            // mnuFile_Open
            // 
            this.mnuFile_Open.Image = global::ILG.Codex.CodexR4.Properties.Resources.open;
            this.mnuFile_Open.Name = "mnuFile_Open";
            this.mnuFile_Open.Size = new System.Drawing.Size(152, 22);
            this.mnuFile_Open.Text = "&გახსნა…";
            this.mnuFile_Open.Click += new System.EventHandler(this.mnuFile_Open_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuFile_Save
            // 
            this.mnuFile_Save.Image = global::ILG.Codex.CodexR4.Properties.Resources.save;
            this.mnuFile_Save.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuFile_Save.MergeIndex = 1;
            this.mnuFile_Save.Name = "mnuFile_Save";
            this.mnuFile_Save.Size = new System.Drawing.Size(152, 22);
            this.mnuFile_Save.Text = "&Save";
            this.mnuFile_Save.Click += new System.EventHandler(this.mnuFile_Save_Click);
            // 
            // mnuFile_SaveAs
            // 
            this.mnuFile_SaveAs.MergeIndex = 2;
            this.mnuFile_SaveAs.Name = "mnuFile_SaveAs";
            this.mnuFile_SaveAs.Size = new System.Drawing.Size(152, 22);
            this.mnuFile_SaveAs.Text = "Save &As…";
            this.mnuFile_SaveAs.Click += new System.EventHandler(this.mnuFile_SaveAs_Click);
            // 
            // mnuFile_Export
            // 
            this.mnuFile_Export.Image = global::ILG.Codex.CodexR4.Properties.Resources._export;
            this.mnuFile_Export.MergeIndex = 3;
            this.mnuFile_Export.Name = "mnuFile_Export";
            this.mnuFile_Export.Size = new System.Drawing.Size(152, 22);
            this.mnuFile_Export.Text = "&Export…";
            this.mnuFile_Export.Click += new System.EventHandler(this.mnuFile_Export_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.MergeIndex = 4;
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuFile_PageSetup
            // 
            this.mnuFile_PageSetup.Image = global::ILG.Codex.CodexR4.Properties.Resources.pagedialog;
            this.mnuFile_PageSetup.MergeIndex = 5;
            this.mnuFile_PageSetup.Name = "mnuFile_PageSetup";
            this.mnuFile_PageSetup.Size = new System.Drawing.Size(152, 22);
            this.mnuFile_PageSetup.Text = "Page Se&tup…";
            this.mnuFile_PageSetup.Click += new System.EventHandler(this.mnuFile_PageSetup_Click);
            // 
            // mnuFile_PrintPreview
            // 
            this.mnuFile_PrintPreview.Image = global::ILG.Codex.CodexR4.Properties.Resources.printpreview;
            this.mnuFile_PrintPreview.MergeIndex = 6;
            this.mnuFile_PrintPreview.Name = "mnuFile_PrintPreview";
            this.mnuFile_PrintPreview.Size = new System.Drawing.Size(152, 22);
            this.mnuFile_PrintPreview.Text = "Print Pre&view…";
            this.mnuFile_PrintPreview.Click += new System.EventHandler(this.mnuFile_PrintPreview_Click);
            // 
            // mnuFile_Print
            // 
            this.mnuFile_Print.Image = global::ILG.Codex.CodexR4.Properties.Resources.print;
            this.mnuFile_Print.MergeIndex = 7;
            this.mnuFile_Print.Name = "mnuFile_Print";
            this.mnuFile_Print.Size = new System.Drawing.Size(152, 22);
            this.mnuFile_Print.Text = "&Print…";
            this.mnuFile_Print.Click += new System.EventHandler(this.mnuFile_Print_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit_Undo,
            this.mnuEdit_Redo,
            this.menuItem4,
            this.mnuEdit_Cut,
            this.mnuEdit_Copy,
            this.mnuEdit_Paste,
            this.menuItem9,
            this.mnuEdit_Delete,
            this.mnuEdit_SelectAll,
            this.menuItem13,
            this.mnuEdit_Find,
            this.mnuEdit_Replace,
            this.menuItem16,
            this.mnuEdit_Hyperlink,
            this.mnuEdit_Target});
            this.mnuEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuEdit.MergeIndex = 1;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(65, 20);
            this.mnuEdit.Text = "&შეცვლა";
            this.mnuEdit.DropDownOpening += new System.EventHandler(this.mnuEdit_Popup);
            // 
            // mnuEdit_Undo
            // 
            this.mnuEdit_Undo.Image = global::ILG.Codex.CodexR4.Properties.Resources.undo;
            this.mnuEdit_Undo.MergeIndex = 0;
            this.mnuEdit_Undo.Name = "mnuEdit_Undo";
            this.mnuEdit_Undo.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Undo.Text = "&Undo";
            this.mnuEdit_Undo.Click += new System.EventHandler(this.mnuEdit_Undo_Click);
            // 
            // mnuEdit_Redo
            // 
            this.mnuEdit_Redo.Image = global::ILG.Codex.CodexR4.Properties.Resources.redo;
            this.mnuEdit_Redo.MergeIndex = 1;
            this.mnuEdit_Redo.Name = "mnuEdit_Redo";
            this.mnuEdit_Redo.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Redo.Text = "&Redo";
            this.mnuEdit_Redo.Click += new System.EventHandler(this.mnuEdit_Redo_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.MergeIndex = 2;
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuEdit_Cut
            // 
            this.mnuEdit_Cut.Image = global::ILG.Codex.CodexR4.Properties.Resources.cut;
            this.mnuEdit_Cut.MergeIndex = 3;
            this.mnuEdit_Cut.Name = "mnuEdit_Cut";
            this.mnuEdit_Cut.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Cut.Text = "Cu&t";
            this.mnuEdit_Cut.Click += new System.EventHandler(this.mnuEdit_Cut_Click);
            // 
            // mnuEdit_Copy
            // 
            this.mnuEdit_Copy.Image = global::ILG.Codex.CodexR4.Properties.Resources.copy;
            this.mnuEdit_Copy.MergeIndex = 4;
            this.mnuEdit_Copy.Name = "mnuEdit_Copy";
            this.mnuEdit_Copy.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Copy.Text = "&Copy";
            this.mnuEdit_Copy.Click += new System.EventHandler(this.mnuEdit_Copy_Click);
            // 
            // mnuEdit_Paste
            // 
            this.mnuEdit_Paste.Image = global::ILG.Codex.CodexR4.Properties.Resources.paste;
            this.mnuEdit_Paste.MergeIndex = 5;
            this.mnuEdit_Paste.Name = "mnuEdit_Paste";
            this.mnuEdit_Paste.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Paste.Text = "&Paste";
            this.mnuEdit_Paste.Click += new System.EventHandler(this.mnuEdit_Paste_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.MergeIndex = 6;
            this.menuItem9.Name = "menuItem9";
            this.menuItem9.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuEdit_Delete
            // 
            this.mnuEdit_Delete.Image = global::ILG.Codex.CodexR4.Properties.Resources.delete;
            this.mnuEdit_Delete.MergeIndex = 7;
            this.mnuEdit_Delete.Name = "mnuEdit_Delete";
            this.mnuEdit_Delete.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Delete.Text = "&Delete";
            this.mnuEdit_Delete.Click += new System.EventHandler(this.mnuEdit_Delete_Click);
            // 
            // mnuEdit_SelectAll
            // 
            this.mnuEdit_SelectAll.Image = global::ILG.Codex.CodexR4.Properties.Resources.selectall;
            this.mnuEdit_SelectAll.MergeIndex = 8;
            this.mnuEdit_SelectAll.Name = "mnuEdit_SelectAll";
            this.mnuEdit_SelectAll.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_SelectAll.Text = "Select &All";
            this.mnuEdit_SelectAll.Click += new System.EventHandler(this.mnuEdit_SelectAll_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.MergeIndex = 9;
            this.menuItem13.Name = "menuItem13";
            this.menuItem13.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuEdit_Find
            // 
            this.mnuEdit_Find.Image = global::ILG.Codex.CodexR4.Properties.Resources.find;
            this.mnuEdit_Find.MergeIndex = 10;
            this.mnuEdit_Find.Name = "mnuEdit_Find";
            this.mnuEdit_Find.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Find.Text = "&Find";
            this.mnuEdit_Find.Click += new System.EventHandler(this.mnuEdit_Find_Click);
            // 
            // mnuEdit_Replace
            // 
            this.mnuEdit_Replace.Image = global::ILG.Codex.CodexR4.Properties.Resources.replace;
            this.mnuEdit_Replace.MergeIndex = 11;
            this.mnuEdit_Replace.Name = "mnuEdit_Replace";
            this.mnuEdit_Replace.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Replace.Text = "R&eplace";
            this.mnuEdit_Replace.Click += new System.EventHandler(this.mnuEdit_Replace_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.MergeIndex = 12;
            this.menuItem16.Name = "menuItem16";
            this.menuItem16.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuEdit_Hyperlink
            // 
            this.mnuEdit_Hyperlink.Image = global::ILG.Codex.CodexR4.Properties.Resources.edithyperlink;
            this.mnuEdit_Hyperlink.MergeIndex = 13;
            this.mnuEdit_Hyperlink.Name = "mnuEdit_Hyperlink";
            this.mnuEdit_Hyperlink.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Hyperlink.Text = "&Hyperlink…";
            this.mnuEdit_Hyperlink.Click += new System.EventHandler(this.mnuEdit_Hyperlink_Click);
            // 
            // mnuEdit_Target
            // 
            this.mnuEdit_Target.Image = global::ILG.Codex.CodexR4.Properties.Resources.insertbookmark;
            this.mnuEdit_Target.MergeIndex = 14;
            this.mnuEdit_Target.Name = "mnuEdit_Target";
            this.mnuEdit_Target.Size = new System.Drawing.Size(137, 22);
            this.mnuEdit_Target.Text = "&Bookmark…";
            this.mnuEdit_Target.Click += new System.EventHandler(this.mnuEdit_Target_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView_PageLayout,
            this.mnuView_Draft,
            this.menuItem8,
            this.mnuView_HeadersAndFooters,
            this.menuItem12,
            this.mnuView_TextFrameMarkerLines,
            this.mnuView_DrawingMarkerLines,
            this.mnuView_DocumentTargetMarkers,
            this.menuItem19,
            this.mnuView_Zoom,
            this.toolStripMenuItem4,
            this._mnuView_FormLayout});
            this.mnuView.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuView.MergeIndex = 2;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(55, 20);
            this.mnuView.Text = "&ხედვა";
            this.mnuView.DropDownOpening += new System.EventHandler(this.mnuView_Popup);
            // 
            // mnuView_PageLayout
            // 
            this.mnuView_PageLayout.Image = global::ILG.Codex.CodexR4.Properties.Resources.pageviewprint;
            this.mnuView_PageLayout.MergeIndex = 1;
            this.mnuView_PageLayout.Name = "mnuView_PageLayout";
            this.mnuView_PageLayout.Size = new System.Drawing.Size(201, 22);
            this.mnuView_PageLayout.Text = "&Page Layout";
            this.mnuView_PageLayout.Click += new System.EventHandler(this.mnuView_PageLayout_Click);
            // 
            // mnuView_Draft
            // 
            this.mnuView_Draft.Image = global::ILG.Codex.CodexR4.Properties.Resources.pageviewnormal;
            this.mnuView_Draft.MergeIndex = 0;
            this.mnuView_Draft.Name = "mnuView_Draft";
            this.mnuView_Draft.Size = new System.Drawing.Size(201, 22);
            this.mnuView_Draft.Text = "&Draft";
            this.mnuView_Draft.Click += new System.EventHandler(this.mnuView_Normal_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.MergeIndex = 2;
            this.menuItem8.Name = "menuItem8";
            this.menuItem8.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuView_HeadersAndFooters
            // 
            this.mnuView_HeadersAndFooters.Image = global::ILG.Codex.CodexR4.Properties.Resources.header;
            this.mnuView_HeadersAndFooters.MergeIndex = 3;
            this.mnuView_HeadersAndFooters.Name = "mnuView_HeadersAndFooters";
            this.mnuView_HeadersAndFooters.Size = new System.Drawing.Size(201, 22);
            this.mnuView_HeadersAndFooters.Text = "&Headers and Footers";
            this.mnuView_HeadersAndFooters.Click += new System.EventHandler(this.mnuView_HeadersAndFooters_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.MergeIndex = 4;
            this.menuItem12.Name = "menuItem12";
            this.menuItem12.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuView_TextFrameMarkerLines
            // 
            this.mnuView_TextFrameMarkerLines.Checked = true;
            this.mnuView_TextFrameMarkerLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuView_TextFrameMarkerLines.MergeIndex = 8;
            this.mnuView_TextFrameMarkerLines.Name = "mnuView_TextFrameMarkerLines";
            this.mnuView_TextFrameMarkerLines.Size = new System.Drawing.Size(201, 22);
            this.mnuView_TextFrameMarkerLines.Text = "Text &Frame Marker Lines";
            this.mnuView_TextFrameMarkerLines.Click += new System.EventHandler(this.mnuView_TextFrameMarkerLines_Click);
            // 
            // mnuView_DrawingMarkerLines
            // 
            this.mnuView_DrawingMarkerLines.Checked = true;
            this.mnuView_DrawingMarkerLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuView_DrawingMarkerLines.Name = "mnuView_DrawingMarkerLines";
            this.mnuView_DrawingMarkerLines.Size = new System.Drawing.Size(201, 22);
            this.mnuView_DrawingMarkerLines.Text = "&Drawing Marker Lines";
            // 
            // mnuView_DocumentTargetMarkers
            // 
            this.mnuView_DocumentTargetMarkers.Name = "mnuView_DocumentTargetMarkers";
            this.mnuView_DocumentTargetMarkers.Size = new System.Drawing.Size(201, 22);
            this.mnuView_DocumentTargetMarkers.Text = "Bookmark &Markers";
            this.mnuView_DocumentTargetMarkers.Click += new System.EventHandler(this.mnuView_DocumentTargetMarkers_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.MergeIndex = 10;
            this.menuItem19.Name = "menuItem19";
            this.menuItem19.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuView_Zoom
            // 
            this.mnuView_Zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView_Zoom_25,
            this.mnuView_Zoom_50,
            this.mnuView_Zoom_75,
            this.mnuView_Zoom_100,
            this.mnuView_Zoom_150,
            this.mnuView_Zoom_200,
            this.mnuView_Zoom_300,
            this.pageWithToolStripMenuItem,
            this.pageHeightToolStripMenuItem,
            this.customToolStripMenuItem});
            this.mnuView_Zoom.Image = global::ILG.Codex.CodexR4.Properties.Resources.zoom;
            this.mnuView_Zoom.MergeIndex = 11;
            this.mnuView_Zoom.Name = "mnuView_Zoom";
            this.mnuView_Zoom.Size = new System.Drawing.Size(201, 22);
            this.mnuView_Zoom.Text = "&Zoom";
            this.mnuView_Zoom.DropDownOpening += new System.EventHandler(this.mnuView_Zoom_DropDownOpening);
            // 
            // mnuView_Zoom_25
            // 
            this.mnuView_Zoom_25.MergeIndex = 0;
            this.mnuView_Zoom_25.Name = "mnuView_Zoom_25";
            this.mnuView_Zoom_25.Size = new System.Drawing.Size(139, 22);
            this.mnuView_Zoom_25.Text = "&1  25%";
            this.mnuView_Zoom_25.Click += new System.EventHandler(this.mnuView_Zoom_25_Click);
            // 
            // mnuView_Zoom_50
            // 
            this.mnuView_Zoom_50.MergeIndex = 1;
            this.mnuView_Zoom_50.Name = "mnuView_Zoom_50";
            this.mnuView_Zoom_50.Size = new System.Drawing.Size(139, 22);
            this.mnuView_Zoom_50.Text = "&2  50%";
            this.mnuView_Zoom_50.Click += new System.EventHandler(this.mnuView_Zoom_50_Click);
            // 
            // mnuView_Zoom_75
            // 
            this.mnuView_Zoom_75.MergeIndex = 2;
            this.mnuView_Zoom_75.Name = "mnuView_Zoom_75";
            this.mnuView_Zoom_75.Size = new System.Drawing.Size(139, 22);
            this.mnuView_Zoom_75.Text = "&3  75%";
            this.mnuView_Zoom_75.Click += new System.EventHandler(this.mnuView_Zoom_75_Click);
            // 
            // mnuView_Zoom_100
            // 
            this.mnuView_Zoom_100.MergeIndex = 3;
            this.mnuView_Zoom_100.Name = "mnuView_Zoom_100";
            this.mnuView_Zoom_100.Size = new System.Drawing.Size(139, 22);
            this.mnuView_Zoom_100.Text = "&4  100%";
            this.mnuView_Zoom_100.Click += new System.EventHandler(this.mnuView_Zoom_100_Click);
            // 
            // mnuView_Zoom_150
            // 
            this.mnuView_Zoom_150.MergeIndex = 4;
            this.mnuView_Zoom_150.Name = "mnuView_Zoom_150";
            this.mnuView_Zoom_150.Size = new System.Drawing.Size(139, 22);
            this.mnuView_Zoom_150.Text = "&5  150%";
            this.mnuView_Zoom_150.Click += new System.EventHandler(this.mnuView_Zoom_150_Click);
            // 
            // mnuView_Zoom_200
            // 
            this.mnuView_Zoom_200.MergeIndex = 5;
            this.mnuView_Zoom_200.Name = "mnuView_Zoom_200";
            this.mnuView_Zoom_200.Size = new System.Drawing.Size(139, 22);
            this.mnuView_Zoom_200.Text = "&6  200%";
            this.mnuView_Zoom_200.Click += new System.EventHandler(this.mnuView_Zoom_200_Click);
            // 
            // mnuView_Zoom_300
            // 
            this.mnuView_Zoom_300.MergeIndex = 6;
            this.mnuView_Zoom_300.Name = "mnuView_Zoom_300";
            this.mnuView_Zoom_300.Size = new System.Drawing.Size(139, 22);
            this.mnuView_Zoom_300.Text = "&7  300%";
            this.mnuView_Zoom_300.Click += new System.EventHandler(this.mnuView_Zoom_300_Click);
            // 
            // pageWithToolStripMenuItem
            // 
            this.pageWithToolStripMenuItem.Name = "pageWithToolStripMenuItem";
            this.pageWithToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.pageWithToolStripMenuItem.Text = "Page With";
            this.pageWithToolStripMenuItem.Click += new System.EventHandler(this.pageWithToolStripMenuItem_Click);
            // 
            // pageHeightToolStripMenuItem
            // 
            this.pageHeightToolStripMenuItem.Name = "pageHeightToolStripMenuItem";
            this.pageHeightToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.pageHeightToolStripMenuItem.Text = "Page Height";
            this.pageHeightToolStripMenuItem.Click += new System.EventHandler(this.pageHeightToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.customToolStripMenuItem.Text = "Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(198, 6);
            // 
            // _mnuView_FormLayout
            // 
            this._mnuView_FormLayout.Image = global::ILG.Codex.CodexR4.Properties.Resources.formlayoutrtl;
            this._mnuView_FormLayout.Name = "_mnuView_FormLayout";
            this._mnuView_FormLayout.Size = new System.Drawing.Size(201, 22);
            this._mnuView_FormLayout.Text = "&Right to Left Layout";
            this._mnuView_FormLayout.Click += new System.EventHandler(this.mnuView_FormLayout_Click);
            // 
            // mnuInsert
            // 
            this.mnuInsert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_File,
            this.menuItem3,
            this.mnuInsert_Image,
            this.mnuInsert_TextFrame,
            this._mnuInsert_pageNum,
            this.toolStripSep_mnuInsert1,
            this._mnuInsert_Fields,
            this._mnuInsert_Symbol,
            this.toolStripSep_mnuInsert2,
            this.mnuInsert_Hyperlink,
            this.mnuInsert_Target,
            this.toolStripSep_mnuInsert3,
            this.sectionToolStripMenuItem});
            this.mnuInsert.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuInsert.MergeIndex = 3;
            this.mnuInsert.Name = "mnuInsert";
            this.mnuInsert.Size = new System.Drawing.Size(52, 20);
            this.mnuInsert.Text = "&ჩასმა";
            this.mnuInsert.DropDownOpening += new System.EventHandler(this.mnuInsert_Popup);
            // 
            // mnuInsert_File
            // 
            this.mnuInsert_File.Image = global::ILG.Codex.CodexR4.Properties.Resources.insertfile;
            this.mnuInsert_File.MergeIndex = 0;
            this.mnuInsert_File.Name = "mnuInsert_File";
            this.mnuInsert_File.Size = new System.Drawing.Size(147, 22);
            this.mnuInsert_File.Text = "&File…";
            this.mnuInsert_File.Click += new System.EventHandler(this.mnuInsert_File_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.MergeIndex = 1;
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(144, 6);
            // 
            // mnuInsert_Image
            // 
            this.mnuInsert_Image.Image = global::ILG.Codex.CodexR4.Properties.Resources.image;
            this.mnuInsert_Image.MergeIndex = 2;
            this.mnuInsert_Image.Name = "mnuInsert_Image";
            this.mnuInsert_Image.Size = new System.Drawing.Size(147, 22);
            this.mnuInsert_Image.Text = "&Image…";
            this.mnuInsert_Image.Click += new System.EventHandler(this.mnuInsert_Image_Click);
            // 
            // mnuInsert_TextFrame
            // 
            this.mnuInsert_TextFrame.Image = global::ILG.Codex.CodexR4.Properties.Resources.textframe;
            this.mnuInsert_TextFrame.MergeIndex = 3;
            this.mnuInsert_TextFrame.Name = "mnuInsert_TextFrame";
            this.mnuInsert_TextFrame.Size = new System.Drawing.Size(147, 22);
            this.mnuInsert_TextFrame.Text = "Te&xt Frame";
            this.mnuInsert_TextFrame.Click += new System.EventHandler(this.mnuInsert_TextFrame_Click);
            // 
            // _mnuInsert_pageNum
            // 
            this._mnuInsert_pageNum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuItmInsert_pageNum,
            this._mnuPageNum_delete});
            this._mnuInsert_pageNum.Image = global::ILG.Codex.CodexR4.Properties.Resources.insertpagenumber;
            this._mnuInsert_pageNum.Name = "_mnuInsert_pageNum";
            this._mnuInsert_pageNum.Size = new System.Drawing.Size(147, 22);
            this._mnuInsert_pageNum.Text = "&Page Number";
            // 
            // _mnuItmInsert_pageNum
            // 
            this._mnuItmInsert_pageNum.Image = global::ILG.Codex.CodexR4.Properties.Resources.pagenumbertop;
            this._mnuItmInsert_pageNum.Name = "_mnuItmInsert_pageNum";
            this._mnuItmInsert_pageNum.Size = new System.Drawing.Size(188, 22);
            this._mnuItmInsert_pageNum.Text = "&Insert Page Number";
            this._mnuItmInsert_pageNum.Click += new System.EventHandler(this.MnuItmPageNum_insert_Click);
            // 
            // _mnuPageNum_delete
            // 
            this._mnuPageNum_delete.Image = global::ILG.Codex.CodexR4.Properties.Resources.deletepagenumber;
            this._mnuPageNum_delete.Name = "_mnuPageNum_delete";
            this._mnuPageNum_delete.Size = new System.Drawing.Size(188, 22);
            this._mnuPageNum_delete.Text = "&Delete Page Numbers";
            this._mnuPageNum_delete.Click += new System.EventHandler(this.MnuPageNum_delete_Click);
            // 
            // toolStripSep_mnuInsert1
            // 
            this.toolStripSep_mnuInsert1.Name = "toolStripSep_mnuInsert1";
            this.toolStripSep_mnuInsert1.Size = new System.Drawing.Size(144, 6);
            // 
            // _mnuInsert_Fields
            // 
            this._mnuInsert_Fields.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuInsert_Fields_insertMergeField,
            this._mnuInsert_Fields_insertSpecialField,
            this._mnuInsert_Fields_highlightMergeFields,
            this.toolStripSeparator14,
            this._mnuInsert_Fields_showFieldCodes,
            this._mnuInsert_Fields_showFieldText,
            this._sep_field01,
            this._mnuInsert_Fields_deleteField});
            this._mnuInsert_Fields.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergeinsertfield;
            this._mnuInsert_Fields.Name = "_mnuInsert_Fields";
            this._mnuInsert_Fields.Size = new System.Drawing.Size(147, 22);
            this._mnuInsert_Fields.Text = "Fi&elds";
            this._mnuInsert_Fields.DropDownOpening += new System.EventHandler(this.MnuInsert_Fields_DropDownOpening);
            // 
            // _mnuInsert_Fields_insertMergeField
            // 
            this._mnuInsert_Fields_insertMergeField.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergeinsertfield;
            this._mnuInsert_Fields_insertMergeField.Name = "_mnuInsert_Fields_insertMergeField";
            this._mnuInsert_Fields_insertMergeField.Size = new System.Drawing.Size(194, 22);
            this._mnuInsert_Fields_insertMergeField.Text = "&Insert Merge Field";
            this._mnuInsert_Fields_insertMergeField.Click += new System.EventHandler(this.MnuInsert_Fields_insertMergeField_Click);
            // 
            // _mnuInsert_Fields_insertSpecialField
            // 
            this._mnuInsert_Fields_insertSpecialField.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuInsert_Fields_insertSpecialField_IF,
            this._mnuInsert_Fields_insertSpecialField_inclText,
            this._mnuInsert_Fields_insertSpecialField_date,
            this._mnuInsert_Fields_insertSpecialField_Next,
            this._mnuInsert_Fields_insertSpecialField_NextIf});
            this._mnuInsert_Fields_insertSpecialField.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergeiffield;
            this._mnuInsert_Fields_insertSpecialField.Name = "_mnuInsert_Fields_insertSpecialField";
            this._mnuInsert_Fields_insertSpecialField.Size = new System.Drawing.Size(194, 22);
            this._mnuInsert_Fields_insertSpecialField.Text = "Insert &Special Field";
            // 
            // _mnuInsert_Fields_insertSpecialField_IF
            // 
            this._mnuInsert_Fields_insertSpecialField_IF.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergeiffield;
            this._mnuInsert_Fields_insertSpecialField_IF.Name = "_mnuInsert_Fields_insertSpecialField_IF";
            this._mnuInsert_Fields_insertSpecialField_IF.Size = new System.Drawing.Size(134, 22);
            this._mnuInsert_Fields_insertSpecialField_IF.Text = "&IF";
            this._mnuInsert_Fields_insertSpecialField_IF.Click += new System.EventHandler(this.MnuInsert_Fields_insertSpecialField_IF_Click);
            // 
            // _mnuInsert_Fields_insertSpecialField_inclText
            // 
            this._mnuInsert_Fields_insertSpecialField_inclText.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergeincludetextfield;
            this._mnuInsert_Fields_insertSpecialField_inclText.Name = "_mnuInsert_Fields_insertSpecialField_inclText";
            this._mnuInsert_Fields_insertSpecialField_inclText.Size = new System.Drawing.Size(134, 22);
            this._mnuInsert_Fields_insertSpecialField_inclText.Text = "I&ncludeText";
            this._mnuInsert_Fields_insertSpecialField_inclText.Click += new System.EventHandler(this.MnuInsert_Fields_insertSpecialField_inclText_Click);
            // 
            // _mnuInsert_Fields_insertSpecialField_date
            // 
            this._mnuInsert_Fields_insertSpecialField_date.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergedatefield;
            this._mnuInsert_Fields_insertSpecialField_date.Name = "_mnuInsert_Fields_insertSpecialField_date";
            this._mnuInsert_Fields_insertSpecialField_date.Size = new System.Drawing.Size(134, 22);
            this._mnuInsert_Fields_insertSpecialField_date.Text = "&Date";
            this._mnuInsert_Fields_insertSpecialField_date.Click += new System.EventHandler(this.MnuInsert_Fields_insertSpecialField_date_Click);
            // 
            // _mnuInsert_Fields_insertSpecialField_Next
            // 
            this._mnuInsert_Fields_insertSpecialField_Next.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergenextfield;
            this._mnuInsert_Fields_insertSpecialField_Next.Name = "_mnuInsert_Fields_insertSpecialField_Next";
            this._mnuInsert_Fields_insertSpecialField_Next.Size = new System.Drawing.Size(134, 22);
            this._mnuInsert_Fields_insertSpecialField_Next.Text = "N&ext";
            this._mnuInsert_Fields_insertSpecialField_Next.Click += new System.EventHandler(this.mnuInsert_Fields_insertSpecialField_next_Click);
            // 
            // _mnuInsert_Fields_insertSpecialField_NextIf
            // 
            this._mnuInsert_Fields_insertSpecialField_NextIf.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergenextiffield;
            this._mnuInsert_Fields_insertSpecialField_NextIf.Name = "_mnuInsert_Fields_insertSpecialField_NextIf";
            this._mnuInsert_Fields_insertSpecialField_NextIf.Size = new System.Drawing.Size(134, 22);
            this._mnuInsert_Fields_insertSpecialField_NextIf.Text = "Ne&xtIf";
            // 
            // _mnuInsert_Fields_highlightMergeFields
            // 
            this._mnuInsert_Fields_highlightMergeFields.Checked = true;
            this._mnuInsert_Fields_highlightMergeFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this._mnuInsert_Fields_highlightMergeFields.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergehighlightfields;
            this._mnuInsert_Fields_highlightMergeFields.Name = "_mnuInsert_Fields_highlightMergeFields";
            this._mnuInsert_Fields_highlightMergeFields.Size = new System.Drawing.Size(194, 22);
            this._mnuInsert_Fields_highlightMergeFields.Text = "&Highlight Merge Fields";
            this._mnuInsert_Fields_highlightMergeFields.Click += new System.EventHandler(this.MnuInsert_Fields_highlightMergeFields_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(191, 6);
            // 
            // _mnuInsert_Fields_showFieldCodes
            // 
            this._mnuInsert_Fields_showFieldCodes.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergeshowfieldcodes;
            this._mnuInsert_Fields_showFieldCodes.Name = "_mnuInsert_Fields_showFieldCodes";
            this._mnuInsert_Fields_showFieldCodes.Size = new System.Drawing.Size(194, 22);
            this._mnuInsert_Fields_showFieldCodes.Text = "Show Field &Codes";
            this._mnuInsert_Fields_showFieldCodes.Click += new System.EventHandler(this.MnuInsert_Fields_showFieldCodes_Click);
            // 
            // _mnuInsert_Fields_showFieldText
            // 
            this._mnuInsert_Fields_showFieldText.Checked = true;
            this._mnuInsert_Fields_showFieldText.CheckState = System.Windows.Forms.CheckState.Checked;
            this._mnuInsert_Fields_showFieldText.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergeshowfieldtext;
            this._mnuInsert_Fields_showFieldText.Name = "_mnuInsert_Fields_showFieldText";
            this._mnuInsert_Fields_showFieldText.Size = new System.Drawing.Size(194, 22);
            this._mnuInsert_Fields_showFieldText.Text = "Show Field &Text";
            this._mnuInsert_Fields_showFieldText.Click += new System.EventHandler(this.MnuInsert_Fields_showFieldText_Click);
            // 
            // _sep_field01
            // 
            this._sep_field01.Name = "_sep_field01";
            this._sep_field01.Size = new System.Drawing.Size(191, 6);
            // 
            // _mnuInsert_Fields_deleteField
            // 
            this._mnuInsert_Fields_deleteField.Image = global::ILG.Codex.CodexR4.Properties.Resources.mailmergedeletefield;
            this._mnuInsert_Fields_deleteField.Name = "_mnuInsert_Fields_deleteField";
            this._mnuInsert_Fields_deleteField.Size = new System.Drawing.Size(194, 22);
            this._mnuInsert_Fields_deleteField.Text = "&Delete Field";
            this._mnuInsert_Fields_deleteField.Click += new System.EventHandler(this.MnuField_delete_Click);
            // 
            // _mnuInsert_Symbol
            // 
            this._mnuInsert_Symbol.Image = global::ILG.Codex.CodexR4.Properties.Resources.moresymbols;
            this._mnuInsert_Symbol.Name = "_mnuInsert_Symbol";
            this._mnuInsert_Symbol.Size = new System.Drawing.Size(147, 22);
            this._mnuInsert_Symbol.Text = "&Symbol…";
            // 
            // toolStripSep_mnuInsert2
            // 
            this.toolStripSep_mnuInsert2.MergeIndex = 4;
            this.toolStripSep_mnuInsert2.Name = "toolStripSep_mnuInsert2";
            this.toolStripSep_mnuInsert2.Size = new System.Drawing.Size(144, 6);
            // 
            // mnuInsert_Hyperlink
            // 
            this.mnuInsert_Hyperlink.Image = global::ILG.Codex.CodexR4.Properties.Resources.inserthyperlink;
            this.mnuInsert_Hyperlink.MergeIndex = 5;
            this.mnuInsert_Hyperlink.Name = "mnuInsert_Hyperlink";
            this.mnuInsert_Hyperlink.Size = new System.Drawing.Size(147, 22);
            this.mnuInsert_Hyperlink.Text = "&Hyperlink…";
            this.mnuInsert_Hyperlink.Click += new System.EventHandler(this.mnuInsert_Hyperlink_Click);
            // 
            // mnuInsert_Target
            // 
            this.mnuInsert_Target.Image = global::ILG.Codex.CodexR4.Properties.Resources.insertbookmark;
            this.mnuInsert_Target.MergeIndex = 6;
            this.mnuInsert_Target.Name = "mnuInsert_Target";
            this.mnuInsert_Target.Size = new System.Drawing.Size(147, 22);
            this.mnuInsert_Target.Text = "&Bookmark…";
            this.mnuInsert_Target.Click += new System.EventHandler(this.mnuInsert_Target_Click);
            // 
            // toolStripSep_mnuInsert3
            // 
            this.toolStripSep_mnuInsert3.MergeIndex = 7;
            this.toolStripSep_mnuInsert3.Name = "toolStripSep_mnuInsert3";
            this.toolStripSep_mnuInsert3.Size = new System.Drawing.Size(144, 6);
            // 
            // sectionToolStripMenuItem
            // 
            this.sectionToolStripMenuItem.Image = global::ILG.Codex.CodexR4.Properties.Resources.insertlinebreak;
            this.sectionToolStripMenuItem.Name = "sectionToolStripMenuItem";
            this.sectionToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.sectionToolStripMenuItem.Text = "Brea&k…";
            this.sectionToolStripMenuItem.Click += new System.EventHandler(this.sectionToolStripMenuItem_Click);
            // 
            // mnuFormat
            // 
            this.mnuFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_Character,
            this.mnuFormat_Paragraph,
            this.mnuFormat_List,
            this.mnuFormat_Styles,
            this.toolStripSeparator5,
            this.mnuFormat_HeadersAndFooters,
            this.mnuFormat_Columns,
            this.mnuFormat_pageframe,
            this.mnuFormat_Tabs,
            this.menuItem20,
            this._mnuFormat_Image,
            this._mnuFormat_TextFrame,
            this._mnuFormat_Shape,
            this.toolStripMenuItem3,
            this.mnuFormat_SetLanguage});
            this.mnuFormat.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuFormat.MergeIndex = 4;
            this.mnuFormat.Name = "mnuFormat";
            this.mnuFormat.Size = new System.Drawing.Size(105, 20);
            this.mnuFormat.Text = "ფო&რმატირება";
            this.mnuFormat.DropDownOpening += new System.EventHandler(this.mnuFormat_Popup);
            // 
            // mnuFormat_Character
            // 
            this.mnuFormat_Character.Image = global::ILG.Codex.CodexR4.Properties.Resources.charactersettings;
            this.mnuFormat_Character.MergeIndex = 0;
            this.mnuFormat_Character.Name = "mnuFormat_Character";
            this.mnuFormat_Character.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Character.Text = "&Character…";
            this.mnuFormat_Character.Click += new System.EventHandler(this.mnuFormat_Character_Click);
            // 
            // mnuFormat_Paragraph
            // 
            this.mnuFormat_Paragraph.Image = global::ILG.Codex.CodexR4.Properties.Resources.paragraphsettings;
            this.mnuFormat_Paragraph.MergeIndex = 1;
            this.mnuFormat_Paragraph.Name = "mnuFormat_Paragraph";
            this.mnuFormat_Paragraph.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Paragraph.Text = "&Paragraph…";
            this.mnuFormat_Paragraph.Click += new System.EventHandler(this.mnuFormat_Paragraph_Click);
            // 
            // mnuFormat_List
            // 
            this.mnuFormat_List.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_List_Attributes,
            this.mnuFormat_List_IncreaseLevel,
            this.mnuFormat_List_DecreaseLevel,
            this.menuItem28,
            this.mnuFormat_List_ArabicNumbers,
            this.mnuFormat_List_CapitalLetters,
            this.mnuFormat_List_Letters,
            this.mnuFormat_List_RomanNumbers,
            this.mnuFormat_List_SmallRomanNumbers,
            this.mnuFormat_List_Bullets});
            this.mnuFormat_List.Image = global::ILG.Codex.CodexR4.Properties.Resources.listdialog;
            this.mnuFormat_List.MergeIndex = 3;
            this.mnuFormat_List.Name = "mnuFormat_List";
            this.mnuFormat_List.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_List.Text = "Bullets and &Numbering";
            this.mnuFormat_List.DropDownOpening += new System.EventHandler(this.mnuFormat_List_DropDownOpening);
            // 
            // mnuFormat_List_Attributes
            // 
            this.mnuFormat_List_Attributes.MergeIndex = 0;
            this.mnuFormat_List_Attributes.Name = "mnuFormat_List_Attributes";
            this.mnuFormat_List_Attributes.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_Attributes.Text = "&Properties…";
            this.mnuFormat_List_Attributes.Click += new System.EventHandler(this.mnuFormat_List_Attributes_Click);
            // 
            // mnuFormat_List_IncreaseLevel
            // 
            this.mnuFormat_List_IncreaseLevel.Image = global::ILG.Codex.CodexR4.Properties.Resources.indentincrease;
            this.mnuFormat_List_IncreaseLevel.MergeIndex = 1;
            this.mnuFormat_List_IncreaseLevel.Name = "mnuFormat_List_IncreaseLevel";
            this.mnuFormat_List_IncreaseLevel.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_IncreaseLevel.Text = "&Increase Level";
            this.mnuFormat_List_IncreaseLevel.Click += new System.EventHandler(this.mnuFormat_List_IncreaseLevel_Click);
            // 
            // mnuFormat_List_DecreaseLevel
            // 
            this.mnuFormat_List_DecreaseLevel.Image = global::ILG.Codex.CodexR4.Properties.Resources.indentdecrease;
            this.mnuFormat_List_DecreaseLevel.MergeIndex = 2;
            this.mnuFormat_List_DecreaseLevel.Name = "mnuFormat_List_DecreaseLevel";
            this.mnuFormat_List_DecreaseLevel.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_DecreaseLevel.Text = "&Decrease Level";
            this.mnuFormat_List_DecreaseLevel.Click += new System.EventHandler(this.mnuFormat_List_DecreaseLevel_Click);
            // 
            // menuItem28
            // 
            this.menuItem28.MergeIndex = 3;
            this.menuItem28.Name = "menuItem28";
            this.menuItem28.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuFormat_List_ArabicNumbers
            // 
            this.mnuFormat_List_ArabicNumbers.MergeIndex = 4;
            this.mnuFormat_List_ArabicNumbers.Name = "mnuFormat_List_ArabicNumbers";
            this.mnuFormat_List_ArabicNumbers.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_ArabicNumbers.Text = "&1, 2, 3";
            this.mnuFormat_List_ArabicNumbers.Click += new System.EventHandler(this.mnuFormat_List_ArabicNumbers_Click);
            // 
            // mnuFormat_List_CapitalLetters
            // 
            this.mnuFormat_List_CapitalLetters.MergeIndex = 5;
            this.mnuFormat_List_CapitalLetters.Name = "mnuFormat_List_CapitalLetters";
            this.mnuFormat_List_CapitalLetters.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_CapitalLetters.Text = "A, &B, C";
            this.mnuFormat_List_CapitalLetters.Click += new System.EventHandler(this.mnuFormat_List_CapitalLetters_Click);
            // 
            // mnuFormat_List_Letters
            // 
            this.mnuFormat_List_Letters.MergeIndex = 6;
            this.mnuFormat_List_Letters.Name = "mnuFormat_List_Letters";
            this.mnuFormat_List_Letters.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_Letters.Text = "a, b, &c";
            this.mnuFormat_List_Letters.Click += new System.EventHandler(this.mnuFormat_List_Letters_Click);
            // 
            // mnuFormat_List_RomanNumbers
            // 
            this.mnuFormat_List_RomanNumbers.MergeIndex = 7;
            this.mnuFormat_List_RomanNumbers.Name = "mnuFormat_List_RomanNumbers";
            this.mnuFormat_List_RomanNumbers.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_RomanNumbers.Text = "&I, II, III, IV";
            this.mnuFormat_List_RomanNumbers.Click += new System.EventHandler(this.mnuFormat_List_RomanNumbers_Click);
            // 
            // mnuFormat_List_SmallRomanNumbers
            // 
            this.mnuFormat_List_SmallRomanNumbers.MergeIndex = 8;
            this.mnuFormat_List_SmallRomanNumbers.Name = "mnuFormat_List_SmallRomanNumbers";
            this.mnuFormat_List_SmallRomanNumbers.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_SmallRomanNumbers.Text = "i, ii, iii, i&v";
            this.mnuFormat_List_SmallRomanNumbers.Click += new System.EventHandler(this.mnuFormat_List_SmallRomanNumbers_Click);
            // 
            // mnuFormat_List_Bullets
            // 
            this.mnuFormat_List_Bullets.MergeIndex = 9;
            this.mnuFormat_List_Bullets.Name = "mnuFormat_List_Bullets";
            this.mnuFormat_List_Bullets.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_Bullets.Text = "B&ullets";
            this.mnuFormat_List_Bullets.Click += new System.EventHandler(this.mnuFormat_List_Bullets_Click);
            // 
            // mnuFormat_Styles
            // 
            this.mnuFormat_Styles.Image = global::ILG.Codex.CodexR4.Properties.Resources.styledialog;
            this.mnuFormat_Styles.MergeIndex = 4;
            this.mnuFormat_Styles.Name = "mnuFormat_Styles";
            this.mnuFormat_Styles.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Styles.Text = "&Styles…";
            this.mnuFormat_Styles.Click += new System.EventHandler(this.mnuFormat_Styles_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.MergeIndex = 9;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuFormat_HeadersAndFooters
            // 
            this.mnuFormat_HeadersAndFooters.Image = global::ILG.Codex.CodexR4.Properties.Resources.header;
            this.mnuFormat_HeadersAndFooters.Name = "mnuFormat_HeadersAndFooters";
            this.mnuFormat_HeadersAndFooters.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_HeadersAndFooters.Text = "&Headers and Footers…";
            this.mnuFormat_HeadersAndFooters.Click += new System.EventHandler(this.mnuFormat_HeadersFooters_Click);
            // 
            // mnuFormat_Columns
            // 
            this.mnuFormat_Columns.Image = global::ILG.Codex.CodexR4.Properties.Resources.pagecolumnstwo;
            this.mnuFormat_Columns.Name = "mnuFormat_Columns";
            this.mnuFormat_Columns.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Columns.Text = "C&olumns…";
            this.mnuFormat_Columns.Click += new System.EventHandler(this.mnuFormat_Columns_Click);
            // 
            // mnuFormat_pageframe
            // 
            this.mnuFormat_pageframe.Image = global::ILG.Codex.CodexR4.Properties.Resources.pageframedialog;
            this.mnuFormat_pageframe.Name = "mnuFormat_pageframe";
            this.mnuFormat_pageframe.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_pageframe.Text = "Page &Borders…";
            this.mnuFormat_pageframe.Click += new System.EventHandler(this.mnuFormat_borders_Click);
            // 
            // mnuFormat_Tabs
            // 
            this.mnuFormat_Tabs.Image = global::ILG.Codex.CodexR4.Properties.Resources.tabs;
            this.mnuFormat_Tabs.MergeIndex = 2;
            this.mnuFormat_Tabs.Name = "mnuFormat_Tabs";
            this.mnuFormat_Tabs.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Tabs.Text = "&Tabs…";
            this.mnuFormat_Tabs.Click += new System.EventHandler(this.mnuFormat_Tabs_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.MergeIndex = 9;
            this.menuItem20.Name = "menuItem20";
            this.menuItem20.Size = new System.Drawing.Size(193, 6);
            // 
            // _mnuFormat_Image
            // 
            this._mnuFormat_Image.Image = global::ILG.Codex.CodexR4.Properties.Resources.image;
            this._mnuFormat_Image.MergeIndex = 6;
            this._mnuFormat_Image.Name = "_mnuFormat_Image";
            this._mnuFormat_Image.Size = new System.Drawing.Size(196, 22);
            this._mnuFormat_Image.Text = "&Image…";
            this._mnuFormat_Image.Click += new System.EventHandler(this.mnuFormat_Image_Click);
            // 
            // _mnuFormat_TextFrame
            // 
            this._mnuFormat_TextFrame.Image = global::ILG.Codex.CodexR4.Properties.Resources.textframe;
            this._mnuFormat_TextFrame.MergeIndex = 7;
            this._mnuFormat_TextFrame.Name = "_mnuFormat_TextFrame";
            this._mnuFormat_TextFrame.Size = new System.Drawing.Size(196, 22);
            this._mnuFormat_TextFrame.Text = "Te&xt Frame…";
            this._mnuFormat_TextFrame.Click += new System.EventHandler(this.mnuFormat_TextFrame_Click);
            // 
            // _mnuFormat_Shape
            // 
            this._mnuFormat_Shape.MergeIndex = 8;
            this._mnuFormat_Shape.Name = "_mnuFormat_Shape";
            this._mnuFormat_Shape.Size = new System.Drawing.Size(196, 22);
            this._mnuFormat_Shape.Text = "Sha&pe…";
            this._mnuFormat_Shape.Click += new System.EventHandler(this.mnuFormat_Shape_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuFormat_SetLanguage
            // 
            this.mnuFormat_SetLanguage.Image = global::ILG.Codex.CodexR4.Properties.Resources.setlanguage;
            this.mnuFormat_SetLanguage.Name = "mnuFormat_SetLanguage";
            this.mnuFormat_SetLanguage.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_SetLanguage.Text = "&Language…";
            this.mnuFormat_SetLanguage.Click += new System.EventHandler(this.mnuFormat_SetLanguage_Click);
            // 
            // mnuTable
            // 
            this.mnuTable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Insert,
            this.mnuTable_Delete,
            this.mnuTable_Select,
            this.mnuTable_Merge_Cells,
            this.mnuTable_Split_Cells,
            this.mnuTable_Split,
            this.mnuTable_GridLines,
            this.toolStripSep_mnuTable1,
            this.mnuTable_Properties});
            this.mnuTable.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuTable.MergeIndex = 5;
            this.mnuTable.Name = "mnuTable";
            this.mnuTable.Size = new System.Drawing.Size(69, 20);
            this.mnuTable.Text = "&ცხრილი";
            this.mnuTable.DropDownOpening += new System.EventHandler(this.mnuTable_Popup);
            // 
            // mnuTable_Insert
            // 
            this.mnuTable_Insert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Insert_Table,
            this.menuItem21,
            this.mnuTable_Insert_ColumnToTheLeft,
            this.mnuTable_Insert_ColumnToTheRight,
            this.menuItem24,
            this.mnuTable_Insert_RowAbove,
            this.mnuTable_Insert_RowBelow});
            this.mnuTable_Insert.Image = global::ILG.Codex.CodexR4.Properties.Resources.table;
            this.mnuTable_Insert.MergeIndex = 0;
            this.mnuTable_Insert.Name = "mnuTable_Insert";
            this.mnuTable_Insert.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Insert.Text = "&Insert";
            this.mnuTable_Insert.DropDownOpening += new System.EventHandler(this.mnuTable_Insert_Popup);
            // 
            // mnuTable_Insert_Table
            // 
            this.mnuTable_Insert_Table.Image = global::ILG.Codex.CodexR4.Properties.Resources.table;
            this.mnuTable_Insert_Table.MergeIndex = 0;
            this.mnuTable_Insert_Table.Name = "mnuTable_Insert_Table";
            this.mnuTable_Insert_Table.Size = new System.Drawing.Size(187, 22);
            this.mnuTable_Insert_Table.Text = "&Table";
            this.mnuTable_Insert_Table.Click += new System.EventHandler(this.mnuTable_Insert_Table_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.MergeIndex = 1;
            this.menuItem21.Name = "menuItem21";
            this.menuItem21.Size = new System.Drawing.Size(184, 6);
            // 
            // mnuTable_Insert_ColumnToTheLeft
            // 
            this.mnuTable_Insert_ColumnToTheLeft.Image = global::ILG.Codex.CodexR4.Properties.Resources.inserttablecolleft;
            this.mnuTable_Insert_ColumnToTheLeft.MergeIndex = 2;
            this.mnuTable_Insert_ColumnToTheLeft.Name = "mnuTable_Insert_ColumnToTheLeft";
            this.mnuTable_Insert_ColumnToTheLeft.Size = new System.Drawing.Size(187, 22);
            this.mnuTable_Insert_ColumnToTheLeft.Text = "Column To The &Left";
            this.mnuTable_Insert_ColumnToTheLeft.Click += new System.EventHandler(this.mnuTable_Insert_ColumnToTheLeft_Click);
            // 
            // mnuTable_Insert_ColumnToTheRight
            // 
            this.mnuTable_Insert_ColumnToTheRight.Image = global::ILG.Codex.CodexR4.Properties.Resources.inserttablecolright;
            this.mnuTable_Insert_ColumnToTheRight.MergeIndex = 3;
            this.mnuTable_Insert_ColumnToTheRight.Name = "mnuTable_Insert_ColumnToTheRight";
            this.mnuTable_Insert_ColumnToTheRight.Size = new System.Drawing.Size(187, 22);
            this.mnuTable_Insert_ColumnToTheRight.Text = "Column To The &Right";
            this.mnuTable_Insert_ColumnToTheRight.Click += new System.EventHandler(this.mnuTable_Insert_ColumnToTheRight_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.MergeIndex = 4;
            this.menuItem24.Name = "menuItem24";
            this.menuItem24.Size = new System.Drawing.Size(184, 6);
            // 
            // mnuTable_Insert_RowAbove
            // 
            this.mnuTable_Insert_RowAbove.Image = global::ILG.Codex.CodexR4.Properties.Resources.inserttablerowabove;
            this.mnuTable_Insert_RowAbove.MergeIndex = 5;
            this.mnuTable_Insert_RowAbove.Name = "mnuTable_Insert_RowAbove";
            this.mnuTable_Insert_RowAbove.Size = new System.Drawing.Size(187, 22);
            this.mnuTable_Insert_RowAbove.Text = "Row &Above";
            this.mnuTable_Insert_RowAbove.Click += new System.EventHandler(this.mnuTable_Insert_RowAbove_Click);
            // 
            // mnuTable_Insert_RowBelow
            // 
            this.mnuTable_Insert_RowBelow.Image = global::ILG.Codex.CodexR4.Properties.Resources.inserttablerowbelow;
            this.mnuTable_Insert_RowBelow.MergeIndex = 6;
            this.mnuTable_Insert_RowBelow.Name = "mnuTable_Insert_RowBelow";
            this.mnuTable_Insert_RowBelow.Size = new System.Drawing.Size(187, 22);
            this.mnuTable_Insert_RowBelow.Text = "Row &Below";
            this.mnuTable_Insert_RowBelow.Click += new System.EventHandler(this.mnuTable_Insert_RowBelow_Click);
            // 
            // mnuTable_Delete
            // 
            this.mnuTable_Delete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Delete_Table,
            this.mnuTable_Delete_Column,
            this.mnuTable_Delete_Rows,
            this.mnuTable_Delete_Cells});
            this.mnuTable_Delete.Image = global::ILG.Codex.CodexR4.Properties.Resources.deletetable;
            this.mnuTable_Delete.MergeIndex = 1;
            this.mnuTable_Delete.Name = "mnuTable_Delete";
            this.mnuTable_Delete.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Delete.Text = "&Delete";
            this.mnuTable_Delete.DropDownOpening += new System.EventHandler(this.mnuTable_Delete_Popup);
            // 
            // mnuTable_Delete_Table
            // 
            this.mnuTable_Delete_Table.Image = global::ILG.Codex.CodexR4.Properties.Resources.deletetable;
            this.mnuTable_Delete_Table.MergeIndex = 0;
            this.mnuTable_Delete_Table.Name = "mnuTable_Delete_Table";
            this.mnuTable_Delete_Table.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Delete_Table.Text = "&Table";
            this.mnuTable_Delete_Table.Click += new System.EventHandler(this.mnuTable_Delete_Table_Click);
            // 
            // mnuTable_Delete_Column
            // 
            this.mnuTable_Delete_Column.Image = global::ILG.Codex.CodexR4.Properties.Resources.deletetablecol;
            this.mnuTable_Delete_Column.MergeIndex = 1;
            this.mnuTable_Delete_Column.Name = "mnuTable_Delete_Column";
            this.mnuTable_Delete_Column.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Delete_Column.Text = "&Column";
            this.mnuTable_Delete_Column.Click += new System.EventHandler(this.mnuTable_Delete_Column_Click);
            // 
            // mnuTable_Delete_Rows
            // 
            this.mnuTable_Delete_Rows.Image = global::ILG.Codex.CodexR4.Properties.Resources.deletetablerow;
            this.mnuTable_Delete_Rows.MergeIndex = 2;
            this.mnuTable_Delete_Rows.Name = "mnuTable_Delete_Rows";
            this.mnuTable_Delete_Rows.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Delete_Rows.Text = "&Rows";
            this.mnuTable_Delete_Rows.Click += new System.EventHandler(this.mnuTable_Delete_Rows_Click);
            // 
            // mnuTable_Delete_Cells
            // 
            this.mnuTable_Delete_Cells.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Delete_Cells_shiftLeft,
            this.mnuTable_Delete_Cells_entireRow,
            this.mnuTable_Delete_Cells_entireColumn});
            this.mnuTable_Delete_Cells.Image = global::ILG.Codex.CodexR4.Properties.Resources.deletetablecell;
            this.mnuTable_Delete_Cells.Name = "mnuTable_Delete_Cells";
            this.mnuTable_Delete_Cells.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Delete_Cells.Text = "C&ells…";
            // 
            // mnuTable_Delete_Cells_shiftLeft
            // 
            this.mnuTable_Delete_Cells_shiftLeft.Name = "mnuTable_Delete_Cells_shiftLeft";
            this.mnuTable_Delete_Cells_shiftLeft.Size = new System.Drawing.Size(186, 22);
            this.mnuTable_Delete_Cells_shiftLeft.Text = "Shift Cells &Left";
            this.mnuTable_Delete_Cells_shiftLeft.Click += new System.EventHandler(this.mnuTable_Delete_Cells_shiftLeft_Click);
            // 
            // mnuTable_Delete_Cells_entireRow
            // 
            this.mnuTable_Delete_Cells_entireRow.Name = "mnuTable_Delete_Cells_entireRow";
            this.mnuTable_Delete_Cells_entireRow.Size = new System.Drawing.Size(186, 22);
            this.mnuTable_Delete_Cells_entireRow.Text = "Delete Entire &Row";
            this.mnuTable_Delete_Cells_entireRow.Click += new System.EventHandler(this.mnuTable_Delete_Cells_entireRow_Click);
            // 
            // mnuTable_Delete_Cells_entireColumn
            // 
            this.mnuTable_Delete_Cells_entireColumn.Name = "mnuTable_Delete_Cells_entireColumn";
            this.mnuTable_Delete_Cells_entireColumn.Size = new System.Drawing.Size(186, 22);
            this.mnuTable_Delete_Cells_entireColumn.Text = "Delete Entire &Column";
            this.mnuTable_Delete_Cells_entireColumn.Click += new System.EventHandler(this.mnuTable_Delete_Cells_entireColumn_Click);
            // 
            // mnuTable_Select
            // 
            this.mnuTable_Select.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Select_Table,
            this.mnuTable_Select_Row,
            this.mnuTable_Select_Column,
            this.mnuTable_Select_Cell});
            this.mnuTable_Select.Image = global::ILG.Codex.CodexR4.Properties.Resources.selecttablerow;
            this.mnuTable_Select.MergeIndex = 3;
            this.mnuTable_Select.Name = "mnuTable_Select";
            this.mnuTable_Select.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Select.Text = "S&elect";
            this.mnuTable_Select.DropDownOpening += new System.EventHandler(this.mnuTable_Select_Popup);
            // 
            // mnuTable_Select_Table
            // 
            this.mnuTable_Select_Table.Image = global::ILG.Codex.CodexR4.Properties.Resources.selecttable;
            this.mnuTable_Select_Table.MergeIndex = 0;
            this.mnuTable_Select_Table.Name = "mnuTable_Select_Table";
            this.mnuTable_Select_Table.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Select_Table.Text = "&Table";
            this.mnuTable_Select_Table.Click += new System.EventHandler(this.mnuTable_Select_Table_Click);
            // 
            // mnuTable_Select_Row
            // 
            this.mnuTable_Select_Row.Image = global::ILG.Codex.CodexR4.Properties.Resources.selecttablerow;
            this.mnuTable_Select_Row.MergeIndex = 1;
            this.mnuTable_Select_Row.Name = "mnuTable_Select_Row";
            this.mnuTable_Select_Row.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Select_Row.Text = "&Row";
            this.mnuTable_Select_Row.Click += new System.EventHandler(this.mnuTable_Select_Row_Click);
            // 
            // mnuTable_Select_Column
            // 
            this.mnuTable_Select_Column.Image = global::ILG.Codex.CodexR4.Properties.Resources.selecttablecol;
            this.mnuTable_Select_Column.MergeIndex = 2;
            this.mnuTable_Select_Column.Name = "mnuTable_Select_Column";
            this.mnuTable_Select_Column.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Select_Column.Text = "&Column";
            this.mnuTable_Select_Column.Click += new System.EventHandler(this.mnuTable_Select_Column_Click);
            // 
            // mnuTable_Select_Cell
            // 
            this.mnuTable_Select_Cell.Image = global::ILG.Codex.CodexR4.Properties.Resources.selecttablecell;
            this.mnuTable_Select_Cell.MergeIndex = 3;
            this.mnuTable_Select_Cell.Name = "mnuTable_Select_Cell";
            this.mnuTable_Select_Cell.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Select_Cell.Text = "C&ell";
            this.mnuTable_Select_Cell.Click += new System.EventHandler(this.mnuTable_Select_Cell_Click);
            // 
            // mnuTable_Merge_Cells
            // 
            this.mnuTable_Merge_Cells.Image = global::ILG.Codex.CodexR4.Properties.Resources.mergetablecells;
            this.mnuTable_Merge_Cells.Name = "mnuTable_Merge_Cells";
            this.mnuTable_Merge_Cells.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Merge_Cells.Text = "&Merge Cells";
            this.mnuTable_Merge_Cells.Click += new System.EventHandler(this.mnuTable_Merge_Cells_Click);
            // 
            // mnuTable_Split_Cells
            // 
            this.mnuTable_Split_Cells.Image = global::ILG.Codex.CodexR4.Properties.Resources.splittablecells;
            this.mnuTable_Split_Cells.Name = "mnuTable_Split_Cells";
            this.mnuTable_Split_Cells.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Split_Cells.Text = "&Split Cells";
            this.mnuTable_Split_Cells.Click += new System.EventHandler(this.mnuTable_Split_Cells_Click);
            // 
            // mnuTable_Split
            // 
            this.mnuTable_Split.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Split_Above,
            this.mnuTable_Split_Below});
            this.mnuTable_Split.Image = global::ILG.Codex.CodexR4.Properties.Resources.splittable;
            this.mnuTable_Split.MergeIndex = 2;
            this.mnuTable_Split.Name = "mnuTable_Split";
            this.mnuTable_Split.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Split.Text = "S&plit Table";
            this.mnuTable_Split.DropDownOpening += new System.EventHandler(this.mnuTable_Split_DropDownOpening);
            // 
            // mnuTable_Split_Above
            // 
            this.mnuTable_Split_Above.Image = global::ILG.Codex.CodexR4.Properties.Resources.splittableabove;
            this.mnuTable_Split_Above.MergeIndex = 0;
            this.mnuTable_Split_Above.Name = "mnuTable_Split_Above";
            this.mnuTable_Split_Above.Size = new System.Drawing.Size(108, 22);
            this.mnuTable_Split_Above.Text = "&Above";
            this.mnuTable_Split_Above.Click += new System.EventHandler(this.mnuTable_Split_Above_Click);
            // 
            // mnuTable_Split_Below
            // 
            this.mnuTable_Split_Below.Image = global::ILG.Codex.CodexR4.Properties.Resources.splittablebelow;
            this.mnuTable_Split_Below.MergeIndex = 1;
            this.mnuTable_Split_Below.Name = "mnuTable_Split_Below";
            this.mnuTable_Split_Below.Size = new System.Drawing.Size(108, 22);
            this.mnuTable_Split_Below.Text = "&Below";
            this.mnuTable_Split_Below.Click += new System.EventHandler(this.mnuTable_Split_Below_Click);
            // 
            // mnuTable_GridLines
            // 
            this.mnuTable_GridLines.Image = global::ILG.Codex.CodexR4.Properties.Resources.tablegridlines;
            this.mnuTable_GridLines.MergeIndex = 4;
            this.mnuTable_GridLines.Name = "mnuTable_GridLines";
            this.mnuTable_GridLines.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_GridLines.Text = "&Grid Lines";
            this.mnuTable_GridLines.Click += new System.EventHandler(this.mnuTable_GridLines_Click);
            // 
            // toolStripSep_mnuTable1
            // 
            this.toolStripSep_mnuTable1.Name = "toolStripSep_mnuTable1";
            this.toolStripSep_mnuTable1.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuTable_Properties
            // 
            this.mnuTable_Properties.Image = global::ILG.Codex.CodexR4.Properties.Resources.tabledialog;
            this.mnuTable_Properties.MergeIndex = 5;
            this.mnuTable_Properties.Name = "mnuTable_Properties";
            this.mnuTable_Properties.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Properties.Text = "&Properties…";
            this.mnuTable_Properties.Click += new System.EventHandler(this.mnuTable_Properties_Click);
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNewFile,
            this.toolStripOpenFile,
            this.toolStripSave,
            this.toolStripSeparator1,
            this.toolStripPrint,
            this.toolStripPrintPreview,
            this.toolStripSeparator2,
            this.toolStripCut,
            this.toolStripCopy,
            this.toolStripPaste,
            this.toolStripDelete,
            this.toolStripSeparator3,
            this.toolStripUndo,
            this.toolStripRedo,
            this.toolStripFind,
            this.toolStripSeparator444,
            this.toolStripMarginsAndPaper,
            this.toolStripHeadersAndFooters,
            this.toolStripColumns,
            this.toolStripPageBorders,
            this.toolStripButton1});
            this._toolStrip.Location = new System.Drawing.Point(0, 24);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(814, 25);
            this._toolStrip.TabIndex = 0;
            // 
            // toolStripNewFile
            // 
            this.toolStripNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripNewFile.Enabled = false;
            this.toolStripNewFile.Image = global::ILG.Codex.CodexR4.Properties.Resources.newpage;
            this.toolStripNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNewFile.Name = "toolStripNewFile";
            this.toolStripNewFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripNewFile.Text = "New document";
            this.toolStripNewFile.ToolTipText = "New document";
            this.toolStripNewFile.Visible = false;
            this.toolStripNewFile.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripOpenFile
            // 
            this.toolStripOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOpenFile.Image = global::ILG.Codex.CodexR4.Properties.Resources.open;
            this.toolStripOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpenFile.Name = "toolStripOpenFile";
            this.toolStripOpenFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripOpenFile.Text = "Open document";
            this.toolStripOpenFile.ToolTipText = "Open document";
            this.toolStripOpenFile.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSave.Image = global::ILG.Codex.CodexR4.Properties.Resources.save;
            this.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripSave.Text = "Save document";
            this.toolStripSave.ToolTipText = "Save document";
            this.toolStripSave.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripPrint
            // 
            this.toolStripPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPrint.Image = global::ILG.Codex.CodexR4.Properties.Resources.print;
            this.toolStripPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPrint.Name = "toolStripPrint";
            this.toolStripPrint.Size = new System.Drawing.Size(23, 22);
            this.toolStripPrint.Text = "Print document";
            this.toolStripPrint.ToolTipText = "Print document";
            this.toolStripPrint.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripPrintPreview
            // 
            this.toolStripPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPrintPreview.Image = global::ILG.Codex.CodexR4.Properties.Resources.printpreview;
            this.toolStripPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPrintPreview.Name = "toolStripPrintPreview";
            this.toolStripPrintPreview.Size = new System.Drawing.Size(23, 22);
            this.toolStripPrintPreview.Text = "Print preview";
            this.toolStripPrintPreview.ToolTipText = "Print preview";
            this.toolStripPrintPreview.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripCut
            // 
            this.toolStripCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCut.Image = global::ILG.Codex.CodexR4.Properties.Resources.cut;
            this.toolStripCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCut.Name = "toolStripCut";
            this.toolStripCut.Size = new System.Drawing.Size(23, 22);
            this.toolStripCut.Text = "Cut";
            this.toolStripCut.ToolTipText = "Cut";
            this.toolStripCut.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripCopy
            // 
            this.toolStripCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCopy.Image = global::ILG.Codex.CodexR4.Properties.Resources.copy;
            this.toolStripCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCopy.Name = "toolStripCopy";
            this.toolStripCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripCopy.Text = "Copy";
            this.toolStripCopy.ToolTipText = "Copy";
            this.toolStripCopy.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripPaste
            // 
            this.toolStripPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPaste.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripSeparator4,
            this.toolStripMenuItem9,
            this.toolStripMenuItem5});
            this.toolStripPaste.Image = global::ILG.Codex.CodexR4.Properties.Resources.paste;
            this.toolStripPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPaste.Name = "toolStripPaste";
            this.toolStripPaste.Size = new System.Drawing.Size(32, 22);
            this.toolStripPaste.Text = "Paste";
            this.toolStripPaste.ToolTipText = "Paste";
            this.toolStripPaste.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::ILG.Codex.CodexR4.Properties.Resources.paste;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem7.Text = "Paste as RTF";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::ILG.Codex.CodexR4.Properties.Resources.paste;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem8.Text = "Paste as Text";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = global::ILG.Codex.CodexR4.Properties.Resources.paste;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem9.Text = "Paste as Image";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteAsHTMLToolStripMenuItem,
            this.pasterAsTXIMAGEToolStripMenuItem,
            this.pasterAsTXFormatToolStripMenuItem,
            this.pasteAsTxFrameToolStripMenuItem});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "Pasta as other";
            // 
            // pasteAsHTMLToolStripMenuItem
            // 
            this.pasteAsHTMLToolStripMenuItem.Name = "pasteAsHTMLToolStripMenuItem";
            this.pasteAsHTMLToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pasteAsHTMLToolStripMenuItem.Text = "Paste as HTML";
            this.pasteAsHTMLToolStripMenuItem.Click += new System.EventHandler(this.pasteAsHTMLToolStripMenuItem_Click);
            // 
            // pasterAsTXIMAGEToolStripMenuItem
            // 
            this.pasterAsTXIMAGEToolStripMenuItem.Name = "pasterAsTXIMAGEToolStripMenuItem";
            this.pasterAsTXIMAGEToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pasterAsTXIMAGEToolStripMenuItem.Text = "Paste as TX IMAGE";
            this.pasterAsTXIMAGEToolStripMenuItem.Click += new System.EventHandler(this.pasterAsTXIMAGEToolStripMenuItem_Click);
            // 
            // pasterAsTXFormatToolStripMenuItem
            // 
            this.pasterAsTXFormatToolStripMenuItem.Name = "pasterAsTXFormatToolStripMenuItem";
            this.pasterAsTXFormatToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pasterAsTXFormatToolStripMenuItem.Text = "Paste as TX Format";
            this.pasterAsTXFormatToolStripMenuItem.Click += new System.EventHandler(this.pasterAsTXFormatToolStripMenuItem_Click);
            // 
            // pasteAsTxFrameToolStripMenuItem
            // 
            this.pasteAsTxFrameToolStripMenuItem.Name = "pasteAsTxFrameToolStripMenuItem";
            this.pasteAsTxFrameToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pasteAsTxFrameToolStripMenuItem.Text = "Paste as Tx Frame";
            this.pasteAsTxFrameToolStripMenuItem.Click += new System.EventHandler(this.pasteAsTxFrameToolStripMenuItem_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDelete.Image = global::ILG.Codex.CodexR4.Properties.Resources.delete;
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripDelete.Text = "Delete selection";
            this.toolStripDelete.ToolTipText = "Delete selection";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripUndo
            // 
            this.toolStripUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripUndo.Image = global::ILG.Codex.CodexR4.Properties.Resources.undo;
            this.toolStripUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripUndo.Name = "toolStripUndo";
            this.toolStripUndo.Size = new System.Drawing.Size(23, 22);
            this.toolStripUndo.Text = "Undo";
            this.toolStripUndo.ToolTipText = "Undo";
            this.toolStripUndo.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripRedo
            // 
            this.toolStripRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRedo.Image = global::ILG.Codex.CodexR4.Properties.Resources.redo;
            this.toolStripRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRedo.Name = "toolStripRedo";
            this.toolStripRedo.Size = new System.Drawing.Size(23, 22);
            this.toolStripRedo.Text = "Redo";
            this.toolStripRedo.ToolTipText = "Redo";
            this.toolStripRedo.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // toolStripFind
            // 
            this.toolStripFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFind.Image = global::ILG.Codex.CodexR4.Properties.Resources.find;
            this.toolStripFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFind.Name = "toolStripFind";
            this.toolStripFind.Size = new System.Drawing.Size(23, 22);
            this.toolStripFind.Text = "Find";
            this.toolStripFind.ToolTipText = "Find";
            this.toolStripFind.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripSeparator444
            // 
            this.toolStripSeparator444.Name = "toolStripSeparator444";
            this.toolStripSeparator444.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMarginsAndPaper
            // 
            this.toolStripMarginsAndPaper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMarginsAndPaper.Image = global::ILG.Codex.CodexR4.Properties.Resources.pagedialog;
            this.toolStripMarginsAndPaper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMarginsAndPaper.Name = "toolStripMarginsAndPaper";
            this.toolStripMarginsAndPaper.Size = new System.Drawing.Size(23, 22);
            this.toolStripMarginsAndPaper.Text = "Margins and Paper";
            this.toolStripMarginsAndPaper.Click += new System.EventHandler(this.toolStripMarginsAndPaper_Click);
            // 
            // toolStripHeadersAndFooters
            // 
            this.toolStripHeadersAndFooters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripHeadersAndFooters.Image = global::ILG.Codex.CodexR4.Properties.Resources.hfdialog;
            this.toolStripHeadersAndFooters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripHeadersAndFooters.Name = "toolStripHeadersAndFooters";
            this.toolStripHeadersAndFooters.Size = new System.Drawing.Size(23, 22);
            this.toolStripHeadersAndFooters.Text = "Headers and Footers";
            this.toolStripHeadersAndFooters.Click += new System.EventHandler(this.toolStripHeadersAndFooters_Click);
            // 
            // toolStripColumns
            // 
            this.toolStripColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripColumns.Image = global::ILG.Codex.CodexR4.Properties.Resources.pagecolumnstwo;
            this.toolStripColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColumns.Name = "toolStripColumns";
            this.toolStripColumns.Size = new System.Drawing.Size(23, 22);
            this.toolStripColumns.Text = "Columns";
            this.toolStripColumns.ToolTipText = "Columns";
            this.toolStripColumns.Click += new System.EventHandler(this.toolStripColumns_Click);
            // 
            // toolStripPageBorders
            // 
            this.toolStripPageBorders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPageBorders.Image = global::ILG.Codex.CodexR4.Properties.Resources.pageframedialog;
            this.toolStripPageBorders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPageBorders.Name = "toolStripPageBorders";
            this.toolStripPageBorders.Size = new System.Drawing.Size(23, 22);
            this.toolStripPageBorders.Text = "Page Borders";
            this.toolStripPageBorders.Click += new System.EventHandler(this.toolStripPageBorders_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ILG.Codex.CodexR4.Properties.Resources.hand_back_16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "სექციების ამოღბა";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // _sep_pageNum01
            // 
            this._sep_pageNum01.Name = "_sep_pageNum01";
            this._sep_pageNum01.Size = new System.Drawing.Size(185, 6);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(470, 77);
            // 
            // BaseTxDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 396);
            this.Controls.Add(this.textControl);
            this.Controls.Add(this.rulerBar2);
            this.Controls.Add(this.rulerBar1);
            this.Controls.Add(this.buttonBar2);
            this.Controls.Add(this.DocumentSearchTab);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._menuStrip);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BaseTxDocument";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CodexBaseTxDocument";
            this.ResizeEnd += new System.EventHandler(this.BaseTxDocument_ResizeEnd);
            this.ultraTabPageControl13.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodexInText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodexSerachInCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentSearchTab)).EndInit();
            this.DocumentSearchTab.ResumeLayout(false);
            this._contextMenuApplicationFields.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private TXTextControl.StatusBar statusBar1;
        public Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl13;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor CodexSerachInCheck;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor CodexInText;
        public Infragistics.Win.Misc.UltraButton SearchButton;
        public Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage5;
        public Infragistics.Win.UltraWinTabControl.UltraTabControl DocumentSearchTab;
        private TXTextControl.ButtonBar buttonBar2;
        private TXTextControl.RulerBar rulerBar1;
        private TXTextControl.RulerBar rulerBar2;


        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Save;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_SaveAs;
        private System.Windows.Forms.ToolStripSeparator menuItem6;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_PageSetup;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_PrintPreview;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Print;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Undo;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Redo;
        private System.Windows.Forms.ToolStripSeparator menuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Cut;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Copy;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Paste;
        private System.Windows.Forms.ToolStripSeparator menuItem9;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Delete;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_SelectAll;
        private System.Windows.Forms.ToolStripSeparator menuItem13;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Find;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Replace;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuView_Draft;
        private System.Windows.Forms.ToolStripMenuItem mnuView_PageLayout;
        private System.Windows.Forms.ToolStripSeparator menuItem8;
        private System.Windows.Forms.ToolStripSeparator menuItem19;
        private System.Windows.Forms.ToolStripMenuItem mnuView_Zoom;
        private System.Windows.Forms.ToolStripMenuItem mnuView_Zoom_25;
        private System.Windows.Forms.ToolStripMenuItem mnuView_Zoom_50;
        private System.Windows.Forms.ToolStripMenuItem mnuView_Zoom_75;
        private System.Windows.Forms.ToolStripMenuItem mnuView_Zoom_100;
        private System.Windows.Forms.ToolStripMenuItem mnuView_Zoom_150;
        private System.Windows.Forms.ToolStripMenuItem mnuView_Zoom_200;
        private System.Windows.Forms.ToolStripMenuItem mnuView_Zoom_300;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert_File;
        private System.Windows.Forms.ToolStripSeparator menuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert_Image;
        private System.Windows.Forms.ToolStripSeparator toolStripSep_mnuInsert3;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_Character;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_Paragraph;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_Tabs;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List_Attributes;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List_IncreaseLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List_DecreaseLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List_ArabicNumbers;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List_CapitalLetters;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List_Letters;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List_RomanNumbers;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List_SmallRomanNumbers;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_List_Bullets;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_Styles;
        private System.Windows.Forms.ToolStripMenuItem _mnuFormat_Image;
        private System.Windows.Forms.ToolStripSeparator menuItem20;
        private System.Windows.Forms.ToolStripMenuItem mnuTable;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Insert;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Insert_Table;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Insert_ColumnToTheLeft;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Insert_ColumnToTheRight;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Insert_RowAbove;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Insert_RowBelow;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Delete;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Delete_Table;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Delete_Column;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Delete_Rows;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Split;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Split_Above;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Split_Below;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Select;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Select_Table;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Select_Row;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Select_Cell;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_GridLines;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Properties;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_New;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Open;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripNewFile;
        private System.Windows.Forms.ToolStripButton toolStripOpenFile;
        private System.Windows.Forms.ToolStripButton toolStripSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripPrint;
        private System.Windows.Forms.ToolStripButton toolStripPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripCut;
        private System.Windows.Forms.ToolStripButton toolStripCopy;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripUndo;
        private System.Windows.Forms.ToolStripButton toolStripRedo;
        private System.Windows.Forms.ToolStripButton toolStripFind;
        private System.Windows.Forms.ToolStripSeparator menuItem28;
        private System.Windows.Forms.ToolStripSeparator menuItem21;
        private System.Windows.Forms.ToolStripSeparator menuItem24;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Select_Column;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Merge_Cells;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Split_Cells;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Delete_Cells;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Delete_Cells_shiftLeft;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Delete_Cells_entireRow;
        private System.Windows.Forms.ToolStripMenuItem mnuTable_Delete_Cells_entireColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSep_mnuTable1;

        private System.Windows.Forms.ToolStripMenuItem mnuFile_Export;
        private System.Windows.Forms.ToolStripSeparator menuItem16;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Hyperlink;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit_Target;
        private System.Windows.Forms.ToolStripMenuItem mnuView_HeadersAndFooters;
        private System.Windows.Forms.ToolStripSeparator menuItem12;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert_TextFrame;
        private System.Windows.Forms.ToolStripSeparator toolStripSep_mnuInsert2;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert_Hyperlink;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert_Target;
        private System.Windows.Forms.ToolStripMenuItem _mnuFormat_TextFrame;
        private System.Windows.Forms.ToolStripMenuItem _mnuFormat_Shape;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator444;
        private System.Windows.Forms.ToolStripMenuItem sectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_HeadersAndFooters;
        private System.Windows.Forms.ToolStripButton toolStripColumns;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_Columns;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat_pageframe;
        private System.Windows.Forms.ToolStripSeparator toolStripSep_mnuInsert1;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Fields;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Fields_insertMergeField;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Fields_insertSpecialField;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Fields_insertSpecialField_IF;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Fields_insertSpecialField_inclText;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Fields_insertSpecialField_date;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Fields_highlightMergeFields;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Fields_showFieldCodes;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Fields_showFieldText;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_Symbol;
        private System.Windows.Forms.ContextMenuStrip _contextMenuApplicationFields;
        private System.Windows.Forms.ToolStripMenuItem _deleteFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _fieldPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mnuInsert_pageNum;
        private System.Windows.Forms.ToolStripMenuItem _mnuItmInsert_pageNum;
        private ToolStripMenuItem _mnuInsert_Fields_deleteField;
        private ToolStripMenuItem _mnuPageNum_delete;
        private ToolStripSeparator _sep_pageNum01;
        private ToolStripSeparator _sep_field01;
        private ToolStripMenuItem mnuView_TextFrameMarkerLines;
        private ToolStripMenuItem mnuView_DrawingMarkerLines;
        private ToolStripMenuItem mnuView_DocumentTargetMarkers;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripMarginsAndPaper;
        private ToolStripButton toolStripHeadersAndFooters;
        private ToolStripButton toolStripPageBorders;
        private ToolStripMenuItem _mnuInsert_Fields_insertSpecialField_Next;
        private ToolStripMenuItem _mnuInsert_Fields_insertSpecialField_NextIf;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem mnuFormat_SetLanguage;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem _mnuView_FormLayout;
        private ToolStripSplitButton toolStripPaste;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem pasteAsHTMLToolStripMenuItem;
        private ToolStripMenuItem pasterAsTXIMAGEToolStripMenuItem;
        private ToolStripMenuItem pasterAsTXFormatToolStripMenuItem;
        private ToolStripMenuItem pasteAsTxFrameToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private TXTextControl.ButtonBar buttonBar1;
        private ToolStripMenuItem pageWithToolStripMenuItem;
        private ToolStripMenuItem pageHeightToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        public Infragistics.Win.Misc.UltraButton ultraButton1;
        private TXTextControl.TextControl textControl;
    }
}