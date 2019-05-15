using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectRelation
{
    class Monster
    {
        public int hp;      // 怪物的生命值
        public int atk;     // 怪物的攻击力

        private int posX;    // 怪物位置的X坐标
        private int posY;    // 怪物位置的Y坐标

        public Monster(int var_hp, int var_atk)
        {
            hp = var_hp;
            atk = var_atk;
        }

        public void TryAttack(Human target)
        {
            if(IsTargetInRange(target))
            {
                Console.WriteLine("找到一个人，他的生命值是：" + target.GetHp() + "，看上去很好吃");
                target.Hurt(atk);
                //target.hp = target.hp - atk;
                Console.WriteLine("咬了这个人一口，他现在的生命值是：" + target.GetHp());

                if(target.GetHp() <= 0)
                {
                    Console.WriteLine("我吃掉了人");
                }
            }
            else
            {
                Console.WriteLine("太远了，吃不到");
            }
        }

        public void Move(int targetX, int targetY)
        {
            posX = targetX;
            posY = targetY;
        }

        private bool IsTargetInRange(Human target)
        {
            int rangeX = posX - target.GetPosX();
            int rangeY = posY - target.GetPosY();

            // rangeX   rangeY   结果
            //   -1       0      true
            //   +1       0      true
            //   0       -1      true
            //   0       +1      true
            //  其余情况均不在范围里

            // rangeX等于-1，或者等于+1时，if条件成立
            if ((rangeX == -1 || rangeX == 1))
            {
                // rangeY等于0时，if条件成立
                if(rangeY == 0)
                {
                    // 上面的两个if都成立的时候，程序会跑进这里，返回true值，方法到这里结束，方法下面的剩余代码不会再执行
                    return true;
                }
            }

            // ----------- 如果上面的两个if没有同时成立，方法会继续执行下面的剩余代码 -------------------

            // rangeY等于-1，或者等于+1时，if条件成立
            if ((rangeY == -1 || rangeY == 1))
            {
                // rangeX等于0时，if条件成立
                if (rangeX == 0)
                {
                    // 上面的两个if都成立的时候，程序会跑进这里，返回true值，方法到这里结束，方法下面的剩余代码不会再执行
                    return true;
                }
            }

            // ----------- 如果上面的if没有成立，说明目标不在范围里面，返回false值，结束方法 -------------------
            return false;
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
