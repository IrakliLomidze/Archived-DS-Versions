namespace ILG.Codex.CodexR4
{
    partial class PrintDoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TXTextControl.Selection selection1 = new TXTextControl.Selection();
            TXTextControl.ListFormat listFormat1 = new TXTextControl.ListFormat();
            TXTextControl.ParagraphFormat paragraphFormat1 = new TXTextControl.ParagraphFormat();
            this.textControl1 = new TXTextControl.TextControl();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(29, 37);
            this.textControl1.Name = "textControl1";
            selection1.FontName = "Arial";
            selection1.FontSize = 200;
            selection1.ForeColor = System.Drawing.SystemColors.WindowText;
            selection1.FormattingStyle = "[Normal]";
            listFormat1.CharAfterNumber = '\0';
            listFormat1.HangingIndent = 0;
            selection1.ListFormat = listFormat1;
            paragraphFormat1.AbsoluteLineSpacing = 228;
            selection1.ParagraphFormat = paragraphFormat1;
            selection1.Text = "textControl1";
            selection1.TextBackColor = System.Drawing.SystemColors.Window;
            this.textControl1.Selection = selection1;
            this.textControl1.Size = new System.Drawing.Size(240, 195);
            this.textControl1.TabIndex = 0;
            this.textControl1.Text = "textControl1";
            this.textControl1.ViewMode = TXTextControl.ViewMode.PageView;
            // 
            // PrintDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.textControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrintDoc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PrintDoc";
            this.ResumeLayout(false);

        }

        #endregion

        public TXTextControl.TextControl textControl1;

    }
}