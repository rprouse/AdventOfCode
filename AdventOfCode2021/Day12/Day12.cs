using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

using Node = System.Collections.Generic.List<string>;
using Map = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>;

namespace AdventOfCode2021;

public static class Day12
{
    public static int PartOne(string filename)
    {
        Map map = GetMap(filename);
        var routes = GetRoutes(map);
        return routes.Count();
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }

    private static Map GetMap(string filename)
    {
        string[] lines = filename.ReadAllLines();
        Map map = new Map();
        foreach (string line in lines)
        {
            var parts = line.Split('-');
            var a = parts[0];
            var b = parts[1];

            if (a != "end")
            {
                if (!map.ContainsKey(a))
                    map.Add(a, new Node());
                map[a].Add(b);
            }

            if (b != "end")
            {
                if (!map.ContainsKey(b))
                    map.Add(b, new List<string>());
                map[b].Add(a);
            }
        }
        return map;
    }

    private static IEnumerable<Node> GetRoutes(Map map)
    {
        var routes = new List<Node>();
        var visited = new Node() { "start" };
        foreach (string next in map["start"])
        {
            var childRoutes = GetChildRoutes(map, visited, next);
            routes.AddRange(childRoutes);
        }
        return routes;
    }

    private static IEnumerable<Node> GetChildRoutes(Map map, Node visited, string next)
    {
        visited = new Node(visited);
        visited.Add(next);
        if (next != "end")
        {
            foreach (string nextChild in map[next].Where(n => !visited.Contains(n) || n.ToUpper() == n))
            {
                foreach (var childRoute in GetChildRoutes(map, visited, nextChild))
                    yield return childRoute;
            }
        }
        else
        {
            yield return visited;
        }
    }
}
