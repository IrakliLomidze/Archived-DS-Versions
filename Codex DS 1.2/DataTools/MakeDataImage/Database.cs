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

		public Database()
		{
			//
			// TODO: Add constructor logic here
			//
		}



		public int GetInfoFrom()
		{
			df = new DataBaseInfo();
			int i = df.GetInfo(Common.FromPath);
			if (i != 0)
			{ 
			  
				LocalVar.MainForm.ShowProgress(0,"Error");
				LocalVar.MainForm.ShowProgress(0,"არ ხერხდება  ["+System.IO.Path.GetFileName(Common.FromPath)+"] ფაილის წაკითხვა)");
				LocalVar.MainForm.ShowProgress(0,"ფაილი ან დაზიანებულია ან არ არის info ფორმატის ");
				LocalVar.MainForm.ShowProgress(0,"------------------------------------------------------------------------");
				ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება "+System.IO.Path.GetFileName(Common.FromPath)+" ფაილის წაკითხვა"+
					"\nფაილი ან დაზიანებულია ან არ არის info ფორმატის "
					,"",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return 1;
              
			}
            
			maindatabasefile = Path.GetDirectoryName(Common.FromPath) + "\\"+ df.ds.Tables["MainDataBase"].Rows[0]["FILE"];
			return 0;

		}

		
		public int ProcessFiles()
		{
			
		
				
			
			this.zipfilename = Common.toPath + "\\"+ df.ds.Tables["ZipFileName"].Rows[0]["FILE"];
			C1.C1Zip.C1ZipFile zf = new C1.C1Zip.C1ZipFile();

			try
			{
				zf.Create(zipfilename);
				
			}
			catch 
			{ 
				LocalVar.MainForm.ShowProgress(0,"Error: ");
				LocalVar.MainForm.ShowProgress(0,"არ ხერხდება ");
				LocalVar.MainForm.ShowProgress(0,zipfilename);
				LocalVar.MainForm.ShowProgress(0,"ფაილის შექმნა");
				LocalVar.MainForm.ShowProgress(0,"------------------------------------------------------------------------");
				return 10;
			}



	
			#region Copying Databases
			#region Main Database
			for(int j=0;j<=df.ds.Tables["MainDataBase"].Rows.Count-1;j++)
			{
				 
				try 
				{
					string strf  = df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString();

					LocalVar.MainForm.ShowProgress(0,"კოპირდება ფაილი ["+Path.GetFileName(strf)+"]");
					zf.Entries.Add(Path.GetDirectoryName(Common.FromPath)+@"\"+strf,strf);

					
					LocalVar.MainForm.ShowProgress(0,"ფაილი  ["+Path.GetFileName(strf)+"] კოპირებულია");
				}
				catch  (Exception ex1)
				{ 
					
 				    LocalVar.MainForm.ShowProgress(0,"Error: ");
					LocalVar.MainForm.ShowProgress(0,"არ ხერხდება ");
					LocalVar.MainForm.ShowProgress(0,df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString());
					LocalVar.MainForm.ShowProgress(0,"ფაილის კოპირება");
                    LocalVar.MainForm.ShowProgress(0, ex1.Message.ToString());
					LocalVar.MainForm.ShowProgress(0,"------------------------------------------------------------------------");
					return 3;

				}
				
			}

			#endregion Main Database
		
			#endregion Copying Databases

			File.Copy(Path.GetDirectoryName(Common.FromPath)+@"\database2007DS.info",Common.toPath+@"\database2007DS.info",true);




		maindatabasefile = Common.toPath   + "\\"+ df.ds.Tables["MainDataBase"].Rows[0]["FILE"];
		
			zf.Close();

	
			return 0;
		}

		public int TakeOfflineDatabase()
		{
			LocalVar.MainForm.ShowProgress(0,"სერვერთან დაკავშირება ");
            srv = new Server(Common.Server);// SQLDMO.SQLServer();
            srv.ConnectionContext.LoginSecure = true; //srv.LoginSecure = true;
            
			try
			{
                srv.ConnectionContext.ConnectTimeout = 30;
                 //    srv.Connect(Common.Server,null,null);
                srv.ConnectionContext.Connect();
			}
			catch (System.Exception ex)
			{
				LocalVar.MainForm.ShowProgress(0,"Error: ");
				LocalVar.MainForm.ShowProgress(0,"არ ხერხდება ");
				LocalVar.MainForm.ShowProgress(0,"SQL Server ["+Common.Server+"] დაკავშირება");
                System.Windows.Forms.MessageBox.Show(ex.ToString());
				return 1;
			}
			bool res1 = false;
			bool res2 = false;
			LocalVar.MainForm.ShowProgress(0,"კავშირი დამყარებულია");
//			System.Windows.Forms.MessageBox.Show(srv.Databases.Item(1,"dbo").Name);
            
			for(int i=0;i<srv.Databases.Count;i++)
			{
				if (srv.Databases[i].Name.ToString().Trim().ToUpper() == "CODEX2007DS") res1 = true;
			}

			if (res1 == true)
			{
				try
				{
					LocalVar.MainForm.ShowProgress(0,"Codex2007DS ბაზის დეაქტივიზაცია");
					//srv.Databases.Item("Codex2005","dbo").DBOption.Offline = true;
                    srv.Databases["CODEX2007DS"].SetOffline();
					LocalVar.MainForm.ShowProgress(0,"დეაქტივიზირებულია");
				}
				catch
				{
					LocalVar.MainForm.ShowProgress(0,"Error: ");
					LocalVar.MainForm.ShowProgress(0,"არ ხერხდება Codex2007DS -ზე ოპერირება, ბაზაზე მუშობს მომხარებელი ");
					LocalVar.MainForm.ShowProgress(0,"დახურეთ ყველა კოდექს პროგრამა");
					return 1;
				}
			}
			
			
			return 0;

		}

		public int TakeOnlineDatabase()
		{
			
			//System.Windows.Forms.MessageBox.Show(strx2.ToString());
			LocalVar.MainForm.ShowProgress(0,"ბაზების აქტივიზაცია");

			try
			{
				//srv.Databases.Item("Codex2005","dbo").DBOption.Offline = false;
                srv.Databases["CODEX2007DS"].SetOnline();
				LocalVar.MainForm.ShowProgress(0,"Codex2007DS აქტივიზირებულია");
			}
			catch
			{
				LocalVar.MainForm.ShowProgress(0,"Error: ");
				LocalVar.MainForm.ShowProgress(0,"არ ხერხდება Codex2007DS აქტივიზაცია");
						
				return 8;
			}

		
			
			LocalVar.MainForm.ShowProgress(0,"კოდექსის ბაზები აქტიურია");
			LocalVar.MainForm.ShowProgress(0,"-------------------------------------------------------");
            ILG.Windows.Forms.ILGMessageBox.Show("კოდექსის ბაზების საინსტალაციო შექმნილია");

				
			return 0;
		
		}

		
	}
}
