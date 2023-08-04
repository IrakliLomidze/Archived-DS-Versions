#include "stdafx.h"
#include ".\font.h"

ILI_Font::ILI_Font(void)
{
}

ILI_Font::~ILI_Font(void)
{
}

#define LENGTH(A) (sizeof(A)/sizeof(A[0]))

bool ILI_Font::CheckFont()
{
	LONG lResult = 0;
	HKEY hkey = NULL;
    
	lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
							_T("Software\\Microsoft\\Windows NT\\CurrentVersion\\Fonts"),      // name of subkey to open
							NULL,
							KEY_READ,
							&hkey               // handle to open key
							);
	
	// we don't proceed unless the call above succeeds
	if (ERROR_SUCCESS != lResult && ERROR_FILE_NOT_FOUND != lResult)
	{
		
		throw HRESULT_FROM_WIN32(lResult);
	}

	TCHAR szVersion[512];

	

	if (ERROR_SUCCESS == lResult)
	{
		DWORD dwBufLen = LENGTH(szVersion);
		

		lResult = RegQueryValueEx( hkey,
								_T("GeoABC (TrueType)"),
								NULL,
								NULL,
								(LPBYTE)szVersion,
								&dwBufLen);

		// if we receive an error other than 0x2, throw
	


		if (ERROR_SUCCESS == lResult)
		{

			if (hkey != NULL) RegCloseKey(hkey);

			return true;
		}
		else if (ERROR_FILE_NOT_FOUND != lResult)
		{

			if (hkey != NULL) RegCloseKey(hkey);

			return false;// you did not have installed "geoabc" font
			throw HRESULT_FROM_WIN32(lResult);
		}
		
		
	}

	return false;
	
}