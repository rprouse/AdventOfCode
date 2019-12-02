using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day01
    {
        public static int PartOne(string filename)
        {
            int[] masses = filename.GetInts();
            return masses.Select(m => FuelRequired(m)).Sum();
        }

        public static int PartTwo(string filename)
        {
            int[] masses = filename.GetInts();
            return masses.Select(m => FuelRequiredWithFuel(m)).Sum();
        }

        public static int FuelRequired(int mass) =>
            mass / 3 - 2;

        public static int FuelRequiredWithFuel(int mass)
        {
            int fuel = FuelRequired(mass);
            int lastFuel = fuel;
            while(true)
            {
                int fuelForFuel = FuelRequired(lastFuel);
                if (fuelForFuel <= 0) return fuel;
                fuel += fuelForFuel;
                lastFuel = fuelForFuel;
            }
        }
    }
}
