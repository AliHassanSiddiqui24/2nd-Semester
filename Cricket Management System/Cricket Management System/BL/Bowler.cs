using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    public class Bowler : CricketPlayer
    {
        private int _ballsBowled;
        private int _fiveWicketHauls;

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

        public Bowler() : base()
        {
        }

        public Bowler(string name, int age, string bowlingStyle, int matches, int wickets,
                     int runs, int ballsBowled, int fiveWicketHauls)
            : base(name, age, "Bowler", "", bowlingStyle, matches, runs, wickets)
        {
            SetBallsBowled(ballsBowled);
            SetFiveWicketHauls(fiveWicketHauls);
        }

        public override string GetPlayerInfo()
        {
            return base.GetPlayerInfo() +
                   $", Balls Bowled: {GetBallsBowled()}, Five Wicket Hauls: {GetFiveWicketHauls()}";
        }

        public override double CalculatePerformanceIndex()
        {
            double wicketPoints = Wickets * 4;
            double fiveWicketPoints = GetFiveWicketHauls() * 5;
            double bowlingAvg = 0;
            double bowlingAvgPoints = 0;

            if (Wickets > 0)
            {
                bowlingAvg = (double)Wickets / Matches;

                if (bowlingAvg > 0)
                {
                    bowlingAvgPoints = 50 / bowlingAvg;
                }
            }

            double totalPoints = wicketPoints + fiveWicketPoints + bowlingAvgPoints;
            return totalPoints;
        }
    }
}