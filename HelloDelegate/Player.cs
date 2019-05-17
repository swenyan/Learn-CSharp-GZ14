using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDelegate
{
    public class Player
    {
        public string name { get; private set; }

        public int pos_x { get; private set; }

        public int pos_y { get; private set; }

        public int maxHp { get; private set; }

        public int currentHp { get; private set; }

        private double encounterRate = 0.2;

        private double winRate = 0.75;

        public void Move(int x, int y)
        {
            pos_x += x;
            pos_y += y;

            if(Encounter(encounterRate))
            {
                Fight();
            }
        }

        private bool Encounter(double encounterRate)
        {
            System.Random random = new Random();
            double rate = random.NextDouble();

            if(rate < encounterRate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Fight()
        {
            System.Random random = new Random();
            double rate = random.NextDouble();

            if (rate < winRate)
            {
                maxHp += (int)(maxHp * 0.05f);
                currentHp = maxHp;
            }
            else
            {
                currentHp -= (int)(maxHp * 0.05f);
            }
        }
    }
}
