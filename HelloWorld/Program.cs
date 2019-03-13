using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//

namespace HelloWorld
{
    class Program
    {
        private static string message = "Hello World";      // 声明字符串变量message，赋初始值Hello World

        private static string userName;
        private static string sex;

        private static bool isMale;             // “用户是男的”布尔值变量
        private static bool isCorrectSexType;   // “性别类型是否正确”布尔值变量

        static void Main(string[] args)
        {
            Console.WriteLine("您好，请输入姓名：");
            userName = Console.ReadLine();

            Console.WriteLine("请输入性别：");
            sex = Console.ReadLine();

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
    }
}

