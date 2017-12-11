using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public static class LineReader
    {
        public static IEnumerable<string> ReadLines(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                string line = reader.ReadLine();
                while (!string.IsNullOrWhiteSpace(line))
                {
                    yield return line;
                    line = reader.ReadLine();
                }
            }
        }

        public static string ReadLine(string filename) =>
            ReadLines(filename).First();

        public static int[] SplitInts(string filename) =>
            SplitStrings(filename)
            .Select(s => {
                int.TryParse(s, out int x);
                return x;
            }).ToArray();

        public static string[] SplitStrings(string filename) =>
            ReadLine(filename)
            .Split(',');
    }
}
