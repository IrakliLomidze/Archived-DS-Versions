/*-------------------------------------------------------------------------------------------------------------
** module:        TX Text Control Words
** description:   This file contains a class handling file operations.
**
** copyright:     © Text Control GmbH
** author:        T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Specialized;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TXTextControl;

namespace ILG.Codex.CodexR4.DocumentForm
{

	/// <summary>
	/// Handles file operations.
	/// </summary>
	public partial class FileHandler {

		# region " Constructor "

		public FileHandler(BaseTxDocument mainWindow, TXTextControl.TextControl textControl) {
			MainWindow = mainWindow;
            _fileList = new StringCollection();// Properties.Settings.Default.MRUFiles;
            _nMaxFiles = 1;// Properties.Settings.Default.MRUMaxFiles;
			TextControl = textControl;

			DocumentFileName = "";
			PDFCertFilePath = "";
			PDFCertPasswd = "";
			PDFUserPassword = "";
			PDFMasterPassword = "";
			CSSFileName = "";

			PDFDocumentAccessPermissions = TXTextControl.DocumentAccessPermissions.AllowAll;
			PDFImportSettings = TXTextControl.PDFImportSettings.GenerateTextFrames;
		}
		# endregion

		# region "  Fields  "

		//const TXTextControl.StreamType DefaultExportTypes = TXTextControl.StreamType.AdobePDF | TXTextControl.StreamType.AdobePDFA | TXTextControl.StreamType.CascadingStylesheet;
		const TXTextControl.StreamType DefaultSaveTypes = TXTextControl.StreamType.All | TXTextControl.StreamType.InternalUnicodeFormat & ~TXTextControl.StreamType.XMLFormat;
		const TXTextControl.StreamType DefaultInsertTypes = TXTextControl.StreamType.All ;
		const TXTextControl.StreamType DefaultLoadTypes = TXTextControl.StreamType.All & ~TXTextControl.StreamType.CascadingStylesheet;

		private TXTextControl.StreamType _documentStreamType;

		private StringCollection _fileList;
		private int _nMaxFiles;

		private bool _bDocumentDirty;
		private bool _bCanUndo;

		# endregion

		# region "  Properties  "

		public BaseTxDocument MainWindow { get; set; }

		public TXTextControl.TextControl TextControl { get; private set; }


		/// <summary>
		/// Gets or sets if the FileHandler instance should react to changes in the text control.
		/// Is used when loading the style document template, for example.
		/// </summary>
		public bool SuspendChangeEvents { get; set; }

		public string DocumentFileName { get; set; }

		public string DocumentTitle {
			get {
				if (DocumentFileName != "") {
					return DocumentFileName;
				}
				else { return "[untitled]"; }
			}
		}


		public bool DocumentDirty {
			get { return _bDocumentDirty; }
			set { SetDocumentDirty(value); }
		}

		public string CSSFileName { get; set; }

		public TXTextControl.CssSaveMode CSSSaveMode { get; set; }

		public string PDFMasterPassword { get; set; }

		public string PDFUserPassword { get; set; }

		public string PDFCertFilePath { get; set; }

		public string PDFCertPasswd { get; set; }

		public TXTextControl.DocumentAccessPermissions PDFDocumentAccessPermissions { get; set; }

		public TXTextControl.PDFImportSettings PDFImportSettings { get; set; }

		public string PrintDocumentName { get { return MainWindow.ProductName + " – " + DocumentTitle; } }

		public bool CanUndo {
			set { _bCanUndo = value; }
		}


		# endregion

		# region "  File methods and functions  "

		/// <summary>
		/// Handles the dirty flag for the current document and adds / removes the star (*)
		/// </summary>
		/// <param name="isDirty">Document is dirty</param>
		private void SetDocumentDirty(bool isDirty) {
			if (SuspendChangeEvents) return;
			if (MainWindow.IsDisposed) return;

			if (!TextControl.CanUndo) {
				_bDocumentDirty = false;
				MainWindow.Invoke(new InvokeDelegate(RemoveAsteriskFromWindowTitle));
			}
			else {
				if (isDirty) {
					_bDocumentDirty = true;
					MainWindow.Invoke(new InvokeDelegate(AddAsteriskToWindowTitle));
				}
				else _bDocumentDirty = false;
			}

			MainWindow.Invoke(new InvokeDelegate(UpdateMainFormSaveStatus));
		}

		public bool FileOpen() {
			bool bSucceeded = false;

			var ls = new TXTextControl.LoadSettings {
				ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord,
				LoadSubTextParts = true,
				PDFImportSettings = PDFImportSettings
			};


			try {
				//if there is no file name, open a dialog to load a document
				if (DocumentFileName == "") TextControl.Load(DefaultLoadTypes, ls);
				else {
					switch (Path.GetExtension(DocumentFileName).ToLower()) {
						case ".rtf":
							TextControl.Load(DocumentFileName, TXTextControl.StreamType.RichTextFormat, ls);
							break;

						case ".doc":
							TextControl.Load(DocumentFileName, TXTextControl.StreamType.MSWord, ls);
							break;

						case ".docx":
							TextControl.Load(DocumentFileName, TXTextControl.StreamType.WordprocessingML, ls);
							break;

						case ".txt":
							TextControl.Load(DocumentFileName, TXTextControl.StreamType.PlainText, ls);
							break;

						case ".htm":
						case ".html":
							TextControl.Load(DocumentFileName, TXTextControl.StreamType.HTMLFormat, ls);
							break;

						case ".pdf":
							TextControl.Load(DocumentFileName, TXTextControl.StreamType.AdobePDF, ls);
							break;

						case ".xml":
							TextControl.Load(DocumentFileName, TXTextControl.StreamType.XMLFormat, ls);
							break;

						case ".tx":
							TextControl.Load(DocumentFileName, TXTextControl.StreamType.InternalUnicodeFormat, ls);
							break;
					}
				}

				if (ls.LoadedFile != "") {
					DocumentFileName = ls.LoadedFile;
					_documentStreamType = ls.LoadedStreamType;
					_bDocumentDirty = false;
					CSSFileName = ls.CssFileName;
					CSSSaveMode = TXTextControl.CssSaveMode.None;
					AddRecentFile(DocumentFileName);
					bSucceeded = true;
					MainWindow.Text = PrintDocumentName;
					MainWindow.SetDefaultFieldAndBlockProperties();
				}
			}
			catch (Exception exc) {
				MessageBox.Show(exc.Message, "Error loading document.",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				bSucceeded = false;
			}
			return bSucceeded;
		}

		public void FileSave() {
			var saveSettings = new TXTextControl.SaveSettings();
			saveSettings.CssFileName = CSSFileName;
			saveSettings.CssSaveMode = CSSSaveMode;

			if (!string.IsNullOrEmpty(DocumentFileName)) {
				// save with same name and type
				TextControl.Save(DocumentFileName, _documentStreamType, saveSettings);
			}
			else {
				// save as..
				TextControl.Save(DefaultSaveTypes, saveSettings);
			}

			if (saveSettings.SavedFile != "") {
				DocumentFileName = saveSettings.SavedFile;
				_documentStreamType = saveSettings.SavedStreamType;
				_bDocumentDirty = false;
				MainWindow.Text = PrintDocumentName;
				AddRecentFile(DocumentFileName);
			}
		}

		public void FileSaveAs(TXTextControl.StreamType streamType) {
			var ls = new TXTextControl.LoadSettings { 
				ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord,
				LoadSubTextParts = true
			};

			var sdfd = new SaveDocumentFileDialog { SelectedFileType = streamType };
            
			if (!sdfd.ShowDialog(MainWindow)) return;

			// Export pdf:
			if ((sdfd.SelectedFileType & (TXTextControl.StreamType.AdobePDF | TXTextControl.StreamType.AdobePDFA)) != 0) {
				Export(sdfd.SelectedFileType, sdfd.FileName);
				return;
			}

			var saveSettings = new TXTextControl.SaveSettings();

            TXTextControl.SaveSettings SaveSettings = new TXTextControl.SaveSettings();
            SaveSettings.ImageSaveMode = TXTextControl.ImageSaveMode.SaveAsData;


            TextControl.Save(sdfd.FileName, sdfd.SelectedFileType, saveSettings);

			if (saveSettings.SavedFile != "") {
				DocumentFileName = saveSettings.SavedFile;

				if (_documentStreamType != saveSettings.SavedStreamType) {
					if (saveSettings.SavedStreamType == TXTextControl.StreamType.HTMLFormat || saveSettings.SavedStreamType == TXTextControl.StreamType.PlainText || saveSettings.SavedStreamType == TXTextControl.StreamType.PlainAnsiText) {
						if (MessageBox.Show("დაიკარგება რაღაცეები HTML ში ჩაწერისისას", "Warning",
							MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
							// reload file if saved in a different format
							TextControl.ResetContents();
							TextControl.Load(saveSettings.SavedFile, saveSettings.SavedStreamType, ls);
						}
					}

					_documentStreamType = saveSettings.SavedStreamType;
				}

				_bDocumentDirty = false;
				MainWindow.Text = PrintDocumentName;
				AddRecentFile(DocumentFileName);
			}
		}

		private void Export(TXTextControl.StreamType streamType, string fileName) {
			var saveSettings = new TXTextControl.SaveSettings {
				UserPassword = PDFUserPassword,
				MasterPassword = PDFMasterPassword,
				DocumentAccessPermissions = PDFDocumentAccessPermissions,
			};

			PDFCertFilePath = PDFCertFilePath.Trim();

			// Load digital signature file if selected
			if (PDFCertFilePath != String.Empty) {
				try {
					var cert = new X509Certificate2(PDFCertFilePath, PDFCertPasswd);
					saveSettings.DigitalSignature = new TXTextControl.DigitalSignature(cert, null);
				}
				catch {
					MessageBox.Show("Please check digital signature settings in the PDF options dialog.", MainWindow.ProductName,
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			try {
				if (fileName.Length > 0) {
					switch (streamType) {
						case TXTextControl.StreamType.AdobePDF:
							TextControl.Save(fileName, TXTextControl.StreamType.AdobePDF, saveSettings);
							break;

						//case TXTextControl.StreamType.AdobePDFA:
						//	if (!TextControl.FontSettings.EmbeddableFontsOnly) {
						//		MessageBox.Show(
						//			Properties.Resources.strMsgFileHandler02, "Exporting to PDF/A not possible",
						//			MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						//		return;
						//	}
						//	TextControl.Save(fileName, TXTextControl.StreamType.AdobePDFA, saveSettings);
						//	break;
					}
				}
			}
			catch (Exception exc) {
				MessageBox.Show(exc.Message, MainWindow.ProductName,
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		public void Insert() {
			var ls = new TXTextControl.LoadSettings { 
				ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord,
				LoadSubTextParts = true
			};
			TextControl.Selection.Load(DefaultInsertTypes, ls);
			if (ls.LoadedFile != "") {
				_bDocumentDirty = true;
				MainWindow.SetDefaultFieldAndBlockProperties();
			}
		}

		#endregion

		#region "  Recent file handling  "

		/// <summary>
		/// Adds a new file path to the top of the list
		/// </summary>
		void AddRecentFile(string filePath) {
			_fileList.Insert(0, filePath);

			for (int i = _fileList.Count - 1; i > 0; i--) {
				for (int j = 0; j < i; j++) {
					if (_fileList[i] == _fileList[j]) {
						_fileList.RemoveAt(i);
						break;
					}
				}
			}
			TrimFileList();
			UpdateMenu();
		}

		void TrimFileList() {
			for (int bynd = _fileList.Count - 1; bynd > _nMaxFiles - 1; bynd--) {
				_fileList.RemoveAt(bynd);
			}
		}

		public void InitRecentFiles() {
   //         _fileList = new StringCollection();// Properties.Settings.Default.MRUFiles;
   //         _nMaxFiles = 1; // Properties.Settings.Default.MRUMaxFiles;
			//UpdateMenu();
		}

		void CheckFiles() {
			for (int i = 0; i < _fileList.Count; i++) {
				if (!File.Exists(_fileList[i])) {
					_fileList.Remove(_fileList[i]);
				}
			}
		}

		#endregion // Recent file handling

		#region "  Helpers  "


		public delegate void InvokeDelegate();

		private void RemoveAsteriskFromWindowTitle() {
			if (MainWindow.Text.EndsWith("*")) {
				MainWindow.Text = MainWindow.Text.Remove(MainWindow.Text.Length - 1, 1);
			}
		}

		private void AddAsteriskToWindowTitle() {
			if (!MainWindow.Text.EndsWith("*")) {
				MainWindow.Text = MainWindow.Text + "*";
			}
		}

		private void UpdateMainFormSaveStatus() {
			MainWindow.UpdateSaveStatus();
		}



		#endregion // Helpers
	}
}
