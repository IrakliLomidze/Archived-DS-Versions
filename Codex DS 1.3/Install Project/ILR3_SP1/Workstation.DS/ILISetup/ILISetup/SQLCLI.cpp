#include "stdafx.h"
#include ".\sqlcli.h"
#pragma comment(lib,"version")

ILI_SQLNative::ILI_SQLNative(void)
{
}

ILI_SQLNative::~ILI_SQLNative(void)
{
}


#define LENGTH(A) (sizeof(A)/sizeof(A[0]))
#define INFO_BUFFER_SIZE 32767

bool ILI_SQLNative::ILI_checkMSI()
{
	// now we'll check the registry for this value
	//
	// msiexec /i sqlncli.msi ADDLOCAL=ALL APPGUID={0CC618CE-F36A-415E-84B4-FB1BFF6967E1}
	// If you use the /passive, /qn, /qb, or /qr option with msiexec, you must also specify IACCEPTSQLNCLILICENSETERMS=YES, to explicitly indicate that you accept the terms of the end user license. This option must be specified in all capital letters.

	TCHAR  infoBuf[INFO_BUFFER_SIZE];
    DWORD  bufCharCount = INFO_BUFFER_SIZE;

	if (GetSystemDirectory(infoBuf,bufCharCount) != 0)
	{
         
		_tcscat_s(infoBuf, INFO_BUFFER_SIZE, _T("\\sqlncli10.dll"));
	}
	else
	{
		return true;
	}

	
	//Find out how much space we need to store the version 
	//information block.
	DWORD dwVersionInfoSize;
	DWORD dwZero; //Temp variable.
	dwVersionInfoSize = GetFileVersionInfoSize(infoBuf, &dwZero);
	if (dwVersionInfoSize != 0)
	{
		//Allocate space to store the version info.
		void* pVersionInfo = malloc(dwVersionInfoSize);

		//Use GetFileVersionInfo to copy the version info 
		//block into pVersion info.
		if (!GetFileVersionInfo(infoBuf, 0, dwVersionInfoSize, pVersionInfo))
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
	    

		WORD major = HIWORD(pFixedFileInfo->dwProductVersionMS);
		WORD minor = LOWORD(pFixedFileInfo->dwProductVersionMS);
		
		CString VersionInfo;
		VersionInfo.Format(_T("%d.%d"),major,minor);

		CurrentVersion = VersionInfo;
		

		free(pVersionInfo);
		
		if ((major == 10) && (minor == 50)) return false; // This is a Right Version
		if ((major == 10) && (minor == 5)) return false; // This is a Right Version
		
		return true;

	}
	else
	{
		return true;
	}
	
	return true;

}
