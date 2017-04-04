using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace Hacked.Controllers
{
    class Database
    {
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                return connection;
            }
        }
        //!!!UPDATE CONNECTIONSTRING!!!
        private static string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"c:\\users\\fam_e\\onedrive\\documenten\\visual studio 2015\\Projects\\Hacked\\Hacked\\App_Data\\Database.mdf\";Integrated Security = True";
    }
}