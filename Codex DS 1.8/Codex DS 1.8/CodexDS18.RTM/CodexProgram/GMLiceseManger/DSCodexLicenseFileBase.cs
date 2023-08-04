using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            string JsonString = Newtonsoft.Json.JsonConvert.SerializeObject(_content, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_fileName, JsonString);
        }

        public void ReadFromFile(String path)
        {
            string JsonString = File.ReadAllText(_fileName);
            _content = Newtonsoft.Json.JsonConvert.DeserializeObject<DSLicenseContent>(JsonString);
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
