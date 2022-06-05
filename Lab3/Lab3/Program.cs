using System;

namespace Lab3
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
           (int startPoint, int endPoint) = InputOperations.GetEntryPointsIndexes();

           DijkstrasAlgorithm algorithm = new DijkstrasAlgorithm(matrix);
           bool IsFound = algorithm.FindRoute(startPoint, endPoint);
           if (IsFound)
           {
               Stack<int> stack = algorithm.TraceRoute(endPoint);
               Console.WriteLine("Path found: ");
               Console.WriteLine(GetPath(stack));
               Console.WriteLine("Path length is " + algorithm.Vertices[endPoint].MinDistance);
           }
           else
           {
               Console.WriteLine("No path found");
           }

        }

        public static string GetPath(Stack<int> stack)
        {
            string path = "" + (stack.Pop()+1);
            while (stack.Count > 0)
            {
                path += " -> " + (stack.Pop()+1);
            }
            return path;
        }
    }
}