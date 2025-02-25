using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;
using System.IO;

namespace Business.DL
{
    public class UserRepository
    {
        public List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            if (File.Exists("users.txt"))
            {
                foreach (string line in File.ReadAllLines("users.txt"))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        users.Add(new User(parts[0], parts[1], parts[2]));
                    }
                }
            }
            return users;
        }

        public void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();
            foreach (User user in users)
            {
                lines.Add($"{user.Username},{user.Password},{user.Role}");
            }
            File.WriteAllLines("users.txt", lines);
        }
    }
}
