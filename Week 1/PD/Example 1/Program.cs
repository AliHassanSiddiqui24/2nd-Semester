﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double number = random.NextDouble();
            Console.WriteLine(number);
            Console.ReadKey();
        }
    }
}
