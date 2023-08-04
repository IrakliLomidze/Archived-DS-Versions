/*-------------------------------------------------------------------------------------------------------------
** module:			TX Text Control Words
**
** copyright:		© Text Control GmbH
** author:			T. Kummerow
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl.Drawing;
using TXTextControl.DataVisualization;
using ILG.Codex.CodexR4.Properties;

namespace ILG.Codex.CodexR4.DocumentForm
{

	public partial class BaseTxDocument
    {

		private void MnuInsert_Shapes_DropDownOpening(object sender, EventArgs e) {
            return;
			//if (_mnuInsert_Shapes_Lines.DropDownItems.Count > 0) return; // Menu items were already added

			//// Add shape menu items:

			//// "Lines": 

			//ToolStripItemCollection items = _mnuInsert_Shapes_Lines.DropDownItems;
			//AddShapeItem(items, ShapeType.Line);
			//AddShapeItem(items, ShapeType.BentConnector3);
			//AddShapeItem(items, ShapeType.CurvedConnector3);

			//// "Rectangles":

			//items = _mnuInsert_Shapes_Rectangles.DropDownItems;
			//AddShapeItem(items, ShapeType.Rectangle);
			//AddShapeItem(items, ShapeType.RoundRectangle);
			//AddShapeItem(items, ShapeType.Snip1Rectangle);
			//AddShapeItem(items, ShapeType.Snip2SameRectangle);
			//AddShapeItem(items, ShapeType.Snip2DiagonalRectangle);
			//AddShapeItem(items, ShapeType.SnipRoundRectangle);
			//AddShapeItem(items, ShapeType.Round1Rectangle);
			//AddShapeItem(items, ShapeType.Round2SameRectangle);
			//AddShapeItem(items, ShapeType.Round2DiagonalRectangle);

			//// "Basic Shapes":

			//items = _mnuInsert_Shapes_Basic.DropDownItems;
			//// AddShapeGalleryItem(basicShapes, ShapeType.TextBox);
			//AddShapeItem(items, ShapeType.Ellipse);
			//AddShapeItem(items, ShapeType.Triangle);
			//AddShapeItem(items, ShapeType.RightTriangle);
			//AddShapeItem(items, ShapeType.Parallelogram);
			//AddShapeItem(items, ShapeType.NonIsoscelesTrapezoid);
			//AddShapeItem(items, ShapeType.Diamond);
			//AddShapeItem(items, ShapeType.Pentagon);
			//AddShapeItem(items, ShapeType.Hexagon);
			//AddShapeItem(items, ShapeType.Heptagon);
			//AddShapeItem(items, ShapeType.Octagon);
			//AddShapeItem(items, ShapeType.Decagon);
			//AddShapeItem(items, ShapeType.Dodecagon);
			//AddShapeItem(items, ShapeType.Pie);
			//AddShapeItem(items, ShapeType.Chord);
			//AddShapeItem(items, ShapeType.Teardrop);
			//AddShapeItem(items, ShapeType.Frame);
			//AddShapeItem(items, ShapeType.HalfFrame);
			//AddShapeItem(items, ShapeType.Corner);
			//AddShapeItem(items, ShapeType.DiagonalStripe);
			//AddShapeItem(items, ShapeType.Plus);
			//AddShapeItem(items, ShapeType.Plaque);
			//AddShapeItem(items, ShapeType.Can);
			//AddShapeItem(items, ShapeType.Cube);
			//AddShapeItem(items, ShapeType.Bevel);
			//AddShapeItem(items, ShapeType.Donut);
			//AddShapeItem(items, ShapeType.NoSmoking);
			//AddShapeItem(items, ShapeType.BlockArc);
			//AddShapeItem(items, ShapeType.FoldedCorner);
			//AddShapeItem(items, ShapeType.SmileyFace);
			//AddShapeItem(items, ShapeType.Heart);
			//AddShapeItem(items, ShapeType.LightningBolt);
			//AddShapeItem(items, ShapeType.Sun);
			//AddShapeItem(items, ShapeType.Moon);
			//AddShapeItem(items, ShapeType.Cloud);
			//AddShapeItem(items, ShapeType.Arc);
			//AddShapeItem(items, ShapeType.BracketPair);
			//AddShapeItem(items, ShapeType.BracePair);
			//AddShapeItem(items, ShapeType.LeftBracket);
			//AddShapeItem(items, ShapeType.RightBracket);
			//AddShapeItem(items, ShapeType.LeftBrace);
			//AddShapeItem(items, ShapeType.RightBrace);

			//// "Block Arrows":

			//items = _mnuInsert_Shapes_BlockArrows.DropDownItems;
			//AddShapeItem(items, ShapeType.RightArrow);
			//AddShapeItem(items, ShapeType.LeftArrow);
			//AddShapeItem(items, ShapeType.UpArrow);
			//AddShapeItem(items, ShapeType.DownArrow);
			//AddShapeItem(items, ShapeType.LeftRightArrow);
			//AddShapeItem(items, ShapeType.UpDownArrow);
			//AddShapeItem(items, ShapeType.QuadArrow);
			//AddShapeItem(items, ShapeType.LeftRightUpArrow);
			//AddShapeItem(items, ShapeType.BentArrow);
			//AddShapeItem(items, ShapeType.UTurnArrow);
			//AddShapeItem(items, ShapeType.LeftUpArrow);
			//AddShapeItem(items, ShapeType.BentUpArrow);
			//AddShapeItem(items, ShapeType.CurvedRightArrow);
			//AddShapeItem(items, ShapeType.CurvedLeftArrow);
			//AddShapeItem(items, ShapeType.CurvedUpArrow);
			//AddShapeItem(items, ShapeType.CurvedDownArrow);
			//AddShapeItem(items, ShapeType.StripedRightArrow);
			//AddShapeItem(items, ShapeType.NotchedRightArrow);
			//AddShapeItem(items, ShapeType.HomePlate);
			//AddShapeItem(items, ShapeType.Chevron);
			//AddShapeItem(items, ShapeType.RightArrowCallout);
			//AddShapeItem(items, ShapeType.DownArrowCallout);
			//AddShapeItem(items, ShapeType.LeftArrowCallout);
			//AddShapeItem(items, ShapeType.UpArrowCallout);
			//AddShapeItem(items, ShapeType.LeftRightArrowCallout);
			//AddShapeItem(items, ShapeType.QuadArrowCallout);
			//AddShapeItem(items, ShapeType.CircularArrow);

			//// "Equation Shapes":

			//items = _mnuInsert_Shapes_Equation.DropDownItems;
			//AddShapeItem(items, ShapeType.MathPlus);
			//AddShapeItem(items, ShapeType.MathMinus);
			//AddShapeItem(items, ShapeType.MathMultiply);
			//AddShapeItem(items, ShapeType.MathDivide);
			//AddShapeItem(items, ShapeType.MathEqual);
			//AddShapeItem(items, ShapeType.MathNotEqual);

			//// "Flowchart":

			//items = _mnuInsert_Shapes_FlowChart.DropDownItems;
			//AddShapeItem(items, ShapeType.FlowChartProcess);
			//AddShapeItem(items, ShapeType.FlowChartAlternateProcess);
			//AddShapeItem(items, ShapeType.FlowChartDecision);
			//AddShapeItem(items, ShapeType.FlowChartInputOutput);
			//AddShapeItem(items, ShapeType.FlowChartPredefinedProcess);
			//AddShapeItem(items, ShapeType.FlowChartInternalStorage);
			//AddShapeItem(items, ShapeType.FlowChartDocument);
			//AddShapeItem(items, ShapeType.FlowChartMultidocument);
			//AddShapeItem(items, ShapeType.FlowChartTerminator);
			//AddShapeItem(items, ShapeType.FlowChartPreparation);
			//AddShapeItem(items, ShapeType.FlowChartManualInput);
			//AddShapeItem(items, ShapeType.FlowChartManualOperation);
			//AddShapeItem(items, ShapeType.FlowChartConnector);
			//AddShapeItem(items, ShapeType.FlowChartOffpageConnector);
			//AddShapeItem(items, ShapeType.FlowChartPunchedCard);
			//AddShapeItem(items, ShapeType.FlowChartPunchedTape);
			//AddShapeItem(items, ShapeType.FlowChartSummingJunction);
			//AddShapeItem(items, ShapeType.FlowChartOr);
			//AddShapeItem(items, ShapeType.FlowChartCollate);
			//AddShapeItem(items, ShapeType.FlowChartSort);
			//AddShapeItem(items, ShapeType.FlowChartExtract);
			//AddShapeItem(items, ShapeType.FlowChartMerge);
			//AddShapeItem(items, ShapeType.FlowChartOnlineStorage);
			//AddShapeItem(items, ShapeType.FlowChartDelay);
			//AddShapeItem(items, ShapeType.FlowChartMagneticTape);
			//AddShapeItem(items, ShapeType.FlowChartMagneticDisk);
			//AddShapeItem(items, ShapeType.FlowChartMagneticDrum);
			//AddShapeItem(items, ShapeType.FlowChartDisplay);

			//// "Stars and Banners":

			//items = _mnuInsert_Shapes_StarsBanners.DropDownItems;
			//AddShapeItem(items, ShapeType.IrregularSeal1);
			//AddShapeItem(items, ShapeType.IrregularSeal2);
			//AddShapeItem(items, ShapeType.Star4);
			//AddShapeItem(items, ShapeType.Star5);
			//AddShapeItem(items, ShapeType.Star6);
			//AddShapeItem(items, ShapeType.Star7);
			//AddShapeItem(items, ShapeType.Star8);
			//AddShapeItem(items, ShapeType.Star10);
			//AddShapeItem(items, ShapeType.Star12);
			//AddShapeItem(items, ShapeType.Star16);
			//AddShapeItem(items, ShapeType.Star24);
			//AddShapeItem(items, ShapeType.Star32);
			//AddShapeItem(items, ShapeType.Ribbon2);
			//AddShapeItem(items, ShapeType.Ribbon);
			//AddShapeItem(items, ShapeType.EllipseRibbon2);
			//AddShapeItem(items, ShapeType.EllipseRibbon);
			//AddShapeItem(items, ShapeType.VerticalScroll);
			//AddShapeItem(items, ShapeType.HorizontalScroll);
			//AddShapeItem(items, ShapeType.Wave);
			//AddShapeItem(items, ShapeType.DoubleWave);

			//// "Callouts":

			//items = _mnuInsert_Shapes_Callouts.DropDownItems;
			//AddShapeItem(items, ShapeType.WedgeRectangleCallout);
			//AddShapeItem(items, ShapeType.WedgeRoundRectangleCallout);
			//AddShapeItem(items, ShapeType.WedgeEllipseCallout);
			//AddShapeItem(items, ShapeType.CloudCallout);
			//AddShapeItem(items, ShapeType.BorderCallout1);
			//AddShapeItem(items, ShapeType.BorderCallout2);
			//AddShapeItem(items, ShapeType.BorderCallout3);
			//AddShapeItem(items, ShapeType.AccentCallout1);
			//AddShapeItem(items, ShapeType.AccentCallout2);
			//AddShapeItem(items, ShapeType.AccentCallout3);
			//AddShapeItem(items, ShapeType.Callout1);
			//AddShapeItem(items, ShapeType.Callout2);
			//AddShapeItem(items, ShapeType.Callout3);
			//AddShapeItem(items, ShapeType.AccentBorderCallout1);
			//AddShapeItem(items, ShapeType.AccentBorderCallout2);
			//AddShapeItem(items, ShapeType.AccentBorderCallout3);
		}

		private void AddShapeItem(ToolStripItemCollection items, ShapeType shapeType) {
			string text = Resources.ResourceManager.GetString("TOOLTIP_SHAPE_" + shapeType.ToString());
			var image = GetEmbeddedBitmap("Small_32bit.Shapes.shape" + shapeType.ToString().ToLower());
			var item = new ToolStripMenuItem(text, image);
			item.Tag = shapeType;   // Somehow store the shape type in the menu item object
			item.Click += ShapeMenuItem_Click;
			items.Add(item);
		}

		void ShapeMenuItem_Click(object sender, EventArgs e) {
			ShapeType shapeType;
			var item = sender as ToolStripMenuItem;
			if (item == null) return;

			try { shapeType = (ShapeType) item.Tag; }
			catch (InvalidCastException) { return; }

			InsertShape(shapeType);
		}

		private void InsertDrawingCanvas() {
			var drawing = new TXDrawingControl(7000, 4000);
			var frame = new DrawingFrame(drawing);
			textControl.Drawings.Add(
				frame, TXTextControl.HorizontalAlignment.Left, -1,
				TXTextControl.FrameInsertionMode.DisplaceText | TXTextControl.FrameInsertionMode.MoveWithText);
			frame.Activate();
		}

		private void InsertShape(ShapeType shapeType) {
			DrawingFrame frame = textControl.Drawings.GetActivatedItem();
			if (frame != null) {
				var drawing = frame.Drawing as TXDrawingControl;
				if (drawing != null && drawing.IsCanvasVisible) {
					drawing.Shapes.Add(new TXTextControl.Drawing.Shape(shapeType), ShapeCollection.AddStyle.MouseCreation);
				}
			}
			else {
				var drawing = new TXDrawingControl(7000, 4000);
				var shape = new TXTextControl.Drawing.Shape(shapeType) { AutoSize = true, Movable = false, Sizable = false };
				drawing.Shapes.Add(shape, ShapeCollection.AddStyle.Fill);

				frame = new DrawingFrame(drawing);
				textControl.Drawings.Add(frame, TXTextControl.FrameInsertionMode.AboveTheText | TXTextControl.FrameInsertionMode.MoveWithText);
			}
			frame.Activate();
		}

	}
}
