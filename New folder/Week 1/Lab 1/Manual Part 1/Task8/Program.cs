using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Floating Point Value: ");
            string str = Console.ReadLine();
            float num = float.Parse(str);
            Console.WriteLine("The Floating Value is: ");
            Console.Write(num);
            Console.ReadKey();
        }
    }
}
