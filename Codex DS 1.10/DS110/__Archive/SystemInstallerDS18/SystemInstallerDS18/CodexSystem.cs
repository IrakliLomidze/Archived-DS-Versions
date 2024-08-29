using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4
{
    class CodexDSSystem
    {
        //      <RegistryValue Id = "Registry2" Root="HKLM" Key="SOFTWARE\Georgian Microsystems\Codex DS\Client18" Name="VersionMajor" Value="8" Type="integer" />
        //<RegistryValue Id = "Registry3" Root="HKLM" Key="SOFTWARE\Georgian Microsystems\Codex DS\Client18" Name="VersionMinor" Value="2022" Type="integer" />
        //<RegistryValue Id = "Registry4" Root="HKLM" Key="SOFTWARE\Georgian Microsystems\Codex DS\Client18" Name="Version" Value="8.2022.2022.4001" Type="string" />

                                                                                                               
        static public  String CodexDSClientKey32 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Georgian Microsystems\Codex DS\Client18";
        static public String CodexDSClientKey64 = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Georgian Microsystems\Codex DS\Client18";
        
        //public enum CodexRegKey (CodexWorskation, CodexClient, CodexServer, CodexInternal);

        public bool isCodexNeedToBeInstalled(String Key32, String Key64)
        {


            bool result1 = false;
        
            

            Version Codex_Installed_Version = new Version("1.0.1.0");

            Version Codex_Installing_Version = new Version("8.2022.2022.4001");

            try
            {
                Codex_Installed_Version = new Version("1.0.1.0");
                var regval = Microsoft.Win32.Registry.GetValue(Key32, "Version", null);
                if (regval == null)
                {
                    regval = Microsoft.Win32.Registry.GetValue(Key64, "Version", null);
                    if (regval != null)
                        Codex_Installed_Version = new Version(regval.ToString());
                }
                else
                {
                    Codex_Installed_Version = new Version(regval.ToString());
                }

                
            }
            catch
            {
                Codex_Installed_Version = new Version("1.0.1.0");
            }
            
            if (Codex_Installing_Version > Codex_Installed_Version )
                result1 = true;
            else
                result1 = false;

            return result1 ;
            
        }



    }
}
