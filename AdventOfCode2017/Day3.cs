using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2017
{
    public static class Day3
    {
        public static int CalculateDistance(int location)
        {
            int x = 0;
            int y = 0;
            int maxX = 0;
            int maxY = 0;
            int minX = 0;
            int minY = 0;
            int xDir = 1;
            int yDir = 0;

            for(int i = 0; i < location; i++)
            {
                x += xDir;
                y += yDir;
                if(x > maxX)
                {
                    maxX = x;
                    xDir = 0;
                    yDir = -1;
                }
                else if(y > maxY)
                {
                    maxY = y;
                    xDir = 1;
                    yDir = 0;
                }
                else if(x < minX)
                {
                    minX = x;
                    xDir = 0;
                    yDir = 1;
                }
                else if(y < minY)
                {
                    minY = y;
                    xDir = -1;
                    yDir = 0;
                }
            }
            return Math.Abs(x) + Math.Abs(y) - 1;
        }

        public static long CalculateSums(int location)
        {
            var dict = new Dictionary<string, long>();
            int x = 0;
            int y = 0;
            int maxX = 0;
            int maxY = 0;
            int minX = 0;
            int minY = 0;
            int xDir = 1;
            int yDir = 0;
            long lastValue = 1;
            dict.Add("0,0", lastValue);

            for (int i = 1; i < location; i++)
            {
                x += xDir;
                y += yDir;
                lastValue = NewValue(x, y, dict);
                dict.Add(Key(x, y), lastValue);
                if (x > maxX)
                {
                    maxX = x;
                    xDir = 0;
                    yDir = -1;
                }
                else if (y > maxY)
                {
                    maxY = y;
                    xDir = 1;
                    yDir = 0;
                }
                else if (x < minX)
                {
                    minX = x;
                    xDir = 0;
                    yDir = 1;
                }
                else if (y < minY)
                {
                    minY = y;
                    xDir = -1;
                    yDir = 0;
                }
            }
            return lastValue;
        }

        public static long NextSum(int location)
        {
            var dict = new Dictionary<string, long>();
            int x = 0;
            int y = 0;
            int maxX = 0;
            int maxY = 0;
            int minX = 0;
            int minY = 0;
            int xDir = 1;
            int yDir = 0;
            long lastValue = 1;
            dict.Add("0,0", lastValue);

            for (int i = 1; i < location; i++)
            {
                x += xDir;
                y += yDir;
                lastValue = NewValue(x, y, dict);
                dict.Add(Key(x, y), lastValue);
                if (lastValue > location) return lastValue;
                if (x > maxX)
                {
                    maxX = x;
                    xDir = 0;
                    yDir = -1;
                }
                else if (y > maxY)
                {
                    maxY = y;
                    xDir = 1;
                    yDir = 0;
                }
                else if (x < minX)
                {
                    minX = x;
                    xDir = 0;
                    yDir = 1;
                }
                else if (y < minY)
                {
                    minY = y;
                    xDir = -1;
                    yDir = 0;
                }
            }
            return lastValue;
        }

        static long NewValue(int x, int y, Dictionary<string, long> dict)
        {
            long sum = 0;
            for (int x1 = x - 1; x1 <= x + 1; x1++)
            {
                for (int y1 = y - 1; y1 <= y + 1; y1++)
                {
                    string key = Key(x1, y1);
                    if ((x1 != x || y1 != y) && dict.ContainsKey(key))
                    {
                        sum += dict[key];
                    }
                }
            }
            return sum;
        }

        static string Key(int x, int y) => $"{x},{y}";
    }
}
