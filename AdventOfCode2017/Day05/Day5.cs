namespace AdventOfCode2017
{
    public static class Day5
    {
        public static int CountJumps(this int[] instuctions)
        {
            int jumps = 0;
            int pointer = 0;
            while(pointer >= 0 && pointer < instuctions.Length)
            {
                int jump = instuctions[pointer];
                instuctions[pointer]++;
                pointer += jump;
                jumps++;
            }
            return jumps;
        }
        public static int CountJumpsPartTwo(this int[] instuctions)
        {
            int jumps = 0;
            int pointer = 0;
            while (pointer >= 0 && pointer < instuctions.Length)
            {
                int jump = instuctions[pointer];
                if (jump >= 3)
                    instuctions[pointer]--;
                else
                    instuctions[pointer]++;
                pointer += jump;
                jumps++;
            }
            return jumps;
        }
    }
}
