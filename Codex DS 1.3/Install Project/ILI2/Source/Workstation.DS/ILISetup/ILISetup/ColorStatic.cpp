// ColorStatic.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "ColorStatic.h"
#include ".\colorstatic.h"


// CColorStatic

IMPLEMENT_DYNAMIC(CColorStatic, CStatic)
CColorStatic::CColorStatic()
{
	nonstandarddrawing = false;
	m_rgbBackground = RGB(255,255,255);
	m_pBrush = new CBrush(m_rgbBackground);
		
}

void CColorStatic::SetTextColor(COLORREF rgb, BOOL bRedraw /*= TRUE*/) 
{ 
	nonstandarddrawing = true;
	m_rgbText = rgb; 
	if (bRedraw)
		RedrawWindow();
}

void CColorStatic::SetBackgroundColor(COLORREF rgb, BOOL bRedraw /*= TRUE*/) 
{ 
	nonstandarddrawing = true;
	m_rgbBackground = rgb; 
	if (m_pBrush)
	{
		m_pBrush->DeleteObject();
		delete m_pBrush;
	}
	m_pBrush = new CBrush(m_rgbBackground);
	if (bRedraw)
		RedrawWindow();
}

CColorStatic::~CColorStatic()
{
	//if (m_font.GetSafeHandle())
	//	m_font.DeleteObject();
	if (m_pBrush)
	{
		m_pBrush->DeleteObject();
		delete m_pBrush;
	}
	m_pBrush = NULL;
}


BEGIN_MESSAGE_MAP(CColorStatic, CStatic)
	ON_WM_PAINT()
END_MESSAGE_MAP()



// CColorStatic message handlers


void CColorStatic::OnPaint()
{
	CPaintDC dc(this); // device context for painting
	//if (nonstandarddrawing == false) return;

	
	dc.SaveDC();

	dc.SetTextColor(m_rgbText);
	dc.SetBkColor(m_rgbBackground);
	dc.SetBkMode(OPAQUE);
	dc.SelectObject(m_pBrush);
	m_pBrush  = new CBrush(m_rgbBackground);

	CRect rect;
	GetClientRect(rect); 
     
	//dc.SelectObject(&m_font);
	LOGFONT lgfnt;
	CFont *t = GetFont();
	CFont *p = new CFont;
	t->GetLogFont(&lgfnt);
		//lgfnt.lfUnderline = 1;
	lgfnt.lfWeight = 700;
	p->CreateFontIndirect(&lgfnt);
	dc.SelectObject(p);

		// get static's text
		CString strText = _T("");
		GetWindowText(strText);

		UINT nFormat = 0;
		DWORD dwStyle = GetStyle();

		// set DrawText format from static style settings
		if (dwStyle & SS_CENTER)
			nFormat |= DT_CENTER;
		else if (dwStyle & SS_LEFT)
			nFormat |= DT_LEFT;
		else if (dwStyle & SS_RIGHT)
			nFormat |= DT_RIGHT;

		if (dwStyle & SS_CENTERIMAGE)	// vertical centering ==> single line only
			nFormat |= DT_VCENTER | DT_SINGLELINE;
		else
			nFormat |= DT_WORDBREAK;

		//rect.left += m_nXMargin;
	//	rect.top  += m_nYMargin;
		dc.DrawText(strText, rect, nFormat);

		dc.RestoreDC(-1);
	// TODO: Add your message handler code here
	// Do not call CStatic::OnPaint() for painting messages
}
