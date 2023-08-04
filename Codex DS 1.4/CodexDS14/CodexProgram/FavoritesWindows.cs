using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win; 

namespace ILG.Codex2007.Favorites
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FavoritesWindows : System.Windows.Forms.Form
    {
        
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.Misc.UltraButton ultraButton5;
        private Infragistics.Win.Misc.UltraButton ultraButton4;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor2;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
		private System.ComponentModel.IContainer components;

		public FavoritesWindows()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoritesWindows));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Favorites");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Colapse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NewFolder");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OpenInNewWindow");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Delete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Rename");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("History");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Colapse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NewFolder");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OpenInNewWindow");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Delete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Rename");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPictureBox2 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraTextEditor2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton5 = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this._Form1_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._Form1_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ultraPanel1);
            this.ultraTabPageControl1.Controls.Add(this.ultraPictureBox2);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel3);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl1.Controls.Add(this.ultraTextEditor1);
            this.ultraTabPageControl1.Controls.Add(this.ultraTextEditor2);
            this.ultraTabPageControl1.Controls.Add(this.ultraPictureBox1);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl1.Controls.Add(this.ultraButton4);
            this.ultraTabPageControl1.Controls.Add(this.ultraButton5);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(542, 265);
            // 
            // ultraPanel1
            // 
            appearance1.BorderColor = System.Drawing.Color.Gray;
            this.ultraPanel1.Appearance = appearance1;
            this.ultraPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraPanel1.Location = new System.Drawing.Point(57, 50);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(470, 1);
            this.ultraPanel1.TabIndex = 30;
            this.ultraPanel1.UseAppStyling = false;
            this.ultraPanel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraPictureBox2
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox2.Appearance = appearance2;
            this.ultraPictureBox2.AutoSize = true;
            this.ultraPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox2.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraPictureBox2.Image = ((object)(resources.GetObject("ultraPictureBox2.Image")));
            this.ultraPictureBox2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox2.Location = new System.Drawing.Point(20, 70);
            this.ultraPictureBox2.Name = "ultraPictureBox2";
            this.ultraPictureBox2.Size = new System.Drawing.Size(48, 48);
            this.ultraPictureBox2.TabIndex = 29;
            this.ultraPictureBox2.UseAppStyling = false;
            // 
            // ultraLabel3
            // 
            appearance3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.ultraLabel3.Appearance = appearance3;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(87, 69);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(125, 18);
            this.ultraLabel3.TabIndex = 28;
            this.ultraLabel3.Text = "ფავორიტის სათაური";
            this.ultraLabel3.UseAppStyling = false;
            // 
            // ultraLabel2
            // 
            appearance4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.ultraLabel2.Appearance = appearance4;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Location = new System.Drawing.Point(87, 124);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(133, 18);
            this.ultraLabel2.TabIndex = 27;
            this.ultraLabel2.Text = "დოკუმენტის სათაური";
            this.ultraLabel2.UseAppStyling = false;
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.ScenicRibbon;
            this.ultraTextEditor1.Location = new System.Drawing.Point(87, 93);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(446, 25);
            this.ultraTextEditor1.TabIndex = 21;
            this.ultraTextEditor1.UseAppStyling = false;
            this.ultraTextEditor1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ultraTextEditor1_KeyPress);
            // 
            // ultraTextEditor2
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            this.ultraTextEditor2.Appearance = appearance5;
            this.ultraTextEditor2.BackColor = System.Drawing.Color.White;
            this.ultraTextEditor2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.ScenicRibbon;
            this.ultraTextEditor2.Location = new System.Drawing.Point(87, 148);
            this.ultraTextEditor2.Multiline = true;
            this.ultraTextEditor2.Name = "ultraTextEditor2";
            this.ultraTextEditor2.ReadOnly = true;
            this.ultraTextEditor2.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.ultraTextEditor2.Size = new System.Drawing.Size(446, 72);
            this.ultraTextEditor2.TabIndex = 26;
            this.ultraTextEditor2.UseAppStyling = false;
            // 
            // ultraPictureBox1
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.Appearance = appearance6;
            this.ultraPictureBox1.AutoSize = true;
            this.ultraPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
            this.ultraPictureBox1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox1.Location = new System.Drawing.Point(3, 3);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.Size = new System.Drawing.Size(48, 48);
            this.ultraPictureBox1.TabIndex = 22;
            this.ultraPictureBox1.UseAppStyling = false;
            // 
            // ultraLabel1
            // 
            appearance7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(57, 20);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(299, 24);
            this.ultraLabel1.TabIndex = 21;
            this.ultraLabel1.Text = "დოკუმენტის დამატება ფავორიტებში";
            this.ultraLabel1.UseAppStyling = false;
            // 
            // ultraButton4
            // 
            this.ultraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.ScenicRibbonButton;
            this.ultraButton4.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraButton4.Location = new System.Drawing.Point(299, 231);
            this.ultraButton4.Name = "ultraButton4";
            this.ultraButton4.Size = new System.Drawing.Size(114, 26);
            this.ultraButton4.TabIndex = 6;
            this.ultraButton4.Text = "დამატება";
            this.ultraButton4.UseAppStyling = false;
            this.ultraButton4.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButton4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton4.Click += new System.EventHandler(this.ultraButton4_Click);
            // 
            // ultraButton5
            // 
            this.ultraButton5.ButtonStyle = Infragistics.Win.UIElementButtonStyle.ScenicRibbonButton;
            this.ultraButton5.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraButton5.Location = new System.Drawing.Point(419, 231);
            this.ultraButton5.Name = "ultraButton5";
            this.ultraButton5.Size = new System.Drawing.Size(114, 26);
            this.ultraButton5.TabIndex = 7;
            this.ultraButton5.Text = "უარი";
            this.ultraButton5.UseAppStyling = false;
            this.ultraButton5.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButton5.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton5.Click += new System.EventHandler(this.ultraButton5_Click);
            // 
            // ultraTabControl1
            // 
            appearance8.BackColor = System.Drawing.Color.White;
            this.ultraTabControl1.ActiveTabAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.White;
            this.ultraTabControl1.Appearance = appearance9;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(542, 265);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ultraTabControl1.TabIndex = 5;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "tab1";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.ultraTabControl1.UseAppStyling = false;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(542, 265);
            // 
            // _Form1_Toolbars_Dock_Area_Left
            // 
            this._Form1_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Form1_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._Form1_Toolbars_Dock_Area_Left.Name = "_Form1_Toolbars_Dock_Area_Left";
            this._Form1_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 265);
            this._Form1_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013;
            popupMenuTool1.SharedPropsInternal.Caption = "ფავორიტები";
            popupMenuTool1.SharedPropsInternal.Category = "Menus";
            popupMenuTool1.SharedPropsInternal.CustomizerCaption = "ფავორიტები";
            buttonTool4.InstanceProps.IsFirstInGroup = true;
            buttonTool6.InstanceProps.IsFirstInGroup = true;
            buttonTool9.InstanceProps.IsFirstInGroup = true;
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10});
            popupMenuTool2.SharedPropsInternal.Caption = "ისტორია";
            popupMenuTool2.SharedPropsInternal.Category = "Menus";
            popupMenuTool2.SharedPropsInternal.CustomizerCaption = "ისტორია";
            buttonTool11.SharedPropsInternal.Caption = "გაშლა";
            buttonTool11.SharedPropsInternal.Category = "Menus";
            buttonTool11.SharedPropsInternal.CustomizerCaption = "გაშლა";
            buttonTool12.SharedPropsInternal.Caption = "დაკეცვა";
            buttonTool12.SharedPropsInternal.Category = "Menus";
            buttonTool12.SharedPropsInternal.CustomizerCaption = "დაკეცვა";
            buttonTool13.SharedPropsInternal.Caption = "ახალი ფოლდერი";
            buttonTool13.SharedPropsInternal.Category = "Menus";
            buttonTool13.SharedPropsInternal.CustomizerCaption = "ახალი ფოლდერი";
            buttonTool14.SharedPropsInternal.Caption = "გახსნა";
            buttonTool14.SharedPropsInternal.Category = "Menus";
            buttonTool14.SharedPropsInternal.CustomizerCaption = "გახსნა";
            buttonTool15.SharedPropsInternal.Caption = "გახსნა ახალ ფანჯარაში";
            buttonTool15.SharedPropsInternal.Category = "Menus";
            buttonTool15.SharedPropsInternal.CustomizerCaption = "გახსნა ახალ ფანჯარაში";
            buttonTool16.SharedPropsInternal.Caption = "წაშლა";
            buttonTool16.SharedPropsInternal.Category = "Menus";
            buttonTool16.SharedPropsInternal.CustomizerCaption = "წაშლა";
            buttonTool17.SharedPropsInternal.Caption = "გადარქმევა";
            buttonTool17.SharedPropsInternal.Category = "Menus";
            buttonTool17.SharedPropsInternal.CustomizerCaption = "გადარქმევა";
            buttonTool18.SharedPropsInternal.Caption = "კოპირება";
            buttonTool18.SharedPropsInternal.Category = "Menus";
            buttonTool18.SharedPropsInternal.CustomizerCaption = "კოპირება";
            buttonTool19.SharedPropsInternal.Caption = "ჩასმა";
            buttonTool19.SharedPropsInternal.Category = "Menus";
            buttonTool19.SharedPropsInternal.CustomizerCaption = "ჩასმა";
            buttonTool20.SharedPropsInternal.Caption = "მოჭრა";
            buttonTool20.SharedPropsInternal.Category = "Menus";
            buttonTool20.SharedPropsInternal.CustomizerCaption = "მოჭრა";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17,
            buttonTool18,
            buttonTool19,
            buttonTool20});
            // 
            // _Form1_Toolbars_Dock_Area_Right
            // 
            this._Form1_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Form1_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(542, 0);
            this._Form1_Toolbars_Dock_Area_Right.Name = "_Form1_Toolbars_Dock_Area_Right";
            this._Form1_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 265);
            this._Form1_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Form1_Toolbars_Dock_Area_Top
            // 
            this._Form1_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Form1_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Form1_Toolbars_Dock_Area_Top.Name = "_Form1_Toolbars_Dock_Area_Top";
            this._Form1_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(542, 0);
            this._Form1_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Form1_Toolbars_Dock_Area_Bottom
            // 
            this._Form1_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Form1_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 265);
            this._Form1_Toolbars_Dock_Area_Bottom.Name = "_Form1_Toolbars_Dock_Area_Bottom";
            this._Form1_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(542, 0);
            this._Form1_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // FavoritesWindows
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(542, 265);
            this.Controls.Add(this.ultraTabControl1);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Top);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FavoritesWindows";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ფავორიტებში დამატება";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion



		private void Form1_Load(object sender, System.EventArgs e)
		{

		}

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void ultraTextEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = ILG.Codex.KeyBoard.Layout.U[e.KeyChar];
        }



        

      
       
    }
}
