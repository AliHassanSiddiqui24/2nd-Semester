using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
                UserManager.LoadUsers();
                PlayerManager.LoadPlayers();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("*           CRICKET MANAGEMENT SYSTEM         *");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register");
                    Console.WriteLine("3. Save and Exit");
                    Console.Write("Enter your choice: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            User user = UserManager.Login();
                            if (user != null)
                            {
                                if (user.Role == "Manager") ManagerMenu.Show(user);
                                else if (user.Role == "Coach") CoachMenu.Show(user);
                            }
                            break;
                        case "2":
                            UserManager.Register();
                            break;
                        case "3":
                            UserManager.SaveUsers();
                            PlayerManager.SavePlayers();
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice! Please try again.");
                            break;
                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }

        }
    }
