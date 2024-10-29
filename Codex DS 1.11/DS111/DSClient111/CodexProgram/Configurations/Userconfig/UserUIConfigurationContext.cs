// *************************************************************************************
// ** DS Configurations
// ** (C) Copyright By 2007-2024 By Irakli Lomidze
// *************************************************************************************
// ** DS User Configurations
// ** Version 2.1
// ** Date 2023/04/09
// ** Date 2023/04/27


using System;

namespace ILG.DS.Configurations
{
    public class UserUIConfigurationContext
    {
        public Version ui_strucutre_version { get; set; } = new Version(1, 0);
        public int ui_keyboard { get; set; }
        public int ui_max_list { get; set; }
        public int ui_defaultzoom { get; set; }

        public bool ui_showlistpreview { get; set; } = true;
        
        public UserUIConfigurationContext()
        {
            ui_keyboard = 0;
            ui_max_list = 1500;
            ui_defaultzoom = -20;
            ui_showlistpreview = true;
        }

        public void AssingNewConfiguraiton(UserUIConfigurationContext newconfig)
        {
            ui_strucutre_version = newconfig.ui_strucutre_version;
            ui_keyboard = newconfig.ui_keyboard;
            ui_max_list = newconfig.ui_max_list;
            ui_defaultzoom = newconfig.ui_defaultzoom;
            ui_showlistpreview=newconfig.ui_showlistpreview;    
        }
    }
}



