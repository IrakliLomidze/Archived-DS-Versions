using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSDatabase
{
    public class DSBaseRow
    {
        public abstract class DSBaseEntity
        {
            [Column(Order = 1)]
            [StringLength(64)]
            public string id { get; set; }

            [Column(Order = 2)]
            [StringLength(64)]
            public string parent_id { get; set; }


            #region Record Data
            [Column(Order = 3)]
            [StringLength(3)]
            public string record_type { get; set; }

            [Column(Order = 4)]
            public int? record_level { get; set; }

            [Column(Order = 5)]
            public float? record_order { get; set; }

            [Column(Order = 6)]
            public int? record_access { get; set; }

            [Column(Order = 7)]
            public int? record_status { get; set; }

            #endregion Record Data

            #region Audit Data
            [Column(Order = 1001)]
            public bool? record_system { get; set; } = false;

            [Column(TypeName = "datetime2", Order = 1002)]
            public DateTime? record_creation_date { get; set; } = DateTime.Now;

            [Column(Order = 1003)]
            [StringLength(64)]
            public string record_created_by { get; set; }

            [Column(TypeName = "datetime2", Order = 32)]
            public DateTime? record_modified_date { get; set; }

            [Column(Order = 1003)]
            [StringLength(64)]
            public string record_modified_by { get; set; }

            [Column(Order = 1004)]
            public bool? record_deleted { get; set; } = false;

            [Column(Order = 1005)]
            [MaxLength]
            public string remark { get; set; }

            #endregion Audit Data

            // TBD 

            #region Display Data
            [Column(Order = 9)]
            public int? language { get; set; }

            [Column(Order = 10)]
            [StringLength(64)]
            public string abberviation { get; set; }

            [Column(Order = 11)]
            [StringLength(255)]
            public string display_text { get; set; }

            [Column(Order = 12)]
            [MaxLength]
            public string description { get; set; }

            [Column(Order = 13)]
            [MaxLength]
            [Description("Json Data for Additinal Lanaugages")]
            public string additinal_data { get; set; }

            [Column(Order = 14)]
            [MaxLength]
            [Description("Additinal Data")]
            public string tag { get; set; }


            #endregion Display Data

            // TBD 

            #region Icon Data
            [Column(Order = 10)]
            [StringLength(64)]
            public string icon { get; set; }

            #endregion Icon Data


        }
    }
}