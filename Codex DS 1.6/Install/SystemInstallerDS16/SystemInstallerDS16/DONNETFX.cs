using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Win32;namespace CodexInstaller
{
    class DONNETFX
    {


       public static bool IsNETFX35()
        {
            return false;
        }


        private static void GetVersionFromRegistry2()
        {
            // Opens the registry key for the .NET Framework entry. 
            using (RegistryKey ndpKey =
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
                OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {

                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();
                        string install = versionKey.GetValue("Install", "").ToString();
                        
                        if (install == "") //no install info, must be later.
                           Console.WriteLine(versionKeyName + "  " + name);
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                Console.WriteLine(versionKeyName + "  " + name + "  SP" + sp);
                            }

                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (name != "")
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "") //no install info, must be later.
                                Console.WriteLine(versionKeyName + "  " + name);
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    Console.WriteLine("  " + subKeyName + "  " + name + "  SP" + sp);
                                }
                                else if (install == "1")
                                {
                                    Console.WriteLine("  " + subKeyName + "  " + name);
                                }

                            }

                        }

                    }
                }
            }

        }


        private static void GetVersionFromRegistry()
        {
            // Opens the registry key for the .NET Framework entry. 
            using (RegistryKey ndpKey =
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
                OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                // As an alternative, if you know the computers you will query are running .NET Framework 4.5  
                // or later, you can use: 
                // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,  
                // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {

                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();
                        string install = versionKey.GetValue("Install", "").ToString();
                        
                        if (install == "") //no install info, must be later.
                            Console.WriteLine(versionKeyName + "  " + name);
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                Console.WriteLine(versionKeyName + "  " + name + "  SP" + sp);
                            }

                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (name != "")
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "") //no install info, must be later.
                                Console.WriteLine(versionKeyName + "  " + name);
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    Console.WriteLine("  " + subKeyName + "  " + name + "  SP" + sp);
                                }
                                else if (install == "1")
                                {
                                    Console.WriteLine("  " + subKeyName + "  " + name);
                                }

                            }

                        }

                    }
                }
            }

        }

//        v2.0.50727  2.0.50727.4016  SP2
//v3.0  3.0.30729.4037  SP2
//v3.5  3.5.30729.01  SP1
//v4
//  Client  4.0.30319
//  Full  4.0.30319


        // .NET Framework 4.5 +
        private static int Get45or451FromRegistry()
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));

                return releaseKey;
            //    if (true)
            //    {
            //        Console.WriteLine("Version: " + CheckFor45DotVersion(releaseKey));
            //    }
            //
            }
        }

        // Checking the version using >= will enable forward compatibility,  
        // however you should always compile your code on newer versions of 
        // the framework to ensure your app works the same. 
   //     public static string CheckFor45DotVersion(int releaseKey)
        public static string CheckFor45DotVersion()
   
        {
            int releaseKey = Get45or451FromRegistry();

            if ((releaseKey >= 379893))
            {
                return "OK: .NET Framework 4.5.2";
            }
            if ((releaseKey >= 378675))
            {
                return "OK: .NET Framework 4.5.1";
            }
            if ((releaseKey >= 378389))
            {
                return "OK: .NET Framework 4.5";
            }
            // This line should never execute. A non-null release key should mean 
            // that 4.5 or later is installed. 
            return "WARRNING: No .NET Framework 4.5 or later version detected";
        }

        public static string CheckFor46_47DotVersion()
        {
            int releaseKey = Get45or451FromRegistry();

            if ((releaseKey == 393295) || (releaseKey == 393297))
            {
                return "OK: .NET Framework 4.6";
            }

            if ((releaseKey == 394254) || (releaseKey == 394271))
            {
                return "OK: .NET Framework 4.61";
            }

            if ((releaseKey == 394802) || (releaseKey == 394806))
            {
                return "OK: .NET Framework 4.62";
            }

            if ((releaseKey == 460798) || (releaseKey == 460798))
            {
                return "OK: .NET Framework 4.7";
            }


            if ((releaseKey == 461308) || (releaseKey == 461310))
            {
                return "OK: .NET Framework 4.71";
            }

            if (releaseKey > 460798) return "OK: .NET Framework 4.7 or above";


            // This line should never execute. A non-null release key should mean 
            // that 4.6 or later is installed. 
            return "WARRNING: No .NET Framework 4.61 or later version detected";

        }
        public static int CheckFor45DotVersion_i()
        {
            int releaseKey = Get45or451FromRegistry();

            if ((releaseKey >= 379893))
            {
                // .NET Framework 4.5.2
                return 2;
            }
            if ((releaseKey >= 378675))
            {
                // .NET Framework 4.5.1 installed with Windows 8.1 or Windows Server 2012 R2
                return 1;
            }

            if ((releaseKey >= 378758))
            {
                // .NET Framework 4.5.1 installed on Windows 8, Windows 7
                return 1;
            }

            if ((releaseKey >= 378389))
            {
                // .NET Framework 4.5
                return 0;
            }
            // This line should never execute. A non-null release key should mean 
            // that 4.5 or later is installed. 
            return -1;
        }

        public static int CheckFor46DotVersion_i()
        {
            int releaseKey = Get45or451FromRegistry();

            System.OperatingSystem osInfo = System.Environment.OSVersion;
            if ((releaseKey == 393295) || (releaseKey == 393297))
            {   //.NET Framework 4.6 installed on all OS versions other than Windows 10  (393297)
                // .NET Framework 4.6 installed on Windows 10 (393295)
                return 46;
            }

            if ((releaseKey == 394254) || (releaseKey == 394271))
            {   // .NET Framework 4.6.1 installed on Windows 10 November Update (394254)
                // .NET Framework 4.6.1 installed on all OS versions other than Windows 10 November Update (394271)
                return 461;
            }


            if ((releaseKey == 394802) || (releaseKey == 394806))
            {   // .NET Framework 4.6.2 installed on  Windows 10 Anniversary (394802)
                // .NET Framework 4.6.2 installed on all OS versions other than Windows 10 November Update (394806)
                return 462;
            }



            if ((releaseKey == 460798) || (releaseKey == 460798))
            {
                return 470;
            }


            if ((releaseKey == 461308) || (releaseKey == 461310))
            {
                return 471;
            }

            if (releaseKey > 461310) return 490;
                //if (osInfo.Version.Major == 10)
                //{
                //    if ((releaseKey == 393295))
                //    {
                //        return 46;
                //    }
                //}
                //else
                //{
                //    if ((releaseKey == 393297))
                //    {
                //        return 46;
                //    }
                //}


                return -1;
        }
        // Codex Segment
        public static int CheckFor47DotVersion_i()
        {
            int releaseKey = Get45or451FromRegistry();

            System.OperatingSystem osInfo = System.Environment.OSVersion;
            if ((releaseKey == 460798) || (releaseKey == 460805))
            {   //.NET Framework 4.7 installed on all OS   (460805)
                // .NET Framework 4.7 Windows 10 Creators Update (460798)
                return 470;
            }

            if ((releaseKey == 461308) || (releaseKey == 461310))
            {   //.NET Framework 4.7.1 installed on Windows 10 Fall Creators Update	461308
                // .NET Framework 4.7.1 installed on all other Windows OS versions	461310
                return 471;
            }

            if ((releaseKey > 461310))
            {   //Unknow New Version;
                return 490;
            }



            return -1;
        }
        public static bool IsNET35SP1()
        {
            bool result = false; // .NET Framework 3.5 SP1 with Service Pack #1 does not installed 
            // Opens the registry key for the .NET Framework entry. 


            try
            {
                RegistryKey ndpKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\");
                String versionKeyName = "v3.5";

                RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                string name = (string)versionKey.GetValue("Version", "");
                string sp = versionKey.GetValue("SP", "").ToString();
                string install = versionKey.GetValue("Install", "").ToString();

                if (install == "") //no install info, must be later.
                { result = false; return result; }
                else
                {
                    if (sp != "" && install == "1")
                    {
                        { result = true; return result; }
                        //Console.WriteLine(versionKeyName + "  " + name + "  SP" + sp);
                    }

                }
                if (name != "")
                {
                    { result = false; return result; }

                }

            }
            catch
            {
                { result = false; return result; }
            }

            result = false; return result;
        }

    }
}
