using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;
using Business.DL;
using Business.PL;
using Business.UI;

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
                    case 1:
                        AuthUI.LoginMenu(userManager, playerManager, fixtureManager, trainingManager);
                        break;
                    case 2:
                        AuthUI.ShowRegisterMenu(userManager);
                        break;
                    case 3:
                        return;
                }
            }
        }








    }
}
