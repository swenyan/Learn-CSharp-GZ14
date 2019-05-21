using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGeneric
{
    class Program
    {
        public delegate void EventDelegate();
        public delegate void EventDelegate<T>(T var1);
        public delegate void EventDelegate<T, U>(T var1, U var2);
        public delegate void EventDelegate<T, U, V>(T var1, U var2, V var3);
        public delegate void EventDelegate<T, U, V, W>(T var1, U var2, V var3, W var4);

        static void Main(string[] args)
        {
            EventDelegate<int, float> eventDelegate = SomeFunction;
            EventDelegate<bool, string> eventDelegate2 = SomeFunction2;

            eventDelegate(255, 3.14f);
            eventDelegate2(true, "TRUE");

            ArrayContainer<int> intContainer = new ArrayContainer<int>(10);

            ArrayContainer<Player> playerContainer = new ArrayContainer<Player>(10);


            for(int i = 0; i < intContainer.Length; i++)
            {
                intContainer.Set(i, i * 2);
                playerContainer.Set(i, new Player());
            }

            for (int i = 0; i < intContainer.Length * 2; i++)
            {
                int g = intContainer.Next();
                Player p = playerContainer.Next();
                Console.WriteLine("{0},{1},{2}",p.name, p.maxHp, g);
            }

            int inta = 3;
            int intb = 6;

            Console.WriteLine("Before Swap: inta:{0}, intb:{1}", inta, intb);

            Swap<int>(ref inta, ref intb);

            Console.WriteLine("After Swap: inta:{0}, intb:{1}", inta, intb);

            Player p1 = new Player("Mario", 100, 1, 2);
            Player p2 = new Player("Lugi", 200, 2, 1);

            playerContainer.Set(0, p1);
            playerContainer.Set(1, p2);

            playerContainer.Get(0);
            playerContainer.Get(1);

            Console.WriteLine("Before Swap: p1:{0}, p2:{1}", p1.name, p2.name);
            Swap<Player>(ref p1, ref p2);
            Console.WriteLine("After Swap: p1:{0}, p2:{1}", p1.name, p2.name);
        }

        static void SomeFunction(int a, float b)
        {
            Console.WriteLine(a + "," + b);
        }

        static void SomeFunction2(bool a, string b)
        {
            Console.WriteLine(a + "," + b);
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp;
            
            temp = a;
            a = b;
            b = temp;
        }
    }
}
