using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Self2
{
    public class Products
    {
        public int ProductID;
        public string Name;
        public float Price;
        public string Category;
        public string BrandName;
        public string Country;
        public Products(int ProductID, string Name, float Price, string Category, string BrandName, string Country)
        {
            this.ProductID = ProductID;
            this.Name = Name;
            this.Price = Price;
            this.Category = Category;
            this.BrandName = BrandName;
            this.Country = Country;
        }

        public Products()
        {
        }

        public List<Products> Multiply = new List<Products>();
        public void AddProduct()
        {
            Console.WriteLine("Enter Product ID: ");
            int ProductID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Price: ");
            float Price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Category: ");
            string Category = Console.ReadLine();
            Console.WriteLine("Enter BrandName: ");
            string BrandName = Console.ReadLine();
            Console.WriteLine("Enter Country: ");
            string Country = Console.ReadLine();

            Multiply.Add(new Products(ProductID, Name, Price, Category, BrandName, Country));
            Console.WriteLine("Product added successfully");
            Console.ReadKey();
        }
        //public void ShowProduct()
        //{
        //    foreach (var products in Multiply)
        //    {
        //        Console.WriteLine($"ProductId: {products.ProductID}, Name: {products.Name}, Price: {products.Price}, Category: {products.Category}, BrandName: {products.BrandName}, Country: {products.Country} ");
        //    }
        //}
        public void ShowProduct()
        {
            for (int i = 0; i < Multiply.Count; i++) 
                {
                    Products p = Multiply[i];
                    Console.WriteLine($"ProductId: {p.ProductID}, Name: {p.Name}, Price: {p.Price}, Category: {p.Category}, BrandName: {p.BrandName}, Country: {p.Country} ");
                }
            Console.ReadKey();
            }
        public void TotalStoreWorth()
        {
            float worth = 0;

            for (int i = 0; i < Multiply.Count; i++)
            {
                worth = worth + Multiply[i].Price;
            }
            Console.WriteLine("Total Store Worth is" + worth);
            Console.ReadKey();
        }
    }
}
