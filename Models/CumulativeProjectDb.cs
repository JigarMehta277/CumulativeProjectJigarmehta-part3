using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CumulativeProjectJigarmehta.Models
{
    public class CumulativeProjectDb
    {
        //These are readonly "secret" properties.
        //Only the CumulativeProjectDb class can use them.
        private static string User { get { return "root"; } }

        private static string Password { get { return "root"; } }

        private static string Database { get { return "project"; } }

        private static string Server { get { return "localhost"; } }

        private static string Port { get { return "3306"; } }


        //ConnectionString is a series of credentials used to connect to the database.
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; Port = " + Port
                    + "; Password = " + Password;
            }
        }

        //This method we use to connect to the databse.
        /// <summary>
        /// Returns a connection to the project databse.
        /// </summary>
        /// <example>
        /// Private CumulativeProject Project = new CumulativeProject();
        /// MySqlConnection Conn =  Project.AccessDatabase();
        /// </example>
        /// <returns>A My SqlConnection Object</returns>
        public MySqlConnection AccessDatabase()
        {
            //In this step we are instantiating class.
            return new MySqlConnection(ConnectionString);
        }
    }
}