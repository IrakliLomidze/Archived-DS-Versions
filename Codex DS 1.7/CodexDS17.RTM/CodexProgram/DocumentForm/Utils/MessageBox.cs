/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System.Windows.Forms;

namespace TX_Text_Control_Words.Utils {

	/*---------------------------------------------------------------------------------------------------------
	** MessageBox class
	**		Provides helper methods for simplifying the invoking of a MessageBox.
	**-------------------------------------------------------------------------------------------------------*/
	internal static class MessageBox {

		/*------------------------------------------------------------------------------------------------------
		** Show method
		**		Shows a message box and applies the reading direction from the owner.
		**----------------------------------------------------------------------------------------------------*/
		internal static DialogResult Show(Control owner, string text, string caption, 
			MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error) {

			if (owner.RightToLeft == RightToLeft.Yes) {
		
				// Show the message in a appropriate right to left layout by setting the reading direction 
				// to 'right to left' and aligning the content to right.
				return System.Windows.Forms.MessageBox.Show(
					owner, text, caption, buttons, icon, 
					MessageBoxDefaultButton.Button1, 
					MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
			}
			else {
				return System.Windows.Forms.MessageBox.Show(owner, text, caption, buttons, icon, 
					MessageBoxDefaultButton.Button1);
			}
		}

	} // class MessageBox
}
