using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ILG.Codex.Codex2007
{

    public enum AccessType
    {
        NoAccess,
        GuestLicense,
        UserLicense,
        PowertLicense,
        ManagerLicense,
        OperatorLicense,
        PowerOperatorLicense,
        BossLicense
    }

    class License
    {

        static bool V_IsConfidentialDocumentShowInList = true;
        static bool V_IsConfidentialDocumentIDShowInList = true;
        static bool V_IsDocumentIDShowInList = true;
        static bool V_IsEnterInConfidentialDocumentAlowed = true;
        static bool V_IsDocumentViewRestrictedMode = true;
        static bool V_IsAdminMode = true;
        static bool V_IsAttachmentShow = true;
        static bool V_IsConfidentialSaveAllow = true;
        static bool V_IsDocumentEditAllow = true;
        static bool V_IsDocumentDeletetAllow = true;
        static bool V_IsNewDocumentAllow = true;
        static bool V_IsDeleteAlowed = true;
        static bool L_DocumentOperation = true;
 

        static public bool IsConfidentialDocumentShowInList()
        {
            return V_IsConfidentialDocumentShowInList;
        }
        static public bool IsConfidentialDocumentIDShowInList()
        {
            return V_IsConfidentialDocumentIDShowInList;
        }
        static public bool IsDocumentIDShowInList()
        {
            return V_IsDocumentIDShowInList;
        }
        static public bool IsEnterInConfidentialDocumentAlowed()
        {
            return V_IsEnterInConfidentialDocumentAlowed;
        }
        static public bool IsDocumentViewRestrictedMode()
        {
            return V_IsDocumentViewRestrictedMode;
        }
        static public bool IsAdminMode()
        {
            return V_IsAdminMode;
        }
        static public bool IsAttachmentShow()
        {
            return V_IsAttachmentShow;
        }
        static public bool IsConfidentialSaveAllow()
        {
            return V_IsConfidentialSaveAllow;
        }
        static public bool IsDocumentEditAllow()
        {
            return V_IsDocumentEditAllow;
        }
        static public bool IsDocumentDeletetAllow()
        {
            return V_IsDocumentDeletetAllow;
        }
        static public bool IsNewDocumentAllow()
        {
            return V_IsNewDocumentAllow;
        }
        static public bool IsDeleteAlowed()
        {
            return V_IsDeleteAlowed;
        }

        // Level 2 License
        static public bool DocumentOperation()
        {
            return L_DocumentOperation;
        }

        // Real Liceses



        #region Licenses
         #endregion Licenses

     
        public static void LicenseAccess()
        {
            V_IsConfidentialDocumentShowInList = true;
            V_IsConfidentialDocumentIDShowInList = true;
            V_IsDocumentIDShowInList = true;
            V_IsEnterInConfidentialDocumentAlowed = true;
            V_IsDocumentViewRestrictedMode = false;
            V_IsAdminMode = true;
            V_IsAttachmentShow = true;
            V_IsConfidentialSaveAllow = true;
            V_IsDocumentEditAllow = true;
            V_IsDocumentDeletetAllow = true;
            V_IsNewDocumentAllow = true;
            V_IsDeleteAlowed = true;
            L_DocumentOperation = true;
            V_IsConfidentialDocumentShowInList = true;
            V_IsAttachmentShow = true;
            
        }

    }
}
