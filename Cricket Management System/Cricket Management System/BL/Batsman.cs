using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    // Batsman class - demonstrates Inheritance and Specialization (OOP)
    public class Batsman : Player
    {
        public int Centuries { get; set; }
        public int HalfCenturies { get; set; }
        public int Fours { get; set; }
        public int Sixes { get; set; }

        public Batsman() : base()
        {
        }

        public Batsman(string name, int age, string battingStyle, int matches, int runs,
                      int centuries, int halfCenturies, int fours, int sixes)
            : base(name, age, "Batsman", battingStyle, "", matches, runs, 0)
        {
            Centuries = centuries;
            HalfCenturies = halfCenturies;
            Fours = fours;
            Sixes = sixes;
        }

        // Overriding method - demonstrates Polymorphism (OOP)
        public override double CalculateBattingAverage()
        {
            if (Matches == 0) return 0;
            return (double)Runs / Matches;
        }

        // Additional method specific to Batsman
        public double CalculateStrikeRate(int ballsFaced)
        {
            if (ballsFaced == 0) return 0;
            return ((double)Runs / ballsFaced) * 100;
        }
    }

    // Bowler class - demonstrates Inheritance and Specialization (OOP)
    public class Bowler : Player
    {
        public int BallsBowled { get; set; }
        public int FiveWicketHauls { get; set; }

        public Bowler() : base()
        {
        }

        public Bowler(string name, int age, string bowlingStyle, int matches, int wickets,
                     int runs, int ballsBowled, int fiveWicketHauls)
            : base(name, age, "Bowler", "", bowlingStyle, matches, runs, wickets)
        {
            BallsBowled = ballsBowled;
            FiveWicketHauls = fiveWicketHauls;
        }

        // Overriding method - demonstrates Polymorphism (OOP)
        public override double CalculateBowlingAverage()
        {
            if (Wickets == 0) return 0;
            return (double)Runs / Wickets;
        }

        // Additional method specific to Bowler
        public double CalculateEconomyRate()
        {
            if (BallsBowled == 0) return 0;
            double overs = BallsBowled / 6.0;
            return (double)Runs / overs;
        }
    }

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
