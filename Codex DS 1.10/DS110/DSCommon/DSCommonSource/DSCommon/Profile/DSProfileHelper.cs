// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Profile
// ** Date: 2023-04-06
// ** Version 1.0

using DS.Config.Encryption;
using ILG.DS.Configurations.Profile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ILG.DS.Profile
{
    public class DSProfileHelper
    {
        static public DSProfileContent ProfileEncryption(DSProfileContent data)
        {
            DSProfileContent result = new DSProfileContent();
            result.ds_profile_version = data.ds_profile_version;
            result.ds_profile_name = data.ds_profile_name;
            result.ds_display_name = data.ds_display_name;

            result.ds_db_version = DSCryptoString.EncryptString(data.ds_db_version);
            result.ds_db_name = DSCryptoString.EncryptString(data.ds_db_name);

            result.ds_auth_type = DSCryptoString.EncryptString(data.ds_auth_type);
            result.ds_sql_sqluser_username = DSCryptoString.EncryptString(data.ds_sql_sqluser_username);
            result.ds_sql_sqluser_password = DSCryptoString.EncryptString(data.ds_sql_sqluser_password);

            return result;
        }

        static public DSProfileContent ProfileDecryption(DSProfileContent data)
        {

            DSProfileContent result = new DSProfileContent();
            result.ds_profile_version = data.ds_profile_version;
            result.ds_profile_name = data.ds_profile_name;
            result.ds_display_name = data.ds_display_name;

            result.ds_db_version = DSCryptoString.DecryptString(data.ds_db_version);
            result.ds_db_name = DSCryptoString.DecryptString(data.ds_db_name);

            result.ds_auth_type = DSCryptoString.DecryptString(data.ds_auth_type);
            result.ds_sql_sqluser_username = DSCryptoString.DecryptString(data.ds_sql_sqluser_username);
            result.ds_sql_sqluser_password = DSCryptoString.DecryptString(data.ds_sql_sqluser_password);

            return result;
        }
        static public List<DSProfileItemViewModel> ReadProfileList(string priflefolder)
        {
            List<DSProfileItemViewModel> result = new List<DSProfileItemViewModel>();
            try
            {
                var priflefiles = Directory.GetFiles(priflefolder, "*.dsprofile");
                foreach (var filename in priflefiles)
                {
                    DSProfileManager dSProfileManager = new DSProfileManager(Path.GetFileName(filename), priflefolder);
                    dSProfileManager.ReadConfiguraiton();
                    DSProfileItemViewModel model = new DSProfileItemViewModel();
                    model.DS_Profile_Name = dSProfileManager._content.ds_profile_name;
                    model.DS_Porfile_DisplayName = dSProfileManager._content.ds_display_name;
                    result.Add(model);
                }
            }
            catch (Exception ex) 
            { Debug.WriteLine(ex.Message);  result = new List<DSProfileItemViewModel>(); }
                 
            return result;
        }
    }
}
