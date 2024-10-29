// *************************************************************************************
// ** DS Configurations
// ** (C) Copyright By 2007-2024 By Irakli Lomidze
// *************************************************************************************
// ** DS User Configurations
// ** Version 2.0
// ** Date 2023/04/09


using DSCommon.Configurations;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ILG.DS.Configurations
{

    public class UserUIConfigurationManager
    {
        public UserUIConfigurationContext content { get; private set; }
        public UserUIConfigurationManager()
        {
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

        public void DefaultParameters()
        {
            content = new UserUIConfigurationContext();
        }


        private string get_fullfilename()
        {
            var current = getStoragePath();
            current = current.EndsWith("/") ? current.Substring(0, current.Length - 1) : current;
            return Path.Combine(current, $"dsuiconfig.json");
        }

        public void AssingNewConfiguraiton(UserUIConfigurationContext newconfig)
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

            string jsonString = JsonSerializer.Serialize(content, options);
            File.WriteAllText(get_fullfilename(), jsonString);
        }

        public void CreateIfNotExists_Admin()
        {
            if (File.Exists(get_fullfilename()) == false)
            {
                content = new UserUIConfigurationContext();
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

                content = JsonSerializer.Deserialize<UserUIConfigurationContext>(jsonString, options);

                return 0;
            }
            catch (Exception) { content = new UserUIConfigurationContext(); return 1; }

        }

        public void WriteConfiguration()
        {
            _writeToFile();
        }

    }

}

