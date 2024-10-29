using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.DS.Configurations.JsonConfigurations
{
    
    public class DSOrganizationConfigurationModel
    {
        public String OrganizationName { get; set; }
        public String OrganizationId { get; set; }

        public String ConfigurationId { get; set; }
        public DSDisplayConfigurationModel DisplayModel { get; set; }

        public DSOrganizationConfigurationModel()
        {
            DisplayModel = new DSDisplayConfigurationModel();
        }

    }
}
