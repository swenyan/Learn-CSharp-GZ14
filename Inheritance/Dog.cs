using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Dog : Mammal
    {
        public Dog() : base("狗")
        {

        }

        public void AnimalWalk()
        {
            Console.WriteLine("{0} 走狗步", name);
        }

        public void Bark()
        {
            Console.WriteLine("汪汪");
        }
    }
}
