using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    enum State
    {
        WaitingForY = 1,
        WaitingForTileId = 2,
        WaitingForX = 3
    }

    public static class Day13
    {
        static IntcodeComputerTwo computer;
        static long[,] game;
        static State state;
        static long x;
        static long y;

        public static async Task<int> PartOne(string filename)
        {
            state = State.WaitingForX;
            game = new long[100, 100];
            long[] program = filename.SplitLongs();
            computer = new IntcodeComputerTwo(program);
            computer.OutputAvailable += OutputAvailable;
            await computer.RunProgram();

            int c = 0;
            foreach(long g in game)
            {
                if (g == 2) c++;
            }
            return c;
        }

        private static void OutputAvailable(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.WaitingForX:
                    x = computer.Output.Dequeue();
                    state = State.WaitingForY;
                    break;
                case State.WaitingForY:
                    y = computer.Output.Dequeue();
                    state = State.WaitingForTileId;
                    break;
                case State.WaitingForTileId:
                    long tile = computer.Output.Dequeue();
                    game[x, y] = tile;
                    state = State.WaitingForX;
                    break;
            }
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }
}
