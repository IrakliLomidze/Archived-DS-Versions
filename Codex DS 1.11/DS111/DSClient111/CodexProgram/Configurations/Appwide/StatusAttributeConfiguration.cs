
using ILG.DS.Controls;
using ILG.DS.Controls.DSList.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.DS.Configurations
{
    public class StatusAttributeConfiguration
    {
        static public DSListConfiguration ListConfiguration { get; set; }

        static public void LoadConfiguraiton()
        {
            ListConfiguration = new DSListConfiguration();
            try
            {
                ListConfiguration.NeedtoBeApplied = true;
            }
            catch
            {
                ListConfiguration.NeedtoBeApplied = false;
            }
        }
    }
}
