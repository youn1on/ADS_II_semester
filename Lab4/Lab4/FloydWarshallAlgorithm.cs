using System;
using System.IO;

namespace Lab4
{
    public class FloydWarshallAlgorithm
    {
        public static int[,] GetPathMatrix(ref int[,] matrix)
        {
            int[,] pathMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < pathMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < pathMatrix.GetLength(1) ; j++)
                {
                    if (matrix[i, j] is > 0 and < int.MaxValue/2) pathMatrix[i, j] = i;
                }
            }
            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (i == m) continue;
                    for (int j = 0; j < matrix.GetLength(1) ; j++)
                    {
                        if(i == j || j == m) continue;
                        if (matrix[i, m] + matrix[m, j] < matrix[i, j])
                        {
                            pathMatrix[i, j] = m;
                            matrix[i, j] = matrix[i, m] + matrix[m, j];
                        }
                    }
                }
            }
            return pathMatrix;
        }
    }
}