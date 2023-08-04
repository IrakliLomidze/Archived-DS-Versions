#pragma once

class ILI_SQLNative
{
public:
	CString CurrentVersion;

	ILI_SQLNative(void);
	bool ILI_checkMSI();
	~ILI_SQLNative(void);
};
