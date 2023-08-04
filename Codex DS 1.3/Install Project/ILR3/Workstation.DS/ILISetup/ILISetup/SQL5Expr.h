#pragma once

class ILI_SQLEXPRESS
{
public:
	ILI_SQLEXPRESS(void);
	int ILI_GetSQLVersion();
	int ILI_checkMSDE();
	int ILI_IsInstanceX64();
	~ILI_SQLEXPRESS(void);
};
