using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public static class Day09
    {
        static Regex regex = new Regex(@"\((\d+)x(\d+)\)", RegexOptions.Compiled);

        public static string Decompress(string compressed)
        {
            var sb = new StringBuilder();
            var match = regex.Match(compressed);
            while (match.Success)
            {
                // Add any text before the match
                sb.Append(compressed.Substring(0, match.Index));

                // Get the number of characters (c) and the multiplier (n)
                int c = match.GetInt(1);
                int n = match.GetInt(2);

                // Multiply it!
                var str = compressed.Substring(match.Index + match.Length, c);
                for (int i = 0; i < n; i++)
                    sb.Append(str);

                // Take what's left
                compressed = compressed.Substring(match.Index + match.Length + c);
                match = regex.Match(compressed);
            }
            sb.Append(compressed);
            return sb.ToString();
        }

        public static long RecursiveDecompress(string compressed)
        {
            long len = 0;
            var match = regex.Match(compressed);
            while (match.Success)
            {
                // Add any text before the match
                len += match.Index;

                // Get the number of characters (c) and the multiplier (n)
                int c = match.GetInt(1);
                int n = match.GetInt(2);

                // Multiply it!
                var str = compressed.Substring(match.Index + match.Length, c);
                len += RecursiveDecompress(str) * n;

                // Take what's left
                compressed = compressed.Substring(match.Index + match.Length + c);
                match = regex.Match(compressed);
            }
            len += compressed.Length;
            return len;
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
