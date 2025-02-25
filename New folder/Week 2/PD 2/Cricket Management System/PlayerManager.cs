using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System
{
    public class PlayerManager
    {
        private static List<Player> players = new List<Player>();
        private static int nextId = 1;

        public static void AddPlayer()
        {
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();

            Console.Write("Enter role (Batsman/Bowler/All Rounder): ");
            string role = Console.ReadLine();

            Console.Write("Enter region: ");
            string region = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter matches played: ");
            int matches = int.Parse(Console.ReadLine());

            Console.Write("Enter wins: ");
            int wins = int.Parse(Console.ReadLine());

            players.Add(new Player(nextId++, name, role, region, age, matches, wins));
            SavePlayers();
            Console.WriteLine("Player added successfully!");
        }

        public static void ViewPlayers()
        {
            Console.WriteLine("ID\tName\tRole\tRegion\tAge\tMatches\tWins\tLosses");
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Id}\t{player.Name}\t{player.Role}\t" +
                                  $"{player.Region}\t{player.Age}\t" +
                                  $"{player.MatchesPlayed}\t{player.Wins}\t{player.Losses}");
            }
        }

        public static void SavePlayers()
        {
            using (StreamWriter writer = new StreamWriter("players.txt"))
            {
                foreach (Player player in players)
                {
                    writer.WriteLine($"{player.Id},{player.Name},{player.Role}," +
                                    $"{player.Region},{player.Age}," +
                                    $"{player.MatchesPlayed},{player.Wins}");
                }
            }
        }

        public static void LoadPlayers()
        {
            if (File.Exists("players.txt"))
            {
                string[] lines = File.ReadAllLines("players.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 7)
                    {
                        players.Add(new Player(
                            int.Parse(parts[0]),
                            parts[1],
                            parts[2],
                            parts[3],
                            int.Parse(parts[4]),
                            int.Parse(parts[5]),
                            int.Parse(parts[6])
                        ));
                        nextId = int.Parse(parts[0]) + 1;
                    }
                }
            }
        }
        public static void UpdatePlayer()
        {
            Console.Write("Enter Player ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format!");
                return;
            }

            Player player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                Console.WriteLine("Player not found!");
                return;
            }

            Console.WriteLine("Leave blank to keep current value");

            Console.Write($"New Name ({player.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) player.Name = name;

            Console.Write($"New Role ({player.Role}): ");
            string role = Console.ReadLine();
            if (!string.IsNullOrEmpty(role)) player.Role = role;

            Console.Write($"New Region ({player.Region}): ");
            string region = Console.ReadLine();
            if (!string.IsNullOrEmpty(region)) player.Region = region;

            Console.Write($"New Age ({player.Age}): ");
            string ageInput = Console.ReadLine();
            if (int.TryParse(ageInput, out int age)) player.Age = age;

            Console.Write($"New Matches ({player.MatchesPlayed}): ");
            string matchesInput = Console.ReadLine();
            if (int.TryParse(matchesInput, out int matches)) player.MatchesPlayed = matches;

            Console.Write($"New Wins ({player.Wins}): ");
            string winsInput = Console.ReadLine();
            if (int.TryParse(winsInput, out int wins)) player.Wins = wins;

            SavePlayers();
            Console.WriteLine("Player updated successfully!");
        }

        public static void DeletePlayer()
        {
            Console.Write("Enter Player ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format!");
                return;
            }

            Player player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                Console.WriteLine("Player not found!");
                return;
            }

            players.Remove(player);
            SavePlayers();
            Console.WriteLine("Player deleted successfully!");
        }
    }
}
