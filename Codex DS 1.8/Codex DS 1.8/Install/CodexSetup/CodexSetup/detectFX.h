#pragma once
// In case the machine this is compiled on does not have the most recent platform SDK
// with these values defined, define them here
#ifndef SM_TABLETPC
	#define SM_TABLETPC     86
#endif

#ifndef SM_MEDIACENTER
	#define SM_MEDIACENTER  87
#endif

#include<string>



class ILI_DOTNETFX
{


// Constants that represent registry key names and value names
// to use for detection
const std::string g_szNetfx10RegKeyName = "Software\\Microsoft\\.NETFramework\\Policy\\v1.0";
const std::string g_szNetfx10RegKeyValue = "3705";
const std::string g_szNetfx10SPxMSIRegKeyName = "Software\\Microsoft\\Active Setup\\Installed Components\\{78705f0d-e8db-4b2d-8193-982bdda15ecd}";
const std::string g_szNetfx10SPxOCMRegKeyName = "Software\\Microsoft\\Active Setup\\Installed Components\\{FDC11A6F-17D1-48f9-9EA3-9051954BAA24}";
const std::string g_szNetfx11RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v1.1.4322";
const std::string g_szNetfx20RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v2.0.50727";
const std::string g_szNetfx30RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v3.0\\Setup";
const std::string g_szNetfx30SpRegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v3.0";
const std::string g_szNetfx30RegValueName = "InstallSuccess";
const std::string g_szNetfx35RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v3.5";
const std::string g_szNetfx40ClientRegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v4\\Client";
const std::string g_szNetfx40FullRegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full";
const std::string g_szNetfx40SPxRegValueName = "Servicing";
const std::string g_szNetfx45RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full";
const std::string g_szNetfx45RegValueName = "Release";
const std::string g_szNetfx46RegKeyName = "Software\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full";
const std::string g_szNetfx46RegValueName = "Release";


const std::string g_szNetfxStandardRegValueName = "Install";
const std::string g_szNetfxStandardSPxRegValueName = "SP";
const std::string g_szNetfxStandardVersionRegValueName = "Version";

// Version information for final release of .NET Framework 3.0
const int g_iNetfx30VersionMajor = 3;
const int g_iNetfx30VersionMinor = 0;
const int g_iNetfx30VersionBuild = 4506;
const int g_iNetfx30VersionRevision = 26;

// Version information for final release of .NET Framework 3.5
const int g_iNetfx35VersionMajor = 3;
const int g_iNetfx35VersionMinor = 5;
const int g_iNetfx35VersionBuild = 21022;
const int g_iNetfx35VersionRevision = 8;

// Version information for final release of .NET Framework 4
const int g_iNetfx40VersionMajor = 4;
const int g_iNetfx40VersionMinor = 0;
const int g_iNetfx40VersionBuild = 30319;
const int g_iNetfx40VersionRevision = 0;

// Version information for final release of .NET Framework 4.5
const int g_dwNetfx45ReleaseVersion = 378389;

// Version information for final release of .NET Framework 4.5.1
// The deployment guide says to use value 378758, but the version of the 
// .NET Framework 4.5.1 in Windows 8.1 has value 378675, so we have to use that instead
const int g_dwNetfx451ReleaseVersion = 378675;

// Version information for final release of .NET Framework 4.5.2
const int g_dwNetfx452ReleaseVersion = 379893;

const int g_dwNetfx46ReleaseVersion = 393297;
const int g_dwNetfx46ReleaseVersion10 = 393295;

const int g_dwNetfx461ReleaseVersion = 394271;
const int g_dwNetfx461ReleaseVersion10 = 394254;


const int g_dwNetfx47ReleaseVersion = 460805;
const int g_dwNetfx47ReleaseVersion10 = 460798;

const int g_dwNetfx48ReleaseVersion = 528049;
const int g_dwNetfx48ReleaseVersion10 = 528372;
const int g_dwNetfx48ReleaseVersion102 = 528049;

public:
	ILI_DOTNETFX(void);

bool IsNetfx48Installed();

~ILI_DOTNETFX(void);

};

