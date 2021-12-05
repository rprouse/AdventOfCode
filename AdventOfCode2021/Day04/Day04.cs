using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2021;

public static class Day04
{
    public static int PartOne(string filename)
    {
        // Parse out the moves and boards
        int[] moves = filename.SplitInts();
        var boards = ParseBoards(filename);

        // Start playing the game
        foreach (var move in moves)
        {
            Play(move, boards);
            var winningBoards = CheckAllWins(boards);
            if (winningBoards.Count > 0)
            {
                return SumBoard(winningBoards[0]) * move;
            }
        }
        return 0;
    }

    public static int PartTwo(string filename)
    {
        // Parse out the moves and boards
        int[] moves = filename.SplitInts();

        // Play through all boards
        var boards = ParseBoards(filename);
        int lastWinningMove = -1;
        int[][] lastWinningBoard = null;
        foreach (var move in moves)
        {
            Play(move, boards);
            var winningBoards = CheckAllWins(boards);
            foreach (var winningBoard in winningBoards)
            {
                lastWinningMove = move;
                lastWinningBoard = winningBoard;
                boards.Remove(winningBoard);
            }
        }
        return SumBoard(lastWinningBoard) * lastWinningMove;
    }

    private static List<int[][]> ParseBoards(string filename)
    {
        string[] lines = filename.ReadAllLinesIncludingBlank();
        List<int[][]> boards = new List<int[][]>();
        for (int i = 2; i < lines.Length; i += 6)
        {
            boards.Add(GetBoard(lines.Skip(i).Take(5).ToArray()));
        }

        return boards;
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

    static IList<int[][]> CheckAllWins(IEnumerable<int[][]> boards) =>
        boards.Where(b => CheckWin(b)).ToList();

    static bool CheckWin(int[][] board)
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

        return false;
    }

    static int SumBoard(int[][] board) =>
        board.Sum(r => r.Where(c => c >= 0).Sum());
}
