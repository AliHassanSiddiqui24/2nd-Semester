using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Cricket_Management_System.DL
{
    public class UserDL
    {
        // Method to validate user login
        public static bool ValidateUser(string username, string password, out string role)
        {
            role = string.Empty;
            string query = $"SELECT Role FROM Users WHERE Username = '{username}' AND Password = '{password}'";
            DataTable dt = SqlHelper.GetTable(query);

            if (dt.Rows.Count > 0)
            {
                role = dt.Rows[0]["Role"].ToString();
                return true;
            }
            return false;
        }

        // Method to check if username already exists
        public static bool UserExists(string username)
        {
            string query = $"SELECT Id FROM Users WHERE Username = '{username}'";
            DataTable dt = SqlHelper.GetTable(query);
            return dt.Rows.Count > 0;
        }

        // Method to add new user
        public static void AddUser(string username, string password, string role)
        {
            string query = $"INSERT INTO Users (Username, Password, Role) VALUES ('{username}', '{password}', '{role}')";
            SqlHelper.ExecuteDML(query);
        }
    }
}
