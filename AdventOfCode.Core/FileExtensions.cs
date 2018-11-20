using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Core
{
    public static class FileExtensions
    {
        public static int[] SplitInts(string filename) =>
            SplitStrings(filename)
            .Select(s => {
                int.TryParse(s, out int x);
                return x;
            }).ToArray();

        public static string[] SplitStrings(string filename) =>
            File.ReadLines(filename)
            .First()
            .Trim()
            .Split(',');
    }
}
