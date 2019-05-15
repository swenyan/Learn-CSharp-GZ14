using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectRelation
{
    class Human
    {
        public string name;
        private int hp;
        private int posX;    // 人类位置的X坐标
        private int posY;    // 人类位置的X坐标

        public int healAmount = 20;

        public Human(int var_hp)
        {
            hp = var_hp;
            Console.WriteLine("一个新的人类出生了，生命值是：" + hp);
        }

        public void Move(int targetX, int targetY)
        {
            posX = targetX;
            posY = targetY;
        }

        public void Hurt(int atk)
        {
            if(atk > 0)
            {
                if(hp > 0)
                {
                    int damage = (int)(atk * 0.9f);
                    hp = hp - damage;

                    if (hp <= 0)
                    {
                        Console.WriteLine(name + "挂了");
                    }
                    else
                    {
                        Console.WriteLine(name + "受到了" + damage + "点伤害");
                    }
                }
                else
                {
                    Console.WriteLine("放过死人吧");
                }
            }
            else
            {
                Console.WriteLine("攻击力小于等于0，无效");
            }
        }

        public void Heal(Human target)
        {
            target.RecoverHP(healAmount);
        }

        public void RecoverHP(int recoverAmount)
        {
            if(recoverAmount > 0)
            {
                hp = hp + recoverAmount;
                if(hp > 100)
                {
                    hp = 100;
                }

                Console.WriteLine(name + "的生命值回复到" + hp + "点");
            }
        }

        public int GetHp()
        {
            return hp;
        }

        public int GetPosX()
        {
            return posX;
        }

        public int GetPosY()
        {
            return posY;
        }

    }
}
