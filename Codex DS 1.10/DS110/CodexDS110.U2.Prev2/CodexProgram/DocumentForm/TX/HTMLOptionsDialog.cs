/*-------------------------------------------------------------------------------------------------------------
** module:     TX Text Control Words
**
** copyright:  © Text Control GmbH
** author:     T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using ILG.Codex.CodexR4.DocumentForm;

namespace ILG.Codex.CodexR4.DocumentForm
{

	public class HTMLOptionsDialog : System.Windows.Forms.Form {

		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.TextBox txtStylesheetFile;
		internal System.Windows.Forms.Label lblStylesheetFile;
		internal System.Windows.Forms.RadioButton optSaveButDoNotOverwriteExistingFile;
		internal System.Windows.Forms.RadioButton optSaveStylesheetInSeperateFile;
		internal System.Windows.Forms.RadioButton optInlineStylesheet;
		internal System.Windows.Forms.RadioButton optNoStylesheet;
		internal System.Windows.Forms.Button cmdCancel;
		internal System.Windows.Forms.Button cmdOK;
		internal FileHandler _fileHandler;
		private System.ComponentModel.Container components = null;

		public HTMLOptionsDialog(FileHandler fileHandler) {
			InitializeComponent();
			_fileHandler = fileHandler;

			// Set dialog icon
			//this.Icon = FormMain.GetAppIcon();
		}

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
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.txtStylesheetFile = new System.Windows.Forms.TextBox();
			this.lblStylesheetFile = new System.Windows.Forms.Label();
			this.optSaveButDoNotOverwriteExistingFile = new System.Windows.Forms.RadioButton();
			this.optSaveStylesheetInSeperateFile = new System.Windows.Forms.RadioButton();
			this.optInlineStylesheet = new System.Windows.Forms.RadioButton();
			this.optNoStylesheet = new System.Windows.Forms.RadioButton();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.txtStylesheetFile);
			this.GroupBox1.Controls.Add(this.lblStylesheetFile);
			this.GroupBox1.Controls.Add(this.optSaveButDoNotOverwriteExistingFile);
			this.GroupBox1.Controls.Add(this.optSaveStylesheetInSeperateFile);
			this.GroupBox1.Controls.Add(this.optInlineStylesheet);
			this.GroupBox1.Controls.Add(this.optNoStylesheet);
			this.GroupBox1.Location = new System.Drawing.Point(8, 8);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(252, 176);
			this.GroupBox1.TabIndex = 2;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "HTML stylesheet save options";
			// 
			// txtStylesheetFile
			// 
			this.txtStylesheetFile.Location = new System.Drawing.Point(8, 144);
			this.txtStylesheetFile.Name = "txtStylesheetFile";
			this.txtStylesheetFile.Size = new System.Drawing.Size(224, 20);
			this.txtStylesheetFile.TabIndex = 5;
			// 
			// lblStylesheetFile
			// 
			this.lblStylesheetFile.Location = new System.Drawing.Point(8, 128);
			this.lblStylesheetFile.Name = "lblStylesheetFile";
			this.lblStylesheetFile.Size = new System.Drawing.Size(224, 16);
			this.lblStylesheetFile.TabIndex = 4;
			this.lblStylesheetFile.Text = "Stylesheet file:";
			// 
			// optSaveButDoNotOverwriteExistingFile
			// 
			this.optSaveButDoNotOverwriteExistingFile.Location = new System.Drawing.Point(8, 96);
			this.optSaveButDoNotOverwriteExistingFile.Name = "optSaveButDoNotOverwriteExistingFile";
			this.optSaveButDoNotOverwriteExistingFile.Size = new System.Drawing.Size(208, 18);
			this.optSaveButDoNotOverwriteExistingFile.TabIndex = 3;
			this.optSaveButDoNotOverwriteExistingFile.Text = "Sa&ve but do not overwrite existing file";
			this.optSaveButDoNotOverwriteExistingFile.CheckedChanged += new System.EventHandler(this.optSaveButDoNotOverwriteExistingFile_CheckedChanged);
			// 
			// optSaveStylesheetInSeperateFile
			// 
			this.optSaveStylesheetInSeperateFile.Location = new System.Drawing.Point(8, 72);
			this.optSaveStylesheetInSeperateFile.Name = "optSaveStylesheetInSeperateFile";
			this.optSaveStylesheetInSeperateFile.Size = new System.Drawing.Size(208, 18);
			this.optSaveStylesheetInSeperateFile.TabIndex = 2;
			this.optSaveStylesheetInSeperateFile.Text = "&Save stylesheet in separate file";
			this.optSaveStylesheetInSeperateFile.CheckedChanged += new System.EventHandler(this.optSaveStylesheetInSeperateFile_CheckedChanged);
			// 
			// optInlineStylesheet
			// 
			this.optInlineStylesheet.Location = new System.Drawing.Point(8, 48);
			this.optInlineStylesheet.Name = "optInlineStylesheet";
			this.optInlineStylesheet.Size = new System.Drawing.Size(208, 18);
			this.optInlineStylesheet.TabIndex = 1;
			this.optInlineStylesheet.Text = "&Inline stylesheet";
			this.optInlineStylesheet.CheckedChanged += new System.EventHandler(this.optInlineStylesheet_CheckedChanged);
			// 
			// optNoStylesheet
			// 
			this.optNoStylesheet.Location = new System.Drawing.Point(8, 24);
			this.optNoStylesheet.Name = "optNoStylesheet";
			this.optNoStylesheet.Size = new System.Drawing.Size(208, 18);
			this.optNoStylesheet.TabIndex = 0;
			this.optNoStylesheet.TabStop = true;
			this.optNoStylesheet.Text = "&No stylesheet";
			this.optNoStylesheet.CheckedChanged += new System.EventHandler(this.optNoStylesheet_CheckedChanged);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(180, 190);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 24);
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(94, 190);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(80, 24);
			this.cmdOK.TabIndex = 0;
			this.cmdOK.Text = "&OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// HTMLOptionsDialog
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(272, 222);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HTMLOptionsDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "HTML Options";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmHTMLOptions_Load);
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e) {
			_fileHandler.CSSFileName = txtStylesheetFile.Text;

			if (optNoStylesheet.Checked) {
				_fileHandler.CSSSaveMode = TXTextControl.CssSaveMode.None;
			}
			else if (optInlineStylesheet.Checked) {
				_fileHandler.CSSSaveMode = TXTextControl.CssSaveMode.Inline;
			}
			else if (optSaveStylesheetInSeperateFile.Checked) {
				_fileHandler.CSSSaveMode = TXTextControl.CssSaveMode.OverwriteFile;
			}
			else {
				_fileHandler.CSSSaveMode = TXTextControl.CssSaveMode.CreateFile;
			}

			Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void optNoStylesheet_CheckedChanged(object sender, System.EventArgs e) {
			EnableFilename(false);
		}

		private void optInlineStylesheet_CheckedChanged(object sender, System.EventArgs e) {
			EnableFilename(false);
		}

		private void optSaveStylesheetInSeperateFile_CheckedChanged(object sender, System.EventArgs e) {
			EnableFilename(true);
		}

		private void optSaveButDoNotOverwriteExistingFile_CheckedChanged(object sender, System.EventArgs e) {
			EnableFilename(true);
		}

		private void EnableFilename(bool Enable) {
			lblStylesheetFile.Enabled = Enable;
			txtStylesheetFile.Enabled = Enable;
		}

		private void frmHTMLOptions_Load(object sender, System.EventArgs e) {
			txtStylesheetFile.Text = _fileHandler.CSSFileName;

			switch (_fileHandler.CSSSaveMode) {
				case TXTextControl.CssSaveMode.None:
					optNoStylesheet.Checked = true; break;
				case TXTextControl.CssSaveMode.Inline:
					optInlineStylesheet.Checked = true; break;
				case TXTextControl.CssSaveMode.OverwriteFile:
					optSaveStylesheetInSeperateFile.Checked = true; break;
				case TXTextControl.CssSaveMode.CreateFile:
					optSaveButDoNotOverwriteExistingFile.Checked = true; break;
			}
		}
	}
}
