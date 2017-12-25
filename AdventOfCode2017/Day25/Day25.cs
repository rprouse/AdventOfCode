using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public static class Day25
    {
        public static int PartOne(string filename)
        {
            var turing = new Turing(filename);
            return turing.Run();
        }

        public static int PartTwo(string filename)
        {
            string[] lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            return 0;
        }

        public class Turing
        {
            static Regex StepsRegEx = new Regex(@"\d+");
            Dictionary<char, State> _states = new Dictionary<char, State>();
            Dictionary<int, int> _tape = new Dictionary<int, int>();
            int _ptr = 0;
            int _steps = 0;
            char _state;

            public Turing(string filename)
            {
                var lines = File.ReadAllLines(filename).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                _state = lines[0][15];

                var stepMatch = StepsRegEx.Match(lines[1]);
                int.TryParse(stepMatch.Value, out _steps);
                for(int i = 2; i < lines.Length; i += 9)
                {
                    char state = lines[i][9];
                    var zero = ReadInstruction(lines, i + 2);
                    var one = ReadInstruction(lines, i + 6);
                    _states.Add(state, new State(zero, one));
                }
                _tape[_ptr] = 0;
            }

            static Instruction ReadInstruction(string[] lines, int offset)
            {
                int write = lines[offset][22] == '0' ? 0 : 1;
                int move = lines[offset + 1][27] == 'r' ? 1 : -1;
                char state = lines[offset + 2][26];
                return new Instruction(write, move, state);
            }

            public int Run()
            {
                foreach(int i in Enumerable.Range(0, _steps))
                {
                    var state = _states[_state];
                    var instruction = state.Instructions[_tape[_ptr]];
                    _tape[_ptr] = instruction.Write;
                    _state = instruction.Continue;
                    _ptr += instruction.Move;
                    if (!_tape.ContainsKey(_ptr)) _tape[_ptr] = 0;
                }
                return Checksum;
            }

            public int Checksum => _tape.Values.Count(s => s == 1);
        }

        public struct State
        {
            public Instruction[] Instructions;

            public State(Instruction zero, Instruction one)
            {
                Instructions = new[] { zero, one };
            }
        }

        public struct Instruction
        {
            public int Write { get; }
            public int Move { get; }
            public char Continue { get; }

            public Instruction(int write, int move, char cont)
            {
                Write = write;
                Move = move;
                Continue = cont;
            }
        }
    }
}
