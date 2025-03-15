using Business.BL;
using Business.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

public class PlayerRepository
{
    public List<Player> LoadPlayers()
    {
        List<Player> players = new List<Player>();
        DataTable dt = SqlHelper.GetTable("SELECT * FROM Players");

        foreach (DataRow row in dt.Rows)
        {
            players.Add(new Player(
                (int)row["Id"],
                row["Name"].ToString(),
                row["Role"].ToString(),
                row["Region"].ToString(),
                (int)row["Age"],
                (int)row["Matches"],
                (int)row["Wins"]
            ));
        }
        return players;
    }

    public void SavePlayers(List<Player> players)
    {
        SqlHelper.ExecuteDML("DELETE FROM Players");

        foreach (Player p in players)
        {
            string query = $@"INSERT INTO Players VALUES(
            {p.Id}, '{p.Name.Replace("'", "''")}', 
            '{p.Role}', '{p.Region}', 
            {p.Age}, {p.Matches}, {p.Wins})";

            SqlHelper.ExecuteDML(query);
        }
    }

}