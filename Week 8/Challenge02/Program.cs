using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();
            Circle c2 = new Circle(2.5);
            Circle c3 = new Circle(3.0, "blue");

            Console.WriteLine(c1);
            Console.WriteLine($"Area c3 = {c3.GetArea():F2}");

            Cylinder cyl1 = new Cylinder();
            Cylinder cyl2 = new Cylinder(2.0);
            Cylinder cyl3 = new Cylinder(2.0, 5.0);
            Cylinder cyl4 = new Cylinder(2.0, 5.0, "green");

            Console.WriteLine(cyl1);
            Console.WriteLine($"Volume cyl4 = {cyl4.GetVolume():F2}");
        }
    }
}
