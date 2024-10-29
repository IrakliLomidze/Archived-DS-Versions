using ILG.DS.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.DS.Notifications
{
    public class NotificationQuery
    {
        List<DSLightNotificationRecord> _notifications;
        
        public NotificationQuery(List<DSLightNotificationRecord> notifications)
        {
            _notifications = notifications;
        }

        public List<DSLightNotificationRecord> GetAllForToday()
        {
            List<DSLightNotificationRecord> result = new List<DSLightNotificationRecord>();
            foreach (var item in _notifications)
            {
                if (item.notification_condition_type == 0)
                {
                    DateTime d = (DateTime)item.on_date;
                    if (item.on_date_remind_before > 0) d = d.Subtract(TimeSpan.FromDays((int)item.on_date_remind_before));

                    if (DateTime.Now.Date >= d.Date) result.Add(item);
                }
            }
            return result;
        }

        public List<DSLightNotificationRecord> GetNotificationsForDocuemtId(int doc_id, bool forToday = true)
        {
            List<DSLightNotificationRecord> result = new List<DSLightNotificationRecord>();
            foreach (var item in _notifications)
            {
                if ((item.notification_condition_type == 0) && (item.on_document_id == doc_id))
                {
                    if (forToday)
                    {
                        DateTime d = (DateTime)item.on_date;
                        if (item.on_date_remind_before > 0) d = d.Subtract(TimeSpan.FromDays((int)item.on_date_remind_before));

                        if (DateTime.Now.Date >= d.Date) result.Add(item);
                    }
                    else
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public List<DSLightNotificationRecord> GetAll()
        {
            List<DSLightNotificationRecord> result = new List<DSLightNotificationRecord>();
            return result;
        }

        public bool IsToday()
        {
            bool result = false;
            foreach (var item in _notifications)
            {
                if (item.notification_condition_type == 0)
                {
                    DateTime d = (DateTime)item.on_date;
                    if (item.on_date_remind_before > 0) d = d.Subtract(TimeSpan.FromDays((int)item.on_date_remind_before));

                    if (DateTime.Now.Date >= d.Date) { result = true; break; }
                }
            }
            return result;
        }

        public List<DSLightNotificationRecord> GetAllForParticularDate(DateTime SpecificDate)
        {
            List<DSLightNotificationRecord> result = new List<DSLightNotificationRecord>();
            foreach (var item in _notifications)
            {
                if (item.notification_condition_type == 0)
                {
                    DateTime d = (DateTime)item.on_date;
                    if (item.on_date_remind_before > 0) d.Subtract(TimeSpan.FromDays((int)item.on_date_remind_before));

                    if (SpecificDate.Date >= d.Date) result.Add(item);
                }
            }
            return result;
        }

       
        public List<DSLightNotificationRecord> GetAllForParticularDocument(int pApp, int pDocId)
        {
            List<DSLightNotificationRecord> result = new List<DSLightNotificationRecord>();
            foreach (var item in _notifications)
            {
                if (/*(item.on_app == pApp) &&*/ (item.on_document_id == pDocId))
                {
                    result.Add(item);
                }
            }
            return result;
        }

    }

    public enum NotificationQueryEnum
    {
        All,
        AllForToday,
        AllForDate,
        AllForDocument
    }
}
