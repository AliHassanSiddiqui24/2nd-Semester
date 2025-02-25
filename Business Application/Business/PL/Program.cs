using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;
using Business.DL;
using Business.PL;

namespace Business
{
    internal class Program
    {
        static UserManager userManager = new UserManager();
        static PlayerManager playerManager = new PlayerManager();
        static FixtureManager fixtureManager = new FixtureManager();
        static TrainingManager trainingManager = new TrainingManager();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Login\n2. Register\n3. Exit");
                int choice = ValidationHelper.GetIntInput("Enter your choice: ", 1, 3);

                switch (choice)
                {
                    case 1: LoginMenu(); break;
                    case 2: RegisterMenu(); break;
                    case 3: Environment.Exit(0); break;
                }
            }
        }

        static void LoginMenu()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            foreach (User user in userManager.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    if (user.Role == "Manager") ShowManagerMenu();
                    else if (user.Role == "Coach") ShowCoachMenu();
                    return;
                }
            }
            Console.WriteLine("Invalid credentials!");
            Console.ReadKey();
        }


        static void AddPlayerMenu()
        {
            string name = ValidationHelper.GetStringInput("Player name: ");
            string role = ValidationHelper.GetStringInput("Role (Batsman/Bowler/All Rounder): ");
            string region = ValidationHelper.GetStringInput("Region: ");
            int age = ValidationHelper.GetIntInput("Age (18-50): ", 18, 50);
            int matches = ValidationHelper.GetIntInput("Matches played: ", 0, 1000);
            int wins = ValidationHelper.GetIntInput($"Wins (0-{matches}): ", 0, matches);

            playerManager.AddPlayer(name, role, region, age, matches, wins);
            Console.WriteLine("Player added!");
            Console.ReadKey();
        }


        static void ViewPlayersMenu()
        {
            Console.WriteLine("ID\tName\tRole\tRegion\tAge\tMatches\tWins\tLosses");
            foreach (Player p in playerManager.Players)
            {
                Console.WriteLine($"{p.Id}\t{p.Name}\t{p.Role}\t{p.Region}\t{p.Age}\t" +
                                  $"{p.Matches}\t{p.Wins}\t{p.Losses}");
            }
            Console.ReadKey();
        }
        static void ShowManagerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Manager Menu");
                Console.WriteLine("1. Add Player\n2. View Players\n3. Edit Player\n4. Delete Player\n" +
                                "5. Schedule Fixture\n6. View Fixtures\n7. Edit Fixture\n8. Delete Fixture\n" +
                                "9. View Training Sessions\n10. Logout");

                int choice = ValidationHelper.GetIntInput("Enter your choice: ", 1, 10);
                switch (choice)
                {
                    case 1: AddPlayerMenu(); break;
                    case 2: ViewPlayersMenu(); break;
                    case 3: EditPlayerMenu(); break;
                    case 4: DeletePlayerMenu(); break;
                    case 5: ScheduleFixtureMenu(); break;
                    case 6: ViewFixturesMenu(); break;
                    case 7: EditFixtureMenu(); break;
                    case 8: DeleteFixtureMenu(); break;
                    case 9: ViewTrainingSessionsMenu(); break;
                    case 10: return;
                }
            }
        }
        static void EditPlayerMenu()
        {
            ViewPlayersMenu();
            if (playerManager.Players.Count == 0) return;

            int id = ValidationHelper.GetIntInput("Enter Player ID to edit: ", 1, int.MaxValue);
            Player player = playerManager.Players.FirstOrDefault(p => p.Id == id);

            if (player != null)
            {
                Console.WriteLine("Enter new values:");
                player.Name = ValidationHelper.GetStringInput("Name: ");
                player.Role = ValidationHelper.GetStringInput("Role: ");
                player.Region = ValidationHelper.GetStringInput("Region: ");
                player.Age = ValidationHelper.GetIntInput("Age (18-50): ", 18, 50);
                player.Matches = ValidationHelper.GetIntInput("Matches: ", 0, 1000);
                player.Wins = ValidationHelper.GetIntInput($"Wins (0-{player.Matches}): ", 0, player.Matches);

                playerManager.SavePlayers();
                Console.WriteLine("Player updated!");
            }
            else
            {
                Console.WriteLine("Player not found!");
            }
            Console.ReadKey();
        }

        static void ShowCoachMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Coach Menu");
                Console.WriteLine("1. Add Training Session\n2. View Training Sessions\n" +
                                "3. Edit Training Session\n4. Delete Training Session\n" +
                                "5. View Players\n6. View Fixtures\n7. Logout");

                int choice = ValidationHelper.GetIntInput("Enter your choice: ", 1, 7);
                switch (choice)
                {
                    case 1: AddTrainingSessionMenu(); break;
                    case 2: ViewTrainingSessionsMenu(); break;
                    case 3: EditTrainingSessionMenu(); break;
                    case 4: DeleteTrainingSessionMenu(); break;
                    case 5: ViewPlayersMenu(); break;
                    case 6: ViewFixturesMenu(); break;
                    case 7: return;
                }
            }
        }

        #region Fixture Operations
        static void ScheduleFixtureMenu()
        {

                string teams = ValidationHelper.GetStringInput("Teams: ");
                string date = ValidationHelper.GetStringInput("Date (DD/MM/YYYY): ");
                string venue = ValidationHelper.GetStringInput("Venue: ");

                fixtureManager.AddFixture(teams, date, venue);
                Console.WriteLine("Fixture scheduled!");
                Console.ReadKey();
            

        }

        static void ViewFixturesMenu()
        {
            Console.Clear();
            if (fixtureManager.Fixtures.Count == 0)
            {
                Console.WriteLine("No fixtures available!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("ID\tTeams\t\t\tDate\t\tVenue");
            Console.WriteLine("------------------------------------------------------------");
            foreach (Fixture f in fixtureManager.Fixtures)
            {
                Console.WriteLine($"{f.Id}\t{f.Teams,-20}\t{f.Date}\t{f.Venue}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void DeleteFixtureMenu()
        {
            ViewFixturesMenu();
            if (fixtureManager.Fixtures.Count == 0) return;

            int id = ValidationHelper.GetIntInput("\nEnter Fixture ID to delete: ", 1, int.MaxValue);
            fixtureManager.DeleteFixture(id);
            Console.WriteLine("Fixture deleted!");
            Console.ReadKey();
        }
        static void DeletePlayerMenu()
        {
            ViewPlayersMenu();
            if (playerManager.Players.Count == 0) return;

            int id = ValidationHelper.GetIntInput("Enter Player ID to delete: ", 1, int.MaxValue);
            playerManager.DeletePlayer(id);
            Console.WriteLine("Player deleted!");
            Console.ReadKey();
        }
        static void EditFixtureMenu()
        {
            ViewFixturesMenu();
            if (fixtureManager.Fixtures.Count == 0) return;

            int id = ValidationHelper.GetIntInput("\nEnter Fixture ID to edit: ", 1, int.MaxValue);
            var fixture = fixtureManager.Fixtures.FirstOrDefault(f => f.Id == id);

            if (fixture != null)
            {
                Console.WriteLine("\nEnter new values (press Enter to keep current):");

                string newTeams = ValidationHelper.GetStringInput($"Teams ({fixture.Teams}): ");
                if (!string.IsNullOrEmpty(newTeams)) fixture.Teams = newTeams;

                string newDate = ValidationHelper.GetStringInput($"Date ({fixture.Date}): ");
                if (!string.IsNullOrEmpty(newDate)) fixture.Date = newDate;

                string newVenue = ValidationHelper.GetStringInput($"Venue ({fixture.Venue}): ");
                if (!string.IsNullOrEmpty(newVenue)) fixture.Venue = newVenue;

                fixtureManager.SaveFixtures();
                Console.WriteLine("Fixture updated!");
            }
            else
            {
                Console.WriteLine("Fixture not found!");
            }
            Console.ReadKey();
        }
        #endregion

        #region Training Session Operations
        static void AddTrainingSessionMenu()
        {
            string date = ValidationHelper.GetStringInput("Date (DD/MM/YYYY): ");
            string details = ValidationHelper.GetStringInput("Session Details: ");

            trainingManager.AddTrainingSession(date, details);
            Console.WriteLine("Training session added!");
            Console.ReadKey();
        }
        static void ViewTrainingSessionsMenu()
        {
            Console.Clear();
            if (trainingManager.TrainingSessions.Count == 0)
            {
                Console.WriteLine("No training sessions available!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("ID\tDate\t\tDetails");
            Console.WriteLine("----------------------------------------");
            foreach (TrainingSession t in trainingManager.TrainingSessions)
            {
                Console.WriteLine($"{t.Id}\t{t.Date}\t{t.Details}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void DeleteTrainingSessionMenu()
        {
            ViewTrainingSessionsMenu();
            if (trainingManager.TrainingSessions.Count == 0) return;

            Console.Write("\nEnter Session ID to delete: ");
            int id = ValidationHelper.GetIntInput("\nEnter Training Session ID to delete: ", 1, int.MaxValue);
            trainingManager.DeleteTrainingSession(id);
            Console.WriteLine("Training session deleted successfully!");
            Console.ReadKey();
        }

        static void EditTrainingSessionMenu()
        {
            ViewTrainingSessionsMenu();
            if (trainingManager.TrainingSessions.Count == 0) return;

            int id = ValidationHelper.GetIntInput("\nEnter Session ID to edit: ", 1, int.MaxValue);
            var session = trainingManager.TrainingSessions.FirstOrDefault(t => t.Id == id);

            if (session != null)
            {
                Console.WriteLine("\nEnter new values (press Enter to keep current):");

                string newDate = ValidationHelper.GetStringInput($"Date ({session.Date}): ");
                if (!string.IsNullOrEmpty(newDate)) session.Date = newDate;

                string newDetails = ValidationHelper.GetStringInput($"Details ({session.Details}): ");
                if (!string.IsNullOrEmpty(newDetails)) session.Details = newDetails;

                trainingManager.SaveTrainingSessions();
                Console.WriteLine("Training session updated!");
            }
            else
            {
                Console.WriteLine("Session not found!");
            }
            Console.ReadKey();
        }

        static void RegisterMenu()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Role (Manager/Coach): ");
            string role = Console.ReadLine();

            if (userManager.RegisterUser(username, password, role))
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Registration failed!");
            }
            Console.ReadKey();
        }
        #endregion
    }
}
