using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.CustomComparator
{
    class CustomComparator
    {
        static void Main()      // 100/100
        {
            var nums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var evenList = new List<int>();
            var oddList = new List<int>();

            Func<int, bool> evenFilter = x => Math.Abs(x % 2 )== 0;
            Func<int, bool> oddFilter = x => Math.Abs(x % 2 ) == 1;
           
            for (int i = 0; i < nums.Length; i++)
            {                
                    if(evenFilter(nums[i]) )
                    {
                        evenList.Add(nums[i]);
                    }
                    else if (oddFilter(nums[i]))
                    {
                       oddList.Add(nums[i]);
                    }                
            }
            evenList.Sort();
            oddList.Sort();

           Console.WriteLine(string.Join(" ", (evenList.Concat(oddList))));

            // Забл: Има и вграден интерфейс за сравняване на данни. Правиш си клас, наследяващ интерфейса, и сравняваме ст-те в кол-ята:
            // Array.Sort(nums, new CustomComparator());
        }
    }
}
