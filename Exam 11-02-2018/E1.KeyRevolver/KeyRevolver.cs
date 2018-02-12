using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace E1.KeyRevolver
{
    class KeyRevolver
    {
        static void Main()  // 100/100
        {
            int bulletPrice = int.Parse(Console.ReadLine()); // br patroni
            int sizeOfBullet = int.Parse(Console.ReadLine()); // br patroni
            var buletSize = sizeOfBullet;

            var bulletsArray = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var bulletsStack = new Stack<int>(bulletsArray);

            var locksArray = Console.ReadLine()
             .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();
            var locksQueue =new Queue<int>(locksArray);
           
            int value = int.Parse(Console.ReadLine()); // br patroni

            while (locksQueue.Count()>0 && bulletsStack.Count()>0)
            {
                int currentBullet = bulletsStack.Peek();
                int currentLock = locksQueue.Peek();
                if(currentLock>=currentBullet)
                {
                    Console.WriteLine("Bang!");
                     locksQueue.Dequeue();
                    bulletsStack.Pop();
                    //sizeOfBullet--;
                    value -= bulletPrice;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletsStack.Pop();
                    //sizeOfBullet--;
                    value -= bulletPrice;
                }
                sizeOfBullet--;

                if (sizeOfBullet ==0)
                {
                    if (bulletsStack.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                         Console.WriteLine("Reloading!");
                        sizeOfBullet = buletSize;
                    }
                   
                }
            }

            if(locksQueue.Count>bulletsStack.Count)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${value}");
            }
        }
    }
}
