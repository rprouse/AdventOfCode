using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day05
    {
        const int ROWS = 127;
        const int COLS = 7;

        public static int PartOne(string filename) =>
            filename.ReadAllLines()
                    .Select(l => GetSeatId(l))
                    .Max();

        public static int PartTwo(string filename)
        {
            var seats = filename
                .ReadAllLines()
                .Select(l => GetSeatId(l))
                .ToList();

            return Enumerable.Range(1, 1022)
                .First(id => !seats.Contains(id) && seats.Contains(id - 1) && seats.Contains(id + 1));
        }

        static internal int GetSeatId(string pass)
        {
            var seat = GetSeat(pass);
            return seat.row * 8 + seat.col;
        }

        static internal (int row, int col) GetSeat(string pass) =>
            (RunBisection(pass, ROWS, 0, 7, 'B'), RunBisection(pass, COLS, 7, 10, 'R'));

        static internal int RunBisection(string pass, int max, int startI, int endI, char highChar)
        {
            int min = 0;
            for (int i = startI; i < endI; i++)
                (min, max) = Bisect(pass[i] == highChar, min, max);
            return max;
        }

        static internal (int min, int max) Bisect(bool high, int min, int max) =>
            high ? (min + (max - min) / 2 + 1, max) :
                   (min, max - ((max - min) / 2) - 1);
    }
}
