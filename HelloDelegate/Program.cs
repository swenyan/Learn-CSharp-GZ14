using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDelegate
{
    public class Program
    {
        delegate void VoidDelegate();
        public delegate void StringDelegate(string s);
        public delegate int IntDelegate(int a, int b);

        static VoidDelegate voidInstance;
        static StringDelegate sDelegate;

        static IntDelegate intDelegate;

        static void Main(string[] args)
        {
            sDelegate = StringCallback;

            TestClass testObj = new TestClass();

            voidInstance = testObj.Func1;
            voidInstance();

            voidInstance = testObj.Func2;
            voidInstance();

            Console.WriteLine();

            voidInstance += testObj.Func1;
            voidInstance += testObj.Func1;
            voidInstance += testObj.Func1;
            voidInstance += testObj.Func2;
            voidInstance();

            int c = testObj.Add(3, 5);

            testObj.ReturnResultWithCallback("Video", "Game", sDelegate);

            intDelegate += testObj.Sub;
            intDelegate += testObj.Add;
            intDelegate += testObj.Sub;

            int result = intDelegate(10, 2);

            Console.WriteLine("c = " + c);
            Console.WriteLine("result = " + result);

            Console.ReadKey();
        }

        static void StringCallback(string s)
        {
            Console.WriteLine("回调函数收到的处理结果是：" + s);
        }
    }

    public class TestClass
    {
        public void Func1()
        {
            Console.WriteLine("I am Func1");
        }

        public void Func2()
        {
            Console.WriteLine("I am Func2");
        }

        public void ReturnResultWithCallback(string a, string b, Program.StringDelegate callback)
        {
            // After a long long wait...
            string result = a + b;
            callback(result);
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }
    }
}
