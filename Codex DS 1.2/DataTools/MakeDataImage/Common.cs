using System;
using System.IO;



namespace ILG
{
	namespace Codex
	{

		namespace Codex2007
		{/// <summary>
			/// Summary description for Common.
			/// </summary>
			public class Common
			{
				static public String toPath;
				static public String FromPath;
				static public String Server;
				static public String CurDir;
				static public bool   Copying;
				
				
				

				static Common()
				{
					CurDir = System.Environment.CurrentDirectory;
				
				}
			}
		}
	}
}