using System;
using System.IO;

namespace Gomoku
{
    public class Save 
    {
        public int X { get; set; }
        public int Y { get; set; }
        public StoneColor stoneColor{ get; set; }
        public char stoneShape { get; set; }
        
        public Save(int x, int y, StoneColor s, char ss)
        {
            this.X = x;
            this.Y = y;
            this.stoneColor = s;
            this.stoneShape= ss;
        }
        public void SaveGameHistory()
        {
            Console.WriteLine("Do you want to save the game? : enter Yes or No");
            string answer;
            answer = Console.ReadLine();
            if (answer == "Yes")
            {
                Console.WriteLine("The game is saved! Thank you for enjoying the game! Bye~");
                string filename = "../../Data/" + DateTime.Now.ToShortDateString() + "-"
                + DateTime.Now.Hour + DateTime.Now.Minute + ".txt";


                FileStream outfile = new FileStream(filename, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outfile);

                writer.WriteLine(0 + 0 + stoneColor + stoneShape);
                writer.Close();
                outfile.Close();

            }
            else
                Console.WriteLine("Bye~ Nice game!");

        }
    }
}
