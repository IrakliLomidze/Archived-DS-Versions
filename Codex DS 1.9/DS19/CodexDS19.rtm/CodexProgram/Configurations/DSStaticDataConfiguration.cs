// *************************************************************************************
// ** Codex 365 New Configurations
// ** (C) Copyright By 2007-2023 By Georgian Microsystems
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Codex Static Configurations
// ** Version 1.6
// ** Date 2022/12/12
// ** Date 2023/01/06

using ILG.Codex.CodexR4;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DS.Configurations
{

    public class DSStaticDataConfiguration
    {
        private string _configurationFullFilename;
        public readonly string configFilename = "dsstaticdata.json";

        private static DSStaticDataConfiguration instance;
        public DSStaticDataContent content { get; private set; }
        public static DSStaticDataConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DSStaticDataConfiguration();
                    instance.DefaultParameters();
                    instance.CreateIfNotExists();
                }
                return instance;
            }
        }

        private void DefaultParameters()
        {
            content = new DSStaticDataContent();
        }

        private DSStaticDataConfiguration()
        {
            _configurationFullFilename = Path.Combine(DirectoryConfiguration.CurrentDirectory, configFilename);
            CreateIfNotExists();
        }

        public void AssingNewConfiguraiton(DSStaticDataContent newconfig)
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
        private void CreateIfNotExists()
        {
            if (File.Exists(_configurationFullFilename) == false)
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

                string jsonString = File.ReadAllText(_configurationFullFilename);
                content = JsonSerializer.Deserialize<DSStaticDataContent>(jsonString, options);
                return 0;
            }
            catch (Exception ex) { DefaultParameters(); return 1; }
            
        }

        public void WriteConfiguration()
        {
            _writeToFile();
        }




    }
    public class DSStaticDataContent
    {
        
        public string WebAddress { get; set; } = "www.codex.ge";
        public string SupportAddress { get; set; } = "support@codex.ge";
        
        public string BugTraqMail { get; set; } = "support@codex.ge";

        
        public void AssingNewConfiguraiton(DSStaticDataContent newconfig)
        {
            WebAddress = newconfig.WebAddress;
            SupportAddress = newconfig.SupportAddress;
            BugTraqMail = newconfig.BugTraqMail;
        }

        public DSStaticDataContent() 
        {
            WebAddress = "www.codex.ge";
            SupportAddress = "support@codex.ge";
            BugTraqMail  = "support@codex.ge";
        }

    }
}
