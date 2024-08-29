using System;
using System.Drawing;
using System.Windows.Forms;

namespace ILG.Windows.Forms
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ILGMessageBox
	{
		
		// Parametrs
		string MessageString;
		string Caption;
		MessageBoxButtons d;
		MessageBoxIcon ic;
		MessageBoxDefaultButton df;
		ILG.Windows.Forms.ILGMessageBoxForm ax;

		public ILGMessageBox()
		{
			MessageString = " ";
			d = MessageBoxButtons.OK;
			ic = MessageBoxIcon.Information;
			df = MessageBoxDefaultButton.Button1;
			ax = new ILG.Windows.Forms.ILGMessageBoxForm();
	
		}
		#region Show Metods
		// Show Methods

		public static DialogResult Show(IWin32Window owner,	string text, string caption,		MessageBoxButtons buttons,	MessageBoxIcon icon, MessageBoxDefaultButton defaultButton,	MessageBoxOptions options	)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";	
			t.d = buttons;
			t.ic = icon;
			t.df = defaultButton;
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			t.CreateBox();
			return t.ax.ShowDialog(owner);
		}

		
		public static DialogResult Show(string text,string caption,	MessageBoxButtons buttons,	MessageBoxIcon icon,MessageBoxDefaultButton defaultButton,	MessageBoxOptions options)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";
			t.d = buttons;
			t.ic = icon;
			t.df = defaultButton;
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			t.CreateBox();
			return t.ax.ShowDialog();
		}

		public static DialogResult Show(IWin32Window owner,	string text,string caption,	MessageBoxButtons buttons,	MessageBoxIcon icon,MessageBoxDefaultButton defaultButton)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";
			t.d = buttons;
			t.ic = icon;
			t.df = defaultButton;
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			t.CreateBox();
			return t.ax.ShowDialog(owner);
		}

		public static DialogResult Show(string text,string caption,	MessageBoxButtons buttons,MessageBoxIcon icon,MessageBoxDefaultButton defaultButton)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";
			t.d = buttons;
			t.ic = icon;
			t.df = defaultButton;
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			t.CreateBox();
			return t.ax.ShowDialog();

		}

		public static DialogResult Show(IWin32Window owner,	string text,string caption,	MessageBoxButtons buttons,	MessageBoxIcon icon	)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";
			t.d = buttons;
			t.ic = icon;
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			t.CreateBox();
			return t.ax.ShowDialog(owner);

		}

		
		public static DialogResult Show(string text,string caption, MessageBoxButtons buttons,	MessageBoxIcon icon	)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";
			t.d = buttons;
			t.ic = icon;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			t.CreateBox();
			return t.ax.ShowDialog();
		}

		
		public static DialogResult Show(IWin32Window owner,	string text,string caption,	MessageBoxButtons buttons)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";
			t.d = buttons;
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			t.CreateBox();
			return t.ax.ShowDialog(owner);
		}

		
		public static DialogResult Show(string text,string caption,	MessageBoxButtons buttons)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";
			t.d = buttons;
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			t.CreateBox();
			return t.ax.ShowDialog();
		}

		
		public static DialogResult Show(IWin32Window owner,	string text,string caption)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			t.CreateBox();
			return t.ax.ShowDialog(owner);
		}

		
		
		public static DialogResult Show(string text, string caption)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.Caption = caption;
			if (t.Caption.Trim() == "") t.Caption = " ";
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			t.CreateBox();
			return t.ax.ShowDialog();
		}

		
		public static DialogResult Show(IWin32Window owner, string text)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			t.CreateBox();
			return t.ax.ShowDialog(owner);
		}
		

		

		public static DialogResult Show(string text)
		{
			ILGMessageBox t = new ILGMessageBox();
			t.MessageString = text;
			t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			t.CreateBox();
			return t.ax.ShowDialog();
		}

		
		#endregion Show Metods


        #region Show Metods
        // Show Methods

        public static DialogResult ShowE(IWin32Window owner, string text, string caption, string Error, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.d = buttons;
            t.ic = icon;
            t.df = defaultButton;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog(owner);
        }

        public static DialogResult ShowE(string text, string caption, string Error, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.d = buttons;
            t.ic = icon;
            t.df = defaultButton;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog();
        }

        public static DialogResult ShowE(IWin32Window owner, string text, string caption, string Error, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.d = buttons;
            t.ic = icon;
            t.df = defaultButton;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog(owner);
        }

        public static DialogResult ShowE(string text, string caption, string Error, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.d = buttons;
            t.ic = icon;
            t.df = defaultButton;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog();

        }

        public static DialogResult ShowE(IWin32Window owner, string text, string caption, string Error, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.d = buttons;
            t.ic = icon;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog(owner);

        }


        public static DialogResult ShowE(string text, string caption, string Error, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.d = buttons;
            t.ic = icon;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog();
        }


        public static DialogResult ShowE(IWin32Window owner, string text, string caption, string Error, MessageBoxButtons buttons)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.d = buttons;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog(owner);
        }


        public static DialogResult ShowE(string text, string caption, string Error, MessageBoxButtons buttons)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.d = buttons;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog();
        }


        public static DialogResult ShowE(IWin32Window owner, string text, string caption,string Error)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog(owner);
        }



        public static DialogResult ShowE(string text, string caption,string Error)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.Caption = caption;
            if (t.Caption.Trim() == "") t.Caption = " ";
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog();
        }


        public static DialogResult ShowE(IWin32Window owner, string text,string Error)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog(owner);
        }




        public static DialogResult ShowE(string text,string Error)
        {
            ILGMessageBox t = new ILGMessageBox();
            t.MessageString = text;
            t.ax.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            t.ax.DetailText.Text = Error;
            t.CreateBox();
            return t.ax.ShowDialog();
        }


        #endregion Show Metods



        
		private void CreateBox()
		{ 
			//ax = new ILG.Windows.Forms.ILGMessageBoxForm();
		    Graphics gfx = ax.CreateGraphics();
			ax.Text = this.Caption;
			ax.df = this.df;
			
			

			ax.pic.Left = 16;
			ax.pic.Top = 16;
			 

			ax.label1.Left = ax.pic.Left+ax.pic.Width+16;
			ax.label1.Top  = ax.pic.Top;

			string s = MessageString;

			
			SizeF f =  gfx.MeasureString(s,ax.Font);

			ax.label1.Text = s;
			ax.label1.ClientSize = new Size((int)f.Width+1,(int)f.Height+1);
			//(System.Drawing.Size)f;//Height = (int)f.Height+1;

			if ( ax.label1.Height < ax.pic.Height) ax.label1.Top = ax.pic.Top + (ax.pic.Height-ax.label1.Height) / 2;

			if ( ax.label1.Height > ax.pic.Height) 
				ax.button1.Top = ax.label1.Top+ax.label1.Height+16;
			else
				ax.button1.Top = ax.pic.Top+ax.pic.Height+16;
			
			ax.button2.Top = ax.button1.Top;
			ax.button3.Top = ax.button1.Top;
			
			

			//Button Withs
			SizeF BF = gfx.MeasureString("ინგორირება",ax.Font);
			ax.button1.Width = 6+(int)BF.Width + 6;
			ax.button1.Height = 4+(int)BF.Height + 4;

			ax.button2.Width = ax.button1.Width;
			ax.button3.Width = ax.button1.Width;
			ax.button2.Height = ax.button1.Height;
			ax.button3.Height = ax.button1.Height;

			// Buttons Captions
			

			int h = ax.button1.Top + ax.button1.Height+16;
			int w = ax.label1.Left + ax.label1.Width+ax.pic.Left;
			int hh1 = 0;
			if (ax.button1.Visible == true) hh1+=ax.button1.Width+8;
			if (ax.button2.Visible == true) hh1+=ax.button2.Width+8;
			if (ax.button3.Visible == true) hh1+=ax.button3.Width+8;

			//if ( w < (ax.button1.Width+8)*3+16) w = (ax.button1.Width+8)*3+16;
			if ( w < hh1+ax.button1.Left) w = hh1+ax.button1.Left;
			
            ax.ClientSize = new Size(w,h);
			//ax.Width = w+8;
			
			



			switch(d)
			{
				case MessageBoxButtons.OK : 
					ax.button1.Visible = false; ax.button2.Visible = true; ax.button3.Visible = false;
					ax.button1.Enabled = false; ax.button2.Enabled = true; ax.button3.Enabled = false;	
					  
								      
					ax.button2.Text = "თანხმობა"; ax.button2.DialogResult = DialogResult.OK;
					ax.button2.Left = (ax.ClientSize.Width - ax.button2.Width) / 2;
					break;
				
				case MessageBoxButtons.OKCancel : 
					ax.button1.Visible = true; ax.button2.Visible = true; ax.button3.Visible = false;
					ax.button1.Enabled = true; ax.button2.Enabled = true; ax.button3.Enabled = false;	
				      
					ax.button1.Text = "თანხმობა"; ax.button1.DialogResult = DialogResult.OK;
					ax.button2.Text = "უარი"; ax.button2.DialogResult = DialogResult.Cancel;
					ax.button1.Left = (ax.ClientSize.Width - (ax.button2.Width+8+ax.button1.Width)) / 2;
					ax.button2.Left = ax.button1.Left+ax.button1.Width+8;
					break;

				case MessageBoxButtons.YesNo : 
					ax.button1.Visible = true; ax.button2.Visible = true; ax.button3.Visible = false;
					ax.button1.Enabled = true; ax.button2.Enabled = true; ax.button3.Enabled = false;	
				      
					ax.button1.Text = "დიახ"; ax.button1.DialogResult = DialogResult.Yes;
					ax.button2.Text = "არა"; ax.button2.DialogResult = DialogResult.No;
					ax.button1.Left = (ax.ClientSize.Width - (ax.button2.Width+8+ax.button1.Width)) / 2;
					ax.button2.Left = ax.button1.Left+ax.button1.Width+8;
					break;


				case MessageBoxButtons.RetryCancel : 
					ax.button1.Visible = true; ax.button2.Visible = true; ax.button3.Visible = false;
					ax.button1.Enabled = true; ax.button2.Enabled = true; ax.button3.Enabled = false;	
				      
					ax.button1.Text = "გაიმეორე"; ax.button1.DialogResult = DialogResult.Retry;
					ax.button2.Text = "უარი"; ax.button2.DialogResult = DialogResult.Cancel;
					ax.button1.Left = (ax.ClientSize.Width - (ax.button2.Width+8+ax.button1.Width)) / 2;
					ax.button2.Left = ax.button1.Left+ax.button1.Width+8;
					break;

				case MessageBoxButtons.YesNoCancel : 
					ax.button1.Visible = true; ax.button2.Visible = true; ax.button3.Visible = true;
					ax.button1.Enabled = true; ax.button2.Enabled = true; ax.button3.Enabled = true;	
				      
					ax.button1.Text = "დიახ"; ax.button1.DialogResult = DialogResult.Yes;
					ax.button2.Text = "არა"; ax.button2.DialogResult = DialogResult.No;
					ax.button3.Text = "უარი"; ax.button3.DialogResult = DialogResult.Cancel;
					ax.button1.Left = (ax.ClientSize.Width - (ax.button2.Width+8+ax.button1.Width+8+ax.button3.Width)) / 2;
					ax.button2.Left = ax.button1.Left+ax.button1.Width+8;
					ax.button3.Left = ax.button2.Left+ax.button2.Width+8;
					break;

				case MessageBoxButtons.AbortRetryIgnore : 
					ax.button1.Visible = true; ax.button2.Visible = true; ax.button3.Visible = true;
					ax.button1.Enabled = true; ax.button2.Enabled = true; ax.button3.Enabled = true;	
				      
					ax.button1.Text = "შესახებ"; ax.button1.DialogResult = DialogResult.Abort;
					ax.button2.Text = "გაიმეორე"; ax.button2.DialogResult = DialogResult.Retry;
					ax.button3.Text = "ინგორირება"; ax.button3.DialogResult = DialogResult.Ignore;
					ax.button1.Left = (ax.ClientSize.Width - (ax.button2.Width+8+ax.button1.Width+8+ax.button3.Width)) / 2;
					ax.button2.Left = ax.button1.Left+ax.button1.Width+8;
					ax.button3.Left = ax.button2.Left+ax.button2.Width+8;
					break;

			}

			
			
			switch (ic)
			{
				case MessageBoxIcon.Asterisk : ax.pic.Image = ax.picInformation.Image;break;
				case MessageBoxIcon.Error : ax.pic.Image = ax.picError.Image;break;
				case MessageBoxIcon.Exclamation : ax.pic.Image = ax.picExclamation.Image;break;
				case MessageBoxIcon.Question : ax.pic.Image = ax.pictureQuestion.Image;break;
				case MessageBoxIcon.None : ax.pic.Image = null; break;
			}

		
			
			switch (df) 
			{
				case  MessageBoxDefaultButton.Button1 : ax.button1.Focus();break;
				case  MessageBoxDefaultButton.Button2 : if (ax.button2.Enabled ) ax.button2.Focus(); else ax.button1.Focus();break;
				case  MessageBoxDefaultButton.Button3 : if (ax.button3.Enabled ) ax.button3.Focus(); else ax.button1.Focus();break;
			}

            if (ax.DetailText.Text.Trim() == "")
            {
                h = ax.button1.Top + ax.button1.Height + 16;
                ax.ClientSize = new Size(w, h);
                ax.DetailLabel.Visible = false;
                ax.DetailText.Visible = false;
                ax.DetailLabel.Enabled = false;
                ax.DetailText.Enabled = false;
                return;
            }

            h = ax.button1.Top + ax.button1.Height + 4;
            ax.DetailLabel.Visible = true;

            
            {
                ax.DetailLabel.Left = w - 8 -ax.DetailLabel.Width ;
                ax.DetailLabel.Top = h ;
                ax.DetailText.Top = ax.DetailLabel.Top + ax.DetailLabel.Height+4;
                ax.DetailText.Width = w - ax.DetailText.Left * 2;
            }
            
            h = ax.DetailText.Top + ax.DetailText.Height + 8;

            ax.DetailLabel.Visible = true;
            ax.DetailText.Visible = true;
            
                 
            ax.ClientSize = new Size(w, h);
					
		}

	}
}

