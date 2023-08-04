using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.SqlClient;
//using ILG.Windows.Forms;

namespace ILG.Codex.Codex2007
{
	/// <summary>
	/// Summary description for Options.
	/// </summary>
	public class Options : System.Windows.Forms.Form
	{
		private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
        private Infragistics.Win.Misc.UltraButton button3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor textBox2;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor textBox3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor textBox4;
        private Infragistics.Win.Misc.UltraButton ultraButton3;
        private Infragistics.Win.Misc.UltraButton ultraButton4;
		private bool SQLConnected;

		public Options()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			SQLConnected = false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.textBox2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.button3 = new Infragistics.Win.Misc.UltraButton();
            this.textBox4 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.textBox3 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.button3);
            this.ultraTabPageControl1.Controls.Add(this.textBox2);
            this.ultraTabPageControl1.Controls.Add(this.pictureBox1);
            this.ultraTabPageControl1.Controls.Add(this.label1);
            this.ultraTabPageControl1.Controls.Add(this.label2);
            this.ultraTabPageControl1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(535, 195);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "SQL Server ის სახელი თუ იგი კოდესის ინსტალატორითაა დაინსტალირებული, იქნება „კომპი" +
                "უტერის სახელი\\CodexDS“";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "SQL სერვერი";
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraButton2);
            this.ultraTabPageControl2.Controls.Add(this.ultraButton1);
            this.ultraTabPageControl2.Controls.Add(this.textBox3);
            this.ultraTabPageControl2.Controls.Add(this.textBox4);
            this.ultraTabPageControl2.Controls.Add(this.pictureBox3);
            this.ultraTabPageControl2.Controls.Add(this.pictureBox2);
            this.ultraTabPageControl2.Controls.Add(this.label7);
            this.ultraTabPageControl2.Controls.Add(this.label4);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(535, 195);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(65, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "სად იქმნება მონაცემთა ბაზის საინსტალაციო";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(62, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(342, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "საიდან კოპირდება მონაცემთა ბაზა, მიუთითეთ info ფაილი ";
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.BackColorInternal = System.Drawing.SystemColors.Control;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(537, 220);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.ultraTabControl1.TabIndex = 0;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "მონაცემთა ბაზა";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "დირექტორიები";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(535, 195);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(18, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(393, 25);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button3
            // 
            this.button3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.button3.Location = new System.Drawing.Point(417, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 25);
            this.button3.TabIndex = 8;
            this.button3.Text = "დაკავშირება";
            this.button3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(8, 69);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(416, 25);
            this.textBox4.TabIndex = 19;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(8, 158);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(416, 25);
            this.textBox3.TabIndex = 20;
            // 
            // ultraButton1
            // 
            appearance6.Image = global::ILG.Codex.Codex2007.Properties.Resources.folder_16;
            this.ultraButton1.Appearance = appearance6;
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.ultraButton1.Location = new System.Drawing.Point(430, 67);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(92, 25);
            this.ultraButton1.TabIndex = 21;
            this.ultraButton1.Text = "არჩევა";
            this.ultraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton1.Click += new System.EventHandler(this.button6_Click);
            // 
            // ultraButton2
            // 
            appearance7.Image = global::ILG.Codex.Codex2007.Properties.Resources.folder_16;
            this.ultraButton2.Appearance = appearance7;
            this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.ultraButton2.Location = new System.Drawing.Point(432, 158);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(92, 25);
            this.ultraButton2.TabIndex = 22;
            this.ultraButton2.Text = "არჩევა";
            this.ultraButton2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton2.Click += new System.EventHandler(this.button5_Click);
            // 
            // ultraButton3
            // 
            this.ultraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.ultraButton3.Location = new System.Drawing.Point(318, 236);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(96, 25);
            this.ultraButton3.TabIndex = 3;
            this.ultraButton3.Text = "ჩაწერა";
            this.ultraButton3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton3.Click += new System.EventHandler(this.button2_Click);
            // 
            // ultraButton4
            // 
            this.ultraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.ultraButton4.Location = new System.Drawing.Point(428, 236);
            this.ultraButton4.Name = "ultraButton4";
            this.ultraButton4.Size = new System.Drawing.Size(96, 25);
            this.ultraButton4.TabIndex = 4;
            this.ultraButton4.Text = "დახურვა";
            this.ultraButton4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButton4.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 104);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // Options
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(537, 272);
            this.Controls.Add(this.ultraButton4);
            this.Controls.Add(this.ultraButton3);
            this.Controls.Add(this.ultraTabControl1);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "კონფიგურაცია";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		
		
		public static void createfile()
		{
			FileStream fs;
			try
			{
				fs = new FileStream(Common.CurDir + @"\Codex2007DSBackUp.Config.Config",FileMode.Create,FileAccess.Write,FileShare.None,1024);
			}
			catch (Exception ex )
			{ // can't open outfile
				String errorStr = "არ ხერხდება ფაილის გახსნა [" + ex.Message + "] ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr);
				return ;
			}
            
		
			Common.Server = "Codex";

			
		
			XmlDocument doc = new XmlDocument();
			XmlTextWriter writer = new XmlTextWriter(fs,System.Text.Encoding.ASCII);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartDocument();
			writer.WriteStartElement("Codex2007DatabasePickerConfiguration");
			writer.WriteElementString("ServerName",Common.Server);
			writer.WriteElementString("ToDir",Common.toPath);
			writer.WriteElementString("FromDir",Common.FromPath);
			writer.WriteEndElement();
			writer.WriteEndDocument();
			writer.Close();
			
			fs.Close();
			
			


		}

		public static void loadformfile()
		{
			
			if (File.Exists(Common.CurDir + @"\Codex2007DSBackUp.Config.Config")== false)
			{ Options.createfile();
			}

			
			
			FileStream fs;
			try
			{
				
				fs = new FileStream(Common.CurDir + @"\Codex2007DSBackUp.Config.Config",FileMode.Open,FileAccess.Read,FileShare.Read,1024);
			}
			catch (Exception ex )
			{ // can't open outfile
				String errorStr = "არ ხერხდება ფაილის გახსნა \n[" + ex.Message + "] "; 
				ILG.Windows.Forms.ILGMessageBox.Show(errorStr);
				return ;
			}
            
			
			try
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(fs);
		
				XmlNodeList nodes = doc.GetElementsByTagName("Codex2007DatabasePickerConfiguration");
				Common.Server = nodes.Item(0).ChildNodes.Item(0).InnerText.ToString(); // Serve Name
				Common.toPath = nodes.Item(0).ChildNodes.Item(1).InnerText.ToString(); // cuf
				Common.FromPath = nodes.Item(0).ChildNodes.Item(2).InnerText.ToString(); // cuf
				

				//Options.mssearch =      System.Convert.ToBoolean( 
				//nodes.Item(0).ChildNodes.Item(1).InnerText.ToString()); // Connection_String
			}
			catch //(Exception ex )
			{ // can't open outfile
				String errorStr = "კონფიგურაციის ფაილი დაზიანებულია  \nგთხოვთ გაასწოროთ იგი.\nან წაშალეთ იგი,და სისტემა შექმნის მას ახლიდან  ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr, "Configuration Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return ;
			}
			
			fs.Close();

		}


		private void button2_Click(object sender, System.EventArgs e)
		{  
		   
			if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი კონფიგურაციის ჩაწერა ?","",System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.SaveXMLData();
                ILG.Windows.Forms.ILGMessageBox.Show("ახალი კონფიგურაცია ჩაწერილია \nცვლილებების გასააქტიურებლად, გადატვირთეთ პროგრამა");
				Close();
			}
					
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void Options_Load(object sender, System.EventArgs e)
		{
			
			Options.loadformfile();
			
		
			this.textBox2.Text = Common.Server;
			this.textBox3.Text = Common.toPath;
			
			this.textBox4.Text = Common.FromPath;
			
		}


		private void SaveXMLData()
		{
			
			FileStream fs;
			try
			{
				fs = new FileStream(Common.CurDir + @"\Codex2007DSBackUp.Config.Config",FileMode.Create,FileAccess.Write,FileShare.None,1024);
			}
			catch (Exception ex )
			{ // can't open outfile
				String errorStr = "არ ხერხდება ფაილის გახსნა [" + ex.Message + "] ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr);
				return ;
			}
            
			
			
			//bool   UseFullText      = this.checkBox1.Checked;
			Common.toPath = this.textBox3.Text;
			Common.FromPath = this.textBox4.Text;

		
			
			XmlDocument doc = new XmlDocument();
			XmlTextWriter writer = new XmlTextWriter(fs,System.Text.Encoding.ASCII);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartDocument();
			writer.WriteStartElement("Codex2007DatabasePickerConfiguration");
			
			writer.WriteElementString("ServerName",Common.Server);
			writer.WriteElementString("ToDir",Common.toPath);
			writer.WriteElementString("FromDir",Common.FromPath);
			writer.WriteEndElement();
			writer.WriteEndDocument();
			writer.Close();
			
			fs.Close();
			
			


		}

		
		private void button3_Click_1(object sender, System.EventArgs e)
		{

			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			SqlConnection test = new SqlConnection ("Server="+this.textBox2.Text.Trim()+";Integrated security=SSPI;database=master");

			this.SQLConnected = false;
			try 
			{
				test.Open();
				SQLConnected  = true;
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (System.Exception ex)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.Show("კავშირი არ მყარდება: \n" + ex.ToString());
				SQLConnected  = false;
			}
			finally
			{
				if (test.State == ConnectionState.Open)
				{
					test.Close();
				}
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
			if ( SQLConnected  == true ) 
			{
                ILG.Windows.Forms.ILGMessageBox.Show("კავშირი წარმატებულად დამყარდა");
				Common.Server = this.textBox2.Text.Trim();
			}



		}

		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
			SQLConnected  = false;
		}

		

		private void button5_Click(object sender, System.EventArgs e)
		{
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            this.textBox3.Text = fd.SelectedPath.ToString();
            Common.toPath = this.textBox3.Text;

		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			
			OpenFileDialog fd = new OpenFileDialog();
			fd.InitialDirectory = "c:\\" ;
			fd.Filter = "Codex DS Update File (*.info)|*.info" ;
			fd.FilterIndex = 0 ;
			fd.RestoreDirectory = true ;
			fd.Multiselect = false;
			fd.Title = "Pick a Codex DS Info File";

			if(fd.ShowDialog() == DialogResult.OK)
			{
				this.textBox4.Text = fd.FileName;
				Common.FromPath = this.textBox4.Text;
				
			}

			
		}

		

		private void button5_Click_1(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fd = new FolderBrowserDialog();
			fd.ShowDialog();
			this.textBox3.Text = fd.SelectedPath.ToString();
			Common.toPath = this.textBox3.Text;
			
		}


	}
}
