using System;



namespace Gomoku
{
    public enum StoneColor
    {
        Black,White
    }

    public abstract class Stone
    {
        public StoneColor color;
        public char shape;

    }
}