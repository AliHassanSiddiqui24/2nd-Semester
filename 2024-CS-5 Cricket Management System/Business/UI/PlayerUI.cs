using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;
using Business.DL;
using Business.PL;

namespace Business.UI
{
    public static class PlayerUI
    {
        public static void AddPlayerMenu(PlayerManager manager)
        {
            string name = ValidationHelper.GetStringInput("Player name: ");
            string role = ValidationHelper.GetRoleInput();
            string region = ValidationHelper.GetCityInput();
            int age = ValidationHelper.GetIntInput("Age (18-50): ", 18, 50);
            int matches = ValidationHelper.GetIntInput("Matches played: ", 0, 1000);
            int wins = ValidationHelper.GetIntInput($"Wins (0-{matches}): ", 0, matches);

            manager.AddPlayer(name, role, region, age, matches, wins);
            Console.WriteLine("Player added!");
            Console.ReadKey();
        }

        public static void ViewPlayersMenu(PlayerManager manager)
        {
            Console.WriteLine("ID\tName\tRole\tRegion\tAge\tMatches\tWins\tLosses");
            foreach (Player p in manager.Players)
            {
                Console.WriteLine($"{p.Id}\t{p.Name}\t{p.Role}\t{p.Region}\t{p.Age}\t" +
                                $"{p.Matches}\t{p.Wins}\t{p.Losses}");
            }
            Console.ReadKey();
        }
        public static void DeletePlayerMenu(PlayerManager manager)
        {
            ViewPlayersMenu(manager);
            if (manager.Players.Count == 0) return;

            int id = ValidationHelper.GetIntInput("Enter Player ID to delete: ", 1, int.MaxValue);

            if (manager.Players.Any(p => p.Id == id))
            {
                manager.DeletePlayer(id);
                Console.WriteLine("Player deleted!");
            }
            else
            {
                Console.WriteLine("Player ID not found! Press any key to continue...");
            }

            Console.ReadKey();
        }

        public static void EditPlayerMenu(PlayerManager manager)
        {
            ViewPlayersMenu(manager);
            if (manager.Players.Count == 0)
            {
                return;
            }

            int id = ValidationHelper.GetIntInput("Enter Player ID to edit: ", 1, int.MaxValue);
            Player player = manager.Players.FirstOrDefault(p => p.Id == id);

            if (player != null)
            {
                Console.WriteLine("Enter new values:");
                player.Name = ValidationHelper.GetStringInput("Name: ");
                player.Role = ValidationHelper.GetRoleInput();
                player.Region = ValidationHelper.GetStringInput("Region: ");
                player.Age = ValidationHelper.GetIntInput("Age (18-50): ", 18, 50);
                player.Matches = ValidationHelper.GetIntInput("Matches: ", 0, 1000);
                player.Wins = ValidationHelper.GetIntInput($"Wins (0-{player.Matches}): ", 0, player.Matches);

                manager.SavePlayers();
                Console.WriteLine("Player updated!");
            }
            else
            {
                Console.WriteLine("Player not found!");
            }
            Console.ReadKey();
        }

    }
}
