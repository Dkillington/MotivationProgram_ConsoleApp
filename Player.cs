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
        public bool bff { get; set; }

        //-1 Bad
        //0 Neutral
        //1 Good
    }
}
