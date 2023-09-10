// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Profile
// ** Version 1.0


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;

namespace ILG.Codex.CodexDS.Configurations.Profile
{
    internal class DSProfileContext
    {
        public Version DS_Profile_Strucutre_Version { get; set; } = new Version(1,0);
        public string DS_Profile_Name { get; set; } = "Base";
        public string DS_Porfile_DisplayName { get; set; } = "Codex DS";
        public string DS_XUser_SQLUserName { get; set; } = "CodexDSXUser";
        public string DS_XUser_SQLPassword { get; set; } = "...your password....";
        public string DS_DefaultDB { get; set; } = "Codex2007DS";
        public string DS_DefaultHost { get; set; } = "DSServer";
        public int DS_DefaultPort { get; set; } = 1433;
        public int DS_UseFullText { get; set; } = 0;
        public string DS_ConnectionString { get; set; }
        public string DS_Def { get; set; }
        public DSProfileContext()
        {
            
        }
        public void AssingNewConfiguraiton(DSProfileContext newconfig)
        {
            DS_Profile_Name = newconfig.DS_Profile_Name;
            DS_Porfile_DisplayName = newconfig.DS_Porfile_DisplayName;
            DS_XUser_SQLUserName = newconfig.DS_XUser_SQLUserName;
            DS_XUser_SQLPassword = newconfig.DS_XUser_SQLPassword;
            DS_DefaultDB = newconfig.DS_DefaultDB;
            DS_DefaultHost = newconfig.DS_DefaultHost;
            DS_DefaultPort = newconfig.DS_DefaultPort;
            DS_UseFullText = newconfig.DS_UseFullText;
            DS_ConnectionString = newconfig.DS_ConnectionString;
        }
    }
}

