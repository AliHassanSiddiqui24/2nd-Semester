using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Dog
    {
        public string name;
        public int age;
        public void Bark()
        {
            Console.WriteLine($"{name} is barking!");
        }
        public void eat(string food)
        {
            Console.WriteLine($"{name} is eating {food}.");
        }
        public int ConvertToHumanYears()
        {
            return age * 7;
        }
    }
}
