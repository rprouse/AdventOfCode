using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

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

        public static int PartTwo(string filename)
        {
            long[] program = filename.SplitLongs();
            return 0;
        }
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
            char c = (char)Output.Dequeue();
            if(c == NEWLINE)
            {
                Camera.Add(scanLine.ToString());
                scanLine.Clear();
            }
            else
            {
                scanLine.Append(c);
            }
        }
    }
}
