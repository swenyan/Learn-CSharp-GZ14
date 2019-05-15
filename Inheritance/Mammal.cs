using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Mammal : Animal
    {
        public Mammal(string name) : base (name)
        {

        }

        public void FeedMilk(Animal baby)
        {
            Console.WriteLine("{0} 开始对 {1} 哺乳", name, baby.name);
            baby.Eat();
        }
    }
}
