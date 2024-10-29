using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using DSProfileMaker.TSQLGenerators;
using ILG.DS.Profile.Specifics;
using ILG.DS.Profile.Properties;
using ILG.DS.Controls;

namespace ILG.DS.Profile
{ 
    public partial class Wizard_Form1 : System.Windows.Forms.Form
    {
        private IContainer components;
        private string profile_file_name;
        private string profile_display_name;
        private string db_version;
        private string db_name;
        private string db_path_t;
        private string db_user;
        private string db_userpassword;
        private string db_autherification;

        private string DSDocumentDir;

        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox4;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private System.Windows.Forms.TextBox SaveDSProfile_textBox;
        private Infragistics.Win.Misc.UltraButton ultraButton9;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox2;
        private Infragistics.Win.Misc.UltraButton ultraButton10;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl LeftPanel;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage4;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl11;
        private Infragistics.Win.Misc.UltraLabel LeftPanel_Label1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileFileName_EditBox;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDisplayName_EditBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infragistics.Win.Misc.UltraButton Button_Next;
        private Infragistics.Win.Misc.UltraButton Close_Button;
        private Infragistics.Win.Misc.UltraButton Button_Previous;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _Wizard_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _Wizard_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _Wizard_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _Wizard_UltraFormManager_Dock_Area_Bottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDBUserName_EditBox;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDBPassword_EditBox;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox DataBase_Icon;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDBName_EditBox;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDBLocation_EditBox;
        private Infragistics.Win.Misc.UltraButton Button_DB_Location;

        public Wizard_Form1()
		{
			InitializeComponent();
        }
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
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wizard_Form1));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.ultraTabPageControl11 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.LeftPanel_Label1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPictureBox6 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ProfileDBUserName_EditBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ProfileDBPassword_EditBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.DataBase_Icon = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.ProfileDBName_EditBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ProfileDBLocation_EditBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.Button_DB_Location = new Infragistics.Win.Misc.UltraButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ProfileFileName_EditBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ProfileDisplayName_EditBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraPictureBox4 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.SaveDSProfile_textBox = new System.Windows.Forms.TextBox();
            this.ultraButton9 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton10 = new Infragistics.Win.Misc.UltraButton();
            this.ultraPictureBox2 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraPictureBox5 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.LeftPanel = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage4 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabSharedControlsPage3 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Next = new Infragistics.Win.Misc.UltraButton();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.Button_Previous = new Infragistics.Win.Misc.UltraButton();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._Wizard_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._Wizard_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._Wizard_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._Wizard_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.ultraTabPageControl11.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDBUserName_EditBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDBPassword_EditBox)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDBName_EditBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDBLocation_EditBox)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileFileName_EditBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDisplayName_EditBox)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftPanel)).BeginInit();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl11
            // 
            this.ultraTabPageControl11.Controls.Add(this.LeftPanel_Label1);
            this.ultraTabPageControl11.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl11.Name = "ultraTabPageControl11";
            this.ultraTabPageControl11.Size = new System.Drawing.Size(150, 435);
            // 
            // LeftPanel_Label1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.White;
            this.LeftPanel_Label1.Appearance = appearance1;
            this.LeftPanel_Label1.AutoSize = true;
            this.LeftPanel_Label1.Location = new System.Drawing.Point(7, 12);
            this.LeftPanel_Label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LeftPanel_Label1.Name = "LeftPanel_Label1";
            this.LeftPanel_Label1.Size = new System.Drawing.Size(124, 18);
            this.LeftPanel_Label1.TabIndex = 28;
            this.LeftPanel_Label1.Text = "DS პროფილის შექმნა";
            this.LeftPanel_Label1.UseAppStyling = false;
            this.LeftPanel_Label1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ultraTabPageControl1.Controls.Add(this.tableLayoutPanel10);
            this.ultraTabPageControl1.Controls.Add(this.tableLayoutPanel6);
            this.ultraTabPageControl1.Controls.Add(this.tableLayoutPanel4);
            this.ultraTabPageControl1.Controls.Add(this.tableLayoutPanel7);
            this.ultraTabPageControl1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(605, 379);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel10.ColumnCount = 4;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.Controls.Add(this.ultraLabel1, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.ultraPictureBox6, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.ProfileDBUserName_EditBox, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.ultraLabel2, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.ProfileDBPassword_EditBox, 2, 1);
            this.tableLayoutPanel10.Controls.Add(this.ultraButton1, 3, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 193);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(603, 59);
            this.tableLayoutPanel10.TabIndex = 80;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance2;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(76, 2);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(88, 17);
            this.ultraLabel1.TabIndex = 74;
            this.ultraLabel1.Text = "DB DSUserName";
            // 
            // ultraPictureBox6
            // 
            appearance3.BorderColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox6.Appearance = appearance3;
            this.ultraPictureBox6.AutoSize = true;
            this.ultraPictureBox6.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox6.Image = ((object)(resources.GetObject("ultraPictureBox6.Image")));
            this.ultraPictureBox6.Location = new System.Drawing.Point(3, 3);
            this.ultraPictureBox6.Name = "ultraPictureBox6";
            this.ultraPictureBox6.Padding = new System.Drawing.Size(6, 0);
            this.tableLayoutPanel10.SetRowSpan(this.ultraPictureBox6, 2);
            this.ultraPictureBox6.Size = new System.Drawing.Size(60, 48);
            this.ultraPictureBox6.TabIndex = 74;
            // 
            // ProfileDBUserName_EditBox
            // 
            this.ProfileDBUserName_EditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileDBUserName_EditBox.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.ScenicRibbon;
            this.ProfileDBUserName_EditBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileDBUserName_EditBox.Location = new System.Drawing.Point(69, 23);
            this.ProfileDBUserName_EditBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 12);
            this.ProfileDBUserName_EditBox.Name = "ProfileDBUserName_EditBox";
            this.ProfileDBUserName_EditBox.Size = new System.Drawing.Size(238, 24);
            this.ProfileDBUserName_EditBox.TabIndex = 76;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance4;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(320, 2);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(86, 17);
            this.ultraLabel2.TabIndex = 75;
            this.ultraLabel2.Text = "DB DS Password";
            // 
            // ProfileDBPassword_EditBox
            // 
            this.ProfileDBPassword_EditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileDBPassword_EditBox.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.ScenicRibbon;
            this.ProfileDBPassword_EditBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileDBPassword_EditBox.Location = new System.Drawing.Point(318, 23);
            this.ProfileDBPassword_EditBox.Margin = new System.Windows.Forms.Padding(8, 2, 3, 12);
            this.ProfileDBPassword_EditBox.Name = "ProfileDBPassword_EditBox";
            this.ProfileDBPassword_EditBox.Size = new System.Drawing.Size(233, 24);
            this.ProfileDBPassword_EditBox.TabIndex = 77;
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.ultraButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraButton1.Location = new System.Drawing.Point(558, 23);
            this.ultraButton1.Margin = new System.Windows.Forms.Padding(4, 2, 16, 2);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Padding = new System.Drawing.Size(8, 0);
            this.ultraButton1.Size = new System.Drawing.Size(29, 20);
            this.ultraButton1.TabIndex = 36;
            this.ultraButton1.Text = "*";
            this.ultraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 5;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.DataBase_Icon, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.ultraLabel16, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.ProfileDBName_EditBox, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.ultraLabel14, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.ProfileDBLocation_EditBox, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.Button_DB_Location, 4, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 131);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(603, 62);
            this.tableLayoutPanel6.TabIndex = 79;
            // 
            // DataBase_Icon
            // 
            this.DataBase_Icon.BackColor = System.Drawing.Color.Transparent;
            this.DataBase_Icon.BackColorInternal = System.Drawing.Color.Transparent;
            this.DataBase_Icon.BorderShadowColor = System.Drawing.Color.Empty;
            this.DataBase_Icon.Image = ((object)(resources.GetObject("DataBase_Icon.Image")));
            this.DataBase_Icon.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.DataBase_Icon.Location = new System.Drawing.Point(3, 2);
            this.DataBase_Icon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataBase_Icon.Name = "DataBase_Icon";
            this.DataBase_Icon.Padding = new System.Drawing.Size(6, 0);
            this.tableLayoutPanel6.SetRowSpan(this.DataBase_Icon, 2);
            this.DataBase_Icon.Size = new System.Drawing.Size(57, 39);
            this.DataBase_Icon.TabIndex = 29;
            this.DataBase_Icon.UseAppStyling = false;
            // 
            // ultraLabel16
            // 
            this.ultraLabel16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel16.Appearance = appearance5;
            this.ultraLabel16.AutoSize = true;
            this.ultraLabel16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel16.Location = new System.Drawing.Point(73, 2);
            this.ultraLabel16.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(81, 17);
            this.ultraLabel16.TabIndex = 70;
            this.ultraLabel16.Text = "DatabaseName";
            // 
            // ProfileDBName_EditBox
            // 
            this.ProfileDBName_EditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileDBName_EditBox.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.ScenicRibbon;
            this.ProfileDBName_EditBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileDBName_EditBox.Location = new System.Drawing.Point(66, 29);
            this.ProfileDBName_EditBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProfileDBName_EditBox.Name = "ProfileDBName_EditBox";
            this.ProfileDBName_EditBox.Size = new System.Drawing.Size(145, 24);
            this.ProfileDBName_EditBox.TabIndex = 71;
            // 
            // ultraLabel14
            // 
            this.ultraLabel14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel14.Appearance = appearance6;
            this.ultraLabel14.AutoSize = true;
            this.ultraLabel14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel14.Location = new System.Drawing.Point(224, 2);
            this.ultraLabel14.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(71, 17);
            this.ultraLabel14.TabIndex = 72;
            this.ultraLabel14.Text = "Disk Location";
            // 
            // ProfileDBLocation_EditBox
            // 
            this.ProfileDBLocation_EditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileDBLocation_EditBox.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.ScenicRibbon;
            this.ProfileDBLocation_EditBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileDBLocation_EditBox.Location = new System.Drawing.Point(222, 29);
            this.ProfileDBLocation_EditBox.Margin = new System.Windows.Forms.Padding(8, 2, 3, 2);
            this.ProfileDBLocation_EditBox.Name = "ProfileDBLocation_EditBox";
            this.ProfileDBLocation_EditBox.ReadOnly = true;
            this.ProfileDBLocation_EditBox.Size = new System.Drawing.Size(260, 24);
            this.ProfileDBLocation_EditBox.TabIndex = 73;
            // 
            // Button_DB_Location
            // 
            this.Button_DB_Location.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DB_Location.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_DB_Location.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_DB_Location.Location = new System.Drawing.Point(493, 31);
            this.Button_DB_Location.Margin = new System.Windows.Forms.Padding(8, 2, 16, 2);
            this.Button_DB_Location.Name = "Button_DB_Location";
            this.Button_DB_Location.Padding = new System.Drawing.Size(8, 0);
            this.Button_DB_Location.Size = new System.Drawing.Size(94, 20);
            this.Button_DB_Location.TabIndex = 78;
            this.Button_DB_Location.Text = "Browse";
            this.Button_DB_Location.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_DB_Location.Click += new System.EventHandler(this.Button_DB_Location_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Controls.Add(this.ultraLabel10, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ProfileFileName_EditBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.ultraLabel13, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.ProfileDisplayName_EditBox, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 71);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(603, 60);
            this.tableLayoutPanel4.TabIndex = 75;
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(57)))), ((int)(((byte)(35)))));
            this.ultraLabel10.Appearance = appearance7;
            this.ultraLabel10.AutoSize = true;
            this.ultraLabel10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel10.Location = new System.Drawing.Point(32, 2);
            this.ultraLabel10.Margin = new System.Windows.Forms.Padding(32, 2, 3, 2);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(122, 17);
            this.ultraLabel10.TabIndex = 18;
            this.ultraLabel10.Text = "პროფილის File Name";
            // 
            // ProfileFileName_EditBox
            // 
            this.ProfileFileName_EditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileFileName_EditBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ProfileFileName_EditBox.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.ProfileFileName_EditBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileFileName_EditBox.Location = new System.Drawing.Point(16, 23);
            this.ProfileFileName_EditBox.Margin = new System.Windows.Forms.Padding(16, 2, 3, 2);
            this.ProfileFileName_EditBox.MaxLength = 32;
            this.ProfileFileName_EditBox.Name = "ProfileFileName_EditBox";
            this.ProfileFileName_EditBox.Nullable = false;
            this.ProfileFileName_EditBox.Size = new System.Drawing.Size(161, 24);
            this.ProfileFileName_EditBox.TabIndex = 1;
            this.ProfileFileName_EditBox.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ProfileFileName_EditBox.TextChanged += new System.EventHandler(this.ProfileFileName_EditBox_TextChanged);
            this.ProfileFileName_EditBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProfileFileName_EditBox_KeyUp);
            this.ProfileFileName_EditBox.Leave += new System.EventHandler(this.ProfileFileName_EditBox_Leave);
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(57)))), ((int)(((byte)(35)))));
            this.ultraLabel13.Appearance = appearance8;
            this.ultraLabel13.AutoSize = true;
            this.ultraLabel13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel13.Location = new System.Drawing.Point(196, 2);
            this.ultraLabel13.Margin = new System.Windows.Forms.Padding(16, 2, 3, 2);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(241, 17);
            this.ultraLabel13.TabIndex = 17;
            this.ultraLabel13.Text = "პროფილის სრული სახელი (Display Name)";
            // 
            // ProfileDisplayName_EditBox
            // 
            this.ProfileDisplayName_EditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileDisplayName_EditBox.AutoSize = false;
            this.ProfileDisplayName_EditBox.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.ProfileDisplayName_EditBox.Location = new System.Drawing.Point(188, 23);
            this.ProfileDisplayName_EditBox.Margin = new System.Windows.Forms.Padding(8, 2, 16, 2);
            this.ProfileDisplayName_EditBox.MaxLength = 256;
            this.ProfileDisplayName_EditBox.Name = "ProfileDisplayName_EditBox";
            this.ProfileDisplayName_EditBox.Size = new System.Drawing.Size(399, 25);
            this.ProfileDisplayName_EditBox.TabIndex = 2;
            this.ProfileDisplayName_EditBox.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.ultraPictureBox4, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(603, 71);
            this.tableLayoutPanel7.TabIndex = 76;
            // 
            // ultraPictureBox4
            // 
            appearance9.BorderColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox4.Appearance = appearance9;
            this.ultraPictureBox4.AutoSize = true;
            this.ultraPictureBox4.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox4.Image = ((object)(resources.GetObject("ultraPictureBox4.Image")));
            this.ultraPictureBox4.Location = new System.Drawing.Point(12, 8);
            this.ultraPictureBox4.Margin = new System.Windows.Forms.Padding(12, 8, 12, 3);
            this.ultraPictureBox4.Name = "ultraPictureBox4";
            this.ultraPictureBox4.Size = new System.Drawing.Size(48, 48);
            this.ultraPictureBox4.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(75, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 12, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 27);
            this.label1.TabIndex = 73;
            this.label1.Text = "ახალი პროფილის შექმნა";
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ultraTabPageControl2.Controls.Add(this.tableLayoutPanel11);
            this.ultraTabPageControl2.Controls.Add(this.tableLayoutPanel9);
            this.ultraTabPageControl2.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraTabPageControl2.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(605, 379);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.AutoSize = true;
            this.tableLayoutPanel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel11.ColumnCount = 4;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.Controls.Add(this.ultraLabel3, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.SaveDSProfile_textBox, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.ultraButton9, 2, 1);
            this.tableLayoutPanel11.Controls.Add(this.ultraButton10, 1, 2);
            this.tableLayoutPanel11.Controls.Add(this.ultraPictureBox2, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 93);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 3;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(603, 93);
            this.tableLayoutPanel11.TabIndex = 80;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel3.Appearance = appearance10;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(64, 2);
            this.ultraLabel3.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(165, 17);
            this.ultraLabel3.TabIndex = 74;
            this.ultraLabel3.Text = "სად ჩაიწეროს ფროფილი";
            // 
            // SaveDSProfile_textBox
            // 
            this.SaveDSProfile_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveDSProfile_textBox.BackColor = System.Drawing.Color.White;
            this.SaveDSProfile_textBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDSProfile_textBox.Location = new System.Drawing.Point(57, 26);
            this.SaveDSProfile_textBox.Name = "SaveDSProfile_textBox";
            this.SaveDSProfile_textBox.ReadOnly = true;
            this.SaveDSProfile_textBox.Size = new System.Drawing.Size(491, 23);
            this.SaveDSProfile_textBox.TabIndex = 45;
            // 
            // ultraButton9
            // 
            appearance11.Image = global::ILG.DS.Profile.Properties.Resources.folder_open;
            this.ultraButton9.Appearance = appearance11;
            this.ultraButton9.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.ultraButton9.Location = new System.Drawing.Point(554, 24);
            this.ultraButton9.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.ultraButton9.Name = "ultraButton9";
            this.ultraButton9.Size = new System.Drawing.Size(33, 23);
            this.ultraButton9.TabIndex = 26;
            this.ultraButton9.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton9.Click += new System.EventHandler(this.ultraButton9_Click);
            // 
            // ultraButton10
            // 
            this.ultraButton10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance12.Image = ((object)(resources.GetObject("appearance12.Image")));
            this.ultraButton10.Appearance = appearance12;
            this.ultraButton10.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.tableLayoutPanel11.SetColumnSpan(this.ultraButton10, 2);
            this.ultraButton10.Location = new System.Drawing.Point(433, 62);
            this.ultraButton10.Margin = new System.Windows.Forms.Padding(3, 8, 16, 3);
            this.ultraButton10.Name = "ultraButton10";
            this.ultraButton10.Size = new System.Drawing.Size(154, 28);
            this.ultraButton10.TabIndex = 27;
            this.ultraButton10.Text = "შექმნა და ჩაწერა";
            this.ultraButton10.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton10.Click += new System.EventHandler(this.GenerateProfile_Click);
            // 
            // ultraPictureBox2
            // 
            this.ultraPictureBox2.AutoSize = true;
            this.ultraPictureBox2.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox2.Image = ((object)(resources.GetObject("ultraPictureBox2.Image")));
            this.ultraPictureBox2.Location = new System.Drawing.Point(3, 3);
            this.ultraPictureBox2.Name = "ultraPictureBox2";
            this.tableLayoutPanel11.SetRowSpan(this.ultraPictureBox2, 2);
            this.ultraPictureBox2.Size = new System.Drawing.Size(48, 48);
            this.ultraPictureBox2.TabIndex = 48;
            this.ultraPictureBox2.UseAppStyling = false;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.Controls.Add(this.ultraPictureBox5, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.label9, 1, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(603, 93);
            this.tableLayoutPanel9.TabIndex = 79;
            // 
            // ultraPictureBox5
            // 
            appearance13.BorderColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox5.Appearance = appearance13;
            this.ultraPictureBox5.AutoSize = true;
            this.ultraPictureBox5.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox5.Image = ((object)(resources.GetObject("ultraPictureBox5.Image")));
            this.ultraPictureBox5.Location = new System.Drawing.Point(12, 8);
            this.ultraPictureBox5.Margin = new System.Windows.Forms.Padding(12, 8, 12, 3);
            this.ultraPictureBox5.Name = "ultraPictureBox5";
            this.ultraPictureBox5.Size = new System.Drawing.Size(48, 48);
            this.ultraPictureBox5.TabIndex = 72;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.label8.Location = new System.Drawing.Point(75, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 12, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(250, 27);
            this.label8.TabIndex = 73;
            this.label8.Text = "ახალი პროფილის შექმნა";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(75, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 22);
            this.label9.TabIndex = 74;
            this.label9.Text = "პროფილის გენრაცია";
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(605, 379);
            // 
            // LeftPanel
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            appearance14.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.LeftPanel.Appearance = appearance14;
            this.LeftPanel.Controls.Add(this.ultraTabSharedControlsPage4);
            this.LeftPanel.Controls.Add(this.ultraTabPageControl11);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(1, 31);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.SharedControlsPage = this.ultraTabSharedControlsPage3;
            this.LeftPanel.Size = new System.Drawing.Size(150, 435);
            this.LeftPanel.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.LeftPanel.TabIndex = 28;
            ultraTab3.TabPage = this.ultraTabPageControl11;
            ultraTab3.Text = "tab1";
            this.LeftPanel.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3});
            // 
            // ultraTabSharedControlsPage4
            // 
            this.ultraTabSharedControlsPage4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage4.Name = "ultraTabSharedControlsPage4";
            this.ultraTabSharedControlsPage4.Size = new System.Drawing.Size(179, 489);
            // 
            // ultraTabSharedControlsPage3
            // 
            this.ultraTabSharedControlsPage3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage3.Name = "ultraTabSharedControlsPage3";
            this.ultraTabSharedControlsPage3.Size = new System.Drawing.Size(150, 435);
            // 
            // ultraTabControl1
            // 
            appearance15.BackColor = System.Drawing.Color.White;
            this.ultraTabControl1.Appearance = appearance15;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(151, 31);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.ultraTabControl1.Size = new System.Drawing.Size(605, 379);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ultraTabControl1.TabIndex = 3;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "tab1";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "tab2";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(752, 409);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Button_Next, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Close_Button, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Button_Previous, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(151, 410);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(12);
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 56);
            this.tableLayoutPanel1.TabIndex = 45;
            // 
            // Button_Next
            // 
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Left;
            this.Button_Next.Appearance = appearance16;
            this.Button_Next.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Next.Location = new System.Drawing.Point(392, 15);
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.Size = new System.Drawing.Size(96, 24);
            this.Button_Next.TabIndex = 3;
            this.Button_Next.Text = "შემდეგი";
            this.Button_Next.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Next.Click += new System.EventHandler(this.Button_Next_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Close_Button.Location = new System.Drawing.Point(494, 15);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(96, 24);
            this.Close_Button.TabIndex = 4;
            this.Close_Button.Text = "დახურვა";
            this.Close_Button.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // Button_Previous
            // 
            appearance17.Image = global::ILG.DS.Profile.Properties.Resources.arrow_left;
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.Button_Previous.Appearance = appearance17;
            this.Button_Previous.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Previous.Location = new System.Drawing.Point(290, 15);
            this.Button_Previous.Name = "Button_Previous";
            this.Button_Previous.Size = new System.Drawing.Size(96, 24);
            this.Button_Previous.TabIndex = 40;
            this.Button_Previous.Text = "წინა";
            this.Button_Previous.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Previous.Click += new System.EventHandler(this.Button_Previous_Click);
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            this.ultraFormManager1.FormStyleSettings.FormDisplayStyle = Infragistics.Win.UltraWinToolbars.FormDisplayStyle.RoundedFixed;
            this.ultraFormManager1.FormStyleSettings.Style = Infragistics.Win.UltraWinForm.UltraFormStyle.Office2013;
            // 
            // _Wizard_UltraFormManager_Dock_Area_Right
            // 
            this._Wizard_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Wizard_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Wizard_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._Wizard_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Wizard_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._Wizard_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 1;
            this._Wizard_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(756, 31);
            this._Wizard_UltraFormManager_Dock_Area_Right.Name = "_Wizard_UltraFormManager_Dock_Area_Right";
            this._Wizard_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(1, 435);
            // 
            // _Wizard_UltraFormManager_Dock_Area_Left
            // 
            this._Wizard_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Wizard_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Wizard_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._Wizard_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Wizard_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._Wizard_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 1;
            this._Wizard_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 31);
            this._Wizard_UltraFormManager_Dock_Area_Left.Name = "_Wizard_UltraFormManager_Dock_Area_Left";
            this._Wizard_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(1, 435);
            // 
            // _Wizard_UltraFormManager_Dock_Area_Bottom
            // 
            this._Wizard_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Wizard_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 1;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 466);
            this._Wizard_UltraFormManager_Dock_Area_Bottom.Name = "_Wizard_UltraFormManager_Dock_Area_Bottom";
            this._Wizard_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(757, 1);
            // 
            // _Wizard_UltraFormManager_Dock_Area_Top
            // 
            this._Wizard_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Wizard_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Wizard_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._Wizard_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Wizard_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._Wizard_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Wizard_UltraFormManager_Dock_Area_Top.Name = "_Wizard_UltraFormManager_Dock_Area_Top";
            this._Wizard_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(757, 31);
            // 
            // Wizard_Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(757, 467);
            this.Controls.Add(this.ultraTabControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this._Wizard_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._Wizard_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._Wizard_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._Wizard_UltraFormManager_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Wizard_Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ახალი პროფილის შექმნა";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ultraTabPageControl11.ResumeLayout(false);
            this.ultraTabPageControl11.PerformLayout();
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDBUserName_EditBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDBPassword_EditBox)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDBName_EditBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDBLocation_EditBox)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileFileName_EditBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDisplayName_EditBox)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftPanel)).EndInit();
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		
		private void Form1_Load(object sender, System.EventArgs e)
		{
            db_version = "DSH1";
            db_autherification = "SQLUSERS";
            db_userpassword = DSPasswordGenerator.Generate(16);
            db_path_t = "C:\\DSDatabases";
            ProfileDBLocation_EditBox.Text = "C:\\DSDatabases";
            
            DSDocumentDir = @Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\DS Profiles";
            if (Directory.Exists(DSDocumentDir) == false) Directory.CreateDirectory(DSDocumentDir);
            SaveDSProfile_textBox.Text = DSDocumentDir;
            PerformAction();
        }



        private void ultraButton9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(fd.SelectedPath.ToString()) == true)
                {
                    string dpath = fd.SelectedPath.ToString();
                    dpath = dpath.EndsWith("/") ? dpath.Substring(0, dpath.Length - 1) : dpath;
                    SaveDSProfile_textBox.Text = dpath;
                    DSDocumentDir = dpath;
                }
            }
        }

  



        
      

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void PerformAction()
        {
           if  (ultraTabControl1.SelectedTab.Index == 0)
            {
                Button_Previous.Enabled = false;
                Button_Previous.Visible = false;

                Button_Next.Enabled = true;
                Button_Next.Visible = true;
                return;
            }

            if (ultraTabControl1.SelectedTab.Index == 1)
            {
                Button_Previous.Enabled = true;
                Button_Previous.Visible = true;

                Button_Next.Enabled = false;
                Button_Next.Visible = false;
                return;
            }

        }
        private void Button_Next_Click(object sender, EventArgs e)
        {
            if (ultraTabControl1.SelectedTab.Index == 1) return;
            ultraTabControl1.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
            PerformAction();
        }

        private void Button_Previous_Click(object sender, EventArgs e)
        {
            if (ultraTabControl1.SelectedTab.Index == 0) return;
                ultraTabControl1.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectPreviousTab);
            PerformAction();
        }

        private void Button_DB_Location_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(fd.SelectedPath.ToString()) == true)
                {
                    db_path_t = fd.SelectedPath.ToString();
                    db_path_t = db_path_t.EndsWith("/") ? db_path_t.Substring(0, db_path_t.Length - 1) : db_path_t;
                    this.ProfileDBLocation_EditBox.Text = db_path_t;    
                }
            }
        }

        private void ProfileDBName_EditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = "DS_" + this.ProfileFileName_EditBox;
        }


        private void ProfileFileName_EditBox_KeyUp(object sender, KeyEventArgs e)
        {
            ProfileDBName_EditBox.Text = "DS_" + this.ProfileFileName_EditBox.Text.Trim();
            ProfileDBUserName_EditBox.Text = "DS_User_" + this.ProfileFileName_EditBox.Text.Trim();
        }

        private void Regenrate_Password_Click(object sender, EventArgs e)
        {
            db_userpassword = DSPasswordGenerator.Generate(16);
            ProfileDBPassword_EditBox.Text = db_userpassword;
        }

        private bool ProfileFileNameCheck(string profilefilename)
        {
            foreach(char c in profilefilename)
            {
                if (c < 'A' || c > 'Z') return false;
            }
            return true;
        }

        

        private void ProfileFileName_EditBox_Leave(object sender, EventArgs e)
        {
            if (ProfileFileNameCheck(ProfileFileName_EditBox.Text) == false)
            {
                MessageBox.Show("Profile file name შეიძლება მხოლოდ შეიცავდეს სიმბოლოებს A-Z მდე", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProfileFileName_EditBox.Focus();
                return;
            }
        }

        private void ProfileFileName_EditBox_TextChanged(object sender, EventArgs e)
        {
            db_userpassword = DSPasswordGenerator.Generate(16);
            ProfileDBPassword_EditBox.Text = db_userpassword;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            db_userpassword = DSPasswordGenerator.Generate(16);
            ProfileDBPassword_EditBox.Text = db_userpassword;
        }

        private void GenerateProfile_Click(object sender, System.EventArgs e)
        {
            if (ProfileFileNameCheck(ProfileFileName_EditBox.Text) == false)
            {
                MessageBox.Show("Profile file name შეიძლება მხოლოდ შეიცავდეს სიმბოლოებს A-Z მდე", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ProfileFileName_EditBox.Text.Trim() == "")
            {
                MessageBox.Show("Profile file name არ შიძლება იყოს ცარიელი", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ProfileDisplayName_EditBox.Text.Trim() == "")
            {
                MessageBox.Show("Profile სრულლი სახელი არ შიძლება იყოს ცარიელი", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ProfileDBName_EditBox.Text.Trim() == "")
            {
                MessageBox.Show("მონაცემთა სახელი არ შიძლება იყოს ცარიელი", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ProfileDBUserName_EditBox.Text.Trim() == "")
            {
                MessageBox.Show("მომხარებლის სახელი არ შიძლება იყოს ცარიელი", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ProfileDBPassword_EditBox.Text.Trim() == "")
            {
                MessageBox.Show("მომხარებლის პაროლი არ შიძლება იყოს ცარიელი", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (File.Exists(Path.Combine(SaveDSProfile_textBox.Text, ProfileFileName_EditBox.Text.Trim() + ".dsprofile")))
            {
                if (ILGMessageBox.Show("პრფილის ფაილი უკვე არსებობს გადავაწერო ?", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;
            }

            GenerateProfile();


            var dsfile = ProfileFileName_EditBox.Text.Trim() + ".dsprofile";
            var _path = SaveDSProfile_textBox.Text;
            
            var script_create_file = Path.Combine(_path, $"{dsfile}_Step_1_Database_Creation.sql");
            var script_structure_file = Path.Combine(_path, $"{dsfile}_Step_2_Create_Tables.sql");
            var script_seeders_file = Path.Combine(_path, $"{dsfile}_Step_3_Table_Seeders.sql");
            var script_users_file = Path.Combine(_path, $"{dsfile}_Step_4_Users.sql");
            var script_ft_file = Path.Combine(_path, $"{dsfile}_Step_5_FullText.sql");
            if (File.Exists(script_create_file) ||
                File.Exists(script_structure_file) ||
                File.Exists(script_seeders_file) ||
                File.Exists(script_users_file) ||
                File.Exists(script_ft_file))
            {
                if (ILGMessageBox.Show("სკრიპტის ფაილები უკვე არსებობს გადავაწერო ?", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) 
                    return;
            }

            MessageBox.Show("Done");
        }

    
        private void GenerateProfile()
        {
            #region step #1 profile file
            DSProfileManager profileManager = new DSProfileManager($"{ProfileFileName_EditBox.Text.Trim()}.dsprofile", SaveDSProfile_textBox.Text);
            DSProfileContent dSProfile = new DSProfileContent();
            dSProfile.ds_profile_name = ProfileFileName_EditBox.Text;
            dSProfile.ds_display_name = ProfileDisplayName_EditBox.Text;
            dSProfile.ds_db_version = db_version;
            dSProfile.ds_db_name = ProfileDBName_EditBox.Text;
            dSProfile.ds_auth_type = db_autherification;
            dSProfile.ds_sql_sqluser_username = ProfileDBUserName_EditBox.Text;
            dSProfile.ds_sql_sqluser_password = ProfileDBPassword_EditBox.Text;
            profileManager.AssingNewConfiguraiton(dSProfile);
            profileManager.WriteConfiguration();
            #endregion step #1 profile file

            #region step #2 generate scripts
            DSDBScriptsGeneration dSDBScripts = new DSDBScriptsGeneration(databaseName: ProfileDBName_EditBox.Text,
                                                                          path: ProfileDBLocation_EditBox.Text,
                                                                          userName: ProfileDBUserName_EditBox.Text,
                                                                          password: ProfileDBPassword_EditBox.Text
                                                                          );

            var dsfile = dSProfile.ds_profile_name;
            var _path = SaveDSProfile_textBox.Text;

            var script_create_file = Path.Combine(_path, $"{dsfile}_Step_1_Database_Creation.sql");
            var script_structure_file = Path.Combine(_path, $"{dsfile}_Step_2_Create_Tables.sql");
            var script_seeders_file = Path.Combine(_path, $"{dsfile}_Step_3_Table_Seeders.sql");
            var script_users_file = Path.Combine(_path, $"{dsfile}_Step_4_Users.sql");
            var script_ft_file = Path.Combine(_path, $"{dsfile}_Step_5_FullText.sql");

            var script_create = dSDBScripts.GetnerateDBCreationScript();
            File.WriteAllText(script_create_file, script_create);

            var script_structure = dSDBScripts.GetnerateDBStructureCreationScript();
            File.WriteAllText(script_structure_file, script_structure);

            var script_seeders = dSDBScripts.GetnerateDBSeedersScript();
            File.WriteAllText(script_seeders_file, script_seeders);

            var script_users = dSDBScripts.GetnerateDBUsersCreationScript();
            File.WriteAllText(script_users_file, script_users);

            var script_ft = dSDBScripts.GetnerateDBFullTextCreationScript();
            File.WriteAllText(script_ft_file, script_ft);
            #endregion step #2 generate scripts

            #region step #3 generate profile folder minimal access
            var folder = SaveDSProfile_textBox.Text;
            folder = folder + $"\\{ProfileFileName_EditBox.Text.Trim()}";
            if (Directory.Exists(folder) == false) Directory.CreateDirectory(folder);

            File.WriteAllBytes(Path.Combine(folder, "dsbehaviour.json"), Resources.dsbehaviour);
            File.WriteAllBytes(Path.Combine(folder, "dsdocument.json"), Resources.dsdocument);
            File.WriteAllBytes(Path.Combine(folder, "dsstaticdata.json"), Resources.dsstaticdata);
            File.WriteAllBytes(Path.Combine(folder, "History_Role.json"), Resources.History_Role);
            File.WriteAllBytes(Path.Combine(folder, "Role.lxs"), Resources.Role);

            #endregion step #3 generate profile folder minimal access

         
        }
    }
}
