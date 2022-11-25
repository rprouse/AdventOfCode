using System;
using System.IO;
using System.Linq;
using RestSharp;
using AdventOfCode.Core;
using System.Text.Json;

namespace Leaderboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = 2020;
            if (args.Length > 1)
                year = args[0].ToInt(year);

            int board = 274125;
            if (args.Length == 2)
                board = args[1].ToInt(board);

            // Add the session token to a file called .aoc in the user directory
            var tokenFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".aoc");
            var token = File.ReadAllText(tokenFile).Trim();

            var client = new RestClient("https://adventofcode.com");
            var request = new RestRequest($"/{year}/leaderboard/private/view/{board}.json");
            request.AddHeader("Cookie", $"session={token}");
            RestResponse response = client.Get(request);

            //Console.WriteLine(response.Content);
            var leaders = JsonSerializer.Deserialize<Leaderboard>(response.Content);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"=== CoderCamp Leaderboard {year} ===");
            Console.WriteLine();

            int place = 1;
            foreach(var member in leaders.members.Values.OrderByDescending(m => m.local_score).ThenByDescending(m => m.stars))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("{0,3}) {1,3}  ", place++, member.local_score);

                for(int d = 1; d <= 25; d++)
                {
                    if(DateTime.Now.Date < new DateTime(year, 12, d))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("·");
                        continue;
                    }

                    string day = d.ToString();
                    if(member.completion_day_level.ContainsKey(day))
                    {
                        Day completed = member.completion_day_level[day];
                        if (completed.PartOne != null && completed.PartTwo != null)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.Write("*");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  {member.name}");
            }
            Console.ResetColor();
        }
    }
}
