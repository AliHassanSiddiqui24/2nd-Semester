using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cricket_Management_System.DL;

namespace Cricket_Management_System.BL
{
    // PlayerBL implements IPlayerService - demonstrates Implementation inheritance (OOP)
    public class PlayerBL : IPlayerService
    {
        public DataTable GetAllPlayers()
        {
            return PlayerDL.GetAllPlayers();
        }

        public DataTable GetPlayerById(int id)
        {
            return PlayerDL.GetPlayerById(id);
        }

        public DataTable SearchPlayersByName(string name)
        {
            return PlayerDL.SearchPlayersByName(name);
        }

        public bool AddPlayer(Player player)
        {
            // Validation
            if (string.IsNullOrEmpty(player.Name) || player.Age <= 0)
            {
                return false;
            }

            // Extract specialized player statistics based on player type
            int centuries = 0, halfCenturies = 0, fours = 0, sixes = 0, ballsBowled = 0, fiveWicketHauls = 0;

            if (player is Batsman batsman)
            {
                centuries = batsman.Centuries;
                halfCenturies = batsman.HalfCenturies;
                fours = batsman.Fours;
                sixes = batsman.Sixes;
            }
            else if (player is Bowler bowler)
            {
                ballsBowled = bowler.BallsBowled;
                fiveWicketHauls = bowler.FiveWicketHauls;
            }
            else if (player is AllRounder allRounder)
            {
                centuries = allRounder.Centuries;
                fiveWicketHauls = allRounder.FiveWicketHauls;
            }

            // Add player to database with all statistics
            PlayerDL.AddPlayer(player.Name, player.Age, player.Role, player.BattingStyle,
                              player.BowlingStyle, player.Matches, player.Runs, player.Wickets,
                              centuries, halfCenturies, fours, sixes, ballsBowled, fiveWicketHauls);
            return true;
        }

        public bool UpdatePlayer(Player player)
        {
            // Validation
            if (player.Id <= 0 || string.IsNullOrEmpty(player.Name) || player.Age <= 0)
            {
                return false;
            }

            // Extract specialized player statistics based on player type
            int centuries = 0, halfCenturies = 0, fours = 0, sixes = 0, ballsBowled = 0, fiveWicketHauls = 0;

            if (player is Batsman batsman)
            {
                centuries = batsman.Centuries;
                halfCenturies = batsman.HalfCenturies;
                fours = batsman.Fours;
                sixes = batsman.Sixes;
            }
            else if (player is Bowler bowler)
            {
                ballsBowled = bowler.BallsBowled;
                fiveWicketHauls = bowler.FiveWicketHauls;
            }
            else if (player is AllRounder allRounder)
            {
                centuries = allRounder.Centuries;
                fiveWicketHauls = allRounder.FiveWicketHauls;
            }

            // Update player in database with all statistics
            PlayerDL.UpdatePlayer(player.Id, player.Name, player.Age, player.Role, player.BattingStyle,
                                 player.BowlingStyle, player.Matches, player.Runs, player.Wickets,
                                 centuries, halfCenturies, fours, sixes, ballsBowled, fiveWicketHauls);
            return true;
        }

        public bool DeletePlayer(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            // Delete player from database
            PlayerDL.DeletePlayer(id);
            return true;
        }
    }
}