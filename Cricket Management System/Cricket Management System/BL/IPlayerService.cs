using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    // Interface for Player Service - Follows Interface Segregation Principle (SOLID)
    public interface IPlayerService
    {
        DataTable GetAllPlayers();
        DataTable GetPlayerById(int id);
        DataTable SearchPlayersByName(string name);
        bool AddPlayer(Player player);
        bool UpdatePlayer(Player player);
        bool DeletePlayer(int id);
    }
}
