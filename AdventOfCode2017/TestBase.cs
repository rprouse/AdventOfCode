namespace AdventOfCode2017
{
    public abstract class TestBase
    {
        private int _day;

        public TestBase(int day)
        {
            _day = day;
        }

        public string TestFile => $"Day{_day}\\Test.txt";

        public string PuzzleFile => $"Day{_day}\\Data.txt";
    }
}
