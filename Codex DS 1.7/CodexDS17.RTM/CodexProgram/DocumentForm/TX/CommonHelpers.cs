/*-------------------------------------------------------------------------------------------------------------
** module:     TX Text Control Words
**
** copyright:  © Text Control GmbH
** author:     T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using TXTextControl;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Resources;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;
using ILG.Codex.CodexR4.Properties;

namespace ILG.Codex.CodexR4.DocumentForm
{
	public partial class BaseTxDocument : Form {

		#region "  Page numbers  "

		////////private void InsertPageNumber() {
		////////	try {
		////////		object textPart = textControl.TextParts.GetItem();
		////////		if (!(textPart is HeaderFooter)) return;

		////////		var hdrFtr = (HeaderFooter) textPart;

		////////		var pgNumFld = new PageNumberField {
		////////			StartNumber = 1,
		////////			Editable = false,
		////////			DoubledInputPosition = true,
		////////			ShowActivated = true,
		////////		};
		////////		hdrFtr.PageNumberFields.Add(pgNumFld);
		////////	}
		////////	catch (Exception ex) {
		////////		// Display information if feature not enabled in current version
		////////		MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		////////		return;
		////////	}
		////////}

		////////private void RemovePageNumbers() {
		////////	Section sectCur = null;

		////////	try {
		////////		sectCur = textControl.Sections.GetItem();
		////////		if (sectCur == null) return;

		////////		foreach (HeaderFooter hdrFtr in sectCur.HeadersAndFooters) {
		////////			hdrFtr.PageNumberFields.Clear(false);
		////////		}
		////////	}
		////////	catch (Exception ex) {
		////////		// Display information if feature not enabled in current version
		////////		MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		////////	}
		////////}

		#endregion // Page Numbers


		#region "  Headers / Footers  "

		////////private bool HeaderExists() {
		////////	if (textControl == null) return false;

		////////	try {
		////////		return ((textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) != null)
		////////						|| (textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) != null));
		////////	}
		////////	catch { }

		////////	return false;
		////////}

		////////private bool FooterExists() {
		////////	if (textControl == null) return false;

		////////	try {
		////////		return ((textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Footer) != null)
		////////						|| (textControl.Sections.GetItem().HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageFooter) != null));
		////////	}
		////////	catch { }

		////////	return false;
		////////}

		#endregion // Headers / Footers


		#region "  Application Icon  "

		/// <summary>
		/// Returns the Application's main icon (In this case "tx.ico" in the folder "Icons")
		/// </summary>
		internal static Icon GetAppIcon() {
			var asm = Assembly.GetExecutingAssembly();
			return new Icon(asm.GetManifestResourceStream("TX_Text_Control_Words.Icons.tx.ico"));
		}

		#endregion // Application Icon


		#region "  Embedded Resources  "

		internal static string GetResourceByName(string resource) {
			var assembly = Assembly.GetExecutingAssembly();
			var reader = new StreamReader(assembly.GetManifestResourceStream(resource));
			return reader.ReadToEnd();
		}

		internal static byte[] GetBinaryResourceByName(string resName) {
			var buffer = new byte[4096];  // Data buffer for reading chunks from the binary stream
			Assembly asm = Assembly.GetExecutingAssembly();

			try {
				using (var msResult = new MemoryStream())
				using (var reader = new BinaryReader(asm.GetManifestResourceStream(resName))) {
					for (; ; ) {
						int bytesRead = reader.Read(buffer, 0, buffer.Length);
						if (bytesRead <= 0) break;
						msResult.Write(buffer, 0, bytesRead);
					}

					return msResult.ToArray();
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, "Binary Resources",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		/// <summary>
		/// Returns a png image from the embedded resources. Looks in "TX_Text_Control_Words.Images".
		/// A small image residing in Images/Small_32bit/Shapes/ is retrieved by calling 
		/// GetEmbeddedBitmap("Small_32bit.Shapes.shapeline") for example.
		/// </summary>
		private static Bitmap GetEmbeddedBitmap(string strImagePath) {
			Bitmap bmp;
			byte[] imageData = GetBinaryResourceByName("TX_Text_Control_Words.Images." + strImagePath + ".png");
			using (var ms = new MemoryStream(imageData)) {
				bmp = new Bitmap(ms);
			}
			var bmpCopy = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			using (Graphics g = Graphics.FromImage(bmpCopy)) {
				g.DrawImage(bmp, 0, 0);
			}
         return bmpCopy;
		}

		private void SetShapeMenuItemResources() {
			//_mnuFormat_Shape.Image =
			//_mnuInsert_Shapes.Image = GetEmbeddedBitmap("Small_32bit.Shapes.shapestar5");
			//_mnuInsert_Shapes_Lines.Image = GetEmbeddedBitmap("Small_32bit.Shapes.shapeline");
			//_mnuInsert_Shapes_Lines.Text = Resources.ResourceManager.GetString("HEADER_LinesCategory");
			//_mnuInsert_Shapes_Rectangles.Image = GetEmbeddedBitmap("Small_32bit.Shapes.shaperectangle");
			//_mnuInsert_Shapes_Rectangles.Text = Resources.ResourceManager.GetString("HEADER_RectanglesCategory");
			//_mnuInsert_Shapes_Basic.Image = GetEmbeddedBitmap("Small_32bit.Shapes.shapeellipse");
			//_mnuInsert_Shapes_Basic.Text = Resources.ResourceManager.GetString("HEADER_BasicShapesCategory");
			//_mnuInsert_Shapes_BlockArrows.Image = GetEmbeddedBitmap("Small_32bit.Shapes.shaperightarrow");
			//_mnuInsert_Shapes_BlockArrows.Text = Resources.ResourceManager.GetString("HEADER_BlockArrowsCategory");
			//_mnuInsert_Shapes_Equation.Image = GetEmbeddedBitmap("Small_32bit.Shapes.shapemathequal");
			//_mnuInsert_Shapes_Equation.Text = Resources.ResourceManager.GetString("HEADER_EquationShapesCategory");
			//_mnuInsert_Shapes_FlowChart.Image = GetEmbeddedBitmap("Small_32bit.Shapes.shapeflowchartmultidocument");
			//_mnuInsert_Shapes_FlowChart.Text = Resources.ResourceManager.GetString("HEADER_FlowChartCategory");
			//_mnuInsert_Shapes_StarsBanners.Image = GetEmbeddedBitmap("Small_32bit.Shapes.shapestar7");
			//_mnuInsert_Shapes_StarsBanners.Text = Resources.ResourceManager.GetString("HEADER_StarsAndBannersCategory");
			//_mnuInsert_Shapes_Callouts.Image = GetEmbeddedBitmap("Small_32bit.Shapes.shapewedgerectanglecallout");
			//_mnuInsert_Shapes_Callouts.Text = Resources.ResourceManager.GetString("HEADER_CalloutsCategory");
		}


		#endregion // Embedded Resources


		#region "  Hyperlinks  "

		////////private void OpenHyperlink(string strTarget) {
		////////	if (strTarget == "") return;

		////////	try {
		////////		Uri uriTarget = new Uri(strTarget, UriKind.RelativeOrAbsolute);
		////////		if (!uriTarget.IsAbsoluteUri) {
		////////			throw new Exception("Only absolute file paths / links are supported.");
		////////		}

		////////		if (uriTarget.IsFile) {
		////////			// Remove any fragment.
		////////			// uriTarget.GetLeftPart(UriPartial.Path) has no effect because the .NET Uri class
		////////			// does not work correct with file URIs containing any query or fragment part.

		////////			strTarget = uriTarget.LocalPath;
		////////			int nPos = strTarget.IndexOf("#");
		////////			if (nPos != -1) {
		////////				strTarget = strTarget.Substring(0, nPos);
		////////			}
		////////		}
		////////		else if (uriTarget.Scheme != Uri.UriSchemeHttp && uriTarget.Scheme != Uri.UriSchemeHttps) {
		////////			strTarget = uriTarget.GetLeftPart(UriPartial.Path);
		////////		}

		////////		if (uriTarget.IsFile && IsMyFile(strTarget)) {
		////////			OpenFileInNewInstance(strTarget);
		////////		}
		////////		else {
		////////			System.Diagnostics.Process.Start(strTarget);
		////////		}
		////////	}
		////////	catch (Exception ex) {
		////////		string msg = ex.Message;
		////////		if (!msg.EndsWith(".")) msg += ".";
		////////		MessageBox.Show("Could not open link / file path. " + msg, "Hyperlink", MessageBoxButtons.OK, MessageBoxIcon.Error);
		////////	}
		////////}

		private void OpenFileInNewInstance(string strTarget) {
			// Check if file exists and show message box if not
			if (!File.Exists(strTarget)) {
				MessageBox.Show("File \"" + strTarget + "\" does not exist.", "Hyperlink", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Get running demo's exe path
			string exePath = Assembly.GetEntryAssembly().Location;

			// Start new demo instance
			var process = new Process();
			process.StartInfo.FileName = exePath;
			process.StartInfo.Arguments = "\"" + strTarget + "\"";
			process.Start();
		}

		/// <summary>
		/// Checks if file type is rtf, doc, docx or tx
		/// </summary>
		private bool IsMyFile(string strTarget) {
			string strExt = Path.GetExtension(strTarget).ToLower();

			switch (strExt) {
				case ".rtf":
				case ".doc":
				case ".docx":
				case ".tx":
					return true;
			}

			return false;
		}

		#endregion // Hyperlinks
	}
}
