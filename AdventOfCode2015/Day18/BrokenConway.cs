using AdventOfCode.Core;

namespace AdventOfCode2015;

// Conway's game of life except the four corners are always on
public class BrokenConway : ConwaysGameOfLife
{
    public BrokenConway(string filename) : base(filename)
    {
        // Set the four corners which are always on to on
        _board[0, 0] = true;
        _board[_board.GetLength(0) - 1, 0] = true;
        _board[0, _board.GetLength(1) - 1] = true;
        _board[_board.GetLength(0) - 1, _board.GetLength(1) - 1] = true;
    }

    public override bool IsAlive(int x, int y)
    {
        // The four corners always stay alive
        if (x == 0 && y == 0) return true;
        if (x == _board.GetLength(0) - 1 && y == 0) return true;
        if (x == 0 && y == _board.GetLength(1) - 1) return true;
        if (x == _board.GetLength(0) - 1 && y == _board.GetLength(1) - 1) return true;
        return base.IsAlive(x, y);
    }
}
