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

namespace ILG.Codex.CodexDS.Configurations.Profile
{
    internal class DSProfileContextItemViewModel
    {
        public string DS_Profile_Name { get; set; }
        public string DS_Porfile_DisplayName { get; set; }

        public DSProfileContextItemViewModel()
        {
            
        }
        public void AssingNewConfiguraiton(DSProfileContext newconfig)
        {
            DS_Profile_Name = newconfig.DS_Profile_Name;
            DS_Porfile_DisplayName = newconfig.DS_Porfile_DisplayName;
        }
    }
}

