using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red Color text");
            Console.ForegroundColor= ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Green Color Background");
            Console.BackgroundColor= ConsoleColor.Black;
            Console.WriteLine("Default Color");
        }
    }
}
