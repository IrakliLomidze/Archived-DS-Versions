#include "stdafx.h"
#include ".\sql5expr.h"

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
