#pragma once


// CWhiteCheck

class CWhiteCheck : public CCheckListBox
{
	DECLARE_DYNAMIC(CWhiteCheck)

public:
	CWhiteCheck();
	virtual ~CWhiteCheck();

protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg HBRUSH CtlColor(CDC* pDC, UINT nCtlColor);
	CBrush* m_b;
	
};


