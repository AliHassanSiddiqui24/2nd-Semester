using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System
{
    public class ManagerMenu
    {
        public static void Show(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("MANAGER MENU");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. View Players");
                Console.WriteLine("3. Update Player");
                Console.WriteLine("4. Delete Player");
                Console.WriteLine("5. Logout");
                Console.Write("Enter choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        PlayerManager.AddPlayer();
                        break;
                    case "2":
                        PlayerManager.ViewPlayers();
                        break;
                    case "3":
                        PlayerManager.UpdatePlayer();
                        break;
                    case "4":
                        PlayerManager.DeletePlayer();
                        break;
                    case "5":
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

