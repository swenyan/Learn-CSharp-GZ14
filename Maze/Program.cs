using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game(8, 8, 1, 1);

            while(game.isRunning)
            {
                game.Loop();
            }

            game.End();

            //for (int i = 0; i < charArray.Length; i++)
            //{
            //    Console.WriteLine(charArray[i]);
            //}

            //Console.WriteLine(" -----------  我是分割线 ---------- ");

        }
    }
}
