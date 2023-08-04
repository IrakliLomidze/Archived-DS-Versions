using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ILG.Codex.Codex2007
{
	/// <summary>
	/// Summary description for frmInsertTable.
	/// </summary>
	public class frmInsertTable : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.NumericUpDown updownColumns;
        internal System.Windows.Forms.NumericUpDown updownRows;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.Misc.UltraButton cmdCancel;
        private Infragistics.Win.Misc.UltraButton cmdOK;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInsertTable()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.updownColumns = new System.Windows.Forms.NumericUpDown();
            this.updownRows = new System.Windows.Forms.NumericUpDown();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.cmdOK = new Infragistics.Win.Misc.UltraButton();
            this.cmdCancel = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.updownColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // updownColumns
            // 
            this.updownColumns.Location = new System.Drawing.Point(104, 51);
            this.updownColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updownColumns.Name = "updownColumns";
            this.updownColumns.Size = new System.Drawing.Size(64, 23);
            this.updownColumns.TabIndex = 13;
            this.updownColumns.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // updownRows
            // 
            this.updownRows.Location = new System.Drawing.Point(104, 17);
            this.updownRows.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.updownRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updownRows.Name = "updownRows";
            this.updownRows.Size = new System.Drawing.Size(64, 23);
            this.updownRows.TabIndex = 12;
            this.updownRows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(303, 127);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.ultraTabControl1.TabIndex = 18;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "ცხრილის ჩასმა";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            this.ultraTabControl1.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.ultraTabControl1_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(301, 102);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.cmdCancel);
            this.ultraTabPageControl1.Controls.Add(this.cmdOK);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl1.Controls.Add(this.updownColumns);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl1.Controls.Add(this.updownRows);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(301, 102);
            // 
            // ultraLabel1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(20, 19);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(63, 18);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "სტრიქონი";
            // 
            // ultraLabel2
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance2;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Location = new System.Drawing.Point(20, 53);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(39, 18);
            this.ultraLabel2.TabIndex = 1;
            this.ultraLabel2.Text = "სვეტი";
            // 
            // cmdOK
            // 
            this.cmdOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.cmdOK.Location = new System.Drawing.Point(198, 17);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 14;
            this.cmdOK.Text = "ჩასმა";
            this.cmdOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.cmdCancel.Location = new System.Drawing.Point(198, 53);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "დახურვა";
            this.cmdCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmInsertTable
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(303, 127);
            this.Controls.Add(this.ultraTabControl1);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertTable";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Table";
            ((System.ComponentModel.ISupportInitialize)(this.updownColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public TXTextControl.TextControl tx;

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			tx.Tables.Add((int)updownRows.Value, (int)updownColumns.Value);
			Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }
	}
}
