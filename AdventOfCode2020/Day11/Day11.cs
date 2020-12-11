namespace AdventOfCode2020
{
    public static class Day11
    {
        public static int PartOne(string filename)
        {
            var area = new WaitingAreaOne(filename);
            area.RunToStability();
            return area.OccupiedSeats();
        }

        public static int PartTwo(string filename)
        {
            var area = new WaitingAreaTwo(filename);
            area.RunToStability();
            return area.OccupiedSeats();
        }
    }
}
