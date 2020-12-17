using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode2020
{
    public class ConwayCubes
    {
        int _cycles;
        int _size;
        int _zero;
        bool[,,] _cubes;
        bool[,,] _newCubes;

        public ConwayCubes(string filename, int cycles)
        {
            _cycles = cycles;
            string[] lines = filename.ReadAllLines();
            _size = lines.Length + _cycles + 8;
            _zero = (_size / 2) - (lines.Length / 2);
            _cubes = new bool[_size, _size, _size];
            _newCubes = new bool[_size, _size, _size];

            for (int y = 0; y < lines.Length; y++)
                for (int x = 0; x < lines[y].Length; x++)
                    _newCubes[x + _zero, y + _zero, _zero] = lines[y][x] == '#';

            CopyBoards();
        }

        public void Run()
        {
            for (int i = 0; i < _cycles; i++)
            {
                UpdateBoard();
                CopyBoards();
            }
        }

        public int CountActive()
        {
            int c = 0;
            for (int z = 1; z < _size - 1; z++)
                for (int y = 1; y < _size - 1; y++)
                    for (int x = 1; x < _size - 1; x++)
                        if (_cubes[x, y, z]) c++;
            return c;
        }

        internal void UpdateBoard()
        {
            for (int z = 1; z < _size - 1; z++)
                for (int y = 1; y < _size - 1; y++)
                    for (int x = 1; x < _size - 1; x++)
                    {
                        int active = ActiveNeighbours(x, y, z);
                        if (_cubes[x, y, z])
                            _newCubes[x, y, z] = active == 2 || active == 3;
                        else
                            _newCubes[x, y, z] = active == 3;
                    }
        }

        internal int ActiveNeighbours(int x, int y, int z)
        {
            int c = 0;

            for (int z1 = z - 1; z1 <= z + 1; z1++)
                for (int y1 = y - 1; y1 <= y + 1; y1++)
                    for (int x1 = x - 1; x1 <= x + 1; x1++)
                        if (!(x1 == x && y1 == y && z1 == z) && _cubes[x1, y1, z1])
                            c++;

            return c;
        }

        internal void CopyBoards()
        {
            for (int z = 1; z < _size - 1; z++)
                for (int y = 1; y < _size - 1 ; y++)
                    for (int x = 1; x < _size - 1; x++)
                        _cubes[x, y, z] = _newCubes[x, y, z];
        }

        internal string View => ToString();

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int z = 0; z < _size; z++)
            {
                builder.AppendLine($"Z = {z}");
                builder.Append(" ");
                for (int x = 0; x < _size; x++)
                {
                    builder.Append(x % 10);
                }
                builder.AppendLine();
                for (int y = 0; y < _size; y++)
                {
                    builder.Append(y % 10);
                    for (int x = 0; x < _size; x++)
                    {
                        builder.Append(_cubes[x, y, z] ? '#' : '.');
                    }
                    builder.AppendLine();
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
