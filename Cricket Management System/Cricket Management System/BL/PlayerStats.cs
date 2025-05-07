using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BLL
{
    public class PlayerStats
    {
        public int PlayerId { get; set; }
        public int Centuries { get; set; }
        public int HalfCenturies { get; set; }
        public int Fours { get; set; }
        public int Sixes { get; set; }
        public int BallsBowled { get; set; }
        public int FiveWicketHauls { get; set; }

        public PlayerStats()
        {
            // Default constructor
        }

        public PlayerStats(int playerId, int centuries = 0, int halfCenturies = 0,
                          int fours = 0, int sixes = 0, int ballsBowled = 0,
                          int fiveWicketHauls = 0)
        {
            PlayerId = playerId;
            Centuries = centuries;
            HalfCenturies = halfCenturies;
            Fours = fours;
            Sixes = sixes;
            BallsBowled = ballsBowled;
            FiveWicketHauls = fiveWicketHauls;
        }

        // Calculate Strike Rate
        public double CalculateStrikeRate(int runs, int ballsFaced)
        {
            if (ballsFaced == 0) return 0;
            return ((double)runs / ballsFaced) * 100;
        }

        // Calculate Economy Rate
        public double CalculateEconomyRate(int runs)
        {
            if (BallsBowled == 0) return 0;
            double overs = BallsBowled / 6.0;
            return (double)runs / overs;
        }

        // Generate statistics summary based on player role
        public string GetStatsSummary(string role, int runs, int wickets)
        {
            StringBuilder summary = new StringBuilder();

            switch (role)
            {
                case "Batsman":
                    summary.AppendLine($"Centuries: {Centuries}");
                    summary.AppendLine($"Half Centuries: {HalfCenturies}");
                    summary.AppendLine($"Fours: {Fours}");
                    summary.AppendLine($"Sixes: {Sixes}");
                    summary.AppendLine($"Runs per Match: {(double)runs / (wickets > 0 ? wickets : 1):F2}");
                    break;

                case "Bowler":
                    summary.AppendLine($"Five Wicket Hauls: {FiveWicketHauls}");
                    summary.AppendLine($"Balls Bowled: {BallsBowled}");
                    if (BallsBowled > 0)
                    {
                        summary.AppendLine($"Economy Rate: {CalculateEconomyRate(runs):F2}");
                    }
                    summary.AppendLine($"Wickets per Match: {(double)wickets / (wickets > 0 ? wickets : 1):F2}");
                    break;

                case "All-rounder":
                    summary.AppendLine($"Centuries: {Centuries}");
                    summary.AppendLine($"Five Wicket Hauls: {FiveWicketHauls}");
                    summary.AppendLine($"All-rounder Rating: {((double)runs / (wickets > 0 ? wickets : 1)):F2}");
                    break;

                default:
                    summary.AppendLine("No specialized statistics available for this player type.");
                    break;
            }

            return summary.ToString();
        }
    }
}
