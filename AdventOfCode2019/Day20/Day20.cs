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
            public string Name { get; set; }
            public Point Port1 { get; set; }
            public Point Port2 { get; set; }
            public bool Visited { get; set; }
        }

        //public class Vertex : IEquatable<Vertex>
        //{
        //    public string Start { get; set; }
        //    public string End { get; set; }
        //    public int Cost { get; set; }

        //    public override string ToString() =>
        //        $"{Start} => {End} = {Cost}";

        //    public override bool Equals(object obj) =>
        //        Equals(obj as Vertex);

        //    public bool Equals([AllowNull] Vertex other) =>
        //        other != null &&
        //        Start == other.Start &&
        //        End == other.End;

        //    public override int GetHashCode() => HashCode.Combine(Start, End);
        //}

        char[,] _maze;
        Dictionary<string, Portal> _nodes = new Dictionary<string, Portal>();
        //List<Vertex> _graph = new List<Vertex>();
        Graph _graph = new Graph();
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
            return _graph.FindShortestPath("AA");
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
            for (int x = _xEdges[0] + 1; x < _xEdges[3]; x++)
            {
                // Top
                if (_maze[x, _yEdges[0]] == '.')
                {
                    string name = $"{_maze[x, _yEdges[0] - 2]}{_maze[x, _yEdges[0] - 1]}";
                    AddNode(name, x, _yEdges[0]);
                }

                if (x > _xEdges[1] && x < _xEdges[2])
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
            if (_nodes.ContainsKey(node))
                _nodes[node].Port2 = point;
            else
                _nodes[node] = new Portal { Name = node, Port1 = point, Visited = node == "AA" || node == "ZZ" };
        }

        private void BuildGraph()
        {
            FindVertexesFrom(_nodes["AA"], _nodes["AA"].Port1);
            _graph.AddEdge("ZZ");
        }

        private void FindVertexesFrom(Portal portal, Point point)
        {
            if (point.X == 0 && point.Y == 0)
                return;

            portal.Visited = true;

            Stack<Point> walk = new Stack<Point>();
            walk.Push(point);
            char[,] maze = (char[,])_maze.Clone();
            maze[point.X, point.Y] = 'x';

            Point next = new Point(point.X, point.Y);
            while (true)
            {
                if (maze[next.X, next.Y - 1] == '.')
                {
                    next.Offset(0, -1);
                    maze[next.X, next.Y] = 'x';
                    walk.Push(next);
                }
                else if (maze[next.X, next.Y + 1] == '.')
                {
                    next.Offset(0, 1);
                    maze[next.X, next.Y] = 'x';
                    walk.Push(next);
                }
                else if (maze[next.X - 1, next.Y] == '.')
                {
                    next.Offset(-1, 0);
                    maze[next.X, next.Y] = 'x';
                    walk.Push(next);
                }
                else if (maze[next.X + 1, next.Y] == '.')
                {
                    next.Offset(1, 0);
                    maze[next.X, next.Y] = 'x';
                    walk.Push(next);
                }
                else if (walk.Count == 1)
                {
                    break;
                }
                else
                {
                    next = walk.Pop();
                }

                var p = _nodes.Values.Where(p => p.Port1 == next || p.Port2 == next).FirstOrDefault();
                if (p != null)
                {
                    // Add to the graph, recurse then start going deep, but not if ZZ                    _
                    //_graph.Add(new Vertex { Start = portal.Name, End = p.Name, Cost = walk.Count });
                    _graph.AddEdge(portal.Name, p.Name, walk.Count);
                    if (!p.Visited)
                    {
                        FindVertexesFrom(p, p.Port1 == next ? p.Port2 : p.Port1);
                    }
                    next = walk.Pop();
                }
            }
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
            sb.AppendLine($"AA: {_nodes["AA"].Port1.X},{_nodes["AA"].Port1.Y}");
            sb.AppendLine($"ZZ: {_nodes["ZZ"].Port1.X},{_nodes["ZZ"].Port1.Y}");
            foreach (var pair in _nodes)
                sb.AppendLine($"{pair.Key}: {pair.Value.Port1.X},{pair.Value.Port1.Y} => {pair.Value.Port2.X},{pair.Value.Port2.Y}");

            return sb.ToString();
        }
    }
    public struct Distance
    {
        public int Value;
        public string Node;
    }
    public class Graph
    {
        private readonly Dictionary<string, List<Edge>> _adj;

        public Graph()
        {
            _adj = new Dictionary<string, List<Edge>>();
        }

        public void AddEdge(string source)
        {
            _adj[source] = new List<Edge>();
        }

        public void AddEdge(string source, string dest, int weight)
        {
            List<Edge> verticies;
            if (!_adj.TryGetValue(source, out verticies))
            {
                verticies = new List<Edge>();
            }
            verticies.Add(new Edge(dest, weight));
            _adj[source] = verticies;
        }

        public int FindShortestPath(string start)
        {
            var q = new ConcurrentPriorityQueue<string, int>();
            q.Enqueue(start, 0);
            var dist = new Dictionary<string, int>();
            var path = new Dictionary<string, string>();
            var s = new Stack<string>();
            foreach (var n in _adj.Keys)
            {
                dist[n] = int.MaxValue;
            }
            dist[start] = 0;
            while (q.Count() > 0)
            {
                var cur = q.Dequeue();
                foreach (var edge in _adj[cur])
                {
                    var newDist = dist[cur] + edge.Weight;
                    if (newDist < dist[edge.Node])
                    {
                        dist[edge.Node] = newDist;
                        //it's invalid we should check if it's in Queue, if it is, decrease key
                        q.Enqueue(edge.Node, newDist);
                        path[cur] = edge.Node;
                    }
                }
            }
            return dist["ZZ"] - 1;
            //Console.WriteLine("dist=[{0}]", string.Join(",", dist));
            //Console.WriteLine("path=[{0}]", string.Join(",", path));
            //s.Push(start);
            //for (var cur = path[start]; cur != null; cur = path.ContainsKey(cur) ? path[cur] : null)
            //{
            //    s.Push(cur);
            //}
            //return s.ToArray();
        }

        private class Edge
        {
            public readonly string Node;
            public readonly int Weight;

            public Edge(string node, int weight)
            {
                Node = node;
                Weight = weight;
            }
        }
    }
}
