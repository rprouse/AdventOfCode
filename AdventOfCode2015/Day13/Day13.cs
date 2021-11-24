using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

using HappinessGraph = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>>;

namespace AdventOfCode2015
{
    public static class Day13
    {
        public static int PartOne(string filename)
        {
            var people = GetHappiness(filename);
            var routes = Seatings(people.Keys.ToList());
            return CalculateMaxHappiness(people, routes);
        }

        private static int CalculateMaxHappiness(HappinessGraph people, IEnumerable<IList<string>> seatings)
        {
            int maxHappy = int.MinValue;
            foreach (var seating in seatings)
            {
                int happiness = 0;

                happiness += people[seating[0]][seating[seating.Count - 1]];
                happiness += people[seating[0]][seating[1]];

                for (int i = 1; i < seating.Count - 1; i++)
                {
                    happiness += people[seating[i]][seating[i - 1]];
                    happiness += people[seating[i]][seating[i + 1]];
                }

                happiness += people[seating[seating.Count - 1]][seating[seating.Count - 2]];
                happiness += people[seating[seating.Count - 1]][seating[0]];

                if (happiness > maxHappy)
                    maxHappy = happiness;
            }

            return maxHappy;
        }

        const string ME = "me";
        public static int PartTwo(string filename)
        {
            var people = GetHappiness(filename);
            var me = new Dictionary<string, int>();
            foreach(var person in people)
            {
                me[person.Key] = 0;
                person.Value[ME] = 0;
            }
            people.Add(ME, me);
            var routes = Seatings(people.Keys.ToList());
            return CalculateMaxHappiness(people, routes);
        }

        internal static IEnumerable<IList<string>> Seatings(IList<string> people)
        {
            List<IList<string>> seatings = new List<IList<string>>();
            foreach (var p in people)
            {
                seatings.AddRange(Seatings(p, people));
            }
            return seatings;
        }

        internal static IEnumerable<IList<string>> Seatings(string start, IList<string> people)
        {
            var cloned = new List<string>(people);
            cloned.Remove(start);

            if (cloned.Count > 0)
            {
                foreach (var c in cloned)
                {
                    var childSeatings = Seatings(c, cloned);
                    foreach (var seating in childSeatings)
                    {
                        yield return seating.Prepend(start).ToList();
                    }
                }
            }
            else
            {
                yield return new List<string> { start };
            }
        }

        internal static HappinessGraph GetHappiness(string filename)
        {
            var people = new Dictionary<string, Dictionary<string, int>>();
            string[] lines = filename.ReadAllLines();
            foreach (string line in lines)
            {
                string[] parts = line.TrimEnd('.').Split(' ');
                var per1 = parts[0];
                var per2 = parts[10];
                var hpy = parts[3].ToInt();
                if (parts[2] == "lose") hpy = -hpy;

                if (!people.ContainsKey(per1))
                    people.Add(per1, new Dictionary<string, int>());

                var happiness = people[per1];
                happiness.Add(per2, hpy);
            }
            return people;
        }
    }
}
