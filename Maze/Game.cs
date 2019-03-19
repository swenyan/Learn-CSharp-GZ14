using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    class Game
    {
        public bool isRunning;

        private ConsoleKeyInfo key;
        private string keyString;
        private Stage stage;

        public Game(int row, int col, int playerPosX, int playerPosY)
        {
            isRunning = true;
            stage = new Stage(row, col, playerPosX, playerPosY);
        }

        public void Loop()
        {
            HandleInput();
            Update();
            Render();
        }

        public void Update()
        {
            switch(key.Key)
            {
                case ConsoleKey.W:
                    keyString = "向上";
                    stage.MovePlayer(Stage.UP);
                    break;
                case ConsoleKey.A:
                    keyString = "向左";
                    stage.MovePlayer(Stage.LEFT);
                    break;
                case ConsoleKey.S:
                    keyString = "向下";
                    stage.MovePlayer(Stage.DOWN);
                    break;
                case ConsoleKey.D:
                    keyString = "向右";
                    stage.MovePlayer(Stage.RIGHT);
                    break;
            }
        }

        public void HandleInput()
        {
            key = Console.ReadKey(true);
        }

        public void Render()
        {
            Console.Clear();
            Console.WriteLine(keyString);
            stage.DrawStage();
        }
    }
}
