using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DL;
using Business.PL;

namespace Business.UI
{
    public class ManagerMenuUI
    {
        public static void ShowManagerMenu(PlayerManager playerManager, FixtureManager fixtureManager, TrainingManager trainingManager)
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
                    case 1: PlayerUI.AddPlayerMenu(playerManager); break;
                    case 2: PlayerUI.ViewPlayersMenu(playerManager); break;
                    case 3: PlayerUI.EditPlayerMenu(playerManager); break;
                    case 4: PlayerUI.DeletePlayerMenu(playerManager); break;
                    case 5: FixtureUI.ScheduleFixtureMenu(fixtureManager); break;
                    case 6: FixtureUI.ViewFixturesMenu(fixtureManager); break;
                    case 7: FixtureUI.EditFixtureMenu(fixtureManager); break;
                    case 8: FixtureUI.DeleteFixtureMenu(fixtureManager); break;
                    case 9: TrainingUI.ViewTrainingSessionsMenu(trainingManager); break;
                    case 10: return;
                }
            }
        }
    }
}
