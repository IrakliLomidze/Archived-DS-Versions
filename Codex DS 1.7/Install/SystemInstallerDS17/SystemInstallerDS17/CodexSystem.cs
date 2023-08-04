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
      //  <RegistryValue Id = "Registry2" Root="HKLM" Key="SOFTWARE\Georgian Microsystems\Codex DS\Client17" Name="VersionMajor" Value="7" Type="integer" />
      //<RegistryValue Id = "Registry3" Root="HKLM" Key="SOFTWARE\Georgian Microsystems\Codex DS\Client17" Name="VersionMinor" Value="2021" Type="integer" />
      //<RegistryValue Id = "Registry4" Root="HKLM" Key="SOFTWARE\Georgian Microsystems\Codex DS\Client17" Name="Version" Value="7.2021.2019.2000" Type="string" />

                                                                                                               
        static public  String CodexDSClientKey32 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Georgian Microsystmes\CodexDS17\Client";
        static public String CodexDSClientKey64 = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Georgian Microsystmes\CodexDS17\Client";
        static public  String CodexDSToolsKey32 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Georgian Microsystmes\CodexDS17\Tools";
        static public String CodexDSToolsKey64 = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Georgian Microsystmes\CodexDS17\Tools";

        //public enum CodexRegKey (CodexWorskation, CodexClient, CodexServer, CodexInternal);

        public bool isCodexNeedToBeInstalled(String Key32, String Key64)
        {


            bool result1 = false;
        
            

            Version Codex_Installed_Version = new Version("1.0.1.0");

            Version Codex_Installing_Version = new Version("7.2021.2019.2001");

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
