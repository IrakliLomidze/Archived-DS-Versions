
// CodexSetupRunner.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "CodexSetupRunner.h"
#include "CodexSetupRunnerDlg.h"
#include "ILC\GeneralRun.h"
#include <VersionHelpers.h>
#include "ILC\detectFX.h"
#include <windows.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CCodexSetupRunnerApp

BEGIN_MESSAGE_MAP(CCodexSetupRunnerApp, CWinApp)
	ON_COMMAND(ID_HELP, &CWinApp::OnHelp)
END_MESSAGE_MAP()


// CCodexSetupRunnerApp construction

CCodexSetupRunnerApp::CCodexSetupRunnerApp()
{
	// support Restart Manager
	m_dwRestartManagerSupportFlags = AFX_RESTART_MANAGER_SUPPORT_RESTART;

	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CCodexSetupRunnerApp object

CCodexSetupRunnerApp theApp;

// CCodexSetupRunnerApp initialization

bool IsWindows10_1909OrGreater()
{
	if (!IsWindows10OrGreater())
	{
		return false;
	}
	//DWORD dwVersion = 0;
	//DWORD dwMajorVersion = 0;
	//DWORD dwMinorVersion = 0;
	//DWORD dwBuild = 0;
	//dwVersion = GetVersion();

	//dwMajorVersion = (DWORD)(LOBYTE(LOWORD(dwVersion)));
	//dwMinorVersion = (DWORD)(HIBYTE(LOWORD(dwVersion)));

	//// Get the build number.

	//if (dwVersion < 0x80000000)
	//	dwBuild = (DWORD)(HIWORD(dwVersion));

	//if (dwBuild < NTDDI_WIN10_19H1) return false;
	return true;

}


BOOL CCodexSetupRunnerApp::InitInstance()
{
	// InitCommonControlsEx() is required on Windows XP if an application
	// manifest specifies use of ComCtl32.dll version 6 or later to enable
	// visual styles.  Otherwise, any window creation will fail.
	INITCOMMONCONTROLSEX InitCtrls;
	InitCtrls.dwSize = sizeof(InitCtrls);
	// Set this to include all the common control classes you want to use
	// in your application.
	InitCtrls.dwICC = ICC_WIN95_CLASSES;
	InitCommonControlsEx(&InitCtrls);

	CWinApp::InitInstance();


	AfxEnableControlContainer();

	int dwRet = GetCurrentDirectory(MAX_PATH, this->CurrentPathStr);
	int dwRet2 = GetSystemDirectory(this->SystemPathStr, MAX_PATH);

	// Create the shell manager, in case the dialog contains
	// any shell tree view or shell list view controls.
	CShellManager *pShellManager = new CShellManager;

	// Activate "Windows Native" visual manager for enabling themes in MFC controls
	CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerWindows));

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	// of your final executable, you should remove from the following
	// the specific initialization routines you do not need
	// Change the registry key under which our settings are stored
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization
	//SetRegistryKey(_T("Local AppWizard-Generated Applications"));

	GeneralRun *r = new GeneralRun();
	//BOOL isnr = r->NeedReboot();

	
//	GeneralRun *r = new GeneralRun();
	if (r->IsCurrentUserLocalAdministrator() == FALSE)
	{
		MessageBox(0,_T("To install Codex DS 1.7 Application you must be log as an Administrator"), _T("Codex DS 1.7 Installer"), MB_OK | MB_ICONINFORMATION);
		// Exit procudure copy from bottom
		// Delete the shell manager created above.
		if (pShellManager != NULL)
		{
			delete pShellManager;
		}

		// Since the dialog has been closed, return FALSE so that we exit the
		//  application, rather than start the application's message pump.
		return FALSE;
	}

	
	if (IsWindowsThresholdOrGreater() != 0)
    {
		MessageBox(NULL, _T("To Install Codex DS 1.7, You need at least Windows 10 1909"), _T("Windows Version Not Supported"), MB_ICONERROR | MB_OK);
		// Delete the shell manager created above.
		if (pShellManager != NULL)
		{
			delete pShellManager;
		}

		// Since the dialog has been closed, return FALSE so that we exit the
		//  application, rather than start the application's message pump.
		return FALSE;
	}

	
	ILI_DOTNETFX *ili9 = new ILI_DOTNETFX();

	if (ili9->IsNetfx48Installed() == false)
	{
		if (MessageBox(NULL, _T("To run Codex DS setup you should have at least .NET Framework 4.8 in your computer\n Do you want to install .net framework"), _T(" Warning "), MB_ICONWARNING | MB_YESNO | MB_DEFBUTTON2) == IDNO )
		{
			#pragma region Deny_Install_NET_Framewokr
			// Exit from App
			// Delete the shell manager created above.
			if (pShellManager != NULL)
			{
				delete pShellManager;
			}

			// Since the dialog has been closed, return FALSE so that we exit the
			//  application, rather than start the application's message pump.
			return FALSE;
			#pragma endregion Deny_Install_NET_Framewokr
		}
		else
			// Run .NET Framework 4 Instllation
		{

			//MessageBox(NULL, _T("111"), _T("2222"), 0);
		    //Nndp48-x86-x64-allos-enu.exe 
			#pragma region Install_NET_Framewokr
			CString runcommand = theApp.CurrentPathStr;
			runcommand.Append(_T("\\Packages\\netframework\\ndp48-x86-x64-allos-enu.exe"));
			runcommand.Append(_T(" /qb "));
			runcommand.Append(_T(" /promptrestart "));

			DWORD d = ExecCmd2(runcommand);


#pragma region responce
			//if (d == 0) netsetupstatus = 0; else netsetupstatus = 1;
			if (d != 0)
			{
				if (d == ERROR_SUCCESS_REBOOT_REQUIRED) { MessageBox(NULL, _T(" .Net Installation Completed \n Reboot Requred \n Please Reboot The System"), _T("Quesiton"), MB_ICONWARNING | MB_OK); }
				else MessageBox(NULL, _T(".NET Installation Failed Please See Log File"), _T("Quesiton"), MB_ICONWARNING | MB_OK);
				
				// Delete the shell manager created above.
				if (pShellManager != NULL)
				{
					delete pShellManager;
				}

				return FALSE;
			}
#pragma endregion responce
			#pragma endregion Install_NET_Framewokr
		}


		
	}


	// Run Codex Installer
	CString runcommand = theApp.CurrentPathStr;
	runcommand.Append(_T("\\Install\\CodexDSInstaller.exe"));
	//if (MessageBox(NULL, runcommand, _T(" Warning "), MB_ICONWARNING | MB_YESNO | MB_DEFBUTTON2))

	CString WorkingDirectory = theApp.CurrentPathStr;
	WorkingDirectory.Append(_T("\\Install\\"));
	int nRet = (int)ShellExecute(NULL, _T("open"), runcommand, NULL, WorkingDirectory, SW_SHOWNORMAL);
	//	DWORD d = ExecCmd2(runcommand);
	
	if (nRet <= 32) {
		DWORD dw = GetLastError();
/*
		char szMsg[250];
		FormatMessage(
			FORMAT_MESSAGE_FROM_SYSTEM,
			0, dw, 0,
			szMsg, sizeof(szMsg),
			NULL
			);*/
		MessageBox(0, _T("Error launching Codex DS 1.7 Installer"), _T("Codex.net DS 1.7 Installer"), MB_OK | MB_ICONINFORMATION);

		
	}


	//CCodexSetupRunnerDlg dlg;
	//m_pMainWnd = &dlg;
	//INT_PTR nResponse = dlg.DoModal();
	//if (nResponse == IDOK)
	//{
	//	// TODO: Place code here to handle when the dialog is
	//	//  dismissed with OK
	//}
	//else if (nResponse == IDCANCEL)
	//{
	//	// TODO: Place code here to handle when the dialog is
	//	//  dismissed with Cancel
	//}
	//else if (nResponse == -1)
	//{
	//	TRACE(traceAppMsg, 0, "Warning: dialog creation failed, so application is terminating unexpectedly.\n");
	//	TRACE(traceAppMsg, 0, "Warning: if you are using MFC controls on the dialog, you cannot #define _AFX_NO_MFC_CONTROLS_IN_DIALOGS.\n");
	//}

	// Delete the shell manager created above.
	if (pShellManager != NULL)
	{
		delete pShellManager;
	}

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}

