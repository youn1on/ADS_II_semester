using System;

namespace Lab4
{
    public class DisplayOperations
    {
        public static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    
                    Console.Write((matrix[i,j] == int.MaxValue/2?"inf":$"{matrix[i,j],-3}") + " ");
                }

                Console.WriteLine();
            }
        }

        public static string TracePath(int[,] pathMatrix, int startPoint, int endPoint)
        {
            if (pathMatrix[startPoint, endPoint] >= Int32.MaxValue / 2) return "";
            string path = (endPoint+1).ToString();
            int iterativeVertice = endPoint;
            while (iterativeVertice!=startPoint)
            {
                iterativeVertice = pathMatrix[startPoint, iterativeVertice];
                path = (iterativeVertice + 1) + " -> " + path;
            }

            return path;
        }
    }
}