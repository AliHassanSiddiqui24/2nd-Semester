using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Challenge_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" Products Management System");
                Console.WriteLine("1️. Add Product");
                Console.WriteLine("2️. Show Products");
                Console.WriteLine("3️. Total Store Worth");
                Console.WriteLine("4️. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DL.ProductDL.AddProduct();
                        Console.ReadKey();
                        break;
                    case 2:
                        DL.ProductDL.ShowProducts();
                        Console.ReadKey();
                        break;
                    case 3:
                        DL.ProductDL.ShowTotalWorth();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
    
}
