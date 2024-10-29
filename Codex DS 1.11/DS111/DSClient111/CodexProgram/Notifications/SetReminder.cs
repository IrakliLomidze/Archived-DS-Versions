using ILG.DS.Controls;
using ILG.DS.Notification;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ILG.DS.Dialogs
{
    public partial class SetReminder : Form
    {
        DSLightNotificationRecord _content;
        int mode; // 0 edit 1 add
        private bool _isChanged = false;
        public bool isChanged => _isChanged;

        public SetReminder(int reminderId)
        {
            InitializeComponent();
            mode = 0;
            _content = new DSLightNotificationRecord();
            LoadNotificationData(reminderId);
            _isChanged = false;

            this.Text = "დოკუმენტის ID:" + _content.on_document_id.ToString();
        }

        public SetReminder(int idDocument, String DocumentTitle, int App)
        {
            InitializeComponent();
            //_ns = new NotificationJsonRepository();
            _content = new DSLightNotificationRecord();
            CreateNewNotificationData(idDocument, DocumentTitle, App);

            _isChanged = false;
            mode = 1;
            this.Text = "დოკუმენტის ID:" + _content.on_document_id.ToString();
        }





        private void LoadNotificationData(int Id)
        {
            mode = 0;
            try
            {
                _content = DSLightNotificationManager.instance.GetNotificationById(Id);//  _ns.GetById(Id);
            }
            catch
            {
                ILGMessageBox.Show("არ ხერხდება ინფორმაციის ჩატვირთვა ბაზიდან");
            }
        }

        private void CreateNewNotificationData(int IdDocument, String DocumentTitle,   int App)
        {
            mode = 1;
            _content = new DSLightNotificationRecord();
            _content.on_document_id = IdDocument;
            _content.document_title = DocumentTitle;
            _content.notification_caption = "";
            _content.on_app = 0;// App;
            _content.on_date = DateTime.Now + TimeSpan.FromDays(14);
            _content.on_date_remind_before = 14;
        }

        private void DisplayData()
        {
            DocumentTitleEditBox.Text = _content.document_title.Trim();
            DocumentSubjectEditBox.Text = _content.notification_caption.Trim();

            CheckEditorConditionType.Checked = (_content.notification_condition_type == 1);
            if (_content.on_date != null) DateTimeEditorWhen.DateTime = _content.on_date.Value;
            if (_content.on_date_remind_before != null)
            {
                if (_content.on_date_remind_before.Value <= RemindMeBeforeCombo.Items.Count)
                    RemindMeBeforeCombo.SelectedIndex = _content.on_date_remind_before.Value;
            }


            bool attachmentButtonShowCondition = false;
            /// Removed Attachment Functionality
            //////attachmentButtonShowCondition = (_content.attachment?.Length != 0);

            //////ultraToolbarsManager1.Tools["Attachment"].SharedProps.Enabled = attachmentButtonShowCondition;
            //////ultraToolbarsManager1.Tools["Attachment"].SharedProps.Visible = attachmentButtonShowCondition;

            //////if (attachmentButtonShowCondition == true)
            //////{
            //////    ultraToolbarsManager1.Tools["Save Attachment"].SharedProps.Caption = $"Save Attachment [{ _content.attachment_filename }]";
            //////    ultraToolbarsManager1.Tools["RemoveAttachment"].SharedProps.Caption = $"Delete Attachment [{ _content.attachment_filename}]";
            //////}

            setCodexAppIcon(_content.on_app);

            if (_content.notification_description.Length != 0)
            {
                richTextBox1.SelectAll();
                richTextBox1.Text = "";
                using (MemoryStream ms = new MemoryStream(_content.notification_description))
                {
                    ms.Position = 0;
                    this.richTextBox1.LoadFile(ms, RichTextBoxStreamType.RichText);
                }
            }

        }

        private void UpdataData()
        {
            _content.document_title = DocumentTitleEditBox.Text;
            _content.notification_caption = DocumentSubjectEditBox.Text;

            if (CheckEditorConditionType.Checked == true)
            { _content.notification_condition_type = 1; } else { _content.notification_condition_type = 0; }

            if (_content.notification_condition_type == 0)
            {
                _content.on_date = DateTimeEditorWhen.DateTime;
                _content.on_date_remind_before = RemindMeBeforeCombo.SelectedIndex;
            }

            /// Removed Attachment Functionality
            ////if (_content.attachment.Length == 0)
            ////{
            ////    if (TextEditorAttachmentFile.Text.Trim() == "") _content.attachment = new byte[0];
            ////    else
            ////    {
            ////        if (File.Exists(TextEditorAttachmentFile.Text.Trim()))
            ////        {
            ////            _content.attachment = File.ReadAllBytes(TextEditorAttachmentFile.Text.Trim());
            ////            _content.attachment_filename = Path.GetFileName(TextEditorAttachmentFile.Text.Trim());
            ////        }
            ////    }
            ////}

            if (richTextBox1.Text.Trim() != "")
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    richTextBox1.SaveFile(ms, RichTextBoxStreamType.RichText);
                    _content.notification_description = ms.ToArray();
                }
            }




        }

        private void setCodexAppIcon(int App)
        {
            
            CodexAppLogoPictureBox.AutoSize = true;
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "SaveAndClose":    // ButtonTool
                    if (mode == 0) { if (PerformNotificationSaveChange() == true) Close(); }
                    if (mode == 1) { if (PerformNotificationSaveNew() == true) Close(); }
                    break;


                case "Delete":    // ButtonTool
                    if (MessageBox.Show("შეტყობინების წაშლა, დრწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("შეტყობინების წაშლა, დრწმუნებული ხართ ? დაადასტურეთ !", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            PerformNotificationDelete();
                            Close();
                        }
                    }

                    break;

                /// Removed Attachment Functionality
                ////case "Save Attachment":
                ////    SaveAttachments();
                ////    break;


                ////case "RemoveAttachment":
                ////    if (MessageBox.Show("მიბმული ფაილის წაშლა, დრწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                ////    {
                ////        if (MessageBox.Show("მიბმული ფაილის წაშლა, დრწმუნებული ხართ ? დაადასტურეთ !", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                ////        {
                ////            DeleteAttachment();
                ////        }
                ////    }

                ////    break;


                #region text
                case "Bold":
                    if (richTextBox1.SelectionLength > 0)
                    {
                        if (richTextBox1.SelectionFont == null) if (richTextBox1.SelectionLength > 0) new Font("Sylfaen", 11, FontStyle.Regular);

                        FontStyle v = richTextBox1.SelectionFont.Style ^ FontStyle.Bold;
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, v);
                    }
                    break;

                case "Italic":
                    if (richTextBox1.SelectionLength > 0)
                    {
                        if (richTextBox1.SelectionFont == null) if (richTextBox1.SelectionLength > 0) new Font("Sylfaen", 11, FontStyle.Regular);

                        FontStyle v = richTextBox1.SelectionFont.Style ^ FontStyle.Italic;

                        this.richTextBox1.SelectionFont = new Font(richTextBox1.Font, v);
                    }
                    break;

                case "Underline":
                    if (richTextBox1.SelectionLength > 0)
                    {
                        if (richTextBox1.SelectionFont == null) if (richTextBox1.SelectionLength > 0) new Font("Sylfaen", 11, FontStyle.Regular);

                        FontStyle v = richTextBox1.SelectionFont.Style ^ FontStyle.Underline;

                        this.richTextBox1.SelectionFont = new Font(richTextBox1.Font, v);
                    }
                    break;

                case "Left":
                    {
                        if (richTextBox1.SelectionLength > 0)
                        {
                            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                        }
                    }
                    break;


                case "Center":
                    {
                        if (richTextBox1.SelectionLength > 0)
                        {
                            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                        }
                    }
                    break;
                case "Right":
                    {
                        if (richTextBox1.SelectionLength > 0)
                        {
                            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                        }
                    }
                    break;

                //case "ColorSchemeList":
                //    ListToolItem item = ((ListTool)e.Tool).SelectedItem;
                //    if (item != null)
                //        Office2013ColorTable.ColorScheme = (Office2013ColorScheme)item.Value;

                //    break;

                case "Paste":
                    {
                        try
                        { richTextBox1.Paste();
                        }
                        catch
                        { }
                   }
                    break;

                case "Copy":
                    richTextBox1.Copy();
                    break;

                case "SellectAll":
                  if  (richTextBox1.CanSelect == true) richTextBox1.SelectAll();
                    break;

                case "Undo":
                    if (richTextBox1.CanUndo == true) richTextBox1.Undo();
                    break;

                case "Redo":
                    if (richTextBox1.CanRedo == true) richTextBox1.Redo();
                    break;


                case "Find":
                    {
                        string fontName = ((FontListTool)this.ultraToolbarsManager1.Tools["FontList"]).Text;
                        string selectedSize = "11";
                        selectedSize = ((ComboBoxTool)ultraToolbarsManager1.Tools["FontSize"]).Text.ToString();
                        float fsize = 10;
                        float.TryParse(selectedSize, out fsize);

                        if (richTextBox1.SelectionLength > 0)
                        {
                            richTextBox1.SelectionFont = new Font(fontName, fsize);
                        }
                        return;

                    }
                    break;

                //case "FontHighlight":
                //    PopupColorPickerTool highlightTool = (PopupColorPickerTool)e.Tool;
                //    Color highlightColor = Color.White;

                //    if (highlightTool.Checked)
                //        highlightColor = highlightTool.SelectedColor;
                //    else
                //    {
                //        Color editorBackColor = this.ultraFormattedTextEditor1.Appearance.BackColor;
                //        if (!editorBackColor.IsEmpty)
                //            highlightColor = this.ultraFormattedTextEditor1.Appearance.BackColor;
                //    }

                //    string hexHighlightColor = System.Drawing.ColorTranslator.ToHtml(highlightColor);
                //    this.ultraFormattedTextEditor1.EditInfo.ApplyStyle("Background-color: " + hexHighlightColor, false);

                //    break;



                case "Reset":
                    this.Reset();

                    break;


                case "Exit":
                    this.Close();

                    break;

                    #endregion Text


            }

        }

        private void SetReminder_Load(object sender, EventArgs e)
        {
            RemindMeBeforeCombo.SelectedIndex = 0;
            DisplayData();
            richTextBox1.Font = new Font("Sylfaen", 11, FontStyle.Regular);

            ((FontListTool)this.ultraToolbarsManager1.Tools["FontList"]).Text = richTextBox1.Font.FontFamily.Name;

            ((ComboBoxTool)ultraToolbarsManager1.Tools["FontSize"]).Text = richTextBox1.Font.SizeInPoints.ToString();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "*.* | *.*";
            if (od.ShowDialog() == DialogResult.OK)
            {
                this.TextEditorAttachmentFile.Text = od.FileName;
            }
        }







        #region Text Formating
        private void ultraToolbarsManager1_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
        {


            switch (e.Tool.Key)
            {
                case "FontList":
                    {
                        string fontName = ((FontListTool)e.Tool).Text;
                        if (richTextBox1.SelectionLength > 0)
                            richTextBox1.SelectionFont = new Font(fontName, richTextBox1.SelectionFont.Size);
                    }
                    break;

                case "FontColor":
                    {
                        Color fontColor = ((PopupColorPickerTool)this.ultraToolbarsManager1.Tools["FontColor"]).SelectedColor;
                        string hexColor = ColorTranslator.ToHtml(fontColor);
                        if (richTextBox1.SelectionLength > 0)
                            richTextBox1.SelectionColor = fontColor;
                        else richTextBox1.ForeColor = fontColor;

                    }
                    break;

                case "BackgroundColor":
                    {
                        Color fontColor = ((PopupColorPickerTool)this.ultraToolbarsManager1.Tools["BackgroundColor"]).SelectedColor;
                        string hexColor = ColorTranslator.ToHtml(fontColor);
                        if (richTextBox1.SelectionLength > 0)
                            richTextBox1.SelectionBackColor = fontColor;


                    }
                    break;

                case "FontSize":
                    {
                        string selectedSize = "10";
                        if (((ComboBoxTool)e.Tool).Text != null)
                            selectedSize = ((ComboBoxTool)e.Tool).Text.ToString();
                        float fsize = 10;
                        float.TryParse(selectedSize, out fsize);
                        if (richTextBox1.SelectionLength > 0)
                            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily.ToString(), fsize);
                        break;
                    }
            }
            this.richTextBox1.Focus();

        }

        private void reflectchangesontoolbar()
        {
            // We want to prevent any of the logic in the ToolClick event handler from executing, otherwise we'll
            // have an infinite loop.
            this.ultraToolbarsManager1.EventManager.SetEnabled(ToolbarEventIds.ToolClick, false);


            //((StateButtonTool)this.ultraToolbarsManager1.Tools["Bold"]).Checked =
            //    richTextBox1.SelectionFont.Bold == true ? true : false;

            //((StateButtonTool)this.ultraToolbarsManager1.Tools["Italic"]).Checked =
            //    richTextBox1.SelectionFont.Italic == true ? true : false;

            //((StateButtonTool)this.ultraToolbarsManager1.Tools["Underline"]).Checked =
            //    richTextBox1.SelectionFont.Underline == true ? true : false;

            //((StateButtonTool)this.ultraToolbarsManager1.Tools["Left"]).Checked =
            //    richTextBox1.SelectionAlignment == HorizontalAlignment.Left;

            //((StateButtonTool)this.ultraToolbarsManager1.Tools["Center"]).Checked =
            //      richTextBox1.SelectionAlignment == HorizontalAlignment.Center;

            //((StateButtonTool)this.ultraToolbarsManager1.Tools["Right"]).Checked =
            //       richTextBox1.SelectionAlignment == HorizontalAlignment.Right;


            this.ultraToolbarsManager1.EventManager.SetEnabled(ToolbarEventIds.ToolClick, true);
        }
        private void richTextBox1_StyleChanged(object sender, EventArgs e)
        {
            reflectchangesontoolbar();

        }


        #region Methods


        // Reset text formatting
        private void Reset()
        {
            // Font defaults
            ((ComboBoxTool)this.ultraToolbarsManager1.Tools["FontSize"]).SelectedIndex = 2;
            ((FontListTool)this.ultraToolbarsManager1.Tools["FontName"]).SelectedIndex = 0;

            ((StateButtonTool)this.ultraToolbarsManager1.Tools["Left"]).Checked = true;
            ((StateButtonTool)this.ultraToolbarsManager1.Tools["Bold"]).Checked = false;
            ((StateButtonTool)this.ultraToolbarsManager1.Tools["Italic"]).Checked = false;
            ((StateButtonTool)this.ultraToolbarsManager1.Tools["Underline"]).Checked = false;
        }


        private void Initialize()
        {
            // Don't fire any toolbar events during initialization
            this.ultraToolbarsManager1.EventManager.AllEventsEnabled = false;

            this.Reset();

            this.ultraToolbarsManager1.EventManager.AllEventsEnabled = true;

            ((PopupGalleryTool)this.ultraToolbarsManager1.Tools["PresetsGallery"]).SelectedItemKey = "Normal";
        }





        #endregion //Methods

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            



        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
            {
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
            }
        }

        private void DocumentTitleEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
            {
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
            }
        }

        private void DocumentSubjectEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
            {
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            reflectchangesontoolbar();
        }

        #endregion Text Formating

        // ....

        private bool SaveReminderChecks()
        {
            if (ILGMessageBox.Show("ინფორმაციის ჩაწერა ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)  return false;
            if (DocumentTitleEditBox.Text.Trim() == String.Empty) { ILGMessageBox.Show("დოკუმენტის ველი არ შეიძლება იყოს ცარიელი", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);  return false; }
            if (DocumentSubjectEditBox.Text.Trim() == String.Empty) { ILGMessageBox.Show("შეხსენების საკითხი არ შეიძლება იყოს ცარიელი", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (CheckEditorConditionType.Checked == false)
            {
                if (DateTimeEditorWhen.Value == null)
                {
                    ILGMessageBox.Show("მიუთითეთ როდის უნდა შეგახსენოთ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
                }
            }

            ////if (TextEditorAttachmentFile.Text.Trim() != String.Empty)
            ////{
            ////    if (!File.Exists(TextEditorAttachmentFile.Text.Trim()))
            ////    {
            ////        ILGMessageBox.Show("მითითებული ფაილი (Attachment) არ მოიძებნა", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            ////    }
            ////}

            return true;
        }



        #region internals

        // ჯერჯერობით მირყვება დღე და ინდექსი, მერე მომიწევს switch ით გადაკეთბა
        private int RemindmeBeforeSelectionToDays(int selectionIndex)
        {
            return selectionIndex;
        }
        // ჯერჯერობით მირყვება დღე და ინდექსი, მერე მომიწევს switch ით გადაკეთბა
        private int RemindmeBeforeDaysToIndex(int Days)
        {
            return Days;
        }

        #endregion internals

        private bool PerformNotificationSaveNew()
        {
            if (SaveReminderChecks() == true)
            {
                UpdataData();
                DSLightNotificationManager.instance.NewNotification(_content); //_ns.Add(_content);

                _isChanged = true;
                ILGMessageBox.Show("ჩაწერილია");
                return true;
            }
            return false;
        }


        private bool PerformNotificationSaveChange()
        {
            if (SaveReminderChecks() == true)
            {
                UpdataData();
                DSLightNotificationManager.instance.UpdateNotification(_content);// _ns.Update(_content);
                _isChanged = true;
                ILGMessageBox.Show("ჩაწერილია");
                return true;
            }
            return false;
        }

        private bool PerformNotificationDelete()
        {
            UpdataData();
            DSLightNotificationManager.instance.RemoveNotification(_content.nt_id); //_ns.Add(_content);
            _isChanged = true;
            ILGMessageBox.Show("წაშლილია");
            return true;
        }

        /// Removed Attachment Functionality
        ////private void SaveAttachments()
        ////{

        ////    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        ////    saveFileDialog1.FileName = _content.attachment_filename;
        ////    saveFileDialog1.Title = "Save an Attachment File";
        ////    //saveFileDialog1.CheckFileExists = true;
        ////    saveFileDialog1.OverwritePrompt = true;
        ////    saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        ////    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        ////    {
        ////        File.WriteAllBytes(saveFileDialog1.FileName, _content.attachment);
        ////        MessageBox.Show("ჩაწერილია");
        ////    }
        ////}

        ////private void DeleteAttachment()
        ////{
        ////    _content.attachment = new byte[0];
        ////    _content.attachment_filename = "";
        ////    DisplayData();
        ////}

        private void ultraToolbarsManager1_BeforeShortcutKeyProcessed(object sender, BeforeShortcutKeyProcessedEventArgs e)
        {

            if (richTextBox1.Focused == false) e.Cancel = true;
        }
    }

}
