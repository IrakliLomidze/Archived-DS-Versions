using System.Drawing;

namespace CodexDSListBox
{
    public class DSListIdConfiguraiton
    {
        public int IdOfOriginalDocument { get; set; }
        public int IdOfCodifiedDocument { get; set; }
        public int IdOfObsoleteDocument { get; set; }
        public int IdOfArchivedDocument { get; set; }
        public int IdOfUnknownDocument { get; set; }
        public int IdOfSpecifiedDocument { get; set; }
        public int IdOfDraftDocument { get; set; }

        public DSListIdConfiguraiton()
        {
            IdOfOriginalDocument = 0;
            IdOfCodifiedDocument = 0;
            IdOfObsoleteDocument = 0;
            IdOfArchivedDocument = 0;
            IdOfUnknownDocument = 0;
            IdOfSpecifiedDocument = 0;
            IdOfDraftDocument = 0;
        }
    }

    public class DSListColorConfiguration
    {
        public Color ColorOfOriginalDocument { get; set; }
        public Color ColorOfCodifiedDocument { get; set; }
        public Color ColorOfObsoleteDocument { get; set; }
        public Color ColorOfArchivedDocument { get; set; }
        public Color ColorOfUnknownDocument { get; set; }
        public Color ColorOfSpecifiedDocument { get; set; }
        public Color ColorOfDraftDocument { get; set; }
        public Color ColorOfDefault { get; set; }

        public DSListColorConfiguration()
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

    public class DSIconIndexConfiguraiton
    {

        public int IconIndexOfOriginalDocument { get; set; }
        public int IconIndexCodifiedDocument { get; set; }
        public int IconIndexObsoleteDocument { get; set; }
        public int IconIndexArchivedDocument { get; set; }
        public int IconIndexUnknownDocument { get; set; }
        public int IconIndexSpecifiedDocument { get; set; }
        public int IconIndexDraftDocument { get; set; }
        public int IconIndexOfDefault { get; set; }

        public DSIconIndexConfiguraiton()
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

        public DSListIdConfiguraiton IdConfiguration { get; set; }
        public DSListColorConfiguration ColorConfiguration { get; set; }

        public DSIconIndexConfiguraiton IconIndexConfiguration { get; set; }

        public DSListConfiguration()
        {
            IdConfiguration = new DSListIdConfiguraiton();
            ColorConfiguration = new DSListColorConfiguration();
            IconIndexConfiguration = new DSIconIndexConfiguraiton();
        }
    }
}
