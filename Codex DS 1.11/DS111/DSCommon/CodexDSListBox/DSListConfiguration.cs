using System.Drawing;

namespace ILG.DS.Controls.DSList.Configuration
{
    public class DSListIdConfig
    {
        public int ID_OriginalDocument { get; set; } = 1;
        public int ID_CodifiedDocument { get; set; } = 2;
        public int ID_ObsoleteDocument { get; set; } = 3;
        public int ID_ArchivedDocument { get; set; } = 0;
        public int ID_UnknowDocument { get; set; } = 0;
        public int ID_Specified { get; set; } = 0;
        public int ID_Draft { get; set; } = 0;

        public DSListIdConfig()
        {
        }
    }

    public class DSListColorConfig
    {
        public Color ColorOfOriginalDocument { get; set; }
        public Color ColorOfCodifiedDocument { get; set; }
        public Color ColorOfObsoleteDocument { get; set; }
        public Color ColorOfArchivedDocument { get; set; }
        public Color ColorOfUnknownDocument { get; set; }
        public Color ColorOfSpecifiedDocument { get; set; }
        public Color ColorOfDraftDocument { get; set; }
        public Color ColorOfDefault { get; set; }

        public DSListColorConfig()
        {
            ColorOfOriginalDocument = Color.FromArgb(30, 57, 91); 
            ColorOfCodifiedDocument = Color.FromArgb(30, 57, 91); 
            ColorOfObsoleteDocument = Color.FromArgb(30, 57, 91);
            ColorOfArchivedDocument = Color.FromArgb(30, 57, 91);
            ColorOfUnknownDocument = Color.FromArgb(30, 57, 91);
            ColorOfSpecifiedDocument = Color.FromArgb(30, 57, 91);
            ColorOfDraftDocument = Color.FromArgb(30, 57, 91);
            ColorOfDefault = Color.FromArgb(30, 57, 91);
        }
    }

    public class DSIconIndexConfig
    {

        public int IconIndexOfOriginalDocument { get; set; }
        public int IconIndexCodifiedDocument { get; set; }
        public int IconIndexObsoleteDocument { get; set; }
        public int IconIndexArchivedDocument { get; set; }
        public int IconIndexUnknownDocument { get; set; }
        public int IconIndexSpecifiedDocument { get; set; }
        public int IconIndexDraftDocument { get; set; }
        public int IconIndexOfDefault { get; set; }

        public DSIconIndexConfig()
        {
            IconIndexOfOriginalDocument = 0;
            IconIndexCodifiedDocument = 0;
            IconIndexObsoleteDocument = 0;
            IconIndexArchivedDocument = 0;
            IconIndexUnknownDocument = 0;
            IconIndexSpecifiedDocument = 0;
            IconIndexDraftDocument = 0;
            IconIndexOfDefault = 0;
        }

    }

    public class DSListConfiguration
    {
        public bool NeedtoBeApplied { get; set; }

        public DSListIdConfig Id_config { get; set; }
        public DSListColorConfig color_config { get; set; }

        public DSIconIndexConfig IconIndex_config { get; set; }

        public DSListConfiguration()
        {
            Id_config = new DSListIdConfig();
            color_config = new DSListColorConfig();
            IconIndex_config = new DSIconIndexConfig();
        }
    }
}
