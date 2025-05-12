using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    public abstract class CricketPlayer
    {
        private int _id;
        private string _name;
        private int _age;
        private string _role;
        private string _battingStyle;
        private string _bowlingStyle;
        private int _matches;
        private int _runs;
        private int _wickets;

        public int GetId()
        {
            return _id;
        }

        public void SetId(int value)
        {
            _id = value;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                _name = "";
            }
            else
            {
                _name = value;
            }
        }

        public int GetAge()
        {
            return _age;
        }

        public void SetAge(int value)
        {
            if (value < 0)
            {
                _age = 0;
            }
            else
            {
                _age = value;
            }
        }

        public string GetRole()
        {
            return _role;
        }

        public void SetRole(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                _role = "";
            }
            else
            {
                _role = value;
            }
        }

        public string GetBattingStyle()
        {
            return _battingStyle;
        }

        public void SetBattingStyle(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                _battingStyle = "";
            }
            else
            {
                _battingStyle = value;
            }
        }

        public string GetBowlingStyle()
        {
            return _bowlingStyle;
        }

        public void SetBowlingStyle(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                _bowlingStyle = "";
            }
            else
            {
                _bowlingStyle = value;
            }
        }

        public int GetMatches()
        {
            return _matches;
        }

        public void SetMatches(int value)
        {
            if (value < 0)
            {
                _matches = 0;
            }
            else
            {
                _matches = value;
            }
        }

        public int GetRuns()
        {
            return _runs;
        }

        public void SetRuns(int value)
        {
            if (value < 0)
            {
                _runs = 0;
            }
            else
            {
                _runs = value;
            }
        }

        public int GetWickets()
        {
            return _wickets;
        }

        public void SetWickets(int value)
        {
            if (value < 0)
            {
                _wickets = 0;
            }
            else
            {
                _wickets = value;
            }
        }

        public int Id
        {
            get { return GetId(); }
            set { SetId(value); }
        }

        public string Name
        {
            get { return GetName(); }
            set { SetName(value); }
        }

        public int Age
        {
            get { return GetAge(); }
            set { SetAge(value); }
        }

        public string Role
        {
            get { return GetRole(); }
            set { SetRole(value); }
        }

        public string BattingStyle
        {
            get { return GetBattingStyle(); }
            set { SetBattingStyle(value); }
        }

        public string BowlingStyle
        {
            get { return GetBowlingStyle(); }
            set { SetBowlingStyle(value); }
        }

        public int Matches
        {
            get { return GetMatches(); }
            set { SetMatches(value); }
        }

        public int Runs
        {
            get { return GetRuns(); }
            set { SetRuns(value); }
        }

        public int Wickets
        {
            get { return GetWickets(); }
            set { SetWickets(value); }
        }

        public CricketPlayer()
        {
        }

        public CricketPlayer(string name, int age, string role, string battingStyle,
                           string bowlingStyle, int matches, int runs, int wickets)
        {
            SetName(name);
            SetAge(age);
            SetRole(role);
            SetBattingStyle(battingStyle);
            SetBowlingStyle(bowlingStyle);
            SetMatches(matches);
            SetRuns(runs);
            SetWickets(wickets);
        }

        public abstract double CalculatePerformanceIndex();

        public virtual string GetPlayerInfo()
        {
            return $"Name: {GetName()}, Age: {GetAge()}, Role: {GetRole()}, " +
                   $"Batting Style: {GetBattingStyle()}, Bowling Style: {GetBowlingStyle()}, " +
                   $"Matches: {GetMatches()}, Runs: {GetRuns()}, Wickets: {GetWickets()}";
        }
    }
}
