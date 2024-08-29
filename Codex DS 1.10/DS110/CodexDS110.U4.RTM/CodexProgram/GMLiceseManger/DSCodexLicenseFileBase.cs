using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4.GMLiceseManger
{
    public class DSCodexLicenseFileBase
    {
        private DSLicenseContent _content;
        private String _fileName;
        public DSCodexLicenseFileBase(string fileName)
        {
            _content = new DSLicenseContent();
            _fileName = fileName;
        }

        public void WritetoFile()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string JsonString = JsonSerializer.Serialize(_content, options);
            File.WriteAllText(_fileName, JsonString);
        }

        public void ReadFromFile(String path)
        {
            string JsonString = File.ReadAllText(_fileName);
            _content = JsonSerializer.Deserialize<DSLicenseContent>(JsonString);
        }
        public DSLicenseContent Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public bool LicenseVerification()
        {

            return true;
        }

    }

}
