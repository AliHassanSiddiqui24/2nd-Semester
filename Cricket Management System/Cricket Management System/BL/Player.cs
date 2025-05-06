using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    // Player class - demonstrates Encapsulation (OOP)
    public class Player
    {
        // Properties with getters and setters - Encapsulation
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string BattingStyle { get; set; }
        public string BowlingStyle { get; set; }
        public int Matches { get; set; }
        public int Runs { get; set; }
        public int Wickets { get; set; }

        // Default constructor
        public Player()
        {
        }

        // Parameterized constructor - Constructor overloading (Polymorphism)
        public Player(string name, int age, string role, string battingStyle, string bowlingStyle,
                      int matches, int runs, int wickets)
        {
            Name = name;
            Age = age;
            Role = role;
            BattingStyle = battingStyle;
            BowlingStyle = bowlingStyle;
            Matches = matches;
            Runs = runs;
            Wickets = wickets;
        }

        // Parameterized constructor with ID - Constructor overloading (Polymorphism)
        public Player(int id, string name, int age, string role, string battingStyle, string bowlingStyle,
                      int matches, int runs, int wickets) : this(name, age, role, battingStyle, bowlingStyle, matches, runs, wickets)
        {
            Id = id;
        }

        // Method to calculate batting average - demonstrates behavior in OOP
        public virtual double CalculateBattingAverage()
        {
            if (Matches == 0) return 0;
            return (double)Runs / Matches;
        }

        // Method to calculate bowling average - demonstrates behavior in OOP
        public virtual double CalculateBowlingAverage()
        {
            if (Wickets == 0) return 0;
            return (double)Runs / Wickets;
        }
    }
}
