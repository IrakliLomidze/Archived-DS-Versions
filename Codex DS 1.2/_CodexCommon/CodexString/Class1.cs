using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ILG.Codex.Strings
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CodexString
	{
		static public bool CheckNumStr(String Str)
		{  
			Regex r = new Regex(",");
			String[] strx = r.Split(Str);
			bool result = false;
			Regex r2 = new Regex("-");
			int first;
			int second;
			foreach(String a in strx)
			{
				String[] strz = r2.Split(a);
								
				if (strz.Length > 2) { result = false; break;}
				

				if (strz.Length == 2)  
				{
					try
					{
						first = Int32.Parse(strz[0].Trim());
						second = Int32.Parse(strz[1].Trim());
					}
					catch ( FormatException e)
					{ result = false; break; }
					catch ( OverflowException e)
					{ result = false; break;  }
					
					if (first > second ) {result = false; break;}
					result = true;
					
				}
				else
				{
					try
					{
						int n = Int32.Parse(strz[0].Trim());
					}
					catch ( FormatException e)
					{ result = false; break; }
					catch ( OverflowException e)
					{ result = false; break; }
					result = true;
				}
			} // loop
			return result;

		}

		static public String CaptionAnaliser(String Str,String FieldName ,String Scope)
		{
			Regex r = new Regex(",");
			Regex rsmall = new Regex("[+]");
			String[] strx = r.Split(Str);
			StringBuilder StrS = new StringBuilder("");
			StringBuilder Strsmall = new StringBuilder("");
			StringBuilder Item = new StringBuilder("");

			for(int i=0;i<strx.Length;i++)
			{
				if (strx[i].Trim() != "") 
				{ 
					String[] strxsmall = rsmall.Split(strx[i]);
					Item.Remove(0,Item.Length);
				 
					for(int j=0;j<strxsmall.Length;j++)
					{
                     
						if (strxsmall[j].Trim() != "")
						{   String L = " LIKE N'%";
							String ST = strxsmall[j].Trim();
							if (strxsmall[j].Trim()[0] == '_') 
							{	L = " NOT LIKE N'%";
								ST = ST.Substring(1,ST.Length-1);
							}
							if ( j !=0 ) Item.Append(" and ("+FieldName+L+ST+"%'"+") "); 
							else Item.Append(" ("+FieldName+L+ST+"%'"+") ") ;
						}
					  
					}
				  
					if (Item.ToString().Trim() != "")			  
						if ( i !=0 )  StrS.Append(" or ("+Item+") "); 
						else StrS.Append(" ("+Item+") ") ;
				     
				}

			}
				

			return StrS.ToString();;
		}
		static public String NumAnaliser(String Str,String FieldName ,String Scope)
		{
			Regex r = new Regex(",");
			Regex r2 = new Regex("-");
			String[] g = r.Split(Str);
			StringBuilder StrS = new StringBuilder("");
			StringBuilder Strsmall = new StringBuilder("");
			StringBuilder Item = new StringBuilder("");

			
			for(int i=0;i<g.Length;i++)
			{
				//String[] a = rsmall.Split(strx[i]);
				String[] strz = r2.Split(g[i]);
				Item.Remove(0,Item.Length);

				if (strz.Length == 2)  
				{
					Item.Append( "(" + FieldName + ">=" + strz[0].Trim()+")");
					Item.Append(" and ( "+ FieldName + " <= " + strz[1].Trim()+ " )");
				}
				else 
				{ Item.Append("  " + FieldName + " = " + strz[0].Trim()+""); }

				if ( i !=0 )  StrS.Append(" or ("+Item+") "); 
				else StrS.Append(" ("+Item+") ") ;
			}

			return StrS.ToString();;
		}

		public CodexString()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
