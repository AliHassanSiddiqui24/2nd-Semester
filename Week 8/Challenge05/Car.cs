using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class Car
    {
        public string Brand { get; protected set; }
        public string Color { get; set; }
        public double PricePerDay { get; set; }

        public Car(string brand, string color, double pricePerDay)
        {
            Brand = brand;
            Color = color;
            PricePerDay = pricePerDay;
        }

        public virtual double CalculateRentalCost(int days)
        {
            return PricePerDay * days;
        }

        public override string ToString()
        {
            return $"Brand: {Brand}, Color: {Color}, Price/Day: {PricePerDay:C}";
        }
    }
}
