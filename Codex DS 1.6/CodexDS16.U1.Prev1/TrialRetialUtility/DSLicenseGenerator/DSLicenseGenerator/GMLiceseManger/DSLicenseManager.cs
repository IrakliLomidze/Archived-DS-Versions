using System;
using System.Collections.Generic;
using System.Linq;
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

        private DSLicenseJsonFile _codexdsLicenseConfiguration;

        private string _stringTrialStatus;
        private DateTime _expirationDate;
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

        public DateTime ExpirationDate
        {
            get
            {
                return _expirationDate;
            }
            set {
                _expirationDate = value;
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

        public void Read()
        {
            _codexdsLicenseConfiguration.ReadInfo();

            _stringOrganization = _codexdsLicenseConfiguration._codexlicensefile.Content.Organization;
            _stringDepartment = _codexdsLicenseConfiguration._codexlicensefile.Content.Department;

            _expirationDate = _codexdsLicenseConfiguration._codexlicensefile.Content.ExpirationDate;
            _stringTrialStatus = _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType;

        }

        public void Write()
        {
            _codexdsLicenseConfiguration._codexlicensefile.Content.LicId = Guid.NewGuid().ToString();
            _codexdsLicenseConfiguration._codexlicensefile.Content.Organization = _stringOrganization;
            _codexdsLicenseConfiguration._codexlicensefile.Content.Department = _stringDepartment;
            _codexdsLicenseConfiguration._codexlicensefile.Content.LicenseType = _stringTrialStatus;
            _codexdsLicenseConfiguration._codexlicensefile.Content.ExpirationDate = _expirationDate;

            _codexdsLicenseConfiguration.SaveInfo();
        }

        public bool CreateIfNotExists()
        {
            if (_codexdsLicenseConfiguration.CreateIfNotExists() == true)
            {

                TrialStatus = "TRIAL";
                ExpirationDate = new DateTime(2019, 2, 1);
                Organizaiton = "";
                Department = "";
                Write();
                return true;
            }
            else return false;
        }
    }

}
