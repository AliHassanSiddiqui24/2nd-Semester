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

            // Add player to database
            PlayerDL.AddPlayer(player.Name, player.Age, player.Role, player.BattingStyle,
                              player.BowlingStyle, player.Matches, player.Runs, player.Wickets);
            return true;
        }

        public bool UpdatePlayer(Player player)
        {
            // Validation
            if (player.Id <= 0 || string.IsNullOrEmpty(player.Name) || player.Age <= 0)
            {
                return false;
            }

            // Update player in database
            PlayerDL.UpdatePlayer(player.Id, player.Name, player.Age, player.Role, player.BattingStyle,
                                 player.BowlingStyle, player.Matches, player.Runs, player.Wickets);
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
