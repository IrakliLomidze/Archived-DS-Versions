// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Profile
// ** Version 1.0


using ILG.DS.Configurations.Profile;
using ILG.DS.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.DS.Configurations.Profile
{
    public class DSProfileItemViewModel
    {
        public string DS_Profile_Name { get; set; }
        public string DS_Porfile_DisplayName { get; set; }

        public DSProfileItemViewModel()
        {

        }
        public void AssingNewConfiguraiton(DSProfileContent newconfig)
        {
            DS_Profile_Name = newconfig.ds_profile_name;
            DS_Porfile_DisplayName = newconfig.ds_display_name;
        }
    }
}

