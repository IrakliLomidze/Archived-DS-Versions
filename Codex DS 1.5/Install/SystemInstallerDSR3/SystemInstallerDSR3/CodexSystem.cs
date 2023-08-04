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
                                                                                                               
        static public  String CodexDSToolsKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Georgian Microsystmes\CodexDSR3\Tools";
        static public  String CodexDSClientKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Georgian Microsystmes\CodexDSR3\Client";
       
        //public enum CodexRegKey (CodexWorskation, CodexClient, CodexServer, CodexInternal);
        
        public bool isCodexNeedToBeInstalled(String Key)
        {


            bool result1 = false;
        
            String _Key1 = Key;

            Version Codex_Installed_Version = new Version("1.0.1.0");

            Version Codex_Installing_Version = new Version("7.2017.2017.8500");

            try
            {
                string regval = Microsoft.Win32.Registry.GetValue(_Key1, "Version", null).ToString();
                Codex_Installed_Version = new Version(regval.ToString());
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
