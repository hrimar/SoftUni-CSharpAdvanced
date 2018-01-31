using System;

namespace P10.TheHeiganDance
{
    class TheHeiganDance  // 100/100
    {
        private const int MatrixSize = 15;
        private const int CloudDemage = 3500;
        private const int EruptionDemage = 6000;
        private const double PlayerHelth = 18500;
        private const double HeiganHelth = 3000000;

        static void Main()
        {
            var matrix = GetMatrix();

            var playerPos = new int[] { MatrixSize / 2, MatrixSize / 2 };
            var heiganPoints = HeiganHelth;
            var playerPoints = PlayerHelth;

            bool isHeiganDeath = false;
            bool isPlayerDeath = false;
            bool hasCloud = false;
            var deathCause = string.Empty;

            var demageToHeigan = double.Parse(Console.ReadLine());

            while (true)
            {
                var tokens = Console.ReadLine().Split();
                var spell = tokens[0];
                var spellRow = int.Parse(tokens[1]);
                var spellCol = int.Parse(tokens[2]);

                heiganPoints -= demageToHeigan;
                isHeiganDeath = heiganPoints <= 0;  // !
                isPlayerDeath = playerPoints <= 0;

                if (hasCloud)
                {
                    playerPoints -= CloudDemage;
                    hasCloud = false;
                    isPlayerDeath = playerPoints <= 0;  // ! ако е така става true
                }

                if (isHeiganDeath || isPlayerDeath) // true || true => true
                {
                    break;
                }

                if (IsPlayerInDemegedZone(playerPos, spellRow, spellCol))
                {
                    if (!PlayerTryEscape(playerPos, spellRow, spellCol))   // !
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerPoints -= CloudDemage;
                                hasCloud = true;
                                deathCause = "Plague Cloud";
                                break;
                            case "Eruption":
                                playerPoints -= EruptionDemage;
                                deathCause = spell;
                                break;
                        }
                    }
                }

                isPlayerDeath = playerPoints <= 0;  // ! ако е така става true
                if (isPlayerDeath)
                {
                    break;
                }
            }

            PrintResult(playerPos, heiganPoints, playerPoints, deathCause);
        }

        private static void PrintResult(int[] playerPos, double heiganPoints, double playerPoints, string deathCause)
        {
            if (heiganPoints <= 0)
            {
                Console.WriteLine($"Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganPoints:f2}");
            }

            if (playerPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {deathCause}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoints}");
            }

            Console.WriteLine($"Final position: {playerPos[0]}, {playerPos[1]}");
        }

        // метод за местене на играча:
        private static bool PlayerTryEscape(int[] playerPos, int spellRow, int spellCol)
        {
            if (playerPos[0] - 1 >= 0 && playerPos[0] - 1 < spellRow - 1)
            {
                playerPos[0]--;
                return true;
            }
            else if (playerPos[1] + 1 < MatrixSize && playerPos[1] + 1 > spellCol + 1)
            {
                playerPos[1]++;
                return true;
            }
            else if (playerPos[0] + 1 < MatrixSize && playerPos[0] + 1 > spellRow + 1)
            {
                playerPos[0]++;
                return true;
            }
            else if (playerPos[1] - 1 >= 0 && playerPos[1] - 1 < spellCol - 1)
            {
                playerPos[1]--;
                return true;
            }
            return false;
        }

        private static bool IsPlayerInDemegedZone(int[] playerPos, int spellRow, int spellCol)
        {
            //bool isHitRow = playerPos[0] >= spellRow - 1 && playerPos[0] <= spellRow + 1;
            //bool isHitCol = playerPos[1] >= spellCol - 1 && playerPos[1] <= spellCol + 1;

            //return isHitRow && isHitCol;

            // или:
            if (playerPos[0] >= spellRow - 1 && playerPos[0] <= spellRow + 1 &&
                playerPos[1] >= spellCol - 1 && playerPos[1] <= spellCol + 1)
            {
                return true;
            }
            return false;
        }

        private static int[][] GetMatrix()
        {
            int startCell = 1;
            var matrix = new int[15][];
            for (int r = 0; r < 15; r++)
            {
                matrix[r] = new int[15];
                for (int c = 0; c < 15; c++)
                {
                    matrix[r][c] = startCell;
                    startCell++;
                }
            }
            return matrix;
        }
    }
}
