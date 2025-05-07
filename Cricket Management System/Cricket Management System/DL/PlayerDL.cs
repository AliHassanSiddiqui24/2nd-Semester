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

        // Add new player with additional statistics
        public static void AddPlayer(string name, int age, string role, string battingStyle, string bowlingStyle,
                                   int matches, int runs, int wickets, int centuries = 0, int halfCenturies = 0,
                                   int fours = 0, int sixes = 0, int ballsBowled = 0, int fiveWicketHauls = 0)
        {
            // Parameter validation
            name = string.IsNullOrEmpty(name) ? "" : name.Replace("'", "''"); // Escape single quotes
            battingStyle = string.IsNullOrEmpty(battingStyle) ? "" : battingStyle.Replace("'", "''");
            bowlingStyle = string.IsNullOrEmpty(bowlingStyle) ? "" : bowlingStyle.Replace("'", "''");
            role = string.IsNullOrEmpty(role) ? "Player" : role.Replace("'", "''");

            // Validate numeric values
            age = age < 0 ? 0 : age;
            matches = matches < 0 ? 0 : matches;
            runs = runs < 0 ? 0 : runs;
            wickets = wickets < 0 ? 0 : wickets;
            centuries = centuries < 0 ? 0 : centuries;
            halfCenturies = halfCenturies < 0 ? 0 : halfCenturies;
            fours = fours < 0 ? 0 : fours;
            sixes = sixes < 0 ? 0 : sixes;
            ballsBowled = ballsBowled < 0 ? 0 : ballsBowled;
            fiveWicketHauls = fiveWicketHauls < 0 ? 0 : fiveWicketHauls;

            string query = $@"INSERT INTO Players (Name, Age, Role, BattingStyle, BowlingStyle, 
                            Matches, Runs, Wickets, Centuries, HalfCenturies, Fours, Sixes, BallsBowled, FiveWicketHauls) VALUES 
                            ('{name}', {age}, '{role}', '{battingStyle}', '{bowlingStyle}', 
                            {matches}, {runs}, {wickets}, {centuries}, {halfCenturies}, {fours}, {sixes}, {ballsBowled}, {fiveWicketHauls})";
            SqlHelper.ExecuteDML(query);
        }

        // Update player with additional statistics
        public static void UpdatePlayer(int id, string name, int age, string role, string battingStyle, string bowlingStyle,
                                       int matches, int runs, int wickets, int centuries = 0, int halfCenturies = 0,
                                       int fours = 0, int sixes = 0, int ballsBowled = 0, int fiveWicketHauls = 0)
        {
            // Parameter validation
            name = string.IsNullOrEmpty(name) ? "" : name.Replace("'", "''"); // Escape single quotes
            battingStyle = string.IsNullOrEmpty(battingStyle) ? "" : battingStyle.Replace("'", "''");
            bowlingStyle = string.IsNullOrEmpty(bowlingStyle) ? "" : bowlingStyle.Replace("'", "''");
            role = string.IsNullOrEmpty(role) ? "Player" : role.Replace("'", "''");

            // Validate numeric values
            age = age < 0 ? 0 : age;
            matches = matches < 0 ? 0 : matches;
            runs = runs < 0 ? 0 : runs;
            wickets = wickets < 0 ? 0 : wickets;
            centuries = centuries < 0 ? 0 : centuries;
            halfCenturies = halfCenturies < 0 ? 0 : halfCenturies;
            fours = fours < 0 ? 0 : fours;
            sixes = sixes < 0 ? 0 : sixes;
            ballsBowled = ballsBowled < 0 ? 0 : ballsBowled;
            fiveWicketHauls = fiveWicketHauls < 0 ? 0 : fiveWicketHauls;

            string query = $@"UPDATE Players SET Name = '{name}', Age = {age}, Role = '{role}', 
                            BattingStyle = '{battingStyle}', BowlingStyle = '{bowlingStyle}', 
                            Matches = {matches}, Runs = {runs}, Wickets = {wickets},
                            Centuries = {centuries}, HalfCenturies = {halfCenturies}, 
                            Fours = {fours}, Sixes = {sixes}, BallsBowled = {ballsBowled}, 
                            FiveWicketHauls = {fiveWicketHauls} WHERE Id = {id}";
            SqlHelper.ExecuteDML(query);
        }

        // Delete player
        public static void DeletePlayer(int id)
        {
            if (id <= 0) return; // Validation

            string query = $"DELETE FROM Players WHERE Id = {id}";
            SqlHelper.ExecuteDML(query);
        }
    }
}