using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public static class Day19
    {
        public static string PartOne(string filename)
        {
            var board = File.ReadAllLines(filename);
            int x = FindStart(board);
            int y = 1;
            int xDir = 0;
            int yDir = 1;
            var path = new StringBuilder();
            while(x > 0 && y > 0 && x < board[0].Length && y < board.Length && board[y][x] != ' ')
            {
                //Print(x, y, xDir, yDir, board);
                switch(board[y][x])
                {
                    case '|':
                    case '-':
                        break;
                    case '+':
                        (xDir, yDir) = NewDirection(x, y, xDir, yDir, board);
                        break; 
                    default:
                        path.Append(board[y][x]);
                        break;
                }
                x += xDir;
                y += yDir;
            }
            return path.ToString();
        }

        public static string PartTwo(string filename)
        {
            return "";
        }

        static int FindStart(string[] board) => board[0].IndexOf('|');

        static (int, int) NewDirection(int x, int y, int xDir, int yDir, string[] board)
        {
            if(xDir != 0)
            {
                if (board[y-1][x] != ' ')
                    return (0, -1);
                else if (board[y+1][x] != ' ')
                    return (0, 1);
            }
            else if(yDir != 0)
            {
                if (board[y][x-1] != ' ')
                    return (-1, 0);
                else if (board[y][x+1] != ' ')
                    return (1, 0);

            }
            Print(x, y, xDir, yDir, board);
            throw new InvalidDataException($"Cannot find new direction {x},{y} {xDir},{yDir}");
        }

        static void Print(int x, int y, int xDir, int yDir, string[] board)
        {
            Console.Clear();
            for(int y1 = 0; y1 < board.Length; y1++)
            {
                for (int x1 = 0; x1 < board[y1].Length; x1++)
                {
                    Console.ForegroundColor = (y1 == y && x1 == x) ?
                         ConsoleColor.Red : ConsoleColor.Gray;
                    Console.BackgroundColor = (y1 == y && x1 == x) ?
                         ConsoleColor.White : ConsoleColor.Black;
                    Console.Write(board[y1][x1]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"({x},{y}) => ({xDir},{yDir})");
            Console.ResetColor();
        }
    }
}
