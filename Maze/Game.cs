﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    class Game
    {
        public bool isRunning;

        private bool isPlayerWon;

        private ConsoleKeyInfo key;
        private string keyString;
        private string hintString = "WASD-移动，R-重新开始，ESC-退出";
        private Stage stage;

        int row;
        int col;
        int playerStartPosX;
        int playerStartPosY;

        public Game(int row, int col, int playerPosX, int playerPosY)
        {
            this.row = row;
            this.col = col;
            this.playerStartPosX = playerPosX;
            this.playerStartPosY = playerPosY;

            Init();
        }

        private void Init()
        {
            isRunning = true;
            isPlayerWon = false;
            keyString = "";
            stage = new Stage(row, col, playerStartPosX, playerStartPosY);
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
                case ConsoleKey.Escape:
                    isRunning = false;
                    break;
                case ConsoleKey.R:
                    Init();
                    break;
            }

            if(stage.IsPlayerReachedGoal())
            {
                isPlayerWon = true;
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
            Console.WriteLine(hintString);
            if (isPlayerWon)
            {
                Console.WriteLine("你赢了！");
            }
        }

        public void End()
        {
            Console.WriteLine("欢迎再玩，再见！");
        }
    }
}
