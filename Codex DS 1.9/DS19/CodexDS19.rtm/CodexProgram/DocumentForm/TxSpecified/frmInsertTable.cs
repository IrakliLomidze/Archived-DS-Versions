using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{
	/// <summary>
	/// Summary description for frmInsertTable.
	/// </summary>
	public class frmInsertTable : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.NumericUpDown updownColumns;
		internal System.Windows.Forms.NumericUpDown updownRows;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button cmdCancel;
		internal System.Windows.Forms.Button cmdOK;
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
            this.updownColumns = new System.Windows.Forms.NumericUpDown();
            this.updownRows = new System.Windows.Forms.NumericUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.updownColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownRows)).BeginInit();
            this.SuspendLayout();
            // 
            // updownColumns
            // 
            this.updownColumns.Location = new System.Drawing.Point(64, 40);
            this.updownColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updownColumns.Name = "updownColumns";
            this.updownColumns.Size = new System.Drawing.Size(64, 20);
            this.updownColumns.TabIndex = 13;
            this.updownColumns.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // updownRows
            // 
            this.updownRows.Location = new System.Drawing.Point(64, 16);
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
            this.updownRows.Size = new System.Drawing.Size(64, 20);
            this.updownRows.TabIndex = 12;
            this.updownRows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 40);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 16);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "Columns";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 16);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Rows";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(184, 40);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 24);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(184, 8);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(80, 24);
            this.cmdOK.TabIndex = 14;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmInsertTable
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(272, 71);
            this.Controls.Add(this.updownColumns);
            this.Controls.Add(this.updownRows);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertTable";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Table";
            ((System.ComponentModel.ISupportInitialize)(this.updownColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownRows)).EndInit();
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
	}
}
