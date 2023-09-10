using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win;
using ILG.Codex.CodexR4.KeyBoard;

namespace ILG.CodexR4.Favorites
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FavoritesWindows : System.Windows.Forms.Form
    {
        
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.Misc.UltraButton Button_Cancel;
        private Infragistics.Win.Misc.UltraButton Button_Add;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel Top_Caption;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor2;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox TopICON;
        private Infragistics.Win.Misc.UltraLabel Label1;
        private Infragistics.Win.Misc.UltraLabel Label2;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _FavoritesWindows_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _FavoritesWindows_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _FavoritesWindows_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _FavoritesWindows_UltraFormManager_Dock_Area_Bottom;
		private System.ComponentModel.IContainer components;

		public FavoritesWindows()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoritesWindows));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.Label1 = new Infragistics.Win.Misc.UltraLabel();
            this.Label2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraTextEditor2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.TopICON = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.Top_Caption = new Infragistics.Win.Misc.UltraLabel();
            this.Button_Add = new Infragistics.Win.Misc.UltraButton();
            this.Button_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._FavoritesWindows_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.Label1);
            this.ultraTabPageControl1.Controls.Add(this.Label2);
            this.ultraTabPageControl1.Controls.Add(this.ultraTextEditor1);
            this.ultraTabPageControl1.Controls.Add(this.ultraTextEditor2);
            this.ultraTabPageControl1.Controls.Add(this.TopICON);
            this.ultraTabPageControl1.Controls.Add(this.Top_Caption);
            this.ultraTabPageControl1.Controls.Add(this.Button_Add);
            this.ultraTabPageControl1.Controls.Add(this.Button_Cancel);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(548, 293);
            // 
            // Label1
            // 
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.Label1.Appearance = appearance1;
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(29, 87);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(125, 18);
            this.Label1.TabIndex = 28;
            this.Label1.Text = "ფავორიტის სათაური";
            this.Label1.UseAppStyling = false;
            // 
            // Label2
            // 
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.Label2.Appearance = appearance2;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(29, 142);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(133, 18);
            this.Label2.TabIndex = 27;
            this.Label2.Text = "დოკუმენტის სათაური";
            this.Label2.UseAppStyling = false;
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.ultraTextEditor1.Location = new System.Drawing.Point(12, 111);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(518, 25);
            this.ultraTextEditor1.TabIndex = 21;
            this.ultraTextEditor1.UseAppStyling = false;
            this.ultraTextEditor1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ultraTextEditor1_KeyPress);
            // 
            // ultraTextEditor2
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            this.ultraTextEditor2.Appearance = appearance3;
            this.ultraTextEditor2.BackColor = System.Drawing.Color.White;
            this.ultraTextEditor2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.ScenicRibbon;
            this.ultraTextEditor2.Location = new System.Drawing.Point(12, 166);
            this.ultraTextEditor2.Multiline = true;
            this.ultraTextEditor2.Name = "ultraTextEditor2";
            this.ultraTextEditor2.ReadOnly = true;
            this.ultraTextEditor2.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.ultraTextEditor2.Size = new System.Drawing.Size(521, 72);
            this.ultraTextEditor2.TabIndex = 26;
            this.ultraTextEditor2.UseAppStyling = false;
            // 
            // TopICON
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.TopICON.Appearance = appearance4;
            this.TopICON.AutoSize = true;
            this.TopICON.BackColor = System.Drawing.Color.Transparent;
            this.TopICON.BorderShadowColor = System.Drawing.Color.Empty;
            this.TopICON.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.TopICON.Image = ((object)(resources.GetObject("TopICON.Image")));
            this.TopICON.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.TopICON.Location = new System.Drawing.Point(12, 12);
            this.TopICON.Name = "TopICON";
            this.TopICON.Size = new System.Drawing.Size(48, 48);
            this.TopICON.TabIndex = 22;
            this.TopICON.UseAppStyling = false;
            // 
            // Top_Caption
            // 
            appearance5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.Top_Caption.Appearance = appearance5;
            this.Top_Caption.AutoSize = true;
            this.Top_Caption.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Top_Caption.Location = new System.Drawing.Point(66, 39);
            this.Top_Caption.Name = "Top_Caption";
            this.Top_Caption.Size = new System.Drawing.Size(290, 24);
            this.Top_Caption.TabIndex = 21;
            this.Top_Caption.Text = "დოკუმენტის დამატება ფავორიტებში";
            this.Top_Caption.UseAppStyling = false;
            // 
            // Button_Add
            // 
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            this.Button_Add.Appearance = appearance6;
            this.Button_Add.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Add.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Add.Location = new System.Drawing.Point(299, 249);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(114, 26);
            this.Button_Add.TabIndex = 6;
            this.Button_Add.Text = "დამატება";
            this.Button_Add.UseAppStyling = false;
            this.Button_Add.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Button_Add.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Add.Click += new System.EventHandler(this.ultraButton4_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Cancel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Cancel.Location = new System.Drawing.Point(419, 249);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(114, 26);
            this.Button_Cancel.TabIndex = 7;
            this.Button_Cancel.Text = "უარი";
            this.Button_Cancel.UseAppStyling = false;
            this.Button_Cancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Button_Cancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Cancel.Click += new System.EventHandler(this.ultraButton5_Click);
            // 
            // ultraTabControl1
            // 
            appearance7.BackColor = System.Drawing.Color.White;
            this.ultraTabControl1.ActiveTabAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.White;
            this.ultraTabControl1.Appearance = appearance8;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(1, 31);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(548, 293);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ultraTabControl1.TabIndex = 5;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "tab1";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.ultraTabControl1.UseAppStyling = false;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(548, 293);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            this.ultraFormManager1.FormStyleSettings.FormDisplayStyle = Infragistics.Win.UltraWinToolbars.FormDisplayStyle.RoundedFixed;
            this.ultraFormManager1.FormStyleSettings.Style = Infragistics.Win.UltraWinForm.UltraFormStyle.Office2013;
            // 
            // _FavoritesWindows_UltraFormManager_Dock_Area_Left
            // 
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 1;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 31);
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left.Name = "_FavoritesWindows_UltraFormManager_Dock_Area_Left";
            this._FavoritesWindows_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(1, 293);
            // 
            // _FavoritesWindows_UltraFormManager_Dock_Area_Right
            // 
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 1;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(549, 31);
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right.Name = "_FavoritesWindows_UltraFormManager_Dock_Area_Right";
            this._FavoritesWindows_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(1, 293);
            // 
            // _FavoritesWindows_UltraFormManager_Dock_Area_Top
            // 
            this._FavoritesWindows_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._FavoritesWindows_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._FavoritesWindows_UltraFormManager_Dock_Area_Top.Name = "_FavoritesWindows_UltraFormManager_Dock_Area_Top";
            this._FavoritesWindows_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(550, 31);
            // 
            // _FavoritesWindows_UltraFormManager_Dock_Area_Bottom
            // 
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 1;
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 324);
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom.Name = "_FavoritesWindows_UltraFormManager_Dock_Area_Bottom";
            this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(550, 1);
            // 
            // FavoritesWindows
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(550, 325);
            this.Controls.Add(this.ultraTabControl1);
            this.Controls.Add(this._FavoritesWindows_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._FavoritesWindows_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._FavoritesWindows_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._FavoritesWindows_UltraFormManager_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FavoritesWindows";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ფავორიტებში დამატება";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion



		private void Form1_Load(object sender, System.EventArgs e)
		{
            TopICON.Left = 12;
            TopICON.Top = 12;
            Top_Caption.Left = TopICON.Left + TopICON.Width + 8;
            Top_Caption.Top = TopICON.Top + TopICON.Height - Top_Caption.Height;

            Label1.Left = 12;
            Label1.Top = TopICON.Top + TopICON.Height + 8;

            ultraTextEditor1.Top = Label1.Top + Label1.Height + 4;
            ultraTextEditor1.Left = 12;

            Label2.Left = 12;
            Label2.Top = ultraTextEditor1.Top + ultraTextEditor1.Height + 8;

            ultraTextEditor2.Top = Label2.Top + Label2.Height + 4;
            ultraTextEditor2.Left = ultraTextEditor1.Left;

            int _w = ultraTextEditor2.Width + ultraTextEditor2.Left + ultraTextEditor2.Left;

            this.Button_Cancel.Left = ultraTextEditor2.Left + ultraTextEditor2.Width - Button_Cancel.Width;
            Button_Cancel.Top = ultraTextEditor2.Top + ultraTextEditor2.Height + 8;
            Button_Add.Top = Button_Cancel.Top;
            Button_Add.Left = Button_Cancel.Left - 8 - Button_Add.Width;

            int _h = Button_Add.Top + Button_Add.Height + 8;

            this.ClientSize = new Size(_w, _h);




            

		}

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void ultraTextEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ILG.Codex.CodexR4.KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = ILG.Codex.CodexR4.KeyBoard.Layout.U[e.KeyChar];
            }

        }



        

      
       
    }
}
