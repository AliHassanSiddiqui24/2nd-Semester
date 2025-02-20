using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System
{
    public class UserManager
    {
        private static List<User> users = new List<User>();

        public static void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Enter role (Manager/Coach): ");
            string role = Console.ReadLine();

            if (role.ToLower() != "manager" && role.ToLower() != "coach")
            {
                Console.WriteLine("Invalid role! Must be Manager or Coach");
                return;
            }

            users.Add(new User(username, password, role));
            SaveUsers();
            Console.WriteLine("Registration successful!");
        }

        public static User Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    Console.WriteLine($"Login successful! Welcome {user.Role}");
                    return user;
                }
            }

            Console.WriteLine("Invalid credentials!");
            return null;
        }

        public static void SaveUsers()
        {
            using (StreamWriter writer = new StreamWriter("users.txt"))
            {
                foreach (User user in users)
                {
                    writer.WriteLine($"{user.Username},{user.Password},{user.Role}");
                }
            }
        }

        public static void LoadUsers()
        {
            if (File.Exists("users.txt"))
            {
                string[] lines = File.ReadAllLines("users.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        users.Add(new User(parts[0], parts[1], parts[2]));
                    }
                }
            }
        }
    }
}
    
