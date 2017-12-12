using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day12
    {
        public static int PartOne(IEnumerable<string> lines)
        {
            var programs = lines.Where(s => !string.IsNullOrWhiteSpace(s))
                            .Select(s => new Day12Program(s));

            var dict = new Dictionary<int, Day12Program>();
            foreach (var program in programs)
                dict.Add(program.Id, program);

            bool[] connected = new bool[dict.Count];
            for (int i = 0; i < dict.Count; i++)
                connected[i] = false;

            var root = dict[0];
            FindConnected(dict, connected, root);

            return connected.Count(c => c);
        }

        private static void FindConnected(Dictionary<int, Day12Program> dict, bool[] connected, Day12Program root)
        {
            var children = root.Connected.ToArray();
            root.Connected.Clear();
            foreach (var id in children)
            {
                connected[id] = true;
                var child = dict[id];
                FindConnected(dict, connected, child);
            }
        }

        public static int PartTwo(IEnumerable<string> lines)
        {
            var programs = lines.Where(s => !string.IsNullOrWhiteSpace(s))
                            .Select(s => new Day12Program(s));

            var dict = new Dictionary<int, Day12Program>();
            foreach (var program in programs)
                dict.Add(program.Id, program);

            int count = 0;

            while (dict.Count > 0)
            {
                count++;
                var root = dict[dict.Keys.First()];
                CountConnected(dict, root);
            }

            return count;
        }

        private static void CountConnected(Dictionary<int, Day12Program> dict, Day12Program root)
        {
            var children = root.Connected.ToArray();
            dict.Remove(root.Id);
            foreach (var id in children.Where(id => dict.ContainsKey(id)))
            {
                var child = dict[id];
                CountConnected(dict, child);
            }
        }
    }

    public class Day12Program
    {
        public int Id { get; }
        public IList<int> Connected { get; } = new List<int>();

        public Day12Program(string line)
        {
            var split = line.Split(" <-> ");
            if (int.TryParse(split[0], out int id))
                Id = id;

            var split2 = split[1].Split(", ");
            foreach(string con in split2)
            {
                if (int.TryParse(con, out int i))
                    Connected.Add(i);
            }
        }
    }
}
