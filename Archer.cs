using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Archer : Hero
    {
        public Archer(string name) : base(name)
        {
            Health = 425;
            Strength = 65;
        }

        public override int Attack()
        {
            int baseDamage = Strength * 2; 
            if (Random.Shared.Next(3) == 0) // 33% chance to double damage
            {
                baseDamage = Strength * 2;
            }
            return baseDamage;
        }

        public void Sacrifice()
        {
            if (Health > 50)
            {
                Health -= 50;
                Strength += 25; // Applying the sacrificial effect
            }
        }
    }
}
