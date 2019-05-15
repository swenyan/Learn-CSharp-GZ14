using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDictionary
{
    class Human
    {
        public string name;
        public int age;

        public Human(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void ShowProfile()
        {
            Console.WriteLine("name:{0}, age:{1}", name, age);
        }
    }
}
