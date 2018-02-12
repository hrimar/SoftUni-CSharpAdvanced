using System;
using System.Collections.Generic;
using System.Linq;

namespace P2.CryptoMaster
{
    class Program   // 100/100
    {
        static void Main() // Хитър алгоритъм!
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxCont = int.MinValue;
            for (int stemp = 1; stemp < input.Length; stemp++)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    int count = 0;
                    int currentIndex = i;
                    int nextIndex = (i + stemp) % input.Length;
                    while (input[currentIndex] < input[nextIndex])
                    {
                        count++;
                        currentIndex = nextIndex % input.Length;
                        nextIndex = (nextIndex + stemp) % input.Length;
                    }

                    if (count > maxCont)
                    {
                        maxCont = count;
                    }
                }

            }
            Console.WriteLine(maxCont + 1);
        }
    }
}
