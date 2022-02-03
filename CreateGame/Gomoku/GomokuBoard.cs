using System;


namespace Gomoku
{

    public class GomokuBoard : Move
    {
        public GomokuBoard()
        {
            SetRowSize(15);
            SetColumnSize(15); // make a 15 # board
            newBoard();
        }

        public override void ShowBoard()
        {
            Console.WriteLine("[GomokuBoard] {0}*{1} board", this.rowSize, this.columnSize);

            for (int r = 0; r < this.rowSize; r++)
            {
     

                for (int c = 0; c < this.columnSize; c++)
                {

                    char stone = ' ';
                    Stone stone1 = stonelocation[r, c];
                    if (stone1 != null)
                    {
                        stone = stonelocation[r, c].shape;
                        if (c == 0)
                            Console.Write("  {0}-", stone); 
                        else if (c == this.columnSize - 1)
                            Console.Write("--{0}", stone);
                        else
                            Console.Write("---{0}-", stone);
                    }
                    else
                    {
                        if (c == 0)
                            Console.Write("   --"); 
                        else if (c == this.columnSize - 1)
                            Console.Write("--");
                        else
                            Console.Write("-- --");
                    }

                }

                Console.WriteLine();


                if (r < this.rowSize - 1)
                {
                    Console.Write("   ");
                    for (int c = 0; c < this.columnSize - 1; c++) 
                    {
                        Console.Write("|    ");
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
        }
            

        }
    }




