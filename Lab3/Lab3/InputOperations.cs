using System;

namespace Lab3
{
    public class InputOperations
    {
        public static int GetDimensions()
        {
            while (true)
            {
                Console.WriteLine("Enter your graph size");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int x))
                {
                    return x;
                }
            }
        }

        public static bool IsRandomized()
        {
            Console.WriteLine("Do you want to fill the matrix randomly (r) or manually (m) ? ");
            while (true)
            {
                string answer = Console.ReadLine();
                if (answer == "r")
                {
                    return true;
                }

                if (answer == "m")
                {
                    return false;
                }

                Console.WriteLine("Incorrect input. Try again...");
            }
        }

        public static int[,] GetManualInput(int n)
        {
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                     matrix[i, j] = int.MaxValue;
                }

                while (true)
                {
                    Console.WriteLine($"Enter adjacent vertice's number to vertice {i + 1}:");
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input)) break;
                    if (int.TryParse(input, out int adjacentVertice) && adjacentVertice <= n && adjacentVertice > 0)
                    {
                        if (adjacentVertice == i)
                        {
                            Console.WriteLine("Distance must be 0");
                            continue;
                        }
                        while (true)
                        {
                            Console.WriteLine($"Enter your distance between {i+1} and {adjacentVertice} ");
                            string distanceInput = Console.ReadLine();
                            if (int.TryParse(distanceInput, out int distance))
                            {
                                matrix[i, adjacentVertice-1] = distance;
                                break;
                            }
                            Console.WriteLine("Incorrect input");
                        }
                    }
                    else Console.WriteLine("Incorrect input");
                }
            }

            return matrix;
        }

        public static (int, int) GetEntryPointsIndexes()
        {
            Console.WriteLine("Enter startpoint and endpoint indexes, separated by ',' : ");
            while (true)
            {
                string input = Console.ReadLine();
                string[] points = input.Split(",");
                if (points.Length == 2 && int.TryParse(points[0], out int startPoint) && int.TryParse(points[1], out int endPoint))
                {
                    return (startPoint-1, endPoint-1);
                }
                Console.WriteLine("Incorrect input");
            }
        }

    }
}