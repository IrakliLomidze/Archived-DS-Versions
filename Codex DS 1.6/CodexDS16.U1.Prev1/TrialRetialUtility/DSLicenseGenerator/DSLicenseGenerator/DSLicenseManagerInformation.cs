using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4.GMLiceseManger
{
    public sealed class DSLicenseManager
    {
        private static volatile DSLicenseManager instance;
        private static object syncRoot = new Object();
        private DSLicenseManager() { }
        public static DSLicenseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DSLicenseManager();
                    }
                }

                return instance;
            }
        }

        #region CryptoGraphy
        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString.ToUpper();
        }

        public static string getHashSha1(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA1Managed hashstring = new SHA1Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString.ToUpper();
        }

        public static string getHashSha384(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA384Managed hashstring = new SHA384Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString.ToUpper();
        }

        public static string getHashSha512(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA512Managed hashstring = new SHA512Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString.ToUpper();
        }


        #endregion CryptoGraphy

        private DSLicenseJsonFile _codexdsLicenseConfiguration;

        private string _stringTrialStatus;
        private ExpirationDate _expirationDate;
        private string _stringOrganization;
        private string _stringDepartment;

        public string TrialStatus
        {
            get
            {
                return _stringTrialStatus;
            }
            set
            {
                _stringTrialStatus = value;
            }
        }

        public DateTime Expiration
        {
            get
            {
                return new DateTime(_expirationDate.Year, _expirationDate.Month, _expirationDate.Day);
            }
        }
        public string Organizaiton
        {
            get
            {
                return _stringOrganization;
            }
            set { _stringOrganization = value; }
        }

        public string Department
        {
            get
            {
                return _stringDepartment;
            }
            set { _stringDepartment = value; }
        }



        public void Initialize(bool readInfo = false)
        {
            _codexdsLicenseConfiguration = new DSLicenseJsonFile();
           

            if (readInfo == true)
            {
                CreateIfNotExists();
                Read();
            }
        }

        public void Initialize(string Filename, bool readInfo = false)
        {
            _codexdsLicenseConfiguration = new DSLicenseJsonFile(Filename);


            if (readInfo == true)
            {
                CreateIfNotExists();
                Read();
            }
        }


        public void Read()
        {
            _codexdsLicenseConfiguration.ReadInfo();

            _stringOrganization = _codexdsLicenseConfiguration._codexlicensefile.Content.Organization;
            _stringDepartment = _codexdsLicenseConfiguration._codexlicensefile.Content.Department;

            _expirationDate = new ExpirationDate()
            {
                Year = _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Year,
                Month = _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Month,
                Day = _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Day
            };
            _stringTrialStatus = _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType;

        }

        public void Write()
        {
            CreateIfNotExists();
            _codexdsLicenseConfiguration._codexlicensefile.Content.LicId = Guid.NewGuid().ToString();
            _codexdsLicenseConfiguration._codexlicensefile.Content.Organization = _stringOrganization;
            _codexdsLicenseConfiguration._codexlicensefile.Content.Department = _stringDepartment;
            _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType = _stringTrialStatus;

         //   _codexdsLicenseConfiguration._codexlicensefile.Content.ExpirationDate = _expirationDate;

            _codexdsLicenseConfiguration.SaveInfo();
        }

        public bool CreateIfNotExists()
        {
            if (_codexdsLicenseConfiguration.CreateIfNotExists() == true)
            {

                TrialStatus = "None";
                //ExpirationDate = new DateTime(2019, 2, 1);
                Organizaiton = "";
                Department = "";
                Write();
                return true;
            }
            else return false;
        }



        public void CreateTrialLicense(DateTime pExpirationDate)
        {
            _codexdsLicenseConfiguration._codexlicensefile.Content.LicId = Guid.NewGuid().ToString();
            _codexdsLicenseConfiguration._codexlicensefile.Content.DefId = Guid.NewGuid().ToString();
            _codexdsLicenseConfiguration._codexlicensefile.Content.Organization = "For trial, non commercial use";
            _codexdsLicenseConfiguration._codexlicensefile.Content.Version = "1.1";
            _codexdsLicenseConfiguration._codexlicensefile.Content.Department = "Trial";
            _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType = "TRIAL";
            _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration = new ExpirationDate()
            {
                Year = pExpirationDate.Year,
                Month = pExpirationDate.Month,
                Day = pExpirationDate.Day
            };
              
            
            DSLicneseInformaton sd = new DSLicneseInformaton();


            String s = _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType +
                       sd.Masters[14] +
                        _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Year.ToString() +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Month.ToString() +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Day.ToString() +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Department +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.LicId +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Organization +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Version +
                       sd.Masters[17] +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Day.ToString() +
                       sd.Masters[3] +
                       sd.Masters[13];


            String H1 = getHashSha512(getHashSha512(s));
            String H2 = getHashSha512(s+ getHashSha256(H1))+ getHashSha384(s)+ getHashSha512(s); ;
            String H3 = getHashSha512(getHashSha512(H2)+H1);


            _codexdsLicenseConfiguration._codexlicensefile.Content.License = H3+H2;

            String H4 = getHashSha512(H3 + getHashSha256(H2)) + getHashSha384(H1);
            String H5 = getHashSha512(getHashSha256(_codexdsLicenseConfiguration._codexlicensefile.Content.DefId + H4));

            _codexdsLicenseConfiguration._codexlicensefile.Content.DefCode = H5 + H1;

            _codexdsLicenseConfiguration.SaveInfo();

        }

        public void CreateRetailLicense(string OrganizationName, string Department)
        {
            _codexdsLicenseConfiguration._codexlicensefile.Content.LicId = Guid.NewGuid().ToString();
            _codexdsLicenseConfiguration._codexlicensefile.Content.DefId = Guid.NewGuid().ToString();
            _codexdsLicenseConfiguration._codexlicensefile.Content.Organization = OrganizationName;
            _codexdsLicenseConfiguration._codexlicensefile.Content.Version = "1.1";
            _codexdsLicenseConfiguration._codexlicensefile.Content.Department = Department;
            _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType = "ENTERPRISE";
            _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration = new ExpirationDate()
            {
                Year = 0,
                Month = 0,
                Day = 0
            };


            DSLicneseInformaton sd = new DSLicneseInformaton();


            String s = _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType +
                       sd.Masters[14] +
                        _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Year.ToString() +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Month.ToString() +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Day.ToString() +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Department +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.LicId +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Organization +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Version +
                       sd.Masters[17] +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Day.ToString() +
                       sd.Masters[3] +
                       sd.Masters[13];


            String H1 = getHashSha512(getHashSha512(s));
            String H2 = getHashSha512(s + getHashSha256(H1)) + getHashSha384(s) + getHashSha512(s); ;
            String H3 = getHashSha512(getHashSha512(H2) + H1);


            _codexdsLicenseConfiguration._codexlicensefile.Content.License = H3 + H2;

            String H4 = getHashSha512(H3 + getHashSha256(H2)) + getHashSha384(H1);
            String H5 = getHashSha512(getHashSha256(_codexdsLicenseConfiguration._codexlicensefile.Content.DefId + H4));

            _codexdsLicenseConfiguration._codexlicensefile.Content.DefCode = H5 + H1;

            _codexdsLicenseConfiguration.SaveInfo();

        }

        public bool VerifyLicense()
        {
            _codexdsLicenseConfiguration.ReadInfo();
            

            DSLicneseInformaton sd = new DSLicneseInformaton();

            String s = _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType +
                        sd.Masters[14] +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Year.ToString() +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Month.ToString() +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Day.ToString() +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Department +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.LicId +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Organization +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Version +
                       sd.Masters[17] +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType +
                       _codexdsLicenseConfiguration._codexlicensefile.Content.Expiration.Day.ToString() +
                       sd.Masters[3] +
                       sd.Masters[13];


            String H1 = getHashSha512(getHashSha512(s));
            String H2 = getHashSha512(s + getHashSha256(H1)) + getHashSha384(s) + getHashSha512(s); ;
            String H3 = getHashSha512(getHashSha512(H2) + H1);

            
            _codexdsLicenseConfiguration._codexlicensefile.Content.License = H3 + H2;

            String H4 = getHashSha512(H3 + getHashSha256(H2)) + getHashSha384(H1);
            String H5 = getHashSha512(getHashSha256(_codexdsLicenseConfiguration._codexlicensefile.Content.DefId + H4));
                        
            
            bool Condition1 = (_codexdsLicenseConfiguration._codexlicensefile.Content.License == (H3 + H2));
            bool Condition2 = (_codexdsLicenseConfiguration._codexlicensefile.Content.DefCode == (H5 + H1));

            return Condition1 && Condition2;
        }
    }

}
