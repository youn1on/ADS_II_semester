using System;

namespace Lab3
{
    public class MatrixRandomizer
    {
        public static int[,] CreateRandomMatrix(int n)
        {
            Random rand = new Random();
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) matrix[i, j] = 0;
                    else matrix[i, j] = rand.Next(2) == 0 ? rand.Next(10, 50) : Int32.MaxValue;
                }
            }
            return matrix;
        }
    }
}