using System;
using System.Linq;

namespace P08.RadioactiveBunnies
{
    class RadioactiveBunnies
    {
        public enum Status {alive, won, dead}
        public static Status playerStatus;


        static void Main()      // 80/100
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //1.
            var matrix = GetMatrix(sizes);
                        
            var comands = Console.ReadLine().ToCharArray();
            for (int i = 0; i < comands.Length; i++)
            {
                char command = comands[i];
                //2.
                int[] playerPosition = GetPlayerPosition(matrix);
                int playerRowPosition = playerPosition[0];
                int playerColPosition = playerPosition[1];
                // 3.
                matrix = PlayerMovie(matrix, ref playerRowPosition, ref playerColPosition, command);

                // 4.
                matrix = BunnyMovies(matrix);

                if (playerStatus == Status.dead || playerStatus == Status.won)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"{playerStatus}: {playerRowPosition} {playerColPosition}");
                    break;
                }
            }

        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i <matrix.Length; i++)
            {
                Console.WriteLine(String.Join("", matrix[i]));
            }
        }

        private static char[][] BunnyMovies(char[][] matrix)
        {
            char[][] tempMatrix = new char[matrix.Length][];
            for (int r = 0; r < matrix.Length; r++)
            {
                tempMatrix[r] = new char[matrix[0].Length];
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    tempMatrix[r][c] = matrix[r][c];
                }
            }

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    if (matrix[r][c] == 'B')
                    {
                        if (r > 0)
                        {
                            if (matrix[r][c] == 'P')
                            {
                                playerStatus = Status.dead;
                            }
                            tempMatrix[r - 1][c] = 'B';
                        }
                        if (r < matrix.Length - 1)
                        {
                            if (matrix[r][c] == 'P')
                            {
                                playerStatus = Status.dead;
                            }
                            tempMatrix[r + 1][c] = 'B';
                        }
                        if (c > 0)
                        {
                            if (matrix[r][c] == 'P')
                            {
                                playerStatus = Status.dead;
                            }
                            tempMatrix[r][c - 1] = 'B';
                        }
                        if (c < matrix[0].Length - 1)
                        {
                            if (matrix[r][c] == 'P')
                            {
                                playerStatus = Status.dead;
                            }
                            tempMatrix[r][c + 1] = 'B';
                        }
                    }
                }
            }
            return tempMatrix;
        }

        private static char[][] PlayerMovie(char[][] matrix, ref int playerRowPosition, ref int playerColPosition, char command)
        {
         
            switch (command)
            {
                case 'U':
                    if(playerRowPosition==0)
                    {
                        playerStatus = Status.won;
                        matrix[playerRowPosition][playerColPosition] = '.';
                    }
                    else
                    {
                        if(matrix[playerRowPosition-1][playerColPosition] == 'B')
                        {
                            playerStatus = Status.dead;
                        }
                        else
                        {
                            matrix[playerRowPosition - 1][playerColPosition] = 'P';
                            matrix[playerRowPosition][playerColPosition] = '.';
                        }
                        playerRowPosition--;
                    }                   
                    break;

                case 'D':
                    if (playerRowPosition == matrix.Length - 1)
                    {
                        playerStatus = Status.won;
                        matrix[playerRowPosition][playerColPosition] = '.';
                    }
                    else
                    {
                        if (matrix[playerRowPosition + 1][playerColPosition] == 'B')
                        {
                            playerStatus = Status.dead;
                        }
                        else
                        {
                            matrix[playerRowPosition + 1][playerColPosition] = 'P';
                            matrix[playerRowPosition][playerColPosition] = '.';
                        }
                        playerRowPosition++;
                    }
                    break;

                case 'L':
                    if (playerColPosition == 0)
                    {
                        playerStatus = Status.won;
                        matrix[playerRowPosition][playerColPosition] = '.';
                    }
                    else
                    {
                        if (matrix[playerRowPosition][playerColPosition - 1] == 'B')
                        {
                            playerStatus = Status.dead;
                        }
                        else
                        {
                            matrix[playerRowPosition][playerColPosition - 1] = 'P';
                            matrix[playerRowPosition][playerColPosition] = '.';
                        }
                        playerColPosition--;
                    }
                    break;

                case 'R':
                    if (playerColPosition == matrix[0].Length - 1)
                    {
                        playerStatus = Status.won;
                        matrix[playerRowPosition][playerColPosition] = '.';
                    }
                    else
                    {
                        if (matrix[playerRowPosition][playerColPosition + 1] == 'B')
                        {
                            playerStatus = Status.dead;
                        }
                        else
                        {
                            matrix[playerRowPosition][playerColPosition + 1] = 'P';
                            matrix[playerRowPosition][playerColPosition] = '.';
                        }
                        playerColPosition++;
                    }
                    break;
            }

            return matrix;
        }
    

        private static int[] GetPlayerPosition(char[][] matrix)
        {
            int[] playerposition = new int[2];

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    if (matrix[r][c] == 'P')
                    {
                        playerposition[0] = r;
                        playerposition[1] = c;
                    }
                }
            }
            return playerposition;
        }

        private static char[][] GetMatrix(int[] sizes)
        {
            var rows = sizes[0];
            var cols = sizes[1];
            var matrix = new char[rows][];

            for (int r = 0; r < rows; r++)
            {
                matrix[r] = Console.ReadLine().ToCharArray();
            }

            return matrix;
        }
    }
}
