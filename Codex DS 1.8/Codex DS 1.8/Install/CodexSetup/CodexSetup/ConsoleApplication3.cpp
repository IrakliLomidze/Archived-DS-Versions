// ConsoleApplication3.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <windows.h>
#include <VersionHelpers.h>
#include "detectFX.h"
#include "GeneralRun.h"

int main()
{
	TCHAR CurrentPathStr[MAX_PATH];
	TCHAR SystemPathStr[MAX_PATH];


	int dwRet = GetCurrentDirectory(MAX_PATH, CurrentPathStr);
	int dwRet2 = GetSystemDirectory(SystemPathStr, MAX_PATH);


	GeneralRun* r = new GeneralRun();
	

	if (r->IsCurrentUserLocalAdministrator() == FALSE)
	{
		MessageBox(0, L"To install Codex DS 1.8 Application you must be log as an Administrator", L"Codex DS 1.8 Installer", MB_OK | MB_ICONINFORMATION);
		// Exit procudure copy from bottom
		// Delete the shell manager created above.
		// Since the dialog has been closed, return FALSE so that we exit the
		//  application, rather than start the application's message pump.
		return FALSE;
	}


	if (IsWindowsThresholdOrGreater() != 0)
	{
		MessageBox(NULL, L"To Install Codex DS 1.8, You need at least Windows 10 1909", L"Windows Version Not Supported", MB_ICONERROR | MB_OK);
		// Delete the shell manager created above.

		// Since the dialog has been closed, return FALSE so that we exit the
		//  application, rather than start the application's message pump.
		return FALSE;
	}


	ILI_DOTNETFX* ili9 = new ILI_DOTNETFX();

	if (ili9->IsNetfx48Installed() == false)
	{
		if (MessageBox(NULL, L"To run Codex DS setup you should have at least .NET Framework 4.8 in your computer\n Do you want to install .net framework", L" Warning ", MB_ICONWARNING | MB_YESNO | MB_DEFBUTTON2) == IDNO)
		{
			return FALSE;
			
		}
		else
		{
			// Run .NET Framework 4 Instllation

			//MessageBox(NULL, _T("111"), _T("2222"), 0);
			//Nndp48-x86-x64-allos-enu.exe 

			std::wstring runcommand = CurrentPathStr;
			runcommand += L"\\Packages\\netframework\\ndp48-x86-x64-allos-enu.exe";
			runcommand += L" /qb ";
			runcommand += L" /promptrestart ";

			DWORD d = ExecCmd2(runcommand.c_str());



			//if (d == 0) netsetupstatus = 0; else netsetupstatus = 1;
			if (d != 0)
			{
				if (d == ERROR_SUCCESS_REBOOT_REQUIRED) { MessageBox(NULL, L" .Net Installation Completed \n Reboot Requred \n Please Reboot The System", L"Quesiton", MB_ICONWARNING | MB_OK); }
				else MessageBox(NULL, L".NET Installation Failed Please See Log File", L"Quesiton", MB_ICONWARNING | MB_OK);

				return FALSE;
			}
		}
	}


	// Run Codex Installer
	std::wstring runcommand = CurrentPathStr;
	
	
	runcommand.append(L"\\Install\\CodexDSInstaller.exe");
	

	std::wstring WorkingDirectory = runcommand;
	WorkingDirectory.append(L"\\Install\\");

	int nRet = (int)ShellExecute(NULL, L"open", runcommand.c_str(), NULL, WorkingDirectory.c_str(), SW_SHOWNORMAL);
	//	DWORD d = ExecCmd2(runcommand);

	if (nRet <= 32) {
		DWORD dw = GetLastError();
		MessageBox(0, L"Error launching Codex DS 1.8 Installer", L"Codex.net DS 1.8 Installer", MB_OK | MB_ICONINFORMATION);

	}


	
	return TRUE;

}



bool IsWindows10_1909OrGreater()
{
	if (!IsWindows10OrGreater())
	{
		return false;
	}
	return true;

}
