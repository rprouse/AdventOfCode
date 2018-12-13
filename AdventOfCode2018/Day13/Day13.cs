using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2018
{
    public static class Day13
    {
        public static (int x, int y) PartOne(string filename)
        {
            var carts = new List<Cart>();
            var track = ReadTrack(filename, carts);

            // Start moving around the track
            while (true)
            {
                //OutputTrack(track, carts);
                carts.Sort();
                var copy = carts.ToArray();
                for (int i = 0; i < copy.Length; i++)
                {
                    copy[i].Move(track);
                    // Check for collisions
                    for (int j = 0; j < copy.Length; j++)
                    {
                        if (j != i && copy[i].Equals(copy[j]))
                            return (copy[i].X, copy[i].Y);
                    }
                }
            }
        }

        public static (int x, int y) PartTwo(string filename)
        {
            var carts = new List<Cart>();
            var track = ReadTrack(filename, carts);

            // Start moving around the track
            while (true)
            {
                //OutputTrack(track, carts);
                carts.Sort();
                var copy = carts.ToArray();
                for (int i = 0; i < copy.Length; i++)
                {
                    copy[i].Move(track);
                    // Check for collisions
                    for (int j = 0; j < copy.Length; j++)
                    {
                        if (j != i && copy[i].Equals(copy[j]))
                        {
                            carts.RemoveAll(c => c == copy[i]);
                            copy[i].X = -1;
                            copy[i].Y = -1;
                            copy[j].X = -1;
                            copy[j].Y = -1;
                        }
                    }
                }
                if (carts.Count == 1)
                    return (carts[0].X, carts[0].Y);
            }
        }

        private static char[][] ReadTrack(string filename, List<Cart> carts)
        {
            string[] lines = filename.ReadAllLines();
            char[][] track = new char[lines.Length][];
            for (int y = 0; y < lines.Length; y++)
            {
                track[y] = ParseLine(lines[y], y, carts);
            }

            return track;
        }

        static void OutputTrack(char[][] track, List<Cart> carts)
        {
            Console.Clear();
            //Console.BufferHeight = track.Length + 5;
            //Console.BufferWidth = track[0].Length + 5;
            Console.ForegroundColor = ConsoleColor.White;
            foreach(char[] line in track)
            {
                Console.WriteLine(new string(line));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach(Cart cart in carts)
            {
                Console.SetCursorPosition(cart.X, cart.Y);
                Console.Write(cart.ToDirectionString());
            }
            Console.ResetColor();
            Console.ReadLine();
        }

        private static char[] ParseLine(string line, int y, List<Cart> carts)
        {
            char[] track = line.ToCharArray();
            FindCarts(track, y).ForEach(c => carts.Add(c));
            return track;
        }

        private static IEnumerable<Cart> FindCarts(char[] track, int y)
        {
            for(int x = 0; x < track.Length; x++)
            {
                char c = track[x];
                if (c == '<' || c == '>')
                    track[x] = '-';
                else if (c == '^' || c == 'v')
                    track[x] = '|';
                if (c == '<' || c == '>' || c == '^' || c == 'v')
                    yield return new Cart(x, y, c);                
            }
        }

        public class Cart : IComparable<Cart>, IEquatable<Cart>
        {
            public int X { get; set; }
            public int Y { get; set; }

            int xDir = 0;
            int yDir = 0;
            int turns = 0;

            public Cart(int x, int y, char c)
            {
                X = x;
                Y = y;
                switch(c)
                {
                    case '^':
                        yDir = -1;
                        break;
                    case 'v':
                        yDir = 1;
                        break;
                    case '>':
                        xDir = 1;
                        break;
                    case '<':
                        xDir = -1;
                        break;
                }
            }

            public void Move(char[][] track)
            {
                if (X == -1 || Y == -1) return;
                char current = track[Y][X];
                if (current == '\\')
                {
                    if (xDir != 0)
                        TurnRight();
                    else
                        TurnLeft();
                }
                else if(current == '/')
                {
                    if (yDir != 0)
                        TurnRight();
                    else
                        TurnLeft();
                }
                else if(current == '+')
                {
                    switch(turns % 3)
                    {
                        case 0:
                            TurnLeft();
                            break;
                        case 1:
                            // Go Straight
                            break;
                        case 2:
                            TurnRight();
                            break;
                    }
                    turns++;
                }
                X += xDir;
                Y += yDir;
            }

            void TurnLeft()
            {
                if(yDir == -1)
                {
                    yDir = 0;
                    xDir = -1;
                }
                else if(yDir == 1)
                {
                    yDir = 0;
                    xDir = 1;
                }
                else if (xDir == -1)
                {
                    yDir = 1;
                    xDir = 0;
                }
                else if (xDir == 1)
                {
                    yDir = -1;
                    xDir = 0;
                }
            }

            void TurnRight()
            {
                if (yDir == -1)
                {
                    yDir = 0;
                    xDir = 1;
                }
                else if (yDir == 1)
                {
                    yDir = 0;
                    xDir = -1;
                }
                else if (xDir == -1)
                {
                    yDir = -1;
                    xDir = 0;
                }
                else if (xDir == 1)
                {
                    yDir = 1;
                    xDir = 0;
                }
            }

            public int CompareTo(Cart other)
            {
                if (other == null) return 1;
                if (Y > other.Y) return 1;
                if (Y < other.Y) return -1;
                if (X > other.X) return 1;
                if (X < other.X) return -1;
                return 0;
            }

            public bool Equals(Cart other)
            {
                if (other == null) return false;
                return Y == other.Y && X == other.X;
            }

            public override int GetHashCode() =>
                (X, Y).GetHashCode();

            public override bool Equals(object obj) =>
                Equals(obj as Cart);

            public override string ToString() =>
                $"({X}, {Y})";

            public string ToDirectionString()
            {
                if(xDir == 0)
                {
                    if (yDir == -1) return "^";
                    return "v";
                }
                else if(xDir == 1)
                {
                    return ">";
                }
                return "<";
            }

            public static bool operator >(Cart operand1, Cart operand2) =>
                operand1.CompareTo(operand2) == 1;

            public static bool operator <(Cart operand1, Cart operand2) =>
                operand1.CompareTo(operand2) == -1;

            public static bool operator >=(Cart operand1, Cart operand2) =>
                operand1.CompareTo(operand2) >= 0;

            public static bool operator <=(Cart operand1, Cart operand2) =>
                operand1.CompareTo(operand2) <= 0;

            public static bool operator ==(Cart operand1, Cart operand2) =>
                operand1?.Equals(operand2) ?? operand2 is null;

            public static bool operator !=(Cart operand1, Cart operand2) =>
                !(operand1?.Equals(operand2) ?? operand2 is null);
        }
    }
}
