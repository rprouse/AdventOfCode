using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day11
    {
        public static int PartOne(string filename)
        {
            var area = new WaitingAreaOne(filename);
            area.RunToStability();
            return area.OccupiedSeats();
        }

        public static int PartTwo(string filename)
        {
            var area = new WaitingAreaTwo(filename);
            area.RunToStability();
            return area.OccupiedSeats();
        }
    }

    public class WaitingAreaOne
    {
        int _w;
        int _h;
        char[,] _board;
        char[,] _newBoard;

        public WaitingAreaOne(string filename) : this(filename.ReadAllLines())
        {
        }

        public WaitingAreaOne(string[] lines)
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

        internal void UpdateBoard()
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

    public class WaitingAreaTwo
    {
        int _w;
        int _h;
        char[,] _board;
        char[,] _newBoard;

        public WaitingAreaTwo(string filename) : this(filename.ReadAllLines())
        {
        }

        public WaitingAreaTwo(string[] lines)
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

        internal void UpdateBoard()
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
            if (x < _w - 1 && y < _h - 1 && _board[x + 1, y + 1] == '#') c++;

            return c;
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
