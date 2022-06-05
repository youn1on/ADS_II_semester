using System;

namespace Lab3
{
    public class DisplayOperations
    {
        public static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    
                    Console.Write((matrix[i,j] == int.MaxValue?"inf":$"{matrix[i,j],-3}") + " ");
                }

                Console.WriteLine();
            }
        }
    }
}