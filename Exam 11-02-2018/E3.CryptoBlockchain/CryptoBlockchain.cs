using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace E3.CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main()  // 100
        {
            int n = int.Parse(Console.ReadLine());

            string blockchain = string.Empty;
            for (int i = 0; i < n; i++)
            {
                blockchain += Console.ReadLine();
            }

            Regex rgx = new Regex(@"(?:(?<bracket>{)|\[)[^0-9]*(?<digits>\d*)[^0-9]*(?(bracket)}|\])");

            StringBuilder sb = new StringBuilder();

            foreach (Match match in rgx.Matches(blockchain))
            {
                string digits = match.Groups["digits"].Value;

                if (digits.Length == 0 || digits.Length % 3 != 0)
                {
                    continue;
                }

                for (int numberIndex = 0; numberIndex < digits.Length / 3; numberIndex++)
                {
                    sb.Append((char)(int.Parse(digits.Substring(3 * numberIndex, 3)) - match.Value.Length));
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
