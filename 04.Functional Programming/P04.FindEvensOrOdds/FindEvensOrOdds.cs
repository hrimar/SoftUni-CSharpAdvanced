using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            // Var 1: Тъпо решение за 100/100:
            //var minMax = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();
            //var minOrMax = minMax[0];
            //var maxOrMin = minMax[1];

            //var min = Math.Min(maxOrMin, minOrMax);
            //var max = Math.Max(maxOrMin, minOrMax);

            //var condition = Console.ReadLine();

            //Predicate<string> isEven = x => x == "even";

            //if(isEven(condition))
            //{
            //    for (int i = min; i <= max; i++)
            //    {
            //        if(Math.Abs(i % 2) == 0)
            //        {
            //            Console.Write($"{i} ");
            //        }
            //    }
            //    Console.WriteLine();
            //}
            //else
            //{
            //    for (int i = min; i <= max; i++)
            //    {
            //        if (Math.Abs(i % 2) == 1)
            //        {
            //            Console.Write($"{i} ");
            //        }
            //    }
            //    Console.WriteLine();
            //    //nums.Where(x => x % 2 == 0).ToList().ForEach(x => Console.WriteLine(x));
            //}

            // Ver 2: Better решение за 100/100 with Predicate or Func:
            var minMax = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            var minOrMax = minMax[0];
            var maxOrMin = minMax[1];

            var min = Math.Min(maxOrMin, minOrMax);
            var max = Math.Max(maxOrMin, minOrMax);

            var condition = Console.ReadLine();
                        
            Func<int, bool> func;
            // Predicate<int> predicate; // also may use Predicate<int>

            switch (condition)
            {                
                case "odd":
                    func = n => n % 2 != 0;
                    break;
                case "even":
                    func = n => n % 2 == 0;
                    break;
                default:
                    func = null;
                    break;
            }

            var result = EvensOrOdds(min, max, func);

            Console.WriteLine(string.Join(" ", result));
        }

        private static Queue<int> EvensOrOdds(int min, int max, Func<int, bool> func)
        {
           var result = new Queue<int>();

            for (int i = min; i <= max; i++)
            {
                if(func(i))
                {
                    result.Enqueue(i);
                }
            }

            return result;
        }
    }
}
