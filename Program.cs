using System;

namespace Gomoku
{
    class Program
    {
        static void Main(string[] args)
        {

            Help h = new Help();
            h.WelcomeUser();
            h.SupportUser();

            GomokuGame newgame = new GomokuGame();
            newgame.Play();

            Save historygame1 = new Save(0,0,StoneColor.Black, '●');
            Save historygame2= new Save(1, 1, StoneColor.White, '○');

            historygame1.SaveGameHistory();
            historygame2.SaveGameHistory();
        }
    }


class GomokuGame : Game
{

    protected override Move makeBoard()
    {
        //Make a Board
        GomokuBoardFactory factory = new GomokuBoardFactory();
        return factory.makeBoard();

    }

    protected override void initializeGame()
    {
        
        playersCount = 2;
        string strName, strAnswer = "n";

        // Set stone array
        stoneArray = new Stone[playersCount];
        stoneArray[0] = new BlackStone();
        stoneArray[1] = new WhiteStone();


        // set player information
        playerArray = new Player[playersCount];
        for (int i = 0; i < playersCount; i++)
        {
            Console.Write("Input {0} player's ID: ", i+1);
            strName = Console.ReadLine();
            if (i > 0)
            {
                Console.WriteLine("Do you want to play with computer? Yes or No");
                strAnswer = Console.ReadLine();
            }

            if (strAnswer != "Yes" && strAnswer != "yes")
                playerArray[i] = new HumanPlayer(strName, true);
            else
                playerArray[i] = new AIPlayer(strName, false);
        }
        //Show board
        board.ShowBoard();
     }

        public override bool IsOver()
        {
            //check the gomoku game rule(5 stone in a low direction of up, down, right, left, and diagnal)
            int stoneCount = 0;

            for (int x = 0; x < board.RowSize; x++)
            {
                for (int y = 0; y < board.ColumnSize; y++)
                {
                    Stone stone = board.stonelocation[x, y]; 
                    StoneColor TargetColor;

                    if (stone == null)
                        continue;
                    else
                        stoneCount++;

                    TargetColor = board.stonelocation[x, y].color;

                    for (int xDir = -1; xDir <= 1; xDir++)
                    {
                        for (int yDir = -1; yDir <= 1; yDir++)
                        {
                            if (xDir == 0 && yDir == 0)
                                continue;
                            int count = 0;
                            while (count < 5)
                            {
                                int targetX = x + count * xDir;
                                int targetY = y + count * yDir;
                                if (targetX < 0 || targetX >= board.RowSize || targetY < 0 || targetY >= board.ColumnSize || board.stonelocation[targetX, targetY] == null || board.stonelocation[targetX, targetY].color != TargetColor)
                                    break;
                                count++;
                            }
                            if (count == 5)
                            {
                               
                                if (TargetColor == StoneColor.Black)
                                    winnerIndex = 0;
                                else
                                    winnerIndex = 1;
                                return true;
                            }
                        }
                    }
                }
            }

            // check board situation
            if (stoneCount == board.RowSize * board.ColumnSize)
                return true;

            return false;
        }
        //make a play
        protected override void makePlay(int index)
        {
            int xValue = 0;
            int yValue = 0;
            string undo = "";
            while (true)
            {
                //request the setting the stone location to human player
                if (playerArray[index].IsHuman)
                {
                    Console.Write("[player{0}:{1}] Input Stone X axis location :", index+1, playerArray[index].ID);
                    xValue = Convert.ToInt32(Console.ReadLine());
                    Console.Write("[player{0}:{1}] Input Stone Y axis location :", index+1, playerArray[index].ID);
                    yValue = Convert.ToInt32(Console.ReadLine());

                    

                    if (board.IsValidPosition(xValue, yValue))
                    {
                        board.SetStone(xValue, yValue, stoneArray[index]);//(int x, int y, Stone stone); 
                        board.ShowBoard();

                        Console.WriteLine("[player{0}:{1}] Do you want to undo and redo? : enter Yes or No ", index+1, playerArray[index].ID);
                        undo = Console.ReadLine();
                        
                        if (undo == "Yes")
                        {
                            board.Undo();
                            board.ShowBoard();
                            continue;
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid position. Please put the stone in  valid position.");
                        continue;
                    }
            }
                //computer player random move
                else
                {

                    Random random = new Random();
                    for (int x = 0; x < board.RowSize; x++)
                    {
                        x = random.Next(0, board.RowSize);

                        for (int y = 0; y < board.ColumnSize; y++)
                        {
                            y = random.Next(0, board.ColumnSize);
                            if (board.IsValidPosition(x, y))
                            {
                                board.SetStone(x, y, stoneArray[index]);
                                Console.WriteLine("[player{0}:{1}] put stone at [{2},{3}]", index + 1, playerArray[index].ID, x, y);

                                board.ShowBoard();
                                return;
                            }


                        }
                    }

                }
       

            }
        }
        // Notice winner
        protected override void printWinner()
        {
            if (winnerIndex == -1)
                Console.WriteLine("no winner");
            else
                Console.WriteLine("winner is :{0}", playerArray[winnerIndex].ID);
        }

        
    }
}
