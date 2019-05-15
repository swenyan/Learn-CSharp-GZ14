using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Animal
    {
        public string name;

        public Animal(string name)
        {
            this.name = name;
        }

        public void Walk()
        {
            Console.WriteLine("{0} 走路", name);
        }

        public void Eat()
        {
            Console.WriteLine("{0} 吃东西", name);
        }
    }
}
