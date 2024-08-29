using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{
	public class frmHeaderSettings : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.CheckBox chkFirstPageDifferent;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.NumericUpDown updownFooter;
		internal System.Windows.Forms.NumericUpDown updownHeader;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button cmdCancel;
		internal System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Timer Timer1;
		private System.ComponentModel.IContainer components;

		public frmHeaderSettings()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            this.chkFirstPageDifferent = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.updownFooter = new System.Windows.Forms.NumericUpDown();
            this.updownHeader = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // chkFirstPageDifferent
            // 
            this.chkFirstPageDifferent.Location = new System.Drawing.Point(16, 112);
            this.chkFirstPageDifferent.Name = "chkFirstPageDifferent";
            this.chkFirstPageDifferent.Size = new System.Drawing.Size(184, 16);
            this.chkFirstPageDifferent.TabIndex = 11;
            this.chkFirstPageDifferent.Text = "First page different";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.updownFooter);
            this.GroupBox1.Controls.Add(this.updownHeader);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 16);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(176, 80);
            this.GroupBox1.TabIndex = 10;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Distance from page border";
            // 
            // updownFooter
            // 
            this.updownFooter.Location = new System.Drawing.Point(64, 48);
            this.updownFooter.Name = "updownFooter";
            this.updownFooter.Size = new System.Drawing.Size(64, 20);
            this.updownFooter.TabIndex = 9;
            // 
            // updownHeader
            // 
            this.updownHeader.Location = new System.Drawing.Point(64, 24);
            this.updownHeader.Name = "updownHeader";
            this.updownHeader.Size = new System.Drawing.Size(64, 20);
            this.updownHeader.TabIndex = 8;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(136, 48);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(32, 16);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "mm";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(136, 24);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(32, 16);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "mm";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 48);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 16);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Footer";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Header";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(200, 48);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 24);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(200, 16);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(80, 24);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmHeaderSettings
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(288, 133);
            this.Controls.Add(this.chkFirstPageDifferent);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHeaderSettings";
            this.ShowInTaskbar = false;
            this.Text = "Header Settings";
            this.Load += new System.EventHandler(this.frmHeaderSettings_Load);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.updownFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownHeader)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public TXTextControl.TextControl tx;
		const double TWIPS2MM = 56.7;

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			tx.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Distance = (int)((Double)updownHeader.Value * TWIPS2MM);
			tx.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Distance = (int)((Double)updownFooter.Value * TWIPS2MM);
			if (chkFirstPageDifferent.Checked)
			{
				if (tx.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) == null)
					tx.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.FirstPageHeader);

				if (tx.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter) == null)
					tx.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.FirstPageFooter);
			}
			else
			{
				if (tx.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) != null)
					tx.HeadersAndFooters.Remove(TXTextControl.HeaderFooterType.FirstPageHeader);

				if (tx.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter) != null)
					tx.HeadersAndFooters.Remove(TXTextControl.HeaderFooterType.FirstPageFooter);
			}
			Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void frmHeaderSettings_Load(object sender, System.EventArgs e)
		{
			updownHeader.Value = (int)((Double)tx.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header).Distance / TWIPS2MM);
			updownFooter.Value = (int)((Double)tx.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer).Distance / TWIPS2MM);
			chkFirstPageDifferent.Checked = !(tx.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) == null);
		}
	}
}
