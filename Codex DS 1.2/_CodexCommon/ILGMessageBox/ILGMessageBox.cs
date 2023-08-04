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
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.PictureBox pic;
		public System.Windows.Forms.PictureBox picError;
		public System.Windows.Forms.PictureBox picExclamation;
		public System.Windows.Forms.PictureBox pictureQuestion;
		public System.Windows.Forms.PictureBox picInformation;
		public Infragistics.Win.Misc.UltraButton button1;
		public Infragistics.Win.Misc.UltraButton button2;
		public Infragistics.Win.Misc.UltraButton button3;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ILGMessageBoxForm));
			this.label1 = new System.Windows.Forms.Label();
			this.pic = new System.Windows.Forms.PictureBox();
			this.picError = new System.Windows.Forms.PictureBox();
			this.picExclamation = new System.Windows.Forms.PictureBox();
			this.pictureQuestion = new System.Windows.Forms.PictureBox();
			this.picInformation = new System.Windows.Forms.PictureBox();
			this.button1 = new Infragistics.Win.Misc.UltraButton();
			this.button2 = new Infragistics.Win.Misc.UltraButton();
			this.button3 = new Infragistics.Win.Misc.UltraButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(64, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 40);
			this.label1.TabIndex = 14;
			// 
			// pic
			// 
			this.pic.Location = new System.Drawing.Point(16, 32);
			this.pic.Name = "pic";
			this.pic.Size = new System.Drawing.Size(32, 32);
			this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pic.TabIndex = 13;
			this.pic.TabStop = false;
			// 
			// picError
			// 
			this.picError.Enabled = false;
			this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
			this.picError.Location = new System.Drawing.Point(128, 0);
			this.picError.Name = "picError";
			this.picError.Size = new System.Drawing.Size(32, 32);
			this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picError.TabIndex = 20;
			this.picError.TabStop = false;
			this.picError.Visible = false;
			// 
			// picExclamation
			// 
			this.picExclamation.Enabled = false;
			this.picExclamation.Image = ((System.Drawing.Image)(resources.GetObject("picExclamation.Image")));
			this.picExclamation.Location = new System.Drawing.Point(216, 0);
			this.picExclamation.Name = "picExclamation";
			this.picExclamation.Size = new System.Drawing.Size(32, 32);
			this.picExclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picExclamation.TabIndex = 19;
			this.picExclamation.TabStop = false;
			this.picExclamation.Visible = false;
			// 
			// pictureQuestion
			// 
			this.pictureQuestion.Enabled = false;
			this.pictureQuestion.Image = ((System.Drawing.Image)(resources.GetObject("pictureQuestion.Image")));
			this.pictureQuestion.Location = new System.Drawing.Point(168, 0);
			this.pictureQuestion.Name = "pictureQuestion";
			this.pictureQuestion.Size = new System.Drawing.Size(32, 32);
			this.pictureQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureQuestion.TabIndex = 18;
			this.pictureQuestion.TabStop = false;
			this.pictureQuestion.Visible = false;
			// 
			// picInformation
			// 
			this.picInformation.Enabled = false;
			this.picInformation.Image = ((System.Drawing.Image)(resources.GetObject("picInformation.Image")));
			this.picInformation.Location = new System.Drawing.Point(256, 0);
			this.picInformation.Name = "picInformation";
			this.picInformation.Size = new System.Drawing.Size(32, 32);
			this.picInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picInformation.TabIndex = 21;
			this.picInformation.TabStop = false;
			this.picInformation.Visible = false;
			// 
			// button1
			// 
			this.button1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsXPCommandButton;
			this.button1.Location = new System.Drawing.Point(32, 88);
			this.button1.Name = "button1";
			this.button1.SupportThemes = false;
			this.button1.TabIndex = 22;
			this.button1.Text = "ultraButton1";
			// 
			// button2
			// 
			this.button2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsXPCommandButton;
			this.button2.Location = new System.Drawing.Point(136, 88);
			this.button2.Name = "button2";
			this.button2.SupportThemes = false;
			this.button2.TabIndex = 23;
			this.button2.Text = "ultraButton2";
			// 
			// button3
			// 
			this.button3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsXPCommandButton;
			this.button3.Location = new System.Drawing.Point(232, 88);
			this.button3.Name = "button3";
			this.button3.SupportThemes = false;
			this.button3.TabIndex = 24;
			this.button3.Text = "ultraButton3";
			// 
			// ILGMessageBoxForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(352, 134);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.picInformation);
			this.Controls.Add(this.picError);
			this.Controls.Add(this.picExclamation);
			this.Controls.Add(this.pictureQuestion);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pic);
			this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ILGMessageBoxForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.ILGMessageBoxForm_Load);
			this.Activated += new System.EventHandler(this.ILGMessageBoxForm_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		public MessageBoxDefaultButton df;

		private void ILGMessageBoxForm_Load(object sender, System.EventArgs e)
		{
		
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


		
	}
}
