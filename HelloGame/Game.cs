using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloGame
{
    class Game
    {
        public string gameName;
        public bool isRunning;

        private int loopCount;
        private string message;

        public void Start()
        {
            Console.WriteLine(gameName + "游戏开始了");
            isRunning = true;
        }

        public void Update()
        {
            loopCount = loopCount + 1;

            Console.WriteLine(gameName + "已运行" + loopCount + "回合");
            Console.WriteLine("还要继续玩吗？退出请按1，继续请按其他键");
            message = Console.ReadLine();

            if(message == "1")
            {
                isRunning = false;
            }
        }

        public void End()
        {
            Console.WriteLine("感谢您玩" + gameName + "，再见！");
        }
    }
}
