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
                new Audi("Silver", 90.0, false),
                new GLI("Blue", 110.0, 15.0) // Added GLI here
            };

            int rentalDays = 3;
            foreach (Car car in cars)
            {
                Console.WriteLine(car.GetCarInfo());
                double cost = car.CalculateRentalCost(rentalDays);
                Console.WriteLine($"Rental cost for {rentalDays} days: {cost:C}");

                // Specific handling for each car type
                if (car is BMW)
                {
                    BMW bmw = (BMW)car;
                    Console.WriteLine($"Luxury Package: {bmw.HasLuxuryPackage}");
                }
                else if (car is Audi)
                {
                    Audi audi = (Audi)car;
                    Console.WriteLine($"Has Sunroof: {audi.HasSunroof}");
                }
                else if (car is GLI)
                {
                    GLI gli = (GLI)car;
                    Console.WriteLine($"Fuel Efficiency: {gli.FuelEfficiency} km/l");
                    Console.WriteLine($"Fuel used for 300 km: {gli.CalculateFuelUsed(300):F2} liters");
                }

                Console.WriteLine("-------------------------------------------");
            }
        }
    }
    
}
