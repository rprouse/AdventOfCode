using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    public enum State
    {
        WaitingForY = 1,
        WaitingForTileId = 2,
        WaitingForX = 3
    }

    public class ArcadeCabinet : EventDrivenIntcodeComputer
    {
        public long[,] Screen { get; }

        State state;
        long x;
        long y;

        public ArcadeCabinet(long[] program) : base(program)
        {
            state = State.WaitingForX;
            Screen = new long[100, 100];
            OutputAvailable += OnOutputAvailable;
        }

        public ArcadeCabinet(long[] program, long[] input) : base(program, input)
        {
            state = State.WaitingForX;
            Screen = new long[100, 100];
            OutputAvailable += OnOutputAvailable;
        }

        private void OnOutputAvailable(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.WaitingForX:
                    x = Output.Dequeue();
                    state = State.WaitingForY;
                    break;
                case State.WaitingForY:
                    y = Output.Dequeue();
                    state = State.WaitingForTileId;
                    break;
                case State.WaitingForTileId:
                    long tile = Output.Dequeue();
                    Screen[x, y] = tile;
                    state = State.WaitingForX;
                    break;
            }
        }
    }
}
