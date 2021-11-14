using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day03
    {
        public static int PartOne(string line)
        {
            int x = 0;
            int y = 0;
            var map = new Dictionary<string, int>();
            map.Add("0,0", 1);
            foreach(char c in line)
            {
                switch (c)
                {
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '>':
                        x++;
                        break;
                    case '<':
                        x--;
                        break;
                    default:
                        break;
                }
                var key = $"{x},{y}";
                if(map.ContainsKey(key))
                    map[key]++;
                else
                    map[key] = 1;
            }

            return map.Count;
        }

        public static int PartTwo(string line)
        {
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            int count = 0;
            var map = new Dictionary<string, int>();
            map.Add("0,0", 2);
            foreach (char c in line)
            {
                switch (c)
                {
                    case '^':
                        if(count % 2 == 0) y1++;
                        else y2++;
                        break;
                    case 'v':
                        if (count % 2 == 0) y1--;                        else y2--;
                        break;
                    case '>':
                        if (count % 2 == 0) x1++;
                        else x2++;
                        break;
                    case '<':
                        if (count % 2 == 0) x1--;
                        else x2--;
                        break;
                    default:
                        break;
                }
                var key = (count % 2 == 0) ? $"{x1},{y1}" : $"{x2},{y2}";
                if (map.ContainsKey(key))
                    map[key]++;
                else
                    map[key] = 1;
                count++;
            }

            return map.Count;
        }
    }
}
