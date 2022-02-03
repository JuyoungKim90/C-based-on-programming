using System;

namespace Gomoku
{
    public class Player
    {
        public string playerID;
        public bool gamemodeHuman;
        
        public string ID
        {
            get { return playerID; }
        }
        public bool IsHuman
        {
            get { return gamemodeHuman; }
        }

    }
}
