using System.Text.Json.Serialization;

namespace Leaderboard
{
    public class Day
    {
        [JsonPropertyName("1")]
        public Part PartOne { get; set; }
        [JsonPropertyName("2")]
        public Part PartTwo { get; set; }
    }
}
