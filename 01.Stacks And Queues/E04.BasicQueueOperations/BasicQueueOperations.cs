using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main()  // 100/100
        {
            var inputArray = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var elementsToEnqueue = inputArray[0];
            var elementsToDequeue = inputArray[1];
            var surchedElements = inputArray[2];

            // 1 adding elements:
            var numbers = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            // 2 removing elements:
            while(elementsToDequeue>0)
            {
                queue.Dequeue();
                elementsToDequeue--;
            }
            if(queue.Contains(surchedElements))
            {
                   Console.WriteLine("true");
            }
            else
            {
                if(queue.Count>0)
                    Console.WriteLine(queue.Min());
                else
                    Console.WriteLine(0);
            }
            
        }
    }
}
