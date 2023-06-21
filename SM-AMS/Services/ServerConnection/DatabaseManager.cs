using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SM_AMS.Services.ServerConnection
{
    public class DatabaseManager
    {
        string connectionString = "";
        //private readonly IConfiguration? configuration;
        public DatabaseManager()
        {
            connectionString = "Data Source=LAPTOP-SMNTE418\\Shabeer;Initial Catalog=DBSM_AMS;Integrated Security=True;";
        }
        public DataTable GetDataTable(string storedProcedureName, SqlParameter[]? parameters = null)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void ExecuteNonQuery(string storedProcedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable Select(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void Insert(string query)
        {
            ExecuteNonQuery(query);
        }

        public void Update(string query)
        {
            ExecuteNonQuery(query);
        }

        public void Delete(string query)
        {
            ExecuteNonQuery(query);
        }

        private void ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
