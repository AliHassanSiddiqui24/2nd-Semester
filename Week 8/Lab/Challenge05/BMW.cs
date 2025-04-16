using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class BMW : Car
    {
        private bool hasLuxuryPackage;

        public bool GetHasLuxuryPackage()
        {
            return hasLuxuryPackage;
        }

        public void SetHasLuxuryPackage(bool value)
        {
            hasLuxuryPackage = value;
        }

        public BMW(string color, double pricePerDay, bool hasLuxuryPackage) : base("BMW", color, pricePerDay)

        {
            SetHasLuxuryPackage(hasLuxuryPackage);
        }

        public override double CalculateRentalCost(int days)
        {
            double baseCost = base.CalculateRentalCost(days);
            if (GetHasLuxuryPackage())
            {
                baseCost += 50.0 * days;
            }
            return baseCost;
        }

        public override string ToString()
        {
            return base.ToString() + $", LuxuryPackage: {GetHasLuxuryPackage()}";
        }
    }
}
