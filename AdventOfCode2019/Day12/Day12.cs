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
                MoveMoons(moons);
            }
            return moons.Sum(m => m.TotalEnergy);
        }

        public static ulong PartTwo(Moon[] moons)
        {
            // Find the X period
            uint x = 1;
            do
            {
                moons[0].AdjustVelocityX(moons[1]);
                moons[0].AdjustVelocityX(moons[2]);
                moons[0].AdjustVelocityX(moons[3]);

                moons[1].AdjustVelocityX(moons[0]);
                moons[1].AdjustVelocityX(moons[2]);
                moons[1].AdjustVelocityX(moons[3]);

                moons[2].AdjustVelocityX(moons[0]);
                moons[2].AdjustVelocityX(moons[1]);
                moons[2].AdjustVelocityX(moons[3]);

                moons[3].AdjustVelocityX(moons[0]);
                moons[3].AdjustVelocityX(moons[1]);
                moons[3].AdjustVelocityX(moons[2]);

                foreach (var moon in moons)
                    moon.Move();

                x++;
            }
            while (moons.Any(m => !m.IsInitialX));
            
            // Find the Y period
            uint y = 1;
            do
            {
                moons[0].AdjustVelocityY(moons[1]);
                moons[0].AdjustVelocityY(moons[2]);
                moons[0].AdjustVelocityY(moons[3]);

                moons[1].AdjustVelocityY(moons[0]);
                moons[1].AdjustVelocityY(moons[2]);
                moons[1].AdjustVelocityY(moons[3]);

                moons[2].AdjustVelocityY(moons[0]);
                moons[2].AdjustVelocityY(moons[1]);
                moons[2].AdjustVelocityY(moons[3]);

                moons[3].AdjustVelocityY(moons[0]);
                moons[3].AdjustVelocityY(moons[1]);
                moons[3].AdjustVelocityY(moons[2]);

                foreach (var moon in moons)
                    moon.Move();

                y++;
            }
            while (moons.Any(m => !m.IsInitialY));

            // Find the Z period
            uint z = 1;
            do
            {
                moons[0].AdjustVelocityZ(moons[1]);
                moons[0].AdjustVelocityZ(moons[2]);
                moons[0].AdjustVelocityZ(moons[3]);

                moons[1].AdjustVelocityZ(moons[0]);
                moons[1].AdjustVelocityZ(moons[2]);
                moons[1].AdjustVelocityZ(moons[3]);

                moons[2].AdjustVelocityZ(moons[0]);
                moons[2].AdjustVelocityZ(moons[1]);
                moons[2].AdjustVelocityZ(moons[3]);

                moons[3].AdjustVelocityZ(moons[0]);
                moons[3].AdjustVelocityZ(moons[1]);
                moons[3].AdjustVelocityZ(moons[2]);

                foreach (var moon in moons)
                    moon.Move();

                z++;
            }
            while (moons.Any(m => !m.IsInitialZ));

            return AocMath.LeastCommonMultiple(x, AocMath.LeastCommonMultiple(y, z));
        }

        private static void MoveMoons(Moon[] moons)
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
    }

    public class Moon
    {
        int _ix;
        int _iy;
        int _iz;

        public Moon(int x, int y, int z)
        {
            X = x;
            _ix = x;
            Y = y;
            _iy = y;
            Z = z;
            _iz = z;
        }

        public override string ToString() => $"<{Z},{Y},{Z}>";

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int VX { get; set; }
        public int VY { get; set; }
        public int VZ { get; set; }

        public void AdjustVelocity(Moon moon)
        {
            AdjustVelocityX(moon);
            AdjustVelocityY(moon);
            AdjustVelocityZ(moon);
        }

        public void AdjustVelocityZ(Moon moon)
        {
            if (moon.Z < Z)
                VZ--;
            else if (moon.Z > Z)
                VZ++;
        }

        public void AdjustVelocityY(Moon moon)
        {
            if (moon.Y < Y)
                VY--;
            else if (moon.Y > Y)
                VY++;
        }

        public void AdjustVelocityX(Moon moon)
        {
            if (moon.X < X)
                VX--;
            else if (moon.X > X)
                VX++;
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

        public bool IsInitialX =>
            _ix == X;
        public bool IsInitialY =>
            _iy == Y;
        public bool IsInitialZ =>
            _iz == Z;
    }
}
