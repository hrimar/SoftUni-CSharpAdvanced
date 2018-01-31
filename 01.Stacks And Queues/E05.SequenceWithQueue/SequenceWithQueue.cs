using System;
using System.Collections.Generic;

namespace E05.SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void Main()
        {
            // Решение 2 - 100/100 - с int даваше 60/100::
            var currentElement = long.Parse(Console.ReadLine());

            var queue1 = new Queue<long>();
            var queue2 = new Queue<long>();
            var queue3 = new Queue<long>();

            queue1.Enqueue(currentElement);

            while (queue1.Count < 50)
            {
                queue1.Enqueue(currentElement + 1);
                queue2.Enqueue(currentElement + 1);

                if (queue1.Count < 50)
                {
                    queue1.Enqueue(2 * currentElement + 1);
                    queue2.Enqueue(2 * currentElement + 1);
                }

                if (queue1.Count < 50)
                {
                    queue1.Enqueue(currentElement + 2);
                    queue2.Enqueue(currentElement + 2);
                    currentElement = queue2.Dequeue();
                }
            }
            Console.WriteLine(string.Join(" ", queue1));

            //  Мое Решение 1 -  100/100 - с int даваше 60/100:
            var n = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(n);
            var element1 = n;
            var element = new long[53];
            element[0] = n;

            var element2 = element1 + 1;
            var element3 = 2 * element1 + 1;
            var element4 = element1 + 2;
            for (int i = 1, j = 1; i < 50; i += 3, j += 2)
            {
                element[i] = element[i - j] + 1;
                element[i + 1] = 2 * element[i - j] + 1;
                element[i + 2] = element[i - j] + 2;
                if (queue.Count >= 50)
                {
                    break;
                }
                queue.Enqueue(element[i]);
                if (queue.Count >= 50)
                {
                    break;
                }
                queue.Enqueue(element[i + 1]);
                if (queue.Count >= 50)
                {
                    break;
                }
                queue.Enqueue(element[i + 2]);
            }

            Console.WriteLine(string.Join(" ", queue));
        }
    }
}
