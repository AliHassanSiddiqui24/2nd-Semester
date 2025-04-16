using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02
{
    public class Cylinder : Circle
    {

        private double height = 1.0;

        public Cylinder() : base()

        {
        }

        public Cylinder(double radius) : base(radius)

        {
        }

        public Cylinder(double radius, double height) : base(radius) 

        {
            this.height = height;
        }

        public Cylinder(double radius, double height, string color) : base(radius, color) 

        {
            this.height = height;
        }

        public double GetHeight()
        {
            return height;
        }

        public void SetHeight(double height)
        {
            this.height = height;
        }

        public double GetVolume()
        {
            return GetArea() * height;
        }

        public override string ToString()
        {
            return $"Cylinder[{base.ToString()},height={height}]";
        }
    }
}
