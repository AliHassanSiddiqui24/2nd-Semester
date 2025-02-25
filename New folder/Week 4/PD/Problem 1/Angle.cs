using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    public class Angle
    {
        public int Degrees;
        public float Minutes;
        public char Direction;

        public Angle(int degrees, float minutes, char direction)
        {
            Degrees = degrees;
            Minutes = minutes;
            Direction = direction;
        }

        public void ChangeAngle(int degrees, float minutes, char direction)
        {
            Degrees = degrees;
            Minutes = minutes;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"{Degrees}\u00b0{Minutes:0.0}' {Direction}";
        }
    }
}
