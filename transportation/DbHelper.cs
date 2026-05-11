using System;
using System.Configuration;
using System.Data;
using Npgsql;

namespace transportation
{
    public static class DbHelper
    {

        public static string GetConnectionString()
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = ConfigurationManager.AppSettings["DbHost"] ?? "localhost",
                Port = int.TryParse(ConfigurationManager.AppSettings["DbPort"], out int port) ? port : 5432,
                Database = ConfigurationManager.AppSettings["DbName"] ?? "cargotrans_db",
                Username = ConfigurationManager.AppSettings["DbUser"] ?? "postgres",
                Password = ConfigurationManager.AppSettings["DbPassword"] ?? "1234"
            };

            return builder.ConnectionString;
        }

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(GetConnectionString());
        }

        public static DataTable ExecuteQuery(string query, params NpgsqlParameter[] parameters)
        {
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                        command.Parameters.AddRange(parameters);

                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        public static int ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                        command.Parameters.AddRange(parameters);

                    return command.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query, params NpgsqlParameter[] parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                        command.Parameters.AddRange(parameters);

                    return command.ExecuteScalar();
                }
            }
        }
    }
}
