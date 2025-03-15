using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DL;
using Business.PL;

namespace Business.UI
{
    public class CoachMenuUI
    {
        public static void ShowCoachMenu(TrainingManager tmanager, PlayerManager pManager, FixtureManager fManager)
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
                    case 1: TrainingUI.AddTrainingSessionMenu(tmanager); break;
                    case 2: TrainingUI.ViewTrainingSessionsMenu(tmanager); break;
                    case 3: TrainingUI.EditTrainingSessionMenu(tmanager); break;
                    case 4: TrainingUI.DeleteTrainingSessionMenu(tmanager); break;
                    case 5: PlayerUI.ViewPlayersMenu(pManager); break;
                    case 6: FixtureUI.ViewFixturesMenu(fManager); break;
                    case 7: return;
                }
            }
        }
    }
}
