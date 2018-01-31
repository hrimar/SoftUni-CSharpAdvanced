using System;
using System.Collections.Generic;
using System.Linq;

namespace E02.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main() // 100/100
        {
            // Извод: Не може от кол-я с Count=0 да казваме stack.Min() !!!

            var elements = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var elementsToPush = elements[0];
            var elementsPop = elements[1];
            var surchedElements = elements[2];

            var stackElements = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var stack = new Stack<int>(stackElements);

            for (int i = 0; i < elementsPop; i++)
            {
                stack.Pop();
            }

            if(stack.Contains(surchedElements))
            {
                Console.WriteLine("true");
            }
            else if(stack.Count>0)  // !!!
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
