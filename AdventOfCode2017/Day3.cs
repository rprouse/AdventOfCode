using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2017
{
    public static class Day3
    {
        public static int CalculateDistance(int location)
        {
            var square = location.CalculateSquare();
            return Math.Abs(square.x) + Math.Abs(square.y) - 1;
        }

        static (int x, int y) CalculateSquare(this int location)
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
            return (x, y);
        }
    }
}
