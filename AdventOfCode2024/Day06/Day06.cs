namespace AdventOfCode2024;

public static class Day06
{
    public static int PartOne(string filename)
    {
        char[][] map = filename.ReadAllLines().Select(s => s.ToCharArray()).ToArray();

        // Find the guard.
        int xDir = 0;
        int yDir = 0;
        int xPos = 0;
        int yPos = 0;
        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '^')
                {
                    xDir = 0;
                    yDir = -1;
                    xPos = x;
                    yPos = y;
                    break;
                }
                else if (map[y][x] == 'v')
                {
                    xDir = 0;
                    yDir = 1;
                    xPos = x;
                    yPos = y;
                    break;
                }
                else if (map[y][x] == '<')
                {
                    xDir = -1;
                    yDir = 0;
                    xPos = x;
                    yPos = y;
                    break;
                }
                else if (map[y][x] == '>')
                {
                    xDir = 1;
                    yDir = 0;
                    xPos = x;
                    yPos = y;
                    break;
                }
            }
        }

        // Move the guard.
        while (true)
        {
            // Mark the current position with an X
            map[yPos][xPos] = 'X';

            // Calculate the next position.
            int nextX = xPos + xDir;
            int nextY = yPos + yDir;

            // Are we stepping out of bounds?
            if (nextX < 0 || nextX >= map[0].Length || nextY < 0 || nextY >= map.Length)
            {
                break;
            }

            // Are we stepping against an obstacles?
            if (map[nextY][nextX] == '#')
            {
                // Turn right
                if (xDir == 0)
                {
                    xDir = -yDir;
                    yDir = 0;
                }
                else
                {
                    yDir = xDir;
                    xDir = 0;
                }
                nextX = xPos + xDir;
                nextY = yPos + yDir;
            }
            xPos = nextX;
            yPos = nextY;
        }
        return map.Sum(y => y.Count(x => x == 'X'));
    }

    public static int PartTwo(string filename)
    {
        string[] lines = filename.ReadAllLines();
        return 0;
    }
}
