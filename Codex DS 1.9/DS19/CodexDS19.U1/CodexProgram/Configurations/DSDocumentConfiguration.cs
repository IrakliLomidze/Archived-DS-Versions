// *************************************************************************************
// ** Codex 365 New Configurations
// ** (C) Copyright By 2007-2023 By Georgian Microsystems
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Codex Static Configurations
// ** Version 1.0
// ** Date 2022/12/12

using ILG.Codex.CodexR4;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DS.Configurations
{

    public class DSDocumentConfiguration
    {
        private string _configurationFullFilename;
        public readonly string configFilename = "dsdocument.json";

        private static DSDocumentConfiguration instance;
        public DSDocumentConfigContent content { get; private set; }
        public static DSDocumentConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DSDocumentConfiguration();
                    instance.DefaultParameters();
                    instance.CreateIfNotExists();
                }
                return instance;
            }
        }

        private void DefaultParameters()
        {
            content = new DSDocumentConfigContent();
        }

        private DSDocumentConfiguration()
        {
            _configurationFullFilename = Path.Combine(DirectoryConfiguration.CurrentDirectory, configFilename);
            CreateIfNotExists();
        }

        public void AssingNewConfiguraiton(DSDocumentConfigContent newconfig)
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

                content = JsonSerializer.Deserialize<DSDocumentConfigContent>(jsonString, options);
                return 0;
            }
            catch (Exception ex) { DefaultParameters(); return 1; }
            
        }

        public void WriteConfiguration()
        {
            _writeToFile();
        }




    }
    public class DSDocumentConfigContent
    {
        public int DocumentPageWidth { get; set; } = 827;
        public int DocumentPageHeight { get; set; } = 1169;
        public int DocumentPageMarginBottom { get; set; } = 70;
        public int DocumentPageMarginTop { get; set; } = 70;
        public int DocumentPageMarginRight { get; set; } = 70;
        public int DocumentPageMarginLeft { get; set; } = 70;

        public int DocumentDefaultEncoding { get; set; } = 1;
        public bool DocumentEncogingPolicy { get; set; } = false;


        public void AssingNewConfiguraiton(DSDocumentConfigContent newconfig)
        {
            DocumentPageWidth = newconfig.DocumentPageWidth;
            DocumentPageHeight = newconfig.DocumentPageHeight;
            DocumentPageMarginBottom = newconfig.DocumentPageMarginBottom;
            DocumentPageMarginTop = newconfig.DocumentPageMarginTop;
            DocumentPageMarginRight = newconfig.DocumentPageMarginRight;
            DocumentPageMarginLeft = newconfig.DocumentPageMarginLeft;
            DocumentDefaultEncoding = newconfig.DocumentDefaultEncoding;
            DocumentEncogingPolicy = newconfig.DocumentEncogingPolicy;

        }

        public DSDocumentConfigContent() 
        {
            
        }

    }
}
