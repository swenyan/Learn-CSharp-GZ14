using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 银行开户，存款，取款
namespace HelloBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // 显示欢迎信息
            Console.WriteLine("欢迎光临王氏银行，请选择操作：");
            Console.WriteLine("1-开户，2-离开");

            // 声明银行账户类型的变量，用于指向下面新创建的账户对象
            BankAccount account;

            // 存放用户输入的账户信息的变量
            string accountName;
            int age;
            int amount;

            // 接收用户的第一次输入
            string op = Console.ReadLine();

            // 用于保存用户第一次输入的数值的变量
            int op_int;

            // 检查用户输入的是不是整数，如果是整数，根据整数数值选择操作
            // 如果不是整数，程序会直接结束
            if (int.TryParse(op, out op_int))
            {
                // 用户输入的是数字1，执行开户操作
                if (op_int == 1)
                {
                    // 提示用户输入新户名，保存在accountName变量中
                    Console.WriteLine("请输入新户名：");
                    accountName = Console.ReadLine();

                    // 提示用户输入年龄
                    Console.WriteLine(accountName + "您好，请输入年龄：");
                    string ageString = Console.ReadLine();

                    // 检测年龄输入是不是整数，如果是整数，将年龄保存在age变量里，继续提示用户输入金额
                    // 如果年龄不是整数，程序会直接结束
                    if (int.TryParse(ageString, out age))
                    {
                        // 提示用户输入金额
                        Console.WriteLine("请输入要存入新账户的金额：");
                        string amountString = Console.ReadLine();

                        // 检测金额输入是不是整数，如果是整数，将金额保存在amount变量里，创建账户对象实例，提示用户进行存取款操作
                        // 如果金额不是整数，程序会直接结束
                        if (int.TryParse(amountString, out amount))
                        {
                            // 创建账户对象实例，赋值给account变量，之后可以用account变量找到这个账户对象
                            Console.WriteLine("正在为您创建账户，请稍候...");
                            account = new BankAccount(accountName, age, amount);

                            // 提示用户操作
                            Console.WriteLine(accountName + "您好，请选择操作：");
                            Console.WriteLine("1-存钱，2-取钱，3-离开");
                            string account_op = Console.ReadLine();

                            // 不断根据用户选择的操作执行存款或取款
                            // 当用户选择3时，结束循环
                            while (account_op != "3")
                            {
                                // 用户选择1时，执行存款
                                if (account_op == "1")
                                {
                                    Console.WriteLine("请输入存款金额：");
                                    string deposite_amount_string = Console.ReadLine();
                                    int deposite_amount;

                                    if (int.TryParse(deposite_amount_string, out deposite_amount))
                                    {
                                        account.Deposite(deposite_amount);
                                    }
                                }

                                // 用户选择2时，执行取款
                                if (account_op == "2")
                                {
                                    Console.WriteLine("请输入取款金额：");
                                    string withdraw_amount_string = Console.ReadLine();
                                    int withdraw_amount;

                                    if (int.TryParse(withdraw_amount_string, out withdraw_amount))
                                    {
                                        account.WithDraw(withdraw_amount);
                                    }
                                }

                                // 继续接受用户的下一次输入
                                Console.WriteLine(accountName + "您好，请选择操作：");
                                Console.WriteLine("1-存钱，2-取钱，3-离开");
                                account_op = Console.ReadLine();
                            }

                            // 循环结束后，显示送别信息，结束程序
                            Console.WriteLine("谢谢光临，欢迎再来");
                            return;
                        }
                    }
                }

                // 用户输入的是数字2，显示送别信息，结束程序
                if (op_int == 2)
                {
                    Console.WriteLine("谢谢光临，欢迎再来");
                    return;
                }
            }
        }

        static void Test()
        {
            BankAccount account1 = new BankAccount("王氏", 23, 10000);
            BankAccount account2 = new BankAccount("教育", 27, 20000);

            account1.Deposite(5000);
            account2.Deposite(1000);

            account1.WithDraw(15000);
            account2.WithDraw(12000);
        }
    }
}
