// *************************************************************************************
// ** DS 1.10 
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Date: 2023-04-05
// ** Version 1.1


using System;
using System.Windows.Forms;

namespace ILG.DS.Profile.UI
{
    public class WaitCursor : IDisposable
    {
        public WaitCursor(bool appStarting = false, bool applicationCursor = false)
        {
            // Wait
            Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
            if (applicationCursor) Application.UseWaitCursor = true;
        }

        public void Dispose()
        {
            // Reset
            Cursor.Current = Cursors.Default;
            Application.UseWaitCursor = false;
        }
    }
}
