using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace E01.ReverseNumbersWithStack
{
    class ReverseNumbersWithStack
    {
        static void Main()
        {
            var input = Console.ReadLine();
 
            if(String.IsNullOrEmpty(input)) //  !!!
            {
                Console.WriteLine("");
            }
            else
            {
                var inputArray = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                var stack = new Stack<long>(inputArray);

                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop() + " ");
                }

                // or:
                //Console.WriteLine(string.Join(" ", stack)); // защото стака държи елем-те на обратно!!!
            }
          
        }
    }
}
