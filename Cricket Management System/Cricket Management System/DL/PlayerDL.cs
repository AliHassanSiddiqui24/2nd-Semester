using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.DL
{
    public class PlayerDL
    {
        // Get all players
        public static DataTable GetAllPlayers()
        {
            string query = "SELECT * FROM Players";
            return SqlHelper.GetTable(query);
        }

        // Get player by ID
        public static DataTable GetPlayerById(int id)
        {
            string query = $"SELECT * FROM Players WHERE Id = {id}";
            return SqlHelper.GetTable(query);
        }

        // Search players by name
        public static DataTable SearchPlayersByName(string name)
        {
            string query = $"SELECT * FROM Players WHERE Name LIKE '%{name}%'";
            return SqlHelper.GetTable(query);
        }

        // Add new player
        public static void AddPlayer(string name, int age, string role, string battingStyle, string bowlingStyle,
                                     int matches, int runs, int wickets)
        {
            string query = $"INSERT INTO Players (Name, Age, Role, BattingStyle, BowlingStyle, Matches, Runs, Wickets) VALUES " +
                          $"('{name}', {age}, '{role}', '{battingStyle}', '{bowlingStyle}', {matches}, {runs}, {wickets})";
            SqlHelper.ExecuteDML(query);
        }

        // Update player
        public static void UpdatePlayer(int id, string name, int age, string role, string battingStyle, string bowlingStyle,
                                       int matches, int runs, int wickets)
        {
            string query = $"UPDATE Players SET Name = '{name}', Age = {age}, Role = '{role}', " +
                          $"BattingStyle = '{battingStyle}', BowlingStyle = '{bowlingStyle}', " +
                          $"Matches = {matches}, Runs = {runs}, Wickets = {wickets} WHERE Id = {id}";
            SqlHelper.ExecuteDML(query);
        }

        // Delete player
        public static void DeletePlayer(int id)
        {
            string query = $"DELETE FROM Players WHERE Id = {id}";
            SqlHelper.ExecuteDML(query);
        }
    }
}
