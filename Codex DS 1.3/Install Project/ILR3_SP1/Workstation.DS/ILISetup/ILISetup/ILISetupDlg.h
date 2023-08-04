// ILISetupDlg.h : header file
//

#pragma once
#include "whitepanel.h"
#include "hbutton.h"
#include "whitestatic.h"
#include "whitecheck.h"
#include "afxwin.h"


// CILISetupDlg dialog
class CILISetupDlg : public CDialog
{
// Construction
public:
	CILISetupDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_ILISETUP_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	CWhitePanel Panel1;
	CHButton B7;
	CHButton GUN;
	CHButton G8N;
	CHButton Help;
	CWhiteStatic DES;
	afx_msg void OnBnClickedButton7();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedButton4();
	afx_msg void OnBnClickedButton5();
	CWhiteStatic m_Static10;
	CWhiteStatic m_static11;
	CHButton m_ViewReadme;
	bool m_force;
	int SQLExpress; // Install Hot Fix 2; Install Older Version 1; Install SP3 0;
	//CButton Check1;
	CWhiteCheck Check1;
	afx_msg void OnBnClickedButton6();
	bool ForceCheck;
	afx_msg void OnBnClickedCheck1();
	CWhiteStatic FV1;
	int FC;
	

	CWhiteStatic staticad;
	CHButton AdobeInstall;
};
