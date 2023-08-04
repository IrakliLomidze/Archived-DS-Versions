#include "stdafx.h"
#include ".\mdac.h"
#include "generalrun.h"

ILI_MDAC::ILI_MDAC(void)
{
}

ILI_MDAC::~ILI_MDAC(void)
{
}

TCHAR* ILI_GetMajorVersion(TCHAR *str)
{
  if ((str == _T("")) || (str == NULL))  return _T("");
  TCHAR *ts = _T("                   ");
  TCHAR *rs = _T("                   ");
  int  result;
  ts = _tcsstr( str, _T(".") );
  if( ts != NULL ) 
			{
				result = ts - str + 1;
				rs = (TCHAR *)malloc(result*sizeof(TCHAR));
				_tcsncpy( rs , str, result-1);
				rs[result-1] = 0;
			}
  else
			{
				rs = (TCHAR *)malloc(_tcslen(str)*sizeof(TCHAR));
				_tcscpy(rs,str);
			}
return rs;
}

TCHAR* ILI_GetMinorVersion(TCHAR *str)
{
  if ((str == _T("")) || (str == NULL))  return NULL;
  TCHAR *ts = _T("                      ");
  int  result;
  ts = _tcsstr( str, _T(".") );
  if( ts != NULL ) 
			{
				result = ts - str + 1;
				str = str + result;
			}
  else
			{
				str = NULL;
			}
return str;
}


int ILI_VersionCompare(TCHAR *Version1Str, TCHAR *Version2Str)
{ // Version String is xx.xx.xxx.xxx.xx


  
  if ((_tcslen(Version1Str) == 0) || (_tcslen(Version1Str) == 0)) return 2; // v1 or v2 is null
  bool loop = true;
  TCHAR *v1 = _T("             "); //= "";GetMajorVersion(Version1Str);
  TCHAR *v2 = _T("             "); // = GetMajorVersion(Version2Str);;
  
  while (loop == true)
  {
	  v1    = ILI_GetMajorVersion(Version1Str);
	  Version1Str = ILI_GetMinorVersion(Version1Str);

	  v2    = ILI_GetMajorVersion(Version2Str);
	  Version2Str = ILI_GetMinorVersion(Version2Str);
	  int iv1,iv2;
	  int r = _tcscmp(v1,v2);
	  if (r != 0) return r;
	  if (((v1 == NULL) || (v1 == _T("")))  && ((v2 == NULL)|| (v2 == _T(""))) ) break;
	  //if (v1 != NULL) free(v1);if (v2 != NULL) free(v2);
  }
  
  return 0;
}



#define LENGTH(A) (sizeof(A)/sizeof(A[0]))
// MDAC Version Detecter
bool ILI_MDAC::ILI_checkMDAC()
{
	// now we'll check the registry for this value
	//
	LONG lResult;
	HKEY hkey = NULL;
	
	lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
							_T("SOFTWARE\\Microsoft\\DataAccess"),      // name of subkey to open
							NULL,
							KEY_READ,
							&hkey               // handle to open key
							);

	// we don't proceed unless the call above succeeds
	if (ERROR_SUCCESS != lResult && ERROR_FILE_NOT_FOUND != lResult)
	{
		throw HRESULT_FROM_WIN32(lResult);
	}

	TCHAR szVersion[256];
	if (ERROR_SUCCESS == lResult)
	{
		DWORD dwBufLen = LENGTH(szVersion);

		lResult = RegQueryValueEx( hkey,
							_T("FullInstallVer"),
								NULL,
								NULL,
								(LPBYTE)szVersion,
								&dwBufLen);
	    
		// if we receive an error other than 0x2, throw
		if (ERROR_SUCCESS == lResult)
		{
		
		}
		else if (ERROR_FILE_NOT_FOUND != lResult)
		{
		
			RegCloseKey(hkey);
			MessageBox(NULL, _T("Did not Find MDAC"), _T("Error"), MB_OK | MB_ICONINFORMATION);
			throw HRESULT_FROM_WIN32(lResult);
		}
		
		//RegCloseKey(hkey);
	}

	
	CurrentVersion = (TCHAR *)malloc((_tcslen(szVersion)+1)*sizeof(TCHAR));
	_tcscpy( CurrentVersion,szVersion);//, strlen(szVersion)-1);
	CurrentVersion[_tcslen(szVersion)] = 0;
	if (ILI_VersionCompare(_T("2.8"),szVersion) == 1) return true; 
	return false;

}


DWORD ILI_MDAC::InstallMDAC()
{
	
	return 0;
}
