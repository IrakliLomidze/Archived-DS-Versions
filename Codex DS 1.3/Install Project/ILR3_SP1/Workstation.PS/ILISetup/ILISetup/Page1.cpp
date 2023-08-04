// Page1.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "Page1.h"
#include "generalrun.h"
#include "MSI.h"
#include "mdac.h"
#include "dotnet.h"
#include "SQL5Expr.h"
#include "PowerShell.h"
#include "SQLCLI.h"
#include <ctime>


// CPage1 dialog

//IMPLEMENT_DYNAMIC(CPage1, CPropertyPage)
//IMPLEMENT_DYNAMIC(CPage1, CDialog)

CPage1::CPage1()
	: CDialog(CPage1::IDD)
	, m_netfx(FALSE)
	, m_sql2005(FALSE)
	, m_sqlclient(FALSE)
	, VCPP(FALSE)
	, SQL_Native_Client_CheckBox(FALSE)
{
	m_brush = new CBrush(RGB(255, 255, 255));
	this->ButtonFX.SetTextColor(0x00800000);
	SQLInstallMode = 0;
	SQLX64DetectionMode = 0;
}

CPage1::~CPage1()
{
}
CString WaitLabelText;
void CPage1::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STATICWP, BackGround);
	DDX_Control(pDX, IDC_STATICPanelW1, Page1_Panel1);
	DDX_Control(pDX, IDC_STATICCodex2007Pre, Codex2007Pre);
	DDX_Control(pDX, IDC_STATIC_WinVersion, m_winver);
	DDX_Control(pDX, IDC_STATICMSIVER, m_MSIVER);

	DDX_Check(pDX, IDC_CHECK1, m_netfx);
	DDX_Check(pDX, IDC_CHECK2, m_sql2005);
	DDX_Control(pDX, IDC_FONTLABEL, C_FONTLABEL);
	DDX_Control(pDX, IDC_PROGRESS1, m_progress1);
	DDX_Control(pDX, IDC_BUTTON3, BI);
	DDX_Check(pDX, IDC_CHECK3, VCPP);
	DDX_Control(pDX, IDC_COMBO1, SQLCOMBO);
	DDX_Control(pDX, IDC_BUTTON1, ButtonFX);
	DDX_Control(pDX, IDC_STATICMode, l_InstallMode);
	DDX_Check(pDX, IDC_CHECK4, SQL_Native_Client_CheckBox);
}


//BEGIN_MESSAGE_MAP(CPage1, CPropertyPage)
BEGIN_MESSAGE_MAP(CPage1, CDialog)
	ON_WM_CTLCOLOR()
	ON_WM_DESTROY()
	ON_NOTIFY(NM_CUSTOMDRAW, IDC_PROGRESS1, &CPage1::OnNMCustomdrawProgress1)
	ON_BN_CLICKED(IDC_BUTTON3, &CPage1::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON1, &CPage1::OnBnClickedButton1)
	ON_STN_CLICKED(IDC_SQLSTATIC, &CPage1::OnStnClickedSqlstatic)
	ON_STN_CLICKED(IDC_STATIC_SQL_SERVER_INSTALL_SP, &CPage1::OnStnClickedStaticSqlServerInstallSp)
	ON_BN_CLICKED(IDC_STATIC_SQL_SERVER_INSTALL, &CPage1::OnBnClickedStaticSqlServerInstall)
	ON_BN_CLICKED(IDC_STATIC_SQL_SERVER_INSTALL_SP, &CPage1::OnBnClickedStaticSqlServerInstallSp)
END_MESSAGE_MAP()


// CPage1 message handlers

BOOL CPage1::OnInitDialog()
{
	CDialog::OnInitDialog();

	DWORD g_dwThread = 0;
	HANDLE g_hThread = NULL;

	// TODO:  Add extra initialization here
	GetInformationv();
	BI.EnableWindow(TRUE);
	//this->ButtonFX.SetTextColor(0x00800000);

	//SQLCOMBO.SetCurSel(1);
	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}

HBRUSH CPage1::OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor)
{
/*
** No need to do this!
**
** HBRUSH hbr = CDialog::OnCtlColor(pDC, pWnd, nCtlColor);
*/

/*
** Return the white brush.
*/
return (HBRUSH)(m_brush->GetSafeHandle());
}


	void CPage1::OnDestroy()
      {
          CDialog::OnDestroy();

          // Free the space allocated for the background brush
          delete m_brush;
	}
	void CPage1::OnNMCustomdrawProgress1(NMHDR *pNMHDR, LRESULT *pResult)
	{
		LPNMCUSTOMDRAW pNMCD = reinterpret_cast<LPNMCUSTOMDRAW>(pNMHDR);
		// TODO: Add your control notification handler code here
		*pResult = 0;
	}


	void CPage1::GetInformationv(void)
	{
		m_Font.CreateFont(-20, 0, 0, 0, 
		FW_BOLD, FALSE, FALSE, 0, DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, 
		CLIP_DEFAULT_PRECIS, DEFAULT_QUALITY, DEFAULT_PITCH, _T("MS Sans Serif"));

	Codex2007Pre.SetFont(&m_Font, TRUE);
	//m_brush.CreateSolidBrush(RGB(255, 255, 255));
	
	#pragma region Windows Version

	// Initialize Windows Version
	OSVERSIONINFOEX OSversion;
	
	ZeroMemory(&OSversion, sizeof(OSVERSIONINFOEX));

	

	OSversion.dwOSVersionInfoSize=sizeof(OSVERSIONINFOEX);

	GetVersionEx((OSVERSIONINFO *)&OSversion);

	CString versioninfo = _T("Microsoft Windows");
	

	if (OSversion.dwMajorVersion < 5) 	{   MessageBox(_T("Minimal System requirement is Windows XP SP3"));	BI.EnableWindow(FALSE);	 return;  }
    
	if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion == 0)) { MessageBox(_T("Windows 2000 does not Supported By Codex R3 \n Minimal System requirement in Windows XP SP3")); BI.EnableWindow(FALSE); return; }

	if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion == 1) ) 
	{
		if (OSversion.wServicePackMajor < 3) { 	MessageBox(_T("Your XP System Does not have Service Pack 3 \n Minimal System requirement is Windows XP SP3")); return; }
		versioninfo.Append(_T(" XP ")); versioninfo.Append(OSversion.szCSDVersion);	CC_X64 = 0;
	}

	
	if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion == 2)) 
	{
		if (is2003() == 1)
		{
			versioninfo.Append(_T(" Server 2003 "));
			
			//if (GetSystemMetric(SM_SERVERR2) != 0) versioninfo.Append(_T(" R2 "));
			
			//if (OSversion.wSuiteMask == 0x0002) versioninfo.Append(_T("Enteprise "));
			//if (OSversion.wSuiteMask == 0x0080) versioninfo.Append(_T("DataCenter "));
			//if (OSversion.wSuiteMask == 0x0400) versioninfo.Append(_T("Web Edition "));
			//if (OSversion.wSuiteMask == 0x0000) versioninfo.Append(_T("Standard "));

			//if (OSversion.wSuiteMask == 0x0000) versioninfo.Append(_T("Home Server "));



			if (OSversion.wServicePackMajor >= 1)
			{
				if (IsWow64() == TRUE)
				{
					versioninfo.Append(_T("64 Bit Edition "));
					CC_X64 = 1;
				}
				else
				{
					versioninfo.Append(_T("32 Bit Edition "));
					CC_X64 = 0;
				}

			}
		    versioninfo.Append(OSversion.szCSDVersion);
		}
		else
		{	
			versioninfo.Append(_T(" XP 64 Bit "));
		    versioninfo.Append(OSversion.szCSDVersion);
			CC_X64 = 1;
		}
	}


	if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion == 0) && (OSversion.wProductType == VER_NT_WORKSTATION))
	{

		versioninfo.Append(_T(" Vista "));

		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate "));
		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate N "));
		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate "));
        //OSversion.


		if (IsWow64() == TRUE)
		{
			versioninfo.Append(_T("64 Bit Edition "));
			CC_X64 = 1;
		}
		else
		{
			versioninfo.Append(_T("32 Bit Edition "));
			CC_X64 = 0;
		}
		versioninfo.Append(OSversion.szCSDVersion);
	}

	// Windows Server 2008
	if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion == 0) && (OSversion.wProductType != VER_NT_WORKSTATION))
	{

		versioninfo.Append(_T(" Server 2008 "));

		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate "));
		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate N "));
		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate "));
        //OSversion.


		if (IsWow64() == TRUE)
		{
			versioninfo.Append(_T("64 Bit Edition "));
			CC_X64 = 1;
		}
		else
		{
			versioninfo.Append(_T("32 Bit Edition "));
			CC_X64 = 0;
		}

		versioninfo.Append(OSversion.szCSDVersion);
	}

    // Windows 7
	if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion == 1) && (OSversion.wProductType == VER_NT_WORKSTATION))
	{

		versioninfo.Append(_T(" 7 "));

		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate "));
		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate N "));
		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate "));
        //OSversion.


		if (IsWow64() == TRUE)
		{
			versioninfo.Append(_T("64 Bit Edition "));
			CC_X64 = 1;
		}
		else
		{
			versioninfo.Append(_T("32 Bit Edition "));
			CC_X64 = 0;
		}
		versioninfo.Append(OSversion.szCSDVersion);
	}

	// Windows 2008 R2
    if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion == 1) && (OSversion.wProductType != VER_NT_WORKSTATION))
	{

		versioninfo.Append(_T(" 2008 R2 "));

		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate "));
		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate N "));
		//if (OSversion.wProductType  == 1) versioninfo.Append(_T(" Ultimate "));
        //OSversion.


		if (IsWow64() == TRUE)
		{
			versioninfo.Append(_T("64 Bit Edition "));
			CC_X64 = 1;
		}
		else
		{
			versioninfo.Append(_T("32 Bit Edition "));
			CC_X64 = 0;
		}
		versioninfo.Append(OSversion.szCSDVersion);
	}




	this->SetDlgItemText(IDC_STATIC_WinVersion,versioninfo);
	#pragma endregion Windows Version

	#pragma region MSI
    // MSI

		// MSI Version
	ILI_MSI *ili2 = new ILI_MSI();
	if (ili2->ILI_checkMSI() == true)
	{
		//ILI_MSI_Check = true;
		
	}
	else
	{
		//ILI_MSI_Check = false;
	}
	

	CString s2 = _T(" ");
	s2.Append(ili2->CurrentVersion);
	s2.Delete(0,1);
	this->SetDlgItemText(IDC_STATICMSIVER,s2);
	#pragma endregion MSI

	VCPP = true;
    
	
		this->ButtonFX.EnableWindow(FALSE);
		this->ButtonFX.ShowWindow(SW_HIDE);
		this->GetDlgItem(IDC_CHECK1)->EnableWindow(TRUE);

	#pragma region PowerShell
		_PowerShell = 0;
		PowerShell *iliP1= new PowerShell();
		iliP1->ili_PowerShell1();
		if (iliP1->PowerShell1 == 0) { this->SetDlgItemText(IDC_STATICPowerShell,_T("PowerShell Does not Present")); _PowerShell = 0; }
		if (iliP1->PowerShell1 == 1) { this->SetDlgItemText(IDC_STATICPowerShell,_T("Version 1.0 RTM")); _PowerShell = 1; }
		if (iliP1->PowerShell1 == -1) { this->SetDlgItemText(IDC_STATICPowerShell,_T("Version 1.0 RC2 (Reinstall)")); _PowerShell = -1;}
    #pragma endregion PowerShell

	#pragma region Dot NET

		ILI_DOTNET *ili9 = new ILI_DOTNET();
		ili9->ili_dotnetcheck3();
		if ((ili9->framework35 == 1) && (ili9->framework35sp1 == 1))
		{
			 this->SetDlgItemText(IDC_NETFXSTATIC,_T("You already have .net framework 3.5 SP1 Installed"));
			 CC_NETFX = 0;
			 m_netfx = false;
		}
		else
		{
			if ((ili9->framework35 == 1) && (ili9->framework35sp1 == 1))
			{
				this->SetDlgItemText(IDC_NETFXSTATIC,_T(".net 3.5 Installed But SP1 requred"));
			    CC_NETFX = 1;
			    m_netfx = true;
			}

		
            // if Windows 7 or Windows 2008 R2
			if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion >= 1))
			{
				this->ButtonFX.EnableWindow(TRUE);
				this->ButtonFX.ShowWindow(SW_SHOW);
				this->GetDlgItem(IDC_CHECK1)->EnableWindow(FALSE);
				//this->ButtonFX.SetTextColor(0x00800000);
				this->ButtonFX.SetTextColor(0x000000A0);
				CC_NETFX = 0;
				m_netfx = false;
			}
			else
			{
				CC_NETFX = 1;
				m_netfx = true;
			}
						
		
			this->SetDlgItemText(IDC_NETFXSTATIC,_T("You need to install .net framework 3.5 SP1"));
			
		}

		if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion >= 1)) { GetDlgItem(IDC_CHECK1)->EnableWindow(FALSE);}
			else { GetDlgItem(IDC_CHECK1)->EnableWindow(TRUE); }

		#pragma endregion Dot NET


	#pragma region SQL Express

	ILI_SQLEXPRESS *ili12 = new ILI_SQLEXPRESS();
	if (ili12->ILI_checkMSDE() == 1)
	{
		this->SetDlgItemText(IDC_SQLSTATIC,_T("You need to install SQL Server 2008 R2 Express Edition 'Codex2007' Instance"));
		CC_SQL = 1;
		m_sql2005 = true;
		
	}
	else
	{
		this->SetDlgItemText(IDC_SQLSTATIC,_T("SQL Server 2008 R2 Express Edition With Tools 'Codex2007' Instance"));
		CC_SQL = 0;
		m_sql2005 = false;
	}
	
	SQLCOMBO.SetCurSel(1);
	int _Version = ili12->ILI_GetSQLVersion();
	if (_Version == 0)    // No Instance
	   { this->l_InstallMode.SetWindowText(_T("SQL Server New Installation Mode"));
		 this->l_InstallMode.SetTextColor(RGB(21,39,104));
		 this->SetDlgItemText(IDC_SQLSTATIC,_T("You need to install SQL Server 2008 R2 Express Edition 'Codex2007' Instance"));
		 CC_SQL = 1; m_sql2005 = true; 
		 SQLInstallMode = 0;
	   } 

	if ((_Version == 1000) || (_Version == 3000)) // Unknow Version
	   { this->l_InstallMode.SetWindowText(_T("Unknow Version Please Uninstall Codex2007 Instance of SQL Server"));
	     this->SetDlgItemText(IDC_SQLSTATIC,_T("You need to install SQL Server 2008 R2 Express Edition 'Codex2007' Instance"));
		 this->l_InstallMode.SetTextColor(RGB(255,0,0));
	     CC_SQL = 1; m_sql2005 = false; 
		 SQLInstallMode = 0;
	   } 
	
	
	if (_Version == 2005) // SQL 2005
	{      
		   this->l_InstallMode.SetWindowText(_T("Update Mode Existing SQL 2005 to SQL 2008R2"));
	   	   #pragma region if in 64 Bit Widows SQL Server 2005 Codex 2007 Instance installed as X 86
		   if (theApp.setting_Sqlx86onWin64Detection == 1)
		   {
		
				   SQLX64DetectionMode = 0;
				   if (IsWow64() == TRUE)
				   {
					   int RIS64 = ili12->ILI_IsInstanceX64();
					   this->l_InstallMode.SetWindowText(_T("Update Mode Existing SQL 2005 .x64 to SQL 2008R2"));

					   if (RIS64 == 86) 
						   { 
							   this->l_InstallMode.SetWindowText(_T("Update Mode Existing SQL 2005 x86 to SQL 2008R2"));
							   SQLX64DetectionMode = 1;
						   }
   					   if (RIS64 == 64) 
						   { 
							   this->l_InstallMode.SetWindowText(_T("Update Mode Existing SQL 2005 x64 to SQL 2008R2"));
							   SQLX64DetectionMode = 0;
						   }
				   }
		   }
		   #pragma endregion if in 64 Bit Widows SQL Server 2005 Codex 2007 Instance installed as X 86
	
		   this->l_InstallMode.SetTextColor(RGB(21,39,104));
		   this->SetDlgItemText(IDC_SQLSTATIC,_T("You need to install SQL Server 2008 R2 Express Edition 'Codex2007' Instance"));
	       CC_SQL = 1; m_sql2005 = true; 
		   SQLInstallMode = 1;
	     } 

	if (_Version == 2008) // SQL 2008
	     { this->l_InstallMode.SetWindowText(_T("Update Mode Existing SQL 2008 to SQL 2008R2"));
		  this->l_InstallMode.SetTextColor(RGB(21,39,104));
		   this->SetDlgItemText(IDC_SQLSTATIC,_T("You need to install SQL Server 2008 R2 Express Edition 'Codex2007' Instance"));
	       CC_SQL = 1; m_sql2005 = true; 
		   SQLInstallMode = 1;
	     } 

	
	if (_Version == 2010) // SQL 2008R2
	      { this->l_InstallMode.SetWindowText(_T("You Do not Neew Install SQL Server, Your Version is SQL 2008R2"));
			this->l_InstallMode.SetTextColor(RGB(21,39,104));
			this->SetDlgItemText(IDC_SQLSTATIC,_T("You do not need to install SQL Server 2008 R2 Express Edition 'Codex2007' Instance"));
			CC_SQL = 1; m_sql2005 = false; } 
	
	#pragma endregion SQL Express
	SQLCOMBO.SetCurSel(1);
	
	#pragma region SQL Native Client
	ILI_SQLNative *ili120 = new ILI_SQLNative();
	SQL_Native_Client_CheckBox = false;
	if (ili120->ILI_checkMSI() == true)
	{
		this->SetDlgItemText(IDC_STATICSQLCLI,_T("Not installed"));
		CC_Client = 1;
		m_sqlclient = true;
		SQL_Native_Client_CheckBox = m_sqlclient;
	}
	else
	{
		CString V = _T("Version ");
		V.Append(ili120->CurrentVersion);
		this->SetDlgItemText(IDC_STATICSQLCLI,V);
		CC_Client = 0;
		m_sqlclient = false;
		SQL_Native_Client_CheckBox = m_sqlclient;
	}

	#pragma endregion SQL Native Client
	
   
	switch (theApp.setting_InstallationMode)
	{
	case 0x0100 : {  //Client Mode
					this->GetDlgItem(IDC_CHECK2)->EnableWindow(FALSE);
					this->GetDlgItem(IDC_COMBO1)->EnableWindow(FALSE);
					this->GetDlgItem(IDC_SQLSTATIC)->ShowWindow(FALSE);
					this->GetDlgItem(IDC_STATICMode)->ShowWindow(FALSE);
					this->m_sql2005 = false;
					this->GetDlgItem(IDC_STATIC_SQL_SERVER_INSTALL)->ShowWindow(FALSE);
					this->GetDlgItem(IDC_STATIC_SQL_SERVER_INSTALL_SP)->ShowWindow(FALSE);

				  } break;
	case 0x0000 : {  //Worksation Mode
					this->GetDlgItem(IDC_CHECK4)->EnableWindow(FALSE);
					this->m_sqlclient = false;
					SQL_Native_Client_CheckBox =  false;
					this->GetDlgItem(IDC_STATIC_SQL_SERVER_INSTALL)->ShowWindow(FALSE);
					this->GetDlgItem(IDC_STATIC_SQL_SERVER_INSTALL_SP)->ShowWindow(FALSE);
				  } break;
	case 0x0010 : { //Server Mode
					this->GetDlgItem(IDC_CHECK4)->EnableWindow(FALSE);
					this->GetDlgItem(IDC_CHECK2)->EnableWindow(FALSE);
					this->GetDlgItem(IDC_COMBO1)->EnableWindow(FALSE);
					this->GetDlgItem(IDC_SQLSTATIC)->ShowWindow(FALSE);
					//this->GetDlgItem(IDC_STATICMode)->ShowWindow(FALSE);
					this->GetDlgItem(IDC_NETFXSTATIC)->ShowWindow(FALSE);
					this->GetDlgItem(IDC_STATIC_SQL_SERVER_INSTALL)->ShowWindow(TRUE);
					this->GetDlgItem(IDC_STATIC_SQL_SERVER_INSTALL_SP)->ShowWindow(TRUE);
					this->GetDlgItem(IDC_BUTTON3)->EnableWindow(FALSE);
					this->m_sql2005 = false;
					this->m_sqlclient = false;
					SQL_Native_Client_CheckBox =  false;
				  } break;
	

		case 0x0001 : { //Internal Mode = Worsktatioin Mode
					this->GetDlgItem(IDC_CHECK4)->EnableWindow(FALSE);
					this->m_sqlclient = false;
					SQL_Native_Client_CheckBox =  false;
					this->GetDlgItem(IDC_STATIC_SQL_SERVER_INSTALL)->ShowWindow(FALSE);
					this->GetDlgItem(IDC_STATIC_SQL_SERVER_INSTALL_SP)->ShowWindow(FALSE);
				  } break;
			}
	
	UpdateData(FALSE);

	}



bool DeleteDirectory(LPCTSTR lpszDir, bool noRecycleBin = true)
{
  int len = _tcslen(lpszDir);
  TCHAR *pszFrom = new TCHAR[len+2];
  _tcscpy(pszFrom, lpszDir);
  pszFrom[len] = 0;
  pszFrom[len+1] = 0;
  
  SHFILEOPSTRUCT fileop;
  fileop.hwnd   = NULL;    // no status display
  fileop.wFunc  = FO_DELETE;  // delete operation
  fileop.pFrom  = pszFrom;  // source file name as double null terminated string
  fileop.pTo    = NULL;    // no destination needed
  fileop.fFlags = FOF_NOCONFIRMATION|FOF_SILENT;  // do not prompt the user
  
  if(!noRecycleBin)
    fileop.fFlags |= FOF_ALLOWUNDO;

  fileop.fAnyOperationsAborted = FALSE;
  fileop.lpszProgressTitle     = NULL;
  fileop.hNameMappings         = NULL;

  int ret = SHFileOperation(&fileop);
  delete [] pszFrom;  
  return (ret == 0);
}

	void CPage1::OnBnClickedButton3()
	{	
		// Installation Process
		
		// Install Framework 3.5sp1
   
		

	UpdateData(TRUE);
	m_progress1.SetRange(0,6);
	BI.EnableWindow(FALSE);	
	


	
    #pragma region Install .NET 

	if (m_netfx == true)
	{
		WaitLabelText = _T("Installing .NET Framework 3.5 SP1 , this procedure will take a several time ...");
		
		ShowBillboard(&g_dwThread, &g_hThread);
		int netsetupstatus = 0;
		CString runcommand = theApp.CurrentPathStr;
		runcommand.Append(_T("\\wcu\\dotNetFX\\dotnetfx35.exe"));
		//else runcommand.Append(_T("\\wcu\\dotNetFramework\\dotNetFX30\\X64\\DotNetFX3_x64.exe"));
		OSVERSIONINFOEX OSversion;
		ZeroMemory(&OSversion, sizeof(OSVERSIONINFOEX));
		OSversion.dwOSVersionInfoSize=sizeof(OSVERSIONINFOEX);
		GetVersionEx((OSVERSIONINFO *)&OSversion);
		runcommand.Append(_T(" /qb "));

		if (OSversion.dwMajorVersion > 5) 
		{
		   runcommand.Append(_T(" /promptrestart "));
		}
	
	

		DWORD d = ExecCmd2(runcommand);
		
		if (d == 0) netsetupstatus = 0; else netsetupstatus = 1;
		TeardownBillboard(g_dwThread, g_hThread);
		if (d != 0) 
			{
	              if ( d == ERROR_SUCCESS_REBOOT_REQUIRED ) { MessageBox(_T(" .Net Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
				  MessageBox(_T(".NET Installation Failed Please See Log File"));
				  m_progress1.SetPos(6);
				  MessageBox(_T("Installation Unsuccessful!"));
				  return;
			}

		if (d == 0) 
		{
			// Install HotFixes
			OSVERSIONINFOEX OSversion;
			ZeroMemory(&OSversion, sizeof(OSVERSIONINFOEX));
			OSversion.dwOSVersionInfoSize=sizeof(OSVERSIONINFOEX);
			GetVersionEx((OSVERSIONINFO *)&OSversion);
	
			#pragma region HotFix1 KB959209 
		
			#pragma region Windows Server 2003; Windows XP

			if (OSversion.dwMajorVersion == 5) 
			{
					int F_RequestReboot = 0;
					#pragma region HotFix1 NDP20SP2-KB958481
					// -----------------------------------------------------------------------------------
					if (IsWow64() == TRUE )  WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (NDP20SP2-KB958481-x64.exe) ...");
					else WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (NDP20SP2-KB958481-x86.exe) ...");

					ShowBillboard(&g_dwThread, &g_hThread);
					

					CString runcommand = theApp.CurrentPathStr;
				    if (IsWow64() == TRUE ) runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\NDP20SP2-KB958481-x64.exe"));
					else runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\NDP20SP2-KB958481-x86.exe"));
					
					runcommand.Append(_T(" /q /norestart "));
					DWORD d = ExecCmd2(runcommand);

					TeardownBillboard(g_dwThread, g_hThread);
					if (d == -2147021886 ) F_RequestReboot = 1;
					if ((d != 0) && (d != -2147021886 )) 
						{
							if ( d == ERROR_SUCCESS_REBOOT_REQUIRED ) { MessageBox(_T(" KB958481 Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
							
							TCHAR *item = new TCHAR[200];
							_stprintf(item, _T("Installation Hot Fix KB958481 Failed with Code %d"), d);
							MessageBox(item);

							//MessageBox(_T("Installation Hot Fix KB958481 Failed"));
							m_progress1.SetPos(6);
							MessageBox(_T("Installation Unsuccessful!"));
							return;
						}
					#pragma endregion HotFix1 NDP20SP2-KB958481
					#pragma region HotFix1 NDP30SP2-KB958483
					// ------------------------------------------------------------------------------
					if (IsWow64() == TRUE )  WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (NDP30SP2-KB958483-x64.exe) ...");
					else WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (NDP30SP2-KB958483-x86.exe) ...");

					ShowBillboard(&g_dwThread, &g_hThread);
					
					runcommand = theApp.CurrentPathStr;
				    if (IsWow64() == TRUE ) runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\NDP30SP2-KB958483-x64.exe"));
					else runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\NDP30SP2-KB958483-x86.exe"));
					runcommand.Append(_T(" /q /norestart "));
					d = ExecCmd2(runcommand);

					TeardownBillboard(g_dwThread, g_hThread);
					if (d == -2147021886 ) F_RequestReboot = 1;
					if ((d != 0) && (d != -2147021886 )) 
						{
							if ( d == ERROR_SUCCESS_REBOOT_REQUIRED ) { MessageBox(_T(" KB958483 Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
							MessageBox(_T("Installation Hot Fix KB958483 Failed"));
							m_progress1.SetPos(6);
							MessageBox(_T("Installation Unsuccessful!"));
							return;
						}

					#pragma endregion HotFix1 NDP30SP2-KB958484
					#pragma region HotFix1 NDP35SP1-KB958484
					// ----------------------------------------------------------------------------
					if (IsWow64() == TRUE )  WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (NDP35SP1-KB958484-x64.exe) ...");
					else WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (NDP35SP1-KB958484-x86.exe) ...");

					ShowBillboard(&g_dwThread, &g_hThread);
					
					runcommand = theApp.CurrentPathStr;
				    if (IsWow64() == TRUE ) runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\NDP35SP1-KB958484-x64.exe"));
					else runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\NDP35SP1-KB958484-x86.exe"));
					runcommand.Append(_T(" /q /norestart "));
					d = ExecCmd2(runcommand);

					TeardownBillboard(g_dwThread, g_hThread);
					if (d == -2147021886 ) F_RequestReboot = 1;
					if (d != 0) 
						{
							if ( d == ERROR_SUCCESS_REBOOT_REQUIRED ) { MessageBox(_T(" KB958484 Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
							MessageBox(_T("Installation Hot Fix KB958484 Failed"));
							m_progress1.SetPos(6);
							MessageBox(_T("Installation Unsuccessful!"));
							return;
						}

				   #pragma endregion HotFix1 NDP35SP1-KB958484

					if (F_RequestReboot = 1)
					{
						m_progress1.SetPos(6);
						MessageBox(_T(" You Should Reboot Your Completed"));
						return;
					}
			}

			#pragma endregion HotFix1 KB959209 

			#pragma region Vista and for Windows Server 2008

			if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion == 0) )
			{


					#pragma region HotFix1 Windows6.0-KB958481
					// -----------------------------------------------------------------------------------
					if (IsWow64() == TRUE )  WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (Windows6.0-KB958481-x64.msu) ...");
					else WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (Windows6.0-KB958481-x86.msu) ...");

					ShowBillboard(&g_dwThread, &g_hThread);
					
					// Define Temp Dir
					CString TemDirPrefix = _T("D3A81ECBAAC541D28A4B37A04F98D7C0");
					DWORD lt = GetTickCount();
					CString s2;
					s2.Format(_T("%i"),lt);
					CString TempDir = theApp.SystemPathStr;
					TempDir = TempDir.Left(1) + _T(":\\") + TemDirPrefix+s2;
					DWORD d2;
					// Create if Not Exists
					if (PathIsDirectory(TempDir) != FILE_ATTRIBUTE_DIRECTORY) 
					{
						// Create Dir
						CreateDirectory(TempDir,NULL);
						
						// Temporary Code
						CString runcommand = theApp.CurrentPathStr;

						if (IsWow64() == TRUE) 	runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\Windows6.0-KB958481-x64.msu"));
						else runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\Windows6.0-KB958481-x86.msu"));

						CString CopyTo = TempDir;
						if (IsWow64() == TRUE) 	CopyTo.Append(_T("\\Windows6.0-KB958481-x64.msu"));
						else CopyTo.Append(_T("\\Windows6.0-KB958481-x86.msu"));
						
						CopyFile(runcommand,CopyTo,FALSE);
						runcommand = _T("wusa \"") + CopyTo +_T("\" /quiet");
					
						d2 = ExecCmd2(runcommand);
						DeleteDirectory(TempDir,false);
					}

					int WU_S_ALREADY_INSTALLED = 0x240006;
					int WU_E_NOT_APPLICABLE = 0x80240017; 
					TeardownBillboard(g_dwThread, g_hThread);
					if ((d2 == 0) || ( d2 == 1) || (d2 == WU_S_ALREADY_INSTALLED )  || (d2 == WU_E_NOT_APPLICABLE )) {}
					else
						{
							int WU_S_REBOOT_REQUIRED = 0x240005;
							int WU_E_SETUP_REBOOTREQUIRED = 0x8024D00E;
							if (( d2 == WU_S_REBOOT_REQUIRED ) || ( d2 == WU_E_SETUP_REBOOTREQUIRED )) { MessageBox(_T(" KB958481 Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
							TCHAR *item = new TCHAR[100];
							_stprintf(item, _T("Installation Hot Fix KB958481 Failed with Code %d"), d2);
							MessageBox(item);
							m_progress1.SetPos(6);
							MessageBox(_T("Installation Unsuccessful!"));
							return;
						}

					#pragma endregion HotFix1 Windows6.0-KB958481

					#pragma region HotFix1 Windows6.0-KB958483
					// ------------------------------------------------------------------------------
					if (IsWow64() == TRUE )  WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (Windows6.0-KB958483-x64.msu) ...");
					else WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (Windows6.0-KB958483-x86.msu) ...");

					ShowBillboard(&g_dwThread, &g_hThread);
					
					// Define Temp Dir
					TemDirPrefix = _T("D3A81ECBAAC541D28A4B37A04F98D7C0");
					lt = GetTickCount();
					CString s3;
					s3.Format(_T("%i"),lt);
					TempDir = theApp.SystemPathStr;
					TempDir = TempDir.Left(1) + _T(":\\") + TemDirPrefix+s3;
					d2=0;
					// Create if Not Exists
					if (PathIsDirectory(TempDir) != FILE_ATTRIBUTE_DIRECTORY) 
					{
						// Create Dir
						CreateDirectory(TempDir,NULL);
						
						// Temporary Code
						CString runcommand = theApp.CurrentPathStr;

						if (IsWow64() == TRUE) 	runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\Windows6.0-KB958483-x64.msu"));
						else runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\Windows6.0-KB958483-x86.msu"));

						CString CopyTo = TempDir;
						if (IsWow64() == TRUE) 	CopyTo.Append(_T("\\Windows6.0-KB958483-x64.msu"));
						else CopyTo.Append(_T("\\Windows6.0-KB958483-x86.msu"));
						
						CopyFile(runcommand,CopyTo,FALSE);
						runcommand = _T("wusa \"") + CopyTo +_T("\" /quiet");
					
						d2 = ExecCmd2(runcommand);
						DeleteDirectory(TempDir,false);
					}

					WU_S_ALREADY_INSTALLED = 0x240006;
					WU_E_NOT_APPLICABLE = 0x80240017; 
					TeardownBillboard(g_dwThread, g_hThread);
					if ((d2 == 0) || ( d2 == 1) || (d2 == WU_S_ALREADY_INSTALLED )  || (d2 == WU_E_NOT_APPLICABLE )) {}
					else
						{
							int WU_S_REBOOT_REQUIRED = 0x240005;
							int WU_E_SETUP_REBOOTREQUIRED = 0x8024D00E;
							if (( d2 == WU_S_REBOOT_REQUIRED ) || ( d2 == WU_E_SETUP_REBOOTREQUIRED )) { MessageBox(_T(" KB958481 Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
							
							TCHAR *item = new TCHAR[100];
							_stprintf(item, _T("Installation Hot Fix KB958483 Failed with Code %d"), d2);
							MessageBox(item);
							m_progress1.SetPos(6);
							MessageBox(_T("Installation Unsuccessful!"));
							return;
						}
					#pragma endregion HotFix1 Windows6.0-KB958483

					#pragma region HotFix1 NDP35SP1-KB958484
					// ----------------------------------------------------------------------------
					if (IsWow64() == TRUE )  WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 (NDP35SP1-KB958484-x64) ...");
					else WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1 NDP35SP1-KB958484-x86) ...");

					ShowBillboard(&g_dwThread, &g_hThread);
					
					runcommand = theApp.CurrentPathStr;                                      
				    if (IsWow64() == TRUE ) runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\NDP35SP1-KB958484-x64.exe"));
					else runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix1\\NDP35SP1-KB958484-x86.exe"));
																		 
					runcommand.Append(_T(" /q"));
					d = ExecCmd2(runcommand);

					TeardownBillboard(g_dwThread, g_hThread);
					if (d != 0) 
						{
							if ( d == ERROR_SUCCESS_REBOOT_REQUIRED ) { MessageBox(_T(" KB958484 Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
							MessageBox(_T("Installation Hot Fix KB958484 Failed"));
							m_progress1.SetPos(6);
							MessageBox(_T("Installation Unsuccessful!"));
							return;
						}

				   #pragma endregion HotFix1 NDP20SP2-KB958484
			}
			

			#pragma endregion HotFix1 KB959209 

			#pragma endregion HotFix1 KB959209 

			#pragma region HotFix2 KB967190 
			if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion == 0) )
			{
					#pragma region HotFix1 Windows6.0-KB967190
					if (IsWow64() == TRUE) 
					{
					// -----------------------------------------------------------------------------------
					WaitLabelText = _T("Installing Hot fix for .NET Framework 3.5 SP1  (Windows6.0-KB967190-x64.msu) ...");

					ShowBillboard(&g_dwThread, &g_hThread);
					
					// Define Temp Dir
					CString TemDirPrefix = _T("D3A81ECBAAC541D28A4B37A04F98D7C0");
					DWORD lt = GetTickCount();
					CString s2;
					s2.Format(_T("%i"),lt);
					CString TempDir = theApp.SystemPathStr;
					TempDir = TempDir.Left(1) + _T(":\\") + TemDirPrefix+s2;
					DWORD d2;
					// Create if Not Exists
					if (PathIsDirectory(TempDir) != FILE_ATTRIBUTE_DIRECTORY) 
					{
						// Create Dir
						CreateDirectory(TempDir,NULL);
						
						// Temporary Code
						CString runcommand = theApp.CurrentPathStr;

						runcommand.Append(_T("\\wcu\\dotNetFX\\HotFix2\\Windows6.0-KB967190-x64.msu"));
						

						CString CopyTo = TempDir;
						CopyTo.Append(_T("\\Windows6.0-KB967190-x64.msu"));
						
						
						CopyFile(runcommand,CopyTo,FALSE);
						runcommand = _T("wusa \"") + CopyTo +_T("\" /quiet");
					
						d2 = ExecCmd2(runcommand);
						DeleteDirectory(TempDir,false);
					}

					int WU_S_ALREADY_INSTALLED = 0x240006;
					int WU_E_NOT_APPLICABLE = 0x80240017; 
					TeardownBillboard(g_dwThread, g_hThread);
					if ((d2 == 0) || ( d2 == 1) || (d2 == WU_S_ALREADY_INSTALLED )  || (d2 == WU_E_NOT_APPLICABLE )) {}
					else
						{
							int WU_S_REBOOT_REQUIRED = 0x240005;
							int WU_E_SETUP_REBOOTREQUIRED = 0x8024D00E;
							if (( d2 == WU_S_REBOOT_REQUIRED ) || ( d2 == WU_E_SETUP_REBOOTREQUIRED )) { MessageBox(_T(" KB967190 Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }

							TCHAR *item = new TCHAR[200];
							_stprintf(item, _T("Installation Hot Fix KB967190 Failed with Code %d"), d2);
							MessageBox(item);
							m_progress1.SetPos(6);
							MessageBox(_T("Installation Unsuccessful!"));
							return;
						}
	
					}
					#pragma endregion HotFix1 Windows6.0-KB967190
			}
			
			#pragma endregion HotFix2 KB967190 
		}

	}
	m_progress1.SetPos(2);	

	#pragma endregion Install .NET 

    #pragma region Install SQL Server


		if (m_sql2005 == true)
	   {
		
		#pragma region if in 64 Bit Widows SQL Server 2005 Codex 2007 Instance installed as X 86
		if (theApp.setting_Sqlx86onWin64Detection == 1)
		{
			// if in 64Bit Widows SQL Server 2005 Codex 2007 Instance installed as X86
			if (IsWow64() == TRUE)
			{
			   if (SQLX64DetectionMode == 1) CC_X64 = 0;
			}
		}
		#pragma endregion if in 64 Bit Widows SQL Server 2005 Codex 2007 Instance installed as X 86
		
		int sqlsetupstatus = 0;
		if (SQLCOMBO.GetCurSel() == 1)
		{
			#pragma region Without Advances Service
	 	    // Without Advances Services
			// ======================================== 
			
		    WaitLabelText = _T("Installing SQL Server 2008 R2 Express, this may take a several time ...");
		    if (SQLInstallMode == 1) WaitLabelText = _T("Upgrading to SQL Server 2008 R2 Express, this may take a several time ...");
		    ShowBillboard(&g_dwThread, &g_hThread);
			CString runcommand = theApp.CurrentPathStr;
            
			if (CC_X64 == 0) runcommand.Append(_T("\\wcu\\SQL2008R2\\EXPRESS\\X86\\SQLEXPR_x86_ENU.exe"));
		    else runcommand.Append(_T("\\wcu\\SQL2008R2\\EXPRESS\\X64\\SQLEXPR_x64_ENU.exe"));
			
			// /QS /Hideconsole=TRUE /ACTION=install /INSTANCENAME=Codex2007R4 /IACCEPTSQLSERVERLICENSETERMS=TRUE /FEATURES=SQL,Tools /SQLSVCACCOUNT="NT AUTHORITY\SYSTEM"  /SQLSYSADMINACCOUNTS="BUILTIN\ADMINISTRATORS" 
																                                                      
			if (SQLInstallMode == 0) runcommand.Append(_T(" /QS /Hideconsole=TRUE /IACCEPTSQLSERVERLICENSETERMS=TRUE /ACTION=install /INSTANCENAME=Codex2007  /Features=SQL,Tools  /SQLSYSADMINACCOUNTS=\"BUILTIN\\ADMINISTRATORS\" /SQLSVCACCOUNT=\"NT AUTHORITY\\SYSTEM\" "));
			if (SQLInstallMode == 1) runcommand.Append(_T(" /QS /Hideconsole=TRUE /IACCEPTSQLSERVERLICENSETERMS=TRUE /ACTION=upgrade /INSTANCENAME=Codex2007 "));

			DWORD d = ExecCmd2(runcommand);
			TeardownBillboard(g_dwThread, g_hThread);
			if (d == 0) sqlsetupstatus = 0; else sqlsetupstatus = 1;
			if (d != 0) 
			{
	              if ( d == ERROR_SUCCESS_REBOOT_REQUIRED ) { MessageBox(_T(" SQL Server Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
				  MessageBox(_T("SQL Installation Failed Please See Log File C:\\Prgoram Files\\Microsoft SQL Server\\100\\Setup Bootstrap\\Log\\Summary.txt"));
				  m_progress1.SetPos(6);
				  MessageBox(_T("Installation Unsuccessful!"));
				  return;
			}
			// If x64 Need Install SMO
			#pragma endregion Without Advances Service
			

		}
		else
		{
			
			// Install Power Shell
			if ( _PowerShell == - 1 )
			{
				MessageBox(_T("You Have Installed PowetShell RC Version on your Machine, Please Remove It to Install RTM Version"));
				m_progress1.SetPos(6);
				MessageBox(_T("Installation Unsuccessful!"));
				return;
			}

			if (_PowerShell == 0)
			{
				// Install PowerShell Stage
				// Install HotFixes
				OSVERSIONINFOEX OSversion;
				ZeroMemory(&OSversion, sizeof(OSVERSIONINFOEX));
				OSversion.dwOSVersionInfoSize=sizeof(OSVERSIONINFOEX);
				GetVersionEx((OSVERSIONINFO *)&OSversion);
				// =======================================================================================================
			#pragma region PowerShell
		
			#pragma region Windows Server 2003; Windows XP

		
			if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion >= 1))
			{
					// -----------------------------------------------------------------------------------
					if (IsWow64() == TRUE )  WaitLabelText = _T("Installing PowerShell for Windows X64 ...");
					else WaitLabelText = _T("Installing PowerShell for Windows ...");

					ShowBillboard(&g_dwThread, &g_hThread);
					
					CString runcommand = theApp.CurrentPathStr;

					if (OSversion.wProductType == VER_NT_WORKSTATION)
					{   
						 if (IsWow64() == FALSE ) runcommand.Append(_T("\\wcu\\PowerShell\\WindowsXP-KB926139-v2-x86-ENU.exe"));
					     else runcommand.Append(_T("\\wcu\\PowerShell\\WindowsServer2003.WindowsXP-KB926139-v2-x64-ENU.exe"));
					}
					else
					{
						 if (IsWow64() == FALSE ) runcommand.Append(_T("\\wcu\\PowerShell\\WindowsServer2003-KB926139-v2-x86-ENU.exe"));
					     else runcommand.Append(_T("\\wcu\\PowerShell\\WindowsServer2003.WindowsXP-KB926139-v2-x64-ENU.exe"));
					}
					
					runcommand.Append(_T(" /q"));
					DWORD d = ExecCmd2(runcommand);

					TeardownBillboard(g_dwThread, g_hThread);

					if (d != 0) 
						{
						  if ( d == ERROR_SUCCESS_REBOOT_REQUIRED ) { MessageBox(_T(" PowerShell Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
						  MessageBox(_T("PowerShell Installation Failed"));
						  m_progress1.SetPos(6);
						  MessageBox(_T("Installation Unsuccessful!"));
						  return;
			             }

			}

			#pragma endregion Windows Server 2003; Windows XP

			#pragma region 7 and for Windows Server 2008 R2

			if  (
				((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion >= 1) && (OSversion.wProductType == VER_NT_WORKSTATION)) ||
				 ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion >= 1))
				 )
			{
			  			    TeardownBillboard(g_dwThread, g_hThread);    
							MessageBox(_T("In Windows 7 and Windows 2008/R2 PowerShell is a part of the system component.\nDo not install it from Codex Distributive Please\nGo to Control Panel/ Programs / Windows Features\nAnd Select PowerShell"));
							m_progress1.SetPos(6);
							MessageBox(_T("Installation Unsuccessful!"));
							return;
			
			}

			if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion == 0) )
			{
					// -----------------------------------------------------------------------------------
						#pragma region PowerShell
					// -----------------------------------------------------------------------------------
					if (IsWow64() == TRUE )  WaitLabelText = _T("Installing PowerShell for Windows x64 ...");
					else WaitLabelText = _T("Installing PowerShell for Windows ...");


					ShowBillboard(&g_dwThread, &g_hThread);
					
					// Define Temp Dir
					CString TemDirPrefix = _T("D3A81ECBAAC541D28A4B37A04F98D7C0");
					DWORD lt = GetTickCount();
					CString s2;
					s2.Format(_T("%i"),lt);
					CString TempDir = theApp.SystemPathStr;
					TempDir = TempDir.Left(1) + _T(":\\") + TemDirPrefix+s2;
					DWORD d2;
					// Create if Not Exists
					if (PathIsDirectory(TempDir) != FILE_ATTRIBUTE_DIRECTORY) 
					{
						// Create Dir
						CreateDirectory(TempDir,NULL);
						
						// Temporary Code
						CString runcommand = theApp.CurrentPathStr;



					 if (IsWow64() == FALSE ) runcommand.Append(_T("\\wcu\\PowerShell\\Windows6.0-KB928439-x86.msu"));
					     else runcommand.Append(_T("\\wcu\\PowerShell\\Windows6.0-KB928439-x64.msu"));

						CString CopyTo = TempDir;
						if (IsWow64() == TRUE) 	CopyTo.Append(_T("\\Windows6.0-KB928439-x64.msu"));
						else CopyTo.Append(_T("\\Windows6.0-KB928439-x86.msu"));
						
						CopyFile(runcommand,CopyTo,FALSE);
						runcommand = _T("wusa \"") + CopyTo +_T("\" /quiet");
					
						d2 = ExecCmd2(runcommand);
						DeleteDirectory(TempDir,false);
					}

					int WU_S_ALREADY_INSTALLED = 0x240006;
					int WU_E_NOT_APPLICABLE = 0x80240017; 
					TeardownBillboard(g_dwThread, g_hThread);
					if ((d2 == 0) || ( d2 == 1) || (d2 == WU_S_ALREADY_INSTALLED )  || (d2 == WU_E_NOT_APPLICABLE )) {}
					else
						{
							int WU_S_REBOOT_REQUIRED = 0x240005;
							int WU_E_SETUP_REBOOTREQUIRED = 0x8024D00E;
							if (( d2 == WU_S_REBOOT_REQUIRED ) || ( d2 == WU_E_SETUP_REBOOTREQUIRED )) { MessageBox(_T(" PowerShell Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }

							TCHAR *item = new TCHAR[100];
							_stprintf(item, _T("PowerShell Installation Failed with Code %d"), d2);
							MessageBox(item);
							m_progress1.SetPos(6);
							MessageBox(_T("Installation Unsuccessful!"));
							return;
						}

					#pragma endregion PowerShell
			}

			#pragma endregion 7 and for Windows Server 2008 R2

			#pragma endregion PowerShell 

			}
			
			
			WaitLabelText = _T("Installing SQL Server 2008 R2 Express With Tools, this may take a several time ...");
		    if (SQLInstallMode == 1) WaitLabelText = _T("Upgrading to SQL Server 2008 R2 Express With Tools, this may take a several time ...");
		
		    ShowBillboard(&g_dwThread, &g_hThread);
	


			CString runcommand = theApp.CurrentPathStr;
			if (CC_X64 == 0) runcommand.Append(_T("\\wcu\\SQL2008R2\\EXPRESSWithTools\\X86\\SQLEXPRWT_x86_ENU.exe"));
		    else runcommand.Append(_T("\\wcu\\SQL2008R2\\EXPRESSWithTools\\X64\\SQLEXPRWT_x64_ENU.exe"));
			
			if (SQLInstallMode == 0) runcommand.Append(_T(" /QS /Hideconsole=TRUE /IACCEPTSQLSERVERLICENSETERMS=TRUE /ACTION=install /INSTANCENAME=Codex2007  /Features=SQL,Tools  /SQLSYSADMINACCOUNTS=\"BUILTIN\\ADMINISTRATORS\" /SQLSVCACCOUNT=\"NT AUTHORITY\\SYSTEM\" "));
			if (SQLInstallMode == 1) runcommand.Append(_T(" /QS /Hideconsole=TRUE /IACCEPTSQLSERVERLICENSETERMS=TRUE /ACTION=upgrade /INSTANCENAME=Codex2007 "));


			DWORD d = ExecCmd2(runcommand);
			TeardownBillboard(g_dwThread, g_hThread);
			if (d == 0) sqlsetupstatus = 0; else sqlsetupstatus = 1;

			if (d != 0) 
			{
	             if ( d == ERROR_SUCCESS_REBOOT_REQUIRED ) { MessageBox(_T(" SQL Server Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }

				  //MessageBox(_T("SQL Installation Failed Please See Log File C:\\Prgoram Files\\Microsoft SQL Server\\100\\Setup Bootstrap\\Log\\Summary.txt"));
				  MessageBox(_T("SQL Installation Failed Please See Log File C:\\Prgoram Files\\Microsoft SQL Server\\100\\Setup Bootstrap\\Log\\Summary.txt"));
				  m_progress1.SetPos(6);
				  MessageBox(_T("Installation Unsuccessful!"));
				  return;
			}
		}
		m_progress1.SetPos(5);
		}
	#pragma endregion Install SQL Server
	
	#pragma region Install SQL Native Client
	//if (this->m_sqlclient == false) MessageBox(_T("FALSE")); else MessageBox(_T("TRUe")); 
	if (this->m_sqlclient == true)
	{

			
		WaitLabelText = _T("Installing SQL Server 2008 R2 Native Client, this may take a several time ...");
		
		ShowBillboard(&g_dwThread, &g_hThread);
		
		CString runcommand = _T("msiexec /i ");
		runcommand.Append(theApp.CurrentPathStr);
		if (CC_X64 == 0) runcommand.Append(_T("\\wcu\\SQL2008R2\\NativeClient\\X86\\sqlncli.msi"));
		else runcommand.Append(_T("\\wcu\\SQL2008R2\\NativeClient\\X64\\sqlncli.msi"));
		
		runcommand.Append(_T(" ADDLOCAL=ALL /passive APPGUID={0CC618CE-F36A-415E-84B4-FB1BFF6967E1}  IACCEPTSQLNCLILICENSETERMS=YES "));
		
		DWORD d = ExecCmd2(runcommand);
		TeardownBillboard(g_dwThread, g_hThread);
   	    if (d != 0) 
		{
	        if ( d == ERROR_SUCCESS_REBOOT_REQUIRED ) { MessageBox(_T(" SQL Server Client Installation Completed \n Reboot Requred \n Please Reboot The System")); return; }
			MessageBox(_T("SQL Server 2008 R2 Native Client Installation Failed Please See Log File"));
		    m_progress1.SetPos(6);
			MessageBox(_T("Installation Unsuccessful!"));
			return;
	     }



	}
	#pragma endregion Install SQL Native Client


	m_progress1.SetPos(6);
	MessageBox(_T("Installation Complete"));


}


// =================================================================================
// ==========================================================================
// ShowBillboard()
//
// Purpose:
//  Display billboard on created thread
// ==========================================================================

void ShowBillboard(DWORD * pdwThreadId, HANDLE * phThread)
{

    *phThread = CreateThread(NULL, 
                            0L, 
							StaticThreadProc, 
                            (LPVOID)NULL, 
                            0, 
                            pdwThreadId );
}

// ==========================================================================
// TeardownBillboard()
//
// Purpose:
//  Take down billboard
// ==========================================================================
//    Private message to tell the thread to destroy the window
const UINT  PWM_THREADDESTROYWND = WM_USER; 

void TeardownBillboard(DWORD dwThreadId, HANDLE hThread)
{
    //    Tell the thread to destroy the modeless dialog
    PostThreadMessage( dwThreadId, PWM_THREADDESTROYWND, 0, 0 );

    WaitForSingleObject( hThread, INFINITE );

    CloseHandle( hThread );
}

// ==========================================================================
// StaticThreadProc()
//
// Purpose:
//  Thread proc that creates our billboard dialog
// ==========================================================================

DWORD WINAPI StaticThreadProc( LPVOID lpParameter )
{
    MSG msg;
	//m_hAppInst = NULL;
    HWND hwnd;
    //HINSTANCE ginst = m_hAppInst;  
    hwnd = CreateDialog(NULL, 
                        MAKEINTRESOURCE(IDD_DIALOG1), 
                        GetDesktopWindow(), 
                        BillboardProc);
 
	
	
    ShowWindow(hwnd, SW_SHOW);

	RECT rcDlg;
    GetWindowRect(hwnd, &rcDlg); 
 

	SetWindowPos(hwnd,HWND_TOPMOST,rcDlg.left,rcDlg.top-2*(rcDlg.bottom-rcDlg.top),0,0,SWP_NOSIZE);

	SetDlgItemText(hwnd,IDC_WHAITLABEL,WaitLabelText);
	SetWindowText(hwnd,_T("Codex Installation System"));
	
	BOOL bEnable = FALSE;    // To disable

	UINT menuf = bEnable ? (MF_BYCOMMAND) : (MF_BYCOMMAND | MF_GRAYED | MF_DISABLED);

	HMENU pSM = ::GetSystemMenu(hwnd,FALSE);
	if(pSM)
		{
			::EnableMenuItem(pSM, SC_CLOSE, menuf ); 
		}
	
	HDC hdc;
	hdc = GetDC(hwnd);
	
	SetBkColor(hdc, RGB(255,255,255));
	


    while( GetMessage( &msg, NULL, 0, 0 ) )
    {
        if (!::IsDialogMessage( hwnd, &msg ))
        {
                if (msg.message == PWM_THREADDESTROYWND)
                {
                    //    Tell the dialog to destroy itself
                    DestroyWindow(hwnd);

                    //    Tell our thread to break out of message pump
                    PostThreadMessage( g_dwThread, WM_QUIT, 0, 0 );
                }
        }
    } 

    return( 0L );

}

// ==========================================================================
// BillboardProc()
//
// Purpose:
//  Callback proc used to set HWND_TOPMOST on billboard
// ==========================================================================
BOOL CALLBACK BillboardProc(HWND hwndDlg, 
                            UINT message, 
                            WPARAM wParam, 
                            LPARAM lParam) 
{ 
    switch (message) 
    { 
        case WM_INITDIALOG: 
            SetWindowPos( hwndDlg, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE );
            return TRUE;
    } 
    return FALSE; 
} 


void CPage1::OnBnClickedButton1()
{
	MessageBox(_T("In Windows 7 and Windows 2008R2 .NET Framework 3.51 is a part of the system component.\nDo not install .NET Framework from Codex Distributive Please\nGo to Control Panel/ Programs / Windows Features\nAnd Select .NET Framework 3.5 SP1"));
}


void CPage1::OnStnClickedSqlstatic()
{
}


void CPage1::OnStnClickedStaticSqlServerInstallSp()
{
	switch (theApp.setting_InstallationMode)
	{
	case 0x0100 : {  //Client Mode
					

				  } break;
	case 0x0000 : {  //Worksation Mode
					
				  } break;
	case 0x0010 : { //Server Mode
					//Run SQL Server 2008 R2
					
					// NO SP for 2008 R2 yet

				  } break;


			case 0x0001 : { //Internal Mode
					//Run SQL Server 2005 Developer This is Temorary Solution Until All Codex User not moved to R3
					
					CString runcommand = theApp.CurrentPathStr;
					if (IsWow64() == TRUE)
					{
						runcommand.Append(_T("\\Server\\SQL2005Dev\\ServicePack\\SQLServer2005SP3-KB955706-x64-ENU.exe"));
					}
					else
					{
						runcommand.Append(_T("\\Server\\SQL2005Dev\\ServicePack\\SQLServer2005SP3-KB955706-x86-ENU.exe"));
					}
	DWORD d = ExecCmd2(runcommand.GetString());
	
					CString ErrorMessage = _T("Error Code :");
					ErrorMessage.Format(_T("Error Code : %i"),d);
					if (d != 0) MessageBox(ErrorMessage);

				  } break;
	}

}


void CPage1::OnBnClickedStaticSqlServerInstall()
{
	switch (theApp.setting_InstallationMode)
	{
	case 0x0100 : {  //Client Mode
					

				  } break;
	case 0x0000 : {  //Worksation Mode
					
				  } break;
	case 0x0010 : { //Server Mode
					//Run SQL Server 2008 R2
					
					CString runcommand = theApp.CurrentPathStr;
					if (IsWow64() == TRUE)
					{
						runcommand.Append(_T("\\Server\\SQL2008R2\\X64\\Servers\\Setup.exe"));
					}
					else
					{
						runcommand.Append(_T("\\Server\\SQL2008R2\\X86\\Servers\\Setup.exe"));
					}
					DWORD d = ExecCmd2(runcommand.GetString());
	
					CString ErrorMessage = _T("Error Code :");
					ErrorMessage.Format(_T("Error Code : %i"),d);
					if (d != 0) MessageBox(ErrorMessage);

				  } break;


			case 0x0001 : { //Internal Mode
					//Run SQL Server 2005 Developer This is Temorary Solution Until All Codex User not moved to R3

				  } break;
	}
	
}


void CPage1::OnBnClickedStaticSqlServerInstallSp()
{
	// TODO: Add your control notification handler code here
}
