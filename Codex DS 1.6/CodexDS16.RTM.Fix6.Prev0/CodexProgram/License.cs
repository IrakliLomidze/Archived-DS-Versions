// Codex DS Licenses
// Copyright By Georgian Microsystems
// Code Version 2018 August 31



using System;
using System.IO;
using System.Text;

namespace ILG.Codex.CodexR4
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

    public enum HistoryAccessType
    {
        NoAccess,
        PublicAccess,
        ExtendedAccess,
        ModificationAccess,
        AdminAccess
    }

    class License
    {

        static bool V_IsConfidentialDocumentShowInList = true;
        static bool V_IsConfidentialDocumentIDShowInList = true;
        static bool V_IsDocumentIDShowInList = true;
        static bool V_IsEnterInConfidentialDocumentAlowed = true;
        static bool V_IsDocumentViewRestrictedMode = false;
        static bool V_IsBossMode = true;
        static bool V_IsAttachmentShow = true;
        static bool V_IsConfidentialSaveAllow = false;
        static bool V_IsDocumentEditAllow = true;
        static bool V_IsDocumentDeletetAllow = true;
        static bool V_IsNewDocumentAllow = true;
        static bool V_IsDeleteAlowed = true;
        static bool L_DocumentOperation = true;


        static bool V_IsHistoryAccessGranted = true;
        static bool V_IsHistoryExtendedAccessGranted = true;

        static bool V_IsModifiedHistoryGranted = true;
        static bool V_IsDeletedInHistoryGranted = true;

        static bool V_IsSearchinDeletedDocumentsGranted = true;
        static bool V_IsRecoverDeletedDocumentsGranted = true;


        static public bool  IsHistoryAccessGranted()
        {
            return V_IsHistoryAccessGranted;
        }

        static public bool IsHistoryExtendedAccessGranted()
        {
            return V_IsHistoryExtendedAccessGranted;
        }

        static public bool IsModifiedHistoryGranted()
        {
            return V_IsModifiedHistoryGranted;
        }

        static public bool IsDeletedInHistoryGranted()
        {
            return V_IsDeletedInHistoryGranted;
        }


        static public bool IsSearchinDeletedDocumentsGranted()
        {
            return V_IsSearchinDeletedDocumentsGranted;
        }

        static public bool IsRecoverDeletedDocumentsGranted()
        {
            return V_IsRecoverDeletedDocumentsGranted;
        }




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
        //static public bool IsAdminMode()
        //{
        //    return V_IsAdminMode;
        //}
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

        public static MemoryStream GetMemStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }

        public static string GetSHA1HashFromString(string Data)
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


        private static FileStream GetFileStream(string pathName)
        {
            return (new FileStream(pathName, System.IO.FileMode.Open,
                      FileAccess.Read, System.IO.FileShare.ReadWrite));
        }

        public static string GetSHA1Hash(string pathName)
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
        public static AccessType GetRights()
        {
            
            String fname = DirectoryConfiguration.CurrentDirectory + "\\Role.lxs";
            if (File.Exists(fname) == false) return AccessType.NoAccess;

            string hash = "";
            hash = GetSHA1Hash(fname);

            AccessType Result = AccessType.NoAccess;

            switch (hash.Trim())
            {
                case "C1F92CA238016A3E876B3C77D0F9FF9A6DC4CC80": Result = AccessType.NoAccess; break;
                case "B545A6F10BA0758414CE819B6826C1FD9B48E284": Result = AccessType.NoAccess; break;
                case "B77A6F7689B9614D7D8A18FACA70B50955565D24": Result = AccessType.NoAccess; break;
                case "A0DCC6DB3D34CA4C15669238045B632475540E54": Result = AccessType.GuestLicense; break; // Guest
                case "E841061017F912B161DD7792281088B1D4A5CEB1": Result = AccessType.NoAccess; break;
                case "F0C9E7E2024D65278597F0A35AC3358176BB22D4": Result = AccessType.NoAccess; break;
                case "8933A208F49E448C7C9A8EE7DB084EE7AD599855": Result = AccessType.PowerOperatorLicense; break; //PowerUser
                case "78023024A27955D1B21D62533F2B8F7F3353D414": Result = AccessType.NoAccess; break;
                case "7539DD54E8B1F6F349EA8717FF3807B146BDC142": Result = AccessType.NoAccess; break;
                case "199527A393883E72DCAB1FC53BC52F5F990158FF": Result = AccessType.NoAccess; break; // Rule 2 True
                case "0614B47A212D91E99AD2A2AC184A00EEB633516E": Result = AccessType.NoAccess; break; // RULE 2 False
                case "6F20584161C3413EA9C7A3102940240DC8061B85": Result = AccessType.NoAccess; break;
                case "4267771656562D6A09A24E353852B9680DC6B5BF": Result = AccessType.NoAccess; break;
                case "8D9D267505A9086E61856D1ECBBFA6550F8824F5": Result = AccessType.NoAccess; break;
                case "1A626B1C73BF4320197C9183B6B7819F38EE55A1": Result = AccessType.NoAccess; break;
                case "E4EF3CA5BAE37A832EB9B13FCB9DF26820E7972C": Result = AccessType.NoAccess; break;
                case "2F2A4DC415A37EA5DCE646B6BDD326FBCB549BB8": Result = AccessType.PowerOperatorLicense; break; // Power Operator
                case "A79A3E9738B3EA56B5059A3CBE69C7F4E6149536": Result = AccessType.NoAccess; break;
                case "39866656FB9711FA43E6F80AEA6DC615857B1783": Result = AccessType.NoAccess; break;
                case "F4EAAD34D3433DAFB1286A5F142648B6A93D924C": Result = AccessType.ManagerLicense; break; // Manager
                case "008C35BCCC2E748B803CDAF3416A10EE72DF740C": Result = AccessType.NoAccess; break;
                case "2D80B84D4D4579CA501EC5AA788062551B143068": Result = AccessType.NoAccess; break;
                case "977448193E0CE27EF43FB852DD3580730EF6AECA": Result = AccessType.NoAccess; break; // RULE 1 FALSE
                case "0F19CC32F96ABD57EA0C7E7199E77A73488B443D": Result = AccessType.NoAccess; break;
                case "12FB640B02E05E9ED5FC0B7965C7C989476CDE90": Result = AccessType.NoAccess; break;
                case "958F1D058B3EF1C1964B478F7DE643D64FCE9214": Result = AccessType.UserLicense; break; //User
                case "13FCB9DF26820E7972C384C99AC34D5D5DACF43E": Result = AccessType.NoAccess; break;
                case "E9ED5FC0B7965C7C989476CDE90EFB11AD64EDA2": Result = AccessType.NoAccess; break;
                case "0334C09575B8364359DAAA51653DB8EE7D5B33DE": Result = AccessType.NoAccess; break;
                case "9E3AFA2B05E3C6142A19053AABB4B0D9092933B9": Result = AccessType.NoAccess; break; // RULE 1 TRUE
                case "64585907DDB86EB0E03590633041941F9C4FDEC8": Result = AccessType.NoAccess; break;
                case "F10C9E5E7BF0B0D38D5DE4B961936F6DF97116D4": Result = AccessType.NoAccess; break;
                case "E15014C56BA495AFF525D0E7DF307CE1CB5C7DF4": Result = AccessType.NoAccess; break;
                case "1600BEC5E2DE73891B497F13139895E247C8B87C": Result = AccessType.OperatorLicense; break; // Operator
                case "83D2F0258836D65D10F9F0E3041A01054DEFA172": Result = AccessType.NoAccess; break;
                case "F69F4D044B20AB5106DEE32FE7F518A3455A97A3": Result = AccessType.NoAccess; break;
                case "CFC4DCA14C6BC4D58249D884E1C8B7F13D7539BD": Result = AccessType.NoAccess; break;
                case "E43C5DEDB7928A247465BF15484D2692A59A2253": Result = AccessType.BossLicense; break; // BOSS
                case "A1753EAB7D63593E688953089EC76D0B48EB243F": Result = AccessType.NoAccess; break;
                case "8D5DE4B961936F6DF97116D433D1F45063476969": Result = AccessType.NoAccess; break;
                default: Result = AccessType.NoAccess; break;
            }
            return Result;
            
        }

        public static HistoryAccessType GetHistoryRights()
        {

            String fname = Path.Combine(DirectoryConfiguration.CurrentDirectory, "History_Role.json");
            if (File.Exists(fname) == false) return HistoryAccessType.NoAccess;

            string hash = "";
            hash = GetSHA1Hash(fname);
            hash = GetSHA1HashFromString(hash);


            HistoryAccessType Result = HistoryAccessType.NoAccess;

            switch (hash.Trim())
            {
                case "C1F92CA238016A3E876B3C77D0F9FF9A6DC4CC80": Result = HistoryAccessType.NoAccess; break;
                case "B545A6F10BA0758414CE819B6826C1FD9B48E284": Result = HistoryAccessType.NoAccess; break;
                case "B77A6F7689B9614D7D8A18FACA70B50955565D24": Result = HistoryAccessType.NoAccess; break;
                case "6789E7F8A19D80913BA96D083558331181FC0C51": Result = HistoryAccessType.NoAccess; break; 
                case "061BD87C6909692E335C14C38505546383BF2FE1": Result = HistoryAccessType.AdminAccess; break;
                case "F0C9E7E2024D65278597F0A35AC3358176BB22D4": Result = HistoryAccessType.NoAccess; break;
                case "8933A208F49E448C7C9A8EE7DB084EE7AD599855": Result = HistoryAccessType.NoAccess; break; 
                case "C46B354D047620FDC98492F1B1E7DDE8C49582C9": Result = HistoryAccessType.ModificationAccess; break;
                case "7539DD54E8B1F6F349EA8717FF3807B146BDC142": Result = HistoryAccessType.NoAccess; break;
                case "199527A393883E72DCAB1FC53BC52F5F990158FF": Result = HistoryAccessType.NoAccess; break; 
                case "6F878FEEDDC64006DE251F6510BFDAB50474AA01": Result = HistoryAccessType.NoAccess; break;
                case "6F20584161C3413EA9C7A3102940240DC8061B85": Result = HistoryAccessType.NoAccess; break;
                case "4267771656562D6A09A24E353852B9680DC6B5BF": Result = HistoryAccessType.NoAccess; break;
                case "8D9D267505A9086E61856D1ECBBFA6550F8824F5": Result = HistoryAccessType.NoAccess; break;
                case "1A626B1C73BF4320197C9183B6B7819F38EE55A1": Result = HistoryAccessType.NoAccess; break;
                case "C0C04CC756BAE3E2FFB0867CBE2A6927A94C9D4C": Result = HistoryAccessType.PublicAccess; break;
                case "2F2A4DC415A37EA5DCE646B6BDD326FBCB549BB8": Result = HistoryAccessType.NoAccess; break; 
                case "543268C754431612FDA40EE727B9291FB5B01AA3": Result = HistoryAccessType.NoAccess; break;
                case "39866656FB9711FA43E6F80AEA6DC615857B1783": Result = HistoryAccessType.NoAccess; break;
                case "F4EAAD34D3433DAFB1286A5F142648B6A93D924C": Result = HistoryAccessType.NoAccess; break; // Manager
                case "008C35BCCC2E748B803CDAF3416A10EE72DF740C": Result = HistoryAccessType.NoAccess; break;
                case "2D80B84D4D4579CA501EC5AA788062551B143068": Result = HistoryAccessType.NoAccess; break;
                case "977448193E0CE27EF43FB852DD3580730EF6AECA": Result = HistoryAccessType.NoAccess; break; 
                case "0F19CC32F96ABD57EA0C7E7199E77A73488B443D": Result = HistoryAccessType.NoAccess; break;
                case "12FB640B02E05E9ED5FC0B7965C7C989476CDE90": Result = HistoryAccessType.NoAccess; break;
                case "958F1D058B3EF1C1964B478F7DE643D64FCE9214": Result = HistoryAccessType.NoAccess; break; 
                case "13FCB9DF26820E7972C384C99AC34D5D5DACF43E": Result = HistoryAccessType.NoAccess; break;
                case "E9ED5FC0B7965C7C989476CDE90EFB11AD64EDA2": Result = HistoryAccessType.NoAccess; break;
                case "0334C09575B8364359DAAA51653DB8EE7D5B33DE": Result = HistoryAccessType.NoAccess; break;
                case "9E3AFA2B05E3C6142A19053AABB4B0D9092933B9": Result = HistoryAccessType.NoAccess; break; 
                case "64585907DDB86EB0E03590633041941F9C4FDEC8": Result = HistoryAccessType.NoAccess; break;
                case "F10C9E5E7BF0B0D38D5DE4B961936F6DF97116D4": Result = HistoryAccessType.NoAccess; break;
                case "E15014C56BA495AFF525D0E7DF307CE1CB5C7DF4": Result = HistoryAccessType.NoAccess; break;
                case "ABBD80AECB54EDEE41D59CA8D199976FC8776B05": Result = HistoryAccessType.ExtendedAccess; break; // Operator
                case "83D2F0258836D65D10F9F0E3041A01054DEFA172": Result = HistoryAccessType.NoAccess; break;
                case "F69F4D044B20AB5106DEE32FE7F518A3455A97A3": Result = HistoryAccessType.NoAccess; break;
                case "CFC4DCA14C6BC4D58249D884E1C8B7F13D7539BD": Result = HistoryAccessType.NoAccess; break;
                case "4966B3D71356102AD6E8037F36CBEC9E7FA515E7": Result = HistoryAccessType.NoAccess; break; // BOSS
                case "A1753EAB7D63593E688953089EC76D0B48EB243F": Result = HistoryAccessType.NoAccess; break;
                case "8D5DE4B961936F6DF97116D433D1F45063476969": Result = HistoryAccessType.NoAccess; break;
                default: Result = HistoryAccessType.NoAccess; break;
            }
            return Result;

        }


        public static bool GetRule1()
        {
            String fname = DirectoryConfiguration.CurrentDirectory + "\\Rule1.rxs";
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

        public static bool GetRule2()
        {
            String fname = DirectoryConfiguration.CurrentDirectory + "\\Rule2.rxs";
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

        public static void LicenseAccess()
        {
            #region Access Right
            AccessType f = License.GetRights();
            switch (f)
            {
                case AccessType.NoAccess:
                     V_IsConfidentialDocumentShowInList = false;
                     V_IsConfidentialDocumentIDShowInList = false;
                     V_IsDocumentIDShowInList = false;
                     V_IsEnterInConfidentialDocumentAlowed = false;
                     V_IsDocumentViewRestrictedMode = true;
                     V_IsBossMode = false;
                     V_IsAttachmentShow = false;
                     V_IsConfidentialSaveAllow = false;
                     V_IsDocumentEditAllow = false;
                     V_IsDocumentDeletetAllow = false;
                     V_IsNewDocumentAllow = false;
                     V_IsDeleteAlowed = false;
                     L_DocumentOperation = false;
                    break;

                case AccessType.GuestLicense:
                    V_IsConfidentialDocumentShowInList = false;
                    V_IsConfidentialDocumentIDShowInList = false;
                    V_IsDocumentIDShowInList = false;
                    V_IsEnterInConfidentialDocumentAlowed = false;
                    V_IsDocumentViewRestrictedMode = true;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = false;
                    V_IsConfidentialSaveAllow = false;
                    V_IsDocumentEditAllow = false;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = false;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = false;
                    break;
                case AccessType.UserLicense:
                    V_IsConfidentialDocumentShowInList = false;
                    V_IsConfidentialDocumentIDShowInList = false;
                    V_IsDocumentIDShowInList = false;
                    V_IsEnterInConfidentialDocumentAlowed = false;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = false;
                    V_IsConfidentialSaveAllow = false;
                    V_IsDocumentEditAllow = false;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = false;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = false;
                    break;

                case AccessType.PowertLicense:
                    V_IsConfidentialDocumentShowInList = true;
                    V_IsConfidentialDocumentIDShowInList = false;
                    V_IsDocumentIDShowInList = false;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = true;
                    V_IsConfidentialSaveAllow = false;
                    V_IsDocumentEditAllow = false;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = false;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = false;
                    break;

                case AccessType.ManagerLicense:
                    V_IsConfidentialDocumentShowInList = true;
                    V_IsConfidentialDocumentIDShowInList = false;
                    V_IsDocumentIDShowInList = false;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = true;
                    V_IsConfidentialSaveAllow = false;
                    V_IsDocumentEditAllow = false;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = false;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = false;
                    break;


                case AccessType.OperatorLicense:
                    V_IsConfidentialDocumentShowInList = true;
                    V_IsConfidentialDocumentIDShowInList = false;
                    V_IsDocumentIDShowInList = true;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = false;
                    V_IsAttachmentShow = true;
                    V_IsConfidentialSaveAllow = false;
                    V_IsDocumentEditAllow = true;
                    V_IsDocumentDeletetAllow = false;
                    V_IsNewDocumentAllow = true;
                    V_IsDeleteAlowed = false;
                    L_DocumentOperation = true;
                    break;


                case AccessType.PowerOperatorLicense:
                    V_IsConfidentialDocumentShowInList = true;
                    V_IsConfidentialDocumentIDShowInList = true;
                    V_IsDocumentIDShowInList = true;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = true;
                    V_IsAttachmentShow = true;
                    V_IsConfidentialSaveAllow = true;
                    V_IsDocumentEditAllow = true;
                    V_IsDocumentDeletetAllow = true;
                    V_IsNewDocumentAllow = true;
                    V_IsDeleteAlowed = true;
                    L_DocumentOperation = true;
                    break;

                case AccessType.BossLicense:
                    V_IsConfidentialDocumentShowInList = true;
                    V_IsConfidentialDocumentIDShowInList = true;
                    V_IsDocumentIDShowInList = true;
                    V_IsEnterInConfidentialDocumentAlowed = true;
                    V_IsDocumentViewRestrictedMode = false;
                    V_IsBossMode = true;
                    V_IsAttachmentShow = true;
                    V_IsConfidentialSaveAllow = true;
                    V_IsDocumentEditAllow = true;
                    V_IsDocumentDeletetAllow = true;
                    V_IsNewDocumentAllow = true;
                    V_IsDeleteAlowed = true;
                    L_DocumentOperation = true;
                    break;
            }
            #endregion Access Right

            #region History Access Right
            HistoryAccessType h = License.GetHistoryRights();
            switch (h)
            {
                case HistoryAccessType.NoAccess:
                    V_IsHistoryAccessGranted = false;
                    V_IsHistoryExtendedAccessGranted = false;

                    V_IsModifiedHistoryGranted = false;
                    V_IsDeletedInHistoryGranted = false;

                    V_IsSearchinDeletedDocumentsGranted = false;
                    V_IsRecoverDeletedDocumentsGranted = false;
                    break;

                case HistoryAccessType.PublicAccess:
                    V_IsHistoryAccessGranted = true;
                    V_IsHistoryExtendedAccessGranted = false;

                    V_IsModifiedHistoryGranted = false;
                    V_IsDeletedInHistoryGranted = false;

                    V_IsSearchinDeletedDocumentsGranted = false;
                    V_IsRecoverDeletedDocumentsGranted = false;
                    break;

                case HistoryAccessType.ExtendedAccess:
                    V_IsHistoryAccessGranted = true;
                    V_IsHistoryExtendedAccessGranted = true;

                    V_IsModifiedHistoryGranted = false;
                    V_IsDeletedInHistoryGranted = false;

                    V_IsSearchinDeletedDocumentsGranted = false;
                    V_IsRecoverDeletedDocumentsGranted = false;
                    break;

                case HistoryAccessType.ModificationAccess:
                    V_IsHistoryAccessGranted = true;
                    V_IsHistoryExtendedAccessGranted = true;

                    V_IsModifiedHistoryGranted = true;
                    V_IsDeletedInHistoryGranted = true; // ეს რეალურად არ შლის დოკუმენტს. მხილოდ მალავს წაშლილის სტატუსით

                    V_IsSearchinDeletedDocumentsGranted = false;
                    V_IsRecoverDeletedDocumentsGranted = false;
                    break;

                case HistoryAccessType.AdminAccess:
                    V_IsHistoryAccessGranted = true;
                    V_IsHistoryExtendedAccessGranted = true;

                    V_IsModifiedHistoryGranted = true;
                    V_IsDeletedInHistoryGranted = true;

                    V_IsSearchinDeletedDocumentsGranted = true;
                    V_IsRecoverDeletedDocumentsGranted = true;  // რეალურად ამით მოწმდეგა ადმინისტრტორსი დაშვება
                    break;


            }
            #endregion History Access Right


            bool rule1 = License.GetRule1();

            if (rule1 == true) V_IsConfidentialDocumentShowInList = true;
            else V_IsConfidentialDocumentShowInList = false;
            
            bool rule2 = License.GetRule2();
            if (rule2 == true) V_IsAttachmentShow = true;
            else V_IsAttachmentShow = false;
 
        }

    }
}
