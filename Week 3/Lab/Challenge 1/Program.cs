using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    internal class Program
    {
        static ClockManager manager = new ClockManager();

        public static void Main()
        {
            // Initialize two clocks
            manager.AddClock(new Clock());
            manager.AddClock(new Clock());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Clock System");
                Console.WriteLine("1. Set Clock 1 Time");
                Console.WriteLine("2. Set Clock 2 Time");
                Console.WriteLine("3. Show Elapsed Time");
                Console.WriteLine("4. Show Remaining Time");
                Console.WriteLine("5. Show Time Difference");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": SetClockTime(0); break;
                    case "2": SetClockTime(1); break;
                    case "3": ShowElapsed(); break;
                    case "4": ShowRemaining(); break;
                    case "5": ShowDifference(); break;
                    case "6": return;
                }
            }
        }

        static void SetClockTime(int index)
        {
            int h = GetNumber($"Enter hours (0-23) for Clock {index + 1}: ", 0, 23);
            int m = GetNumber($"Enter minutes (0-59) for Clock {index + 1}: ", 0, 59);
            int s = GetNumber($"Enter seconds (0-59) for Clock {index + 1}: ", 0, 59);

            manager.UpdateClock(index, h, m, s);
            Console.WriteLine($"Clock {index + 1} updated!");
            Console.ReadKey();
        }

        static int GetNumber(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (IsValidNumber(input, min, max))
                    return int.Parse(input);
                Console.WriteLine($"Invalid input! Enter {min}-{max}");
            }
        }

        static bool IsValidNumber(string input, int min, int max)
        {
            if (string.IsNullOrEmpty(input)) return false;
            foreach (char c in input)
            {
                if (!char.IsDigit(c)) return false;
            }
            int num = int.Parse(input);
            return num >= min && num <= max;
        }

        static void ShowElapsed()
        {
            for (int i = 0; i < manager.ClockCount; i++)
            {
                Clock c = manager.GetClock(i);
                Console.WriteLine($"Clock {i + 1}: {c.CalculateElapsedSeconds()} seconds");
            }
            Console.ReadKey();
        }

        static void ShowRemaining()
        {
            for (int i = 0; i < manager.ClockCount; i++)
            {
                Clock c = manager.GetClock(i);
                Console.WriteLine($"Clock {i + 1}: {c.CalculateRemainingSeconds()} seconds");
            }
            Console.ReadKey();
        }

        static void ShowDifference()
        {
            int diff = manager.CalculateTimeDifference(0, 1);
            Console.WriteLine($"Time difference: {diff} seconds");
            Console.ReadKey();
        }
    }
}
