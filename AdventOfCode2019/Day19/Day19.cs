using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day19
    {
        public static long PartOne(string filename)
        {
            long[] program = filename.SplitLongs();
            int count = 0;
            for (int y = 0; y < 50; y++)
            {
                for (int x = 0; x < 50; x++)
                {
                    var drone = new TractorDrone(program, x, y);
                    if (drone.RunProgram() == 1)
                        count++;
                }
            }
            return count;
        }
        public static void VisualizeTractorBeam()
        {
            long[] program = Day19Tests.PuzzleFile(19).SplitLongs();
            for (int y = 690; y < 804; y++)
            {
                for (int x = 1400; x < 1512; x++)
                {
                    var drone = new TractorDrone(program, x, y);
                    char f = '#';
                    if (x >= 1404 && x < 1504 && y >= 699 && y < 799)
                        f = ';';
                    Console.Write(drone.RunProgram() == 1 ? f : '.');
                }
                Console.WriteLine($" {y}");
            }
        }

        public static long PartTwo(string filename)
        {
            long[] program = filename.SplitLongs();
            long y = 690;
            long x = 1400;
            long firstX = 0;
            bool foundX = false;
            while (true)
            {
                var drone = new TractorDrone(program, x, y);
                if (drone.RunProgram() == 1)
                {
                    if (!foundX)
                    {
                        firstX = x;
                        foundX = true;
                    }
                    var testX = new TractorDrone(program, x + 99, y);
                    if (testX.RunProgram() == 1)
                    {
                        var testY = new TractorDrone(program, x, y + 99);
                        if (testY.RunProgram() == 1)
                        {
                            return x * 10000L + y;
                        }
                    }
                    else
                    {
                        y++;
                        x = firstX - 1;
                        foundX = false;
                    }
                    x++;
                }
                else if (foundX)
                {
                    y++;
                    x = firstX;
                    foundX = false;
                }
                else
                {
                    x++;
                }
            }
        }
    }
}
