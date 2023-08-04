using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ILG.Codex.CodexR4
{
    public class AcrobatVersion
    {
        public string Description { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }

        public bool RequredUpdate { get; set; }
        public bool RecomendedUpdate { get; set; }
        public bool Warn { get; set; }

    }
    public enum AcrobatType { notinstalled, acrobat, reader};
    class AdobeDC
    {

        #region Comments
        //http://www.adobe.com/devnet-docs/acrobatetk/tools/AdminGuide/identify.html#dc-products

        //

        //        GUID registry location

        //The GUID is written to a variety of locations.However, Adobe recommends you use the following:

        //32 bit Windows: HKEY_LOCAL_MACHINE\SOFTWARE\Adobe\{ application}\{version
        //    }\Installer\
        //64 bit Windows: HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Adobe\{application
        //}\{version}\Installer\
        //GUID installer package location

        //Administrators interested in dissecting installer packages prior to deployment can find the GUID in the installer msi package.To find the GUID in an installer, go to Property > ProductCode, and look in the Value column.

        #endregion Comments
 //       private Dictionary<string, AcrobatVersion> _Acrobats;
 //       private List<string> ProductNames  = new List<string>(){ "Adobe Acrobat",  "Acrobat Reader" };

        private string ENU_GUID = string.Empty;
        public string ProductDescription { get; set; }
        public AcrobatType ProductType { get; set; }
        public AdobeDC()
        {
            ProductType = AcrobatType.notinstalled;
            #region Legacy
            //_Acrobats = new Dictionary<string, AcrobatVersion>();
            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-A80C00000100}", new AcrobatVersion { Description = "Reader DC Trunk", MajorVersion = 12, MinorVersion = 0, RecomendedUpdate = false, RequredUpdate = false, Warn = false });
            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-AB0C01000100}", new AcrobatVersion { Description = "Reader DC Beta", MajorVersion = 12, MinorVersion = -1, RecomendedUpdate = true, RequredUpdate = true, Warn = false });
            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-AC0C02000100}", new AcrobatVersion { Description = "Reader DC Consumer", MajorVersion = 12, MinorVersion = -1, RecomendedUpdate = false, RequredUpdate = false, Warn = false });
            //_Acrobats.Add("{AC76BA86-1033-FFFF-7760-080C00000100}", new AcrobatVersion { Description = "Acrobat Pro DC MUL Trunk", MajorVersion = 12, MinorVersion = 0, RecomendedUpdate = false, RequredUpdate = false, Warn = false });
            //_Acrobats.Add("{AC76BA86-1033 FFFF-7760-0B0C01000100}", new AcrobatVersion { Description = "Acrobat Pro DC MUL Beta", MajorVersion = 12, MinorVersion = -1, RecomendedUpdate = true, RequredUpdate = true, Warn = false });
            //_Acrobats.Add("{AC76BA86-1033-FFFF-7760-0C0C02000100}", new AcrobatVersion { Description = "Acrobat Pro DC MUL Consumer", MajorVersion = 12, MinorVersion = 0, RecomendedUpdate = false, RequredUpdate = false, Warn = false });
            //_Acrobats.Add("{AC76BA86-1033-FFFF-7760-000000000006}", new AcrobatVersion { Description = "Acrobat 11.0 (each installer supports all languages)", MajorVersion = 11, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = false, Warn = true });

            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-AA0000000001}", new AcrobatVersion { Description = "Reader 10.0.0", MajorVersion = 10, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = false, Warn = false });
            //_Acrobats.Add("{AC76BA86-7AD7-FFFF-7B44-AA0000000001}", new AcrobatVersion { Description = "Reader 10.0.0 MUI", MajorVersion = 10, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = false, Warn = false });
            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-AA1000000001}", new AcrobatVersion { Description = "Reader 10.1.0 en_US", MajorVersion = 10, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = false, Warn = false });

            //_Acrobats.Add("{AC76BA86-1033-F400-7760-000000000005}", new AcrobatVersion { Description = "Acrobat 10.1", MajorVersion = 10, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = false, Warn = true });
            //_Acrobats.Add("{AC76BA86-1033-0000-BA7E-000000000005}", new AcrobatVersion { Description = "Acrobat Std 10.0.0 en_US", MajorVersion = 10, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = false, Warn = true });
            //_Acrobats.Add("{AC76BA86-1033-0000-7760-000000000005}", new AcrobatVersion { Description = "Acrobat Pro 10.0.0 en_US", MajorVersion = 10, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = false, Warn = true });

            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-A70500000002}", new AcrobatVersion { Description = "Adobe Reader 9.2", MajorVersion = 9, MinorVersion = 2, RecomendedUpdate = true, RequredUpdate = true, Warn = false });

            //_Acrobats.Add("{AC76BA86-1033-0000-7760-000000000003}", new AcrobatVersion { Description = "Acrobat Professional 8.0", MajorVersion = 8, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = true });
            //_Acrobats.Add("{AC76BA86-1033-0000-BA7E-000000000003}", new AcrobatVersion { Description = "Acrobat Standard 8.0", MajorVersion = 8, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = true });

            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-A80000000002}", new AcrobatVersion { Description = "Reader 8.0", MajorVersion = 8, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = false });

            //_Acrobats.Add("{AC76BA86-1033-0000-7760-000000000002}", new AcrobatVersion { Description = "Acrobat Professional 7.0 retail edition", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = true });
            //_Acrobats.Add("{AC76BA86-1033-0000-7760-100000000002}", new AcrobatVersion { Description = "Acrobat Standard 7.0 volume license edition", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = true });
            //_Acrobats.Add("{AC76BA86-1033-0000-BA7E-000000000002}", new AcrobatVersion { Description = "Acrobat Standard 7.0 retail edition", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = true });
            //_Acrobats.Add("{AC76BA86-1033-0000-BA7E-100000000002}", new AcrobatVersion { Description = "Acrobat Standard 7.0 volume license edition", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = true });
            //_Acrobats.Add("{AC76BA86-1033-F400-7760–0000003D0002}", new AcrobatVersion { Description = "Acrobat 3D retail", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = true });
            //_Acrobats.Add("{AC76BA86-1033-F400-7760-1000003D0002}", new AcrobatVersion { Description = "Acrobat 3D volume license edition", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = true });

            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-A70000000000}", new AcrobatVersion { Description = "Reader 7.0", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = false });
            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-A70500000002}", new AcrobatVersion { Description = "Reader 7.0.5", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = false });
            //_Acrobats.Add("{AC76BA86-0000-7EC8-7489-000000000702}", new AcrobatVersion { Description = "Acrobat 7.0.1 and Reader 7.0.1 Update", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = false });
            //_Acrobats.Add("{AC76BA86-0000-7EC8-7489-000000000703}", new AcrobatVersion { Description = "Acrobat 7.0.2 and Reader 7.0.2 Update", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = false });
            //_Acrobats.Add("{AC76BA86-0000-7EC8-7489-000000000704}", new AcrobatVersion { Description = "Acrobat 7.0.3 and Reader 7.0.3 Update", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = false });
            //_Acrobats.Add("{AC76BA86-7AD7-1033-7B44-A70500000002}", new AcrobatVersion { Description = "Reader 7.0.5", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = false });
            //_Acrobats.Add("{AC76BA86-1033-F400-7760-100000000002}", new AcrobatVersion { Description = "Adobe Acrobat 7.0.7 and Reader 7.0.7 update", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = false });
            //_Acrobats.Add("{AC76BA86-1033-0000-7760-100000000002}", new AcrobatVersion { Description = "Adobe Acrobat 7.0.8 and Reader 7.0.8 update", MajorVersion = 7, MinorVersion = 0, RecomendedUpdate = true, RequredUpdate = true, Warn = false });

            #endregion Legacy

        }

        public void Analize()
        {
            ProductDescription = "";
            // Analizing for Adobr Acrobat
            ENU_GUID = GetAcrobatFromRegistry(productName: "Adobe Acrobat", productVersion: "DC");
            if (ENU_GUID != String.Empty)
            {
                // Verifing GUID
                String Sub1 = ENU_GUID.Substring(0, 3).ToUpper();
                if (Sub1 == "{AC")
                {
                    if (ENU_GUID.Contains("-7760-") == true) ProductDescription = "Acrobat Pro";
                    if (ENU_GUID.Contains("-BA7E-") == true) ProductDescription = "Acrobat Standard";
                    if (ENU_GUID.Contains("-7B44-") == true) ProductDescription = "ReaderBig";
                    if (ENU_GUID.Contains("-7761-") == true) ProductDescription = "3D";
                    ProductType = AcrobatType.acrobat;

                }
                return;
            }

            ENU_GUID = GetAcrobatFromRegistry(productName: "Acrobat Reader", productVersion: "DC");
            if (ENU_GUID != String.Empty)
            {
                String Sub1 = ENU_GUID.Substring(0, 3).ToUpper();
                if (Sub1 == "{AC")
                {
                    if (ENU_GUID.Contains("-7760-") == true) ProductDescription = "Acrobat Pro";
                    if (ENU_GUID.Contains("-BA7E-") == true) ProductDescription = "Acrobat Standard";
                    if (ENU_GUID.Contains("-7B44-") == true) ProductDescription = "ReaderBig";
                    if (ENU_GUID.Contains("-7761-") == true) ProductDescription = "3D";
                    ProductType = AcrobatType.reader;
                }
                return;
            }

      
        }

        private string GetValueFromReg(String regsubkey)
        {
            try
            {
                string releaseKey = Microsoft.Win32.Registry.GetValue(regsubkey, "ENU_GUID", null).ToString();
                return releaseKey;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        private string GetAcrobatFromRegistry(String productName, String productVersion)
        {
            string regkey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Adobe\\" + productName + "\\" + productVersion + "\\Installer\\";
            string result = GetValueFromReg(regkey);
            if (result == string.Empty)
            {
                regkey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Adobe\\" + productName + "\\" + productVersion + "\\Installer\\";
                result = GetValueFromReg(regkey);
            }
            return result;
        }


    }
}
