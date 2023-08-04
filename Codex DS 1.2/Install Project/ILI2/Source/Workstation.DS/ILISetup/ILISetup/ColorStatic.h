#pragma once


// CColorStatic

class CColorStatic : public CStatic
{
	DECLARE_DYNAMIC(CColorStatic)

public:
	CColorStatic();
	virtual ~CColorStatic();
	void SetBackgroundColor(COLORREF rgb, BOOL bRedraw = TRUE);
	void SetTextColor(COLORREF rgb, BOOL bRedraw = TRUE);
	//void SetBold(BOOL bFlag, BOOL bRedraw = TRUE);
	bool nonstandarddrawing;

protected:
	//CFont		m_font;
	COLORREF	m_rgbText;
	COLORREF	m_rgbBackground;
	CBrush *	m_pBrush;
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnPaint();
};


