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

        // Walk the map once to find all routes
        WalkMap(map, xDir, yDir, xPos, yPos);

        // Walk the map again to find all loops
        while (true)
        {
            // Calculate the next position.
            int nextX = xPos + xDir;
            int nextY = yPos + yDir;

            // Are we stepping out of bounds?
            if (nextX < 0 || nextX >= map[0].Length || nextY < 0 || nextY >= map.Length)
            {
                break;
            }

            // If we turn right, would that result in a loop?
            // Only do it if the next square is not an obstacle and not visited yet.
            if (map[nextY][nextX] == '#' && map[nextY][nextX] != 'O')
            {
                int xRight, yRight;
                if (xDir == 0)
                {
                    xRight = -yDir;
                    yRight = 0;
                }
                else
                {
                    yRight = xDir;
                    xRight = 0;
                }

                int xNew = xPos + xRight;
                int yNew = yPos + yRight;
                if (xNew >= 0 && xNew < map[0].Length && yNew >= 0 && yNew < map.Length)
                {
                    if (map[yNew][xNew] == 'X')
                    {
                        // We could be in a loop because we are on a walked path
                        // but not if we are walking in the wrong direction.
                        // So let's walk it and see if we hit an obstacle.
                        while (xNew >= 0 && xNew < map[0].Length && yNew >= 0 && yNew < map.Length)
                        {
                            if (map[yNew][xNew] == '#')
                            {
                                // We hit an obstacle, so we are in a loop
                                // Mark the potential obtruction point
                                map[nextY][nextX] = 'O';
                                break;
                            }
                            xNew += xRight;
                            yNew += yRight;
                        }
                    }
                }
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
}
