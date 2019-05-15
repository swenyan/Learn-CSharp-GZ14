using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLoop
{
    class Game
    {
        public bool isRunning;
        public string input;

        public int progress;

        public Monster monster;

        public bool isFighting;

        public void Start()
        {
            Console.WriteLine("游戏开始");
            isRunning = true;
            Console.WriteLine("1-前进，2-退出");
        }

        public void Update()
        {
            //Console.WriteLine("游戏正在进行");
            UpdateInput();
            UpdateGameplay();
        }

        public void End()
        {
            Console.WriteLine("游戏结束");
        }

        public void UpdateInput()
        {
            input = Console.ReadLine();
        }

        public void UpdateGameplay()
        {
            if(isFighting)
            {
                if (input == "1")
                {
                    if (monster != null)
                    {
                        monster.Hurt(50);
                        if (monster.isDead)
                        {
                            monster = null;
                        }
                    }
                }

                if (input == "2")
                {
                    isFighting = false;
                }

                if (input == "3")
                {
                    isRunning = false;
                }
            }
            else
            {
                if (input == "1")
                {
                    progress = progress + 1;
                    if (progress % 10 == 0)
                    {
                        EncounterMonster();
                    }
                }

                if (input == "2")
                {
                    isRunning = false;
                }
            }
        }

        private void EncounterMonster()
        {
            isFighting = true;
            monster = new Monster("史莱姆", 25 + progress * 2);
        }

        public void Render()
        {
            if(isFighting)
            {
                if(monster != null)
                {
                    Console.WriteLine("正在和" + monster.name + "战斗，它还有" + monster.hp + "点血");
                    Console.WriteLine("1-攻击，2-逃走，3-退出");
                }
                else
                {
                    Console.WriteLine("怪物死掉了");
                    isFighting = false;
                }
            }
            else
            {
                Console.WriteLine("玩家进度：" + progress);
                Console.WriteLine("1-前进，2-退出");
            }
        }
    }
}
