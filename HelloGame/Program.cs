using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.gameName = "王氏自走棋";

            game.Start();

            while(game.isRunning)
            {
                game.Update();
            }

            game.End();
        }
    }
}
