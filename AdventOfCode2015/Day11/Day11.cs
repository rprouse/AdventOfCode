using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode2015
{
    public static class Day11
    {
        public static string PartOne(string password)
        {
            while(!IsValid(password))
            {
                password = IncrementPassword(password);
            }
            return password;
        }

        internal static string IncrementPassword(string password)
        {
            var result = password.ToArray();
            result[password.Length - 1]++;
            bool carry = false;
            for(int i = password.Length - 1; i >= 0; i--)
            {
                if (carry) result[i]++;
                carry = false;

                if(result[i] > 'z')
                {
                    result[i] = 'a';
                    carry = true;
                }
            }
            return string.Join("", result);
        }

        public static bool IsValid(string password)
        {
            if ( password.Contains('i') ||
                 password.Contains('o') ||
                 password.Contains('l'))
                return false;

            int pairs = 0;
            for (int i = 0; i < password.Length - 1; i++)
            {
                if(password[i] == password[i+1])
                {
                    pairs++;
                    i++;
                }
            }

            bool straight = false;
            for(int i = 0; i < password.Length - 2; i++)
            {
                if(password[i] == (password[i+1] - 1) &&
                   password[i] == (password[i+2] - 2))
                {
                    straight = true;
                    break;
                }
            }

            return straight && pairs >= 2;
        }

        public static string PartTwo(string password)
        {
            while (!IsValid(password))
            {
                password = IncrementPassword(password);
            }
            password = IncrementPassword(password);
            while (!IsValid(password))
            {
                password = IncrementPassword(password);
            }
            return password;
        }
    }
}
