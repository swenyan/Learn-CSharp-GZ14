using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEvent
{
    public class UI
    {
        Player player;

        public UI(Player player)
        {
            this.player = player;

            player.Event_PlayerInit += Player_Event_PlayerInit;
            player.Event_PlayerEncouter += OnPlayerEncounter;
            player.Event_PlayerMove += OnPlayerMove;
            player.Event_PlayerEncouterWin += OnPlayerEncounterWin;
            player.Event_PlayerEncouterLose += OnPlayerEncounterLose;
        }

        private void Player_Event_PlayerInit(string name, int maxHp, int currentHp, int pos_x, int pos_y)
        {
            Console.Clear();
            Console.WriteLine(name + "出生了");
            ShowPlayerProfile(name, maxHp, currentHp, pos_x, pos_y);
            ShowMoveHint();
            Process_Move();
        }

        private void OnPlayerEncounter(string name, int maxHp, int currentHp, int pos_x, int pos_y)
        {
            Console.WriteLine("敌人出现了!");
            ShowFightHint();
            Process_Fight();
        }

        private void OnPlayerMove(string name, int maxHp, int currentHp, int pos_x, int pos_y)
        {
            Console.Clear();
            Console.WriteLine("玩家移动到了 " + pos_x + "," + pos_y + " 位置");
            ShowPlayerProfile(name, maxHp, currentHp, pos_x, pos_y);
            ShowMoveHint();
            Process_Move();
        }

        private void OnPlayerEncounterLose(string name, int maxHp, int currentHp, int pos_x, int pos_y)
        {
            Console.Clear();
            Console.WriteLine("玩家输给了敌人，生命值减少为 " + currentHp);
            ShowPlayerProfile(name, maxHp, currentHp, pos_x, pos_y);
            ShowMoveHint();
            Process_Move();
        }

        private void OnPlayerEncounterWin(string name, int maxHp, int currentHp, int pos_x, int pos_y)
        {
            Console.Clear();
            Console.WriteLine("玩家战胜了敌人，最大生命值提升至 " + maxHp);
            ShowPlayerProfile(name, maxHp, currentHp, pos_x, pos_y);
            ShowMoveHint();
            Process_Move();
        }

        private void ShowPlayerProfile(string name, int maxHp, int currentHp, int pos_x, int pos_y)
        {
            Console.WriteLine("玩家：" + name);
            Console.WriteLine("生命：" + currentHp + " / " + maxHp);
            Console.WriteLine("坐标：" + pos_x + " , " + pos_y);
        }

        private void ShowMoveHint()
        {
            Console.WriteLine("WASD：移动");
        }

        private void ShowFightHint()
        {
            Console.WriteLine("按空格键战斗");
        }


        public void Process_Move()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            bool isMoveKey = key.Key == ConsoleKey.W || key.Key == ConsoleKey.A || key.Key == ConsoleKey.S || key.Key == ConsoleKey.D;

            while (!isMoveKey)
            {
                key = Console.ReadKey(true);
                isMoveKey = key.Key == ConsoleKey.W || key.Key == ConsoleKey.A || key.Key == ConsoleKey.S || key.Key == ConsoleKey.D;
            }

            switch (key.Key)
            {
                case ConsoleKey.W:
                    player.Move(0, 1);
                    break;
                case ConsoleKey.A:
                    player.Move(-1, 0);
                    break;
                case ConsoleKey.S:
                    player.Move(0, -1);
                    break;
                case ConsoleKey.D:
                    player.Move(1, 0);
                    break;
            }
        }

        public void Process_Fight()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            bool isFightKey = key.Key == ConsoleKey.Spacebar;

            while (!isFightKey)
            {
                key = Console.ReadKey(true);
                isFightKey = key.Key == ConsoleKey.Spacebar;
            }

            player.Fight();
        }
    }
}
