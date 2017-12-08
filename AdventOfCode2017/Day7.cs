using System;
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

        public static int BalanceTower(this IEnumerable<Program> programs)
        {
            IList<Program> from = programs.ToList();
            string code = programs.FindRootProgram();
            var root = HookupChildren(code, from);

            return FindBalance(root);
        }

        public static int FindBalance(Program node)
        {
            var weights = node.Children.Select(c => c.WeightWithChildren()).Distinct().ToArray();
            if (weights.Length == 2)
            {
                var one = node.Children.Count(c => c.WeightWithChildren() == weights[0]);
                var two = node.Children.Count(c => c.WeightWithChildren() == weights[1]);

                var needsChange = node.Children.First(c => c.WeightWithChildren() == weights[one == 1 ? 0 : 1]);
                if (needsChange.Children.Count > 1 && needsChange.Children.Select(c => c.WeightWithChildren()).Distinct().Count() > 1)
                    return FindBalance(needsChange);

                if (one == 1)
                {
                    return needsChange.Weight - (weights[0] - weights[1]);
                }
                else
                {
                    return needsChange.Weight - (weights[1] - weights[0]);
                }
            }
            foreach(var child in node.Children)
            {
                int balance = FindBalance(child);
                if (balance != -1) return balance;
            }
            return -1;
        }

        static Program HookupChildren(string code, IList<Program> from)
        {
            Program root = from.FindProgram(code);
            from.Remove(root);
            foreach(string childCode in root.ChildCodes)
            {
                root.Children.Add(HookupChildren(childCode, from));
            }
            return root;
        }

        static Program FindProgram(this IList<Program> list, string code) =>
            list.First(p => p.Code == code);
    }

    public class Program
    {
        static Regex regex = new Regex(
            "^(?<Code>[a-zA-Z]+)\\s\\((?<Weight>\\d+)\\)(?<Children>.*)$",
            RegexOptions.CultureInvariant
            | RegexOptions.Compiled );

        public string Code { get; }
        public int Weight { get; }
        public IList<string> ChildCodes { get; } = new List<string>();
        public IList<Program> Children { get; } = new List<Program>();

        public Program(string info)
        {
            Match m = regex.Match(info);
            if(m.Success)
            {
                Code = m.Groups["Code"].Value;

                string weight = m.Groups["Weight"].Value;
                if (int.TryParse(weight, out int w))
                    Weight = w;
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

        int _weightWithChildren = -1;

        public int WeightWithChildren()
        {
            if (_weightWithChildren == -1)
            {
                _weightWithChildren = Weight;
                foreach (var child in Children)
                {
                    _weightWithChildren += child.WeightWithChildren();
                }
            }
            return _weightWithChildren;
        }

        public bool HasChildren => ChildCodes.Count > 0;

        public bool ContainsChild(string code) => ChildCodes.Contains(code);

        public override bool Equals(object obj) => (obj as Program)?.Code == Code;

        public override int GetHashCode() => Code.GetHashCode();
    }
}
