/*-------------------------------------------------------------------------------------------------------------
** module:        TX Text Control Words
**
** copyright:     © Text Control GmbH
** author:        T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4.DocumentForm
{

	public class PDFOptionsDialog : System.Windows.Forms.Form {

		internal System.Windows.Forms.Button cmdCancel;
		internal System.Windows.Forms.Button cmdOK;
		private TabControl tabPDFSettings;
		private TabPage tabPagePDFSecurity;
		private Label labelDocumentPassword;
		private CheckBox chkUserPassword;
		private GroupBox groupBoxPDFSecurity;
		private ComboBox cboChangesAllowed;
		private Label label5;
		private ComboBox cboPrinting;
		private Label label6;
		private CheckBox chkAllowExtractContents;
		private CheckBox chkAllowContentAccessibility;
		private Label label7;
		private TextBox txtUserPassword;
		private TabPage tabPagePDFImport;
		private GroupBox groupBoxPDFImport;
		private TabPage tabPagePDFExport;
		private GroupBox groupBoxPDFExport;
		private CheckBox chkPDFEmbeddableFontsOnly;
		private ComboBox cboPDFImport;
		private CheckBox chkMasterPassword;
		private TextBox txtMasterPassword;
		private GroupBox groupBoxUserPassword;
		private GroupBox groupBox1;
		private Label lblCertPwd;
		private Label lblCertFile;
		private TextBox tbCertFile;
		private Button btnBrowseCertFile;
		private TextBox tbCertPwd;
		private System.ComponentModel.Container components = null;

		public PDFOptionsDialog(TXTextControl.TextControl textControl) {
			InitializeComponent();
			TextControl = textControl;

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
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.tabPDFSettings = new System.Windows.Forms.TabControl();
			this.tabPagePDFSecurity = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnBrowseCertFile = new System.Windows.Forms.Button();
			this.tbCertPwd = new System.Windows.Forms.TextBox();
			this.lblCertPwd = new System.Windows.Forms.Label();
			this.lblCertFile = new System.Windows.Forms.Label();
			this.tbCertFile = new System.Windows.Forms.TextBox();
			this.groupBoxUserPassword = new System.Windows.Forms.GroupBox();
			this.txtUserPassword = new System.Windows.Forms.TextBox();
			this.chkUserPassword = new System.Windows.Forms.CheckBox();
			this.labelDocumentPassword = new System.Windows.Forms.Label();
			this.groupBoxPDFSecurity = new System.Windows.Forms.GroupBox();
			this.txtMasterPassword = new System.Windows.Forms.TextBox();
			this.chkMasterPassword = new System.Windows.Forms.CheckBox();
			this.cboChangesAllowed = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cboPrinting = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkAllowExtractContents = new System.Windows.Forms.CheckBox();
			this.chkAllowContentAccessibility = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tabPagePDFImport = new System.Windows.Forms.TabPage();
			this.groupBoxPDFImport = new System.Windows.Forms.GroupBox();
			this.cboPDFImport = new System.Windows.Forms.ComboBox();
			this.tabPagePDFExport = new System.Windows.Forms.TabPage();
			this.groupBoxPDFExport = new System.Windows.Forms.GroupBox();
			this.chkPDFEmbeddableFontsOnly = new System.Windows.Forms.CheckBox();
			this.tabPDFSettings.SuspendLayout();
			this.tabPagePDFSecurity.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBoxUserPassword.SuspendLayout();
			this.groupBoxPDFSecurity.SuspendLayout();
			this.tabPagePDFImport.SuspendLayout();
			this.groupBoxPDFImport.SuspendLayout();
			this.tabPagePDFExport.SuspendLayout();
			this.groupBoxPDFExport.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(301, 399);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(80, 24);
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Text = "&Cancel";
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(387, 399);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(80, 24);
			this.cmdOK.TabIndex = 0;
			this.cmdOK.Text = "&OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// tabPDFSettings
			// 
			this.tabPDFSettings.Controls.Add(this.tabPagePDFSecurity);
			this.tabPDFSettings.Controls.Add(this.tabPagePDFImport);
			this.tabPDFSettings.Controls.Add(this.tabPagePDFExport);
			this.tabPDFSettings.Location = new System.Drawing.Point(12, 12);
			this.tabPDFSettings.Name = "tabPDFSettings";
			this.tabPDFSettings.SelectedIndex = 0;
			this.tabPDFSettings.Size = new System.Drawing.Size(455, 381);
			this.tabPDFSettings.TabIndex = 2;
			// 
			// tabPagePDFSecurity
			// 
			this.tabPagePDFSecurity.Controls.Add(this.groupBox1);
			this.tabPagePDFSecurity.Controls.Add(this.groupBoxUserPassword);
			this.tabPagePDFSecurity.Controls.Add(this.groupBoxPDFSecurity);
			this.tabPagePDFSecurity.Location = new System.Drawing.Point(4, 22);
			this.tabPagePDFSecurity.Name = "tabPagePDFSecurity";
			this.tabPagePDFSecurity.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePDFSecurity.Size = new System.Drawing.Size(447, 355);
			this.tabPagePDFSecurity.TabIndex = 0;
			this.tabPagePDFSecurity.Text = "Security";
			this.tabPagePDFSecurity.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnBrowseCertFile);
			this.groupBox1.Controls.Add(this.tbCertPwd);
			this.groupBox1.Controls.Add(this.lblCertPwd);
			this.groupBox1.Controls.Add(this.lblCertFile);
			this.groupBox1.Controls.Add(this.tbCertFile);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(435, 76);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Digital Signature";
			// 
			// btnBrowseCertFile
			// 
			this.btnBrowseCertFile.Location = new System.Drawing.Point(365, 16);
			this.btnBrowseCertFile.Name = "btnBrowseCertFile";
			this.btnBrowseCertFile.Size = new System.Drawing.Size(58, 24);
			this.btnBrowseCertFile.TabIndex = 14;
			this.btnBrowseCertFile.Text = "Browse…";
			this.btnBrowseCertFile.UseVisualStyleBackColor = true;
			this.btnBrowseCertFile.Click += new System.EventHandler(this.btnBrowseCertFile_Click);
			// 
			// tbCertPwd
			// 
			this.tbCertPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCertPwd.Location = new System.Drawing.Point(143, 45);
			this.tbCertPwd.Name = "tbCertPwd";
			this.tbCertPwd.PasswordChar = '*';
			this.tbCertPwd.Size = new System.Drawing.Size(210, 20);
			this.tbCertPwd.TabIndex = 13;
			this.tbCertPwd.UseSystemPasswordChar = true;
			this.tbCertPwd.TextChanged += new System.EventHandler(this.tbCertPwd_TextChanged);
			// 
			// lblCertPwd
			// 
			this.lblCertPwd.AutoSize = true;
			this.lblCertPwd.Location = new System.Drawing.Point(31, 47);
			this.lblCertPwd.Name = "lblCertPwd";
			this.lblCertPwd.Size = new System.Drawing.Size(106, 13);
			this.lblCertPwd.TabIndex = 12;
			this.lblCertPwd.Text = "Certificate Password:";
			// 
			// lblCertFile
			// 
			this.lblCertFile.AutoSize = true;
			this.lblCertFile.Location = new System.Drawing.Point(31, 21);
			this.lblCertFile.Name = "lblCertFile";
			this.lblCertFile.Size = new System.Drawing.Size(106, 13);
			this.lblCertFile.TabIndex = 11;
			this.lblCertFile.Text = "Certificate File (*.pfx):";
			// 
			// tbCertFile
			// 
			this.tbCertFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCertFile.Location = new System.Drawing.Point(143, 19);
			this.tbCertFile.Name = "tbCertFile";
			this.tbCertFile.Size = new System.Drawing.Size(210, 20);
			this.tbCertFile.TabIndex = 11;
			this.tbCertFile.TextChanged += new System.EventHandler(this.tbCertFile_TextChanged);
			// 
			// groupBoxUserPassword
			// 
			this.groupBoxUserPassword.Controls.Add(this.txtUserPassword);
			this.groupBoxUserPassword.Controls.Add(this.chkUserPassword);
			this.groupBoxUserPassword.Controls.Add(this.labelDocumentPassword);
			this.groupBoxUserPassword.Location = new System.Drawing.Point(6, 88);
			this.groupBoxUserPassword.Name = "groupBoxUserPassword";
			this.groupBoxUserPassword.Size = new System.Drawing.Size(435, 75);
			this.groupBoxUserPassword.TabIndex = 14;
			this.groupBoxUserPassword.TabStop = false;
			this.groupBoxUserPassword.Text = "PDF Document Password";
			// 
			// txtUserPassword
			// 
			this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUserPassword.Location = new System.Drawing.Point(143, 45);
			this.txtUserPassword.Name = "txtUserPassword";
			this.txtUserPassword.PasswordChar = '*';
			this.txtUserPassword.Size = new System.Drawing.Size(160, 20);
			this.txtUserPassword.TabIndex = 10;
			this.txtUserPassword.UseSystemPasswordChar = true;
			// 
			// chkUserPassword
			// 
			this.chkUserPassword.AutoSize = true;
			this.chkUserPassword.Location = new System.Drawing.Point(6, 19);
			this.chkUserPassword.Name = "chkUserPassword";
			this.chkUserPassword.Size = new System.Drawing.Size(227, 17);
			this.chkUserPassword.TabIndex = 7;
			this.chkUserPassword.Text = "&Require a password to open the document";
			this.chkUserPassword.Click += new System.EventHandler(this.chkUserPassword_Click);
			// 
			// labelDocumentPassword
			// 
			this.labelDocumentPassword.AutoSize = true;
			this.labelDocumentPassword.Location = new System.Drawing.Point(29, 47);
			this.labelDocumentPassword.Name = "labelDocumentPassword";
			this.labelDocumentPassword.Size = new System.Drawing.Size(108, 13);
			this.labelDocumentPassword.TabIndex = 9;
			this.labelDocumentPassword.Text = "&Document Password:";
			// 
			// groupBoxPDFSecurity
			// 
			this.groupBoxPDFSecurity.Controls.Add(this.txtMasterPassword);
			this.groupBoxPDFSecurity.Controls.Add(this.chkMasterPassword);
			this.groupBoxPDFSecurity.Controls.Add(this.cboChangesAllowed);
			this.groupBoxPDFSecurity.Controls.Add(this.label5);
			this.groupBoxPDFSecurity.Controls.Add(this.cboPrinting);
			this.groupBoxPDFSecurity.Controls.Add(this.label6);
			this.groupBoxPDFSecurity.Controls.Add(this.chkAllowExtractContents);
			this.groupBoxPDFSecurity.Controls.Add(this.chkAllowContentAccessibility);
			this.groupBoxPDFSecurity.Controls.Add(this.label7);
			this.groupBoxPDFSecurity.Location = new System.Drawing.Point(6, 169);
			this.groupBoxPDFSecurity.Name = "groupBoxPDFSecurity";
			this.groupBoxPDFSecurity.Size = new System.Drawing.Size(435, 181);
			this.groupBoxPDFSecurity.TabIndex = 13;
			this.groupBoxPDFSecurity.TabStop = false;
			this.groupBoxPDFSecurity.Text = "Permissions";
			// 
			// txtMasterPassword
			// 
			this.txtMasterPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMasterPassword.Location = new System.Drawing.Point(143, 43);
			this.txtMasterPassword.Name = "txtMasterPassword";
			this.txtMasterPassword.PasswordChar = '*';
			this.txtMasterPassword.Size = new System.Drawing.Size(160, 20);
			this.txtMasterPassword.TabIndex = 13;
			this.txtMasterPassword.TabStop = false;
			this.txtMasterPassword.UseSystemPasswordChar = true;
			// 
			// chkMasterPassword
			// 
			this.chkMasterPassword.AutoSize = true;
			this.chkMasterPassword.Location = new System.Drawing.Point(6, 19);
			this.chkMasterPassword.Name = "chkMasterPassword";
			this.chkMasterPassword.Size = new System.Drawing.Size(347, 17);
			this.chkMasterPassword.TabIndex = 12;
			this.chkMasterPassword.Text = "&Require Password for restricting printing and editing of the document";
			this.chkMasterPassword.Click += new System.EventHandler(this.chkMasterPassword_Click);
			// 
			// cboChangesAllowed
			// 
			this.cboChangesAllowed.Location = new System.Drawing.Point(143, 100);
			this.cboChangesAllowed.Name = "cboChangesAllowed";
			this.cboChangesAllowed.Size = new System.Drawing.Size(280, 21);
			this.cboChangesAllowed.TabIndex = 9;
			this.cboChangesAllowed.TabStop = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(45, 103);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Changes &Allowed:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboPrinting
			// 
			this.cboPrinting.Location = new System.Drawing.Point(143, 73);
			this.cboPrinting.Name = "cboPrinting";
			this.cboPrinting.Size = new System.Drawing.Size(280, 21);
			this.cboPrinting.TabIndex = 8;
			this.cboPrinting.TabStop = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(52, 76);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(85, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Pri&nting Allowed:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkAllowExtractContents
			// 
			this.chkAllowExtractContents.AutoSize = true;
			this.chkAllowExtractContents.Location = new System.Drawing.Point(26, 127);
			this.chkAllowExtractContents.Name = "chkAllowExtractContents";
			this.chkAllowExtractContents.Size = new System.Drawing.Size(260, 17);
			this.chkAllowExtractContents.TabIndex = 10;
			this.chkAllowExtractContents.TabStop = false;
			this.chkAllowExtractContents.Text = "&Enable copying of text, images, and other content";
			// 
			// chkAllowContentAccessibility
			// 
			this.chkAllowContentAccessibility.AutoSize = true;
			this.chkAllowContentAccessibility.Location = new System.Drawing.Point(26, 150);
			this.chkAllowContentAccessibility.Name = "chkAllowContentAccessibility";
			this.chkAllowContentAccessibility.Size = new System.Drawing.Size(351, 17);
			this.chkAllowContentAccessibility.TabIndex = 11;
			this.chkAllowContentAccessibility.TabStop = false;
			this.chkAllowContentAccessibility.Text = "Enable text access for screen reader devices for the &visually impaired";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(23, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(114, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "&Permissions Password:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabPagePDFImport
			// 
			this.tabPagePDFImport.Controls.Add(this.groupBoxPDFImport);
			this.tabPagePDFImport.Location = new System.Drawing.Point(4, 22);
			this.tabPagePDFImport.Name = "tabPagePDFImport";
			this.tabPagePDFImport.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePDFImport.Size = new System.Drawing.Size(447, 355);
			this.tabPagePDFImport.TabIndex = 1;
			this.tabPagePDFImport.Text = "Import";
			this.tabPagePDFImport.UseVisualStyleBackColor = true;
			// 
			// groupBoxPDFImport
			// 
			this.groupBoxPDFImport.Controls.Add(this.cboPDFImport);
			this.groupBoxPDFImport.Location = new System.Drawing.Point(6, 6);
			this.groupBoxPDFImport.Name = "groupBoxPDFImport";
			this.groupBoxPDFImport.Size = new System.Drawing.Size(435, 343);
			this.groupBoxPDFImport.TabIndex = 7;
			this.groupBoxPDFImport.TabStop = false;
			this.groupBoxPDFImport.Text = "PDF Import Options";
			// 
			// cboPDFImport
			// 
			this.cboPDFImport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPDFImport.FormattingEnabled = true;
			this.cboPDFImport.Location = new System.Drawing.Point(6, 19);
			this.cboPDFImport.MaxDropDownItems = 3;
			this.cboPDFImport.Name = "cboPDFImport";
			this.cboPDFImport.Size = new System.Drawing.Size(180, 21);
			this.cboPDFImport.TabIndex = 0;
			// 
			// tabPagePDFExport
			// 
			this.tabPagePDFExport.Controls.Add(this.groupBoxPDFExport);
			this.tabPagePDFExport.Location = new System.Drawing.Point(4, 22);
			this.tabPagePDFExport.Name = "tabPagePDFExport";
			this.tabPagePDFExport.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePDFExport.Size = new System.Drawing.Size(447, 355);
			this.tabPagePDFExport.TabIndex = 2;
			this.tabPagePDFExport.Text = "Export";
			this.tabPagePDFExport.UseVisualStyleBackColor = true;
			// 
			// groupBoxPDFExport
			// 
			this.groupBoxPDFExport.Controls.Add(this.chkPDFEmbeddableFontsOnly);
			this.groupBoxPDFExport.Location = new System.Drawing.Point(6, 6);
			this.groupBoxPDFExport.Name = "groupBoxPDFExport";
			this.groupBoxPDFExport.Size = new System.Drawing.Size(435, 343);
			this.groupBoxPDFExport.TabIndex = 8;
			this.groupBoxPDFExport.TabStop = false;
			this.groupBoxPDFExport.Text = "PDF Export Options";
			// 
			// chkPDFEmbeddableFontsOnly
			// 
			this.chkPDFEmbeddableFontsOnly.AutoSize = true;
			this.chkPDFEmbeddableFontsOnly.Location = new System.Drawing.Point(6, 19);
			this.chkPDFEmbeddableFontsOnly.Name = "chkPDFEmbeddableFontsOnly";
			this.chkPDFEmbeddableFontsOnly.Size = new System.Drawing.Size(95, 17);
			this.chkPDFEmbeddableFontsOnly.TabIndex = 0;
			this.chkPDFEmbeddableFontsOnly.Text = "&Enable PDF/A";
			this.chkPDFEmbeddableFontsOnly.UseVisualStyleBackColor = true;
			this.chkPDFEmbeddableFontsOnly.CheckedChanged += new System.EventHandler(this.chkPDFEmbeddableFontsOnly_CheckedChanged);
			// 
			// PDFOptionsDialog
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(479, 431);
			this.Controls.Add(this.tabPDFSettings);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PDFOptionsDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PDF Settings";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmPDFOptions_Load);
			this.tabPDFSettings.ResumeLayout(false);
			this.tabPagePDFSecurity.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBoxUserPassword.ResumeLayout(false);
			this.groupBoxUserPassword.PerformLayout();
			this.groupBoxPDFSecurity.ResumeLayout(false);
			this.groupBoxPDFSecurity.PerformLayout();
			this.tabPagePDFImport.ResumeLayout(false);
			this.groupBoxPDFImport.ResumeLayout(false);
			this.tabPagePDFExport.ResumeLayout(false);
			this.groupBoxPDFExport.ResumeLayout(false);
			this.groupBoxPDFExport.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		public FileHandler FileHandler { set; get; }

		public TXTextControl.TextControl TextControl { get; private set; }

		private void cmdOK_Click(object sender, System.EventArgs e) {
			if (chkMasterPassword.Checked && txtMasterPassword.Text.Length == 0) {
				MessageBox.Show("The 'Use a password to restrict printing and editing of the " +
					"document and its security settings' option is selected, but the Permissions " +
					"Password field is empty. Please enter a password or deselect the security option.",
					ProductName);
			}
			else if (chkUserPassword.Checked && txtUserPassword.Text.Length == 0) {
				MessageBox.Show("The 'Require a password to open the document' option is selected, " +
					"but the Document Open Password field is empty. Please enter a password or deselect " +
					"the security option.", ProductName);
			}
			else if (chkMasterPassword.Checked && chkUserPassword.Checked &&
					 txtMasterPassword.Text == txtUserPassword.Text) {
				MessageBox.Show("The Document Open and Permissions passwords cannot be the same. " +
					"Please enter a different password in either the Document Open Password field or " +
					"the Permission Password field.", ProductName);
			}
			else {
				FileHandler.PDFUserPassword = txtUserPassword.Text;
				FileHandler.PDFMasterPassword = txtMasterPassword.Text;

				int nFlags = 0;

				// Printing combo box
				if (cboPrinting.SelectedIndex == 2)
					nFlags += (int) TXTextControl.DocumentAccessPermissions.AllowHighLevelPrinting;
				else if (cboPrinting.SelectedIndex == 1)
					nFlags += (int) TXTextControl.DocumentAccessPermissions.AllowLowLevelPrinting;

				// Changes Allowed combo box
				if (cboChangesAllowed.SelectedIndex == 4)
					nFlags += (int) TXTextControl.DocumentAccessPermissions.AllowAuthoring
						+ (int) TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly
						+ (int) TXTextControl.DocumentAccessPermissions.AllowGeneralEditing;
				else if (cboChangesAllowed.SelectedIndex == 3)
					nFlags += (int) TXTextControl.DocumentAccessPermissions.AllowAuthoring;
				else if (cboChangesAllowed.SelectedIndex == 2)
					nFlags += (int) TXTextControl.DocumentAccessPermissions.AllowAuthoringFields;
				else if (cboChangesAllowed.SelectedIndex == 1)
					nFlags += (int) TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly;

				// Remaining 2 checkboxes
				if (chkAllowContentAccessibility.Checked)
					nFlags += (int) TXTextControl.DocumentAccessPermissions.AllowContentAccessibility;
				if (chkAllowExtractContents.Checked)
					nFlags += (int) TXTextControl.DocumentAccessPermissions.AllowExtractContents;

				FileHandler.PDFDocumentAccessPermissions = (TXTextControl.DocumentAccessPermissions) nFlags;

				// Set PDFImportSettings
				switch (cboPDFImport.SelectedIndex) {
					case 0:
						FileHandler.PDFImportSettings = TXTextControl.PDFImportSettings.GenerateLines;
						break;
					case 1:
						FileHandler.PDFImportSettings = TXTextControl.PDFImportSettings.GenerateParagraphs;
						break;
					case 2:
						FileHandler.PDFImportSettings = TXTextControl.PDFImportSettings.GenerateTextFrames;
						break;
				}

				// PDF/A setting
				TextControl.FontSettings.EmbeddableFontsOnly = chkPDFEmbeddableFontsOnly.Checked;

				// Close the dialog finally
				Close();
			}
		}

		private void frmPDFOptions_Load(object sender, System.EventArgs e) {
			txtUserPassword.Text = FileHandler.PDFUserPassword;
			chkUserPassword.Checked = (FileHandler.PDFUserPassword.Length > 0);
			txtUserPassword.Enabled = chkUserPassword.Checked;

			txtMasterPassword.Text = FileHandler.PDFMasterPassword;
			chkMasterPassword.Checked = (FileHandler.PDFMasterPassword.Length > 0);
			txtMasterPassword.Enabled = chkMasterPassword.Checked;

			tbCertFile.Text = FileHandler.PDFCertFilePath;
			tbCertPwd.Text = FileHandler.PDFCertPasswd;

			// PDF import combo box
			cboPDFImport.Items.Clear();
			cboPDFImport.Items.Add("Plain text mode");
			cboPDFImport.Items.Add("Paragraph recognition mode");
			cboPDFImport.Items.Add("Text frame import mode");

			switch (FileHandler.PDFImportSettings) {
				case TXTextControl.PDFImportSettings.GenerateLines:
					cboPDFImport.SelectedIndex = 0;
					break;
				case TXTextControl.PDFImportSettings.GenerateParagraphs:
					cboPDFImport.SelectedIndex = 1;
					break;
				case TXTextControl.PDFImportSettings.GenerateTextFrames:
					cboPDFImport.SelectedIndex = 2;
					break;
			}

			// PDF export: EmbeddableFontsOnly = false by default
			chkPDFEmbeddableFontsOnly.Checked = TextControl.FontSettings.EmbeddableFontsOnly;

			// Printing combo box
			cboPrinting.Items.Clear();
			cboPrinting.Items.Add("None");
			cboPrinting.Items.Add("Low Resolution");
			cboPrinting.Items.Add("High Resolution");

			uint Flags = (uint) FileHandler.PDFDocumentAccessPermissions;

			if ((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowHighLevelPrinting) != 0)
				cboPrinting.SelectedIndex = 2;
			else if ((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowLowLevelPrinting) != 0)
				cboPrinting.SelectedIndex = 1;
			else
				cboPrinting.SelectedIndex = 0;
			cboPrinting.Enabled = chkMasterPassword.Checked;

			// Changes Allowed combo box
			cboChangesAllowed.Items.Clear();
			cboChangesAllowed.Items.Add("None");
			cboChangesAllowed.Items.Add("Inserting, deleting and rotating pages");
			cboChangesAllowed.Items.Add("Filling in form fields and signing");
			cboChangesAllowed.Items.Add("Commenting, filling in form fields and signing");
			cboChangesAllowed.Items.Add("Any except extracting pages");

			if (((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowAuthoring) != 0) &&
				((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly) != 0) &&
				((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowGeneralEditing) != 0))
				cboChangesAllowed.SelectedIndex = 4;
			else if ((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowAuthoring) != 0)
				cboChangesAllowed.SelectedIndex = 3;
			else if ((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowAuthoringFields) != 0)
				cboChangesAllowed.SelectedIndex = 2;
			else if ((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowDocumentAssembly) != 0)
				cboChangesAllowed.SelectedIndex = 1;
			else
				cboChangesAllowed.SelectedIndex = 0;
			cboChangesAllowed.Enabled = chkMasterPassword.Checked;

			// Remaining 2 checkboxes
			chkAllowContentAccessibility.Checked = ((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowContentAccessibility) != 0);
			chkAllowExtractContents.Checked = ((Flags & (uint) TXTextControl.DocumentAccessPermissions.AllowExtractContents) != 0);

			chkAllowContentAccessibility.Enabled = chkMasterPassword.Checked;
			chkAllowExtractContents.Enabled = chkMasterPassword.Checked;
		}

		private void btnBrowseCertFile_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.CheckPathExists = true;
			ofd.Filter = "Personal Information Exchange File (*.pfx)|*.pfx";
			ofd.ValidateNames = true;

			if (ofd.ShowDialog(this) != DialogResult.OK) return;

			tbCertFile.Text = ofd.FileName;
		}

		private void tbCertFile_TextChanged(object sender, EventArgs e) {
			FileHandler.PDFCertFilePath = tbCertFile.Text;
		}

		private void tbCertPwd_TextChanged(object sender, EventArgs e) {
			FileHandler.PDFCertPasswd = tbCertPwd.Text;
		}

		private void chkUserPassword_Click(object sender, System.EventArgs e) {
			if (!chkUserPassword.Checked)
				txtUserPassword.Text = "";
			txtUserPassword.Enabled = chkUserPassword.Checked;
			chkPDFEmbeddableFontsOnly.Enabled = !chkUserPassword.Checked;
		}

		private void chkMasterPassword_Click(object sender, System.EventArgs e) {
			if (!chkMasterPassword.Checked)
				txtMasterPassword.Text = "";
			txtMasterPassword.Enabled = chkMasterPassword.Checked;
			cboPrinting.Enabled = chkMasterPassword.Checked;
			cboChangesAllowed.Enabled = chkMasterPassword.Checked;
			chkAllowContentAccessibility.Enabled = chkMasterPassword.Checked;
			chkAllowExtractContents.Enabled = chkMasterPassword.Checked;
			chkPDFEmbeddableFontsOnly.Enabled = !chkMasterPassword.Checked;
		}

		private void chkPDFEmbeddableFontsOnly_CheckedChanged(object sender, EventArgs e) {
			groupBoxUserPassword.Enabled = !chkPDFEmbeddableFontsOnly.Checked;
			groupBoxPDFSecurity.Enabled = !chkPDFEmbeddableFontsOnly.Checked;
		}
	}
}
