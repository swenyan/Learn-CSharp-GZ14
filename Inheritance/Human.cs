using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Human
    {
        public string name { get; set; }

        public Human(string name)
        {
            this.name = name;
        }

        public void WalkWithCat(Cat cat)
        {
            cat.AnimalWalk();
        }

        public void WalkWithDog(Dog dog)
        {
            dog.AnimalWalk();
        }

        public void WalkWithAnimal(Animal animal)
        {
            Console.WriteLine(name + "带" + animal.name + "散步");
            animal.Walk();
        }
    }
}
