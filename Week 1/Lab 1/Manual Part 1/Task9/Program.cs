﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float area;
            float length;
            String str;
            Console.WriteLine("Enter Length: ");
            str = Console.ReadLine();
            length = float.Parse(str);
            area = length * length;
            Console.WriteLine("The Area is: ");
            Console.Write(area);
            Console.ReadKey();
        }
    }
}
