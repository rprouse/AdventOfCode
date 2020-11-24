using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Drawing;

namespace AdventOfCode2019
{
    public static class Day18
    {
        public static int PartOne(string filename)
        {
            string[] maze = filename.ReadAllLines();
            var vault = new UndergroundVault(maze);
            Console.WriteLine(vault.ToString());
            return 0;
        }

        public static int PartTwo(string filename)
        {
            string[] maze = filename.ReadAllLines();
            return 0;
        }
    }

    public class UndergroundVault
    {
        char[,] _vault;
        Point _player;
        Dictionary<char, Point> _keys = new Dictionary<char, Point>();
        Dictionary<char, Point> _doors = new Dictionary<char, Point>();
        Stack<Point> _walk = new Stack<Point>();
        List<Stack<Point>> _options = new List<Stack<Point>>();
        
        public UndergroundVault(string[] maze)
        {
            LoadMaze(maze);
            FindObjects();
        }

        private void LoadMaze(string[] maze)
        {
            _vault = new char[maze[0].Length, maze.Length];
            for (int y = 0; y < maze.Length; y++)
            {
                for (int x = 0; x < maze[y].Length; x++)
                {
                    _vault[x, y] = maze[y][x];
                }
            }
        }

        private void FindObjects()
        {
            for (int y = 0; y < _vault.GetLength(1); y++)
            {
                for (int x = 0; x < _vault.GetLength(0); x++)
                {
                    char c = _vault[x, y];
                    if(c == '@')
                    {
                        _player = new Point(x, y);
                        _vault[x, y] = '.';
                        return;
                    }
                    else if(c >= 'A' && c <= 'Z')
                    {
                        _doors[c] = new Point(x, y);
                    }
                    else if (c >= 'a' && c <= 'z')
                    {
                        _keys[c] = new Point(x, y);
                    }
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(_vault.Length);
            for (int y = 0; y < _vault.GetLength(1); y++)
            {
                for (int x = 0; x < _vault.GetLength(0); x++)
                {
                    if (x == _player.X && y == _player.Y)
                        sb.Append('@');
                    else
                        sb.Append(_vault[x, y]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
