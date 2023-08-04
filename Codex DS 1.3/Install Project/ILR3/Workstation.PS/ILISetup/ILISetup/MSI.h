#pragma once

class ILI_MSI
{
public:
	TCHAR* CurrentVersion;
	ILI_MSI(void);
	bool ILI_checkMSI();
	~ILI_MSI(void);
};
