using System;


namespace Lab3
{
    public class DijkstrasAlgorithm
    {
        public readonly Vertice[] Vertices;
        private readonly int[,] _distanceMatrix;

        public DijkstrasAlgorithm(int[,] distanceMatrix)
        {
            Vertices = new Vertice[distanceMatrix.GetLength(0)];
            for (int i = 0; i < Vertices.Length; i++)
            {
                Vertices[i] = new();
            }
            _distanceMatrix = distanceMatrix;
        }
        public bool FindRoute(int startPointIndex, int endPointIndex)
        {
            PriorityQueue queue = new();
            Vertices[startPointIndex].MinDistance = 0;
            queue.Push(startPointIndex, 0);
            while (queue.Count > 0)
            {
                int currentVertice = queue.Pop();
                if (currentVertice == endPointIndex)
                {
                    return true;
                }
                for (int i = 0; i<Vertices.Length; i++)
                {
                    if (_distanceMatrix[currentVertice,i]==Int32.MaxValue || currentVertice==i || Vertices[i].Passed) continue;
                    if (Vertices[i].MinDistance >
                        Vertices[currentVertice].MinDistance + _distanceMatrix[currentVertice,i])
                    {
                        Vertices[i].MinDistance =
                            Vertices[currentVertice].MinDistance + _distanceMatrix[currentVertice,i];
                        Vertices[i].Previous = currentVertice;
                    }
                    if (!Vertices[i].Passed)
                    {
                        queue.Push(i, Vertices[i].MinDistance);
                    }
                }

                Vertices[currentVertice].Passed = true;
                
            }
            return false;
        }

        public Stack <int> TraceRoute(int finishIndex)
        {
            Stack <int> route = new();
            int current = finishIndex;
            while (current > -1)
            {
                route.Push(current);
                current = Vertices[current].Previous;
            }

            return route;
        }
    }
}