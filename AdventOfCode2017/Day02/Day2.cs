using System.Linq;

namespace AdventOfCode2017
{
    public static class Day2
    {
        public static int Checksum(int[][] spreadsheet) =>
            spreadsheet.Sum(row => row.Max() - row.Min());

        public static int Divisors(int[][] spreadsheet) =>
            spreadsheet.Sum(row => row.DivideDivisors());

        static int DivideDivisors(this int[] row)
        {
            var sorted = row.OrderByDescending(i => i).ToArray(); ;
            for(int i = 0; i < sorted.Length - 1; i++)
            {
                for(int j = i + 1; j < sorted.Length; j++)
                {
                    if (sorted[i] % sorted[j] == 0)
                        return sorted[i] / sorted[j];
                }
            }
            return 0;
        }
    }
}
