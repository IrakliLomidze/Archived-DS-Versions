// ILISetupDlg.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "ILISetupDlg.h"
#include <Windows.h>
#include <Shlwapi.h>
#include <WinError.h>
#include "generalrun.h"
#include <cstringt.h>
#include "page1.h"
#include "MSI.h"
#include "SXS.h"
#include "font.h"
#include "afxwin.h"
#include "XPWarning.h"
#include "IniFile.h"




#ifdef _DEBUG
#define new DEBUG_NEW
#endif

extern CILISetupApp theApp;

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
public:
	CWhiteStatic C1;
	CWhiteStatic C2;
	CWhiteStatic C3;
	CWhiteStatic C4;
	CWhiteStatic C5;
	CBrush* m_brush;
	afx_msg HBRUSH OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor);
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	m_brush = new CBrush(RGB(255, 255, 255));
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STATIC1, C1);
	DDX_Control(pDX, IDC_STATIC2, C2);
	DDX_Control(pDX, IDC_STATIC3, C3);
	DDX_Control(pDX, IDC_STATIC4, C4);
	DDX_Control(pDX, IDC_STATIC5, C5);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	ON_WM_CTLCOLOR()
END_MESSAGE_MAP()


// CILISetupDlg dialog




CILISetupDlg::CILISetupDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CILISetupDlg::IDD, pParent)
	, m_force(false)
	, ForceCheck(false)
	, SQLExpress(0)
	, FC(false)
	
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

   


}

void CILISetupDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STATIC1, Panel1);
	DDX_Control(pDX, IDC_BUTTON7, B7);
	DDX_Control(pDX, IDC_BUTTON1, GUN);
	DDX_Control(pDX, IDC_BUTTON2, G8N);
	DDX_Control(pDX, IDC_BUTTON6, Help);
	DDX_Control(pDX, IDC_STATIC2, DES);
	DDX_Control(pDX, IDC_STATIC10, m_Static10);
	DDX_Control(pDX, IDC_STATIC11, m_static11);
	DDX_Control(pDX, IDC_BUTTON3, m_ViewReadme);
	DDX_Control(pDX, IDC_CHECK1, Check1);
	DDX_Check(pDX, IDC_CHECK2, FC);
	DDX_Control(pDX, IDC_STATICForceInstall, FV1);
	DDX_Control(pDX, IDC_STATIC12, staticad);
	DDX_Control(pDX, IDC_BUTTON4, AdobeInstall);
}

BEGIN_MESSAGE_MAP(CILISetupDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(IDC_BUTTON7, &CILISetupDlg::OnBnClickedButton7)
	ON_BN_CLICKED(IDC_BUTTON1, &CILISetupDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON3, &CILISetupDlg::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON2, &CILISetupDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON4, &CILISetupDlg::OnBnClickedButton4)
	ON_BN_CLICKED(IDC_BUTTON5, &CILISetupDlg::OnBnClickedButton5)
	ON_BN_CLICKED(IDC_BUTTON6, &CILISetupDlg::OnBnClickedButton6)
	ON_BN_CLICKED(IDC_CHECK1, &CILISetupDlg::OnBnClickedCheck1)
END_MESSAGE_MAP()


// CILISetupDlg message handlers

BOOL CILISetupDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	m_Static10.isBold = 1;
	m_static11.isBold = 1;
	staticad.isBold = 1;
	
	
  
	
	
	//CIniFile codexsetting;
	//codexsetting.Create("ILISetup.ini");
	//codexsetting.CommentSection(CIniFile::CommentChar::Pound,"Section1","ILISetup.ini");
	//codexsetting.CommentRecord(CIniFile::CommentChar::Pound, "SQLCodex2007UpdateMode","General","ILISetup.ini");

	//codexsetting.SetValue("SQLCodex2007UpdateMode","FALSE","General","ILISetup.ini");
	//codexsetting.SetSectionComments("#My Comment","Section1","ILISetup.ini");
	//codexsetting.SetRecordComments("# if Codex2007 Instamce (SQL2005) Exists Mandatory to Update SQL 2008 R2", "SQLCodex2007UpdateMode", "General","ILISetup.ini");
	
	CIniFile codexsetting;
	
	std::string _SQLCodex2007UpdateMode;
	
	
	_SQLCodex2007UpdateMode = codexsetting.GetValue("SQLCodex2007UpdateMode","General","ILISetup.ini");
	//if (_SQLCodex2007UpdateMode == "FALSE" )
		//MessageBox(_T("1"));
	
	//if (_SQLCodex2007UpdateMode == "FALSE " )
		//MessageBox(_T("2"));

	theApp.setting_InstallationMode = 0;
	std::string ;
	
	_SQLCodex2007UpdateMode = codexsetting.GetValue("InstallationMode","General","ILISetup.ini");
	if (_SQLCodex2007UpdateMode == "DS Workstation") theApp.setting_InstallationMode = 0x0000; // Worksation Mode
	if (_SQLCodex2007UpdateMode == "DS Client") theApp.setting_InstallationMode = 0x0100; // Client Mode
	if (_SQLCodex2007UpdateMode == "DS Server") theApp.setting_InstallationMode = 0x0010; // Server Mode
	

	if  (theApp.setting_InstallationMode == 0x0100 )
	{
		this->GetDlgItem(IDC_STATIC11)->SetWindowText(_T("Repair, Reinstall or Install Codex.Net DS R3 Client"));
		this->GetDlgItem(IDC_BUTTON2)->SetWindowText(_T("Step 2 -> Codex.net DS R3 Client"));
	}

	if  (theApp.setting_InstallationMode == 0x0000 )
	{
		this->GetDlgItem(IDC_STATIC11)->SetWindowText(_T("Repair, Reinstall or Install Codex.Net DS R3 Workstation Demo"));
		this->GetDlgItem(IDC_BUTTON2)->SetWindowText(_T("Step 2 -> Codex.net DS R3 Workstation Demo"));
	}

	if  (theApp.setting_InstallationMode == 0x0010 )
	{
		this->GetDlgItem(IDC_STATIC11)->SetWindowText(_T("Repair, Reinstall or Install Codex.Net DS R3 Server"));
		this->GetDlgItem(IDC_BUTTON2)->SetWindowText(_T("Step 2 -> Codex.net DS R3 Server"));
		this->GetDlgItem(IDC_BUTTON4)->EnableWindow(FALSE);
	}

	

	theApp.setting_Sqlx86onWin64Detection = 0;
	std::string _Sqlx86onWin64Detection = codexsetting.GetValue("Sqlx86onWin64Detection","General","ILISetup.ini");
	if (_Sqlx86onWin64Detection == "True" )
	{
		theApp.setting_Sqlx86onWin64Detection = 1;
		//MessageBox(_T("1"));
	}
	else
	{
		theApp.setting_Sqlx86onWin64Detection = 0;
		//MessageBox(_T("0"));
	}

		
	// TODO: Add extra initialization here
    // if you are not administrator
	GeneralRun *run1 = new GeneralRun();
	if (run1->IsCurrentUserLocalAdministrator() == FALSE )
	{
		MessageBox(_T("To install Codex.net DS R3 software you must be log as an Administrator"),_T("Codex.net R3 Installer"),MB_OK | MB_ICONINFORMATION);
		CDialog::OnCancel();
	}
	else
	{
		
	//	{  	CXPWarning w1;  w1.DoModal(); CDialog::EndDialog(0); }
		

		// -----------------------------------------------------------------------------------------------------------------------
		int OSStatus = isOSNormal();
		if (OSStatus != 0) 	{  	CXPWarning w1;  w1.DoModal(); CDialog::EndDialog(0); return FALSE; 	}

		
		// OS Check
		OSVERSIONINFOEX OSversion;
		ZeroMemory(&OSversion, sizeof(OSVERSIONINFOEX));
		OSversion.dwOSVersionInfoSize=sizeof(OSVERSIONINFOEX);
		GetVersionEx((OSVERSIONINFO *)&OSversion);

		//CXPWarning w1;  w1.DoModal(); CDialog::EndDialog(0);

		// Windows Vista
		if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion == 0)) 
		{ 
			if (OSversion.wServicePackMajor < 1)  // if not Service Pack 1
			{  	CXPWarning w1;  w1.DoModal(); CDialog::EndDialog(0); }
		}

		// Windows XP
		if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion == 1))  
		{ 
			if (OSversion.wServicePackMajor < 3)  // if not Service Pack 3
			{  	CXPWarning w1;  w1.DoModal(); CDialog::EndDialog(0); }
		}

		// Windows 2000
		if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion < 1)) // Winsows 2000
		{
			{  	CXPWarning w1;  w1.DoModal(); CDialog::EndDialog(0); }
		}

		// Windows Older than 2000
		if (OSversion.dwMajorVersion < 5)  // Less than Winsows 2000
		   {  	CXPWarning w1;  w1.DoModal(); CDialog::EndDialog(0); }

		// ---------------------------------------------------------------------------------------------------------------
		
		ILI_MSI *ili2 = new ILI_MSI();
		
		if (ili2->ILI_checkMSI() == true)
		{
			if (MessageBox(_T("To Install Codex.net DS R3 on your system is required \n Microsoft Windows Installer 4.5 \n \n Would you like to install it? \n After installing Windows Installer 4.5 system will reboot."),_T("System requriement"),
				       MB_YESNO) == IDYES)	
			{
				
				CString runcommand = theApp.CurrentPathStr;

				// Install Windows Installer 4.5
				// Determine OS
				// OS Check
				OSVERSIONINFOEX OSversion;
				ZeroMemory(&OSversion, sizeof(OSVERSIONINFOEX));
				OSversion.dwOSVersionInfoSize=sizeof(OSVERSIONINFOEX);
				GetVersionEx((OSVERSIONINFO *)&OSversion);


				// For Windows Vista, Windows Vista Service Pack 1 and Windows Server 2008:
				if ((OSversion.dwMajorVersion == 6) && (OSversion.dwMinorVersion == 0)) 
				{  
					runcommand.Append (_T("wusa update "));
					if (IsWow64() == TRUE ) runcommand.Append(_T("\\wcu\\MSI45\\Windows6.0-KB942288-v2-x64.msu")); 	
					else runcommand.Append(_T("\\wcu\\MSI45\\Windows6.0-KB942288-v2-x86.msu")); 	
				}

				// Windows XP Service Pack 2 and Windows XP Service Pack 3 (32-bit platforms):
				if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion == 1))		
				{  
					runcommand.Append(_T("\\wcu\\MSI45\\WindowsXP-KB942288-v3-x86.exe")); 	
				}

				//Windows Server 2003 Service Pack 1, Windows Server 2003 Service Pack 2 and Windows XP 64-bit Editions
				if ((OSversion.dwMajorVersion == 5) && (OSversion.dwMinorVersion == 2)) 
				{  
					if (IsWow64() == TRUE ) runcommand.Append(_T("\\wcu\\MSI45\\WindowsServer2003-KB942288-v4-x64.exe")); 	
					else runcommand.Append(_T("\\wcu\\MSI45\\WindowsServer2003-KB942288-v4-x86.exe")); 	
				}
				
				
				DWORD d = ExecCmd2(runcommand);
				if (d != 0)
				{
					MessageBox(_T("Can't run Windows Installer 4.5 Installer Package"));
				}
				CDialog::OnCancel();
				return FALSE;
			}
			else
			{
				CDialog::OnCancel();
			    return FALSE;
			}
			
			
		}
		else
		{
		//	CString s2 = _T("Your Current MSI Version is :");
		//	s2.Append(ili2->CurrentVersion);
		//	MessageBox(s2);
		}
	
	

		

	}


	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CILISetupDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CILISetupDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CILISetupDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CILISetupDlg::OnBnClickedButton7()
{
	CDialog::OnCancel();
}

void CILISetupDlg::OnBnClickedButton1()
{

	if (theApp.setting_InstallationMode ==  0x0010) // Sever Mode
	{
		   MessageBox(_T("Please Insert a SQL Server 2008 R2 Installation DVD and Run Setup\n\rInstallation Instructions are in Help Directory"),_T("Codex.Net R3 Installer"),MB_OK | MB_ICONINFORMATION);
		   return;
	
	}

	UpdateData(true);

	GeneralRun *r = new GeneralRun();
	BOOL isnr = r->NeedReboot();
	if (isnr == TRUE)
	{
		
		if (FC == 0)
		{
		   MessageBox(_T("Setup has detected that another program requires the computer to reboot. \nYou must reboot the computer before installing Codex.NET R3 Prerequisites.\nOnce the system reboots, you need to restart setup. Click Cancel to exit setup and install later.\n\nFor force installing software check force check box on form and please read readme document\n\nForce installing has some risks make you sure that your system will work fine if you install in force mode"),_T("Codex.Net DS R3 Installer"),MB_OK | MB_ICONINFORMATION);
		   return;
		}
		else
		{
			if (MessageBox(_T("You select a force mode installation\nForce installing has some risks make you sure that your system will work fine if you install in force mode\nDo you want continue"),_T("Codex.Net DS R3 Installer"),MB_YESNO|MB_DEFBUTTON2|MB_ICONQUESTION) == IDNO) return;
		}
	}



	CPage1 p1;
	p1._SQLEXPRESS = this->SQLExpress;
	p1.DoModal();
	return;


}

void CILISetupDlg::OnBnClickedButton3()
{
	CString s = theApp.CurrentPathStr;
	s.Append(_T("\\HELP\\ilsetup.htm"));

	HINSTANCE hInstance = (HINSTANCE)ShellExecute(NULL, _T("open"), s , NULL, NULL, 2);

	if ((UINT)hInstance < HINSTANCE_ERROR)
		MessageBox(_T("Error open help file"),_T(""),MB_OK | MB_ICONINFORMATION);
}

void CILISetupDlg::OnBnClickedButton2()
{

	ILI_Font *ili5 = new ILI_Font();

		if (ili5->CheckFont()  == true)
		{
             //ILI_FONT_CHEK = true;
			 //AfxMessageBox(_T("You have dublicate font geoabc.ttf"),0,0);
             //return;
			 
		}
		


	// Georgian 8 Bit English Layout 	
	CString runcommand = theApp.CurrentPathStr;
	runcommand.Append(_T("\\Setup\\setup.exe"));
	DWORD d = ExecCmd2(runcommand.GetString());
	
		CString ErrorMessage = _T("Error Code :                  ");
		ErrorMessage.Format(_T("Error Code : %d"),d);
	    if (d != 0) MessageBox(ErrorMessage);

}

void CILISetupDlg::OnBnClickedButton4()
{
	CString runcommand = theApp.CurrentPathStr;
	runcommand.Append(_T("\\WCU\\Acrobat\\AdbeRdr1000_en_US.exe"));
	DWORD d = ExecCmd2(runcommand.GetString());
	
		CString ErrorMessage = _T("Error Code :                  ");
		ErrorMessage.Format(_T("Error Code : %d"),d);
	    if (d != 0) MessageBox(ErrorMessage);
}

void CILISetupDlg::OnBnClickedButton5()
{
}

void CILISetupDlg::OnBnClickedButton6()
{
	// TODO: Add your control notification handler code here
	CAboutDlg ab1;
	ab1.DoModal();
}





HBRUSH CAboutDlg::OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor)
{
	HBRUSH hbr = CDialog::OnCtlColor(pDC, pWnd, nCtlColor);

	// TODO:  Change any attributes of the DC here

	// TODO:  Return a different brush if the default is not desired
	return (HBRUSH)(m_brush->GetSafeHandle());
	//return hbr;
}

void CILISetupDlg::OnBnClickedCheck1()
{
	
}
