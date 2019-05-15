using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectRelation
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human(10000);
            human1.Move(5, 5);

            Human human2 = new Human(100);
            human2.Move(3, 3);

            Human[] humanArray = new Human[100];

            for(int i = 0; i < humanArray.Length; i++)
            {
                humanArray[i] = new Human((i + 1) * 10);
            }

            Monster monster = new Monster(200, 100);
            monster.Move(1, 0);

            for (int i = 0; i < humanArray.Length; i++)
            {
                while(humanArray[i].GetHp() > 0)
                {
                    monster.TryAttack(humanArray[i]);
                }

                Console.WriteLine("吃掉了第" + i + "个人");
            }

            //for(int i = 0; i < 100; i++)
            //{
            //    monster.TryAttack(human1);
            //}
        }
    }
}
