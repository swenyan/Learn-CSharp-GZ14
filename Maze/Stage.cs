using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    class Stage
    {
        public const int UP = 0;
        public const int DOWN = 1;
        public const int LEFT = 2;
        public const int RIGHT = 3;

        public int row = 8;
        public int col = 8;

        public int playerPosX = 1;
        public int playerPosY = 1;

        char[] stage;

        public Stage(int row, int col, int playerPosX, int playerPosY)
        {
            this.row = row;
            this.col = col;

            this.playerPosX = playerPosX;
            this.playerPosY = playerPosY;

            CreateStage(this.row, this.col);
            SetPlayerPos(this.playerPosX, this.playerPosY);
        }

        private void CreateStage(int row, int col)
        {
            stage = new char[row * col];

            for (int i = 0; i < row; i++)
            {
                for (int t = 0; t < col; t++)
                {
                    bool isWall = IsWall(row, col, i, t);

                    if (isWall)
                    {
                        stage[i * col + t] = '*';
                    }
                    else
                    {
                        stage[i * col + t] = ' ';
                    }
                }
            }
        }

        private static bool IsWall(int row, int col, int i, int t)
        {
            bool isWall = false;

            // TODO : 判断是不是围墙

            // 判断标准：
            // 第一行和最后一行必定是围墙
            // 第一列和最后一列必定是围墙

            bool isFirstRow = false;
            bool isLastRow = false;
            bool isFirstCol = false;
            bool isLastCol = false;

            // 是否第一行
            isFirstRow = (i == 0);

            // 是否最后一行
            isLastRow = (i == row - 1);

            // 是否第一列
            isFirstCol = (t == 0);

            // 是否最后一列
            isLastCol = (t == col - 1);

            // 上述四个条件任何一个满足，就是围墙
            isWall = isFirstRow || isLastRow || isFirstCol || isLastCol;
            return isWall;
        }

        private void SetPlayerPos(int newPosX, int newPosY)
        {
            if(IsWall(row, col, newPosX, newPosY) == false)
            {
                int currentIdx = playerPosY * col + playerPosX;
                stage[currentIdx] = ' ';

                playerPosX = newPosX;
                playerPosY = newPosY;

                int idx = newPosY * col + newPosX;
                stage[idx] = 'p';
            }
        }

        public void MovePlayer(int direction)
        {
            switch(direction)
            {
                case UP:
                    SetPlayerPos(playerPosX, playerPosY - 1);
                    break;
                case DOWN:
                    SetPlayerPos(playerPosX, playerPosY + 1);
                    break;
                case LEFT:
                    SetPlayerPos(playerPosX - 1, playerPosY);
                    break;
                case RIGHT:
                    SetPlayerPos(playerPosX + 1, playerPosY);
                    break;
            }
        }

        public void DrawStage()
        {
            for (int i = 0; i < stage.Length; i++)
            {
                Console.Write(stage[i]);
                Console.Write(' ');

                int mod = i % col;
                if (mod == col - 1)
                {
                    Console.Write('\n');
                }
            }
        }
    }
}
