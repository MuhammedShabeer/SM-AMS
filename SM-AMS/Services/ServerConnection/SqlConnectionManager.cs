using System;
using System.Data.SqlClient;

namespace SM_AMS.Services.ServerConnection
{
    public class SqlConnectionManager
    {
        private readonly string connectionString;

        public SqlConnectionManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
