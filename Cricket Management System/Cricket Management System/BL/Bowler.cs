using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
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
}
