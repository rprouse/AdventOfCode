using System.Linq;

namespace AdventOfCode2017
{
    public static class Day2
    {
        public static int Checksum(int[][] spreadsheet) =>
            spreadsheet.Sum(row => row.Max() - row.Min());
    }
}
