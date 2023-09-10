using CodexDSListBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4.CodexSettings
{
    public class StatusAttributeConfiguration
    {
        static public DSListConfiguration ListConfiguration { get; set; }

        static public void LoadConfiguraiton()
        {
            ListConfiguration = new DSListConfiguration();
            try
            {

                ListConfiguration.NeedtoBeApplied = CodexStatusSettings.Default.UseStatusBehavior; 

                ListConfiguration.IdConfiguration = new DSListIdConfiguraiton()
                {
                    IdOfOriginalDocument = CodexStatusSettings.Default.ID_OriginalDocument,
                    IdOfCodifiedDocument = CodexStatusSettings.Default.ID_CodifiedDocument,
                    IdOfObsoleteDocument = CodexStatusSettings.Default.ID_ObsoleteDocument,
                    IdOfArchivedDocument = CodexStatusSettings.Default.ID_ArchivedDocument,
                    IdOfDraftDocument = CodexStatusSettings.Default.ID_DraftDocument,
                    IdOfSpecifiedDocument = CodexStatusSettings.Default.ID_Specified,
                    IdOfUnknownDocument = CodexStatusSettings.Default.ID_UnknowDocument
                };

                ListConfiguration.ColorConfiguration = new DSListColorConfiguration()
                {
                    ColorOfDefault = CodexStatusSettings.Default.Color_Default,
                    ColorOfOriginalDocument = CodexStatusSettings.Default.Color_OriginalDocument,
                    ColorOfCodifiedDocument = CodexStatusSettings.Default.Color_CodifiedDocument,
                    ColorOfArchivedDocument = CodexStatusSettings.Default.Color_ArchivedDocument,
                    ColorOfDraftDocument = CodexStatusSettings.Default.Color_DraftDocument,
                    ColorOfObsoleteDocument = CodexStatusSettings.Default.Color_ObsoleteDocument,
                    ColorOfSpecifiedDocument = CodexStatusSettings.Default.Color_Specified,
                    ColorOfUnknownDocument = CodexStatusSettings.Default.Color_UnknowDocument
                };


                ListConfiguration.IconIndexConfiguration = new DSIconIndexConfiguraiton()
                {
                    IconIndexOfDefault = CodexStatusSettings.Default.IconIndex_Default,
                    IconIndexOfOriginalDocument = CodexStatusSettings.Default.IconIndex_OriginalDocument,
                    IconIndexCodifiedDocument = CodexStatusSettings.Default.IconIndex_CodifiedDocument,
                    IconIndexArchivedDocument = CodexStatusSettings.Default.IconIndex_ArchivedDocument,
                    IconIndexDraftDocument = CodexStatusSettings.Default.IconIndex_DraftDocument,
                    IconIndexObsoleteDocument = CodexStatusSettings.Default.IconIndex_ObsoleteDocument,
                    IconIndexSpecifiedDocument = CodexStatusSettings.Default.IconIndex_Specified,
                    IconIndexUnknownDocument = CodexStatusSettings.Default.IconIndex_UnknowDocument
                };
            }
            catch
            {
                ListConfiguration.NeedtoBeApplied = false;
            }
        }
    }
}
