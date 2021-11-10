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
            return 0;
        }
    }
}
