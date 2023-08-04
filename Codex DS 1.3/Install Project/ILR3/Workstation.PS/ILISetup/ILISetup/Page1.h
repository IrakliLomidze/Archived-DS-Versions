#pragma once
#include "afxwin.h"

#include "WhiteStatic.h"
#include "ColorStatic.h"
#include "afxcmn.h"
#include "hbutton.h"

// CPage1 dialog

//class CPage1 : public CPropertyPage
class CPage1 : public CDialog
{
	//DECLARE_DYNAMIC(CPage1)
	//DECLARE_DYNAMIC(CDialog)

public:
	CPage1();
	virtual ~CPage1();
	CFont m_Font;
	CBrush* m_brush;
	HBRUSH OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor);
	void OnDestroy();

// Dialog Data
	enum { IDD = IDD_PAGEDIALOG1 };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	CWhiteStatic Page1_Panel1;
	CWhiteStatic BackGround;
	virtual BOOL OnInitDialog();
	CWhiteStatic Codex2007Pre;
	CStatic m_winver;
	CStatic m_MSIVER;

	int CC_Font;
	int CC_X64;
	int CC_Server;
	int CC_SQL;
	int CC_Client;
	int CC_NETFX;
	int _SQLEXPRESS;
	int _PowerShell;
	int SQLInstallMode;
	int SQLX64DetectionMode;
	afx_msg void OnNMCustomdrawProgress1(NMHDR *pNMHDR, LRESULT *pResult);
	//bool m_netfx;
	//bool m_sql2005;
	BOOL m_netfx;
	BOOL m_sql2005;
	BOOL m_sqlclient;
	CStatic C_FONTLABEL;
	void GetInformationv(void);
	afx_msg void OnBnClickedButton3();
	CProgressCtrl m_progress1;
	CButton BI;
	BOOL VCPP;
	CComboBox SQLCOMBO;
	CHButton ButtonFX;
	afx_msg void OnBnClickedButton1();
	afx_msg void OnStnClickedSqlstatic();
	CColorStatic l_InstallMode;
	BOOL SQL_Native_Client_CheckBox;
	afx_msg void OnStnClickedStaticSqlServerInstallSp();
	afx_msg void OnBnClickedStaticSqlServerInstall();
	afx_msg void OnBnClickedStaticSqlServerInstallSp();
};



static	DWORD g_dwThread;

static	HANDLE g_hThread;

void ShowBillboard(DWORD * pdwThreadId, HANDLE * phThread);

void TeardownBillboard(DWORD dwThreadId, HANDLE hThread);
DWORD WINAPI StaticThreadProc( LPVOID lpParameter );

BOOL CALLBACK BillboardProc(HWND hwndDlg, 
                            UINT message, 
                            WPARAM wParam, 
                            LPARAM lParam) ;
