// *************************************************************************************
// ** DS Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** DS User Configurations
// ** Version 2.0
// ** Date 2023/04/09


using System;

namespace DSCommon.Configurations
{
    public class UserSQLConfigurationContext
    {
        public Version db_connection_strucutre_version { get; set; } = new Version(1, 0);
        public string db_host { get; set; }
        public string db_port { get; set; }
        public string db_usefulltext { get; set; }
        public string db_connectiontimeout { get; set; }
        public string db_connectionstring { get; set; }

        public UserSQLConfigurationContext()
        {
            
        }

        public void AssingNewConfiguraiton(UserSQLConfigurationContext newconfig)
        {
            db_connection_strucutre_version = newconfig.db_connection_strucutre_version;
            db_host = newconfig.db_host;
            db_port = newconfig.db_port;
            db_usefulltext = newconfig.db_usefulltext;
            db_connectiontimeout = newconfig.db_connectiontimeout;
            db_connectionstring = newconfig.db_connectionstring;
        }

        public void GenerateSQLConnectionString()
        {

        }
    }
}



