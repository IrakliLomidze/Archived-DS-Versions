#pragma once


// CWhitePanel

class CWhitePanel : public CStatic
{
	DECLARE_DYNAMIC(CWhitePanel)

public:
	CWhitePanel();
	virtual ~CWhitePanel();

protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnPaint();
};


