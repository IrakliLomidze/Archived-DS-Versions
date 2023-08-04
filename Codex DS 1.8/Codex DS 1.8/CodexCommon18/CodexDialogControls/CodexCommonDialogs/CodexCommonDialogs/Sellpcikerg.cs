using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using Infragistics.Win; 
using Infragistics.Win.UltraWinGrid; 
using Infragistics.Shared;

namespace ILG.Codex.CodexR4
{
    /// <summary>
    /// Summary description for Sellpickerg.
    /// </summary>
    public class Sellpickerg : System.Windows.Forms.Form
    {
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private IContainer components;
        private String CCaption;
        private String CSQL;
        private String NoSellStr;
        private String CaptionField;
        private String IDField;
        private int SQLStyle;
        private int Selx; // 0 no sellected 1 sellect 2 NoT
        private String SQLField;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor FilterTextEdit;
        private ContextMenuStrip contextMenuStrip1;
        public bool canceled;
        private Infragistics.Win.Misc.UltraPanel TopPanel;
        private Infragistics.Win.Misc.UltraLabel CaptionLabel;
        private Infragistics.Win.Misc.UltraPanel FilterPanel;
        private Infragistics.Win.Misc.UltraPanel Sellpickerg_Fill_Panel;
        public Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Sellpickerg_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Sellpickerg_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Sellpickerg_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Sellpickerg_Toolbars_Dock_Area_Top;
        private Infragistics.Win.Misc.UltraButton Button_Cancel;
        private Infragistics.Win.Misc.UltraDropDownButton Button_OK;
        private BindingSource bs;
        new private Infragistics.Win.Misc.UltraButton HelpButton;
        private bool Inverse = false;


        public Sellpickerg(DataTable dt, int Style, String IDFieldP, String SQLFieldP, String CaptionFieldP, String HeaderStr, String NoSellStrP, int X, int Y, int Width, String R4Filtering)
        {
            //
            // Required for Windows Form Designer support
            //

            InitializeComponent();
            // MessageBox.Show(dt.Rows.Count.ToString()); 

            Infragistics.Win.AppStyling.StyleManager.Office2013ColorScheme = Infragistics.Win.Office2013ColorScheme.White;




            NoSellStr = NoSellStrP;
            IDField = IDFieldP;
            SQLField = SQLFieldP;
            CaptionField = CaptionFieldP;
            SQLStyle = Style;
            this.Width = Width;



            Button_Cancel.Text = "უარი";
            Button_OK.Text = "მონიშვნა";
            Button_OK.Appearance.FontData.Name = "Sylfaen";
            Button_OK.Appearance.FontData.SizeInPoints = 9.0f;
            Button_Cancel.Appearance.FontData.Name = "Sylfaen";
            Button_Cancel.Appearance.FontData.SizeInPoints = 9.0f;


            Inverse = false;
            // DataBinding
            bs = new BindingSource();

            bs.Filter = "";
            bs.DataSource = dt;
            ultraGrid1.DataSource = bs;


            ultraGrid1.DataBind();
            ultraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;  //AutoFitColumns = true;
            ultraGrid1.DisplayLayout.Key = IDField;
            //  ultraGrid1.UseFlatMode = DefaultableBoolean.True;// FlatMode = true;


            for (int i = 0; i <= ultraGrid1.DisplayLayout.Bands[0].Columns.Count - 1; i++)
                ultraGrid1.DisplayLayout.Bands[0].Columns[i].Hidden = true;


            ultraGrid1.DisplayLayout.Bands[0].Columns[CaptionField].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].ColHeadersVisible = false;
            ultraGrid1.DisplayLayout.Bands[0].HeaderVisible = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns[CaptionField].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;// AutoEdit = false;
            ultraGrid1.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGrid1.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.FromArgb(250, 250, 250);// Color.AliceBlue;//.LightSteelBlue;// .Wheat;

            //ultraGrid1.DisplayLayout.Bands[0].Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            //ultraGrid1.DisplayLayout.Bands[0].Override.AllowColSizing =  Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            ultraGrid1.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;


            ultraGrid1.DisplayLayout.Bands[0].Override.CellAppearance.BorderColor = Color.LightGray;
            ultraGrid1.DisplayLayout.Bands[0].Override.RowAppearance.BorderColor = Color.LightGray;


            ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
            ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            ultraGrid1.Text = HeaderStr;

            ultraGrid1.UseAppStyling = true;


            // Layout R4

            CaptionLabel.Text = HeaderStr;
            FilterTextEdit.Left = 6;
            FilterTextEdit.Top = 4;
            FilterTextEdit.Width = FilterPanel.Width - FilterTextEdit.Left * 2;
            FilterPanel.Height = FilterTextEdit.Top + FilterTextEdit.Height + FilterTextEdit.Top;
            FilterTextEdit.Text = "";



            // Display
            ultraGrid1.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            ultraGrid1.Left = 0;
            ultraGrid1.Top = FilterPanel.Top + FilterPanel.Height; ;
            ultraGrid1.Width = ClientSize.Width;
            ultraGrid1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            // Height Calculded Code
            int hhx = 0;
            hhx = (this.ultraGrid1.Rows[0].Height + 1 +
                this.ultraGrid1.Rows[0].RowSpacingBefore +
                this.ultraGrid1.Rows[0].RowSpacingAfter) * (ultraGrid1.Rows.Count + 1) + 2;

            if ((hhx > 0) && (this.ultraGrid1.Height > hhx)) this.ultraGrid1.Height = hhx;




            Button_OK.Left = 0;
            Button_OK.Width = ClientSize.Width / 2;
            Button_Cancel.Width = ClientSize.Width / 2 - 1;
            Button_Cancel.Top = ultraGrid1.Top + ultraGrid1.Height + 2;
            Button_OK.Top = Button_Cancel.Top;
            Button_Cancel.Left = Button_OK.Width;
            Button_Cancel.Height = Button_OK.Height;


            int _h = Button_OK.Top + Button_OK.Height;

            this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, _h);

            Point p = new Point(X, Y);
            Location = p;


            // calculder free space


            if (R4Filtering.Trim() != "")
            {
                this.FilterTextEdit.Text = R4Filtering;
                ultraTextEditor1_TextChanged(null, null);
                this.FilterTextEdit.Focus();
                this.FilterTextEdit.SelectionStart = 1;
            }





        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sellpickerg));
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("MenuItem");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Selected");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Inverse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Selected");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Inverse");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Selected");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Inverse");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.FilterTextEdit = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TopPanel = new Infragistics.Win.Misc.UltraPanel();
            this.HelpButton = new Infragistics.Win.Misc.UltraButton();
            this.CaptionLabel = new Infragistics.Win.Misc.UltraLabel();
            this.FilterPanel = new Infragistics.Win.Misc.UltraPanel();
            this.Sellpickerg_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.Button_OK = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.Button_Cancel = new Infragistics.Win.Misc.UltraButton();
            this._Sellpickerg_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Sellpickerg_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Sellpickerg_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Sellpickerg_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterTextEdit)).BeginInit();
            this.TopPanel.ClientArea.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.FilterPanel.ClientArea.SuspendLayout();
            this.FilterPanel.SuspendLayout();
            this.Sellpickerg_Fill_Panel.ClientArea.SuspendLayout();
            this.Sellpickerg_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Cursor = System.Windows.Forms.Cursors.Default;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            appearance1.ForeColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.CaptionAppearance = appearance1;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Gainsboro;
            this.ultraGrid1.DisplayLayout.DefaultSelectedForeColor = System.Drawing.Color.Black;
            appearance2.BorderColor = System.Drawing.Color.LightGray;
            this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ultraGrid1.DisplayLayout.Override.HotTrackCellAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance4.BorderColor = System.Drawing.Color.Gray;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance4;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.WindowsVista;
            this.ultraGrid1.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BorderColor = System.Drawing.Color.Gray;
            scrollBarLook1.Appearance = appearance5;
            this.ultraGrid1.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGrid1.Location = new System.Drawing.Point(0, 55);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(360, 201);
            this.ultraGrid1.TabIndex = 1;
            this.ultraGrid1.Text = "ultraGrid1";
            this.ultraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
            this.ultraGrid1.DoubleClick += new System.EventHandler(this.ultraGrid1_DoubleClick);
            this.ultraGrid1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ultraGrid1_KeyPress);
            this.ultraGrid1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ultraGrid1_KeyUp);
            this.ultraGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ultraGrid1_MouseUp);
            // 
            // FilterTextEdit
            // 
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FilterTextEdit.Appearance = appearance6;
            this.FilterTextEdit.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            editorButton1.Appearance = appearance7;
            editorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.FilterTextEdit.ButtonsRight.Add(editorButton1);
            this.FilterTextEdit.ContextMenuStrip = this.contextMenuStrip1;
            this.FilterTextEdit.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.FilterTextEdit.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterTextEdit.Location = new System.Drawing.Point(12, 4);
            this.FilterTextEdit.Name = "FilterTextEdit";
            this.FilterTextEdit.NullText = "ფილტრაცია სიაში";
            appearance8.ForeColor = System.Drawing.Color.Gray;
            this.FilterTextEdit.NullTextAppearance = appearance8;
            this.FilterTextEdit.Size = new System.Drawing.Size(336, 21);
            this.FilterTextEdit.TabIndex = 2;
            this.FilterTextEdit.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.FilterTextEdit.TextChanged += new System.EventHandler(this.ultraTextEditor1_TextChanged);
            this.FilterTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ultraTextEditor1_KeyPress);
            this.FilterTextEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ultraTextEditor1_KeyUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // TopPanel
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.TopPanel.Appearance = appearance9;
            this.TopPanel.AutoSize = true;
            // 
            // TopPanel.ClientArea
            // 
            this.TopPanel.ClientArea.Controls.Add(this.HelpButton);
            this.TopPanel.ClientArea.Controls.Add(this.CaptionLabel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(358, 24);
            this.TopPanel.TabIndex = 6;
            // 
            // HelpButton
            // 
            appearance10.Image = ((object)(resources.GetObject("appearance10.Image")));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.HelpButton.Appearance = appearance10;
            this.HelpButton.AutoSize = true;
            this.HelpButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            this.HelpButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.HelpButton.Location = new System.Drawing.Point(334, 0);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(24, 24);
            this.HelpButton.TabIndex = 1;
            this.HelpButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // CaptionLabel
            // 
            appearance11.ForeColor = System.Drawing.Color.White;
            this.CaptionLabel.Appearance = appearance11;
            this.CaptionLabel.AutoSize = true;
            this.CaptionLabel.Location = new System.Drawing.Point(4, 3);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Padding = new System.Drawing.Size(8, 0);
            this.CaptionLabel.Size = new System.Drawing.Size(79, 18);
            this.CaptionLabel.TabIndex = 0;
            this.CaptionLabel.Text = "ultraLabel1";
            // 
            // FilterPanel
            // 
            appearance12.BackColor = System.Drawing.Color.White;
            this.FilterPanel.Appearance = appearance12;
            // 
            // FilterPanel.ClientArea
            // 
            this.FilterPanel.ClientArea.Controls.Add(this.FilterTextEdit);
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanel.Location = new System.Drawing.Point(0, 24);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(358, 35);
            this.FilterPanel.TabIndex = 7;
            // 
            // Sellpickerg_Fill_Panel
            // 
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.Sellpickerg_Fill_Panel.Appearance = appearance13;
            this.Sellpickerg_Fill_Panel.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // Sellpickerg_Fill_Panel.ClientArea
            // 
            this.Sellpickerg_Fill_Panel.ClientArea.Controls.Add(this.Button_OK);
            this.Sellpickerg_Fill_Panel.ClientArea.Controls.Add(this.Button_Cancel);
            this.Sellpickerg_Fill_Panel.ClientArea.Controls.Add(this.FilterPanel);
            this.Sellpickerg_Fill_Panel.ClientArea.Controls.Add(this.TopPanel);
            this.Sellpickerg_Fill_Panel.ClientArea.Controls.Add(this.ultraGrid1);
            this.Sellpickerg_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Sellpickerg_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sellpickerg_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.Sellpickerg_Fill_Panel.Name = "Sellpickerg_Fill_Panel";
            this.Sellpickerg_Fill_Panel.Size = new System.Drawing.Size(360, 380);
            this.Sellpickerg_Fill_Panel.TabIndex = 1;
            // 
            // Button_OK
            // 
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            this.Button_OK.Appearance = appearance14;
            this.Button_OK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_OK.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_OK.Location = new System.Drawing.Point(12, 283);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.PopupItemKey = "PopupMenuTool1";
            this.Button_OK.PopupItemProvider = this.ultraToolbarsManager1;
            this.Button_OK.Size = new System.Drawing.Size(144, 28);
            this.Button_OK.TabIndex = 10;
            this.Button_OK.Text = "მონიშვნა";
            this.Button_OK.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Random;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Text = "UltraToolbar1";
            ultraToolbar1.Visible = false;
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            popupMenuTool1.SharedPropsInternal.Caption = "MenuItem";
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            buttonTool1.SharedPropsInternal.AppearancesLarge.Appearance = appearance15;
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            buttonTool1.SharedPropsInternal.AppearancesSmall.Appearance = appearance16;
            buttonTool1.SharedPropsInternal.Caption = "მოიძებნოს მონიშნული/ები";
            buttonTool1.SharedPropsInternal.CustomizerCaption = "Selected";
            appearance17.Image = ((object)(resources.GetObject("appearance17.Image")));
            buttonTool2.SharedPropsInternal.AppearancesLarge.Appearance = appearance17;
            appearance18.Image = ((object)(resources.GetObject("appearance18.Image")));
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance18;
            buttonTool2.SharedPropsInternal.Caption = "მოიძებნოს ყველა მონიშნულის/ების გარდა";
            buttonTool2.SharedPropsInternal.CustomizerCaption = "მოიძებნოს ყველა მონიშნულის/ების გარდა";
            popupMenuTool2.SharedPropsInternal.Caption = "PopupMenuTool1";
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6});
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            buttonTool1,
            buttonTool2,
            popupMenuTool2});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // Button_Cancel
            // 
            appearance19.Image = ((object)(resources.GetObject("appearance19.Image")));
            this.Button_Cancel.Appearance = appearance19;
            this.Button_Cancel.BackColorInternal = System.Drawing.Color.SteelBlue;
            this.Button_Cancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Cancel.Location = new System.Drawing.Point(180, 288);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.ShowFocusRect = false;
            this.Button_Cancel.ShowOutline = false;
            this.Button_Cancel.Size = new System.Drawing.Size(168, 23);
            this.Button_Cancel.TabIndex = 9;
            this.Button_Cancel.Text = "Button_Cancel";
            this.Button_Cancel.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Cancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Button_Cancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Cancel.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // _Sellpickerg_Toolbars_Dock_Area_Left
            // 
            this._Sellpickerg_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Sellpickerg_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Sellpickerg_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Sellpickerg_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Sellpickerg_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._Sellpickerg_Toolbars_Dock_Area_Left.Name = "_Sellpickerg_Toolbars_Dock_Area_Left";
            this._Sellpickerg_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 380);
            this._Sellpickerg_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Sellpickerg_Toolbars_Dock_Area_Right
            // 
            this._Sellpickerg_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Sellpickerg_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Sellpickerg_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Sellpickerg_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Sellpickerg_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(360, 0);
            this._Sellpickerg_Toolbars_Dock_Area_Right.Name = "_Sellpickerg_Toolbars_Dock_Area_Right";
            this._Sellpickerg_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 380);
            this._Sellpickerg_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Sellpickerg_Toolbars_Dock_Area_Top
            // 
            this._Sellpickerg_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Sellpickerg_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Sellpickerg_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Sellpickerg_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Sellpickerg_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Sellpickerg_Toolbars_Dock_Area_Top.Name = "_Sellpickerg_Toolbars_Dock_Area_Top";
            this._Sellpickerg_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(360, 0);
            this._Sellpickerg_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Sellpickerg_Toolbars_Dock_Area_Bottom
            // 
            this._Sellpickerg_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Sellpickerg_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Sellpickerg_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Sellpickerg_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Sellpickerg_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 380);
            this._Sellpickerg_Toolbars_Dock_Area_Bottom.Name = "_Sellpickerg_Toolbars_Dock_Area_Bottom";
            this._Sellpickerg_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(360, 0);
            this._Sellpickerg_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // Sellpickerg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(360, 380);
            this.Controls.Add(this.Sellpickerg_Fill_Panel);
            this.Controls.Add(this._Sellpickerg_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Sellpickerg_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Sellpickerg_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._Sellpickerg_Toolbars_Dock_Area_Top);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sellpickerg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sellpickerg";
            this.Load += new System.EventHandler(this.Sellpickerg_Load);
            this.Shown += new System.EventHandler(this.Sellpickerg_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ultraGrid1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterTextEdit)).EndInit();
            this.TopPanel.ClientArea.ResumeLayout(false);
            this.TopPanel.ClientArea.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.FilterPanel.ClientArea.ResumeLayout(false);
            this.FilterPanel.ClientArea.PerformLayout();
            this.FilterPanel.ResumeLayout(false);
            this.Sellpickerg_Fill_Panel.ClientArea.ResumeLayout(false);
            this.Sellpickerg_Fill_Panel.ClientArea.PerformLayout();
            this.Sellpickerg_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void Sellpickerg_Load(object sender, System.EventArgs e)
        {

            this.SuspendLayout();
            Infragistics.Win.AppStyling.StyleManager.Office2013ColorScheme = Infragistics.Win.Office2013ColorScheme.White;
            Point p = new Point(Location.X, Location.Y);
            p.Y = p.Y - this.ClientSize.Height;
            this.Location = p;
            this.ResumeLayout();

            if (this.FilterTextEdit.Text.Length > 0)
            {
                FilterTextEdit.Focus();
            }

        }

        private void ClickOK()
        {
            StringBuilder St = new StringBuilder("");
            StringBuilder StSQL = new StringBuilder("");

            if (ultraGrid1.Selected.Rows.Count == 0)
            {
                St.Append(NoSellStr);
                Selx = 0;

            }

            if (ultraGrid1.Selected.Rows.Count == 1)
            {
                if (this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim() != "")
                {
                    St.Append(this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim());
                    if (Inverse == false)// (SelectionCombo.Value.ToString() == "T")
                    {
                        Selx = 1;
                        if (SQLStyle == 0) { StSQL.Append(" ( " + SQLField + " = " + this.ultraGrid1.Selected.Rows[0].Cells[IDField].Text.ToString() + " )"); }
                        else { StSQL.Append(" ( " + SQLField + " LIKE  N'%" + this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim() + "%' )"); }
                    }
                    else
                    {
                        Selx = 2;
                        if (SQLStyle == 0) { StSQL.Append(" ( " + SQLField + " <> " + this.ultraGrid1.Selected.Rows[0].Cells[IDField].Text.ToString() + " )"); }
                        else { StSQL.Append(" ( " + SQLField + " NOT LIKE N'%" + this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim() + "%' )"); }
                    }
                }
                else
                {
                    St.Append(NoSellStr);
                }

            }
            if (ultraGrid1.Selected.Rows.Count > 1)
            {

                for (int i = 0; i < ultraGrid1.Selected.Rows.Count; i++)
                {
                    if (ultraGrid1.Selected.Rows[i].Cells[CaptionField].Text.ToString().Trim() == "") continue;
                    St.Append(ultraGrid1.Selected.Rows[i].Cells[CaptionField].Text.ToString().Trim());
                    if (i != ultraGrid1.Selected.Rows.Count - 1) St.Append(", ");
                    // SQL Generation
                    if (Inverse == false)//(SelectionCombo.Value.ToString() == "T")
                    {
                        Selx = 1;
                        if (SQLStyle == 0) { StSQL.Append(" ( " + SQLField + " = " + ultraGrid1.Selected.Rows[i].Cells[IDField].Text.ToString().Trim() + " ) "); }
                        else { StSQL.Append(" ( " + SQLField + " LIKE N'%" + this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim() + "%' )"); }
                        if (i != ultraGrid1.Selected.Rows.Count - 1) StSQL.Append(" OR ");
                    }
                    else
                    {
                        Selx = 2;
                        if (SQLStyle == 0) { StSQL.Append(" ( " + SQLField + " <> " + ultraGrid1.Selected.Rows[i].Cells[IDField].Text.ToString().Trim() + " ) "); }
                        else { StSQL.Append(" ( " + SQLField + " NOT LIKE  N'%" + this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim() + "%' )"); }
                        if (i != ultraGrid1.Selected.Rows.Count - 1) StSQL.Append(" AND ");
                    }
                }

            }


            CCaption = St.ToString();
            CSQL = StSQL.ToString();
            this.canceled = false;
            Close();
            return;
        }

        public override String ToString()
        {
            return CCaption;
        }
        public String ToSQLString()
        {
            return CSQL;
        }

        public int ToWhat()
        {
            return Selx;
        }

        private void ultraButton1_Click(object sender, System.EventArgs e)
        {
            CCaption = NoSellStr;
            CSQL = "";
            Selx = 0;
            this.canceled = true;
            Close();
        }

        private void ultraGrid1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void ultraGrid1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.ultraButton1_Click(null, null);
            if (e.KeyCode == Keys.Enter) ClickOK();

        }

        private void ultraGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.AScrooling == false) this.ClickOK();
        }

        bool AScrooling = true;
        private void ultraGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // declare and retrieve a reference to the UIElement
            Infragistics.Win.UIElement aUIElement = this.ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));
            if (aUIElement is Infragistics.Win.EditorWithTextDisplayTextUIElement) AScrooling = false; else AScrooling = true;
        }

        private void ultraTextEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = ILG.Codex.CodexR4.KeyBoard.Layout.U[e.KeyChar];
        }

        private void ultraTextEditor1_TextChanged(object sender, EventArgs e)
        {

            bs.Filter = "";
            bs.Filter = " " + CaptionField + " Like '%" + FilterTextEdit.Text + "%' ";
            if (this.ultraGrid1.Rows.Count != 0)
            {
                for (int i = 0; i < this.ultraGrid1.Rows.Count - 1; i++)
                    this.ultraGrid1.Rows[i].Selected = false;

                this.ultraGrid1.Rows[0].Selected = true;

            }

            if (this.FilterTextEdit.Text.Trim() != "")
            {
                FilterPanel.Appearance.BackColor = Color.FromArgb(205, 230, 247);
                FilterPanel.Appearance.BackColor2 = Color.FromArgb(205, 230, 247);

                FilterPanel.Appearance.BorderColor = Color.FromArgb(42, 141, 212);
                FilterPanel.Appearance.BorderColor2 = Color.FromArgb(42, 141, 212);
            }
            else
            {
                FilterPanel.Appearance.BackColor = Color.FromArgb(255, 255, 255);
                FilterPanel.Appearance.BackColor2 = Color.FromArgb(255, 255, 255);

                FilterPanel.Appearance.BorderColor = Color.FromArgb(255, 255, 255);
                FilterPanel.Appearance.BorderColor2 = Color.FromArgb(255, 255, 255);
            }


        }

        private void ultraTextEditor1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) FilterTextEdit.Text = "";
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Selected":    // ButtonTool
                    ClickOK();
                    break;

                case "Inverse":    // ButtonTool
                    Inverse = true;
                    ClickOK();
                    break;

            }

        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            ClickOK();
        }

        bool RunOnce = true;
        private void Sellpickerg_Shown(object sender, EventArgs e)
        {
            if (RunOnce == true)
            {
                if (FilterTextEdit.Text.Trim() != "")
                {
                    this.FilterTextEdit.Focus();
                    this.FilterTextEdit.SelectionStart = 1;
                    this.FilterTextEdit.SelectionLength = 0;
                }
                RunOnce = false;
            }
        }

    }

}