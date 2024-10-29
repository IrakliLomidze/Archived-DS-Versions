using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSDatabase
{

    [Table(name:"ds_settings")]
    public class ds_settings : DSBaseRow
    {
        [Key]
        [StringLength(64)]
        public string setting_key { get; set; }

        [StringLength(64)]
        public string setting_type { get; set; } // folder value

        [StringLength(64)]
        public string setting_level { get; set; } // Tenant, Division, Group, User

        [MaxLength]
        public string setting_value { get; set; }

        [StringLength(64)]
        public string setting_value_type { get; set; } // string, int, double ...

        public string setting_value_validation { get; set; } // regex
    }

    public enum ds_setting_record_type { folder, value }
    public class ds_settings_seeders
    {
        public int addorupdate_root_folder(string foldername)
        {
            return 0;
        }
        public int addorupdate_folder(string foldername, int parent)
        {
            return 0;
        }
        public void addorupdate_value(string settingkey, int parent, object settingvalue = null)
        {

        }

        public void settings_seeders()
        {
            int s = 0;
            int root = addorupdate_root_folder("DSTenantGlobal");
            int doc = addorupdate_folder("document", root);
            int doc_default = addorupdate_folder("default", doc);
            addorupdate_value("documentPageWidth", doc_default, 827);
            addorupdate_value("documentPageHeight", doc_default, 1169);
            addorupdate_value("documentPageMarginBottom", doc_default, 70);
            addorupdate_value("documentPageMarginTop", doc_default, 70);
            addorupdate_value("documentPageMarginRight", doc_default, 70);
            addorupdate_value("documentPageMarginLeft", doc_default, 70);
            addorupdate_value("documentDefaultEncoding", doc_default, 1);
            addorupdate_value("documentEncogingPolicy", doc_default, false);

            int attribute = addorupdate_folder("attributes", root);
            int attribute_behaviour = addorupdate_folder("behaviour", attribute);
            addorupdate_value("showAdvancedAttributes", attribute_behaviour, true);
            addorupdate_value("useStatusAsMandatory", attribute_behaviour, true);
            addorupdate_value("useCategoryAsMandatory", attribute_behaviour, true);
            addorupdate_value("useNumberAsManadatory", attribute_behaviour, true);
            addorupdate_value("isDefaultParameterStatus", attribute_behaviour, false);
            addorupdate_value("defaultStatus", attribute_behaviour, "");

        }

    }
}
