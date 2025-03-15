using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.PL
{
    public class ValidationHelper
    {
        public static string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static int GetIntInput(string prompt, int min, int max)
        {
            int result;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                bool isNumber = true;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] < '0' || input[i] > '9')
                    {
                        isNumber = false;
                        break;
                    }
                }

                if (isNumber && input.Length > 0)
                {
                    result = 0;
                    for (int i = 0; i < input.Length; i++)
                    {
                        result = result * 10 + (input[i] - '0');
                    }

                    if (result >= min && result <= max)
                    {
                        return result;
                    }
                }

                Console.WriteLine("Invalid input! Enter a number between " + min + "-" + max);
            }
        }


        public static string GetRoleInput()
        {
            string role;

            while (true)
            {
                Console.Write("Role (Batsman/Bowler/All Rounder): ");
                role = Console.ReadLine().Trim();
                if (role == "Batsman" || role == "Bowler" || role == "All Rounder")
                {
                    return role;
                }

                Console.WriteLine("Invalid role! Choose from Batsman, Bowler, or All Rounder.\n");
            }
        }

        public static string GetUserRoleInput()
        {
            string role;

            while (true)
            {
                Console.Write("Role (Manager/Coach): ");
                role = Console.ReadLine();

                if (role == "Manager" || role == "Coach")
                {
                    return role;
                }

                Console.WriteLine("Invalid role! You must enter either 'Manager' or 'Coach'.\n");
            }
        }

        private static string[] validCities =
{
                "Karachi", "Lahore", "Islamabad", "Rawalpindi", "Peshawar",
                    "Quetta", "Multan", "Faisalabad", "Hyderabad", "Gujranwala"
};

        public static string GetCityInput()
        {
            while (true)
            {
                Console.Write("Region (Pakistan city): ");
                string input = Console.ReadLine();
 
                for (int i = 0; i < validCities.Length; i++)
                {
                    if (input == validCities[i])
                    {
                        return input;
                    }
                }

                Console.WriteLine("Invalid city! Please enter a valid Pakistan city.");
            }
        }


        public static string GetFutureDateInput()
        {
            DateTime minDate = new DateTime(2025, 3, 1);

            while (true)
            {
                Console.Write("Enter Date (DD-MM-YYYY): ");
                string input = Console.ReadLine();
                string[] parts = input.Split('-');

                if (parts.Length == 3)
                {
                    bool validDay = parts[0].All(char.IsDigit);
                    bool validMonth = parts[1].All(char.IsDigit);
                    bool validYear = parts[2].All(char.IsDigit);

                    if (validDay && validMonth && validYear)
                    {
                        int day = Convert.ToInt32(parts[0]);
                        int month = Convert.ToInt32(parts[1]);
                        int year = Convert.ToInt32(parts[2]);

                        if (month >= 1 && month <= 12 && day >= 1 && day <= 31)
                        {
                            DateTime date = new DateTime(year, month, day);
                            if (date >= minDate)
                            {
                                return input;
                            }
                            Console.WriteLine("Date must be after March 2025!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date! Please enter a valid day, month, and year.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid format! Please enter numbers in DD-MM-YYYY format.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format! Please enter the date in DD-MM-YYYY format.");
                }
            }
        }

    }
}
