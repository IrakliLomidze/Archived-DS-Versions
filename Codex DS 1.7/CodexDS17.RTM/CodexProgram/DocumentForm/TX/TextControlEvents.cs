/*-------------------------------------------------------------------------------------------------------------
** module:        TX Text Control Words
**
** copyright:     © Text Control GmbH
** author:        T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Reflection;
using TXTextControl.DataVisualization;
using System.Collections.Generic;
using TXTextControl;
using System.IO;

namespace ILG.Codex.CodexR4.DocumentForm
{

	public partial class BaseTxDocument : Form {

		#region "  Fields  "

		private bool _bHdrFtrActivated = false;

		#endregion // Fields

		#region "  Event Handlers  "

		void TextControl_GotFocus(object sender, EventArgs e) {
			UpdateGUIState();
		}

		private void TextControl_Changed(object sender, EventArgs e) {
			_fileHandler.DocumentDirty = true;
			UpdateGUIState();
		}

		private void TextControl_InputPositionChanged(object sender, EventArgs e) {
			UpdateGUIState();
		}

		private void TextControl_KeyDown(object sender, KeyEventArgs e) {
			HandleKeyDownEvent(e);
		}


		private void TextControl_BarcodeDeleted(object sender, TXTextControl.DataVisualization.BarcodeEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_BarcodeSelected(object sender, TXTextControl.DataVisualization.BarcodeEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_BarcodeDeselected(object sender, TXTextControl.DataVisualization.BarcodeEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_ChartSelected(object sender, TXTextControl.DataVisualization.ChartEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_ChartDeleted(object sender, TXTextControl.DataVisualization.ChartEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_ChartDeselected(object sender, TXTextControl.DataVisualization.ChartEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_ImageSelected(object sender, TXTextControl.ImageEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_ImageDeselected(object sender, TXTextControl.ImageEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_ImageDeleted(object sender, TXTextControl.ImageEventArgs e) {
			UpdateCurrentObject();
		}


		void TextControl_DrawingActivated(object sender, TXTextControl.DataVisualization.DrawingEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_TextFrameSelected(object sender, TXTextControl.TextFrameEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_TextFrameDeselected(object sender, TXTextControl.TextFrameEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_TextFrameDeleted(object sender, TXTextControl.TextFrameEventArgs e) {
			UpdateCurrentObject();
		}

		private void TextControl_TextContextMenuOpening(object sender, TXTextControl.TextContextMenuEventArgs e) {
			if ((e.ContextMenuLocation & TXTextControl.ContextMenuLocation.TextField) != 0) {
				var field = textControl.ApplicationFields.GetItem();
				if (field == null) return;

				_contextMenuApplicationFields.Show(this, PointToClient(Cursor.Position));
				e.Cancel = true;
			}
			else if ((e.ContextMenuLocation & TXTextControl.ContextMenuLocation.SelectedFrame) != 0) {
				var frame = textControl.Frames.GetItem();
				if (frame != null) {
					AddNameContextMenuItems(e.TextContextMenu);
				}
			}
		}

		private void TextControl_DocumentLinkClicked(object sender, TXTextControl.DocumentLinkEventArgs e) {
			if (e.DocumentLink.DocumentTarget == null) return;
			e.DocumentLink.DocumentTarget.ScrollTo();
		}

		

		private void RulerBarVert_DoubleClick(object sender, EventArgs e) {
			textControl.TabDialog();
		}

		private void TextControl_DragDrop(object sender, DragEventArgs e) {
			if (_fileDragDropHandler.CanDrop) {
				switch (_fileDragDropHandler.FileType) {
					case FileDragDropHandler.DraggedFileType.Document:
						OpenDroppedDocument();
						break;

					case FileDragDropHandler.DraggedFileType.Image:
						InsertDroppedImage(e);
						break;
				}
			}
		}

		private void TextControl_DragEnter(object sender, DragEventArgs e) {
			_fileDragDropHandler.Reset();
			_fileDragDropHandler.CheckDraggedFiles((string[]) e.Data.GetData(DataFormats.FileDrop));
		}

		private void TextControl_DragOver(object sender, DragEventArgs e) {
			if (_fileDragDropHandler.CanDrop) {
				e.Effect = _fileDragDropHandler.GetDragDropEffect(e.AllowedEffect);
			}
		}


		private void TextControl_HeaderFooterActivated(object sender, TXTextControl.HeaderFooterEventArgs e) {
			_bHdrFtrActivated = true;
		}

		private void TextControl_HeaderFooterDeactivated(object sender, TXTextControl.HeaderFooterEventArgs e) {
			// Only set variable to false if header / footer was deactivated because another
			// Textcontrol part was selected. If TextParts.GetItem() is still a HeaderFooter, 
			// the event was fired because another window was selected.
			object tp = textControl.TextParts.GetItem();
			if ((tp != null) && !(tp is HeaderFooter)) {
				_bHdrFtrActivated = false;
			}
		}

		#endregion // Event Handlers

		#region "  Helpers  "

		private void HandleKeyDownEvent(KeyEventArgs e) {
			switch (e.KeyCode) {
				case Keys.Insert:
					// Toggle insertion mode
					if (e.Control || e.Alt || e.Shift) break;
					textControl.InsertionMode
						= textControl.InsertionMode == TXTextControl.InsertionMode.Insert
						? TXTextControl.InsertionMode.Overwrite
						: TXTextControl.InsertionMode.Insert;
					break;

				case Keys.A:
					if (!e.Control || e.Alt || e.Shift) break;
					// Ctrl-A: Select all
					textControl.SelectAll();
					break;

				case Keys.S:
					if (!e.Control || e.Alt || e.Shift) break;
					// Ctrl-S: save
					try {
						_fileHandler.FileSave();
					}
					catch (Exception exc) {
						MessageBox.Show(exc.Message, "Error saving document", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					break;

				case Keys.O:
					if (!e.Control || e.Alt || e.Shift) break;

					// Ctrl-O: open
					if (_fileHandler.DocumentDirty && !FileSaveQuestion()) return;


					_fileHandler.DocumentFileName = string.Empty;
					_fileHandler.FileOpen();
					break;

				case Keys.F:
					if (!e.Control || e.Alt || e.Shift) break;

					// Ctrl-F: search
					textControl.Find();
					break;
			}
		}

		private bool FileSaveQuestion() {
			DialogResult res
				= MessageBox.Show("Save changes to " + _fileHandler.DocumentTitle + "?", 
					"Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

			switch (res) {
				case DialogResult.Yes:
					_fileHandler.FileSave();
					if (_fileHandler.DocumentFileName == "") return false;
					break;

				case DialogResult.Cancel:
					return false;
			}

			return true;
		}

		private void OpenDroppedDocument() {
			if (_fileHandler.DocumentDirty) {
				DialogResult result = MessageBox.Show("Save changes to " + _fileHandler.DocumentTitle + "?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (result == DialogResult.Yes) {
					_fileHandler.FileSave();
				}
				else if (result == DialogResult.Cancel) return;
			}


			_fileHandler.DocumentFileName = _fileDragDropHandler.FileName;
			_fileHandler.FileOpen();
		}

		private void InsertDroppedImage(DragEventArgs e) {
			try {
				// Get pixel position of mouse cursor inside Text Control
				Point posCursor = textControl.PointToClient(Cursor.Position);

				// Get bounding rectangle of the first character of the paragraph
				// the image was dropped over
				TXTextControl.Paragraph par = textControl.Paragraphs.GetItem(posCursor);
				TXTextControl.TextChar charParStart = textControl.TextChars[par.Start];
				Rectangle rPar = (charParStart != null) ? charParStart.Bounds : new Rectangle();

				// Get bounding rectangle of the character the image was dropped over
				TXTextControl.TextChar txChar = textControl.TextChars.GetItem(posCursor, true);
				Rectangle rChar = (txChar != null) ? txChar.Bounds : new Rectangle();

				// Calculate image position relative to paragraph position
				var posImg = new Point(rChar.Left - rPar.Left + rChar.Width, rChar.Top - rPar.Top);

				// Insert image anchored to paragraph
				var txImg = new TXTextControl.Image() { FileName = _fileDragDropHandler.FileName };
				textControl.Images.Add(txImg, posImg, par.Start, TXTextControl.ImageInsertionMode.DisplaceText);
			}
			catch (Exception exc) {
				MessageBox.Show(exc.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddNameContextMenuItems(ContextMenuStrip contextMenuStrip) {
			contextMenuStrip.Items.Add(new ToolStripSeparator()); // Separator


			// Name 
			contextMenuStrip.Items.Add(
				Properties.Resources.strObjectName,
				GetEmbeddedBitmap("Small_32bit.objectname"), SetObjectName);
		}


		private void SetObjectName(object sender, EventArgs e) {
			SetObjectName(_objSel);
		}

		private void SetObjectName(TXTextControl.FrameBase obj) {
			if (obj == null) return;

            //string strName = obj.Name;
            //if (InputBoxDialog.ShowInputBox("Object Name", ref strName, this, true))
            //{
            //    obj.Name = strName;
            //}
        }


		#endregion // Helpers
	}
}
