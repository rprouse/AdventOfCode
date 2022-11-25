using System.Collections.Generic;

namespace Leaderboard
{
    public class Member
    {
        public string name { get; set; }
        public int id { get; set; }
        public int global_score { get; set; }
        public int local_score { get; set; }
        public int stars { get; set; }
        public Dictionary<string, Day> completion_day_level { get; set; }
    }
}
