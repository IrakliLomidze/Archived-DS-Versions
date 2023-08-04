// Codex DS 1.6
// (C) Copyright 2007-2017 By Irakli Lomidze

using System;
using System.Collections.Generic;
using System.Data;

namespace ILG.Codex.CodexR4
{

	public class CodexDSDataBaseInfo
	{
	    DataSet ds;
        public String DisplayString;
        public FullDataBase Info;

        public class SingleDataBase
        {
            public String DataBaseName;
            public String CatalogName;
            public List<String> Files;
            public String DataBaseFile;
        }
        
        public class FullDataBase
        {
            public List<SingleDataBase> DataBases;
            public List<String> DatabaseNames;
        }
        
            
		public CodexDSDataBaseInfo()
		{
            SingleDataBase MainDataBase = new SingleDataBase();
            MainDataBase.Files = new List<string>() { "Codex2007DS_data.mdf", "Codex2007DS_blobs_data.ndf", "Codex2007DS_log.ldf" };
            MainDataBase.CatalogName = "Codex2007DS";
            MainDataBase.DataBaseName = "MainDataBase";
            MainDataBase.DataBaseFile = "Codex2007DS_data.mdf";

            Info = new FullDataBase();
            Info.DataBases = new List<SingleDataBase>() { MainDataBase };

            Info.DatabaseNames = new List<string>() { "Codex2007DS".ToUpper()};

            ds = new DataSet("CodexCodex2007DSDataBase");

       

		  DataTable Dt4 = new DataTable("Information");
		  DataColumn dc4 = new DataColumn("DisplayString",System.Type.GetType("System.String"));
		  Dt4.Columns.Add(dc4);
		  ds.Tables.Add(Dt4);


          
 
		}

		public int GetInfo(string filename)
		{
			
			try
			{
				ds.ReadXml(filename);
                DisplayString = ds.Tables["Information"].Rows[0]["DisplayString"].ToString();
			}
			catch //(System.Exception ex)
			{
					return 1;
			}

			return 0;
		}

		

		}
	
}
