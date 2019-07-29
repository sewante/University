using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityService
{
    public class DataBaseManager
    {

        private string connectionString;
        private SqlConnection sqlConnection;
        /**
            The Databse manager class
         */
         public DataBaseManager()
        {
            //definition for the costructor
            connectionString = ConfigurationManager.AppSettings["dbConn"];
        }
        
        /**
            Esablish connection to the database
         */
        public SqlConnection GetDBConnection()
        {


            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
            catch (Exception e)
            {
                // log the error
            }

            return sqlConnection;
        }
        /**
            insert data
         */
         /**
            select data 
         */
         /**
            update data 
         */

    }
}