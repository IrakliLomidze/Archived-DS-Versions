using System;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer;
using System.Collections.Specialized;
using System.Collections.Generic;




namespace ILG.Codex.Codex2007
{
	/// <summary>
	/// Summary description for Database.
	/// </summary>
	public class Database
	{

        Form1 Owner;
        DataBaseInfo df;		
		string maindatabasefile;
		//string maindatabasecatalog;
		string zipfilename;
		Server  srv;

		public Database(Form1 sender)
		{
			Owner = sender;
		}

		public int GetInfoFrom()
		{
			df = new DataBaseInfo();
			int i = df.GetInfo(Form1.CopyFrom);
			if (i != 0)
			{

                Owner.ShowProgress(0, "Error");
                Owner.ShowProgress(0, "არ ხერხდება  [" + System.IO.Path.GetFileName(Form1.CopyFrom) + "] ფაილის წაკითხვა)");
                Owner.ShowProgress(0, "ფაილი ან დაზიანებულია ან არ არის info ფორმატის");
                Owner.ShowProgress(0, "------------------------------------------------------------------------");
                ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება " + System.IO.Path.GetFileName(Form1.CopyFrom) + " ფაილის წაკითხვა" +
					"\nფაილი ან დაზიანებულია ან არ არის info ფორმატის "
					,"",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				return 1;
              
			}

            maindatabasefile = Path.GetDirectoryName(Form1.CopyFrom) + "\\" + df.ds.Tables["MainDataBase"].Rows[0]["FILE"];
            return 0;

		}

		
		public int ProcessFiles()
		{
			
		
			//Owner.ShowProgress("მზადდება ფაილები კოპირებისათვის",0);
			//Int64 sum = 0;

            this.zipfilename = Path.GetDirectoryName(Form1.CopyFrom) + "\\" + df.ds.Tables["ZipFileName"].Rows[0]["FILE"];
			
       



			#region Calculating Sizes
			/*
			#region main Database
			for(int j=0;j<=df.ds.Tables["MainDataBase"].Rows.Count-1;j++)
			{
				 
				try 
				{
					FileStream fs = File.Open(Path.GetDirectoryName(Common.FromPath)+@"\"+df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString()
						,System.IO.FileMode.Open,System.IO.FileAccess.Read);
					sum += fs.Length;
					fs.Close(); 
				}
				catch 
				{ 
					
					Owner.ShowProgress(0,"Error: ");
					Owner.ShowProgress(0,"არ ხერხდება ");
					Owner.ShowProgress(0,Path.GetDirectoryName(Common.FromPath)+@"\"+df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString());
					Owner.ShowProgress(0,"ფაილის წაკითხვა");
					Owner.ShowProgress(0,"------------------------------------------------------------------------");

					ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება "+
														 Path.GetDirectoryName(Common.FromPath)+@"\"+df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString()+
                                                         " ფაილის წაკითხვა"+
						                                 "\n Error Code: C002"
							,"",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return 2;



				}
				
			}

			#endregion main Database

		#region update Database
			for(int j=0;j<=df.ds.Tables["UpdateDataBase"].Rows.Count-1;j++)
			{
				 
				try 
				{
					FileStream fs = File.Open(Path.GetDirectoryName(Common.FromPath)+@"\"+df.ds.Tables["UpdateDataBase"].Rows[j]["FILE"].ToString()
						,System.IO.FileMode.Open,System.IO.FileAccess.Read);
					sum += fs.Length;
					fs.Close(); 
				}
				catch 
				{ 

					Owner.ShowProgress(0,"Error: ");
					Owner.ShowProgress(0,"არ ხერხდება ");
					Owner.ShowProgress(0,Path.GetDirectoryName(Common.FromPath)+@"\"+df.ds.Tables["UpdateDataBase"].Rows[j]["FILE"].ToString());
					Owner.ShowProgress(0,"ფაილის წაკითხვა");
					
					ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება "+
						Path.GetDirectoryName(Common.FromPath)+@"\"+df.ds.Tables["UpdateDataBase"].Rows[j]["FILE"].ToString()+
						" ფაილის წაკითხვა"
						,"",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					return 2;

				}
				
			}

			#endregion update Database
			*/
			
			#endregion Calculating Sizes

			#region Copying Databases
			#region Main Database
			for(int j=0;j<=df.ds.Tables["MainDataBase"].Rows.Count-1;j++)
			{
				 
				try 
				{
					string strf  = df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString();

					Owner.ShowProgress(0,"კოპირდება ფაილი ["+Path.GetFileName(strf)+"]");
					

                    strf = Form1.CopyTo + @"\" + strf;
					if ((File.GetAttributes(strf) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
					{ File.SetAttributes(strf,System.IO.FileAttributes.Archive);
				
					}
                    Owner.ShowProgress(0, "ფაილი  [" + Path.GetFileName(strf) + "] კოპირებულია");
				}
				catch 
				{

                    Owner.ShowProgress(0, "Error: ");
                    Owner.ShowProgress(0, "არ ხერხდება ");
                    Owner.ShowProgress(0, df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString());
                    Owner.ShowProgress(0, "ფაილის კოპირება");
                    Owner.ShowProgress(0, "------------------------------------------------------------------------");
					return 3;

				}
				
			}

			#endregion Main Database
	
            #endregion Copying Databases

			
			
			if (File.Exists(Path.GetDirectoryName(Form1.CopyTo)+@"\database2007DS.info") == true)
			{
                if ((File.GetAttributes(Path.GetDirectoryName(Form1.CopyTo) + @"\database2007DS.info") & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                { File.SetAttributes(Path.GetDirectoryName(Form1.CopyTo) + @"\database2007DS.info", System.IO.FileAttributes.Archive); }
			}

			
			
			File.Copy(Path.GetDirectoryName(Form1.CopyFrom)+@"\database2007DS.info",Path.GetDirectoryName(Form1.CopyTo)+@"\database2007DS.info",true);

		    maindatabasefile = Form1.CopyTo   + "\\"+ df.ds.Tables["MainDataBase"].Rows[0]["FILE"];
		
		
			return 0;
		}

		public int dropDatabase()
		{
			Owner.ShowProgress(0,"სერვერთან დაკავშირება ");
            srv = new Server(global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer);
            srv.ConnectionContext.LoginSecure = true;//srv.LoginSecure = true;
			try
			{
                srv.ConnectionContext.ConnectTimeout = 30;
                
                srv.ConnectionContext.Connect();        //srv.Connect(Common.Server,null,null);
			}
			catch
			{
				Owner.ShowProgress(0,"Error: ");
				Owner.ShowProgress(0,"არ ხერხდება ");
                Owner.ShowProgress(0, "SQL Server [" + global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer + "] დაკავშირება");
				return 1;
			}
			bool res1 = false;
			Owner.ShowProgress(0,"კავშირი დამყარებულია");
//			System.Windows.Forms.MessageBox.Show(srv.Databases.Item(1,"dbo").Name);

			for(int i=0;i<srv.Databases.Count;i++)
			{
				//srv.Databases.Item(i).Name
				if (srv.Databases[i].Name.ToString().Trim().ToUpper() == "CODEX2007DS") res1 = true;
			}

			if (res1 == true)
			{
				try
				{
					Owner.ShowProgress(0,"ძველი Codex2007DS ბაზის წაშლა");
                    srv.DetachDatabase("Codex2007DS",true,true);//  DetachDB("Codex2005",true);
					Owner.ShowProgress(0,"წაშლილია");
				}
				catch 
				{
					Owner.ShowProgress(0,"Error: ");
                    Owner.ShowProgress(0, "არ ხერხდება Codex2007DS ბაზის გადაწერა, ბაზაზე მუშობს მომხმარებელი ");
					Owner.ShowProgress(0,"დახურეთ ყველა კოდექს პროგრამა");
					return 1;
				}
			}
			
			

			
	
			
			return 0;

		}

		public int AttachDatabase()
		{
			
//			StringBuilder strx = new StringBuilder();
            StringCollection strx = new StringCollection();

            for (int i = 0; i <= df.ds.Tables["MainDataBase"].Rows.Count - 1; i++)
            {
                strx.Add(//"[" +
                    Path.GetDirectoryName(this.maindatabasefile) + @"\" + df.ds.Tables["MainDataBase"].Rows[i]["FILE"].ToString() 
                    //+
                    //"]"
                    );
            }
            
			//System.Windows.Forms.MessageBox.Show(strx.ToString());

			//StringBuilder strx2 = new StringBuilder();
            StringCollection strx2 = new StringCollection();
			Owner.ShowProgress(0,"ბაზების რეგისტრაცია");

			try
			{
                srv.AttachDatabase("Codex2007DS", strx);// AttachDB("Codex2005", strx.ToString());
				Owner.ShowProgress(0,"Codex2007DS რეგისტრირებულია");
			}
			catch (Exception e)
			{
				Owner.ShowProgress(0,"Error: ");
				Owner.ShowProgress(0,"არ ხერხდება Codex2007DS ბაზის რეგისტრაცია ");
                ILG.Windows.Forms.ILGMessageBox.ShowE("Er", e.ToString());
						
				return 8;
			}

			
			Owner.ShowProgress(0,"კოდექსის ბაზები რეგისტრირებულია");
			Owner.ShowProgress(0,"-------------------------------------------------------");
			ILG.Windows.Forms.ILGMessageBox.Show("კოდექსის ბაზების ინსტალაცია დასრულდა");

				
			return 0;
		
		}

		
	}
}
