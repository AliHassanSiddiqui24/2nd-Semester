using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. User Operations");
                Console.WriteLine("2. Twitter Operations");
                Console.WriteLine("3. Facebook Operations");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        UserOperations();
                        break;
                    case "2":
                        TwitterUI.TwitterMenu();
                        break;
                    case "3":
                        FacebookUI.FacebookMenu();
                        break;
                    case "4":
                        return;
                }
            }
        }

        static void UserOperations()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Back");
                Console.Write("Choose: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        UserUI.CreateUser();
                        break;
                    case "2":
                        if (UserUI.Login()) UserUI.UserMenu();
                        break;
                    case "3":
                        return;
                }
            }
        }
    }
}
