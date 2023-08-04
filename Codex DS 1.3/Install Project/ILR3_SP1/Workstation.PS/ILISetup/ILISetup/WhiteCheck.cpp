// WhiteCheck.cpp : implementation file
//

#include "stdafx.h"
#include "ILISetup.h"
#include "whitecheck.h"
#include ".\whitecheck.h"


// CWhiteCheck

IMPLEMENT_DYNAMIC(CWhiteCheck, CCheckListBox)
CWhiteCheck::CWhiteCheck()
{
	m_b = new CBrush(RGB(255, 255, 255));
}

CWhiteCheck::~CWhiteCheck()
{ 
	delete m_b;
}


BEGIN_MESSAGE_MAP(CWhiteCheck, CCheckListBox)
	//ON_WM_CTLCOLOR_REFLECT()
	ON_WM_CTLCOLOR()
END_MESSAGE_MAP()



// CWhiteCheck message handlers


//HBRUSH CWhiteCheck::CtlColor(CDC* /*pDC*/, UINT /*nCtlColor*/)
HBRUSH CWhiteCheck::CtlColor(CDC *pDC, UINT nCtlColor)

{
	// TODO:  Change any attributes of the DC here
	//pDC->SetBkColor(RGB(255,255,255));
	//COLORREF f = rgb;
	//CBrush m_b;
	//m_b.CreateSolidBrush(RGB(255,255,255));
	// TODO:  Return a non-NULL brush if the parent's handler should not be called
	
	//return NULL;
	return (HBRUSH)(m_b->GetSafeHandle());
}
