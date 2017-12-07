using System;

namespace AdventOfCode2017
{
    public static class Day1
    {
        public static int CalculateCaptcha(string captcha)
        {
            int sum = 0;
            for (int i = 0; i < captcha.Length; i++)
            {
                int j = i == captcha.Length - 1 ? 0 : i + 1;
                if(captcha[i] == captcha[j])
                {
                    sum += captcha[i] - '0';
                }
            }
            return sum;
        }
    }
}
