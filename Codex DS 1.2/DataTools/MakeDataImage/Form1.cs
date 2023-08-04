using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using ILG.Windows.Forms;

//using SQLDMO;


namespace ILG.Codex.Codex2007
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl7;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ImageList imageList1;
		private Infragistics.Win.Misc.UltraButton button7;
		private Infragistics.Win.Misc.UltraButton button17;
		private Infragistics.Win.Misc.UltraButton button18;
		private Infragistics.Win.Misc.UltraButton button19;
		private Infragistics.Win.Misc.UltraButton button2;
		private Infragistics.Win.Misc.UltraButton button3;
		private Infragistics.Win.Misc.UltraButton button4;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.Label label4;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl3;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage4;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
		private System.ComponentModel.IContainer components;

		
		public delegate void ShowProgressDelegate(int progress,string Str);

		public void  ShowProgress(int progress,string Str)
		{
			if ( this.listBox1.InvokeRequired == false ) 
			{
				if (Str != "") this.listBox1.Items.Add(Str);
				this.listBox1.SelectedIndex = this.listBox1.Items.Count-1;
				//this.progressBar2.Value = progress;
			}
			else
			{
				ShowProgressDelegate  showProgress = new ShowProgressDelegate(ShowProgress);
				// Show progress synchronously 
				Invoke(showProgress, new object[] { progress, Str });
			}

		
	}




		public Form1()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new Infragistics.Win.Misc.UltraButton();
            this.label6 = new System.Windows.Forms.Label();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button3 = new Infragistics.Win.Misc.UltraButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.button4 = new Infragistics.Win.Misc.UltraButton();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ultraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ultraTabControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.button7 = new Infragistics.Win.Misc.UltraButton();
            this.button17 = new Infragistics.Win.Misc.UltraButton();
            this.button18 = new Infragistics.Win.Misc.UltraButton();
            this.button19 = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage4 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.ultraTabPageControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.ultraTabPageControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl7)).BeginInit();
            this.ultraTabControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl3)).BeginInit();
            this.ultraTabControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ultraTabPageControl1.Controls.Add(this.label10);
            this.ultraTabPageControl1.Controls.Add(this.pictureBox2);
            this.ultraTabPageControl1.Controls.Add(this.button2);
            this.ultraTabPageControl1.Controls.Add(this.label6);
            this.ultraTabPageControl1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(687, 268);
            this.ultraTabPageControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.ultraTabPageControl1_Paint);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(11, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(647, 42);
            this.label10.TabIndex = 38;
            this.label10.Text = "პროგრამა აარქივებს კოდექსი 2007 DS ის ბაზას, მითითებულ დირექტორიაში. P.S. ეს პროგ" +
                "რამა მხარს არ უჭერს სრულტექტოვანი კატალოგების კოპირებას";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(11, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            appearance1.Image = global::ILG.Codex.Codex2007.Properties.Resources.gear1;
            this.button2.Appearance = appearance1;
            this.button2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.button2.Location = new System.Drawing.Point(546, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 26);
            this.button2.TabIndex = 37;
            this.button2.Text = "კონფიგურაცია";
            this.button2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(478, 19);
            this.label6.TabIndex = 31;
            this.label6.Text = "კოდექსი 2007 დოკუმენტების არქივის ბაზის Back-ის შექმნა";
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ultraTabPageControl3.Controls.Add(this.ultraButton1);
            this.ultraTabPageControl3.Controls.Add(this.label4);
            this.ultraTabPageControl3.Controls.Add(this.pictureBox4);
            this.ultraTabPageControl3.Controls.Add(this.pictureBox3);
            this.ultraTabPageControl3.Controls.Add(this.button3);
            this.ultraTabPageControl3.Controls.Add(this.label1);
            this.ultraTabPageControl3.Controls.Add(this.textBox10);
            this.ultraTabPageControl3.Controls.Add(this.label2);
            this.ultraTabPageControl3.Controls.Add(this.textBox1);
            this.ultraTabPageControl3.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(687, 268);
            // 
            // ultraButton1
            // 
            appearance2.Image = global::ILG.Codex.Codex2007.Properties.Resources.folder_16;
            this.ultraButton1.Appearance = appearance2;
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.ultraButton1.Location = new System.Drawing.Point(564, 174);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(104, 26);
            this.ultraButton1.TabIndex = 42;
            this.ultraButton1.Text = "არჩევა";
            this.ultraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(67, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "სად იქმნება  ბაზის არქივი";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(8, 40);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 48);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 40;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 148);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            // 
            // button3
            // 
            appearance3.Image = global::ILG.Codex.Codex2007.Properties.Resources.folder_16;
            this.button3.Appearance = appearance3;
            this.button3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.button3.Location = new System.Drawing.Point(564, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 26);
            this.button3.TabIndex = 37;
            this.button3.Text = "არჩევა";
            this.button3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(62, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "მონაცემთა ბაზა Info ფაილი";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.White;
            this.textBox10.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(62, 176);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(496, 23);
            this.textBox10.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "ბაზის საინსტალაციოს შექმნა";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(59, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(499, 23);
            this.textBox1.TabIndex = 2;
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ultraTabPageControl5.Controls.Add(this.pictureBox5);
            this.ultraTabPageControl5.Controls.Add(this.button4);
            this.ultraTabPageControl5.Controls.Add(this.label3);
            this.ultraTabPageControl5.Controls.Add(this.listBox1);
            this.ultraTabPageControl5.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraTabPageControl5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(687, 268);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(16, 206);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(48, 48);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 46;
            this.pictureBox5.TabStop = false;
            // 
            // button4
            // 
            appearance4.Image = global::ILG.Codex.Codex2007.Properties.Resources.play_16;
            this.button4.Appearance = appearance4;
            this.button4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.button4.Location = new System.Drawing.Point(564, 225);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 29);
            this.button4.TabIndex = 45;
            this.button4.Text = "პროცესი";
            this.button4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(10, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(664, 23);
            this.label3.TabIndex = 44;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(10, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(664, 162);
            this.listBox1.TabIndex = 43;
            // 
            // ultraTabPageControl6
            // 
            this.ultraTabPageControl6.Controls.Add(this.pictureBox7);
            this.ultraTabPageControl6.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl6.Margin = new System.Windows.Forms.Padding(0);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new System.Drawing.Size(687, 92);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox7.Image = global::ILG.Codex.Codex2007.Properties.Resources.Left;
            this.pictureBox7.Location = new System.Drawing.Point(0, 0);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(272, 92);
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            // 
            // ultraTabControl7
            // 
            this.ultraTabControl7.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl7.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl7.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl7.Controls.Add(this.ultraTabPageControl5);
            this.ultraTabControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraTabControl7.Location = new System.Drawing.Point(0, 103);
            this.ultraTabControl7.Name = "ultraTabControl7";
            this.ultraTabControl7.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl7.Size = new System.Drawing.Size(687, 268);
            this.ultraTabControl7.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ultraTabControl7.TabIndex = 3;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "tab1";
            ultraTab2.TabPage = this.ultraTabPageControl3;
            ultraTab2.Text = "tab3";
            ultraTab3.TabPage = this.ultraTabPageControl5;
            ultraTab3.Text = "tab5";
            this.ultraTabControl7.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3});
            this.ultraTabControl7.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(687, 268);
            // 
            // button7
            // 
            appearance5.Image = global::ILG.Codex.Codex2007.Properties.Resources.arrow_left_blue;
            this.button7.Appearance = appearance5;
            this.button7.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.button7.Location = new System.Drawing.Point(283, 377);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 26);
            this.button7.TabIndex = 33;
            this.button7.Text = "უკან";
            this.button7.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button17
            // 
            appearance6.Image = global::ILG.Codex.Codex2007.Properties.Resources.arrow_right_blue;
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.button17.Appearance = appearance6;
            this.button17.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.button17.ImageList = this.imageList1;
            this.button17.Location = new System.Drawing.Point(379, 377);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(96, 26);
            this.button17.TabIndex = 34;
            this.button17.Text = "შემდეგი";
            this.button17.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            appearance7.Image = global::ILG.Codex.Codex2007.Properties.Resources.delete;
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Left;
            this.button18.Appearance = appearance7;
            this.button18.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.button18.ImageList = this.imageList1;
            this.button18.Location = new System.Drawing.Point(483, 377);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(96, 26);
            this.button18.TabIndex = 35;
            this.button18.Text = "დახურვა";
            this.button18.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            appearance8.Image = global::ILG.Codex.Codex2007.Properties.Resources.help2;
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Left;
            this.button19.Appearance = appearance8;
            this.button19.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.button19.ImageList = this.imageList1;
            this.button19.Location = new System.Drawing.Point(579, 377);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(96, 26);
            this.button19.TabIndex = 36;
            this.button19.Text = "დახმარება";
            this.button19.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // ultraTabControl3
            // 
            this.ultraTabControl3.Controls.Add(this.ultraTabSharedControlsPage4);
            this.ultraTabControl3.Controls.Add(this.ultraTabPageControl6);
            this.ultraTabControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraTabControl3.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl3.Name = "ultraTabControl3";
            this.ultraTabControl3.SharedControlsPage = this.ultraTabSharedControlsPage4;
            this.ultraTabControl3.Size = new System.Drawing.Size(687, 92);
            this.ultraTabControl3.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ultraTabControl3.TabIndex = 38;
            appearance9.ImageBackground = global::ILG.Codex.Codex2007.Properties.Resources.Midle;
            ultraTab4.Appearance = appearance9;
            ultraTab4.TabPage = this.ultraTabPageControl6;
            ultraTab4.Text = "tab1";
            this.ultraTabControl3.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab4});
            this.ultraTabControl3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage4
            // 
            this.ultraTabSharedControlsPage4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage4.Name = "ultraTabSharedControlsPage4";
            this.ultraTabSharedControlsPage4.Size = new System.Drawing.Size(687, 92);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox8.Image = global::ILG.Codex.Codex2007.Properties.Resources.aa3;
            this.pictureBox8.Location = new System.Drawing.Point(0, 92);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(687, 11);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 39;
            this.pictureBox8.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(687, 417);
            this.ControlBox = false;
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.ultraTabControl7);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.ultraTabControl3);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "კოდექსი 2007 დოკუმენტების არქივი (Backup)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ultraTabPageControl5.ResumeLayout(false);
            this.ultraTabPageControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ultraTabPageControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl7)).EndInit();
            this.ultraTabControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl3)).EndInit();
            this.ultraTabControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			int ww = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
			int hh = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
			if ((ww < 800) || (hh<600) ) 
			{
				ILG.Windows.Forms.ILGMessageBox.Show("კოდექს 2007 ის გასაშვებად ეკრანიზე წერტილების \nრაოდენობა უნა იყოს "+
					"800x600 ზე.\n"+"თქვენი ეკრანზე არის "+ww.ToString()+"x"+hh.ToString());
				return;
			}

			
			SplashScreen sp = new SplashScreen();
			sp.Show();
			sp.Refresh();
			Options.loadformfile();
			sp.Close();
			if (Common.Server == "*") 
			{
				ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება ბაზასთან დაკავშირება");
				Options dlg = new Options();
				dlg.ShowDialog();
				return;
			}
			
			
			Application.Run(LocalVar.MainForm);
		}

		
		
		private void Form1_Load(object sender, System.EventArgs e)
		{
            CheckForIllegalCrossThreadCalls = false;
            Infragistics.Win.AppStyling.StyleManager.Load(Common.CurDir + "\\Styles\\Office2007Blue.isl");
            pagenumber = 1;
			Common.CurDir = System.Environment.CurrentDirectory;
			Options.loadformfile();
			
			
			

		}

		public void Process()
		{
			this.button7.Enabled = false;
			this.button17.Enabled  = false;
			this.button18.Enabled = false;
			this.button19.Enabled = false;
			this.button4.Enabled = false;


			LocalVar.MainForm.ShowProgress(0,"მონაცემთა ბაზის კოპირების და რეგისტრაციის პროცესი");
			Database s = new Database();
			
			if (s.GetInfoFrom() == 0)
			{
				
				if (s.TakeOfflineDatabase() == 0)
				{
				    
				    s.ProcessFiles();
					s.TakeOnlineDatabase();
				}
				
			}
			
		
			//this.button7.Enabled = true;
			//this.button17.Enabled  = true;
			this.button18.Enabled = true;
			this.button19.Enabled = true;
			


		}

		delegate void ProcessDelegate();
	

		
		private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		
		private void button7_Click(object sender, System.EventArgs e)
		{
			pagenumber--;
			if (pagenumber == 5)
			{
				this.button17.Enabled = false;
				//pagenumber--;
				
			}
			else this.button17.Enabled = true;
			this.ultraTabControl7.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectPreviousTab);
		}
    
		



		
		private void button18_Click(object sender, System.EventArgs e)
		{
			if (ILG.Windows.Forms.ILGMessageBox.Show("პროგრამიდან გამოსვლა \nდარწმუნებული ხართ ?","",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) Close();
		}
		
		int pagenumber;
		
		private void button17_Click(object sender, System.EventArgs e)
		{
			pagenumber++;
			if (pagenumber == 2) { this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				                   this.textBox1.Text = Common.toPath;
				                   this.textBox10.Text = Common.FromPath;
			                       this.Cursor = System.Windows.Forms.Cursors.Default;
			                      }
			if (pagenumber == 3) { this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				                   Common.toPath = this.textBox1.Text;
				                   Common.FromPath = this.textBox10.Text;
				                   //Common.Copying = this.radioButton1.Checked;
								   showdetails();
			                       this.Cursor = System.Windows.Forms.Cursors.Default;
			                     }
			if (pagenumber == 3) { this.button17.Enabled = false;
								   

								 }
			
			this.ultraTabControl7.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
		}

		private void button15_Click(object sender, System.EventArgs e)
		{
			
		}

		private void button13_Click(object sender, System.EventArgs e)
		{
			pagenumber--;
			if (pagenumber != 3) 
			{
				this.button17.Enabled = true;

			}
			
			this.ultraTabControl7.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectPreviousTab);

		}

		private int showdetails()
		{
			DataBaseInfo f = new DataBaseInfo();
			int c = f.GetInfo(Common.FromPath);
			if (c == 0)
			{
				try
				{
					this.label3.Text = f.ds.Tables["Information"].Rows[0]["DisplayString"].ToString();
				}
				catch 
				{
					this.label3.Text = "No Database Info";
				}
			}
			else
			{
				this.label3.Text = "Error in Reading Info File";
			}
		    
			return c;
		
		}
		

		private void button2_Click_2(object sender, System.EventArgs e)
		{
			Options opdlg = new Options();
			opdlg.ShowDialog();
		}

		

		private void button3_Click_1(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fd = new FolderBrowserDialog();
			fd.ShowDialog();
		
		}
            
		
	

		private void button4_Click_1(object sender, System.EventArgs e)
		{
			

			ProcessDelegate proc = new ProcessDelegate(Process);
			proc.BeginInvoke(null,null);
			//this.Process();
			return;

		}

		private void button19_Click(object sender, System.EventArgs e)
		{
			About ab = new About();
			ab.ShowDialog();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fd = new FolderBrowserDialog();
			fd.ShowDialog();
			this.textBox1.Text = fd.SelectedPath.ToString();
			Common.toPath = this.textBox1.Text;
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
			
			OpenFileDialog fd = new OpenFileDialog();
			fd.InitialDirectory = "c:\\" ;
			fd.Filter = "Codex Update File (*.info)|*.info" ;
			fd.FilterIndex = 0 ;
			fd.RestoreDirectory = true ;
			fd.Multiselect = false;
			fd.Title = "Pick a Codex Info File";

			if(fd.ShowDialog() == DialogResult.OK)
			{
				this.textBox10.Text = fd.FileName;
				Common.FromPath = this.textBox10.Text;
				
			}

		}

		private void ultraTabPageControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		

	
	}
}

