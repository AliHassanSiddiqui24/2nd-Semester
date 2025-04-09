using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MountainBike mb = new MountainBike(10, 90, 20, 5);
            mb.SetCadence(95);
            mb.SetGear(4);
            mb.ApplyBrake(5);
            mb.SpeedUp(10);
            mb.SetSeatHeight(12);

            Console.WriteLine("MountainBike object is created and modified.");
        }
    }
}
