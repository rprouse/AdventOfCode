using System;
using System.Collections.Generic;
using System.Drawing;
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
        const int RESOLUTION = 40;
        const int EMPTY = 0;
        const int WALL = 1;
        const int BLOCK = 2;
        const int PADDLE = 3;
        const int BALL = 4;

        public long[,] Screen { get; }
        public long Score { get; private set; }

        State state;
        long x;
        long y;

        public override string ToString()
        {
            var b = new StringBuilder(RESOLUTION * RESOLUTION);
            b.AppendLine($"Score: {Score}");
            for (int y = 0; y < RESOLUTION; y++)
            {
                for (int x = 0; x < RESOLUTION; x++)
                {
                    switch(Screen[x,y])
                    {
                        case EMPTY:
                            b.Append(' ');
                            break;
                        case WALL:
                            b.Append('█');
                            break;
                        case BLOCK:
                            b.Append('▒');
                            break;
                        case PADDLE:
                            b.Append('=');
                            break;
                        case BALL:
                            b.Append('o');
                            break;
                    }
                }
                b.AppendLine();
            }
            return b.ToString();
        }

        public ArcadeCabinet(long[] program) : base(program)
        {
            state = State.WaitingForX;
            Screen = new long[RESOLUTION, RESOLUTION];
            OutputAvailable += OnOutputAvailable;
            InputNeeded += OnInputNeeded;
        }

        private void OnInputNeeded(object sender, EventArgs e)
        {
            int ball = FindXOf(BALL);
            int paddle = FindXOf(PADDLE);
            if (paddle == ball)
                Input.Enqueue(0);
            else if (paddle < ball)
                Input.Enqueue(1);
            else
                Input.Enqueue(-1);
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
                    if (x == -1 && y == 0)
                        Score = tile;
                    else
                        Screen[x, y] = tile;
                    state = State.WaitingForX;
                    break;
            }
        }

        private int FindXOf(int tile)
        {
            for (int y = 0; y < RESOLUTION; y++)
                for (int x = 0; x < RESOLUTION; x++)
                    if (Screen[x, y] == tile)
                        return x;
            return 0;
        }
    }
}
