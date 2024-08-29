/*-------------------------------------------------------------------------------------------------------------
** module:        TX Text Control Words
** description:   This file contains the parts of the class handling file operations which are only needed
**                in the toolbar demos.
**
** copyright:     © Text Control GmbH
** author:        T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4.DocumentForm
{

	/// <summary>
	/// Handles file operations.
	/// </summary>
	public partial class FileHandler {

		private ToolStripMenuItem _clientMenu;

		public ToolStripMenuItem RecentFilesMenuItem {
			set { _clientMenu = value; }
		}

		public void UpdateMenu() {
			int i;
			if (_clientMenu == null) return;
            // Clear current menu
            for (i = _clientMenu.DropDownItems.Count - 1; i >= 0; i--) {
				_clientMenu.DropDownItems.RemoveAt(i);
			}
			// Check all recent files if they still exist
			CheckFiles();
			// Setup Recent files menu
			for (i = 0; i < _fileList.Count; i++) {
				ToolStripItem mnuItm = new ToolStripMenuItem();
				mnuItm.Text = Path.GetFileName(_fileList[i]);
				mnuItm.Tag = _fileList[i];
				mnuItm.Click += new EventHandler(mnuItm_Click);

				_clientMenu.DropDownItems.Add(mnuItm);
			}
			// Insert Clear menu entry
			if (_clientMenu.DropDownItems.Count >= 1) {
				_clientMenu.Enabled = true;
				_clientMenu.DropDownItems.Add("-");
				ToolStripMenuItem clearListItm = new ToolStripMenuItem("Clear list");
				_clientMenu.DropDownItems.Add(clearListItm);
				clearListItm.Click += new EventHandler(clearListItm_Click);
			}
			else { _clientMenu.Enabled = false; }
		}

		void mnuItm_Click(object sender, EventArgs e) {
			if (_bDocumentDirty) {
				DialogResult res 
					= MessageBox.Show("Save changes to " + DocumentFileName + "?", 
						MainWindow.ProductName, MessageBoxButtons.YesNoCancel);
				if (res == DialogResult.Yes) {
					FileSave();
				}
			}
			ToolStripMenuItem itm = (ToolStripMenuItem) sender;
			int pos = itm.GetCurrentParent().Items.IndexOf(itm);
			if (pos >= 0 && pos < _fileList.Count) {
				DocumentFileName = itm.Tag.ToString();
				FileOpen();
			}
		}

		void clearListItm_Click(object sender, EventArgs e) {
			_fileList.Clear();
			UpdateMenu();
		}
	}
}