using ILG.DS.Controls;

namespace ILG.Codex.CodexR4
{
    partial class CodexDocumentList
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("Search");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodexDocumentList));
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton("Reset");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.DropDownEditorButton dropDownEditorButton1 = new Infragistics.Win.UltraWinEditors.DropDownEditorButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ListFilter = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.Button_Word = new Infragistics.Win.Misc.UltraButton();
            this.Button_Save = new Infragistics.Win.Misc.UltraButton();
            this.Button_Copy = new Infragistics.Win.Misc.UltraButton();
            this.Document_Preview_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DocumentPictureBox = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.TopBar = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ListSplitContainer = new System.Windows.Forms.SplitContainer();
            this.DocumentListBox1 = new ILG.DS.Controls.DSListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Document_Preview = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TopPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.PreviewBar = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListFilter)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopBar)).BeginInit();
            this.TopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListSplitContainer)).BeginInit();
            this.ListSplitContainer.Panel1.SuspendLayout();
            this.ListSplitContainer.Panel2.SuspendLayout();
            this.ListSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBar)).BeginInit();
            this.PreviewBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ListFilter);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(401, 36);
            // 
            // ListFilter
            // 
            this.ListFilter.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            editorButton1.Appearance = appearance1;
            editorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            editorButton1.Key = "Search";
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            editorButton2.Appearance = appearance2;
            editorButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            editorButton2.Key = "Reset";
            this.ListFilter.ButtonsRight.Add(editorButton1);
            this.ListFilter.ButtonsRight.Add(editorButton2);
            this.ListFilter.ButtonsRight.Add(dropDownEditorButton1);
            this.ListFilter.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.ListFilter.Location = new System.Drawing.Point(5, 8);
            this.ListFilter.Name = "ListFilter";
            this.ListFilter.NullText = "ძებნა სიაში";
            appearance3.ForeColor = System.Drawing.Color.Gray;
            this.ListFilter.NullTextAppearance = appearance3;
            this.ListFilter.Size = new System.Drawing.Size(327, 21);
            this.ListFilter.TabIndex = 26;
            this.ListFilter.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
            this.ListFilter.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ListFilter.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.ListFilter_EditorButtonClick);
            this.ListFilter.TextChanged += new System.EventHandler(this.ListFilter_TextChanged);
            this.ListFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListFilter_KeyPress);
            this.ListFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListFilter_KeyUp);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.Button_Word);
            this.ultraTabPageControl2.Controls.Add(this.Button_Save);
            this.ultraTabPageControl2.Controls.Add(this.Button_Copy);
            this.ultraTabPageControl2.Controls.Add(this.Document_Preview_Label);
            this.ultraTabPageControl2.Controls.Add(this.DocumentPictureBox);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(621, 60);
            // 
            // Button_Word
            // 
            this.Button_Word.AutoSize = true;
            this.Button_Word.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Word.Enabled = false;
            this.Button_Word.Location = new System.Drawing.Point(309, 37);
            this.Button_Word.Name = "Button_Word";
            this.Button_Word.Size = new System.Drawing.Size(122, 26);
            this.Button_Word.TabIndex = 4;
            this.Button_Word.Text = "ექსპორტი Word ში";
            this.Button_Word.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Word.Visible = false;
            // 
            // Button_Save
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            this.Button_Save.Appearance = appearance4;
            this.Button_Save.AutoSize = true;
            this.Button_Save.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Save.Enabled = false;
            this.Button_Save.Location = new System.Drawing.Point(147, 34);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(121, 26);
            this.Button_Save.TabIndex = 3;
            this.Button_Save.Text = "ჩაწერა ბაზიდან";
            this.Button_Save.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Save.Visible = false;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Copy
            // 
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            this.Button_Copy.Appearance = appearance5;
            this.Button_Copy.AutoSize = true;
            this.Button_Copy.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Copy.Location = new System.Drawing.Point(59, 33);
            this.Button_Copy.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Copy.Name = "Button_Copy";
            this.Button_Copy.Size = new System.Drawing.Size(83, 26);
            this.Button_Copy.TabIndex = 2;
            this.Button_Copy.Text = "კოპირება";
            this.Button_Copy.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Copy.Click += new System.EventHandler(this.Button_Copy_Click);
            // 
            // Document_Preview_Label
            // 
            appearance6.FontData.Name = "Sylfaen";
            appearance6.FontData.SizeInPoints = 12F;
            this.Document_Preview_Label.Appearance = appearance6;
            this.Document_Preview_Label.AutoSize = true;
            this.Document_Preview_Label.Location = new System.Drawing.Point(64, 8);
            this.Document_Preview_Label.Name = "Document_Preview_Label";
            this.Document_Preview_Label.Size = new System.Drawing.Size(84, 24);
            this.Document_Preview_Label.TabIndex = 1;
            this.Document_Preview_Label.Text = "ultraLabel1";
            this.Document_Preview_Label.Click += new System.EventHandler(this.Document_Preview_Label_Click);
            // 
            // DocumentPictureBox
            // 
            this.DocumentPictureBox.AutoSize = true;
            this.DocumentPictureBox.BackColor = System.Drawing.Color.White;
            this.DocumentPictureBox.BackColorInternal = System.Drawing.Color.White;
            this.DocumentPictureBox.BorderShadowColor = System.Drawing.Color.Empty;
            this.DocumentPictureBox.Image = ((object)(resources.GetObject("DocumentPictureBox.Image")));
            this.DocumentPictureBox.Location = new System.Drawing.Point(3, 3);
            this.DocumentPictureBox.Name = "DocumentPictureBox";
            this.DocumentPictureBox.Size = new System.Drawing.Size(48, 48);
            this.DocumentPictureBox.TabIndex = 0;
            // 
            // TopBar
            // 
            this.TopBar.Controls.Add(this.ultraTabSharedControlsPage1);
            this.TopBar.Controls.Add(this.ultraTabPageControl1);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TopBar.Name = "TopBar";
            this.TopBar.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.TopBar.Size = new System.Drawing.Size(401, 36);
            this.TopBar.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.TopBar.TabIndex = 0;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "tab1";
            this.TopBar.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.TopBar.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(401, 36);
            // 
            // ListSplitContainer
            // 
            this.ListSplitContainer.BackColor = System.Drawing.Color.LightSlateGray;
            this.ListSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ListSplitContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListSplitContainer.Name = "ListSplitContainer";
            // 
            // ListSplitContainer.Panel1
            // 
            this.ListSplitContainer.Panel1.Controls.Add(this.DocumentListBox1);
            this.ListSplitContainer.Panel1.Controls.Add(this.TopBar);
            // 
            // ListSplitContainer.Panel2
            // 
            this.ListSplitContainer.Panel2.Controls.Add(this.Document_Preview);
            this.ListSplitContainer.Panel2.Controls.Add(this.TopPanel);
            this.ListSplitContainer.Panel2.Controls.Add(this.LeftPanel);
            this.ListSplitContainer.Panel2.Controls.Add(this.panel1);
            this.ListSplitContainer.Panel2.Controls.Add(this.PreviewBar);
            this.ListSplitContainer.Size = new System.Drawing.Size(1024, 506);
            this.ListSplitContainer.SplitterDistance = 401;
            this.ListSplitContainer.SplitterWidth = 2;
            this.ListSplitContainer.TabIndex = 1;
            this.ListSplitContainer.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.ListSplitContainer_SplitterMoving);
            this.ListSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.ListSplitContainer_SplitterMoved);
            // 
            // DocumentListBox1
            // 
            this.DocumentListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.DocumentListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentListBox1.Location = new System.Drawing.Point(0, 36);
            this.DocumentListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DocumentListBox1.Name = "DocumentListBox1";
            this.DocumentListBox1.Size = new System.Drawing.Size(401, 470);
            this.DocumentListBox1.TabIndex = 0;
            this.DocumentListBox1.DocumentClick += new DSListBoxCallDocumentEventHandler(this.DocumentListBox1_DocumentClick);
            this.DocumentListBox1.PreviewDocument += new DSListBoxPreviewDocumentEventHandler(this.DocumentListBox1_PreviewDocument);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // Document_Preview
            // 
            this.Document_Preview.AutoWordSelection = true;
            this.Document_Preview.BackColor = System.Drawing.Color.White;
            this.Document_Preview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Document_Preview.ContextMenuStrip = this.contextMenuStrip2;
            this.Document_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Document_Preview.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.Document_Preview.HideSelection = false;
            this.Document_Preview.Location = new System.Drawing.Point(16, 100);
            this.Document_Preview.Margin = new System.Windows.Forms.Padding(20);
            this.Document_Preview.Name = "Document_Preview";
            this.Document_Preview.ReadOnly = true;
            this.Document_Preview.ShowSelectionMargin = true;
            this.Document_Preview.Size = new System.Drawing.Size(605, 406);
            this.Document_Preview.TabIndex = 2;
            this.Document_Preview.Text = "";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.White;
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(16, 80);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(605, 20);
            this.TopPanel.TabIndex = 4;
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.White;
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 80);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(16, 426);
            this.LeftPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.ultraLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 20);
            this.panel1.TabIndex = 5;
            // 
            // ultraLabel1
            // 
            appearance7.ForeColor = System.Drawing.Color.White;
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ultraLabel1.Location = new System.Drawing.Point(5, 2);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(114, 15);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Document Preview";
            this.ultraLabel1.UseAppStyling = false;
            this.ultraLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // PreviewBar
            // 
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColor2 = System.Drawing.Color.White;
            this.PreviewBar.Appearance = appearance8;
            this.PreviewBar.Controls.Add(this.ultraTabSharedControlsPage2);
            this.PreviewBar.Controls.Add(this.ultraTabPageControl2);
            this.PreviewBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PreviewBar.Location = new System.Drawing.Point(0, 0);
            this.PreviewBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PreviewBar.Name = "PreviewBar";
            this.PreviewBar.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.PreviewBar.Size = new System.Drawing.Size(621, 60);
            this.PreviewBar.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.PreviewBar.TabIndex = 1;
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "tab1";
            this.PreviewBar.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab2});
            this.PreviewBar.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(621, 60);
            // 
            // CodexDocumentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 506);
            this.Controls.Add(this.ListSplitContainer);
            this.Font = new System.Drawing.Font("Sylfaen", 9.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CodexDocumentList";
            this.Text = "CodexDocumentList";
            this.Load += new System.EventHandler(this.CodexDocumentList_Load);
            this.Resize += new System.EventHandler(this.CodexDocumentList_Resize_1);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListFilter)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopBar)).EndInit();
            this.TopBar.ResumeLayout(false);
            this.ListSplitContainer.Panel1.ResumeLayout(false);
            this.ListSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListSplitContainer)).EndInit();
            this.ListSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewBar)).EndInit();
            this.PreviewBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTabControl.UltraTabControl TopBar;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.SplitContainer ListSplitContainer;
        private System.Windows.Forms.RichTextBox Document_Preview;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl PreviewBar;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ListFilter;
        public  ILG.DS.Controls.DSListBox DocumentListBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Infragistics.Win.Misc.UltraLabel Document_Preview_Label;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox DocumentPictureBox;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private Infragistics.Win.Misc.UltraButton Button_Word;
        private Infragistics.Win.Misc.UltraButton Button_Save;
        private Infragistics.Win.Misc.UltraButton Button_Copy;

    }
}