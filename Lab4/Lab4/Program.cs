using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
           int n = InputOperations.GetDimensions();
           int[,] matrix;
           if (InputOperations.IsRandomized())
           {
               matrix = MatrixRandomizer.CreateRandomMatrix(n);
           }
           else
           {
               matrix = InputOperations.GetManualInput(n);
           }
           DisplayOperations.DisplayMatrix(matrix);
           int[,] pathMatrix = FloydWarshallAlgorithm.GetPathMatrix(ref matrix);
           Console.WriteLine("New matrix:");
           DisplayOperations.DisplayMatrix(matrix);
           (int startPoint, int endPoint) = InputOperations.GetEntryPointsIndexes(n);
           if (matrix[startPoint, endPoint] < Int32.MaxValue / 2)
           {
               Console.WriteLine($"Distance is {matrix[startPoint,endPoint]}");
               Console.WriteLine("Path: "+DisplayOperations.TracePath(pathMatrix, startPoint, endPoint));
           }
           else Console.WriteLine("No path found..");
        }
    }
}