using System.Collections.Generic;

namespace Leaderboard
{
    public class Leaderboard
    {
        public string year { get; set; }

        public string owner_id { get; set; }

        public Dictionary<string, Member> members { get; set; }
    }
}
