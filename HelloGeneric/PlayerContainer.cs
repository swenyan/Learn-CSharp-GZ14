using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGeneric
{
    class PlayerContainer<T> : IGetNextElem<T> where T : Player
    {
        public int Length { get { return array.Length; } }

        private int idx = 0;

        T[] array;

        public PlayerContainer(int capacity)
        {
            array = new T[capacity];
        }

        public T Get(int i)
        {
            Console.WriteLine("获取" + array[i].name + "，maxHp:" + array[i].maxHp);
            return array[i];
        }

        public void Set(int i, T elem)
        {
            Console.WriteLine(elem.name + "被放进容器了");
            array[i] = elem;
        }

        public T Next()
        {
            int currentIdx = idx;

            if (idx < Length - 1)
            {
                idx++;
            }

            return array[currentIdx];
        }
    }
}
