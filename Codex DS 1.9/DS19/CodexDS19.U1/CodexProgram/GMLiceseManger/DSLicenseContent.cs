using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4.GMLiceseManger
{
    public class ExpirationDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
    public class DSLicenseContent
    {
        public string LicId { get; set; }
        public string License { get; set; }
        public string Version { get; set; }
        public String LicenseType { get; set; }

        public String Organization { get; set; }
        public String Department { get; set; }
        public ExpirationDate Expiration { get; set; }

        public String DefId { get; set; }
        public String DefCode { get; set; }

    }
}
