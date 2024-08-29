/*-------------------------------------------------------------------------------------------------------------
** module:        TX Text Control Words
**
** copyright:     © Text Control GmbH
** author:        T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4.DocumentForm
{

	/// <summary>
	/// Summary description for frmInsertSection.
	/// </summary>
	public class InsertBreakDialog : System.Windows.Forms.Form {

		internal System.Windows.Forms.Button cmdCancel;
		internal System.Windows.Forms.Button cmdOK;
		private RadioButton BeginAtNewLineRadio;
		private RadioButton BeginAtNewPageRadio;
		private RadioButton InsertPageBreakRadio;
		private GroupBox SectionBreakGroupBox;
		private GroupBox BreakGroupBox;
		private RadioButton InsertTextBreakRadio;
		private RadioButton InsertColumnRadio;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InsertBreakDialog() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

	
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
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
		private void InitializeComponent() {
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.BeginAtNewLineRadio = new System.Windows.Forms.RadioButton();
			this.BeginAtNewPageRadio = new System.Windows.Forms.RadioButton();
			this.SectionBreakGroupBox = new System.Windows.Forms.GroupBox();
			this.InsertPageBreakRadio = new System.Windows.Forms.RadioButton();
			this.BreakGroupBox = new System.Windows.Forms.GroupBox();
			this.InsertColumnRadio = new System.Windows.Forms.RadioButton();
			this.InsertTextBreakRadio = new System.Windows.Forms.RadioButton();
			this.SectionBreakGroupBox.SuspendLayout();
			this.BreakGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(102, 184);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 24);
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(12, 185);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(80, 24);
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "&OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// BeginAtNewLineRadio
			// 
			this.BeginAtNewLineRadio.AutoCheck = false;
			this.BeginAtNewLineRadio.AutoSize = true;
			this.BeginAtNewLineRadio.Location = new System.Drawing.Point(6, 42);
			this.BeginAtNewLineRadio.Name = "BeginAtNewLineRadio";
			this.BeginAtNewLineRadio.Size = new System.Drawing.Size(106, 17);
			this.BeginAtNewLineRadio.TabIndex = 4;
			this.BeginAtNewLineRadio.TabStop = true;
			this.BeginAtNewLineRadio.Text = "Begin at &new line";
			this.BeginAtNewLineRadio.UseVisualStyleBackColor = true;
			this.BeginAtNewLineRadio.Click += new System.EventHandler(this.BeginAtNewLineRadio_Click);
			// 
			// BeginAtNewPageRadio
			// 
			this.BeginAtNewPageRadio.AutoCheck = false;
			this.BeginAtNewPageRadio.Location = new System.Drawing.Point(6, 19);
			this.BeginAtNewPageRadio.Name = "BeginAtNewPageRadio";
			this.BeginAtNewPageRadio.Size = new System.Drawing.Size(158, 17);
			this.BeginAtNewPageRadio.TabIndex = 3;
			this.BeginAtNewPageRadio.TabStop = true;
			this.BeginAtNewPageRadio.Text = "Begin &at new page";
			this.BeginAtNewPageRadio.UseVisualStyleBackColor = true;
			this.BeginAtNewPageRadio.Click += new System.EventHandler(this.BeginAtNewPageRadio_Click);
			// 
			// SectionBreakGroupBox
			// 
			this.SectionBreakGroupBox.Controls.Add(this.BeginAtNewLineRadio);
			this.SectionBreakGroupBox.Controls.Add(this.BeginAtNewPageRadio);
			this.SectionBreakGroupBox.Location = new System.Drawing.Point(12, 109);
			this.SectionBreakGroupBox.Name = "SectionBreakGroupBox";
			this.SectionBreakGroupBox.Size = new System.Drawing.Size(170, 70);
			this.SectionBreakGroupBox.TabIndex = 3;
			this.SectionBreakGroupBox.TabStop = false;
			this.SectionBreakGroupBox.Text = "Section break types";
			// 
			// InsertPageBreakRadio
			// 
			this.InsertPageBreakRadio.AutoCheck = false;
			this.InsertPageBreakRadio.AutoSize = true;
			this.InsertPageBreakRadio.Checked = true;
			this.InsertPageBreakRadio.Location = new System.Drawing.Point(6, 19);
			this.InsertPageBreakRadio.Name = "InsertPageBreakRadio";
			this.InsertPageBreakRadio.Size = new System.Drawing.Size(108, 17);
			this.InsertPageBreakRadio.TabIndex = 0;
			this.InsertPageBreakRadio.TabStop = true;
			this.InsertPageBreakRadio.Text = "Insert page &break";
			this.InsertPageBreakRadio.UseVisualStyleBackColor = true;
			this.InsertPageBreakRadio.Click += new System.EventHandler(this.InsertPageRadio_Click);
			// 
			// BreakGroupBox
			// 
			this.BreakGroupBox.Controls.Add(this.InsertColumnRadio);
			this.BreakGroupBox.Controls.Add(this.InsertTextBreakRadio);
			this.BreakGroupBox.Controls.Add(this.InsertPageBreakRadio);
			this.BreakGroupBox.Location = new System.Drawing.Point(12, 12);
			this.BreakGroupBox.Name = "BreakGroupBox";
			this.BreakGroupBox.Size = new System.Drawing.Size(170, 92);
			this.BreakGroupBox.TabIndex = 2;
			this.BreakGroupBox.TabStop = false;
			this.BreakGroupBox.Text = "Break types";
			// 
			// InsertColumnRadio
			// 
			this.InsertColumnRadio.AutoCheck = false;
			this.InsertColumnRadio.AutoSize = true;
			this.InsertColumnRadio.Location = new System.Drawing.Point(6, 42);
			this.InsertColumnRadio.Name = "InsertColumnRadio";
			this.InsertColumnRadio.Size = new System.Drawing.Size(118, 17);
			this.InsertColumnRadio.TabIndex = 1;
			this.InsertColumnRadio.TabStop = true;
			this.InsertColumnRadio.Text = "Insert &column break";
			this.InsertColumnRadio.UseVisualStyleBackColor = true;
			this.InsertColumnRadio.Click += new System.EventHandler(this.InsertColumnRadio_Click);
			// 
			// InsertTextBreakRadio
			// 
			this.InsertTextBreakRadio.AutoCheck = false;
			this.InsertTextBreakRadio.AutoSize = true;
			this.InsertTextBreakRadio.Location = new System.Drawing.Point(6, 65);
			this.InsertTextBreakRadio.Name = "InsertTextBreakRadio";
			this.InsertTextBreakRadio.Size = new System.Drawing.Size(147, 17);
			this.InsertTextBreakRadio.TabIndex = 2;
			this.InsertTextBreakRadio.TabStop = true;
			this.InsertTextBreakRadio.Text = "Insert text &wrapping break";
			this.InsertTextBreakRadio.UseVisualStyleBackColor = true;
			this.InsertTextBreakRadio.Click += new System.EventHandler(this.InsertTextBreakRadio_Click);
			// 
			// InsertBreakDialog
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(194, 219);
			this.Controls.Add(this.BreakGroupBox);
			this.Controls.Add(this.SectionBreakGroupBox);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InsertBreakDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Insert Break";
			this.TopMost = true;
			this.SectionBreakGroupBox.ResumeLayout(false);
			this.SectionBreakGroupBox.PerformLayout();
			this.BreakGroupBox.ResumeLayout(false);
			this.BreakGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		public TXTextControl.TextControl tx;
		private TXTextControl.SectionBreakKind breakKind;

		private void cmdOK_Click(object sender, System.EventArgs e) {
			int dpi = (int) (1440 / tx.CreateGraphics().DpiX);

			if (InsertPageBreakRadio.Checked) {
				tx.Selection.Text = "\f";
			}
			else if (InsertColumnRadio.Checked) {
				tx.Selection.Text = "\x0E";
			}
			else if (InsertTextBreakRadio.Checked) {
				tx.Selection.Text = "\v";
			}
			else {
				try {
					tx.Sections.Add(breakKind);
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message, ProductName);
					return;
				}
			}

			tx.ScrollLocation = new Point(tx.ScrollLocation.X, (int) (tx.InputPosition.Location.Y - (tx.Selection.SectionFormat.PageMargins.Top * dpi)));
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void InsertPageRadio_Click(object sender, EventArgs e) {
			BeginAtNewLineRadio.Checked = false;
			BeginAtNewPageRadio.Checked = false;
			InsertColumnRadio.Checked = false;
			InsertPageBreakRadio.Checked = true;
			InsertTextBreakRadio.Checked = false;
		}

		private void InsertColumnRadio_Click(object sender, EventArgs e) {
			BeginAtNewLineRadio.Checked = false;
			BeginAtNewPageRadio.Checked = false;
			InsertColumnRadio.Checked = true;
			InsertPageBreakRadio.Checked = false;
			InsertTextBreakRadio.Checked = false;
		}

		private void BeginAtNewPageRadio_Click(object sender, EventArgs e) {
			BeginAtNewLineRadio.Checked = false;
			BeginAtNewPageRadio.Checked = true;
			InsertColumnRadio.Checked = false;
			InsertPageBreakRadio.Checked = false;
			InsertTextBreakRadio.Checked = false;
			breakKind = TXTextControl.SectionBreakKind.BeginAtNewPage;
		}

		private void BeginAtNewLineRadio_Click(object sender, EventArgs e) {
			BeginAtNewLineRadio.Checked = true;
			BeginAtNewPageRadio.Checked = false;
			InsertColumnRadio.Checked = false;
			InsertPageBreakRadio.Checked = false;
			InsertTextBreakRadio.Checked = false;
			breakKind = TXTextControl.SectionBreakKind.BeginAtNewLine;
		}

		private void InsertTextBreakRadio_Click(object sender, EventArgs e) {
			BeginAtNewLineRadio.Checked = false;
			BeginAtNewPageRadio.Checked = false;
			InsertColumnRadio.Checked = false;
			InsertPageBreakRadio.Checked = false;
			InsertTextBreakRadio.Checked = true;
		}
	}
}
