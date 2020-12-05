using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
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
                .OrderBy(i => i)
                .ToList();

            for(int id = 1; id < 828; id++)
            {
                if (!seats.Contains(id) && seats.Contains(id - 1) && seats.Contains(id + 1))
                    return id;
            }
            return 0;
        }

        static internal int GetSeatId(string pass)
        {
            var seat = GetSeat(pass);
            return seat.row * 8 + seat.col;
        }

        static internal (int row, int col) GetSeat(string pass)
        {
            int row = ROWS;
            int low = 0;
            for(int i = 0; i < 7; i++)
            {
                if (pass[i] == 'F')
                    row -= (row - low) / 2 + 1;
                else
                    low += (row - low) / 2 + 1;
            }
            int col = COLS;
            low = 0;
            for (int i = 7; i < 10; i++)
            {
                if (pass[i] == 'L')
                    col -= (col - low) / 2 + 1;
                else
                    low += (col - low) / 2 + 1;
            }
            return (row, col);
        }
    }
}
