#pragma once


// WhiteStatic

class CWhiteStatic : public CStatic
{
	DECLARE_DYNAMIC(CWhiteStatic)

public:
	CWhiteStatic();
	virtual ~CWhiteStatic();
	int isBold;
protected:
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnPaint();
};


