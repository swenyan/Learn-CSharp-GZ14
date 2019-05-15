using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Archer : Warrior
    {
        public override string job { get { return "箭手"; } }

        public Archer(string name) : base(name)
        {

        }

        public override void PrepareForBattle()
        {
            PickupBow();
        }

        public void PickupBow()
        {
            Console.WriteLine("{0} 弯弓搭箭", name);
        }

        public override void SayHello()
        {
            PickupBow();
            Console.WriteLine("百步穿杨");
        }
    }
}
