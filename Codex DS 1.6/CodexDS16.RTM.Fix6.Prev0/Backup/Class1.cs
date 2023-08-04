using System;
using System.Text;
using System.IO;
using System.Xml;


namespace ILG
{
	namespace Codex
	{
		namespace XML
		{
			/// <summary>
			/// Summary description for Class1.
			/// </summary>
			public class LinkXMLConvert
			{
				
				public LinkXMLConvert()
				{
				
				}
				public static string converttoGuni(string str)
				{
					char[] c = new char[256];
					for(int i=0;i<=255;i++)
						c[i] = Convert.ToChar(i);
			
					c[0xc0] = Convert.ToChar(0x10d0);
					c[0xc1] = Convert.ToChar(0x10d1);
					c[0xc2] = Convert.ToChar(0x10d2);
					c[0xc3] = Convert.ToChar(0x10d3);
					c[0xc4] = Convert.ToChar(0x10d4);
					c[0xc5] = Convert.ToChar(0x10d5);
					c[0xc6] = Convert.ToChar(0x10d6);
			
					c[0xc7] = Convert.ToChar(0x10f1); // 5 V

					c[0xc8] = Convert.ToChar(0x10d7);
					c[0xc9] = Convert.ToChar(0x10d8);
					c[0xca] = Convert.ToChar(0x10d9);
					c[0xcb] = Convert.ToChar(0x10da);
					c[0xcc] = Convert.ToChar(0x10db);
					c[0xcd] = Convert.ToChar(0x10dc);

					c[0xce] = Convert.ToChar(0x10f2); // 5 V

					c[0xcf] = Convert.ToChar(0x10dd);
					c[0xd0] = Convert.ToChar(0x10de);
					c[0xd1] = Convert.ToChar(0x10df);
					c[0xd2] = Convert.ToChar(0x10e0);
					c[0xd3] = Convert.ToChar(0x10e1);
					c[0xd4] = Convert.ToChar(0x10e2);

					c[0xd5] = Convert.ToChar(0x10f3); // 5 V

					c[0xd6] = Convert.ToChar(0x10e3);
					c[0xd7] = Convert.ToChar(0x10e4);
					c[0xd8] = Convert.ToChar(0x10e5);
					c[0xd9] = Convert.ToChar(0x10e6);
					c[0xda] = Convert.ToChar(0x10e7);
					c[0xdb] = Convert.ToChar(0x10e8);
					c[0xdc] = Convert.ToChar(0x10e9);
					c[0xdd] = Convert.ToChar(0x10ea);
					c[0xde] = Convert.ToChar(0x10eb);
					c[0xdf] = Convert.ToChar(0x10ec);
					c[0xe0] = Convert.ToChar(0x10ed);
					c[0xe1] = Convert.ToChar(0x10ee);

					c[0xe2] = Convert.ToChar(0x10f4); // 5 V

					c[0xe3] = Convert.ToChar(0x10ef);
					c[0xe4] = Convert.ToChar(0x10f0);

					c[0xe5] = Convert.ToChar(0x10f5); // 5 V
					c[0xe6] = Convert.ToChar(0x10f6); // 5 V

					StringBuilder f = new StringBuilder("");
                	for(int i=0;i<str.Length;i++)
					{
						if ( System.Convert.ToInt16(str[i]) < 255) 	f.Append(c[str[i]]);
						else  
							f.Append(str[i]);
		
					}

					return  f.ToString();
								   
				}

				public static string converttoRuni(string str)
				{
					char[] c = new char[256];
					for(int i=0;i<=255;i++)
						c[i] = Convert.ToChar(i);
			
					for(int i=0;i<=63;i++)
					c[0xc0+i] = Convert.ToChar(0x0410+i);
			
					c[0xb8] = Convert.ToChar(0x0451); // 1 e:

					StringBuilder f = new StringBuilder("");
					for(int i=0;i<str.Length;i++)
					{
						if ( System.Convert.ToInt16(str[i]) < 255) 	f.Append(c[str[i]]);
						else  
							f.Append(str[i]);
		
					}

					return  f.ToString();
								   
				}


				
				public static void convertfile(string infilestr,string temppath,string outfile) 
				{
					StreamReader t = new StreamReader(infilestr,System.Text.Encoding.GetEncoding(1252));
					StreamWriter t2 = new StreamWriter(temppath+@"\nn.xml",false,System.Text.Encoding.Unicode);

					String line;
					while ((line = t.ReadLine()) != null) 
					{
						line = LinkXMLConvert.converttoGuni(line);
						t2.WriteLine(line);
					}
					t.Close();
					t2.Close();

					XmlDocument doc = new XmlDocument();
					XmlTextWriter writer = new XmlTextWriter(outfile,System.Text.Encoding.Unicode);
					writer.Formatting = Formatting.Indented;

					
					doc.Load(temppath+@"\nn.xml");
					XmlNodeList nodes = doc.GetElementsByTagName("ROWDATA");
					writer.WriteStartDocument();

					writer.WriteStartElement("LinkDataSet");

								
					foreach(XmlNode node in nodes)
					{   
						if (node.HasChildNodes)
						{
							XmlNodeList children = node.ChildNodes;
							foreach(XmlNode child in children )
							{	
								writer.WriteStartElement("LinkTable");
								foreach(XmlAttribute attr in child.Attributes)
								{
									if ( (attr.Name.ToUpper().Trim() == "LINK") || 
										(attr.Name.ToUpper().Trim() == "CAPTION") || 
										(attr.Name.ToUpper().Trim() == "LINKTYPE") )
										writer.WriteElementString(attr.Name.ToString(),attr.Value.ToString());
								}
								writer.WriteElementString("Order","0");
								writer.WriteElementString("Status","0");
								writer.WriteEndElement();
							}
						}
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
					System.IO.File.Delete(temppath+@"\nn.xml");

				}




			}
		}
	}

}