namespace AdventOfCode2024;

public static class Day04
{
    public static int PartOne(string filename)
    {
        string[] lines = filename.ReadAllLines();
        int count = 0;
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] != 'X')
                    continue;

                // Horizontal forward
                if (x <= lines[y].Length - 4 && lines[y][x+1] == 'M' && lines[y][x + 2] == 'A' && lines[y][x + 3] == 'S')
                    count++;
                // Horizontal backward
                if (x >= 3 && lines[y][x - 1] == 'M' && lines[y][x - 2] == 'A' && lines[y][x - 3] == 'S')
                    count++;
                // Vertical down
                if (y <= lines.Length - 4 && lines[y + 1][x] == 'M' && lines[y + 2][x] == 'A' && lines[y + 3][x] == 'S')
                    count++;
                // Vertical up
                if (y >= 3 && lines[y - 1][x] == 'M' && lines[y - 2][x] == 'A' && lines[y - 3][x] == 'S')
                    count++;
                // Diagonal down-right
                if (x <= lines[y].Length - 4 && y <= lines.Length - 4 && lines[y + 1][x + 1] == 'M' && lines[y + 2][x + 2] == 'A' && lines[y + 3][x + 3] == 'S')
                    count++;
                // Diagonal down-left
                if (x >= 3 && y <= lines.Length - 4 && lines[y + 1][x - 1] == 'M' && lines[y + 2][x - 2] == 'A' && lines[y + 3][x - 3] == 'S')
                    count++;
                // Diagonal up-right
                if (x <= lines[y].Length - 4 && y >= 3 && lines[y - 1][x + 1] == 'M' && lines[y - 2][x + 2] == 'A' && lines[y - 3][x + 3] == 'S')
                    count++;
                // Diagonal up-left
                if (x >= 3 && y >= 3 && lines[y - 1][x - 1] == 'M' && lines[y - 2][x - 2] == 'A' && lines[y - 3][x - 3] == 'S')
                    count++;
            }
        }
        return count;
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
