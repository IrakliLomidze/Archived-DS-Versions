using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4.GMLiceseManger
{
    public class DSLicenseContent
    {
        public string LicId { get; set; }
        public string License { get; set; }
        public string Version { get; set; }
        public String LicenseType { get; set; }

        public String Organization { get; set; }
        public String Department { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Set1 { get; set; }
        public string Set2 { get; set; }
        public string Set3 { get; set; }

        public String Rights { get; set; }
        public String DefCode1 { get; set; }
        public String DefCode2 { get; set; }
        public String ZCode1 { get; set; }
        public String ZCode2 { get; set; }
    }
}
