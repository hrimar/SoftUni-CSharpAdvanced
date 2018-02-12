using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace P1_Regeh
{
    class Regeh
    {
        static void Main()      // 100/100 za 1:30
        {
            var input = Console.ReadLine();
            //Console.WriteLine(input.Length);

            var regex = new Regex(@"\[[a-zA-Z]+<(?<index1>\d+)REGEH(?<index2>\d+)>[a-zA-Z]+\]");
            var machedIndexes1 = regex.Matches(input).Cast<Match>().Select(a=>a.Groups["index1"].Value).ToArray();
            var machedIndexes2 = regex.Matches(input).Cast<Match>().Select(a => a.Groups["index2"].Value).ToArray();
            var indexes = new int[machedIndexes1.Length*2];
            if (indexes.Length==0 )
            {
                Environment.Exit(0);      // return; 
            }
            for (int i = 0, j=0; i < machedIndexes1.Length; i++, j+=2)
            {
                indexes[j] = int.Parse(machedIndexes1[i]);
                indexes[j+1] = int.Parse(machedIndexes2[i]);
            }

            for (int i = 0, j=0; i < indexes.Length; i++)
            {
                var index = (indexes[i] + j) % input.Length;

                if (index< input.Length)
                {
                    Console.Write(input[index]);
                }
                
                j += indexes[i];
            }
            Console.WriteLine();
            //Console.WriteLine(string.Join(" ", indexes));           
        }
    }
}
