using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    public class Batsman : CricketPlayer
    {
        private int _centuries;
        private int _halfCenturies;
        private int _fours;
        private int _sixes;

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

        public Batsman() : base()
        {
        }

        public Batsman(string name, int age, string battingStyle, int matches, int runs,
                      int centuries, int halfCenturies, int fours, int sixes)
            : base(name, age, "Batsman", battingStyle, "", matches, runs, 0)
        {
            SetCenturies(centuries);
            SetHalfCenturies(halfCenturies);
            SetFours(fours);
            SetSixes(sixes);
        }

        public override string GetPlayerInfo()
        {
            return base.GetPlayerInfo() +
                   $", Centuries: {GetCenturies()}, Half Centuries: {GetHalfCenturies()}, " +
                   $"Fours: {GetFours()}, Sixes: {GetSixes()}";
        }

        public override double CalculatePerformanceIndex()
        {
            double battingAvg = 0;
            double centuryPoints = GetCenturies() * 5;
            double halfCenturyPoints = GetHalfCenturies() * 2;
            double boundaryPoints = (GetFours() * 0.25) + (GetSixes() * 0.5);

            if (Matches > 0)
            {
                battingAvg = (double)Runs / Matches;
            }

            double totalPoints = battingAvg + centuryPoints + halfCenturyPoints + boundaryPoints;
            return totalPoints;
        }
    }
}