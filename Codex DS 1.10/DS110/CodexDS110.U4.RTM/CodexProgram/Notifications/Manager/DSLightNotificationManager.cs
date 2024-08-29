// ******************************************************************************
// Codex 365 Local Favorite Manager
// (C) Copyright 2007-2023 By Georgian Microsystems 
// (C) Copyright 2007-2023 By Irakli Lomidze 
// ******************************************************************************
// DateTime : 2023/05/13
// DateTime : 2023/06/01




using ILG.DS.AppStateManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.XPath;

namespace ILG.DS.Notification
{
    public class DSLightNotificationManager
    {
        public static int Version = 1;
        public static int MinorVersion = 0;

        private static volatile DSLightNotificationManager _state;
        private static object syncRoot = new Object();
        private bool _isInitiized = false;
        public bool IsInitiized { get => _isInitiized; }
        public static DSLightNotificationManager instance
        {
            get
            {
                if (_state == null)
                {
                    lock (syncRoot)
                    {
                        if (_state == null)
                            _state = new DSLightNotificationManager();
                    }
                }

                return _state;
            }
        }
        public List<DSLightNotificationRecord> _datacontexts { get; set; } = null;

        private DSLightNotificationManager()
        {
            CreateIfNotExists();
            ReadNotifications();
        }

        private string getStoragePath()
        {
            string apppath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DocumentStorage");
            if (!Directory.Exists(apppath)) Directory.CreateDirectory(apppath);
            
            string codexpath = Path.Combine(apppath, "DS");
            if (!Directory.Exists(codexpath)) Directory.CreateDirectory(codexpath);

            string datapath = Path.Combine(codexpath, "10");
            if (!Directory.Exists(datapath)) Directory.CreateDirectory(datapath);

            string verpath = Path.Combine(datapath, "data");
            if (!Directory.Exists(verpath)) Directory.CreateDirectory(verpath);

            return verpath;
        }
        private string getStorageFilename()
        {
            //return $"dsnotification_{app.state.DS_Profile_Id.Trim().ToLower()}_dsntf.json";
            var s = Path.Combine(getStoragePath(), $"dsnotification_{app.state.DS_Profile_Id.Trim().ToLower()}_dsntf.json");
            return s;
        }

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        private bool _writeToFile_save()
        {
            bool brinback = false;
            string sourcefile = getStorageFilename();
            if (!File.Exists(sourcefile))
            {
                string jsonString = JsonSerializer.Serialize(_datacontexts, options);
                File.WriteAllText(sourcefile, jsonString);
                return true;
            }
            string t_sourcefile = Path.Combine(getStoragePath(), $"dsnotification_{app.state.DS_Profile_Id.Trim().ToLower()}_dsntf.{DateTime.Now.Ticks}.json");
            string l_sourcefile = Path.Combine(getStoragePath(),  $"dsnotification_{app.state.DS_Profile_Id.Trim().ToLower()}_dsntf.last.json");
            try
            {
                // Json Deseralization Operation
                string jsonString = JsonSerializer.Serialize(_datacontexts, options);
                File.Copy(sourcefile, t_sourcefile, true);
                brinback = true;
                File.WriteAllText(getStorageFilename(), jsonString);
                if (File.Exists(l_sourcefile)) File.Delete(l_sourcefile);
                File.Move(t_sourcefile, l_sourcefile);
                return true;
            } 
            catch (Exception ex)
            {
                if (brinback == true)
                {
                    if (File.Exists(l_sourcefile))
                    {
                        if (File.Exists(l_sourcefile)) File.Delete(l_sourcefile);
                        File.Move(l_sourcefile, sourcefile);
                    }
                }
                return false;
            }
            
        }

        private void CreateIfNotExists()
        {
            if (File.Exists(getStorageFilename()) == false)
            {
                _datacontexts = new List<DSLightNotificationRecord>();
                _writeToFile_save();
            }
        }

        public bool ReadNotifications()
        {
            List<DSLightNotificationRecord> result = null;
            try
            {
                CreateIfNotExists();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                string jsonString = File.ReadAllText(getStorageFilename());

                result = JsonSerializer.Deserialize<List<DSLightNotificationRecord>>(jsonString, options);
                _datacontexts = new List<DSLightNotificationRecord>();
                if (result != null)
                {
                    _datacontexts = result.ToList();
                }

                return true;
            }
            catch (Exception) { 
                
                // Keey _datacontexts intact
                if (_datacontexts == null) _datacontexts = new List<DSLightNotificationRecord>();
                return false;
            }

        }

        public void WriteConfiguration()
        {
            _writeToFile_save();
        }

        private void CheckIfNeedToRead()
        {
            if (_datacontexts == null) { ReadNotifications(); }
        }
      
        

        
        #region Notification
        public void NewNotification(DSLightNotificationRecord record)
        {
            CheckIfNeedToRead();
            int max = 0;
            if (_datacontexts.Count() > 0)
              max = _datacontexts.Select(n => n.nt_id).Max();
            record.nt_id = max+1;
            
            _datacontexts.Add(record);
            WriteConfiguration();
        }

        public void UpdateNotification(DSLightNotificationRecord record)
        {
            CheckIfNeedToRead();
            if (_datacontexts.RemoveAll(x => x.nt_id == record.nt_id) > 0)
            {
                _datacontexts.Add(record);
                WriteConfiguration();
            }
        }

        public void RemoveNotification(int nt_id)
        {
            CheckIfNeedToRead();
            if (_datacontexts.RemoveAll(x => x.nt_id == nt_id) > 0)
            {
                WriteConfiguration();
            }
        }

        public List<DSLightNotificationRecord> GetAllNotifications()
        {
            CheckIfNeedToRead();
            List<DSLightNotificationRecord> Result = new List<DSLightNotificationRecord>();
            
            return _datacontexts.ToList();
        }

        public List<DSLightNotificationRecord> GetAllNotificationsForDocument(int Id)
        {
            CheckIfNeedToRead();
            List<DSLightNotificationRecord> Result = new List<DSLightNotificationRecord>();

            return _datacontexts.Where(w=>w.on_document_id == Id).ToList();
        }

        public DSLightNotificationRecord GetNotificationById(int id)
        {
            CheckIfNeedToRead();
            return _datacontexts.Where(w => w.nt_id == id).FirstOrDefault();
        }



        public void DeleteAllRecords()
        {
            CheckIfNeedToRead();
            _datacontexts = new List<DSLightNotificationRecord>();
            {
                WriteConfiguration();
            }
        }

        #endregion documents


        public bool IsNotificationsForDocuemtId(int doc_id, bool forToday = true)
        {
            CheckIfNeedToRead();
            List<DSLightNotificationRecord> result = new List<DSLightNotificationRecord>();
            foreach (var item in _datacontexts)
            {
                if ((item.notification_condition_type == 0) && (item.on_document_id == doc_id))
                {
                    if (forToday)
                    {
                        DateTime d = (DateTime)item.on_date;
                        if (item.on_date_remind_before > 0) d = d.Subtract(TimeSpan.FromDays((int)item.on_date_remind_before));

                        if (DateTime.Now.Date >= d.Date) return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public List<DSLightNotificationRecord> GetNotificationsForDocuemtId(int doc_id, bool forToday = true)
        {
            CheckIfNeedToRead();
            List<DSLightNotificationRecord> result = new List<DSLightNotificationRecord>();
            foreach (var item in _datacontexts)
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

        public List<DSLightNotificationRecord> GetNotificationsForToday()
        {
            CheckIfNeedToRead();
            List<DSLightNotificationRecord> result = new List<DSLightNotificationRecord>();
            foreach (var item in _datacontexts)
            {
                if ((item.notification_condition_type == 0))
                {
                    
                        DateTime d = (DateTime)item.on_date;
                        if (item.on_date_remind_before > 0) d = d.Subtract(TimeSpan.FromDays((int)item.on_date_remind_before));

                        if (DateTime.Now.Date >= d.Date) result.Add(item);
                    
                }
            }
            return result;

        }

        public int CountNotificationsForToday()
        {
            CheckIfNeedToRead();
            int result = 0;
            foreach (var item in _datacontexts)
            {
                DateTime d = (DateTime)item.on_date;
                if (item.on_date_remind_before > 0) d = d.Subtract(TimeSpan.FromDays((int)item.on_date_remind_before));

                if (DateTime.Now.Date >= d.Date) result++;

            }
            return result;
        }



    }


    public class DSLightNotificationRecord
    {
        public int nt_id { get; set; }
        public DateTime creation_date { get; set; }
        public int notification_type { get; set; }
        public string notification_caption { get; set; }
        public byte[] notification_description { get; set; }
        public int on_document_id { get; set; }
        public string document_title { get; set; }
        public DateTime? on_date { get; set; }
        public int? on_date_remind_before { get; set; }
        public int on_app { get; set; }

        //public byte[] attachment { get; set; }
        //public int attachment_size { get; set; }
        //public string attachment_filename { get; set; }

        public int notification_condition_type { get; set; }
        public int notification_repeatable { get; set; }
        public float diplay_order { get; set; }

        public DSLightNotificationRecord()
        {
            notification_caption = "";
            notification_description = new byte[0];
            document_title = "";
            on_date_remind_before = 7;
        }
    }

    

    
}
 
