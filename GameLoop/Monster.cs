using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLoop
{
    class Monster
    {
        public int hp;
        public string name;
        public bool isDead;

        public Monster(string var_name, int var_hp)
        {
            name = var_name;
            hp = var_hp;
            isDead = false;
        }

        public void Hurt(int damage)
        {
            hp = hp - damage;

            if(hp <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            isDead = true;
        }
    }
}
