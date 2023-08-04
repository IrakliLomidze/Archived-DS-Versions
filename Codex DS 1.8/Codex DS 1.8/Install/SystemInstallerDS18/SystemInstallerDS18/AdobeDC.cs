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
                //RegistryKey localKey;

                //if (Environment.Is64BitOperatingSystem)
                //    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                //else
                //    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);

                string releaseKey = Registry.GetValue(regsubkey, "ENU_GUID", null).ToString();
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
                regkey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Adobe\\" + productName + "\\" + productVersion + "\\Installer";
                result = GetValueFromReg(regkey);
            }
            return result;
        }


    }
}
