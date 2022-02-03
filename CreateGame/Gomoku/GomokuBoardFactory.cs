using System;


namespace Gomoku
{

    public class GomokuBoardFactory
    {

        public Move makeBoard()
        {
            return new GomokuBoard();
        }
    }
}
