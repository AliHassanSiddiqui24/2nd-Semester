using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Car Rental System ===");
                Console.WriteLine("1. Add a BMW Car");
                Console.WriteLine("2. Add an Audi Car");
                Console.WriteLine("3. Show All Cars and Calculate Rental Costs");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddBMWCar(cars);
                        break;
                    case 2:
                        AddAudiCar(cars);
                        break;
                    case 3:
                        ShowAllCarsAndRentalCosts(cars);
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the Car Rental System. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        static void AddBMWCar(List<Car> cars)
        {
            Console.WriteLine("\nEnter details for BMW car:");
            Console.Write("Enter color: ");
            string color = Console.ReadLine();
            Console.Write("Enter price per day: ");
            double pricePerDay = double.Parse(Console.ReadLine());
            Console.Write("Does the car have a luxury package (true/false)? ");
            bool hasLuxuryPackage = bool.Parse(Console.ReadLine());

            BMW bmw = new BMW(color, pricePerDay, hasLuxuryPackage);
            cars.Add(bmw);
            Console.WriteLine("BMW car added successfully!");
        }

        static void AddAudiCar(List<Car> cars)
        {
            Console.WriteLine("\nEnter details for Audi car:");
            Console.Write("Enter color: ");
            string color = Console.ReadLine();
            Console.Write("Enter price per day: ");
            double pricePerDay = double.Parse(Console.ReadLine());
            Console.Write("Does the car have a sunroof (true/false)? ");
            bool hasSunroof = bool.Parse(Console.ReadLine());

            Audi audi = new Audi(color, pricePerDay, hasSunroof);
            cars.Add(audi);
            Console.WriteLine("Audi car added successfully!");
        }

        static void ShowAllCarsAndRentalCosts(List<Car> cars)
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available. Please add cars first.");
                return;
            }

            Console.Write("Enter the number of rental days: ");
            int rentalDays = int.Parse(Console.ReadLine());

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
                double cost = car.CalculateRentalCost(rentalDays);
                Console.WriteLine($"Rental cost for {rentalDays} days: {cost:C}");
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}

