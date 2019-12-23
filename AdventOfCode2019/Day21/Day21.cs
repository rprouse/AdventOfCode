using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2019
{
    public static class Day21
    {
        public static int PartOne(string filename)
        {
            long[] program = filename.SplitLongs();
            var droid = new SpringDroid(program);
            return 0;
        }

        public static int PartTwo(string filename)
        {
            long[] program = filename.SplitLongs();
            return 0;
        }
    }

    public class SpringDroid : EventDrivenIntcodeComputer
    {
        bool T { get; set; }
        bool J { get; set; }

        bool A { get; set; }
        bool B { get; set; }
        bool C { get; set; }
        bool D { get; set; }

        public SpringDroid(long[] program) : base(program)
        {

        }
    }
}
