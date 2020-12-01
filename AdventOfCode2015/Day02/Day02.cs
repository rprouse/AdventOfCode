using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day02
    {
        public static int PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return lines.Sum(l => CalculatePaperNeeded(l));
        }

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return lines.Sum(l => CalculateRibbonNeeded(l));
        }

        public static int CalculatePaperNeeded(string str)
        {
            var parts = str.Split('x');
            return CalculatePaperNeeded(parts[0].ToInt(), parts[1].ToInt(), parts[2].ToInt());
        }

        public static int CalculatePaperNeeded(int l, int w, int h)
        {
            int a = l * w;
            int b = w * h;
            int c = h * l;
            return 2 * a + 2 * b + 2 * c + Math.Min(a, Math.Min(b, c));
        }

        public static int CalculateRibbonNeeded(string str)
        {
            var parts = str.Split('x');
            return CalculateRibbonNeeded(parts[0].ToInt(), parts[1].ToInt(), parts[2].ToInt());
        }

        public static int CalculateRibbonNeeded(int l, int w, int h)
        {
            int smallest = Math.Min(l + w, Math.Min(w + h, h + l)) * 2;
            return smallest + (l * w * h);
        }
    }
}
