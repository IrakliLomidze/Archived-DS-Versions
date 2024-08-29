// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Profile
// ** Date: 2023-04-06
// ** Version 1.0

using DS.Config.Encryption;
using DSCommon.Configurations;
using ILG.DS.Configurations.Profile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ILG.DS.Profile
{
    public class UserSQLConfigurationHelper
    {
        static public UserSQLConfigurationContext UserConfigEncryption(UserSQLConfigurationContext data)
        {
            UserSQLConfigurationContext result = new UserSQLConfigurationContext();
            result.db_connection_strucutre_version = data.db_connection_strucutre_version;
            result.db_host = data.db_host;
            result.db_port = data.db_port;
            result.db_usefulltext = data.db_usefulltext;
            result.db_connectiontimeout = data.db_connectiontimeout;
            if (String.IsNullOrEmpty(data.db_connectionstring)) result.db_connectionstring = "";
            else result.db_connectionstring = DSCryptoString.EncryptString(data.db_connectionstring);
            return result;
        }

        static public UserSQLConfigurationContext UserConfigDecryption(UserSQLConfigurationContext data)
        {
            UserSQLConfigurationContext result = new UserSQLConfigurationContext();
            result.db_connection_strucutre_version = data.db_connection_strucutre_version;
            result.db_host = data.db_host;
            result.db_port = data.db_port;
            result.db_usefulltext = data.db_usefulltext;
            result.db_connectiontimeout = data.db_connectiontimeout;
            if (String.IsNullOrEmpty(data.db_connectionstring)) result.db_connectionstring = "";
            else result.db_connectionstring = DSCryptoString.DecryptString(data.db_connectionstring);
            return result;
        }
    }
}
