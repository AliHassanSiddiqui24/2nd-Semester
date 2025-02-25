using System;
using System.Collections.Generic;
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
            return Console.ReadLine().Trim();
        }

        public static int GetIntInput(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                    return result;
                Console.WriteLine($"Invalid input! Enter between {min}-{max}");
            }
        }
    }
}
