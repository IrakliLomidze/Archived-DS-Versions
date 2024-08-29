
#include <stdio.h>
#include <windows.h>
#include <strsafe.h>
#include "detectFX.h"
#include <string>
#include <stdio.h>
#include <vector>
#include <iostream>

ILI_DOTNETFX::ILI_DOTNETFX(void)
{
}

ILI_DOTNETFX::~ILI_DOTNETFX(void)
{
}


bool RegistryGetValue(HKEY hk, const std::string* pszKey, const std::string* pszValue, DWORD dwType, LPBYTE data, DWORD dwSize);
std::vector<std::string> split(const std::string& s, char seperator);

//.NET Framework 4.8	On Windows 10 May 2019 Update and Windows 10 November 2019 Update: 528040
//On Windows 10 May 2020 Update and Windows 10 October 2020 Update : 528372
//On all other Windows operating systems(including other Windows 10 operating systems) : 528049

bool ILI_DOTNETFX::IsNetfx48Installed()
{
	bool bRetValue = false;
	DWORD dwRegValue = 0;

	if (RegistryGetValue(HKEY_LOCAL_MACHINE, &g_szNetfx46RegKeyName, &g_szNetfx46RegValueName, NULL, (LPBYTE)&dwRegValue, sizeof(DWORD)))
	{
		if ((g_dwNetfx48ReleaseVersion10 == dwRegValue) || (g_dwNetfx48ReleaseVersion10 == dwRegValue)
			|| (g_dwNetfx48ReleaseVersion102 == dwRegValue))
			bRetValue = true;

		if (dwRegValue > 528372) bRetValue = true;
	}



	return bRetValue;
}




/******************************************************************
Function Name:	CheckNetfxBuildNumber
Description:	Retrieves the .NET Framework build number from
                the registry and validates that it is not a pre-release
                version number
Inputs:         NONE
Results:        true if the build number in the registry is greater
				than or equal to the passed in version; false otherwise
******************************************************************/
bool CheckNetfxBuildNumber(const std::string *pszNetfxRegKeyName, const std::string *pszNetfxRegKeyValue, const int iRequestedVersionMajor, const int iRequestedVersionMinor, const int iRequestedVersionBuild, const int iRequestedVersionRevision)
{
	std::string szRegValue;
	std::string pszToken = "";
	std::string pszNextToken = "";
	int iVersionPartCounter = 0;
	int iRegistryVersionMajor = 0;
	int iRegistryVersionMinor = 0;
	int iRegistryVersionBuild = 0;
	int iRegistryVersionRevision = 0;
	bool bRegistryRetVal = false;

	// Attempt to retrieve the build number registry value
					  
	bRegistryRetVal = RegistryGetValue(HKEY_LOCAL_MACHINE, pszNetfxRegKeyName, pszNetfxRegKeyValue, NULL, (LPBYTE)szRegValue.c_str(), MAX_PATH);

	if (bRegistryRetVal)
	{
		// This registry value should be of the format
		// #.#.#####.##.  Try to parse the 4 parts of
		// the version here
		
		std::vector<std::string> tokens = split(szRegValue, '.');
		
		while (tokens.size() == 4)
		{
			iRegistryVersionMajor = std::stoi(tokens[0]);
			iRegistryVersionMinor = std::stoi(tokens[1]);
			iRegistryVersionBuild = std::stoi(tokens[2]);
			iRegistryVersionRevision = std::stoi(tokens[3]);
		}
	}

	
	// Compare the version number retrieved from the registry with
	// the version number of the final release of the .NET Framework
	// that we are checking
	if (iRegistryVersionMajor > iRequestedVersionMajor)
	{
		return true;
	}
	else if (iRegistryVersionMajor == iRequestedVersionMajor)
	{
		if (iRegistryVersionMinor > iRequestedVersionMinor)
		{
			return true;
		}
		else if (iRegistryVersionMinor == iRequestedVersionMinor)
		{
			if (iRegistryVersionBuild > iRequestedVersionBuild)
			{
				return true;
			}
			else if (iRegistryVersionBuild == iRequestedVersionBuild)
			{
				if (iRegistryVersionRevision >= iRequestedVersionRevision)
				{
					return true;
				}
			}
		}
	}

	// If we get here, the version in the registry must be less than the
	// version of the final release of the .NET Framework we are checking,
	// so return false
	return false;
}





/******************************************************************
Function Name:	RegistryGetValue
Description:	Get the value of a reg key
Inputs:			HKEY hk - The hk of the key to retrieve
				std::string *pszKey - Name of the key to retrieve
				std::string *pszValue - The value that will be retrieved
				DWORD dwType - The type of the value that will be retrieved
				LPBYTE data - A buffer to save the retrieved data
				DWORD dwSize - The size of the data retrieved
Results:		true if successful, false otherwise
******************************************************************/
bool RegistryGetValue(HKEY hk, const std::string * pszKey, const std::string * pszValue, DWORD dwType, LPBYTE data, DWORD dwSize)
{
	HKEY hkOpened;

	
	// Try to open the key
	if (RegOpenKeyExA(hk, pszKey->c_str(), 0, KEY_READ, &hkOpened) != ERROR_SUCCESS)
	{
		return false;
	}

	// If the key was opened, try to retrieve the value
	if (RegQueryValueExA(hkOpened, pszValue->c_str(), 0, &dwType, (LPBYTE)data, &dwSize) != ERROR_SUCCESS)
	{
		RegCloseKey(hkOpened);
		return false;
	}
	
	// Clean up
	RegCloseKey(hkOpened);

	return true;
}


std::vector<std::string> split(const std::string& s, char seperator)
{
	std::vector<std::string> output;

	std::string::size_type prev_pos = 0, pos = 0;

	while ((pos = s.find(seperator, pos)) != std::string::npos)
	{
		std::string substring(s.substr(prev_pos, pos - prev_pos));

		output.push_back(substring);

		prev_pos = ++pos;
	}

	output.push_back(s.substr(prev_pos, pos - prev_pos)); // Last word

	return output;
}