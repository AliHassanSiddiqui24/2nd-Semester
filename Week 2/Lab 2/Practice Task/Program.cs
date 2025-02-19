using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.name = "Buddy";
            myDog.age = 3;
            myDog.Bark();
            myDog.eat("Dog Food");
            int humanYears = myDog.ConvertToHumanYears();
            Console.WriteLine($"{myDog.name}'s age in human years: {humanYears}");
            Console.ReadKey();

        }
    }
}
