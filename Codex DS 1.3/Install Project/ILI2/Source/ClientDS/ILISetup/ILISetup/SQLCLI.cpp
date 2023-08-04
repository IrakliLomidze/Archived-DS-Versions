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
	
	TCHAR  infoBuf[INFO_BUFFER_SIZE];
    DWORD  bufCharCount = INFO_BUFFER_SIZE;

	if (GetSystemDirectory(infoBuf,bufCharCount) != 0)
	{
         
		_tcscat_s(infoBuf, INFO_BUFFER_SIZE, _T("\\Sqlncli.dll"));
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
		return false;

	}
	else
	{
		return true;
	}
	return false;

}
