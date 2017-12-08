using System.Collections.Generic;
using System.IO;

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
    }
}
