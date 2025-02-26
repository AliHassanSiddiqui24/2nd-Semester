using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public static class TwitterUI
    {
        public static void TwitterMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Add User");
                Console.WriteLine("2. View Tweets");
                Console.WriteLine("3. Post Tweet");
                Console.WriteLine("4. Back");
                Console.Write("Choose: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Username: ");
                        User user = UserDL.Users.Find(u => u.Username == Console.ReadLine());
                        if (user != null) TwitterBL.AddUser(user);
                        break;
                    case "2":
                        Console.Write("Username: ");
                        User target = TwitterBL.GetUser(Console.ReadLine());
                        if (target != null)
                            foreach (string msg in target.Messages)
                                Console.WriteLine(msg);
                        break;
                    case "3":
                        Console.Write("Tweet: ");
                        UserUI.currentUser.Messages.Add(Console.ReadLine());
                        break;
                    case "4":
                        return;
                }
            }
        }
    }
}
