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
            List<string> layers = GetLayers(filename.ReadAll(), width, height);

            // Find layer with fewest zeros
            int min = layers.Min(l => CountNumber(l, '0'));
            string minLayer = layers.Single(l => CountNumber(l, '0') == min);

            // Multiply the number of 1s with the number of 2s
            return CountNumber(minLayer, '1') * CountNumber(minLayer, '2');
        }

        private static List<string> GetLayers(string encoded, int width, int height)
        {
            var layers = new List<string>();
            int pos = 0;

            // Get the layers
            while (pos < encoded.Length)
            {
                layers.Add(encoded.Substring(pos, width * height));
                pos += width * height;
            }

            return layers;
        }

        public static int CountNumber(string layer, char n) =>
            layer.Count(c => c == n);

        public static string PartTwo(string filename, int width, int height)
        {
            List<string> layers = GetLayers(filename.ReadAll(), width, height);
            char[] image = new char[width * height];
            for(int pos = 0; pos < image.Length; pos++)
            {
                image[pos] = GetColorAtPos(layers, pos);
            }

            string final = DivideImageIntoRows(new string(image), width, height);
            Console.WriteLine(final);
            return final;
        }

        static char GetColorAtPos(IEnumerable<string> layers, int pos) =>
            layers.Select(l => l[pos]).First(c => c != '2');

        static string DivideImageIntoRows(string image, int width, int height)
        {
            var builder = new StringBuilder(width * height);

            for(int pos = 0; pos < width * height; pos += width)
            {
                builder.AppendLine(image.Substring(pos, width));
            }
            return builder.ToString();
        }
    }
}
