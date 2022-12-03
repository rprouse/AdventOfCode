using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2022;

public static class Day03
{
    public static int PartOne(string filename) =>
        filename.ReadAllLines()
            .Select(line => line.Common().Priority())
            .Sum();

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int sum = 0;
        for (int i = 0; i < lines.Length; i += 3)
        {
            foreach (char c in lines[i])
            {
                if (lines[i + 1].Any(d => d == c) &&
                    lines[i + 2].Any(d => d == c))
                {
                    sum += c.Priority();
                    break;
                }
            }
        }
        return sum;
    }

    internal static int Priority(this char c) =>
        c < 'a' ? c - 'A' + 27 : c - 'a' + 1;

    internal static char Common(this string line)
    {
        int len = line.Length;
        char[] a = line.Substring(0, len / 2).ToCharArray();
        char[] b = line.Substring(len / 2).ToCharArray();
        foreach (char c in a)
        {
            if (b.Any(d => d == c))
                return c;
        }
        return '\0';
    }
}
