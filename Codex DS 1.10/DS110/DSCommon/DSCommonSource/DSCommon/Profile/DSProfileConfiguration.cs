// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Profile
// ** Date: 2023-04-05
// ** Version 1.1



using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ILG.DS.Profile
{
    public class DSProfileManager
    {
        private string _configurationFullFilename;
        private string _configFilename = "dsbaseprofile.dsprofile";

        private string _path;
        public DSProfileContent _content { get; private set; }

        public DSProfileManager(string configfilename, string path)
        {
            _configFilename = configfilename;
            _path = path;
            _configurationFullFilename = Path.Combine(_path, _configFilename);
        }
        public void AssingNewConfiguraiton(DSProfileContent newconfig)
        {
            if (_content == null) _content = new DSProfileContent();
            _content.AssingNewConfiguraiton(newconfig);
        }

        private void _writeToFile()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            DSProfileContent _econtext = DSProfileHelper.ProfileEncryption(_content);
            string jsonString = JsonSerializer.Serialize(_econtext, options);
            File.WriteAllText(_configurationFullFilename, jsonString);
        }

   
        public void ReadConfiguraiton()
        {
            //CreateIfNotExists();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string jsonString = File.ReadAllText(_configurationFullFilename);
            var _dcontent = JsonSerializer.Deserialize<DSProfileContent>(jsonString, options);
            _content = DSProfileHelper.ProfileDecryption(_dcontent);
        }

        private DSProfileContent ReadProfile(string profileFilename)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Always
            };
            try
            {
                var dcontent = JsonSerializer.Deserialize<DSProfileContent>(File.ReadAllText(profileFilename), options);
                var content = DSProfileHelper.ProfileDecryption(dcontent);
                return content;
            }
            catch { return null; }
        }

        public void WriteConfiguration()
        {
            _writeToFile();
        }


        public List<DSProfileContent> ReadExistingsProfiles()
        {
            List<DSProfileContent> dSProfiles = new List<DSProfileContent>();
            string[] files = Directory.GetFiles(_path, "*.dsprofile");
            foreach (string file in files)
            {
                var data = ReadProfile(file);
                if (data != null) dSProfiles.Add(data);
            }
            return dSProfiles;
        }

    }
}

