namespace AdventOfCode2019
{
    public class TractorDrone : EventDrivenIntcodeComputer
    {
        public static int Count { get; set; } = 0;

        public TractorDrone(long[] program, long x, long y) : base(program)
        {
            Input.Enqueue(x);
            Input.Enqueue(y);
        }
    }
}
