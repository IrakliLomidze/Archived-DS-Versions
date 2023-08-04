using ILG.Codex.CodexR4.GMLiceseManger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLicenseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("DS License Creator");
                Console.WriteLine("Version 1.1");
                Console.WriteLine("DSLicenseGenerator.exe params");
                Console.WriteLine();
                Console.WriteLine("Verify License");
                Console.WriteLine("DSLicenseGenerator.exe --CHECK");
                Console.WriteLine();
                Console.WriteLine("TRIAL License");
                Console.WriteLine("DSLicenseGenerator.exe --TRIAL YYYY DD MM");
                Console.WriteLine("e.g. DSLicenseGenerator.exe TRIAL 2019 01 02");
                Console.WriteLine();
                Console.WriteLine("Will Generate Trial License");
                Console.WriteLine("DSLicenseGenerator.exe --COMM [OrganizationName] [Department]");
                Console.WriteLine("e.g. DSLicenseGenerator.exe --COMM \"Microsoft\" \"HR Division\" ");
                return;
            }

            if (args[0].Trim().ToUpper() == "--TRIAL")
            {
                if (args.Length != 4)
                {
                    Console.WriteLine("TRIAL License");
                    Console.WriteLine("DSLicenseGenerator.exe --TRIAL YYYY DD MM");
                    Console.WriteLine("e.g. DSLicenseGenerator.exe TRIAL 2019 01 02");
                    return;
                }
                DSLicenseManager.Instance.Initialize();
                int YYYY = int.Parse(args[1]);
                int MM = int.Parse(args[2]);
                int DD = int.Parse(args[3]);
                DSLicenseManager.Instance.CreateTrialLicense(new DateTime(YYYY, MM, DD));
                Console.WriteLine("Done");
                Console.WriteLine("Press Any Key to Exit");
                Console.ReadKey();
                return;
            }

            if (args[0].Trim().ToUpper() == "--COMM")
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("Will Generate Trial License");
                    Console.WriteLine("DSLicenseGenerator.exe --COMM [OrganizationName] [Department]");
                    Console.WriteLine("e.g. DSLicenseGenerator.exe --COMM \"Microsoft\" \"HR Division\" ");
                    return;
                }
                DSLicenseManager.Instance.Initialize();
                string Organization = args[1];
                string Department = args[2];

                DSLicenseManager.Instance.CreateRetailLicense(Organization, Department);
                Console.WriteLine("Done");
                Console.WriteLine("Press Any Key to Exit");
                Console.ReadKey();
                return;
            }

            if (args[0].Trim().ToUpper() == "--CHECK")
            {
                DSLicenseManager.Instance.Initialize();
                bool VerificationStatus = DSLicenseManager.Instance.VerifyLicense();

                Console.WriteLine($"Verifing : {VerificationStatus}");
                
                Console.WriteLine("Done");
                Console.WriteLine("Press Any Key to Exit");
                Console.ReadKey();
                return;
            }
        }
    }
}
