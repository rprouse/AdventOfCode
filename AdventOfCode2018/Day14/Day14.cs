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
            while (board.Count < recipes + 10)
            {
                int sum = board[e1] + board[e2];
                if (sum >= 10)
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

        public static int PartTwo(int score)
        {
            int e1 = 0;
            int e2 = 1;
            var board = new List<int>() { 3, 7 };
            while (true)
            {
                int sum = board[e1] + board[e2];
                if (sum >= 10)
                {
                    board.Add(1);
                    if (board.Count >= 7 && board[board.Count-1] % 10 == 1 && EndMatches(board, score)) return board.Count - 6;

                    sum -= 10;

                    board.Add(sum);
                    if (board.Count >= 7 && EndMatches(board, score)) return board.Count - 6;
                }
                else
                {
                    board.Add(sum);
                    if (board.Count >= 7 && EndMatches(board, score)) return board.Count - 6;
                }

                e1 = (e1 + 1 + board[e1]) % board.Count;
                e2 = (e2 + 1 + board[e2]) % board.Count;
            }
        }

        public static bool EndMatches(List<int> board, int score) =>
            Enumerable.Range(1, 6)
                .All(i => board[board.Count - 7 + i] == GetDigit(i, score));

        public static int GetDigit(int d, int i)
        {
            d = 6 - d;
            while(d-- > 0)
            {
                i /= 10;
            }
            return i % 10;
        }
    }
}
