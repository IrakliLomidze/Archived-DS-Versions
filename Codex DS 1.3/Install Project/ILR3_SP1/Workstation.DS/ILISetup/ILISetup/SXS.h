#pragma once

class ILI_SXS
{
public:
	TCHAR* CurrentVersion;
	WORD BuildVersion;
	ILI_SXS(void);
	bool ILI_check();
	~ILI_SXS(void);
};
