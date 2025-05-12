using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cricket_Management_System.DL;

namespace Cricket_Management_System.BL
{
    public class UserBL : IUserService
    {
        public bool Login(string username, string password, out string role)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                role = string.Empty;
                return false;
            }

            return UserDL.ValidateUser(username, password, out role);
        }

        public bool Register(string username, string password, string role)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (UserDL.UserExists(username))
            {
                return false;
            }

            UserDL.AddUser(username, password, role);
            return true;
        }
    }
}
