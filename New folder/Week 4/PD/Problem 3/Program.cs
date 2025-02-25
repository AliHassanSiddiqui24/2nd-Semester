using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    internal class Program
    {
        private static List<Player> players = new List<Player>();
        private static List<Stats> skills = new List<Stats>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Magical Duel Menu");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Add Skill Statistics");
                Console.WriteLine("3. Display Player Info");
                Console.WriteLine("4. Learn a Skill");
                Console.WriteLine("5. Attack");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddPlayer();
                        break;
                    case "2":
                        AddSkill();
                        break;
                    case "3":
                        DisplayPlayers();
                        break;
                    case "4":
                        LearnSkill();
                        break;
                    case "5":
                        PerformAttack();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void AddPlayer()
        {
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();

            Console.Write("Enter health: ");
            double health = double.Parse(Console.ReadLine());

            Console.Write("Enter energy: ");
            int energy = int.Parse(Console.ReadLine());

            Console.Write("Enter armor: ");
            double armor = double.Parse(Console.ReadLine());

            players.Add(new Player(name, health, energy, armor));
            Console.WriteLine("Player added successfully!");
            Console.ReadKey ();
        }

        static void AddSkill()
        {
            Console.Write("Enter skill name: ");
            string name = Console.ReadLine();

            Console.Write("Enter damage: ");
            double damage = double.Parse(Console.ReadLine());

            Console.Write("Enter penetration: ");
            double penetration = double.Parse(Console.ReadLine());

            Console.Write("Enter heal value: ");
            int heal = int.Parse(Console.ReadLine());

            Console.Write("Enter energy cost: ");
            int cost = int.Parse(Console.ReadLine());

            Console.Write("Enter description: ");
            string desc = Console.ReadLine();

            skills.Add(new Stats(name, damage, penetration, heal, cost, desc));
            Console.WriteLine("Skill added successfully!");
            Console.ReadKey ();
        }

        static void DisplayPlayers()
        {
            foreach (Player p in players)
            {
                Console.WriteLine($"\n{p.Name}");
                Console.WriteLine($"Health: {p.Hp}/{p.MaxHp}");
                Console.WriteLine($"Energy: {p.Energy}/{p.MaxEnergy}");
                Console.WriteLine($"Armor: {p.Armor}");
                Console.ReadKey();
            }
        }

        static void LearnSkill()
        {
            Console.Write("Enter player name: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter skill name: ");
            string skillName = Console.ReadLine();

            Player player = players.Find(p => p.Name == playerName);
            Stats skill = skills.Find(s => s.Name == skillName);

            if (player != null && skill != null)
            {
                player.LearnSkill(skill);
                Console.WriteLine($"{playerName} learned {skillName}!");
            }
            else
            {
                Console.WriteLine("Player or skill not found!");
            }
            Console.ReadKey();
        }

        static void PerformAttack()
        {
            Console.Write("Enter attacker name: ");
            string attackerName = Console.ReadLine();

            Console.Write("Enter target name: ");
            string targetName = Console.ReadLine();

            Player attacker = players.Find(p => p.Name == attackerName);
            Player target = players.Find(p => p.Name == targetName);

            if (attacker != null && target != null)
            {
                Console.WriteLine(attacker.Attack(target));
            }
            else
            {
                Console.WriteLine("Invalid attacker or target!");
            }
            Console.ReadKey();
        }
    }
}
