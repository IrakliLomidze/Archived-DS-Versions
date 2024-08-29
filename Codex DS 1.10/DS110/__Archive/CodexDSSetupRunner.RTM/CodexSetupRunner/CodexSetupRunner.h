
// CodexSetupRunner.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CCodexSetupRunnerApp:
// See CodexSetupRunner.cpp for the implementation of this class
//

class CCodexSetupRunnerApp : public CWinApp
{
public:
	CCodexSetupRunnerApp();
	TCHAR CurrentPathStr[MAX_PATH];
	TCHAR SystemPathStr[MAX_PATH];


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CCodexSetupRunnerApp theApp;