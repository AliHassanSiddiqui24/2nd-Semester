using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public static class FacebookUI
    {
        public static void FacebookMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Add User");
                Console.WriteLine("2. View Posts");
                Console.WriteLine("3. Add Post");
                Console.WriteLine("4. Back");
                Console.Write("Choose: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Username: ");
                        User user = UserDL.Users.Find(u => u.Username == Console.ReadLine());
                        if (user != null) FacebookBL.AddUser(user);
                        break;
                    case "2":
                        Console.Write("Username: ");
                        User target = FacebookBL.GetUser(Console.ReadLine());
                        if (target != null)
                            foreach (string msg in target.Messages)
                                Console.WriteLine(msg);
                        break;
                    case "3":
                        Console.Write("Post: ");
                        UserUI.currentUser.Messages.Add(Console.ReadLine());
                        break;
                    case "4":
                        return;
                }
            }
        }
    }
}
