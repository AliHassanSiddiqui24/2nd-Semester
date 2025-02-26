using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public static class AdminDL
    {
        private static List<Admin> admins = new List<Admin>();

        // Static constructor to add default admin
        static AdminDL()
        {
            admins.Add(new Admin { Username = "admin", Password = "admin123" });
        }

        public static void AddAdmin(Admin a)
        {
            admins.Add(a);
        }

        public static Admin ValidateAdmin(string username, string password)
        {
            foreach (Admin a in admins)
            {
                if (a.Username == username && a.Password == password)
                    return a;
            }
            return null;
        }
    }
}
