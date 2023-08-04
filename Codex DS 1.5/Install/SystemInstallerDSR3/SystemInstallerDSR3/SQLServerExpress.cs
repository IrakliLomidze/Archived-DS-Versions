using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4
{
    class SQLServerExpress
    {

        // /QS /ACTION=Install /Hideconsole=TRUE /FEATURES=SQL,Tools /IACCEPTSQLSERVERLICENSETERMS=TRUE  /INSTANCENAME=CodexR4 /SECURITYMODE=SQL /SAPWD="Codex$12345678" /SQLCOLLATION="SQL_Latin1_General_CP1_CI_AS" /SQLSYSADMINACCOUNTS="BUILTIN\ADMINISTRATORS" /SQLSVCACCOUNT="NT AUTHORITY\SYSTEM" /AGTSVCACCOUNT="NT AUTHORITY\Network Service" /UPDATEENABLED=FALSE

        public int IsInstanceX64()
        {
            if (Environment.Is64BitOperatingSystem == false) return 0;

            String Reg1 = "Software\\Wow6432Node\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL";
            
            int result = 0;
            try
            { 
              string regval = Microsoft.Win32.Registry.GetValue(Reg1, "CODEXR4", null).ToString();
              result = 86;
            }
            catch
            {
                result = 0;
            }

            Reg1 = "Software\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL";
            
            try
            { 
              string regval = Microsoft.Win32.Registry.GetValue(Reg1, "CODEXR4", null).ToString();
              result = 64;
            }
            catch
            {
                result = 0;
            }
      

            return 0;
        }

        public int GetSQLVersion()
        {

    //        int result = 0;
            string regval = "";
            try
            {
                regval = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Microsoft SQL Server\\CODEXR4\\MSSQLServer\\CurrentVersion", "CurrentVersion", null ).ToString();
            }
            catch
            {
                return 1000;
            }

            try
            {
                var Ver = Version.Parse(regval);
                if ((Ver.Major == 9) &&  (Ver.Minor == 0)) return 2005; // SQL 2005
                if ((Ver.Major == 10) && (Ver.Minor == 0)) return 2008; // SQL 2008
                if ((Ver.Major == 10) && (Ver.Minor == 5)) return 2010; // SQL 2008R2
                if ((Ver.Major == 10) && (Ver.Minor == 50)) return 2010; // SQL 2008R2
                if ((Ver.Major == 11) && (Ver.Minor == 0))  return 2012; // SQL 2012
                if ((Ver.Major == 12) && (Ver.Minor == 0)) return 2014;  // SQL 2014

            }
            catch
            {
                return 3000;
            }



            return 3000;
        }


        public int IsLocalDB2014Installed()
        {

            string regval = "";
            try
            {
                regval = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Microsoft SQL Server Local DB\\Installed Versions\\12.0", "ParentInstance", null).ToString();
            }
            catch
            {
                return 1000;
            }


            return 2014;
        }
    }
}
