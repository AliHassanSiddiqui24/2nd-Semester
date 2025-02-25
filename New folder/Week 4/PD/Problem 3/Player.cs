using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    public class Player
    {
        public string Name;
        public double Hp;   
        public double MaxHp;
        public int Energy;
        public int MaxEnergy;
        public double Armor;
        private Stats learnedSkill;

        public Player(string name, double health, int energy, double armor)
        {
            Name = name;
            MaxHp = health;
            Hp = health;
            MaxEnergy = energy;
            Energy = energy;
            Armor = armor;
        }

        public void UpdateHealth(double amount)
        {
            Hp = Hp + amount;
            if (Hp < 0)
            {
                Hp = 0;
            }
            if (Hp > MaxHp)
            {
                Hp = MaxHp;
            }
        }

        public void UpdateEnergy(int amount)
        {
            Energy += amount;
            if (Energy < 0) Energy = 0;
            if (Energy > MaxEnergy)
            {
                Energy = MaxEnergy;
                }
        }

        public void UpdateArmor(double newArmor)
        {
            Armor = newArmor;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void LearnSkill(Stats skill)
        {
            learnedSkill = skill;
        }

        public string Attack(Player target)
        {
            if (learnedSkill == null)
                return $"{Name} has no skill to attack!";

            Stats skill = learnedSkill;

            if (Energy < skill.Cost)
                return $"{Name} attempted to use {skill.Name}, but didn't have enough energy!";

            Energy -= skill.Cost;

            // Calculate effective armor
            double effectiveArmor = target.Armor - skill.Penetration;
            if (effectiveArmor < 0) effectiveArmor = 0;

            // Calculate damage
            double damage = skill.Damage * (100 - effectiveArmor) / 100;
            damage = Math.Round(damage, 2);

            // Apply damage to target
            target.UpdateHealth(-damage);

            // Apply heal to self
            if (skill.Heal > 0)
            {
                UpdateHealth(skill.Heal);
            }

            // Build result string
            string result = $"{Name} used {skill.Name}, {skill.Description}, against {target.Name}, doing {damage:F2} damage!";

            if (skill.Heal > 0)
                result += $" {Name} healed for {skill.Heal} health!";

            if (target.Hp <= 0)
                result += $" {target.Name} died.";
            else
                result += $" {target.Name} is at {(target.Hp / target.MaxHp * 100):F2}% health.";

            return result;
        }
    }
}
