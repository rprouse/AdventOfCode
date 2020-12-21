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

        public static int PartTwo(string filename)
        {
            string[] lines = filename.ReadAllLines();
            List<Tile> tiles = new List<Tile>();
            for (int i = 0; i < lines.Length; i += 11)
                tiles.Add(new Tile(lines[i..(i + 11)]));

            Tile one = null;
            Tile two = null;

            // Find a corner tile
            Tile corner = tiles.First(tile => {
                var matching = tiles.Where(t => t.HasMatchingSide(tile)).ToArray();
                if(matching.Length == 2)
                {
                    one = matching[0];
                    two = matching[1];
                    return true;
                }
                return false;
            });
            corner.FlipAndRotateTopLeftCornerToMatch(one, two);

            int size = (int)Math.Sqrt(tiles.Count);
            Tile[,] arrangedTiles = new Tile[size, size];
            arrangedTiles[0, 0] = corner;
            tiles.Remove(corner);

            // Place the top row
            for (int x = 1; x < size; x++)
            {
                Tile left = arrangedTiles[x-1, 0];
                Tile right = tiles.First(t => t.MatchesToTheLeft(left));
                tiles.Remove(right);
                right.FlipAndRotateToMatchLeft(left);
                arrangedTiles[x, 0] = right;
            }

            // Place subsequent rows
            for (int y = 1; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    Tile top = arrangedTiles[x, y - 1];
                    Tile bottom = tiles.First(t => t.MatchesToTheTop(top));
                    tiles.Remove(bottom);
                    bottom.FlipAndRotateToMatchTop(top);
                    arrangedTiles[x, y] = bottom;
                }
            }

            int hashes = 0;
            string[] ocean = new string[size * 8];
            for(int y = 0; y < size * 8; y++)
            {
                var row = new StringBuilder(size * 8);
                for(int x = 0; x < size * 8; x++)
                {
                    Tile tile = arrangedTiles[x/8, y/8];
                    char c = tile[x % 8 + 1, y % 8 + 1];
                    if (c == '#') hashes++;
                    row.Append(c);
                }
                ocean[y] = row.ToString();
            }

            int monsters = CountSeaMonsters(ocean);
            if(monsters > 0)
                return hashes - (monsters * 15);

            string[] rotated = ocean;
            for (int i = 0; i < 4; i++)
            {
                rotated = RotateOcean(rotated);
                monsters = CountSeaMonsters(rotated);
                if (monsters > 0)
                    return hashes - (monsters * 15);
            }

            rotated = FlipOcean(ocean);
            for (int i = 0; i < 4; i++)
            {
                rotated = RotateOcean(rotated);
                monsters = CountSeaMonsters(rotated);
                if (monsters > 0)
                    return hashes - (monsters * 15);
            }

            return 0;
        }

        static string[] RotateOcean(string[] ocean)
        {
            string[] rotated = new string[ocean.Length];
            char[] row = new char[ocean.Length];
            for (int x = 0; x < ocean.Length; x++)
            {
                for (int y = 0; y < ocean.Length; y++)
                {
                    row[y] = ocean[ocean.Length - y - 1][x];
                }
                rotated[x] = new string(row);
            }
            return rotated;
        }

        static string[] FlipOcean(string[] ocean)
        {
            string[] flipped = new string[ocean.Length];

            for (int i = 0; i < ocean.Length; i++)
                flipped[i] = ocean[ocean.Length - i - 1];

            return flipped;
        }

        static int CountSeaMonsters(string[] ocean)
        {
            int count = 0;
            for (int y = 1; y < ocean.Length - 1; y++)
                for (int x = 0; x < ocean.Length - 19; x++)
                    if(IsSeaMonster(ocean, x, y)) 
                        count++;
            return count;
        }

        static bool IsSeaMonster(string[] ocean, int x, int y) =>
            ocean[y][x] == '#' &&
            ocean[y + 1][x + 1] == '#' &&
            ocean[y + 1][x + 4] == '#' &&
            ocean[y][x + 5] == '#' &&
            ocean[y][x + 6] == '#' &&
            ocean[y + 1][x + 7] == '#' &&
            ocean[y + 1][x + 10] == '#' &&
            ocean[y][x + 11] == '#' &&
            ocean[y][x + 12] == '#' &&
            ocean[y + 1][x + 13] == '#' &&
            ocean[y + 1][x + 16] == '#' &&
            ocean[y][x + 17] == '#' &&
            ocean[y][x + 18] == '#' &&
            ocean[y - 1][x + 18] == '#' &&
            ocean[y][x + 19] == '#';
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

        public char this[int x, int y] => _tile[y][x];

        public Tile(string[] lines)
        {
            Id = lines[0][5..9].ToLong();
            _tile = lines[1..];
            UpdateFromTile();
        }

        private void UpdateFromTile()
        { 
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

        public bool MatchesToTheLeft(Tile left)
        {
            if (left.Id == Id)
                return false;
            return _sides.Any(s => s == left._right);
        }

        public bool MatchesToTheTop(Tile Top)
        {
            if (Top.Id == Id)
                return false;
            return _sides.Any(s => s == Top._bottom);
        }

        public void FlipAndRotateTopLeftCornerToMatch(Tile one, Tile two)
        {
            if (one._top == _fTop ||
                one._top == _fRight ||
                one._top == _fBottom ||
                one._top == _fLeft ||
                one._right == _fTop ||
                one._right == _fRight ||
                one._right == _fBottom ||
                one._right == _fLeft ||
                one._bottom == _fTop ||
                one._bottom == _fRight ||
                one._bottom == _fBottom ||
                one._bottom == _fLeft ||
                one._left == _fTop ||
                one._left == _fRight ||
                one._left == _fBottom ||
                one._left == _fLeft)
                FlipVertical();

            if(one._sides.Any(s => s == _top))
            {
                if (two._sides.Any(s => s == _right))
                    Rotate90();
                else if (two._sides.Any(s => s == _left))
                    Rotate180();
                else
                    throw new Exception();
            }
            else if (one._sides.Any(s => s == _right))
            {
                if (two._sides.Any(s => s == _top))
                    Rotate90();
                else if (two._sides.Any(s => s == _bottom))
                    NoRotation();
                else
                    throw new Exception();
            }
            else if (one._sides.Any(s => s == _bottom))
            {
                if (two._sides.Any(s => s == _right))
                    NoRotation();
                else if (two._sides.Any(s => s == _left))
                    Rotate270();
                else
                    throw new Exception();
            }
            else if(one._sides.Any(s => s == _left))
            {
                if (two._sides.Any(s => s == _bottom))
                    Rotate270();
                else if (two._sides.Any(s => s == _top))
                    Rotate180();
                else
                    throw new Exception();
            }
        }

        public void FlipAndRotateToMatchLeft(Tile left)
        {
            if (left._right == _top ||
                left._right == _right ||
                left._right == _bottom ||
                left._right == _left)
                FlipVertical();

            if (left._right == _fLeft)
                NoRotation();
            else if (left._right == _fTop)
                Rotate270();
            else if (left._right == _fRight)
                Rotate180();
            else if (left._right == _fBottom)
                Rotate90();
            else
                throw new Exception();
        }

        public void FlipAndRotateToMatchTop(Tile top)
        {
            if (top._bottom == _top ||
                top._bottom == _right ||
                top._bottom == _bottom ||
                top._bottom == _left)
                FlipVertical();

            if (top._bottom == _fTop)
                NoRotation();
            else if (top._bottom == _fRight)
                Rotate270();
            else if (top._bottom == _fBottom)
                Rotate180();
            else if (top._bottom == _fLeft)
                Rotate90();
            else
                throw new Exception();
        }

        void NoRotation() { }

        void Rotate90()
        {
            Rotate90Internal();
            UpdateFromTile();
        }

        private void Rotate90Internal()
        {
            string[] rotated = new string[10];
            char[] row = new char[10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    row[y] = _tile[9 - y][x];
                }
                rotated[x] = new string(row);
            }
            _tile = rotated;
        }

        void Rotate180()
        {
            Rotate90Internal();
            Rotate90Internal();
            UpdateFromTile();
        }

        void Rotate270()
        {
            Rotate90Internal();
            Rotate90Internal();
            Rotate90Internal();
            UpdateFromTile();
        }

        void FlipHorizontal()
        {
            char[] row = new char[10];
            for(int x = 0; x < 10; x++)
            {
                for(int y = 0; y < 10; y++)
                {
                    row[y] = _tile[x][9 - y];
                }
                _tile[x] = new string(row);
            }
            UpdateFromTile();
        }

        void FlipVertical()
        {
            string[] flipped = new string[10];
            for (int i = 0; i < 10; i++)
                flipped[i] = _tile[9 - i];

            _tile = flipped;
            UpdateFromTile();
        }

        public override string ToString() => Id.ToString();

        public override bool Equals(object obj) => obj.GetHashCode() == GetHashCode();

        public override int GetHashCode() => Id.GetHashCode();
    }
}
