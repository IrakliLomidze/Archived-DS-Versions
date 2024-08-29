using System;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4.UI
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
