// ILISetup.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CILISetupApp:
// See ILISetup.cpp for the implementation of this class
//

class CILISetupApp : public CWinApp
{
public:
	CILISetupApp();
	TCHAR CurrentPathStr[MAX_PATH];
    TCHAR SystemPathStr[MAX_PATH];
	int setting_SQLCodex2007UpdateMode;
	int setting_SQLInstanceNameTextBox;
	CString setting_Application;
	int setting_InstallationMode;	
	int setting_Sqlx86onWin64Detection;
// Overrides
	public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CILISetupApp theApp;
