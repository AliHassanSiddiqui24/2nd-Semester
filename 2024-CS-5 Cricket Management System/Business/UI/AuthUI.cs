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
    public static class AuthUI
    {
        public static void LoginMenu(UserManager userManager, PlayerManager pManager, FixtureManager fManager,TrainingManager tManager )
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            foreach (User user in userManager.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    if (user.Role == "Manager")
                    {


                        ManagerMenuUI.ShowManagerMenu(pManager, fManager, tManager);
                    }
                    else if (user.Role == "Coach")
                    {
                        CoachMenuUI.ShowCoachMenu(tManager, pManager, fManager);
                    }
                    return;
                }
            }
            Console.WriteLine("Invalid credentials!");
            Console.ReadKey();
        }

        public static void ShowRegisterMenu(UserManager manager)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            string role = ValidationHelper.GetUserRoleInput();

            if (manager.RegisterUser(username, password, role))
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Registration failed!");
            }
            Console.ReadKey();
        }
    }
}
