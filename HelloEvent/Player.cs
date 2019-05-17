using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEvent
{
    public class Player
    {
        public string name { get; private set; }

        public int pos_x { get; private set; }

        public int pos_y { get; private set; }

        public int maxHp { get; private set; }

        public int currentHp { get; private set; }

        private int encounterRate = 20;

        private int winRate = 30;

        System.Random random = new Random();

        public delegate void PlayerEventDelegate(string name, int maxHp, int currentHp, int pos_x, int pos_y);
        public event PlayerEventDelegate Event_PlayerInit;
        public event PlayerEventDelegate Event_PlayerMove;
        public event PlayerEventDelegate Event_PlayerEncouter;
        public event PlayerEventDelegate Event_PlayerEncouterWin;
        public event PlayerEventDelegate Event_PlayerEncouterLose;

        public Player(string name, int maxHp, int pos_x, int pos_y)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.currentHp = this.maxHp;
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }

        private void SendPlayerEvent(PlayerEventDelegate playerEvent)
        {
            if (playerEvent != null)
            {
                playerEvent(this.name, this.maxHp, this.currentHp, this.pos_x, this.pos_y);
            }
        }

        public void Init()
        {
            SendPlayerEvent(Event_PlayerInit);
        }

        public void Move(int x, int y)
        {
            pos_x += x;
            pos_y += y;

            if(Encounter(encounterRate))
            {
                SendPlayerEvent(Event_PlayerEncouter);                
            }
            else
            {
                SendPlayerEvent(Event_PlayerMove);
            }
        }

        private bool Encounter(double encounterRate)
        {
            int rate = random.Next(0,100);

            if (rate < encounterRate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Fight()
        {
            double rate = random.Next(0,100);

            if (rate < winRate)
            {
                maxHp += (int)(maxHp * 0.05f);
                currentHp = maxHp;
                SendPlayerEvent(Event_PlayerEncouterWin);
            }
            else
            {
                currentHp -= (int)(maxHp * 0.05f);
                SendPlayerEvent(Event_PlayerEncouterLose);
            }
        }
    }
}
