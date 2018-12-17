using System;

namespace AdventOfCode2018.DaySixteen
{
    public class Computer
    {
        public int[] Registers { get; } = new int[4];

        public Func<int, int, int, int[]>[] Opcodes { get; } =
            new Func<int, int, int, int[]>[16];

        public Computer()
        {
            Opcodes[0] = Bani;
            Opcodes[1] = Banr;
            Opcodes[2] = Muli;
            Opcodes[3] = Setr;
            Opcodes[4] = Bori;
            Opcodes[5] = Eqrr;
            Opcodes[6] = Gtir;
            Opcodes[7] = Mulr;
            Opcodes[8] = Gtrr;
            Opcodes[9] = Seti;
            Opcodes[10] = Gtri;
            Opcodes[11] = Eqri;
            Opcodes[12] = Addi;
            Opcodes[13] = Borr;
            Opcodes[14] = Eqir;
            Opcodes[15] = Addr;
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

        public void ExecuteOperation(int o, int a, int b, int c)
        {
            Opcodes[o](a, b, c);
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
