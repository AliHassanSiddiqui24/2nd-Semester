using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle original = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nCircle Menu:");
                Console.WriteLine("1. Create Default Circle");
                Console.WriteLine("2. Create Circle with Radius");
                Console.WriteLine("3. Create Circle with Radius and Color");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                   original = new Circle();
                    original.display();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Radius: ");
                    double radius = double.Parse(Console.ReadLine());
                    original = new Circle(radius);
                    original.display();
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Radius: ");
                    double radius = double.Parse(Console.ReadLine());
                    Console.Write("Enter Color: ");
                    string color = Console.ReadLine();
                    original = new Circle(radius, color);
                    original.display();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Exiting Program...");
                    original= new Circle(original);
                    original.display();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Try Again.");
                    continue;
                }
                
            }


        }
    }
}
