#pragma once

class GeneralRun
{
public:
	GeneralRun(void);
	~GeneralRun(void);
	BOOL IsCurrentUserLocalAdministrator(void);
	DWORD ExecCmd( LPCTSTR pszCmd );
	BOOL NeedReboot();
	DWORD runExe(LPCTSTR pszCmd);
	//int isOSNormal();

};

DWORD ExecCmd( LPCTSTR pszCmd );
DWORD ExecCmd2( LPCTSTR pszCmd );
int isOSNormal();
int is2003();
BOOL IsWow64();