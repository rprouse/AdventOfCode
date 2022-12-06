using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode2022;

internal class Move
{
    static Regex regex = new Regex(
      "move (\\d+) from (\\d+) to (\\d+)",
       RegexOptions.CultureInvariant | RegexOptions.Compiled
    );

    public int BoxesToMove { get; }
    public int From { get; }
    public int To { get; }

    public Move(string line)
    {
        Match match = regex.Match(line);
        BoxesToMove = match.Groups[1].Value.ToInt();
        From = match.Groups[2].Value.ToInt() - 1;
        To = match.Groups[3].Value.ToInt() - 1;
    }
}