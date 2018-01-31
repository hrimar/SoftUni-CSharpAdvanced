using System;
using System.Collections.Generic;
using System.Linq;

namespace E06.TruckTour
{
    class TruckTour
    {
        static void Main() // 100/100 - ТРЯБВА ДА Я РАЗБЕРА ТАЗИ ЗАДАЧА И ТЕЗИ ОПАШКИ!!!
                           // ИЗВОД: Позваме опашкат асамо да за да държим последователността от безниностанции!
        {
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<int[]>(); // !!!

            //1. Вкарваме всички помпи в опашка
            for (int i = 0; i < n; i++)
            {
                var pump = Console.ReadLine().Split().Select(int.Parse).ToArray();

                queue.Enqueue(pump);
            }

            // 2. 
            for (int currentStart = 0; currentStart < n - 1; currentStart++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                {
                    int[] currentPump = queue.Dequeue();
                    int pumpFuel = currentPump[0];
                    int nextPumpDistance = currentPump[1];

                    fuel += pumpFuel - nextPumpDistance;

                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        isSolution = false;
                        break;
                    }

                    queue.Enqueue(currentPump);
                    // т.е. след като сме проверили за тази станция и връщаме в редицата, за д апочнем наново ако трябва
                }
                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    //Environment.Exit(0);
                    return;
                }
            }
        }
    }
}
