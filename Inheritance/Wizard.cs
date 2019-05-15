using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Wizard : Warrior
    {
        public override string job { get { return "法师"; } }

        public Wizard(string name) : base(name)
        {

        }

        public override void PrepareForBattle()
        {
            ChargeMana();
        }

        public void ChargeMana()
        {
            Console.WriteLine("{0} 举起法杖充能", name);
        }

        public override void SayHello()
        {
            ChargeMana();
            Console.WriteLine("你对力量一无所知");
        }
    }
}
