//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ILG.Codex.CodexR4.JsonConfigurations
//{
//    public class CodexDSOrganizationConfigurationFile
//    {
//        private CodexDSOrganizationModel _content;
//        private String _fileName;
//        public CodexDSOrganizationConfigurationFile(string fileName)
//        {
//            _content = new CodexDSOrganizationModel();
//            _fileName = fileName;
//        }

//        public void WritetoFile()
//        {
//            string JsonString = Newtonsoft.Json.JsonConvert.SerializeObject(_content, Newtonsoft.Json.Formatting.Indented);
//            File.WriteAllText(_fileName, JsonString);
//        }

//        public void ReadFromFile()
//        {
//            string JsonString = File.ReadAllText(_fileName);
//            try
//            {
//                _content = Newtonsoft.Json.JsonConvert.DeserializeObject<CodexDSOrganizationModel>(JsonString);
//            }
//            catch
//            {
//                _content = new CodexDSOrganizationModel(); // Default Paramenters
//            }
//        }
//        public CodexDSOrganizationModel Content
//        {
//            get { return _content; }
//            set { _content = value; }
//        }

//    }
//}
