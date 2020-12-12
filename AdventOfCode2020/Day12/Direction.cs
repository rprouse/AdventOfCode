namespace AdventOfCode2020
{
    public class Direction
    {
        public int X { get; set; } = 1;
        public int Y { get; set; } = 0;

        public override string ToString() => $"{X},{Y}";

        public void TurnLeft(int degrees)
        {
            TurnLeft();
            if (degrees >= 180)
                TurnLeft();
            if (degrees == 270)
                TurnLeft();
        }

        public void TurnLeft()
        {
            if (Y == -1)
            {
                Y = 0;
                X = -1;
            }
            else if (Y == 1)
            {
                Y = 0;
                X = 1;
            }
            else if (X == -1)
            {
                Y = 1;
                X = 0;
            }
            else if (X == 1)
            {
                Y = -1;
                X = 0;
            }
        }

        public void TurnRight(int degrees)
        {
            TurnRight();
            if (degrees >= 180)
                TurnRight();
            if (degrees == 270)
                TurnRight();
        }

        public void TurnRight()
        {
            if (Y == -1)
            {
                Y = 0;
                X = 1;
            }
            else if (Y == 1)
            {
                Y = 0;
                X = -1;
            }
            else if (X == -1)
            {
                Y = -1;
                X = 0;
            }
            else if (X == 1)
            {
                Y = 1;
                X = 0;
            }
        }
    }
}
