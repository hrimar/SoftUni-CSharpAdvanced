using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main()
        {
            //// Var 1: 80/100 - too much used memory!
            //var n = int.Parse(Console.ReadLine());

            //var nums = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .Distinct()
            //    .ToArray();

            //var result = new List<int>();

            //bool isAllDevided = false;

            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 0; j < nums.Length; j++)
            //    {
            //        Func<int, bool> deviderFilter = x => x % nums[j] == 0;

            //        if ( deviderFilter(i))
            //        {
            //            isAllDevided = true;                    
            //        }
            //        else
            //        {
            //            isAllDevided = false;
            //            break;
            //        }
            //    }
            //    if(isAllDevided)
            //    {
            //        result.Add(i);
            //    }
            //}

            //Console.WriteLine(string.Join(" ", result));

            //// Var 2:  80/100 - too much used memory!
            //var n = int.Parse(Console.ReadLine());

            //var nums = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .Distinct()
            //    .ToArray();

            //var result = new List<int>();                   

            //for (int i = 1; i <= n; i++)
            //{
            //    bool isAllDevided = true;

            //    foreach (var num in nums)                
            //    {
            //        Func<int, bool> deviderFilter = x => x % num == 0;

            //        if (!deviderFilter(i))
            //        {
            //            isAllDevided = false;
            //            break;
            //        }

            //    }
            //    if (isAllDevided)
            //    {
            //        result.Add(i);
            //    }
            //}

            //Console.WriteLine(string.Join(" ", result));

            // Var 3 : 100/100 !!!
            var n = int.Parse(Console.ReadLine());

            var nums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            var result = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                result.Add(i);
            }

            Func<int, bool> predicate = CreatePredicate(nums);

            result = result.Where(predicate).ToList();

            Console.WriteLine(string.Join(" ", result));
        }

        private static Func<int, bool> CreatePredicate(int[] nums)
        {
            //// да върна число х само ако вскички от кол-ята отговарят на усл-то ж % n == 0
            //return x => nums.All(n => x % n == 0); // Хитро, но пак 80/100

            // Тка е 100/100
            return n =>
            {
                foreach (var num in nums)
                {
                    if (n % num != 0)
                    {
                        return false;
                    }
                }
                return true;
            };

        }
    }
}
