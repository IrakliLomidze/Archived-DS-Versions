#pragma once
#include "whitestatic.h"
#include "afxwin.h"
#include "whitepanel.h"
#include "colorstatic.h"


// CXPWarning dialog

class CXPWarning : public CDialog
{
	DECLARE_DYNAMIC(CXPWarning)

public:
	CXPWarning(CWnd* pParent = NULL);   // standard constructor
	virtual ~CXPWarning();

// Dialog Data
	enum { IDD = IDD_XPD };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedClose();
	afx_msg void OnClose();
    virtual BOOL OnInitDialog();

	afx_msg void OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized);
	CWhitePanel Panel2;
	CWhiteStatic LabelSupport1;
	CWhiteStatic Label1;
	CWhiteStatic Label2;
	CWhiteStatic Label3;
	CWhiteStatic Label4;
	CWhiteStatic Label5;
	CWhiteStatic Label6;
	CWhiteStatic Label7;
};
