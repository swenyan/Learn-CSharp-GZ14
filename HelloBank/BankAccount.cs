using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloBank
{
    class BankAccount
    {
        private string accountName; // 账户名
        private int age;            // 年龄
        private int amount;         // 账户余额

        // 构造函数，用于创建新的银行账户对象实例，var_name：账户名，var_age：年龄，var_amount：初始余额
        public BankAccount(string var_name, int var_age, int var_amount)
        {
            accountName = var_name;
            age = var_age;
            amount = var_amount;

            Console.WriteLine("您的新账号：" + accountName + "," + age + "," + amount);
        }

        // 存款方法
        public void Deposite(int deposite_amount)
        {
            int new_amount = amount + deposite_amount;
            amount = new_amount;
            Console.WriteLine("您存入" + deposite_amount + "，新的余额是：" + amount);
        }

        // 取款方法
        public void WithDraw(int withdraw_amount)
        {
            if(withdraw_amount <= amount)
            {
                int new_amount = amount - withdraw_amount;
                amount = new_amount;
                Console.WriteLine("您取出" + withdraw_amount + "，新的余额是：" + amount);
            }
            else
            {
                Console.WriteLine("余额不足");
            }
        }
    }
}
