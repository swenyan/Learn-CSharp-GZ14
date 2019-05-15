using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze_File
{
    class Block
    {
        public int x;
        public int y;
        public char blockChar;

        public Block(int x, int y, char blockChar)
        {
            this.x = x;
            this.y = y;
            this.blockChar = blockChar;
        }
    }
}
