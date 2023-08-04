// WhiteStatic.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "WhiteStatic.h"
#include ".\whitestatic.h"


// WhiteStatic

IMPLEMENT_DYNAMIC(CWhiteStatic, CStatic)
CWhiteStatic::CWhiteStatic()
{
}

CWhiteStatic::~CWhiteStatic()
{
}


BEGIN_MESSAGE_MAP(CWhiteStatic, CStatic)
	ON_WM_PAINT()
END_MESSAGE_MAP()



// WhiteStatic message handlers


void CWhiteStatic::OnPaint()
{
	CPaintDC dc(this); // device context for painting
	dc.SetBkColor(RGB(255,255,255));
	CRect client_rect;
	GetClientRect(client_rect);
	dc.FillSolidRect(client_rect,RGB(255,255,255));
	CString strText = _T("");
	GetWindowText(strText);
	int nFormat=0;
	nFormat |= DT_LEFT;
	nFormat |= DT_WORDBREAK;

	LOGFONT lgfnt;
	CFont *t = GetFont();
	CFont *p = new CFont;
	t->GetLogFont(&lgfnt);
		//lgfnt.lfUnderline = 1;
	lgfnt.lfWeight = 700;
	p->CreateFontIndirect(&lgfnt);
	dc.SelectObject(p);

    dc.DrawText(strText, client_rect, nFormat);

	// TODO: Add your message handler code here
	// Do not call CStatic::OnPaint() for painting messages
}
