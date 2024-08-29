/*-------------------------------------------------------------------------------------------------------------
** module:        TX Text Control Words
** description:   This file contains the implementation of the mail merge functions.
**
** copyright:     © Text Control GmbH
** author:        T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using TXTextControl.DocumentServer.Fields;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;

namespace ILG.Codex.CodexR4.DocumentForm
{
	public partial class BaseTxDocument : Form {

		private FieldDisplayMode _fldDispModeCur;
		private bool _bHighlightFields = true;

		private const string MsgNoFields = "The document does not contain any fields.";

		private enum FieldDisplayMode {
			ShowFieldText,
			ShowFieldCodes,
		}

		/// <summary>
		/// Sets document wide default merge field and merge block 
		/// (SubTextPart) properties.
		/// </summary>
		internal void SetDefaultFieldAndBlockProperties() {
			try {
				foreach (TXTextControl.IFormattedText part in textControl.TextParts) {
					foreach (TXTextControl.ApplicationField fld in part.ApplicationFields) {
						if ((fld.TypeName == "IF") && (fld.Length == 0)) {
							// Show invisible IF fields
							fld.Text = "{IF}";
						}
						fld.Editable = false;
						fld.DoubledInputPosition = true;
						fld.ShowActivated = _bHighlightFields;
					}
				}
			}
			catch { }
		}

		private MergeField InsertMergeField(string strName) {
			MergeField mf = CreateMergeField(strName);
			textControl.ApplicationFields.Add(mf.ApplicationField);
			return mf;
		}

		private MergeField CreateMergeField(string strName) {
			var mf = new MergeField();

			mf.ApplicationField.DoubledInputPosition = true;
			mf.ApplicationField.Editable = false;
			mf.ApplicationField.ShowActivated = _bHighlightFields;

			if (strName != string.Empty) {
				mf.Name = strName;

				switch (_fldDispModeCur) {
					case FieldDisplayMode.ShowFieldCodes:
						string strSwitches
							= (mf.ApplicationField.Parameters != null) ? string.Join(" ", mf.ApplicationField.Parameters) : "";
						mf.Text = "{" + mf.TypeName + strSwitches + " }";
						break;

					case FieldDisplayMode.ShowFieldText:
						mf.Text = "«" + strName + "»";
						break;
				}
			}

			return mf;
		}

		private void InsertMergeField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newMergeField = CreateMergeField("");
			if (newMergeField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				newMergeField.Text = "«" + newMergeField.Name + "»";
				textControl.ApplicationFields.Add(newMergeField.ApplicationField);
			}
		}

		private void InsertIfField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newIfField = new IfField();
			newIfField.ApplicationField.DoubledInputPosition = true;
			newIfField.ApplicationField.Editable = false;
			newIfField.ApplicationField.ShowActivated = _bHighlightFields;

			if (newIfField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				textControl.ApplicationFields.Add(newIfField.ApplicationField);
			}
		}

		private void InsertNextField() {
			var newField = new NextField();
			newField.ApplicationField.DoubledInputPosition = true;
			newField.ApplicationField.Editable = false;
			newField.ApplicationField.ShowActivated = _bHighlightFields;

			textControl.ApplicationFields.Add(newField.ApplicationField);
		}

		private void InsertNextIfField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newField = new NextIfField();
			newField.ApplicationField.DoubledInputPosition = true;
			newField.ApplicationField.Editable = false;
			newField.ApplicationField.ShowActivated = _bHighlightFields;

			if (newField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				textControl.ApplicationFields.Add(newField.ApplicationField);
			}
		}

		private void InsertDateField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newDateField = new DateField() { Format = "dd.MM.yyyy" };
			newDateField.ApplicationField.DoubledInputPosition = true;
			newDateField.ApplicationField.Editable = false;
			newDateField.ApplicationField.ShowActivated = _bHighlightFields;

			if (newDateField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				textControl.ApplicationFields.Add(newDateField.ApplicationField);
			}
		}

		private void InsertIncludeTextField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newIncludeTextField = new IncludeText();
			newIncludeTextField.ApplicationField.DoubledInputPosition = true;
			newIncludeTextField.ApplicationField.Editable = false;
			newIncludeTextField.ApplicationField.ShowActivated = _bHighlightFields;

			if (newIncludeTextField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				textControl.ApplicationFields.Add(newIncludeTextField.ApplicationField);
			}
		}

		private void DeleteField() {
			try {
				var field = textControl.ApplicationFields.GetItem();
				if (field == null) return;
				textControl.ApplicationFields.Remove(field);
			}
			catch (Exception exc) {
				MessageBox.Show(
					exc.Message, ProductName,
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private bool FieldAtCurrentPos() {
			try {
				var field = textControl.ApplicationFields.GetItem();
				return field != null;
			}
			catch { return false; }
		}

		private void FieldSettings() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;
			try {
				var field = textControl.ApplicationFields.GetItem();
				if (field == null) {
					MessageBox.Show(
						"There is no field at the current input position.", ProductName,
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				switch (field.TypeName) {
					case MergeField.TYPE_NAME:
						var mergeField = new MergeField(field);
						mergeField.ShowDialog(this, bRTL);
						break;

					case DateField.TYPE_NAME:
						var dateField = new DateField(field);
						dateField.ShowDialog(this, bRTL);
						break;

					case IncludeText.TYPE_NAME:
						var includeTextField = new IncludeText(field);
						includeTextField.ShowDialog(this, bRTL);
						break;

					case IfField.TYPE_NAME:
						var ifField = new IfField(field);
						ifField.ShowDialog(this, bRTL);
						break;

					case NextIfField.TYPE_NAME:
						var nextIf = new NextIfField(field);
						nextIf.ShowDialog(this, bRTL);
						break;
				}
			}
			catch { }
		}

		private void UpdateFieldValues() {
			if (textControl == null) return;

			foreach (TXTextControl.IFormattedText textPart in textControl.TextParts) {
				foreach (TXTextControl.ApplicationField appField in textPart.ApplicationFields) {
					UpdateFieldValues(appField);
				}
			}
		}

		private void UpdateFieldValues(TXTextControl.ApplicationField appField) {
			try {
				switch (_fldDispModeCur) {
					case FieldDisplayMode.ShowFieldCodes:
						ShowFieldCodes(appField);
						break;

					case FieldDisplayMode.ShowFieldText:
						ShowFieldText(appField);
						break;
				}
			}
			catch { }
		}

		private static void ShowFieldCodes(TXTextControl.ApplicationField appField) {
			string fieldSwitches
				= (appField.Parameters != null) ? string.Join(" ", appField.Parameters) : "";
			appField.Text = "{ " + appField.TypeName + " " + fieldSwitches + " }";
		}

		private static void ShowFieldText(TXTextControl.ApplicationField appField) {
			switch (appField.TypeName) {
				case MergeField.TYPE_NAME:
					var mergeField = new MergeField(appField);
					mergeField.Text = "«" + mergeField.Name + "»";
					break;

				case IfField.TYPE_NAME:
					var ifField = new IfField(appField);
					ifField.Text = "{" + ifField.TypeName + "}";
					break;

				case DateField.TYPE_NAME:
					var dateField = new DateField(appField);
					dateField.Text = "{" + dateField.TypeName + "}";
					break;

				case IncludeText.TYPE_NAME:
					var includeText = new IncludeText(appField);
					includeText.ApplicationField.Text = "{" + includeText.TypeName + "}";
					break;

				case NextField.TYPE_NAME:
					var next = new NextField(appField);
					next.ApplicationField.Text = "{" + next.TypeName + "}";
					break;

				case NextIfField.TYPE_NAME:
					var nextIf = new NextIfField(appField);
					nextIf.ApplicationField.Text = "{" + nextIf.TypeName + "}";
					break;
			}
		}

		private bool DocumentContainsFields() {
			foreach (TXTextControl.IFormattedText textPart in textControl.TextParts) {
				if ((textPart.ApplicationFields != null) && (textPart.ApplicationFields.Count > 0)) return true;
			}

			return false;
		}

		private bool DocumentContainsNamedObjects() {
			foreach (TXTextControl.IFormattedText textPart in textControl.TextParts) {
				foreach (TXTextControl.Image img in textPart.Images) {
					if (!string.IsNullOrEmpty(img.Name)) return true;
				}
			}

			foreach (TXTextControl.DataVisualization.ChartFrame chart in textControl.Charts) {
				if (!string.IsNullOrEmpty(chart.Name)) return true;
			}

			foreach (TXTextControl.DataVisualization.BarcodeFrame barcode in textControl.Barcodes) {
				if (!string.IsNullOrEmpty(barcode.Name)) return true;
			}

			return false;
		}

		private string StreamTypeToFileExt(TXTextControl.StreamType streamType) {
			switch (streamType) {
				case TXTextControl.StreamType.AdobePDF:
				case TXTextControl.StreamType.AdobePDFA:
					return "pdf";

				case TXTextControl.StreamType.CascadingStylesheet:
					return "css";

				case TXTextControl.StreamType.HTMLFormat:
					return "html";

				case TXTextControl.StreamType.InternalFormat:
				case TXTextControl.StreamType.InternalUnicodeFormat:
					return "tx";

				case TXTextControl.StreamType.MSWord:
					return "doc";

				case TXTextControl.StreamType.PlainAnsiText:
				case TXTextControl.StreamType.PlainText:
					return "txt";

				case TXTextControl.StreamType.RichTextFormat:
					return "rtf";

				case TXTextControl.StreamType.WordprocessingML:
					return "docx";

				case TXTextControl.StreamType.XMLFormat:
					return "xml";
			}

			return string.Empty;
		}

		private static TXTextControl.StreamType FileExtToStreamType(string fileExt) {
			TXTextControl.StreamType streamType = TXTextControl.StreamType.RichTextFormat;

			switch (fileExt.ToLower()) {
				case "pdf":
					streamType = TXTextControl.StreamType.AdobePDF;
					break;

				case "rtf":
					streamType = TXTextControl.StreamType.RichTextFormat;
					break;

				case "docx":
					streamType = TXTextControl.StreamType.WordprocessingML;
					break;

				case "doc":
					streamType = TXTextControl.StreamType.MSWord;
					break;

				case "html":
					streamType = TXTextControl.StreamType.HTMLFormat;
					break;

				case "txt":
					streamType = TXTextControl.StreamType.PlainText;
					break;

				case "tx":
					streamType = TXTextControl.StreamType.InternalUnicodeFormat;
					break;

				case "xml":
					streamType = TXTextControl.StreamType.XMLFormat;
					break;
			}
			return streamType;
		}
	}
}
