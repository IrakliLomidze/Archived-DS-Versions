#include "stdafx.h"
#include ".\msi.h"
#pragma comment(lib,"version")

ILI_MSI::ILI_MSI(void)
{
}

ILI_MSI::~ILI_MSI(void)
{
}

#define LENGTH(A) (sizeof(A)/sizeof(A[0]))
bool ILI_MSI::ILI_checkMSI()
{
	// now we'll check the registry for this value
	//
	LONG lResult;
	HKEY hkey = NULL;
	
	lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
							_T("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer"),      // name of subkey to open
							NULL,
							KEY_READ,
							&hkey // handle to open key
							);

	// we don't proceed unless the call above succeeds
	if (ERROR_SUCCESS != lResult && ERROR_FILE_NOT_FOUND != lResult)
	{
		throw HRESULT_FROM_WIN32(lResult);
		return true;
	}


	TCHAR szLocation[256];
	if (ERROR_SUCCESS == lResult)
	{
		DWORD dwBufLen = LENGTH(szLocation);

		lResult = RegQueryValueEx( hkey,
								_T("InstallerLocation"),
								NULL,
								NULL,
								(LPBYTE)szLocation,
								&dwBufLen);
	    
		// if we receive an error other than 0x2, throw
		if (ERROR_SUCCESS == lResult)
		{
		}
		else if (ERROR_FILE_NOT_FOUND != lResult)
		{

			RegCloseKey(hkey);
			throw HRESULT_FROM_WIN32(lResult);
			return true;
		}

		RegCloseKey(hkey);
	}
	_tcscat_s(szLocation, 256, _T("\\msiexec.exe"));


     
	
	//Find out how much space we need to store the version 
	//information block.
	DWORD dwVersionInfoSize;
	DWORD dwZero; //Temp variable.
	dwVersionInfoSize = GetFileVersionInfoSize(szLocation, &dwZero);
	if (dwVersionInfoSize)
	{
		//Allocate space to store the version info.
		void* pVersionInfo = malloc(dwVersionInfoSize);

		//Use GetFileVersionInfo to copy the version info 
		//block into pVersion info.
		if (!GetFileVersionInfo(szLocation, 0, dwVersionInfoSize, pVersionInfo))
		{
			free(pVersionInfo);
			return true;
		}

		//Use VerQueryValue to parse the version information
		//data block and get a pointer to the VS_FIXEDFILEINFO
		//structure.
		VS_FIXEDFILEINFO* pFixedFileInfo;
		UINT nBytesReturned;
		if (!VerQueryValue(pVersionInfo, _T("\\"), (void**)&pFixedFileInfo, &nBytesReturned))
		{
			free(pVersionInfo);
			return true;
		}
	    

		//WORD major = HIWORD(pFixedFileInfo->dwFileVersionMS);
		//WORD minor = LOWORD(pFixedFileInfo->dwFileVersionMS);

		WORD major = HIWORD(pFixedFileInfo->dwProductVersionMS);
		WORD minor = LOWORD(pFixedFileInfo->dwProductVersionMS);
		
	    TCHAR r[100];	
		_itot_s(major,r,100,20);

		TCHAR r2[100];	
		_itot_s(minor,r2,100,20);

		CurrentVersion = (TCHAR*) malloc((_tcslen(r)+_tcslen(r2)+1+1)*sizeof(TCHAR));
		//_tcscpy_s(CurrentVersion,256,r);
		//_tcscpy_s(CurrentVersion,256,_T("."));
		//_tcscpy_s(CurrentVersion,256,r2);
		
        


		_tcscpy_s(CurrentVersion,256,r);
		_tcscat(CurrentVersion,_T("."));
		_tcscat(CurrentVersion,r2);

		//strcpy( CurrentVersion, r);//, strlen(szVersion)-1);
		CurrentVersion[_tcslen(CurrentVersion)] = 0;

				
	
		free(pVersionInfo);

		if (((major == 3) && (minor >= 1)) || (major > 3))
		{
			return false;  // no need installing 
		}
		else
		{
			return true;
		}


	}
	return true;

}
