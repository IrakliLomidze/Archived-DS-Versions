/*-------------------------------------------------------------------------------------------------------------
** module:        TX Text Control Words
** description:   This file contains a replacement for Text Control's default file saving dialog.
**
** copyright:     © Text Control GmbH
** author:        T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System.Windows.Forms;

namespace ILG.Codex.CodexR4.DocumentForm
{

	/// <summary>
	/// A replacement for Text Control's default file saving dialog. Adds the possibility 
	/// to get and set the selected file extension using TXTextControl.StreamType.
	/// </summary>
	class SaveDocumentFileDialog {

		private SaveFileDialog _sfd = new SaveFileDialog { Filter = FilterString };

		private const string FilterString
			= "Rich Text Format (*.rtf)|*.rtf|"
			+ "Hypertext Markup Language (*.htm, *.html)|*.htm;*.html"
			+ "|Microsoft Word (*.docx)|*.docx|"
			+ "Microsoft Word 97-2003 (*.doc)|*.doc|"
			+ "Adobe PDF (*.pdf)|*.pdf|"
			+ "Adobe PDF/A (*.pdf)|*.pdf|"
			+ "Plain Unicode Text (*.txt)|*.txt|"
			+ "Internal TX Text Control Unicode Format (*.tx)|*.tx"
			;

		public bool CheckFileExists {
			get { return _sfd.CheckFileExists; }
			set { _sfd.CheckFileExists = value; }
		}

		public TXTextControl.StreamType SelectedFileType {
			get { return FilterIndexToStreamType(_sfd.FilterIndex); }
			set { _sfd.FilterIndex = StreamTypeToFilterIndex(value); }
		}

		public string FileName {
			get { return _sfd.FileName; }
			set { _sfd.FileName = value; }
		}

		public bool ShowDialog(IWin32Window owner) {
			return _sfd.ShowDialog(owner) == DialogResult.OK;
		}

		private TXTextControl.StreamType FilterIndexToStreamType(int nIndex) {
			switch (nIndex) {
				case 1:
					return TXTextControl.StreamType.RichTextFormat;

				case 2:
					return TXTextControl.StreamType.HTMLFormat;
				case 3:
					return TXTextControl.StreamType.WordprocessingML;

				case 4:
					return TXTextControl.StreamType.MSWord;

				case 5:
					return TXTextControl.StreamType.AdobePDF;

				case 6:
					return TXTextControl.StreamType.AdobePDFA;

				case 7:
					return TXTextControl.StreamType.PlainText;

				case 8:
					return TXTextControl.StreamType.InternalUnicodeFormat;
			}

			return TXTextControl.StreamType.RichTextFormat;
		}

		private int StreamTypeToFilterIndex(TXTextControl.StreamType streamType) {
			switch (streamType) {
				case TXTextControl.StreamType.RichTextFormat:
					return 1;

				case TXTextControl.StreamType.HTMLFormat:
					return 2;
				case TXTextControl.StreamType.WordprocessingML:
					return 3;

				case TXTextControl.StreamType.MSWord:
					return 4;

				case TXTextControl.StreamType.AdobePDF:
					return 5;

				case TXTextControl.StreamType.AdobePDFA:
					return 6;

				case TXTextControl.StreamType.PlainText:
					return 7;

				case TXTextControl.StreamType.InternalUnicodeFormat:
					return 8;
			}

			return 1;
		}
	}
}
