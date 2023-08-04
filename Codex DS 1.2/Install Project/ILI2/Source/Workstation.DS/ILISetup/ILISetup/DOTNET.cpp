#include "stdafx.h"
#include ".\dotnet.h"

ILI_DOTNET::ILI_DOTNET(void)
{
}

ILI_DOTNET::~ILI_DOTNET(void)
{
}

#define LENGTH(A) (sizeof(A)/sizeof(A[0]))

void ILI_DOTNET::ili_dotnetcheck3()
{
        HRESULT hr;
        // now we'll check the registry for this value
        //
        LONG lResult;
        HKEY hkey = NULL;
		
		framework30 = 0;
		framework30sp1 = 0;	

        
        lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
                                _T("SOFTWARE\\Microsoft\\.NETFramework\\v3.0"),    // name of subkey to open
                                NULL,
                                KEY_READ,
                                &hkey               // handle to open key
                                );


		// we don't proceed unless the call above succeeds
        if  (ERROR_SUCCESS != lResult && ERROR_FILE_NOT_FOUND != lResult)
        {
			framework30 = 0;
			framework30sp1 = 0;
			return;// .NET Framework 3.0 is not found ERROR_FILE_NOT_FOUND;
        }
        
		if (hkey != NULL) RegCloseKey(hkey);
		
        lResult = RegOpenKeyEx( HKEY_LOCAL_MACHINE, // handle to open key
                                _T("Software\\Microsoft\\NET Framework Setup\\NDP\\v3.0"),    // name of subkey to open
                                NULL,
                                KEY_READ,
                                &hkey               // handle to open key
                                );

		if  (ERROR_SUCCESS != lResult && ERROR_FILE_NOT_FOUND != lResult)
        {
          
		  framework30 = 0;
		  framework30sp1 = 0;
	      return;// .NET Framework 3.0 is not found ERROR_FILE_NOT_FOUND;
        }

		if (hkey != NULL) RegCloseKey(hkey);
    
	
        if (ERROR_SUCCESS == lResult)
        {
		  framework30 = 1;
		}

	return;
}



// -=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

