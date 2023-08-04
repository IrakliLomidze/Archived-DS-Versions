// CodexDSServer.h : main header file for the CodexDSServer DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CCodexDSServerApp
// See CodexDSServer.cpp for the implementation of this class
//

class CCodexDSServerApp : public CWinApp
{
public:
	CCodexDSServerApp();

// Overrides
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
