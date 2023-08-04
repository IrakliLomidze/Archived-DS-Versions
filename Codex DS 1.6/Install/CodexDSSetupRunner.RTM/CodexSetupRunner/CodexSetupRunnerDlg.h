
// CodexSetupRunnerDlg.h : header file
//

#pragma once


// CCodexSetupRunnerDlg dialog
class CCodexSetupRunnerDlg : public CDialogEx
{
// Construction
public:
	CCodexSetupRunnerDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_CODEXSETUPRUNNER_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
};
