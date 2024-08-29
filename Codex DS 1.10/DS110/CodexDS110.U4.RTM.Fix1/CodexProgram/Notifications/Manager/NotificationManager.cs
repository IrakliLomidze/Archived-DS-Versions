////// ******************************************************************************
////// Codex 365 Local Favorite Manager
////// (C) Copyright 2007-2023 By Georgian Microsystems 
////// (C) Copyright 2007-2023 By Irakli Lomidze 
////// ******************************************************************************
////// DateTime : 2023/05/13



////using ILG.DS.AppStateManagement;
////using System;
////using System.Collections.Generic;
////using System.Data.Entity;
////using System.Data.SQLite;
////using System.IO;
////using System.Linq;


////namespace ILG.DS.Notification
////{
////    public class DSNotificationManager
////    {
////        public static int Version = 1;
////        public static int MinorVersion = 0;

////        private static volatile DSNotificationManager _state;
////        private static object syncRoot = new Object();
////        private bool _isInitiized = false;
////        public bool IsInitiized { get => _isInitiized; }
////        public static DSNotificationManager instance
////        {
////            get
////            {
////                if (_state == null)
////                {
////                    lock (syncRoot)
////                    {
////                        if (_state == null)
////                            _state = new DSNotificationManager();
////                    }
////                }

////                return _state;
////            }
////        }


////        private DSNotificationManager()
////        {
////            CreateEmptyStorageIfNotExists();
////        }

////        private string getStoragePath()
////        {
////            string apppath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GeorgianMicrosystems");
////            if (!Directory.Exists(apppath)) Directory.CreateDirectory(apppath);
            
////            string codexpath = Path.Combine(apppath, "DS");
////            if (!Directory.Exists(codexpath)) Directory.CreateDirectory(codexpath);

////            string datapath = Path.Combine(codexpath, "10");
////            if (!Directory.Exists(datapath)) Directory.CreateDirectory(datapath);

////            string verpath = Path.Combine(datapath, "data");
////            if (!Directory.Exists(verpath)) Directory.CreateDirectory(verpath);

////            return verpath;
////        }
////        private string getStorageFilename()
////        {
////            return $"dsnotification_{app.state.DS_Profile_Id.Trim().ToLower()}.dsntfdb";
////        }
////        private string createStorageTables()
////        {
////            return
////            "CREATE TABLE notifications (                                " + Environment.NewLine +
////            "      nt_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,     " + Environment.NewLine +
////            "      creation_date TEXT,                                   " + Environment.NewLine +
////            "      notification_type INTEGER NOT NULL,                   " + Environment.NewLine +
////            "      notification_caption TEXT NOT NULL,                   " + Environment.NewLine +
////            "      notification_description BLOB ,                       " + Environment.NewLine +
////            "      document_id INTEGER NOT NULL,                         " + Environment.NewLine +
////            "      document_title TEXT,                                  " + Environment.NewLine +
////            "      on_date TEXT,                                         " + Environment.NewLine +
////            "      on_date_remind_before INTEGER,                        " + Environment.NewLine +
////            "      attachment BLOB,                                      " + Environment.NewLine +
////            "      attachment_size INTEGER,                              " + Environment.NewLine +
////            "      attachment_filename TEXT,                             " + Environment.NewLine +
////            "      on_app_id INTEGER NOT NULL,                           " + Environment.NewLine +
////            "      notification_condition_type INTEGER ,                 " + Environment.NewLine +
////            "      notification_repeatable INTEGER ,                     " + Environment.NewLine +
////            "      display_order REAL NOT NULL                           " + Environment.NewLine +
////            "                    );                                      " + Environment.NewLine +
////            ""                                                             + Environment.NewLine +
////            "CREATE INDEX nt_index ON documents(nt_id);                  " + Environment.NewLine +
////            "CREATE INDEX nt_index2 ON documents(on_document_id);        " + Environment.NewLine +
////            "CREATE INDEX nt_index3 ON documents(on_date);               " + Environment.NewLine +
////            ""                                                             + Environment.NewLine +
////            "CREATE TABLE visited(                                       " + Environment.NewLine +
////            "      doc_id INTEGER  NOT NULL                              " + Environment.NewLine +
////            "      v_date TEXT,                                            " + Environment.NewLine +
////            "                    );                                      " + Environment.NewLine +
////            ""                                                             + Environment.NewLine +
////            "CREATE INDEX vis_index  ON visited(doc_id);                  " + Environment.NewLine +
////            "CREATE INDEX vis_index2 ON visited(v_date);                  " + Environment.NewLine +
////            "";                                                           

////        }


////        private void ExcecuteSqliteStatment(string sqlcommand)
////        {
////            String SQLCommand = sqlcommand;

////            string f = Path.Combine(getStoragePath(), getStorageFilename());
////            try
////            {
////                using (SQLiteConnection cn = new SQLiteConnection($"Data Source = '{f}'; Version = 3;"))
////                {
////                    cn.Open();
////                    using (SQLiteCommand cm = new SQLiteCommand(SQLCommand, cn))
////                    {
////                        cm.ExecuteNonQuery();
////                    }
////                }
////            }
////            catch //(Exception ex)
////            {

////            }
////        }


////        public void CreateEmptyStorageIfNotExists()
////        {
////            string f = Path.Combine(getStoragePath(), getStorageFilename());
////            if (!File.Exists(f))
////            {
////                SQLiteConnection.CreateFile(f);
////                using (SQLiteConnection cn = new SQLiteConnection($"Data Source = '{f}'; Version = 3;"))
////                {
////                    cn.Open();
////                    using (SQLiteCommand cm = new SQLiteCommand(createStorageTables(), cn))
////                    {
////                        cm.ExecuteNonQuery();
////                    }
////                }

////            }
////        }


////        private string GetConnectionString()
////        {
////            string f = Path.Combine(getStoragePath(), getStorageFilename());
////            return $"Data Source = '{f}'; Version = 3;";
////        }
        

////        #region folders
////        public void AddNewFolder(string folder_name)
////        {
////            String SQLCommand = "INSERT INTO folders (folder_name,   folder_parent_id  , display_order  ) " +
////                                $"VALUES( '{folder_name}', 0, 0 ) ";

////            ExcecuteSqliteStatment(SQLCommand);
////        }

      

////        public void DeleteFolder(int folder_id)
////        {
////            if (folder_id == 0) return;
////            String SQLCommand  = $"DELETE FROM documents WHERE folder_id = {folder_id}; " + System.Environment.NewLine +
////                                 $"DELETE FROM folders WHERE folder_id = {folder_id}; ";

////            ExcecuteSqliteStatment(SQLCommand);
////        }

        



////        #endregion folders

////        #region Notification
////        public void NewNotification(DSNotificationRecord record)
////        {
////            using (var db = new DSNotificationDBContext(GetConnectionString()))
////            {
////                db.Notifications.Add(record);
////                db.SaveChanges();
////            }
////        }

////        public void UpdateNotification(DSNotificationRecord record)
////        {
////            using (var db = new DSNotificationDBContext(GetConnectionString()))
////            {
////                db.Notifications.Attach(record);
////                db.SaveChanges();
////            }
////        }

////        public void RemoveNotification(int nt_id)
////        {
////            String SQLCommand = $"DELETE FROM notifications WHERE nt_id = {nt_id}";
////            ExcecuteSqliteStatment(SQLCommand);
////        }

////        public List<DSNotificationRecord> GetAllNotifications()
////        {
////            List<DSNotificationRecord> Result = new List<DSNotificationRecord>();

////            using (var db = new DSNotificationDBContext(GetConnectionString()))
////            {
////                return db.Notifications.AsNoTracking().ToList();
////            }
////        }

////        public DSNotificationRecord GetNotificationById(int id)
////        {
////            using (var db = new DSNotificationDBContext(GetConnectionString()))
////            {
////                return db.Notifications.AsNoTracking().Where(w => w.nt_id == id).FirstOrDefault();
////            }
////        }



////        public bool DeleteAllRecords()
////        {
////            String SQLCommand  = "DELETE FROM notifications; " + System.Environment.NewLine +
////                                 "DELETE FROM visited WHERE folder_id <> 0;";

////            string f = Path.Combine(getStoragePath(), getStorageFilename());

////            try
////            {
////                using (SQLiteConnection cn = new SQLiteConnection($"Data Source = '{f}'; Version = 3;"))
////                {
////                    cn.Open();
////                    using (SQLiteCommand cm = new SQLiteCommand(SQLCommand, cn))
////                    {
////                        cm.ExecuteNonQuery();
////                    }
////                }
////                return true;
////            }
////            catch //(Exception ex)
////            {
////                return false;
////            }
////        }

////        #endregion documents


        
////    }

    
////    public class DSNotificationRecord
////    {
////        public int nt_id { get; set; }
////        public DateTime creation_date { get; set; }
////        public int notification_type { get; set; }
////        public string notification_caption { get; set; }
////        public byte[] notification_description { get; set; }
////        public int on_document_id { get; set; }
////        public string document_title { get; set; }
////        public DateTime? on_date { get; set; }
////        public int? on_date_remind_before { get; set; }
////        public int on_app { get; set; }

////        public byte[] attachment { get; set; }
////        public int attachment_size { get; set; }
////        public string attachment_filename { get; set; }

////        public int notification_condition_type { get; set; }
////        public int notification_repeatable { get; set; }
////        public float diplay_order { get; set; }
////    }

////    public class DSVisited
////    {
////        public int doc_id { get; set; }
////        public DateTime v_date { get; set; }
////    }
    
////    class DSNotificationDBContext : DbContext
////    {
////        public DbSet<DSNotificationRecord> Notifications { get; set; }
////        public DbSet<DSVisited> Visited { get; set; }

////        public DSNotificationDBContext(string cn)
////             : base(new SQLiteConnection(cn), true)
////        {
            
////        }

////        protected override void OnModelCreating(DbModelBuilder modelBuilder)
////        {

////            //Map entity to table
////            modelBuilder.Entity<DSNotificationRecord>().ToTable("notifications");
////            modelBuilder.Entity<DSVisited>().ToTable("visited");
////        }
////    }

    
////}
 
