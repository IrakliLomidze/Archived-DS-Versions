// WhitePanel.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "WhitePanel.h"
#include ".\whitepanel.h"


// CWhitePanel

IMPLEMENT_DYNAMIC(CWhitePanel, CStatic)
CWhitePanel::CWhitePanel()
{
}

CWhitePanel::~CWhitePanel()
{
}


BEGIN_MESSAGE_MAP(CWhitePanel, CStatic)
	ON_WM_PAINT()
END_MESSAGE_MAP()



// CWhitePanel message handlers


void CWhitePanel::OnPaint()
{
	CPaintDC dc(this); // device context for painting
	dc.SetBkColor(RGB(255,255,255));
	CRect client_rect;
	GetClientRect(client_rect);
	dc.FillSolidRect(client_rect,RGB(255,255,255));
	

	//dc.FillRect(clientrect,


	
	// TODO: Add your message handler code here
	// Do not call CStatic::OnPaint() for painting messages
}
