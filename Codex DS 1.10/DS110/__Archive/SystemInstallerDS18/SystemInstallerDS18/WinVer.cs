using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4
{
    class WinVer
    {
        static bool isSupprtedOsVersion()
        {
            bool Result = false;
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            
            switch (osInfo.Platform)
            {
                case System.PlatformID.Win32Windows:
                    {
                        // Code to determine specific version of Windows 95, 
                        // Windows 98, Windows 98 Second Edition, or Windows Me.
                        Result = false;
                        return Result;
                    } break;

                case System.PlatformID.Win32NT:
                    {
                        // Code to determine specific version of Windows NT 3.51, 
                        // Windows NT 4.0, Windows 2000, or Windows XP.
                        if ((osInfo.Version.Major == 6) && (osInfo.Version.Major == 1))
                        {
                            // 6.1 Windows Server 2008 R2
                            // Windows 7
                            // Windows Server 2008 R2
                            if (osInfo.ServicePack.Trim() == "") Result = false; else Result = true;  // if Service Pack Instaled
                            return Result;
                         }

                        if ((osInfo.Version.Major == 6) && (osInfo.Version.Major == 2))
                        {
                            // 6.2 
                            // Windows Server 2012
                            // Windows 8
                            // Windows Server 2008 R2
                            Result = true; 
                            return Result;
                           
                        }

                        if ((osInfo.Version.Major == 6) && (osInfo.Version.Major == 3))
                        {
                            // 6.3 
                            // Windows Server 2012 R2
                            // Windows 8.1
                            Result = true;
                            return Result;

                        }

                        // https://msdn.microsoft.com/en-us/library/windows/desktop/dn481241(v=vs.85).aspx
                        // Targeting your application for Windows

                        if ((osInfo.Version.Major == 10) )
                        {
                            // 10.0 
                            // Windows 10
                            Result = true;
                            return Result;

                        }
                    } break;

            }
			
            return false;

        }
        string GetWindowsVersion()
        {
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            return "";
        }
    }
}
