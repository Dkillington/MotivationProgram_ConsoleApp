using System;

namespace MotivationProgram
{
    [Serializable]
    class Player
    {
        public int timesPlayed { get; set; }
        public int timesAsked { get; set; }
        public int timesAskedThisSession { get; set; }
        public string name { get; set; }
        public int mood { get; set; }
        //-1 Bad
        //0 Neutral
        //1 Good
        public bool bff { get; set; }

        // Creating a player with specific characteristics
        public Player(int timesPlayed, int timesAsked, int timesAskedThisSession, string name, int mood, bool bff)
        {
            this.timesPlayed = timesPlayed;
            this.timesAsked = timesAsked;
            this.timesAskedThisSession = timesAskedThisSession;
            this.name = name;
            this.mood = mood;
            this.bff = bff;
        }

        // Creating a new (Blank) player
        public Player()
        {
            //Inital player stats
            name = "";
            mood = 0;
            timesPlayed = 0;
            timesAsked = 0;
            bff = false;
        }
    }
}
