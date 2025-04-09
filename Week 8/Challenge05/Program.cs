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
            List<Car> cars = new List<Car>
            {
                new BMW("Black", 150.0, true),
                new BMW("White", 120.0, false),
                new Audi("Red", 100.0, true),
                new Audi("Silver", 90.0, false)
            };

            int rentalDays = 3;
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
