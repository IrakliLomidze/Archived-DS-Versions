#include "StdAfx.h"
#include "PowerShell.h"
#include <string>


PowerShell::PowerShell(void)
{
}



PowerShell::~PowerShell(void)
{
}


bool RegistryGetValue4(HKEY hk, const TCHAR * pszKey, const TCHAR * pszValue, DWORD dwType, LPBYTE data, DWORD dwSize)
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
void PowerShell::ili_PowerShell1()
{
        TCHAR szRegValue[MAX_PATH];
		bool bRegistryRetVal = false;
		
		PowerShell1 = 0;
		
		if (RegistryGetValue4(HKEY_LOCAL_MACHINE, _T("Software\\Microsoft\\PowerShell\\1"), _T("PID"), NULL, (LPBYTE)szRegValue, MAX_PATH)  == true)
		{
		         	std::wstring s2(szRegValue);
					if (s2.compare(_T("89383-100-0001260-04309")) == 0) PowerShell1 = 1;  // RTM
					if (s2.compare(_T("89393-100-0001260-00301")) == 0) PowerShell1 = -1; // RC
        }

        
        
	return;
}
