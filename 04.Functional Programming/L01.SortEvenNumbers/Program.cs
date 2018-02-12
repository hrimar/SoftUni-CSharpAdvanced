using System;
using System.Linq;

namespace L01.SortEvenNumbers
{
    class Program
    {
        static void Main()
        {
            // Var 1:
            var nums = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n);  // така n е int и дава грешен резултат (2, 4, 012)
                                   //.ToArray(); - ако не го сложим тук, то ще изпълнят филтрите долу на ред 22!

            // Var 2 - грешен!
            //var nums = Console.ReadLine()
            //   .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            //   .Where(n => int.Parse(n) % 2 == 0)
            //   .OrderBy(n => n); // така n е string и дава грешен резултат (012, 2, 4)

            // var 3 - грешен, остава , накрая!
            //Console.ReadLine()
            //    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .Where(n => n % 2 == 0)
            //    .OrderBy(n => n)  // така n е int и дава грешен резултат (2, 4, 012)
            //    .ToList()
            //    .ForEach(n => Console.WriteLine(n));

            Console.WriteLine(string.Join(", ", nums));
            
        }
    }
}
