namespace AdventOfCode2024;

public static class Day06
{
    public static int PartOne(string filename)
    {
        char[][] map;
        int xDir, yDir, xPos, yPos;
        ParseMap(filename, out map, out xDir, out yDir, out xPos, out yPos);

        // Move the guard.
        WalkMap(map, xDir, yDir, xPos, yPos);
        return map.Sum(y => y.Count(x => x == 'X'));
    }

    public static int PartTwo(string filename)
    {
        char[][] map;
        int xDir, yDir, xPos, yPos;
        ParseMap(filename, out map, out xDir, out yDir, out xPos, out yPos);

        // Mark the starting position with an S
        map[yPos][xPos] = 'S';

        while (true)
        {
            // Mark the current position with an X if it is not an O
            if (map[yPos][xPos] != 'O')
                map[yPos][xPos] = 'X';

            // Calculate the next position.
            int nextX = xPos + xDir;
            int nextY = yPos + yDir;

            // Are we stepping out of bounds?
            if (nextX < 0 || nextX >= map[0].Length || nextY < 0 || nextY >= map.Length)
            {
                break;
            }

            // If we put an obstacle here, will it cause a loop?
            if (map[nextY][nextX] != '#' && map[nextY][nextX] != 'S' && map[nextY][nextX] != 'O' && IsLoop(map, xDir, yDir, xPos, yPos))
            {
                map[nextY][nextX] = 'O';
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
        return map.Sum(y => y.Count(x => x == 'O'));
    }

    private static void ParseMap(string filename, out char[][] map, out int xDir, out int yDir, out int xPos, out int yPos)
    {
        map = filename.ReadAllLines().Select(s => s.ToCharArray()).ToArray();

        // Find the guard.
        xDir = 0;
        yDir = 0;
        xPos = 0;
        yPos = 0;
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
    }

    private static void WalkMap(char[][] map, int xDir, int yDir, int xPos, int yPos)
    {
        // Mark the starting position with an S
        map[yPos][xPos] = 'S';

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
    }

    private static bool IsLoop(char[][] map, int xDir, int yDir, int xPos, int yPos)
    {
        // Save where we are and which way we are going.
        int saveX = xPos;
        int saveY = yPos;
        int saveXDir = xDir;
        int saveYDir = yDir;

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

        // Walk the map.
        while (true)
        {
            // Calculate the next position.
            int nextX = xPos + xDir;
            int nextY = yPos + yDir;

            // Are we back at the starting position?
            if (xPos == saveX && yPos == saveY && saveXDir == xDir && saveYDir == yDir)
            {
                return true;
            }

            // Are we stepping out of bounds?
            if (nextX < 0 || nextX >= map[0].Length || nextY < 0 || nextY >= map.Length)
            {
                return false;
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
    }
}
