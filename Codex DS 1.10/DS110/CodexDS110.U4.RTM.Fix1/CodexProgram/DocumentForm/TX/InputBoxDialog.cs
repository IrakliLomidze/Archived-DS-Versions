/*-------------------------------------------------------------------------------------------------------------
** module:        TX Text Control Words
** description:   This file contains a small dialog which lets the user enter text.
**
** copyright:     © Text Control GmbH
** author:        T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;

namespace ILG.Codex.CodexR4.DocumentForm
{

	/// <summary>
	/// Lets the user enter text.
	/// </summary>
	public class InputBoxDialog : Form {

		private TextBox _txtInput;
		private Button _btnCancel;
		private Button _btnOK;
		private Button _btnFont;
		private Container _components = null;
		private bool _bAllowEmptyString = false;

		public bool HasFontButton {
			get { return _btnFont.Visible; }
			set { _btnFont.Visible = value; }
		}

		public Font SelectedFont { get; set; }

		public string TextInput { get { return _txtInput.Text; } }

		public bool AllowEmptyString {
			get { return _bAllowEmptyString; }

			set {
				_bAllowEmptyString = value;
				if (_bAllowEmptyString) _btnOK.Enabled = true;
			}
		}

		public InputBoxDialog(string strCaption, string strText) {
			InitializeComponent();

			// Set dialog icon
			

			AllowEmptyString = false;
			SelectedFont = new System.Drawing.Font("Calibri", 12);  // Set an arbitrary font
			Text = strCaption;
			_txtInput.Text = strText;
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (_components != null) {
					_components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent() {
			this._txtInput = new System.Windows.Forms.TextBox();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOK = new System.Windows.Forms.Button();
			this._btnFont = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _txtInput
			// 
			this._txtInput.Location = new System.Drawing.Point(12, 8);
			this._txtInput.Name = "_txtInput";
			this._txtInput.Size = new System.Drawing.Size(277, 20);
			this._txtInput.TabIndex = 0;
			this._txtInput.TextChanged += new System.EventHandler(this.TxtInput_TextChanged);
			// 
			// _btnCancel
			// 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(209, 34);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(80, 24);
			this._btnCancel.TabIndex = 3;
			this._btnCancel.Text = "&Cancel";
			this._btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// _btnOK
			// 
			this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOK.Enabled = false;
			this._btnOK.Location = new System.Drawing.Point(123, 34);
			this._btnOK.Name = "_btnOK";
			this._btnOK.Size = new System.Drawing.Size(80, 24);
			this._btnOK.TabIndex = 2;
			this._btnOK.Text = "&OK";
			this._btnOK.Click += new System.EventHandler(this.BtnOK_Click);
			// 
			// _btnFont
			// 
			this._btnFont.Location = new System.Drawing.Point(12, 34);
			this._btnFont.Name = "_btnFont";
			this._btnFont.Size = new System.Drawing.Size(72, 24);
			this._btnFont.TabIndex = 1;
			this._btnFont.Text = "&Font…";
			this._btnFont.Visible = false;
			this._btnFont.Click += new System.EventHandler(this.BtnFont_Click);
			// 
			// InputBoxDialog
			// 
			this.AcceptButton = this._btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(301, 67);
			this.Controls.Add(this._btnFont);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOK);
			this.Controls.Add(this._txtInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputBoxDialog";
			this.RightToLeftLayout = true;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "InputBox";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public static bool ShowInputBox(string strCaption, ref string strInput, Form owner) {
			return ShowInputBox(strCaption, ref strInput, owner, false);
		}

		public static bool ShowInputBox(string strCaption, ref string strInput, Form owner, bool allowEmptyString) {
			DialogResult result;

			var box = new InputBoxDialog(strCaption, strInput);
			box.RightToLeft = owner.RightToLeft;
			box.AllowEmptyString = allowEmptyString;
			result = box.ShowDialog(owner);

			if (result == DialogResult.OK) strInput = box._txtInput.Text;

			return (result == DialogResult.OK);
		}

		private void BtnOK_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void BtnCancel_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void TxtInput_TextChanged(object sender, System.EventArgs e) {
			if (_bAllowEmptyString) return;
			_btnOK.Enabled = (_txtInput.Text.Length > 0);
		}

		private void BtnFont_Click(object sender, System.EventArgs e) {
			var fntDlg = new FontDialog { Font = this.SelectedFont };
			if (fntDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				this.SelectedFont = fntDlg.Font;
			}
		}
	}
}
