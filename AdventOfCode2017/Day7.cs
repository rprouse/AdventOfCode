using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public static class Day7
    {
        public static IEnumerable<Program> ReadPrograms(string filename) =>
            LineReader.ReadLines(filename).Select(l => new Program(l));

        public static string FindRootProgram(this IEnumerable<Program> programs)
        {
            var candidates = programs.Where(p => p.HasChildren).ToList();
            return candidates.Single(p1 => !candidates.Any(p2 => p2.ContainsChild(p1.Code))).Code;
        }
    }

    public class Program
    {
        static Regex regex = new Regex(
            "^(?<Code>[a-zA-Z]+)\\s\\((?<Weight>\\d+)\\)(?<Children>.*)$",
            RegexOptions.CultureInvariant
            | RegexOptions.Compiled );

        public string Code { get; }
        public string Weight { get; }
        public IList<string> ChildCodes { get; } = new List<string>();
        public IList<Program> Children { get; } = new List<Program>();

        public Program(string info)
        {
            Match m = regex.Match(info);
            if(m.Success)
            {
                Code = m.Groups["Code"].Value;
                Weight = m.Groups["Weight"].Value;
                string children = m.Groups["Children"].Value;
                if(children.Length > 3)
                {
                    foreach (var code in children.Substring(4).Split(", "))
                    {
                        ChildCodes.Add(code);
                    }
                }
            }
        }

        public bool HasChildren => ChildCodes.Count > 0;

        public bool ContainsChild(string code) => ChildCodes.Contains(code);
    }
}
