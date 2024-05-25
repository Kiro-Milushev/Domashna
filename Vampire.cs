using System;

namespace ArenaGameEngine
{
    public class Vampire : Hero
    {
        public Vampire(string name) : base(name)
        {
            Health = 450; 
            Strength = 65; 
        }
        public override int Attack()
        {
            int damage = base.Attack();
            int lifestealAmount = damage / 2; // Heal for 50% of damage dealt

            Health += lifestealAmount; // Apply the lifesteal
            Console.WriteLine($"{Name} used Lifesteal and healed for {lifestealAmount}!");

            return damage;
        }

        public override void TakeDamage(int incomingDamage)
        {
            int reducedDamage = (int)(incomingDamage * 0.8);  // Reduce damage by 20%

            base.TakeDamage(reducedDamage);  // Apply the reduced damage
        }
    }
    
}


