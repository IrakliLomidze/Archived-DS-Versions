using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{
	/// <summary>
	/// Summary description for frmInsertSection.
	/// </summary>
	public class frmInsertBreak : System.Windows.Forms.Form
    {
        private RadioButton BeginAtNewLineRadio;
        private RadioButton BeginAtNewPageRadio;
        private RadioButton InsertPageBreakRadio;
        private RadioButton InsertTextBreakRadio;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraButton cmdCancel;
        private Infragistics.Win.Misc.UltraButton cmdOK;
        private IContainer components;

		public frmInsertBreak()
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Begin at &new line", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Begin &at new page", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Insert page &break", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Insert text &wrapping break", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.BeginAtNewLineRadio = new System.Windows.Forms.RadioButton();
            this.BeginAtNewPageRadio = new System.Windows.Forms.RadioButton();
            this.InsertPageBreakRadio = new System.Windows.Forms.RadioButton();
            this.InsertTextBreakRadio = new System.Windows.Forms.RadioButton();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.cmdOK = new Infragistics.Win.Misc.UltraButton();
            this.cmdCancel = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BeginAtNewLineRadio
            // 
            this.BeginAtNewLineRadio.AutoCheck = false;
            this.BeginAtNewLineRadio.AutoSize = true;
            this.BeginAtNewLineRadio.BackColor = System.Drawing.Color.Transparent;
            this.BeginAtNewLineRadio.Location = new System.Drawing.Point(17, 57);
            this.BeginAtNewLineRadio.Name = "BeginAtNewLineRadio";
            this.BeginAtNewLineRadio.Size = new System.Drawing.Size(185, 20);
            this.BeginAtNewLineRadio.TabIndex = 1;
            this.BeginAtNewLineRadio.Text = "დაიწყე ახალი სტრიქონიდან";
            ultraToolTipInfo4.ToolTipText = "Begin at &new line";
            this.ultraToolTipManager1.SetUltraToolTip(this.BeginAtNewLineRadio, ultraToolTipInfo4);
            this.BeginAtNewLineRadio.UseVisualStyleBackColor = false;
            this.BeginAtNewLineRadio.Click += new System.EventHandler(this.BeginAtNewLineRadio_Click);
            // 
            // BeginAtNewPageRadio
            // 
            this.BeginAtNewPageRadio.AutoCheck = false;
            this.BeginAtNewPageRadio.BackColor = System.Drawing.Color.Transparent;
            this.BeginAtNewPageRadio.Location = new System.Drawing.Point(17, 23);
            this.BeginAtNewPageRadio.Name = "BeginAtNewPageRadio";
            this.BeginAtNewPageRadio.Size = new System.Drawing.Size(209, 28);
            this.BeginAtNewPageRadio.TabIndex = 0;
            this.BeginAtNewPageRadio.TabStop = true;
            this.BeginAtNewPageRadio.Text = "დაიწყე ახალი გვერდიდან";
            ultraToolTipInfo1.ToolTipText = "Begin &at new page";
            this.ultraToolTipManager1.SetUltraToolTip(this.BeginAtNewPageRadio, ultraToolTipInfo1);
            this.BeginAtNewPageRadio.UseVisualStyleBackColor = false;
            this.BeginAtNewPageRadio.Click += new System.EventHandler(this.BeginAtNewPageRadio_Click);
            // 
            // InsertPageBreakRadio
            // 
            this.InsertPageBreakRadio.AutoCheck = false;
            this.InsertPageBreakRadio.AutoSize = true;
            this.InsertPageBreakRadio.BackColor = System.Drawing.Color.Transparent;
            this.InsertPageBreakRadio.Checked = true;
            this.InsertPageBreakRadio.Location = new System.Drawing.Point(19, 33);
            this.InsertPageBreakRadio.Name = "InsertPageBreakRadio";
            this.InsertPageBreakRadio.Size = new System.Drawing.Size(160, 20);
            this.InsertPageBreakRadio.TabIndex = 0;
            this.InsertPageBreakRadio.TabStop = true;
            this.InsertPageBreakRadio.Text = "ჩასვი გვერდის გამყოფი";
            ultraToolTipInfo3.ToolTipText = "Insert page &break";
            this.ultraToolTipManager1.SetUltraToolTip(this.InsertPageBreakRadio, ultraToolTipInfo3);
            this.InsertPageBreakRadio.UseVisualStyleBackColor = false;
            this.InsertPageBreakRadio.Click += new System.EventHandler(this.InsertPageRadio_Click);
            // 
            // InsertTextBreakRadio
            // 
            this.InsertTextBreakRadio.AutoCheck = false;
            this.InsertTextBreakRadio.AutoSize = true;
            this.InsertTextBreakRadio.BackColor = System.Drawing.Color.Transparent;
            this.InsertTextBreakRadio.Location = new System.Drawing.Point(19, 59);
            this.InsertTextBreakRadio.Name = "InsertTextBreakRadio";
            this.InsertTextBreakRadio.Size = new System.Drawing.Size(158, 20);
            this.InsertTextBreakRadio.TabIndex = 1;
            this.InsertTextBreakRadio.Text = "ჩასვი ტექსტის გამყოფი";
            ultraToolTipInfo2.ToolTipText = "Insert text &wrapping break";
            this.ultraToolTipManager1.SetUltraToolTip(this.InsertTextBreakRadio, ultraToolTipInfo2);
            this.InsertTextBreakRadio.UseVisualStyleBackColor = false;
            this.InsertTextBreakRadio.Click += new System.EventHandler(this.InsertTextBreakRadio_Click);
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(366, 306);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.ultraTabControl1.TabIndex = 4;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "გამყოფის ჩასმა";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(364, 281);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.cmdCancel);
            this.ultraTabPageControl1.Controls.Add(this.cmdOK);
            this.ultraTabPageControl1.Controls.Add(this.ultraGroupBox2);
            this.ultraTabPageControl1.Controls.Add(this.ultraGroupBox1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(364, 281);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.InsertTextBreakRadio);
            this.ultraGroupBox1.Controls.Add(this.InsertPageBreakRadio);
            this.ultraGroupBox1.Location = new System.Drawing.Point(14, 16);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(339, 97);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.Text = "გამყოფის ტიპი";
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.BeginAtNewLineRadio);
            this.ultraGroupBox2.Controls.Add(this.BeginAtNewPageRadio);
            this.ultraGroupBox2.Location = new System.Drawing.Point(14, 125);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(339, 94);
            this.ultraGroupBox2.TabIndex = 1;
            this.ultraGroupBox2.Text = "სექციის გამყოფის ტიპი";
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // cmdOK
            // 
            this.cmdOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.cmdOK.Location = new System.Drawing.Point(16, 235);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(103, 25);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "ჩასმა";
            this.cmdOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.cmdCancel.Location = new System.Drawing.Point(125, 235);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(103, 25);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "დახურვა";
            this.cmdCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmInsertBreak
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(366, 306);
            this.Controls.Add(this.ultraTabControl1);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertBreak";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Break";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public TXTextControl.TextControl tx;
        private TXTextControl.SectionBreakKind breakKind;

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
            int dpi = (int)(1440 / tx.CreateGraphics().DpiX);

            if (InsertPageBreakRadio.Checked)
            {
                tx.Selection.Text = "\f";
            }
            else if (InsertTextBreakRadio.Checked)
            {
                tx.Selection.Text = "\v";
            }
            else tx.Sections.Add(breakKind);

/////// ZXZ            tx.ScrollLocation = new Point(tx.ScrollLocation.X, tx.InputPosition.Location.Y - (tx.Sections.GetItem().Format.PageMargins.Top * dpi));
            this.DialogResult = DialogResult.OK;
            Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

        private void InsertPageRadio_Click(object sender, EventArgs e)
        {
            BeginAtNewLineRadio.Checked = false;
            BeginAtNewPageRadio.Checked = false;
            InsertPageBreakRadio.Checked = true;
            InsertTextBreakRadio.Checked = false;
        }

        private void BeginAtNewPageRadio_Click(object sender, EventArgs e)
        {
            BeginAtNewLineRadio.Checked = false;
            BeginAtNewPageRadio.Checked = true;
            InsertPageBreakRadio.Checked = false;
            InsertTextBreakRadio.Checked = false;
            breakKind = TXTextControl.SectionBreakKind.BeginAtNewPage;
        }

        private void BeginAtNewLineRadio_Click(object sender, EventArgs e)
        {
            BeginAtNewLineRadio.Checked = true;
            BeginAtNewPageRadio.Checked = false;
            InsertPageBreakRadio.Checked = false;
            InsertTextBreakRadio.Checked = false;
            breakKind = TXTextControl.SectionBreakKind.BeginAtNewLine;
        }

        private void InsertTextBreakRadio_Click(object sender, EventArgs e)
        {
            BeginAtNewLineRadio.Checked = false;
            BeginAtNewPageRadio.Checked = false;
            InsertPageBreakRadio.Checked = false;
            InsertTextBreakRadio.Checked = true;
        }
	}
}
