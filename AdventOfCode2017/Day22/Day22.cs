using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017
{
    public static class Day22
    {
        public static int PartOne(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var virus = new Virus(lines);
            return virus.Run(10000);
        }

        public static int PartTwo(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return 0;
        }

        public class Virus
        {
            internal Dictionary<string, bool> _nodes = new Dictionary<string, bool>();
            int _x = 0;
            int _y = 0;
            internal Direction _dir = Direction.Up;

            public Virus(string[] lines)
            {
                int mid = lines.Length / 2;
                int y = 1;
                foreach(var line in lines)
                {
                    for (int x = 0; x < line.Length; x++)
                        _nodes[Position(x - mid, y)] = line[x] == '#';
                    y--;
                }
            }

            public int Run(int iterations)
            {
                int count = 0;
                foreach(int i in Enumerable.Range(0, iterations))
                {
                    if (Burst()) count++;
                }
                return count;
            }

            public bool Burst()
            {
                Turn();
                bool infected = Infect();
                Move();
                return infected;
            }

            public void Turn()
            {
                if(_nodes[Position()]) 
                {
                    TurnRight();
                }
                else
                {
                    TurnLeft();
                }
            }

            void TurnRight()
            {
                switch(_dir)
                {
                    case Direction.Up:
                        _dir = Direction.Right;
                        break;
                    case Direction.Right:
                        _dir = Direction.Down;
                        break;
                    case Direction.Down:
                        _dir = Direction.Left;
                        break;
                    case Direction.Left:
                        _dir = Direction.Up;
                        break;
                }
            }

            void TurnLeft()
            {
                switch (_dir)
                {
                    case Direction.Up:
                        _dir = Direction.Left;
                        break;
                    case Direction.Right:
                        _dir = Direction.Up;
                        break;
                    case Direction.Down:
                        _dir = Direction.Right;
                        break;
                    case Direction.Left:
                        _dir = Direction.Down;
                        break;
                }
            }

            public bool Infect()
            {
                bool infected = !_nodes[Position()];
                _nodes[Position()] = infected;
                return infected;
            }

            public void Move()
            {
                switch(_dir)
                {
                    case Direction.Up:
                        _y++;
                        break;
                    case Direction.Right:
                        _x++;
                        break;
                    case Direction.Down:
                        _y--;
                        break;
                    case Direction.Left:
                        _x--;
                        break;
                }
                if (!_nodes.ContainsKey(Position()))
                    _nodes[Position()] = false;
            }

            string Position() => Position(_x, _y);
            static string Position(int x, int y) => $"{x},{y}";
        }

        public enum Direction
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        }
    }
}
