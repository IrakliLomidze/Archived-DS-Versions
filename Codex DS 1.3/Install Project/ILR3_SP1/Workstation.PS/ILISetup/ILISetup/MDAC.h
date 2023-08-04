#pragma once


class ILI_MDAC
{
public:
	TCHAR* CurrentVersion;
	ILI_MDAC(void);
	bool ILI_checkMDAC();
	DWORD InstallMDAC();
    ~ILI_MDAC(void);
};

