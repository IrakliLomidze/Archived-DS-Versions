using ILG.Codex.CodexR4.JsonConfigurations.DisplayModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4.JsonConfigurations
{
    public class CodexDSOrganizationModel
    {
        public String OrganizationName { get; set; }
        public String OrganizationId { get; set; }

        public String ConfigurationId { get; set; }
        public CodexDSDisplayModel DisplayModel { get; set; }

        public CodexDSOrganizationModel()
        {
            DisplayModel = new CodexDSDisplayModel();
        }

    }
}
