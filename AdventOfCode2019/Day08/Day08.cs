using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day08
    {
        public static int PartOne(string filename, int width, int height)
        {
            string encoded = filename.ReadAll();
            var layers = new List<string>();
            int pos = 0;

            // Get the layers
            while(pos < encoded.Length)
            {
                layers.Add(encoded.Substring(pos, width * height));
                pos += width * height;
            }

            // Find layer with fewest zeros
            int min = layers.Min(l => CountNumber(l, '0'));
            string minLayer = layers.Single(l => CountNumber(l, '0') == min);

            // Multiply the number of 1s with the number of 2s
            return CountNumber(minLayer, '1') * CountNumber(minLayer, '2');
        }

        public static int CountNumber(string layer, char n) =>
            layer.Count(c => c == n);

        public static int PartTwo(string filename)
        {
            string encoded = filename.ReadAll();
            return 0;
        }
    }
}
