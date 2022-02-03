using System;
using System.IO;

namespace Gomoku
{
    public class Help
    {
        
        public void WelcomeUser()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("==   WELCOME TO IFN 563 GOMOKU GAME   ==");
            Console.WriteLine("========================================");
        }
        

        public void SupportUser()
        {
            Console.WriteLine("Do you need help? : enter 'Yes' or 'No'");
            string answer1, answer2;
            answer1 = Console.ReadLine();

            while (answer1 == "Yes")
            {
                Console.WriteLine("Here is guidebook for the game");
                string line;

                StreamReader manual = new StreamReader("GameGuide.txt");
                line = manual.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = manual.ReadLine();
                }

                manual.Close();

                Console.WriteLine("Now, Are you ready to play game? : enter 'Yes' or 'No'");
                answer2 = Console.ReadLine();
                if (answer2 == "Yes")
                    break;

                else
                    Console.WriteLine("That's Okay I will provide the guide book");
            }

        }
    }
}