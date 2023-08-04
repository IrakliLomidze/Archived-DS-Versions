using System;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer;

namespace ILG.Codex.Codex2007
{
	/// <summary>
	/// Summary description for Database.
	/// </summary>
	public class Database
	{
		DataBaseInfo df;		
		string maindatabasefile;
		string zipfilename;
		Server srv;
        public Form1 Owner;

		public Database()
		{
			//
			// TODO: Add constructor logic here
			//
		}



		public int GetInfoFrom()
		{
			df = new DataBaseInfo();
			int i = df.GetInfo( ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom);
			if (i != 0)
			{ 
			  
				Owner.ShowProgress(0,"Error");
                Owner.ShowProgress(0, "არ ხერხდება  [" + System.IO.Path.GetFileName(ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom) + "] ფაილის წაკითხვა)");
                Owner.ShowProgress(0, "ფაილი ან დაზიანებულია ან არ არის info ფორმატის ");
                Owner.ShowProgress(0, "------------------------------------------------------------------------");
				ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება "+System.IO.Path.GetFileName(ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom)+" ფაილის წაკითხვა"+
					"\nფაილი ან დაზიანებულია ან არ არის info ფორმატის "
					,"",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return 1;
              
			}
            
			maindatabasefile = Path.GetDirectoryName(ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom) + "\\"+ df.ds.Tables["MainDataBase"].Rows[0]["FILE"];
			return 0;

		}

		
		public int ProcessFiles()
		{
			
		
				
			
			this.zipfilename = ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo + "\\"+ df.ds.Tables["ZipFileName"].Rows[0]["FILE"];
			C1.C1Zip.C1ZipFile zf = new C1.C1Zip.C1ZipFile();

			try
			{
				zf.Create(zipfilename);
				
			}
			catch
			{ 
				Owner.ShowProgress(0,"Error: ");
				Owner.ShowProgress(0,"არ ხერხდება ");
				Owner.ShowProgress(0,zipfilename);
				Owner.ShowProgress(0,"ფაილის შექმნა");
				Owner.ShowProgress(0,"------------------------------------------------------------------------");
				return 10;
			}



	
			#region Copying Databases
			#region Main Database
			for(int j=0;j<=df.ds.Tables["MainDataBase"].Rows.Count-1;j++)
			{
				 
				try 
				{
					string strf  = df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString();

					Owner.ShowProgress(0,"კოპირდება ფაილი ["+Path.GetFileName(strf)+"]");
					zf.Entries.Add(Path.GetDirectoryName(ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom)+@"\"+strf,strf);

					
					Owner.ShowProgress(0,"ფაილი  ["+Path.GetFileName(strf)+"] კოპირებულია");
				}
				catch 
				{ 
					
 				    Owner.ShowProgress(0,"Error: ");
					Owner.ShowProgress(0,"არ ხერხდება ");
					Owner.ShowProgress(0,df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString());
					Owner.ShowProgress(0,"ფაილის კოპირება");
					Owner.ShowProgress(0,"------------------------------------------------------------------------");
					return 3;

				}
				
			}

			#endregion Main Database
		
			#endregion Copying Databases

			File.Copy(Path.GetDirectoryName(ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom)+@"\database2007DS.info",ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo+@"\database2007DS.info",true);

		    maindatabasefile = ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo   + "\\"+ df.ds.Tables["MainDataBase"].Rows[0]["FILE"];
		
			zf.Close();

			return 0;
		}

		public int TakeOfflineDatabase()
		{
			Owner.ShowProgress(0,"სერვერთან დაკავშირება ");
            srv = new Server(ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer);// SQLDMO.SQLServer();
            srv.ConnectionContext.LoginSecure = true; //srv.LoginSecure = true;
            
			try
			{
                srv.ConnectionContext.ConnectTimeout = 30;
                 //    srv.Connect(Common.Server,null,null);
                srv.ConnectionContext.Connect();
			}
			catch (System.Exception ex)
			{
				Owner.ShowProgress(0,"Error: ");
				Owner.ShowProgress(0,"არ ხერხდება ");
                Owner.ShowProgress(0, "SQL Server [" + ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer+ "] დაკავშირება");
                System.Windows.Forms.MessageBox.Show(ex.ToString());
				return 1;
			}
			bool res1 = false;
			
			Owner.ShowProgress(0,"კავშირი დამყარებულია");
//			System.Windows.Forms.MessageBox.Show(srv.Databases.Item(1,"dbo").Name);
            
			for(int i=0;i<srv.Databases.Count;i++)
			{
				if (srv.Databases[i].Name.ToString().Trim().ToUpper() == "CODEX2007DS") res1 = true;
			}

			if (res1 == true)
			{
				try
				{
					Owner.ShowProgress(0,"Codex2007DS ბაზის დეაქტივიზაცია");
					//srv.Databases.Item("Codex2005","dbo").DBOption.Offline = true;
                    srv.Databases["Codex2007DS"].SetOffline();
					Owner.ShowProgress(0,"დეაქტივიზირებულია");
				}
				catch
				{
					Owner.ShowProgress(0,"Error: ");
					Owner.ShowProgress(0,"არ ხერხდება Codex2007DS-ზე ოპერირება, ბაზაზე მუშობს მომხარებელი ");
					Owner.ShowProgress(0,"დახურეთ ყველა კოდექს პროგრამა");
					return 1;
				}
			}
			
			return 0;

		}

		public int TakeOnlineDatabase()
		{
			Owner.ShowProgress(0,"ბაზების აქტივიზაცია");

			try
			{
                srv.Databases["Codex2007DS"].SetOnline();
				Owner.ShowProgress(0,"Codex2007DS აქტივიზირებულია");
			}
			catch
			{
				Owner.ShowProgress(0,"Error: ");
				Owner.ShowProgress(0,"არ ხერხდება Codex2007DS აქტივიზაცია");
						
				return 8;
			}

			
			Owner.ShowProgress(0,"კოდექსის ბაზები აქტიურია");
			Owner.ShowProgress(0,"-------------------------------------------------------");
            ILG.Windows.Forms.ILGMessageBox.Show("კოდექსის ბაზების საინსტალაციო შექმნილია");
				
			return 0;
		}

		
	}
}
