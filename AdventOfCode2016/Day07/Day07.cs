using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode2016
{
    public class Day07
    {
        bool[] _screen;
        int _width;
        int _height;

        public Day07(int width, int height)
        {
            _screen = new bool[width*height];
            _width = width;
            _height = height;
        }

        public void ParseLine(string line)
        {
            if (line.StartsWith("rect"))
                Rect(line);
            else if (line.StartsWith("rotate column"))
                RotateColumn(line);
            else if (line.StartsWith("rotate row"))
                RotateRow(line);
        }

        public int LitPixels =>
            _screen.Count(b => b);

        public bool this[int x, int y]
        {
            get { return _screen[x + y * _width]; }
            set { _screen[x + y * _width] = value; }
        }

        static Regex rectRegx = new Regex(@"rect (\d+)x(\d+)", RegexOptions.Compiled);
        void Rect(string line)
        {
            var match = rectRegx.Match(line);
            if(match.Success)
            {
                int.TryParse(match.Groups[1].Value, out int w);
                int.TryParse(match.Groups[2].Value, out int h);
                for (int x = 0; x < w; x++)
                    for (int y = 0; y < h; y++)
                        this[x, y] = true;
            }
        }

        static Regex rotcRegx = new Regex(@"rotate column x=(\d+) by (\d+)", RegexOptions.Compiled);
        void RotateColumn(string line)
        {
            var match = rotcRegx.Match(line);
            if (match.Success)
            {
                int.TryParse(match.Groups[1].Value, out int x);
                int.TryParse(match.Groups[2].Value, out int n);
                for (int i = 0; i < n; i++)
                {
                    var copy = new bool[_height];
                    for (int y = 1; y < _height; y++)
                        copy[y] = this[x, y - 1];
                    copy[0] = this[x, _height - 1];
                    for (int y = 0; y < _height; y++)
                        this[x, y] = copy[y];
                }
            }
        }

        static Regex rotrRegx = new Regex(@"rotate row y=(\d+) by (\d+)", RegexOptions.Compiled);
        void RotateRow(string line)
        {
            var match = rotrRegx.Match(line);
            if (match.Success)
            {
                int.TryParse(match.Groups[1].Value, out int y);
                int.TryParse(match.Groups[2].Value, out int n);
                for (int i = 0; i < n; i++)
                {
                    var copy = new bool[_width];
                    for (int x = 1; x < _width; x++)
                        copy[x] = this[x - 1, y];
                    copy[0] = this[_width - 1, y];
                    for (int x = 0; x < _width; x++)
                        this[x, y] = copy[x];
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(_width * _height);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    sb.Append(this[x, y] ? "#" : ".");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static int PartOne(string filename, int width, int height) =>
            RunDisplay(filename, width, height).LitPixels;

        public static string PartTwo(string filename, int width, int height) =>
            RunDisplay(filename, width, height).ToString();

        private static Day07 RunDisplay(string filename, int width, int height)
        {
            var day = new Day07(width, height);
            string[] lines = filename.ReadAllLines();
            foreach (var line in lines)
                day.ParseLine(line);
            return day;
        }
    }
}
