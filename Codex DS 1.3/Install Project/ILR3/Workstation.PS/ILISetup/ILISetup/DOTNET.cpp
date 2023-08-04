#include "stdafx.h"
#include ".\dotnet.h"

ILI_DOTNET::ILI_DOTNET(void)
{
}

ILI_DOTNET::~ILI_DOTNET(void)
{
}

#define LENGTH(A) (sizeof(A)/sizeof(A[0]))


/******************************************************************
Function Name:	RegistryGetValue
Description:	Get the value of a reg key
Inputs:			HKEY hk - The hk of the key to retrieve
				TCHAR *pszKey - Name of the key to retrieve
				TCHAR *pszValue - The value that will be retrieved
				DWORD dwType - The type of the value that will be retrieved
				LPBYTE data - A buffer to save the retrieved data
				DWORD dwSize - The size of the data retrieved
Results:		true if successful, false otherwise
******************************************************************/
bool RegistryGetValue(HKEY hk, const TCHAR * pszKey, const TCHAR * pszValue, DWORD dwType, LPBYTE data, DWORD dwSize)
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



void ILI_DOTNET::ili_dotnetcheck3()
{
        HRESULT hr;
        // now we'll check the registry for this value
        //
        LONG lResult;
        HKEY hkey = NULL;
		
		framework35 = 0;
		framework35sp1 = 0;	

        
        lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
                                _T("SOFTWARE\\Microsoft\\.NETFramework\\v3.5"),    // name of subkey to open
                                NULL,
                                KEY_READ,
                                &hkey               // handle to open key
                                );


		// we don't proceed unless the call above succeeds
        if  (ERROR_SUCCESS != lResult && ERROR_FILE_NOT_FOUND != lResult)
        {
			framework35 = 0;
			framework35sp1 = 0;
			return;// .NET Framework 3.5 is not found ERROR_FILE_NOT_FOUND;
        }
        
		if (hkey != NULL) RegCloseKey(hkey);
		
        lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
                                _T("Software\\Microsoft\\NET Framework Setup\\NDP\\v3.5"),    // name of subkey to open
                                NULL,
                                KEY_READ,
                                &hkey               // handle to open key
                                );

		if  (ERROR_SUCCESS != lResult && ERROR_FILE_NOT_FOUND != lResult)
        {
          
		  framework35 = 0;
		  framework35sp1 = 0;
	      return;// .NET Framework 3.5 is not found ERROR_FILE_NOT_FOUND;
        }

		if (hkey != NULL) RegCloseKey(hkey);
    
	
           if (ERROR_SUCCESS == lResult)
            {
		      framework35 = 1;
		      DWORD dwRegValue=0;

		      if (RegistryGetValue(HKEY_LOCAL_MACHINE, _T("Software\\Microsoft\\NET Framework Setup\\NDP\\v3.5"), _T("SP"), NULL, (LPBYTE)&dwRegValue, sizeof(DWORD)))
	            {
		          framework35sp1 = (int)dwRegValue;
	            }
		     }

	return;
}



// -=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

