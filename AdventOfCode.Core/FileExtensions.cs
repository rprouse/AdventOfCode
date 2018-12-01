using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Core
{
    public static class FileExtensions
    {
        public static int[] SplitInts(this string filename) =>
            SplitStrings(filename)
                .Select(s => {
                    int.TryParse(s, out int x);
                    return x;
                }).ToArray();

        public static string[] SplitStrings(this string filename) =>
            filename.ReadFirstLine()
                .Split(',');

        public static string ReadFirstLine(this string filename) =>
            File.ReadLines(filename)
                .First()
                .Trim();

        public static string[] ReadAllLines(this string filename) =>
            File.ReadAllLines(filename)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();

        public static string ReadAll(this string filename) =>
            File.ReadAllText(filename);
    }
}
