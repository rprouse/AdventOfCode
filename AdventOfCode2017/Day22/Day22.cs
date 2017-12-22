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
            var virus = new Virus(lines);
            return virus.Run2();
        }

        public class Virus
        {
            const char CLEAN = 'c';
            const char INFECTED = 'i';
            const char WEAKENED = 'w';
            const char FLAGGED = 'f'
;
            internal Dictionary<string, char> _nodes = new Dictionary<string, char>();
            int _x = 0;
            int _y = 0;
            internal Direction _dir = Direction.Up;

            public int NumInfected { get; set; }

            public Virus(string[] lines)
            {
                int mid = lines.Length / 2;
                int y = mid;
                foreach(var line in lines)
                {
                    for (int x = 0; x < line.Length; x++)
                        _nodes[Position(x - mid, y)] = line[x] == '#' ? INFECTED : CLEAN;
                    y--;
                }
            }

            public int Run(int iterations)
            {
                foreach(int i in Enumerable.Range(0, iterations))
                {
                    Burst();
                }
                return NumInfected;
            }

            public int Run2()
            {
                foreach (int i in Enumerable.Range(0, 10000000))
                {
                    Burst2();
                }
                return NumInfected;
            }

            public void Burst()
            {
                Turn();
                Infect();
                Move();
            }

            public void Burst2()
            {
                Turn();
                Infect2();
                Move();
            }

            public void Turn()
            {
                char status = _nodes[Position()];
                if (status == CLEAN)
                    TurnLeft();
                else if (status == INFECTED)
                    TurnRight();
                else if (status == FLAGGED)
                    TurnAround();
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

            void TurnAround()
            {
                switch (_dir)
                {
                    case Direction.Up:
                        _dir = Direction.Down;
                        break;
                    case Direction.Right:
                        _dir = Direction.Left;
                        break;
                    case Direction.Down:
                        _dir = Direction.Up;
                        break;
                    case Direction.Left:
                        _dir = Direction.Right;
                        break;
                }
            }

            public void Infect()
            {
                char infected = _nodes[Position()] == CLEAN ? INFECTED : CLEAN;
                if (infected == INFECTED) NumInfected++;
                _nodes[Position()] = infected;
            }

            public void Infect2()
            {
                char status = _nodes[Position()];
                if(status == CLEAN)
                {
                    _nodes[Position()] = WEAKENED;
                }
                else if(status == WEAKENED)
                {
                    _nodes[Position()] = INFECTED;
                    NumInfected++;
                }
                else if (status == INFECTED)
                {
                    _nodes[Position()] = FLAGGED;
                }
                else
                {
                    _nodes[Position()] = CLEAN;
                }
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
                    _nodes[Position()] = CLEAN;
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
