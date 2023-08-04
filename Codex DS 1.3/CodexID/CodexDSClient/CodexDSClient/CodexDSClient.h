// CodexDSClient.h : main header file for the CodexDSClient DLL
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CCodexDSClientApp
// See CodexDSClient.cpp for the implementation of this class
//

class CCodexDSClientApp : public CWinApp
{
public:
	CCodexDSClientApp();

// Overrides
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
