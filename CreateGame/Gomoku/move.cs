using System;

namespace Gomoku
{
    public abstract class Move :Board
    {
        
        public virtual void SetStone(int x, int y, Stone targetStone)
        {
            Stonelocation[x, y] = targetStone;
            lastX = x;
            lastY = y;
        }

        public virtual bool IsValidPosition(int x, int y)
        {
            if (x > this.rowSize - 1)
                return false;
            if (y > this.columnSize - 1)
                return false;
            Stone stone = Stonelocation[x, y];
            if (stone == null)
                return true;
            else
                return false;
        }
        public virtual void Undo()
        {
            if (lastX > this.rowSize - 1 || lastX < 0)
                return;
            if (lastY > this.columnSize - 1 || lastY < 0)
                return;
            Stonelocation[lastX, lastY] = null;
            lastX = -1;
            lastY = -1;
        }

        public virtual void ShowBoard()
        {

        }


    }
}
