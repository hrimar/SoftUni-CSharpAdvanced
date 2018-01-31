using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.ParkingSystem
{
    class ParkingSystem
    {
        static void Main()  // 100/100 - РЕШИ Я ПАК!!!
        {
            // решението с масив дава само 30/100- трябва друга структора от данни!:
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            var parking = new Dictionary<int, HashSet<int>>();

            var input = Console.ReadLine();
            while (input != "stop")
            {
                var inputDetails = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                var entryRow = inputDetails[0];
                var desiredRow = inputDetails[1];
                var desiredCol = inputDetails[2];

                if (!IsPlaceOccupied(parking, desiredRow, desiredCol))
                {
                    OccupyPlace(parking, desiredRow, desiredCol);
                    int distance = Math.Abs(entryRow - desiredRow) + 1 + desiredCol;
                    Console.WriteLine(distance);
                }
                else
                {
                    desiredCol = TryFindFreeSpot(parking[desiredRow], cols, desiredCol);
                    if (desiredCol == 0)
                    {
                        Console.WriteLine($"Row {desiredRow} full");
                    }
                    else
                    {
                        OccupyPlace(parking, desiredRow, desiredCol);
                        int distance = Math.Abs(entryRow - desiredRow) + 1 + desiredCol;
                        Console.WriteLine(distance);
                    }
                }
                                                
                input = Console.ReadLine();
            }

        }

        private static int TryFindFreeSpot(HashSet<int> parkingRow, int cols, int desiredCol)
        {
            int minDistance = int.MaxValue;
            int resultCol = 0;

            if (parkingRow.Count == cols - 1)
            {
                return resultCol;
            }

            for (int col = 1; col < cols; col++)
            {
                int currentDistance = Math.Abs(desiredCol - col);
                if (!parkingRow.Contains(col) && currentDistance < minDistance)
                {
                    resultCol = col;
                    minDistance = currentDistance;
                }
            }

            return resultCol;
        }

        private static void OccupyPlace(Dictionary<int, HashSet<int>> parking, int desiredRow, int desiredCol)
        {
            if (!parking.ContainsKey(desiredRow))
            {
                parking.Add(desiredRow, new HashSet<int>());
            }

            parking[desiredRow].Add(desiredCol);
        }

        private static bool IsPlaceOccupied(Dictionary<int, HashSet<int>> parking, int desiredRow, int desiredCol)
        {
           var isOccupied = parking.ContainsKey(desiredRow) && parking[desiredRow].Contains(desiredCol);

            return isOccupied;
        }
    }
}
