using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2.BL
{
    public class Product
    {
        public int ID;
        public string Name;
        public float Price;
        public string Category;
        public string BrandName;
        public string Country;

        public Product(int id, string name, float price, string category, string brandName, string country)
        {
            ID = id;
            Name = name;
            Price = price;
            Category = category;
            BrandName = brandName;
            Country = country;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}, Name: {Name}, Price: {Price}, Category: {Category}, Brand: {BrandName}, Country: {Country}");
        }
    }
}

