using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using ILG.DS.Controls;
using ILG.DS.Profile;
using ILG.DS.Profile.Specifics;
using ILG.DS.Profile.Properties;
using DSProfileMaker.TSQLGenerators;
using ILG.DS.IO;

namespace ILG.DS.Profile
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Wizard_Form2 : System.Windows.Forms.Form
	{
		private Infragistics.Win.UltraWinTabControl.UltraTabControl MainPageWizard;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private System.Windows.Forms.TextBox textBox_DSProfileFilename;
		private Infragistics.Win.Misc.UltraButton Button_CUFFilePicker;
		private Infragistics.Win.Misc.UltraButton Button_Close;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _Wizard_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _Wizard_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _Wizard_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _Wizard_UltraFormManager_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl LeftPanel;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage4;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl11;
        private Infragistics.Win.Misc.UltraLabel LeftPanel_Label1;
        private Infragistics.Win.Misc.UltraLabel LeftPanel_Label2;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private TableLayoutPanel tableLayoutPanel1;
        private IContainer components;
        private TableLayoutPanel tableLayoutPanel3;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox5;
        private Label label6;
        private Label label7;
        private TableLayoutPanel tableLayoutPanel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileFileName_EditBox;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDisplayName_EditBox;
        private TableLayoutPanel tableLayoutPanel6;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox DataBase_Icon;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDBName_EditBox;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDBLocation_EditBox;
        private Infragistics.Win.Misc.UltraButton Button_DB_Location;
        private TableLayoutPanel tableLayoutPanel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDBUserName_EditBox;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ProfileDBPassword_EditBox;
        private Infragistics.Win.Misc.UltraButton ultraButton3;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraButton ultraButton2;



        private DSProfileManager _profileManager;
        private string ds_path;

        private string profile_fill_path;

        private string profile_file_name;
        private string profile_display_name;
        private string db_version;
        private string db_name;
        private string db_path_t;
        private string db_user;
        private string db_userpassword;
        private string db_autherification;


        public Wizard_Form2()
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wizard_Form2));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPictureBox4 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ProfileDBUserName_EditBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ProfileDBPassword_EditBox = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraPictureBox5 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Button_CUFFilePicker = new Infragistics.Win.Misc.UltraButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_DSProfileFilename = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Close = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabPageControl11 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.LeftPanel_Label1 = new Infragistics.Win.Misc.UltraLabel();
            this.LeftPanel_Label2 = new Infragistics.Win.Misc.UltraLabel();
            this.MainPageWizard = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._Wizard_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._Wizard_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._Wizard_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._Wizard_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.LeftPanel = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage4 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
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
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ultraTabPageControl11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPageWizard)).BeginInit();
            this.MainPageWizard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftPanel)).BeginInit();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ultraTabPageControl1.Controls.Add(this.ultraButton1);
            this.ultraTabPageControl1.Controls.Add(this.ultraButton3);
            this.ultraTabPageControl1.Controls.Add(this.tableLayoutPanel10);
            this.ultraTabPageControl1.Controls.Add(this.tableLayoutPanel6);
            this.ultraTabPageControl1.Controls.Add(this.tableLayoutPanel4);
            this.ultraTabPageControl1.Controls.Add(this.tableLayoutPanel3);
            this.ultraTabPageControl1.Controls.Add(this.tableLayoutPanel1);
            this.ultraTabPageControl1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(705, 475);
            // 
            // ultraButton1
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            this.ultraButton1.Appearance = appearance1;
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.ultraButton1.Location = new System.Drawing.Point(4, 300);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(227, 30);
            this.ultraButton1.TabIndex = 83;
            this.ultraButton1.Text = "Script ების ახლიდან გენერაცია";
            this.ultraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton1.Click += new System.EventHandler(this.Regenerate_Scrtips_Click);
            // 
            // ultraButton3
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            this.ultraButton3.Appearance = appearance2;
            this.ultraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.ultraButton3.Location = new System.Drawing.Point(464, 387);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(229, 24);
            this.ultraButton3.TabIndex = 82;
            this.ultraButton3.Text = "პრფილიში ცვილებების ჩაწერა";
            this.ultraButton3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton3.Click += new System.EventHandler(this.SaveNewProfile_Click);
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
            this.tableLayoutPanel10.Controls.Add(this.ultraPictureBox4, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.ProfileDBUserName_EditBox, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.ultraLabel2, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.ProfileDBPassword_EditBox, 2, 1);
            this.tableLayoutPanel10.Controls.Add(this.ultraButton2, 3, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 236);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(703, 59);
            this.tableLayoutPanel10.TabIndex = 81;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance3;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(76, 2);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(88, 17);
            this.ultraLabel1.TabIndex = 74;
            this.ultraLabel1.Text = "DB DSUserName";
            // 
            // ultraPictureBox4
            // 
            appearance4.BorderColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox4.Appearance = appearance4;
            this.ultraPictureBox4.AutoSize = true;
            this.ultraPictureBox4.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox4.Image = ((object)(resources.GetObject("ultraPictureBox4.Image")));
            this.ultraPictureBox4.Location = new System.Drawing.Point(3, 3);
            this.ultraPictureBox4.Name = "ultraPictureBox4";
            this.ultraPictureBox4.Padding = new System.Drawing.Size(6, 0);
            this.tableLayoutPanel10.SetRowSpan(this.ultraPictureBox4, 2);
            this.ultraPictureBox4.Size = new System.Drawing.Size(60, 48);
            this.ultraPictureBox4.TabIndex = 74;
            // 
            // ProfileDBUserName_EditBox
            // 
            this.ProfileDBUserName_EditBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProfileDBUserName_EditBox.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.ScenicRibbon;
            this.ProfileDBUserName_EditBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileDBUserName_EditBox.Location = new System.Drawing.Point(69, 23);
            this.ProfileDBUserName_EditBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 12);
            this.ProfileDBUserName_EditBox.Name = "ProfileDBUserName_EditBox";
            this.ProfileDBUserName_EditBox.Size = new System.Drawing.Size(288, 24);
            this.ProfileDBUserName_EditBox.TabIndex = 76;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance5;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(370, 2);
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
            this.ProfileDBPassword_EditBox.Location = new System.Drawing.Point(368, 23);
            this.ProfileDBPassword_EditBox.Margin = new System.Windows.Forms.Padding(8, 2, 3, 12);
            this.ProfileDBPassword_EditBox.Name = "ProfileDBPassword_EditBox";
            this.ProfileDBPassword_EditBox.Size = new System.Drawing.Size(283, 24);
            this.ProfileDBPassword_EditBox.TabIndex = 77;
            // 
            // ultraButton2
            // 
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.ultraButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraButton2.Location = new System.Drawing.Point(658, 23);
            this.ultraButton2.Margin = new System.Windows.Forms.Padding(4, 2, 16, 2);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Padding = new System.Drawing.Size(8, 0);
            this.ultraButton2.Size = new System.Drawing.Size(29, 20);
            this.ultraButton2.TabIndex = 36;
            this.ultraButton2.Text = "*";
            this.ultraButton2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton2.Click += new System.EventHandler(this.Regenrate_Password_Click);
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
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 174);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(703, 62);
            this.tableLayoutPanel6.TabIndex = 80;
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
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel16.Appearance = appearance6;
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
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel14.Appearance = appearance7;
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
            this.ProfileDBLocation_EditBox.Size = new System.Drawing.Size(314, 24);
            this.ProfileDBLocation_EditBox.TabIndex = 73;
            // 
            // Button_DB_Location
            // 
            this.Button_DB_Location.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DB_Location.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_DB_Location.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_DB_Location.Location = new System.Drawing.Point(547, 31);
            this.Button_DB_Location.Margin = new System.Windows.Forms.Padding(8, 2, 16, 2);
            this.Button_DB_Location.Name = "Button_DB_Location";
            this.Button_DB_Location.Padding = new System.Drawing.Size(8, 0);
            this.Button_DB_Location.Size = new System.Drawing.Size(140, 20);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 114);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(703, 60);
            this.tableLayoutPanel4.TabIndex = 79;
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(57)))), ((int)(((byte)(35)))));
            this.ultraLabel10.Appearance = appearance8;
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
            this.ProfileFileName_EditBox.ReadOnly = true;
            this.ProfileFileName_EditBox.Size = new System.Drawing.Size(191, 24);
            this.ProfileFileName_EditBox.TabIndex = 1;
            this.ProfileFileName_EditBox.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ProfileFileName_EditBox.TextChanged += new System.EventHandler(this.ProfileFileName_EditBox_TextChanged);
            this.ProfileFileName_EditBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProfileFileName_EditBox_KeyUp);
            this.ProfileFileName_EditBox.Leave += new System.EventHandler(this.ProfileFileName_EditBox_Leave);
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(57)))), ((int)(((byte)(35)))));
            this.ultraLabel13.Appearance = appearance9;
            this.ultraLabel13.AutoSize = true;
            this.ultraLabel13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel13.Location = new System.Drawing.Point(226, 2);
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
            this.ProfileDisplayName_EditBox.Location = new System.Drawing.Point(218, 23);
            this.ProfileDisplayName_EditBox.Margin = new System.Windows.Forms.Padding(8, 2, 16, 2);
            this.ProfileDisplayName_EditBox.MaxLength = 256;
            this.ProfileDisplayName_EditBox.Name = "ProfileDisplayName_EditBox";
            this.ProfileDisplayName_EditBox.Size = new System.Drawing.Size(469, 25);
            this.ProfileDisplayName_EditBox.TabIndex = 2;
            this.ProfileDisplayName_EditBox.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.ultraPictureBox5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Button_CUFFilePicker, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox_DSProfileFilename, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(703, 114);
            this.tableLayoutPanel3.TabIndex = 78;
            // 
            // ultraPictureBox5
            // 
            appearance10.BorderColor = System.Drawing.Color.Transparent;
            this.ultraPictureBox5.Appearance = appearance10;
            this.ultraPictureBox5.AutoSize = true;
            this.ultraPictureBox5.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox5.Image = ((object)(resources.GetObject("ultraPictureBox5.Image")));
            this.ultraPictureBox5.Location = new System.Drawing.Point(12, 8);
            this.ultraPictureBox5.Margin = new System.Windows.Forms.Padding(12, 8, 12, 3);
            this.ultraPictureBox5.Name = "ultraPictureBox5";
            this.ultraPictureBox5.Size = new System.Drawing.Size(48, 48);
            this.ultraPictureBox5.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(75, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 12, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 27);
            this.label6.TabIndex = 73;
            this.label6.Text = "პროფილის რედაქტირება";
            // 
            // Button_CUFFilePicker
            // 
            this.Button_CUFFilePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.Image = global::ILG.DS.Profile.Properties.Resources.folder_open;
            this.Button_CUFFilePicker.Appearance = appearance11;
            this.Button_CUFFilePicker.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_CUFFilePicker.Location = new System.Drawing.Point(592, 85);
            this.Button_CUFFilePicker.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.Button_CUFFilePicker.Name = "Button_CUFFilePicker";
            this.Button_CUFFilePicker.Size = new System.Drawing.Size(99, 24);
            this.Button_CUFFilePicker.TabIndex = 37;
            this.Button_CUFFilePicker.Text = "არჩევა";
            this.Button_CUFFilePicker.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_CUFFilePicker.Click += new System.EventHandler(this.Button_ReadProfile_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(75, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 22);
            this.label7.TabIndex = 74;
            this.label7.Text = "აირჩიეთ პროფილის ფაილი";
            // 
            // textBox_DSProfileFilename
            // 
            this.textBox_DSProfileFilename.Location = new System.Drawing.Point(75, 84);
            this.textBox_DSProfileFilename.Name = "textBox_DSProfileFilename";
            this.textBox_DSProfileFilename.ReadOnly = true;
            this.textBox_DSProfileFilename.Size = new System.Drawing.Size(511, 23);
            this.textBox_DSProfileFilename.TabIndex = 32;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Button_Close, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 417);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(12);
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(703, 56);
            this.tableLayoutPanel1.TabIndex = 76;
            // 
            // Button_Close
            // 
            this.Button_Close.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Close.Location = new System.Drawing.Point(592, 15);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(96, 24);
            this.Button_Close.TabIndex = 41;
            this.Button_Close.Text = "დახურვა";
            this.Button_Close.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // ultraTabPageControl11
            // 
            this.ultraTabPageControl11.Controls.Add(this.LeftPanel_Label1);
            this.ultraTabPageControl11.Controls.Add(this.LeftPanel_Label2);
            this.ultraTabPageControl11.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl11.Name = "ultraTabPageControl11";
            this.ultraTabPageControl11.Size = new System.Drawing.Size(130, 475);
            // 
            // LeftPanel_Label1
            // 
            appearance12.BackColor = System.Drawing.Color.Transparent;
            appearance12.ForeColor = System.Drawing.Color.White;
            this.LeftPanel_Label1.Appearance = appearance12;
            this.LeftPanel_Label1.AutoSize = true;
            this.LeftPanel_Label1.Location = new System.Drawing.Point(7, 12);
            this.LeftPanel_Label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LeftPanel_Label1.Name = "LeftPanel_Label1";
            this.LeftPanel_Label1.Size = new System.Drawing.Size(130, 18);
            this.LeftPanel_Label1.TabIndex = 28;
            this.LeftPanel_Label1.Text = "კოდექსის განახლების";
            this.LeftPanel_Label1.UseAppStyling = false;
            this.LeftPanel_Label1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // LeftPanel_Label2
            // 
            appearance13.BackColor = System.Drawing.Color.Transparent;
            appearance13.ForeColor = System.Drawing.Color.White;
            this.LeftPanel_Label2.Appearance = appearance13;
            this.LeftPanel_Label2.AutoSize = true;
            this.LeftPanel_Label2.Location = new System.Drawing.Point(7, 36);
            this.LeftPanel_Label2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LeftPanel_Label2.Name = "LeftPanel_Label2";
            this.LeftPanel_Label2.Size = new System.Drawing.Size(88, 18);
            this.LeftPanel_Label2.TabIndex = 26;
            this.LeftPanel_Label2.Text = "ფაილის შექმნა";
            this.LeftPanel_Label2.UseAppStyling = false;
            this.LeftPanel_Label2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // MainPageWizard
            // 
            appearance14.BackColor = System.Drawing.Color.White;
            this.MainPageWizard.Appearance = appearance14;
            this.MainPageWizard.Controls.Add(this.ultraTabSharedControlsPage1);
            this.MainPageWizard.Controls.Add(this.ultraTabPageControl1);
            this.MainPageWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPageWizard.Location = new System.Drawing.Point(131, 31);
            this.MainPageWizard.Name = "MainPageWizard";
            this.MainPageWizard.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.MainPageWizard.Size = new System.Drawing.Size(705, 475);
            this.MainPageWizard.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.MainPageWizard.TabIndex = 3;
            ultraTab2.TabPage = this.ultraTabPageControl1;
            ultraTab2.Text = "tab1";
            this.MainPageWizard.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab2});
            this.MainPageWizard.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Standard;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(705, 475);
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            this.ultraFormManager1.FormStyleSettings.FormDisplayStyle = Infragistics.Win.UltraWinToolbars.FormDisplayStyle.RoundedFixed;
            this.ultraFormManager1.FormStyleSettings.Style = Infragistics.Win.UltraWinForm.UltraFormStyle.Office2013;
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
            this._Wizard_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(837, 31);
            // 
            // _Wizard_UltraFormManager_Dock_Area_Bottom
            // 
            this._Wizard_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Wizard_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 1;
            this._Wizard_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 506);
            this._Wizard_UltraFormManager_Dock_Area_Bottom.Name = "_Wizard_UltraFormManager_Dock_Area_Bottom";
            this._Wizard_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(837, 1);
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
            this._Wizard_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(1, 475);
            // 
            // _Wizard_UltraFormManager_Dock_Area_Right
            // 
            this._Wizard_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Wizard_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._Wizard_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._Wizard_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Wizard_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._Wizard_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 1;
            this._Wizard_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(836, 31);
            this._Wizard_UltraFormManager_Dock_Area_Right.Name = "_Wizard_UltraFormManager_Dock_Area_Right";
            this._Wizard_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(1, 475);
            // 
            // LeftPanel
            // 
            appearance15.BackColor = System.Drawing.Color.Gray;
            appearance15.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            this.LeftPanel.Appearance = appearance15;
            this.LeftPanel.Controls.Add(this.ultraTabSharedControlsPage4);
            this.LeftPanel.Controls.Add(this.ultraTabPageControl11);
            this.LeftPanel.Controls.Add(this.ultraTabSharedControlsPage2);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(1, 31);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.LeftPanel.Size = new System.Drawing.Size(130, 475);
            this.LeftPanel.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.LeftPanel.TabIndex = 29;
            ultraTab1.TabPage = this.ultraTabPageControl11;
            ultraTab1.Text = "tab1";
            this.LeftPanel.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            // 
            // ultraTabSharedControlsPage4
            // 
            this.ultraTabSharedControlsPage4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage4.Name = "ultraTabSharedControlsPage4";
            this.ultraTabSharedControlsPage4.Size = new System.Drawing.Size(179, 489);
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(130, 475);
            // 
            // Wizard_Form2
            // 
            
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 507);
            this.ControlBox = false;
            this.Controls.Add(this.MainPageWizard);
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
            this.Name = "Wizard_Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "პროფილის რედაქტირება";
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
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ultraTabPageControl11.ResumeLayout(false);
            this.ultraTabPageControl11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPageWizard)).EndInit();
            this.MainPageWizard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftPanel)).EndInit();
            this.LeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

	    private void Button_Close_Click(object sender, System.EventArgs e)
		{
			Close();
		}
    
        private void Button_ReadProfile_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = DirectoryConfiguration.Instance.DSProfileRootDirectory;
            fd.Filter = "DS Profile Files (*.dsprofile)|*.dsprofile";
			fd.FilterIndex = 0 ;
			fd.RestoreDirectory = true ;
			fd.Multiselect = false;
			fd.Title = "DS Profile File";

			if(fd.ShowDialog() == DialogResult.OK)
			{
                profile_fill_path = fd.FileName;
				textBox_DSProfileFilename.Text = profile_fill_path;
                ReadData(profile_fill_path);
            }
		}

        private void ReadData(string profile_file_name)
        {
            ds_path = Path.GetDirectoryName(profile_file_name);
            var ds_file = Path.GetFileName(profile_file_name);

            _profileManager = new DSProfileManager(ds_file, ds_path);
            _profileManager.ReadConfiguraiton();
            ProfileFileName_EditBox.Text = Path.GetFileNameWithoutExtension(profile_file_name).ToUpper();
            ProfileDisplayName_EditBox.Text = _profileManager._content.ds_display_name;
            ProfileDBName_EditBox.Text = _profileManager._content.ds_db_name;
            ProfileDBUserName_EditBox.Text = _profileManager._content.ds_sql_sqluser_username;
            ProfileDBPassword_EditBox.Text = _profileManager._content.ds_sql_sqluser_password;
        }

        private void Button_Close2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Regenrate_Password_Click(object sender, EventArgs e)
        {
            db_userpassword = DSPasswordGenerator.Generate(16);
            ProfileDBPassword_EditBox.Text = db_userpassword;
        }

        private void ProfileFileName_EditBox_KeyUp(object sender, KeyEventArgs e)
        {
            ProfileDBName_EditBox.Text = "DS_" + this.ProfileFileName_EditBox.Text.Trim();
            ProfileDBUserName_EditBox.Text = "DS_User_" + this.ProfileFileName_EditBox.Text.Trim();

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
                    ProfileDBLocation_EditBox.Text = db_path_t;
                }
            }

        }

        private void ProfileFileName_EditBox_TextChanged(object sender, EventArgs e)
        {
            db_userpassword = DSPasswordGenerator.Generate(16);
            ProfileDBPassword_EditBox.Text = db_userpassword;
        }
        private bool ProfileFileNameCheck(string profilefilename)
        {
            foreach (char c in profilefilename)
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

        private void Regenerate_Scrtips_Click(object sender, EventArgs e)
        {
            if (_profileManager == null) return;
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

            if (ProfileDBLocation_EditBox.Text.Trim() == "")
            {
                MessageBox.Show("ბაზის ადგილმდებარეობა უნდა იყოს მითითებული", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RegenerateScripts();
            MessageBox.Show("Done");

        }

        private void SaveNewProfile_Click(object sender, EventArgs e)
        {
            if (_profileManager == null) return;

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
            ProfileSaving();

            MessageBox.Show("Done");
        }

        
        private void ProfileSaving()
        {
            _profileManager._content.ds_display_name = ProfileDisplayName_EditBox.Text;
            _profileManager._content.ds_db_name = ProfileDBName_EditBox.Text;
            _profileManager._content.ds_sql_sqluser_username = ProfileDBUserName_EditBox.Text;
            _profileManager._content.ds_sql_sqluser_password = ProfileDBPassword_EditBox.Text;
            _profileManager.WriteConfiguration();
        }

        private void RegenerateScripts()
        {
            DSDBScriptsGeneration dSDBScripts = new DSDBScriptsGeneration(databaseName: _profileManager._content.ds_db_name,
                                                              path: ProfileDBLocation_EditBox.Text,
                                                              userName: ProfileDBUserName_EditBox.Text,
                                                              password: ProfileDBPassword_EditBox.Text
                                                              );

            var dsfile = _profileManager._content.ds_profile_name;
            var _path = ds_path;

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

            MessageBox.Show("Done");

        }
    }
}
