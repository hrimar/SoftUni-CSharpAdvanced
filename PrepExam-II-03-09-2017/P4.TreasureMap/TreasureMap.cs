using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P4.TreasureMap
{
    class TreasureMap       //  100/100
    {
        static void Main()
        {
            var regex = new Regex(@"((?<hash>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?(?(hash)!|#)");
            var result = new List<string>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                  var input = Console.ReadLine();

                var matches = regex.Matches(input);

                var correctMatch = matches[matches.Count / 2]; // !!!

                string streetNumber = correctMatch.Groups["streetNumber"].Value;
                string streetName = correctMatch.Groups["streetName"].Value;
                string password = correctMatch.Groups["password"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
                
                //foreach (Match match in matches)
                //{                    
                //    Console.WriteLine(match.ToString());
                //}
            }
            
            //var maches = regex.Matches(input).Cast<Match>().Select(a => a.Groups["1"].Value).ToArray();

        }
    }
}
