using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Swordman : Warrior
    {
        public override string job { get { return "剑士"; } }

        public Swordman(string name) : base(name)
        {

        }

        public override void PrepareForBattle()
        {
            PickupSword();
        }

        public void PickupSword()
        {
            Console.WriteLine("{0} 拿起了剑", name);
        }

        public override void SayHello()
        {
            PickupSword();
            Console.WriteLine("势不可挡");
        }
    }
}
