using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

// ........#########............................
// ........#.......#............................
// ........#.#############......................
// ........#.......#.....#......................
// ........#.......#.....#.......###########....
// ........#.......#.....#.......#.........#....
// ........#.......#.....#.......#.#############
// ........#.......#.....#.......#.#.......#...#
// ........#.......#.....#.......#.#.......#...#
// ........#.......#.....#.......#.#.......#...#
// ^########.....#########.#############...#...#
// ..............#.#.......#.....#.#...#...#...#
// ........#########.....#########.#...#...#...#
// ........#.....#.......#.#.......#...#...#...#
// ........#.....#.......#.#.......#...#...#...#
// ........#.....#.......#.#.......#...#...#...#
// ........#.....#.......#.#.......#########...#
// ........#.....#.......#.#...........#.......#
// ........#.....#.......#.###########.#########
// ........#.....#.......#...........#..........
// ........#############.#...........#..........
// ..............#.....#.#...........#..........
// ..............#########...........#..........
// ....................#.............#..........
// ....................#.............#..........
// ....................#.............#..........
// ....................#.............#########..
// ....................#.....................#..
// ....................###########...........#..
// ..............................#...........#..
// ..............................#...........#..
// ..............................#...........#..
// ..............................#...........#..
// ..............................#...........#..
// ..............................#...........#..
// ..............................#...........#..
// ..............................#############..

namespace AdventOfCode2019
{
    public static class Day17
    {
        public static int PartOne(string filename)
        {
            long[] program = filename.SplitLongs();
            var asciiCode = new AsciiCode(program);
            asciiCode.RunProgram();
            asciiCode.OutputToConsole();
            return CalculateAlignmentParameters(asciiCode.Camera);
        }

        public static int CalculateAlignmentParameters(IList<string> camera)
        {
            int sum = 0;
            for (int y = 1; y < camera.Count - 2; y++)
            {
                for (int x = 1; x < camera[y].Length - 1; x++)
                {
                    if (camera[y][x] == '#' &&
                       camera[y - 1][x] == '#' &&
                       camera[y + 1][x] == '#' &&
                       camera[y][x - 1] == '#' &&
                       camera[y][x + 1] == '#')
                    {
                        sum += x * y;
                    }
                }
            }
            return sum;
        }

        public static long PartTwo(string filename)
        {
            // Get the view
            long[] program = filename.SplitLongs();
            program[0] = 2;
            var asciiCode = new AsciiCode(program);
            foreach (int d in directions)
                asciiCode.Input.Enqueue(d);
            long ret = asciiCode.RunProgram();
            return ret;
        }

        // A = R8,L10,R8,
        // B = R12,R8,L8,L12,
        // A = R8,L10,R8,
        // C = L12,L10,L8,
        // A = R8,L10,R8
        // B = R12,R8,L8,L12,
        // C = L12,L10,L8,
        // C = L12,L10,L8,
        // A = R8,L10,R8
        // B = R12,R8,L8,L12
        static int[] directions = new int[]
        {
            'A',',','B',',','A',',','C',',','A',',','B',',','C',',','C',',','A',',','B','\n',
            'R',',','8',',','L',',','9',',','1',',','R',',','8','\n',
            'R',',','9',',','3',',','R',',','8',',','L',',','8',',','L',',','9',',','3','\n',
            'L',',','9',',','3',',','L',',','9',',','1',',','L',',','8','\n',
            'n','\n'
        };
    }

    public class AsciiCode : EventDrivenIntcodeComputer
    {
        const char SCAFFOLD = '#';
        const char SPACE = '.';
        const char LOST = 'x';
        const char UP = '^';
        const char DOWN = 'v';
        const char LEFT = '<';
        const char RIGHT = '>';
        const char NEWLINE = (char)10;

        public List<string> Camera { get; } = new List<string>();
        StringBuilder scanLine = new StringBuilder();

        public AsciiCode(long[] program) : base(program)
        {
            InputNeeded += AsciiCode_InputNeeded;
            OutputAvailable += AsciiCode_OutputAvailable;
        }

        public void OutputToConsole()
        {
            foreach(var line in Camera)
            {
                Console.WriteLine(line);
            }
        }

        private void AsciiCode_InputNeeded(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AsciiCode_OutputAvailable(object sender, EventArgs e)
        {
            long c = Output.Dequeue();
            if (c > 127)
            {
                Console.WriteLine($"Collected: {c}");
            }
            else
            {
                Console.Write((char)c);
            }
            if(c == NEWLINE)
            {
                Camera.Add(scanLine.ToString());
                scanLine.Clear();
            }
            else
            {
                scanLine.Append((char)c);
            }
        }
    }
}
