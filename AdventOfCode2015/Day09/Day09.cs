using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

using CityGraph = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>>;

namespace AdventOfCode2015
{
    public static class Day09
    {
        public static int PartOne(string filename)
        {
            var cities = GetCities(filename);
            var routes = Day09.Routes(cities.Keys.ToList());

            int minDist = int.MaxValue;
            foreach (var route in routes)
            {
                int dist = 0;
                for(int i = 0; i < route.Count - 1; i++)
                {
                    dist += cities[route[i]][route[i + 1]];
                }
                if(dist < minDist)
                    minDist = dist;
            }
            return minDist;
        }

        internal static IEnumerable<IList<string>> Routes(IList<string> cities)
        {
            List<IList<string>> routes = new List<IList<string>>();
            foreach (var c in cities)
            {
                routes.AddRange(Routes(c, cities));
            }
            return routes;
        }

        internal static IEnumerable<IList<string>> Routes(string start, IList<string> cities)
        {
            var cloned = new List<string>(cities);
            cloned.Remove(start);

            if (cloned.Count > 0)
            {
                foreach (var c in cloned)
                {
                    var childRoutes = Routes(c, cloned);
                    foreach (var route in childRoutes)
                    {
                        yield return route.Prepend(start).ToList();
                    }
                }
            }
            else
            {
                yield return new List<string> { start };
            }
        }

        internal static CityGraph GetCities(string filename)
        {
            var cities = new Dictionary<string, Dictionary<string, int>>();
            string[] lines = filename.ReadAllLines();
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                var start = parts[0];
                var end = parts[2];
                var dist = parts[4].ToInt();

                if (!cities.ContainsKey(start))
                    cities.Add(start, new Dictionary<string, int>());

                var city = cities[start];
                city.Add(end, dist);

                if (!cities.ContainsKey(end))
                    cities.Add(end, new Dictionary<string, int>());

                city = cities[end];
                city.Add(start, dist);
            }

            return cities;
        }

        public static int PartTwo(string filename)
        {
            var cities = GetCities(filename);
            var routes = Day09.Routes(cities.Keys.ToList());

            int maxDist = int.MinValue;
            foreach (var route in routes)
            {
                int dist = 0;
                for (int i = 0; i < route.Count - 1; i++)
                {
                    dist += cities[route[i]][route[i + 1]];
                }
                if (dist > maxDist)
                    maxDist = dist;
            }
            return maxDist;
        }
    }
}
