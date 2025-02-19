using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self3
{
    public class Circle
    {
        public double Radius;
        public string Color;
        public Circle(Circle other)
        {
            this.Radius = other.Radius;
            this.Color = other.Color;
        }
        public Circle()
        {
            Radius = 1.0;
            Color = "red";
        }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public Circle(double Radius, string Color)
        {
            this.Radius = Radius;
            this.Color = Color;
        }
        public double getArea()
        {
            return 3.14 * Radius * Radius;
        }
        public double getDiameter()
        {
            return 2 * Radius;
        }
        public double getCircumference()
        {
            return 2 * 3.14 * Radius;
        }
        public void display()
        {
            Console.WriteLine($"Circle Details: Radius = {Radius}, Color = {Color}");
            Console.WriteLine($"Area = {getArea()}");
            Console.WriteLine($"Diameter = {getDiameter()}");
            Console.WriteLine($"Circumference = {getCircumference()}");
            Console.ReadKey();
        }
    }
}
