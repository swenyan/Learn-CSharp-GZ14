using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Start();

            while(game.isRunning)
            {
                game.Update();
                game.Render();
            }

            game.End();

            Console.ReadLine();
        }
    }
}
