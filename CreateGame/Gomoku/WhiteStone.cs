using System;


namespace Gomoku
{
    public class WhiteStone : Stone
    {
        public StoneColor Color
        {
            get { return color; }
        }
        public char Graph
        {
            get { return shape; }
        }

        public WhiteStone()
        {
            color = StoneColor.White;
            shape = '○';
        }
    }
}