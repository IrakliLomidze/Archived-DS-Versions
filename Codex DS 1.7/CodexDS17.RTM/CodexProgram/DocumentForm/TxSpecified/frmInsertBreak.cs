using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{
	
	public class frmInsertBreak : System.Windows.Forms.Form
    {
        internal TableLayoutPanel TableLayoutPanel1;
        internal Button m_btnOK;
        internal Button m_btnCancel;
        private GroupBox groupBox1;
        internal TableLayoutPanel tableLayoutPanel4;
        private RadioButton m_rbInsertColumn;
        private RadioButton m_rbInsertTextBreak;
        private RadioButton m_rbInsertPageBreak;
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.m_rbInsertColumn = new System.Windows.Forms.RadioButton();
            this.m_rbInsertTextBreak = new System.Windows.Forms.RadioButton();
            this.m_rbInsertPageBreak = new System.Windows.Forms.RadioButton();
            this.TableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel1.ColumnCount = 3;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel1.Controls.Add(this.m_btnOK, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.m_btnCancel, 2, 3);
            this.TableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 4;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.Size = new System.Drawing.Size(345, 204);
            this.TableLayoutPanel1.TabIndex = 10;
            // 
            // m_btnOK
            // 
            this.m_btnOK.AutoSize = true;
            this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_btnOK.Location = new System.Drawing.Point(193, 177);
            this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.m_btnOK.MinimumSize = new System.Drawing.Size(72, 23);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(72, 27);
            this.m_btnOK.TabIndex = 6;
            this.m_btnOK.Text = "ჩასმა";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.AutoSize = true;
            this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_btnCancel.Location = new System.Drawing.Point(271, 177);
            this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.m_btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(74, 27);
            this.m_btnCancel.TabIndex = 7;
            this.m_btnCancel.Text = "დახურვა";
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel1.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "გამყოფის ჩასმა";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.m_rbInsertColumn, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.m_rbInsertTextBreak, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.m_rbInsertPageBreak, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(339, 75);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // m_rbInsertColumn
            // 
            this.m_rbInsertColumn.AutoCheck = false;
            this.m_rbInsertColumn.AutoSize = true;
            this.m_rbInsertColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_rbInsertColumn.Location = new System.Drawing.Point(3, 28);
            this.m_rbInsertColumn.Name = "m_rbInsertColumn";
            this.m_rbInsertColumn.Size = new System.Drawing.Size(222, 19);
            this.m_rbInsertColumn.TabIndex = 2;
            this.m_rbInsertColumn.Text = "ჩასვი ტექსტის გამყოფი (Column)";
            this.m_rbInsertColumn.UseVisualStyleBackColor = true;
            this.m_rbInsertColumn.Click += new System.EventHandler(this.m_rbInsertColumn_Click);
            // 
            // m_rbInsertTextBreak
            // 
            this.m_rbInsertTextBreak.AutoCheck = false;
            this.m_rbInsertTextBreak.AutoSize = true;
            this.m_rbInsertTextBreak.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_rbInsertTextBreak.Location = new System.Drawing.Point(3, 53);
            this.m_rbInsertTextBreak.Name = "m_rbInsertTextBreak";
            this.m_rbInsertTextBreak.Size = new System.Drawing.Size(162, 19);
            this.m_rbInsertTextBreak.TabIndex = 3;
            this.m_rbInsertTextBreak.Text = "Insert text &wrapping break";
            this.m_rbInsertTextBreak.UseVisualStyleBackColor = true;
            this.m_rbInsertTextBreak.Click += new System.EventHandler(this.m_rbInsertTextBreak_Click);
            // 
            // m_rbInsertPageBreak
            // 
            this.m_rbInsertPageBreak.AutoCheck = false;
            this.m_rbInsertPageBreak.AutoSize = true;
            this.m_rbInsertPageBreak.Checked = true;
            this.m_rbInsertPageBreak.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_rbInsertPageBreak.Location = new System.Drawing.Point(3, 3);
            this.m_rbInsertPageBreak.Name = "m_rbInsertPageBreak";
            this.m_rbInsertPageBreak.Size = new System.Drawing.Size(170, 19);
            this.m_rbInsertPageBreak.TabIndex = 1;
            this.m_rbInsertPageBreak.TabStop = true;
            this.m_rbInsertPageBreak.Text = "ჩასვი გვერდის გამყოფი";
            this.m_rbInsertPageBreak.UseVisualStyleBackColor = true;
            this.m_rbInsertPageBreak.Click += new System.EventHandler(this.m_rbInsertPageBreak_Click);
            // 
            // frmInsertBreak
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(383, 227);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertBreak";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Break";
            this.TopMost = true;
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public TXTextControl.TextControl tx;
        private TXTextControl.SectionBreakKind breakKind;

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
            int dpi = (int)(1440 / tx.CreateGraphics().DpiX);

            if (m_rbInsertPageBreak.Checked)
            {
                tx.Selection.Text = "\f";
            }
            else if (m_rbInsertColumn.Checked)
            {
                tx.Selection.Text = "\x0E";
            }
            else if (m_rbInsertTextBreak.Checked)
            {
                tx.Selection.Text = "\v";
            }
            

            tx.ScrollLocation = new Point(tx.ScrollLocation.X, (int)(tx.InputPosition.Location.Y - (tx.Selection.SectionFormat.PageMargins.Top * dpi)));
            this.DialogResult = DialogResult.OK;
            Close();
        }

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

     
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_rbInsertPageBreak_Click(object sender, EventArgs e)
        {
            
            m_rbInsertColumn.Checked = false;
            m_rbInsertPageBreak.Checked = true;
            m_rbInsertTextBreak.Checked = false;
        }

        private void m_rbInsertColumn_Click(object sender, EventArgs e)
        {
            m_rbInsertColumn.Checked = true;
            m_rbInsertPageBreak.Checked = false;
            m_rbInsertTextBreak.Checked = false;
        }

        private void m_rbInsertTextBreak_Click(object sender, EventArgs e)
        {
            m_rbInsertColumn.Checked = false;
            m_rbInsertPageBreak.Checked = false;
            m_rbInsertTextBreak.Checked = true;
        }
    }
}
