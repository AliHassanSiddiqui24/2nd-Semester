using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class GLI : Car
    {
        public double FuelEfficiency { get; set; } // km per liter

        public GLI(string color, double pricePerDay, double fuelEfficiency)
            : base("GLI", color, pricePerDay)
        {
            FuelEfficiency = fuelEfficiency;
        }

        public double CalculateFuelUsed(double distance)
        {
            return distance / FuelEfficiency;
        }

        public string GetGLIInfo()
        {
            return $"{GetCarInfo()}, FuelEfficiency: {FuelEfficiency} km/l";
        }
    }
}
