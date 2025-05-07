using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.DL
{
    public class PlayerStatsDL
    {
        // Add player statistics to database
        public static void AddPlayerStats(int playerId, int centuries, int halfCenturies, int fours, int sixes,
                                          int ballsBowled, int fiveWicketHauls)
        {
            // Parameter validation
            centuries = centuries < 0 ? 0 : centuries;
            halfCenturies = halfCenturies < 0 ? 0 : halfCenturies;
            fours = fours < 0 ? 0 : fours;
            sixes = sixes < 0 ? 0 : sixes;
            ballsBowled = ballsBowled < 0 ? 0 : ballsBowled;
            fiveWicketHauls = fiveWicketHauls < 0 ? 0 : fiveWicketHauls;

            string query = $@"UPDATE Players SET 
                            Centuries = {centuries},
                            HalfCenturies = {halfCenturies},
                            Fours = {fours},
                            Sixes = {sixes},
                            BallsBowled = {ballsBowled},
                            FiveWicketHauls = {fiveWicketHauls}
                            WHERE Id = {playerId}";

            SqlHelper.ExecuteDML(query);
        }

        // Get player statistics from database
        public static DataTable GetPlayerStats(int playerId)
        {
            string query = $"SELECT Centuries, HalfCenturies, Fours, Sixes, BallsBowled, FiveWicketHauls FROM Players WHERE Id = {playerId}";
            return SqlHelper.GetTable(query);
        }
    }
}
