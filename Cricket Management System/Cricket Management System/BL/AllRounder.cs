using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    // AllRounder class - demonstrates Multiple Inheritance concept (though C# doesn't support direct multiple inheritance)
    public class AllRounder : Player
    {
        public int Centuries { get; set; }
        public int FiveWicketHauls { get; set; }

        public AllRounder() : base()
        {
        }

        public AllRounder(string name, int age, string battingStyle, string bowlingStyle,
                         int matches, int runs, int wickets, int centuries, int fiveWicketHauls)
            : base(name, age, "All-rounder", battingStyle, bowlingStyle, matches, runs, wickets)
        {
            Centuries = centuries;
            FiveWicketHauls = fiveWicketHauls;
        }

        // Method specific to AllRounder
        public double CalculateAllRounderIndex()
        {
            double battingAvg = CalculateBattingAverage();
            double bowlingAvg = CalculateBowlingAverage();

            if (bowlingAvg == 0) return 0;
            return battingAvg / bowlingAvg;
        }
    }
}
