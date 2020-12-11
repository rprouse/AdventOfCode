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
            {
                if (_board[x1, y1] == 'L')
                    break;

                if (_board[x1, y1] == '#')
                {
                    c++;
                    break;
                }
            }

            // Up
            for (int y1 = y - 1; y1 >= 0; y1--)
            {
                if (_board[x, y1] == 'L')
                    break;

                if (_board[x, y1] == '#')
                {
                    c++;
                    break;
                }
            }

            // Up Right
            for (int x1 = x + 1, y1 = y - 1; x1 < _w && y1 >= 0; x1++, y1--)
            {
                if (_board[x1, y1] == 'L')
                    break;

                if (_board[x1, y1] == '#')
                {
                    c++;
                    break;
                }
            }

            // Left
            for (int x1 = x - 1; x1 >= 0; x1--)
            {
                if (_board[x1, y] == 'L')
                    break;

                if (_board[x1, y] == '#')
                {
                    c++;
                    break;
                }
            }

            // Right
            for (int x1 = x + 1; x1 < _w; x1++)
            {
                if (_board[x1, y] == 'L')
                    break;

                if (_board[x1, y] == '#')
                {
                    c++;
                    break;
                }
            }

            // Down Left
            for (int x1 = x - 1, y1 = y + 1; x1 >= 0 && y1 < _h; x1--, y1++)
            {
                if (_board[x1, y1] == 'L')
                    break;

                if (_board[x1, y1] == '#')
                {
                    c++;
                    break;
                }
            }

            // Down
            for (int y1 = y + 1; y1 < _h; y1++)
            {
                if (_board[x, y1] == 'L')
                    break;

                if (_board[x, y1] == '#')
                {
                    c++;
                    break;
                }
            }

            // Down Right
            for (int x1 = x + 1, y1 = y + 1; x1 < _w && y1 < _h; x1++, y1++)
            {
                if (_board[x1, y1] == 'L')
                    break;

                if (_board[x1, y1] == '#')
                {
                    c++;
                    break;
                }
            }

            return c;
        }
    }
}
