using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    public class Stats
    {
        public string Name;
        public double Damage;
        public string Description;
        public double Penetration;
        public int Cost;
        public int Heal;

        public Stats(string name, double damage, double penetration, int heal, int cost, string description)
        {
            Name = name;
            Damage = damage;
            Penetration = penetration;
            Heal = heal;
            Cost = cost;
            Description = description;
        }
    }
}
