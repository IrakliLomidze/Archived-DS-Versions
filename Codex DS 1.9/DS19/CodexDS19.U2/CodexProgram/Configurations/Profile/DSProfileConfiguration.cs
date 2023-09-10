// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Profile
// ** Version 1.0

using ILG.Codex.CodexR4;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ILG.Codex.CodexDS.Configurations.Profile
{
    internal class DSProfileConfiguration
    {
        private string _configurationFullFilename;
        private readonly string _configFilename = "dsbaseprofile.dsprofile";
        public DSProfileContext content { get; private set; }

        public DSProfileConfiguration(string configfilename)
        {
            _configFilename = configfilename;
            _configurationFullFilename = Path.Combine(DirectoryConfiguration.Instance.DSProfileRootDirectory, _configFilename);
        }
        public void AssingNewConfiguraiton(DSProfileContext newconfig)
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
            File.WriteAllText(_configurationFullFilename, jsonString);
        }

        //private void CreateIfNotExists()
        //{
        //    if (File.Exists(_configurationFullFilename) == false)
        //    {
        //        DefaultParameters();
        //        _writeToFile();
        //    }
        //}
        public void ReadConfiguraiton()
        {
            //CreateIfNotExists();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true
            };

            string jsonString = File.ReadAllText(_configurationFullFilename);
            content = JsonSerializer.Deserialize<DSProfileContext>(jsonString, options);
        }

        private DSProfileContext ReadProfile(string profileFilename)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Always
            };
            try
            {
                var content = JsonSerializer.Deserialize<DSProfileContext>(File.ReadAllText(profileFilename), options);
                return content;
            }
            catch { return null; }
        }

        public void WriteConfiguration()
        {
           _writeToFile();
        }


        public List<DSProfileContext> ReadExistingsProfiles()
        {
            List<DSProfileContext> dSProfiles = new List<DSProfileContext>();
            string[] files = Directory.GetFiles(DirectoryConfiguration.Instance.DSProfileRootDirectory, "*.dsprofile");
            foreach (string file in files) 
            {
                DSProfileContext data = ReadProfile(file);
                if (data != null ) dSProfiles.Add(data);
            }
            return dSProfiles;
        }

    }
}

