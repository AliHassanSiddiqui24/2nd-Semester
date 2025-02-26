using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public static class UserUI
    {
        public static User currentUser;

        public static void CreateUser()
        {
            Console.Write("Username: ");
            string user = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();
            UserDL.Users.Add(new User(user, pass));
            Console.WriteLine("User created!");
        }

        public static bool Login()
        {
            Console.Write("Username: ");
            string user = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();

            foreach (User u in UserDL.Users)
            {
                if (u.Username == user && u.CheckPassword(pass))
                {
                    currentUser = u;
                    return true;
                }
            }
            return false;
        }

        public static void UserMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. View Profile");
                Console.WriteLine("2. Encrypt Password");
                Console.WriteLine("3. Check Password");
                Console.WriteLine("4. Change Password");
                Console.WriteLine("5. Get Password");
                Console.WriteLine("6. Log Out");
                Console.Write("Choose: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine($"Username: {currentUser.Username}");
                        Console.WriteLine($"Password: {currentUser.GetPassword()}");
                        break;
                    case "2":
                        Console.Write("Enter string: ");
                        string str = Console.ReadLine();
                        Console.WriteLine("Encrypted: " + currentUser.EncryptPassword(str));
                        break;
                    case "3":
                        Console.Write("Enter password: ");
                        Console.WriteLine("Match: " + currentUser.CheckPassword(Console.ReadLine()));
                        break;
                    case "4":
                        Console.Write("New password: ");
                        currentUser.ChangePassword(Console.ReadLine());
                        break;
                    case "5":
                        Console.WriteLine("Password: " + currentUser.GetPassword());
                        break;
                    case "6":
                        return;
                }
            }
        }
    }
}

