using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public static class Day20
    {
        public static long PartOne(string filename)
        {
            string[] lines = filename.ReadAllLines();
            List<Tile> tiles = new List<Tile>();
            for(int i = 0; i < lines.Length; i += 11)
                tiles.Add(new Tile(lines[i..(i+11)]));

            long cornerProduct = 1;
            for(int i = 0; i < tiles.Count; i++)
            {
                int count = tiles.Count(t => t.HasMatchingSide(tiles[i]));
                if ( count == 2)
                    cornerProduct *= tiles[i].Id;
            }
            return cornerProduct;
        }

        public static long PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            return 0;
        }
    }

    public class Tile
    {
        public long Id { get; }

        public string[] _tile;
        public string _top;
        public string _right;
        public string _bottom;
        public string _left;
        public string _fTop;
        public string _fRight;
        public string _fBottom;
        public string _fLeft;
        public string[] _sides = new string[8];

        public Tile(string[] lines)
        {
            Id = lines[0][5..9].ToLong();
            _tile = lines[1..];

            // Rotation
            char[] top = new char[10];
            char[] rgt = new char[10];
            char[] btm = new char[10];
            char[] lft = new char[10];
            for (int x = 0; x < 10; x++)
            {
                top[x] = _tile[0][x];
                rgt[x] = _tile[x][9];
                btm[x] = _tile[9][9 - x];
                lft[x] = _tile[9 - x][0];
            }
            _top = new string(top);
            _right = new string(rgt);
            _bottom = new string(btm);
            _left = new string(lft);
            _fTop = new string(top.Reverse().ToArray());
            _fRight = new string(rgt.Reverse().ToArray());
            _fBottom = new string(btm.Reverse().ToArray());
            _fLeft = new string(lft.Reverse().ToArray());
            _sides[0] = _top;
            _sides[1] = _right;
            _sides[2] = _bottom;
            _sides[3] = _left;
            _sides[4] = _fTop;
            _sides[5] = _fRight;
            _sides[6] = _fBottom;
            _sides[7] = _fLeft;
        }

        public bool HasMatchingSide(Tile other)
        {
            if (other.Id == Id) 
                return false;
            return _sides.Any(s => s == other._top) ||
                   _sides.Any(s => s == other._right) ||
                   _sides.Any(s => s == other._bottom) ||
                   _sides.Any(s => s == other._left) ||
                   _sides.Any(s => s == other._fTop) ||
                   _sides.Any(s => s == other._fRight) ||
                   _sides.Any(s => s == other._fBottom) ||
                   _sides.Any(s => s == other._fLeft);
        }

        public override string ToString() => Id.ToString();
    }
}
