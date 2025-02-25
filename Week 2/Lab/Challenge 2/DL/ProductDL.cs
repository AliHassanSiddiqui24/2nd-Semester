using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_2.BL;

namespace Challenge_2.DL
{
    public class ProductDL
    {
        private static List<Product> products = new List<Product>();
        public static void AddProduct()
        {
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Brand Name: ");
            string brandName = Console.ReadLine();
            Console.Write("Enter Country: ");
            string country = Console.ReadLine();

            Product newProduct = new Product(id, name, price, category, brandName, country);
            products.Add(newProduct);
            Console.WriteLine(" Product added successfully!\n");
        }
        public static void ShowProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine(" No products available.");
            }
            else
            {
                Console.WriteLine("\n Product List:");
                foreach (Product p in products)
                {
                    p.DisplayInfo();
                }
            }
        }
        public static void ShowTotalWorth()
        {
            float totalWorth = products.Sum(p => p.Price);
            Console.WriteLine($"\nTotal Store Worth: {totalWorth:F2}");
        }
    }
}

