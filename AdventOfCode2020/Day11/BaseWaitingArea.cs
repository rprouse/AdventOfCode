using System.Text;
using System.Linq;

namespace AdventOfCode2020
{
    public abstract class BaseWaitingArea
    {
        protected int _w;
        protected int _h;
        protected char[,] _board;
        protected char[,] _newBoard;

        public BaseWaitingArea(string[] lines)
        {
            _w = lines[0].Length;
            _h = lines.Length;
            _board = new char[lines[0].Length, lines.Length];
            _newBoard = new char[lines[0].Length, lines.Length];
            for (int y = 0; y < _h; y++)
            {
                for (int x = 0; x < _w; x++)
                {
                    _board[x, y] = lines[y][x];
                    _newBoard[x, y] = lines[y][x];
                }
            }
        }

        public void RunToStability()
        {
            do
            {
                CopyBoards();
                UpdateBoard();
            } while (BoardsAreChanged());
        }

        public int OccupiedSeats()
        {
            int c = 0;
            for (int y = 0; y < _h; y++)
            {
                for (int x = 0; x < _w; x++)
                {
                    if (_board[x, y] == '#') c++;
                }
            }
            return c;
        }

        internal abstract void UpdateBoard();

        internal void CopyBoards()
        {
            for (int y = 0; y < _h; y++)
            {
                for (int x = 0; x < _w; x++)
                {
                    _board[x, y] = _newBoard[x, y];
                }
            }
        }

        internal bool BoardsAreChanged()
        {
            for (int y = 0; y < _h; y++)
            {
                for (int x = 0; x < _w; x++)
                {
                    if (_board[x, y] != _newBoard[x, y])
                        return true;
                }
            }
            return false;
        }

        public string View
        {
            get
            {
                var builder = new StringBuilder();

                for (int y = 0; y < _h; y++)
                {
                    for (int x = 0; x < _w; x++)
                    {
                        builder.Append(_board[x, y]);
                    }
                    builder.Append("  ");
                    for (int x = 0; x < _w; x++)
                    {
                        builder.Append(_newBoard[x, y]);
                    }
                    builder.AppendLine();
                }
                return builder.ToString();
            }
        }

        public override string ToString() => View;
    }
}
