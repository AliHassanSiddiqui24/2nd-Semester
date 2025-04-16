using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge05
{
    public class Car
    {
        private string brand;
        private string color;
        private double pricePerDay;

        public string GetBrand()
        {
            return brand;
        }

        public void SetBrand(string value)
        {
            brand = value;
        }

        public string GetColor()
        {
            return color;
        }

        public void SetColor(string value)
        {
            color = value;
        }

        public double GetPricePerDay()
        {
            return pricePerDay;
        }

        public void SetPricePerDay(double value)
        {
            pricePerDay = value;
        }

        public Car(string brand, string color, double pricePerDay)
        {
            SetBrand(brand);
            SetColor(color);
            SetPricePerDay(pricePerDay);
        }

        public virtual double CalculateRentalCost(int days)
        {
            return GetPricePerDay() * days;
        }

        public override string ToString()
        {
            return $"Brand: {GetBrand()}, Color: {GetColor()}, Price/Day: {GetPricePerDay():C}";
        }
    }
}
