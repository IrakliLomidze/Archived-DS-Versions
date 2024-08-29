
using ILG.Codex.CodexR4.Notifications;
using ILG.Codex.CodexR4.UI;
using ILG.DS.Notification;
using ILG.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{

    public partial class DocumentReminder : Form
    {
        //NotificationJsonRepository _ns;
        DSLightNotificationRecord _content;
        List<DSLightNotificationRecord> _notificationList = new List<DSLightNotificationRecord>();
        NotificationQueryEnum _mode;
        //int _app;
        int _doc;

        private bool _isChanged = false;
        public bool isChanged => _isChanged;



        public DocumentReminder(NotificationQueryEnum mode)
        {
            InitializeComponent();
            _content = new DSLightNotificationRecord();
            _mode = mode;
            _isChanged = false;
        }

        public DocumentReminder(NotificationQueryEnum mode,int app, int doc)
        {
            InitializeComponent();
            _content = new DSLightNotificationRecord();
            _mode = mode;
            //_app = app;
            _doc = doc;
            _isChanged = false;
        }

        private void RefreshData()
        {
            _notificationList = DSLightNotificationManager.instance.GetAllNotifications();
            NotificationQuery nq = new NotificationQuery(_notificationList);

            switch (_mode)
            {
                case NotificationQueryEnum.All : break;
                case NotificationQueryEnum.AllForToday: _notificationList = nq.GetAllForToday(); break;
                case NotificationQueryEnum.AllForDocument: _notificationList = nq.GetAllForParticularDocument(/*_app*/ 0, _doc); break;
            }

            if (_notificationList == null) { MessageBox.Show("შეხსენებების სია ცარიელია"); Close(); return; }
            if (_notificationList?.Count == 0) { MessageBox.Show("შეხსენებების სია ცარიელია"); Close(); return; }

            PopulateList();
        }

      
      
        private void DisplayData()
        {
            DocumentTitleEditBox.Text = _content.document_title.Trim();
            DocumentSubjectEditBox.Text = _content.notification_caption.Trim();

            CheckEditorConditionType.Checked = (_content.notification_condition_type == 1);
            RemindMeBeforeCombo.SelectedIndex = 0;

            if (_content.on_date != null) DateTimeEditorWhen.DateTime = _content.on_date.Value;
            if (_content.on_date_remind_before != null)
            {
                if (_content.on_date_remind_before.Value <= RemindMeBeforeCombo.Items.Count)
                    RemindMeBeforeCombo.SelectedIndex = _content.on_date_remind_before.Value;
            }


            bool attachmentButtonShowCondition = false;
            // Removed Attachment Funcitonality
            //////attachmentButtonShowCondition = (_content.attachment?.Length != 0);

            //////ultraToolbarsManager1.Tools["Attachment"].SharedProps.Enabled = attachmentButtonShowCondition;
            //////ultraToolbarsManager1.Tools["Attachment"].SharedProps.Visible = attachmentButtonShowCondition;

            //////if (attachmentButtonShowCondition == true)
            //////{
            //////    ultraToolbarsManager1.Tools["Save Attachment"].SharedProps.Caption = $"Save Attachment [{ _content.attachment_filename }]";
            //////}

            setCodexAppIcon(_content.on_app);

            richTextBox1.SelectAll();
            richTextBox1.Text = "";

            if (_content.notification_description.Length != 0)
            {
                using (MemoryStream ms = new MemoryStream(_content.notification_description))
                {
                    ms.Position = 0;
                    this.richTextBox1.LoadFile(ms, RichTextBoxStreamType.RichText);
                }
            }

        }


        private void setCodexAppIcon(int App)
        {
            
            ultraToolbarsManager1.BeginUpdate();
            
            CodexAppLogoPictureBox.AutoSize = true;
            ultraToolbarsManager1.Tools["ControlContainerTool1"].SharedProps.Visible = false;
            ultraToolbarsManager1.Tools["ControlContainerTool1"].SharedProps.Visible = true;
            ultraToolbarsManager1.EndUpdate();


        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // Removed Attachment Funcitonality
                //case "Save Attachment":
                //    SaveAttachments();
                //    break;

                case "Close":
                Close();
                    break;

                #region text
         
                case "Copy":
                    richTextBox1.Copy();
                    break;

                case "SellectAll":
                    richTextBox1.SelectAll();
                    break;
                    
                case "Exit":
                    this.Close();

                    break;

                case "Edit":
                    EditNotification();

                    break;


                    #endregion Text


            }

        }

        private void EditNotification()
        {
            if (CodexNotificationsListViews.SelectedItems.Count > 0)
            {
                string s = CodexNotificationsListViews.SelectedItems[0].SubItems[0].Text.ToString().Trim();
                int id = -1;
                if (int.TryParse(s, out id) == true)
                {
                    SetReminder sr = new SetReminder(id);
                    sr.ShowDialog();
                    _isChanged = sr.isChanged;
                    if (sr.isChanged == true)
                    {
                        RefreshData();
                    }
                    
                }
            }
        }
        private void DocumentReminders_Load(object sender, EventArgs e)
        {
            RemindMeBeforeCombo.SelectedIndex = 0;
            using (new WaitCursor())
            {
                RefreshData();
            }
            //DisplayData();
            richTextBox1.Font = new Font("Sylfaen", 11, FontStyle.Regular);
        }

      



        #region Text Formating
 
   

        #region Methods


        


        #endregion //Methods

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
        
            if ((e.KeyCode == Keys.C) && (e.Control == true))
            {
                richTextBox1.Copy();
                return;
            }

            if ((e.KeyCode == Keys.A) && (e.Control == true))
            {
                richTextBox1.SelectAll();
                return;
            }

        
        }

        
        #endregion Text Formating

        

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







        //private void SaveAttachments()
        //{

        //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        //    saveFileDialog1.FileName = _content.attachment_filename;
        //    saveFileDialog1.Title = "Save an Attachment File";
        //    //saveFileDialog1.CheckFileExists = true;
        //    saveFileDialog1.OverwritePrompt = true;
        //    saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        File.WriteAllBytes(saveFileDialog1.FileName, _content.attachment);
        //        MessageBox.Show("ჩაწერილია");
        //    }
        //}

     

        private void PopulateList()
        {

            CodexNotificationsListViews.SuspendLayout();
            CodexNotificationsListViews.Items.Clear();
            CodexNotificationsListViews.MultiSelect = false;
            CodexNotificationsListViews.View = View.Details;


            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "#";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 0;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "პროგრამა";
            columnHeader2.TextAlign = HorizontalAlignment.Left;
            columnHeader2.Width = 40;


            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "დოკუმენტი";
            columnHeader3.TextAlign = HorizontalAlignment.Left;
            columnHeader3.Width = 200;


            ColumnHeader columnHeader4 = new ColumnHeader();
            columnHeader4.Text = "id";
            columnHeader4.TextAlign = HorizontalAlignment.Left;
            columnHeader4.Width = 200;

            CodexNotificationsListViews.Columns.Clear();
            CodexNotificationsListViews.Columns.Add(columnHeader1);
            CodexNotificationsListViews.Columns.Add(columnHeader2);
            CodexNotificationsListViews.Columns.Add(columnHeader3);
            CodexNotificationsListViews.Columns.Add(columnHeader4);

            CodexNotificationsListViews.HeaderStyle = ColumnHeaderStyle.None;
            CodexNotificationsListViews.HeaderStyle = ColumnHeaderStyle.Clickable;




            foreach (var item in _notificationList)
            {
                var listviewitem = new ListViewItem(new string[] { item.nt_id.ToString(), "DS" + " :", item.document_title, item.on_document_id.ToString() }, item.on_app);
                CodexNotificationsListViews.Items.Add(listviewitem);
            }

            CodexNotificationsListViews.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //CodexNotificationsListViews.Columns[0].Width = 0;


            CodexNotificationsListViews.ResumeLayout();
        }


        private DSLightNotificationRecord GetById(int id)
        {
            foreach (var item in _notificationList)
            {
                if (item.nt_id == id) return item;
            }

            return null;
        }
        private void ShowDetails(int id)
        {
            _content = GetById(id);
            if (_content != null)
            {
                //this.Text = _content.Caption; // ReminderCaptionLable.Text = notification.Caption;
                DocumentTitleEditBox.Text = _content.document_title;

                DocumentSubjectEditBox.Text = _content.notification_caption;

                DateTimeEditorWhen.Enabled = false;
                CheckEditorConditionType.Checked = true;

                if (_content.notification_condition_type == 0)
                {
                    CheckEditorConditionType.Checked = false;
                    DateTimeEditorWhen.Enabled = true;
                    DateTimeEditorWhen.DateTime = (DateTime)_content.on_date;
                    RemindMeBeforeCombo.SelectedIndex = 0;
                    if (_content.on_date_remind_before != null)
                    {
                        if (_content.on_date_remind_before > 0)
                        {
                            RemindMeBeforeCombo.SelectedIndex = (int)_content.on_date_remind_before;
                        }
                    }

                }
                else
                {
                    CheckEditorConditionType.Checked = true;
                }
                DisplayData();
            }

        }

        private void CodexNotificationsListViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CodexNotificationsListViews.SelectedItems.Count > 0)
            {
                string s = CodexNotificationsListViews.SelectedItems[0].SubItems[0].Text.ToString().Trim();
                int id = -1;
                if (int.TryParse(s, out id) == true)
                {
                    ShowDetails(id);
                }
            }
        }

        private void CodexNotificationsListViews_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                e.NewWidth = 0;
                e.Cancel = true;
            }
        }


    }

}
