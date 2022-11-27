using System.Text;

namespace AdventOfCode.Core;

public class ConwaysGameOfLife
{
    protected bool[,] _board;

    public ConwaysGameOfLife(string filename, char onChar = '#')
    {
        _board = ReadBoard(filename, onChar);
    }

    /// <summary>
    /// Steps one round of life
    /// </summary>
    /// <returns>The next board state</returns>
    public void Step()
    {
        var next = new bool[_board.GetLength(0), _board.GetLength(1)];
        for (int y = 0; y < _board.GetLength(1); y++)
        {
            for (int x = 0; x < _board.GetLength(0); x++)
            {
                next[x, y] = IsAlive(x, y);
            }
        }
        _board = next;
    }

    public virtual bool IsAlive(int x, int y)
    {
        int neighbors = Neighbors(x, y);
        // A cell which is alive stays alive when 2 or 3 neighbors are alive, and dies otherwise.
        if (_board[x, y])
        {
            return neighbors == 2 || neighbors == 3;
        }
        // A cell which is dead becomes alive if exactly 3 neighbors are alive, and stays dead otherwise.
        return neighbors == 3;
    }

    public int CountAlive()
    {
        int count = 0;
        for (int y = 0; y < _board.GetLength(1); y++)
        {
            for (int x = 0; x < _board.GetLength(0); x++)
            {
                if (_board[x, y]) count++;
            }
        }
        return count;
    }

    public int Neighbors(int x, int y)
    {
        int count = 0;
        for (int y1 = y - 1; y1 <= y + 1 && y1 < _board.GetLength(1); y1++)
        {
            for (int x1 = x - 1; x1 <= x + 1 && x1 < _board.GetLength(0); x1++)
            {
                if (x1 >= 0 && y1 >= 0 && (x1 != x || y1 != y) && _board[x1, y1])
                    count++;
            }
        }
        return count;
    }

    static bool[,] ReadBoard(string filename, char onChar = '#')
    {
        string[] lines = filename.ReadAllLines();
        var board = new bool[lines[0].Length, lines.Length];
        for (int y = 0; y < board.GetLength(1); y++)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                board[x, y] = lines[y][x] == onChar;
            }
        }
        return board;
    }

    public override string ToString()
    {
        var builder = new StringBuilder(_board.GetLength(0) * _board.GetLength(1));
        for (int y = 0; y < _board.GetLength(1); y++)
        {
            for (int x = 0; x < _board.GetLength(0); x++)
            {
                builder.Append(_board[x,y] ? '#' : '.' );
            }
            builder.AppendLine();
        }
        return builder.ToString();
    }
}
