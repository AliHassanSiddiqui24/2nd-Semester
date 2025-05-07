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

    

    
}
