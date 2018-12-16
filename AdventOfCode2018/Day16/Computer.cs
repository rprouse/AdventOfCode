using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.DaySixteen
{
    public class Computer
    {
        public int[] Registers { get; } = new int[4];

        public Func<int, int, int, int[]>[] Opcodes =
            new Func<int, int, int, int[]>[16];

        public Computer()
        {
            Opcodes[0] = Addr;
            Opcodes[1] = Addi;
            Opcodes[2] = Mulr;
            Opcodes[3] = Muli;
            Opcodes[4] = Banr;
            Opcodes[5] = Bani;
            Opcodes[6] = Borr;
            Opcodes[7] = Bori;
            Opcodes[8] = Setr;
            Opcodes[9] = Seti;
            Opcodes[10] = Gtir;
            Opcodes[11] = Gtri;
            Opcodes[12] = Gtrr;
            Opcodes[13] = Eqir;
            Opcodes[14] = Eqri;
            Opcodes[15] = Eqrr;
        }

        public Computer(int a, int b, int c, int d) : this()
        {
            SetRegisters(a, b, c, d);
        }

        public void SetRegisters(int a, int b, int c, int d)
        {
            Registers[0] = a;
            Registers[1] = b;
            Registers[2] = c;
            Registers[3] = d;
        }

        public int[] Addr(int a, int b, int c)
        {
            Registers[c] = Registers[a] + Registers[b];
            return Registers;
        }

        public int[] Addi(int a, int b, int c)
        {
            Registers[c] = Registers[a] + b;
            return Registers;
        }

        public int[] Mulr(int a, int b, int c)
        {
            Registers[c] = Registers[a] * Registers[b];
            return Registers;
        }

        public int[] Muli(int a, int b, int c)
        {
            Registers[c] = Registers[a] * b;
            return Registers;
        }

        public int[] Banr(int a, int b, int c)
        {
            Registers[c] = Registers[a] & Registers[b];
            return Registers;
        }

        public int[] Bani(int a, int b, int c)
        {
            Registers[c] = Registers[a] & b;
            return Registers;
        }

        public int[] Borr(int a, int b, int c)
        {
            Registers[c] = Registers[a] | Registers[b];
            return Registers;
        }

        public int[] Bori(int a, int b, int c)
        {
            Registers[c] = Registers[a] | b;
            return Registers;
        }

        public int[] Setr(int a, int b, int c)
        {
            Registers[c] = Registers[a];
            return Registers;
        }

        public int[] Seti(int a, int b, int c)
        {
            Registers[c] = a;
            return Registers;
        }

        public int[] Gtir(int a, int b, int c)
        {
            Registers[c] = a > Registers[b] ? 1 : 0;
            return Registers;
        }

        public int[] Gtri(int a, int b, int c)
        {
            Registers[c] = Registers[a] > b ? 1 : 0;
            return Registers;
        }

        public int[] Gtrr(int a, int b, int c)
        {
            Registers[c] = Registers[a] > Registers[b] ? 1 : 0;
            return Registers;
        }

        public int[] Eqir(int a, int b, int c)
        {
            Registers[c] = a == Registers[b] ? 1 : 0;
            return Registers;
        }

        public int[] Eqri(int a, int b, int c)
        {
            Registers[c] = Registers[a] == b ? 1 : 0;
            return Registers;
        }

        public int[] Eqrr(int a, int b, int c)
        {
            Registers[c] = Registers[a] == Registers[b] ? 1 : 0;
            return Registers;
        }
    }
}
