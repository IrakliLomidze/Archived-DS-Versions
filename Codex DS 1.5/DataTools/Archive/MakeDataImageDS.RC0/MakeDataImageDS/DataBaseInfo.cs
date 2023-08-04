using System;
using System.Data;

namespace ILG.Codex.Codex2007
{

	public class DataBaseInfo
	{
	    public DataSet ds;

        public DataBaseInfo()
        {

            ds = new DataSet("Files");
            DataTable Dt1 = new DataTable("MainDataBase");
            DataColumn dc1 = new DataColumn("FILE", System.Type.GetType("System.String"));
            Dt1.Columns.Add(dc1);
            ds.Tables.Add(Dt1);

            DataTable Dt3 = new DataTable("Information");
            DataColumn dc3 = new DataColumn("DisplayString", System.Type.GetType("System.String"));
            Dt3.Columns.Add(dc3);
            ds.Tables.Add(Dt3);

            DataTable Dt4 = new DataTable("MainDatabaseRegister");
            DataColumn dc4 = new DataColumn("Catalog", System.Type.GetType("System.String"));
            Dt4.Columns.Add(dc4);
            ds.Tables.Add(Dt4);


            DataTable Dt6 = new DataTable("ZipFileName");
            DataColumn dc6 = new DataColumn("File", System.Type.GetType("System.String"));
            Dt6.Columns.Add(dc6);
            ds.Tables.Add(Dt6);

            DataTable Dt7 = new DataTable("Version");
            DataColumn dc7 = new DataColumn("info", System.Type.GetType("System.String"));
            ds.Tables.Add(Dt7);




        }


		public int GetInfo(string filename)
		{
			
			try
			{
				ds.ReadXml(filename);
			}
			catch //(System.Exception ex)
			{
					return 1;
			}

			return 0;
		}

		

		}
	
}
