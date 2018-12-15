using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day14
    {
        public static string PartOne(int recipes)
        {
            int e1 = 0;
            int e2 = 1;
            var board = new List<int>() { 3, 7 };
            while(board.Count < recipes + 10)
            {
                int sum = board[e1] + board[e2];
                if(sum >= 10)
                {
                    board.Add(1);
                    sum -= 10;
                }
                board.Add(sum);
                e1 = (e1 + 1 + board[e1]) % board.Count;
                e2 = (e2 + 1 + board[e2]) % board.Count;
            }
            return new string(board.Skip(recipes).Take(10).Select(i => (char)('0' + i)).ToArray());
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
