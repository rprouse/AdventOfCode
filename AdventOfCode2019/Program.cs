using System;
using System.Threading.Tasks;
using AdventOfCode.Core;
using NUnit.Framework;

[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace AdventOfCode2019
{
    public static class ProgramEntry
    {
        public static async Task Main()
        {
            PlayBreakout();

            Console.ResetColor();
            Console.ReadLine();

            await Task.FromResult(false);
        }

        private static void PlayBreakout()
        {
            long[] program = TestBase.PuzzleFile(13).SplitLongs();
            program[0] = 2;
            var game = new ArcadeCabinet(program);
            game.OutputAvailable += Game_OutputAvailable;
            game.RunProgram();
        }

        private static void Game_OutputAvailable(object sender, EventArgs e)
        {
            var game = sender as ArcadeCabinet;
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.Write(game.ToString());
        }
    }
}
