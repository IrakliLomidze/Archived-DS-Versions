/*-------------------------------------------------------------------------------------------------------------
** module:     TX Text Control Words
**
** copyright:  © Text Control GmbH
** author:     T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4.DocumentForm
{

	public partial class BaseTxDocument : Form {

		private void DeleteFieldToolStripMenuItem_Click(object sender, EventArgs e) {
			DeleteField();
		}

		private void FieldPropertiesToolStripMenuItem_Click(object sender, EventArgs e) {
			FieldSettings();
		}

		private void ContextMenuApplicationFields_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
		}
	}
}
