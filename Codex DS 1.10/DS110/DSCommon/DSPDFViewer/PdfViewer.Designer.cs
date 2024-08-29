using System;
using System.Collections.Generic;
using System.Text;

namespace PdfiumViewer
{
    partial class PdfViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfViewer));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this.PageLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this._zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this._renderer = new PdfiumViewer.PdfRenderer();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            resources.ApplyResources(this._toolStrip, "_toolStrip");
            this._toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PageLabel,
            this.toolStripSeparator1,
            this._zoomInButton,
            this.toolStripButton1,
            this._zoomOutButton});
            this._toolStrip.Name = "_toolStrip";
            // 
            // PageLabel
            // 
            this.PageLabel.ActiveLinkColor = System.Drawing.Color.White;
            this.PageLabel.ForeColor = System.Drawing.Color.Black;
            this.PageLabel.Name = "PageLabel";
            resources.ApplyResources(this.PageLabel, "PageLabel");
            this.PageLabel.VisitedLinkColor = System.Drawing.Color.Black;
            this.PageLabel.Click += new System.EventHandler(this.PageLabel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // _zoomInButton
            // 
            this._zoomInButton.Image = global::DSPDFViewer.Properties.Resources.zoom_in_16px;
            resources.ApplyResources(this._zoomInButton, "_zoomInButton");
            this._zoomInButton.Name = "_zoomInButton";
            this._zoomInButton.Click += new System.EventHandler(this._zoomInButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::DSPDFViewer.Properties.Resources.view_page_width_16px;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // _zoomOutButton
            // 
            this._zoomOutButton.Image = global::DSPDFViewer.Properties.Resources.zoom_out_16px;
            resources.ApplyResources(this._zoomOutButton, "_zoomOutButton");
            this._zoomOutButton.Name = "_zoomOutButton";
            this._zoomOutButton.Click += new System.EventHandler(this._zoomOutButton_Click);
            // 
            // _renderer
            // 
            this._renderer.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._renderer, "_renderer");
            this._renderer.Name = "_renderer";
            this._renderer.Page = 0;
            this._renderer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this._renderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
            this._renderer.LinkClick += new PdfiumViewer.LinkClickEventHandler(this._renderer_LinkClick);
            // 
            // PdfViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._renderer);
            this.Controls.Add(this._toolStrip);
            this.Name = "PdfViewer";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _zoomInButton;
        private System.Windows.Forms.ToolStripButton _zoomOutButton;
        private PdfRenderer _renderer;
        private System.Windows.Forms.ToolStripLabel PageLabel;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
