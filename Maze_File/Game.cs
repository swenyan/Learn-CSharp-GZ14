using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Maze_File
{
    class Game
    {
        public const int WAIT_FOR_USER_NAME = 0;
        public const int PLAYING = 1;

        public int GameState = WAIT_FOR_USER_NAME;
        public bool isRunning;

        private bool isPlayerWon;

        private ConsoleKeyInfo key;
        private string keyString;
        private string hintString = "WASD-移动，R-重新开始，ESC-退出";
        private Stage stage;

        string[] scoreRecords;

        string name;
        int score;

        int level;

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

            Init(1);
        }

        private void Init(int level)
        {
            isRunning = true;
            isPlayerWon = false;
            keyString = "";

            this.level = level;

            stage = new Stage(this.level);

            //stage = new Stage(row, col, playerStartPosX, playerStartPosY);
        }

        public void Loop()
        {
            HandleInput();
            Update();
            Render();
        }

        public void Update()
        {
            if(GameState == PLAYING)
            {
                switch (key.Key)
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
                        SaveScore(this.name, this.score);
                        break;
                    case ConsoleKey.R:
                        Init(this.level);
                        break;
                }

                if (stage.IsPlayerReachedGoal())
                {
                    isPlayerWon = true;
                }
            }
        }

        public void HandleInput()
        {
            if(GameState == PLAYING)
            {
                key = Console.ReadKey(true);
            }
        }

        public void Render()
        {
            if(GameState == PLAYING)
            {
                Console.Clear();
                Console.WriteLine(keyString + "," + score);
                stage.DrawStage();
                Console.WriteLine(hintString);
                if (isPlayerWon)
                {
                    score += 100;

                    int nextLevel = level + 1;
                    if (Stage.HasLevel(nextLevel))
                    {
                        level++;
                        Console.Clear();
                        Init(level);
                    }
                    else
                    {
                        Console.WriteLine("恭喜打通全部关卡，你赢了！");
                        SaveScore(this.name, this.score);
                    }
                }
            }

            if(GameState == WAIT_FOR_USER_NAME)
            {
                Console.WriteLine("请输入姓名：");
                string name = Console.ReadLine();
                this.name = name;

                string[] scores = File.ReadAllLines("./HiScore.txt");

                for(int i = 0; i < scores.Length; i++)
                {
                    if(scores[i].StartsWith(name))
                    {
                        string[] splits = scores[i].Split(',');
                        score = int.Parse(splits[1]);
                        Console.WriteLine("{0}，欢迎回来，你的累积得分是：{1}，按任意键开始", name, score);
                        Console.ReadKey();
                        GameState = PLAYING;
                        scoreRecords = scores;

                        return;
                    }
                }

                // for 循环跑完，都没有找到和玩家输入匹配的名字，说明是新玩家

                score = 0;

                scoreRecords = new string[scores.Length + 1];

                for(int i = 0; i < scores.Length; i++)
                {
                    scoreRecords[i] = scores[i];
                }

                scoreRecords[scoreRecords.Length - 1] = string.Format("{0},{1}", name, score);

                Console.WriteLine("{0}，初次见面，你的得分从零开始，加油！按任意键开始", name);
                Console.ReadKey();
                GameState = PLAYING;
            }
        }

        public void SaveScore(string name, int score)
        {
            for(int i = 0; i < scoreRecords.Length; i++)
            {
                if(scoreRecords[i].StartsWith(name))
                {
                    scoreRecords[i] = string.Format("{0},{1}", name, score);
                }
            }
            File.WriteAllLines("./HiScore.txt", scoreRecords);
        }

        public void End()
        {
            Console.WriteLine("欢迎再玩，再见！");
        }
    }
}
