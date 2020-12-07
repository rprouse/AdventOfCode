using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day03
    {
        public static int PartOne(string filename, int right, int down) =>
            CountTreesOnSlope(right, down, filename.ReadAllLines());

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return CountTreesOnSlope(1, 1, lines) *
                   CountTreesOnSlope(3, 1, lines) *
                   CountTreesOnSlope(5, 1, lines) *
                   CountTreesOnSlope(7, 1, lines) *
                   CountTreesOnSlope(1, 2, lines);
        }

        private static int CountTreesOnSlope(int right, int down, string[] lines)
        {
            int trees = 0;
            for (int x = right, y = down; y < lines.Length; x += right, y += down)
            {
                if (lines[y][x % lines[0].Length] == '#')
                    trees++;
            }
            return trees;
        }
    }
}
