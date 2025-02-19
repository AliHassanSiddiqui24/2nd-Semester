using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter minimum number of orders (N): ");
            int ordersQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter minimum order price: ");
            int minimumPrice = int.Parse(Console.ReadLine());
            string inputFile = "Customers.txt";
            StreamReader reader = new StreamReader(inputFile);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] lines = line.Split(' ');
                string name = lines[0];
                int total = int.Parse(lines[1]);
                string orderlist = lines[2].Trim('[',']');
                string [] ordersArray = orderlist.Split(',');
                int count = 0;
                for (int i = 0; i < total; i++)
                {
                    if(int.Parse(ordersArray[i]) >= minimumPrice)
                    {
                        count++;
                    }
                }
                if (count > ordersQuantity)
                {
                    Console.WriteLine(name);
                    
                }

            }
            Console.Read();
            reader.Close();
        }
    }
}
