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

        public int goalPosX = 0;
        public int goalPosY = 0;

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
            Block[] blocks = new Block[9];
            blocks[0] = new Block(2, 2, '#');
            blocks[1] = new Block(2, 3, '#');
            blocks[2] = new Block(2, 4, '#');
            blocks[3] = new Block(3, 6, '#');
            blocks[4] = new Block(4, 2, '#');
            blocks[5] = new Block(5, 2, '#');
            blocks[6] = new Block(5, 4, '#');
            blocks[7] = new Block(5, 5, '#');
            blocks[8] = new Block(6, 6, 'o');

            stage = new char[row * col];

            for (int i = 0; i < row; i++)
            {
                for (int t = 0; t < col; t++)
                {
                    bool isWall = IsWall(row, col, i, t);

                    if (isWall)
                    {
                        CreateBlock(t, i, '*');
                        //stage[i * col + t] = '*';
                    }
                    else
                    {
                        CreateBlock(t, i, ' ');
                    }
                }
            }

            for(int i = 0; i < blocks.Length; i++)
            {
                CreateBlock(blocks[i].x, blocks[i].y, blocks[i].blockChar);
                if(blocks[i].blockChar == 'o')
                {
                    goalPosX = blocks[i].x;
                    goalPosY = blocks[i].y;
                }
            }
        }

        private bool IsWall(int row, int col, int i, int t)
        {
            bool isWall = false;

            // TODO : 判断是不是围墙

            // 判断标准：
            // 第一行和最后一行必定是围墙
            // 第一列和最后一列必定是围墙
            // '#'字符也是不能走的
            bool isFirstRow = false;
            bool isLastRow = false;
            bool isFirstCol = false;
            bool isLastCol = false;
            bool isObstacle = false;

            // 是否第一行
            isFirstRow = (t == 0);

            // 是否最后一行
            isLastRow = (t == row - 1);

            // 是否第一列
            isFirstCol = (i == 0);

            // 是否最后一列
            isLastCol = (i == col - 1);

            // 是不是 # 字障碍物
            isObstacle = (stage[t * col + i] == '#');

            // 上述五个条件任何一个满足，就是围墙
            isWall = isFirstRow || isLastRow || isFirstCol || isLastCol || isObstacle;
            return isWall;
        }

        private void SetPlayerPos(int newPosX, int newPosY)
        {
            if(IsWall(row, col, newPosX, newPosY) == false)
            {
                int currentIdx = playerPosY * col + playerPosX;
                //stage[currentIdx] = ' ';

                playerPosX = newPosX;
                playerPosY = newPosY;

                int idx = newPosY * col + newPosX;
                //stage[idx] = 'p';
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
                if(playerPosY * col + playerPosX == i)
                {
                    Console.Write('p');
                }
                else
                {
                    Console.Write(stage[i]);
                }

                Console.Write(' ');

                int mod = i % col;
                if (mod == col - 1)
                {
                    Console.Write('\n');
                }
            }
        }

        private void CreateBlock(int x, int y, char block)
        {
            stage[y * this.col + x] = block;
        }

        public bool IsPlayerReachedGoal()
        {
            return (playerPosX == goalPosX && playerPosY == goalPosY);
        }
    }
}
