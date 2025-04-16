using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class Audi : Car
    {
        private bool hasSunroof;

        public bool GetHasSunroof()
        {
            return hasSunroof;
        }

        public void SetHasSunroof(bool value)
        {
            hasSunroof = value;
        }

        public Audi(string color, double pricePerDay, bool hasSunroof) : base("Audi", color, pricePerDay)

        {
            SetHasSunroof(hasSunroof);
        }

        public override double CalculateRentalCost(int days)
        {
            double baseCost = base.CalculateRentalCost(days);
            if (GetHasSunroof())
            {
                baseCost -= 10.0 * days;
            }
            return baseCost;
        }

        public override string ToString()
        {
            return base.ToString() + $", Sunroof: {GetHasSunroof()}";
        }
    }
}
