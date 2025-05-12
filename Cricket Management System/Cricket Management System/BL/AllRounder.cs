using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    public class AllRounder : CricketPlayer
    {
        private int _centuries;
        private int _halfCenturies;
        private int _fours;
        private int _sixes;
        private int _ballsBowled;
        private int _fiveWicketHauls;

        public int GetCenturies()
        { 
            return _centuries; 
        }
        public void SetCenturies(int value) 
        { 
            _centuries = value; 
        }

        public int GetHalfCenturies() 
        { 
            return _halfCenturies; 
        }
        public void SetHalfCenturies(int value)
        { 
            _halfCenturies = value; 
        }

        public int GetFours() 
        { 
            return _fours; 
        }
        public void SetFours(int value)
        { 
            _fours = value; 
        }

        public int GetSixes()
        {
            return _sixes; 
        }
        public void SetSixes(int value)
        { 
            _sixes = value;
        }

        public int GetBallsBowled() 
        {
            return _ballsBowled; 
        }
        public void SetBallsBowled(int value) 
        { 
            _ballsBowled = value; 
        }

        public int GetFiveWicketHauls() 
        { 
            return _fiveWicketHauls; 
        }
        public void SetFiveWicketHauls(int value) 
        { 
            _fiveWicketHauls = value; 
        }

        public int Centuries
        {
            get { return GetCenturies(); }
            set { SetCenturies(value); }
        }

        public int HalfCenturies
        {
            get { return GetHalfCenturies(); }
            set { SetHalfCenturies(value); }
        }

        public int Fours
        {
            get { return GetFours(); }
            set { SetFours(value); }
        }

        public int Sixes
        {
            get { return GetSixes(); }
            set { SetSixes(value); }
        }

        public int BallsBowled
        {
            get { return GetBallsBowled(); }
            set { SetBallsBowled(value); }
        }

        public int FiveWicketHauls
        {
            get { return GetFiveWicketHauls(); }
            set { SetFiveWicketHauls(value); }
        }

        public AllRounder() : base()
        {
        }

        public AllRounder(string name, int age, string battingStyle, string bowlingStyle,
                        int matches, int runs, int wickets, int centuries, int halfCenturies,
                        int fours, int sixes, int ballsBowled, int fiveWicketHauls)
                        : base(name, age, "All-rounder", battingStyle, bowlingStyle, matches, runs, wickets)
        {
            SetCenturies(centuries);
            SetHalfCenturies(halfCenturies);
            SetFours(fours);
            SetSixes(sixes);
            SetBallsBowled(ballsBowled);
            SetFiveWicketHauls(fiveWicketHauls);
        }

        public override string GetPlayerInfo()
        {
            return base.GetPlayerInfo() +
                   $", Centuries: {GetCenturies()}, Five Wicket Hauls: {GetFiveWicketHauls()}, " +
                   $"Half Centuries: {GetHalfCenturies()}, Fours: {GetFours()}, Sixes: {GetSixes()}, " +
                   $"Balls Bowled: {GetBallsBowled()}";
        }

        public override double CalculatePerformanceIndex()
        {
            double battingAvg = 0;
            double centuryPoints = GetCenturies() * 3;
            double halfCenturyPoints = GetHalfCenturies() * 1.5;
            double boundaryPoints = (GetFours() * 0.2) + (GetSixes() * 0.4);

            if (Matches > 0)
            {
                battingAvg = (double)Runs / Matches;
            }

            double wicketPoints = Wickets * 3;
            double fiveWicketPoints = GetFiveWicketHauls() * 3;
            double bowlingAvg = 0;
            double bowlingAvgPoints = 0;

            if (Wickets > 0)
            {
                bowlingAvg = (double)Wickets / Matches;

                if (bowlingAvg > 0)
                {
                    bowlingAvgPoints = 40 / bowlingAvg;
                }
            }

            double allRounderIndex = 0;

            if (battingAvg > 0 && bowlingAvg > 0)
            {
                allRounderIndex = (battingAvg / bowlingAvg) * 10;
            }

            double totalPoints = battingAvg + centuryPoints + halfCenturyPoints + boundaryPoints +
                                 wicketPoints + fiveWicketPoints + bowlingAvgPoints + allRounderIndex;

            return totalPoints;
        }
    }
}