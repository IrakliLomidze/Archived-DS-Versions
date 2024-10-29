using DS.Configurations;
using ILG.Codex.CodexR4;
using ILG.DS.Access;
using ILG.DS.Configurations;
using ILG.DS.Controls;
using System;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Windows.Forms;

namespace ILG.DS.AppStateManagement
{
    public sealed class app
    {
        private static volatile app _state;
        private static object syncRoot = new Object();
        private app()
        {
            DSRunTimeLicense dSRunTimeLicense = new DSRunTimeLicense();
            //this.IsSingleApplicationMode = false;
            //this.IsSingleApplicationMode = false;
        }
        public static app state
        {
            get
            {
                if (_state == null)
                {
                    lock (syncRoot)
                    {
                        if (_state == null)
                            _state = new app();
                    }
                }

                return _state;
            }
        }


        internal DSRunTimeLicense RunTimeLicense {get; set;}
        public   UserUIConfigurationManager UISettingsManager;
        public string DS_Profile_Id { private set; get; }
        public string DS_Porfile_DisplayName { private set; get; }

        public bool Show_DS_Profile_Info { set; get; } = true;
        public void SetProfileInformation(string ds_profile_id, string ds_porfile_displayname)
        {
            DS_Profile_Id = ds_profile_id;
            DS_Porfile_DisplayName = ds_porfile_displayname;
            RunTimeLicense = new DSRunTimeLicense();
            RunTimeLicense.SetLicenseAccess(ds_profile_id);
            UISettingsManager = new UserUIConfigurationManager();
        }
        
        public string ConnectionString { set; get; }
        public bool UseFullTextSearch { set; get; }
        public bool InternalMode { get; set; }
        public int Current_Keyboard_Layout = 0;//4 DSKeyboardLayout.KEYBOARD_WINDOWS;

        public bool isconnecting(string connctionstring)
        {
            
            SqlConnection test = new SqlConnection(connctionstring);
            bool SQLConnected = false;
            try
            {
                test.Open();
                SQLConnected = true;
            }
            catch (Exception ex)
            {
                SQLConnected = false;
                throw ex;
            }

            finally
            {
                if (test.State == System.Data.ConnectionState.Open)
                {
                    test.Close();
                }
            }
            return SQLConnected;
        }




    }
}