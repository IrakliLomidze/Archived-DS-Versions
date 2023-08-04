#include "stdafx.h"
#include <windows.h>
#include ".\generalrun.h"

GeneralRun::GeneralRun(void)
{
}

GeneralRun::~GeneralRun(void)
{
}

/*-------------------------------------------------------------------------

-
IsCurrentUserLocalAdministrator ()

This function checks the token of the calling thread to see if the caller
belongs to the Administrators group.

Return Value:
   TRUE if the caller is an administrator on the local machine.
   Otherwise, FALSE.
--------------------------------------------------------------------------*

*/

BOOL GeneralRun::IsCurrentUserLocalAdministrator(void)
{
   BOOL   fReturn         = FALSE;
   DWORD  dwStatus;
   DWORD  dwAccessMask;
   DWORD  dwAccessDesired;
   DWORD  dwACLSize;
   DWORD  dwStructureSize = sizeof(PRIVILEGE_SET);
   PACL   pACL            = NULL;
   PSID   psidAdmin       = NULL;

   HANDLE hToken              = NULL;
   HANDLE hImpersonationToken = NULL;

   PRIVILEGE_SET   ps;
   GENERIC_MAPPING GenericMapping;

   PSECURITY_DESCRIPTOR     psdAdmin           = NULL;
   SID_IDENTIFIER_AUTHORITY SystemSidAuthority = SECURITY_NT_AUTHORITY;


   /*
      Determine if the current thread is running as a user that is a member of
      the local admins group.  To do this, create a security descriptor that
      has a DACL which has an ACE that allows only local aministrators access.
      Then, call AccessCheck with the current thread's token and the security
      descriptor.  It will say whether the user could access an object if it
      had that security descriptor.  Note: you do not need to actually create
      the object.  Just checking access against the security descriptor alone
      will be sufficient.
   */
   const DWORD ACCESS_READ  = 1;
   const DWORD ACCESS_WRITE = 2;


   __try
   {

      /*
         AccessCheck() requires an impersonation token.  We first get a primary
         token and then create a duplicate impersonation token.  The 
		 impersonation token is not actually assigned to the thread, but is
         used in the call to AccessCheck.  Thus, this function itself never
         impersonates, but does use the identity of the thread.  If the thread
         was impersonating already, this function uses that impersonation context.
      */
      if (!OpenThreadToken(GetCurrentThread(), TOKEN_DUPLICATE|TOKEN_QUERY,TRUE, &hToken))
      {
         if (GetLastError() != ERROR_NO_TOKEN)
            __leave;

         if (!OpenProcessToken(GetCurrentProcess(),TOKEN_DUPLICATE|TOKEN_QUERY, &hToken))
            __leave;
      }

      if (!DuplicateToken (hToken, SecurityImpersonation,&hImpersonationToken))
          __leave;


      /*
        Create the binary representation of the well-known SID that
        represents the local administrators group.  Then create the security
        descriptor and DACL with an ACE that allows only local adminsaccess.
        After that, perform the access check.  This will determine whether
        the current user is a local admin.
      */
      if (!AllocateAndInitializeSid(&SystemSidAuthority, 2,
                                    SECURITY_BUILTIN_DOMAIN_RID,
                                    DOMAIN_ALIAS_RID_ADMINS,
                                    0, 0, 0, 0, 0, 0, &psidAdmin))
         __leave;

      psdAdmin = LocalAlloc(LPTR, SECURITY_DESCRIPTOR_MIN_LENGTH);
      if (psdAdmin == NULL)
         __leave;

      if (!InitializeSecurityDescriptor(psdAdmin,SECURITY_DESCRIPTOR_REVISION))
         __leave;

      // Compute size needed for the ACL.
      dwACLSize = sizeof(ACL) + sizeof(ACCESS_ALLOWED_ACE) +
                  GetLengthSid(psidAdmin) - sizeof(DWORD);

      pACL = (PACL)LocalAlloc(LPTR, dwACLSize);
      if (pACL == NULL)
         __leave;

      if (!InitializeAcl(pACL, dwACLSize, ACL_REVISION2))
         __leave;

      dwAccessMask= ACCESS_READ | ACCESS_WRITE;

      if (!AddAccessAllowedAce(pACL, ACL_REVISION2, dwAccessMask,psidAdmin))
         __leave;

      if (!SetSecurityDescriptorDacl(psdAdmin, TRUE, pACL, FALSE))
         __leave;

      /*
         AccessCheck validates a security descriptor somewhat; set the group
         and owner so that enough of the security descriptor is filled out to
         make AccessCheck happy.
      */
      SetSecurityDescriptorGroup(psdAdmin, psidAdmin, FALSE);
      SetSecurityDescriptorOwner(psdAdmin, psidAdmin, FALSE);

      if (!IsValidSecurityDescriptor(psdAdmin))
         __leave;

      dwAccessDesired = ACCESS_READ;

      /*
         Initialize GenericMapping structure even though you
         do not use generic rights.
      */
      GenericMapping.GenericRead    = ACCESS_READ;
      GenericMapping.GenericWrite   = ACCESS_WRITE;
      GenericMapping.GenericExecute = 0;
      GenericMapping.GenericAll     = ACCESS_READ | ACCESS_WRITE;

      if (!AccessCheck(psdAdmin, hImpersonationToken, dwAccessDesired,
                       &GenericMapping, &ps, &dwStructureSize, &dwStatus,
                       &fReturn))
      {
         fReturn = FALSE;
         __leave;
      }
   }
   __finally
   {
      // Clean up.
      if (pACL) LocalFree(pACL);
      if (psdAdmin) LocalFree(psdAdmin);
      if (psidAdmin) FreeSid(psidAdmin);
      if (hImpersonationToken) CloseHandle (hImpersonationToken);
      if (hToken) CloseHandle (hToken);
   }

   return fReturn;
}

// ==========================================================================
// ExecCmd()
//
// Purpose:
//  Executes command-line
// Inputs:
//  LPCTSTR pszCmd: command to run
// Outputs:
//  DWORD dwExitCode: exit code from the command
// Notes: This routine does a CreateProcess on the input cmd-line
//        and waits for the launched process to exit.
// ==========================================================================
DWORD GeneralRun::ExecCmd( LPCTSTR pszCmd )
{
    BOOL  bReturnVal   = false ;
    STARTUPINFO  si ;
    DWORD  dwExitCode ;
    SECURITY_ATTRIBUTES saProcess, saThread ;
    PROCESS_INFORMATION process_info ;

    ZeroMemory(&si, sizeof(si)) ;
    si.cb = sizeof(si) ;

    saProcess.nLength = sizeof(saProcess) ;
    saProcess.lpSecurityDescriptor = NULL ;
    saProcess.bInheritHandle = TRUE ;

    saThread.nLength = sizeof(saThread) ;
    saThread.lpSecurityDescriptor = NULL ;
    saThread.bInheritHandle = FALSE ;

    bReturnVal = CreateProcess(NULL, 
                               (LPTSTR)pszCmd, 
                               &saProcess, 
                               &saThread, 
                               FALSE, 
                               DETACHED_PROCESS, 
                               NULL, 
                               NULL, 
                               &si, 
                               &process_info) ;

    if (bReturnVal)
    {
        CloseHandle( process_info.hThread ) ;
        WaitForSingleObject( process_info.hProcess, INFINITE ) ;
        GetExitCodeProcess( process_info.hProcess, &dwExitCode ) ;
        CloseHandle( process_info.hProcess ) ;
    }
    else
    {
       // CError se( IDS_CREATE_PROCESS_FAILURE, 
         //          0, 
           //        MB_ICONERROR, 
             //      COR_EXIT_FAILURE, 
               //    pszCmd );

        //throw( se );
    }

    return dwExitCode;
}
// ========================================================================

#define MAX_KEY_LENGTH 255
#define MAX_VALUE_NAME 16383
#define LENGTH(A) (sizeof(A)/sizeof(A[0])) 


BOOL GeneralRun::NeedReboot()
{
	// now we'll check the registry for this value
	
	BOOL needreboot = FALSE;
	//
	LONG lResult;
	HKEY hkey = NULL;

	// Part #1 Pendingrenamefiles

	lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
							_T("SYSTEM\\CurrentControlSet\\Control\\Session Manager"),      // name of subkey to open
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
		// is "PendingFileRenameOperations" is Exsists

		DWORD dwBufLen = LENGTH(szVersion);

//		RegQueryMultipleValues
		//lResult = RegQueryValueEx( hkey,
		//						"PendingFileRenameOperations",
		//						NULL,
		//						NULL,
		//						(LPBYTE)szVersion,
		//						&dwBufLen);
	    CString sValue;

		while ( (lResult = RegQueryValueEx( hkey, 
			                               _T("PendingFileRenameOperations"),
			                               NULL, 
										   NULL, 
										   (PBYTE) sValue.GetBuffer(dwBufLen - 1), 
										   &dwBufLen)
										   ) == ERROR_MORE_DATA)
       sValue.ReleaseBuffer(0);
		
   // if (lResult == ERROR_SUCCESS)
   // {
     //   sValue.ReleaseBuffer(dwSize -1);
        //return TRUE; 
    //}
    //sValue.ReleaseBuffer(0);


		// if we receive an error other than 0x2, throw
		if (ERROR_SUCCESS == lResult)
		{
			needreboot = TRUE;
		}
		else if (ERROR_FILE_NOT_FOUND != lResult)
		{
			needreboot = FALSE;
		}

		RegCloseKey(hkey);
	}


	// Part 2 runones

	BOOL needreboot2 = FALSE;

	TCHAR    achKey[MAX_KEY_LENGTH];   // buffer for subkey name
    DWORD    cbName;                   // size of name string 
    TCHAR    achClass[MAX_PATH] = TEXT("");  // buffer for class name 
    DWORD    cchClassName = MAX_PATH;  // size of class string 
    DWORD    cSubKeys=0;               // number of subkeys 
    DWORD    cbMaxSubKey;              // longest subkey size 
    DWORD    cchMaxClass;              // longest class string 
    DWORD    cValues;              // number of values for key 
    DWORD    cchMaxValue;          // longest value name 
    DWORD    cbMaxValueData;       // longest value data 
    DWORD    cbSecurityDescriptor; // size of security descriptor 
    FILETIME ftLastWriteTime;      // last write time 
 
    DWORD i, retCode; 
 
    TCHAR  achValue[MAX_VALUE_NAME]; 
    DWORD cchValue = MAX_VALUE_NAME;


	if (lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
							_T("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce"),      // name of subkey to open
							0,
							KEY_READ,
							&hkey               // handle to open key
							) == ERROR_SUCCESS)
	{
		
		 // Get the class name and the value count. 
    retCode = RegQueryInfoKey(
        hkey,                    // key handle 
        achClass,                // buffer for class name 
        &cchClassName,           // size of class string 
        NULL,                    // reserved 
        &cSubKeys,               // number of subkeys 
        &cbMaxSubKey,            // longest subkey size 
        &cchMaxClass,            // longest class string 
        &cValues,                // number of values for this key 
        &cchMaxValue,            // longest value name 
        &cbMaxValueData,         // longest value data 
        &cbSecurityDescriptor,   // security descriptor 
        &ftLastWriteTime);       // last write time 

		if ((cSubKeys == 0) && (cValues == 0)) needreboot2 = FALSE; else needreboot2 = TRUE;
 

	}   
	else
	{
		needreboot2 = TRUE;
	}

   


	// Part 3 runones

	BOOL needreboot3 = FALSE;
	if (lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
							_T("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnceEx"),      // name of subkey to open
							0,
							KEY_READ,
							&hkey               // handle to open key
							) == ERROR_SUCCESS)
	{
		
		 // Get the class name and the value count. 
    retCode = RegQueryInfoKey(
        hkey,                    // key handle 
        achClass,                // buffer for class name 
        &cchClassName,           // size of class string 
        NULL,                    // reserved 
        &cSubKeys,               // number of subkeys 
        &cbMaxSubKey,            // longest subkey size 
        &cchMaxClass,            // longest class string 
        &cValues,                // number of values for this key 
        &cchMaxValue,            // longest value name 
        &cbMaxValueData,         // longest value data 
        &cbSecurityDescriptor,   // security descriptor 
        &ftLastWriteTime);       // last write time 

		if ((cSubKeys == 0) && (cValues == 0)) needreboot3 = FALSE; else needreboot3 = TRUE;
 

	}   
	else
	{
		needreboot3 = TRUE;
	}

	BOOL FinalNeedReboot = FALSE;
	if ((needreboot == TRUE) ||(needreboot2 == TRUE) ||(needreboot3 == TRUE)) FinalNeedReboot = TRUE;

	
return FinalNeedReboot;

}
// RUN
// ========================================================================================================

// ExecCmd()
//
// Purpose:
//  Executes command-line
// Inputs:
//  LPCTSTR pszCmd: command to run
// Outputs:
//  DWORD dwExitCode: exit code from the command
// Notes: This routine does a CreateProcess on the input cmd-line
//        and waits for the launched process to exit.
// ==========================================================================
DWORD ExecCmd( LPCTSTR pszCmd )
{
    BOOL  bReturnVal   = false ;
    STARTUPINFO  si ;
    DWORD  dwExitCode ;
    SECURITY_ATTRIBUTES saProcess, saThread ;
    PROCESS_INFORMATION process_info ;

    ZeroMemory(&si, sizeof(si)) ;
    si.cb = sizeof(si) ;

    saProcess.nLength = sizeof(saProcess) ;
    saProcess.lpSecurityDescriptor = NULL ;
    saProcess.bInheritHandle = TRUE ;

    saThread.nLength = sizeof(saThread) ;
    saThread.lpSecurityDescriptor = NULL ;
    saThread.bInheritHandle = FALSE ;


    bReturnVal = CreateProcess(NULL, 
                               (LPTSTR)pszCmd, 
                               &saProcess, 
                               &saThread, 
                               FALSE, 
                               DETACHED_PROCESS, 
                               NULL, 
                               NULL, 
                               &si, 
                               &process_info) ;

    if (bReturnVal)
    {
        CloseHandle( process_info.hThread ) ;
        WaitForSingleObject( process_info.hProcess, INFINITE ) ;
        GetExitCodeProcess( process_info.hProcess, &dwExitCode ) ;
        CloseHandle( process_info.hProcess ) ;
    }
    else
    {
                
	//	CError se( IDS_CREATE_PROCESS_FAILURE, 
      //             0, 
        //           MB_ICONERROR, 
          //         COR_EXIT_FAILURE, 
            //       pszCmd );

       // throw( se );
    }

    return dwExitCode;
}


DWORD ExecCmd2( LPCTSTR pszCmd )
{
    MSG msg;
	BOOL  bReturnVal   = false ;
    STARTUPINFO  si ;
    DWORD  dwExitCode ;
    SECURITY_ATTRIBUTES saProcess, saThread ;
    PROCESS_INFORMATION process_info ;

    ZeroMemory(&si, sizeof(si)) ;
    si.cb = sizeof(si) ;

    saProcess.nLength = sizeof(saProcess) ;
    saProcess.lpSecurityDescriptor = NULL ;
    saProcess.bInheritHandle = TRUE ;



    saThread.nLength = sizeof(saThread) ;
    saThread.lpSecurityDescriptor = NULL ;
    saThread.bInheritHandle = FALSE ;


    bReturnVal = CreateProcess(NULL, 
                               (LPTSTR)pszCmd, 
                               &saProcess, 
                               &saThread, 
                               FALSE, 
                               DETACHED_PROCESS, 
                               NULL, 
                               NULL, 
                               &si, 
                               &process_info) ;

    if (bReturnVal)
    {
        CloseHandle( process_info.hThread ) ;
        //WaitForSingleObject( process_info.hProcess, INFINITE ) ;
		
		while(1)
		{
			while (PeekMessage(&msg,NULL,0,0,PM_REMOVE))
			{
				TranslateMessage(&msg);
				if (msg.message == WM_QUIT) return 1;
				DispatchMessage(&msg);
			}
			
			if (MsgWaitForMultipleObjects(1,&process_info.hProcess,FALSE,1000,QS_ALLINPUT)==WAIT_OBJECT_0) break;
		}
		
		GetExitCodeProcess( process_info.hProcess, &dwExitCode ) ;
		CloseHandle( process_info.hProcess ) ;
    }
    else
    {
                
	//	CError se( IDS_CREATE_PROCESS_FAILURE, 
      //             0, 
        //           MB_ICONERROR, 
          //         COR_EXIT_FAILURE, 
            //       pszCmd );

       // throw( se );
    }

    return dwExitCode;
}




DWORD GeneralRun::runExe(LPCTSTR pszCmd)
{
    // show 'setup is working...' msg
//    ShowBillboard(&g_dwThread, &g_hThread);

    // execute dotnetfx.exe setup
    DWORD dwResult = ExecCmd(pszCmd);
    
    // take down billboard
//    TeardownBillboard(g_dwThread, g_hThread);
	return dwResult;
}


// Call in you are running in OSNormal Mode
typedef BOOL (WINAPI *LPFN_ISWOW64PROCESS) (HANDLE, PBOOL);

LPFN_ISWOW64PROCESS fnIsWow64Process;

BOOL IsWow64()
{
    BOOL bIsWow64 = FALSE;

    fnIsWow64Process = (LPFN_ISWOW64PROCESS)GetProcAddress(
        GetModuleHandle(TEXT("kernel32")),"IsWow64Process");
  
    if (NULL != fnIsWow64Process)
    {
        if (!fnIsWow64Process(GetCurrentProcess(),&bIsWow64))
        {
            // handle error
        }
    }
    return bIsWow64;
}
