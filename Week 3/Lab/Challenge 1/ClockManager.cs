using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class ClockManager
    {
        private List<Clock> clocks = new List<Clock>();

        public int ClockCount => clocks.Count;

        public void AddClock(Clock clock)
        {
            clocks.Add(clock);
        }

        public Clock GetClock(int index)
        {
            return clocks[index];
        }

        public void UpdateClock(int index, int hours, int minutes, int seconds)
        {
            if (index < 0 || index >= clocks.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Clock clock = clocks[index];
            clock.Hours = hours;
            clock.Minutes = minutes;
            clock.Seconds = seconds;
        }

        public int CalculateTimeDifference(int index1, int index2)
        {
            Clock clock1 = GetClock(index1);
            Clock clock2 = GetClock(index2);
            return clock1.CalculateDifference(clock2);
        }
    }
}
