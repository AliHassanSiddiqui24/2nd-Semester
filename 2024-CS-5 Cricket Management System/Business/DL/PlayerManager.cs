using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;

namespace Business.DL
{
    public class PlayerManager
    {
        public List<Player> Players = new List<Player>();
        private PlayerRepository repo = new PlayerRepository();

        public PlayerManager()
        {
            Players = repo.LoadPlayers();
        }

        public void AddPlayer(string name, string role, string region, int age, int matches, int wins)
        {
            int newId = 1;
            if (Players.Count > 0)
            {
                foreach (Player p in Players)
                {
                    if (p.Id > newId)
                    { 
                        newId = p.Id;
                    }
                }
                newId++;
            }
            Players.Add(new Player(newId, name, role, region, age, matches, wins));
            repo.SavePlayers(Players);
        }
        public void DeletePlayer(int id)
        {
            Players.RemoveAll(p => p.Id == id);
            repo.SavePlayers(Players);
        }

        public void SavePlayers()
        {
            repo.SavePlayers(Players);
        }
    }
}
