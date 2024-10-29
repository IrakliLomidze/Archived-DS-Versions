// *************************************************************************************
// ** DS Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** DS User Configurations
// ** Version 2.0
// ** Date 2023/04/09


using DSCommon.Configurations;
using ILG.DS.Profile;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace DS.Configurations
{

    public class UserSQLConfigurationManager
    {

        //public readonly string configFilename = "dbconnection.dssqlconnection";
        

        private string _profile;
        public UserSQLConfigurationContext content { get; private set; }
        public UserSQLConfigurationManager(string profile)
        {
            _profile = profile;
            //_configurationFullFilename = get_fullfilename();
            CreateIfNotExists();
        }

        private string getStoragePath()
        {
            string apppath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DocumentStorage");
            if (!Directory.Exists(apppath)) Directory.CreateDirectory(apppath);

            string codexpath = Path.Combine(apppath, "DS");
            if (!Directory.Exists(codexpath)) Directory.CreateDirectory(codexpath);

            string datapath = Path.Combine(codexpath, "configurations");
            if (!Directory.Exists(datapath)) Directory.CreateDirectory(datapath);

            string verpath = Path.Combine(datapath, "1.11");
            if (!Directory.Exists(verpath)) Directory.CreateDirectory(verpath);

            return verpath;
        }

        private void DefaultParameters()
        {
            content = new UserSQLConfigurationContext();
        }


        private string get_fullfilename()
        {
            if (_profile == null) { throw new Exception("Not Initialized profile"); }
            var current = getStoragePath();
            current = current.EndsWith("/") ? current.Substring(0, current.Length - 1) : current;
            return Path.Combine(current, $"{_profile}.dssqlconnection");
        }

        public void AssingNewConfiguraiton(UserSQLConfigurationContext newconfig)
        {
            content.AssingNewConfiguraiton(newconfig);
        }

        private void _writeToFile()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            UserSQLConfigurationContext _econtext = UserSQLConfigurationHelper.UserConfigEncryption(content);
            string jsonString = JsonSerializer.Serialize(_econtext, options);
            File.WriteAllText(get_fullfilename(), jsonString);
        }

        public void CreateIfNotExists_Admin()
        {
            if (File.Exists(get_fullfilename()) == false)
            {
                content = new UserSQLConfigurationContext();
                _writeToFile();
            }
        }

        private void CreateIfNotExists()
        {
            if (File.Exists(get_fullfilename()) == false)
            {
                DefaultParameters();
                _writeToFile();
            }
        }

        public int ReadConfiguraiton()
        {
            try
            {
                CreateIfNotExists();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                string jsonString = File.ReadAllText(get_fullfilename());

                var _dcontent = JsonSerializer.Deserialize<UserSQLConfigurationContext>(jsonString, options);
                content = UserSQLConfigurationHelper.UserConfigDecryption(_dcontent);

                return 0;
            }
            catch (Exception) { content = new UserSQLConfigurationContext(); return 1; }

        }

        public void WriteConfiguration()
        {
            _writeToFile();
        }




    }






}

