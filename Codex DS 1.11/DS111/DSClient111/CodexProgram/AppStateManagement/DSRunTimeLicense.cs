// *************************************************************************************
// ** DS 1.10 Access Rights
// ** DS Licenses
// ** (C) Copyright By 2007-2024 By Irakli Lomidze
// *************************************************************************************
// ** Date 2023-03-28
// ** Date 2023-04-08
// ** Version 1.5

using ILG.Codex.CodexR4;
using ILG.DS.Configurations;
using System;
using System.IO;
using System.Text;


namespace ILG.DS.Access
{

    public enum DSAccessType
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

    public enum DSHistoryAccessType
    {
        NoAccess,
        PublicAccess,
        ExtendedAccess,
        ModificationAccess,
        AdminAccess
    }

    internal class DSRunTimeLicense
    {

        private bool V_Is_ConfidentialDocument_ShowInList = true;
        private bool V_Is_ConfidentialDocument_ID_ShowInList = true;
        private bool V_IsDocumentIDShowInList = true;
        private bool V_IsEnterInConfidentialDocumentAlowed = true;
        private bool V_IsDocumentViewRestrictedMode = false;
        private bool V_IsBossMode = true;
        private bool V_IsAttachmentShow = true;
        private bool V_Is_ConfidentialDocument_SavingAllowed = false;
        private bool V_IsDocumentEditAllow = true;
        private bool V_IsDocumentDeletetAllow = true;
        private bool V_IsNewDocumentAllow = true;
        private bool V_IsDeleteAlowed = true;
        private bool L_DocumentOperation = true;


        private bool V_IsHistoryAccessGranted = true;
        private bool V_IsHistoryExtendedAccessGranted = true;

        private bool V_IsModifiedHistoryGranted = true;
        private bool V_IsDeletedInHistoryGranted = true;

        private bool V_IsSearchinDeletedDocumentsGranted = true;
        private bool V_IsRecoverDeletedDocumentsGranted = true;


        public bool  IsHistoryAccessGranted()
        {
            return V_IsHistoryAccessGranted;
        }

        public bool IsHistoryExtendedAccessGranted()
        {
            return V_IsHistoryExtendedAccessGranted;
        }

        public bool IsModifiedHistoryGranted()
        {
            return V_IsModifiedHistoryGranted;
        }

        public bool IsDeletedInHistoryGranted()
        {
            return V_IsDeletedInHistoryGranted;
        }


        public bool IsSearchinDeletedDocumentsGranted()
        {
            return V_IsSearchinDeletedDocumentsGranted;
        }

        public bool IsRecoverDeletedDocumentsGranted()
        {
            return V_IsRecoverDeletedDocumentsGranted;
        }




        public bool IsConfidentialDocumentShowInList()
        {
            return V_Is_ConfidentialDocument_ShowInList;
        }
        public bool IsConfidentialDocumentIDShowInList()
        {
            return V_Is_ConfidentialDocument_ID_ShowInList;
        }
        public bool IsDocumentIDShowInList()
        {
            return V_IsDocumentIDShowInList;
        }
        public bool IsEnterInConfidentialDocumentAlowed()
        {
            return V_IsEnterInConfidentialDocumentAlowed;
        }
        public bool IsDocumentViewRestrictedMode()
        {
            return V_IsDocumentViewRestrictedMode;
        }
        //static public bool IsAdminMode()
        //{
        //    return V_IsAdminMode;
        //}
        public bool IsAttachmentShow()
        {
            return V_IsAttachmentShow;
        }
        public bool IsConfidentialSaveAllow()
        {
            return V_Is_ConfidentialDocument_SavingAllowed;
        }
        public bool IsDocumentEditAllow()
        {
            return V_IsDocumentEditAllow;
        }
        public bool IsDocumentDeletetAllow()
        {
            return V_IsDocumentDeletetAllow;
        }
        public bool IsNewDocumentAllow()
        {
            return V_IsNewDocumentAllow;
        }
        public bool IsDeleteAlowed()
        {
            return V_IsDeleteAlowed;
        }

        // Level 2 License
        public bool DocumentOperation()
        {
            return L_DocumentOperation;
        }

        // Real Liceses

        private MemoryStream GetMemStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }

        private string GetSHA1HashFromString(string Data)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            MemoryStream oMemStream = null;

            System.Security.Cryptography.SHA1CryptoServiceProvider oSHA1Hasher =
                       new System.Security.Cryptography.SHA1CryptoServiceProvider();

            try
            {
                oMemStream = GetMemStreamFromString(Data);
                arrbytHashValue = oSHA1Hasher.ComputeHash(oMemStream);
                oMemStream.Close();

                strHashData = System.BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (strResult);
        }


        private FileStream GetFileStream(string pathName)
        {
            return (new FileStream(pathName, System.IO.FileMode.Open,
                      FileAccess.Read, System.IO.FileShare.ReadWrite));
        }

        private string GetSHA1Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.SHA1CryptoServiceProvider oSHA1Hasher =
                       new System.Security.Cryptography.SHA1CryptoServiceProvider();

            try
            {
                oFileStream = GetFileStream(pathName);
                arrbytHashValue = oSHA1Hasher.ComputeHash(oFileStream);
                oFileStream.Close();

                strHashData = System.BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error!",
                         System.Windows.Forms.MessageBoxButtons.OK,
                         System.Windows.Forms.MessageBoxIcon.Error,
                         System.Windows.Forms.MessageBoxDefaultButton.Button1);
            }

            return (strResult);
        }
   
        #region Licenses
        /*
        static string License01 = "C1F92CA238016A3E876B3C77D0F9FF9A6DC4CC80";
        static string License02 = "B545A6F10BA0758414CE819B6826C1FD9B48E284";
        static string License03 = "B77A6F7689B9614D7D8A18FACA70B50955565D24";
        static string License04 = "A0DCC6DB3D34CA4C15669238045B632475540E54"; // Guest
        static string License05 = "E841061017F912B161DD7792281088B1D4A5CEB1";
        static string License06 = "F0C9E7E2024D65278597F0A35AC3358176BB22D4";
        static string License07 = "8933A208F49E448C7C9A8EE7DB084EE7AD599855"; //PowerUser
        static string License08 = "78023024A27955D1B21D62533F2B8F7F3353D414";
        static string License09 = "7539DD54E8B1F6F349EA8717FF3807B146BDC142";
        static string License10 = "199527A393883E72DCAB1FC53BC52F5F990158FF"; // Rule 2 True
        static string License11 = "0614B47A212D91E99AD2A2AC184A00EEB633516E"; // RULE 2 False
        static string License12 = "6F20584161C3413EA9C7A3102940240DC8061B85";
        static string License13 = "4267771656562D6A09A24E353852B9680DC6B5BF";
        static string License14 = "8D9D267505A9086E61856D1ECBBFA6550F8824F5";
        static string License15 = "1A626B1C73BF4320197C9183B6B7819F38EE55A1";
        static string License16 = "E4EF3CA5BAE37A832EB9B13FCB9DF26820E7972C";
        static string License17 = "2F2A4DC415A37EA5DCE646B6BDD326FBCB549BB8"; // Power Operator
        static string License18 = "A79A3E9738B3EA56B5059A3CBE69C7F4E6149536";
        static string License19 = "39866656FB9711FA43E6F80AEA6DC615857B1783";
        static string License20 = "F4EAAD34D3433DAFB1286A5F142648B6A93D924C"; // Manager
        static string License21 = "008C35BCCC2E748B803CDAF3416A10EE72DF740C";
        static string License22 = "2D80B84D4D4579CA501EC5AA788062551B143068";
        static string License23 = "977448193E0CE27EF43FB852DD3580730EF6AECA"; // RULE 1 FALSE
        static string License24 = "0F19CC32F96ABD57EA0C7E7199E77A73488B443D";
        static string License25 = "12FB640B02E05E9ED5FC0B7965C7C989476CDE90";
        static string License26 = "958F1D058B3EF1C1964B478F7DE643D64FCE9214"; //User
        static string License27 = "13FCB9DF26820E7972C384C99AC34D5D5DACF43E";
        static string License28 = "E9ED5FC0B7965C7C989476CDE90EFB11AD64EDA2";
        static string License29 = "0334C09575B8364359DAAA51653DB8EE7D5B33DE";
        static string License30 = "9E3AFA2B05E3C6142A19053AABB4B0D9092933B9"; // RULE 1 TRUE
        static string License31 = "64585907DDB86EB0E03590633041941F9C4FDEC8";
        static string License32 = "F10C9E5E7BF0B0D38D5DE4B961936F6DF97116D4";
        static string License33 = "E15014C56BA495AFF525D0E7DF307CE1CB5C7DF4";
        static string License34 = "1600BEC5E2DE73891B497F13139895E247C8B87C"; // Operator
        static string License35 = "83D2F0258836D65D10F9F0E3041A01054DEFA172";
        static string License36 = "F69F4D044B20AB5106DEE32FE7F518A3455A97A3";
        static string License37 = "CFC4DCA14C6BC4D58249D884E1C8B7F13D7539BD";
        static string License38 = "E43C5DEDB7928A247465BF15484D2692A59A2253"; // BOSS
        static string License39 = "A1753EAB7D63593E688953089EC76D0B48EB243F";
        static string License40 = "8D5DE4B961936F6DF97116D433D1F45063476969";
        */
         #endregion Licenses

        #region GetLicense Right
        public DSAccessType GetRights(string profileName)
        {
            if (profileName == null) { throw new Exception("Not Initialized profile"); }
            
            var current = DirectoryConfiguration.Instance.DSCurrentDirectory;
            current = current.EndsWith("/") ? current.Substring(0, current.Length - 1) : current;
            string fname = Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory + $"\\PROFILES\\{profileName}\\", "Role.lxs");

            //String fname = DirectoryConfiguration.Instance.DSCurrentDirectory + "\\Role.lxs";
            if (File.Exists(fname) == false) return DSAccessType.GuestLicense;

            string hash = "";
            hash = GetSHA1Hash(fname);

            DSAccessType Result = DSAccessType.NoAccess;

            switch (hash.Trim())
            {
                case "C1F92CA238016A3E876B3C77D0F9FF9A6DC4CC80": Result = DSAccessType.NoAccess; break;
                case "B545A6F10BA0758414CE819B6826C1FD9B48E284": Result = DSAccessType.NoAccess; break;
                case "B77A6F7689B9614D7D8A18FACA70B50955565D24": Result = DSAccessType.NoAccess; break;
                case "A0DCC6DB3D34CA4C15669238045B632475540E54": Result = DSAccessType.GuestLicense; break; // Guest
                case "E841061017F912B161DD7792281088B1D4A5CEB1": Result = DSAccessType.NoAccess; break;
                case "F0C9E7E2024D65278597F0A35AC3358176BB22D4": Result = DSAccessType.NoAccess; break;
                case "8933A208F49E448C7C9A8EE7DB084EE7AD599855": Result = DSAccessType.PowerOperatorLicense; break; //PowerUser
                case "78023024A27955D1B21D62533F2B8F7F3353D414": Result = DSAccessType.NoAccess; break;
                case "7539DD54E8B1F6F349EA8717FF3807B146BDC142": Result = DSAccessType.NoAccess; break;
                case "199527A393883E72DCAB1FC53BC52F5F990158FF": Result = DSAccessType.NoAccess; break; // Rule 2 True
                case "0614B47A212D91E99AD2A2AC184A00EEB633516E": Result = DSAccessType.NoAccess; break; // RULE 2 False
                case "6F20584161C3413EA9C7A3102940240DC8061B85": Result = DSAccessType.NoAccess; break;
                case "4267771656562D6A09A24E353852B9680DC6B5BF": Result = DSAccessType.NoAccess; break;
                case "8D9D267505A9086E61856D1ECBBFA6550F8824F5": Result = DSAccessType.NoAccess; break;
                case "1A626B1C73BF4320197C9183B6B7819F38EE55A1": Result = DSAccessType.NoAccess; break;
                case "E4EF3CA5BAE37A832EB9B13FCB9DF26820E7972C": Result = DSAccessType.NoAccess; break;
                case "2F2A4DC415A37EA5DCE646B6BDD326FBCB549BB8": Result = DSAccessType.PowerOperatorLicense; break; // Power Operator
                case "A79A3E9738B3EA56B5059A3CBE69C7F4E6149536": Result = DSAccessType.NoAccess; break;
                case "39866656FB9711FA43E6F80AEA6DC615857B1783": Result = DSAccessType.NoAccess; break;
                case "F4EAAD34D3433DAFB1286A5F142648B6A93D924C": Result = DSAccessType.ManagerLicense; break; // Manager
                case "008C35BCCC2E748B803CDAF3416A10EE72DF740C": Result = DSAccessType.NoAccess; break;
                case "2D80B84D4D4579CA501EC5AA788062551B143068": Result = DSAccessType.NoAccess; break;
                case "977448193E0CE27EF43FB852DD3580730EF6AECA": Result = DSAccessType.NoAccess; break; // RULE 1 FALSE
                case "0F19CC32F96ABD57EA0C7E7199E77A73488B443D": Result = DSAccessType.NoAccess; break;
                case "12FB640B02E05E9ED5FC0B7965C7C989476CDE90": Result = DSAccessType.NoAccess; break;
                case "958F1D058B3EF1C1964B478F7DE643D64FCE9214": Result = DSAccessType.UserLicense; break; //User
                case "13FCB9DF26820E7972C384C99AC34D5D5DACF43E": Result = DSAccessType.NoAccess; break;
                case "E9ED5FC0B7965C7C989476CDE90EFB11AD64EDA2": Result = DSAccessType.NoAccess; break;
                case "0334C09575B8364359DAAA51653DB8EE7D5B33DE": Result = DSAccessType.NoAccess; break;
                case "9E3AFA2B05E3C6142A19053AABB4B0D9092933B9": Result = DSAccessType.NoAccess; break; // RULE 1 TRUE
                case "64585907DDB86EB0E03590633041941F9C4FDEC8": Result = DSAccessType.NoAccess; break;
                case "F10C9E5E7BF0B0D38D5DE4B961936F6DF97116D4": Result = DSAccessType.NoAccess; break;
                case "E15014C56BA495AFF525D0E7DF307CE1CB5C7DF4": Result = DSAccessType.NoAccess; break;
                case "1600BEC5E2DE73891B497F13139895E247C8B87C": Result = DSAccessType.OperatorLicense; break; // Operator
                case "83D2F0258836D65D10F9F0E3041A01054DEFA172": Result = DSAccessType.NoAccess; break;
                case "F69F4D044B20AB5106DEE32FE7F518A3455A97A3": Result = DSAccessType.NoAccess; break;
                case "CFC4DCA14C6BC4D58249D884E1C8B7F13D7539BD": Result = DSAccessType.NoAccess; break;
                case "E43C5DEDB7928A247465BF15484D2692A59A2253": Result = DSAccessType.BossLicense; break; // BOSS
                case "A1753EAB7D63593E688953089EC76D0B48EB243F": Result = DSAccessType.NoAccess; break;
                case "8D5DE4B961936F6DF97116D433D1F45063476969": Result = DSAccessType.NoAccess; break;
                default: Result = DSAccessType.NoAccess; break;
            }
            return Result;
            
        }

        public DSHistoryAccessType GetHistoryRights(string profileName)
        {
            if (profileName == null) { throw new Exception("Not Initialized profile"); }

            var current = DirectoryConfiguration.Instance.DSCurrentDirectory;
            current = current.EndsWith("/") ? current.Substring(0, current.Length - 1) : current;
            string fname = Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory + $"\\PROFILES\\{profileName}\\", "History_Role.json");

            //String fname = Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory, "History_Role.json");
            if (File.Exists(fname) == false) return DSHistoryAccessType.NoAccess;

            string hash = "";
            hash = GetSHA1Hash(fname);
            hash = GetSHA1HashFromString(hash);


            DSHistoryAccessType Result = DSHistoryAccessType.NoAccess;

            switch (hash.Trim())
            {
                case "C1F92CA238016A3E876B3C77D0F9FF9A6DC4CC80": Result = DSHistoryAccessType.NoAccess; break;
                case "B545A6F10BA0758414CE819B6826C1FD9B48E284": Result = DSHistoryAccessType.NoAccess; break;
                case "B77A6F7689B9614D7D8A18FACA70B50955565D24": Result = DSHistoryAccessType.NoAccess; break;
                case "6789E7F8A19D80913BA96D083558331181FC0C51": Result = DSHistoryAccessType.NoAccess; break; 
                case "061BD87C6909692E335C14C38505546383BF2FE1": Result = DSHistoryAccessType.AdminAccess; break;
                case "F0C9E7E2024D65278597F0A35AC3358176BB22D4": Result = DSHistoryAccessType.NoAccess; break;
                case "8933A208F49E448C7C9A8EE7DB084EE7AD599855": Result = DSHistoryAccessType.NoAccess; break; 
                case "C46B354D047620FDC98492F1B1E7DDE8C49582C9": Result = DSHistoryAccessType.ModificationAccess; break;
                case "7539DD54E8B1F6F349EA8717FF3807B146BDC142": Result = DSHistoryAccessType.NoAccess; break;
                case "199527A393883E72DCAB1FC53BC52F5F990158FF": Result = DSHistoryAccessType.NoAccess; break; 
                case "6F878FEEDDC64006DE251F6510BFDAB50474AA01": Result = DSHistoryAccessType.NoAccess; break;
                case "6F20584161C3413EA9C7A3102940240DC8061B85": Result = DSHistoryAccessType.NoAccess; break;
                case "4267771656562D6A09A24E353852B9680DC6B5BF": Result = DSHistoryAccessType.NoAccess; break;
                case "8D9D267505A9086E61856D1ECBBFA6550F8824F5": Result = DSHistoryAccessType.NoAccess; break;
                case "1A626B1C73BF4320197C9183B6B7819F38EE55A1": Result = DSHistoryAccessType.NoAccess; break;
                case "C0C04CC756BAE3E2FFB0867CBE2A6927A94C9D4C": Result = DSHistoryAccessType.PublicAccess; break;
                case "2F2A4DC415A37EA5DCE646B6BDD326FBCB549BB8": Result = DSHistoryAccessType.NoAccess; break; 
                case "543268C754431612FDA40EE727B9291FB5B01AA3": Result = DSHistoryAccessType.NoAccess; break;
                case "39866656FB9711FA43E6F80AEA6DC615857B1783": Result = DSHistoryAccessType.NoAccess; break;
                case "F4EAAD34D3433DAFB1286A5F142648B6A93D924C": Result = DSHistoryAccessType.NoAccess; break; // Manager
                case "008C35BCCC2E748B803CDAF3416A10EE72DF740C": Result = DSHistoryAccessType.NoAccess; break;
                case "2D80B84D4D4579CA501EC5AA788062551B143068": Result = DSHistoryAccessType.NoAccess; break;
                case "977448193E0CE27EF43FB852DD3580730EF6AECA": Result = DSHistoryAccessType.NoAccess; break; 
                case "0F19CC32F96ABD57EA0C7E7199E77A73488B443D": Result = DSHistoryAccessType.NoAccess; break;
                case "12FB640B02E05E9ED5FC0B7965C7C989476CDE90": Result = DSHistoryAccessType.NoAccess; break;
                case "958F1D058B3EF1C1964B478F7DE643D64FCE9214": Result = DSHistoryAccessType.NoAccess; break; 
                case "13FCB9DF26820E7972C384C99AC34D5D5DACF43E": Result = DSHistoryAccessType.NoAccess; break;
                case "E9ED5FC0B7965C7C989476CDE90EFB11AD64EDA2": Result = DSHistoryAccessType.NoAccess; break;
                case "0334C09575B8364359DAAA51653DB8EE7D5B33DE": Result = DSHistoryAccessType.NoAccess; break;
                case "9E3AFA2B05E3C6142A19053AABB4B0D9092933B9": Result = DSHistoryAccessType.NoAccess; break; 
                case "64585907DDB86EB0E03590633041941F9C4FDEC8": Result = DSHistoryAccessType.NoAccess; break;
                case "F10C9E5E7BF0B0D38D5DE4B961936F6DF97116D4": Result = DSHistoryAccessType.NoAccess; break;
                case "E15014C56BA495AFF525D0E7DF307CE1CB5C7DF4": Result = DSHistoryAccessType.NoAccess; break;
                case "ABBD80AECB54EDEE41D59CA8D199976FC8776B05": Result = DSHistoryAccessType.ExtendedAccess; break; // Operator
                case "83D2F0258836D65D10F9F0E3041A01054DEFA172": Result = DSHistoryAccessType.NoAccess; break;
                case "F69F4D044B20AB5106DEE32FE7F518A3455A97A3": Result = DSHistoryAccessType.NoAccess; break;
                case "CFC4DCA14C6BC4D58249D884E1C8B7F13D7539BD": Result = DSHistoryAccessType.NoAccess; break;
                case "4966B3D71356102AD6E8037F36CBEC9E7FA515E7": Result = DSHistoryAccessType.NoAccess; break; // BOSS
                case "A1753EAB7D63593E688953089EC76D0B48EB243F": Result = DSHistoryAccessType.NoAccess; break;
                case "8D5DE4B961936F6DF97116D433D1F45063476969": Result = DSHistoryAccessType.NoAccess; break;
                default: Result = DSHistoryAccessType.NoAccess; break;
            }
            return Result;

        }

        public bool IsRule1Exists(string profileName)
        {
            if (profileName == null) { throw new Exception("Not Initialized profile"); }

            var current = DirectoryConfiguration.Instance.DSCurrentDirectory;
            current = current.EndsWith("/") ? current.Substring(0, current.Length - 1) : current;
            string fname = Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory + $"\\PROFILES\\{profileName}\\", "Rule1.rxs");
            return File.Exists(fname);
        }

        public bool IsRule2Exists(string profileName)
        {
            if (profileName == null) { throw new Exception("Not Initialized profile"); }

            var current = DirectoryConfiguration.Instance.DSCurrentDirectory;
            current = current.EndsWith("/") ? current.Substring(0, current.Length - 1) : current;
            string fname = Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory + $"\\PROFILES\\{profileName}\\", "Rule2.rxs");
            return File.Exists(fname);
        }
        public bool GetRule1(string profileName)
        {

            if (profileName == null) { throw new Exception("Not Initialized profile"); }

            var current = DirectoryConfiguration.Instance.DSCurrentDirectory;
            current = current.EndsWith("/") ? current.Substring(0, current.Length - 1) : current;
            string fname = Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory + $"\\PROFILES\\{profileName}\\", "Rule1.rxs");

            //String fname = DirectoryConfiguration.Instance.DSCurrentDirectory + "\\Rule1.rxs";
            if (File.Exists(fname) == false) return false;

            string hash = "";
            hash = GetSHA1Hash(fname);

            bool Result = false;

            switch (hash.Trim())
            {
                case "C1F92CA238016A3E876B3C77D0F9FF9A6DC4CC80": Result = false; break;
                case "B545A6F10BA0758414CE819B6826C1FD9B48E284": Result = false; break;
                case "B77A6F7689B9614D7D8A18FACA70B50955565D24": Result = false; break;
                case "A0DCC6DB3D34CA4C15669238045B632475540E54": Result = false; break;// Guest
                case "E841061017F912B161DD7792281088B1D4A5CEB1": Result = false; break;
                case "F0C9E7E2024D65278597F0A35AC3358176BB22D4": Result = false; break;
                case "8933A208F49E448C7C9A8EE7DB084EE7AD599855": Result = false; break; //PowerUser
                case "78023024A27955D1B21D62533F2B8F7F3353D414": Result = false; break;
                case "7539DD54E8B1F6F349EA8717FF3807B146BDC142": Result = false; break;
                case "199527A393883E72DCAB1FC53BC52F5F990158FF": Result = false; break; // Rule 2 True
                case "0614B47A212D91E99AD2A2AC184A00EEB633516E": Result = false; break; // RULE 2 False
                case "6F20584161C3413EA9C7A3102940240DC8061B85": Result = false; break;
                case "4267771656562D6A09A24E353852B9680DC6B5BF": Result = false; break;
                case "8D9D267505A9086E61856D1ECBBFA6550F8824F5": Result = false; break;
                case "1A626B1C73BF4320197C9183B6B7819F38EE55A1": Result = false; break;
                case "E4EF3CA5BAE37A832EB9B13FCB9DF26820E7972C": Result = false; break;
                case "2F2A4DC415A37EA5DCE646B6BDD326FBCB549BB8": Result = false; break; // Power Operator
                case "A79A3E9738B3EA56B5059A3CBE69C7F4E6149536": Result = false; break;
                case "39866656FB9711FA43E6F80AEA6DC615857B1783": Result = false; break;
                case "F4EAAD34D3433DAFB1286A5F142648B6A93D924C": Result = false; break; // Manager
                case "008C35BCCC2E748B803CDAF3416A10EE72DF740C": Result = false; break;
                case "2D80B84D4D4579CA501EC5AA788062551B143068": Result = false; break;
                case "977448193E0CE27EF43FB852DD3580730EF6AECA": Result = false; break; // RULE 1 FALSE
                case "0F19CC32F96ABD57EA0C7E7199E77A73488B443D": Result = false; break;
                case "12FB640B02E05E9ED5FC0B7965C7C989476CDE90": Result = false; break;
                case "958F1D058B3EF1C1964B478F7DE643D64FCE9214": Result = false; break; //User
                case "13FCB9DF26820E7972C384C99AC34D5D5DACF43E": Result = false; break;
                case "E9ED5FC0B7965C7C989476CDE90EFB11AD64EDA2": Result = false; break;
                case "0334C09575B8364359DAAA51653DB8EE7D5B33DE": Result = false; break;
                case "9E3AFA2B05E3C6142A19053AABB4B0D9092933B9": Result = true;  break; // RULE 1 TRUE
                case "64585907DDB86EB0E03590633041941F9C4FDEC8": Result = false; break;
                case "F10C9E5E7BF0B0D38D5DE4B961936F6DF97116D4": Result = false; break;
                case "E15014C56BA495AFF525D0E7DF307CE1CB5C7DF4": Result = false; break;
                case "1600BEC5E2DE73891B497F13139895E247C8B87C": Result = false; break; // Operator
                case "83D2F0258836D65D10F9F0E3041A01054DEFA172": Result = false; break;
                case "F69F4D044B20AB5106DEE32FE7F518A3455A97A3": Result = false; break;
                case "CFC4DCA14C6BC4D58249D884E1C8B7F13D7539BD": Result = false; break;
                case "E43C5DEDB7928A247465BF15484D2692A59A2253": Result = false; break; // BOSS
                case "A1753EAB7D63593E688953089EC76D0B48EB243F": Result = false; break;
                case "8D5DE4B961936F6DF97116D433D1F45063476969": Result = false; break;
                default: Result = false; break;
            }
            return Result;

        }

        public bool GetRule2(string profileName)
        {

            if (profileName == null) { throw new Exception("Not Initialized profile"); }

            var current = DirectoryConfiguration.Instance.DSCurrentDirectory;
            current = current.EndsWith("/") ? current.Substring(0, current.Length - 1) : current;
            string fname = Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory + $"\\PROFILES\\{profileName}\\", "Rule2.rxs");

            //String fname = DirectoryConfiguration.Instance.DSCurrentDirectory + "\\Rule2.rxs";
            if (File.Exists(fname) == false) return false;

            string hash = "";
            hash = GetSHA1Hash(fname);

            bool Result = false;

            switch (hash.Trim())
            {
                case "C1F92CA238016A3E876B3C77D0F9FF9A6DC4CC80": Result = false; break;
                case "B545A6F10BA0758414CE819B6826C1FD9B48E284": Result = false; break;
                case "B77A6F7689B9614D7D8A18FACA70B50955565D24": Result = false; break;
                case "A0DCC6DB3D34CA4C15669238045B632475540E54": Result = false; break;// Guest
                case "E841061017F912B161DD7792281088B1D4A5CEB1": Result = false; break;
                case "F0C9E7E2024D65278597F0A35AC3358176BB22D4": Result = false; break;
                case "8933A208F49E448C7C9A8EE7DB084EE7AD599855": Result = false; break; //PowerUser
                case "78023024A27955D1B21D62533F2B8F7F3353D414": Result = false; break;
                case "7539DD54E8B1F6F349EA8717FF3807B146BDC142": Result = false; break;
                case "199527A393883E72DCAB1FC53BC52F5F990158FF": Result = true; break; // Rule 2 True
                case "0614B47A212D91E99AD2A2AC184A00EEB633516E": Result = false; break; // RULE 2 False
                case "6F20584161C3413EA9C7A3102940240DC8061B85": Result = false; break;
                case "4267771656562D6A09A24E353852B9680DC6B5BF": Result = false; break;
                case "8D9D267505A9086E61856D1ECBBFA6550F8824F5": Result = false; break;
                case "1A626B1C73BF4320197C9183B6B7819F38EE55A1": Result = false; break;
                case "E4EF3CA5BAE37A832EB9B13FCB9DF26820E7972C": Result = false; break;
                case "2F2A4DC415A37EA5DCE646B6BDD326FBCB549BB8": Result = false; break; // Power Operator
                case "A79A3E9738B3EA56B5059A3CBE69C7F4E6149536": Result = false; break;
                case "39866656FB9711FA43E6F80AEA6DC615857B1783": Result = false; break;
                case "F4EAAD34D3433DAFB1286A5F142648B6A93D924C": Result = false; break; // Manager
                case "008C35BCCC2E748B803CDAF3416A10EE72DF740C": Result = false; break;
                case "2D80B84D4D4579CA501EC5AA788062551B143068": Result = false; break;
                case "977448193E0CE27EF43FB852DD3580730EF6AECA": Result = false; break; // RULE 1 FALSE
                case "0F19CC32F96ABD57EA0C7E7199E77A73488B443D": Result = false; break;
                case "12FB640B02E05E9ED5FC0B7965C7C989476CDE90": Result = false; break;
                case "958F1D058B3EF1C1964B478F7DE643D64FCE9214": Result = false; break; //User
                case "13FCB9DF26820E7972C384C99AC34D5D5DACF43E": Result = false; break;
                case "E9ED5FC0B7965C7C989476CDE90EFB11AD64EDA2": Result = false; break;
                case "0334C09575B8364359DAAA51653DB8EE7D5B33DE": Result = false; break;
                case "9E3AFA2B05E3C6142A19053AABB4B0D9092933B9": Result = false; break; // RULE 1 TRUE
                case "64585907DDB86EB0E03590633041941F9C4FDEC8": Result = false; break;
                case "F10C9E5E7BF0B0D38D5DE4B961936F6DF97116D4": Result = false; break;
                case "E15014C56BA495AFF525D0E7DF307CE1CB5C7DF4": Result = false; break;
                case "1600BEC5E2DE73891B497F13139895E247C8B87C": Result = false; break; // Operator
                case "83D2F0258836D65D10F9F0E3041A01054DEFA172": Result = false; break;
                case "F69F4D044B20AB5106DEE32FE7F518A3455A97A3": Result = false; break;
                case "CFC4DCA14C6BC4D58249D884E1C8B7F13D7539BD": Result = false; break;
                case "E43C5DEDB7928A247465BF15484D2692A59A2253": Result = false; break; // BOSS
                case "A1753EAB7D63593E688953089EC76D0B48EB243F": Result = false; break;
                case "8D5DE4B961936F6DF97116D433D1F45063476969": Result = false; break;
                default: Result = false; break;
            }
            return Result;
        }

        #endregion GetLicense Right

        

        public void SetLicenseAccess(string profileName)
        {
            #region Access Right
            bool rule1_exists = IsRule1Exists(profileName);
            bool rule2_exists = IsRule2Exists(profileName);

            
            

            DSAccessType f = GetRights(profileName);
            switch (f)
            {
                case DSAccessType.NoAccess:
                     V_Is_ConfidentialDocument_ShowInList = false;
                     V_Is_ConfidentialDocument_ID_ShowInList = false;
                     V_IsDocumentIDShowInList = false;
                     V_IsEnterInConfidentialDocumentAlowed = false;
                     V_IsDocumentViewRestrictedMode = true;
                     V_IsBossMode = false;
                     V_IsAttachmentShow = false;
                     V_Is_ConfidentialDocument_SavingAllowed = false;
                     V_IsDocumentEditAllow = false;
                     V_IsDocumentDeletetAllow = false;
                     V_IsNewDocumentAllow = false;
                     V_IsDeleteAlowed = false;
                     L_DocumentOperation = false;
                    break;
                case DSAccessType.GuestLicense:
                    V_Is_ConfidentialDocument_ShowInList = false;
                    V_Is_ConfidentialDocument_ID_ShowInList = false;
                    V_IsDocumentIDShowInList = false;
                    V_IsEnterInConfidentialDocumentAlowed = false;
                    V_IsDocumentViewRestrictedMode = true;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = true;
                    V_Is_ConfidentialDocument_SavingAllowed = false;
                    V_IsDocumentEditAllow = false;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = false;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = false;
                    break;
                case DSAccessType.UserLicense:
                    V_Is_ConfidentialDocument_ShowInList = false;
                    V_Is_ConfidentialDocument_ID_ShowInList = false;
                    V_IsDocumentIDShowInList = false;
                    V_IsEnterInConfidentialDocumentAlowed = false;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = true;
                    V_Is_ConfidentialDocument_SavingAllowed = false;
                    V_IsDocumentEditAllow = false;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = false;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = false;
                    break;
                case DSAccessType.PowertLicense:
                    V_Is_ConfidentialDocument_ShowInList = true;
                    V_Is_ConfidentialDocument_ID_ShowInList = false;
                    V_IsDocumentIDShowInList = false;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = true;
                    V_Is_ConfidentialDocument_SavingAllowed = false;
                    V_IsDocumentEditAllow = false;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = false;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = false;
                    break;
                case DSAccessType.ManagerLicense:
                    V_Is_ConfidentialDocument_ShowInList = true;
                    V_Is_ConfidentialDocument_ID_ShowInList = false;
                    V_IsDocumentIDShowInList = false;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = true;
                    V_Is_ConfidentialDocument_SavingAllowed = false;
                    V_IsDocumentEditAllow = false;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = false;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = false;
                    break;
                case DSAccessType.OperatorLicense:
                    V_Is_ConfidentialDocument_ShowInList = true;
                    V_Is_ConfidentialDocument_ID_ShowInList = false;
                    V_IsDocumentIDShowInList = true;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = true;
                    V_Is_ConfidentialDocument_SavingAllowed = false;
                    V_IsDocumentEditAllow = true;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = true;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = true;
                    break;
                case DSAccessType.PowerOperatorLicense:
                    V_Is_ConfidentialDocument_ShowInList = true;
                    V_Is_ConfidentialDocument_ID_ShowInList = true;
                    V_IsDocumentIDShowInList = true;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = true;
                    V_IsAttachmentShow = true;
                    V_Is_ConfidentialDocument_SavingAllowed = true;
                    V_IsDocumentEditAllow = true;
                    V_IsDocumentDeletetAllow = true;
                    V_IsNewDocumentAllow = true;
                    V_IsDeleteAlowed = true;
                    L_DocumentOperation = true;
                    break;
                case DSAccessType.BossLicense:
                    V_Is_ConfidentialDocument_ShowInList = true;
                    V_Is_ConfidentialDocument_ID_ShowInList = true;
                    V_IsDocumentIDShowInList = true;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = true;
                    V_IsAttachmentShow = true;
                    V_Is_ConfidentialDocument_SavingAllowed = true;
                    V_IsDocumentEditAllow = true;
                    V_IsDocumentDeletetAllow = true;
                    V_IsNewDocumentAllow = true;
                    V_IsDeleteAlowed = true;
                    L_DocumentOperation = true;
                    break;
            }
            #endregion Access Right

            #region History Access Right
            DSHistoryAccessType h = GetHistoryRights(profileName);
            switch (h)
            {
                case DSHistoryAccessType.NoAccess:
                    V_IsHistoryAccessGranted = false;
                    V_IsHistoryExtendedAccessGranted = false;

                    V_IsModifiedHistoryGranted = false;
                    V_IsDeletedInHistoryGranted = false;

                    V_IsSearchinDeletedDocumentsGranted = false;
                    V_IsRecoverDeletedDocumentsGranted = false;
                    break;

                case DSHistoryAccessType.PublicAccess:
                    V_IsHistoryAccessGranted = true;
                    V_IsHistoryExtendedAccessGranted = false;

                    V_IsModifiedHistoryGranted = false;
                    V_IsDeletedInHistoryGranted = false;

                    V_IsSearchinDeletedDocumentsGranted = false;
                    V_IsRecoverDeletedDocumentsGranted = false;
                    break;

                case DSHistoryAccessType.ExtendedAccess:
                    V_IsHistoryAccessGranted = true;
                    V_IsHistoryExtendedAccessGranted = true;

                    V_IsModifiedHistoryGranted = false;
                    V_IsDeletedInHistoryGranted = false;

                    V_IsSearchinDeletedDocumentsGranted = false;
                    V_IsRecoverDeletedDocumentsGranted = false;
                    break;

                case DSHistoryAccessType.ModificationAccess:
                    V_IsHistoryAccessGranted = true;
                    V_IsHistoryExtendedAccessGranted = true;

                    V_IsModifiedHistoryGranted = true;
                    V_IsDeletedInHistoryGranted = true; // ეს რეალურად არ შლის დოკუმენტს. მხილოდ მალავს წაშლილის სტატუსით

                    V_IsSearchinDeletedDocumentsGranted = false;
                    V_IsRecoverDeletedDocumentsGranted = false;
                    break;

                case DSHistoryAccessType.AdminAccess:
                    V_IsHistoryAccessGranted = true;
                    V_IsHistoryExtendedAccessGranted = true;

                    V_IsModifiedHistoryGranted = true;
                    V_IsDeletedInHistoryGranted = true;

                    V_IsSearchinDeletedDocumentsGranted = true;
                    V_IsRecoverDeletedDocumentsGranted = true;  // რეალურად ამით მოწმდეგა ადმინისტრტორსი დაშვება
                    break;


            }
            #endregion History Access Right


            if (rule1_exists)
            {
                bool rule1_V_IsConfidentialDocumentShowInList = GetRule1(profileName);
                if (rule1_V_IsConfidentialDocumentShowInList == true) V_Is_ConfidentialDocument_ShowInList = true;
                else V_Is_ConfidentialDocument_ShowInList = false;
            }

            if (rule1_exists)
            {
                bool rule2_V_IsAttachmentShow = GetRule2(profileName);
                if (rule2_V_IsAttachmentShow == true) V_IsAttachmentShow = true;
                else V_IsAttachmentShow = false;
            }
 
        }

    }
}
