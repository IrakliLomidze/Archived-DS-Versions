#include "stdafx.h"
#include ".\sxs.h"
#pragma comment(lib,"version")

ILI_SXS::ILI_SXS(void)
{
	BuildVersion = 0;
}

ILI_SXS::~ILI_SXS(void)
{
}


#define LENGTH(A) (sizeof(A)/sizeof(A[0]))
#define INFO_BUFFER_SIZE 32767

bool ILI_SXS::ILI_check()
{
	// now we'll check the registry for this value
	//
	
	TCHAR  infoBuf[INFO_BUFFER_SIZE];
    DWORD  bufCharCount = INFO_BUFFER_SIZE;


	if (GetSystemDirectory(infoBuf,bufCharCount) != 0)
	{
         
		_tcscat_s(infoBuf, INFO_BUFFER_SIZE, _T("\\sxs.dll"));
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
	    
		
		//WORD major = HIWORD(pFixedFileInfo->dwProductVersionMS);
		//WORD minor = LOWORD(pFixedFileInfo->dwProductVersionMS);
	
		WORD majorX = HIWORD(pFixedFileInfo->dwFileVersionLS);
		WORD minorX = LOWORD(pFixedFileInfo->dwFileVersionLS);
		BuildVersion = minorX;


	    TCHAR r[100];	
		_stprintf_s(r,100,_T("%d"),majorX);
		//_itot_s(majorX,r,100,20);
		

		TCHAR r2[100];	
		//_itot_s(minorX,r2,100,20);
		_stprintf_s(r2,100,_T("%d"),minorX);
		
        
		CurrentVersion = (TCHAR*) malloc((_tcslen(r)+_tcslen(r2)+1+1)*sizeof(TCHAR));
		
		_tcscpy_s(CurrentVersion,256,r);
		_tcscat(CurrentVersion,_T("."));
		_tcscat(CurrentVersion,r2);

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
