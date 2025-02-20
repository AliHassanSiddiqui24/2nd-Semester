using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
    public class Stats
    {
        public string Name { get; }
        public double Damage { get; }
        public string Description { get; }
        public double Penetration { get; }
        public int Cost { get; }
        public int Heal { get; }

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
