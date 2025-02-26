using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public static class TwitterBL
    {
        public static List<User> Users = new List<User>();

        public static void AddUser(User user) => Users.Add(user);
        public static User GetUser(string name) => Users.Find(u => u.Username == name);
    }
}
