using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    internal class Program
    {
        static List<Product> products = new List<Product>();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Department Store Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Find Highest Price Product");
                Console.WriteLine("4. View Sales Tax");
                Console.WriteLine("5. Products to Order");
                Console.WriteLine("6. Exit");
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1": AddProduct();
                        Console.ReadKey();
                        break;
                    case "2": ViewProducts();
                        Console.ReadKey(); 
                        break;
                    case "3": FindHighestPrice();
                        Console.ReadKey(); 
                        break;
                    case "4": ShowTax();
                        Console.ReadKey(); 
                        break;
                    case "5": ShowOrderList();
                        Console.ReadKey(); 
                        break;
                    case "6": return;
                    default: Console.WriteLine("Invalid option!"); break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Category (Groceries/Fresh Fruit/Other): ");
            string category = Console.ReadLine();

            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Current Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Console.Write("Minimum Stock: ");
            int minStock = Convert.ToInt32(Console.ReadLine());

            products.Add(new Product(name, category, price, stock, minStock));
            Console.WriteLine("Product added!");
        }

        static void ViewProducts()
        {
            Console.WriteLine("\nAll Products:");
            foreach (Product p in products)
            {
                Console.WriteLine($"{p.Name} ({p.Category}) - Price: {p.Price:C}, Stock: {p.StockQuantity}, Min Stock: {p.MinimumStockQuantity}");
            }
        }

        static void FindHighestPrice()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available!");
                return;
            }

            Product highest = products[0];
            foreach (Product p in products)
            {
                if (p.Price > highest.Price) highest = p;
            }

            Console.WriteLine($"Highest Priced Product: {highest.Name} - {highest.Price:C}");
        }

        static void ShowTax()
        {
            Console.WriteLine("\nSales Tax:");
            foreach (Product p in products)
            {
                Console.WriteLine($"{p.Name}: {p.CalculateTax():C}");
            }
        }

        static void ShowOrderList()
        {
            Console.WriteLine("\nProducts to Order:");
            foreach (Product p in products)
            {
                if (p.StockQuantity < p.MinimumStockQuantity)
                {
                    Console.WriteLine($"{p.Name} (Current: {p.StockQuantity}, Minimum: {p.MinimumStockQuantity})");
                }
            }
        }
    }
}

