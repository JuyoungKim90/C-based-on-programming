using System;


namespace Gomoku
{
    public class BlackStone : Stone
    {
        public StoneColor Color
        {
            get { return color; }
        }
        public char Graph
        {
            get { return shape; }
        }

        public BlackStone()
        {
            color = StoneColor.Black;
            shape = '●';
        }
    }
}