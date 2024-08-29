/*-------------------------------------------------------------------------------------------------------------
** module:        TX Text Control Words
** description:   This file contains a class handling file drag & drop operations.
**
** copyright:     © Text Control GmbH
** author:        T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows;

namespace ILG.Codex.CodexR4.DocumentForm
{

	public enum ImageType {
		UNKNOWN,

		bmp, jpg, gif, tif, png, emf, wmf,
	}

	/// <summary>
	/// Handles file drag &amp; drop operations.
	/// </summary>
	class FileDragDropHandler {

		#region "  Enumerations  "

		public enum DraggedFileType {
			UNKNOWN,
			Document,
			Image,
		}

		#endregion // Enumerations

		# region "  Class Properties  "

		/// <summary>
		/// Dragged / dropped file type. (Image, document etc.)
		/// </summary>
		public DraggedFileType FileType { get; private set; }

		/// <summary>
		/// Dragged image type.
		/// </summary>
		public ImageType ImageType { get; private set; }

		// Gets the name of the file handled through this drag&drop handler:
		public string FileName { get; private set; }

		// Gets the TXTextControl Streamtype of the file handled through this drag&drop handler:
		public TXTextControl.StreamType StreamType { get; private set; }

		// Gets a value indicating whether something can be dropped:
		public bool CanDrop { get; private set; }

		#endregion // Class Properties

		#region "  Methods  "

		// Resets the internal state of the drag & drop handler:
		public void Reset() {
			FileName = string.Empty;
			StreamType = 0;
			CanDrop = false;
			FileType = DraggedFileType.UNKNOWN;
			ImageType = ImageType.UNKNOWN;
		}

		public void CheckDraggedFiles(string[] fileList) {
			Reset();

			if (fileList != null) {
				// Get first parameter from the list and check if it is a supported file type
				FileName = fileList[0];

				switch (Path.GetExtension(FileName).ToLower()) {
					case ".rtf":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.RichTextFormat;
						break;

					case ".htm":
					case ".html":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.HTMLFormat;
						break;

					case ".doc":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.MSWord;
						break;

					case ".docx":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.WordprocessingML;
						break;

					case ".pdf":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.AdobePDF;
						break;

					case ".xml":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.XMLFormat;
						break;

					case ".txt":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.PlainText;
						break;

					case ".tx":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.InternalUnicodeFormat;
						break;

					case ".jpeg":
					case ".jpg":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.jpg;
						break;

					case ".tif":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.tif;
						break;

					case ".bmp":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.bmp;
						break;

					case ".gif":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.gif;
						break;

					case ".png":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.png;
						break;

					case ".wmf":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.wmf;
						break;

					case ".emf":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.emf;
						break;
					default:
						FileType = DraggedFileType.UNKNOWN;
						ImageType = ImageType.UNKNOWN;
						FileName = String.Empty;
						break;
				}

				if (FileType != DraggedFileType.UNKNOWN) CanDrop = true;
			}
		}

		// Calculates a drag&drop effect depending on the allowed effects:
		public System.Windows.Forms.DragDropEffects GetDragDropEffect(System.Windows.Forms.DragDropEffects allowedEffects) {
			if ((allowedEffects & System.Windows.Forms.DragDropEffects.Copy) == System.Windows.Forms.DragDropEffects.Copy) {
				return System.Windows.Forms.DragDropEffects.Copy;
			}
			else if ((allowedEffects & System.Windows.Forms.DragDropEffects.Move) == System.Windows.Forms.DragDropEffects.Move) {
				return System.Windows.Forms.DragDropEffects.Move;
			}
			else { return System.Windows.Forms.DragDropEffects.None; }
		}

		#endregion // Methods

	}
}

