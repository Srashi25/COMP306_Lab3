using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.DbData

{
    public static class Helpers
    {
        public static string GetRDSConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["MOVIE_WEB_DB"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["ADMIN"];
            string password = appConfig["PASSWORD"];
            string hostname = appConfig["moviesdblab3.cpgfkgne7e1e.us-east-2.rds.amazonaws.com"];
            string port = appConfig["1433"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}
