using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class BMW : Car
    {
        public bool HasLuxuryPackage { get; set; }

        public BMW(string color, double pricePerDay, bool hasLuxuryPackage) : base("BMW", color, pricePerDay)

        {
            HasLuxuryPackage = hasLuxuryPackage;
        }

        public override double CalculateRentalCost(int days)
        {
            double baseCost = base.CalculateRentalCost(days);
            if (HasLuxuryPackage)
            {
                baseCost += 50.0 * days;
            }
            return baseCost;
        }

        public override string ToString()
        {
            return base.ToString() + $", LuxuryPackage: {HasLuxuryPackage}";
        }
    }
}
