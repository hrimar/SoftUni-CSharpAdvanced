using System;
using System.Collections.Generic;

namespace Lab05.HotPotatoWithQueue
{
    class Program
    {
        static void Main()
        {

            var input = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(input);

            while (queue.Count != 1)
            {
                for (int i = 1; i < n; i++)
                {
                    queue.Enqueue(queue.Dequeue()); // Така местим 1-вия елем от опашката                 
                }
               var removed = queue.Dequeue();
                Console.WriteLine($"Removed {removed}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
