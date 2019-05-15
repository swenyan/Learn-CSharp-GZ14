using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Human human = new Human("小明");

            //Cat cat = new Cat();
            //Dog dog = new Dog();
            //TRex rex = new TRex();

            //cat.Meow();
            //dog.Bark();

            //// 以 Animal 为参数类型的方法，可以接受任何 Animal 子类作为参数
            //human.WalkWithAnimal(cat);
            //human.WalkWithAnimal(dog);

            //// 以 Cat 为参数类型的方法，只可以可以接受 Cat 类型作为参数
            //human.WalkWithCat(cat);
            ////human.WalkWithCat(dog);   // 想把 Dog 作为参数传入以 Cat 为参数类型的方法是不行的

            //// 以 Dog 为参数类型的方法，只可以可以接受 Dog 类型作为参数
            //human.WalkWithDog(dog);
            ////human.WalkWithDog(cat);   // 想把 Cat 作为参数传入以 Dog 为参数类型的方法是不行的

            //// 爬行动物可以冬眠
            //rex.Hibernate();

            //// 哺乳动物可以给其他动物喂奶
            //dog.FeedMilk(cat);
            //cat.FeedMilk(rex);

            Warrior[] warriors = new Warrior[3];

            //Warrior warrior = new Warrior("赵云");
            //warrior.PrepareForBattle();

            Swordman swordman = new Swordman("项羽");
            //swordman.PrepareForBattle();

            Archer archer = new Archer("黄忠");
            //archer.PrepareForBattle();

            Wizard wizard = new Wizard("孔明");
            //wizard.PrepareForBattle();

            warriors[0] = swordman;
            warriors[1] = archer;
            warriors[2] = wizard;

            Console.WriteLine("全军出击");

            for(int i = 0; i < warriors.Length; i++)
            {
                //warriors[i].SayHello();
                Console.WriteLine(warriors[i].name + ":" + warriors[i].job);
                warriors[i].PrepareForBattle();
            }

            Console.ReadKey();
        }
    }
}
