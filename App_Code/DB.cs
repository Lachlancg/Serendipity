using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
/// <summary>
/// Summary description for DB
/// </summary>
/// 
namespace FilmWebsite
{
    public class DB
    {
        public DB()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static OleDbConnection OpenConnection()
        {
            // Creates the connection to the database, it can be called from anywhere in the project. 
            //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\Computer Science\A2\Project\WebSite2 5\App_Data\Movies.accdb;Persist Security Info=True");
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\lachl\Desktop\Serendiptiy\App_Data\Movies.accdb;Persist Security Info=True");

            return conn;
        }

    }
}