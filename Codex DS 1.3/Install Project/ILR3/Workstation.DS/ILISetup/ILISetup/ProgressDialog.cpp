// ProgressDialog.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "ProgressDialog.h"
#include "afxdialogex.h"


// ProgressDialog dialog

IMPLEMENT_DYNAMIC(ProgressDialog, CDialogEx)

ProgressDialog::ProgressDialog(CWnd* pParent /*=NULL*/)
	: CDialogEx(ProgressDialog::IDD, pParent)
{
	//BOOL bEnable = TRUE;     // To enable
    BOOL bEnable = FALSE;    // To disable

    UINT menuf = bEnable ? (MF_BYCOMMAND) : (MF_BYCOMMAND | MF_GRAYED | MF_DISABLED);

   CMenu* pSM = GetSystemMenu(FALSE);
   if(pSM)
       {
         pSM->EnableMenuItem(SC_CLOSE, menuf);
       }
}

ProgressDialog::~ProgressDialog()
{
}

void ProgressDialog::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(ProgressDialog, CDialogEx)
END_MESSAGE_MAP()


// ProgressDialog message handlers
