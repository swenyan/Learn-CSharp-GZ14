using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    abstract class Warrior : Human
    {
        public abstract string job { get; }

        public Warrior(string name) : base(name)
        {
            Console.WriteLine("----------");
            SayHello();
            Console.WriteLine("----------");
        }

        public virtual void PrepareForBattle()
        {
            Console.WriteLine("{0} 准备战斗", name);
        }

        public abstract void SayHello();
    }
}
