using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public static class Day8
    {
        public static IEnumerable<Instruction> ReadInstructions(string filename) =>
            LineReader.ReadLines(filename).Select(l => new Instruction(l));

        public static IDictionary<string, int> RunProgram(this IEnumerable<Instruction> instructions, out int max)
        {
            max = 0;
            IDictionary<string, int> registers = new Dictionary<string, int>();
            foreach (var instruction in instructions)
            {
                instruction.Apply(registers);
                int currentMax = registers.FindLargestRegister();
                if (currentMax > max) max = currentMax;
            }
            return registers;
        }

        public static int FindLargestRegister(this IDictionary<string, int> registers) =>
            registers.Values.Max();
    }

    public class Instruction
    {
        public static Regex regex = new Regex(
                "^(?<Register>[a-zA-Z]+)\\s(?<Op>\\w\\w\\w)\\s(?<Increme" +
                "nt>-?\\d+)\\sif\\s(?<Target>[a-zA-Z]+)\\s(?<Operator>[<>!=]+" +
                ")\\s(?<Conditional>-?\\d+)",
                RegexOptions.CultureInvariant
                | RegexOptions.Compiled
           );

        public string Register { get; }
        public int Increment { get; }
        public string TargetRegister { get; }
        public string Opererator { get; }
        public int ConditionalValue { get; }

        public Instruction(string line)
        {
            Match m = regex.Match(line);
            if (m.Success)
            {
                Register = m.Groups["Register"].Value;
                string op = m.Groups["Op"].Value;
                string inc = m.Groups["Increment"].Value;
                if (int.TryParse(inc, out int i))
                {
                    if (op == "dec")
                        Increment = -i;
                    else
                        Increment = i;
                }
                TargetRegister = m.Groups["Target"].Value;
                Opererator = m.Groups["Operator"].Value;
                string cond = m.Groups["Conditional"].Value;
                if (int.TryParse(cond, out int j))
                    ConditionalValue = j;
            }
        }

        /// <summary>
        /// Applies the current instruction to the registers
        /// </summary>
        /// <param name="registers"></param>
        public void Apply(IDictionary<string, int> registers)
        {
            // Do the registers exist? If not, add them
            if (!registers.ContainsKey(Register)) registers.Add(Register, 0);
            if (!registers.ContainsKey(TargetRegister)) registers.Add(TargetRegister, 0);

            if (MeetsCondition(registers))
                registers[Register] += Increment;
        }

        bool MeetsCondition(IDictionary<string, int> registers)
        {
            int val = registers[TargetRegister];
            return (Opererator == "==" && val == ConditionalValue) ||
                   (Opererator == "!=" && val != ConditionalValue) ||
                   (Opererator == "<"  && val <  ConditionalValue) ||
                   (Opererator == ">"  && val >  ConditionalValue) ||
                   (Opererator == "<=" && val <= ConditionalValue) ||
                   (Opererator == ">=" && val >= ConditionalValue);
        }
    }
}
