#pragma once
#include "whitestatic.h"
#include "afxwin.h"


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
	CWhiteStatic Panel1;
	CWhiteStatic Label1;
	CWhiteStatic Label2;
	CWhiteStatic Label3;
	CWhiteStatic LabelD3;
	CWhiteStatic LabelD2;
	int ResultX;
	int HotFixDisable;
	afx_msg void OnStnClickedStatic4();
	afx_msg void OnBnClickedClose();
	afx_msg void OnBnClickedNo();
	afx_msg void OnBnClickedYes();
	CWhiteStatic LavelD4;
	afx_msg void OnStnClickedStaticwp();
	CButton Button_HotFix;
	afx_msg void OnClose();
    virtual BOOL OnInitDialog();

};
