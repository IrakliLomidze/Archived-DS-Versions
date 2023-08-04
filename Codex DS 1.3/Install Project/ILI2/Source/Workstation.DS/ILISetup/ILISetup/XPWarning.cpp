// XPWarning.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "XPWarning.h"


// CXPWarning dialog

IMPLEMENT_DYNAMIC(CXPWarning, CDialog)

CXPWarning::CXPWarning(CWnd* pParent /*=NULL*/)
	: CDialog(CXPWarning::IDD, pParent)
{
   int ResultX = 0;
   HotFixDisable = 0;
}

CXPWarning::~CXPWarning()
{
}

void CXPWarning::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STATICWP, Panel1);
	DDX_Control(pDX, IDC_STATIC_OLD, Label1);
	DDX_Control(pDX, IDC_STATIC2, Label2);
	DDX_Control(pDX, IDC_STATIC3, Label3);
	DDX_Control(pDX, IDC_STATIC4, LabelD3);
	DDX_Control(pDX, IDC_STATIC10, LabelD2);
	DDX_Control(pDX, IDC_STATIC5, LavelD4);
	DDX_Control(pDX, IDC_NO, Button_HotFix);
}


BEGIN_MESSAGE_MAP(CXPWarning, CDialog)
	ON_STN_CLICKED(IDC_STATIC4, &CXPWarning::OnStnClickedStatic4)
	ON_BN_CLICKED(IDC_CLOSE, &CXPWarning::OnBnClickedClose)
	ON_BN_CLICKED(IDC_NO, &CXPWarning::OnBnClickedNo)
	ON_BN_CLICKED(IDC_YES, &CXPWarning::OnBnClickedYes)
	ON_STN_CLICKED(IDC_STATICWP, &CXPWarning::OnStnClickedStaticwp)
	ON_WM_CLOSE()
END_MESSAGE_MAP()



// CXPWarning message handlers


void CXPWarning::OnStnClickedStatic4()
{
	// TODO: Add your control notification handler code here
}

void CXPWarning::OnBnClickedClose()
{
	ResultX = 0;
	CDialog::EndDialog(0);
}

void CXPWarning::OnBnClickedNo()
{
	ResultX = 1;
    CDialog::EndDialog(1);
	
}

void CXPWarning::OnBnClickedYes()
{
	ResultX = 2;
    CDialog::EndDialog(2);
}

void CXPWarning::OnStnClickedStaticwp()
{
	// TODO: Add your control notification handler code here
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

	if (this->HotFixDisable == 1) this->Button_HotFix.EnableWindow(TRUE);
	if (this->HotFixDisable == 0) this->Button_HotFix.EnableWindow(FALSE);
	
	//BI.EnableWindow(TRUE);
	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}


