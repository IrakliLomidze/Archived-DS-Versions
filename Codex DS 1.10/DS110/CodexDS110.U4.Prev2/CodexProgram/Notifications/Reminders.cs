using ILG.DS.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4.Notifications
{
    public partial class Reminders : Form
    {
        List<DSLightNotificationRecord> _notificationList;
        
        private bool _isChanged = false;
        public bool isChanged => _isChanged;

        public Reminders()
        {
            InitializeComponent();
            _notificationList = new List<DSLightNotificationRecord>();
            _isChanged = false;
        }

        public Reminders(List<DSLightNotificationRecord> items)
        {
            InitializeComponent();

            _notificationList = items;
            _isChanged = false;
        }

        private string AppInttoString(int app)
        {
            if (app == 0) return "ხელშეკრულებები";
            if (app == 1) return "კოდიცირებული";
            if (app == 2) return "კოდექსი";
            return "WTF :)";
        }


        private void PopulateUI()
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
            columnHeader3.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);


            ColumnHeader columnHeader4 = new ColumnHeader();
            columnHeader4.Text = "როდის";
            columnHeader4.TextAlign = HorizontalAlignment.Left;
            columnHeader4.Width = 100;
            columnHeader4.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            ColumnHeader columnHeader5 = new ColumnHeader();
            columnHeader5.Text = "ID";
            columnHeader5.TextAlign = HorizontalAlignment.Left;
            columnHeader5.Width = 100;
            columnHeader5.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);


            CodexNotificationsListViews.Columns.Clear();
            CodexNotificationsListViews.Columns.Add(columnHeader1);
            CodexNotificationsListViews.Columns.Add(columnHeader2);
            CodexNotificationsListViews.Columns.Add(columnHeader3);
            CodexNotificationsListViews.Columns.Add(columnHeader4);
            CodexNotificationsListViews.Columns.Add(columnHeader5);


            CodexNotificationsListViews.HeaderStyle = ColumnHeaderStyle.None;
            CodexNotificationsListViews.HeaderStyle = ColumnHeaderStyle.Clickable;




            foreach (var item in _notificationList)
            {

                String WhenStr = "";
                String BeforeDateStr = "";
                if (item.on_date_remind_before > 0) BeforeDateStr = $" {item.on_date_remind_before} დღით ადრე";
                if (item.notification_condition_type == 0) WhenStr = DateToGString((DateTime)item.on_date) + BeforeDateStr; 
                else WhenStr = "OnUpdate";
                var listviewitem = new ListViewItem(new string[] { item.nt_id.ToString(), AppInttoString(item.on_app) + ":", item.document_title, WhenStr, item.on_document_id.ToString() }, item.on_app);
                CodexNotificationsListViews.Items.Add(listviewitem);
            }

            CodexNotificationsListViews.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //CodexNotificationsListViews.Columns[0].Width = 0;


            CodexNotificationsListViews.ResumeLayout();
        }

        public void Populate(List<DSLightNotificationRecord> list)
        {
            _notificationList = list;
            PopulateUI();
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            Close();
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
            var notification = GetById(id);
            if (notification != null)
            {
                ReminderCaptionLable.Text = notification.notification_caption;
                ultraLabel3.Text = "";

                if (notification.notification_condition_type == 0)
                {
                    string s = "";
                    if (notification.on_date  != null) s = DateToGString((DateTime)notification.on_date);//.ToString();
                    ConditionAndAppLabel.Text = s;
                    ultraLabel3.Text = "";
                    if (notification.on_date_remind_before != null)
                    {
                        if (notification.on_date_remind_before > 0)
                        {
                            ultraLabel3.Text = $" {notification.on_date_remind_before} დღით ადრე";
                        }


                    }

                }
                else
                {
                    ConditionAndAppLabel.Text = "დოკუმენტის გადატანისას განახლების სიაში";
                }
                DocumentTitleLabel.Text = notification.document_title;
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

        private void Reminders_Load(object sender, EventArgs e)
        {
            _notificationList = DSLightNotificationManager.instance.GetAllNotifications();
            if (_notificationList == null) { MessageBox.Show("შეხსენებების სია ცარიელია"); Close(); return; }
            if (_notificationList?.Count == 0) { MessageBox.Show("შეხსენებების სია ცარიელია"); Close(); return; }
            DocumentTitleLabel.Text = "";
            ConditionAndAppLabel.Text = "";
            ultraLabel3.Text = "";
            ReminderCaptionLable.Text = "";

            PopulateUI();
            SystemSounds.Beep.Play();
        }

       

        private void RefreshData()
        {
            _notificationList = DSLightNotificationManager.instance.GetAllNotifications(); 
            if (_notificationList == null) { MessageBox.Show("შეხსენებების სია ცარიელია"); Close(); return; }
            if (_notificationList?.Count == 0) { MessageBox.Show("შეხსენებების სია ცარიელია"); Close(); return; }
            PopulateUI();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            CodexNotificationsListViews_DoubleClick(sender, e);
        }

        private void Test()
        {
            DSLightNotificationRecord c1 = new DSLightNotificationRecord()
            {
                notification_caption = "შესატანია ცვლილება",
                notification_condition_type = 0,
                document_title = "კანონი 2013 წლის N 243",
                
                on_document_id = 343,
                on_app = 0,
                on_date = new DateTime(2013, 3, 2),
                on_date_remind_before = 2
            };

            DSLightNotificationRecord c2 = new DSLightNotificationRecord()
            {
                notification_caption = "წასაშლელია რაღაცეები ცვლილება",
                notification_condition_type = 0,
                document_title = "ბრძანება 2009 წლის N 23343",
                
                on_document_id = 443,
                on_app = 0,
                on_date = new DateTime(2013, 3, 2),
                on_date_remind_before = 2
            };

            DSLightNotificationRecord c3 = new DSLightNotificationRecord()
            {
                notification_caption = "ცხრილის განახლება რაღაცეები ცვლილება",
                notification_condition_type = 1,
                document_title = "ბრძანება 2013 წლის N 8888",
                
                on_document_id = 4443,
                on_app = 0,
                on_date = new DateTime(2013, 3, 2),
                on_date_remind_before = 2
            };

            _notificationList.Clear();
            _notificationList.Add(c1);
            _notificationList.Add(c2);
            _notificationList.Add(c3);

        }
        private void CodexNotificationsListViews_Click(object sender, EventArgs e)
        {

        }

        private void CodexNotificationsListViews_DoubleClick(object sender, EventArgs e)
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

        #region DateTimeG
        private int DaysinMonth(int Month, int Year)
        {
            int Count = 0;
            switch (Month)
            {
                case 1: Count = 31; break;
                case 2: Count = 28; if (((Year % 4) == 0) && (Year != 1900)) Count = 29; break;
                case 3: Count = 31; break;
                case 4: Count = 30; break;
                case 5: Count = 31; break;
                case 6: Count = 30; break;
                case 7: Count = 31; break;
                case 8: Count = 31; break;
                case 9: Count = 30; break;
                case 10: Count = 31; break;
                case 11: Count = 30; break;
                case 12: Count = 31; break;
            }
            return Count;
        }
        private static String MonthToString(int Month)
        {
            String Str = "";
            switch (Month)
            {
                case 1: Str = "იანვარი"; break;
                case 2: Str = "თებერვალი"; break;
                case 3: Str = "მარტი"; break;
                case 4: Str = "აპრილი"; break;
                case 5: Str = "მაისი"; break;
                case 6: Str = "ივნისი"; break;
                case 7: Str = "ივლისი"; break;
                case 8: Str = "აგვისტო"; break;
                case 9: Str = "სექტემბერი"; break;
                case 10: Str = "ოქტომბერი"; break;
                case 11: Str = "ნოემბერი"; break;
                case 12: Str = "დეკემბერი"; break;
            }
            return Str;

        }

        private static int StringToMonth(String Month)
        {
            int Ret = 0; ;
            switch (Month)
            {
                case "იანვარი": Ret = 1; break;
                case "თებერვალი": Ret = 2; break;
                case "მარტი": Ret = 3; break;
                case "აპრილი": Ret = 4; break;
                case "მაისი": Ret = 5; break;
                case "ივნისი": Ret = 6; break;
                case "ივლისი": Ret = 7; break;
                case "აგვისტო": Ret = 8; break;
                case "სექტემბერი": Ret = 9; break;
                case "ოქტომბერი": Ret = 10; break;
                case "ნოემბერი": Ret = 11; break;
                case "დეკემბერი": Ret = 12; break;
            }
            return Ret;

        }


        // Calendat Info




        public String DateToGString(DateTime D)
        {
            return D.Day.ToString() + " " + MonthToString(D.Month) + " " + D.Year.ToString();
        }
        #endregion
    }
}
