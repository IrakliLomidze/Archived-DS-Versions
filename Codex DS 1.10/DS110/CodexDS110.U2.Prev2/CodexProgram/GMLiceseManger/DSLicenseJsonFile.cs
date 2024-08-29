using System;
using System.IO;
using System.Reflection;

namespace ILG.Codex.CodexR4.GMLiceseManger
{
    class DSLicenseJsonFile
    {
        private string _licenseDirectory;
        private string _licenseFullFilename;
        private readonly string configFilename = "CodexDSProduction.json";

        public DSCodexLicenseFileBase _codexlicensefile;

        private string GetDSLicDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public DSLicenseJsonFile()
        {
            _licenseDirectory = GetDSLicDirectory();
            _licenseFullFilename = Path.Combine(_licenseDirectory, configFilename);
            _codexlicensefile = new DSCodexLicenseFileBase(_licenseFullFilename);

        }

        public DSLicenseJsonFile(String fileName)
        {
            configFilename = fileName;
            _licenseDirectory = GetDSLicDirectory();
            _licenseFullFilename = Path.Combine(_licenseDirectory, configFilename);
            _codexlicensefile = new DSCodexLicenseFileBase(_licenseFullFilename);

        }

        public bool CreateIfNotExists()
        {
            if (File.Exists(_licenseFullFilename) == false)
            {
                var codexlicensefile = new DSCodexLicenseFileBase(_licenseFullFilename);
                codexlicensefile.WritetoFile();
                return true;
            }
            else return false;
        }

        public bool CheckIfExits()
        {
            if (File.Exists(_licenseFullFilename) == false)
            {
                return true;
            }
            else return false;
        }
        public void ReadInfo()
        {
            _codexlicensefile.ReadFromFile(_licenseFullFilename);
        }

        public void SaveInfo()
        {
            _codexlicensefile.WritetoFile();
        }


    }
}
