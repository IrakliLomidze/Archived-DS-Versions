using ILG.DS.Profile.Properties;
using System;


namespace DSProfileMaker.TSQLGenerators
{
    internal class DSDBScriptsGeneration
    {
        private string _databaseName;
        private string _path;
        private string _userName;
        private string _password;
        public DSDBScriptsGeneration(string databaseName, string path, String userName, String password)
        {
            _databaseName = databaseName;
            _path = path;
            if (path.EndsWith("/")) { path = path.Remove(path.Length - 1, 1); }
            _userName = userName;
            _password = password;
        }

        public string GetnerateDBCreationScript()
        {
            string script = Resources.DBCreation;
            if (script != null) 
            {
               script = script.Replace("__DBNAME__", _databaseName);
               script = script.Replace("__PATH__", _path);
            }
            return script;
        }

        public string GetnerateDBStructureCreationScript()
        {
            string script = Resources.DBStructure;
            if (script != null)
            {
                script = script.Replace("__DBNAME__", _databaseName);
            }
            return script;
        }

        public string GetnerateDBFullTextCreationScript()
        {
            string script = Resources.FullText;
            if (script != null)
            {
                script = script.Replace("__DBNAME__", _databaseName);
            }
            return script;
        }

        public string GetnerateDBSeedersScript()
        {
            string script = Resources.DBSeeders;
            if (script != null)
            {
                script = script.Replace("__DBNAME__", _databaseName);
            }
            return script;
        }

        public string GetnerateDBUsersCreationScript()
        {
            string script = Resources.DBUsers;
            if (script != null)
            {
                script = script.Replace("__DBNAME__", _databaseName);
                script = script.Replace("__DBUSERNAME__", _userName);
                script = script.Replace("__DBUSERNAMEPASSWORD__", _password);
            }
            return script;
        }
    }
}
