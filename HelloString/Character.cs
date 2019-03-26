using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloString
{
    class Character
    {
        private string name;
        private int job;
        private int level;
        private int hp;
        private int mana;
        private int atk;
        private int def;

        public Character(string name, int job, int level, int hp, int mana, int atk, int def)
        {
            this.name = name;
            this.job = job;
            this.level = level;
            this.hp = hp;
            this.mana = mana;
            this.atk = atk;
            this.def = def;

            ShowProfile();
        }

        public void ShowProfile()
        {
            Console.WriteLine("姓名-{0}，职业-{1}，等级-{2}，生命-{3}，魔力-{4}，攻击-{5}，防御-{5}", name, job, level, hp, mana, atk, def);
        }

        public string GetProfileString()
        {
            string ret = string.Format("{0},{1},{2},{3},{4},{5},{6}", this.name, this.job, this.level, this.hp, this.mana, this.atk, this.def);
            return ret;
        }

        public void LevelUp()
        {
            this.level++;
            this.hp += 50;
            this.mana += 25;
            this.atk += 10;
            this.def += 5;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
