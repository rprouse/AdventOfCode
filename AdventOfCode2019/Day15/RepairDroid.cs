using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode2019
{
    public class RepairDroid : EventDrivenIntcodeComputer
    {
        const int North = 1;
        const int South = 2;
        const int West = 3;
        const int East = 4;

        const int WALL = 0;
        const int Open = 1;
        const int OxygenSystem = 2;

        const char WALL_CHAR = '█';
        const char OPEN_CHAR = '.';
        const char DROID_CHAR = 'o';
        const char OXYGEN_CHAR = '◇';
        const char START_CHAR = 'S';
        const char SPACE_CHAR = ' ';

        const int SIZE = 42;

        Stack<Point> walk = new Stack<Point>();
        Point pos = new Point(SIZE / 2, SIZE / 2);
        int lastDir = North;

        char[,] ship = new char[SIZE, SIZE];

        public RepairDroid(long[] program) : base(program)
        {
            for (int y = 0; y < SIZE; y++)
                for (int x = 0; x < SIZE; x++)
                    ship[x, y] = SPACE_CHAR;

            Console.Clear();
            Console.CursorLeft = pos.X;
            Console.CursorTop = pos.Y;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(DROID_CHAR);
            Console.CursorLeft = 0;
            Console.CursorTop = SIZE + 2;
            Console.ResetColor();

            ship[pos.X, pos.Y] = START_CHAR;
            walk.Push(pos);

            InputNeeded += RepairDroid_CalculateInput;
            OutputAvailable += RepairDroid_OutputAvailable;
        }

        private void RepairDroid_InputNeeded(object sender, EventArgs e)
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Input.Enqueue(North);
                        lastDir = North;
                        return;
                    case ConsoleKey.DownArrow:
                        Input.Enqueue(South);
                        lastDir = South;
                        return;
                    case ConsoleKey.LeftArrow:
                        Input.Enqueue(West);
                        lastDir = West;
                        return;
                    case ConsoleKey.RightArrow:
                        Input.Enqueue(East);
                        lastDir = East;
                        return;
                }
            }
        }

        private void RepairDroid_CalculateInput(object sender, EventArgs e)
        {
            if(pos.X > 0 && ship[pos.X - 1, pos.Y] == SPACE_CHAR)
            {
                Input.Enqueue(West);
                lastDir = West;
            }
            else if(pos.X < SIZE && ship[pos.X + 1, pos.Y] == SPACE_CHAR)
            {
                Input.Enqueue(East);
                lastDir = East;
            }
            else if(pos.Y > 0 && ship[pos.X, pos.Y - 1] == SPACE_CHAR)
            {
                Input.Enqueue(North);
                lastDir = North;
            }
            else if(pos.Y < SIZE && ship[pos.X, pos.Y + 1] == SPACE_CHAR)
            {
                Input.Enqueue(South);
                lastDir = South;
            }
            else // Pop from the stack and move back
            {
                if(walk.Count == 0)
                {
                    // Back to start
                    Console.CursorLeft = 0;
                    Console.CursorTop = SIZE + 3;
                    Console.WriteLine("Back to start, finished");
                    Environment.Exit(0);
                }

                // Take the current location off the stack
                // and look at the previous to go back to
                walk.Pop();
                Point popped = walk.Peek();
                if(popped.X < pos.X)
                {
                    Input.Enqueue(West);
                    lastDir = West;
                }
                else if(popped.X > pos.X)
                {
                    Input.Enqueue(East);
                    lastDir = East;
                }
                else if(popped.Y < pos.Y)
                {
                    Input.Enqueue(North);
                    lastDir = North;
                }
                else if(popped.Y > pos.Y)
                {
                    Input.Enqueue(South);
                    lastDir = South;
                }
                else
                {
                    throw new Exception($"Invalid previous position {popped} for pos {pos}");
                }
            }
        }

        private void RepairDroid_OutputAvailable(object sender, EventArgs e)
        {
            long result = Output.Dequeue();

            Point newPos;

            switch (lastDir)
            {
                case North:
                    newPos = new Point(pos.X, pos.Y - 1);
                    break;
                case South:
                    newPos = new Point(pos.X, pos.Y + 1);
                    break;
                case West:
                    newPos = new Point(pos.X - 1, pos.Y);
                    break;
                case East:
                    newPos = new Point(pos.X + 1, pos.Y);
                    break;
                default:
                    newPos = new Point(pos.X, pos.Y);
                    break;
            }

            switch (result)
            {
                case WALL:
                    Console.CursorLeft = newPos.X;
                    Console.CursorTop = newPos.Y;
                    Console.Write(WALL_CHAR);
                    ship[newPos.X, newPos.Y] = WALL_CHAR;
                    break;
                case Open:
                    Console.CursorLeft = pos.X;
                    Console.CursorTop = pos.Y;
                    Console.Write(ship[pos.X, pos.Y]);
                    Console.CursorLeft = newPos.X;
                    Console.CursorTop = newPos.Y;
                    Console.Write(DROID_CHAR);
                    if (ship[newPos.X, newPos.Y] == ' ')
                    {
                        walk.Push(newPos);
                        ship[newPos.X, newPos.Y] = OPEN_CHAR;
                    }
                    pos = newPos;
                    break;
                case OxygenSystem:
                    Console.CursorLeft = pos.X;
                    Console.CursorTop = pos.Y;
                    Console.Write(ship[pos.X, pos.Y]);
                    Console.CursorLeft = newPos.X;
                    Console.CursorTop = newPos.Y;
                    Console.Write(DROID_CHAR);
                    if (ship[newPos.X, newPos.Y] == ' ')
                    {
                        walk.Push(newPos);
                        ship[newPos.X, newPos.Y] = OXYGEN_CHAR;
                    }
                    pos = newPos;

                    Console.CursorLeft = 0;
                    Console.CursorTop = SIZE + 2;
                    Console.WriteLine($"Found oxygen tank at {pos}, {walk.Count - 1} steps away");

                    break;
            }
        }
    }
}
