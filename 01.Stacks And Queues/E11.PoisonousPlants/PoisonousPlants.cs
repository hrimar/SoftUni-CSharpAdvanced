using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E11.PoisonousPlants
{
    class PoisonousPlants
    {
        static void Main()
        {
            //  Var 2: 100/100 Бреее....
            int n = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] days = new int[plants.Length];
            Stack<int> proximityStack = new Stack<int>();
            proximityStack.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (proximityStack.Count > 0 && plants[proximityStack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[proximityStack.Pop()]);
                }
                if (proximityStack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                proximityStack.Push(i);
            }
            Console.WriteLine(days.Max());


            //  Var 1: 33 / 100 - гърми за памет и време
            //var n = int.Parse(Console.ReadLine());
            //var plans = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            //bool hasDying = true;
            //var days = 0;

            //var stack = new Stack<long>();

            //while (hasDying)
            //{
            //    for (int i = 1; i < plans.Length; i++)
            //    {
            //        if (i == 1)
            //        {
            //            stack.Push(plans[0]);
            //        }

            //        if (plans[i] < plans[i - 1])
            //        {
            //            stack.Push(plans[i]);
            //            hasDying = true;
            //        }
            //        else
            //        {
            //            hasDying = false;
            //        }
            //    }
            //    plans = stack.Reverse().ToArray();
            //    days++;
            //    stack.Clear();
            //}
            //Console.WriteLine(days);
        }
    }
}
