using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace ILG.Codex.CodexR4
{
    
        public class PageSetup
        {
            //
            // ShowDialog
            //
            // Display a PageSetupDialog to let the user set page size, page margins and orientation
            //
            public void ShowDialog(TXTextControl.TextControl tx)
            {
                //bool Landscape = (tx.PageSize.Width > tx.PageSize.Height);
                //PageSetupDialog psDlg = new PageSetupDialog();

                //try
                //{
                //    psDlg.PageSettings = new PageSettings();
                //    psDlg.PageSettings.PaperSize = GetTxPaperSize(tx.PageSize, Landscape);
                //    psDlg.PageSettings.Landscape = Landscape;
                    

                //    if (System.Globalization.RegionInfo.CurrentRegion.IsMetric)
                //    {
                //        // Workaround for a .NET framework issue: the dialog box should always 
                //        // accept 1/100 inch, but it actually depends on the regional settings 
                //        // which measurement is used.
                //        psDlg.PageSettings.Margins = new Margins(
                //            (int)(tx.PageMargins.Left * 2.54), (int)(tx.PageMargins.Right * 2.54),
                //            (int)(tx.PageMargins.Top * 2.54), (int)(tx.PageMargins.Bottom * 2.54));
                //    }
                //    else
                //    {
                //        psDlg.PageSettings.Margins = new Margins(
                //            tx.PageMargins.Left, tx.PageMargins.Right,
                //            tx.PageMargins.Top, tx.PageMargins.Bottom);
                //    }
                //    psDlg.PageSettings.Landscape = Landscape;

                //    if (psDlg.ShowDialog() == DialogResult.OK)
                //    {
                //        Landscape = psDlg.PageSettings.Landscape;
                //        if (Landscape)
                //            tx.PageSize = new Size(psDlg.PageSettings.PaperSize.Height, psDlg.PageSettings.PaperSize.Width);
                //        else
                //            tx.PageSize = new Size(psDlg.PageSettings.PaperSize.Width, psDlg.PageSettings.PaperSize.Height);

                //        tx.PageMargins = new TXTextControl.PageMargins(psDlg.PageSettings.Margins.Left, psDlg.PageSettings.Margins.Top, psDlg.PageSettings.Margins.Right, psDlg.PageSettings.Margins.Bottom);
                //    }
                //}
                //catch (Exception e)
                //{
                //    System.Windows.Forms.MessageBox.Show("Error setting page size or margins.\r\n\r\n" + e.ToString());
                //}

            }

            //
            // GetTxPaperSize
            // 
            // Find a paper size that matches Text Control//s current page size settings. 
            //
            private PaperSize GetTxPaperSize(Size DocSize, bool Landscape)
            {
                PrintDocument pdoc = new PrintDocument();

                // Swap values if Landscape.
                if (Landscape)
                    DocSize = new Size(DocSize.Height, DocSize.Width); // swap

                // Find a matching page size in the printer//s paper size collection
                foreach (PaperSize ps in pdoc.PrinterSettings.PaperSizes)
                {
                    if (Math.Abs(ps.Height - DocSize.Height) == 0 && Math.Abs(ps.Width - DocSize.Width) == 0)
                        return ps;
                }

                return null;
            }
        }

}
