using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public class WaitingAreaTwo : BaseWaitingArea
    {
        public WaitingAreaTwo(string filename) : base(filename.ReadAllLines())
        {
        }

        internal override void UpdateBoard()
        {
            for (int y = 0; y < _h; y++)
            {
                for (int x = 0; x < _w; x++)
                {
                    if (_board[x, y] == '.')
                        continue;
                    if (_board[x, y] == 'L')
                        _newBoard[x, y] = VisibleSeats(x, y) == 0 ? '#' : 'L';
                    else
                        _newBoard[x, y] = VisibleSeats(x, y) >= 5 ? 'L' : '#';
                }
            }
        }

        internal int VisibleSeats(int x, int y)
        {
            int c = 0;

            // Up Left
            for (int x1 = x - 1, y1 = y - 1; x1 >= 0 && y1 >= 0; x1--, y1--)
                if (FindOccupied(ref c, x1, y1)) break;

            // Up
            for (int y1 = y - 1; y1 >= 0; y1--)
                if (FindOccupied(ref c, x, y1)) break;

            // Up Right
            for (int x1 = x + 1, y1 = y - 1; x1 < _w && y1 >= 0; x1++, y1--)
                if (FindOccupied(ref c, x1, y1)) break;

            // Left
            for (int x1 = x - 1; x1 >= 0; x1--)
                if (FindOccupied(ref c, x1, y)) break;

            // Right
            for (int x1 = x + 1; x1 < _w; x1++)
                if (FindOccupied(ref c, x1, y)) break;

            // Down Left
            for (int x1 = x - 1, y1 = y + 1; x1 >= 0 && y1 < _h; x1--, y1++)
                if (FindOccupied(ref c, x1, y1)) break;

            // Down
            for (int y1 = y + 1; y1 < _h; y1++)
                if (FindOccupied(ref c, x, y1)) break;

            // Down Right
            for (int x1 = x + 1, y1 = y + 1; x1 < _w && y1 < _h; x1++, y1++)
                if (FindOccupied(ref c, x1, y1)) break;

            return c;
        }

        bool FindOccupied(ref int c, int x, int y)
        {
            if (_board[x, y] == 'L')
                return true;

            if (_board[x, y] == '#')
            {
                c++;
                return true;
            }
            return false;
        }
    }
}
