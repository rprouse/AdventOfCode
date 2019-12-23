using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2019
{
    public static class Day20
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            var maze = new PlutoMaze(lines);
            Console.WriteLine(maze.ToString());
            return maze.ShortestDistance();
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }

    public class PlutoMaze
    {
        public class Portal
        {
            public Point Port1 { get; set; }
            public Point Port2 { get; set; }
        }

        public class Vertex : IEquatable<Vertex>
        {
            public string Start { get; set; }
            public string End { get; set; }
            public int Cost { get; set; }

            public override bool Equals(object obj) =>
                Equals(obj as Vertex);

            public bool Equals([AllowNull] Vertex other) =>
                other != null &&
                Start == other.Start &&
                End == other.End;

            public override int GetHashCode() => HashCode.Combine(Start, End);
        }

        char[,] _maze;
        Dictionary<string, Portal> _nodes = new Dictionary<string, Portal>();
        Point _start;
        Point _end;
        List<Vertex> _graph = new List<Vertex>();
        int[] _xEdges = new int[4];
        int[] _yEdges = new int[4];

        public PlutoMaze(string[] maze)
        {
            LoadMaze(maze);
            FindEdgesOfDonut();
            FindNodes();
            BuildGraph();
        }

        public int ShortestDistance()
        {
            return 0;
        }

        private void LoadMaze(string[] maze)
        {
            _maze = new char[maze[0].Length, maze.Length];
            for (int y = 0; y < maze.Length; y++)
            {
                for (int x = 0; x < maze[y].Length; x++)
                {
                    _maze[x, y] = maze[y][x];
                }
            }
        }

        private void FindEdgesOfDonut()
        {
            _xEdges[0] = 2;
            _xEdges[3] = _maze.GetLength(0) - 3;
            _yEdges[0] = 2;
            _yEdges[3] = _maze.GetLength(1) - 3;

            int centerX = _maze.GetLength(0) / 2;
            int centerY = _maze.GetLength(1) / 2;
            for (int x = _xEdges[0]; x < centerX; x++)
            {
                if (_maze[x, centerY] != '#' && _maze[x, centerY] != '.')
                {
                    _xEdges[1] = x - 1;
                    break;
                }
            }
            for (int x = _xEdges[3]; x > centerX; x--)
            {
                if (_maze[x, centerY] != '#' && _maze[x, centerY] != '.')
                {
                    _xEdges[2] = x + 1;
                    break;
                }
            }
            for (int y = _yEdges[0]; y < centerY; y++)
            {
                if (_maze[centerX, y] != '#' && _maze[centerX, y] != '.')
                {
                    _yEdges[1] = y - 1;
                    break;
                }
            }
            for (int y = _yEdges[3]; y > centerY; y--)
            {
                if (_maze[centerX, y] != '#' && _maze[centerX, y] != '.')
                {
                    _yEdges[2] = y + 1;
                    break;
                }
            }
        }

        private void FindNodes()
        {
            // Horizontal edges
            for(int x = _xEdges[0] + 1; x < _xEdges[3]; x++)
            {
                // Top
                if(_maze[x, _yEdges[0]] == '.')
                {
                    string name = $"{_maze[x,_yEdges[0]-2]}{_maze[x, _yEdges[0]-1]}";
                    AddNode(name, x, _yEdges[0]);
                }

                if(x > _xEdges[1] && x < _xEdges[2])
                {
                    // Top middle
                    if (_maze[x, _yEdges[1]] == '.')
                    {
                        string name = $"{_maze[x, _yEdges[1] + 1]}{_maze[x, _yEdges[1] + 2]}";
                        AddNode(name, x, _yEdges[1]);
                    }

                    // Bottom middle
                    if (_maze[x, _yEdges[2]] == '.')
                    {
                        string name = $"{_maze[x, _yEdges[2] - 2]}{_maze[x, _yEdges[2] - 1]}";
                        AddNode(name, x, _yEdges[2]);
                    }
                }

                // Bottom
                if (_maze[x, _yEdges[3]] == '.')
                {
                    string name = $"{_maze[x, _yEdges[3] + 1]}{_maze[x, _yEdges[3] + 2]}";
                    AddNode(name, x, _yEdges[3]);
                }
            }

            // Vertical edges
            for (int y = _yEdges[0] + 1; y < _yEdges[3]; y++)
            {
                // Top
                if (_maze[_xEdges[0], y] == '.')
                {
                    string name = $"{_maze[_xEdges[0] - 2, y]}{_maze[_xEdges[0] - 1, y]}";
                    AddNode(name, _xEdges[0], y);
                }

                if (y > _yEdges[1] && y < _yEdges[2])
                {
                    // Top middle
                    if (_maze[_xEdges[1], y] == '.')
                    {
                        string name = $"{_maze[_xEdges[1] + 1, y]}{_maze[_xEdges[1] + 2, y]}";
                        AddNode(name, _xEdges[1], y);
                    }

                    // Bottom middle
                    if (_maze[_xEdges[2], y] == '.')
                    {
                        string name = $"{_maze[_xEdges[2] - 2, y]}{_maze[_xEdges[2] - 1, y]}";
                        AddNode(name, _xEdges[2], y);
                    }
                }

                // Bottom
                if (_maze[_xEdges[3], y] == '.')
                {
                    string name = $"{_maze[_xEdges[3] + 1, y]}{_maze[_xEdges[3] + 2, y]}";
                    AddNode(name, _xEdges[3], y);
                }
            }
        }

        private void AddNode(string node, int x, int y)
        {
            var point = new Point(x, y);
            if (node == "AA")
                _start = point;
            else if (node == "ZZ")
                _end = point;
            else if (_nodes.ContainsKey(node))
                _nodes[node].Port2 = point;
            else
                _nodes[node] = new Portal { Port1 = point };
        }

        private void BuildGraph()
        {

        }

        private void FindVertexesFrom(string node)
        {

        }

        public override string ToString()
        {
            var sb = new StringBuilder(_maze.Length);
            for (int y = 0; y < _maze.GetLength(1); y++)
            {
                for (int x = 0; x < _maze.GetLength(0); x++)
                {
                    sb.Append(_maze[x, y]);
                }
                sb.AppendLine();
            }
            sb.AppendLine();
            sb.AppendLine($"X Edges: {_xEdges[0]}, {_xEdges[1]}, {_xEdges[2]}, {_xEdges[3]}");
            sb.AppendLine($"Y Edges: {_yEdges[0]}, {_yEdges[1]}, {_yEdges[2]}, {_yEdges[3]}");
            sb.AppendLine();
            sb.AppendLine($"AA: {_start.X},{_start.Y}");
            sb.AppendLine($"ZZ: {_end.X},{_end.Y}");
            foreach(var pair in _nodes)
                sb.AppendLine($"{pair.Key}: {pair.Value.Port1.X},{pair.Value.Port1.Y} => {pair.Value.Port2.X},{pair.Value.Port2.Y}");

            return sb.ToString();
        }
    }
}
