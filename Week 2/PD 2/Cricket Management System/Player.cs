﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System
{
    public class Player
    {
        public int Id;
        public string Name;
        public string Role;
        public string Region;
        public int Age;
        public int MatchesPlayed;
        public int Wins;
        public int Losses => MatchesPlayed - Wins;

        public Player(int id, string name, string role, string region, int age, int matches, int wins)
        {
            Id = id;
            Name = name;
            Role = role;
            Region = region;
            Age = age;
            MatchesPlayed = matches;
            Wins = wins;
        }
    }
}

