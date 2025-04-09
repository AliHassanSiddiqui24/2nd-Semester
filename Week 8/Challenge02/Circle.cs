using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02
{
    public class Circle
    {
        protected double radius = 1.0;
        protected string color = "red";

        public Circle()
        {
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }

        public double GetRadius()
        {
            return radius;
        }

        public void SetRadius(double radius)
        {
            this.radius = radius;
        }

        public string GetColor()
        {
            return color;
        }

        public void SetColor(string color)
        {
            this.color = color;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return $"Circle[radius={radius},color={color}]";
        }
    }
}
