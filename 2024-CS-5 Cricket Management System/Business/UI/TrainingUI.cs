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
    public class TrainingUI
    {
        public static void AddTrainingSessionMenu(TrainingManager manager)
        {
            string date = ValidationHelper.GetFutureDateInput();
            string details = ValidationHelper.GetStringInput("Session Details: ");

            manager.AddTrainingSession(date, details);
            Console.WriteLine("Training session added!");
            Console.ReadKey();
        }
        public static void ViewTrainingSessionsMenu(TrainingManager manager)
        {
            Console.Clear();
            if (manager.TrainingSessions.Count == 0)
            {
                Console.WriteLine("No training sessions available!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("ID\tDate\t\tDetails");
            Console.WriteLine("----------------------------------------");
            foreach (TrainingSession t in manager.TrainingSessions)
            {
                Console.WriteLine($"{t.Id}\t{t.Date}\t{t.Details}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        public static void DeleteTrainingSessionMenu(TrainingManager manager)
        {
            ViewTrainingSessionsMenu(manager);
            if (manager.TrainingSessions.Count == 0) return;

            int id = ValidationHelper.GetIntInput("\nEnter Training Session ID to delete: ", 1, int.MaxValue);

            if (manager.TrainingSessions.Any(t => t.Id == id))
            {
                manager.DeleteTrainingSession(id);
                Console.WriteLine("Training session deleted successfully!");
            }
            else
            {
                Console.WriteLine("Session ID not found! Press any key to continue...");
            }

            Console.ReadKey();
        }

        public static void EditTrainingSessionMenu(TrainingManager manager)
        {
            ViewTrainingSessionsMenu(manager);

            if (manager.TrainingSessions.Count == 0)
            {
                return;
            }

            int id = ValidationHelper.GetIntInput("Enter Session ID to edit: ", 1, 9999);
            TrainingSession session = null;
            for (int i = 0; i < manager.TrainingSessions.Count; i++)
            {
                if (manager.TrainingSessions[i].Id == id)
                {
                    session = manager.TrainingSessions[i];
                    break;
                }
            }

            if (session != null)
            {
                Console.WriteLine("Enter new values:");

                session.Date = ValidationHelper.GetStringInput("Date (DD-MM-YYYY): ");
                session.Details = ValidationHelper.GetStringInput("Details: ");

                manager.SaveTrainingSessions();
                Console.WriteLine("Training session updated!");
            }
            else
            {
                Console.WriteLine("Session not found!");
            }

            Console.ReadKey();
        }

    }
}
