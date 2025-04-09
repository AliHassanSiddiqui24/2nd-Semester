using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class Audi : Car
    {
        public bool HasSunroof { get; set; }

        public Audi(string color, double pricePerDay, bool hasSunroof)
            : base("Audi", color, pricePerDay)
        {
            HasSunroof = hasSunroof;
        }

        public double CalculateRentalCost(int days)
        {
            double baseCost = base.CalculateRentalCost(days);
            if (HasSunroof)
            {
                baseCost -= 10.0 * days;
            }
            return baseCost;
        }

        public string GetAudiInfo()
        {
            return $"{GetCarInfo()}, Sunroof: {HasSunroof}";
        }
    }
}
