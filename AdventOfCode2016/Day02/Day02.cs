using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public static class Day02
    {
        public static string PartOne(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var sb = new StringBuilder(lines.Length);
            int key = 5;

            foreach (string line in lines)
            {
                foreach(char m in line)
                {
                    key = Move(m, key);
                }
                sb.Append(key.ToString());
            }
            return sb.ToString();
        }

        public static int PartTwo(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return 0;
        }

        static int Move(char m, int key)
        {
            switch(m)
            {
                case 'U':
                    if (key > 3)
                        key -= 3;
                    break;
                case 'D':
                    if (key < 7)
                        key += 3;
                    break;
                case 'R':
                    if (key % 3 != 0)
                        key++;
                    break;
                case 'L':
                    if (key % 3 != 1)
                        key--;
                    break;
            }
            return key;
        }
    }
}
