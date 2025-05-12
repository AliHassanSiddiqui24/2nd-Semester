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
        public static DataTable GetAllPlayers()
        {
            string query = "SELECT * FROM Players";
            return SqlHelper.GetTable(query);
        }

        public static DataTable SearchPlayersByName(string name)
        {
            string query = $"SELECT * FROM Players WHERE Name LIKE '%{name}%'";
            return SqlHelper.GetTable(query);
        }

        public static void AddPlayer(string name, int age, string role, string battingStyle, string bowlingStyle,
                             int matches, int runs, int wickets,
                             int centuries = 0, int halfCenturies = 0,
                             int fours = 0, int sixes = 0, int ballsBowled = 0, int fiveWicketHauls = 0)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "";
            }
            if (string.IsNullOrEmpty(battingStyle))
            {
                battingStyle = "";
            }
            if (string.IsNullOrEmpty(bowlingStyle))
            {
                bowlingStyle = "";
            }
            if (string.IsNullOrEmpty(role))
            {
                role = "Player";
            }

            if (age < 0) age = 0;
            if (matches < 0) matches = 0;
            if (runs < 0) runs = 0;
            if (wickets < 0) wickets = 0;
            if (centuries < 0) centuries = 0;
            if (halfCenturies < 0) halfCenturies = 0;
            if (fours < 0) fours = 0;
            if (sixes < 0) sixes = 0;
            if (ballsBowled < 0) ballsBowled = 0;
            if (fiveWicketHauls < 0) fiveWicketHauls = 0;

            string query = $@"INSERT INTO Players (Name, Age, Role, BattingStyle, BowlingStyle, 
                    Matches, Runs, Wickets, Centuries, HalfCenturies, Fours, Sixes, BallsBowled, FiveWicketHauls) 
                    VALUES ('{name}', {age}, '{role}', '{battingStyle}', '{bowlingStyle}', 
                    {matches}, {runs}, {wickets}, {centuries}, {halfCenturies}, {fours}, {sixes}, {ballsBowled}, {fiveWicketHauls})";

            SqlHelper.ExecuteDML(query);
        }

        public static void UpdatePlayer(int id, string name, int age, string role, string battingStyle, string bowlingStyle,
                                        int matches, int runs, int wickets,
                                        int centuries = 0, int halfCenturies = 0,
                                        int fours = 0, int sixes = 0, int ballsBowled = 0, int fiveWicketHauls = 0)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "";
            }
            if (string.IsNullOrEmpty(battingStyle))
            {
                battingStyle = "";
            }
            if (string.IsNullOrEmpty(bowlingStyle))
            {
                bowlingStyle = "";
            }
            if (string.IsNullOrEmpty(role))
            {
                role = "Player";
            }

            if (age < 0) age = 0;
            if (matches < 0) matches = 0;
            if (runs < 0) runs = 0;
            if (wickets < 0) wickets = 0;
            if (centuries < 0) centuries = 0;
            if (halfCenturies < 0) halfCenturies = 0;
            if (fours < 0) fours = 0;
            if (sixes < 0) sixes = 0;
            if (ballsBowled < 0) ballsBowled = 0;
            if (fiveWicketHauls < 0) fiveWicketHauls = 0;

            string query = $@"UPDATE Players SET Name = '{name}', Age = {age}, Role = '{role}', 
                    BattingStyle = '{battingStyle}', BowlingStyle = '{bowlingStyle}', 
                    Matches = {matches}, Runs = {runs}, Wickets = {wickets},
                    Centuries = {centuries}, HalfCenturies = {halfCenturies}, 
                    Fours = {fours}, Sixes = {sixes}, BallsBowled = {ballsBowled}, 
                    FiveWicketHauls = {fiveWicketHauls} WHERE Id = {id}";

            SqlHelper.ExecuteDML(query);
        }


        public static void DeletePlayer(int id)
        {
            if (id <= 0)
            {
                return;
            }

            string query = $"DELETE FROM Players WHERE Id = {id}";
            SqlHelper.ExecuteDML(query);
        }
    }
}