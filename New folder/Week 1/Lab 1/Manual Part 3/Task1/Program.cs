using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;
            Console.Write("Enter 1st Number: ");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd Number: ");
            num2 = int.Parse(Console.ReadLine());
            int result = add(num1, num2);
            Console.WriteLine("Sum is {0}", result);
            Console.Read();

        }
        static int add(int n1, int n2)
        {
            return n1 + n2;
        }
    }
}
