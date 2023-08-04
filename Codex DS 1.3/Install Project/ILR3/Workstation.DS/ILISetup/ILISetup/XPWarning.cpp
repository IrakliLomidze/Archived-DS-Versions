// XPWarning.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "XPWarning.h"
#include "ColorStatic.h"


// CXPWarning dialog

IMPLEMENT_DYNAMIC(CXPWarning, CDialog)

CXPWarning::CXPWarning(CWnd* pParent /*=NULL*/)
	: CDialog(CXPWarning::IDD, pParent)
{
}

CXPWarning::~CXPWarning()
{
}

void CXPWarning::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STATICPanel, Panel2);
	DDX_Control(pDX, IDC_STATIC10, LabelSupport1);
	DDX_Control(pDX, IDC_STATICW1, Label1);
	DDX_Control(pDX, IDC_STATICW2, Label2);
	DDX_Control(pDX, IDC_STATICW3, Label3);
	DDX_Control(pDX, IDC_STATICW4, Label4);
	DDX_Control(pDX, IDC_STATICW5, Label5);
	DDX_Control(pDX, IDC_STATICW6, Label6);
	DDX_Control(pDX, IDC_STATICW7, Label7);
}


BEGIN_MESSAGE_MAP(CXPWarning, CDialog)
	ON_BN_CLICKED(IDC_CLOSE, &CXPWarning::OnBnClickedClose)
	ON_WM_CLOSE()
	ON_WM_ACTIVATE()
END_MESSAGE_MAP()



// CXPWarning message handlers

void CXPWarning::OnBnClickedClose()
{
	CDialog::EndDialog(0);
}


void CXPWarning::OnClose()
{
	// TODO: Add your message handler code here and/or call default
	CDialog::OnClose();
}

BOOL CXPWarning::OnInitDialog()
{
	CDialog::OnInitDialog();

	DWORD g_dwThread = 0;
	HANDLE g_hThread = NULL;

	
	
	//this->Header.SetTButtonFX.SetTextColor(0x00800000);
	
	//Codex2007Pre.SetFont(&m_Font, TRUE);

//	if (this->HotFixDisable == 1) this->Button_HotFix.EnableWindow(TRUE);
//	if (this->HotFixDisable == 0) this->Button_HotFix.EnableWindow(FALSE);
	
	//BI.EnableWindow(TRUE);
	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}




void CXPWarning::OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized)
{
	CDialog::OnActivate(nState, pWndOther, bMinimized);
	
	// TODO: Add your message handler code here
}
