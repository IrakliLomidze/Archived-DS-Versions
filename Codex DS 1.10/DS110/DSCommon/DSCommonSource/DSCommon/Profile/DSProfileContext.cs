// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Profile
// ** Date: 2023-04-05
// ** Version 1.1


using System;


namespace ILG.DS.Profile
{
    public class DSProfileContent
    {
        public Version ds_profile_version { get; set; } = new Version(1, 0);
        public string ds_profile_name { get; set; }
        public string ds_display_name { get; set; }
        public string ds_db_version { get; set; }
        public string ds_db_name { get; set; }
        public string ds_auth_type { get; set; }
        public string ds_sql_sqluser_username { get; set; }
        public string ds_sql_sqluser_password { get; set; }


        public DSProfileContent()
        {
        }

        public void AssingNewConfiguraiton(DSProfileContent newconfig)
        {
            ds_profile_version = newconfig.ds_profile_version;
            ds_profile_name = newconfig.ds_profile_name;
            ds_display_name = newconfig.ds_display_name;
            ds_db_version = newconfig.ds_db_version;
            ds_db_name = newconfig.ds_db_name;
            ds_auth_type = newconfig.ds_auth_type;
            ds_sql_sqluser_username = newconfig.ds_sql_sqluser_username;
            ds_sql_sqluser_password = newconfig.ds_sql_sqluser_password;
        }
    }

}

