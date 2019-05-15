using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Cat : Mammal
    {
        public Cat() : base("猫")
        {

        }

        public void AnimalWalk()
        {
            Console.WriteLine("{0} 走猫步", name);
        }

        public void Meow()
        {
            Console.WriteLine("喵喵");
        }
    }
}
