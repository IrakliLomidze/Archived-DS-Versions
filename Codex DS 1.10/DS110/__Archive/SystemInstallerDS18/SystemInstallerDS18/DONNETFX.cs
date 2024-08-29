using System;


using Microsoft.Win32;

namespace CodexInstaller
{
    class DONNETFX
    {



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

        public static string CheckFor46_48DotVersion()
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

            if ((releaseKey == 461808) || (releaseKey == 461814))
            {
                return "OK: .NET Framework 4.72";
            }

            if ((releaseKey == 528040) || (releaseKey == 528372) || (releaseKey == 528049))
            {
                return "OK: .NET Framework 4.8";
            }


            if (releaseKey > 528372) return "OK: .NET Framework 4.8 or above";


            // This line should never execute. A non-null release key should mean 
            // that 4.6 or later is installed. 
            return "WARRNING: No .NET Framework 4.8 or later version detected";

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

        ////public static int CheckFor46DotVersion_i()
        ////{
        ////    int releaseKey = Get45or451FromRegistry();

        ////    System.OperatingSystem osInfo = System.Environment.OSVersion;
        ////    if ((releaseKey == 393295) || (releaseKey == 393297))
        ////    {   //.NET Framework 4.6 installed on all OS versions other than Windows 10  (393297)
        ////        // .NET Framework 4.6 installed on Windows 10 (393295)
        ////        return 46;
        ////    }

        ////    if ((releaseKey == 394254) || (releaseKey == 394271))
        ////    {   // .NET Framework 4.6.1 installed on Windows 10 November Update (394254)
        ////        // .NET Framework 4.6.1 installed on all OS versions other than Windows 10 November Update (394271)
        ////        return 461;
        ////    }


        ////    if ((releaseKey == 394802) || (releaseKey == 394806))
        ////    {   // .NET Framework 4.6.2 installed on  Windows 10 Anniversary (394802)
        ////        // .NET Framework 4.6.2 installed on all OS versions other than Windows 10 November Update (394806)
        ////        return 462;
        ////    }



        ////    if ((releaseKey == 460798) || (releaseKey == 460798))
        ////    {
        ////        return 470;
        ////    }


        ////    if ((releaseKey == 461308) || (releaseKey == 461310))
        ////    {
        ////        return 471;
        ////    }

        ////    if (releaseKey > 461310) return 490;
        ////        //if (osInfo.Version.Major == 10)
        ////        //{
        ////        //    if ((releaseKey == 393295))
        ////        //    {
        ////        //        return 46;
        ////        //    }
        ////        //}
        ////        //else
        ////        //{
        ////        //    if ((releaseKey == 393297))
        ////        //    {
        ////        //        return 46;
        ////        //    }
        ////        //}


        ////        return -1;
        ////}
        // Codex Segment
        public static int CheckFor48DotVersion_i()
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


            if ((releaseKey == 461808) || (releaseKey == 461814))
            {
                //On Windows 10 April 2018 Update and Windows Server, version 1803: 461808
                //On all Windows operating systems other than Windows 10 April 2018 Update and Windows Server, version 1803: 461814
                return 472;
            }

            if ((releaseKey == 528040) || (releaseKey == 528372) || (releaseKey == 528049))
            {
                ////On Windows 10 May 2019 Update and Windows 10 November 2019 Update: 528040
                ////On Windows 10 May 2020 Update and Windows 10 October 2020 Update: 528372
                ////On all other Windows operating systems(including other Windows 10 operating systems): 528049
                return 480;
            }


            if (releaseKey > 528372) { 
                return 481;
            }



            return -1;
        }
   

    }
}
