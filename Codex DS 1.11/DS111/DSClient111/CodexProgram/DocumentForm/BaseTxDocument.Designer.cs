using System.Drawing;
using System.Windows.Forms;

namespace ILG.DS.Forms.DocumentForm
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
            components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab10 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            ultraTabPageControl13 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            tableLayoutPanel1 = new TableLayoutPanel();
            ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            DSInText = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            DSSearchInCheck = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            SearchButton = new Infragistics.Win.Misc.UltraButton();
            ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            statusBar1 = new TXTextControl.StatusBar();
            ultraTabSharedControlsPage5 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            DocumentSearchTab = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            buttonBar2 = new TXTextControl.ButtonBar();
            buttonBar1 = new TXTextControl.ButtonBar();
            rulerBar1 = new TXTextControl.RulerBar();
            rulerBar2 = new TXTextControl.RulerBar();
            textControl = new TXTextControl.TextControl();
            _contextMenuApplicationFields = new ContextMenuStrip(components);
            _fieldPropertiesToolStripMenuItem = new ToolStripMenuItem();
            _deleteFieldToolStripMenuItem = new ToolStripMenuItem();
            _menuStrip = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuFile_New = new ToolStripMenuItem();
            mnuFile_Open = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            mnuFile_Save = new ToolStripMenuItem();
            mnuFile_SaveAs = new ToolStripMenuItem();
            mnuFile_Export = new ToolStripMenuItem();
            menuItem6 = new ToolStripSeparator();
            mnuFile_PageSetup = new ToolStripMenuItem();
            mnuFile_PrintPreview = new ToolStripMenuItem();
            mnuFile_Print = new ToolStripMenuItem();
            mnuEdit = new ToolStripMenuItem();
            mnuEdit_Undo = new ToolStripMenuItem();
            mnuEdit_Redo = new ToolStripMenuItem();
            menuItem4 = new ToolStripSeparator();
            mnuEdit_Cut = new ToolStripMenuItem();
            mnuEdit_Copy = new ToolStripMenuItem();
            mnuEdit_Paste = new ToolStripMenuItem();
            menuItem9 = new ToolStripSeparator();
            mnuEdit_Delete = new ToolStripMenuItem();
            mnuEdit_SelectAll = new ToolStripMenuItem();
            menuItem13 = new ToolStripSeparator();
            mnuEdit_Find = new ToolStripMenuItem();
            mnuEdit_Replace = new ToolStripMenuItem();
            menuItem16 = new ToolStripSeparator();
            mnuEdit_Hyperlink = new ToolStripMenuItem();
            mnuEdit_Target = new ToolStripMenuItem();
            mnuView = new ToolStripMenuItem();
            mnuView_PageLayout = new ToolStripMenuItem();
            mnuView_Draft = new ToolStripMenuItem();
            menuItem8 = new ToolStripSeparator();
            mnuView_HeadersAndFooters = new ToolStripMenuItem();
            menuItem12 = new ToolStripSeparator();
            mnuView_TextFrameMarkerLines = new ToolStripMenuItem();
            mnuView_DrawingMarkerLines = new ToolStripMenuItem();
            mnuView_DocumentTargetMarkers = new ToolStripMenuItem();
            menuItem19 = new ToolStripSeparator();
            mnuView_Zoom = new ToolStripMenuItem();
            mnuView_Zoom_25 = new ToolStripMenuItem();
            mnuView_Zoom_50 = new ToolStripMenuItem();
            mnuView_Zoom_75 = new ToolStripMenuItem();
            mnuView_Zoom_100 = new ToolStripMenuItem();
            mnuView_Zoom_150 = new ToolStripMenuItem();
            mnuView_Zoom_200 = new ToolStripMenuItem();
            mnuView_Zoom_300 = new ToolStripMenuItem();
            pageWithToolStripMenuItem = new ToolStripMenuItem();
            pageHeightToolStripMenuItem = new ToolStripMenuItem();
            customToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            _mnuView_FormLayout = new ToolStripMenuItem();
            mnuInsert = new ToolStripMenuItem();
            mnuInsert_File = new ToolStripMenuItem();
            menuItem3 = new ToolStripSeparator();
            mnuInsert_Image = new ToolStripMenuItem();
            mnuInsert_TextFrame = new ToolStripMenuItem();
            _mnuInsert_pageNum = new ToolStripMenuItem();
            _mnuItmInsert_pageNum = new ToolStripMenuItem();
            _mnuPageNum_delete = new ToolStripMenuItem();
            toolStripSep_mnuInsert1 = new ToolStripSeparator();
            _mnuInsert_Fields = new ToolStripMenuItem();
            _mnuInsert_Fields_insertMergeField = new ToolStripMenuItem();
            _mnuInsert_Fields_insertSpecialField = new ToolStripMenuItem();
            _mnuInsert_Fields_insertSpecialField_IF = new ToolStripMenuItem();
            _mnuInsert_Fields_insertSpecialField_inclText = new ToolStripMenuItem();
            _mnuInsert_Fields_insertSpecialField_date = new ToolStripMenuItem();
            _mnuInsert_Fields_insertSpecialField_Next = new ToolStripMenuItem();
            _mnuInsert_Fields_insertSpecialField_NextIf = new ToolStripMenuItem();
            _mnuInsert_Fields_highlightMergeFields = new ToolStripMenuItem();
            toolStripSeparator14 = new ToolStripSeparator();
            _mnuInsert_Fields_showFieldCodes = new ToolStripMenuItem();
            _mnuInsert_Fields_showFieldText = new ToolStripMenuItem();
            _sep_field01 = new ToolStripSeparator();
            _mnuInsert_Fields_deleteField = new ToolStripMenuItem();
            _mnuInsert_Symbol = new ToolStripMenuItem();
            toolStripSep_mnuInsert2 = new ToolStripSeparator();
            mnuInsert_Hyperlink = new ToolStripMenuItem();
            mnuInsert_Target = new ToolStripMenuItem();
            toolStripSep_mnuInsert3 = new ToolStripSeparator();
            sectionToolStripMenuItem = new ToolStripMenuItem();
            mnuFormat = new ToolStripMenuItem();
            mnuFormat_Character = new ToolStripMenuItem();
            mnuFormat_Paragraph = new ToolStripMenuItem();
            mnuFormat_List = new ToolStripMenuItem();
            mnuFormat_List_Attributes = new ToolStripMenuItem();
            mnuFormat_List_IncreaseLevel = new ToolStripMenuItem();
            mnuFormat_List_DecreaseLevel = new ToolStripMenuItem();
            menuItem28 = new ToolStripSeparator();
            mnuFormat_List_ArabicNumbers = new ToolStripMenuItem();
            mnuFormat_List_CapitalLetters = new ToolStripMenuItem();
            mnuFormat_List_Letters = new ToolStripMenuItem();
            mnuFormat_List_RomanNumbers = new ToolStripMenuItem();
            mnuFormat_List_SmallRomanNumbers = new ToolStripMenuItem();
            mnuFormat_List_Bullets = new ToolStripMenuItem();
            mnuFormat_Styles = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            mnuFormat_HeadersAndFooters = new ToolStripMenuItem();
            mnuFormat_Columns = new ToolStripMenuItem();
            mnuFormat_pageframe = new ToolStripMenuItem();
            mnuFormat_Tabs = new ToolStripMenuItem();
            menuItem20 = new ToolStripSeparator();
            _mnuFormat_Image = new ToolStripMenuItem();
            _mnuFormat_TextFrame = new ToolStripMenuItem();
            _mnuFormat_Shape = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            mnuFormat_SetLanguage = new ToolStripMenuItem();
            mnuTable = new ToolStripMenuItem();
            mnuTable_Insert = new ToolStripMenuItem();
            mnuTable_Insert_Table = new ToolStripMenuItem();
            menuItem21 = new ToolStripSeparator();
            mnuTable_Insert_ColumnToTheLeft = new ToolStripMenuItem();
            mnuTable_Insert_ColumnToTheRight = new ToolStripMenuItem();
            menuItem24 = new ToolStripSeparator();
            mnuTable_Insert_RowAbove = new ToolStripMenuItem();
            mnuTable_Insert_RowBelow = new ToolStripMenuItem();
            mnuTable_Delete = new ToolStripMenuItem();
            mnuTable_Delete_Table = new ToolStripMenuItem();
            mnuTable_Delete_Column = new ToolStripMenuItem();
            mnuTable_Delete_Rows = new ToolStripMenuItem();
            mnuTable_Delete_Cells = new ToolStripMenuItem();
            mnuTable_Delete_Cells_shiftLeft = new ToolStripMenuItem();
            mnuTable_Delete_Cells_entireRow = new ToolStripMenuItem();
            mnuTable_Delete_Cells_entireColumn = new ToolStripMenuItem();
            mnuTable_Select = new ToolStripMenuItem();
            mnuTable_Select_Table = new ToolStripMenuItem();
            mnuTable_Select_Row = new ToolStripMenuItem();
            mnuTable_Select_Column = new ToolStripMenuItem();
            mnuTable_Select_Cell = new ToolStripMenuItem();
            mnuTable_Merge_Cells = new ToolStripMenuItem();
            mnuTable_Split_Cells = new ToolStripMenuItem();
            mnuTable_Split = new ToolStripMenuItem();
            mnuTable_Split_Above = new ToolStripMenuItem();
            mnuTable_Split_Below = new ToolStripMenuItem();
            mnuTable_GridLines = new ToolStripMenuItem();
            toolStripSep_mnuTable1 = new ToolStripSeparator();
            mnuTable_Properties = new ToolStripMenuItem();
            _toolStrip = new ToolStrip();
            toolStripNewFile = new ToolStripButton();
            toolStripOpenFile = new ToolStripButton();
            toolStripSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripPrint = new ToolStripButton();
            toolStripPrintPreview = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripCut = new ToolStripButton();
            toolStripCopy = new ToolStripButton();
            toolStripPaste = new ToolStripSplitButton();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            pasteAsHTMLToolStripMenuItem = new ToolStripMenuItem();
            pasterAsTXIMAGEToolStripMenuItem = new ToolStripMenuItem();
            pasterAsTXFormatToolStripMenuItem = new ToolStripMenuItem();
            pasteAsTxFrameToolStripMenuItem = new ToolStripMenuItem();
            toolStripDelete = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripUndo = new ToolStripButton();
            toolStripRedo = new ToolStripButton();
            toolStripFind = new ToolStripButton();
            toolStripSeparator444 = new ToolStripSeparator();
            toolStripMarginsAndPaper = new ToolStripButton();
            toolStripHeadersAndFooters = new ToolStripButton();
            toolStripColumns = new ToolStripButton();
            toolStripPageBorders = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            _sep_pageNum01 = new ToolStripSeparator();
            BottomToolStripPanel = new ToolStripPanel();
            TopToolStripPanel = new ToolStripPanel();
            RightToolStripPanel = new ToolStripPanel();
            LeftToolStripPanel = new ToolStripPanel();
            ContentPanel = new ToolStripContentPanel();
            ultraTabPageControl13.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DSInText).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DSSearchInCheck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ultraStatusBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DocumentSearchTab).BeginInit();
            DocumentSearchTab.SuspendLayout();
            _contextMenuApplicationFields.SuspendLayout();
            _menuStrip.SuspendLayout();
            _toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ultraTabPageControl13
            // 
            ultraTabPageControl13.Controls.Add(tableLayoutPanel1);
            ultraTabPageControl13.Location = new Point(0, 0);
            ultraTabPageControl13.Margin = new Padding(3, 4, 3, 4);
            ultraTabPageControl13.Name = "ultraTabPageControl13";
            ultraTabPageControl13.Size = new Size(814, 40);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 328F));
            tableLayoutPanel1.Controls.Add(ultraButton1, 3, 0);
            tableLayoutPanel1.Controls.Add(DSInText, 0, 0);
            tableLayoutPanel1.Controls.Add(DSSearchInCheck, 2, 0);
            tableLayoutPanel1.Controls.Add(SearchButton, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(814, 40);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // ultraButton1
            // 
            ultraButton1.Anchor = AnchorStyles.Right;
            ultraButton1.AutoSize = true;
            ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013ScrollbarButton;
            ultraButton1.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ultraButton1.Location = new Point(789, 8);
            ultraButton1.Margin = new Padding(6, 4, 6, 4);
            ultraButton1.Name = "ultraButton1";
            ultraButton1.Size = new Size(19, 24);
            ultraButton1.TabIndex = 3;
            ultraButton1.Text = "X";
            ultraButton1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            ultraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            ultraButton1.Click += ultraButton1_Click;
            // 
            // DSInText
            // 
            DSInText.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DSInText.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DSInText.Location = new Point(12, 7);
            DSInText.Margin = new Padding(12, 4, 12, 4);
            DSInText.Name = "DSInText";
            DSInText.Size = new Size(247, 25);
            DSInText.TabIndex = 1;
            DSInText.TextChanged += DSInText_TextChanged;
            DSInText.KeyUp += DSInText_KeyUp;
            // 
            // DSSearchInCheck
            // 
            DSSearchInCheck.Anchor = AnchorStyles.Left;
            DSSearchInCheck.BackColor = Color.Transparent;
            DSSearchInCheck.BackColorInternal = Color.Transparent;
            DSSearchInCheck.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button;
            DSSearchInCheck.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2007CheckBoxGlyphInfo;
            DSSearchInCheck.Location = new Point(389, 8);
            DSSearchInCheck.Margin = new Padding(3, 4, 3, 4);
            DSSearchInCheck.Name = "DSSearchInCheck";
            DSSearchInCheck.Size = new Size(94, 23);
            DSSearchInCheck.TabIndex = 2;
            DSSearchInCheck.Text = "ძებნა ზევით";
            DSSearchInCheck.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            DSSearchInCheck.CheckedChanged += DSSerachInCheck_CheckedChanged;
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SearchButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton;
            SearchButton.Font = new Font("Sylfaen", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchButton.Location = new Point(277, 7);
            SearchButton.Margin = new Padding(6, 4, 6, 4);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(103, 26);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "ძებნა";
            SearchButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            SearchButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            SearchButton.Click += SearchButton_Click;
            // 
            // ultraStatusBar1
            // 
            appearance1.FontData.Name = "Sylfaen";
            appearance1.FontData.SizeInPoints = 9F;
            ultraStatusBar1.Appearance = appearance1;
            ultraStatusBar1.Location = new Point(0, 0);
            ultraStatusBar1.Name = "ultraStatusBar1";
            ultraStatusBar1.Size = new Size(0, 0);
            ultraStatusBar1.TabIndex = 0;
            // 
            // statusBar1
            // 
            statusBar1.BackColor = Color.FromArgb(34, 115, 70);
            statusBar1.ColumnText = "სვეტი  ";
            statusBar1.DisplayColors.BackColorBottom = Color.FromArgb(34, 115, 70);
            statusBar1.DisplayColors.BackColorMiddle = Color.FromArgb(34, 115, 70);
            statusBar1.DisplayColors.BackColorTop = Color.FromArgb(34, 115, 70);
            statusBar1.DisplayColors.ForeColor = Color.White;
            statusBar1.Dock = DockStyle.Bottom;
            statusBar1.Font = new Font("Segoe UI", 9F);
            statusBar1.LineText = "სტიქონი ";
            statusBar1.Location = new Point(0, 374);
            statusBar1.Name = "statusBar1";
            statusBar1.PageText = "გვერდი ";
            statusBar1.SectionText = "სექცია  ";
            statusBar1.Size = new Size(814, 22);
            statusBar1.TabIndex = 70;
            // 
            // ultraTabSharedControlsPage5
            // 
            ultraTabSharedControlsPage5.Location = new Point(-10000, -10000);
            ultraTabSharedControlsPage5.Margin = new Padding(3, 4, 3, 4);
            ultraTabSharedControlsPage5.Name = "ultraTabSharedControlsPage5";
            ultraTabSharedControlsPage5.Size = new Size(814, 40);
            // 
            // DocumentSearchTab
            // 
            DocumentSearchTab.Controls.Add(ultraTabSharedControlsPage5);
            DocumentSearchTab.Controls.Add(ultraTabPageControl13);
            DocumentSearchTab.Dock = DockStyle.Bottom;
            DocumentSearchTab.Enabled = false;
            DocumentSearchTab.Location = new Point(0, 334);
            DocumentSearchTab.Margin = new Padding(3, 4, 3, 4);
            DocumentSearchTab.Name = "DocumentSearchTab";
            DocumentSearchTab.SharedControlsPage = ultraTabSharedControlsPage5;
            DocumentSearchTab.Size = new Size(814, 40);
            DocumentSearchTab.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            DocumentSearchTab.TabIndex = 13;
            ultraTab10.TabPage = ultraTabPageControl13;
            ultraTab10.Text = "tab1";
            DocumentSearchTab.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { ultraTab10 });
            DocumentSearchTab.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            DocumentSearchTab.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            DocumentSearchTab.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            DocumentSearchTab.Visible = false;
            // 
            // buttonBar2
            // 
            buttonBar2.BackColor = SystemColors.Control;
            buttonBar2.Dock = DockStyle.Top;
            buttonBar2.Location = new Point(0, 49);
            buttonBar2.Margin = new Padding(3, 4, 3, 4);
            buttonBar2.Name = "buttonBar2";
            buttonBar2.Size = new Size(814, 29);
            buttonBar2.TabIndex = 15;
            buttonBar2.Text = "TXButtonBar";
            // 
            // buttonBar1
            // 
            buttonBar1.BackColor = SystemColors.Control;
            buttonBar1.Location = new Point(0, 0);
            buttonBar1.Name = "buttonBar1";
            buttonBar1.Size = new Size(200, 28);
            buttonBar1.TabIndex = 0;
            // 
            // rulerBar1
            // 
            rulerBar1.Dock = DockStyle.Top;
            rulerBar1.Location = new Point(0, 78);
            rulerBar1.Name = "rulerBar1";
            rulerBar1.Size = new Size(814, 25);
            rulerBar1.TabIndex = 68;
            rulerBar1.Text = "rulerBar1";
            // 
            // rulerBar2
            // 
            rulerBar2.Alignment = TXTextControl.RulerBarAlignment.Left;
            rulerBar2.Dock = DockStyle.Left;
            rulerBar2.Location = new Point(0, 103);
            rulerBar2.Name = "rulerBar2";
            rulerBar2.Size = new Size(25, 231);
            rulerBar2.TabIndex = 69;
            rulerBar2.Text = "rulerBar2";
            // 
            // textControl
            // 
            textControl.Dock = DockStyle.Fill;
            textControl.Font = new Font("Sylfaen", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textControl.FormattingPrinter = "Standard";
            textControl.HideSelection = false;
            textControl.Location = new Point(25, 103);
            textControl.Margin = new Padding(3, 4, 3, 4);
            textControl.Name = "textControl";
            textControl.PageMargins.Bottom = 79.03D;
            textControl.PageMargins.Left = 79.03D;
            textControl.PageMargins.Right = 79.03D;
            textControl.PageMargins.Top = 79.03D;
            textControl.RulerBar = rulerBar1;
            textControl.Size = new Size(789, 231);
            textControl.TabIndex = 12;
            textControl.UserNames = null;
            textControl.VerticalRulerBar = rulerBar2;
            textControl.Click += textControl_Click;
            textControl.KeyPress += textControl_KeyPress;
            textControl.KeyUp += textControl_KeyUp;
            // 
            // _contextMenuApplicationFields
            // 
            _contextMenuApplicationFields.Items.AddRange(new ToolStripItem[] { _fieldPropertiesToolStripMenuItem, _deleteFieldToolStripMenuItem });
            _contextMenuApplicationFields.Name = "_contextMenuApplicationFields";
            _contextMenuApplicationFields.Size = new Size(165, 48);
            // 
            // _fieldPropertiesToolStripMenuItem
            // 
            _fieldPropertiesToolStripMenuItem.Image = Codex.CodexR4.Properties.Resources.mailmergefieldproperties;
            _fieldPropertiesToolStripMenuItem.Name = "_fieldPropertiesToolStripMenuItem";
            _fieldPropertiesToolStripMenuItem.Size = new Size(164, 22);
            _fieldPropertiesToolStripMenuItem.Text = "Field &Properties…";
            _fieldPropertiesToolStripMenuItem.Click += FieldPropertiesToolStripMenuItem_Click;
            // 
            // _deleteFieldToolStripMenuItem
            // 
            _deleteFieldToolStripMenuItem.Image = Codex.CodexR4.Properties.Resources.mailmergedeletefield;
            _deleteFieldToolStripMenuItem.Name = "_deleteFieldToolStripMenuItem";
            _deleteFieldToolStripMenuItem.Size = new Size(164, 22);
            _deleteFieldToolStripMenuItem.Text = "&Delete Field";
            _deleteFieldToolStripMenuItem.Click += DeleteFieldToolStripMenuItem_Click;
            // 
            // _menuStrip
            // 
            _menuStrip.Items.AddRange(new ToolStripItem[] { mnuFile, mnuEdit, mnuView, mnuInsert, mnuFormat, mnuTable });
            _menuStrip.Location = new Point(0, 0);
            _menuStrip.Name = "_menuStrip";
            _menuStrip.Size = new Size(814, 24);
            _menuStrip.TabIndex = 1;
            _menuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFile_New, mnuFile_Open, toolStripMenuItem1, mnuFile_Save, mnuFile_SaveAs, mnuFile_Export, menuItem6, mnuFile_PageSetup, mnuFile_PrintPreview, mnuFile_Print });
            mnuFile.MergeIndex = 0;
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(63, 20);
            mnuFile.Text = "&ფაილი";
            mnuFile.DropDownOpening += mnuFile_DropDownOpening;
            // 
            // mnuFile_New
            // 
            mnuFile_New.Image = Codex.CodexR4.Properties.Resources.newpage;
            mnuFile_New.Name = "mnuFile_New";
            mnuFile_New.Size = new Size(152, 22);
            mnuFile_New.Text = "&ახალი";
            mnuFile_New.Click += mnuFile_New_Click;
            // 
            // mnuFile_Open
            // 
            mnuFile_Open.Image = Codex.CodexR4.Properties.Resources.open;
            mnuFile_Open.Name = "mnuFile_Open";
            mnuFile_Open.Size = new Size(152, 22);
            mnuFile_Open.Text = "&გახსნა…";
            mnuFile_Open.Click += mnuFile_Open_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(149, 6);
            // 
            // mnuFile_Save
            // 
            mnuFile_Save.Image = Codex.CodexR4.Properties.Resources.save;
            mnuFile_Save.MergeAction = MergeAction.Insert;
            mnuFile_Save.MergeIndex = 1;
            mnuFile_Save.Name = "mnuFile_Save";
            mnuFile_Save.Size = new Size(152, 22);
            mnuFile_Save.Text = "&Save";
            mnuFile_Save.Click += mnuFile_Save_Click;
            // 
            // mnuFile_SaveAs
            // 
            mnuFile_SaveAs.MergeIndex = 2;
            mnuFile_SaveAs.Name = "mnuFile_SaveAs";
            mnuFile_SaveAs.Size = new Size(152, 22);
            mnuFile_SaveAs.Text = "Save &As…";
            mnuFile_SaveAs.Click += mnuFile_SaveAs_Click;
            // 
            // mnuFile_Export
            // 
            mnuFile_Export.Image = Codex.CodexR4.Properties.Resources._export;
            mnuFile_Export.MergeIndex = 3;
            mnuFile_Export.Name = "mnuFile_Export";
            mnuFile_Export.Size = new Size(152, 22);
            mnuFile_Export.Text = "&Export…";
            mnuFile_Export.Click += mnuFile_Export_Click;
            // 
            // menuItem6
            // 
            menuItem6.MergeIndex = 4;
            menuItem6.Name = "menuItem6";
            menuItem6.Size = new Size(149, 6);
            // 
            // mnuFile_PageSetup
            // 
            mnuFile_PageSetup.Image = Codex.CodexR4.Properties.Resources.pagedialog;
            mnuFile_PageSetup.MergeIndex = 5;
            mnuFile_PageSetup.Name = "mnuFile_PageSetup";
            mnuFile_PageSetup.Size = new Size(152, 22);
            mnuFile_PageSetup.Text = "Page Se&tup…";
            mnuFile_PageSetup.Click += mnuFile_PageSetup_Click;
            // 
            // mnuFile_PrintPreview
            // 
            mnuFile_PrintPreview.Image = Codex.CodexR4.Properties.Resources.printpreview;
            mnuFile_PrintPreview.MergeIndex = 6;
            mnuFile_PrintPreview.Name = "mnuFile_PrintPreview";
            mnuFile_PrintPreview.Size = new Size(152, 22);
            mnuFile_PrintPreview.Text = "Print Pre&view…";
            mnuFile_PrintPreview.Click += mnuFile_PrintPreview_Click;
            // 
            // mnuFile_Print
            // 
            mnuFile_Print.Image = Codex.CodexR4.Properties.Resources.print;
            mnuFile_Print.MergeIndex = 7;
            mnuFile_Print.Name = "mnuFile_Print";
            mnuFile_Print.Size = new Size(152, 22);
            mnuFile_Print.Text = "&Print…";
            mnuFile_Print.Click += mnuFile_Print_Click;
            // 
            // mnuEdit
            // 
            mnuEdit.DropDownItems.AddRange(new ToolStripItem[] { mnuEdit_Undo, mnuEdit_Redo, menuItem4, mnuEdit_Cut, mnuEdit_Copy, mnuEdit_Paste, menuItem9, mnuEdit_Delete, mnuEdit_SelectAll, menuItem13, mnuEdit_Find, mnuEdit_Replace, menuItem16, mnuEdit_Hyperlink, mnuEdit_Target });
            mnuEdit.MergeAction = MergeAction.Insert;
            mnuEdit.MergeIndex = 1;
            mnuEdit.Name = "mnuEdit";
            mnuEdit.Size = new Size(65, 20);
            mnuEdit.Text = "&შეცვლა";
            mnuEdit.DropDownOpening += mnuEdit_Popup;
            // 
            // mnuEdit_Undo
            // 
            mnuEdit_Undo.Image = Codex.CodexR4.Properties.Resources.undo;
            mnuEdit_Undo.MergeIndex = 0;
            mnuEdit_Undo.Name = "mnuEdit_Undo";
            mnuEdit_Undo.Size = new Size(137, 22);
            mnuEdit_Undo.Text = "&Undo";
            mnuEdit_Undo.Click += mnuEdit_Undo_Click;
            // 
            // mnuEdit_Redo
            // 
            mnuEdit_Redo.Image = Codex.CodexR4.Properties.Resources.redo;
            mnuEdit_Redo.MergeIndex = 1;
            mnuEdit_Redo.Name = "mnuEdit_Redo";
            mnuEdit_Redo.Size = new Size(137, 22);
            mnuEdit_Redo.Text = "&Redo";
            mnuEdit_Redo.Click += mnuEdit_Redo_Click;
            // 
            // menuItem4
            // 
            menuItem4.MergeIndex = 2;
            menuItem4.Name = "menuItem4";
            menuItem4.Size = new Size(134, 6);
            // 
            // mnuEdit_Cut
            // 
            mnuEdit_Cut.Image = Codex.CodexR4.Properties.Resources.cut;
            mnuEdit_Cut.MergeIndex = 3;
            mnuEdit_Cut.Name = "mnuEdit_Cut";
            mnuEdit_Cut.Size = new Size(137, 22);
            mnuEdit_Cut.Text = "Cu&t";
            mnuEdit_Cut.Click += mnuEdit_Cut_Click;
            // 
            // mnuEdit_Copy
            // 
            mnuEdit_Copy.Image = Codex.CodexR4.Properties.Resources.copy;
            mnuEdit_Copy.MergeIndex = 4;
            mnuEdit_Copy.Name = "mnuEdit_Copy";
            mnuEdit_Copy.Size = new Size(137, 22);
            mnuEdit_Copy.Text = "&Copy";
            mnuEdit_Copy.Click += mnuEdit_Copy_Click;
            // 
            // mnuEdit_Paste
            // 
            mnuEdit_Paste.Image = Codex.CodexR4.Properties.Resources.paste;
            mnuEdit_Paste.MergeIndex = 5;
            mnuEdit_Paste.Name = "mnuEdit_Paste";
            mnuEdit_Paste.Size = new Size(137, 22);
            mnuEdit_Paste.Text = "&Paste";
            mnuEdit_Paste.Click += mnuEdit_Paste_Click;
            // 
            // menuItem9
            // 
            menuItem9.MergeIndex = 6;
            menuItem9.Name = "menuItem9";
            menuItem9.Size = new Size(134, 6);
            // 
            // mnuEdit_Delete
            // 
            mnuEdit_Delete.Image = Codex.CodexR4.Properties.Resources.delete;
            mnuEdit_Delete.MergeIndex = 7;
            mnuEdit_Delete.Name = "mnuEdit_Delete";
            mnuEdit_Delete.Size = new Size(137, 22);
            mnuEdit_Delete.Text = "&Delete";
            mnuEdit_Delete.Click += mnuEdit_Delete_Click;
            // 
            // mnuEdit_SelectAll
            // 
            mnuEdit_SelectAll.Image = Codex.CodexR4.Properties.Resources.selectall;
            mnuEdit_SelectAll.MergeIndex = 8;
            mnuEdit_SelectAll.Name = "mnuEdit_SelectAll";
            mnuEdit_SelectAll.Size = new Size(137, 22);
            mnuEdit_SelectAll.Text = "Select &All";
            mnuEdit_SelectAll.Click += mnuEdit_SelectAll_Click;
            // 
            // menuItem13
            // 
            menuItem13.MergeIndex = 9;
            menuItem13.Name = "menuItem13";
            menuItem13.Size = new Size(134, 6);
            // 
            // mnuEdit_Find
            // 
            mnuEdit_Find.Image = Codex.CodexR4.Properties.Resources.find;
            mnuEdit_Find.MergeIndex = 10;
            mnuEdit_Find.Name = "mnuEdit_Find";
            mnuEdit_Find.Size = new Size(137, 22);
            mnuEdit_Find.Text = "&Find";
            mnuEdit_Find.Click += mnuEdit_Find_Click;
            // 
            // mnuEdit_Replace
            // 
            mnuEdit_Replace.Image = Codex.CodexR4.Properties.Resources.replace;
            mnuEdit_Replace.MergeIndex = 11;
            mnuEdit_Replace.Name = "mnuEdit_Replace";
            mnuEdit_Replace.Size = new Size(137, 22);
            mnuEdit_Replace.Text = "R&eplace";
            mnuEdit_Replace.Click += mnuEdit_Replace_Click;
            // 
            // menuItem16
            // 
            menuItem16.MergeIndex = 12;
            menuItem16.Name = "menuItem16";
            menuItem16.Size = new Size(134, 6);
            // 
            // mnuEdit_Hyperlink
            // 
            mnuEdit_Hyperlink.Image = Codex.CodexR4.Properties.Resources.edithyperlink;
            mnuEdit_Hyperlink.MergeIndex = 13;
            mnuEdit_Hyperlink.Name = "mnuEdit_Hyperlink";
            mnuEdit_Hyperlink.Size = new Size(137, 22);
            mnuEdit_Hyperlink.Text = "&Hyperlink…";
            mnuEdit_Hyperlink.Click += mnuEdit_Hyperlink_Click;
            // 
            // mnuEdit_Target
            // 
            mnuEdit_Target.Image = Codex.CodexR4.Properties.Resources.insertbookmark;
            mnuEdit_Target.MergeIndex = 14;
            mnuEdit_Target.Name = "mnuEdit_Target";
            mnuEdit_Target.Size = new Size(137, 22);
            mnuEdit_Target.Text = "&Bookmark…";
            mnuEdit_Target.Click += mnuEdit_Target_Click;
            // 
            // mnuView
            // 
            mnuView.DropDownItems.AddRange(new ToolStripItem[] { mnuView_PageLayout, mnuView_Draft, menuItem8, mnuView_HeadersAndFooters, menuItem12, mnuView_TextFrameMarkerLines, mnuView_DrawingMarkerLines, mnuView_DocumentTargetMarkers, menuItem19, mnuView_Zoom, toolStripMenuItem4, _mnuView_FormLayout });
            mnuView.MergeAction = MergeAction.Insert;
            mnuView.MergeIndex = 2;
            mnuView.Name = "mnuView";
            mnuView.Size = new Size(55, 20);
            mnuView.Text = "&ხედვა";
            mnuView.DropDownOpening += mnuView_Popup;
            // 
            // mnuView_PageLayout
            // 
            mnuView_PageLayout.Image = Codex.CodexR4.Properties.Resources.pageviewprint;
            mnuView_PageLayout.MergeIndex = 1;
            mnuView_PageLayout.Name = "mnuView_PageLayout";
            mnuView_PageLayout.Size = new Size(201, 22);
            mnuView_PageLayout.Text = "&Page Layout";
            mnuView_PageLayout.Click += mnuView_PageLayout_Click;
            // 
            // mnuView_Draft
            // 
            mnuView_Draft.Image = Codex.CodexR4.Properties.Resources.pageviewnormal;
            mnuView_Draft.MergeIndex = 0;
            mnuView_Draft.Name = "mnuView_Draft";
            mnuView_Draft.Size = new Size(201, 22);
            mnuView_Draft.Text = "&Draft";
            mnuView_Draft.Click += mnuView_Normal_Click;
            // 
            // menuItem8
            // 
            menuItem8.MergeIndex = 2;
            menuItem8.Name = "menuItem8";
            menuItem8.Size = new Size(198, 6);
            // 
            // mnuView_HeadersAndFooters
            // 
            mnuView_HeadersAndFooters.Image = Codex.CodexR4.Properties.Resources.header;
            mnuView_HeadersAndFooters.MergeIndex = 3;
            mnuView_HeadersAndFooters.Name = "mnuView_HeadersAndFooters";
            mnuView_HeadersAndFooters.Size = new Size(201, 22);
            mnuView_HeadersAndFooters.Text = "&Headers and Footers";
            mnuView_HeadersAndFooters.Click += mnuView_HeadersAndFooters_Click;
            // 
            // menuItem12
            // 
            menuItem12.MergeIndex = 4;
            menuItem12.Name = "menuItem12";
            menuItem12.Size = new Size(198, 6);
            // 
            // mnuView_TextFrameMarkerLines
            // 
            mnuView_TextFrameMarkerLines.Checked = true;
            mnuView_TextFrameMarkerLines.CheckState = CheckState.Checked;
            mnuView_TextFrameMarkerLines.MergeIndex = 8;
            mnuView_TextFrameMarkerLines.Name = "mnuView_TextFrameMarkerLines";
            mnuView_TextFrameMarkerLines.Size = new Size(201, 22);
            mnuView_TextFrameMarkerLines.Text = "Text &Frame Marker Lines";
            mnuView_TextFrameMarkerLines.Click += mnuView_TextFrameMarkerLines_Click;
            // 
            // mnuView_DrawingMarkerLines
            // 
            mnuView_DrawingMarkerLines.Checked = true;
            mnuView_DrawingMarkerLines.CheckState = CheckState.Checked;
            mnuView_DrawingMarkerLines.Name = "mnuView_DrawingMarkerLines";
            mnuView_DrawingMarkerLines.Size = new Size(201, 22);
            mnuView_DrawingMarkerLines.Text = "&Drawing Marker Lines";
            // 
            // mnuView_DocumentTargetMarkers
            // 
            mnuView_DocumentTargetMarkers.Name = "mnuView_DocumentTargetMarkers";
            mnuView_DocumentTargetMarkers.Size = new Size(201, 22);
            mnuView_DocumentTargetMarkers.Text = "Bookmark &Markers";
            mnuView_DocumentTargetMarkers.Click += mnuView_DocumentTargetMarkers_Click;
            // 
            // menuItem19
            // 
            menuItem19.MergeIndex = 10;
            menuItem19.Name = "menuItem19";
            menuItem19.Size = new Size(198, 6);
            // 
            // mnuView_Zoom
            // 
            mnuView_Zoom.DropDownItems.AddRange(new ToolStripItem[] { mnuView_Zoom_25, mnuView_Zoom_50, mnuView_Zoom_75, mnuView_Zoom_100, mnuView_Zoom_150, mnuView_Zoom_200, mnuView_Zoom_300, pageWithToolStripMenuItem, pageHeightToolStripMenuItem, customToolStripMenuItem });
            mnuView_Zoom.Image = Codex.CodexR4.Properties.Resources.zoom;
            mnuView_Zoom.MergeIndex = 11;
            mnuView_Zoom.Name = "mnuView_Zoom";
            mnuView_Zoom.Size = new Size(201, 22);
            mnuView_Zoom.Text = "&Zoom";
            mnuView_Zoom.DropDownOpening += mnuView_Zoom_DropDownOpening;
            // 
            // mnuView_Zoom_25
            // 
            mnuView_Zoom_25.MergeIndex = 0;
            mnuView_Zoom_25.Name = "mnuView_Zoom_25";
            mnuView_Zoom_25.Size = new Size(139, 22);
            mnuView_Zoom_25.Text = "&1  25%";
            mnuView_Zoom_25.Click += mnuView_Zoom_25_Click;
            // 
            // mnuView_Zoom_50
            // 
            mnuView_Zoom_50.MergeIndex = 1;
            mnuView_Zoom_50.Name = "mnuView_Zoom_50";
            mnuView_Zoom_50.Size = new Size(139, 22);
            mnuView_Zoom_50.Text = "&2  50%";
            mnuView_Zoom_50.Click += mnuView_Zoom_50_Click;
            // 
            // mnuView_Zoom_75
            // 
            mnuView_Zoom_75.MergeIndex = 2;
            mnuView_Zoom_75.Name = "mnuView_Zoom_75";
            mnuView_Zoom_75.Size = new Size(139, 22);
            mnuView_Zoom_75.Text = "&3  75%";
            mnuView_Zoom_75.Click += mnuView_Zoom_75_Click;
            // 
            // mnuView_Zoom_100
            // 
            mnuView_Zoom_100.MergeIndex = 3;
            mnuView_Zoom_100.Name = "mnuView_Zoom_100";
            mnuView_Zoom_100.Size = new Size(139, 22);
            mnuView_Zoom_100.Text = "&4  100%";
            mnuView_Zoom_100.Click += mnuView_Zoom_100_Click;
            // 
            // mnuView_Zoom_150
            // 
            mnuView_Zoom_150.MergeIndex = 4;
            mnuView_Zoom_150.Name = "mnuView_Zoom_150";
            mnuView_Zoom_150.Size = new Size(139, 22);
            mnuView_Zoom_150.Text = "&5  150%";
            mnuView_Zoom_150.Click += mnuView_Zoom_150_Click;
            // 
            // mnuView_Zoom_200
            // 
            mnuView_Zoom_200.MergeIndex = 5;
            mnuView_Zoom_200.Name = "mnuView_Zoom_200";
            mnuView_Zoom_200.Size = new Size(139, 22);
            mnuView_Zoom_200.Text = "&6  200%";
            mnuView_Zoom_200.Click += mnuView_Zoom_200_Click;
            // 
            // mnuView_Zoom_300
            // 
            mnuView_Zoom_300.MergeIndex = 6;
            mnuView_Zoom_300.Name = "mnuView_Zoom_300";
            mnuView_Zoom_300.Size = new Size(139, 22);
            mnuView_Zoom_300.Text = "&7  300%";
            mnuView_Zoom_300.Click += mnuView_Zoom_300_Click;
            // 
            // pageWithToolStripMenuItem
            // 
            pageWithToolStripMenuItem.Name = "pageWithToolStripMenuItem";
            pageWithToolStripMenuItem.Size = new Size(139, 22);
            pageWithToolStripMenuItem.Text = "Page With";
            pageWithToolStripMenuItem.Click += pageWithToolStripMenuItem_Click;
            // 
            // pageHeightToolStripMenuItem
            // 
            pageHeightToolStripMenuItem.Name = "pageHeightToolStripMenuItem";
            pageHeightToolStripMenuItem.Size = new Size(139, 22);
            pageHeightToolStripMenuItem.Text = "Page Height";
            pageHeightToolStripMenuItem.Click += pageHeightToolStripMenuItem_Click;
            // 
            // customToolStripMenuItem
            // 
            customToolStripMenuItem.Name = "customToolStripMenuItem";
            customToolStripMenuItem.Size = new Size(139, 22);
            customToolStripMenuItem.Text = "Custom";
            customToolStripMenuItem.Click += customToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(198, 6);
            // 
            // _mnuView_FormLayout
            // 
            _mnuView_FormLayout.Image = Codex.CodexR4.Properties.Resources.formlayoutrtl;
            _mnuView_FormLayout.Name = "_mnuView_FormLayout";
            _mnuView_FormLayout.Size = new Size(201, 22);
            _mnuView_FormLayout.Text = "&Right to Left Layout";
            _mnuView_FormLayout.Click += mnuView_FormLayout_Click;
            // 
            // mnuInsert
            // 
            mnuInsert.DropDownItems.AddRange(new ToolStripItem[] { mnuInsert_File, menuItem3, mnuInsert_Image, mnuInsert_TextFrame, _mnuInsert_pageNum, toolStripSep_mnuInsert1, _mnuInsert_Fields, _mnuInsert_Symbol, toolStripSep_mnuInsert2, mnuInsert_Hyperlink, mnuInsert_Target, toolStripSep_mnuInsert3, sectionToolStripMenuItem });
            mnuInsert.MergeAction = MergeAction.Insert;
            mnuInsert.MergeIndex = 3;
            mnuInsert.Name = "mnuInsert";
            mnuInsert.Size = new Size(52, 20);
            mnuInsert.Text = "&ჩასმა";
            mnuInsert.DropDownOpening += mnuInsert_Popup;
            // 
            // mnuInsert_File
            // 
            mnuInsert_File.Image = Codex.CodexR4.Properties.Resources.insertfile;
            mnuInsert_File.MergeIndex = 0;
            mnuInsert_File.Name = "mnuInsert_File";
            mnuInsert_File.Size = new Size(147, 22);
            mnuInsert_File.Text = "&File…";
            mnuInsert_File.Click += mnuInsert_File_Click;
            // 
            // menuItem3
            // 
            menuItem3.MergeIndex = 1;
            menuItem3.Name = "menuItem3";
            menuItem3.Size = new Size(144, 6);
            // 
            // mnuInsert_Image
            // 
            mnuInsert_Image.Image = Codex.CodexR4.Properties.Resources.image;
            mnuInsert_Image.MergeIndex = 2;
            mnuInsert_Image.Name = "mnuInsert_Image";
            mnuInsert_Image.Size = new Size(147, 22);
            mnuInsert_Image.Text = "&Image…";
            mnuInsert_Image.Click += mnuInsert_Image_Click;
            // 
            // mnuInsert_TextFrame
            // 
            mnuInsert_TextFrame.Image = Codex.CodexR4.Properties.Resources.textframe;
            mnuInsert_TextFrame.MergeIndex = 3;
            mnuInsert_TextFrame.Name = "mnuInsert_TextFrame";
            mnuInsert_TextFrame.Size = new Size(147, 22);
            mnuInsert_TextFrame.Text = "Te&xt Frame";
            mnuInsert_TextFrame.Click += mnuInsert_TextFrame_Click;
            // 
            // _mnuInsert_pageNum
            // 
            _mnuInsert_pageNum.DropDownItems.AddRange(new ToolStripItem[] { _mnuItmInsert_pageNum, _mnuPageNum_delete });
            _mnuInsert_pageNum.Image = Codex.CodexR4.Properties.Resources.insertpagenumber;
            _mnuInsert_pageNum.Name = "_mnuInsert_pageNum";
            _mnuInsert_pageNum.Size = new Size(147, 22);
            _mnuInsert_pageNum.Text = "&Page Number";
            // 
            // _mnuItmInsert_pageNum
            // 
            _mnuItmInsert_pageNum.Image = Codex.CodexR4.Properties.Resources.pagenumbertop;
            _mnuItmInsert_pageNum.Name = "_mnuItmInsert_pageNum";
            _mnuItmInsert_pageNum.Size = new Size(188, 22);
            _mnuItmInsert_pageNum.Text = "&Insert Page Number";
            _mnuItmInsert_pageNum.Click += MnuItmPageNum_insert_Click;
            // 
            // _mnuPageNum_delete
            // 
            _mnuPageNum_delete.Image = Codex.CodexR4.Properties.Resources.deletepagenumber;
            _mnuPageNum_delete.Name = "_mnuPageNum_delete";
            _mnuPageNum_delete.Size = new Size(188, 22);
            _mnuPageNum_delete.Text = "&Delete Page Numbers";
            _mnuPageNum_delete.Click += MnuPageNum_delete_Click;
            // 
            // toolStripSep_mnuInsert1
            // 
            toolStripSep_mnuInsert1.Name = "toolStripSep_mnuInsert1";
            toolStripSep_mnuInsert1.Size = new Size(144, 6);
            // 
            // _mnuInsert_Fields
            // 
            _mnuInsert_Fields.DropDownItems.AddRange(new ToolStripItem[] { _mnuInsert_Fields_insertMergeField, _mnuInsert_Fields_insertSpecialField, _mnuInsert_Fields_highlightMergeFields, toolStripSeparator14, _mnuInsert_Fields_showFieldCodes, _mnuInsert_Fields_showFieldText, _sep_field01, _mnuInsert_Fields_deleteField });
            _mnuInsert_Fields.Image = Codex.CodexR4.Properties.Resources.mailmergeinsertfield;
            _mnuInsert_Fields.Name = "_mnuInsert_Fields";
            _mnuInsert_Fields.Size = new Size(147, 22);
            _mnuInsert_Fields.Text = "Fi&elds";
            _mnuInsert_Fields.DropDownOpening += MnuInsert_Fields_DropDownOpening;
            // 
            // _mnuInsert_Fields_insertMergeField
            // 
            _mnuInsert_Fields_insertMergeField.Image = Codex.CodexR4.Properties.Resources.mailmergeinsertfield;
            _mnuInsert_Fields_insertMergeField.Name = "_mnuInsert_Fields_insertMergeField";
            _mnuInsert_Fields_insertMergeField.Size = new Size(194, 22);
            _mnuInsert_Fields_insertMergeField.Text = "&Insert Merge Field";
            _mnuInsert_Fields_insertMergeField.Click += MnuInsert_Fields_insertMergeField_Click;
            // 
            // _mnuInsert_Fields_insertSpecialField
            // 
            _mnuInsert_Fields_insertSpecialField.DropDownItems.AddRange(new ToolStripItem[] { _mnuInsert_Fields_insertSpecialField_IF, _mnuInsert_Fields_insertSpecialField_inclText, _mnuInsert_Fields_insertSpecialField_date, _mnuInsert_Fields_insertSpecialField_Next, _mnuInsert_Fields_insertSpecialField_NextIf });
            _mnuInsert_Fields_insertSpecialField.Image = Codex.CodexR4.Properties.Resources.mailmergeiffield;
            _mnuInsert_Fields_insertSpecialField.Name = "_mnuInsert_Fields_insertSpecialField";
            _mnuInsert_Fields_insertSpecialField.Size = new Size(194, 22);
            _mnuInsert_Fields_insertSpecialField.Text = "Insert &Special Field";
            // 
            // _mnuInsert_Fields_insertSpecialField_IF
            // 
            _mnuInsert_Fields_insertSpecialField_IF.Image = Codex.CodexR4.Properties.Resources.mailmergeiffield;
            _mnuInsert_Fields_insertSpecialField_IF.Name = "_mnuInsert_Fields_insertSpecialField_IF";
            _mnuInsert_Fields_insertSpecialField_IF.Size = new Size(134, 22);
            _mnuInsert_Fields_insertSpecialField_IF.Text = "&IF";
            _mnuInsert_Fields_insertSpecialField_IF.Click += MnuInsert_Fields_insertSpecialField_IF_Click;
            // 
            // _mnuInsert_Fields_insertSpecialField_inclText
            // 
            _mnuInsert_Fields_insertSpecialField_inclText.Image = Codex.CodexR4.Properties.Resources.mailmergeincludetextfield;
            _mnuInsert_Fields_insertSpecialField_inclText.Name = "_mnuInsert_Fields_insertSpecialField_inclText";
            _mnuInsert_Fields_insertSpecialField_inclText.Size = new Size(134, 22);
            _mnuInsert_Fields_insertSpecialField_inclText.Text = "I&ncludeText";
            _mnuInsert_Fields_insertSpecialField_inclText.Click += MnuInsert_Fields_insertSpecialField_inclText_Click;
            // 
            // _mnuInsert_Fields_insertSpecialField_date
            // 
            _mnuInsert_Fields_insertSpecialField_date.Image = Codex.CodexR4.Properties.Resources.mailmergedatefield;
            _mnuInsert_Fields_insertSpecialField_date.Name = "_mnuInsert_Fields_insertSpecialField_date";
            _mnuInsert_Fields_insertSpecialField_date.Size = new Size(134, 22);
            _mnuInsert_Fields_insertSpecialField_date.Text = "&Date";
            _mnuInsert_Fields_insertSpecialField_date.Click += MnuInsert_Fields_insertSpecialField_date_Click;
            // 
            // _mnuInsert_Fields_insertSpecialField_Next
            // 
            _mnuInsert_Fields_insertSpecialField_Next.Image = Codex.CodexR4.Properties.Resources.mailmergenextfield;
            _mnuInsert_Fields_insertSpecialField_Next.Name = "_mnuInsert_Fields_insertSpecialField_Next";
            _mnuInsert_Fields_insertSpecialField_Next.Size = new Size(134, 22);
            _mnuInsert_Fields_insertSpecialField_Next.Text = "N&ext";
            _mnuInsert_Fields_insertSpecialField_Next.Click += mnuInsert_Fields_insertSpecialField_next_Click;
            // 
            // _mnuInsert_Fields_insertSpecialField_NextIf
            // 
            _mnuInsert_Fields_insertSpecialField_NextIf.Image = Codex.CodexR4.Properties.Resources.mailmergenextiffield;
            _mnuInsert_Fields_insertSpecialField_NextIf.Name = "_mnuInsert_Fields_insertSpecialField_NextIf";
            _mnuInsert_Fields_insertSpecialField_NextIf.Size = new Size(134, 22);
            _mnuInsert_Fields_insertSpecialField_NextIf.Text = "Ne&xtIf";
            // 
            // _mnuInsert_Fields_highlightMergeFields
            // 
            _mnuInsert_Fields_highlightMergeFields.Checked = true;
            _mnuInsert_Fields_highlightMergeFields.CheckState = CheckState.Checked;
            _mnuInsert_Fields_highlightMergeFields.Image = Codex.CodexR4.Properties.Resources.mailmergehighlightfields;
            _mnuInsert_Fields_highlightMergeFields.Name = "_mnuInsert_Fields_highlightMergeFields";
            _mnuInsert_Fields_highlightMergeFields.Size = new Size(194, 22);
            _mnuInsert_Fields_highlightMergeFields.Text = "&Highlight Merge Fields";
            _mnuInsert_Fields_highlightMergeFields.Click += MnuInsert_Fields_highlightMergeFields_Click;
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new Size(191, 6);
            // 
            // _mnuInsert_Fields_showFieldCodes
            // 
            _mnuInsert_Fields_showFieldCodes.Image = Codex.CodexR4.Properties.Resources.mailmergeshowfieldcodes;
            _mnuInsert_Fields_showFieldCodes.Name = "_mnuInsert_Fields_showFieldCodes";
            _mnuInsert_Fields_showFieldCodes.Size = new Size(194, 22);
            _mnuInsert_Fields_showFieldCodes.Text = "Show Field &Codes";
            _mnuInsert_Fields_showFieldCodes.Click += MnuInsert_Fields_showFieldCodes_Click;
            // 
            // _mnuInsert_Fields_showFieldText
            // 
            _mnuInsert_Fields_showFieldText.Checked = true;
            _mnuInsert_Fields_showFieldText.CheckState = CheckState.Checked;
            _mnuInsert_Fields_showFieldText.Image = Codex.CodexR4.Properties.Resources.mailmergeshowfieldtext;
            _mnuInsert_Fields_showFieldText.Name = "_mnuInsert_Fields_showFieldText";
            _mnuInsert_Fields_showFieldText.Size = new Size(194, 22);
            _mnuInsert_Fields_showFieldText.Text = "Show Field &Text";
            _mnuInsert_Fields_showFieldText.Click += MnuInsert_Fields_showFieldText_Click;
            // 
            // _sep_field01
            // 
            _sep_field01.Name = "_sep_field01";
            _sep_field01.Size = new Size(191, 6);
            // 
            // _mnuInsert_Fields_deleteField
            // 
            _mnuInsert_Fields_deleteField.Image = Codex.CodexR4.Properties.Resources.mailmergedeletefield;
            _mnuInsert_Fields_deleteField.Name = "_mnuInsert_Fields_deleteField";
            _mnuInsert_Fields_deleteField.Size = new Size(194, 22);
            _mnuInsert_Fields_deleteField.Text = "&Delete Field";
            _mnuInsert_Fields_deleteField.Click += MnuField_delete_Click;
            // 
            // _mnuInsert_Symbol
            // 
            _mnuInsert_Symbol.Image = Codex.CodexR4.Properties.Resources.moresymbols;
            _mnuInsert_Symbol.Name = "_mnuInsert_Symbol";
            _mnuInsert_Symbol.Size = new Size(147, 22);
            _mnuInsert_Symbol.Text = "&Symbol…";
            // 
            // toolStripSep_mnuInsert2
            // 
            toolStripSep_mnuInsert2.MergeIndex = 4;
            toolStripSep_mnuInsert2.Name = "toolStripSep_mnuInsert2";
            toolStripSep_mnuInsert2.Size = new Size(144, 6);
            // 
            // mnuInsert_Hyperlink
            // 
            mnuInsert_Hyperlink.Image = Codex.CodexR4.Properties.Resources.inserthyperlink;
            mnuInsert_Hyperlink.MergeIndex = 5;
            mnuInsert_Hyperlink.Name = "mnuInsert_Hyperlink";
            mnuInsert_Hyperlink.Size = new Size(147, 22);
            mnuInsert_Hyperlink.Text = "&Hyperlink…";
            mnuInsert_Hyperlink.Click += mnuInsert_Hyperlink_Click;
            // 
            // mnuInsert_Target
            // 
            mnuInsert_Target.Image = Codex.CodexR4.Properties.Resources.insertbookmark;
            mnuInsert_Target.MergeIndex = 6;
            mnuInsert_Target.Name = "mnuInsert_Target";
            mnuInsert_Target.Size = new Size(147, 22);
            mnuInsert_Target.Text = "&Bookmark…";
            mnuInsert_Target.Click += mnuInsert_Target_Click;
            // 
            // toolStripSep_mnuInsert3
            // 
            toolStripSep_mnuInsert3.MergeIndex = 7;
            toolStripSep_mnuInsert3.Name = "toolStripSep_mnuInsert3";
            toolStripSep_mnuInsert3.Size = new Size(144, 6);
            // 
            // sectionToolStripMenuItem
            // 
            sectionToolStripMenuItem.Image = Codex.CodexR4.Properties.Resources.insertlinebreak;
            sectionToolStripMenuItem.Name = "sectionToolStripMenuItem";
            sectionToolStripMenuItem.Size = new Size(147, 22);
            sectionToolStripMenuItem.Text = "Brea&k…";
            sectionToolStripMenuItem.Click += sectionToolStripMenuItem_Click;
            // 
            // mnuFormat
            // 
            mnuFormat.DropDownItems.AddRange(new ToolStripItem[] { mnuFormat_Character, mnuFormat_Paragraph, mnuFormat_List, mnuFormat_Styles, toolStripSeparator5, mnuFormat_HeadersAndFooters, mnuFormat_Columns, mnuFormat_pageframe, mnuFormat_Tabs, menuItem20, _mnuFormat_Image, _mnuFormat_TextFrame, _mnuFormat_Shape, toolStripMenuItem3, mnuFormat_SetLanguage });
            mnuFormat.MergeAction = MergeAction.Insert;
            mnuFormat.MergeIndex = 4;
            mnuFormat.Name = "mnuFormat";
            mnuFormat.Size = new Size(105, 20);
            mnuFormat.Text = "ფო&რმატირება";
            mnuFormat.DropDownOpening += mnuFormat_Popup;
            // 
            // mnuFormat_Character
            // 
            mnuFormat_Character.Image = Codex.CodexR4.Properties.Resources.charactersettings;
            mnuFormat_Character.MergeIndex = 0;
            mnuFormat_Character.Name = "mnuFormat_Character";
            mnuFormat_Character.Size = new Size(196, 22);
            mnuFormat_Character.Text = "&Character…";
            mnuFormat_Character.Click += mnuFormat_Character_Click;
            // 
            // mnuFormat_Paragraph
            // 
            mnuFormat_Paragraph.Image = Codex.CodexR4.Properties.Resources.paragraphsettings;
            mnuFormat_Paragraph.MergeIndex = 1;
            mnuFormat_Paragraph.Name = "mnuFormat_Paragraph";
            mnuFormat_Paragraph.Size = new Size(196, 22);
            mnuFormat_Paragraph.Text = "&Paragraph…";
            mnuFormat_Paragraph.Click += mnuFormat_Paragraph_Click;
            // 
            // mnuFormat_List
            // 
            mnuFormat_List.DropDownItems.AddRange(new ToolStripItem[] { mnuFormat_List_Attributes, mnuFormat_List_IncreaseLevel, mnuFormat_List_DecreaseLevel, menuItem28, mnuFormat_List_ArabicNumbers, mnuFormat_List_CapitalLetters, mnuFormat_List_Letters, mnuFormat_List_RomanNumbers, mnuFormat_List_SmallRomanNumbers, mnuFormat_List_Bullets });
            mnuFormat_List.Image = Codex.CodexR4.Properties.Resources.listdialog;
            mnuFormat_List.MergeIndex = 3;
            mnuFormat_List.Name = "mnuFormat_List";
            mnuFormat_List.Size = new Size(196, 22);
            mnuFormat_List.Text = "Bullets and &Numbering";
            mnuFormat_List.DropDownOpening += mnuFormat_List_DropDownOpening;
            // 
            // mnuFormat_List_Attributes
            // 
            mnuFormat_List_Attributes.MergeIndex = 0;
            mnuFormat_List_Attributes.Name = "mnuFormat_List_Attributes";
            mnuFormat_List_Attributes.Size = new Size(151, 22);
            mnuFormat_List_Attributes.Text = "&Properties…";
            mnuFormat_List_Attributes.Click += mnuFormat_List_Attributes_Click;
            // 
            // mnuFormat_List_IncreaseLevel
            // 
            mnuFormat_List_IncreaseLevel.Image = Codex.CodexR4.Properties.Resources.indentincrease;
            mnuFormat_List_IncreaseLevel.MergeIndex = 1;
            mnuFormat_List_IncreaseLevel.Name = "mnuFormat_List_IncreaseLevel";
            mnuFormat_List_IncreaseLevel.Size = new Size(151, 22);
            mnuFormat_List_IncreaseLevel.Text = "&Increase Level";
            mnuFormat_List_IncreaseLevel.Click += mnuFormat_List_IncreaseLevel_Click;
            // 
            // mnuFormat_List_DecreaseLevel
            // 
            mnuFormat_List_DecreaseLevel.Image = Codex.CodexR4.Properties.Resources.indentdecrease;
            mnuFormat_List_DecreaseLevel.MergeIndex = 2;
            mnuFormat_List_DecreaseLevel.Name = "mnuFormat_List_DecreaseLevel";
            mnuFormat_List_DecreaseLevel.Size = new Size(151, 22);
            mnuFormat_List_DecreaseLevel.Text = "&Decrease Level";
            mnuFormat_List_DecreaseLevel.Click += mnuFormat_List_DecreaseLevel_Click;
            // 
            // menuItem28
            // 
            menuItem28.MergeIndex = 3;
            menuItem28.Name = "menuItem28";
            menuItem28.Size = new Size(148, 6);
            // 
            // mnuFormat_List_ArabicNumbers
            // 
            mnuFormat_List_ArabicNumbers.MergeIndex = 4;
            mnuFormat_List_ArabicNumbers.Name = "mnuFormat_List_ArabicNumbers";
            mnuFormat_List_ArabicNumbers.Size = new Size(151, 22);
            mnuFormat_List_ArabicNumbers.Text = "&1, 2, 3";
            mnuFormat_List_ArabicNumbers.Click += mnuFormat_List_ArabicNumbers_Click;
            // 
            // mnuFormat_List_CapitalLetters
            // 
            mnuFormat_List_CapitalLetters.MergeIndex = 5;
            mnuFormat_List_CapitalLetters.Name = "mnuFormat_List_CapitalLetters";
            mnuFormat_List_CapitalLetters.Size = new Size(151, 22);
            mnuFormat_List_CapitalLetters.Text = "A, &B, C";
            mnuFormat_List_CapitalLetters.Click += mnuFormat_List_CapitalLetters_Click;
            // 
            // mnuFormat_List_Letters
            // 
            mnuFormat_List_Letters.MergeIndex = 6;
            mnuFormat_List_Letters.Name = "mnuFormat_List_Letters";
            mnuFormat_List_Letters.Size = new Size(151, 22);
            mnuFormat_List_Letters.Text = "a, b, &c";
            mnuFormat_List_Letters.Click += mnuFormat_List_Letters_Click;
            // 
            // mnuFormat_List_RomanNumbers
            // 
            mnuFormat_List_RomanNumbers.MergeIndex = 7;
            mnuFormat_List_RomanNumbers.Name = "mnuFormat_List_RomanNumbers";
            mnuFormat_List_RomanNumbers.Size = new Size(151, 22);
            mnuFormat_List_RomanNumbers.Text = "&I, II, III, IV";
            mnuFormat_List_RomanNumbers.Click += mnuFormat_List_RomanNumbers_Click;
            // 
            // mnuFormat_List_SmallRomanNumbers
            // 
            mnuFormat_List_SmallRomanNumbers.MergeIndex = 8;
            mnuFormat_List_SmallRomanNumbers.Name = "mnuFormat_List_SmallRomanNumbers";
            mnuFormat_List_SmallRomanNumbers.Size = new Size(151, 22);
            mnuFormat_List_SmallRomanNumbers.Text = "i, ii, iii, i&v";
            mnuFormat_List_SmallRomanNumbers.Click += mnuFormat_List_SmallRomanNumbers_Click;
            // 
            // mnuFormat_List_Bullets
            // 
            mnuFormat_List_Bullets.MergeIndex = 9;
            mnuFormat_List_Bullets.Name = "mnuFormat_List_Bullets";
            mnuFormat_List_Bullets.Size = new Size(151, 22);
            mnuFormat_List_Bullets.Text = "B&ullets";
            mnuFormat_List_Bullets.Click += mnuFormat_List_Bullets_Click;
            // 
            // mnuFormat_Styles
            // 
            mnuFormat_Styles.Image = Codex.CodexR4.Properties.Resources.styledialog;
            mnuFormat_Styles.MergeIndex = 4;
            mnuFormat_Styles.Name = "mnuFormat_Styles";
            mnuFormat_Styles.Size = new Size(196, 22);
            mnuFormat_Styles.Text = "&Styles…";
            mnuFormat_Styles.Click += mnuFormat_Styles_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.MergeIndex = 9;
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(193, 6);
            // 
            // mnuFormat_HeadersAndFooters
            // 
            mnuFormat_HeadersAndFooters.Image = Codex.CodexR4.Properties.Resources.header;
            mnuFormat_HeadersAndFooters.Name = "mnuFormat_HeadersAndFooters";
            mnuFormat_HeadersAndFooters.Size = new Size(196, 22);
            mnuFormat_HeadersAndFooters.Text = "&Headers and Footers…";
            mnuFormat_HeadersAndFooters.Click += mnuFormat_HeadersFooters_Click;
            // 
            // mnuFormat_Columns
            // 
            mnuFormat_Columns.Image = Codex.CodexR4.Properties.Resources.pagecolumnstwo;
            mnuFormat_Columns.Name = "mnuFormat_Columns";
            mnuFormat_Columns.Size = new Size(196, 22);
            mnuFormat_Columns.Text = "C&olumns…";
            mnuFormat_Columns.Click += mnuFormat_Columns_Click;
            // 
            // mnuFormat_pageframe
            // 
            mnuFormat_pageframe.Image = Codex.CodexR4.Properties.Resources.pageframedialog;
            mnuFormat_pageframe.Name = "mnuFormat_pageframe";
            mnuFormat_pageframe.Size = new Size(196, 22);
            mnuFormat_pageframe.Text = "Page &Borders…";
            mnuFormat_pageframe.Click += mnuFormat_borders_Click;
            // 
            // mnuFormat_Tabs
            // 
            mnuFormat_Tabs.Image = Codex.CodexR4.Properties.Resources.tabs;
            mnuFormat_Tabs.MergeIndex = 2;
            mnuFormat_Tabs.Name = "mnuFormat_Tabs";
            mnuFormat_Tabs.Size = new Size(196, 22);
            mnuFormat_Tabs.Text = "&Tabs…";
            mnuFormat_Tabs.Click += mnuFormat_Tabs_Click;
            // 
            // menuItem20
            // 
            menuItem20.MergeIndex = 9;
            menuItem20.Name = "menuItem20";
            menuItem20.Size = new Size(193, 6);
            // 
            // _mnuFormat_Image
            // 
            _mnuFormat_Image.Image = Codex.CodexR4.Properties.Resources.image;
            _mnuFormat_Image.MergeIndex = 6;
            _mnuFormat_Image.Name = "_mnuFormat_Image";
            _mnuFormat_Image.Size = new Size(196, 22);
            _mnuFormat_Image.Text = "&Image…";
            _mnuFormat_Image.Click += mnuFormat_Image_Click;
            // 
            // _mnuFormat_TextFrame
            // 
            _mnuFormat_TextFrame.Image = Codex.CodexR4.Properties.Resources.textframe;
            _mnuFormat_TextFrame.MergeIndex = 7;
            _mnuFormat_TextFrame.Name = "_mnuFormat_TextFrame";
            _mnuFormat_TextFrame.Size = new Size(196, 22);
            _mnuFormat_TextFrame.Text = "Te&xt Frame…";
            _mnuFormat_TextFrame.Click += mnuFormat_TextFrame_Click;
            // 
            // _mnuFormat_Shape
            // 
            _mnuFormat_Shape.MergeIndex = 8;
            _mnuFormat_Shape.Name = "_mnuFormat_Shape";
            _mnuFormat_Shape.Size = new Size(196, 22);
            _mnuFormat_Shape.Text = "Sha&pe…";
            _mnuFormat_Shape.Click += mnuFormat_Shape_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(193, 6);
            // 
            // mnuFormat_SetLanguage
            // 
            mnuFormat_SetLanguage.Image = Codex.CodexR4.Properties.Resources.setlanguage;
            mnuFormat_SetLanguage.Name = "mnuFormat_SetLanguage";
            mnuFormat_SetLanguage.Size = new Size(196, 22);
            mnuFormat_SetLanguage.Text = "&Language…";
            mnuFormat_SetLanguage.Click += mnuFormat_SetLanguage_Click;
            // 
            // mnuTable
            // 
            mnuTable.DropDownItems.AddRange(new ToolStripItem[] { mnuTable_Insert, mnuTable_Delete, mnuTable_Select, mnuTable_Merge_Cells, mnuTable_Split_Cells, mnuTable_Split, mnuTable_GridLines, toolStripSep_mnuTable1, mnuTable_Properties });
            mnuTable.MergeAction = MergeAction.Insert;
            mnuTable.MergeIndex = 5;
            mnuTable.Name = "mnuTable";
            mnuTable.Size = new Size(69, 20);
            mnuTable.Text = "&ცხრილი";
            mnuTable.DropDownOpening += mnuTable_Popup;
            // 
            // mnuTable_Insert
            // 
            mnuTable_Insert.DropDownItems.AddRange(new ToolStripItem[] { mnuTable_Insert_Table, menuItem21, mnuTable_Insert_ColumnToTheLeft, mnuTable_Insert_ColumnToTheRight, menuItem24, mnuTable_Insert_RowAbove, mnuTable_Insert_RowBelow });
            mnuTable_Insert.Image = Codex.CodexR4.Properties.Resources.table;
            mnuTable_Insert.MergeIndex = 0;
            mnuTable_Insert.Name = "mnuTable_Insert";
            mnuTable_Insert.Size = new Size(136, 22);
            mnuTable_Insert.Text = "&Insert";
            mnuTable_Insert.DropDownOpening += mnuTable_Insert_Popup;
            // 
            // mnuTable_Insert_Table
            // 
            mnuTable_Insert_Table.Image = Codex.CodexR4.Properties.Resources.table;
            mnuTable_Insert_Table.MergeIndex = 0;
            mnuTable_Insert_Table.Name = "mnuTable_Insert_Table";
            mnuTable_Insert_Table.Size = new Size(185, 22);
            mnuTable_Insert_Table.Text = "&Table";
            mnuTable_Insert_Table.Click += mnuTable_Insert_Table_Click;
            // 
            // menuItem21
            // 
            menuItem21.MergeIndex = 1;
            menuItem21.Name = "menuItem21";
            menuItem21.Size = new Size(182, 6);
            // 
            // mnuTable_Insert_ColumnToTheLeft
            // 
            mnuTable_Insert_ColumnToTheLeft.Image = Codex.CodexR4.Properties.Resources.inserttablecolleft;
            mnuTable_Insert_ColumnToTheLeft.MergeIndex = 2;
            mnuTable_Insert_ColumnToTheLeft.Name = "mnuTable_Insert_ColumnToTheLeft";
            mnuTable_Insert_ColumnToTheLeft.Size = new Size(185, 22);
            mnuTable_Insert_ColumnToTheLeft.Text = "Column To The &Left";
            mnuTable_Insert_ColumnToTheLeft.Click += mnuTable_Insert_ColumnToTheLeft_Click;
            // 
            // mnuTable_Insert_ColumnToTheRight
            // 
            mnuTable_Insert_ColumnToTheRight.Image = Codex.CodexR4.Properties.Resources.inserttablecolright;
            mnuTable_Insert_ColumnToTheRight.MergeIndex = 3;
            mnuTable_Insert_ColumnToTheRight.Name = "mnuTable_Insert_ColumnToTheRight";
            mnuTable_Insert_ColumnToTheRight.Size = new Size(185, 22);
            mnuTable_Insert_ColumnToTheRight.Text = "Column To The &Right";
            mnuTable_Insert_ColumnToTheRight.Click += mnuTable_Insert_ColumnToTheRight_Click;
            // 
            // menuItem24
            // 
            menuItem24.MergeIndex = 4;
            menuItem24.Name = "menuItem24";
            menuItem24.Size = new Size(182, 6);
            // 
            // mnuTable_Insert_RowAbove
            // 
            mnuTable_Insert_RowAbove.Image = Codex.CodexR4.Properties.Resources.inserttablerowabove;
            mnuTable_Insert_RowAbove.MergeIndex = 5;
            mnuTable_Insert_RowAbove.Name = "mnuTable_Insert_RowAbove";
            mnuTable_Insert_RowAbove.Size = new Size(185, 22);
            mnuTable_Insert_RowAbove.Text = "Row &Above";
            mnuTable_Insert_RowAbove.Click += mnuTable_Insert_RowAbove_Click;
            // 
            // mnuTable_Insert_RowBelow
            // 
            mnuTable_Insert_RowBelow.Image = Codex.CodexR4.Properties.Resources.inserttablerowbelow;
            mnuTable_Insert_RowBelow.MergeIndex = 6;
            mnuTable_Insert_RowBelow.Name = "mnuTable_Insert_RowBelow";
            mnuTable_Insert_RowBelow.Size = new Size(185, 22);
            mnuTable_Insert_RowBelow.Text = "Row &Below";
            mnuTable_Insert_RowBelow.Click += mnuTable_Insert_RowBelow_Click;
            // 
            // mnuTable_Delete
            // 
            mnuTable_Delete.DropDownItems.AddRange(new ToolStripItem[] { mnuTable_Delete_Table, mnuTable_Delete_Column, mnuTable_Delete_Rows, mnuTable_Delete_Cells });
            mnuTable_Delete.Image = Codex.CodexR4.Properties.Resources.deletetable;
            mnuTable_Delete.MergeIndex = 1;
            mnuTable_Delete.Name = "mnuTable_Delete";
            mnuTable_Delete.Size = new Size(136, 22);
            mnuTable_Delete.Text = "&Delete";
            mnuTable_Delete.DropDownOpening += mnuTable_Delete_Popup;
            // 
            // mnuTable_Delete_Table
            // 
            mnuTable_Delete_Table.Image = Codex.CodexR4.Properties.Resources.deletetable;
            mnuTable_Delete_Table.MergeIndex = 0;
            mnuTable_Delete_Table.Name = "mnuTable_Delete_Table";
            mnuTable_Delete_Table.Size = new Size(117, 22);
            mnuTable_Delete_Table.Text = "&Table";
            mnuTable_Delete_Table.Click += mnuTable_Delete_Table_Click;
            // 
            // mnuTable_Delete_Column
            // 
            mnuTable_Delete_Column.Image = Codex.CodexR4.Properties.Resources.deletetablecol;
            mnuTable_Delete_Column.MergeIndex = 1;
            mnuTable_Delete_Column.Name = "mnuTable_Delete_Column";
            mnuTable_Delete_Column.Size = new Size(117, 22);
            mnuTable_Delete_Column.Text = "&Column";
            mnuTable_Delete_Column.Click += mnuTable_Delete_Column_Click;
            // 
            // mnuTable_Delete_Rows
            // 
            mnuTable_Delete_Rows.Image = Codex.CodexR4.Properties.Resources.deletetablerow;
            mnuTable_Delete_Rows.MergeIndex = 2;
            mnuTable_Delete_Rows.Name = "mnuTable_Delete_Rows";
            mnuTable_Delete_Rows.Size = new Size(117, 22);
            mnuTable_Delete_Rows.Text = "&Rows";
            mnuTable_Delete_Rows.Click += mnuTable_Delete_Rows_Click;
            // 
            // mnuTable_Delete_Cells
            // 
            mnuTable_Delete_Cells.DropDownItems.AddRange(new ToolStripItem[] { mnuTable_Delete_Cells_shiftLeft, mnuTable_Delete_Cells_entireRow, mnuTable_Delete_Cells_entireColumn });
            mnuTable_Delete_Cells.Image = Codex.CodexR4.Properties.Resources.deletetablecell;
            mnuTable_Delete_Cells.Name = "mnuTable_Delete_Cells";
            mnuTable_Delete_Cells.Size = new Size(117, 22);
            mnuTable_Delete_Cells.Text = "C&ells…";
            // 
            // mnuTable_Delete_Cells_shiftLeft
            // 
            mnuTable_Delete_Cells_shiftLeft.Name = "mnuTable_Delete_Cells_shiftLeft";
            mnuTable_Delete_Cells_shiftLeft.Size = new Size(186, 22);
            mnuTable_Delete_Cells_shiftLeft.Text = "Shift Cells &Left";
            mnuTable_Delete_Cells_shiftLeft.Click += mnuTable_Delete_Cells_shiftLeft_Click;
            // 
            // mnuTable_Delete_Cells_entireRow
            // 
            mnuTable_Delete_Cells_entireRow.Name = "mnuTable_Delete_Cells_entireRow";
            mnuTable_Delete_Cells_entireRow.Size = new Size(186, 22);
            mnuTable_Delete_Cells_entireRow.Text = "Delete Entire &Row";
            mnuTable_Delete_Cells_entireRow.Click += mnuTable_Delete_Cells_entireRow_Click;
            // 
            // mnuTable_Delete_Cells_entireColumn
            // 
            mnuTable_Delete_Cells_entireColumn.Name = "mnuTable_Delete_Cells_entireColumn";
            mnuTable_Delete_Cells_entireColumn.Size = new Size(186, 22);
            mnuTable_Delete_Cells_entireColumn.Text = "Delete Entire &Column";
            mnuTable_Delete_Cells_entireColumn.Click += mnuTable_Delete_Cells_entireColumn_Click;
            // 
            // mnuTable_Select
            // 
            mnuTable_Select.DropDownItems.AddRange(new ToolStripItem[] { mnuTable_Select_Table, mnuTable_Select_Row, mnuTable_Select_Column, mnuTable_Select_Cell });
            mnuTable_Select.Image = Codex.CodexR4.Properties.Resources.selecttablerow;
            mnuTable_Select.MergeIndex = 3;
            mnuTable_Select.Name = "mnuTable_Select";
            mnuTable_Select.Size = new Size(136, 22);
            mnuTable_Select.Text = "S&elect";
            mnuTable_Select.DropDownOpening += mnuTable_Select_Popup;
            // 
            // mnuTable_Select_Table
            // 
            mnuTable_Select_Table.Image = Codex.CodexR4.Properties.Resources.selecttable;
            mnuTable_Select_Table.MergeIndex = 0;
            mnuTable_Select_Table.Name = "mnuTable_Select_Table";
            mnuTable_Select_Table.Size = new Size(117, 22);
            mnuTable_Select_Table.Text = "&Table";
            mnuTable_Select_Table.Click += mnuTable_Select_Table_Click;
            // 
            // mnuTable_Select_Row
            // 
            mnuTable_Select_Row.Image = Codex.CodexR4.Properties.Resources.selecttablerow;
            mnuTable_Select_Row.MergeIndex = 1;
            mnuTable_Select_Row.Name = "mnuTable_Select_Row";
            mnuTable_Select_Row.Size = new Size(117, 22);
            mnuTable_Select_Row.Text = "&Row";
            mnuTable_Select_Row.Click += mnuTable_Select_Row_Click;
            // 
            // mnuTable_Select_Column
            // 
            mnuTable_Select_Column.Image = Codex.CodexR4.Properties.Resources.selecttablecol;
            mnuTable_Select_Column.MergeIndex = 2;
            mnuTable_Select_Column.Name = "mnuTable_Select_Column";
            mnuTable_Select_Column.Size = new Size(117, 22);
            mnuTable_Select_Column.Text = "&Column";
            mnuTable_Select_Column.Click += mnuTable_Select_Column_Click;
            // 
            // mnuTable_Select_Cell
            // 
            mnuTable_Select_Cell.Image = Codex.CodexR4.Properties.Resources.selecttablecell;
            mnuTable_Select_Cell.MergeIndex = 3;
            mnuTable_Select_Cell.Name = "mnuTable_Select_Cell";
            mnuTable_Select_Cell.Size = new Size(117, 22);
            mnuTable_Select_Cell.Text = "C&ell";
            mnuTable_Select_Cell.Click += mnuTable_Select_Cell_Click;
            // 
            // mnuTable_Merge_Cells
            // 
            mnuTable_Merge_Cells.Image = Codex.CodexR4.Properties.Resources.mergetablecells;
            mnuTable_Merge_Cells.Name = "mnuTable_Merge_Cells";
            mnuTable_Merge_Cells.Size = new Size(136, 22);
            mnuTable_Merge_Cells.Text = "&Merge Cells";
            mnuTable_Merge_Cells.Click += mnuTable_Merge_Cells_Click;
            // 
            // mnuTable_Split_Cells
            // 
            mnuTable_Split_Cells.Image = Codex.CodexR4.Properties.Resources.splittablecells;
            mnuTable_Split_Cells.Name = "mnuTable_Split_Cells";
            mnuTable_Split_Cells.Size = new Size(136, 22);
            mnuTable_Split_Cells.Text = "&Split Cells";
            mnuTable_Split_Cells.Click += mnuTable_Split_Cells_Click;
            // 
            // mnuTable_Split
            // 
            mnuTable_Split.DropDownItems.AddRange(new ToolStripItem[] { mnuTable_Split_Above, mnuTable_Split_Below });
            mnuTable_Split.Image = Codex.CodexR4.Properties.Resources.splittable;
            mnuTable_Split.MergeIndex = 2;
            mnuTable_Split.Name = "mnuTable_Split";
            mnuTable_Split.Size = new Size(136, 22);
            mnuTable_Split.Text = "S&plit Table";
            mnuTable_Split.DropDownOpening += mnuTable_Split_DropDownOpening;
            // 
            // mnuTable_Split_Above
            // 
            mnuTable_Split_Above.Image = Codex.CodexR4.Properties.Resources.splittableabove;
            mnuTable_Split_Above.MergeIndex = 0;
            mnuTable_Split_Above.Name = "mnuTable_Split_Above";
            mnuTable_Split_Above.Size = new Size(108, 22);
            mnuTable_Split_Above.Text = "&Above";
            mnuTable_Split_Above.Click += mnuTable_Split_Above_Click;
            // 
            // mnuTable_Split_Below
            // 
            mnuTable_Split_Below.Image = Codex.CodexR4.Properties.Resources.splittablebelow;
            mnuTable_Split_Below.MergeIndex = 1;
            mnuTable_Split_Below.Name = "mnuTable_Split_Below";
            mnuTable_Split_Below.Size = new Size(108, 22);
            mnuTable_Split_Below.Text = "&Below";
            mnuTable_Split_Below.Click += mnuTable_Split_Below_Click;
            // 
            // mnuTable_GridLines
            // 
            mnuTable_GridLines.Image = Codex.CodexR4.Properties.Resources.tablegridlines;
            mnuTable_GridLines.MergeIndex = 4;
            mnuTable_GridLines.Name = "mnuTable_GridLines";
            mnuTable_GridLines.Size = new Size(136, 22);
            mnuTable_GridLines.Text = "&Grid Lines";
            mnuTable_GridLines.Click += mnuTable_GridLines_Click;
            // 
            // toolStripSep_mnuTable1
            // 
            toolStripSep_mnuTable1.Name = "toolStripSep_mnuTable1";
            toolStripSep_mnuTable1.Size = new Size(133, 6);
            // 
            // mnuTable_Properties
            // 
            mnuTable_Properties.Image = Codex.CodexR4.Properties.Resources.tabledialog;
            mnuTable_Properties.MergeIndex = 5;
            mnuTable_Properties.Name = "mnuTable_Properties";
            mnuTable_Properties.Size = new Size(136, 22);
            mnuTable_Properties.Text = "&Properties…";
            mnuTable_Properties.Click += mnuTable_Properties_Click;
            // 
            // _toolStrip
            // 
            _toolStrip.Items.AddRange(new ToolStripItem[] { toolStripNewFile, toolStripOpenFile, toolStripSave, toolStripSeparator1, toolStripPrint, toolStripPrintPreview, toolStripSeparator2, toolStripCut, toolStripCopy, toolStripPaste, toolStripDelete, toolStripSeparator3, toolStripUndo, toolStripRedo, toolStripFind, toolStripSeparator444, toolStripMarginsAndPaper, toolStripHeadersAndFooters, toolStripColumns, toolStripPageBorders, toolStripButton1 });
            _toolStrip.Location = new Point(0, 24);
            _toolStrip.Name = "_toolStrip";
            _toolStrip.Size = new Size(814, 25);
            _toolStrip.TabIndex = 0;
            // 
            // toolStripNewFile
            // 
            toolStripNewFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripNewFile.Enabled = false;
            toolStripNewFile.Image = Codex.CodexR4.Properties.Resources.newpage;
            toolStripNewFile.ImageTransparentColor = Color.Magenta;
            toolStripNewFile.Name = "toolStripNewFile";
            toolStripNewFile.Size = new Size(23, 22);
            toolStripNewFile.Text = "New document";
            toolStripNewFile.ToolTipText = "New document";
            toolStripNewFile.Visible = false;
            toolStripNewFile.Click += toolStripButton1_Click;
            // 
            // toolStripOpenFile
            // 
            toolStripOpenFile.Image = Codex.CodexR4.Properties.Resources.open;
            toolStripOpenFile.ImageTransparentColor = Color.Magenta;
            toolStripOpenFile.Name = "toolStripOpenFile";
            toolStripOpenFile.Size = new Size(114, 22);
            toolStripOpenFile.Text = "Open document";
            toolStripOpenFile.ToolTipText = "Open document";
            toolStripOpenFile.Click += toolStripButton2_Click;
            // 
            // toolStripSave
            // 
            toolStripSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSave.Image = Codex.CodexR4.Properties.Resources.save;
            toolStripSave.ImageTransparentColor = Color.Magenta;
            toolStripSave.Name = "toolStripSave";
            toolStripSave.Size = new Size(23, 22);
            toolStripSave.Text = "Save document";
            toolStripSave.ToolTipText = "Save document";
            toolStripSave.Click += toolStripButton3_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripPrint
            // 
            toolStripPrint.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripPrint.Image = Codex.CodexR4.Properties.Resources.print;
            toolStripPrint.ImageTransparentColor = Color.Magenta;
            toolStripPrint.Name = "toolStripPrint";
            toolStripPrint.Size = new Size(23, 22);
            toolStripPrint.Text = "Print document";
            toolStripPrint.ToolTipText = "Print document";
            toolStripPrint.Click += toolStripButton4_Click;
            // 
            // toolStripPrintPreview
            // 
            toolStripPrintPreview.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripPrintPreview.Image = Codex.CodexR4.Properties.Resources.printpreview;
            toolStripPrintPreview.ImageTransparentColor = Color.Magenta;
            toolStripPrintPreview.Name = "toolStripPrintPreview";
            toolStripPrintPreview.Size = new Size(23, 22);
            toolStripPrintPreview.Text = "Print preview";
            toolStripPrintPreview.ToolTipText = "Print preview";
            toolStripPrintPreview.Click += toolStripButton5_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripCut
            // 
            toolStripCut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripCut.Image = Codex.CodexR4.Properties.Resources.cut;
            toolStripCut.ImageTransparentColor = Color.Magenta;
            toolStripCut.Name = "toolStripCut";
            toolStripCut.Size = new Size(23, 22);
            toolStripCut.Text = "Cut";
            toolStripCut.ToolTipText = "Cut";
            toolStripCut.Click += toolStripButton6_Click;
            // 
            // toolStripCopy
            // 
            toolStripCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripCopy.Image = Codex.CodexR4.Properties.Resources.copy;
            toolStripCopy.ImageTransparentColor = Color.Magenta;
            toolStripCopy.Name = "toolStripCopy";
            toolStripCopy.Size = new Size(23, 22);
            toolStripCopy.Text = "Copy";
            toolStripCopy.ToolTipText = "Copy";
            toolStripCopy.Click += toolStripButton7_Click;
            // 
            // toolStripPaste
            // 
            toolStripPaste.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripPaste.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem7, toolStripMenuItem8, toolStripSeparator4, toolStripMenuItem9, toolStripMenuItem5 });
            toolStripPaste.Image = Codex.CodexR4.Properties.Resources.paste;
            toolStripPaste.ImageTransparentColor = Color.Magenta;
            toolStripPaste.Name = "toolStripPaste";
            toolStripPaste.Size = new Size(32, 22);
            toolStripPaste.Text = "Paste";
            toolStripPaste.ToolTipText = "Paste";
            toolStripPaste.Click += toolStripButton8_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Image = Codex.CodexR4.Properties.Resources.paste;
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(152, 22);
            toolStripMenuItem7.Text = "Paste as RTF";
            toolStripMenuItem7.Click += toolStripMenuItem7_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Image = Codex.CodexR4.Properties.Resources.paste;
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(152, 22);
            toolStripMenuItem8.Text = "Paste as Text";
            toolStripMenuItem8.Click += toolStripMenuItem8_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(149, 6);
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Image = Codex.CodexR4.Properties.Resources.paste;
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(152, 22);
            toolStripMenuItem9.Text = "Paste as Image";
            toolStripMenuItem9.Click += toolStripMenuItem9_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.DropDownItems.AddRange(new ToolStripItem[] { pasteAsHTMLToolStripMenuItem, pasterAsTXIMAGEToolStripMenuItem, pasterAsTXFormatToolStripMenuItem, pasteAsTxFrameToolStripMenuItem });
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(152, 22);
            toolStripMenuItem5.Text = "Pasta as other";
            // 
            // pasteAsHTMLToolStripMenuItem
            // 
            pasteAsHTMLToolStripMenuItem.Name = "pasteAsHTMLToolStripMenuItem";
            pasteAsHTMLToolStripMenuItem.Size = new Size(173, 22);
            pasteAsHTMLToolStripMenuItem.Text = "Paste as HTML";
            pasteAsHTMLToolStripMenuItem.Click += pasteAsHTMLToolStripMenuItem_Click;
            // 
            // pasterAsTXIMAGEToolStripMenuItem
            // 
            pasterAsTXIMAGEToolStripMenuItem.Name = "pasterAsTXIMAGEToolStripMenuItem";
            pasterAsTXIMAGEToolStripMenuItem.Size = new Size(173, 22);
            pasterAsTXIMAGEToolStripMenuItem.Text = "Paste as TX IMAGE";
            pasterAsTXIMAGEToolStripMenuItem.Click += pasterAsTXIMAGEToolStripMenuItem_Click;
            // 
            // pasterAsTXFormatToolStripMenuItem
            // 
            pasterAsTXFormatToolStripMenuItem.Name = "pasterAsTXFormatToolStripMenuItem";
            pasterAsTXFormatToolStripMenuItem.Size = new Size(173, 22);
            pasterAsTXFormatToolStripMenuItem.Text = "Paste as TX Format";
            pasterAsTXFormatToolStripMenuItem.Click += pasterAsTXFormatToolStripMenuItem_Click;
            // 
            // pasteAsTxFrameToolStripMenuItem
            // 
            pasteAsTxFrameToolStripMenuItem.Name = "pasteAsTxFrameToolStripMenuItem";
            pasteAsTxFrameToolStripMenuItem.Size = new Size(173, 22);
            pasteAsTxFrameToolStripMenuItem.Text = "Paste as Tx Frame";
            pasteAsTxFrameToolStripMenuItem.Click += pasteAsTxFrameToolStripMenuItem_Click;
            // 
            // toolStripDelete
            // 
            toolStripDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDelete.Image = Codex.CodexR4.Properties.Resources.delete;
            toolStripDelete.ImageTransparentColor = Color.Magenta;
            toolStripDelete.Name = "toolStripDelete";
            toolStripDelete.Size = new Size(23, 22);
            toolStripDelete.Text = "Delete selection";
            toolStripDelete.ToolTipText = "Delete selection";
            toolStripDelete.Click += toolStripButton9_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripUndo
            // 
            toolStripUndo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripUndo.Image = Codex.CodexR4.Properties.Resources.undo;
            toolStripUndo.ImageTransparentColor = Color.Magenta;
            toolStripUndo.Name = "toolStripUndo";
            toolStripUndo.Size = new Size(23, 22);
            toolStripUndo.Text = "Undo";
            toolStripUndo.ToolTipText = "Undo";
            toolStripUndo.Click += toolStripButton10_Click;
            // 
            // toolStripRedo
            // 
            toolStripRedo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripRedo.Image = Codex.CodexR4.Properties.Resources.redo;
            toolStripRedo.ImageTransparentColor = Color.Magenta;
            toolStripRedo.Name = "toolStripRedo";
            toolStripRedo.Size = new Size(23, 22);
            toolStripRedo.Text = "Redo";
            toolStripRedo.ToolTipText = "Redo";
            toolStripRedo.Click += toolStripButton11_Click;
            // 
            // toolStripFind
            // 
            toolStripFind.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripFind.Image = Codex.CodexR4.Properties.Resources.find;
            toolStripFind.ImageTransparentColor = Color.Magenta;
            toolStripFind.Name = "toolStripFind";
            toolStripFind.Size = new Size(23, 22);
            toolStripFind.Text = "Find";
            toolStripFind.ToolTipText = "Find";
            toolStripFind.Click += toolStripButton12_Click;
            // 
            // toolStripSeparator444
            // 
            toolStripSeparator444.Name = "toolStripSeparator444";
            toolStripSeparator444.Size = new Size(6, 25);
            // 
            // toolStripMarginsAndPaper
            // 
            toolStripMarginsAndPaper.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripMarginsAndPaper.Image = Codex.CodexR4.Properties.Resources.pagedialog;
            toolStripMarginsAndPaper.ImageTransparentColor = Color.Magenta;
            toolStripMarginsAndPaper.Name = "toolStripMarginsAndPaper";
            toolStripMarginsAndPaper.Size = new Size(23, 22);
            toolStripMarginsAndPaper.Text = "Margins and Paper";
            toolStripMarginsAndPaper.Click += toolStripMarginsAndPaper_Click;
            // 
            // toolStripHeadersAndFooters
            // 
            toolStripHeadersAndFooters.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripHeadersAndFooters.Image = Codex.CodexR4.Properties.Resources.hfdialog;
            toolStripHeadersAndFooters.ImageTransparentColor = Color.Magenta;
            toolStripHeadersAndFooters.Name = "toolStripHeadersAndFooters";
            toolStripHeadersAndFooters.Size = new Size(23, 22);
            toolStripHeadersAndFooters.Text = "Headers and Footers";
            toolStripHeadersAndFooters.Click += toolStripHeadersAndFooters_Click;
            // 
            // toolStripColumns
            // 
            toolStripColumns.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripColumns.Image = Codex.CodexR4.Properties.Resources.pagecolumnstwo;
            toolStripColumns.ImageTransparentColor = Color.Magenta;
            toolStripColumns.Name = "toolStripColumns";
            toolStripColumns.Size = new Size(23, 22);
            toolStripColumns.Text = "Columns";
            toolStripColumns.ToolTipText = "Columns";
            toolStripColumns.Click += toolStripColumns_Click;
            // 
            // toolStripPageBorders
            // 
            toolStripPageBorders.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripPageBorders.Image = Codex.CodexR4.Properties.Resources.pageframedialog;
            toolStripPageBorders.ImageTransparentColor = Color.Magenta;
            toolStripPageBorders.Name = "toolStripPageBorders";
            toolStripPageBorders.Size = new Size(23, 22);
            toolStripPageBorders.Text = "Page Borders";
            toolStripPageBorders.Click += toolStripPageBorders_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Codex.CodexR4.Properties.Resources.hand_back_16;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "სექციების ამოღბა";
            toolStripButton1.Click += toolStripButton1_Click_1;
            // 
            // _sep_pageNum01
            // 
            _sep_pageNum01.Name = "_sep_pageNum01";
            _sep_pageNum01.Size = new Size(185, 6);
            // 
            // BottomToolStripPanel
            // 
            BottomToolStripPanel.Location = new Point(0, 0);
            BottomToolStripPanel.Name = "BottomToolStripPanel";
            BottomToolStripPanel.Orientation = Orientation.Horizontal;
            BottomToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            BottomToolStripPanel.Size = new Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            TopToolStripPanel.Location = new Point(0, 0);
            TopToolStripPanel.Name = "TopToolStripPanel";
            TopToolStripPanel.Orientation = Orientation.Horizontal;
            TopToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            TopToolStripPanel.Size = new Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            RightToolStripPanel.Location = new Point(0, 0);
            RightToolStripPanel.Name = "RightToolStripPanel";
            RightToolStripPanel.Orientation = Orientation.Horizontal;
            RightToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            RightToolStripPanel.Size = new Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            LeftToolStripPanel.Location = new Point(0, 0);
            LeftToolStripPanel.Name = "LeftToolStripPanel";
            LeftToolStripPanel.Orientation = Orientation.Horizontal;
            LeftToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            LeftToolStripPanel.Size = new Size(0, 0);
            // 
            // ContentPanel
            // 
            ContentPanel.Size = new Size(470, 77);
            // 
            // BaseTxDocument
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 396);
            Controls.Add(textControl);
            Controls.Add(rulerBar2);
            Controls.Add(rulerBar1);
            Controls.Add(buttonBar2);
            Controls.Add(DocumentSearchTab);
            Controls.Add(statusBar1);
            Controls.Add(_toolStrip);
            Controls.Add(_menuStrip);
            Font = new Font("MS Reference Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BaseTxDocument";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "CodexBaseTxDocument";
            ResizeEnd += BaseTxDocument_ResizeEnd;
            ultraTabPageControl13.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DSInText).EndInit();
            ((System.ComponentModel.ISupportInitialize)DSSearchInCheck).EndInit();
            ((System.ComponentModel.ISupportInitialize)ultraStatusBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DocumentSearchTab).EndInit();
            DocumentSearchTab.ResumeLayout(false);
            _contextMenuApplicationFields.ResumeLayout(false);
            _menuStrip.ResumeLayout(false);
            _menuStrip.PerformLayout();
            _toolStrip.ResumeLayout(false);
            _toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private TXTextControl.StatusBar statusBar1;
        public Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl13;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor DSSearchInCheck;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor DSInText;
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