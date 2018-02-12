using System;
using System.Linq;

namespace P07.PredicateForNames
{
    class PredicateForNames
    {
        static void Main()       //  100 / 100
        {
            var n = int.Parse(Console.ReadLine());

            var words = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, bool> func = x => x.Length <= n;

            foreach (var word in words)
            {
                if (func(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
