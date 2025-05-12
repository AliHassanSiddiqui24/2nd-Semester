using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    public interface IPlayerService
    {
        DataTable GetAllPlayers();
        DataTable SearchPlayersByName(string name);
        bool AddPlayer(CricketPlayer player);
        bool UpdatePlayer(CricketPlayer player);
        bool DeletePlayer(int id);
    }
}
