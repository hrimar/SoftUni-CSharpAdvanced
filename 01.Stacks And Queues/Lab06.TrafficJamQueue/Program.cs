using System;
using System.Collections.Generic;

namespace Lab06.TrafficJamQueue
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var queueCars = new Queue<string>();

            var input = Console.ReadLine();
            var count = 0;
            while (input != "end")
            {                
                if (input == "green")
                {
                    var carsThatCanPass = Math.Min(queueCars.Count, n);
                    for (int i = 0; i < carsThatCanPass; i++)
                    {
                       var passedCar = queueCars.Dequeue();
                        Console.WriteLine($"{passedCar} passed!");
                        count++;
                    }
                }
                else
                {
                    queueCars.Enqueue(input);
                }                

                input = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
