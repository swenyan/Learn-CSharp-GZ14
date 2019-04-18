using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Reptile : Animal
    {
        public Reptile(string name) : base(name)
        {

        }

        public void Hibernate()
        {
            Console.WriteLine("{0} 冬眠", name);
        }
    }
}
