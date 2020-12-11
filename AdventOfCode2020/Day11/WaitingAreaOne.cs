using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public class WaitingAreaOne : BaseWaitingArea
    {
        public WaitingAreaOne(string filename) : base(filename.ReadAllLines())
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
                        _newBoard[x, y] = AdjecentSeats(x, y) == 0 ? '#' : 'L';
                    else
                        _newBoard[x, y] = AdjecentSeats(x, y) >= 4 ? 'L' : '#';
                }
            }
        }

        internal int AdjecentSeats(int x, int y)
        {
            int c = 0;

            if (x > 0 && y > 0 && _board[x - 1, y - 1] == '#') c++;
            if (y > 0 && _board[x, y - 1] == '#') c++;
            if (x < _w - 1 && y > 0 && _board[x + 1, y - 1] == '#') c++;
            if (x > 0 && _board[x - 1, y] == '#') c++;
            if (x < _w - 1 && _board[x + 1, y] == '#') c++;
            if (x > 0 && y < _h - 1 && _board[x - 1, y + 1] == '#') c++;
            if (y < _h - 1 && _board[x, y + 1] == '#') c++;
            if (x < _w - 1&& y < _h - 1&& _board[x + 1, y + 1] == '#') c++;

            return c;
        }
    }
}
