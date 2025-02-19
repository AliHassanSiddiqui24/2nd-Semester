using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Products p = new Products();
            while (true)
            {

                Console.Clear();
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Show Products");
                Console.WriteLine("3. Total Store Worth");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    p.AddProduct();
                }
                else if (choice == 2)
                {
                    p.ShowProduct();
                }
                else if (choice == 3)
                {
                    p.TotalStoreWorth();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Exiting Program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Try Again.");
                }
            }
        }
    }

}
    

