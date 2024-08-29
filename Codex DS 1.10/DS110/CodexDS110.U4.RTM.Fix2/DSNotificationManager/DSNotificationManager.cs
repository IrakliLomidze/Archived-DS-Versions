// ******************************************************************************
// Codex 365 Local Favorite Manager
// (C) Copyright 2007-2023 By Georgian Microsystems 
// (C) Copyright 2007-2023 By Irakli Lomidze 
// ******************************************************************************
// DateTime : 2023/05/13



using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;


namespace ILG.DS.Notification
{
    public class DSNotificationManager
    {
        public static int Version = 1;
        public static int MinorVersion = 0;

        private static volatile DSNotificationManager _state;
        private static object syncRoot = new Object();
        private bool _isInitiized = false;
        public bool IsInitiized { get => _isInitiized; }
        public static DSNotificationManager instance
        {
            get
            {
                if (_state == null)
                {
                    lock (syncRoot)
                    {
                        if (_state == null)
                            _state = new DSNotificationManager();
                    }
                }

                return _state;
            }
        }



        private DSNotificationManager()
        {
            CreateEmptyStorageIfNotExists();
        }

        private string getStoragePath()
        {
            string apppath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GeorgianMicrosystems");
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
            return $"dsnotification_{app.state.DS_Profile_Id.Trim().ToLower()}.dsntfdb";
        }
        private string createStorageTables()
        {
            return
            "CREATE TABLE notifications (                                " + Environment.NewLine +
            "      nt_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,     " + Environment.NewLine +
            "      creation_date TEXT,                                   " + Environment.NewLine +
            "      notification_type INTEGER NOT NULL,                   " + Environment.NewLine +
            "      notification_caption TEXT NOT NULL,                   " + Environment.NewLine +
            "      notification_description BLOB ,                       " + Environment.NewLine +
            "      document_id INTEGER NOT NULL,                         " + Environment.NewLine +
            "      document_title TEXT,                                  " + Environment.NewLine +
            "      on_date TEXT,                                         " + Environment.NewLine +
            "      on_date_remind_before INTEGER,                        " + Environment.NewLine +
            "      attachment BLOB,                                      " + Environment.NewLine +
            "      attachment_size INTEGER,                              " + Environment.NewLine +
            "      attachment_filename TEXT,                             " + Environment.NewLine +
            "      on_app_id INTEGER NOT NULL,                           " + Environment.NewLine +
            "      notification_condition_type INTEGER ,                 " + Environment.NewLine +
            "      notification_repeatable INTEGER ,                     " + Environment.NewLine +
            "      display_order REAL NOT NULL                           " + Environment.NewLine +
            "                    );                                      " + Environment.NewLine +
            "" + Environment.NewLine +
            "CREATE INDEX nt_index ON notifications(nt_id);                  " + Environment.NewLine +
            "CREATE INDEX nt_index2 ON notifications(on_document_id);        " + Environment.NewLine +
            "CREATE INDEX nt_index3 ON notifications(on_date);               " + Environment.NewLine +
            "" + Environment.NewLine +
            "CREATE TABLE visited(                                       " + Environment.NewLine +
            "      doc_id INTEGER  NOT NULL                              " + Environment.NewLine +
            "      v_date TEXT,                                            " + Environment.NewLine +
            "                    );                                      " + Environment.NewLine +
            "" + Environment.NewLine +
            "CREATE INDEX vis_index  ON visited(doc_id);                  " + Environment.NewLine +
            "CREATE INDEX vis_index2 ON visited(v_date);                  " + Environment.NewLine +
            "";

        }


        private void ExcecuteSqliteStatment(string sqlcommand)
        {
            String SQLCommand = sqlcommand;

            string f = Path.Combine(getStoragePath(), getStorageFilename());
            try
            {
                using (SqliteConnection cn = new SqliteConnection($"Data Source = '{f}'; Version = 3;"))
                {
                    cn.Open();
                    using (SqliteCommand cm = new SqliteCommand(SQLCommand, cn))
                    {
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch //(Exception ex)
            {

            }
        }


        public void CreateEmptyStorageIfNotExists()
        {
            string f = Path.Combine(getStoragePath(), getStorageFilename());
            if (!File.Exists(f))
            {

                SQLiteConnection.CreateFile(f);
                using (SQLiteConnection cn = new SQLiteConnection($"Data Source = '{f}'; Version = 3;"))
                {
                    cn.Open();
                    using (SqliteCommand cm = new SqliteCommand(createStorageTables(), cn))
                    {
                        cm.ExecuteNonQuery();
                    }
                }

            }
        }


        private string GetConnectionString()
        {
            string f = Path.Combine(getStoragePath(), getStorageFilename());
            return $"Data Source = '{f}'; Version = 3;";
        }



        #region Notification




    

        public void NewNotification(DSNotificationRecord record)
        {
            //CreateNotificationInsertCommands();
            //Notification_Insert_Command.Connection = new SQLiteConnection(GetConnectionString());
            //Notification_Insert_Command.Parameters["@creation_date"].Value = DateTime.Now;
            //Notification_Insert_Command.Parameters["@notification_type"].Value = record.notification_type;
            //Notification_Insert_Command.Parameters["@notification_caption"].Value = record.notification_caption ?? "";
            //Notification_Insert_Command.Parameters["@notification_description"].Value = record.notification_description;
            //Notification_Insert_Command.Parameters["@document_id"].Value = record.on_document_id;
            //Notification_Insert_Command.Parameters["@document_title"], DbType.String, "document_title"));
            //Notification_Insert_Command.Parameters["@on_date"], DbType.DateTime, "on_date"));
            //Notification_Insert_Command.Parameters["@on_date_remind_before"], DbType.Int64, "on_date_remind_before"));
            ////Notification_Insert_Command.Parameters["@attachment", DbType.Binary, "attachment"));
            ////Notification_Insert_Command.Parameters["@attachment_size", DbType.Int64, "attachment_size"));
            ////Notification_Insert_Command.Parameters["@attachment_filename", DbType.String, "attachment_filename"));
            //Notification_Insert_Command.Parameters["@on_app_id"], DbType.Int64, "on_app_id"));
            //Notification_Insert_Command.Parameters["@notification_condition_type"], DbType.Int64, "notification_condition_type"));
            //Notification_Insert_Command.Parameters["@notification_repeatable"], DbType.Int64, "notification_repeatable"));
            //Notification_Insert_Command.Parameters["@display_order"], DbType.Double, "display_order")) ;

            using (var db = new DSNotificationDBContext(GetConnectionString()))
            {
                db.Notifications.Add(record);
                db.SaveChanges();
            }
        }

        public void UpdateNotification(DSNotificationRecord record)
        {
            using (var db = new DSNotificationDBContext(GetConnectionString()))
            {
                db.Notifications.Attach(record);
                db.SaveChanges();
            }
        }

        public void RemoveNotification(int nt_id)
        {
            String SQLCommand = $"DELETE FROM notifications WHERE nt_id = {nt_id}";
            ExcecuteSqliteStatment(SQLCommand);
        }

        public List<DSNotificationRecord> GetAllNotifications()
        {
            List<DSNotificationRecord> Result = new List<DSNotificationRecord>();
            string SQL = "SELECT * FROM notifications";
            using (var db = new DSNotificationDBContext(GetConnectionString()))
            {
                return db.Notifications.AsNoTracking().ToList();
            }
        }

        public DSNotificationRecord GetNotificationById(int id)
        {
            using (var db = new DSNotificationDBContext(GetConnectionString()))
            {
                return db.Notifications.AsNoTracking().Where(w => w.nt_id == id).FirstOrDefault();
            }
        }



        public bool DeleteAllRecords()
        {
            String SQLCommand = "DELETE FROM notifications; " + System.Environment.NewLine +
                                 "DELETE FROM visited WHERE folder_id <> 0;";

            string f = Path.Combine(getStoragePath(), getStorageFilename());

            try
            {

                using (SqliteConnection cn = new SqliteConnection($"Data Source = '{f}'; Version = 3;"))
                {
                    cn.Open();
                    using (SQLiteCommand cm = new SQLiteCommand(SQLCommand, cn))
                    {
                        cm.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch //(Exception ex)
            {
                return false;
            }
        }

        #endregion documents



    }

    class DSNotificationDBContext : DbContext
    {
        public DbSet<DSNotificationRecord> Notifications { get; set; }
        public DbSet<DSVisited> Visited { get; set; }

        public DSNotificationDBContext(string cn)
             : base(new SQLiteConnection(cn), true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Map entity to table
            modelBuilder.Entity<DSNotificationRecord>().ToTable("notifications");
            modelBuilder.Entity<DSVisited>().ToTable("visited");
        }
    }


    public class DSNotificationRecord
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

        public byte[] attachment { get; set; }
        public int attachment_size { get; set; }
        public string attachment_filename { get; set; }

        public int notification_condition_type { get; set; }
        public int notification_repeatable { get; set; }
        public float diplay_order { get; set; }
    }

    public class DSVisited
    {
        public int doc_id { get; set; }
        public DateTime v_date { get; set; }
    }


}

