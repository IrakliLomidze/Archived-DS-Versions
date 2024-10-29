// ******************************************************************************
// Codex 365 Local Favorite Manager
// (C) Copyright 2007-2023 By Georgian Microsystems 
// (C) Copyright 2007-2023 By Irakli Lomidze 
// ******************************************************************************
// DateTime : 2023/05/13
// DateTime : 2023/06/11



using DS.Configurations;
using ILG.DS.AppStateManagement;
using ILG.DS.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ILG.DS.Notification.Visited
{
    public class DSVisitedNotificationManager
    {
        public static int Version = 1;
        public static int MinorVersion = 0;

        public static int MaxDate = 30; // Day

        private static volatile DSVisitedNotificationManager _state;
        private static object syncRoot = new Object();
        private bool _isInitiized = false;
        public bool IsInitiized { get => _isInitiized; }
        public static DSVisitedNotificationManager instance
        {
            get
            {
                if (_state == null)
                {
                    lock (syncRoot)
                    {
                        if (_state == null)
                            _state = new DSVisitedNotificationManager();
                    }
                }

                return _state;
            }
        }
        public List<DSVisited> _datacontexts { get; set; } = null;

        private DSVisitedNotificationManager()
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
            var s = Path.Combine(getStoragePath(), $"dsvisited_{app.state.DS_Profile_Id.Trim().ToLower()}_v.json");
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
            if ( !File.Exists(sourcefile))
            {
                string jsonString = JsonSerializer.Serialize(_datacontexts, options);
                File.WriteAllText(sourcefile, jsonString);
                return true;
            }
            string t_sourcefile = Path.Combine(getStoragePath(), $"dsvisited_{app.state.DS_Profile_Id.Trim().ToLower()}_v.{DateTime.Now.Ticks}.json");
            string l_sourcefile = Path.Combine(getStoragePath(), $"dsvisited_{app.state.DS_Profile_Id.Trim().ToLower()}_v.last.json");

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
                _datacontexts = new List<DSVisited>();
                _writeToFile_save();
            }
        }

        public bool ReadNotifications()
        {
            List<DSVisited> result = null;
            try
            {
                CreateIfNotExists();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                string jsonString = File.ReadAllText(getStorageFilename());

                result = JsonSerializer.Deserialize<List<DSVisited>>(jsonString, options);
                _datacontexts = new List<DSVisited>();
                _datacontexts.AddRange(result);

                return true;
            }
            catch (Exception ex)
            { 
                
                // Keey _datacontexts intact
                if (_datacontexts == null) _datacontexts = new List<DSVisited>();
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

        public void AddVisitedDocument(int id)
        {
            CheckIfNeedToRead();
            int offset = DSBehaviorConfiguration.Instance.content.NewDocumentNotification.new_document_notification;
            DateTime monthago = DateTime.Now - TimeSpan.FromDays(offset);
            _datacontexts = _datacontexts.Where(w => (w.v_date >= monthago)).ToList<DSVisited>();
            if (!_datacontexts.Exists(w => w.doc_id == id)) _datacontexts.Add(new DSVisited() { doc_id = id, v_date = DateTime.Now });
            WriteConfiguration();
        }


        public List<int> Check(List<int> newdocuments)
        {
            CheckIfNeedToRead();
            List<int> result = new List<int>();
            foreach(int document in newdocuments) 
            { 
               if (_datacontexts.Where(w=>w.doc_id == document).FirstOrDefault() == null)
                {
                    result.Add(document);
                }
            }
            return result;
        }


        public void DeleteAllRecords()
        {
            CheckIfNeedToRead();
            _datacontexts = new List<DSVisited>();
            {
                WriteConfiguration();
            }
        }



        #endregion documents


        
    }

    

    public class DSVisited
    {
        public int doc_id { get; set; }
        public DateTime v_date { get; set; }
    }
    

    
}
 
