using System.Text;

namespace AdventOfCode2015
{
    public static class Day04
    {
        public static int PartOne(string secret)
        {
            return MD5AStartsWith(secret, "00000");
        }

        public static int PartTwo(string secret)
        {
            return MD5AStartsWith(secret, "000000");
        }

        private static int MD5AStartsWith(string secret, string startsWith)
        {
            int i = 1;
            while (true)
            {
                string txt = $"{secret}{i}";
                string hash = CreateMD5(txt);
                if (hash.StartsWith(startsWith))
                    return i;
                i++;
            }
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
