using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Business.DL
{
    public static class SqlHelper
    {

        private static string connectionString =
        "Server=localhost;Port=3306;Database=sports_management;Uid=root;Pwd=Alihassansid6857@;";

        public static DataTable GetTable(string query)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }
        public static void ExecuteDML(string query)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
