using System;

namespace Gomoku
{
    public abstract class Board
    {
        protected Stone[,] Stonelocation;

        protected int rowSize; 
        protected int columnSize; 
        protected const int DEFAULT_SIZE = 3;
        protected int lastX;
        protected int lastY;

        public Board()
        {
            rowSize = DEFAULT_SIZE;
            columnSize = DEFAULT_SIZE;
            lastX = -1;
            lastY = -1; 
        }
        public int RowSize
        {
            get { return rowSize; }
        }
        public int ColumnSize
        {
            get { return columnSize; }
        }
        public int LastX
        {
            get { return lastX; }
        }
        public int LastY
        {
            get { return lastY; }
        }
        public Stone[,] stonelocation
        {
            get { return Stonelocation; }
        }



        public virtual void SetRowSize(int size)
        {
            this.rowSize = size;
        }
        public virtual void SetColumnSize(int size)
        {
            this.columnSize = size;
        }

        protected void newBoard()
        {
            this.Stonelocation = new Stone[rowSize, columnSize];
        }
 
        
    }
}
