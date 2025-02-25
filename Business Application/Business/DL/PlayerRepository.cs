using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;
using System.IO;

namespace Business.DL
{
    public class PlayerRepository
    {
        private string filePath = "players.txt";

        public List<Player> LoadPlayers()
        {
            List<Player> players = new List<Player>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 7)
                        {
                            players.Add(new Player(
                                int.Parse(parts[0]),
                                parts[1],
                                parts[2],
                                parts[3],
                                int.Parse(parts[4]),
                                int.Parse(parts[5]),
                                int.Parse(parts[6])
                            ));
                        }
                    }
                }
            }
            return players;
        }

        public void SavePlayers(List<Player> players)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Player p in players)
                {
                    writer.WriteLine($"{p.Id},{p.Name},{p.Role},{p.Region},{p.Age},{p.Matches},{p.Wins}");
                }
            }
        }
    }
}