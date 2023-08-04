#pragma once

class ILI_SQLNative
{
public:
	TCHAR* CurrentVersion;
	ILI_SQLNative(void);
	bool ILI_checkMSI();
	~ILI_SQLNative(void);
};
