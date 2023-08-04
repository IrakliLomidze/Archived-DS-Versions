using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ILG.Windows.Forms
{
	/// <summary>
	/// Summary description for ILGMessageBox.
	/// </summary>
	internal class ILGMessageBoxForm :	System.Windows.Forms.Form
    {
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        public LinkLabel DetailLabel;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor DetailText;
        public Infragistics.Win.Misc.UltraButton button3;
        public Infragistics.Win.Misc.UltraButton button2;
        public Infragistics.Win.Misc.UltraButton button1;
        public PictureBox picInformation;
        public PictureBox picError;
        public PictureBox picExclamation;
        public PictureBox pictureQuestion;
        public PictureBox pic;
        public Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		// Parametrs
		
		public ILGMessageBoxForm()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ILGMessageBoxForm));
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.label1 = new System.Windows.Forms.Label();
            this.DetailLabel = new System.Windows.Forms.LinkLabel();
            this.DetailText = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.button3 = new Infragistics.Win.Misc.UltraButton();
            this.button2 = new Infragistics.Win.Misc.UltraButton();
            this.button1 = new Infragistics.Win.Misc.UltraButton();
            this.picInformation = new System.Windows.Forms.PictureBox();
            this.picError = new System.Windows.Forms.PictureBox();
            this.picExclamation = new System.Windows.Forms.PictureBox();
            this.pictureQuestion = new System.Windows.Forms.PictureBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExclamation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.label1);
            this.ultraTabPageControl1.Controls.Add(this.DetailLabel);
            this.ultraTabPageControl1.Controls.Add(this.DetailText);
            this.ultraTabPageControl1.Controls.Add(this.button3);
            this.ultraTabPageControl1.Controls.Add(this.button2);
            this.ultraTabPageControl1.Controls.Add(this.button1);
            this.ultraTabPageControl1.Controls.Add(this.picInformation);
            this.ultraTabPageControl1.Controls.Add(this.picError);
            this.ultraTabPageControl1.Controls.Add(this.picExclamation);
            this.ultraTabPageControl1.Controls.Add(this.pictureQuestion);
            this.ultraTabPageControl1.Controls.Add(this.pic);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(352, 303);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(59, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 40);
            this.label1.TabIndex = 38;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // DetailLabel
            // 
            this.DetailLabel.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.DetailLabel.AutoSize = true;
            this.DetailLabel.BackColor = System.Drawing.Color.Transparent;
            this.DetailLabel.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.DetailLabel.Location = new System.Drawing.Point(251, 120);
            this.DetailLabel.Name = "DetailLabel";
            this.DetailLabel.Size = new System.Drawing.Size(83, 16);
            this.DetailLabel.TabIndex = 37;
            this.DetailLabel.TabStop = true;
            this.DetailLabel.Text = "დეტალები >>";
            this.DetailLabel.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.DetailLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DetailLabel_LinkClicked_1);
            // 
            // DetailText
            // 
            this.DetailText.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.DetailText.Location = new System.Drawing.Point(13, 139);
            this.DetailText.Multiline = true;
            this.DetailText.Name = "DetailText";
            this.DetailText.ReadOnly = true;
            this.DetailText.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.DetailText.Size = new System.Drawing.Size(324, 146);
            this.DetailText.TabIndex = 36;
            // 
            // button3
            // 
            this.button3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton;
            this.button3.Location = new System.Drawing.Point(230, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 35;
            this.button3.Text = "ultraButton3";
            this.button3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // button2
            // 
            this.button2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton;
            this.button2.Location = new System.Drawing.Point(134, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "ultraButton2";
            this.button2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // button1
            // 
            this.button1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton;
            this.button1.Location = new System.Drawing.Point(30, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "ultraButton1";
            this.button1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // picInformation
            // 
            this.picInformation.Enabled = false;
            this.picInformation.Image = ((System.Drawing.Image)(resources.GetObject("picInformation.Image")));
            this.picInformation.Location = new System.Drawing.Point(254, -7);
            this.picInformation.Name = "picInformation";
            this.picInformation.Size = new System.Drawing.Size(32, 32);
            this.picInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picInformation.TabIndex = 32;
            this.picInformation.TabStop = false;
            this.picInformation.Visible = false;
            // 
            // picError
            // 
            this.picError.Enabled = false;
            this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
            this.picError.Location = new System.Drawing.Point(126, -7);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(32, 32);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picError.TabIndex = 31;
            this.picError.TabStop = false;
            this.picError.Visible = false;
            // 
            // picExclamation
            // 
            this.picExclamation.Enabled = false;
            this.picExclamation.Image = ((System.Drawing.Image)(resources.GetObject("picExclamation.Image")));
            this.picExclamation.Location = new System.Drawing.Point(214, -7);
            this.picExclamation.Name = "picExclamation";
            this.picExclamation.Size = new System.Drawing.Size(32, 32);
            this.picExclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picExclamation.TabIndex = 30;
            this.picExclamation.TabStop = false;
            this.picExclamation.Visible = false;
            // 
            // pictureQuestion
            // 
            this.pictureQuestion.Enabled = false;
            this.pictureQuestion.Image = ((System.Drawing.Image)(resources.GetObject("pictureQuestion.Image")));
            this.pictureQuestion.Location = new System.Drawing.Point(166, -7);
            this.pictureQuestion.Name = "pictureQuestion";
            this.pictureQuestion.Size = new System.Drawing.Size(32, 32);
            this.pictureQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureQuestion.TabIndex = 29;
            this.pictureQuestion.TabStop = false;
            this.pictureQuestion.Visible = false;
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(14, 25);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(32, 32);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic.TabIndex = 28;
            this.pic.TabStop = false;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(352, 303);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ultraTabControl1.TabIndex = 28;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "tab1";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(352, 303);
            // 
            // ILGMessageBoxForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(352, 303);
            this.Controls.Add(this.ultraTabControl1);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ILGMessageBoxForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Activated += new System.EventHandler(this.ILGMessageBoxForm_Activated);
            this.Load += new System.EventHandler(this.ILGMessageBoxForm_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExclamation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public MessageBoxDefaultButton df;
        public bool expanded = false;

		private void ILGMessageBoxForm_Load(object sender, System.EventArgs e)
		{
            if (this.DetailText.Text.Trim() == "") return;
            expanded = false;
            updateform2();
		}

		private void ILGMessageBoxForm_Activated(object sender, System.EventArgs e)
		{
			switch (df) 
			{
				case  MessageBoxDefaultButton.Button1 : button1.Focus();break;
				case  MessageBoxDefaultButton.Button2 : if (button2.Enabled ) button2.Focus(); else button1.Focus();break;
				case  MessageBoxDefaultButton.Button3 : if (button3.Enabled ) button3.Focus(); else button1.Focus();break;
			}
		
		}

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
       

        }

        private void updateform2()
        {
            if (expanded == false)
            {
                this.DetailText.Enabled = false;
                this.DetailText.Visible = false;
                int w = this.ClientSize.Width;
                this.ClientSize = new Size(w, this.DetailLabel.Top + this.DetailLabel.Height + 8);
                this.DetailLabel.Text = "დეტალები >>";
            }
            else
            {
                this.DetailText.Enabled = true;
                this.DetailText.Visible = true;
                int w = this.ClientSize.Width;
                this.ClientSize = new Size(w, this.DetailText.Top + this.DetailText.Height + 8);
                this.DetailLabel.Text = "მოკლედ <<";
            }
        }
        private void DetailText_ValueChanged(object sender, EventArgs e)
        {
            
         
        }

        private void DetailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            expanded = !expanded;
            updateform2();
        }

        private void DetailLabel_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            expanded = !expanded;
            updateform2();
        }


		
	}
}
