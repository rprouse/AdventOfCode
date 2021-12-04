using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day04
{
    public static int PartOne(string filename) =>
        PlayBingo(filename, false);

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLinesIncludingBlank();
        return 0;
    }

    static int PlayBingo(string filename, bool includeDiagonals)
    { 
        // Parse out the moves and boards
        int[] moves = filename.SplitInts();
        string[] lines = filename.ReadAllLinesIncludingBlank();
        List<int[][]> boards = new List<int[][]>();
        for (int i = 2; i < lines.Length; i += 6)
        {
            boards.Add(GetBoard(lines.Skip(i).Take(5).ToArray()));
        }

        // Start playing the game
        foreach (var move in moves)
        {
            Play(move, boards);
            int[][] winningBoard = CheckWins(boards, includeDiagonals);
            if(winningBoard != null)
            {
                return SumBoard(winningBoard) * move;
            }
        }
        return 0;
    }

    static int[][] GetBoard(string[] lines)
    {
        int[][] board = new int[5][];
        for (int y = 0; y < lines.Length; y++)
        {
            board[y] = lines[y].Split(' ')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.ToInt())
                .ToArray();
        }
        return board;
    }

    static void Play(int move, IEnumerable<int[][]> boards) =>
        boards.ForEach(board => Play(move, board));

    static void Play(int move, int[][] board)
    {
        for (int y = 0; y < board.Length; y++)
        {
            for (int x = 0; x < board[y].Length; x++)
            {
                if (board[y][x] == move)
                {
                    board[y][x] = -1;
                    return;
                }
            }
        }
    }

    static int[][] CheckWins(IEnumerable<int[][]> boards, bool includeDiagonals)
    {
        foreach (int[][] board in boards)
        {
            if (CheckWin(board, includeDiagonals))
                return board;
        }
        return null;
    }

    static bool CheckWin(int[][] board, bool includeDiagonals)
    {
        // Horizontal
        foreach (int[] row in board)
        {
            if (row.All(c => c < 0))
                return true;
        }

        // Vertical
        for (int x = 0; x < board.Length; x++)
        {
            if (board.Select(r => r[x]).All(c => c < 0))
                return true;
        }

        // Diagonal 1
        if (includeDiagonals && Enumerable.Range(0, 5).All(i => board[i][i] < 0))
            return true;

        // Diagonal 2
        if (includeDiagonals && Enumerable.Range(0, 5).All(i => board[i][4-i] < 0))
            return true;

        return false;
    }

    static int SumBoard(int[][] board) =>
        board.Sum(r => r.Where(c => c >= 0).Sum());
}
