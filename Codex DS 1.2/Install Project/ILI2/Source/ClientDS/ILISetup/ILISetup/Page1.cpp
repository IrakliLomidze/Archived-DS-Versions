// Page1.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "Page1.h"
#include "generalrun.h"
#include "MSI.h"
#include "font.h"
#include "mdac.h"
#include "dotnet.h"
#include "SQL5Expr.h"
#include "SQLCLI.h"


// CPage1 dialog

//IMPLEMENT_DYNAMIC(CPage1, CPropertyPage)
//IMPLEMENT_DYNAMIC(CPage1, CDialog)

CPage1::CPage1()
	: CDialog(CPage1::IDD)
	, m_netfx(FALSE)
	, m_sql2005(FALSE)
	, VCPP(FALSE)
{
	m_brush = new CBrush(RGB(255, 255, 255));
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
	DDX_Control(pDX, IDC_BUTTON1, ButtonFX);
}


//BEGIN_MESSAGE_MAP(CPage1, CPropertyPage)
BEGIN_MESSAGE_MAP(CPage1, CDialog)
	ON_WM_CTLCOLOR()
	ON_WM_DESTROY()
	ON_NOTIFY(NM_CUSTOMDRAW, IDC_PROGRESS1, &CPage1::OnNMCustomdrawProgress1)
	ON_BN_CLICKED(IDC_BUTTON3, &CPage1::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON1, &CPage1::OnBnClickedButton1)
END_MESSAGE_MAP()


// CPage1 message handlers

BOOL CPage1::OnInitDialog()
{
	CDialog::OnInitDialog();

	DWORD g_dwThread = 0;
	HANDLE g_hThread = NULL;
	BI.EnableWindow(TRUE);	
	// TODO:  Add extra initialization here
	GetInformationv();
	
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
	
	// Initialize Windows Version
	OSVERSIONINFOEX OSversion;
	
	ZeroMemory(&OSversion, sizeof(OSVERSIONINFOEX));

	

	OSversion.dwOSVersionInfoSize=sizeof(OSVERSIONINFOEX);

	GetVersionEx((OSVERSIONINFO *)&OSversion);

	CString versioninfo = _T("Microsoft Windows");
	

		if (OSversion.dwMajorVersion < 5)
	{
		// Minimal System requrement in Windows XP SP2
		MessageBox(_T("Minimal System requrement in Windows XP SP2"));
		BI.EnableWindow(FALSE);	
		return;
	}
    
	if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion == 0)) 
	{
		// Minimal System requrement in Windows XP SP2
		MessageBox(_T("Windows 2000 Does not Supported By Codex 2007 R2 \n Minimal System requrement in Windows XP SP2"));
		BI.EnableWindow(FALSE);	
		return;
	}

	if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion == 1)) 
	{
		if (OSversion.wServicePackMajor < 2) 
		{
			MessageBox(_T("Your XP System Does not have Serive Pack 2 \n Minimal System requrement in Windows XP SP2 \n You may install But now garanded that codex will work ok"));
		}
		versioninfo.Append(_T(" XP "));
		versioninfo.Append(OSversion.szCSDVersion);
		CC_X64 = 0;
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
	this->SetDlgItemText(IDC_STATICMSIVER,s2);
	
	
    
	// Fonts


	ILI_Font *ili5 = new ILI_Font();

		if (ili5->CheckFont()  == true)
		{
             //ILI_FONT_CHEK = true;
			 this->SetDlgItemText(IDC_FONTLABEL,_T("You have dublicate font geoabc.ttf"));
             // Change Color xxx
			 CC_Font = 1;
		}
		else
		{
			//ILI_FONT_CHEK = false;
			this->SetDlgItemText(IDC_FONTLABEL,_T("You do not need any font action"));
			CC_Font = 0;
		}

VCPP = true;

		ILI_MDAC *ili7 = new ILI_MDAC();
		if (ili7->ILI_checkMDAC() == true)
		{
			this->SetDlgItemText(IDC_MDACLABEL,_T("You do not have MDAC"));
		}
		else
		{
			this->SetDlgItemText(IDC_MDACLABEL,ili7->CurrentVersion);
		}

	

		this->ButtonFX.EnableWindow(FALSE);
		this->ButtonFX.ShowWindow(SW_HIDE);
		this->GetDlgItem(IDC_CHECK1)->EnableWindow(TRUE);


		ILI_DOTNET *ili9 = new ILI_DOTNET();
		ili9->ili_dotnetcheck3();
		if (ili9->framework30 == 1)
		{
			 this->SetDlgItemText(IDC_NETFXSTATIC,_T("You Have .net framework 3.0 Installed"));
			 CC_NETFX = 0;
			 m_netfx = false;
		}
		else
		{
			
			if (OSversion.dwMajorVersion == 6)
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
						
		
			this->SetDlgItemText(IDC_NETFXSTATIC,_T("You need to install .net framework 3.0"));
			
		}

		if (OSversion.dwMajorVersion == 6) { GetDlgItem(IDC_CHECK1)->EnableWindow(FALSE);}
			else { GetDlgItem(IDC_CHECK1)->EnableWindow(TRUE); }


		

    ILI_SQLNative *ili14 = new ILI_SQLNative();
	
	if (ili14->ILI_checkMSI() == true)
	{
		this->SetDlgItemText(IDC_SQLSTATIC,_T("You need to install SQL Server Native Client "));
		CC_SQL = 1;
		m_sql2005 = true;
		
	}
	else
	{
		CString V = _T("Version ");
		V.Append(ili14->CurrentVersion);
		this->SetDlgItemText(IDC_SQLSTATIC,V);
		CC_SQL = 0;
		m_sql2005 = false;
	}
	
	

	UpdateData(FALSE);

	}

	void CPage1::OnBnClickedButton3()
	{
		// Installation Process
		
		// Install Framework 3.0
	m_progress1.SetRange(0,6);
	UpdateData(TRUE);
	BI.EnableWindow(FALSE);	

		
	if (m_netfx == true)
	{
		WaitLabelText = _T("Installing .NET Framework 3.0, this procedure may take a several time ...");
		
		ShowBillboard(&g_dwThread, &g_hThread);
		int netsetupstatus = 0;
		CString runcommand = theApp.CurrentPathStr;
		if (CC_X64 == 0) runcommand.Append(_T("\\wcu\\dotNetFramework\\dotNetFX30\\X86\\DotNetFX3.exe"));
		else runcommand.Append(_T("\\wcu\\dotNetFramework\\dotNetFX30\\X64\\DotNetFX3_x64.exe"));
		runcommand.Append(_T(" /q"));

		DWORD d = ExecCmd2(runcommand);
		
		if (d == 0) netsetupstatus = 0; else netsetupstatus = 1;
		TeardownBillboard(g_dwThread, g_hThread);
	}
	m_progress1.SetPos(4);	

	if (m_sql2005 == true)
	{
		WaitLabelText = _T("Installing SQL Server Native Client, this may take a several time ...");
		
		//ShowBillboard(&g_dwThread, &g_hThread);
		
		int sqlsetupstatus = 0;
		//ShowBillboard(&g_dwThread, &g_hThread);
		
		CString runcommand = _T("msiexec /i ");
		runcommand.Append(theApp.CurrentPathStr);
		if (CC_X64 == 0) runcommand.Append(_T("\\wcu\\SQLCLIENT\\90\\X86\\sqlncli.msi"));
		else runcommand.Append(_T("\\wcu\\SQLCLIENT\\90\\X64\\sqlncli_x64.msi"));
		
		runcommand.Append(_T(" ADDLOCAL=ALL /passive"));
		
		DWORD d = ExecCmd2(runcommand);
		//TeardownBillboard(g_dwThread, g_hThread);
		if (d == 0) sqlsetupstatus = 0; else sqlsetupstatus = 1;
	}


	m_progress1.SetPos(5);

	if (VCPP == true)
	{
		WaitLabelText = _T("Installing runtime components of Visual C++ Libraries ...");
		
		ShowBillboard(&g_dwThread, &g_hThread);
		//int netsetupstatus = 0;
		CString runcommand = theApp.CurrentPathStr;
		if (CC_X64 == 0) runcommand.Append(_T("\\wcu\\VC2008\\X86\\vcredist_x86.exe"));
		else runcommand.Append(_T("\\wcu\\VC2008\\X64\\vcredist_x64.exe "));
		runcommand.Append(_T(" /q"));

		DWORD d = ExecCmd2(runcommand);
		
		//if (d == 0) netsetupstatus = 0; else netsetupstatus = 1;
		TeardownBillboard(g_dwThread, g_hThread);
	}
	m_progress1.SetPos(6);


	m_progress1.SetPos(6);	
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
 

	SetWindowPos(hwnd,HWND_TOPMOST,rcDlg.left,rcDlg.top-(rcDlg.bottom-rcDlg.top),0,0,SWP_NOSIZE);
	SetDlgItemText(hwnd,IDC_WHAITLABEL,WaitLabelText);
	
				
	

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
	MessageBox(_T("In Windows Vista/7 and Windows 2008/2008R2 .NET Framework is a system component.\nDo not install .NET Framework from Codex Distributive Please\nGo to Control Panel/ Programs / Windows Features\nAnd Select .NET Framework 3.0/3.5 SP1"));
}
