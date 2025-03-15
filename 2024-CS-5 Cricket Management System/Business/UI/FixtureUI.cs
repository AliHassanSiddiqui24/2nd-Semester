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
    public class FixtureUI
    {
        public static void ScheduleFixtureMenu(FixtureManager manager)
        {
            string teams = ValidationHelper.GetStringInput("Teams: ");
            string date = ValidationHelper.GetFutureDateInput();
            string venue = ValidationHelper.GetStringInput("Venue: ");

            manager.AddFixture(teams, date, venue);
            Console.WriteLine("Fixture scheduled!");
            Console.ReadKey();
        }
        public static void ViewFixturesMenu(FixtureManager manager)
        {
            Console.Clear();
            if (manager.fix.Count == 0)
            {
                Console.WriteLine("No fixtures available!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("ID\tTeams\t\t\tDate\t\tVenue");
            Console.WriteLine("------------------------------------------------------------");
            foreach (Fixture f in manager.fix)
            {
                Console.WriteLine($"{f.Id}\t{f.Teams,-20}\t{f.Date}\t{f.Venue}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        public static void DeleteFixtureMenu(FixtureManager manager)
        {
            ViewFixturesMenu(manager);
            if (manager.fix.Count == 0) return;

            int id = ValidationHelper.GetIntInput("\nEnter Fixture ID to delete: ", 1, int.MaxValue);

            if (manager.fix.Any(f => f.Id == id))
            {
                manager.DeleteFixture(id);
                Console.WriteLine("Fixture deleted!");
            }
            else
            {
                Console.WriteLine("Fixture ID not found! Press any key to continue...");
            }

            Console.ReadKey();
        }


        public static void EditFixtureMenu(FixtureManager manager)
        {
            ViewFixturesMenu(manager);

            if (manager.fix.Count == 0)
            {
                return;
            }

            int id = ValidationHelper.GetIntInput("Enter Fixture ID to edit: ", 1, 9999);

            Fixture fixture = null;
            for (int i = 0; i < manager.fix.Count; i++)
            {
                if (manager.fix[i].Id == id)
                {
                    fixture = manager.fix[i];
                    break;
                }
            }

            if (fixture != null)
            {
                Console.WriteLine("Enter new values:");

                fixture.Teams = ValidationHelper.GetStringInput("Teams (Country vs Country) :  ");
                fixture.Date = ValidationHelper.GetStringInput("Date (DD-MM-YYYY): ");
                fixture.Venue = ValidationHelper.GetStringInput("Venue: ");

                manager.SaveFixtures();
                Console.WriteLine("Fixture updated!");
            }
            else
            {
                Console.WriteLine("Fixture not found!");
            }

            Console.ReadKey();
        }


    }
}
