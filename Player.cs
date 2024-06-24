using System;
using System.Collections.Generic;

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
        public friendEnums friendStatus { get; set; }

        // Creating a player with specific characteristics
        public Player(int timesPlayed, int timesAsked, int timesAskedThisSession, string name, int mood, friendEnums friendStatus)
        {
            this.timesPlayed = timesPlayed;
            this.timesAsked = timesAsked;
            this.timesAskedThisSession = timesAskedThisSession;
            this.name = name;
            this.mood = mood;
            this.friendStatus = friendStatus;
        }

        // Creating a new (Blank) player
        public Player()
        {
            //Inital player stats
            name = "";
            mood = 0;
            timesPlayed = 0;
            timesAsked = 0;
            friendStatus = friendEnums.Acquaintance;
        }










        public string ReturnMood()
        {
            if (mood < 0)
            {
                return "Bad";
            }
            if (mood > 0)
            {
                return "Good";
            }
            else
            {
                return "Neutral";
            }
        }

        public string ReturnName()
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return "Unknown";
            }
            else
            {
                return name;
            }
        }

        public void UpgradeFriendStatus()
        {
            List<friendEnums> statuses = new List<friendEnums>();
            PopulateList();
            int nextIndex = (statuses.IndexOf(friendStatus) + 1);

            try
            {
                friendStatus = statuses[nextIndex];
            }
            catch
            {

            }

            void PopulateList()
            {
                foreach (friendEnums friendEnum in Enum.GetValues(typeof(friendEnums)))
                {
                    statuses.Add(friendEnum);
                }
            }
        }
    }
}
