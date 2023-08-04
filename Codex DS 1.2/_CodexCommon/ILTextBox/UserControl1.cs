using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ILG.Codex.KeyBoard;

namespace ILG
{
	namespace Codex
	{
		namespace Controls
		{
				/// <summary>
				/// Summary description for UserControl1.
				/// </summary>
			public class ILTextControl : System.Windows.Forms.TextBox
			{
				/// <summary>
				/// Required designer variable.
				public ILG.Codex.KeyBoard.KeyLayout LanguageSet;
										
				/// </summary>
				//private System.ComponentModel.Container components = null;
					

				public ILTextControl()
				{
					// This call is required by the Windows.Forms Form Designer.
					
				//	InitializeComponent();
					// TODO: Add any initialization after the InitComponent call
					LanguageSet = ILG.Codex.KeyBoard.KeyLayout.English;

				}
			
				// #define WM_CHAR                         0x0102
				public override bool PreProcessMessage(ref Message msg)
                {  
					int WM_CHAR = 0x0102;
					if (msg.Msg == WM_CHAR) msg.WParam = (IntPtr)Convert.ToInt16(ILG.Codex.KeyBoard.Layout.C[msg.WParam.ToInt32()]);
					return base.PreProcessMessage(ref msg);
				}

					

					/// <summary>
					/// Clean up any resources being used.
					/// </summary>
					protected override void Dispose( bool disposing )
					{
						
						base.Dispose( disposing );
						
					}

				
			
			}

			public class ILTextControlUni : System.Windows.Forms.TextBox
			{
				/// <summary>
				/// Required designer variable.
				public ILG.Codex.KeyBoard.KeyLayout LanguageSet;
										
				/// </summary>
				//private System.ComponentModel.Container components = null;
					

				public ILTextControlUni()
				{
					// This call is required by the Windows.Forms Form Designer.
					
					//	InitializeComponent();
					// TODO: Add any initialization after the InitComponent call
					LanguageSet = ILG.Codex.KeyBoard.KeyLayout.English;

				}
			
				// #define WM_CHAR                         0x0102
				public override bool PreProcessMessage(ref Message msg)
				{  
					int WM_CHAR = 0x0102; 
					if ((msg.Msg == WM_CHAR) && (msg.WParam.ToInt32() < 255)) msg.WParam = (IntPtr)Convert.ToInt16(ILG.Codex.KeyBoard.Layout.U[msg.WParam.ToInt32()]);
					return base.PreProcessMessage(ref msg);
				}

					

				/// <summary>
				/// Clean up any resources being used.
				/// </summary>
				protected override void Dispose( bool disposing )
				{
						
					base.Dispose( disposing );
						
				}

				
			
			}
		}
	}
}