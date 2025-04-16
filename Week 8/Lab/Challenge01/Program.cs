using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Mountain Bike Creator ====");

            // Initial input from user
            Console.Write("Enter initial cadence: ");
            int cadence = int.Parse(Console.ReadLine());

            Console.Write("Enter initial speed: ");
            int speed = int.Parse(Console.ReadLine());

            Console.Write("Enter initial gear: ");
            int gear = int.Parse(Console.ReadLine());

            Console.Write("Enter initial seat height: ");
            int seatHeight = int.Parse(Console.ReadLine());

            MountainBike mb = new MountainBike(seatHeight, cadence, speed, gear);

            while (true)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1. Set Cadence");
                Console.WriteLine("2. Set Gear");
                Console.WriteLine("3. Set Speed");
                Console.WriteLine("4. Set Seat Height");
                Console.WriteLine("5. Apply Brake");
                Console.WriteLine("6. Speed Up");
                Console.WriteLine("7. Show Bike Details");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new cadence: ");
                        mb.SetCadence(int.Parse(Console.ReadLine()));
                        break;

                    case "2":
                        Console.Write("Enter new gear: ");
                        mb.SetGear(int.Parse(Console.ReadLine()));
                        break;

                    case "3":
                        Console.Write("Enter new speed: ");
                        mb.SetSpeed(int.Parse(Console.ReadLine()));
                        break;

                    case "4":
                        Console.Write("Enter new seat height: ");
                        mb.SetSeatHeight(int.Parse(Console.ReadLine()));
                        break;

                    case "5":
                        Console.Write("Enter brake value to decrease speed: ");
                        mb.ApplyBrake(int.Parse(Console.ReadLine()));
                        break;

                    case "6":
                        Console.Write("Enter value to increase speed: ");
                        mb.SpeedUp(int.Parse(Console.ReadLine()));
                        break;

                    case "7":
                        Console.WriteLine("\n--- Bike Details ---");
                        Console.WriteLine($"Cadence: {mb.GetCadence()}");
                        Console.WriteLine($"Gear: {mb.GetGear()}");
                        Console.WriteLine($"Speed: {mb.GetSpeed()}");
                        Console.WriteLine($"Seat Height: {mb.GetSeatHeight()}");
                        break;

                    case "8":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
