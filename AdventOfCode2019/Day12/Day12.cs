using System;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day12
    {
        public static int PartOne(Moon[] moons, int steps)
        {
            for(int i = 0; i < steps; i++)
            {
                moons[0].AdjustVelocity(moons[1]);
                moons[0].AdjustVelocity(moons[2]);
                moons[0].AdjustVelocity(moons[3]);

                moons[1].AdjustVelocity(moons[0]);
                moons[1].AdjustVelocity(moons[2]);
                moons[1].AdjustVelocity(moons[3]);

                moons[2].AdjustVelocity(moons[0]);
                moons[2].AdjustVelocity(moons[1]);
                moons[2].AdjustVelocity(moons[3]);

                moons[3].AdjustVelocity(moons[0]);
                moons[3].AdjustVelocity(moons[1]);
                moons[3].AdjustVelocity(moons[2]);

                foreach (var moon in moons)
                    moon.Move();
            }
            return moons.Sum(m => m.TotalEnergy);
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }

    public class Moon
    {
        public Moon(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int VX { get; set; }
        public int VY { get; set; }
        public int VZ { get; set; }

        public void AdjustVelocity(Moon moon)
        {
            if (moon.X < X)
                VX--;
            else if (moon.X > X)
                VX++;

            if (moon.Y < Y)
                VY--;
            else if (moon.Y > Y)
                VY++;

            if (moon.Z < Z)
                VZ--;
            else if (moon.Z > Z)
                VZ++;
        }

        public void Move()
        {
            X += VX;
            Y += VY;
            Z += VZ;
        }

        public int PotentialEnergy =>
            Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);

        public int KineticEnergy =>
            Math.Abs(VX) + Math.Abs(VY) + Math.Abs(VZ);

        public int TotalEnergy =>
            PotentialEnergy * KineticEnergy;
    }
}
