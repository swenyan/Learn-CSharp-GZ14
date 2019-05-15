using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        private static string message = "Hello World";      // 声明字符串变量message，赋初始值Hello World

        private static string userName;
        private static string sex;

        private static bool isMale;             // “用户是男的”布尔值变量
        private static bool isCorrectSexType;   // “性别类型是否正确”布尔值变量

        private static string ageString;
        private static int age;

        private static string paiString;
        private static float pai;

        private static int balance;

        private static int int_num = 2;             // 整型变量用来存放整数
        private static float float_num = 3.14f;     // 浮点变量用来存放带小数的数

        static void Main(string[] args)
        {            
            SayHello();

            Add(1,2);

            Console.WriteLine("本金加利息总共是：" + GetBalance(10000, 1500));

            balance = GetBalance(2000, 100);

            Console.WriteLine("balance:" + balance);

            Console.WriteLine(int_num);
            Console.WriteLine(float_num);

            Console.WriteLine("您好，请输入姓名：");
            userName = Console.ReadLine();

            Console.WriteLine("请输入性别：");
            sex = Console.ReadLine();
            
            Console.WriteLine("请输入年龄：");
            ageString = Console.ReadLine();

            if(int.TryParse(ageString, out age))
            {
                Console.WriteLine("您今年" + age + "岁");
            }
            else
            {
                Console.WriteLine("年龄请输入整数！");
            }

            Console.WriteLine("请回答圆周率（精确到小数点后两位）：");
            paiString = Console.ReadLine();

            if(float.TryParse(paiString, out pai))
            {
                if(pai == 3.14f)
                {
                    Console.WriteLine("回答正确");
                }
                else                    
                {
                    Console.WriteLine("回答错误！");
                }
            }
            else
            {
                Console.WriteLine("请输入浮点数！");
            }


            isCorrectSexType = (sex == "男") || (sex == "女");    // sex字符串的内容是“男”或者“女”，性别类型就是正确的

            while (isCorrectSexType == false)
            {
                Console.WriteLine("性别类型错误，请输入男或女：");
                sex = Console.ReadLine();
                isCorrectSexType = (sex == "男") || (sex == "女");    // sex字符串的内容是“男”或者“女”，性别类型就是正确的
            }

            // 性别类型正确，再判断是男是女
            if (isCorrectSexType)
            {
                // Console.WriteLine("性别类型:" + sex + "，正确");

                // Ctrl+K 再按 Ctrl+C，注释选中的代码块
                // Ctrl+K 再按 Ctrl+U，取消选中的代码块的注释
                isMale = (sex == "男");

                if (isMale)
                {
                    Console.WriteLine("早上好，" + userName + "先生");
                }
                else
                {
                    Console.WriteLine("早上好，" + userName + "女士");
                }
            }
            else
            {
                Console.WriteLine("性别类型:" + sex + "，不正确");
            }
        }

        private static void SayHello()
        {
            Console.WriteLine("在SayHello方法里面说Hello");
        }

        private static void Add(int num1, int num2)
        {
            Console.WriteLine(num1 + "+" + num2 + "=" + (num1 + num2));
        }

        private static int GetBalance(int amount, int extra)
        {
            return (amount + extra);
        }
    }
}

