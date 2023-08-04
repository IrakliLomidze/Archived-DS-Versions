#include "stdafx.h"
#include ".\sql5expr.h"
#include <string>
#include <errno.h>
#include "GeneralRun.h"

ILI_SQLEXPRESS::ILI_SQLEXPRESS(void)
{
}

ILI_SQLEXPRESS::~ILI_SQLEXPRESS(void)
{
}

#define LENGTH(A) (sizeof(A)/sizeof(A[0]))
int ILI_SQLEXPRESS::ILI_checkMSDE()
{
	// now we'll check the registry for this value
	//
	LONG lResult;
	HKEY hkey = NULL;
	
	lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
							_T("SOFTWARE\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL"),      // name of subkey to open
							NULL,
							KEY_READ,
							&hkey               // handle to open key
							);

	// we don't proceed unless the call above succeeds
	if (ERROR_SUCCESS != lResult && ERROR_FILE_NOT_FOUND != lResult)
	{
		return 1;//throw HRESULT_FROM_WIN32(lResult);
	}

	if (ERROR_SUCCESS == lResult)
	{
        TCHAR szVersion[256];
	  	DWORD dwBufLen = LENGTH(szVersion);
		lResult = RegQueryValueEx( hkey,
								_T("CODEX2007"),
								NULL,
								NULL,
								(LPBYTE)szVersion,
								&dwBufLen);
		// if we receive an error other than 0x2, throw
		if (ERROR_SUCCESS == lResult)
		{
			RegCloseKey(hkey);
			return 0;
		}
		else if (ERROR_FILE_NOT_FOUND != lResult)
		{
			RegCloseKey(hkey);
			return 1;
			//throw HRESULT_FROM_WIN32(lResult);
		}

	}
	
	RegCloseKey(hkey);
	  return 1;
}

bool RegistryGetValue2(HKEY hk, const TCHAR * pszKey, const TCHAR * pszValue, DWORD dwType, LPBYTE data, DWORD dwSize)
{
	HKEY hkOpened;

	// Try to open the key
	if (RegOpenKeyEx(hk, pszKey, 0, KEY_READ, &hkOpened) != ERROR_SUCCESS)
	{
		return false;
	}

	// If the key was opened, try to retrieve the value
	if (RegQueryValueEx(hkOpened, pszValue, 0, &dwType, (LPBYTE)data, &dwSize) != ERROR_SUCCESS)
	{
		RegCloseKey(hkOpened);
		return false;
	}
	
	// Clean up
	RegCloseKey(hkOpened);

	return true;
}


using namespace std;


// this need for detection if SQL Server 2005 Codex 2007 Instance is Installed as X86
int ILI_SQLEXPRESS::ILI_IsInstanceX64()//std::wstring instancename)
{
    if (IsWow64() == FALSE) return 0;
	TCHAR szRegValue[MAX_PATH];
	bool bRegistryRetVal = false;
	
	if (RegistryGetValue2(HKEY_LOCAL_MACHINE, _T("Software\\Wow6432Node\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL"), _T("CODEX2007"), NULL, (LPBYTE)szRegValue, MAX_PATH)  == true)
	{
		return 86; // Instance is X86
	}


	 // Always redirect to Wow6432Node because is compiled as 32 bit application

	if (RegistryGetValue2(HKEY_LOCAL_MACHINE, _T("Software\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL"), _T("CODEX2007"), NULL, (LPBYTE)szRegValue, MAX_PATH)  == true)
	{
		return 64; // Instance is X64
	}

	
	return 1;
}
int ILI_SQLEXPRESS::ILI_GetSQLVersion()
{
	TCHAR szRegValue[MAX_PATH];
	
	
	bool bRegistryRetVal = false;

	if (RegistryGetValue2(HKEY_LOCAL_MACHINE, _T("Software\\Microsoft\\Microsoft SQL Server\\CODEX2007\\MSSQLServer\\CurrentVersion"), _T("CurrentVersion"), NULL, (LPBYTE)szRegValue, MAX_PATH)  == true)
	//if (RegistryGetValue2(HKEY_LOCAL_MACHINE, _T("Software\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL"), _T("CODEX2007"), NULL, (LPBYTE)szRegValue, MAX_PATH)  == true)
	{
		
		
		size_t Point1;
		size_t Point2;
		std::wstring s2(szRegValue);
		Point1 = s2.find_first_of(_T("."),0);    // Find Firs Dot
		if (Point1 == string::npos) return 1000; // Does Not Contain Version
		std::wstring Version1;
		Version1 = s2.substr(0,Point1);
		Point2 = s2.find_first_of(_T("."),Point1+1); // Find Second Dot
		if (Point2 == string::npos) return 1000; // Does Not Contain Version
		std::wstring Version2;
		Version2 = s2.substr(Point1+1,Point2-Point1-1);
		
		
		std::wstring VersionG;
		VersionG = s2.substr(0,Point2);
		
		//MessageBox(0,s2.c_str(),0,MB_OK);
		//MessageBox(0,(LPCTSTR)Version1.c_str(),0,MB_OK);
		//MessageBox(0,(LPCTSTR)Version2.c_str(),0,MB_OK);
		
		int _version1 = _wtoi(Version1.c_str());
		if (errno != 0 ) return 1000;
		int _version2 = _wtoi(Version2.c_str());
		if (errno != 0 ) return 1000;

		//StrTrim(szRegValue, trim);
		
		if ((_version1 == 9) && (_version2 == 0)) return 2005; // SQL 2005
		if ((_version1 == 10) && (_version2 == 0)) return 2008; // SQL 2008
		if ((_version1 == 10) && (_version2 == 5)) return 2010; // SQL 2008R2
		if ((_version1 == 10) && (_version2 == 50)) return 2010; // SQL 2008R2

		//if (VersionG.compare(_T("9.0")) == 0) return 2005; // SQL 2005
		//if (VersionG.compare(_T("9.00")) == 0) return 2005; // SQL 2005
		//if (VersionG.compare(_T("10.00")) == 0) return 2008; // SQL 2008
		//if (VersionG.compare(_T("10.0")) == 0) return 2008; // SQL 2008
		//if (VersionG.compare(_T("10.5")) == 0) return 2010; // SQL 2008R2

		return 3000; // Unknown Version
	}

	return 0; // Does not Exists
}