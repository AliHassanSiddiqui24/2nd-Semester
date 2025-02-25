using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Clock
    {
        public int Hours;
        public int Minutes;
        public int Seconds;

        public int CalculateElapsedSeconds()
        {
            return Hours * 3600 + Minutes * 60 + Seconds;
        }

        public int CalculateRemainingSeconds()
        {
            return 86400 - CalculateElapsedSeconds();
        }

        public int CalculateDifference(Clock other)
        {
            int thisSeconds = CalculateElapsedSeconds();
            int otherSeconds = other.CalculateElapsedSeconds();
            return Math.Abs(thisSeconds - otherSeconds);
        }

        public string GetFormattedTime()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }
    }
}