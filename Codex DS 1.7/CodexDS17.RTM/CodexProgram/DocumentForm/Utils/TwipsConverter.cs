/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using TXTextControl;

namespace TX_Text_Control_Words.Utils {

	/*----------------------------------------------------------------------------------------------------------
	** class TwipsConverter
	**		Capsulates methods for converting twips to/from another measurement.
	**--------------------------------------------------------------------------------------------------------*/
	static class TwipsConverter {

		/*-------------------------------------------------------------------------------------------------------
		** DotNet2Twips method
		**		Converts a value in the specified unit to a value in twips.
		**-----------------------------------------------------------------------------------------------------*/
		internal static int DotNet2Twips(double val, MeasuringUnit unit) {
			switch (unit) {
				case MeasuringUnit.CentiInch: return MilliInch2Twips(val);
				case MeasuringUnit.Millimeter: return Millimeters2Twips(val);
				case MeasuringUnit.Centimeter: return Centimeters2Twips(val);
				case MeasuringUnit.Point: return (int)Math.Round(val * 20);
				case MeasuringUnit.StandardWPF: return WPF2Twips(val);
				case MeasuringUnit.Twips: return (int)Math.Round(val);
			}
			return 0;
		}


		/*-------------------------------------------------------------------------------------------------------
		** MilliInch2Twips method
		**		 Converts a value in 1/100 inch to a value in twips.
		**-----------------------------------------------------------------------------------------------------*/
		internal static int MilliInch2Twips(double val) { return (int)Math.Round(val * 14.4); }	// 1102, N492


		/*-------------------------------------------------------------------------------------------------------
		** Millimeters2Twips method
		**		Converts a value in mm to a value in twips.
		**-----------------------------------------------------------------------------------------------------*/
		internal static int Millimeters2Twips(double val) { return (int)Math.Round(val * 1440 / 25.4); }


		/*-------------------------------------------------------------------------------------------------------
		** Centimeters2Twips method
		**		Converts a value in mm to a value in twips.
		**-----------------------------------------------------------------------------------------------------*/
		internal static int Centimeters2Twips(double val) { return (int)Math.Round(val * 1440 / 2.54); }


		/*-------------------------------------------------------------------------------------------------------
		** WPF2Twips method
		**		Converts device independent WPF units (1/96 inch) to twips.
		**-----------------------------------------------------------------------------------------------------*/
		internal static int WPF2Twips(double val) { return (int)Math.Round(val * 15); }


		/*-------------------------------------------------------------------------------------------------------
		** Twips2DotNet method
		**		Converts a value in twips to the specified unit.
		**-----------------------------------------------------------------------------------------------------*/
		internal static double Twips2DotNet(int val, MeasuringUnit unit) {
			return Twips2DotNet(val, unit, 2);
		}

		internal static double Twips2DotNet(int val, MeasuringUnit unit, int iDecimals) {
			switch (unit) {
				case MeasuringUnit.CentiInch: return Math.Round((double)val * 10 / 144, iDecimals);
				case MeasuringUnit.Millimeter: return Math.Round((double)val * 25.4 / 1440, iDecimals);
				case MeasuringUnit.Centimeter: return Math.Round((double)val * 2.54 / 1440, iDecimals);
				case MeasuringUnit.Point: return Math.Round(val / 20.0, iDecimals);
				case MeasuringUnit.StandardWPF: return Math.Round(val / 15.0, iDecimals);
				case MeasuringUnit.Twips: return val;
			}
			return 0;
		}


		/*-------------------------------------------------------------------------------------------------------
		** WPF2Pt method
		**		Converts device independent WPF units (1/96 inch) to a pointsize.
		**-----------------------------------------------------------------------------------------------------*/
		internal static int WPF2Pt(double val) { return (int)Math.Round(val * 3 / 4); }
	}
}
