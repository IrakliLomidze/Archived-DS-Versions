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

        static  public char ConvertGeoUnitoGeo8(char c)
		{ 
			
			int code = Convert.ToInt16(c);

			if ((code >= 0x10d0) && (code <= 0x10d6)) return Convert.ToChar((code-0x10d0)+0xc0);
			if (code == 0x10f1) return Convert.ToChar(0xc7);					
			if ((code >= 0x10d7) && (code <= 0x10dc)) return Convert.ToChar((code-0x10d7)+0xc8);
			if (code == 0x10f2) return Convert.ToChar(0xce);					
			if ((code >= 0x10dd) && (code <= 0x10e2)) return Convert.ToChar((code-0x10dd)+0xcf);
			if (code == 0x10f3) return Convert.ToChar(0xd5);
			if ((code >= 0x10e3) && (code <= 0x10ee)) return Convert.ToChar((code-0x10e3)+0xd6);
			if (code == 0x10f4) return Convert.ToChar(0xe2);
			if ((code >= 0x10ef) && (code <= 0x10f0)) return Convert.ToChar((code-0x10ef)+0xe3);
			if (code == 0x10f5) return Convert.ToChar(0xe5);
			if (code == 0x10f6) return Convert.ToChar(0xe6);
            else return '÷';

		}

		static public string GeoUnitoGeo8(string str)
		{
			StringBuilder st = new StringBuilder();

			for(int i=0;i<str.Length;i++)
			{
				if ((Convert.ToInt16(str[i]) >= 0x10D0) && (Convert.ToInt16(str[i])<= 0x10FB))
				  st.Append(Convert.ToChar(ConvertGeoUnitoGeo8(str[i])));
			      else st.Append(str[i]);

			}
			return st.ToString();

		}


		public CodexString()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
