using System;
using System.IO;

namespace ILG.Codex.CodexR4
{
    public class COFHeader
    {
        public String Suffix { get; set; }
        public String Description { get; set; }
        public String Version { get; set; }
        public Version MajorVersion { get; set; }
        public Version MinorVersion { get; set; }
        public int ApplicationID { get; set; }
        public String Application { get; set; }

        public UInt64 StartFrom { get; set; }
        public UInt64 EndTo { get; set; }
        public UInt64 Amount { get; set; }

        public DateTime Date { get; set; }

        public COFHeader(int _applicationID, string _applicationNmae, UInt64 _startFrom, UInt64 _endTo, UInt64 _amount, DateTime _uDate)
        {
            Suffix = "COF";
            Description = "Codex Open Format";
            MajorVersion = new System.Version(7000, 1000);
            MinorVersion = new System.Version(0, 0);
            ApplicationID = _applicationID;
            Application = "Codex";
            StartFrom = _startFrom;
            EndTo = _endTo;
            Amount = _amount;
        }
    }

    public class COFIntegrity
    {
        public Strng FileName { get; set; }
        public int FileSize { get; set; }
        public String MD5 { get; set; }
    }
}
