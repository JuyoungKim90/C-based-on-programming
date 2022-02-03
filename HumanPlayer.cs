using System;

namespace Gomoku
{
    class HumanPlayer : Player
    {
        
        public HumanPlayer(string ID, bool ishuman) // containner
        {
            playerID = ID;
            gamemodeHuman = ishuman;
        }
        
    }
}

