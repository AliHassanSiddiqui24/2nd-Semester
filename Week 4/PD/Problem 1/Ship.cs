using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    public class Ship
    {
        public string SerialNumber { get; set; }
        public Angle Latitude { get; set; }
        public Angle Longitude { get; set; }

        public Ship(string serialNumber, Angle latitude, Angle longitude)
        {
            SerialNumber = serialNumber;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void PrintPosition()
        {
            Console.WriteLine($"Ship is at {Latitude} and {Longitude}");
        }

        public void PrintSerialNumber()
        {
            Console.WriteLine($"Ship's serial number is {SerialNumber}");
        }
    }
}
