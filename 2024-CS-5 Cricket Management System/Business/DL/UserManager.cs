using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;

namespace Business.DL
{
    public class UserManager
    {
        public List<User> Users = new List<User>();
        private UserRepository userRepo = new UserRepository();

        public UserManager()
        {
            Users = userRepo.LoadUsers();
        }

        public bool RegisterUser(string username, string password, string role)
        {
            if (Users.Count < 100 && (role == "Manager" || role == "Coach"))
            {
                Users.Add(new User(username, password, role));
                userRepo.SaveUsers(Users);
                return true;
            }
            return false;
        }
    }
}
