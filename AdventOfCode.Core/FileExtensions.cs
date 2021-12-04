using System.IO;
using System.Linq;

namespace AdventOfCode.Core
{
    public static class FileExtensions
    {
        /// <summary>
        /// Reads in a file in the format `1, 2, 3, -4` as a series of ints
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int[] SplitInts(this string filename) =>
            filename.SplitStrings()
                .Select(s => s.ToInt())
                .ToArray();

        /// <summary>
        /// Reads in a file in the format `1, 2, 3, -4` as a series of ints
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static long[] SplitLongs(this string filename) =>
            filename.SplitStrings()
                .Select(s => s.ToLong())
                .ToArray();

        /// <summary>
        /// Reads a file with one int per line
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int[] GetInts(this string filename) =>
            filename.ReadAllLines()
                .Select(l => l.ToInt())
                .ToArray();

        /// <summary>
        /// Reads a file with one long per line
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static long[] GetLongs(this string filename) =>
            filename.ReadAllLines()
                .Select(l => l.ToLong())
                .ToArray();

        /// <summary>
        /// Reads a file in the format `a, b, cee, dee` as a series of string
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string[] SplitStrings(this string filename) =>
            filename.ReadFirstLine()
                .Split(',', ' ');

        /// <summary>
        /// Returns the first line of a file as a string
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ReadFirstLine(this string filename) =>
            File.ReadLines(filename)
                .First()
                .Trim();

        /// <summary>
        /// Reads all lines in a file and returns them as an array of lines
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string[] ReadAllLines(this string filename) =>
            File.ReadAllLines(filename)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();

        /// <summary>
        /// Reads all lines in a file including blank lines and returns them as an array of lines
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string[] ReadAllLinesIncludingBlank(this string filename) =>
            File.ReadAllLines(filename)
                .ToArray();

        /// <summary>
        /// Reads all text in a file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ReadAll(this string filename) =>
            File.ReadAllText(filename);
    }
}
