using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cricket_Management_System.DL;

namespace Cricket_Management_System.BL
{
    // UserBL implements IUserService - demonstrates Implementation inheritance (OOP)
    public class UserBL : IUserService
    {
        // Validates user login
        public bool Login(string username, string password, out string role)
        {
            // Basic validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                role = string.Empty;
                return false;
            }

            return UserDL.ValidateUser(username, password, out role);
        }

        // Registers a new user
        public bool Register(string username, string password, string role)
        {
            // Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Check if username already exists
            if (UserDL.UserExists(username))
            {
                return false;
            }

            // Add user to database
            UserDL.AddUser(username, password, role);
            return true;
        }
    }
}
