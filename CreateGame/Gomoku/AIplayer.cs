using System;


namespace Gomoku
{
    class AIPlayer : Player
    {

        public AIPlayer(string ID, bool ishuman)
        {
            playerID = ID;
            gamemodeHuman = ishuman;
        }

    }
}

