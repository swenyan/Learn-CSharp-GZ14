using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGeneric
{
    public class ArrayContainer<T> : IGetNextElem<T> where T : new()
    {
        public int Length { get { return array.Length; } }

        private int idx = 0;

        T[] array;

        public ArrayContainer(int capacity)
        {
            array = new T[capacity];

            for(int i = 0; i < capacity; i++)
            {
                array[i] = new T();
            }
        }

        public T Get(int i)
        {
            return array[i];
        }

        public void Set(int i, T elem)
        {
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
