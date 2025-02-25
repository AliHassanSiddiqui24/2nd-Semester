using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUp_Page
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] username = new string[100];
            string[] password = new string[100];
            string[] role = new string[100];
            int count = 0;
            while (true) 
            {
                Console.Clear();
                string choice = MainMenu();
                switch (choice)
                {
                    case "1":
                        SignUp(username, password, role, ref count);
                        break;
                    case "2":
                        SignIn(username, password, role, count);
                        break;
                    case "3":
                        Console.WriteLine("Exiting.... Good Bye");
                        return;
                    default:
                        Console.WriteLine("Enter a Valid Number...");
                        break;
                }
            }
        }
        static string MainMenu()
        {
            Console.WriteLine("Welcome to SignUp Page..");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter 1/2/3");
            string input = (Console.ReadLine());
            return input;        
        }
        static void SignUp(string []username, string []password,string []role,ref int count)
        {
            Console.WriteLine("Enter UserName: ");
            username[count] = Console.ReadLine();
            Console.WriteLine("Enter Password");
            password[count] = Console.ReadLine();
            Console.WriteLine("Enter Role (Manager/Coach): ");
            role[count] = Console.ReadLine();
            if(role[count] != "Manager" && role[count] != "Coach")
            {
                Console.WriteLine("Invalid Role..");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("SignUp Successfully as " + role[count]);
            count++;
            Console.ReadKey();
            return;
        }
        static void SignIn(string []username, string []password, string []role, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("No one has SignUp yet...");
                Console.ReadKey();
                return;
            }
            bool IsFound = false;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter Username: ");
                string uname = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string pword = Console.ReadLine();
                if (uname == username[i] && pword == password[i])
                {
                    Console.WriteLine("You have successfully login " + role[i] +".");
                    IsFound = true;
                    Console.ReadKey ();
                    return;
                }

            }
            if (!IsFound)
            {
                Console.WriteLine("Invalid Credentials... try again");
            }
        }
    }
}
