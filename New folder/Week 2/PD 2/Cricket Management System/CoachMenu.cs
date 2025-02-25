using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System
{
    public class CoachMenu
    {
        public static void Show(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("COACH MENU");
                Console.WriteLine("1. View Players");
                Console.WriteLine("2. Logout");
                Console.Write("Enter choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        PlayerManager.ViewPlayers();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}

