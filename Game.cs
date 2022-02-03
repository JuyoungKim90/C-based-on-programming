using System;


namespace Gomoku
{
    public abstract class Game
    {
        protected int playersCount;
        protected int winnerIndex;
        protected Move board;
        protected Stone[] stoneArray;
        protected Player[] playerArray;

        protected abstract Move makeBoard();
        protected abstract void initializeGame();
        public abstract bool IsOver();

        protected abstract void printWinner();

        protected abstract void makePlay(int player);

        public void Play()
        {
            board = makeBoard();
            initializeGame();

            int index = 0;
            while (!IsOver())
            {
                makePlay(index);
                index = (index + 1) % playersCount;
            }
            printWinner();
        }
    }
}