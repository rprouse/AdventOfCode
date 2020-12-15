namespace AdventOfCode2020
{
    public static class Day15
    {
        public static int LastSpoken(int[] numbers, int stop)
        {
            int[] spoken = new int[stop];
            for (int i = 0; i < numbers.Length - 1; i++)
                spoken[numbers[i]] = i + 1;

            int lastSpoken = numbers[^1];
            for (int turn = numbers.Length; turn < stop; turn++)
            {
                int previous = spoken[lastSpoken];
                spoken[lastSpoken] = turn;
                lastSpoken = (previous != 0) ? turn - previous : 0;
            }
            return lastSpoken;
        }
    }
}
