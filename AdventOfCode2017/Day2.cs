using System.Linq;

namespace AdventOfCode2017
{
    public static class Day2
    {
        public static int Checksum(int[][] spreadsheet)
        {
            int sum = 0;
            foreach(var row in spreadsheet)
            {
                sum += row.Max() - row.Min();
            }
            return sum;
        }
    }
}
