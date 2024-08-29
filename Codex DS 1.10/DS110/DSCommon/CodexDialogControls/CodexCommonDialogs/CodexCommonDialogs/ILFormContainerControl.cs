using System.Windows.Forms;

namespace ILG.Codex.CodexR4.ILFormContainer
{
	public class FormContainer : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		
		private System.ComponentModel.Container components = null;
		private int MinH;
		private int MinW;

		public FormContainer()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// FormContainer
			// 
			this.AutoScroll = true;
			this.AutoScrollMinSize = new System.Drawing.Size(1, 1);
			this.Font = new System.Drawing.Font("Sylfaen", 9F);
			this.Name = "FormContainer";
			this.Resize += new System.EventHandler(this.FormContainer_Resize);
			this.Load += new System.EventHandler(this.FormContainer_Load_1);
			this.SizeChanged += new System.EventHandler(this.FormContainer_SizeChanged);

		}
		#endregion

		private void FormContainer_Load(object sender, System.EventArgs e)
		{
		 
		}
		public void ShowForm(System.Windows.Forms.Form  fw )
		{ 
			 
			 fw.TopLevel = false;
			 this.Controls.Clear();
			 fw.FormBorderStyle = FormBorderStyle.None;
			 this.Controls.Add(fw);
			 fw.Top = 0;
			 fw.Left = 0;
			 this.MinH = fw.MinimumSize.Height;
			 this.MinW = fw.MinimumSize.Width;

			 
			 if ( fw.Width < this.ClientSize.Width ) fw.Width = this.ClientSize.Width;
			 if ( fw.Height < this.ClientSize.Height ) fw.Height = this.ClientSize.Height;

					  
			 
			 //fw.FormBorderStyle = FormBorderStyle.None;
			// if ((this.ClientSize.Width != fw.Width) || (this.ClientSize.Height != fw.Height))
			  this.FormContainer_Resize(null,null);


			 fw.Show();
			
		}

		

		
		private void FormContainer_Resize(object sender, System.EventArgs e)
		{
			if (Controls.Count != 0)
			{
				int CurrentWidth  = this.ClientSize.Width;
				int CurrentHeight = this.ClientSize.Height;

				if (this.ClientSize.Width < this.MinW) 
				{
					CurrentWidth = this.MinW;
				}
				
				if (this.ClientSize.Height < this.MinH) 
				{
					CurrentHeight = this.MinH;
				}
				
				Controls[0].Width  = CurrentWidth-1;
				Controls[0].Height = CurrentHeight-1;
			
			}
			
		}

		private void FormContainer_Load_1(object sender, System.EventArgs e)
		{
		 
		}

		public void resize()
		{
			this.FormContainer_Resize(null,null);
		}

		private void FormContainer_SizeChanged(object sender, System.EventArgs e)
		{
		  this.ResumeLayout();
		}


	}
}
